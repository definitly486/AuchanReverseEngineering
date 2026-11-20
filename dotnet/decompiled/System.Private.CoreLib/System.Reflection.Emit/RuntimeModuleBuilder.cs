using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeModuleBuilder : ModuleBuilder
{
	internal nint _impl;

	internal Assembly assembly;

	internal string fqname;

	internal string name;

	internal string scopename;

	internal bool is_resource;

	internal int token;

	private nuint dynamic_image;

	private int num_types;

	private RuntimeTypeBuilder[] types;

	private CustomAttributeBuilder[] cattrs;

	private int table_idx;

	internal RuntimeAssemblyBuilder assemblyb;

	private object[] global_methods;

	private object[] global_fields;

	private bool is_main;

	private object resources;

	private nint unparented_classes;

	private int[] table_indexes;

	private byte[] guid;

	private RuntimeTypeBuilder global_type;

	private bool global_type_created;

	private Dictionary<ITypeName, RuntimeTypeBuilder> name_cache;

	private Dictionary<string, int> us_string_cache;

	private ModuleBuilderTokenGenerator token_gen;

	private static int typeref_tokengen = 33554431;

	private static int typedef_tokengen = 50331647;

	private static int typespec_tokengen = 469762047;

	private static int memberref_tokengen = 184549375;

	private static int methoddef_tokengen = 117440511;

	private Dictionary<MemberInfo, int> inst_tokens;

	private Dictionary<MemberInfo, int> inst_tokens_open;

	[RequiresAssemblyFiles("Returns <Unknown> for modules with no file path")]
	public override string FullyQualifiedName
	{
		get
		{
			string text = fqname;
			if (text == null)
			{
				return null;
			}
			return text;
		}
	}

	public override Assembly Assembly => assemblyb;

	[RequiresAssemblyFiles("Returns <Unknown> for modules with no file path")]
	public override string Name => name;

	public override string ScopeName => name;

	public override Guid ModuleVersionId => new Guid(guid);

	public override int MetadataToken => RuntimeModule.get_MetadataToken(this);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void basic_init(RuntimeModuleBuilder ab);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_wrappers_type(RuntimeModuleBuilder mb, Type ab);

	internal RuntimeModuleBuilder(RuntimeAssemblyBuilder assb, string name)
	{
		this.name = (scopename = name);
		fqname = name;
		assembly = (assemblyb = assb);
		guid = Guid.NewGuid().ToByteArray();
		table_idx = get_next_table_index(0, 1);
		name_cache = new Dictionary<ITypeName, RuntimeTypeBuilder>();
		us_string_cache = new Dictionary<string, int>(512);
		global_type_created = false;
		basic_init(this);
		CreateGlobalType();
		Type ab = new RuntimeTypeBuilder(this, TypeAttributes.Abstract, 16777215).CreateTypeInfo();
		set_wrappers_type(this, ab);
	}

	protected override void CreateGlobalFunctionsCore()
	{
		if (global_type_created)
		{
			throw new InvalidOperationException("InvalidOperation_GlobalsHaveBeenCreated");
		}
		if (global_type != null)
		{
			global_type_created = true;
			global_type.CreateTypeInfo();
		}
	}

	protected override FieldBuilder DefineInitializedDataCore(string name, byte[] data, FieldAttributes attributes)
	{
		ArgumentNullException.ThrowIfNull(data, "data");
		FieldAttributes fieldAttributes = attributes & ~FieldAttributes.ReservedMask;
		RuntimeFieldBuilder obj = (RuntimeFieldBuilder)DefineDataImpl(name, data.Length, fieldAttributes | FieldAttributes.HasFieldRVA);
		obj.SetRVAData(data);
		return obj;
	}

	protected override FieldBuilder DefineUninitializedDataCore(string name, int size, FieldAttributes attributes)
	{
		return DefineDataImpl(name, size, attributes & ~FieldAttributes.ReservedMask);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Reflection.Emit is not subject to trimming")]
	private FieldBuilder DefineDataImpl(string name, int size, FieldAttributes attributes)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		if (global_type_created)
		{
			throw new InvalidOperationException("InvalidOperation_GlobalsHaveBeenCreated");
		}
		if (size <= 0 || size >= 4128768)
		{
			throw new ArgumentException("Argument_BadSizeForData", (string?)null);
		}
		CreateGlobalType();
		string className = "$ArrayType$" + size;
		Type type = GetType(className, throwOnError: false, ignoreCase: false);
		if (type == null)
		{
			RuntimeTypeBuilder runtimeTypeBuilder = DefineType(className, TypeAttributes.Public | TypeAttributes.ExplicitLayout | TypeAttributes.Sealed, typeof(ValueType), null, RuntimeFieldBuilder.RVADataPackingSize(size), size);
			runtimeTypeBuilder.CreateType();
			type = runtimeTypeBuilder;
		}
		FieldBuilder fieldBuilder = global_type.DefineField(name, type, attributes | FieldAttributes.Static);
		if (global_fields != null)
		{
			FieldBuilder[] array = new FieldBuilder[global_fields.Length + 1];
			Array.Copy(global_fields, array, global_fields.Length);
			array[global_fields.Length] = fieldBuilder;
			object[] array2 = array;
			global_fields = array2;
		}
		else
		{
			object[] array2 = new FieldBuilder[1] { fieldBuilder };
			global_fields = array2;
		}
		return fieldBuilder;
	}

	private void addGlobalMethod(MethodBuilder mb)
	{
		if (global_methods != null)
		{
			MethodBuilder[] array = new MethodBuilder[global_methods.Length + 1];
			Array.Copy(global_methods, array, global_methods.Length);
			array[global_methods.Length] = mb;
			object[] array2 = array;
			global_methods = array2;
		}
		else
		{
			object[] array2 = new MethodBuilder[1] { mb };
			global_methods = array2;
		}
	}

	protected override MethodBuilder DefineGlobalMethodCore(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] requiredReturnTypeCustomModifiers, Type[] optionalReturnTypeCustomModifiers, Type[] parameterTypes, Type[][] requiredParameterTypeCustomModifiers, Type[][] optionalParameterTypeCustomModifiers)
	{
		if ((attributes & MethodAttributes.Static) == 0)
		{
			throw new ArgumentException("Argument_GlobalMembersMustBeStatic");
		}
		if (global_type_created)
		{
			throw new InvalidOperationException("InvalidOperation_GlobalsHaveBeenCreated");
		}
		CreateGlobalType();
		MethodBuilder methodBuilder = global_type.DefineMethod(name, attributes, callingConvention, returnType, requiredReturnTypeCustomModifiers, optionalReturnTypeCustomModifiers, parameterTypes, requiredParameterTypeCustomModifiers, optionalParameterTypeCustomModifiers);
		addGlobalMethod(methodBuilder);
		return methodBuilder;
	}

	[RequiresUnreferencedCode("P/Invoke marshalling may dynamically access members that could be trimmed.")]
	protected override MethodBuilder DefinePInvokeMethodCore(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		if ((attributes & MethodAttributes.Static) == 0)
		{
			throw new ArgumentException("Argument_GlobalMembersMustBeStatic");
		}
		if (global_type_created)
		{
			throw new InvalidOperationException("InvalidOperation_GlobalsHaveBeenCreated");
		}
		CreateGlobalType();
		MethodBuilder methodBuilder = global_type.DefinePInvokeMethod(name, dllName, entryName, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet);
		addGlobalMethod(methodBuilder);
		return methodBuilder;
	}

	private void AddType(RuntimeTypeBuilder tb)
	{
		if (types != null)
		{
			if (types.Length == num_types)
			{
				RuntimeTypeBuilder[] destinationArray = new RuntimeTypeBuilder[types.Length * 2];
				Array.Copy(types, destinationArray, num_types);
				types = destinationArray;
			}
		}
		else
		{
			types = new RuntimeTypeBuilder[1];
		}
		types[num_types] = tb;
		num_types++;
	}

	private RuntimeTypeBuilder DefineType(string name, TypeAttributes attr, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type parent, Type[] interfaces, PackingSize packingSize, int typesize)
	{
		ITypeIdentifier key = TypeIdentifiers.FromInternal(name);
		if (name_cache.ContainsKey(key))
		{
			throw new ArgumentException("Argument_DuplicateTypeName");
		}
		RuntimeTypeBuilder runtimeTypeBuilder = new RuntimeTypeBuilder(this, name, attr, parent, interfaces, packingSize, typesize, null);
		AddType(runtimeTypeBuilder);
		name_cache.Add(key, runtimeTypeBuilder);
		return runtimeTypeBuilder;
	}

	internal void RegisterTypeName(RuntimeTypeBuilder tb, ITypeName name)
	{
		name_cache.Add(name, tb);
	}

	internal RuntimeTypeBuilder GetRegisteredType(ITypeName name)
	{
		name_cache.TryGetValue(name, out var value);
		return value;
	}

	protected override TypeBuilder DefineTypeCore(string name, TypeAttributes attr, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type parent, Type[] interfaces, PackingSize packingSize, int typesize)
	{
		return DefineType(name, attr, parent, interfaces, packingSize, typesize);
	}

	protected override MethodInfo GetArrayMethodCore(Type arrayClass, string methodName, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
	{
		return new MonoArrayMethod(arrayClass, methodName, callingConvention, returnType, parameterTypes);
	}

	protected override EnumBuilder DefineEnumCore(string name, TypeAttributes visibility, Type underlyingType)
	{
		ITypeIdentifier key = TypeIdentifiers.FromInternal(name);
		if (name_cache.ContainsKey(key))
		{
			throw new ArgumentException("Argument_DuplicateTypeName");
		}
		RuntimeEnumBuilder runtimeEnumBuilder = new RuntimeEnumBuilder(this, name, visibility, underlyingType);
		RuntimeTypeBuilder typeBuilder = runtimeEnumBuilder.GetTypeBuilder();
		AddType(typeBuilder);
		name_cache.Add(key, typeBuilder);
		return runtimeEnumBuilder;
	}

	[RequiresUnreferencedCode("Types might be removed by trimming. If the type name is a string literal, consider using Type.GetType instead.")]
	public override Type GetType(string className)
	{
		return GetType(className, throwOnError: false, ignoreCase: false);
	}

	[RequiresUnreferencedCode("Types might be removed by trimming. If the type name is a string literal, consider using Type.GetType instead.")]
	public override Type GetType(string className, bool ignoreCase)
	{
		return GetType(className, throwOnError: false, ignoreCase);
	}

	private static RuntimeTypeBuilder search_in_array(RuntimeTypeBuilder[] arr, int validElementsInArray, ITypeName className)
	{
		for (int i = 0; i < validElementsInArray; i++)
		{
			if (string.Compare(className.DisplayName, arr[i].FullName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
			{
				return arr[i];
			}
		}
		return null;
	}

	private static RuntimeTypeBuilder search_nested_in_array(RuntimeTypeBuilder[] arr, int validElementsInArray, ITypeName className)
	{
		for (int i = 0; i < validElementsInArray; i++)
		{
			if (string.Compare(className.DisplayName, arr[i].Name, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
			{
				return arr[i];
			}
		}
		return null;
	}

	private static RuntimeTypeBuilder GetMaybeNested(RuntimeTypeBuilder t, IEnumerable<ITypeName> nested)
	{
		RuntimeTypeBuilder runtimeTypeBuilder = t;
		foreach (ITypeName item in nested)
		{
			if (runtimeTypeBuilder.subtypes == null)
			{
				return null;
			}
			runtimeTypeBuilder = search_nested_in_array(runtimeTypeBuilder.subtypes, runtimeTypeBuilder.subtypes.Length, item);
			if (runtimeTypeBuilder == null)
			{
				return null;
			}
		}
		return runtimeTypeBuilder;
	}

	[RequiresUnreferencedCode("Types might be removed by trimming. If the type name is a string literal, consider using Type.GetType instead.")]
	public override Type GetType(string className, bool throwOnError, bool ignoreCase)
	{
		ArgumentException.ThrowIfNullOrEmpty(className, "className");
		RuntimeTypeBuilder value = null;
		if (types == null && throwOnError)
		{
			throw new TypeLoadException(className);
		}
		TypeSpec typeSpec = TypeSpec.Parse(className);
		if (!ignoreCase)
		{
			ITypeName key = typeSpec.TypeNameWithoutModifiers();
			name_cache.TryGetValue(key, out value);
		}
		else
		{
			if (types != null)
			{
				value = search_in_array(types, num_types, typeSpec.Name);
			}
			if (!typeSpec.IsNested && value != null)
			{
				value = GetMaybeNested(value, typeSpec.Nested);
			}
		}
		if (value == null && throwOnError)
		{
			throw new TypeLoadException(className);
		}
		if (value != null && (typeSpec.HasModifiers || typeSpec.IsByRef))
		{
			Type type = value;
			if ((object)value != null)
			{
				RuntimeTypeBuilder runtimeTypeBuilder = value;
				if (runtimeTypeBuilder.is_created)
				{
					type = runtimeTypeBuilder.CreateType();
				}
			}
			foreach (IModifierSpec modifier in typeSpec.Modifiers)
			{
				if (modifier is PointerSpec)
				{
					type = type.MakePointerType();
				}
				else if (modifier is IArraySpec)
				{
					IArraySpec arraySpec = modifier as IArraySpec;
					if (arraySpec.IsBound)
					{
						return null;
					}
					type = ((arraySpec.Rank != 1) ? type.MakeArrayType(arraySpec.Rank) : type.MakeArrayType());
				}
			}
			if (typeSpec.IsByRef)
			{
				type = type.MakeByRefType();
			}
			value = type as RuntimeTypeBuilder;
			if (value == null)
			{
				return type;
			}
		}
		if (value != null && value.is_created)
		{
			return value.CreateType();
		}
		return value;
	}

	internal int get_next_table_index(int table, int count)
	{
		if (table_indexes == null)
		{
			table_indexes = new int[64];
			for (int i = 0; i < 64; i++)
			{
				table_indexes[i] = 1;
			}
			table_indexes[2] = 2;
		}
		int result = table_indexes[table];
		table_indexes[table] += count;
		return result;
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(con, binaryAttribute);
		if (cattrs != null)
		{
			CustomAttributeBuilder[] array = new CustomAttributeBuilder[cattrs.Length + 1];
			cattrs.CopyTo(array, 0);
			array[cattrs.Length] = customAttributeBuilder;
			cattrs = array;
		}
		else
		{
			cattrs = new CustomAttributeBuilder[1];
			cattrs[0] = customAttributeBuilder;
		}
	}

	[RequiresUnreferencedCode("Types might be removed")]
	public override Type[] GetTypes()
	{
		if (types == null)
		{
			return Type.EmptyTypes;
		}
		int num = num_types;
		Type[] array = new Type[num];
		Array.Copy(types, array, num);
		for (int i = 0; i < array.Length; i++)
		{
			if (types[i].is_created)
			{
				array[i] = types[i].CreateType();
			}
		}
		return array;
	}

	public override int GetMethodMetadataToken(MethodInfo method)
	{
		ArgumentNullException.ThrowIfNull(method, "method");
		return method.MetadataToken;
	}

	public override int GetMethodMetadataToken(ConstructorInfo constructor)
	{
		ArgumentNullException.ThrowIfNull(constructor, "constructor");
		return constructor.MetadataToken;
	}

	public override int GetFieldMetadataToken(FieldInfo field)
	{
		ArgumentNullException.ThrowIfNull(field, "field");
		return field.MetadataToken;
	}

	internal static Module GetRuntimeModuleFromModule(Module m)
	{
		if (m is ModuleBuilder)
		{
			return m;
		}
		return m as RuntimeModule;
	}

	public override int GetSignatureMetadataToken(SignatureHelper signature)
	{
		ArgumentNullException.ThrowIfNull(signature, "signature");
		return GetToken(signature);
	}

	public override int GetStringMetadataToken(string stringConstant)
	{
		ArgumentNullException.ThrowIfNull(stringConstant, "stringConstant");
		return GetToken(stringConstant);
	}

	public override int GetTypeMetadataToken(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		if (type.IsByRef)
		{
			throw new ArgumentException("Argument_CannotBeByRefType", "type");
		}
		return type.MetadataToken;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int getUSIndex(RuntimeModuleBuilder mb, string str);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int getToken(RuntimeModuleBuilder mb, object obj, bool create_open_instance);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int getMethodToken(RuntimeModuleBuilder mb, MethodBase method, Type[] opt_param_types);

	internal int GetToken(string str)
	{
		if (!us_string_cache.TryGetValue(str, out var value))
		{
			value = getUSIndex(this, str);
			us_string_cache[str] = value;
		}
		return value;
	}

	private int GetPseudoToken(MemberInfo member, bool create_open_instance)
	{
		Dictionary<MemberInfo, int> dictionary = (create_open_instance ? inst_tokens_open : inst_tokens);
		int value;
		if (dictionary == null)
		{
			dictionary = new Dictionary<MemberInfo, int>(ReferenceEqualityComparer.Instance);
			if (create_open_instance)
			{
				inst_tokens_open = dictionary;
			}
			else
			{
				inst_tokens = dictionary;
			}
		}
		else if (dictionary.TryGetValue(member, out value))
		{
			return value;
		}
		if (member is TypeBuilderInstantiation || member is SymbolType)
		{
			value = typespec_tokengen--;
		}
		else if (member is FieldOnTypeBuilderInstantiation)
		{
			value = memberref_tokengen--;
		}
		else if (member is ConstructorOnTypeBuilderInstantiation)
		{
			value = memberref_tokengen--;
		}
		else if (member is MethodOnTypeBuilderInstantiation)
		{
			value = memberref_tokengen--;
		}
		else if (member is FieldBuilder)
		{
			value = memberref_tokengen--;
		}
		else if (member is TypeBuilder typeBuilder)
		{
			value = ((create_open_instance && typeBuilder.ContainsGenericParameters) ? typespec_tokengen-- : ((!(member.Module == this)) ? typeref_tokengen-- : typedef_tokengen--));
		}
		else
		{
			if (member is RuntimeEnumBuilder runtimeEnumBuilder)
			{
				return dictionary[member] = GetPseudoToken(runtimeEnumBuilder.GetTypeBuilder(), create_open_instance);
			}
			if (member is RuntimeConstructorBuilder runtimeConstructorBuilder)
			{
				value = ((!(member.Module == this) || runtimeConstructorBuilder.TypeBuilder.ContainsGenericParameters) ? memberref_tokengen-- : methoddef_tokengen--);
			}
			else if (member is RuntimeMethodBuilder runtimeMethodBuilder)
			{
				value = ((!(member.Module == this) || runtimeMethodBuilder.TypeBuilder.ContainsGenericParameters || runtimeMethodBuilder.IsGenericMethodDefinition) ? memberref_tokengen-- : methoddef_tokengen--);
			}
			else
			{
				if (!(member is GenericTypeParameterBuilder))
				{
					throw new NotImplementedException();
				}
				value = typespec_tokengen--;
			}
		}
		dictionary[member] = value;
		RegisterToken(member, value);
		return value;
	}

	internal int GetToken(MemberInfo member)
	{
		if (member is ConstructorBuilder || member is MethodBuilder || member is FieldBuilder)
		{
			return GetPseudoToken(member, create_open_instance: false);
		}
		return getToken(this, member, create_open_instance: true);
	}

	internal int GetToken(MemberInfo member, bool create_open_instance)
	{
		if (member is TypeBuilderInstantiation || member is FieldOnTypeBuilderInstantiation || member is ConstructorOnTypeBuilderInstantiation || member is MethodOnTypeBuilderInstantiation || member is SymbolType || member is FieldBuilder || member is TypeBuilder || member is ConstructorBuilder || member is MethodBuilder || member is GenericTypeParameterBuilder || member is EnumBuilder)
		{
			return GetPseudoToken(member, create_open_instance);
		}
		return getToken(this, member, create_open_instance);
	}

	internal int GetToken(MethodBase method, Type[] opt_param_types)
	{
		if (method is ConstructorBuilder || method is MethodBuilder)
		{
			return GetPseudoToken(method, create_open_instance: false);
		}
		return getMethodToken(this, method, opt_param_types);
	}

	internal int GetToken(SignatureHelper helper)
	{
		return getToken(this, helper, create_open_instance: true);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal extern void RegisterToken(object obj, int token);

	internal ITokenGenerator GetTokenGenerator()
	{
		return token_gen ?? (token_gen = new ModuleBuilderTokenGenerator(this));
	}

	internal static object RuntimeResolve(object obj)
	{
		if (obj is RuntimeMethodBuilder runtimeMethodBuilder)
		{
			return runtimeMethodBuilder.RuntimeResolve();
		}
		if (obj is RuntimeConstructorBuilder runtimeConstructorBuilder)
		{
			return runtimeConstructorBuilder.RuntimeResolve();
		}
		if (obj is RuntimeFieldBuilder runtimeFieldBuilder)
		{
			return runtimeFieldBuilder.RuntimeResolve();
		}
		if (obj is RuntimeGenericTypeParameterBuilder runtimeGenericTypeParameterBuilder)
		{
			return runtimeGenericTypeParameterBuilder.RuntimeResolve();
		}
		if (obj is FieldOnTypeBuilderInstantiation fieldOnTypeBuilderInstantiation)
		{
			return fieldOnTypeBuilderInstantiation.RuntimeResolve();
		}
		if (obj is MethodOnTypeBuilderInstantiation methodOnTypeBuilderInstantiation)
		{
			return methodOnTypeBuilderInstantiation.RuntimeResolve();
		}
		if (obj is ConstructorOnTypeBuilderInstantiation constructorOnTypeBuilderInstantiation)
		{
			return constructorOnTypeBuilderInstantiation.RuntimeResolve();
		}
		if (obj is Type type)
		{
			return type.RuntimeResolve();
		}
		throw new NotImplementedException(obj.GetType().FullName);
	}

	internal void CreateGlobalType()
	{
		if ((object)global_type == null)
		{
			global_type = new RuntimeTypeBuilder(this, TypeAttributes.NotPublic, 1, is_hidden_global_type: true);
		}
	}

	public override bool IsResource()
	{
		return false;
	}

	private protected override ModuleHandle GetModuleHandleImpl()
	{
		return new ModuleHandle(_impl);
	}

	[RequiresUnreferencedCode("Methods might be removed")]
	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		if (!global_type_created)
		{
			return null;
		}
		if (types == null)
		{
			return global_type.AsType().GetMethod(name);
		}
		return global_type.AsType().GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return RuntimeModule.ResolveField(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return RuntimeModule.ResolveMember(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return RuntimeModule.ResolveMethod(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override string ResolveString(int metadataToken)
	{
		return RuntimeModule.ResolveString(this, _impl, metadataToken);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override byte[] ResolveSignature(int metadataToken)
	{
		return RuntimeModule.ResolveSignature(this, _impl, metadataToken);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return RuntimeModule.ResolveType(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return base.IsDefined(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return CustomAttribute.GetCustomAttributesData(this);
	}

	[RequiresUnreferencedCode("Fields might be removed")]
	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		if (!global_type_created)
		{
			throw new InvalidOperationException("InvalidOperation_ModuleFieldsMethodsRelyOnCreateGlobalFunctionsMethod");
		}
		return global_type.AsType().GetField(name, bindingAttr);
	}

	[RequiresUnreferencedCode("Fields might be removed")]
	public override FieldInfo[] GetFields(BindingFlags bindingFlags)
	{
		if (!global_type_created)
		{
			throw new InvalidOperationException("InvalidOperation_ModuleFieldsMethodsRelyOnCreateGlobalFunctionsMethod");
		}
		return global_type.AsType().GetFields(bindingFlags);
	}

	[RequiresUnreferencedCode("Methods might be removed")]
	public override MethodInfo[] GetMethods(BindingFlags bindingFlags)
	{
		if (!global_type_created)
		{
			throw new InvalidOperationException("InvalidOperation_ModuleFieldsMethodsRelyOnCreateGlobalFunctionsMethod");
		}
		return global_type.AsType().GetMethods(bindingFlags);
	}
}

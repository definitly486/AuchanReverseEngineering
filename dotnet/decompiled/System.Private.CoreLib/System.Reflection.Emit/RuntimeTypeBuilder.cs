using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeTypeBuilder : TypeBuilder
{
	private string tname;

	private string nspace;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
	private Type parent;

	private Type nesting_type;

	internal Type[] interfaces;

	internal int num_methods;

	internal RuntimeMethodBuilder[] methods;

	internal RuntimeConstructorBuilder[] ctors;

	internal RuntimePropertyBuilder[] properties;

	internal int num_fields;

	internal RuntimeFieldBuilder[] fields;

	internal RuntimeEventBuilder[] events;

	private CustomAttributeBuilder[] cattrs;

	internal RuntimeTypeBuilder[] subtypes;

	internal TypeAttributes attrs;

	private int table_idx;

	private RuntimeModuleBuilder pmodule;

	private int class_size;

	private PackingSize packing_size;

	private nint generic_container;

	private RuntimeGenericTypeParameterBuilder[] generic_params;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
	private TypeInfo created;

	private int is_byreflike_set;

	private int state;

	internal bool is_hidden_global_type;

	private ITypeName fullname;

	private bool createTypeCalled;

	private Type underlying_type;

	public override Assembly Assembly => pmodule.Assembly;

	public override string AssemblyQualifiedName => TypeNameBuilder.ToString(this, TypeNameBuilder.Format.AssemblyQualifiedName);

	public override Type BaseType => parent;

	public override Type DeclaringType => nesting_type;

	public override Type UnderlyingSystemType
	{
		get
		{
			if (is_created)
			{
				return created.UnderlyingSystemType;
			}
			if (IsEnum)
			{
				if (underlying_type != null)
				{
					return underlying_type;
				}
				throw new InvalidOperationException("Enumeration type is not defined.");
			}
			return this;
		}
	}

	public override string FullName => TypeNameBuilder.ToString(this, TypeNameBuilder.Format.FullName);

	public override Guid GUID
	{
		get
		{
			check_created();
			return created.GUID;
		}
	}

	public override Module Module => pmodule;

	public override string Name => tname;

	public override string Namespace => nspace;

	protected override PackingSize PackingSizeCore => packing_size;

	protected override int SizeCore => class_size;

	public override Type ReflectedType => nesting_type;

	public override bool IsSZArray => false;

	public override RuntimeTypeHandle TypeHandle
	{
		get
		{
			check_created();
			return created.TypeHandle;
		}
	}

	public override int MetadataToken => 0x2000000 | table_idx;

	internal bool is_created => createTypeCalled;

	public override bool ContainsGenericParameters => generic_params != null;

	public override bool IsGenericParameter => false;

	public override GenericParameterAttributes GenericParameterAttributes => GenericParameterAttributes.None;

	public override bool IsGenericTypeDefinition => generic_params != null;

	public override bool IsGenericType => IsGenericTypeDefinition;

	public override int GenericParameterPosition => 0;

	public override MethodBase DeclaringMethod => null;

	internal override bool IsUserType => false;

	public override bool IsConstructedGenericType => false;

	public override bool IsTypeDefinition => true;

	public override bool IsByRefLike => false;

	protected override TypeAttributes GetAttributeFlagsImpl()
	{
		return attrs;
	}

	internal RuntimeTypeBuilder(RuntimeModuleBuilder mb, TypeAttributes attr, int table_idx, bool is_hidden_global_type = false)
	{
		this.is_hidden_global_type = is_hidden_global_type;
		parent = null;
		attrs = attr;
		class_size = 0;
		this.table_idx = table_idx;
		tname = ((table_idx == 1) ? "<Module>" : ("type_" + table_idx));
		nspace = string.Empty;
		fullname = TypeIdentifiers.WithoutEscape(tname);
		pmodule = mb;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2074:UnrecognizedReflectionPattern", Justification = "Linker doesn't analyze ResolveUserType but it's an identity function")]
	internal RuntimeTypeBuilder(RuntimeModuleBuilder mb, string name, TypeAttributes attr, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type parent, Type[] interfaces, PackingSize packing_size, int type_size, Type nesting_type)
	{
		is_hidden_global_type = false;
		this.parent = ResolveUserType(parent);
		attrs = attr;
		class_size = type_size;
		this.packing_size = packing_size;
		this.nesting_type = nesting_type;
		check_name("name", name);
		if (parent == null && (attr & TypeAttributes.ClassSemanticsMask) != TypeAttributes.NotPublic && (attr & TypeAttributes.Abstract) == 0)
		{
			throw new InvalidOperationException("InvalidOperation_BadInterfaceNotAbstract");
		}
		int num = name.LastIndexOf('.');
		if (num != -1)
		{
			tname = name.Substring(num + 1);
			nspace = name.Substring(0, num);
		}
		else
		{
			tname = name;
			nspace = string.Empty;
		}
		if (interfaces != null)
		{
			this.interfaces = new Type[interfaces.Length];
			Array.Copy(interfaces, this.interfaces, interfaces.Length);
		}
		pmodule = mb;
		if ((attr & TypeAttributes.ClassSemanticsMask) == 0 && parent == null)
		{
			this.parent = typeof(object);
		}
		table_idx = mb.get_next_table_index(2, 1);
		fullname = GetFullName();
	}

	public override bool IsSubclassOf(Type c)
	{
		if (c == null)
		{
			return false;
		}
		if (c == this)
		{
			return false;
		}
		Type baseType = parent;
		while (baseType != null)
		{
			if (c == baseType)
			{
				return true;
			}
			baseType = baseType.BaseType;
		}
		return false;
	}

	private ITypeName GetFullName()
	{
		ITypeIdentifier typeIdentifier = TypeIdentifiers.FromInternal(tname);
		if (nesting_type != null)
		{
			return TypeNames.FromDisplay(nesting_type.FullName).NestedName(typeIdentifier);
		}
		if (nspace != null && nspace.Length > 0)
		{
			return TypeIdentifiers.FromInternal(nspace, typeIdentifier);
		}
		return typeIdentifier;
	}

	protected override void AddInterfaceImplementationCore([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type interfaceType)
	{
		check_not_created();
		if (interfaces != null)
		{
			Type[] array = interfaces;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == interfaceType)
				{
					return;
				}
			}
			Type[] array2 = new Type[interfaces.Length + 1];
			interfaces.CopyTo(array2, 0);
			array2[interfaces.Length] = interfaceType;
			interfaces = array2;
		}
		else
		{
			interfaces = new Type[1];
			interfaces[0] = interfaceType;
		}
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		check_created();
		if (created == typeof(object))
		{
			if (ctors == null)
			{
				return null;
			}
			ConstructorBuilder constructorBuilder = null;
			int num = 0;
			RuntimeConstructorBuilder[] array = ctors;
			foreach (RuntimeConstructorBuilder runtimeConstructorBuilder in array)
			{
				if (callConvention == CallingConventions.Any || runtimeConstructorBuilder.CallingConvention == callConvention)
				{
					constructorBuilder = runtimeConstructorBuilder;
					num++;
				}
			}
			if (num == 0)
			{
				return null;
			}
			if (types == null)
			{
				if (num > 1)
				{
					throw ThrowHelper.GetAmbiguousMatchException(constructorBuilder);
				}
				return constructorBuilder;
			}
			MethodBase[] array2 = new MethodBase[num];
			if (num == 1)
			{
				array2[0] = constructorBuilder;
			}
			else
			{
				num = 0;
				array = ctors;
				foreach (ConstructorInfo constructorInfo in array)
				{
					if (callConvention == CallingConventions.Any || constructorInfo.CallingConvention == callConvention)
					{
						array2[num++] = constructorInfo;
					}
				}
			}
			if (binder == null)
			{
				binder = Type.DefaultBinder;
			}
			return (ConstructorInfo)binder.SelectMethod(bindingAttr, array2, types, modifiers);
		}
		return created.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		if (!is_created)
		{
			throw new NotSupportedException();
		}
		return CustomAttribute.IsDefined(this, attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		check_created();
		return created.GetCustomAttributes(inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		check_created();
		return created.GetCustomAttributes(attributeType, inherit);
	}

	protected override TypeBuilder DefineNestedTypeCore(string name, TypeAttributes attr, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type parent, Type[] interfaces, PackingSize packSize, int typeSize)
	{
		if (interfaces != null)
		{
			foreach (Type obj in interfaces)
			{
				ArgumentNullException.ThrowIfNull(obj, "interfaces");
				if (obj.IsByRef)
				{
					throw new ArgumentException("interfaces");
				}
			}
		}
		RuntimeTypeBuilder runtimeTypeBuilder = new RuntimeTypeBuilder(pmodule, name, attr, parent, interfaces, packSize, typeSize, this);
		runtimeTypeBuilder.fullname = runtimeTypeBuilder.GetFullName();
		pmodule.RegisterTypeName(runtimeTypeBuilder, runtimeTypeBuilder.fullname);
		if (subtypes != null)
		{
			RuntimeTypeBuilder[] array = new RuntimeTypeBuilder[subtypes.Length + 1];
			Array.Copy(subtypes, array, subtypes.Length);
			array[subtypes.Length] = runtimeTypeBuilder;
			subtypes = array;
		}
		else
		{
			subtypes = new RuntimeTypeBuilder[1];
			subtypes[0] = runtimeTypeBuilder;
		}
		return runtimeTypeBuilder;
	}

	protected override ConstructorBuilder DefineConstructorCore(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers)
	{
		check_not_created();
		if (base.IsInterface && (attributes & MethodAttributes.Static) == 0)
		{
			throw new InvalidOperationException();
		}
		RuntimeConstructorBuilder runtimeConstructorBuilder = new RuntimeConstructorBuilder(this, attributes, callingConvention, parameterTypes, requiredCustomModifiers, optionalCustomModifiers);
		if (ctors != null)
		{
			RuntimeConstructorBuilder[] array = new RuntimeConstructorBuilder[ctors.Length + 1];
			Array.Copy(ctors, array, ctors.Length);
			array[ctors.Length] = runtimeConstructorBuilder;
			ctors = array;
		}
		else
		{
			ctors = new RuntimeConstructorBuilder[1];
			ctors[0] = runtimeConstructorBuilder;
		}
		return runtimeConstructorBuilder;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "Reflection.Emit is not subject to trimming")]
	protected override ConstructorBuilder DefineDefaultConstructorCore(MethodAttributes attributes)
	{
		if (base.IsInterface)
		{
			throw new InvalidOperationException();
		}
		if ((attributes & (MethodAttributes.Static | MethodAttributes.Virtual)) > MethodAttributes.PrivateScope)
		{
			throw new ArgumentException("Arg_NoStaticVirtual");
		}
		Type type = ((!(parent != null)) ? typeof(object) : parent);
		Type type2 = type;
		type = type.InternalResolve();
		if (type == typeof(object) || type == typeof(ValueType))
		{
			type = type2;
		}
		ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
		if (constructor == null)
		{
			throw new NotSupportedException("NotSupported_NoParentDefaultConstructor");
		}
		RuntimeConstructorBuilder obj = (RuntimeConstructorBuilder)DefineConstructor(attributes, CallingConventions.Standard, Type.EmptyTypes);
		ILGenerator iLGenerator = obj.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, constructor);
		iLGenerator.Emit(OpCodes.Ret);
		obj.finished = true;
		return obj;
	}

	private void append_method(RuntimeMethodBuilder mb)
	{
		if (methods != null)
		{
			if (methods.Length == num_methods)
			{
				RuntimeMethodBuilder[] destinationArray = new RuntimeMethodBuilder[methods.Length * 2];
				Array.Copy(methods, destinationArray, num_methods);
				methods = destinationArray;
			}
		}
		else
		{
			methods = new RuntimeMethodBuilder[1];
		}
		methods[num_methods] = mb;
		num_methods++;
	}

	protected override MethodBuilder DefineMethodCore(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
	{
		check_name("name", name);
		check_not_created();
		if (base.IsInterface && ((attributes & MethodAttributes.Abstract) == 0 || (attributes & MethodAttributes.Virtual) == 0) && (attributes & MethodAttributes.Static) == 0)
		{
			throw new ArgumentException("InvalidOperation_BadInterfaceNotAbstractAndVirtual");
		}
		if ((object)returnType == null)
		{
			returnType = typeof(void);
		}
		RuntimeMethodBuilder runtimeMethodBuilder = new RuntimeMethodBuilder(this, name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
		append_method(runtimeMethodBuilder);
		return runtimeMethodBuilder;
	}

	[RequiresUnreferencedCode("P/Invoke marshalling may dynamically access members that could be trimmed.")]
	protected override MethodBuilder DefinePInvokeMethodCore(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
	{
		check_name("name", name);
		check_name("dllName", dllName);
		check_name("entryName", entryName);
		if ((attributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope)
		{
			throw new ArgumentException("Argument_BadPInvokeMethod");
		}
		if (base.IsInterface)
		{
			throw new ArgumentException("Argument_BadPInvokeOnInterface");
		}
		check_not_created();
		RuntimeMethodBuilder runtimeMethodBuilder = new RuntimeMethodBuilder(this, name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, dllName, entryName, nativeCallConv, nativeCharSet);
		append_method(runtimeMethodBuilder);
		return runtimeMethodBuilder;
	}

	protected override void DefineMethodOverrideCore(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration)
	{
		check_not_created();
		if (methodInfoBody.DeclaringType != this)
		{
			throw new ArgumentException("Argument_MethodBodyMustBelongToType");
		}
		if (methodInfoBody is RuntimeMethodBuilder runtimeMethodBuilder)
		{
			runtimeMethodBuilder.set_override(methodInfoDeclaration);
		}
	}

	protected override FieldBuilder DefineFieldCore(string fieldName, Type type, Type[] requiredCustomModifiers, Type[] optionalCustomModifiers, FieldAttributes attributes)
	{
		check_name("fieldName", fieldName);
		if (type == typeof(void))
		{
			throw new ArgumentException("Argument_BadFieldType");
		}
		check_not_created();
		RuntimeFieldBuilder runtimeFieldBuilder = new RuntimeFieldBuilder(this, fieldName, type, attributes, requiredCustomModifiers, optionalCustomModifiers);
		if (fields != null)
		{
			if (fields.Length == num_fields)
			{
				RuntimeFieldBuilder[] destinationArray = new RuntimeFieldBuilder[fields.Length * 2];
				Array.Copy(fields, destinationArray, num_fields);
				fields = destinationArray;
			}
			fields[num_fields] = runtimeFieldBuilder;
			num_fields++;
		}
		else
		{
			fields = new RuntimeFieldBuilder[1];
			fields[0] = runtimeFieldBuilder;
			num_fields++;
		}
		if (IsEnum && underlying_type == null && (attributes & FieldAttributes.Static) == 0)
		{
			underlying_type = type;
		}
		return runtimeFieldBuilder;
	}

	protected override PropertyBuilder DefinePropertyCore(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
	{
		check_name("name", name);
		if (parameterTypes != null)
		{
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				ArgumentNullException.ThrowIfNull(parameterTypes[i], "parameterTypes");
			}
		}
		check_not_created();
		RuntimePropertyBuilder runtimePropertyBuilder = new RuntimePropertyBuilder(this, name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
		if (properties != null)
		{
			Array.Resize(ref properties, properties.Length + 1);
			properties[properties.Length - 1] = runtimePropertyBuilder;
		}
		else
		{
			properties = new RuntimePropertyBuilder[1] { runtimePropertyBuilder };
		}
		return runtimePropertyBuilder;
	}

	protected override ConstructorBuilder DefineTypeInitializerCore()
	{
		return DefineConstructor(MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, CallingConventions.Standard, null);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2110:ReflectionToDynamicallyAccessedMembers", Justification = "For instance member internal calls, the linker preserves all fields of the declaring type. The parent and created fields have DynamicallyAccessedMembersAttribute requirements, but creating the runtime class is safe because the annotations fully preserve the parent type, and the type created via Reflection.Emit is not subject to trimming.")]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
	private extern TypeInfo create_runtime_class();

	private bool is_nested_in(Type t)
	{
		while (t != null)
		{
			if (t == this)
			{
				return true;
			}
			t = t.DeclaringType;
		}
		return false;
	}

	private bool has_ctor_method()
	{
		MethodAttributes methodAttributes = MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
		for (int i = 0; i < num_methods; i++)
		{
			MethodBuilder methodBuilder = methods[i];
			if (methodBuilder.Name == ConstructorInfo.ConstructorName && (methodBuilder.Attributes & methodAttributes) == methodAttributes)
			{
				return true;
			}
		}
		return false;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2083:UnrecognizedReflectionPattern", Justification = "Reflection.Emit is not subject to trimming")]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
	protected override TypeInfo CreateTypeInfoCore()
	{
		if (createTypeCalled)
		{
			return created;
		}
		if (!base.IsInterface && parent == null && this != typeof(object) && FullName != "<Module>")
		{
			SetParent(typeof(object));
		}
		if (fields != null)
		{
			RuntimeFieldBuilder[] array = fields;
			foreach (RuntimeFieldBuilder runtimeFieldBuilder in array)
			{
				if (!(runtimeFieldBuilder == null))
				{
					Type fieldType = runtimeFieldBuilder.FieldType;
					if (!runtimeFieldBuilder.IsStatic && fieldType is RuntimeTypeBuilder runtimeTypeBuilder && fieldType.IsValueType && fieldType != this && is_nested_in(fieldType) && !runtimeTypeBuilder.is_created)
					{
						throw new NotImplementedException();
					}
				}
			}
		}
		if (parent != null)
		{
			if (parent.IsByRef)
			{
				throw new NotSupportedException();
			}
			if (base.IsInterface)
			{
				throw new TypeLoadException();
			}
		}
		if (!base.IsInterface && !base.IsValueType && ctors == null && tname != "<Module>" && ((GetAttributeFlagsImpl() & TypeAttributes.Abstract) | TypeAttributes.Sealed) != (TypeAttributes.Abstract | TypeAttributes.Sealed) && !has_ctor_method())
		{
			DefineDefaultConstructor(MethodAttributes.Public);
		}
		createTypeCalled = true;
		if (parent != null)
		{
			if (parent.IsSealed)
			{
				throw new TypeLoadException(SR.Format("TypeLoad_AssemblySealedParentTypeError", fullname.DisplayName, Assembly));
			}
			if (parent.IsGenericTypeDefinition)
			{
				throw new BadImageFormatException();
			}
		}
		if (parent == typeof(Enum) && methods != null)
		{
			throw new TypeLoadException(SR.Format("TypeLoad_AssemblyEnumContainsMethodsError", fullname.DisplayName, Assembly));
		}
		if (interfaces != null)
		{
			Type[] array2 = interfaces;
			foreach (Type type in array2)
			{
				if (type.IsNestedPrivate && type.Assembly != Assembly)
				{
					throw new TypeLoadException(SR.Format("TypeLoad_AssemblyInaccessibleInterfaceError", fullname.DisplayName, Assembly, type.FullName));
				}
				if (type.IsGenericTypeDefinition)
				{
					throw new BadImageFormatException();
				}
				if (!type.IsInterface)
				{
					throw new TypeLoadException();
				}
				if (type is RuntimeTypeBuilder { is_created: false })
				{
					throw new TypeLoadException();
				}
			}
		}
		if (methods != null)
		{
			bool flag = !base.IsAbstract;
			for (int j = 0; j < num_methods; j++)
			{
				RuntimeMethodBuilder runtimeMethodBuilder = methods[j];
				if (flag && runtimeMethodBuilder.IsAbstract)
				{
					throw new InvalidOperationException(SR.Format("InvalidOperation_AbstractMethod", runtimeMethodBuilder));
				}
				runtimeMethodBuilder.check_override();
				runtimeMethodBuilder.fixup();
			}
		}
		if (ctors != null)
		{
			RuntimeConstructorBuilder[] array3 = ctors;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i].fixup();
			}
		}
		ResolveUserTypes();
		created = create_runtime_class();
		if (is_hidden_global_type)
		{
			return null;
		}
		if (created != null)
		{
			return created;
		}
		return this;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2074:UnrecognizedReflectionPattern", Justification = "Linker doesn't analyze ResolveUserType but it's an identity function")]
	private void ResolveUserTypes()
	{
		parent = ResolveUserType(parent);
		ResolveUserTypes(interfaces);
		if (fields != null)
		{
			RuntimeFieldBuilder[] array = fields;
			for (int i = 0; i < array.Length; i++)
			{
				array[i]?.ResolveUserTypes();
			}
		}
		if (methods != null)
		{
			RuntimeMethodBuilder[] array2 = methods;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i]?.ResolveUserTypes();
			}
		}
		if (ctors != null)
		{
			RuntimeConstructorBuilder[] array3 = ctors;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i]?.ResolveUserTypes();
			}
		}
	}

	internal static void ResolveUserTypes(Type[] types)
	{
		if (types != null)
		{
			for (int i = 0; i < types.Length; i++)
			{
				types[i] = ResolveUserType(types[i]);
			}
		}
	}

	[return: NotNullIfNotNull("t")]
	internal static Type ResolveUserType(Type t)
	{
		if (t != null && (t.GetType().Assembly != typeof(int).Assembly || t is TypeDelegator))
		{
			t = t.UnderlyingSystemType;
			if (t != null && (t.GetType().Assembly != typeof(int).Assembly || t is TypeDelegator))
			{
				throw new NotSupportedException("PlatformNotSupported_UserDefinedSubclassesOfType");
			}
			return t;
		}
		return t;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
	{
		if (is_created)
		{
			return created.GetConstructors(bindingAttr);
		}
		throw new NotSupportedException();
	}

	public override Type GetElementType()
	{
		throw new NotSupportedException();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
	{
		check_created();
		return created.GetEvent(name, bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents)]
	public override EventInfo[] GetEvents()
	{
		return GetEvents(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo[] GetEvents(BindingFlags bindingAttr)
	{
		if (is_created)
		{
			return created.GetEvents(bindingAttr);
		}
		throw new NotSupportedException();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		check_created();
		return created.GetField(name, bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo[] GetFields(BindingFlags bindingAttr)
	{
		check_created();
		return created.GetFields(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type GetInterface(string name, bool ignoreCase)
	{
		check_created();
		return created.GetInterface(name, ignoreCase);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type[] GetInterfaces()
	{
		if (is_created)
		{
			return created.GetInterfaces();
		}
		if (interfaces != null)
		{
			Type[] array = new Type[interfaces.Length];
			interfaces.CopyTo(array, 0);
			return array;
		}
		return Type.EmptyTypes;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
	{
		check_created();
		return created.GetMember(name, type, bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
	{
		check_created();
		return created.GetMembers(bindingAttr);
	}

	private MethodInfo[] GetMethodsByName(string name, BindingFlags bindingAttr, bool ignoreCase)
	{
		MethodInfo[] array2;
		MethodInfo[] array3;
		if ((bindingAttr & BindingFlags.DeclaredOnly) == 0 && parent != null)
		{
			MethodInfo[] array = parent.GetMethods(bindingAttr);
			List<MethodInfo> list = new List<MethodInfo>(array.Length);
			bool flag = (bindingAttr & BindingFlags.FlattenHierarchy) != 0;
			foreach (MethodInfo methodInfo in array)
			{
				MethodAttributes attributes = methodInfo.Attributes;
				if ((!methodInfo.IsStatic || flag) && (attributes & MethodAttributes.MemberAccessMask) switch
				{
					MethodAttributes.Public => (bindingAttr & BindingFlags.Public) != 0, 
					MethodAttributes.Assembly => (bindingAttr & BindingFlags.NonPublic) != 0, 
					MethodAttributes.Private => false, 
					_ => (bindingAttr & BindingFlags.NonPublic) != 0, 
				})
				{
					list.Add(methodInfo);
				}
			}
			if (methods == null)
			{
				array2 = new MethodInfo[list.Count];
				list.CopyTo(array2);
			}
			else
			{
				array2 = new MethodInfo[methods.Length + list.Count];
				list.CopyTo(array2, 0);
				methods.CopyTo(array2, list.Count);
			}
		}
		else
		{
			array3 = methods;
			array2 = array3;
		}
		if (array2 == null)
		{
			return Array.Empty<MethodInfo>();
		}
		List<MethodInfo> list2 = new List<MethodInfo>();
		array3 = array2;
		foreach (MethodInfo methodInfo2 in array3)
		{
			if (methodInfo2 == null || (name != null && string.Compare(methodInfo2.Name, name, ignoreCase) != 0))
			{
				continue;
			}
			bool flag2 = false;
			MethodAttributes attributes = methodInfo2.Attributes;
			if ((attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public)
			{
				if ((bindingAttr & BindingFlags.Public) != BindingFlags.Default)
				{
					flag2 = true;
				}
			}
			else if ((bindingAttr & BindingFlags.NonPublic) != BindingFlags.Default)
			{
				flag2 = true;
			}
			if (!flag2)
			{
				continue;
			}
			flag2 = false;
			if ((attributes & MethodAttributes.Static) != MethodAttributes.PrivateScope)
			{
				if ((bindingAttr & BindingFlags.Static) != BindingFlags.Default)
				{
					flag2 = true;
				}
			}
			else if ((bindingAttr & BindingFlags.Instance) != BindingFlags.Default)
			{
				flag2 = true;
			}
			if (flag2)
			{
				list2.Add(methodInfo2);
			}
		}
		return list2.ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
	{
		check_created();
		return GetMethodsByName(null, bindingAttr, ignoreCase: false);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		check_created();
		if (types == null)
		{
			return created.GetMethod(name, bindingAttr);
		}
		return created.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type GetNestedType(string name, BindingFlags bindingAttr)
	{
		check_created();
		if (subtypes == null)
		{
			return null;
		}
		RuntimeTypeBuilder[] array = subtypes;
		foreach (RuntimeTypeBuilder runtimeTypeBuilder in array)
		{
			if (!runtimeTypeBuilder.is_created)
			{
				continue;
			}
			if ((runtimeTypeBuilder.attrs & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic)
			{
				if ((bindingAttr & BindingFlags.Public) == 0)
				{
					continue;
				}
			}
			else if ((bindingAttr & BindingFlags.NonPublic) == 0)
			{
				continue;
			}
			if (runtimeTypeBuilder.Name == name)
			{
				return runtimeTypeBuilder.created;
			}
		}
		return null;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes)]
	public override Type[] GetNestedTypes(BindingFlags bindingAttr)
	{
		if (!is_created)
		{
			throw new NotSupportedException();
		}
		List<Type> list = new List<Type>();
		if (subtypes == null)
		{
			return Type.EmptyTypes;
		}
		RuntimeTypeBuilder[] array = subtypes;
		foreach (RuntimeTypeBuilder runtimeTypeBuilder in array)
		{
			bool flag = false;
			if ((runtimeTypeBuilder.attrs & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic)
			{
				if ((bindingAttr & BindingFlags.Public) != BindingFlags.Default)
				{
					flag = true;
				}
			}
			else if ((bindingAttr & BindingFlags.NonPublic) != BindingFlags.Default)
			{
				flag = true;
			}
			if (flag)
			{
				list.Add(runtimeTypeBuilder);
			}
		}
		return list.ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
	{
		check_created();
		return created.GetProperties(bindingAttr);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		throw not_supported();
	}

	protected override bool HasElementTypeImpl()
	{
		if (!is_created)
		{
			return false;
		}
		return created.HasElementType;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
	{
		check_created();
		return created.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
	}

	protected override bool IsArrayImpl()
	{
		return false;
	}

	protected override bool IsByRefImpl()
	{
		return false;
	}

	protected override bool IsCOMObjectImpl()
	{
		return (GetAttributeFlagsImpl() & TypeAttributes.Import) != 0;
	}

	protected override bool IsPointerImpl()
	{
		return false;
	}

	protected override bool IsPrimitiveImpl()
	{
		return false;
	}

	protected override bool IsValueTypeImpl()
	{
		Type baseType = parent;
		while (baseType != null)
		{
			if (baseType == typeof(ValueType))
			{
				return true;
			}
			baseType = baseType.BaseType;
		}
		return false;
	}

	[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override Type MakeGenericType(params Type[] typeArguments)
	{
		if (!IsGenericTypeDefinition)
		{
			throw new InvalidOperationException("InvalidOperation_NotGenericType");
		}
		ArgumentNullException.ThrowIfNull(typeArguments, "typeArguments");
		if (generic_params.Length != typeArguments.Length)
		{
			throw new ArgumentException(SR.Format("Argument_NotEnoughGenArguments", generic_params.Length, typeArguments.Length), "typeArguments");
		}
		for (int i = 0; i < typeArguments.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(typeArguments[i], "typeArguments");
		}
		Type[] array = new Type[typeArguments.Length];
		typeArguments.CopyTo(array, 0);
		return RuntimeAssemblyBuilder.MakeGenericType(this, array);
	}

	internal void SetCustomAttribute(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		SetCustomAttributeCore(con, binaryAttribute);
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		switch (con.ReflectedType.FullName)
		{
		case "System.Runtime.InteropServices.StructLayoutAttribute":
		{
			int num = binaryAttribute[2] | (binaryAttribute[3] << 8);
			attrs &= ~TypeAttributes.LayoutMask;
			TypeAttributes typeAttributes = attrs;
			attrs = (TypeAttributes)((int)typeAttributes | ((LayoutKind)num switch
			{
				LayoutKind.Auto => 0, 
				LayoutKind.Explicit => 16, 
				LayoutKind.Sequential => 8, 
				_ => throw new Exception("Argument_InvalidKindOfTypeForCA"), 
			}));
			Type obj = ((con is RuntimeConstructorBuilder runtimeConstructorBuilder) ? runtimeConstructorBuilder.parameters[0] : con.GetParametersInternal()[0].ParameterType);
			int num2 = 6;
			if (obj.FullName == "System.Int16")
			{
				num2 = 4;
			}
			int num3 = BinaryPrimitives.ReadUInt16LittleEndian(binaryAttribute.Slice(num2++));
			num2++;
			for (int i = 0; i < num3; i++)
			{
				num2++;
				int num4;
				if (binaryAttribute[num2++] == 85)
				{
					num4 = CustomAttributeBuilder.decode_len(binaryAttribute, num2, out num2);
					CustomAttributeBuilder.string_from_bytes(binaryAttribute, num2, num4);
					num2 += num4;
				}
				num4 = CustomAttributeBuilder.decode_len(binaryAttribute, num2, out num2);
				string text = CustomAttributeBuilder.string_from_bytes(binaryAttribute, num2, num4);
				num2 += num4;
				int num5 = BinaryPrimitives.ReadInt32LittleEndian(binaryAttribute.Slice(num2++));
				num2 += 3;
				switch (text)
				{
				case "CharSet":
					switch ((CharSet)num5)
					{
					case CharSet.None:
					case CharSet.Ansi:
						attrs &= ~TypeAttributes.StringFormatMask;
						break;
					case CharSet.Unicode:
						attrs &= ~TypeAttributes.AutoClass;
						attrs |= TypeAttributes.UnicodeClass;
						break;
					case CharSet.Auto:
						attrs &= ~TypeAttributes.UnicodeClass;
						attrs |= TypeAttributes.AutoClass;
						break;
					}
					break;
				case "Pack":
					packing_size = (PackingSize)num5;
					break;
				case "Size":
					class_size = num5;
					break;
				}
			}
			return;
		}
		case "System.Runtime.CompilerServices.SpecialNameAttribute":
			attrs |= TypeAttributes.SpecialName;
			return;
		case "System.SerializableAttribute":
			attrs |= TypeAttributes.Serializable;
			return;
		case "System.Runtime.InteropServices.ComImportAttribute":
			attrs |= TypeAttributes.Import;
			return;
		case "System.Security.SuppressUnmanagedCodeSecurityAttribute":
			attrs |= TypeAttributes.HasSecurity;
			break;
		case "System.Runtime.CompilerServices.IsByRefLikeAttribute":
			is_byreflike_set = 1;
			break;
		}
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

	protected override EventBuilder DefineEventCore(string name, EventAttributes attributes, Type eventtype)
	{
		check_name("name", name);
		ArgumentNullException.ThrowIfNull(eventtype, "eventtype");
		check_not_created();
		RuntimeEventBuilder runtimeEventBuilder = new RuntimeEventBuilder(this, name, attributes, eventtype);
		if (events != null)
		{
			RuntimeEventBuilder[] array = new RuntimeEventBuilder[events.Length + 1];
			Array.Copy(events, array, events.Length);
			array[events.Length] = runtimeEventBuilder;
			events = array;
		}
		else
		{
			events = new RuntimeEventBuilder[1];
			events[0] = runtimeEventBuilder;
		}
		return runtimeEventBuilder;
	}

	protected override FieldBuilder DefineInitializedDataCore(string name, byte[] data, FieldAttributes attributes)
	{
		RuntimeFieldBuilder obj = (RuntimeFieldBuilder)DefineUninitializedData(name, data.Length, attributes);
		obj.SetRVAData(data);
		return obj;
	}

	protected override FieldBuilder DefineUninitializedDataCore(string name, int size, FieldAttributes attributes)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		if (size <= 0 || size > 4128768)
		{
			throw new ArgumentException("Argument_BadSizeForData");
		}
		check_not_created();
		string text = "$ArrayType$" + size;
		ITypeIdentifier innerName = TypeIdentifiers.WithoutEscape(text);
		Type type = pmodule.GetRegisteredType(fullname.NestedName(innerName));
		if (type == null)
		{
			TypeBuilder typeBuilder = DefineNestedTypeCore(text, TypeAttributes.NestedPrivate | TypeAttributes.ExplicitLayout | TypeAttributes.Sealed, typeof(ValueType), null, RuntimeFieldBuilder.RVADataPackingSize(size), size);
			typeBuilder.CreateType();
			type = typeBuilder;
		}
		return DefineField(name, type, attributes | FieldAttributes.Static | FieldAttributes.HasFieldRVA);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2074:UnrecognizedReflectionPattern", Justification = "Linker doesn't analyze ResolveUserType but it's an identity function")]
	protected override void SetParentCore([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type parent)
	{
		check_not_created();
		if (parent == null)
		{
			if ((attrs & TypeAttributes.ClassSemanticsMask) != TypeAttributes.NotPublic)
			{
				if ((attrs & TypeAttributes.Abstract) == 0)
				{
					throw new InvalidOperationException("InvalidOperation_BadInterfaceNotAbstract");
				}
				this.parent = null;
			}
			else
			{
				this.parent = typeof(object);
			}
		}
		else
		{
			if (parent.IsInterface)
			{
				throw new ArgumentException("Argument_CannotSetParentToInterface");
			}
			this.parent = parent;
		}
		this.parent = ResolveUserType(this.parent);
	}

	internal int get_next_table_index(int table, int count)
	{
		return pmodule.get_next_table_index(table, count);
	}

	public override InterfaceMapping GetInterfaceMap([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)] Type interfaceType)
	{
		if (created == null)
		{
			throw new NotSupportedException("NotSupported_IncompleteTypes");
		}
		return created.GetInterfaceMap(interfaceType);
	}

	internal override Type InternalResolve()
	{
		check_created();
		return created;
	}

	internal override Type RuntimeResolve()
	{
		check_created();
		return created;
	}

	private static NotSupportedException not_supported()
	{
		return new NotSupportedException("NotSupported_DynamicModule");
	}

	internal void check_not_created()
	{
		if (is_created)
		{
			throw new InvalidOperationException("InvalidOperation_TypeHasBeenCreated");
		}
	}

	private void check_created()
	{
		if (!is_created)
		{
			throw not_supported();
		}
	}

	private static void check_name(string argName, string name)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, argName);
		if (name[0] == '\0')
		{
			throw new ArgumentException("Argument_EmptyName", argName);
		}
	}

	public override string ToString()
	{
		return FullName;
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] Type c)
	{
		return base.IsAssignableFrom(c);
	}

	internal bool IsAssignableToInternal([NotNullWhen(true)] Type c)
	{
		if (c == this)
		{
			return true;
		}
		if (c.IsInterface)
		{
			if (parent != null && is_created && c.IsAssignableFrom(parent))
			{
				return true;
			}
			if (interfaces == null)
			{
				return false;
			}
			Type[] array = interfaces;
			foreach (Type c2 in array)
			{
				if (c.IsAssignableFrom(c2))
				{
					return true;
				}
			}
			if (!is_created)
			{
				return false;
			}
		}
		if (parent == null)
		{
			return c == typeof(object);
		}
		return c.IsAssignableFrom(parent);
	}

	protected override bool IsCreatedCore()
	{
		return is_created;
	}

	public override Type[] GetGenericArguments()
	{
		if (generic_params == null)
		{
			return Type.EmptyTypes;
		}
		Type[] array = new Type[generic_params.Length];
		generic_params.CopyTo(array, 0);
		return array;
	}

	public override Type GetGenericTypeDefinition()
	{
		if (generic_params == null)
		{
			throw new InvalidOperationException("InvalidOperation_NotGenericType");
		}
		return this;
	}

	protected override GenericTypeParameterBuilder[] DefineGenericParametersCore(params string[] names)
	{
		generic_params = new RuntimeGenericTypeParameterBuilder[names.Length];
		for (int i = 0; i < names.Length; i++)
		{
			string text = names[i];
			ArgumentNullException.ThrowIfNull(text, "names");
			generic_params[i] = new RuntimeGenericTypeParameterBuilder(this, null, text, i);
		}
		return generic_params;
	}

	internal override bool IsTypeBuilder()
	{
		return true;
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] TypeInfo typeInfo)
	{
		return base.IsAssignableFrom(typeInfo);
	}

	internal static bool SetConstantValue(Type destType, object value, ref object destValue)
	{
		if (value != null)
		{
			Type type = value.GetType();
			if (destType.IsByRef)
			{
				destType = destType.GetElementType();
			}
			destType = Nullable.GetUnderlyingType(destType) ?? destType;
			if (destType.IsEnum)
			{
				Type type2;
				if (destType is RuntimeEnumBuilder runtimeEnumBuilder)
				{
					type2 = runtimeEnumBuilder.GetEnumUnderlyingType();
					if ((!runtimeEnumBuilder.GetTypeBuilder().is_created || !(type == runtimeEnumBuilder.GetTypeBuilder().created)) && !(type == type2))
					{
						throw_argument_ConstantDoesntMatch();
					}
				}
				else if (destType is RuntimeTypeBuilder runtimeTypeBuilder)
				{
					type2 = runtimeTypeBuilder.underlying_type;
					if (type2 == null || (type != runtimeTypeBuilder.UnderlyingSystemType && type != type2))
					{
						throw_argument_ConstantDoesntMatch();
					}
				}
				else
				{
					type2 = Enum.GetUnderlyingType(destType);
					if (type != destType && type != type2)
					{
						throw_argument_ConstantDoesntMatch();
					}
				}
				type = type2;
			}
			else if (!destType.IsAssignableFrom(type))
			{
				throw_argument_ConstantDoesntMatch();
			}
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Boolean:
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
				destValue = value;
				return true;
			case TypeCode.String:
				destValue = value;
				return true;
			case TypeCode.DateTime:
			{
				long ticks = ((DateTime)value).Ticks;
				destValue = ticks;
				return true;
			}
			default:
				throw new ArgumentException(SR.Format("Argument_ConstantNotSupported", type));
			}
		}
		destValue = null;
		return true;
	}

	private static void throw_argument_ConstantDoesntMatch()
	{
		throw new ArgumentException("Argument_ConstantDoesntMatch");
	}
}

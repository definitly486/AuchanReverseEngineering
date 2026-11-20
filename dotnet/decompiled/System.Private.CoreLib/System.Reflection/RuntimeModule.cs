using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeModule : Module
{
	internal nint _impl;

	internal Assembly assembly;

	internal string fqname;

	internal string name;

	internal string scopename;

	internal bool is_resource;

	internal int token;

	public override Assembly Assembly => assembly;

	[RequiresAssemblyFiles("Returns <Unknown> for modules with no file path")]
	public override string Name => name;

	public override string ScopeName => scopename;

	public override int MDStreamVersion
	{
		get
		{
			if (_impl == IntPtr.Zero)
			{
				throw new NotSupportedException();
			}
			return GetMDStreamVersion(_impl);
		}
	}

	public override Guid ModuleVersionId => GetModuleVersionId();

	[RequiresAssemblyFiles("Returns <Unknown> for modules with no file path")]
	public override string FullyQualifiedName => fqname;

	public override int MetadataToken => get_MetadataToken(this);

	public override bool IsResource()
	{
		return is_resource;
	}

	[RequiresUnreferencedCode("Types might be removed")]
	public override Type[] FindTypes(TypeFilter filter, object filterCriteria)
	{
		List<Type> list = new List<Type>();
		Type[] types = GetTypes();
		foreach (Type type in types)
		{
			if (filter != null && filter(type, filterCriteria))
			{
				list.Add(type);
			}
		}
		return list.ToArray();
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
	}

	[RequiresUnreferencedCode("Fields might be removed")]
	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		if (IsResource())
		{
			return null;
		}
		return GetGlobalType(_impl)?.GetField(name, bindingAttr);
	}

	[RequiresUnreferencedCode("Fields might be removed")]
	public override FieldInfo[] GetFields(BindingFlags bindingFlags)
	{
		if (IsResource())
		{
			return Array.Empty<FieldInfo>();
		}
		Type globalType = GetGlobalType(_impl);
		if (!(globalType != null))
		{
			return Array.Empty<FieldInfo>();
		}
		return globalType.GetFields(bindingFlags);
	}

	[RequiresUnreferencedCode("Methods might be removed")]
	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		if (IsResource())
		{
			return null;
		}
		Type globalType = GetGlobalType(_impl);
		if (globalType == null)
		{
			return null;
		}
		if (types == null)
		{
			return globalType.GetMethod(name);
		}
		return globalType.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
	}

	[RequiresUnreferencedCode("Methods might be removed")]
	public override MethodInfo[] GetMethods(BindingFlags bindingFlags)
	{
		if (IsResource())
		{
			return Array.Empty<MethodInfo>();
		}
		Type globalType = GetGlobalType(_impl);
		if (!(globalType != null))
		{
			return Array.Empty<MethodInfo>();
		}
		return globalType.GetMethods(bindingFlags);
	}

	public override void GetPEKind(out PortableExecutableKinds peKind, out ImageFileMachine machine)
	{
		GetPEKind(_impl, out peKind, out machine);
	}

	[RequiresUnreferencedCode("Types might be removed by trimming. If the type name is a string literal, consider using Type.GetType instead.")]
	public override Type GetType(string className, bool throwOnError, bool ignoreCase)
	{
		ArgumentException.ThrowIfNullOrEmpty(className, "className");
		return assembly.InternalGetType(this, className, throwOnError, ignoreCase);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(this, attributeType, inherit);
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return ResolveField(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	internal static FieldInfo ResolveField(Module module, nint monoModule, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		ResolveTokenError error;
		nint num = ResolveFieldToken(monoModule, metadataToken, ptrs_from_types(genericTypeArguments), ptrs_from_types(genericMethodArguments), out error);
		if (num == IntPtr.Zero)
		{
			throw resolve_token_exception(module, metadataToken, error, "Field");
		}
		return FieldInfo.GetFieldFromHandle(new RuntimeFieldHandle(num));
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return ResolveMember(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	internal static MemberInfo ResolveMember(Module module, nint monoModule, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		ResolveTokenError error;
		MemberInfo memberInfo = ResolveMemberToken(monoModule, metadataToken, ptrs_from_types(genericTypeArguments), ptrs_from_types(genericMethodArguments), out error);
		if (memberInfo == null)
		{
			throw resolve_token_exception(module, metadataToken, error, "MemberInfo");
		}
		return memberInfo;
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return ResolveMethod(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	internal static MethodBase ResolveMethod(Module module, nint monoModule, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		ResolveTokenError error;
		nint num = ResolveMethodToken(monoModule, metadataToken, ptrs_from_types(genericTypeArguments), ptrs_from_types(genericMethodArguments), out error);
		if (num == IntPtr.Zero)
		{
			throw resolve_token_exception(module, metadataToken, error, "MethodBase");
		}
		return RuntimeMethodInfo.GetMethodFromHandleNoGenericCheck(new RuntimeMethodHandle(num));
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override string ResolveString(int metadataToken)
	{
		return ResolveString(this, _impl, metadataToken);
	}

	internal static string ResolveString(Module module, nint monoModule, int metadataToken)
	{
		ResolveTokenError error;
		string text = ResolveStringToken(monoModule, metadataToken, out error);
		if (text == null)
		{
			throw resolve_token_exception(module, metadataToken, error, "string");
		}
		return text;
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return ResolveType(this, _impl, metadataToken, genericTypeArguments, genericMethodArguments);
	}

	internal static Type ResolveType(Module module, nint monoModule, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		ResolveTokenError error;
		nint num = ResolveTypeToken(monoModule, metadataToken, ptrs_from_types(genericTypeArguments), ptrs_from_types(genericMethodArguments), out error);
		if (num == IntPtr.Zero)
		{
			throw resolve_token_exception(module, metadataToken, error, "Type");
		}
		return Type.GetTypeFromHandle(new RuntimeTypeHandle(num));
	}

	[RequiresUnreferencedCode("Trimming changes metadata tokens")]
	public override byte[] ResolveSignature(int metadataToken)
	{
		return ResolveSignature(this, _impl, metadataToken);
	}

	internal static byte[] ResolveSignature(Module module, nint monoModule, int metadataToken)
	{
		ResolveTokenError error;
		byte[] array = ResolveSignature(monoModule, metadataToken, out error);
		if (array == null)
		{
			throw resolve_token_exception(module, metadataToken, error, "signature");
		}
		return array;
	}

	[RequiresUnreferencedCode("Types might be removed")]
	public override Type[] GetTypes()
	{
		return InternalGetTypes(_impl);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	internal Guid GetModuleVersionId()
	{
		byte[] array = new byte[16];
		GetGuidInternal(_impl, array);
		return new Guid(array);
	}

	[UnconditionalSuppressMessage("SingleFile", "IL3002:RequiresAssemblyFiles", Justification = "Module Name is used only for diagnostic reporting message")]
	internal static Exception resolve_token_exception(Module module, int metadataToken, ResolveTokenError error, string tokenType)
	{
		return resolve_token_exception(module.Name, metadataToken, error, tokenType);
	}

	internal static Exception resolve_token_exception(string name, int metadataToken, ResolveTokenError error, string tokenType)
	{
		if (error == ResolveTokenError.OutOfRange)
		{
			return new ArgumentOutOfRangeException("metadataToken", SR.Format("Argument_InvalidToken", metadataToken, name));
		}
		return new ArgumentException(SR.Format("Argument_ResolveType", metadataToken, tokenType, name), "metadataToken");
	}

	internal static nint[] ptrs_from_types(Type[] types)
	{
		if (types == null)
		{
			return null;
		}
		nint[] array = new nint[types.Length];
		for (int i = 0; i < types.Length; i++)
		{
			if (types[i] == null)
			{
				throw new ArgumentException();
			}
			array[i] = types[i].TypeHandle.Value;
		}
		return array;
	}

	private protected override ModuleHandle GetModuleHandleImpl()
	{
		return new ModuleHandle(_impl);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int get_MetadataToken(Module module);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int GetMDStreamVersion(nint module);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern Type[] InternalGetTypes(nint module);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGuidInternal(nint module, byte[] guid);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern Type GetGlobalType(nint module);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint ResolveTypeToken(nint module, int token, nint[] type_args, nint[] method_args, out ResolveTokenError error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint ResolveMethodToken(nint module, int token, nint[] type_args, nint[] method_args, out ResolveTokenError error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint ResolveFieldToken(nint module, int token, nint[] type_args, nint[] method_args, out ResolveTokenError error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern string ResolveStringToken(nint module, int token, out ResolveTokenError error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern MemberInfo ResolveMemberToken(nint module, int token, nint[] type_args, nint[] method_args, out ResolveTokenError error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern byte[] ResolveSignature(nint module, int metadataToken, out ResolveTokenError error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetPEKind(nint module, out PortableExecutableKinds peKind, out ImageFileMachine machine);
}

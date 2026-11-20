using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection;

internal struct MonoMethodInfo
{
	private Type parent;

	private Type ret;

	internal MethodAttributes attrs;

	internal MethodImplAttributes iattrs;

	private CallingConventions callconv;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_method_info(nint handle, out MonoMethodInfo info);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_method_attributes(nint handle);

	internal static MonoMethodInfo GetMethodInfo(nint handle)
	{
		get_method_info(handle, out var info);
		return info;
	}

	internal static Type GetDeclaringType(nint handle)
	{
		return GetMethodInfo(handle).parent;
	}

	internal static Type GetReturnType(nint handle)
	{
		return GetMethodInfo(handle).ret;
	}

	internal static MethodAttributes GetAttributes(nint handle)
	{
		return (MethodAttributes)get_method_attributes(handle);
	}

	internal static CallingConventions GetCallingConvention(nint handle)
	{
		return GetMethodInfo(handle).callconv;
	}

	internal static MethodImplAttributes GetMethodImplementationFlags(nint handle)
	{
		return GetMethodInfo(handle).iattrs;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern ParameterInfo[] get_parameter_info(nint handle, MemberInfo member);

	internal static ParameterInfo[] GetParametersInfo(nint handle, MemberInfo member)
	{
		return get_parameter_info(handle, member);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern MarshalAsAttribute get_retval_marshal(nint handle);

	internal static ParameterInfo GetReturnParameterInfo(RuntimeMethodInfo method)
	{
		return RuntimeParameterInfo.New(GetReturnType(method.mhandle), method, get_retval_marshal(method.mhandle));
	}
}

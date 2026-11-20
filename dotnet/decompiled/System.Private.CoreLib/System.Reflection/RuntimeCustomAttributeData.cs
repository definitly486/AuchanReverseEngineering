using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Reflection;

internal sealed class RuntimeCustomAttributeData : CustomAttributeData
{
	private sealed class LazyCAttrData
	{
		internal Assembly assembly;

		internal nint data;

		internal uint data_length;
	}

	private ConstructorInfo ctorInfo;

	private IList<CustomAttributeTypedArgument> ctorArgs;

	private IList<CustomAttributeNamedArgument> namedArgs;

	private LazyCAttrData lazyData;

	public override ConstructorInfo Constructor => ctorInfo;

	public override IList<CustomAttributeTypedArgument> ConstructorArguments
	{
		get
		{
			ResolveArguments();
			return ctorArgs;
		}
	}

	public override IList<CustomAttributeNamedArgument> NamedArguments
	{
		get
		{
			ResolveArguments();
			return namedArgs;
		}
	}

	internal RuntimeCustomAttributeData(ConstructorInfo ctorInfo, Assembly assembly, nint data, uint data_length)
	{
		this.ctorInfo = ctorInfo;
		lazyData = new LazyCAttrData();
		lazyData.assembly = assembly;
		lazyData.data = data;
		lazyData.data_length = data_length;
	}

	internal RuntimeCustomAttributeData(ConstructorInfo ctorInfo)
		: this(ctorInfo, Array.Empty<CustomAttributeTypedArgument>(), Array.Empty<CustomAttributeNamedArgument>())
	{
	}

	internal RuntimeCustomAttributeData(ConstructorInfo ctorInfo, IList<CustomAttributeTypedArgument> ctorArgs, IList<CustomAttributeNamedArgument> namedArgs)
	{
		this.ctorInfo = ctorInfo;
		this.ctorArgs = ctorArgs;
		this.namedArgs = namedArgs;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ResolveArgumentsInternal(ConstructorInfo ctor, Assembly assembly, nint data, uint data_length, out object[] ctorArgs, out object[] namedArgs);

	private void ResolveArguments()
	{
		if (lazyData != null)
		{
			ResolveArgumentsInternal(ctorInfo, lazyData.assembly, lazyData.data, lazyData.data_length, out var array, out var array2);
			ctorArgs = Array.AsReadOnly((array != null) ? UnboxValues<CustomAttributeTypedArgument>(array) : Array.Empty<CustomAttributeTypedArgument>());
			namedArgs = Array.AsReadOnly((array2 != null) ? UnboxValues<CustomAttributeNamedArgument>(array2) : Array.Empty<CustomAttributeNamedArgument>());
			lazyData = null;
		}
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeType target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeFieldInfo target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeMethodInfo target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeConstructorInfo target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeEventInfo target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimePropertyInfo target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeModule target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeAssembly target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	internal static IList<CustomAttributeData> GetCustomAttributesInternal(RuntimeParameterInfo target)
	{
		return CustomAttribute.GetCustomAttributesData(target);
	}

	private static T[] UnboxValues<T>(object[] values)
	{
		T[] array = new T[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			array[i] = (T)values[i];
		}
		return array;
	}
}

using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

public static class RuntimeFeature
{
	public const string PortablePdb = "PortablePdb";

	public const string DefaultImplementationsOfInterfaces = "DefaultImplementationsOfInterfaces";

	public const string UnmanagedSignatureCallingConvention = "UnmanagedSignatureCallingConvention";

	public const string CovariantReturnsOfClasses = "CovariantReturnsOfClasses";

	public const string ByRefFields = "ByRefFields";

	public const string ByRefLikeGenerics = "ByRefLikeGenerics";

	public const string VirtualStaticsInInterfaces = "VirtualStaticsInInterfaces";

	public const string NumericIntPtr = "NumericIntPtr";

	[CompilerGenerated]
	private static readonly bool _003CIsDynamicCodeSupported_003Ek__BackingField;

	[FeatureSwitchDefinition("System.Runtime.CompilerServices.RuntimeFeature.IsDynamicCodeSupported")]
	public static bool IsDynamicCodeSupported
	{
		[CompilerGenerated]
		[Intrinsic]
		get
		{
			return true;
		}
	} = !AppContext.TryGetSwitch("System.Runtime.CompilerServices.RuntimeFeature.IsDynamicCodeSupported", out var isEnabled) || isEnabled;

	[FeatureGuard(typeof(RequiresDynamicCodeAttribute))]
	public static bool IsDynamicCodeCompiled
	{
		[Intrinsic]
		get
		{
			return true;
		}
	}

	public static bool IsSupported(string feature)
	{
		switch (feature)
		{
		case "ByRefFields":
		case "PortablePdb":
		case "CovariantReturnsOfClasses":
		case "ByRefLikeGenerics":
		case "UnmanagedSignatureCallingConvention":
		case "DefaultImplementationsOfInterfaces":
		case "VirtualStaticsInInterfaces":
		case "NumericIntPtr":
			return true;
		case "IsDynamicCodeSupported":
			return true;
		case "IsDynamicCodeCompiled":
			return IsDynamicCodeCompiled;
		default:
			return false;
		}
	}
}

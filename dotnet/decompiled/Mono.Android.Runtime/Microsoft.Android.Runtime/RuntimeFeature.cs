using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Microsoft.Android.Runtime;

internal static class RuntimeFeature
{
	private const bool ManagedTypeMapEnabledByDefault = false;

	private const bool IsMonoRuntimeEnabledByDefault = true;

	private const bool IsCoreClrRuntimeEnabledByDefault = false;

	private const bool IsAssignableFromCheckEnabledByDefault = true;

	private const bool StartupHookSupportEnabledByDefault = true;

	private const string FeatureSwitchPrefix = "Microsoft.Android.Runtime.RuntimeFeature.";

	private const string StartupHookProviderSwitch = "System.StartupHookProvider.IsSupported";

	[CompilerGenerated]
	private static readonly bool _003CManagedTypeMap_003Ek__BackingField;

	[CompilerGenerated]
	private static readonly bool _003CIsMonoRuntime_003Ek__BackingField;

	[CompilerGenerated]
	private static readonly bool _003CIsCoreClrRuntime_003Ek__BackingField;

	[CompilerGenerated]
	private static readonly bool _003CStartupHookSupport_003Ek__BackingField;

	[FeatureSwitchDefinition("Microsoft.Android.Runtime.RuntimeFeature.ManagedTypeMap")]
	internal static bool ManagedTypeMap
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
	} = AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.ManagedTypeMap", out var isEnabled) && isEnabled;

	[FeatureSwitchDefinition("Microsoft.Android.Runtime.RuntimeFeature.IsMonoRuntime")]
	internal static bool IsMonoRuntime
	{
		[CompilerGenerated]
		get
		{
			return true;
		}
	} = !AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.IsMonoRuntime", out var isEnabled2) || isEnabled2;

	[FeatureSwitchDefinition("Microsoft.Android.Runtime.RuntimeFeature.IsCoreClrRuntime")]
	internal static bool IsCoreClrRuntime
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
	} = AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.IsCoreClrRuntime", out var isEnabled3) && isEnabled3;

	[FeatureSwitchDefinition("Microsoft.Android.Runtime.RuntimeFeature.IsAssignableFromCheck")]
	internal static bool IsAssignableFromCheck { get; } = !AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.IsAssignableFromCheck", out var isEnabled4) || isEnabled4;

	[FeatureSwitchDefinition("System.StartupHookProvider.IsSupported")]
	[FeatureGuard(typeof(RequiresUnreferencedCodeAttribute))]
	internal static bool StartupHookSupport
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
	} = !AppContext.TryGetSwitch("System.StartupHookProvider.IsSupported", out var isEnabled5) || isEnabled5;
}

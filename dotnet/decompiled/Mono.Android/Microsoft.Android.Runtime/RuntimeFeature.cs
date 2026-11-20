using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Microsoft.Android.Runtime;

internal static class RuntimeFeature
{
	[CompilerGenerated]
	private static readonly bool _003CManagedTypeMap_003Ek__BackingField = AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.ManagedTypeMap", out var isEnabled) && isEnabled;

	[CompilerGenerated]
	private static readonly bool _003CIsMonoRuntime_003Ek__BackingField = !AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.IsMonoRuntime", out var isEnabled2) || isEnabled2;

	[CompilerGenerated]
	private static readonly bool _003CIsCoreClrRuntime_003Ek__BackingField = AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.IsCoreClrRuntime", out var isEnabled3) && isEnabled3;

	[CompilerGenerated]
	private static readonly bool _003CStartupHookSupport_003Ek__BackingField = !AppContext.TryGetSwitch("System.StartupHookProvider.IsSupported", out var isEnabled5) || isEnabled5;

	[FeatureSwitchDefinition("Microsoft.Android.Runtime.RuntimeFeature.IsAssignableFromCheck")]
	internal static bool IsAssignableFromCheck { get; } = !AppContext.TryGetSwitch("Microsoft.Android.Runtime.RuntimeFeature.IsAssignableFromCheck", out var isEnabled4) || isEnabled4;
}

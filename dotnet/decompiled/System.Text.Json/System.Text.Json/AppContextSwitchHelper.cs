using System.Runtime.CompilerServices;

namespace System.Text.Json;

internal static class AppContextSwitchHelper
{
	[CompilerGenerated]
	private static readonly bool _003CIsSourceGenReflectionFallbackEnabled_003Ek__BackingField = AppContext.TryGetSwitch("System.Text.Json.Serialization.EnableSourceGenReflectionFallback", out var isEnabled) && isEnabled;

	public static bool RespectNullableAnnotationsDefault { get; } = AppContext.TryGetSwitch("System.Text.Json.Serialization.RespectNullableAnnotationsDefault", out var isEnabled2) && isEnabled2;

	public static bool RespectRequiredConstructorParametersDefault { get; } = AppContext.TryGetSwitch("System.Text.Json.Serialization.RespectRequiredConstructorParametersDefault", out var isEnabled3) && isEnabled3;
}

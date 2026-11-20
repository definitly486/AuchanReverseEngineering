using System.Runtime.CompilerServices;

namespace System;

internal static class LocalAppContextSwitches
{
	public static bool DefaultActivityIdFormatIsHierarchial { get; } = InitializeDefaultActivityIdFormat();

	private static bool InitializeDefaultActivityIdFormat()
	{
		bool switchValue = false;
		if (!GetSwitchValue("System.Diagnostics.DefaultActivityIdFormatIsHierarchial", ref switchValue))
		{
			string environmentVariable = Environment.GetEnvironmentVariable("DOTNET_SYSTEM_DIAGNOSTICS_DEFAULTACTIVITYIDFORMATISHIERARCHIAL");
			if (environmentVariable != null)
			{
				switchValue = environmentVariable.Equals("true", StringComparison.OrdinalIgnoreCase) || environmentVariable.Equals("1");
			}
		}
		return switchValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool GetSwitchValue(string switchName, ref bool switchValue)
	{
		return AppContext.TryGetSwitch(switchName, out switchValue);
	}
}

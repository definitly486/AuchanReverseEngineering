using System.Resources;
using FxResources.System.Runtime.Serialization.Primitives;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = true;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string OrderCannotBeNegative => "OrderCannotBeNegative";

	private static bool GetUsingResourceKeysSwitchValue()
	{
		return true;
	}

	internal static bool UsingResourceKeys()
	{
		return true;
	}

	private static string GetResourceString(string resourceKey)
	{
		_ = 1;
		return resourceKey;
	}
}

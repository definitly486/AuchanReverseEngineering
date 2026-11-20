using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

internal static class LocalAppContextSwitches
{
	private static int s_enableUnsafeUTF7Encoding;

	private static int s_enforceJapaneseEraYearRanges;

	private static int s_formatJapaneseFirstYearAsANumber;

	private static int s_enforceLegacyJapaneseDateParsing;

	private static int s_preserveEventListenerObjectIdentity;

	private static int s_forceEmitInvoke;

	private static int s_forceInterpretedInvoke;

	private static int s_serializationGuard;

	private static int s_showILOffset;

	[FeatureSwitchDefinition("System.Text.Encoding.EnableUnsafeUTF7Encoding")]
	public static bool EnableUnsafeUTF7Encoding
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return false;
		}
	}

	public static bool EnforceJapaneseEraYearRanges
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetCachedSwitchValue("Switch.System.Globalization.EnforceJapaneseEraYearRanges", ref s_enforceJapaneseEraYearRanges);
		}
	}

	public static bool FormatJapaneseFirstYearAsANumber
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetCachedSwitchValue("Switch.System.Globalization.FormatJapaneseFirstYearAsANumber", ref s_formatJapaneseFirstYearAsANumber);
		}
	}

	public static bool EnforceLegacyJapaneseDateParsing
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetCachedSwitchValue("Switch.System.Globalization.EnforceLegacyJapaneseDateParsing", ref s_enforceLegacyJapaneseDateParsing);
		}
	}

	public static bool PreserveEventListenerObjectIdentity
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetCachedSwitchValue("Switch.System.Diagnostics.EventSource.PreserveEventListenerObjectIdentity", ref s_preserveEventListenerObjectIdentity);
		}
	}

	public static bool ForceEmitInvoke
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetCachedSwitchValue("Switch.System.Reflection.ForceEmitInvoke", ref s_forceEmitInvoke);
		}
	}

	public static bool ForceInterpretedInvoke
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetCachedSwitchValue("Switch.System.Reflection.ForceInterpretedInvoke", ref s_forceInterpretedInvoke);
		}
	}

	public static bool SerializationGuard
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetCachedSwitchValue("Switch.System.Runtime.Serialization.SerializationGuard", ref s_serializationGuard);
		}
	}

	public static bool ShowILOffsets
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return GetDefaultShowILOffsetSetting();
		}
	}

	private static bool GetDefaultShowILOffsetSetting()
	{
		if (s_showILOffset < 0)
		{
			return false;
		}
		if (s_showILOffset > 0)
		{
			return true;
		}
		bool booleanConfig = AppContextConfigHelper.GetBooleanConfig("Switch.System.Diagnostics.StackTrace.ShowILOffsets", defaultValue: false);
		s_showILOffset = (booleanConfig ? 1 : (-1));
		return booleanConfig;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool GetCachedSwitchValue(string switchName, ref int cachedSwitchValue)
	{
		if (cachedSwitchValue < 0)
		{
			return false;
		}
		if (cachedSwitchValue > 0)
		{
			return true;
		}
		return GetCachedSwitchValueInternal(switchName, ref cachedSwitchValue);
	}

	private static bool GetCachedSwitchValueInternal(string switchName, ref int cachedSwitchValue)
	{
		if (!AppContext.TryGetSwitch(switchName, out var isEnabled))
		{
			isEnabled = GetSwitchDefaultValue(switchName);
		}
		AppContext.TryGetSwitch("TestSwitch.LocalAppContext.DisableCaching", out var isEnabled2);
		if (!isEnabled2)
		{
			cachedSwitchValue = (isEnabled ? 1 : (-1));
		}
		return isEnabled;
	}

	private static bool GetSwitchDefaultValue(string switchName)
	{
		return switchName switch
		{
			"Switch.System.Runtime.Serialization.SerializationGuard" => true, 
			"System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization" => true, 
			"System.Xml.XmlResolver.IsNetworkingEnabledByDefault" => true, 
			_ => false, 
		};
	}
}

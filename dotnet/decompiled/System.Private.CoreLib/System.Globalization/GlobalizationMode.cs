using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Globalization;

internal static class GlobalizationMode
{
	private static class Settings
	{
		[CompilerGenerated]
		private static readonly bool _003CInvariant_003Ek__BackingField;

		internal static bool Invariant
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
		}

		internal static bool PredefinedCulturesOnly { get; }

		static Settings()
		{
			Invariant = AppContextConfigHelper.GetBooleanConfig("System.Globalization.Invariant", "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT");
			PredefinedCulturesOnly = AppContextConfigHelper.GetBooleanConfig("System.Globalization.PredefinedCulturesOnly", "DOTNET_SYSTEM_GLOBALIZATION_PREDEFINED_CULTURES_ONLY", GlobalizationMode.Invariant);
			_ = GlobalizationMode.Invariant;
			if (TryGetAppLocalIcuSwitchValue(out var value))
			{
				LoadAppLocalIcu(value);
			}
			else if (LoadICU() == 0)
			{
				Environment.FailFast(GetIcuLoadFailureMessage());
			}
		}

		private static string GetIcuLoadFailureMessage()
		{
			_ = 0;
			_ = 0;
			if (1 == 0)
			{
			}
			return "Unable to load required ICU Globalization data. Please see https://aka.ms/dotnet-missing-libicu for more information";
		}
	}

	internal static bool Invariant => Settings.Invariant;

	internal static bool InvariantNoLoad => Settings.Invariant;

	internal static bool PredefinedCulturesOnly => Settings.PredefinedCulturesOnly;

	private static bool TryGetAppLocalIcuSwitchValue([NotNullWhen(true)] out string value)
	{
		return TryGetStringValue("System.Globalization.AppLocalIcu", "DOTNET_SYSTEM_GLOBALIZATION_APPLOCALICU", out value);
	}

	private static bool TryGetStringValue(string switchName, string envVariable, [NotNullWhen(true)] out string value)
	{
		value = AppContext.GetData(switchName) as string;
		if (string.IsNullOrEmpty(value))
		{
			value = Environment.GetEnvironmentVariable(envVariable);
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
		}
		return true;
	}

	private static void LoadAppLocalIcu(string icuSuffixAndVersion)
	{
		ReadOnlySpan<char> suffix = default(ReadOnlySpan<char>);
		int num = icuSuffixAndVersion.IndexOf(':');
		ReadOnlySpan<char> version;
		if (num >= 0)
		{
			suffix = icuSuffixAndVersion.AsSpan(0, num);
			version = icuSuffixAndVersion.AsSpan(suffix.Length + 1);
		}
		else
		{
			version = icuSuffixAndVersion.AsSpan();
		}
		LoadAppLocalIcuCore(version, suffix);
	}

	private static string CreateLibraryName(ReadOnlySpan<char> baseName, ReadOnlySpan<char> suffix, ReadOnlySpan<char> extension, ReadOnlySpan<char> version, bool versionAtEnd = false)
	{
		if (!versionAtEnd)
		{
			return string.Concat(baseName, suffix, version, extension);
		}
		return string.Concat(baseName, suffix, extension, version);
	}

	private static nint LoadLibrary(string library, bool failOnLoadFailure)
	{
		if (!NativeLibrary.TryLoad(library, typeof(object).Assembly, DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.System32, out var handle) && failOnLoadFailure)
		{
			Environment.FailFast("Failed to load app-local ICU: " + library);
		}
		return handle;
	}

	private static void LoadAppLocalIcuCore(ReadOnlySpan<char> version, ReadOnlySpan<char> suffix)
	{
		string text = ((version.Length > 0) ? "so." : "so");
		bool versionAtEnd = true;
		ReadOnlySpan<char> suffix2 = string.Concat(suffix, ".".AsSpan()).AsSpan();
		LoadLibrary(CreateLibraryName("libicudata".AsSpan(), suffix2, text.AsSpan(), version, versionAtEnd), failOnLoadFailure: true);
		nint icuuc = LoadLibrary(CreateLibraryName("libicuuc".AsSpan(), suffix2, text.AsSpan(), version, versionAtEnd), failOnLoadFailure: true);
		nint icuin = LoadLibrary(CreateLibraryName("libicui18n".AsSpan(), suffix2, text.AsSpan(), version, versionAtEnd), failOnLoadFailure: true);
		Interop.Globalization.InitICUFunctions(icuuc, icuin, version, suffix);
	}

	private static int LoadICU()
	{
		return Interop.Globalization.LoadICU();
	}
}

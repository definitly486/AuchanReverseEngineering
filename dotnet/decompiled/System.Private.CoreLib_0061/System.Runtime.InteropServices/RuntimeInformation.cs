using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices;

public static class RuntimeInformation
{
	private static string s_runtimeIdentifier;

	private static volatile int s_osArchPlusOne;

	[CompilerGenerated]
	private static string _003COSDescription_003Ek__BackingField;

	public static string RuntimeIdentifier
	{
		get
		{
			object obj = s_runtimeIdentifier;
			if (obj == null)
			{
				obj = (AppContext.GetData("RUNTIME_IDENTIFIER") as string) ?? "unknown";
				s_runtimeIdentifier = (string)obj;
			}
			return (string)obj;
		}
	}

	public static Architecture ProcessArchitecture => Architecture.Arm;

	public static string OSDescription => _003COSDescription_003Ek__BackingField ?? (_003COSDescription_003Ek__BackingField = $"Android (API level {Environment.OSVersion.Version.Major})");

	public static Architecture OSArchitecture
	{
		get
		{
			int num = s_osArchPlusOne - 1;
			if (num < 0)
			{
				num = Interop.Sys.GetOSArchitecture();
				if (num < 0)
				{
					num = 2;
				}
				s_osArchPlusOne = num + 1;
			}
			return (Architecture)num;
		}
	}

	public static string FrameworkDescription => ".NET 10.0.12";

	public static bool IsOSPlatform(OSPlatform osPlatform)
	{
		return OperatingSystem.IsOSPlatform(osPlatform.Name);
	}
}

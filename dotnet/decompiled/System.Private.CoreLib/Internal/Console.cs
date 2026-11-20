using System.Runtime.CompilerServices;

namespace Internal;

public static class Console
{
	public static class Error
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void WriteLine()
		{
			Write("\n");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Write(string s)
		{
			Interop.Logcat.AndroidLogPrint(Interop.Logcat.LogLevel.Error, "DOTNET", s ?? string.Empty);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(string? s)
	{
		Write(s + "\n");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine()
	{
		Write("\n");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Write(string s)
	{
		Interop.Logcat.AndroidLogPrint(Interop.Logcat.LogLevel.Debug, "DOTNET", s ?? string.Empty);
	}
}

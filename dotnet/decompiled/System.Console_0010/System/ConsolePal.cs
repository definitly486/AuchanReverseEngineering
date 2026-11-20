using System.IO;
using System.Text;

namespace System;

internal static class ConsolePal
{
	public static Encoding OutputEncoding => Encoding.Unicode;

	public static ConsoleColor BackgroundColor
	{
		get
		{
			throw new PlatformNotSupportedException();
		}
		set
		{
			throw new PlatformNotSupportedException();
		}
	}

	public static ConsoleColor ForegroundColor
	{
		get
		{
			throw new PlatformNotSupportedException();
		}
		set
		{
			throw new PlatformNotSupportedException();
		}
	}

	public static Stream OpenStandardInput()
	{
		throw new PlatformNotSupportedException();
	}

	public static Stream OpenStandardOutput()
	{
		return new LogcatStream(OutputEncoding);
	}

	public static Stream OpenStandardError()
	{
		return new LogcatStream(OutputEncoding);
	}

	public static void SetConsoleOutputEncoding(Encoding enc)
	{
		throw new PlatformNotSupportedException();
	}
}

using System.IO;
using System.Text;

namespace System;

internal sealed class LogcatStream : CachedConsoleStream
{
	public LogcatStream(Encoding encoding)
		: base(encoding)
	{
	}

	protected override void Print(ReadOnlySpan<char> line)
	{
		string message = line.ToString();
		global::Interop.Logcat.AndroidLogPrint(global::Interop.Logcat.LogLevel.Info, "DOTNET", message);
	}
}

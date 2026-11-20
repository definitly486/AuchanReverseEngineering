using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

public class DebugProvider
{
	private sealed class DebugAssertException : Exception
	{
		internal DebugAssertException(string message, string detailMessage, string stackTrace)
			: base(Terminate(message) + Terminate(detailMessage) + stackTrace)
		{
		}

		private static string Terminate(string s)
		{
			if (s == null)
			{
				return s;
			}
			s = s.Trim();
			if (s.Length > 0)
			{
				s += "\n";
			}
			return s;
		}
	}

	private static readonly object s_lock = new object();

	private bool _needIndent = true;

	private string _indentString;

	internal static Action<string, string, string, string> s_FailCore;

	internal static Action<string> s_WriteCore;

	private static readonly bool s_shouldWriteToStdErr = Environment.GetEnvironmentVariable("DOTNET_DebugWriteToStdErr") == "1";

	[DoesNotReturn]
	public virtual void Fail(string? message, string? detailMessage)
	{
		string stackTrace;
		try
		{
			stackTrace = new StackTrace(0, fNeedFileInfo: true).ToString(StackTrace.TraceFormat.Normal);
		}
		catch
		{
			stackTrace = "";
		}
		WriteAssert(stackTrace, message, detailMessage);
		FailCore(stackTrace, message, detailMessage, "Assertion failed.");
	}

	internal void WriteAssert(string stackTrace, string message, string detailMessage)
	{
		WriteLine("DebugAssertBanner" + "\n" + "DebugAssertShortMessage" + "\n" + message + "\n" + "DebugAssertLongMessage" + "\n" + detailMessage + "\n" + stackTrace);
	}

	public virtual void Write(string? message)
	{
		lock (s_lock)
		{
			if (message == null)
			{
				WriteCore(string.Empty);
				return;
			}
			if (_needIndent)
			{
				message = GetIndentString() + message;
				_needIndent = false;
			}
			WriteCore(message);
			if (message.EndsWith("\n", StringComparison.Ordinal))
			{
				_needIndent = true;
			}
		}
	}

	public virtual void WriteLine(string? message)
	{
		Write(message + "\n");
	}

	public virtual void OnIndentLevelChanged(int indentLevel)
	{
	}

	public virtual void OnIndentSizeChanged(int indentSize)
	{
	}

	private string GetIndentString()
	{
		int num = Debug.IndentSize * Debug.IndentLevel;
		string indentString = _indentString;
		if (indentString != null && indentString.Length == num)
		{
			return _indentString;
		}
		return _indentString = new string(' ', num);
	}

	public static void FailCore(string stackTrace, string? message, string? detailMessage, string errorSource)
	{
		if (s_FailCore != null)
		{
			s_FailCore(stackTrace, message, detailMessage, errorSource);
			return;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
			return;
		}
		DebugAssertException ex = new DebugAssertException(message, detailMessage, stackTrace);
		Environment.FailFast(ex.Message, ex, errorSource);
	}

	public static void WriteCore(string message)
	{
		if (s_WriteCore != null)
		{
			s_WriteCore(message);
			return;
		}
		WriteToDebugger(message);
		if (s_shouldWriteToStdErr)
		{
			WriteToStderr(message);
		}
	}

	private static void WriteToDebugger(string message)
	{
		if (Debugger.IsLogging())
		{
			Debugger.Log(0, null, message);
		}
		else
		{
			Interop.Sys.SysLog(Interop.Sys.SysLogPriority.LOG_DEBUG, "%s", message);
		}
	}

	private unsafe static void WriteToStderr(string message)
	{
		byte* ptr = stackalloc byte[256];
		int num = 0;
		while (num < message.Length)
		{
			int num2 = 0;
			while (num2 < 256 && num < message.Length)
			{
				if (message[num] <= '\u007f')
				{
					ptr[num2] = (byte)message[num];
					num2++;
				}
				num++;
			}
			int num3 = 0;
			while (num2 > 0)
			{
				int num4 = Interop.Sys.Write(2, ptr + num3, num2);
				if (num4 < 0)
				{
					return;
				}
				num2 -= num4;
				num3 += num4;
			}
		}
	}
}

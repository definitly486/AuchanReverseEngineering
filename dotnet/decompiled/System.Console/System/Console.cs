using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;

namespace System;

public static class Console
{
	private static readonly object s_syncObject = new object();

	private static TextWriter s_out;

	private static TextWriter s_error;

	private static Encoding s_outputEncoding;

	private static bool s_isOutTextWriterRedirected;

	private static bool s_isErrorTextWriterRedirected;

	private static StrongBox<bool> _isStdOutRedirected;

	private static StrongBox<bool> _isStdErrRedirected;

	public static Encoding OutputEncoding
	{
		get
		{
			Encoding encoding = Volatile.Read(in s_outputEncoding);
			if (encoding == null)
			{
				lock (s_syncObject)
				{
					if (s_outputEncoding == null)
					{
						Volatile.Write(ref s_outputEncoding, ConsolePal.OutputEncoding);
					}
					encoding = s_outputEncoding;
				}
			}
			return encoding;
		}
		[UnsupportedOSPlatform("android")]
		[UnsupportedOSPlatform("ios")]
		[UnsupportedOSPlatform("tvos")]
		set
		{
			ArgumentNullException.ThrowIfNull(value, "value");
			lock (s_syncObject)
			{
				ConsolePal.SetConsoleOutputEncoding(value);
				if (s_out != null && !s_isOutTextWriterRedirected)
				{
					s_out.Flush();
					Volatile.Write(ref s_out, null);
				}
				if (s_error != null && !s_isErrorTextWriterRedirected)
				{
					s_error.Flush();
					Volatile.Write(ref s_error, null);
				}
				Volatile.Write(ref s_outputEncoding, (Encoding)value.Clone());
			}
		}
	}

	public static TextWriter Out
	{
		get
		{
			return Volatile.Read(in s_out) ?? EnsureInitialized();
			static TextWriter EnsureInitialized()
			{
				lock (s_syncObject)
				{
					if (s_out == null)
					{
						Volatile.Write(ref s_out, CreateOutputWriter(ConsolePal.OpenStandardOutput()));
					}
					return s_out;
				}
			}
		}
	}

	public static TextWriter Error
	{
		get
		{
			return Volatile.Read(in s_error) ?? EnsureInitialized();
			static TextWriter EnsureInitialized()
			{
				lock (s_syncObject)
				{
					if (s_error == null)
					{
						Volatile.Write(ref s_error, CreateOutputWriter(ConsolePal.OpenStandardError()));
					}
					return s_error;
				}
			}
		}
	}

	public static bool IsOutputRedirected
	{
		get
		{
			return (Volatile.Read(in _isStdOutRedirected) ?? EnsureInitialized()).Value;
			static StrongBox<bool> EnsureInitialized()
			{
				Volatile.Write(ref _isStdOutRedirected, new StrongBox<bool>(value: false));
				return _isStdOutRedirected;
			}
		}
	}

	public static bool IsErrorRedirected
	{
		get
		{
			return (Volatile.Read(in _isStdErrRedirected) ?? EnsureInitialized()).Value;
			static StrongBox<bool> EnsureInitialized()
			{
				Volatile.Write(ref _isStdErrRedirected, new StrongBox<bool>(value: false));
				return _isStdErrRedirected;
			}
		}
	}

	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	public static ConsoleColor BackgroundColor
	{
		get
		{
			return ConsolePal.BackgroundColor;
		}
		set
		{
			ConsolePal.BackgroundColor = value;
		}
	}

	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	public static ConsoleColor ForegroundColor
	{
		get
		{
			return ConsolePal.ForegroundColor;
		}
		set
		{
			ConsolePal.ForegroundColor = value;
		}
	}

	private static TextWriter CreateOutputWriter(Stream outputStream)
	{
		if (outputStream != Stream.Null)
		{
			return TextWriter.Synchronized(new StreamWriter(outputStream, OutputEncoding.RemovePreamble(), 256, leaveOpen: true)
			{
				AutoFlush = true
			});
		}
		return TextWriter.Null;
	}

	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	public static Stream OpenStandardInput(int bufferSize)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(bufferSize, "bufferSize");
		return ConsolePal.OpenStandardInput();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine()
	{
		Out.WriteLine();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(bool value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(char value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(char[]? buffer)
	{
		Out.WriteLine(buffer);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(char[] buffer, int index, int count)
	{
		Out.WriteLine(buffer, index, count);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(decimal value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(double value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(float value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(int value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static void WriteLine(uint value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(long value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CLSCompliant(false)]
	public static void WriteLine(ulong value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(object? value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(string? value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine(ReadOnlySpan<char> value)
	{
		Out.WriteLine(value);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine([StringSyntax("CompositeFormat")] string format, object? arg0)
	{
		Out.WriteLine(format, arg0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine([StringSyntax("CompositeFormat")] string format, object? arg0, object? arg1)
	{
		Out.WriteLine(format, arg0, arg1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine([StringSyntax("CompositeFormat")] string format, object? arg0, object? arg1, object? arg2)
	{
		Out.WriteLine(format, arg0, arg1, arg2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine([StringSyntax("CompositeFormat")] string format, params object?[]? arg)
	{
		if (arg == null)
		{
			Out.WriteLine(format, null, null);
		}
		else
		{
			Out.WriteLine(format, arg);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WriteLine([StringSyntax("CompositeFormat")] string format, [ParamCollection] scoped ReadOnlySpan<object?> arg)
	{
		Out.WriteLine(format, arg);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Write(string? value)
	{
		Out.Write(value);
	}
}

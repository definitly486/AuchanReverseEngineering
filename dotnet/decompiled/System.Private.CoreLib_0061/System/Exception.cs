using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace System;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class Exception : ISerializable
{
	internal readonly struct DispatchState
	{
		public readonly MonoStackFrame[] StackFrames;

		public DispatchState(MonoStackFrame[] stackFrames)
		{
			StackFrames = stackFrames;
		}
	}

	private string _unused1;

	internal string _message;

	private IDictionary _data;

	private Exception _innerException;

	private string _helpURL;

	private object _traceIPs;

	private string _stackTraceString;

	private string _remoteStackTraceString;

	private int _unused4;

	private object[] _dynamicMethods;

	private int _HResult;

	private string _source;

	private object _unused6;

	internal MonoStackFrame[] foreignExceptionsFrames;

	private nint[] native_trace_ips;

	private int caught_in_unmanaged;

	private protected const string InnerExceptionPrefix = " ---> ";

	private bool HasBeenThrown => _traceIPs != null;

	public MethodBase? TargetSite
	{
		[RequiresUnreferencedCode("Metadata for the method might be incomplete or removed")]
		get
		{
			StackTrace stackTrace = new StackTrace(this, fNeedFileInfo: true);
			if (stackTrace.FrameCount > 0)
			{
				return stackTrace.GetFrame(0)?.GetMethod();
			}
			return null;
		}
	}

	public virtual string Message => _message ?? SR.Format("Exception_WasThrown", GetClassName());

	public virtual IDictionary Data => _data ?? (_data = CreateDataContainer());

	public Exception? InnerException => _innerException;

	public virtual string? HelpLink
	{
		get
		{
			return _helpURL;
		}
		set
		{
			_helpURL = value;
		}
	}

	public virtual string? Source
	{
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The API will return <unknown> if the metadata for current method cannot be established.")]
		get
		{
			return _source ?? (_source = ((!HasBeenThrown) ? null : (TargetSite?.Module.Assembly.GetName().Name ?? "<unknown>")));
		}
		set
		{
			_source = value;
		}
	}

	public int HResult
	{
		get
		{
			return _HResult;
		}
		set
		{
			_HResult = value;
		}
	}

	public virtual string? StackTrace
	{
		get
		{
			string stackTraceString = _stackTraceString;
			string remoteStackTraceString = _remoteStackTraceString;
			if (stackTraceString != null)
			{
				return remoteStackTraceString + stackTraceString;
			}
			if (!HasBeenThrown)
			{
				return remoteStackTraceString;
			}
			return remoteStackTraceString + GetStackTrace();
		}
	}

	private string? SerializationStackTraceString
	{
		get
		{
			string text = _stackTraceString;
			if (text == null && HasBeenThrown)
			{
				text = GetStackTrace();
			}
			return text;
		}
	}

	[Obsolete("BinaryFormatter serialization is obsolete and should not be used. See https://aka.ms/binaryformatter for more information.", DiagnosticId = "SYSLIB0011", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	protected event EventHandler<SafeSerializationEventArgs>? SerializeObjectState
	{
		add
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_SecureBinarySerialization");
		}
		remove
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_SecureBinarySerialization");
		}
	}

	internal static uint GetExceptionCount()
	{
		return (uint)EventPipeInternal.GetRuntimeCounterValue(EventPipeInternal.RuntimeCounters.EXCEPTION_COUNT);
	}

	internal DispatchState CaptureDispatchState()
	{
		MonoStackFrame[] array;
		if (_traceIPs != null)
		{
			Exception o = this;
			MonoStackFrame[] o2 = null;
			System.Diagnostics.StackTrace.GetTrace(ObjectHandleOnStack.Create(ref o), ObjectHandleOnStack.Create(ref o2), 0, needFileInfo: true);
			array = o2;
			if (array.Length != 0)
			{
				array[^1].isLastFrameFromForeignException = true;
			}
			MonoStackFrame[] array2 = foreignExceptionsFrames;
			if (array2 != null)
			{
				MonoStackFrame[] array3 = new MonoStackFrame[array.Length + array2.Length];
				Array.Copy(array2, 0, array3, 0, array2.Length);
				Array.Copy(array, 0, array3, array2.Length, array.Length);
				array = array3;
			}
		}
		else
		{
			array = foreignExceptionsFrames;
		}
		return new DispatchState(array);
	}

	internal void RestoreDispatchState(in DispatchState state)
	{
		foreignExceptionsFrames = state.StackFrames;
		_stackTraceString = null;
	}

	private bool CanSetRemoteStackTrace()
	{
		if (_traceIPs != null || _stackTraceString != null || _remoteStackTraceString != null)
		{
			ThrowHelper.ThrowInvalidOperationException();
		}
		return true;
	}

	private static ListDictionaryInternal CreateDataContainer()
	{
		return new ListDictionaryInternal();
	}

	public Exception()
	{
		_HResult = -2146233088;
	}

	public Exception(string? message)
		: this()
	{
		_message = message;
	}

	public Exception(string? message, Exception? innerException)
		: this()
	{
		_message = message;
		_innerException = innerException;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected Exception(SerializationInfo info, StreamingContext context)
	{
		ArgumentNullException.ThrowIfNull(info, "info");
		_message = info.GetString("Message");
		_data = (IDictionary)info.GetValueNoThrow("Data", typeof(IDictionary));
		_innerException = (Exception)info.GetValue("InnerException", typeof(Exception));
		_helpURL = info.GetString("HelpURL");
		_stackTraceString = info.GetString("StackTraceString");
		_remoteStackTraceString = info.GetString("RemoteStackTraceString");
		_HResult = info.GetInt32("HResult");
		_source = info.GetString("Source");
	}

	private string GetClassName()
	{
		return GetType().ToString();
	}

	public virtual Exception GetBaseException()
	{
		Exception innerException = InnerException;
		Exception result = this;
		while (innerException != null)
		{
			result = innerException;
			innerException = innerException.InnerException;
		}
		return result;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		ArgumentNullException.ThrowIfNull(info, "info");
		if (_source == null)
		{
			_source = Source;
		}
		info.AddValue("ClassName", GetClassName(), typeof(string));
		info.AddValue("Message", _message, typeof(string));
		info.AddValue("Data", _data, typeof(IDictionary));
		info.AddValue("InnerException", _innerException, typeof(Exception));
		info.AddValue("HelpURL", _helpURL, typeof(string));
		info.AddValue("StackTraceString", SerializationStackTraceString, typeof(string));
		info.AddValue("RemoteStackTraceString", _remoteStackTraceString, typeof(string));
		info.AddValue("RemoteStackIndex", 0, typeof(int));
		info.AddValue("ExceptionMethod", null, typeof(string));
		info.AddValue("HResult", _HResult);
		info.AddValue("Source", _source, typeof(string));
		info.AddValue("WatsonBuckets", null, typeof(byte[]));
	}

	public override string ToString()
	{
		string className = GetClassName();
		string message = Message;
		string text = _innerException?.ToString() ?? "";
		string text2 = "Exception_EndOfInnerExceptionStack";
		string stackTrace = StackTrace;
		int num = className.Length;
		checked
		{
			if (!string.IsNullOrEmpty(message))
			{
				num += 2 + message.Length;
			}
			if (_innerException != null)
			{
				num += "\n".Length + " ---> ".Length + text.Length + "\n".Length + 3 + text2.Length;
			}
			if (stackTrace != null)
			{
				num += "\n".Length + stackTrace.Length;
			}
			string text3 = string.FastAllocateString(num);
			Span<char> dest = new Span<char>(ref text3.GetRawStringData(), text3.Length);
			Write(className, ref dest);
			if (!string.IsNullOrEmpty(message))
			{
				Write(": ", ref dest);
				Write(message, ref dest);
			}
			if (_innerException != null)
			{
				Write("\n", ref dest);
				Write(" ---> ", ref dest);
				Write(text, ref dest);
				Write("\n", ref dest);
				Write("   ", ref dest);
				Write(text2, ref dest);
			}
			if (stackTrace != null)
			{
				Write("\n", ref dest);
				Write(stackTrace, ref dest);
			}
			return text3;
		}
		static void Write(string source, ref Span<char> reference)
		{
			source.CopyTo(reference);
			reference = reference.Slice(source.Length);
		}
	}

	public new Type GetType()
	{
		return base.GetType();
	}

	private string GetStackTrace()
	{
		return new StackTrace(this, fNeedFileInfo: true).ToString(System.Diagnostics.StackTrace.TraceFormat.Normal);
	}

	[StackTraceHidden]
	internal void SetCurrentStackTrace()
	{
		if (CanSetRemoteStackTrace())
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			new StackTrace(fNeedFileInfo: true).ToString(System.Diagnostics.StackTrace.TraceFormat.TrailingNewLine, stringBuilder);
			stringBuilder.AppendLine("Exception_EndStackTraceFromPreviousThrow");
			_remoteStackTraceString = stringBuilder.ToString();
		}
	}

	internal void SetRemoteStackTrace(string stackTrace)
	{
		if (CanSetRemoteStackTrace())
		{
			_remoteStackTraceString = stackTrace + "\n" + "Exception_EndStackTraceFromPreviousThrow" + "\n";
		}
	}
}

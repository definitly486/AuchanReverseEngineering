using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.IO;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class FileLoadException : IOException
{
	public override string Message => _message ?? (_message = FormatFileLoadExceptionMessage(FileName, base.HResult));

	public string? FileName { get; }

	public string? FusionLog { get; }

	internal static string FormatFileLoadExceptionMessage(string fileName, int hResult)
	{
		return "";
	}

	public FileLoadException()
		: base("IO_FileLoad")
	{
		base.HResult = -2146232799;
	}

	public FileLoadException(string? message)
		: base(message)
	{
		base.HResult = -2146232799;
	}

	public FileLoadException(string? message, Exception? inner)
		: base(message, inner)
	{
		base.HResult = -2146232799;
	}

	public FileLoadException(string? message, string? fileName)
		: base(message)
	{
		base.HResult = -2146232799;
		FileName = fileName;
	}

	public FileLoadException(string? message, string? fileName, Exception? inner)
		: base(message, inner)
	{
		base.HResult = -2146232799;
		FileName = fileName;
	}

	public override string ToString()
	{
		string text = GetType().ToString() + ": " + Message;
		if (!string.IsNullOrEmpty(FileName))
		{
			text = text + "\n" + SR.Format("IO_FileName_Name", FileName);
		}
		if (base.InnerException != null)
		{
			text = text + "\n ---> " + base.InnerException.ToString();
		}
		if (StackTrace != null)
		{
			text = text + "\n" + StackTrace;
		}
		if (FusionLog != null)
		{
			if (text == null)
			{
				text = " ";
			}
			text = text + "\n\n" + FusionLog;
		}
		return text;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected FileLoadException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		FileName = info.GetString("FileLoad_FileName");
		FusionLog = info.GetString("FileLoad_FusionLog");
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("FileLoad_FileName", FileName, typeof(string));
		info.AddValue("FileLoad_FusionLog", FusionLog, typeof(string));
	}
}

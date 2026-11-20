using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class TypeLoadException : SystemException
{
	private string _className;

	private string _assemblyName;

	private readonly string _messageArg;

	private readonly int _resourceId;

	public override string Message
	{
		get
		{
			SetMessageField();
			return _message;
		}
	}

	public string TypeName => _className ?? string.Empty;

	private TypeLoadException(string className, string assemblyName)
		: this(null)
	{
		_className = className;
		_assemblyName = assemblyName;
	}

	internal TypeLoadException(string message, string typeName, bool _ = true)
		: base(message)
	{
		base.HResult = -2146233054;
		_className = typeName;
	}

	private void SetMessageField()
	{
		if (_message == null)
		{
			if (_className == null)
			{
				_message = "Arg_TypeLoadException";
			}
			else
			{
				_message = SR.Format("ClassLoad_General", _className, _assemblyName ?? "IO_UnknownFileName");
			}
		}
	}

	public TypeLoadException()
		: base("Arg_TypeLoadException")
	{
		base.HResult = -2146233054;
	}

	public TypeLoadException(string? message)
		: base(message)
	{
		base.HResult = -2146233054;
	}

	public TypeLoadException(string? message, Exception? inner)
		: base(message, inner)
	{
		base.HResult = -2146233054;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected TypeLoadException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_className = info.GetString("TypeLoadClassName");
		_assemblyName = info.GetString("TypeLoadAssemblyName");
		_messageArg = info.GetString("TypeLoadMessageArg");
		_resourceId = info.GetInt32("TypeLoadResourceID");
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("TypeLoadClassName", _className, typeof(string));
		info.AddValue("TypeLoadAssemblyName", _assemblyName, typeof(string));
		info.AddValue("TypeLoadMessageArg", _messageArg, typeof(string));
		info.AddValue("TypeLoadResourceID", _resourceId);
	}
}

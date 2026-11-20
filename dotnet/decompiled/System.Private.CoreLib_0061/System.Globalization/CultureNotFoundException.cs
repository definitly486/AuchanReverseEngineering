using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Globalization;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class CultureNotFoundException : ArgumentException
{
	private readonly string _invalidCultureName;

	private readonly int? _invalidCultureId;

	public virtual int? InvalidCultureId => _invalidCultureId;

	public virtual string? InvalidCultureName => _invalidCultureName;

	private static string DefaultMessage => "Argument_CultureNotSupported";

	private string? FormattedInvalidCultureId
	{
		get
		{
			if (!InvalidCultureId.HasValue)
			{
				return InvalidCultureName;
			}
			return string.Format(CultureInfo.InvariantCulture, "{0} (0x{0:x4})", InvalidCultureId.Value);
		}
	}

	public override string Message
	{
		get
		{
			string message = base.Message;
			if (_invalidCultureId.HasValue || _invalidCultureName != null)
			{
				string text = SR.Format("Argument_CultureInvalidIdentifier", FormattedInvalidCultureId);
				if (message == null)
				{
					return text;
				}
				return message + "\n" + text;
			}
			return message;
		}
	}

	public CultureNotFoundException()
		: base("Argument_CultureNotSupported")
	{
	}

	public CultureNotFoundException(string? message)
		: base(message ?? "Argument_CultureNotSupported")
	{
	}

	public CultureNotFoundException(string? paramName, string? message)
		: base(message ?? "Argument_CultureNotSupported", paramName)
	{
	}

	public CultureNotFoundException(string? message, Exception? innerException)
		: base(message ?? "Argument_CultureNotSupported", innerException)
	{
	}

	public CultureNotFoundException(string? paramName, string? invalidCultureName, string? message)
		: base(message ?? "Argument_CultureNotSupported", paramName)
	{
		_invalidCultureName = invalidCultureName;
	}

	public CultureNotFoundException(string? message, string? invalidCultureName, Exception? innerException)
		: base(message ?? "Argument_CultureNotSupported", innerException)
	{
		_invalidCultureName = invalidCultureName;
	}

	public CultureNotFoundException(string? message, int invalidCultureId, Exception? innerException)
		: base(message ?? "Argument_CultureNotSupported", innerException)
	{
		_invalidCultureId = invalidCultureId;
	}

	public CultureNotFoundException(string? paramName, int invalidCultureId, string? message)
		: base(message ?? "Argument_CultureNotSupported", paramName)
	{
		_invalidCultureId = invalidCultureId;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected CultureNotFoundException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_invalidCultureId = (int?)info.GetValue("InvalidCultureId", typeof(int?));
		_invalidCultureName = (string)info.GetValue("InvalidCultureName", typeof(string));
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("InvalidCultureId", _invalidCultureId, typeof(int?));
		info.AddValue("InvalidCultureName", _invalidCultureName, typeof(string));
	}
}

namespace System.Formats.Asn1;

[Serializable]
public class AsnContentException : Exception
{
	public AsnContentException()
		: base("ContentException_DefaultMessage")
	{
	}

	public AsnContentException(string? message)
		: base(message ?? "ContentException_DefaultMessage")
	{
	}

	public AsnContentException(string? message, Exception? inner)
		: base(message ?? "ContentException_DefaultMessage", inner)
	{
	}
}

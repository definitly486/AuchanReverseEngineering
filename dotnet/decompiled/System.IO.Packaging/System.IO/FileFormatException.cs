using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.IO;

[Serializable]
[TypeForwardedFrom("WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")]
public class FileFormatException : FormatException
{
	private readonly Uri _sourceUri;

	public Uri SourceUri => _sourceUri;

	public FileFormatException(string message)
		: base(message)
	{
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("SourceUri", SourceUri?.GetComponents(UriComponents.SerializationInfoString, UriFormat.SafeUnescaped), typeof(string));
	}
}

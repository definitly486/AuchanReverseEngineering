using System;
using System.Net.Http;

namespace Refit;

public class ByteArrayPart : MultipartItem
{
	public byte[] Value { get; } = value ?? throw new ArgumentNullException("value");

	public ByteArrayPart(byte[] value, string fileName, string? contentType = null, string? name = null)
		: base(fileName, contentType, name)
	{
	}

	protected override HttpContent CreateContent()
	{
		return new ByteArrayContent(Value);
	}
}

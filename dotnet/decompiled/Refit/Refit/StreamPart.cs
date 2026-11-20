using System;
using System.IO;
using System.Net.Http;

namespace Refit;

public class StreamPart : MultipartItem
{
	public Stream Value { get; } = value ?? throw new ArgumentNullException("value");

	public StreamPart(Stream value, string fileName, string? contentType = null, string? name = null)
		: base(fileName, contentType, name)
	{
	}

	protected override HttpContent CreateContent()
	{
		return new StreamContent(Value);
	}
}

using System;
using System.IO;
using System.Net.Http;

namespace Refit;

public class FileInfoPart : MultipartItem
{
	public FileInfo Value { get; } = value ?? throw new ArgumentNullException("value");

	public FileInfoPart(FileInfo value, string fileName, string? contentType = null, string? name = null)
		: base(fileName, contentType, name)
	{
	}

	protected override HttpContent CreateContent()
	{
		return new StreamContent(Value.OpenRead());
	}
}

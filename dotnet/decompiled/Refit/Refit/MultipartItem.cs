using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Refit;

public abstract class MultipartItem
{
	public string? Name { get; }

	public string? ContentType { get; }

	public string FileName { get; }

	protected MultipartItem(string fileName, string? contentType)
	{
		ContentType = contentType;
		FileName = fileName ?? throw new ArgumentNullException("fileName");
		base._002Ector();
	}

	public MultipartItem(string fileName, string? contentType, string? name)
		: this(fileName, contentType)
	{
		Name = name;
	}

	public HttpContent ToContent()
	{
		HttpContent httpContent = CreateContent();
		if (!string.IsNullOrEmpty(ContentType))
		{
			httpContent.Headers.ContentType = new MediaTypeHeaderValue(ContentType);
		}
		return httpContent;
	}

	protected abstract HttpContent CreateContent();
}

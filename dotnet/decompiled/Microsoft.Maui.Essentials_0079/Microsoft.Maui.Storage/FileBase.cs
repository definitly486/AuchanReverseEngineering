using System;
using System.IO;
using System.Threading.Tasks;
using Android.Webkit;

namespace Microsoft.Maui.Storage;

public abstract class FileBase
{
	private string? contentType;

	private string? fileName;

	public string FullPath { get; internal set; }

	public string ContentType
	{
		get
		{
			return GetContentType();
		}
		set
		{
			contentType = value;
		}
	}

	public string FileName => GetFileName();

	internal FileBase(string fullPath)
	{
		if (fullPath == null)
		{
			throw new ArgumentNullException("fullPath");
		}
		if (string.IsNullOrWhiteSpace(fullPath))
		{
			throw new ArgumentException("The file path cannot be an empty string.", "fullPath");
		}
		if (string.IsNullOrWhiteSpace(Path.GetFileName(fullPath)))
		{
			throw new ArgumentException("The file path must be a file path.", "fullPath");
		}
		FullPath = fullPath;
	}

	internal FileBase(string fullPath, string contentType)
		: this(fullPath)
	{
		FullPath = fullPath;
		ContentType = contentType;
	}

	internal string GetContentType()
	{
		if (!string.IsNullOrWhiteSpace(contentType))
		{
			return contentType;
		}
		string extension = Path.GetExtension(FullPath);
		if (!string.IsNullOrWhiteSpace(extension))
		{
			string text = PlatformGetContentType(extension);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		return "application/octet-stream";
	}

	internal string GetFileName()
	{
		if (!string.IsNullOrWhiteSpace(fileName))
		{
			return fileName;
		}
		if (!string.IsNullOrWhiteSpace(FullPath))
		{
			return Path.GetFileName(FullPath);
		}
		throw new InvalidOperationException("Unable to determine the file name from '" + FullPath + "'.");
	}

	public Task<Stream> OpenReadAsync()
	{
		return PlatformOpenReadAsync();
	}

	private string PlatformGetContentType(string extension)
	{
		return MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension.TrimStart('.'));
	}

	internal virtual Task<Stream> PlatformOpenReadAsync()
	{
		FileStream result = File.OpenRead(FullPath);
		return Task.FromResult((Stream)result);
	}
}

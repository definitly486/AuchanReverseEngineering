using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Versioning;

namespace System.IO;

public abstract class FileSystemInfo : MarshalByRefObject, ISerializable
{
	protected string FullPath;

	protected string OriginalPath;

	internal string _name;

	private string _linkTarget;

	private bool _linkTargetIsValid;

	private readonly bool _asDirectory;

	private FileStatus _fileStatus;

	public virtual string FullName => FullPath;

	public string Extension
	{
		get
		{
			int length = FullPath.Length;
			int num = length;
			while (--num >= 0)
			{
				char c = FullPath[num];
				if (c == '.')
				{
					return FullPath.Substring(num, length - num);
				}
				if (PathInternal.IsDirectorySeparator(c) || c == Path.VolumeSeparatorChar)
				{
					break;
				}
			}
			return string.Empty;
		}
	}

	public abstract string Name { get; }

	public abstract bool Exists { get; }

	public DateTime CreationTime
	{
		get
		{
			return CreationTimeUtc.ToLocalTime();
		}
		set
		{
			CreationTimeUtc = value.ToUniversalTime();
		}
	}

	public DateTime CreationTimeUtc
	{
		get
		{
			return CreationTimeCore.UtcDateTime;
		}
		set
		{
			CreationTimeCore = File.GetUtcDateTimeOffset(value);
		}
	}

	public DateTime LastAccessTime
	{
		get
		{
			return LastAccessTimeUtc.ToLocalTime();
		}
		set
		{
			LastAccessTimeUtc = value.ToUniversalTime();
		}
	}

	public DateTime LastAccessTimeUtc
	{
		get
		{
			return LastAccessTimeCore.UtcDateTime;
		}
		set
		{
			LastAccessTimeCore = File.GetUtcDateTimeOffset(value);
		}
	}

	public DateTime LastWriteTime
	{
		get
		{
			return LastWriteTimeUtc.ToLocalTime();
		}
		set
		{
			LastWriteTimeUtc = value.ToUniversalTime();
		}
	}

	public DateTime LastWriteTimeUtc
	{
		get
		{
			return LastWriteTimeCore.UtcDateTime;
		}
		set
		{
			LastWriteTimeCore = File.GetUtcDateTimeOffset(value);
		}
	}

	public string? LinkTarget
	{
		get
		{
			if (_linkTargetIsValid)
			{
				return _linkTarget;
			}
			_linkTarget = FileSystem.GetLinkTarget(FullPath.AsSpan(), this is DirectoryInfo);
			_linkTargetIsValid = true;
			return _linkTarget;
		}
	}

	public UnixFileMode UnixFileMode
	{
		get
		{
			return UnixFileModeCore;
		}
		[UnsupportedOSPlatform("windows")]
		set
		{
			UnixFileModeCore = value;
		}
	}

	public FileAttributes Attributes
	{
		get
		{
			return _fileStatus.GetAttributes(FullPath.AsSpan(), Name.AsSpan());
		}
		set
		{
			_fileStatus.SetAttributes(FullPath, value, _asDirectory);
		}
	}

	internal bool ExistsCore => _fileStatus.GetExists(FullPath.AsSpan(), _asDirectory);

	internal DateTimeOffset CreationTimeCore
	{
		get
		{
			return _fileStatus.GetCreationTime(FullPath.AsSpan());
		}
		set
		{
			_fileStatus.SetCreationTime(FullPath, value, _asDirectory);
		}
	}

	internal DateTimeOffset LastAccessTimeCore
	{
		get
		{
			return _fileStatus.GetLastAccessTime(FullPath.AsSpan());
		}
		set
		{
			_fileStatus.SetLastAccessTime(FullPath, value, _asDirectory);
		}
	}

	internal DateTimeOffset LastWriteTimeCore
	{
		get
		{
			return _fileStatus.GetLastWriteTime(FullPath.AsSpan());
		}
		set
		{
			_fileStatus.SetLastWriteTime(FullPath, value, _asDirectory);
		}
	}

	internal long LengthCore => _fileStatus.GetLength(FullPath.AsSpan());

	internal UnixFileMode UnixFileModeCore
	{
		get
		{
			return _fileStatus.GetUnixFileMode(FullPath.AsSpan());
		}
		set
		{
			_fileStatus.SetUnixFileMode(FullPath, value);
		}
	}

	internal string NormalizedPath => FullPath;

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected FileSystemInfo(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}

	internal void Invalidate()
	{
		_linkTargetIsValid = false;
		InvalidateCore();
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}

	public abstract void Delete();

	public void CreateAsSymbolicLink(string pathToTarget)
	{
		FileSystem.VerifyValidPath(pathToTarget, "pathToTarget");
		FileSystem.CreateSymbolicLink(OriginalPath, pathToTarget, this is DirectoryInfo);
		Invalidate();
	}

	public FileSystemInfo? ResolveLinkTarget(bool returnFinalTarget)
	{
		return FileSystem.ResolveLinkTarget(FullPath, returnFinalTarget, this is DirectoryInfo);
	}

	public override string ToString()
	{
		return OriginalPath ?? string.Empty;
	}

	protected FileSystemInfo()
	{
		_asDirectory = this is DirectoryInfo;
	}

	internal static FileSystemInfo Create(string fullPath, string fileName, bool asDirectory, ref FileStatus fileStatus)
	{
		FileSystemInfo obj = (asDirectory ? ((FileSystemInfo)new DirectoryInfo(fullPath, null, fileName, isNormalized: true)) : ((FileSystemInfo)new FileInfo(fullPath, null, fileName, isNormalized: true)));
		obj.Init(ref fileStatus);
		return obj;
	}

	internal void InvalidateCore()
	{
		_fileStatus.InvalidateCaches();
	}

	internal void Init(ref FileStatus fileStatus)
	{
		_fileStatus = fileStatus;
		_fileStatus.EnsureCachesInitialized(FullPath.AsSpan());
	}

	public void Refresh()
	{
		_linkTargetIsValid = false;
		_fileStatus.RefreshCaches(FullPath.AsSpan());
	}
}

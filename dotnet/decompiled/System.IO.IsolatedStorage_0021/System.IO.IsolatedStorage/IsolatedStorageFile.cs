using System.Text;

namespace System.IO.IsolatedStorage;

public sealed class IsolatedStorageFile : IsolatedStorage, IDisposable
{
	private bool _disposed;

	private bool _closed;

	private readonly object _internalLock = new object();

	private readonly string _rootDirectory;

	private string RootDirectory => _rootDirectory;

	internal bool Disposed => _disposed;

	internal bool IsDeleted
	{
		get
		{
			try
			{
				return !Directory.Exists(RootDirectory);
			}
			catch (IOException)
			{
				return true;
			}
			catch (UnauthorizedAccessException)
			{
				return true;
			}
		}
	}

	public void Close()
	{
		if (Helper.IsRoaming(base.Scope))
		{
			return;
		}
		lock (_internalLock)
		{
			if (!_closed)
			{
				_closed = true;
				GC.SuppressFinalize(this);
			}
		}
	}

	public void DeleteFile(string file)
	{
		ArgumentNullException.ThrowIfNull(file, "file");
		EnsureStoreIsValid();
		try
		{
			File.Delete(GetFullPath(file));
		}
		catch (Exception rootCause)
		{
			throw GetIsolatedStorageException("IsolatedStorage_DeleteFile", rootCause);
		}
	}

	public bool FileExists(string path)
	{
		ArgumentNullException.ThrowIfNull(path, "path");
		EnsureStoreIsValid();
		return File.Exists(GetFullPath(path));
	}

	public bool DirectoryExists(string path)
	{
		ArgumentNullException.ThrowIfNull(path, "path");
		EnsureStoreIsValid();
		return Directory.Exists(GetFullPath(path));
	}

	public void CreateDirectory(string dir)
	{
		ArgumentNullException.ThrowIfNull(dir, "dir");
		EnsureStoreIsValid();
		string fullPath = GetFullPath(dir);
		if (Directory.Exists(fullPath))
		{
			return;
		}
		try
		{
			Directory.CreateDirectory(fullPath);
		}
		catch (Exception rootCause)
		{
			throw GetIsolatedStorageException("IsolatedStorage_CreateDirectory", rootCause);
		}
	}

	public IsolatedStorageFileStream OpenFile(string path, FileMode mode, FileAccess access, FileShare share)
	{
		EnsureStoreIsValid();
		return new IsolatedStorageFileStream(path, mode, access, share, this);
	}

	public static IsolatedStorageFile GetUserStoreForApplication()
	{
		return GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Application);
	}

	public static IsolatedStorageFile GetUserStoreForDomain()
	{
		return GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly);
	}

	private static IsolatedStorageFile GetStore(IsolatedStorageScope scope)
	{
		return new IsolatedStorageFile(scope);
	}

	internal string GetFullPath(string partialPath)
	{
		int i;
		for (i = 0; i < partialPath.Length && (partialPath[i] == Path.DirectorySeparatorChar || partialPath[i] == Path.AltDirectorySeparatorChar); i++)
		{
		}
		partialPath = partialPath.Substring(i);
		return Path.Combine(RootDirectory, partialPath);
	}

	internal void EnsureStoreIsValid()
	{
		if (Disposed)
		{
			throw new ObjectDisposedException(null, "IsolatedStorage_StoreNotOpen");
		}
		if (_closed || IsDeleted)
		{
			throw new InvalidOperationException("IsolatedStorage_StoreNotOpen");
		}
	}

	public void Dispose()
	{
		Close();
		_disposed = true;
	}

	internal static Exception GetIsolatedStorageException(string exceptionMsg, Exception rootCause)
	{
		return new IsolatedStorageException(exceptionMsg, rootCause)
		{
			_underlyingException = rootCause
		};
	}

	internal IsolatedStorageFile(IsolatedStorageScope scope)
	{
		InitStore(scope, null, null);
		StringBuilder stringBuilder = new StringBuilder(GetIsolatedStorageRoot());
		string text = stringBuilder.ToString() + SeparatorExternal;
		if (Helper.IsApplication(scope) && Directory.Exists(text + "AppFiles"))
		{
			stringBuilder.Append(SeparatorExternal);
			stringBuilder.Append("AppFiles");
			stringBuilder.Append(SeparatorExternal);
		}
		else if (Helper.IsDomain(scope) && Directory.Exists(text + "Files"))
		{
			stringBuilder.Append(SeparatorExternal);
			stringBuilder.Append("Files");
			stringBuilder.Append(SeparatorExternal);
		}
		else if (Directory.Exists(text + "AssemFiles"))
		{
			stringBuilder.Append(SeparatorExternal);
			stringBuilder.Append("AssemFiles");
			stringBuilder.Append(SeparatorExternal);
		}
		_rootDirectory = stringBuilder.ToString();
		Helper.CreateDirectory(_rootDirectory, scope);
	}

	private string GetIsolatedStorageRoot()
	{
		return Helper.GetRootDirectory(base.Scope);
	}
}

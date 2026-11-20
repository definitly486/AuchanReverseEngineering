using System.Collections.Generic;

namespace System.IO.Packaging;

public abstract class PackagePart
{
	private PackUriHelper.ValidatedPartUri _uri;

	private Package _container;

	private ContentType _contentType;

	private List<Stream> _requestedStreams;

	private InternalRelationshipCollection _relationships;

	private CompressionOption _compressionOption = CompressionOption.NotCompressed;

	private bool _disposed;

	private bool _deleted;

	private bool _isRelationshipPart;

	public Uri Uri
	{
		get
		{
			CheckInvalidState();
			return _uri;
		}
	}

	public Package Package
	{
		get
		{
			CheckInvalidState();
			return _container;
		}
	}

	public CompressionOption CompressionOption
	{
		get
		{
			CheckInvalidState();
			return _compressionOption;
		}
	}

	internal bool IsRelationshipPart => _isRelationshipPart;

	internal bool IsDeleted
	{
		get
		{
			return _deleted;
		}
		set
		{
			_deleted = value;
		}
	}

	internal bool IsClosed => _disposed;

	internal ContentType ValidatedContentType => _contentType;

	protected PackagePart(Package package, Uri partUri, string contentType, CompressionOption compressionOption)
	{
		if (package == null)
		{
			throw new ArgumentNullException("package");
		}
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		Package.ThrowIfCompressionOptionInvalid(compressionOption);
		_uri = PackUriHelper.ValidatePartUri(partUri);
		_container = package;
		if (contentType == null)
		{
			_contentType = null;
		}
		else
		{
			_contentType = new ContentType(contentType);
		}
		_requestedStreams = null;
		_compressionOption = compressionOption;
		_isRelationshipPart = PackUriHelper.IsRelationshipPartUri(partUri);
	}

	public Stream GetStream()
	{
		CheckInvalidState();
		return GetStream(FileMode.OpenOrCreate, _container.FileOpenAccess);
	}

	public Stream GetStream(FileMode mode, FileAccess access)
	{
		CheckInvalidState();
		ThrowIfOpenAccessModesAreIncompatible(mode, access);
		switch (mode)
		{
		case FileMode.CreateNew:
			throw new ArgumentException(System.SR.CreateNewNotSupported);
		case FileMode.Truncate:
			throw new ArgumentException(System.SR.TruncateNotSupported);
		default:
		{
			Stream streamCore = GetStreamCore(mode, access);
			if (streamCore == null)
			{
				throw new IOException(System.SR.NullStreamReturned);
			}
			if (_requestedStreams == null)
			{
				_requestedStreams = new List<Stream>();
			}
			CleanUpRequestedStreamsList();
			_requestedStreams.Add(streamCore);
			return streamCore;
		}
		}
	}

	protected abstract Stream GetStreamCore(FileMode mode, FileAccess access);

	public PackageRelationship CreateRelationship(Uri targetUri, TargetMode targetMode, string relationshipType, string id)
	{
		CheckInvalidState();
		_container.ThrowIfReadOnly();
		EnsureRelationships();
		return _relationships.Add(targetUri, targetMode, relationshipType, id);
	}

	internal void ClearRelationships()
	{
		if (_relationships != null)
		{
			_relationships.Clear();
		}
	}

	internal void Flush()
	{
		if (_requestedStreams == null)
		{
			return;
		}
		foreach (Stream requestedStream in _requestedStreams)
		{
			if (requestedStream.CanWrite)
			{
				requestedStream.Flush();
			}
		}
	}

	internal void Close()
	{
		if (_disposed)
		{
			return;
		}
		try
		{
			if (_requestedStreams == null)
			{
				return;
			}
			if (!_deleted)
			{
				foreach (Stream requestedStream in _requestedStreams)
				{
					requestedStream.Dispose();
				}
			}
			_requestedStreams.Clear();
		}
		finally
		{
			_requestedStreams = null;
			_relationships = null;
			_container = null;
			_disposed = true;
		}
	}

	internal void FlushRelationships()
	{
		if (_relationships != null && _container.FileOpenAccess != FileAccess.Read)
		{
			_relationships.Flush();
		}
	}

	internal void CloseRelationships()
	{
		if (!_deleted)
		{
			FlushRelationships();
		}
	}

	private void EnsureRelationships()
	{
		if (_relationships == null)
		{
			ThrowIfRelationship();
			_relationships = new InternalRelationshipCollection(this);
		}
	}

	private void ThrowIfOpenAccessModesAreIncompatible(FileMode mode, FileAccess access)
	{
		Package.ThrowIfFileModeInvalid(mode);
		Package.ThrowIfFileAccessInvalid(access);
		if (access == FileAccess.Read && (mode == FileMode.Create || mode == FileMode.CreateNew || mode == FileMode.Truncate || mode == FileMode.Append))
		{
			throw new IOException(System.SR.UnsupportedCombinationOfModeAccess);
		}
		if ((_container.FileOpenAccess == FileAccess.Read && access != FileAccess.Read) || (_container.FileOpenAccess == FileAccess.Write && access != FileAccess.Write))
		{
			throw new IOException(System.SR.ContainerAndPartModeIncompatible);
		}
	}

	private void CheckInvalidState()
	{
		ThrowIfPackagePartDeleted();
		ThrowIfParentContainerClosed();
	}

	private void ThrowIfParentContainerClosed()
	{
		if (_container == null)
		{
			throw new InvalidOperationException(System.SR.ParentContainerClosed);
		}
	}

	private void ThrowIfPackagePartDeleted()
	{
		if (_deleted)
		{
			throw new InvalidOperationException(System.SR.PackagePartDeleted);
		}
	}

	private void ThrowIfRelationship()
	{
		if (IsRelationshipPart)
		{
			throw new InvalidOperationException(System.SR.RelationshipPartsCannotHaveRelationships);
		}
	}

	private void CleanUpRequestedStreamsList()
	{
		if (_requestedStreams == null)
		{
			return;
		}
		for (int num = _requestedStreams.Count - 1; num >= 0; num--)
		{
			if (IsStreamClosed(_requestedStreams[num]))
			{
				_requestedStreams.RemoveAt(num);
			}
		}
	}

	private bool IsStreamClosed(Stream s)
	{
		if (!s.CanRead && !s.CanSeek)
		{
			return !s.CanWrite;
		}
		return false;
	}
}

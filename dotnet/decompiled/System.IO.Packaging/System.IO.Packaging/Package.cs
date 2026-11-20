using System.Collections.Generic;

namespace System.IO.Packaging;

public abstract class Package : IDisposable
{
	internal delegate bool PartOperation(PackagePart p);

	private FileAccess _openFileAccess;

	private bool _disposed;

	private SortedList<PackUriHelper.ValidatedPartUri, PackagePart> _partList;

	private PackagePartCollection _partCollection;

	private InternalRelationshipCollection _relationships;

	private PartBasedPackageProperties _packageProperties;

	public FileAccess FileOpenAccess
	{
		get
		{
			ThrowIfObjectDisposed();
			return _openFileAccess;
		}
	}

	protected Package(FileAccess openFileAccess)
	{
		ThrowIfFileAccessInvalid(openFileAccess);
		_openFileAccess = openFileAccess;
		_partList = new SortedList<PackUriHelper.ValidatedPartUri, PackagePart>();
		_partCollection = null;
		_disposed = false;
	}

	public static Package Open(Stream stream, FileMode packageMode)
	{
		return Open(stream, packageMode, FileAccess.ReadWrite);
	}

	public PackagePart CreatePart(Uri partUri, string contentType, CompressionOption compressionOption)
	{
		ThrowIfObjectDisposed();
		ThrowIfReadOnly();
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		if (contentType == null)
		{
			throw new ArgumentNullException("contentType");
		}
		ThrowIfCompressionOptionInvalid(compressionOption);
		PackUriHelper.ValidatedPartUri validatedPartUri = PackUriHelper.ValidatePartUri(partUri);
		if (_partList.ContainsKey(validatedPartUri))
		{
			throw new InvalidOperationException(System.SR.PartAlreadyExists);
		}
		AddIfNoPrefixCollisionDetected(validatedPartUri, null);
		PackagePart packagePart = CreatePartCore(validatedPartUri, contentType, compressionOption);
		_partList[validatedPartUri] = packagePart;
		return packagePart;
	}

	public PackagePart GetPart(Uri partUri)
	{
		PackagePart partHelper = GetPartHelper(partUri);
		if (partHelper == null)
		{
			throw new InvalidOperationException(System.SR.PartDoesNotExist);
		}
		return partHelper;
	}

	public virtual bool PartExists(Uri partUri)
	{
		ThrowIfObjectDisposed();
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		PackUriHelper.ValidatedPartUri key = PackUriHelper.ValidatePartUri(partUri);
		return _partList.ContainsKey(key);
	}

	public void DeletePart(Uri partUri)
	{
		ThrowIfObjectDisposed();
		ThrowIfReadOnly();
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		PackUriHelper.ValidatedPartUri validatedPartUri = PackUriHelper.ValidatePartUri(partUri);
		if (_partList.ContainsKey(validatedPartUri))
		{
			validatedPartUri = (PackUriHelper.ValidatedPartUri)_partList[validatedPartUri].Uri;
			_partList[validatedPartUri].IsDeleted = true;
			_partList[validatedPartUri].Close();
			DeletePartCore(validatedPartUri);
			_partList.Remove(validatedPartUri);
		}
		else
		{
			DeletePartCore(validatedPartUri);
		}
		if (PackUriHelper.IsRelationshipPartUri(validatedPartUri))
		{
			Uri sourcePartUriFromRelationshipPartUri = PackUriHelper.GetSourcePartUriFromRelationshipPartUri(validatedPartUri);
			if (Uri.Compare(sourcePartUriFromRelationshipPartUri, PackUriHelper.PackageRootUri, UriComponents.SerializationInfoString, UriFormat.UriEscaped, StringComparison.Ordinal) == 0)
			{
				ClearRelationships();
			}
			else if (PartExists(sourcePartUriFromRelationshipPartUri))
			{
				PackagePart part = GetPart(sourcePartUriFromRelationshipPartUri);
				part.ClearRelationships();
			}
		}
		else
		{
			DeletePart(PackUriHelper.GetRelationshipPartUri(validatedPartUri));
		}
	}

	public PackagePartCollection GetParts()
	{
		ThrowIfObjectDisposed();
		ThrowIfWriteOnly();
		if (_partCollection == null)
		{
			PackagePart[] partsCore = GetPartsCore();
			Dictionary<PackUriHelper.ValidatedPartUri, PackagePart> dictionary = new Dictionary<PackUriHelper.ValidatedPartUri, PackagePart>(partsCore.Length);
			for (int i = 0; i < partsCore.Length; i++)
			{
				PackUriHelper.ValidatedPartUri validatedPartUri = (PackUriHelper.ValidatedPartUri)partsCore[i].Uri;
				if (dictionary.ContainsKey(validatedPartUri))
				{
					throw new FileFormatException(System.SR.BadPackageFormat);
				}
				dictionary.Add(validatedPartUri, partsCore[i]);
				if (!_partList.ContainsKey(validatedPartUri))
				{
					AddIfNoPrefixCollisionDetected(validatedPartUri, partsCore[i]);
				}
			}
			_partCollection = new PackagePartCollection(_partList);
		}
		return _partCollection;
	}

	void IDisposable.Dispose()
	{
		if (_disposed)
		{
			return;
		}
		try
		{
			if (_packageProperties != null)
			{
				_packageProperties.Close();
			}
			FlushRelationships();
			DoOperationOnEachPart(DoCloseRelationshipsXml);
			DoOperationOnEachPart(DoClose);
			Dispose(disposing: true);
		}
		finally
		{
			_disposed = true;
		}
		GC.SuppressFinalize(this);
	}

	public void Close()
	{
		((IDisposable)this).Dispose();
	}

	public void Flush()
	{
		ThrowIfObjectDisposed();
		ThrowIfReadOnly();
		if (_packageProperties != null)
		{
			_packageProperties.Flush();
		}
		FlushRelationships();
		DoOperationOnEachPart(DoWriteRelationshipsXml);
		DoOperationOnEachPart(DoFlush);
		FlushCore();
	}

	public PackageRelationship CreateRelationship(Uri targetUri, TargetMode targetMode, string relationshipType, string id)
	{
		ThrowIfObjectDisposed();
		ThrowIfReadOnly();
		EnsureRelationships();
		return _relationships.Add(targetUri, targetMode, relationshipType, id);
	}

	protected abstract PackagePart CreatePartCore(Uri partUri, string contentType, CompressionOption compressionOption);

	protected abstract PackagePart GetPartCore(Uri partUri);

	protected abstract void DeletePartCore(Uri partUri);

	protected abstract PackagePart[] GetPartsCore();

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			if (_partList != null)
			{
				_partList.Clear();
			}
			if (_packageProperties != null)
			{
				_packageProperties.Dispose();
				_packageProperties = null;
			}
			_partList = null;
			_partCollection = null;
			_relationships = null;
			_disposed = true;
		}
	}

	protected abstract void FlushCore();

	internal void ThrowIfReadOnly()
	{
		if (_openFileAccess == FileAccess.Read)
		{
			throw new IOException(System.SR.CannotModifyReadOnlyContainer);
		}
	}

	internal void ThrowIfWriteOnly()
	{
		if (_openFileAccess == FileAccess.Write)
		{
			throw new IOException(System.SR.CannotRetrievePartsOfWriteOnlyContainer);
		}
	}

	internal static void ThrowIfFileModeInvalid(FileMode mode)
	{
		if (mode < FileMode.CreateNew || mode > FileMode.Append)
		{
			throw new ArgumentOutOfRangeException("mode");
		}
	}

	internal static void ThrowIfFileAccessInvalid(FileAccess access)
	{
		if (access < FileAccess.Read || access > FileAccess.ReadWrite)
		{
			throw new ArgumentOutOfRangeException("access");
		}
	}

	internal static void ThrowIfCompressionOptionInvalid(CompressionOption compressionOption)
	{
		if (compressionOption < CompressionOption.NotCompressed || compressionOption > CompressionOption.SuperFast)
		{
			throw new ArgumentOutOfRangeException("compressionOption");
		}
	}

	public static Package Open(Stream stream, FileMode packageMode, FileAccess packageAccess)
	{
		Package package = null;
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		try
		{
			package = new ZipPackage(stream, packageMode, packageAccess);
			if (package.FileOpenAccess == FileAccess.ReadWrite || package.FileOpenAccess == FileAccess.Read)
			{
				package.GetParts();
			}
		}
		catch
		{
			package?.Close();
			throw;
		}
		return package;
	}

	private void AddIfNoPrefixCollisionDetected(PackUriHelper.ValidatedPartUri partUri, PackagePart part)
	{
		_partList.Add(partUri, part);
		int num = _partList.IndexOfKey(partUri);
		string normalizedPartUriString = partUri.NormalizedPartUriString;
		string text = null;
		string text2 = null;
		if (num > 0)
		{
			text = _partList.Keys[num - 1].NormalizedPartUriString;
		}
		if (num < _partList.Count - 1)
		{
			text2 = _partList.Keys[num + 1].NormalizedPartUriString;
		}
		if ((text != null && normalizedPartUriString.StartsWith(text, StringComparison.Ordinal) && normalizedPartUriString.Length > text.Length && normalizedPartUriString[text.Length] == '/') || (text2 != null && text2.StartsWith(normalizedPartUriString, StringComparison.Ordinal) && text2.Length > normalizedPartUriString.Length && text2[normalizedPartUriString.Length] == '/'))
		{
			_partList.Remove(partUri);
			throw new InvalidOperationException(System.SR.PartNamePrefixExists);
		}
	}

	private void ThrowIfObjectDisposed()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException(null, System.SR.ObjectDisposed);
		}
	}

	private void EnsureRelationships()
	{
		if (_relationships == null)
		{
			_relationships = new InternalRelationshipCollection(this);
		}
	}

	private void ClearRelationships()
	{
		if (_relationships != null)
		{
			_relationships.Clear();
		}
	}

	private void FlushRelationships()
	{
		if (_relationships != null && _openFileAccess != FileAccess.Read)
		{
			_relationships.Flush();
		}
	}

	private void DoOperationOnEachPart(PartOperation operation)
	{
		if (_partList.Count <= 0)
		{
			return;
		}
		int num = 0;
		PackUriHelper.ValidatedPartUri[] array = new PackUriHelper.ValidatedPartUri[_partList.Keys.Count];
		foreach (PackUriHelper.ValidatedPartUri key in _partList.Keys)
		{
			array[num++] = key;
		}
		PackagePart value;
		for (int i = 0; i < array.Length && (!_partList.TryGetValue(array[i], out value) || operation(value)); i++)
		{
		}
	}

	private bool DoClose(PackagePart p)
	{
		if (!p.IsClosed)
		{
			if (PackUriHelper.IsRelationshipPartUri(p.Uri) && PackUriHelper.ComparePartUri(p.Uri, PackageRelationship.ContainerRelationshipPartName) != 0)
			{
				PackUriHelper.ValidatedPartUri key = (PackUriHelper.ValidatedPartUri)PackUriHelper.GetSourcePartUriFromRelationshipPartUri(p.Uri);
				if (_partList.TryGetValue(key, out var value))
				{
					value.Close();
				}
			}
			p.Close();
		}
		return true;
	}

	private bool DoFlush(PackagePart p)
	{
		p.Flush();
		return true;
	}

	private bool DoWriteRelationshipsXml(PackagePart p)
	{
		if (!p.IsRelationshipPart)
		{
			p.FlushRelationships();
		}
		return true;
	}

	private bool DoCloseRelationshipsXml(PackagePart p)
	{
		if (!p.IsRelationshipPart)
		{
			p.CloseRelationships();
		}
		return true;
	}

	private PackagePart GetPartHelper(Uri partUri)
	{
		ThrowIfObjectDisposed();
		ThrowIfWriteOnly();
		if (partUri == null)
		{
			throw new ArgumentNullException("partUri");
		}
		PackUriHelper.ValidatedPartUri validatedPartUri = PackUriHelper.ValidatePartUri(partUri);
		if (_partList.ContainsKey(validatedPartUri))
		{
			return _partList[validatedPartUri];
		}
		PackagePart partCore = GetPartCore(validatedPartUri);
		if (partCore != null)
		{
			AddIfNoPrefixCollisionDetected(validatedPartUri, partCore);
		}
		return partCore;
	}
}

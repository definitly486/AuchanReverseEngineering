using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

public class ZipArchive : IDisposable, IAsyncDisposable
{
	[Flags]
	internal enum ChangeState
	{
		Unchanged = 0,
		FixedLengthMetadata = 1,
		DynamicLengthMetadata = 2,
		StoredData = 4
	}

	private readonly Stream _archiveStream;

	private ZipArchiveEntry _archiveStreamOwner;

	private readonly ZipArchiveMode _mode;

	private readonly List<ZipArchiveEntry> _entries;

	private readonly ReadOnlyCollection<ZipArchiveEntry> _entriesCollection;

	private readonly Dictionary<string, ZipArchiveEntry> _entriesDictionary;

	private bool _readEntries;

	private readonly bool _leaveOpen;

	private long _centralDirectoryStart;

	private bool _isDisposed;

	private uint _numberOfThisDisk;

	private long _expectedNumberOfEntries;

	private readonly Stream _backingStream;

	private byte[] _archiveComment;

	private Encoding _entryNameAndCommentEncoding;

	private long _firstDeletedEntryOffset;

	public ReadOnlyCollection<ZipArchiveEntry> Entries
	{
		get
		{
			if (_mode == ZipArchiveMode.Create)
			{
				throw new NotSupportedException("EntriesInCreateMode");
			}
			ThrowIfDisposed();
			EnsureCentralDirectoryRead();
			return _entriesCollection;
		}
	}

	public ZipArchiveMode Mode => _mode;

	internal Stream ArchiveStream => _archiveStream;

	internal uint NumberOfThisDisk => _numberOfThisDisk;

	internal Encoding? EntryNameAndCommentEncoding
	{
		get
		{
			return _entryNameAndCommentEncoding;
		}
		private set
		{
			if (value != null && (value.Equals(Encoding.BigEndianUnicode) || value.Equals(Encoding.Unicode)))
			{
				throw new ArgumentException("EntryNameAndCommentEncodingNotSupported", "EntryNameAndCommentEncoding");
			}
			_entryNameAndCommentEncoding = value;
		}
	}

	internal ChangeState Changed { get; private set; }

	public ZipArchive(Stream stream, ZipArchiveMode mode)
		: this(stream, mode, leaveOpen: false, null)
	{
	}

	public ZipArchive(Stream stream, ZipArchiveMode mode, bool leaveOpen)
		: this(stream, mode, leaveOpen, null)
	{
	}

	public ZipArchive(Stream stream, ZipArchiveMode mode, bool leaveOpen, Encoding? entryNameEncoding)
		: this(mode, leaveOpen, entryNameEncoding, null, DecideArchiveStream(mode, stream))
	{
		ArgumentNullException.ThrowIfNull(stream, "stream");
		Stream stream2 = null;
		try
		{
			_backingStream = null;
			if (ValidateMode(mode, stream))
			{
				_backingStream = stream;
				stream2 = (stream = new MemoryStream());
				_backingStream.CopyTo(stream);
				stream.Seek(0L, SeekOrigin.Begin);
			}
			_archiveStream = DecideArchiveStream(mode, stream);
			switch (mode)
			{
			case ZipArchiveMode.Create:
				_readEntries = true;
				return;
			case ZipArchiveMode.Read:
				ReadEndOfCentralDirectory();
				return;
			}
			if (_archiveStream.Length == 0L)
			{
				_readEntries = true;
				return;
			}
			ReadEndOfCentralDirectory();
			EnsureCentralDirectoryRead();
			foreach (ZipArchiveEntry entry in _entries)
			{
				entry.ThrowIfNotOpenable(needToUncompress: false, needToLoadIntoMemory: true);
			}
		}
		catch (Exception)
		{
			stream2?.Dispose();
			throw;
		}
	}

	private ZipArchive(ZipArchiveMode mode, bool leaveOpen, Encoding entryNameEncoding, Stream backingStream, Stream archiveStream)
	{
		_backingStream = backingStream;
		_archiveStream = archiveStream;
		_mode = mode;
		EntryNameAndCommentEncoding = entryNameEncoding;
		_archiveStreamOwner = null;
		_entries = new List<ZipArchiveEntry>();
		_entriesCollection = new ReadOnlyCollection<ZipArchiveEntry>(_entries);
		_entriesDictionary = new Dictionary<string, ZipArchiveEntry>();
		Changed = ChangeState.Unchanged;
		_readEntries = false;
		_leaveOpen = leaveOpen;
		_centralDirectoryStart = 0L;
		_isDisposed = false;
		_numberOfThisDisk = 0u;
		_archiveComment = Array.Empty<byte>();
		_firstDeletedEntryOffset = long.MaxValue;
	}

	public ZipArchiveEntry CreateEntry(string entryName)
	{
		return DoCreateEntry(entryName, null);
	}

	public ZipArchiveEntry CreateEntry(string entryName, CompressionLevel compressionLevel)
	{
		return DoCreateEntry(entryName, compressionLevel);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing || _isDisposed)
		{
			return;
		}
		try
		{
			ZipArchiveMode mode = _mode;
			if (mode != ZipArchiveMode.Read)
			{
				_ = mode - 1;
				_ = 1;
				WriteFile();
			}
		}
		finally
		{
			CloseStreams();
			_isDisposed = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	public ZipArchiveEntry? GetEntry(string entryName)
	{
		ArgumentNullException.ThrowIfNull(entryName, "entryName");
		if (_mode == ZipArchiveMode.Create)
		{
			throw new NotSupportedException("EntriesInCreateMode");
		}
		EnsureCentralDirectoryRead();
		_entriesDictionary.TryGetValue(entryName, out var value);
		return value;
	}

	private ZipArchiveEntry DoCreateEntry(string entryName, CompressionLevel? compressionLevel)
	{
		ArgumentException.ThrowIfNullOrEmpty(entryName, "entryName");
		if (_mode == ZipArchiveMode.Read)
		{
			throw new NotSupportedException("CreateInReadMode");
		}
		ThrowIfDisposed();
		ZipArchiveEntry zipArchiveEntry = (compressionLevel.HasValue ? new ZipArchiveEntry(this, entryName, compressionLevel.Value) : new ZipArchiveEntry(this, entryName));
		AddEntry(zipArchiveEntry);
		return zipArchiveEntry;
	}

	internal void AcquireArchiveStream(ZipArchiveEntry entry)
	{
		if (_archiveStreamOwner != null)
		{
			if (_archiveStreamOwner.EverOpenedForWrite)
			{
				throw new IOException("CreateModeCreateEntryWhileOpen");
			}
			_archiveStreamOwner.WriteAndFinishLocalEntry(forceWrite: true);
		}
		_archiveStreamOwner = entry;
	}

	private void AddEntry(ZipArchiveEntry entry)
	{
		_entries.Add(entry);
		_entriesDictionary.TryAdd(entry.FullName, entry);
	}

	internal void ReleaseArchiveStream(ZipArchiveEntry entry)
	{
		_archiveStreamOwner = null;
	}

	internal void RemoveEntry(ZipArchiveEntry entry)
	{
		_entries.Remove(entry);
		_entriesDictionary.Remove(entry.FullName);
		if (entry.OriginallyInArchive && entry.OffsetOfLocalHeader < _firstDeletedEntryOffset)
		{
			_firstDeletedEntryOffset = entry.OffsetOfLocalHeader;
		}
	}

	internal void ThrowIfDisposed()
	{
		ObjectDisposedException.ThrowIf(_isDisposed, this);
	}

	private void CloseStreams()
	{
		if (!_leaveOpen)
		{
			_archiveStream.Dispose();
			_backingStream?.Dispose();
		}
		else if (_backingStream != null)
		{
			_archiveStream.Dispose();
		}
	}

	private void EnsureCentralDirectoryRead()
	{
		if (!_readEntries)
		{
			ReadCentralDirectory();
			_readEntries = true;
		}
	}

	private void ReadCentralDirectoryInitialize(out byte[] fileBuffer, out long numberOfEntries, out bool saveExtraFieldsAndComments, out bool continueReadingCentralDirectory, out int bytesRead, out int currPosition, out int bytesConsumed)
	{
		fileBuffer = new byte[4096];
		_archiveStream.Seek(_centralDirectoryStart, SeekOrigin.Begin);
		numberOfEntries = 0L;
		saveExtraFieldsAndComments = Mode == ZipArchiveMode.Update;
		continueReadingCentralDirectory = true;
		bytesRead = 0;
		currPosition = 0;
		bytesConsumed = 0;
		_entries.Clear();
		_entriesDictionary.Clear();
	}

	private bool ReadCentralDirectoryEndOfInnerLoopWork(bool result, ZipCentralDirectoryFileHeader currentHeader, int bytesConsumed, ref bool continueReadingCentralDirectory, ref long numberOfEntries, ref int currPosition, ref int bytesRead)
	{
		if (!result)
		{
			continueReadingCentralDirectory = false;
			return false;
		}
		AddEntry(new ZipArchiveEntry(this, currentHeader));
		numberOfEntries++;
		if (numberOfEntries > _expectedNumberOfEntries)
		{
			throw new InvalidDataException("NumEntriesWrong");
		}
		currPosition += bytesConsumed;
		bytesRead += bytesConsumed;
		return true;
	}

	private void ReadCentralDirectoryEndOfOuterLoopWork(ref int currPosition, ReadOnlySpan<byte> sizedFileBuffer)
	{
		if (currPosition < sizedFileBuffer.Length)
		{
			_archiveStream.Seek(-(sizedFileBuffer.Length - currPosition), SeekOrigin.Current);
		}
		currPosition = 0;
	}

	private void ReadCentralDirectoryPostOuterLoopWork(long numberOfEntries)
	{
		if (numberOfEntries != _expectedNumberOfEntries)
		{
			throw new InvalidDataException("NumEntriesWrong");
		}
		if (Mode == ZipArchiveMode.Update)
		{
			_entries.Sort(ZipArchiveEntry.LocalHeaderOffsetComparer.Instance);
		}
	}

	private void ReadCentralDirectory()
	{
		try
		{
			ReadCentralDirectoryInitialize(out var fileBuffer, out var numberOfEntries, out var saveExtraFieldsAndComments, out var continueReadingCentralDirectory, out var bytesRead, out var currPosition, out var bytesConsumed);
			Span<byte> buffer = fileBuffer.AsSpan();
			while (continueReadingCentralDirectory)
			{
				int num = _archiveStream.ReadAtLeast(buffer, 46, throwOnEndOfStream: false);
				ReadOnlySpan<byte> sizedFileBuffer = buffer.Slice(0, num);
				continueReadingCentralDirectory = num >= 46;
				while (currPosition + 46 <= num)
				{
					ZipCentralDirectoryFileHeader header;
					bool result = ZipCentralDirectoryFileHeader.TryReadBlock(sizedFileBuffer.Slice(currPosition), _archiveStream, saveExtraFieldsAndComments, out bytesConsumed, out header);
					if (!ReadCentralDirectoryEndOfInnerLoopWork(result, header, bytesConsumed, ref continueReadingCentralDirectory, ref numberOfEntries, ref currPosition, ref bytesRead))
					{
						break;
					}
				}
				ReadCentralDirectoryEndOfOuterLoopWork(ref currPosition, sizedFileBuffer);
			}
			ReadCentralDirectoryPostOuterLoopWork(numberOfEntries);
		}
		catch (EndOfStreamException p)
		{
			throw new InvalidDataException(System.SR.Format("CentralDirectoryInvalid", p));
		}
	}

	private void ReadEndOfCentralDirectoryInnerWork(ZipEndOfCentralDirectoryBlock eocd)
	{
		if (eocd.NumberOfThisDisk != eocd.NumberOfTheDiskWithTheStartOfTheCentralDirectory)
		{
			throw new InvalidDataException("SplitSpanned");
		}
		_numberOfThisDisk = eocd.NumberOfThisDisk;
		_centralDirectoryStart = eocd.OffsetOfStartOfCentralDirectoryWithRespectToTheStartingDiskNumber;
		if (eocd.NumberOfEntriesInTheCentralDirectory != eocd.NumberOfEntriesInTheCentralDirectoryOnThisDisk)
		{
			throw new InvalidDataException("SplitSpanned");
		}
		_expectedNumberOfEntries = eocd.NumberOfEntriesInTheCentralDirectory;
		_archiveComment = eocd.ArchiveComment;
	}

	private void ReadEndOfCentralDirectory()
	{
		try
		{
			_archiveStream.Seek(-18L, SeekOrigin.End);
			if (!ZipHelper.SeekBackwardsToSignature(_archiveStream, ZipEndOfCentralDirectoryBlock.SignatureConstantBytes, 65539))
			{
				throw new InvalidDataException("EOCDNotFound");
			}
			long position = _archiveStream.Position;
			ZipEndOfCentralDirectoryBlock eocd = ZipEndOfCentralDirectoryBlock.ReadBlock(_archiveStream);
			ReadEndOfCentralDirectoryInnerWork(eocd);
			TryReadZip64EndOfCentralDirectory(eocd, position);
			if (_centralDirectoryStart > _archiveStream.Length)
			{
				throw new InvalidDataException("FieldTooBigOffsetToCD");
			}
		}
		catch (EndOfStreamException innerException)
		{
			throw new InvalidDataException("CDCorrupt", innerException);
		}
		catch (IOException innerException2)
		{
			throw new InvalidDataException("CDCorrupt", innerException2);
		}
	}

	private void TryReadZip64EndOfCentralDirectoryInnerInitialWork(Zip64EndOfCentralDirectoryLocator locator)
	{
		if (locator == null || locator.OffsetOfZip64EOCD > long.MaxValue)
		{
			throw new InvalidDataException("FieldTooBigOffsetToZip64EOCD");
		}
		long offsetOfZip64EOCD = (long)locator.OffsetOfZip64EOCD;
		if (offsetOfZip64EOCD < 0 || offsetOfZip64EOCD > _archiveStream.Length)
		{
			throw new InvalidDataException("InvalidOffsetToZip64EOCD");
		}
		_archiveStream.Seek(offsetOfZip64EOCD, SeekOrigin.Begin);
	}

	private void TryReadZip64EndOfCentralDirectoryInnerFinalWork(Zip64EndOfCentralDirectoryRecord record)
	{
		_numberOfThisDisk = record.NumberOfThisDisk;
		if (record.NumberOfEntriesTotal > long.MaxValue)
		{
			throw new InvalidDataException("FieldTooBigNumEntries");
		}
		if (record.OffsetOfCentralDirectory > long.MaxValue)
		{
			throw new InvalidDataException("FieldTooBigOffsetToCD");
		}
		if (record.NumberOfEntriesTotal != record.NumberOfEntriesOnThisDisk)
		{
			throw new InvalidDataException("SplitSpanned");
		}
		_expectedNumberOfEntries = (long)record.NumberOfEntriesTotal;
		_centralDirectoryStart = (long)record.OffsetOfCentralDirectory;
	}

	private void TryReadZip64EndOfCentralDirectory(ZipEndOfCentralDirectoryBlock eocd, long eocdStart)
	{
		if (eocd.NumberOfThisDisk == ushort.MaxValue || eocd.OffsetOfStartOfCentralDirectoryWithRespectToTheStartingDiskNumber == uint.MaxValue || eocd.NumberOfEntriesInTheCentralDirectory == ushort.MaxValue)
		{
			if (eocdStart < 20)
			{
				throw new InvalidDataException("Zip64EOCDNotWhereExpected");
			}
			_archiveStream.Seek(eocdStart - 16, SeekOrigin.Begin);
			if (ZipHelper.SeekBackwardsToSignature(_archiveStream, Zip64EndOfCentralDirectoryLocator.SignatureConstantBytes, 4))
			{
				Zip64EndOfCentralDirectoryLocator locator = Zip64EndOfCentralDirectoryLocator.TryReadBlock(_archiveStream);
				TryReadZip64EndOfCentralDirectoryInnerInitialWork(locator);
				Zip64EndOfCentralDirectoryRecord record = Zip64EndOfCentralDirectoryRecord.TryReadBlock(_archiveStream);
				TryReadZip64EndOfCentralDirectoryInnerFinalWork(record);
			}
		}
	}

	private static void WriteFileCalculateOffsets(ZipArchiveEntry entry, ref long startingOffset, ref long nextFileOffset)
	{
		if (entry.Changes == ChangeState.Unchanged)
		{
			nextFileOffset = Math.Max(nextFileOffset, entry.GetOffsetOfCompressedData() + entry.CompressedLength);
		}
		else
		{
			startingOffset = Math.Min(startingOffset, entry.OffsetOfLocalHeader);
		}
	}

	private static void WriteFileCheckStartingOffset(ZipArchiveEntry entry, ref long completeRewriteStartingOffset)
	{
		if ((entry.Changes & (ChangeState.DynamicLengthMetadata | ChangeState.StoredData)) != ChangeState.Unchanged)
		{
			completeRewriteStartingOffset = Math.Min(completeRewriteStartingOffset, entry.OffsetOfLocalHeader);
		}
	}

	private void WriteFileUpdateModeFinalWork(long startingOffset, long nextFileOffset)
	{
		if (startingOffset == long.MaxValue)
		{
			startingOffset = nextFileOffset;
		}
		_archiveStream.Seek(startingOffset, SeekOrigin.Begin);
	}

	private void WriteFileFinalWork()
	{
		if (_mode == ZipArchiveMode.Update && _archiveStream.Position != _archiveStream.Length)
		{
			_archiveStream.SetLength(_archiveStream.Position);
		}
	}

	private void WriteFile()
	{
		long completeRewriteStartingOffset = 0L;
		List<ZipArchiveEntry> list = _entries;
		if (_mode == ZipArchiveMode.Update)
		{
			long startingOffset = _firstDeletedEntryOffset;
			long nextFileOffset = 0L;
			completeRewriteStartingOffset = startingOffset;
			list = new List<ZipArchiveEntry>(_entries.Count);
			foreach (ZipArchiveEntry entry in _entries)
			{
				if (!entry.OriginallyInArchive)
				{
					list.Add(entry);
					continue;
				}
				WriteFileCalculateOffsets(entry, ref startingOffset, ref nextFileOffset);
				if (entry.OffsetOfLocalHeader >= startingOffset)
				{
					WriteFileCheckStartingOffset(entry, ref completeRewriteStartingOffset);
					entry.LoadLocalHeaderExtraFieldIfNeeded();
					if (entry.OffsetOfLocalHeader >= completeRewriteStartingOffset)
					{
						entry.LoadCompressedBytesIfNeeded();
					}
					list.Add(entry);
				}
			}
			WriteFileUpdateModeFinalWork(startingOffset, nextFileOffset);
		}
		foreach (ZipArchiveEntry item in list)
		{
			bool forceWrite = !item.OriginallyInArchive || (item.OriginallyInArchive && item.OffsetOfLocalHeader >= completeRewriteStartingOffset);
			item.WriteAndFinishLocalEntry(forceWrite);
		}
		long position = _archiveStream.Position;
		bool flag = _entries.Count == 0;
		foreach (ZipArchiveEntry entry2 in _entries)
		{
			bool flag2 = position != _centralDirectoryStart || !entry2.OriginallyInArchive || entry2.OffsetOfLocalHeader >= completeRewriteStartingOffset;
			entry2.WriteCentralDirectoryFileHeader(flag2);
			flag = flag || flag2;
		}
		long sizeOfCentralDirectory = _archiveStream.Position - position;
		WriteArchiveEpilogue(position, sizeOfCentralDirectory, flag);
		WriteFileFinalWork();
	}

	private void WriteArchiveEpilogueNoCDChangesWork()
	{
		_archiveStream.Seek(56L, SeekOrigin.Current);
		_archiveStream.Seek(20L, SeekOrigin.Current);
	}

	private void WriteArchiveEpilogue(long startOfCentralDirectory, long sizeOfCentralDirectory, bool centralDirectoryChanged)
	{
		if (startOfCentralDirectory >= uint.MaxValue || sizeOfCentralDirectory >= uint.MaxValue || _entries.Count >= 65535)
		{
			long position = _archiveStream.Position;
			if (centralDirectoryChanged)
			{
				Zip64EndOfCentralDirectoryRecord.WriteBlock(_archiveStream, _entries.Count, startOfCentralDirectory, sizeOfCentralDirectory);
				Zip64EndOfCentralDirectoryLocator.WriteBlock(_archiveStream, position);
			}
			else
			{
				WriteArchiveEpilogueNoCDChangesWork();
			}
		}
		if (centralDirectoryChanged || Changed != ChangeState.Unchanged)
		{
			ZipEndOfCentralDirectoryBlock.WriteBlock(_archiveStream, _entries.Count, startOfCentralDirectory, sizeOfCentralDirectory, _archiveComment);
		}
		else
		{
			_archiveStream.Seek(22 + _archiveComment.Length, SeekOrigin.Current);
		}
	}

	private static bool ValidateMode(ZipArchiveMode mode, Stream stream)
	{
		bool result = false;
		switch (mode)
		{
		case ZipArchiveMode.Create:
			if (!stream.CanWrite)
			{
				throw new ArgumentException("CreateModeCapabilities");
			}
			break;
		case ZipArchiveMode.Read:
			if (!stream.CanRead)
			{
				throw new ArgumentException("ReadModeCapabilities");
			}
			if (!stream.CanSeek)
			{
				result = true;
			}
			break;
		case ZipArchiveMode.Update:
			if (!stream.CanRead || !stream.CanWrite || !stream.CanSeek)
			{
				throw new ArgumentException("UpdateModeCapabilities");
			}
			break;
		default:
			throw new ArgumentOutOfRangeException("mode");
		}
		return result;
	}

	private static Stream DecideArchiveStream(ZipArchiveMode mode, Stream stream)
	{
		ArgumentNullException.ThrowIfNull(stream, "stream");
		if (mode != ZipArchiveMode.Create || stream.CanSeek)
		{
			return stream;
		}
		return new PositionPreservingWriteOnlyStreamWrapper(stream);
	}

	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore().ConfigureAwait(continueOnCapturedContext: false);
	}

	protected virtual async ValueTask DisposeAsyncCore()
	{
		if (_isDisposed)
		{
			return;
		}
		try
		{
			ZipArchiveMode mode = _mode;
			if (mode != ZipArchiveMode.Read)
			{
				_ = mode - 1;
				_ = 1;
				await WriteFileAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		finally
		{
			await CloseStreamsAsync().ConfigureAwait(continueOnCapturedContext: false);
			_isDisposed = true;
		}
	}

	private async Task CloseStreamsAsync()
	{
		if (!_leaveOpen)
		{
			await _archiveStream.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (_backingStream != null)
			{
				await _backingStream.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		else if (_backingStream != null)
		{
			await _archiveStream.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private async ValueTask WriteFileAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		long completeRewriteStartingOffset = 0L;
		List<ZipArchiveEntry> entriesToWrite = _entries;
		if (_mode == ZipArchiveMode.Update)
		{
			long startingOffset = _firstDeletedEntryOffset;
			long nextFileOffset = 0L;
			completeRewriteStartingOffset = startingOffset;
			entriesToWrite = new List<ZipArchiveEntry>(_entries.Count);
			foreach (ZipArchiveEntry entry in _entries)
			{
				if (!entry.OriginallyInArchive)
				{
					entriesToWrite.Add(entry);
					continue;
				}
				WriteFileCalculateOffsets(entry, ref startingOffset, ref nextFileOffset);
				if (entry.OffsetOfLocalHeader >= startingOffset)
				{
					WriteFileCheckStartingOffset(entry, ref completeRewriteStartingOffset);
					await entry.LoadLocalHeaderExtraFieldIfNeededAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (entry.OffsetOfLocalHeader >= completeRewriteStartingOffset)
					{
						await entry.LoadCompressedBytesIfNeededAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					entriesToWrite.Add(entry);
				}
			}
			WriteFileUpdateModeFinalWork(startingOffset, nextFileOffset);
		}
		foreach (ZipArchiveEntry item in entriesToWrite)
		{
			bool forceWrite = !item.OriginallyInArchive || (item.OriginallyInArchive && item.OffsetOfLocalHeader >= completeRewriteStartingOffset);
			await item.WriteAndFinishLocalEntryAsync(forceWrite, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		long plannedCentralDirectoryPosition = _archiveStream.Position;
		bool archiveEpilogueRequiresUpdate = _entries.Count == 0;
		foreach (ZipArchiveEntry entry2 in _entries)
		{
			bool centralDirectoryEntryRequiresUpdate = plannedCentralDirectoryPosition != _centralDirectoryStart || !entry2.OriginallyInArchive || entry2.OffsetOfLocalHeader >= completeRewriteStartingOffset;
			await entry2.WriteCentralDirectoryFileHeaderAsync(centralDirectoryEntryRequiresUpdate, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			archiveEpilogueRequiresUpdate = archiveEpilogueRequiresUpdate || centralDirectoryEntryRequiresUpdate;
		}
		long sizeOfCentralDirectory = _archiveStream.Position - plannedCentralDirectoryPosition;
		await WriteArchiveEpilogueAsync(plannedCentralDirectoryPosition, sizeOfCentralDirectory, archiveEpilogueRequiresUpdate, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		WriteFileFinalWork();
	}

	private async ValueTask WriteArchiveEpilogueAsync(long startOfCentralDirectory, long sizeOfCentralDirectory, bool centralDirectoryChanged, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (startOfCentralDirectory >= uint.MaxValue || sizeOfCentralDirectory >= uint.MaxValue || _entries.Count >= 65535)
		{
			long zip64EOCDRecordStart = _archiveStream.Position;
			if (centralDirectoryChanged)
			{
				await Zip64EndOfCentralDirectoryRecord.WriteBlockAsync(_archiveStream, _entries.Count, startOfCentralDirectory, sizeOfCentralDirectory, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await Zip64EndOfCentralDirectoryLocator.WriteBlockAsync(_archiveStream, zip64EOCDRecordStart, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				WriteArchiveEpilogueNoCDChangesWork();
			}
		}
		if (centralDirectoryChanged || Changed != ChangeState.Unchanged)
		{
			await ZipEndOfCentralDirectoryBlock.WriteBlockAsync(_archiveStream, _entries.Count, startOfCentralDirectory, sizeOfCentralDirectory, _archiveComment, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		else
		{
			_archiveStream.Seek(22 + _archiveComment.Length, SeekOrigin.Current);
		}
	}
}

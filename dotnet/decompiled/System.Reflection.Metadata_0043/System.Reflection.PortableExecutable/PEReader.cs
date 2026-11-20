using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection.Internal;
using System.Threading;

namespace System.Reflection.PortableExecutable;

public sealed class PEReader : IDisposable
{
	private MemoryBlockProvider _peImage;

	private PEHeaders _lazyPEHeaders;

	private AbstractMemoryBlock _lazyMetadataBlock;

	private AbstractMemoryBlock _lazyImageBlock;

	private AbstractMemoryBlock[] _lazyPESectionBlocks;

	public bool IsLoadedImage { get; }

	public PEHeaders PEHeaders
	{
		get
		{
			if (_lazyPEHeaders == null)
			{
				InitializePEHeaders();
			}
			return _lazyPEHeaders;
		}
	}

	public bool HasMetadata => PEHeaders.MetadataSize > 0;

	public unsafe PEReader(byte* peImage, int size)
		: this(peImage, size, isLoadedImage: false)
	{
	}

	public unsafe PEReader(byte* peImage, int size, bool isLoadedImage)
	{
		if (peImage == null)
		{
			Throw.ArgumentNull("peImage");
		}
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		_peImage = new ExternalMemoryBlockProvider(peImage, size);
		IsLoadedImage = isLoadedImage;
	}

	public void Dispose()
	{
		_lazyPEHeaders = null;
		_peImage?.Dispose();
		_peImage = null;
		_lazyImageBlock?.Dispose();
		_lazyImageBlock = null;
		_lazyMetadataBlock?.Dispose();
		_lazyMetadataBlock = null;
		AbstractMemoryBlock[] lazyPESectionBlocks = _lazyPESectionBlocks;
		if (lazyPESectionBlocks != null)
		{
			AbstractMemoryBlock[] array = lazyPESectionBlocks;
			for (int i = 0; i < array.Length; i++)
			{
				array[i]?.Dispose();
			}
			_lazyPESectionBlocks = null;
		}
	}

	private MemoryBlockProvider GetPEImage()
	{
		MemoryBlockProvider peImage = _peImage;
		if (peImage == null)
		{
			if (_lazyPEHeaders == null)
			{
				Throw.PEReaderDisposed();
			}
			Throw.InvalidOperation_PEImageNotAvailable();
		}
		return peImage;
	}

	[MemberNotNull("_lazyPEHeaders")]
	private void InitializePEHeaders()
	{
		MemoryBlockProvider pEImage = GetPEImage();
		PEHeaders value;
		if (pEImage.TryGetUnderlyingStream(out Stream stream, out long imageStart, out int imageSize, out object streamGuard))
		{
			lock (streamGuard)
			{
				stream.Seek(imageStart, SeekOrigin.Begin);
				value = new PEHeaders(stream, imageSize, IsLoadedImage);
			}
		}
		else
		{
			AbstractMemoryBlock memoryBlock = pEImage.GetMemoryBlock();
			value = new PEHeaders(memoryBlock.GetStream(), memoryBlock.Size, IsLoadedImage);
		}
		Interlocked.CompareExchange(ref _lazyPEHeaders, value, null);
	}

	private AbstractMemoryBlock GetMetadataBlock()
	{
		if (!HasMetadata)
		{
			throw new InvalidOperationException("PEImageDoesNotHaveMetadata");
		}
		if (_lazyMetadataBlock == null)
		{
			AbstractMemoryBlock memoryBlock = GetPEImage().GetMemoryBlock(PEHeaders.MetadataStartOffset, PEHeaders.MetadataSize);
			if (Interlocked.CompareExchange(ref _lazyMetadataBlock, memoryBlock, null) != null)
			{
				memoryBlock.Dispose();
			}
		}
		return _lazyMetadataBlock;
	}

	public PEMemoryBlock GetMetadata()
	{
		return new PEMemoryBlock(GetMetadataBlock());
	}
}

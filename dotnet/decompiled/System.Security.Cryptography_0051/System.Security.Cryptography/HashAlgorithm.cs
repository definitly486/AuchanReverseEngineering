using System.Buffers;
using System.IO;

namespace System.Security.Cryptography;

public abstract class HashAlgorithm : IDisposable, ICryptoTransform
{
	private bool _disposed;

	protected int HashSizeValue;

	protected internal byte[]? HashValue;

	protected int State;

	public byte[] ComputeHash(byte[] buffer)
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		HashCore(buffer, 0, buffer.Length);
		return CaptureHashCodeAndReinitialize();
	}

	public byte[] ComputeHash(Stream inputStream)
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
		byte[] array = ArrayPool<byte>.Shared.Rent(4096);
		int num = 0;
		int num2;
		while ((num2 = inputStream.Read(array, 0, array.Length)) > 0)
		{
			if (num2 > num)
			{
				num = num2;
			}
			HashCore(array, 0, num2);
		}
		CryptographicOperations.ZeroMemory(array.AsSpan(0, num));
		ArrayPool<byte>.Shared.Return(array);
		return CaptureHashCodeAndReinitialize();
	}

	private byte[] CaptureHashCodeAndReinitialize()
	{
		HashValue = HashFinal();
		byte[] result = (byte[])HashValue.Clone();
		Initialize();
		return result;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_disposed = true;
		}
	}

	public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[]? outputBuffer, int outputOffset)
	{
		ValidateTransformBlock(inputBuffer, inputOffset, inputCount);
		State = 1;
		HashCore(inputBuffer, inputOffset, inputCount);
		if (outputBuffer != null && (inputBuffer != outputBuffer || inputOffset != outputOffset))
		{
			Buffer.BlockCopy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
		}
		return inputCount;
	}

	public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		ValidateTransformBlock(inputBuffer, inputOffset, inputCount);
		HashCore(inputBuffer, inputOffset, inputCount);
		HashValue = CaptureHashCodeAndReinitialize();
		byte[] array;
		if (inputCount != 0)
		{
			array = new byte[inputCount];
			Buffer.BlockCopy(inputBuffer, inputOffset, array, 0, inputCount);
		}
		else
		{
			array = Array.Empty<byte>();
		}
		State = 0;
		return array;
	}

	private void ValidateTransformBlock(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		ArgumentNullException.ThrowIfNull(inputBuffer, "inputBuffer");
		ArgumentOutOfRangeException.ThrowIfNegative(inputOffset, "inputOffset");
		if (inputCount < 0 || inputCount > inputBuffer.Length)
		{
			throw new ArgumentException("Argument_InvalidValue");
		}
		if (inputBuffer.Length - inputCount < inputOffset)
		{
			throw new ArgumentException("Argument_InvalidOffLen");
		}
		ObjectDisposedException.ThrowIf(_disposed, this);
	}

	protected abstract void HashCore(byte[] array, int ibStart, int cbSize);

	protected abstract byte[] HashFinal();

	public abstract void Initialize();
}

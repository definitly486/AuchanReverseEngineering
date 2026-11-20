namespace System.Security.Cryptography;

public interface ICryptoTransform : IDisposable
{
	int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset);

	byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount);
}

using System;
using System.Reactive.Linq;

namespace Akavache;

public class EncryptionProvider : IEncryptionProvider
{
	public IObservable<byte[]> EncryptBlock(byte[] block)
	{
		return Observable.Return(ProtectedData.Protect(block, null));
	}

	public IObservable<byte[]> DecryptBlock(byte[] block)
	{
		return Observable.Return(ProtectedData.Unprotect(block, null));
	}
}

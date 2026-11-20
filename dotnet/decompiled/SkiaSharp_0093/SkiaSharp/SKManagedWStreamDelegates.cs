using System;

namespace SkiaSharp;

internal struct SKManagedWStreamDelegates : IEquatable<SKManagedWStreamDelegates>
{
	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void*, nint, bool> fWrite;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void> fFlush;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint> fBytesWritten;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void> fDestroy;

	public unsafe readonly bool Equals(SKManagedWStreamDelegates obj)
	{
		if (fWrite == obj.fWrite && fFlush == obj.fFlush && fBytesWritten == obj.fBytesWritten)
		{
			return fDestroy == obj.fDestroy;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKManagedWStreamDelegates obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKManagedWStreamDelegates left, SKManagedWStreamDelegates right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKManagedWStreamDelegates left, SKManagedWStreamDelegates right)
	{
		return !left.Equals(right);
	}

	public unsafe override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add((void*)fWrite);
		hashCode.Add((void*)fFlush);
		hashCode.Add((void*)fBytesWritten);
		hashCode.Add((void*)fDestroy);
		return hashCode.ToHashCode();
	}
}

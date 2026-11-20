using System;

namespace SkiaSharp;

internal struct SKManagedStreamDelegates : IEquatable<SKManagedStreamDelegates>
{
	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void*, nint, nint> fRead;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void*, nint, nint> fPeek;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, bool> fIsAtEnd;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, bool> fHasPosition;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, bool> fHasLength;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, bool> fRewind;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint> fGetPosition;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint, bool> fSeek;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, int, bool> fMove;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint> fGetLength;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint> fDuplicate;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint> fFork;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void> fDestroy;

	public unsafe readonly bool Equals(SKManagedStreamDelegates obj)
	{
		if (fRead == obj.fRead && fPeek == obj.fPeek && fIsAtEnd == obj.fIsAtEnd && fHasPosition == obj.fHasPosition && fHasLength == obj.fHasLength && fRewind == obj.fRewind && fGetPosition == obj.fGetPosition && fSeek == obj.fSeek && fMove == obj.fMove && fGetLength == obj.fGetLength && fDuplicate == obj.fDuplicate && fFork == obj.fFork)
		{
			return fDestroy == obj.fDestroy;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKManagedStreamDelegates obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKManagedStreamDelegates left, SKManagedStreamDelegates right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKManagedStreamDelegates left, SKManagedStreamDelegates right)
	{
		return !left.Equals(right);
	}

	public unsafe override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add((void*)fRead);
		hashCode.Add((void*)fPeek);
		hashCode.Add((void*)fIsAtEnd);
		hashCode.Add((void*)fHasPosition);
		hashCode.Add((void*)fHasLength);
		hashCode.Add((void*)fRewind);
		hashCode.Add((void*)fGetPosition);
		hashCode.Add((void*)fSeek);
		hashCode.Add((void*)fMove);
		hashCode.Add((void*)fGetLength);
		hashCode.Add((void*)fDuplicate);
		hashCode.Add((void*)fFork);
		hashCode.Add((void*)fDestroy);
		return hashCode.ToHashCode();
	}
}

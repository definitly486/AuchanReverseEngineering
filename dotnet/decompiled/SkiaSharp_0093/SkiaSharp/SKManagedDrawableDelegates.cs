using System;

namespace SkiaSharp;

internal struct SKManagedDrawableDelegates : IEquatable<SKManagedDrawableDelegates>
{
	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint, void> fDraw;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, SKRect*, void> fGetBounds;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint> fApproximateBytesUsed;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, nint> fMakePictureSnapshot;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void> fDestroy;

	public unsafe readonly bool Equals(SKManagedDrawableDelegates obj)
	{
		if (fDraw == obj.fDraw && fGetBounds == obj.fGetBounds && fApproximateBytesUsed == obj.fApproximateBytesUsed && fMakePictureSnapshot == obj.fMakePictureSnapshot)
		{
			return fDestroy == obj.fDestroy;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKManagedDrawableDelegates obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKManagedDrawableDelegates left, SKManagedDrawableDelegates right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKManagedDrawableDelegates left, SKManagedDrawableDelegates right)
	{
		return !left.Equals(right);
	}

	public unsafe override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add((void*)fDraw);
		hashCode.Add((void*)fGetBounds);
		hashCode.Add((void*)fApproximateBytesUsed);
		hashCode.Add((void*)fMakePictureSnapshot);
		hashCode.Add((void*)fDestroy);
		return hashCode.ToHashCode();
	}
}

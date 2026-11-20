using System;

namespace SkiaSharp;

internal struct SKManagedTraceMemoryDumpDelegates : IEquatable<SKManagedTraceMemoryDumpDelegates>
{
	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void*, void*, void*, ulong, void> fDumpNumericValue;

	public unsafe delegate* unmanaged[Cdecl]<nint, void*, void*, void*, void*, void> fDumpStringValue;

	public unsafe readonly bool Equals(SKManagedTraceMemoryDumpDelegates obj)
	{
		if (fDumpNumericValue == obj.fDumpNumericValue)
		{
			return fDumpStringValue == obj.fDumpStringValue;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is SKManagedTraceMemoryDumpDelegates obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public static bool operator ==(SKManagedTraceMemoryDumpDelegates left, SKManagedTraceMemoryDumpDelegates right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SKManagedTraceMemoryDumpDelegates left, SKManagedTraceMemoryDumpDelegates right)
	{
		return !left.Equals(right);
	}

	public unsafe override readonly int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add((void*)fDumpNumericValue);
		hashCode.Add((void*)fDumpStringValue);
		return hashCode.ToHashCode();
	}
}

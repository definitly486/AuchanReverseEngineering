using System.Diagnostics.CodeAnalysis;

namespace System.Reflection.Metadata;

public readonly struct BlobHandle : IEquatable<BlobHandle>
{
	internal enum VirtualIndex : byte
	{
		Nil,
		ContractPublicKeyToken,
		ContractPublicKey,
		AttributeUsage_AllowSingle,
		AttributeUsage_AllowMultiple,
		Count
	}

	private readonly uint _value;

	public bool IsNil => _value == 0;

	internal bool IsVirtual => (_value & 0x80000000u) != 0;

	private ushort VirtualValue => (ushort)(_value >> 8);

	private BlobHandle(uint value)
	{
		_value = value;
	}

	internal static BlobHandle FromOffset(int heapOffset)
	{
		return new BlobHandle((uint)heapOffset);
	}

	internal unsafe void SubstituteTemplateParameters(byte[] blob)
	{
		fixed (byte* ptr = &blob[2])
		{
			*(int*)ptr = VirtualValue;
		}
	}

	internal int GetHeapOffset()
	{
		return (int)_value;
	}

	internal VirtualIndex GetVirtualIndex()
	{
		return (VirtualIndex)(_value & 0xFF);
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is BlobHandle other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(BlobHandle other)
	{
		return _value == other._value;
	}

	public override int GetHashCode()
	{
		return (int)_value;
	}

	public static bool operator ==(BlobHandle left, BlobHandle right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(BlobHandle left, BlobHandle right)
	{
		return !left.Equals(right);
	}
}

using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;

namespace System.Net.NetworkInformation;

public class PhysicalAddress
{
	private readonly byte[] _address;

	private int _hash;

	public static readonly PhysicalAddress None = new PhysicalAddress(Array.Empty<byte>());

	public PhysicalAddress(byte[] address)
	{
		_address = address;
	}

	public override int GetHashCode()
	{
		if (_hash == 0)
		{
			int num = 0;
			int num2 = _address.Length & -4;
			int i;
			for (i = 0; i < num2; i += 4)
			{
				num ^= BinaryPrimitives.ReadInt32LittleEndian(_address.AsSpan(i));
			}
			if ((_address.Length & 3) != 0)
			{
				int num3 = 0;
				int num4 = 0;
				for (; i < _address.Length; i++)
				{
					num3 |= _address[i] << num4;
					num4 += 8;
				}
				num ^= num3;
			}
			if (num == 0)
			{
				num = 1;
			}
			_hash = num;
		}
		return _hash;
	}

	public override bool Equals([NotNullWhen(true)] object? comparand)
	{
		if (comparand is PhysicalAddress physicalAddress && _address.Length == physicalAddress._address.Length && GetHashCode() == physicalAddress.GetHashCode())
		{
			return ((ReadOnlySpan<byte>)_address.AsSpan()).SequenceEqual((ReadOnlySpan<byte>)physicalAddress._address);
		}
		return false;
	}

	public override string ToString()
	{
		return Convert.ToHexString(_address.AsSpan());
	}
}

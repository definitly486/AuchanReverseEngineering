using System;

namespace Mono;

internal struct RuntimePropertyHandle : IEquatable<RuntimePropertyHandle>
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimePropertyHandle(nint v)
	{
		value = v;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return value == ((RuntimePropertyHandle)obj).Value;
	}

	public bool Equals(RuntimePropertyHandle handle)
	{
		return value == handle.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}
}

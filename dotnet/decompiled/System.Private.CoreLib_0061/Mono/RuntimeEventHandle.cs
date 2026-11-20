using System;

namespace Mono;

internal struct RuntimeEventHandle : IEquatable<RuntimeEventHandle>
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimeEventHandle(nint v)
	{
		value = v;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return value == ((RuntimeEventHandle)obj).Value;
	}

	public bool Equals(RuntimeEventHandle handle)
	{
		return value == handle.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}
}

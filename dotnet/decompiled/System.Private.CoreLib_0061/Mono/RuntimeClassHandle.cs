using System;
using System.Runtime.CompilerServices;

namespace Mono;

internal struct RuntimeClassHandle : IEquatable<RuntimeClassHandle>
{
	private unsafe readonly RuntimeStructs.MonoClass* value;

	internal unsafe RuntimeStructs.MonoClass* Value => value;

	internal unsafe RuntimeClassHandle(RuntimeStructs.MonoClass* value)
	{
		this.value = value;
	}

	public unsafe override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return value == ((RuntimeClassHandle)obj).Value;
	}

	public unsafe override int GetHashCode()
	{
		nint num = (nint)value;
		return ((IntPtr)num).GetHashCode();
	}

	public unsafe bool Equals(RuntimeClassHandle handle)
	{
		return value == handle.Value;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe static extern nint GetTypeFromClass(RuntimeStructs.MonoClass* klass);

	internal unsafe RuntimeTypeHandle GetTypeHandle()
	{
		return new RuntimeTypeHandle(GetTypeFromClass(value));
	}
}

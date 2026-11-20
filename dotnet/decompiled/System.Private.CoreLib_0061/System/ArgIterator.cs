using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Auto)]
public ref struct ArgIterator
{
	private nint sig;

	private nint args;

	private int next_arg;

	private int num_args;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern void Setup(nint argsp, nint start);

	public ArgIterator(RuntimeArgumentHandle arglist)
	{
		sig = IntPtr.Zero;
		args = IntPtr.Zero;
		next_arg = (num_args = 0);
		if (arglist.args == IntPtr.Zero)
		{
			throw new PlatformNotSupportedException();
		}
		Setup(arglist.args, IntPtr.Zero);
	}

	[CLSCompliant(false)]
	public unsafe ArgIterator(RuntimeArgumentHandle arglist, void* ptr)
	{
		sig = IntPtr.Zero;
		args = IntPtr.Zero;
		next_arg = (num_args = 0);
		if (arglist.args == IntPtr.Zero)
		{
			throw new PlatformNotSupportedException();
		}
		Setup(arglist.args, (nint)ptr);
	}

	public void End()
	{
		next_arg = num_args;
	}

	public override bool Equals(object? o)
	{
		throw new NotSupportedException("NotSupported_NYI");
	}

	public override int GetHashCode()
	{
		return ((IntPtr)sig).GetHashCode();
	}

	[CLSCompliant(false)]
	public unsafe TypedReference GetNextArg()
	{
		if (num_args == next_arg)
		{
			throw new InvalidOperationException("InvalidOperation_EnumEnded");
		}
		TypedReference result = default(TypedReference);
		IntGetNextArg(&result);
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe extern void IntGetNextArg(void* res);

	[CLSCompliant(false)]
	public unsafe TypedReference GetNextArg(RuntimeTypeHandle rth)
	{
		if (num_args == next_arg)
		{
			throw new InvalidOperationException("InvalidOperation_EnumEnded");
		}
		TypedReference result = default(TypedReference);
		IntGetNextArgWithType(&result, rth.Value);
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe extern void IntGetNextArgWithType(void* res, nint rth);

	public RuntimeTypeHandle GetNextArgType()
	{
		if (num_args == next_arg)
		{
			throw new InvalidOperationException("InvalidOperation_EnumEnded");
		}
		return new RuntimeTypeHandle(IntGetNextArgType());
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern nint IntGetNextArgType();

	public int GetRemainingCount()
	{
		return num_args - next_arg;
	}
}

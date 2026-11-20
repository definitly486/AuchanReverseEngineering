using System;
using System.Runtime.InteropServices;

namespace Java.Interop;

[StructLayout(LayoutKind.Explicit)]
public struct JniArgumentValue : IEquatable<JniArgumentValue>
{
	[FieldOffset(0)]
	private bool z;

	[FieldOffset(0)]
	private sbyte b;

	[FieldOffset(0)]
	private char c;

	[FieldOffset(0)]
	private short s;

	[FieldOffset(0)]
	private int i;

	[FieldOffset(0)]
	private long j;

	[FieldOffset(0)]
	private float f;

	[FieldOffset(0)]
	private double d;

	[FieldOffset(0)]
	private nint l;

	public JniArgumentValue(bool value)
	{
		this = default(JniArgumentValue);
		z = value;
	}

	public JniArgumentValue(sbyte value)
	{
		this = default(JniArgumentValue);
		b = value;
	}

	public JniArgumentValue(char value)
	{
		this = default(JniArgumentValue);
		c = value;
	}

	public JniArgumentValue(short value)
	{
		this = default(JniArgumentValue);
		s = value;
	}

	public JniArgumentValue(ushort value)
		: this((short)value)
	{
	}

	public JniArgumentValue(int value)
	{
		this = default(JniArgumentValue);
		i = value;
	}

	public JniArgumentValue(long value)
	{
		this = default(JniArgumentValue);
		j = value;
	}

	public JniArgumentValue(float value)
	{
		this = default(JniArgumentValue);
		f = value;
	}

	public JniArgumentValue(double value)
	{
		this = default(JniArgumentValue);
		d = value;
	}

	public JniArgumentValue(nint value)
	{
		this = default(JniArgumentValue);
		l = value;
	}

	public JniArgumentValue(JniObjectReference value)
	{
		this = default(JniArgumentValue);
		l = value.Handle;
	}

	public JniArgumentValue(IJavaPeerable? value)
	{
		this = default(JniArgumentValue);
		if (value != null)
		{
			l = value.PeerReference.Handle;
		}
		else
		{
			l = IntPtr.Zero;
		}
	}

	public override int GetHashCode()
	{
		return j.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		JniArgumentValue? jniArgumentValue = obj as JniArgumentValue?;
		if (!jniArgumentValue.HasValue)
		{
			return false;
		}
		return Equals(jniArgumentValue.Value);
	}

	public bool Equals(JniArgumentValue other)
	{
		return j == other.j;
	}

	public static bool operator ==(JniArgumentValue lhs, JniArgumentValue rhs)
	{
		return lhs.j == rhs.j;
	}

	public static bool operator !=(JniArgumentValue lhs, JniArgumentValue rhs)
	{
		return lhs.j != rhs.j;
	}

	public override string ToString()
	{
		_003C_003Ey__InlineArray9<object> buffer = default(_003C_003Ey__InlineArray9<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 0) = z;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 1) = b;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 2) = c;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 3) = s;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 4) = i;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 5) = j;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 6) = f;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 7) = d;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<object>, object>(ref buffer, 8) = ((IntPtr)l).ToString("x");
		return string.Format("JniArgumentValue(z={0},b={1},c={2},s={3},i={4},j={5},f={6},d={7},l=0x{8})", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<object>, object>(in buffer, 9));
	}
}

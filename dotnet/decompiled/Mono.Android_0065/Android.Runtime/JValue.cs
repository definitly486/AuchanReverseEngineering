using System;
using System.Runtime.InteropServices;

namespace Android.Runtime;

[StructLayout(LayoutKind.Explicit)]
public struct JValue
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

	public static JValue Zero = new JValue(IntPtr.Zero);

	public JValue(bool value)
	{
		this = default(JValue);
		z = value;
	}

	public JValue(sbyte value)
	{
		this = default(JValue);
		b = value;
	}

	public JValue(char value)
	{
		this = default(JValue);
		c = value;
	}

	public JValue(short value)
	{
		this = default(JValue);
		s = value;
	}

	public JValue(int value)
	{
		this = default(JValue);
		i = value;
	}

	public JValue(long value)
	{
		this = default(JValue);
		j = value;
	}

	public JValue(float value)
	{
		this = default(JValue);
		f = value;
	}

	public JValue(double value)
	{
		this = default(JValue);
		d = value;
	}

	public JValue(nint value)
	{
		this = default(JValue);
		l = value;
	}

	public JValue(IJavaObject value)
	{
		this = default(JValue);
		l = value?.Handle ?? IntPtr.Zero;
	}
}

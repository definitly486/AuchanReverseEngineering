using System;
using System.Runtime.CompilerServices;

namespace Java.Interop;

public sealed class JniFieldInfo
{
	[CompilerGenerated]
	private bool _003CIsStatic_003Ek__BackingField;

	public nint ID { get; private set; }

	private bool IsStatic
	{
		[CompilerGenerated]
		set
		{
			_003CIsStatic_003Ek__BackingField = value;
		}
	}

	internal bool IsValid => ID != IntPtr.Zero;

	public string Name
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public string Signature
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public JniFieldInfo(nint fieldID, bool isStatic)
	{
		ID = fieldID;
		IsStatic = isStatic;
	}

	public JniFieldInfo(string name, string signature, nint fieldID, bool isStatic)
	{
		ID = fieldID;
		IsStatic = isStatic;
	}

	public override string ToString()
	{
		bool flag = false;
		bool flag2 = false;
		_003C_003Ey__InlineArray5<object> buffer = default(_003C_003Ey__InlineArray5<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 0) = (flag ? ("Name=" + Name) : string.Empty);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 1) = (flag ? ", " : string.Empty);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 2) = (flag2 ? ("Signature=" + Signature) : string.Empty);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 3) = ((flag || flag2) ? ", " : string.Empty);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<object>, object>(ref buffer, 4) = ((IntPtr)ID).ToString("x");
		return string.Format("JniFieldInfo({0}{1}{2}{3}ID=0x{4})", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<object>, object>(in buffer, 5));
	}
}

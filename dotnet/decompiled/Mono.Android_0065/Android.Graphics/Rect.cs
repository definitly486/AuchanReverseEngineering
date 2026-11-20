using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Rect", DoNotGenerateAcw = true)]
public sealed class Rect : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Rect", typeof(Rect));

	[Register("bottom")]
	public int Bottom
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("bottom.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("bottom.I", this, value);
		}
	}

	[Register("left")]
	public int Left
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("left.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("left.I", this, value);
		}
	}

	[Register("right")]
	public int Right
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("right.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("right.I", this, value);
		}
	}

	[Register("top")]
	public int Top
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("top.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("top.I", this, value);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe bool IsEmpty => _members.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	internal Rect(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe Rect()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	public unsafe Rect(Rect? r)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/Rect;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(r);
		}
	}

	public unsafe Rect(int left, int top, int right, int bottom)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
		}
	}

	public unsafe bool Contains(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("contains.(II)Z", this, ptr);
	}

	public unsafe int DescribeContents()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
	}

	public unsafe int Height()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("height.()I", this, null);
	}

	public unsafe bool Intersect(Rect r)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("intersect.(Landroid/graphics/Rect;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(r);
		}
	}

	public unsafe static bool Intersects(Rect a, Rect b)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("intersects.(Landroid/graphics/Rect;Landroid/graphics/Rect;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	public unsafe void OffsetTo(int newLeft, int newTop)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(newLeft);
		ptr[1] = new JniArgumentValue(newTop);
		_members.InstanceMethods.InvokeAbstractVoidMethod("offsetTo.(II)V", this, ptr);
	}

	public unsafe int Width()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("width.()I", this, null);
	}

	public unsafe void WriteToParcel(Parcel? @out, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@out);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}

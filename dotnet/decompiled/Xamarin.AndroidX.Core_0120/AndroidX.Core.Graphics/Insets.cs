using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Graphics;

[Register("androidx/core/graphics/Insets", DoNotGenerateAcw = true)]
public sealed class Insets : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/graphics/Insets", typeof(Insets));

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

	[Register("NONE")]
	public static Insets? None => Java.Lang.Object.GetObject<Insets>(_members.StaticFields.GetObjectValue("NONE.Landroidx/core/graphics/Insets;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal Insets(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("add", "(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? Add(Insets? a, Insets? b)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("add.(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	[Register("max", "(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? Max(Insets? a, Insets? b)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("max.(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	[Register("min", "(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? Min(Insets? a, Insets? b)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("min.(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	[Register("of", "(Landroid/graphics/Rect;)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? Of(Rect? r)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("of.(Landroid/graphics/Rect;)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(r);
		}
	}

	[Register("of", "(IIII)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? Of(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("of.(IIII)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("subtract", "(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? Subtract(Insets? a, Insets? b)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("subtract.(Landroidx/core/graphics/Insets;Landroidx/core/graphics/Insets;)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(a);
			GC.KeepAlive(b);
		}
	}

	[Register("toCompatInsets", "(Landroid/graphics/Insets;)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? ToCompatInsets(Android.Graphics.Insets? insets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("toCompatInsets.(Landroid/graphics/Insets;)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(insets);
		}
	}

	[Register("toPlatformInsets", "()Landroid/graphics/Insets;", "")]
	public unsafe Android.Graphics.Insets? ToPlatformInsets()
	{
		return Java.Lang.Object.GetObject<Android.Graphics.Insets>(_members.InstanceMethods.InvokeAbstractObjectMethod("toPlatformInsets.()Landroid/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("wrap", "(Landroid/graphics/Insets;)Landroidx/core/graphics/Insets;", "")]
	public unsafe static Insets? Wrap(Android.Graphics.Insets? insets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Insets>(_members.StaticMethods.InvokeObjectMethod("wrap.(Landroid/graphics/Insets;)Landroidx/core/graphics/Insets;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(insets);
		}
	}
}

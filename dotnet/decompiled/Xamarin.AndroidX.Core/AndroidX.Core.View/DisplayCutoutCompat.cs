using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using AndroidX.Core.Graphics;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/DisplayCutoutCompat", DoNotGenerateAcw = true)]
public sealed class DisplayCutoutCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/DisplayCutoutCompat", typeof(DisplayCutoutCompat));

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

	public unsafe IList<Rect>? BoundingRects
	{
		[Register("getBoundingRects", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<Rect>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getBoundingRects.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Path? CutoutPath
	{
		[Register("getCutoutPath", "()Landroid/graphics/Path;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Path>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCutoutPath.()Landroid/graphics/Path;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int SafeInsetBottom
	{
		[Register("getSafeInsetBottom", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSafeInsetBottom.()I", this, null);
		}
	}

	public unsafe int SafeInsetLeft
	{
		[Register("getSafeInsetLeft", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSafeInsetLeft.()I", this, null);
		}
	}

	public unsafe int SafeInsetRight
	{
		[Register("getSafeInsetRight", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSafeInsetRight.()I", this, null);
		}
	}

	public unsafe int SafeInsetTop
	{
		[Register("getSafeInsetTop", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSafeInsetTop.()I", this, null);
		}
	}

	public unsafe AndroidX.Core.Graphics.Insets? WaterfallInsets
	{
		[Register("getWaterfallInsets", "()Landroidx/core/graphics/Insets;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Core.Graphics.Insets>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWaterfallInsets.()Landroidx/core/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal DisplayCutoutCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/graphics/Rect;Ljava/util/List;)V", "")]
	public unsafe DisplayCutoutCompat(Rect? safeInsets, IList<Rect>? boundingRects)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JavaList<Rect>.ToLocalJniHandle(boundingRects);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(safeInsets?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/Rect;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/Rect;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(safeInsets);
			GC.KeepAlive(boundingRects);
		}
	}

	[Register(".ctor", "(Landroidx/core/graphics/Insets;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroidx/core/graphics/Insets;)V", "")]
	public unsafe DisplayCutoutCompat(AndroidX.Core.Graphics.Insets? safeInsets, Rect? boundLeft, Rect? boundTop, Rect? boundRight, Rect? boundBottom, AndroidX.Core.Graphics.Insets? waterfallInsets)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(safeInsets?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(boundLeft?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(boundTop?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(boundRight?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(boundBottom?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(waterfallInsets?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/core/graphics/Insets;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroidx/core/graphics/Insets;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/core/graphics/Insets;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroidx/core/graphics/Insets;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(safeInsets);
			GC.KeepAlive(boundLeft);
			GC.KeepAlive(boundTop);
			GC.KeepAlive(boundRight);
			GC.KeepAlive(boundBottom);
			GC.KeepAlive(waterfallInsets);
		}
	}

	[Register(".ctor", "(Landroidx/core/graphics/Insets;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroidx/core/graphics/Insets;Landroid/graphics/Path;)V", "")]
	public unsafe DisplayCutoutCompat(AndroidX.Core.Graphics.Insets? safeInsets, Rect? boundLeft, Rect? boundTop, Rect? boundRight, Rect? boundBottom, AndroidX.Core.Graphics.Insets? waterfallInsets, Path? cutoutPath)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(safeInsets?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(boundLeft?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(boundTop?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(boundRight?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(boundBottom?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(waterfallInsets?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(cutoutPath?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/core/graphics/Insets;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroidx/core/graphics/Insets;Landroid/graphics/Path;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/core/graphics/Insets;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroid/graphics/Rect;Landroidx/core/graphics/Insets;Landroid/graphics/Path;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(safeInsets);
			GC.KeepAlive(boundLeft);
			GC.KeepAlive(boundTop);
			GC.KeepAlive(boundRight);
			GC.KeepAlive(boundBottom);
			GC.KeepAlive(waterfallInsets);
			GC.KeepAlive(cutoutPath);
		}
	}
}

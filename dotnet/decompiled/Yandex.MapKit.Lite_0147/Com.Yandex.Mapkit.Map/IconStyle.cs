using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/IconStyle", DoNotGenerateAcw = true)]
public sealed class IconStyle : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/IconStyle", typeof(IconStyle));

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

	public unsafe PointF? Anchor
	{
		[Register("getAnchor", "()Landroid/graphics/PointF;", "")]
		get
		{
			return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAnchor.()Landroid/graphics/PointF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Java.Lang.Boolean? Flat
	{
		[Register("getFlat", "()Ljava/lang/Boolean;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getFlat.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe RotationType? RotationType
	{
		[Register("getRotationType", "()Lcom/yandex/mapkit/map/RotationType;", "")]
		get
		{
			return Java.Lang.Object.GetObject<RotationType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRotationType.()Lcom/yandex/mapkit/map/RotationType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Float? Scale
	{
		[Register("getScale", "()Ljava/lang/Float;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeAbstractObjectMethod("getScale.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Rect? TappableArea
	{
		[Register("getTappableArea", "()Lcom/yandex/mapkit/map/Rect;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTappableArea.()Lcom/yandex/mapkit/map/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Java.Lang.Boolean? Visible
	{
		[Register("getVisible", "()Ljava/lang/Boolean;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getVisible.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Float? ZIndex
	{
		[Register("getZIndex", "()Ljava/lang/Float;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Float>(_members.InstanceMethods.InvokeAbstractObjectMethod("getZIndex.()Ljava/lang/Float;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal IconStyle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe IconStyle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/graphics/PointF;Lcom/yandex/mapkit/map/RotationType;Ljava/lang/Float;Ljava/lang/Boolean;Ljava/lang/Boolean;Ljava/lang/Float;Lcom/yandex/mapkit/map/Rect;)V", "")]
	public unsafe IconStyle(PointF? anchor, RotationType? rotationType, Float? zIndex, Java.Lang.Boolean? flat, Java.Lang.Boolean? visible, Float? scale, Rect? tappableArea)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(rotationType?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(zIndex?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(flat?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(visible?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(scale?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(tappableArea?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/PointF;Lcom/yandex/mapkit/map/RotationType;Ljava/lang/Float;Ljava/lang/Boolean;Ljava/lang/Boolean;Ljava/lang/Float;Lcom/yandex/mapkit/map/Rect;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/PointF;Lcom/yandex/mapkit/map/RotationType;Ljava/lang/Float;Ljava/lang/Boolean;Ljava/lang/Boolean;Ljava/lang/Float;Lcom/yandex/mapkit/map/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchor);
			GC.KeepAlive(rotationType);
			GC.KeepAlive(zIndex);
			GC.KeepAlive(flat);
			GC.KeepAlive(visible);
			GC.KeepAlive(scale);
			GC.KeepAlive(tappableArea);
		}
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "")]
	public unsafe void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}

	[Register("setAnchor", "(Landroid/graphics/PointF;)Lcom/yandex/mapkit/map/IconStyle;", "")]
	public unsafe IconStyle? SetAnchor(PointF? anchor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IconStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAnchor.(Landroid/graphics/PointF;)Lcom/yandex/mapkit/map/IconStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	[Register("setFlat", "(Ljava/lang/Boolean;)Lcom/yandex/mapkit/map/IconStyle;", "")]
	public unsafe IconStyle? SetFlat(Java.Lang.Boolean? flat)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(flat?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IconStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setFlat.(Ljava/lang/Boolean;)Lcom/yandex/mapkit/map/IconStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(flat);
		}
	}

	[Register("setRotationType", "(Lcom/yandex/mapkit/map/RotationType;)Lcom/yandex/mapkit/map/IconStyle;", "")]
	public unsafe IconStyle? SetRotationType(RotationType? rotationType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rotationType?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IconStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRotationType.(Lcom/yandex/mapkit/map/RotationType;)Lcom/yandex/mapkit/map/IconStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(rotationType);
		}
	}

	[Register("setScale", "(Ljava/lang/Float;)Lcom/yandex/mapkit/map/IconStyle;", "")]
	public unsafe IconStyle? SetScale(Float? scale)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(scale?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IconStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setScale.(Ljava/lang/Float;)Lcom/yandex/mapkit/map/IconStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(scale);
		}
	}

	[Register("setTappableArea", "(Lcom/yandex/mapkit/map/Rect;)Lcom/yandex/mapkit/map/IconStyle;", "")]
	public unsafe IconStyle? SetTappableArea(Rect? tappableArea)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tappableArea?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IconStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTappableArea.(Lcom/yandex/mapkit/map/Rect;)Lcom/yandex/mapkit/map/IconStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(tappableArea);
		}
	}

	[Register("setVisible", "(Ljava/lang/Boolean;)Lcom/yandex/mapkit/map/IconStyle;", "")]
	public unsafe IconStyle? SetVisible(Java.Lang.Boolean? visible)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(visible?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IconStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setVisible.(Ljava/lang/Boolean;)Lcom/yandex/mapkit/map/IconStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(visible);
		}
	}

	[Register("setZIndex", "(Ljava/lang/Float;)Lcom/yandex/mapkit/map/IconStyle;", "")]
	public unsafe IconStyle? SetZIndex(Float? zIndex)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(zIndex?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IconStyle>(_members.InstanceMethods.InvokeAbstractObjectMethod("setZIndex.(Ljava/lang/Float;)Lcom/yandex/mapkit/map/IconStyle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(zIndex);
		}
	}
}

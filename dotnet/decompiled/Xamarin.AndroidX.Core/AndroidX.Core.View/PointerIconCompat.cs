using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/PointerIconCompat", DoNotGenerateAcw = true)]
public sealed class PointerIconCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/PointerIconCompat", typeof(PointerIconCompat));

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

	public unsafe Java.Lang.Object? PointerIcon
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getPointerIcon", "()Ljava/lang/Object;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPointerIcon.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal PointerIconCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("create", "(Landroid/graphics/Bitmap;FF)Landroidx/core/view/PointerIconCompat;", "")]
	public unsafe static PointerIconCompat? Create(Bitmap? bitmap, float hotSpotX, float hotSpotY)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(hotSpotX);
			ptr[2] = new JniArgumentValue(hotSpotY);
			return Java.Lang.Object.GetObject<PointerIconCompat>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/graphics/Bitmap;FF)Landroidx/core/view/PointerIconCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(bitmap);
		}
	}

	[Register("getSystemIcon", "(Landroid/content/Context;I)Landroidx/core/view/PointerIconCompat;", "")]
	public unsafe static PointerIconCompat? GetSystemIcon(Context? context, int style)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(style);
			return Java.Lang.Object.GetObject<PointerIconCompat>(_members.StaticMethods.InvokeObjectMethod("getSystemIcon.(Landroid/content/Context;I)Landroidx/core/view/PointerIconCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("load", "(Landroid/content/res/Resources;I)Landroidx/core/view/PointerIconCompat;", "")]
	public unsafe static PointerIconCompat? Load(Resources? resources, int resourceId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resources?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceId);
			return Java.Lang.Object.GetObject<PointerIconCompat>(_members.StaticMethods.InvokeObjectMethod("load.(Landroid/content/res/Resources;I)Landroidx/core/view/PointerIconCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resources);
		}
	}
}

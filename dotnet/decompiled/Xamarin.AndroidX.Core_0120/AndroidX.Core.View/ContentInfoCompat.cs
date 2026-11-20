using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.Util;
using Java.Interop;
using Java.Lang;
using Java.Util.Functions;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ContentInfoCompat", DoNotGenerateAcw = true)]
public sealed class ContentInfoCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/ContentInfoCompat", typeof(ContentInfoCompat));

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

	public unsafe ClipData? Clip
	{
		[Register("getClip", "()Landroid/content/ClipData;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ClipData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getClip.()Landroid/content/ClipData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Bundle? Extras
	{
		[Register("getExtras", "()Landroid/os/Bundle;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExtras.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int Flags
	{
		[Register("getFlags", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getFlags.()I", this, null);
		}
	}

	public unsafe Uri? LinkUri
	{
		[Register("getLinkUri", "()Landroid/net/Uri;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLinkUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int Source
	{
		[Register("getSource", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSource.()I", this, null);
		}
	}

	internal ContentInfoCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("partition", "(Landroid/view/ContentInfo;Ljava/util/function/Predicate;)Landroid/util/Pair;", "")]
	public unsafe static Android.Util.Pair? Partition(ContentInfo? payload, Java.Util.Functions.IPredicate? itemPredicate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((itemPredicate == null) ? IntPtr.Zero : ((Java.Lang.Object)itemPredicate).Handle);
			return Java.Lang.Object.GetObject<Android.Util.Pair>(_members.StaticMethods.InvokeObjectMethod("partition.(Landroid/view/ContentInfo;Ljava/util/function/Predicate;)Landroid/util/Pair;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(payload);
			GC.KeepAlive(itemPredicate);
		}
	}

	[Register("partition", "(Landroidx/core/util/Predicate;)Landroid/util/Pair;", "")]
	public unsafe Android.Util.Pair? Partition(AndroidX.Core.Util.IPredicate? itemPredicate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((itemPredicate == null) ? IntPtr.Zero : ((Java.Lang.Object)itemPredicate).Handle);
			return Java.Lang.Object.GetObject<Android.Util.Pair>(_members.InstanceMethods.InvokeAbstractObjectMethod("partition.(Landroidx/core/util/Predicate;)Landroid/util/Pair;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(itemPredicate);
		}
	}

	[Register("toContentInfo", "()Landroid/view/ContentInfo;", "")]
	public unsafe ContentInfo? ToContentInfo()
	{
		return Java.Lang.Object.GetObject<ContentInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("toContentInfo.()Landroid/view/ContentInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toContentInfoCompat", "(Landroid/view/ContentInfo;)Landroidx/core/view/ContentInfoCompat;", "")]
	public unsafe static ContentInfoCompat? ToContentInfoCompat(ContentInfo? platContentInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(platContentInfo?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ContentInfoCompat>(_members.StaticMethods.InvokeObjectMethod("toContentInfoCompat.(Landroid/view/ContentInfo;)Landroidx/core/view/ContentInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(platContentInfo);
		}
	}
}

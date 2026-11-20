using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/MediaStoreOutputOptions", DoNotGenerateAcw = true)]
public sealed class MediaStoreOutputOptions : OutputOptions
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/MediaStoreOutputOptions", typeof(MediaStoreOutputOptions));

	[Register("EMPTY_CONTENT_VALUES")]
	public static ContentValues EmptyContentValues => Java.Lang.Object.GetObject<ContentValues>(_members.StaticFields.GetObjectValue("EMPTY_CONTENT_VALUES.Landroid/content/ContentValues;").Handle, JniHandleOwnership.TransferLocalRef);

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Android.Net.Uri CollectionUri
	{
		[Register("getCollectionUri", "()Landroid/net/Uri;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCollectionUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ContentResolver ContentResolver
	{
		[Register("getContentResolver", "()Landroid/content/ContentResolver;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ContentResolver>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentResolver.()Landroid/content/ContentResolver;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ContentValues ContentValues
	{
		[Register("getContentValues", "()Landroid/content/ContentValues;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ContentValues>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentValues.()Landroid/content/ContentValues;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal MediaStoreOutputOptions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}

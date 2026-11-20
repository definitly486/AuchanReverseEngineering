using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/Quality", DoNotGenerateAcw = true)]
public class Quality : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/Quality", typeof(Quality));

	[Register("FHD")]
	public static Quality? Fhd => Java.Lang.Object.GetObject<Quality>(_members.StaticFields.GetObjectValue("FHD.Landroidx/camera/video/Quality;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HD")]
	public static Quality? Hd => Java.Lang.Object.GetObject<Quality>(_members.StaticFields.GetObjectValue("HD.Landroidx/camera/video/Quality;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HIGHEST")]
	public static Quality? Highest => Java.Lang.Object.GetObject<Quality>(_members.StaticFields.GetObjectValue("HIGHEST.Landroidx/camera/video/Quality;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LOWEST")]
	public static Quality? Lowest => Java.Lang.Object.GetObject<Quality>(_members.StaticFields.GetObjectValue("LOWEST.Landroidx/camera/video/Quality;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SD")]
	public static Quality? Sd => Java.Lang.Object.GetObject<Quality>(_members.StaticFields.GetObjectValue("SD.Landroidx/camera/video/Quality;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UHD")]
	public static Quality? Uhd => Java.Lang.Object.GetObject<Quality>(_members.StaticFields.GetObjectValue("UHD.Landroidx/camera/video/Quality;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe static IList<Quality> SortedQualities
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSortedQualities", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<Quality>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getSortedQualities.()Ljava/util/List;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Quality(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}

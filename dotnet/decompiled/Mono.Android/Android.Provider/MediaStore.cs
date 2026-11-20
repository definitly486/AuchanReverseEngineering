using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Net;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Provider;

[Register("android/provider/MediaStore", DoNotGenerateAcw = true)]
public sealed class MediaStore : Java.Lang.Object
{
	[Register("android/provider/MediaStore$Audio", DoNotGenerateAcw = true)]
	public sealed class Audio : Java.Lang.Object
	{
		[Register("android/provider/MediaStore$Audio$Media", DoNotGenerateAcw = true)]
		public sealed class Media : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/MediaStore$Audio$Media", typeof(Media));

			[Register("EXTERNAL_CONTENT_URI")]
			public static Android.Net.Uri? ExternalContentUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticFields.GetObjectValue("EXTERNAL_CONTENT_URI.Landroid/net/Uri;").Handle, JniHandleOwnership.TransferLocalRef);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Media(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/MediaStore$Audio", typeof(Audio));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Audio(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/provider/MediaStore$Images", DoNotGenerateAcw = true)]
	public sealed class Images : Java.Lang.Object
	{
		[Register("android/provider/MediaStore$Images$Media", DoNotGenerateAcw = true)]
		public sealed class Media : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/MediaStore$Images$Media", typeof(Media));

			[Register("EXTERNAL_CONTENT_URI")]
			public static Android.Net.Uri? ExternalContentUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticFields.GetObjectValue("EXTERNAL_CONTENT_URI.Landroid/net/Uri;").Handle, JniHandleOwnership.TransferLocalRef);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Media(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/MediaStore$Images", typeof(Images));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Images(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/provider/MediaStore$Video", DoNotGenerateAcw = true)]
	public sealed class Video : Java.Lang.Object
	{
		[Register("android/provider/MediaStore$Video$Media", DoNotGenerateAcw = true)]
		public sealed class Media : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/MediaStore$Video$Media", typeof(Media));

			[Register("EXTERNAL_CONTENT_URI")]
			public static Android.Net.Uri? ExternalContentUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticFields.GetObjectValue("EXTERNAL_CONTENT_URI.Landroid/net/Uri;").Handle, JniHandleOwnership.TransferLocalRef);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Media(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/MediaStore$Video", typeof(Video));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Video(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/MediaStore", typeof(MediaStore));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal MediaStore(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}

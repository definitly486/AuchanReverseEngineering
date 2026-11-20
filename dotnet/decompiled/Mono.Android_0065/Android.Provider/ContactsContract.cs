using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Net;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Provider;

[Register("android/provider/ContactsContract", DoNotGenerateAcw = true)]
public sealed class ContactsContract : Java.Lang.Object
{
	[Register("android/provider/ContactsContract$CommonDataKinds", DoNotGenerateAcw = true)]
	public sealed class CommonDataKinds : Java.Lang.Object
	{
		[Register("android/provider/ContactsContract$CommonDataKinds$Email", DoNotGenerateAcw = true)]
		public sealed class Email : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/ContactsContract$CommonDataKinds$Email", typeof(Email));

			[Register("CONTENT_URI")]
			public static Android.Net.Uri? ContentUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticFields.GetObjectValue("CONTENT_URI.Landroid/net/Uri;").Handle, JniHandleOwnership.TransferLocalRef);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Email(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		[Register("android/provider/ContactsContract$CommonDataKinds$Phone", DoNotGenerateAcw = true)]
		public sealed class Phone : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/ContactsContract$CommonDataKinds$Phone", typeof(Phone));

			[Register("CONTENT_URI")]
			public static Android.Net.Uri? ContentUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticFields.GetObjectValue("CONTENT_URI.Landroid/net/Uri;").Handle, JniHandleOwnership.TransferLocalRef);

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal Phone(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/ContactsContract$CommonDataKinds", typeof(CommonDataKinds));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal CommonDataKinds(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/provider/ContactsContract$Contacts", DoNotGenerateAcw = true)]
	public class Contacts : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/ContactsContract$Contacts", typeof(Contacts));

		[Register("CONTENT_URI")]
		public static Android.Net.Uri? ContentUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticFields.GetObjectValue("CONTENT_URI.Landroid/net/Uri;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Contacts(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/provider/ContactsContract$Data", DoNotGenerateAcw = true)]
	public sealed class Data : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/ContactsContract$Data", typeof(Data));

		[Register("CONTENT_URI")]
		public static Android.Net.Uri? ContentUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members.StaticFields.GetObjectValue("CONTENT_URI.Landroid/net/Uri;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Data(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/ContactsContract", typeof(ContactsContract));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal ContactsContract(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}

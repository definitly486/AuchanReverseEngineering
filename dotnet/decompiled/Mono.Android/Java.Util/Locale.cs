using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Locale", DoNotGenerateAcw = true)]
public sealed class Locale : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android24.0")]
	[Register("java/util/Locale$Category", DoNotGenerateAcw = true, ApiSince = 24)]
	public sealed class Category : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Locale$Category", typeof(Category));

		[SupportedOSPlatform("android24.0")]
		[Register("FORMAT", ApiSince = 24)]
		public static Category? Format => Java.Lang.Object.GetObject<Category>(_members.StaticFields.GetObjectValue("FORMAT.Ljava/util/Locale$Category;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Category(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Locale", typeof(Locale));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe string Country
	{
		[Register("getCountry", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getCountry.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static Locale Default
	{
		[Register("getDefault", "()Ljava/util/Locale;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Locale>(_members.StaticMethods.InvokeObjectMethod("getDefault.()Ljava/util/Locale;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal Locale(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	[Register("getDefault", "(Ljava/util/Locale$Category;)Ljava/util/Locale;", "", ApiSince = 24)]
	public unsafe static Locale GetDefault(Category category)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(category?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Locale>(_members.StaticMethods.InvokeObjectMethod("getDefault.(Ljava/util/Locale$Category;)Ljava/util/Locale;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(category);
		}
	}

	[Register("toString", "()Ljava/lang/String;", "")]
	public unsafe sealed override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

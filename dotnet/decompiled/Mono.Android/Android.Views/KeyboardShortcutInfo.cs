using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[SupportedOSPlatform("android24.0")]
[Register("android/view/KeyboardShortcutInfo", DoNotGenerateAcw = true, ApiSince = 24)]
public sealed class KeyboardShortcutInfo : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/KeyboardShortcutInfo", typeof(KeyboardShortcutInfo));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal KeyboardShortcutInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;CI)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutInfo(ICharSequence? label, char baseCharacter, MetaKeyStates modifiers)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((ushort)baseCharacter);
			ptr[2] = new JniArgumentValue((int)modifiers);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;CI)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;CI)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(label);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;CI)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutInfo(string? label, char baseCharacter, MetaKeyStates modifiers)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((ushort)baseCharacter);
			ptr[2] = new JniArgumentValue((int)modifiers);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;CI)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;CI)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(label);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;II)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutInfo(ICharSequence? label, Keycode keycode, MetaKeyStates modifiers)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)keycode);
			ptr[2] = new JniArgumentValue((int)modifiers);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(label);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;II)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutInfo(string? label, Keycode keycode, MetaKeyStates modifiers)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)keycode);
			ptr[2] = new JniArgumentValue((int)modifiers);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(label);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register("describeContents", "()I", "", ApiSince = 24)]
	public unsafe int DescribeContents()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
	}

	[SupportedOSPlatform("android24.0")]
	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "", ApiSince = 24)]
	public unsafe void WriteToParcel(Parcel? dest, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
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

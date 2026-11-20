using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[SupportedOSPlatform("android24.0")]
[Register("android/view/KeyboardShortcutGroup", DoNotGenerateAcw = true, ApiSince = 24)]
public sealed class KeyboardShortcutGroup : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/KeyboardShortcutGroup", typeof(KeyboardShortcutGroup));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal KeyboardShortcutGroup(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;Ljava/util/List;)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutGroup(ICharSequence? label, IList<KeyboardShortcutInfo> items)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		nint num2 = JavaList<KeyboardShortcutInfo>.ToLocalJniHandle(items);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(label);
			GC.KeepAlive(items);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;Ljava/util/List;)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutGroup(string? label, IList<KeyboardShortcutInfo> items)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		nint num2 = JavaList<KeyboardShortcutInfo>.ToLocalJniHandle(items);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;Ljava/util/List;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(label);
			GC.KeepAlive(items);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutGroup(ICharSequence? label)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(label);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register(".ctor", "(Ljava/lang/CharSequence;)V", "", ApiSince = 24)]
	public unsafe KeyboardShortcutGroup(string? label)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/CharSequence;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/CharSequence;)V", this, ptr);
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

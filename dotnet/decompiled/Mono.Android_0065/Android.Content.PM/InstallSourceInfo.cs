using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content.PM;

[SupportedOSPlatform("android30.0")]
[Register("android/content/pm/InstallSourceInfo", DoNotGenerateAcw = true, ApiSince = 30)]
public sealed class InstallSourceInfo : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/InstallSourceInfo", typeof(InstallSourceInfo));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[SupportedOSPlatform("android30.0")]
	public unsafe string? InitiatingPackageName => JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getInitiatingPackageName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android30.0")]
	public unsafe string? InstallingPackageName => JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getInstallingPackageName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android34.0")]
	public unsafe string? UpdateOwnerPackageName => JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getUpdateOwnerPackageName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	internal InstallSourceInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android30.0")]
	public unsafe int DescribeContents()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("describeContents.()I", this, null);
	}

	[SupportedOSPlatform("android30.0")]
	public unsafe void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
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

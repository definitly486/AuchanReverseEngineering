using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Net;

[Register("java/net/URL", DoNotGenerateAcw = true)]
public sealed class URL : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/URL", typeof(URL));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe string? Protocol => JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getProtocol.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Ref => JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getRef.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	internal URL(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe URL(string? spec)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(spec);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	public unsafe URLConnection? OpenConnection()
	{
		return Java.Lang.Object.GetObject<URLConnection>(_members.InstanceMethods.InvokeAbstractObjectMethod("openConnection.()Ljava/net/URLConnection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe URLConnection? OpenConnection(Proxy? proxy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(proxy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<URLConnection>(_members.InstanceMethods.InvokeAbstractObjectMethod("openConnection.(Ljava/net/Proxy;)Ljava/net/URLConnection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(proxy);
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

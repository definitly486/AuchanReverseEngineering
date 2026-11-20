using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio.Channels;

namespace Java.IO;

[Register("java/io/FileInputStream", DoNotGenerateAcw = true)]
public class FileInputStream : InputStream, ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/FileInputStream", typeof(FileInputStream));

	private static Delegate? cb_getChannel_GetChannel_Ljava_nio_channels_FileChannel_;

	private static Delegate? cb_read_Read_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual FileChannel? Channel => Java.Lang.Object.GetObject<FileChannel>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChannel.()Ljava/nio/channels/FileChannel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	protected FileInputStream(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetChannelHandler()
	{
		return new _JniMarshal_PP_L(n_GetChannel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChannel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FileInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Channel);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetReadHandler()
	{
		return new _JniMarshal_PP_I(n_Read);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Read(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FileInputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Read();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe override int Read()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("read.()I", this, null);
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

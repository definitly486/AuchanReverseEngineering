using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Nio.Channels.Spi;

namespace Java.Nio.Channels;

[Register("java/nio/channels/FileChannel", DoNotGenerateAcw = true)]
public abstract class FileChannel : AbstractInterruptibleChannel, ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/nio/channels/FileChannel", typeof(FileChannel));

	private static Delegate? cb_position_Position_J;

	private static Delegate? cb_position_Position_J_Ljava_nio_channels_FileChannel_;

	private static Delegate? cb_size_Size_J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FileChannel(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetPositionHandler()
	{
		return new _JniMarshal_PP_J(n_Position);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_Position(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<FileChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public abstract long Position();

	private static Delegate GetPosition_JHandler()
	{
		return new _JniMarshal_PPJ_L(n_Position_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Position_J(nint jnienv, nint native__this, long newPosition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FileChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position(newPosition));
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

	public abstract FileChannel? Position(long newPosition);

	private static Delegate GetSizeHandler()
	{
		return new _JniMarshal_PP_J(n_Size);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_Size(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<FileChannel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public abstract long Size();

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

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Looper", DoNotGenerateAcw = true)]
public class Looper : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Looper", typeof(Looper));

	private static Delegate? cb_isCurrentThread_IsCurrentThread_Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual bool IsCurrentThread
	{
		[Register("isCurrentThread", "()Z", "GetIsCurrentThreadHandler", ApiSince = 23)]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCurrentThread.()Z", this, null);
		}
	}

	public unsafe static Looper? MainLooper
	{
		[Register("getMainLooper", "()Landroid/os/Looper;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Looper>(_members.StaticMethods.InvokeObjectMethod("getMainLooper.()Landroid/os/Looper;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Looper(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetIsCurrentThreadHandler()
	{
		return new _JniMarshal_PP_B(n_IsCurrentThread);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCurrentThread(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Looper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCurrentThread ? ((sbyte)1) : ((sbyte)0);
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

	[Register("myLooper", "()Landroid/os/Looper;", "")]
	public unsafe static Looper? MyLooper()
	{
		return Java.Lang.Object.GetObject<Looper>(_members.StaticMethods.InvokeObjectMethod("myLooper.()Landroid/os/Looper;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}

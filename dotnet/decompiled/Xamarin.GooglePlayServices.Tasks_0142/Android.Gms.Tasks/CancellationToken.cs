using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/CancellationToken", DoNotGenerateAcw = true)]
public abstract class CancellationToken : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/CancellationToken", typeof(CancellationToken));

	private static Delegate? cb_isCancellationRequested_IsCancellationRequested_Z;

	private static Delegate? cb_onCanceledRequested_OnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener__Lcom_google_android_gms_tasks_CancellationToken_;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract bool IsCancellationRequested
	{
		[Register("isCancellationRequested", "()Z", "GetIsCancellationRequestedHandler")]
		get;
	}

	protected CancellationToken(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe CancellationToken()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetIsCancellationRequestedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCancellationRequested);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCancellationRequested(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CancellationToken>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCancellationRequested ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetOnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_OnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CancellationToken? cancellationToken = Java.Lang.Object.GetObject<CancellationToken>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTokenCanceledListener p = Java.Lang.Object.GetObject<IOnTokenCanceledListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cancellationToken.OnCanceledRequested(p));
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

	[Register("onCanceledRequested", "(Lcom/google/android/gms/tasks/OnTokenCanceledListener;)Lcom/google/android/gms/tasks/CancellationToken;", "GetOnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_Handler")]
	public abstract CancellationToken OnCanceledRequested(IOnTokenCanceledListener p0);
}

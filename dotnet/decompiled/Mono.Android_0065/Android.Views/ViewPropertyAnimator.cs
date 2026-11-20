using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewPropertyAnimator", DoNotGenerateAcw = true)]
public class ViewPropertyAnimator : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewPropertyAnimator", typeof(ViewPropertyAnimator));

	private static Delegate? cb_alpha_Alpha_F_Landroid_view_ViewPropertyAnimator_;

	private static Delegate? cb_cancel_Cancel_V;

	private static Delegate? cb_rotation_Rotation_F_Landroid_view_ViewPropertyAnimator_;

	private static Delegate? cb_setDuration_SetDuration_J_Landroid_view_ViewPropertyAnimator_;

	private static Delegate? cb_start_Start_V;

	private static Delegate? cb_withEndAction_WithEndAction_Ljava_lang_Runnable__Landroid_view_ViewPropertyAnimator_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ViewPropertyAnimator(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetAlpha_FHandler()
	{
		return new _JniMarshal_PPF_L(n_Alpha_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Alpha_F(nint jnienv, nint native__this, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewPropertyAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Alpha(value));
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

	public unsafe virtual ViewPropertyAnimator Alpha(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("alpha.(F)Landroid/view/ViewPropertyAnimator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCancelHandler()
	{
		return new _JniMarshal_PP_V(n_Cancel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Cancel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPropertyAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual void Cancel()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("cancel.()V", this, null);
	}

	private static Delegate GetRotation_FHandler()
	{
		return new _JniMarshal_PPF_L(n_Rotation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Rotation_F(nint jnienv, nint native__this, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewPropertyAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rotation(value));
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

	public unsafe virtual ViewPropertyAnimator Rotation(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<ViewPropertyAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("rotation.(F)Landroid/view/ViewPropertyAnimator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetDuration_JHandler()
	{
		return new _JniMarshal_PPJ_L(n_SetDuration_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDuration_J(nint jnienv, nint native__this, long duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewPropertyAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDuration(duration));
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

	public unsafe virtual ViewPropertyAnimator SetDuration(long duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(duration);
		return Java.Lang.Object.GetObject<ViewPropertyAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDuration.(J)Landroid/view/ViewPropertyAnimator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetStartHandler()
	{
		return new _JniMarshal_PP_V(n_Start);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Start(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPropertyAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual void Start()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("start.()V", this, null);
	}

	private static Delegate GetWithEndAction_Ljava_lang_Runnable_Handler()
	{
		return new _JniMarshal_PPL_L(n_WithEndAction_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_WithEndAction_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_runnable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewPropertyAnimator? viewPropertyAnimator = Java.Lang.Object.GetObject<ViewPropertyAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable runnable = Java.Lang.Object.GetObject<IRunnable>(native_runnable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(viewPropertyAnimator.WithEndAction(runnable));
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

	public unsafe virtual ViewPropertyAnimator WithEndAction(IRunnable? runnable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			return Java.Lang.Object.GetObject<ViewPropertyAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("withEndAction.(Ljava/lang/Runnable;)Landroid/view/ViewPropertyAnimator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(runnable);
		}
	}
}

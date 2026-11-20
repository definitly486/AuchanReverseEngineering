using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Animation;

[Register("android/animation/Animator", DoNotGenerateAcw = true)]
public abstract class Animator : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/animation/Animator$AnimatorListener", "", "Android.Animation.Animator/IAnimatorListenerInvoker")]
	public interface IAnimatorListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onAnimationCancel", "(Landroid/animation/Animator;)V", "GetOnAnimationCancel_Landroid_animation_Animator_Handler:Android.Animation.Animator/IAnimatorListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnAnimationCancel(Animator animation);

		[Register("onAnimationEnd", "(Landroid/animation/Animator;)V", "GetOnAnimationEnd_Landroid_animation_Animator_Handler:Android.Animation.Animator/IAnimatorListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnAnimationEnd(Animator animation);

		[Register("onAnimationRepeat", "(Landroid/animation/Animator;)V", "GetOnAnimationRepeat_Landroid_animation_Animator_Handler:Android.Animation.Animator/IAnimatorListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnAnimationRepeat(Animator animation);

		[Register("onAnimationStart", "(Landroid/animation/Animator;)V", "GetOnAnimationStart_Landroid_animation_Animator_Handler:Android.Animation.Animator/IAnimatorListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnAnimationStart(Animator animation);
	}

	[Register("android/animation/Animator$AnimatorListener", DoNotGenerateAcw = true)]
	internal class IAnimatorListenerInvoker : Java.Lang.Object, IAnimatorListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_animation_Animator_AnimatorListener = new XAPeerMembers("android/animation/Animator$AnimatorListener", typeof(IAnimatorListenerInvoker));

		private static Delegate? cb_onAnimationCancel_OnAnimationCancel_Landroid_animation_Animator__V;

		private static Delegate? cb_onAnimationEnd_OnAnimationEnd_Landroid_animation_Animator__V;

		private static Delegate? cb_onAnimationRepeat_OnAnimationRepeat_Landroid_animation_Animator__V;

		private static Delegate? cb_onAnimationStart_OnAnimationStart_Landroid_animation_Animator__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_animation_Animator_AnimatorListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_animation_Animator_AnimatorListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_animation_Animator_AnimatorListener.ManagedPeerType;

		public IAnimatorListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAnimationCancel_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IAnimatorListener? animatorListener = Java.Lang.Object.GetObject<IAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
				animatorListener.OnAnimationCancel(animation);
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

		public unsafe void OnAnimationCancel(Animator animation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				_members_android_animation_Animator_AnimatorListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationCancel.(Landroid/animation/Animator;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(animation);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAnimationEnd_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IAnimatorListener? animatorListener = Java.Lang.Object.GetObject<IAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
				animatorListener.OnAnimationEnd(animation);
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

		public unsafe void OnAnimationEnd(Animator animation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				_members_android_animation_Animator_AnimatorListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationEnd.(Landroid/animation/Animator;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(animation);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAnimationRepeat_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IAnimatorListener? animatorListener = Java.Lang.Object.GetObject<IAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
				animatorListener.OnAnimationRepeat(animation);
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

		public unsafe void OnAnimationRepeat(Animator animation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				_members_android_animation_Animator_AnimatorListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationRepeat.(Landroid/animation/Animator;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(animation);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAnimationStart_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IAnimatorListener? animatorListener = Java.Lang.Object.GetObject<IAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
				animatorListener.OnAnimationStart(animation);
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

		public unsafe void OnAnimationStart(Animator animation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				_members_android_animation_Animator_AnimatorListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationStart.(Landroid/animation/Animator;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(animation);
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

		[UnmanagedCallersOnly]
		private static void n_OnAnimationCancel_Landroid_animation_Animator__mm_wrapper(nint jnienv, nint native__this, nint native_animation)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAnimationCancel_Landroid_animation_Animator_(jnienv, native__this, native_animation);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnAnimationEnd_Landroid_animation_Animator__mm_wrapper(nint jnienv, nint native__this, nint native_animation)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAnimationEnd_Landroid_animation_Animator_(jnienv, native__this, native_animation);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnAnimationRepeat_Landroid_animation_Animator__mm_wrapper(nint jnienv, nint native__this, nint native_animation)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAnimationRepeat_Landroid_animation_Animator_(jnienv, native__this, native_animation);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnAnimationStart_Landroid_animation_Animator__mm_wrapper(nint jnienv, nint native__this, nint native_animation)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAnimationStart_Landroid_animation_Animator_(jnienv, native__this, native_animation);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	private WeakReference? dispatcher;

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/animation/Animator", typeof(Animator));

	private static Delegate? cb_setStartDelay_SetStartDelay_J_V;

	private static Delegate? cb_addListener_AddListener_Landroid_animation_Animator_AnimatorListener__V;

	private static Delegate? cb_cancel_Cancel_V;

	private static Delegate? cb_setDuration_SetDuration_J_Landroid_animation_Animator_;

	private static Delegate? cb_setInterpolator_SetInterpolator_Landroid_animation_TimeInterpolator__V;

	private static Delegate? cb_start_Start_V;

	private AnimatorEventDispatcher Dispatcher
	{
		get
		{
			if (dispatcher == null || !dispatcher.IsAlive)
			{
				dispatcher = new WeakReference(new AnimatorEventDispatcher());
				AddListener((AnimatorEventDispatcher)dispatcher.Target);
			}
			return (AnimatorEventDispatcher)dispatcher.Target;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract long StartDelay { set; }

	public event EventHandler AnimationEnd
	{
		add
		{
			AnimatorEventDispatcher animatorEventDispatcher = Dispatcher;
			animatorEventDispatcher.AnimationEnd = (EventHandler)Delegate.Combine(animatorEventDispatcher.AnimationEnd, value);
		}
		remove
		{
			AnimatorEventDispatcher animatorEventDispatcher = Dispatcher;
			animatorEventDispatcher.AnimationEnd = (EventHandler)Delegate.Remove(animatorEventDispatcher.AnimationEnd, value);
		}
	}

	protected Animator(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetSetStartDelay_JHandler()
	{
		return new _JniMarshal_PPJ_V(n_SetStartDelay_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStartDelay_J(nint jnienv, nint native__this, long startDelay)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Animator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartDelay = startDelay;
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

	private static Delegate GetAddListener_Landroid_animation_Animator_AnimatorListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddListener_Landroid_animation_Animator_AnimatorListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddListener_Landroid_animation_Animator_AnimatorListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Animator? animator = Java.Lang.Object.GetObject<Animator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IAnimatorListener listener = Java.Lang.Object.GetObject<IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			animator.AddListener(listener);
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

	public unsafe virtual void AddListener(IAnimatorListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
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
			Java.Lang.Object.GetObject<Animator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Animator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDuration(duration));
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

	public abstract Animator? SetDuration(long duration);

	private static Delegate GetSetInterpolator_Landroid_animation_TimeInterpolator_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetInterpolator_Landroid_animation_TimeInterpolator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInterpolator_Landroid_animation_TimeInterpolator_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Animator? animator = Java.Lang.Object.GetObject<Animator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITimeInterpolator interpolator = Java.Lang.Object.GetObject<ITimeInterpolator>(native_value, JniHandleOwnership.DoNotTransfer);
			animator.SetInterpolator(interpolator);
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

	public abstract void SetInterpolator(ITimeInterpolator? value);

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
			Java.Lang.Object.GetObject<Animator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start();
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

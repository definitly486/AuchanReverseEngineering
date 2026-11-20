using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Animation;

[Register("android/animation/ValueAnimator", DoNotGenerateAcw = true)]
public class ValueAnimator : Animator
{
	[Register("android/animation/ValueAnimator$AnimatorUpdateListener", "", "Android.Animation.ValueAnimator/IAnimatorUpdateListenerInvoker")]
	public interface IAnimatorUpdateListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onAnimationUpdate", "(Landroid/animation/ValueAnimator;)V", "GetOnAnimationUpdate_Landroid_animation_ValueAnimator_Handler:Android.Animation.ValueAnimator/IAnimatorUpdateListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnAnimationUpdate(ValueAnimator animation);
	}

	[Register("android/animation/ValueAnimator$AnimatorUpdateListener", DoNotGenerateAcw = true)]
	internal class IAnimatorUpdateListenerInvoker : Java.Lang.Object, IAnimatorUpdateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_animation_ValueAnimator_AnimatorUpdateListener = new XAPeerMembers("android/animation/ValueAnimator$AnimatorUpdateListener", typeof(IAnimatorUpdateListenerInvoker));

		private static Delegate? cb_onAnimationUpdate_OnAnimationUpdate_Landroid_animation_ValueAnimator__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_animation_ValueAnimator_AnimatorUpdateListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_animation_ValueAnimator_AnimatorUpdateListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_animation_ValueAnimator_AnimatorUpdateListener.ManagedPeerType;

		public IAnimatorUpdateListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAnimationUpdate_Landroid_animation_ValueAnimator_(nint jnienv, nint native__this, nint native_animation)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IAnimatorUpdateListener? animatorUpdateListener = Java.Lang.Object.GetObject<IAnimatorUpdateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ValueAnimator animation = Java.Lang.Object.GetObject<ValueAnimator>(native_animation, JniHandleOwnership.DoNotTransfer);
				animatorUpdateListener.OnAnimationUpdate(animation);
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

		public unsafe void OnAnimationUpdate(ValueAnimator animation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				_members_android_animation_ValueAnimator_AnimatorUpdateListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationUpdate.(Landroid/animation/ValueAnimator;)V", this, ptr);
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
		private static void n_OnAnimationUpdate_Landroid_animation_ValueAnimator__mm_wrapper(nint jnienv, nint native__this, nint native_animation)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAnimationUpdate_Landroid_animation_ValueAnimator_(jnienv, native__this, native_animation);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class AnimatorUpdateEventArgs : EventArgs
	{
		private ValueAnimator animation;

		public ValueAnimator Animation => animation;

		public AnimatorUpdateEventArgs(ValueAnimator animation)
		{
			this.animation = animation;
		}
	}

	[Register("mono/android/animation/ValueAnimator_AnimatorUpdateListenerImplementor")]
	internal sealed class IAnimatorUpdateListenerImplementor : Java.Lang.Object, IAnimatorUpdateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<AnimatorUpdateEventArgs>? Handler;

		public unsafe IAnimatorUpdateListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnAnimationUpdate(ValueAnimator animation)
		{
			Handler?.Invoke(sender, new AnimatorUpdateEventArgs(animation));
		}

		internal static bool __IsEmpty(IAnimatorUpdateListenerImplementor value)
		{
			return value.Handler == null;
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

	private static Delegate cb_setDuration_SetDuration_J_Landroid_animation_Animator_;

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/animation/ValueAnimator", typeof(ValueAnimator));

	private static Delegate? cb_getAnimatedFraction_GetAnimatedFraction_F;

	private static Delegate? cb_getAnimatedValue_GetAnimatedValue_Ljava_lang_Object_;

	private static Delegate? cb_setRepeatCount_SetRepeatCount_I_V;

	private static Delegate? cb_setRepeatMode_SetRepeatMode_I_V;

	private static Delegate? cb_setStartDelay_SetStartDelay_J_V;

	private static Delegate? cb_addUpdateListener_AddUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener__V;

	private static Delegate? cb_removeUpdateListener_RemoveUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener__V;

	private static Delegate? cb_setFloatValues_SetFloatValues_arrayF_V;

	private static Delegate? cb_setInterpolator_SetInterpolator_Landroid_animation_TimeInterpolator__V;

	private WeakReference? weak_implementor_AddUpdateListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual float AnimatedFraction => _members.InstanceMethods.InvokeVirtualSingleMethod("getAnimatedFraction.()F", this, null);

	public unsafe virtual Java.Lang.Object? AnimatedValue => Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnimatedValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe virtual int RepeatCount
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRepeatCount.(I)V", this, ptr);
		}
	}

	public unsafe virtual ValueAnimatorRepeatMode RepeatMode
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRepeatMode.(I)V", this, ptr);
		}
	}

	public unsafe override long StartDelay
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStartDelay.(J)V", this, ptr);
		}
	}

	public event EventHandler<AnimatorUpdateEventArgs> Update
	{
		add
		{
			EventHelper.AddEventHandler<IAnimatorUpdateListener, IAnimatorUpdateListenerImplementor>(ref weak_implementor_AddUpdateListener, __CreateIAnimatorUpdateListenerImplementor, AddUpdateListener, delegate(IAnimatorUpdateListenerImplementor __h)
			{
				__h.Handler = (EventHandler<AnimatorUpdateEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddUpdateListener, IAnimatorUpdateListenerImplementor.__IsEmpty, delegate(IAnimatorUpdateListener __v)
			{
				RemoveUpdateListener(__v);
			}, delegate(IAnimatorUpdateListenerImplementor __h)
			{
				__h.Handler = (EventHandler<AnimatorUpdateEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public unsafe override Animator SetDuration(long duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(duration);
		return Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDuration.(J)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDuration(duration));
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

	protected ValueAnimator(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe ValueAnimator()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetAnimatedFractionHandler()
	{
		return new _JniMarshal_PP_F(n_GetAnimatedFraction);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetAnimatedFraction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimatedFraction;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetAnimatedValueHandler()
	{
		return new _JniMarshal_PP_L(n_GetAnimatedValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnimatedValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimatedValue);
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

	private static Delegate GetSetRepeatCount_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetRepeatCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRepeatCount_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatCount = value;
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

	private static Delegate GetSetRepeatMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetRepeatMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRepeatMode_I(nint jnienv, nint native__this, int native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatMode = (ValueAnimatorRepeatMode)native_value;
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
			Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartDelay = startDelay;
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

	private static Delegate GetAddUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ValueAnimator? valueAnimator = Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IAnimatorUpdateListener listener = Java.Lang.Object.GetObject<IAnimatorUpdateListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			valueAnimator.AddUpdateListener(listener);
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

	public unsafe virtual void AddUpdateListener(IAnimatorUpdateListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addUpdateListener.(Landroid/animation/ValueAnimator$AnimatorUpdateListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	public unsafe static ValueAnimator? OfArgb(params int[]? values)
	{
		nint num = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ValueAnimator>(_members.StaticMethods.InvokeObjectMethod("ofArgb.([I)Landroid/animation/ValueAnimator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (values != null)
			{
				JNIEnv.CopyArray(num, values);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(values);
		}
	}

	public unsafe static ValueAnimator? OfFloat(params float[]? values)
	{
		nint num = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ValueAnimator>(_members.StaticMethods.InvokeObjectMethod("ofFloat.([F)Landroid/animation/ValueAnimator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (values != null)
			{
				JNIEnv.CopyArray(num, values);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(values);
		}
	}

	public unsafe static ValueAnimator? OfInt(params int[]? values)
	{
		nint num = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ValueAnimator>(_members.StaticMethods.InvokeObjectMethod("ofInt.([I)Landroid/animation/ValueAnimator;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (values != null)
			{
				JNIEnv.CopyArray(num, values);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetRemoveUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveUpdateListener_Landroid_animation_ValueAnimator_AnimatorUpdateListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ValueAnimator? valueAnimator = Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IAnimatorUpdateListener listener = Java.Lang.Object.GetObject<IAnimatorUpdateListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			valueAnimator.RemoveUpdateListener(listener);
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

	public unsafe virtual void RemoveUpdateListener(IAnimatorUpdateListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeUpdateListener.(Landroid/animation/ValueAnimator$AnimatorUpdateListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetFloatValues_arrayFHandler()
	{
		return new _JniMarshal_PPL_V(n_SetFloatValues_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFloatValues_arrayF(nint jnienv, nint native__this, nint native_values)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ValueAnimator? valueAnimator = Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_values, JniHandleOwnership.DoNotTransfer, typeof(float));
			valueAnimator.SetFloatValues(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_values);
			}
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

	public unsafe virtual void SetFloatValues(params float[]? values)
	{
		nint num = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFloatValues.([F)V", this, ptr);
		}
		finally
		{
			if (values != null)
			{
				JNIEnv.CopyArray(num, values);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(values);
		}
	}

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
			ValueAnimator? valueAnimator = Java.Lang.Object.GetObject<ValueAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITimeInterpolator interpolator = Java.Lang.Object.GetObject<ITimeInterpolator>(native_value, JniHandleOwnership.DoNotTransfer);
			valueAnimator.SetInterpolator(interpolator);
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

	public unsafe override void SetInterpolator(ITimeInterpolator? value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolator.(Landroid/animation/TimeInterpolator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	private IAnimatorUpdateListenerImplementor __CreateIAnimatorUpdateListenerImplementor()
	{
		return new IAnimatorUpdateListenerImplementor(this);
	}
}

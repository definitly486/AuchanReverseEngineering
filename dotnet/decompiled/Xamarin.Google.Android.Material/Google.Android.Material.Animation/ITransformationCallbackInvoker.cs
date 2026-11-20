using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Animation;

[Register("com/google/android/material/animation/TransformationCallback", DoNotGenerateAcw = true)]
internal class ITransformationCallbackInvoker : Java.Lang.Object, ITransformationCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_google_android_material_animation_TransformationCallback = new XAPeerMembers("com/google/android/material/animation/TransformationCallback", typeof(ITransformationCallbackInvoker));

	private static Delegate? cb_onScaleChanged_OnScaleChanged_Landroid_view_View__V;

	private static Delegate? cb_onTranslationChanged_OnTranslationChanged_Landroid_view_View__V;

	private static nint java_class_ref => _members_com_google_android_material_animation_TransformationCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_animation_TransformationCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_google_android_material_animation_TransformationCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_google_android_material_animation_TransformationCallback.ManagedPeerType;

	public ITransformationCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnScaleChanged_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnScaleChanged_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnScaleChanged_Landroid_view_View_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ITransformationCallback? transformationCallback = Java.Lang.Object.GetObject<ITransformationCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			transformationCallback.OnScaleChanged(p);
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

	public unsafe void OnScaleChanged(Java.Lang.Object? p0)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_google_android_material_animation_TransformationCallback.InstanceMethods.InvokeAbstractVoidMethod("onScaleChanged.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnTranslationChanged_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnTranslationChanged_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTranslationChanged_Landroid_view_View_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ITransformationCallback? transformationCallback = Java.Lang.Object.GetObject<ITransformationCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			transformationCallback.OnTranslationChanged(p);
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

	public unsafe void OnTranslationChanged(Java.Lang.Object? p0)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_google_android_material_animation_TransformationCallback.InstanceMethods.InvokeAbstractVoidMethod("onTranslationChanged.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
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

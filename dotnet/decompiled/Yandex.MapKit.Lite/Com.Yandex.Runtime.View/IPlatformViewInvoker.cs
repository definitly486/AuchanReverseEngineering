using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.View;

[Register("com/yandex/runtime/view/PlatformView", DoNotGenerateAcw = true)]
internal class IPlatformViewInvoker : Java.Lang.Object, IPlatformView, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_runtime_view_PlatformView = new XAPeerMembers("com/yandex/runtime/view/PlatformView", typeof(IPlatformViewInvoker));

	private static Delegate? cb_isDebugModeEnabled_IsDebugModeEnabled_Z;

	private static Delegate? cb_getNativePlatformView_GetNativePlatformView_Lcom_yandex_runtime_NativeObject_;

	private static Delegate? cb_getView_GetView_Landroid_view_View_;

	private static Delegate? cb_destroyNativePlatformView_DestroyNativePlatformView_V;

	private static Delegate? cb_onMemoryWarning_OnMemoryWarning_V;

	private static Delegate? cb_pause_Pause_V;

	private static Delegate? cb_resume_Resume_V;

	private static Delegate? cb_setNoninteractive_SetNoninteractive_Z_V;

	private static Delegate? cb_start_Start_V;

	private static Delegate? cb_stop_Stop_V;

	private static nint java_class_ref => _members_com_yandex_runtime_view_PlatformView.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_runtime_view_PlatformView;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_runtime_view_PlatformView.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_runtime_view_PlatformView.ManagedPeerType;

	public unsafe bool IsDebugModeEnabled => _members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractBooleanMethod("isDebugModeEnabled.()Z", this, null);

	public unsafe NativeObject? NativePlatformView => Java.Lang.Object.GetObject<NativeObject>(_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractObjectMethod("getNativePlatformView.()Lcom/yandex/runtime/NativeObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Android.Views.View? View => Java.Lang.Object.GetObject<Android.Views.View>(_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractObjectMethod("getView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IPlatformViewInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsDebugModeEnabledHandler()
	{
		if ((object)cb_isDebugModeEnabled_IsDebugModeEnabled_Z == null)
		{
			cb_isDebugModeEnabled_IsDebugModeEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDebugModeEnabled));
		}
		return cb_isDebugModeEnabled_IsDebugModeEnabled_Z;
	}

	private static bool n_IsDebugModeEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDebugModeEnabled;
	}

	private static Delegate GetGetNativePlatformViewHandler()
	{
		if ((object)cb_getNativePlatformView_GetNativePlatformView_Lcom_yandex_runtime_NativeObject_ == null)
		{
			cb_getNativePlatformView_GetNativePlatformView_Lcom_yandex_runtime_NativeObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNativePlatformView));
		}
		return cb_getNativePlatformView_GetNativePlatformView_Lcom_yandex_runtime_NativeObject_;
	}

	private static nint n_GetNativePlatformView(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NativePlatformView);
	}

	private static Delegate GetGetViewHandler()
	{
		if ((object)cb_getView_GetView_Landroid_view_View_ == null)
		{
			cb_getView_GetView_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetView));
		}
		return cb_getView_GetView_Landroid_view_View_;
	}

	private static nint n_GetView(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).View);
	}

	private static Delegate GetDestroyNativePlatformViewHandler()
	{
		if ((object)cb_destroyNativePlatformView_DestroyNativePlatformView_V == null)
		{
			cb_destroyNativePlatformView_DestroyNativePlatformView_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DestroyNativePlatformView));
		}
		return cb_destroyNativePlatformView_DestroyNativePlatformView_V;
	}

	private static void n_DestroyNativePlatformView(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DestroyNativePlatformView();
	}

	public unsafe void DestroyNativePlatformView()
	{
		_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractVoidMethod("destroyNativePlatformView.()V", this, null);
	}

	private static Delegate GetOnMemoryWarningHandler()
	{
		if ((object)cb_onMemoryWarning_OnMemoryWarning_V == null)
		{
			cb_onMemoryWarning_OnMemoryWarning_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnMemoryWarning));
		}
		return cb_onMemoryWarning_OnMemoryWarning_V;
	}

	private static void n_OnMemoryWarning(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMemoryWarning();
	}

	public unsafe void OnMemoryWarning()
	{
		_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractVoidMethod("onMemoryWarning.()V", this, null);
	}

	private static Delegate GetPauseHandler()
	{
		if ((object)cb_pause_Pause_V == null)
		{
			cb_pause_Pause_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Pause));
		}
		return cb_pause_Pause_V;
	}

	private static void n_Pause(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Pause();
	}

	public unsafe void Pause()
	{
		_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractVoidMethod("pause.()V", this, null);
	}

	private static Delegate GetResumeHandler()
	{
		if ((object)cb_resume_Resume_V == null)
		{
			cb_resume_Resume_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Resume));
		}
		return cb_resume_Resume_V;
	}

	private static void n_Resume(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resume();
	}

	public unsafe void Resume()
	{
		_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractVoidMethod("resume.()V", this, null);
	}

	private static Delegate GetSetNoninteractive_ZHandler()
	{
		if ((object)cb_setNoninteractive_SetNoninteractive_Z_V == null)
		{
			cb_setNoninteractive_SetNoninteractive_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetNoninteractive_Z));
		}
		return cb_setNoninteractive_SetNoninteractive_Z_V;
	}

	private static void n_SetNoninteractive_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNoninteractive(p0);
	}

	public unsafe void SetNoninteractive(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractVoidMethod("setNoninteractive.(Z)V", this, ptr);
	}

	private static Delegate GetStartHandler()
	{
		if ((object)cb_start_Start_V == null)
		{
			cb_start_Start_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Start));
		}
		return cb_start_Start_V;
	}

	private static void n_Start(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Start();
	}

	public unsafe void Start()
	{
		_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractVoidMethod("start.()V", this, null);
	}

	private static Delegate GetStopHandler()
	{
		if ((object)cb_stop_Stop_V == null)
		{
			cb_stop_Stop_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Stop));
		}
		return cb_stop_Stop_V;
	}

	private static void n_Stop(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlatformView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Stop();
	}

	public unsafe void Stop()
	{
		_members_com_yandex_runtime_view_PlatformView.InstanceMethods.InvokeAbstractVoidMethod("stop.()V", this, null);
	}
}

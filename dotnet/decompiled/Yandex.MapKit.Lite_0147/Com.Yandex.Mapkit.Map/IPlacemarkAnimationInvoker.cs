using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkAnimation", DoNotGenerateAcw = true)]
internal class IPlacemarkAnimationInvoker : Java.Lang.Object, IPlacemarkAnimation, IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkAnimation = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkAnimation", typeof(IPlacemarkAnimationInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkPresentation = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkPresentation", typeof(IPlacemarkAnimationInvoker));

	private static Delegate? cb_isReversed_IsReversed_Z;

	private static Delegate? cb_setReversed_SetReversed_Z_V;

	private static Delegate? cb_pause_Pause_V;

	private static Delegate? cb_play_Play_V;

	private static Delegate? cb_play_Play_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_resume_Resume_V;

	private static Delegate? cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_stop_Stop_V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_remove_Remove_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_PlacemarkAnimation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_PlacemarkAnimation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_PlacemarkAnimation.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_PlacemarkAnimation.ManagedPeerType;

	public unsafe bool Reversed
	{
		get
		{
			return _members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractBooleanMethod("isReversed.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("setReversed.(Z)V", this, ptr);
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IPlacemarkAnimationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsReversedHandler()
	{
		if ((object)cb_isReversed_IsReversed_Z == null)
		{
			cb_isReversed_IsReversed_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsReversed));
		}
		return cb_isReversed_IsReversed_Z;
	}

	private static bool n_IsReversed(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reversed;
	}

	private static Delegate GetSetReversed_ZHandler()
	{
		if ((object)cb_setReversed_SetReversed_Z_V == null)
		{
			cb_setReversed_SetReversed_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetReversed_Z));
		}
		return cb_setReversed_SetReversed_Z_V;
	}

	private static void n_SetReversed_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reversed = p0;
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
		Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Pause();
	}

	public unsafe void Pause()
	{
		_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("pause.()V", this, null);
	}

	private static Delegate GetPlayHandler()
	{
		if ((object)cb_play_Play_V == null)
		{
			cb_play_Play_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Play));
		}
		return cb_play_Play_V;
	}

	private static void n_Play(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Play();
	}

	public unsafe void Play()
	{
		_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("play.()V", this, null);
	}

	private static Delegate GetPlay_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_play_Play_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_play_Play_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Play_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_play_Play_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_Play_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkAnimation? placemarkAnimation = Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICallback p = Java.Lang.Object.GetObject<ICallback>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkAnimation.Play(p);
	}

	public unsafe void Play(ICallback p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("play.(Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
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
		Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resume();
	}

	public unsafe void Resume()
	{
		_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("resume.()V", this, null);
	}

	private static Delegate GetSetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPlacemarkAnimation? placemarkAnimation = Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		AnimatedImageProvider p = Java.Lang.Object.GetObject<AnimatedImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		placemarkAnimation.SetIcon(p, p2);
	}

	public unsafe void SetIcon(AnimatedImageProvider p0, IconStyle p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setIcon_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetIcon_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IPlacemarkAnimation? placemarkAnimation = Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		AnimatedImageProvider p = Java.Lang.Object.GetObject<AnimatedImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p3 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		placemarkAnimation.SetIcon(p, p2, p3);
	}

	public unsafe void SetIcon(AnimatedImageProvider p0, IconStyle p1, ICallback p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetSetIconStyle_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkAnimation? placemarkAnimation = Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IconStyle iconStyle = Java.Lang.Object.GetObject<IconStyle>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkAnimation.SetIconStyle(iconStyle);
	}

	public unsafe void SetIconStyle(IconStyle p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("setIconStyle.(Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
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
		Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Stop();
	}

	public unsafe void Stop()
	{
		_members_com_yandex_mapkit_map_PlacemarkAnimation.InstanceMethods.InvokeAbstractVoidMethod("stop.()V", this, null);
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetRemoveHandler()
	{
		if ((object)cb_remove_Remove_V == null)
		{
			cb_remove_Remove_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Remove));
		}
		return cb_remove_Remove_V;
	}

	private static void n_Remove(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IPlacemarkAnimation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}
}

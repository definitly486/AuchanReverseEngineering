using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationSimulator", DoNotGenerateAcw = true)]
internal class ILocationSimulatorInvoker : Java.Lang.Object, ILocationSimulator, ILocationManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_location_LocationManager = new XAPeerMembers("com/yandex/mapkit/location/LocationManager", typeof(ILocationSimulatorInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_location_LocationSimulator = new XAPeerMembers("com/yandex/mapkit/location/LocationSimulator", typeof(ILocationSimulatorInvoker));

	private static Delegate? cb_isActive_IsActive_Z;

	private static Delegate? cb_getSettings_GetSettings_Ljava_util_List_;

	private static Delegate? cb_setSettings_SetSettings_Ljava_util_List__V;

	private static Delegate? cb_getSpeed_GetSpeed_D;

	private static Delegate? cb_setSpeed_SetSpeed_D_V;

	private static Delegate? cb_polylinePosition_PolylinePosition_Lcom_yandex_mapkit_geometry_PolylinePosition_;

	private static Delegate? cb_startSimulation_StartSimulation_Ljava_util_List__V;

	private static Delegate? cb_stopSimulation_StopSimulation_V;

	private static Delegate? cb_subscribeForSimulatorEvents_SubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V;

	private static Delegate? cb_unsubscribeFromSimulatorEvents_UnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V;

	private static Delegate? cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V;

	private static Delegate? cb_resume_Resume_V;

	private static Delegate? cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V;

	private static Delegate? cb_suspend_Suspend_V;

	private static Delegate? cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_location_LocationSimulator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_location_LocationSimulator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_location_LocationSimulator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_location_LocationSimulator.ManagedPeerType;

	public unsafe bool IsActive => _members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractBooleanMethod("isActive.()Z", this, null);

	public unsafe IList<SimulationSettings> Settings
	{
		get
		{
			return JavaList<SimulationSettings>.FromJniHandle(_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractObjectMethod("getSettings.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaList<SimulationSettings>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractVoidMethod("setSettings.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe double Speed
	{
		get
		{
			return _members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractDoubleMethod("getSpeed.()D", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractVoidMethod("setSpeed.(D)V", this, ptr);
		}
	}

	public ILocationSimulatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsActiveHandler()
	{
		if ((object)cb_isActive_IsActive_Z == null)
		{
			cb_isActive_IsActive_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsActive));
		}
		return cb_isActive_IsActive_Z;
	}

	private static bool n_IsActive(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsActive;
	}

	private static Delegate GetGetSettingsHandler()
	{
		if ((object)cb_getSettings_GetSettings_Ljava_util_List_ == null)
		{
			cb_getSettings_GetSettings_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSettings));
		}
		return cb_getSettings_GetSettings_Ljava_util_List_;
	}

	private static nint n_GetSettings(nint jnienv, nint native__this)
	{
		return JavaList<SimulationSettings>.ToLocalJniHandle(Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Settings);
	}

	private static Delegate GetSetSettings_Ljava_util_List_Handler()
	{
		if ((object)cb_setSettings_SetSettings_Ljava_util_List__V == null)
		{
			cb_setSettings_SetSettings_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSettings_Ljava_util_List_));
		}
		return cb_setSettings_SetSettings_Ljava_util_List__V;
	}

	private static void n_SetSettings_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationSimulator? locationSimulator = Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<SimulationSettings> settings = JavaList<SimulationSettings>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		locationSimulator.Settings = settings;
	}

	[Obsolete]
	private static Delegate GetGetSpeedHandler()
	{
		if ((object)cb_getSpeed_GetSpeed_D == null)
		{
			cb_getSpeed_GetSpeed_D = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_D(n_GetSpeed));
		}
		return cb_getSpeed_GetSpeed_D;
	}

	[Obsolete]
	private static double n_GetSpeed(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Speed;
	}

	[Obsolete]
	private static Delegate GetSetSpeed_DHandler()
	{
		if ((object)cb_setSpeed_SetSpeed_D_V == null)
		{
			cb_setSpeed_SetSpeed_D_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPD_V(n_SetSpeed_D));
		}
		return cb_setSpeed_SetSpeed_D_V;
	}

	[Obsolete]
	private static void n_SetSpeed_D(nint jnienv, nint native__this, double p0)
	{
		Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Speed = p0;
	}

	private static Delegate GetPolylinePositionHandler()
	{
		if ((object)cb_polylinePosition_PolylinePosition_Lcom_yandex_mapkit_geometry_PolylinePosition_ == null)
		{
			cb_polylinePosition_PolylinePosition_Lcom_yandex_mapkit_geometry_PolylinePosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_PolylinePosition));
		}
		return cb_polylinePosition_PolylinePosition_Lcom_yandex_mapkit_geometry_PolylinePosition_;
	}

	private static nint n_PolylinePosition(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PolylinePosition());
	}

	public unsafe PolylinePosition PolylinePosition()
	{
		return Java.Lang.Object.GetObject<PolylinePosition>(_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractObjectMethod("polylinePosition.()Lcom/yandex/mapkit/geometry/PolylinePosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetStartSimulation_Ljava_util_List_Handler()
	{
		if ((object)cb_startSimulation_StartSimulation_Ljava_util_List__V == null)
		{
			cb_startSimulation_StartSimulation_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_StartSimulation_Ljava_util_List_));
		}
		return cb_startSimulation_StartSimulation_Ljava_util_List__V;
	}

	private static void n_StartSimulation_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationSimulator? locationSimulator = Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<SimulationSettings> p = JavaList<SimulationSettings>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		locationSimulator.StartSimulation(p);
	}

	public unsafe void StartSimulation(IList<SimulationSettings> p0)
	{
		nint num = JavaList<SimulationSettings>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractVoidMethod("startSimulation.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetStopSimulationHandler()
	{
		if ((object)cb_stopSimulation_StopSimulation_V == null)
		{
			cb_stopSimulation_StopSimulation_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StopSimulation));
		}
		return cb_stopSimulation_StopSimulation_V;
	}

	private static void n_StopSimulation(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopSimulation();
	}

	public unsafe void StopSimulation()
	{
		_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractVoidMethod("stopSimulation.()V", this, null);
	}

	private static Delegate GetSubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_Handler()
	{
		if ((object)cb_subscribeForSimulatorEvents_SubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V == null)
		{
			cb_subscribeForSimulatorEvents_SubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_));
		}
		return cb_subscribeForSimulatorEvents_SubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V;
	}

	private static void n_SubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationSimulator? locationSimulator = Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationSimulatorListener p = Java.Lang.Object.GetObject<ILocationSimulatorListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationSimulator.SubscribeForSimulatorEvents(p);
	}

	public unsafe void SubscribeForSimulatorEvents(ILocationSimulatorListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractVoidMethod("subscribeForSimulatorEvents.(Lcom/yandex/mapkit/location/LocationSimulatorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetUnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_Handler()
	{
		if ((object)cb_unsubscribeFromSimulatorEvents_UnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V == null)
		{
			cb_unsubscribeFromSimulatorEvents_UnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_));
		}
		return cb_unsubscribeFromSimulatorEvents_UnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener__V;
	}

	private static void n_UnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationSimulator? locationSimulator = Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationSimulatorListener p = Java.Lang.Object.GetObject<ILocationSimulatorListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationSimulator.UnsubscribeFromSimulatorEvents(p);
	}

	public unsafe void UnsubscribeFromSimulatorEvents(ILocationSimulatorListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_location_LocationSimulator.InstanceMethods.InvokeAbstractVoidMethod("unsubscribeFromSimulatorEvents.(Lcom/yandex/mapkit/location/LocationSimulatorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener_Handler()
	{
		if ((object)cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V == null)
		{
			cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener_));
		}
		return cb_requestSingleUpdate_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener__V;
	}

	private static void n_RequestSingleUpdate_Lcom_yandex_mapkit_location_LocationListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationSimulator? locationSimulator = Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationListener p = Java.Lang.Object.GetObject<ILocationListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationSimulator.RequestSingleUpdate(p);
	}

	public unsafe void RequestSingleUpdate(ILocationListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("requestSingleUpdate.(Lcom/yandex/mapkit/location/LocationListener;)V", this, ptr);
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
		Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resume();
	}

	public unsafe void Resume()
	{
		_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("resume.()V", this, null);
	}

	private static Delegate GetSubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener_Handler()
	{
		if ((object)cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V == null)
		{
			cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener_));
		}
		return cb_subscribeForLocationUpdates_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener__V;
	}

	private static void n_SubscribeForLocationUpdates_Lcom_yandex_mapkit_location_SubscriptionSettings_Lcom_yandex_mapkit_location_LocationListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ILocationSimulator? locationSimulator = Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SubscriptionSettings p = Java.Lang.Object.GetObject<SubscriptionSettings>(native_p0, JniHandleOwnership.DoNotTransfer);
		ILocationListener p2 = Java.Lang.Object.GetObject<ILocationListener>(native_p1, JniHandleOwnership.DoNotTransfer);
		locationSimulator.SubscribeForLocationUpdates(p, p2);
	}

	public unsafe void SubscribeForLocationUpdates(SubscriptionSettings p0, ILocationListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("subscribeForLocationUpdates.(Lcom/yandex/mapkit/location/SubscriptionSettings;Lcom/yandex/mapkit/location/LocationListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSuspendHandler()
	{
		if ((object)cb_suspend_Suspend_V == null)
		{
			cb_suspend_Suspend_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Suspend));
		}
		return cb_suspend_Suspend_V;
	}

	private static void n_Suspend(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Suspend();
	}

	public unsafe void Suspend()
	{
		_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("suspend.()V", this, null);
	}

	private static Delegate GetUnsubscribe_Lcom_yandex_mapkit_location_LocationListener_Handler()
	{
		if ((object)cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V == null)
		{
			cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener_));
		}
		return cb_unsubscribe_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener__V;
	}

	private static void n_Unsubscribe_Lcom_yandex_mapkit_location_LocationListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ILocationSimulator? locationSimulator = Java.Lang.Object.GetObject<ILocationSimulator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationListener p = Java.Lang.Object.GetObject<ILocationListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		locationSimulator.Unsubscribe(p);
	}

	public unsafe void Unsubscribe(ILocationListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_location_LocationManager.InstanceMethods.InvokeAbstractVoidMethod("unsubscribe.(Lcom/yandex/mapkit/location/LocationListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/SubscriptionSettings", DoNotGenerateAcw = true)]
public class SubscriptionSettings : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/SubscriptionSettings", typeof(SubscriptionSettings));

	private static Delegate? cb_getPurpose_GetPurpose_Lcom_yandex_mapkit_location_Purpose_;

	private static Delegate? cb_getUseInBackground_GetUseInBackground_Lcom_yandex_mapkit_location_UseInBackground_;

	private static Delegate? cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;

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

	public unsafe virtual Purpose Purpose
	{
		[Register("getPurpose", "()Lcom/yandex/mapkit/location/Purpose;", "GetGetPurposeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Purpose>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPurpose.()Lcom/yandex/mapkit/location/Purpose;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual UseInBackground UseInBackground
	{
		[Register("getUseInBackground", "()Lcom/yandex/mapkit/location/UseInBackground;", "GetGetUseInBackgroundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<UseInBackground>(_members.InstanceMethods.InvokeVirtualObjectMethod("getUseInBackground.()Lcom/yandex/mapkit/location/UseInBackground;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected SubscriptionSettings(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SubscriptionSettings()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/location/UseInBackground;Lcom/yandex/mapkit/location/Purpose;)V", "")]
	public unsafe SubscriptionSettings(UseInBackground useInBackground, Purpose purpose)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(useInBackground?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(purpose?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/location/UseInBackground;Lcom/yandex/mapkit/location/Purpose;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/location/UseInBackground;Lcom/yandex/mapkit/location/Purpose;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(useInBackground);
			GC.KeepAlive(purpose);
		}
	}

	private static Delegate GetGetPurposeHandler()
	{
		if ((object)cb_getPurpose_GetPurpose_Lcom_yandex_mapkit_location_Purpose_ == null)
		{
			cb_getPurpose_GetPurpose_Lcom_yandex_mapkit_location_Purpose_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPurpose));
		}
		return cb_getPurpose_GetPurpose_Lcom_yandex_mapkit_location_Purpose_;
	}

	private static nint n_GetPurpose(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SubscriptionSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Purpose);
	}

	private static Delegate GetGetUseInBackgroundHandler()
	{
		if ((object)cb_getUseInBackground_GetUseInBackground_Lcom_yandex_mapkit_location_UseInBackground_ == null)
		{
			cb_getUseInBackground_GetUseInBackground_Lcom_yandex_mapkit_location_UseInBackground_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUseInBackground));
		}
		return cb_getUseInBackground_GetUseInBackground_Lcom_yandex_mapkit_location_UseInBackground_;
	}

	private static nint n_GetUseInBackground(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SubscriptionSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseInBackground);
	}

	private static Delegate GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler()
	{
		if ((object)cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V == null)
		{
			cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Serialize_Lcom_yandex_runtime_bindings_Archive_));
		}
		return cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;
	}

	private static void n_Serialize_Lcom_yandex_runtime_bindings_Archive_(nint jnienv, nint native__this, nint native_archive)
	{
		SubscriptionSettings? subscriptionSettings = Java.Lang.Object.GetObject<SubscriptionSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		subscriptionSettings.Serialize(archive);
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler")]
	public unsafe virtual void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}
}

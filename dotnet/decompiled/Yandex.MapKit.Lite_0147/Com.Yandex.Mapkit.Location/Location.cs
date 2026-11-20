using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/Location", DoNotGenerateAcw = true)]
public class Location : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/Location", typeof(Location));

	private static Delegate? cb_getAbsoluteTimestamp_GetAbsoluteTimestamp_J;

	private static Delegate? cb_getAccuracy_GetAccuracy_Ljava_lang_Double_;

	private static Delegate? cb_getAltitude_GetAltitude_Ljava_lang_Double_;

	private static Delegate? cb_getAltitudeAccuracy_GetAltitudeAccuracy_Ljava_lang_Double_;

	private static Delegate? cb_getHeading_GetHeading_Ljava_lang_Double_;

	private static Delegate? cb_getIndoorLevelId_GetIndoorLevelId_Ljava_lang_String_;

	private static Delegate? cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getRelativeTimestamp_GetRelativeTimestamp_J;

	private static Delegate? cb_getSpeed_GetSpeed_Ljava_lang_Double_;

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

	public unsafe virtual long AbsoluteTimestamp
	{
		[Register("getAbsoluteTimestamp", "()J", "GetGetAbsoluteTimestampHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getAbsoluteTimestamp.()J", this, null);
		}
	}

	public unsafe virtual Java.Lang.Double? Accuracy
	{
		[Register("getAccuracy", "()Ljava/lang/Double;", "GetGetAccuracyHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAccuracy.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Double? Altitude
	{
		[Register("getAltitude", "()Ljava/lang/Double;", "GetGetAltitudeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAltitude.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Double? AltitudeAccuracy
	{
		[Register("getAltitudeAccuracy", "()Ljava/lang/Double;", "GetGetAltitudeAccuracyHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAltitudeAccuracy.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Java.Lang.Double? Heading
	{
		[Register("getHeading", "()Ljava/lang/Double;", "GetGetHeadingHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeading.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? IndoorLevelId
	{
		[Register("getIndoorLevelId", "()Ljava/lang/String;", "GetGetIndoorLevelIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getIndoorLevelId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Point Position
	{
		[Register("getPosition", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetPositionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPosition.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual long RelativeTimestamp
	{
		[Register("getRelativeTimestamp", "()J", "GetGetRelativeTimestampHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getRelativeTimestamp.()J", this, null);
		}
	}

	public unsafe virtual Java.Lang.Double? Speed
	{
		[Register("getSpeed", "()Ljava/lang/Double;", "GetGetSpeedHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Double>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSpeed.()Ljava/lang/Double;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Location(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Location()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/Point;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/String;JJ)V", "")]
	public unsafe Location(Point position, Java.Lang.Double? accuracy, Java.Lang.Double? altitude, Java.Lang.Double? altitudeAccuracy, Java.Lang.Double? heading, Java.Lang.Double? speed, string? indoorLevelId, long absoluteTimestamp, long relativeTimestamp)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(indoorLevelId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(position?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(accuracy?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(altitude?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(altitudeAccuracy?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(heading?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(speed?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(num);
			ptr[7] = new JniArgumentValue(absoluteTimestamp);
			ptr[8] = new JniArgumentValue(relativeTimestamp);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/Point;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/String;JJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/Point;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/Double;Ljava/lang/String;JJ)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(position);
			GC.KeepAlive(accuracy);
			GC.KeepAlive(altitude);
			GC.KeepAlive(altitudeAccuracy);
			GC.KeepAlive(heading);
			GC.KeepAlive(speed);
		}
	}

	private static Delegate GetGetAbsoluteTimestampHandler()
	{
		if ((object)cb_getAbsoluteTimestamp_GetAbsoluteTimestamp_J == null)
		{
			cb_getAbsoluteTimestamp_GetAbsoluteTimestamp_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetAbsoluteTimestamp));
		}
		return cb_getAbsoluteTimestamp_GetAbsoluteTimestamp_J;
	}

	private static long n_GetAbsoluteTimestamp(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AbsoluteTimestamp;
	}

	private static Delegate GetGetAccuracyHandler()
	{
		if ((object)cb_getAccuracy_GetAccuracy_Ljava_lang_Double_ == null)
		{
			cb_getAccuracy_GetAccuracy_Ljava_lang_Double_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAccuracy));
		}
		return cb_getAccuracy_GetAccuracy_Ljava_lang_Double_;
	}

	private static nint n_GetAccuracy(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Accuracy);
	}

	private static Delegate GetGetAltitudeHandler()
	{
		if ((object)cb_getAltitude_GetAltitude_Ljava_lang_Double_ == null)
		{
			cb_getAltitude_GetAltitude_Ljava_lang_Double_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAltitude));
		}
		return cb_getAltitude_GetAltitude_Ljava_lang_Double_;
	}

	private static nint n_GetAltitude(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Altitude);
	}

	private static Delegate GetGetAltitudeAccuracyHandler()
	{
		if ((object)cb_getAltitudeAccuracy_GetAltitudeAccuracy_Ljava_lang_Double_ == null)
		{
			cb_getAltitudeAccuracy_GetAltitudeAccuracy_Ljava_lang_Double_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAltitudeAccuracy));
		}
		return cb_getAltitudeAccuracy_GetAltitudeAccuracy_Ljava_lang_Double_;
	}

	private static nint n_GetAltitudeAccuracy(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AltitudeAccuracy);
	}

	private static Delegate GetGetHeadingHandler()
	{
		if ((object)cb_getHeading_GetHeading_Ljava_lang_Double_ == null)
		{
			cb_getHeading_GetHeading_Ljava_lang_Double_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHeading));
		}
		return cb_getHeading_GetHeading_Ljava_lang_Double_;
	}

	private static nint n_GetHeading(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Heading);
	}

	private static Delegate GetGetIndoorLevelIdHandler()
	{
		if ((object)cb_getIndoorLevelId_GetIndoorLevelId_Ljava_lang_String_ == null)
		{
			cb_getIndoorLevelId_GetIndoorLevelId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetIndoorLevelId));
		}
		return cb_getIndoorLevelId_GetIndoorLevelId_Ljava_lang_String_;
	}

	private static nint n_GetIndoorLevelId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndoorLevelId);
	}

	private static Delegate GetGetPositionHandler()
	{
		if ((object)cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPosition));
		}
		return cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetPosition(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position);
	}

	private static Delegate GetGetRelativeTimestampHandler()
	{
		if ((object)cb_getRelativeTimestamp_GetRelativeTimestamp_J == null)
		{
			cb_getRelativeTimestamp_GetRelativeTimestamp_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetRelativeTimestamp));
		}
		return cb_getRelativeTimestamp_GetRelativeTimestamp_J;
	}

	private static long n_GetRelativeTimestamp(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativeTimestamp;
	}

	private static Delegate GetGetSpeedHandler()
	{
		if ((object)cb_getSpeed_GetSpeed_Ljava_lang_Double_ == null)
		{
			cb_getSpeed_GetSpeed_Ljava_lang_Double_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSpeed));
		}
		return cb_getSpeed_GetSpeed_Ljava_lang_Double_;
	}

	private static nint n_GetSpeed(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Speed);
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
		Location? location = Java.Lang.Object.GetObject<Location>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		location.Serialize(archive);
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

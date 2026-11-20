using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationSettings", DoNotGenerateAcw = true)]
public sealed class LocationSettings : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/LocationSettings", typeof(LocationSettings));

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

	public unsafe Range? Accuracy
	{
		[Register("getAccuracy", "()Lcom/yandex/mapkit/location/Range;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAccuracy.()Lcom/yandex/mapkit/location/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Range? HeadingError
	{
		[Register("getHeadingError", "()Lcom/yandex/mapkit/location/Range;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getHeadingError.()Lcom/yandex/mapkit/location/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe LocationError? LocationError
	{
		[Register("getLocationError", "()Lcom/yandex/mapkit/location/LocationError;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LocationError>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocationError.()Lcom/yandex/mapkit/location/LocationError;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe TimeInterval? LocationTimeInterval
	{
		[Register("getLocationTimeInterval", "()Lcom/yandex/mapkit/location/TimeInterval;", "")]
		get
		{
			return Java.Lang.Object.GetObject<TimeInterval>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocationTimeInterval.()Lcom/yandex/mapkit/location/TimeInterval;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool ProvideAccuracy
	{
		[Register("getProvideAccuracy", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getProvideAccuracy.()Z", this, null);
		}
	}

	public unsafe bool ProvideHeading
	{
		[Register("getProvideHeading", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getProvideHeading.()Z", this, null);
		}
	}

	public unsafe bool ProvideSpeed
	{
		[Register("getProvideSpeed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getProvideSpeed.()Z", this, null);
		}
	}

	public unsafe bool ProvideWheelSpeed
	{
		[Register("getProvideWheelSpeed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getProvideWheelSpeed.()Z", this, null);
		}
	}

	public unsafe double Speed
	{
		[Register("getSpeed", "()D", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractDoubleMethod("getSpeed.()D", this, null);
		}
	}

	public unsafe TimeInterval? WheelSpeedTimeInterval
	{
		[Register("getWheelSpeedTimeInterval", "()Lcom/yandex/mapkit/location/TimeInterval;", "")]
		get
		{
			return Java.Lang.Object.GetObject<TimeInterval>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWheelSpeedTimeInterval.()Lcom/yandex/mapkit/location/TimeInterval;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal LocationSettings(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LocationSettings()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(ZLcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/TimeInterval;ZDZLcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/LocationError;ZLcom/yandex/mapkit/location/TimeInterval;)V", "")]
	public unsafe LocationSettings(bool provideAccuracy, Range? accuracy, TimeInterval? locationTimeInterval, bool provideSpeed, double speed, bool provideHeading, Range? headingError, LocationError? locationError, bool provideWheelSpeed, TimeInterval? wheelSpeedTimeInterval)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
			*ptr = new JniArgumentValue(provideAccuracy);
			ptr[1] = new JniArgumentValue(accuracy?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(locationTimeInterval?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(provideSpeed);
			ptr[4] = new JniArgumentValue(speed);
			ptr[5] = new JniArgumentValue(provideHeading);
			ptr[6] = new JniArgumentValue(headingError?.Handle ?? IntPtr.Zero);
			ptr[7] = new JniArgumentValue(locationError?.Handle ?? IntPtr.Zero);
			ptr[8] = new JniArgumentValue(provideWheelSpeed);
			ptr[9] = new JniArgumentValue(wheelSpeedTimeInterval?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ZLcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/TimeInterval;ZDZLcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/LocationError;ZLcom/yandex/mapkit/location/TimeInterval;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ZLcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/TimeInterval;ZDZLcom/yandex/mapkit/location/Range;Lcom/yandex/mapkit/location/LocationError;ZLcom/yandex/mapkit/location/TimeInterval;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(accuracy);
			GC.KeepAlive(locationTimeInterval);
			GC.KeepAlive(headingError);
			GC.KeepAlive(locationError);
			GC.KeepAlive(wheelSpeedTimeInterval);
		}
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "")]
	public unsafe void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}

	[Register("setAccuracy", "(Lcom/yandex/mapkit/location/Range;)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetAccuracy(Range? accuracy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(accuracy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAccuracy.(Lcom/yandex/mapkit/location/Range;)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(accuracy);
		}
	}

	[Register("setHeadingError", "(Lcom/yandex/mapkit/location/Range;)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetHeadingError(Range? headingError)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(headingError?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setHeadingError.(Lcom/yandex/mapkit/location/Range;)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(headingError);
		}
	}

	[Register("setLocationError", "(Lcom/yandex/mapkit/location/LocationError;)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetLocationError(LocationError? locationError)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locationError?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLocationError.(Lcom/yandex/mapkit/location/LocationError;)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(locationError);
		}
	}

	[Register("setLocationTimeInterval", "(Lcom/yandex/mapkit/location/TimeInterval;)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetLocationTimeInterval(TimeInterval? locationTimeInterval)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locationTimeInterval?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLocationTimeInterval.(Lcom/yandex/mapkit/location/TimeInterval;)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(locationTimeInterval);
		}
	}

	[Register("setProvideAccuracy", "(Z)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetProvideAccuracy(bool provideAccuracy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(provideAccuracy);
		return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setProvideAccuracy.(Z)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setProvideHeading", "(Z)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetProvideHeading(bool provideHeading)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(provideHeading);
		return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setProvideHeading.(Z)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setProvideSpeed", "(Z)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetProvideSpeed(bool provideSpeed)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(provideSpeed);
		return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setProvideSpeed.(Z)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setProvideWheelSpeed", "(Z)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetProvideWheelSpeed(bool provideWheelSpeed)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(provideWheelSpeed);
		return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setProvideWheelSpeed.(Z)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setSpeed", "(D)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetSpeed(double speed)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(speed);
		return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSpeed.(D)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setWheelSpeedTimeInterval", "(Lcom/yandex/mapkit/location/TimeInterval;)Lcom/yandex/mapkit/location/LocationSettings;", "")]
	public unsafe LocationSettings? SetWheelSpeedTimeInterval(TimeInterval? wheelSpeedTimeInterval)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(wheelSpeedTimeInterval?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeAbstractObjectMethod("setWheelSpeedTimeInterval.(Lcom/yandex/mapkit/location/TimeInterval;)Lcom/yandex/mapkit/location/LocationSettings;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(wheelSpeedTimeInterval);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/TimeInterval", DoNotGenerateAcw = true)]
public class TimeInterval : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/TimeInterval", typeof(TimeInterval));

	private static Delegate? cb_getFrom_GetFrom_J;

	private static Delegate? cb_getTo_GetTo_J;

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

	public unsafe virtual long From
	{
		[Register("getFrom", "()J", "GetGetFromHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getFrom.()J", this, null);
		}
	}

	public unsafe static string? NativeName
	{
		[Register("getNativeName", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getNativeName.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual long To
	{
		[Register("getTo", "()J", "GetGetToHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getTo.()J", this, null);
		}
	}

	protected TimeInterval(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe TimeInterval()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(JJ)V", "")]
	public unsafe TimeInterval(long from, long to)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(from);
			ptr[1] = new JniArgumentValue(to);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(JJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(JJ)V", this, ptr);
		}
	}

	private static Delegate GetGetFromHandler()
	{
		if ((object)cb_getFrom_GetFrom_J == null)
		{
			cb_getFrom_GetFrom_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetFrom));
		}
		return cb_getFrom_GetFrom_J;
	}

	private static long n_GetFrom(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<TimeInterval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).From;
	}

	private static Delegate GetGetToHandler()
	{
		if ((object)cb_getTo_GetTo_J == null)
		{
			cb_getTo_GetTo_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTo));
		}
		return cb_getTo_GetTo_J;
	}

	private static long n_GetTo(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<TimeInterval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).To;
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
		TimeInterval? timeInterval = Java.Lang.Object.GetObject<TimeInterval>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		timeInterval.Serialize(archive);
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

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/Animation", DoNotGenerateAcw = true)]
public class Animation : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/Animation$Type", DoNotGenerateAcw = true)]
	public sealed class Type : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/Animation$Type", typeof(Type));

		[Register("LINEAR")]
		public static Type? Linear => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("LINEAR.Lcom/yandex/mapkit/Animation$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SMOOTH")]
		public static Type? Smooth => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("SMOOTH.Lcom/yandex/mapkit/Animation$Type;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override System.Type ThresholdType => _members.ManagedPeerType;

		internal Type(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/Animation$Type;", "")]
		public unsafe static Type? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Type>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/Animation$Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lcom/yandex/mapkit/Animation$Type;", "")]
		public unsafe static Type[]? Values()
		{
			return (Type[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/Animation$Type;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Type));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/Animation", typeof(Animation));

	private static Delegate? cb_getDuration_GetDuration_F;

	private static Delegate? cb_getType_GetType_Lcom_yandex_mapkit_Animation_Type_;

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
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual float Duration
	{
		[Register("getDuration", "()F", "GetGetDurationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getDuration.()F", this, null);
		}
	}

	protected Animation(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Animation()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", base.GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/Animation$Type;F)V", "")]
	public unsafe Animation(Type type, float duration)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(duration);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/Animation$Type;F)V", base.GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/Animation$Type;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(type);
		}
	}

	private static Delegate GetGetDurationHandler()
	{
		if ((object)cb_getDuration_GetDuration_F == null)
		{
			cb_getDuration_GetDuration_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetDuration));
		}
		return cb_getDuration_GetDuration_F;
	}

	private static float n_GetDuration(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
	}

	private static Delegate GetGetTypeHandler()
	{
		if ((object)cb_getType_GetType_Lcom_yandex_mapkit_Animation_Type_ == null)
		{
			cb_getType_GetType_Lcom_yandex_mapkit_Animation_Type_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
		}
		return cb_getType_GetType_Lcom_yandex_mapkit_Animation_Type_;
	}

	private static nint n_GetType(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetType());
	}

	[Register("getType", "()Lcom/yandex/mapkit/Animation$Type;", "GetGetTypeHandler")]
	public new unsafe virtual Type GetType()
	{
		return Java.Lang.Object.GetObject<Type>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Lcom/yandex/mapkit/Animation$Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
		Animation? animation = Java.Lang.Object.GetObject<Animation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		animation.Serialize(archive);
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

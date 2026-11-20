using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/DeferrableSurface", DoNotGenerateAcw = true)]
public abstract class DeferrableSurface : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/DeferrableSurface", typeof(DeferrableSurface));

	private static Delegate? cb_getCloseFuture;

	private static Delegate? cb_getContainerClass;

	private static Delegate? cb_setContainerClass_Ljava_lang_Class_;

	private static Delegate? cb_isClosed;

	private static Delegate? cb_getPrescribedSize;

	private static Delegate? cb_getPrescribedStreamFormat;

	private static Delegate? cb_getTerminationFuture;

	private static Delegate? cb_getUseCount;

	private static Delegate? cb_close;

	private static Delegate? cb_decrementUseCount;

	private static Delegate? cb_incrementUseCount;

	private static Delegate? cb_provideSurface;

	[Register("SIZE_UNDEFINED")]
	public static Size? SizeUndefined => Java.Lang.Object.GetObject<Size>(_members.StaticFields.GetObjectValue("SIZE_UNDEFINED.Landroid/util/Size;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe virtual IListenableFuture CloseFuture
	{
		[Register("getCloseFuture", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetCloseFutureHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCloseFuture.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Class? ContainerClass
	{
		[Register("getContainerClass", "()Ljava/lang/Class;", "GetGetContainerClassHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Class>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContainerClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setContainerClass", "(Ljava/lang/Class;)V", "GetSetContainerClass_Ljava_lang_Class_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setContainerClass.(Ljava/lang/Class;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool IsClosed
	{
		[Register("isClosed", "()Z", "GetIsClosedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isClosed.()Z", this, null);
		}
	}

	public unsafe virtual Size PrescribedSize
	{
		[Register("getPrescribedSize", "()Landroid/util/Size;", "GetGetPrescribedSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrescribedSize.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int PrescribedStreamFormat
	{
		[Register("getPrescribedStreamFormat", "()I", "GetGetPrescribedStreamFormatHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPrescribedStreamFormat.()I", this, null);
		}
	}

	public unsafe IListenableFuture Surface
	{
		[Register("getSurface", "()Lcom/google/common/util/concurrent/ListenableFuture;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSurface.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IListenableFuture TerminationFuture
	{
		[Register("getTerminationFuture", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetTerminationFutureHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTerminationFuture.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int UseCount
	{
		[Register("getUseCount", "()I", "GetGetUseCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getUseCount.()I", this, null);
		}
	}

	protected DeferrableSurface(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe DeferrableSurface()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/util/Size;I)V", "")]
	public unsafe DeferrableSurface(Size size, int format)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(size?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(format);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Size;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Size;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(size);
		}
	}

	private static Delegate GetGetCloseFutureHandler()
	{
		if ((object)cb_getCloseFuture == null)
		{
			cb_getCloseFuture = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCloseFuture));
		}
		return cb_getCloseFuture;
	}

	private static nint n_GetCloseFuture(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloseFuture);
	}

	private static Delegate GetGetContainerClassHandler()
	{
		if ((object)cb_getContainerClass == null)
		{
			cb_getContainerClass = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContainerClass));
		}
		return cb_getContainerClass;
	}

	private static nint n_GetContainerClass(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainerClass);
	}

	private static Delegate GetSetContainerClass_Ljava_lang_Class_Handler()
	{
		if ((object)cb_setContainerClass_Ljava_lang_Class_ == null)
		{
			cb_setContainerClass_Ljava_lang_Class_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetContainerClass_Ljava_lang_Class_));
		}
		return cb_setContainerClass_Ljava_lang_Class_;
	}

	private static void n_SetContainerClass_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_containerClass)
	{
		DeferrableSurface? deferrableSurface = Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Class containerClass = Java.Lang.Object.GetObject<Class>(native_containerClass, JniHandleOwnership.DoNotTransfer);
		deferrableSurface.ContainerClass = containerClass;
	}

	private static Delegate GetIsClosedHandler()
	{
		if ((object)cb_isClosed == null)
		{
			cb_isClosed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsClosed));
		}
		return cb_isClosed;
	}

	private static bool n_IsClosed(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsClosed;
	}

	private static Delegate GetGetPrescribedSizeHandler()
	{
		if ((object)cb_getPrescribedSize == null)
		{
			cb_getPrescribedSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPrescribedSize));
		}
		return cb_getPrescribedSize;
	}

	private static nint n_GetPrescribedSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrescribedSize);
	}

	private static Delegate GetGetPrescribedStreamFormatHandler()
	{
		if ((object)cb_getPrescribedStreamFormat == null)
		{
			cb_getPrescribedStreamFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPrescribedStreamFormat));
		}
		return cb_getPrescribedStreamFormat;
	}

	private static int n_GetPrescribedStreamFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrescribedStreamFormat;
	}

	private static Delegate GetGetTerminationFutureHandler()
	{
		if ((object)cb_getTerminationFuture == null)
		{
			cb_getTerminationFuture = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTerminationFuture));
		}
		return cb_getTerminationFuture;
	}

	private static nint n_GetTerminationFuture(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TerminationFuture);
	}

	private static Delegate GetGetUseCountHandler()
	{
		if ((object)cb_getUseCount == null)
		{
			cb_getUseCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetUseCount));
		}
		return cb_getUseCount;
	}

	private static int n_GetUseCount(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCount;
	}

	private static Delegate GetCloseHandler()
	{
		if ((object)cb_close == null)
		{
			cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
		}
		return cb_close;
	}

	private static void n_Close(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
	}

	[Register("close", "()V", "GetCloseHandler")]
	public unsafe virtual void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}

	private static Delegate GetDecrementUseCountHandler()
	{
		if ((object)cb_decrementUseCount == null)
		{
			cb_decrementUseCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DecrementUseCount));
		}
		return cb_decrementUseCount;
	}

	private static void n_DecrementUseCount(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DecrementUseCount();
	}

	[Register("decrementUseCount", "()V", "GetDecrementUseCountHandler")]
	public unsafe virtual void DecrementUseCount()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("decrementUseCount.()V", this, null);
	}

	private static Delegate GetIncrementUseCountHandler()
	{
		if ((object)cb_incrementUseCount == null)
		{
			cb_incrementUseCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_IncrementUseCount));
		}
		return cb_incrementUseCount;
	}

	private static void n_IncrementUseCount(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IncrementUseCount();
	}

	[Register("incrementUseCount", "()V", "GetIncrementUseCountHandler")]
	public unsafe virtual void IncrementUseCount()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("incrementUseCount.()V", this, null);
	}

	private static Delegate GetProvideSurfaceHandler()
	{
		if ((object)cb_provideSurface == null)
		{
			cb_provideSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ProvideSurface));
		}
		return cb_provideSurface;
	}

	private static nint n_ProvideSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DeferrableSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProvideSurface());
	}

	[Register("provideSurface", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetProvideSurfaceHandler")]
	protected abstract IListenableFuture ProvideSurface();
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.Util;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/SurfaceOutput", DoNotGenerateAcw = true)]
internal class ISurfaceOutputInvoker : Java.Lang.Object, ISurfaceOutput, ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceOutput", typeof(ISurfaceOutputInvoker));

	private nint class_ref;

	private static Delegate? cb_getSize;

	private nint id_getSize;

	private static Delegate? cb_getTargets;

	private nint id_getTargets;

	private static Delegate? cb_close;

	private nint id_close;

	private static Delegate? cb_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;

	private nint id_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;

	private static Delegate? cb_updateTransformMatrix_arrayFarrayF;

	private nint id_updateTransformMatrix_arrayFarrayF;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public Size Size
	{
		get
		{
			if (id_getSize == IntPtr.Zero)
			{
				id_getSize = JNIEnv.GetMethodID(class_ref, "getSize", "()Landroid/util/Size;");
			}
			return Java.Lang.Object.GetObject<Size>(JNIEnv.CallObjectMethod(base.Handle, id_getSize), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int Targets
	{
		get
		{
			if (id_getTargets == IntPtr.Zero)
			{
				id_getTargets = JNIEnv.GetMethodID(class_ref, "getTargets", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getTargets);
		}
	}

	public static ISurfaceOutput? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ISurfaceOutput>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.SurfaceOutput'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public ISurfaceOutputInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetSizeHandler()
	{
		if ((object)cb_getSize == null)
		{
			cb_getSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSize));
		}
		return cb_getSize;
	}

	private static nint n_GetSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size);
	}

	private static Delegate GetGetTargetsHandler()
	{
		if ((object)cb_getTargets == null)
		{
			cb_getTargets = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargets));
		}
		return cb_getTargets;
	}

	private static int n_GetTargets(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Targets;
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
		Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
	}

	public void Close()
	{
		if (id_close == IntPtr.Zero)
		{
			id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_close);
	}

	private static Delegate GetGetSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler()
	{
		if ((object)cb_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ == null)
		{
			cb_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GetSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_));
		}
		return cb_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_;
	}

	private static nint n_GetSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ISurfaceOutput? surfaceOutput = Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
		IConsumer p2 = Java.Lang.Object.GetObject<IConsumer>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(surfaceOutput.GetSurface(p, p2));
	}

	public unsafe Surface GetSurface(IExecutor p0, IConsumer p1)
	{
		if (id_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ == IntPtr.Zero)
		{
			id_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_ = JNIEnv.GetMethodID(class_ref, "getSurface", "(Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroid/view/Surface;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		return Java.Lang.Object.GetObject<Surface>(JNIEnv.CallObjectMethod(base.Handle, id_getSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUpdateTransformMatrix_arrayFarrayFHandler()
	{
		if ((object)cb_updateTransformMatrix_arrayFarrayF == null)
		{
			cb_updateTransformMatrix_arrayFarrayF = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_UpdateTransformMatrix_arrayFarrayF));
		}
		return cb_updateTransformMatrix_arrayFarrayF;
	}

	private static void n_UpdateTransformMatrix_arrayFarrayF(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ISurfaceOutput? surfaceOutput = Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		float[] array = (float[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(float));
		float[] array2 = (float[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(float));
		surfaceOutput.UpdateTransformMatrix(array, array2);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_p0);
		}
		if (array2 != null)
		{
			JNIEnv.CopyArray(array2, native_p1);
		}
	}

	public unsafe void UpdateTransformMatrix(float[] p0, float[] p1)
	{
		if (id_updateTransformMatrix_arrayFarrayF == IntPtr.Zero)
		{
			id_updateTransformMatrix_arrayFarrayF = JNIEnv.GetMethodID(class_ref, "updateTransformMatrix", "([F[F)V");
		}
		nint num = JNIEnv.NewArray(p0);
		nint num2 = JNIEnv.NewArray(p1);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(num);
		ptr[1] = new JValue(num2);
		JNIEnv.CallVoidMethod(base.Handle, id_updateTransformMatrix_arrayFarrayF, ptr);
		if (p0 != null)
		{
			JNIEnv.CopyArray(num, p0);
			JNIEnv.DeleteLocalRef(num);
		}
		if (p1 != null)
		{
			JNIEnv.CopyArray(num2, p1);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}

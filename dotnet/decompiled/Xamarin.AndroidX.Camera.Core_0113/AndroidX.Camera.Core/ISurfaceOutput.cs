using System;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.Util;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/SurfaceOutput", "", "AndroidX.Camera.Core.ISurfaceOutputInvoker")]
public interface ISurfaceOutput : ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceOutput", typeof(ISurfaceOutput), isInterface: true);

	private static Delegate? cb_getFormat;

	private static Delegate? cb_getSensorToBufferTransform;

	private static Delegate? cb_updateTransformMatrix_arrayFarrayFZ;

	Size Size
	{
		[Register("getSize", "()Landroid/util/Size;", "GetGetSizeHandler:AndroidX.Camera.Core.ISurfaceOutputInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int Targets
	{
		[Register("getTargets", "()I", "GetGetTargetsHandler:AndroidX.Camera.Core.ISurfaceOutputInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	unsafe int Format
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getFormat", "()I", "GetGetFormatHandler:AndroidX.Camera.Core.ISurfaceOutput, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFormat.()I", this, null);
		}
	}

	unsafe Matrix SensorToBufferTransform
	{
		[Register("getSensorToBufferTransform", "()Landroid/graphics/Matrix;", "GetGetSensorToBufferTransformHandler:AndroidX.Camera.Core.ISurfaceOutput, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSensorToBufferTransform.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static Delegate GetGetFormatHandler()
	{
		if ((object)cb_getFormat == null)
		{
			cb_getFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFormat));
		}
		return cb_getFormat;
	}

	private static int n_GetFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Format;
	}

	private static Delegate GetGetSensorToBufferTransformHandler()
	{
		if ((object)cb_getSensorToBufferTransform == null)
		{
			cb_getSensorToBufferTransform = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSensorToBufferTransform));
		}
		return cb_getSensorToBufferTransform;
	}

	private static nint n_GetSensorToBufferTransform(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorToBufferTransform);
	}

	[Register("close", "()V", "GetCloseHandler:AndroidX.Camera.Core.ISurfaceOutputInvoker, Xamarin.AndroidX.Camera.Core")]
	new void Close();

	[Register("getSurface", "(Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)Landroid/view/Surface;", "GetGetSurface_Ljava_util_concurrent_Executor_Landroidx_core_util_Consumer_Handler:AndroidX.Camera.Core.ISurfaceOutputInvoker, Xamarin.AndroidX.Camera.Core")]
	Surface GetSurface(IExecutor p0, IConsumer p1);

	[Register("updateTransformMatrix", "([F[F)V", "GetUpdateTransformMatrix_arrayFarrayFHandler:AndroidX.Camera.Core.ISurfaceOutputInvoker, Xamarin.AndroidX.Camera.Core")]
	void UpdateTransformMatrix(float[] p0, float[] p1);

	private static Delegate GetUpdateTransformMatrix_arrayFarrayFZHandler()
	{
		if ((object)cb_updateTransformMatrix_arrayFarrayFZ == null)
		{
			cb_updateTransformMatrix_arrayFarrayFZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_UpdateTransformMatrix_arrayFarrayFZ));
		}
		return cb_updateTransformMatrix_arrayFarrayFZ;
	}

	private static void n_UpdateTransformMatrix_arrayFarrayFZ(nint jnienv, nint native__this, nint native_updated, nint native_original, bool isPrimary)
	{
		ISurfaceOutput? surfaceOutput = Java.Lang.Object.GetObject<ISurfaceOutput>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		float[] array = (float[])JNIEnv.GetArray(native_updated, JniHandleOwnership.DoNotTransfer, typeof(float));
		float[] array2 = (float[])JNIEnv.GetArray(native_original, JniHandleOwnership.DoNotTransfer, typeof(float));
		surfaceOutput.UpdateTransformMatrix(array, array2, isPrimary);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_updated);
		}
		if (array2 != null)
		{
			JNIEnv.CopyArray(array2, native_original);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("updateTransformMatrix", "([F[FZ)V", "GetUpdateTransformMatrix_arrayFarrayFZHandler:AndroidX.Camera.Core.ISurfaceOutput, Xamarin.AndroidX.Camera.Core")]
	unsafe void UpdateTransformMatrix(float[] updated, float[] original, bool isPrimary)
	{
		nint num = JNIEnv.NewArray(updated);
		nint num2 = JNIEnv.NewArray(original);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(isPrimary);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateTransformMatrix.([F[FZ)V", this, ptr);
		}
		finally
		{
			if (updated != null)
			{
				JNIEnv.CopyArray(num, updated);
				JNIEnv.DeleteLocalRef(num);
			}
			if (original != null)
			{
				JNIEnv.CopyArray(num2, original);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(updated);
			GC.KeepAlive(original);
		}
	}
}

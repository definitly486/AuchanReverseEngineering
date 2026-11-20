using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Nio;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageProxy$PlaneProxy", DoNotGenerateAcw = true)]
internal class IImageProxyPlaneProxyInvoker : Java.Lang.Object, IImageProxyPlaneProxy, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageProxy$PlaneProxy", typeof(IImageProxyPlaneProxyInvoker));

	private nint class_ref;

	private static Delegate? cb_getBuffer;

	private nint id_getBuffer;

	private static Delegate? cb_getPixelStride;

	private nint id_getPixelStride;

	private static Delegate? cb_getRowStride;

	private nint id_getRowStride;

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

	public ByteBuffer Buffer
	{
		get
		{
			if (id_getBuffer == IntPtr.Zero)
			{
				id_getBuffer = JNIEnv.GetMethodID(class_ref, "getBuffer", "()Ljava/nio/ByteBuffer;");
			}
			return Java.Lang.Object.GetObject<ByteBuffer>(JNIEnv.CallObjectMethod(base.Handle, id_getBuffer), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int PixelStride
	{
		get
		{
			if (id_getPixelStride == IntPtr.Zero)
			{
				id_getPixelStride = JNIEnv.GetMethodID(class_ref, "getPixelStride", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getPixelStride);
		}
	}

	public int RowStride
	{
		get
		{
			if (id_getRowStride == IntPtr.Zero)
			{
				id_getRowStride = JNIEnv.GetMethodID(class_ref, "getRowStride", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getRowStride);
		}
	}

	public static IImageProxyPlaneProxy? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageProxyPlaneProxy>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageProxy.PlaneProxy'.");
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

	public IImageProxyPlaneProxyInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetBufferHandler()
	{
		if ((object)cb_getBuffer == null)
		{
			cb_getBuffer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBuffer));
		}
		return cb_getBuffer;
	}

	private static nint n_GetBuffer(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageProxyPlaneProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Buffer);
	}

	private static Delegate GetGetPixelStrideHandler()
	{
		if ((object)cb_getPixelStride == null)
		{
			cb_getPixelStride = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetPixelStride));
		}
		return cb_getPixelStride;
	}

	private static int n_GetPixelStride(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageProxyPlaneProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PixelStride;
	}

	private static Delegate GetGetRowStrideHandler()
	{
		if ((object)cb_getRowStride == null)
		{
			cb_getRowStride = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRowStride));
		}
		return cb_getRowStride;
	}

	private static int n_GetRowStride(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageProxyPlaneProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowStride;
	}
}

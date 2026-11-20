using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageReaderProxyProvider", DoNotGenerateAcw = true)]
internal class IImageReaderProxyProviderInvoker : Java.Lang.Object, IImageReaderProxyProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageReaderProxyProvider", typeof(IImageReaderProxyProviderInvoker));

	private nint class_ref;

	private static Delegate? cb_newInstance_IIIIJ;

	private nint id_newInstance_IIIIJ;

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

	public static IImageReaderProxyProvider? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageReaderProxyProvider>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageReaderProxyProvider'.");
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

	public IImageReaderProxyProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetNewInstance_IIIIJHandler()
	{
		if ((object)cb_newInstance_IIIIJ == null)
		{
			cb_newInstance_IIIIJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIJ_L(n_NewInstance_IIIIJ));
		}
		return cb_newInstance_IIIIJ;
	}

	private static nint n_NewInstance_IIIIJ(nint jnienv, nint native__this, int p0, int p1, int p2, int p3, long p4)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageReaderProxyProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewInstance(p0, p1, p2, p3, p4));
	}

	public unsafe IImageReaderProxy NewInstance(int p0, int p1, int p2, int p3, long p4)
	{
		if (id_newInstance_IIIIJ == IntPtr.Zero)
		{
			id_newInstance_IIIIJ = JNIEnv.GetMethodID(class_ref, "newInstance", "(IIIIJ)Landroidx/camera/core/impl/ImageReaderProxy;");
		}
		JValue* ptr = stackalloc JValue[5];
		*ptr = new JValue(p0);
		ptr[1] = new JValue(p1);
		ptr[2] = new JValue(p2);
		ptr[3] = new JValue(p3);
		ptr[4] = new JValue(p4);
		return Java.Lang.Object.GetObject<IImageReaderProxy>(JNIEnv.CallObjectMethod(base.Handle, id_newInstance_IIIIJ, ptr), JniHandleOwnership.TransferLocalRef);
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/UseCaseConfigFactory", DoNotGenerateAcw = true)]
internal class IUseCaseConfigFactoryInvoker : Java.Lang.Object, IUseCaseConfigFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/UseCaseConfigFactory", typeof(IUseCaseConfigFactoryInvoker));

	private nint class_ref;

	private static Delegate? cb_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I;

	private nint id_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I;

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

	public static IUseCaseConfigFactory? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IUseCaseConfigFactory>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.UseCaseConfigFactory'.");
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

	public IUseCaseConfigFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_IHandler()
	{
		if ((object)cb_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I == null)
		{
			cb_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_GetConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I));
		}
		return cb_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I;
	}

	private static nint n_GetConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I(nint jnienv, nint native__this, nint native_p0, int p1)
	{
		IUseCaseConfigFactory? useCaseConfigFactory = Java.Lang.Object.GetObject<IUseCaseConfigFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCaseConfigFactoryCaptureType p2 = Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(useCaseConfigFactory.GetConfig(p2, p1));
	}

	public unsafe IConfig? GetConfig(UseCaseConfigFactoryCaptureType p0, int p1)
	{
		if (id_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I == IntPtr.Zero)
		{
			id_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I = JNIEnv.GetMethodID(class_ref, "getConfig", "(Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;I)Landroidx/camera/core/impl/Config;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(p1);
		return Java.Lang.Object.GetObject<IConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_I, ptr), JniHandleOwnership.TransferLocalRef);
	}
}

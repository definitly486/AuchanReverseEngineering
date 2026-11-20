using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ConfigProvider", DoNotGenerateAcw = true)]
internal class IConfigProviderInvoker : Java.Lang.Object, IConfigProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/ConfigProvider", typeof(IConfigProviderInvoker));

	private nint class_ref;

	private static Delegate? cb_getConfig;

	private nint id_getConfig;

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

	public Java.Lang.Object Config
	{
		get
		{
			if (id_getConfig == IntPtr.Zero)
			{
				id_getConfig = JNIEnv.GetMethodID(class_ref, "getConfig", "()Landroidx/camera/core/impl/Config;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IConfigProvider? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IConfigProvider>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.ConfigProvider'.");
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

	public IConfigProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetConfigHandler()
	{
		if ((object)cb_getConfig == null)
		{
			cb_getConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetConfig));
		}
		return cb_getConfig;
	}

	private static nint n_GetConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IConfigProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Config);
	}
}

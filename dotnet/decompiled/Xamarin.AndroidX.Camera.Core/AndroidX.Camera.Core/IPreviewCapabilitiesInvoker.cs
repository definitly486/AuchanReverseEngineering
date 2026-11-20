using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/PreviewCapabilities", DoNotGenerateAcw = true)]
internal class IPreviewCapabilitiesInvoker : Java.Lang.Object, IPreviewCapabilities, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/PreviewCapabilities", typeof(IPreviewCapabilitiesInvoker));

	private nint class_ref;

	private static Delegate? cb_isStabilizationSupported;

	private nint id_isStabilizationSupported;

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

	public bool IsStabilizationSupported
	{
		get
		{
			if (id_isStabilizationSupported == IntPtr.Zero)
			{
				id_isStabilizationSupported = JNIEnv.GetMethodID(class_ref, "isStabilizationSupported", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_isStabilizationSupported);
		}
	}

	public static IPreviewCapabilities? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IPreviewCapabilities>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.PreviewCapabilities'.");
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

	public IPreviewCapabilitiesInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetIsStabilizationSupportedHandler()
	{
		if ((object)cb_isStabilizationSupported == null)
		{
			cb_isStabilizationSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStabilizationSupported));
		}
		return cb_isStabilizationSupported;
	}

	private static bool n_IsStabilizationSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPreviewCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStabilizationSupported;
	}
}

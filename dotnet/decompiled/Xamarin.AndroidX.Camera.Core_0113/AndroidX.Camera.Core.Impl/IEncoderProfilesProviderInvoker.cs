using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProvider", DoNotGenerateAcw = true)]
internal class IEncoderProfilesProviderInvoker : Java.Lang.Object, IEncoderProfilesProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProvider", typeof(IEncoderProfilesProviderInvoker));

	private nint class_ref;

	private static Delegate? cb_getAll_I;

	private nint id_getAll_I;

	private static Delegate? cb_hasProfile_I;

	private nint id_hasProfile_I;

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

	public static IEncoderProfilesProvider? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IEncoderProfilesProvider>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.EncoderProfilesProvider'.");
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

	public IEncoderProfilesProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetAll_IHandler()
	{
		if ((object)cb_getAll_I == null)
		{
			cb_getAll_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetAll_I));
		}
		return cb_getAll_I;
	}

	private static nint n_GetAll_I(nint jnienv, nint native__this, int p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEncoderProfilesProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAll(p0));
	}

	public unsafe IEncoderProfilesProxy? GetAll(int p0)
	{
		if (id_getAll_I == IntPtr.Zero)
		{
			id_getAll_I = JNIEnv.GetMethodID(class_ref, "getAll", "(I)Landroidx/camera/core/impl/EncoderProfilesProxy;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IEncoderProfilesProxy>(JNIEnv.CallObjectMethod(base.Handle, id_getAll_I, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetHasProfile_IHandler()
	{
		if ((object)cb_hasProfile_I == null)
		{
			cb_hasProfile_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPI_Z(n_HasProfile_I));
		}
		return cb_hasProfile_I;
	}

	private static bool n_HasProfile_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<IEncoderProfilesProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasProfile(p0);
	}

	public unsafe bool HasProfile(int p0)
	{
		if (id_hasProfile_I == IntPtr.Zero)
		{
			id_hasProfile_I = JNIEnv.GetMethodID(class_ref, "hasProfile", "(I)Z");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return JNIEnv.CallBooleanMethod(base.Handle, id_hasProfile_I, ptr);
	}
}

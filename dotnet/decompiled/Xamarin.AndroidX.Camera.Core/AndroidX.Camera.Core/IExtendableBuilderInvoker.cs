using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ExtendableBuilder", DoNotGenerateAcw = true)]
internal class IExtendableBuilderInvoker : Java.Lang.Object, IExtendableBuilder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ExtendableBuilder", typeof(IExtendableBuilderInvoker));

	private nint class_ref;

	private static Delegate? cb_getMutableConfig;

	private nint id_getMutableConfig;

	private static Delegate? cb_build;

	private nint id_build;

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

	public IMutableConfig MutableConfig
	{
		get
		{
			if (id_getMutableConfig == IntPtr.Zero)
			{
				id_getMutableConfig = JNIEnv.GetMethodID(class_ref, "getMutableConfig", "()Landroidx/camera/core/impl/MutableConfig;");
			}
			return Java.Lang.Object.GetObject<IMutableConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getMutableConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IExtendableBuilder? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IExtendableBuilder>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ExtendableBuilder'.");
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

	public IExtendableBuilderInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetMutableConfigHandler()
	{
		if ((object)cb_getMutableConfig == null)
		{
			cb_getMutableConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMutableConfig));
		}
		return cb_getMutableConfig;
	}

	private static nint n_GetMutableConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExtendableBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MutableConfig);
	}

	private static Delegate GetBuildHandler()
	{
		if ((object)cb_build == null)
		{
			cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
		}
		return cb_build;
	}

	private static nint n_Build(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExtendableBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
	}

	public Java.Lang.Object Build()
	{
		if (id_build == IntPtr.Zero)
		{
			id_build = JNIEnv.GetMethodID(class_ref, "build", "()Ljava/lang/Object;");
		}
		return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_build), JniHandleOwnership.TransferLocalRef);
	}
}

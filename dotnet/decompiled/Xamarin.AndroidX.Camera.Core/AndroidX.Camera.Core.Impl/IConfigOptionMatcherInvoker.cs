using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Config$OptionMatcher", DoNotGenerateAcw = true)]
internal class IConfigOptionMatcherInvoker : Java.Lang.Object, IConfigOptionMatcher, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Config$OptionMatcher", typeof(IConfigOptionMatcherInvoker));

	private nint class_ref;

	private static Delegate? cb_onOptionMatched_Landroidx_camera_core_impl_Config_Option_;

	private nint id_onOptionMatched_Landroidx_camera_core_impl_Config_Option_;

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

	public static IConfigOptionMatcher? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IConfigOptionMatcher>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.Config.OptionMatcher'.");
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

	public IConfigOptionMatcherInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetOnOptionMatched_Landroidx_camera_core_impl_Config_Option_Handler()
	{
		if ((object)cb_onOptionMatched_Landroidx_camera_core_impl_Config_Option_ == null)
		{
			cb_onOptionMatched_Landroidx_camera_core_impl_Config_Option_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnOptionMatched_Landroidx_camera_core_impl_Config_Option_));
		}
		return cb_onOptionMatched_Landroidx_camera_core_impl_Config_Option_;
	}

	private static bool n_OnOptionMatched_Landroidx_camera_core_impl_Config_Option_(nint jnienv, nint native__this, nint native_p0)
	{
		IConfigOptionMatcher? configOptionMatcher = Java.Lang.Object.GetObject<IConfigOptionMatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ConfigOption p = Java.Lang.Object.GetObject<ConfigOption>(native_p0, JniHandleOwnership.DoNotTransfer);
		return configOptionMatcher.OnOptionMatched(p);
	}

	public unsafe bool OnOptionMatched(ConfigOption p0)
	{
		if (id_onOptionMatched_Landroidx_camera_core_impl_Config_Option_ == IntPtr.Zero)
		{
			id_onOptionMatched_Landroidx_camera_core_impl_Config_Option_ = JNIEnv.GetMethodID(class_ref, "onOptionMatched", "(Landroidx/camera/core/impl/Config$Option;)Z");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return JNIEnv.CallBooleanMethod(base.Handle, id_onOptionMatched_Landroidx_camera_core_impl_Config_Option_, ptr);
	}
}

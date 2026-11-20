using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ImageInputConfig", "", "AndroidX.Camera.Core.Impl.IImageInputConfigInvoker")]
public interface IImageInputConfig : IReadableConfig, IConfig, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/ImageInputConfig", typeof(IImageInputConfig), isInterface: true);

	private static Delegate? cb_getDynamicRange;

	private static Delegate? cb_hasDynamicRange;

	private static Delegate? cb_getInputFormat;

	[Register("OPTION_INPUT_DYNAMIC_RANGE")]
	static ConfigOption? OptionInputDynamicRange => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_INPUT_DYNAMIC_RANGE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_INPUT_FORMAT")]
	static ConfigOption? OptionInputFormat => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_INPUT_FORMAT.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	unsafe DynamicRange DynamicRange
	{
		[Register("getDynamicRange", "()Landroidx/camera/core/DynamicRange;", "GetGetDynamicRangeHandler:AndroidX.Camera.Core.Impl.IImageInputConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<DynamicRange>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDynamicRange.()Landroidx/camera/core/DynamicRange;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe bool HasDynamicRange
	{
		[Register("hasDynamicRange", "()Z", "GetHasDynamicRangeHandler:AndroidX.Camera.Core.Impl.IImageInputConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDynamicRange.()Z", this, null);
		}
	}

	unsafe int InputFormat
	{
		[Register("getInputFormat", "()I", "GetGetInputFormatHandler:AndroidX.Camera.Core.Impl.IImageInputConfig, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInputFormat.()I", this, null);
		}
	}

	private static Delegate GetGetDynamicRangeHandler()
	{
		if ((object)cb_getDynamicRange == null)
		{
			cb_getDynamicRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDynamicRange));
		}
		return cb_getDynamicRange;
	}

	private static nint n_GetDynamicRange(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageInputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DynamicRange);
	}

	private static Delegate GetHasDynamicRangeHandler()
	{
		if ((object)cb_hasDynamicRange == null)
		{
			cb_hasDynamicRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasDynamicRange));
		}
		return cb_hasDynamicRange;
	}

	private static bool n_HasDynamicRange(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageInputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDynamicRange;
	}

	private static Delegate GetGetInputFormatHandler()
	{
		if ((object)cb_getInputFormat == null)
		{
			cb_getInputFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetInputFormat));
		}
		return cb_getInputFormat;
	}

	private static int n_GetInputFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageInputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputFormat;
	}
}

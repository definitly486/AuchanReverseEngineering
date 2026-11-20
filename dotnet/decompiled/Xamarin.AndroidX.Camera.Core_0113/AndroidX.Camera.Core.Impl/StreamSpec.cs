using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/StreamSpec", DoNotGenerateAcw = true)]
public abstract class StreamSpec : Java.Lang.Object
{
	[Register("androidx/camera/core/impl/StreamSpec$Builder", DoNotGenerateAcw = true)]
	public abstract class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/StreamSpec$Builder", typeof(Builder));

		private static Delegate? cb_build;

		private static Delegate? cb_setDynamicRange_Landroidx_camera_core_DynamicRange_;

		private static Delegate? cb_setExpectedFrameRateRange_Landroid_util_Range_;

		private static Delegate? cb_setImplementationOptions_Landroidx_camera_core_impl_Config_;

		private static Delegate? cb_setResolution_Landroid_util_Size_;

		private static Delegate? cb_setZslDisabled_Z;

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Landroidx/camera/core/impl/StreamSpec;", "GetBuildHandler")]
		public abstract StreamSpec Build();

		private static Delegate GetSetDynamicRange_Landroidx_camera_core_DynamicRange_Handler()
		{
			if ((object)cb_setDynamicRange_Landroidx_camera_core_DynamicRange_ == null)
			{
				cb_setDynamicRange_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetDynamicRange_Landroidx_camera_core_DynamicRange_));
			}
			return cb_setDynamicRange_Landroidx_camera_core_DynamicRange_;
		}

		private static nint n_SetDynamicRange_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_p0)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DynamicRange dynamicRange = Java.Lang.Object.GetObject<DynamicRange>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetDynamicRange(dynamicRange));
		}

		[Register("setDynamicRange", "(Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetDynamicRange_Landroidx_camera_core_DynamicRange_Handler")]
		public abstract Builder SetDynamicRange(DynamicRange p0);

		private static Delegate GetSetExpectedFrameRateRange_Landroid_util_Range_Handler()
		{
			if ((object)cb_setExpectedFrameRateRange_Landroid_util_Range_ == null)
			{
				cb_setExpectedFrameRateRange_Landroid_util_Range_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetExpectedFrameRateRange_Landroid_util_Range_));
			}
			return cb_setExpectedFrameRateRange_Landroid_util_Range_;
		}

		private static nint n_SetExpectedFrameRateRange_Landroid_util_Range_(nint jnienv, nint native__this, nint native_p0)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Util.Range expectedFrameRateRange = Java.Lang.Object.GetObject<Android.Util.Range>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetExpectedFrameRateRange(expectedFrameRateRange));
		}

		[Register("setExpectedFrameRateRange", "(Landroid/util/Range;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetExpectedFrameRateRange_Landroid_util_Range_Handler")]
		public abstract Builder SetExpectedFrameRateRange(Android.Util.Range p0);

		private static Delegate GetSetImplementationOptions_Landroidx_camera_core_impl_Config_Handler()
		{
			if ((object)cb_setImplementationOptions_Landroidx_camera_core_impl_Config_ == null)
			{
				cb_setImplementationOptions_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetImplementationOptions_Landroidx_camera_core_impl_Config_));
			}
			return cb_setImplementationOptions_Landroidx_camera_core_impl_Config_;
		}

		private static nint n_SetImplementationOptions_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_p0)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConfig implementationOptions = Java.Lang.Object.GetObject<IConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetImplementationOptions(implementationOptions));
		}

		[Register("setImplementationOptions", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetImplementationOptions_Landroidx_camera_core_impl_Config_Handler")]
		public abstract Builder SetImplementationOptions(IConfig p0);

		private static Delegate GetSetResolution_Landroid_util_Size_Handler()
		{
			if ((object)cb_setResolution_Landroid_util_Size_ == null)
			{
				cb_setResolution_Landroid_util_Size_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetResolution_Landroid_util_Size_));
			}
			return cb_setResolution_Landroid_util_Size_;
		}

		private static nint n_SetResolution_Landroid_util_Size_(nint jnienv, nint native__this, nint native_p0)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Size resolution = Java.Lang.Object.GetObject<Size>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetResolution(resolution));
		}

		[Register("setResolution", "(Landroid/util/Size;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetResolution_Landroid_util_Size_Handler")]
		public abstract Builder SetResolution(Size p0);

		private static Delegate GetSetZslDisabled_ZHandler()
		{
			if ((object)cb_setZslDisabled_Z == null)
			{
				cb_setZslDisabled_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_SetZslDisabled_Z));
			}
			return cb_setZslDisabled_Z;
		}

		private static nint n_SetZslDisabled_Z(nint jnienv, nint native__this, bool p0)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZslDisabled(p0));
		}

		[Register("setZslDisabled", "(Z)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetZslDisabled_ZHandler")]
		public abstract Builder SetZslDisabled(bool p0);
	}

	[Register("androidx/camera/core/impl/StreamSpec$Builder", DoNotGenerateAcw = true)]
	internal class BuilderInvoker : Builder
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/StreamSpec$Builder", typeof(BuilderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public BuilderInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("build", "()Landroidx/camera/core/impl/StreamSpec;", "GetBuildHandler")]
		public unsafe override StreamSpec Build()
		{
			return Java.Lang.Object.GetObject<StreamSpec>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroidx/camera/core/impl/StreamSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setDynamicRange", "(Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetDynamicRange_Landroidx_camera_core_DynamicRange_Handler")]
		public unsafe override Builder SetDynamicRange(DynamicRange p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDynamicRange.(Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/StreamSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("setExpectedFrameRateRange", "(Landroid/util/Range;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetExpectedFrameRateRange_Landroid_util_Range_Handler")]
		public unsafe override Builder SetExpectedFrameRateRange(Android.Util.Range p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExpectedFrameRateRange.(Landroid/util/Range;)Landroidx/camera/core/impl/StreamSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("setImplementationOptions", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetImplementationOptions_Landroidx_camera_core_impl_Config_Handler")]
		public unsafe override Builder SetImplementationOptions(IConfig p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setImplementationOptions.(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/StreamSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("setResolution", "(Landroid/util/Size;)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetResolution_Landroid_util_Size_Handler")]
		public unsafe override Builder SetResolution(Size p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setResolution.(Landroid/util/Size;)Landroidx/camera/core/impl/StreamSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("setZslDisabled", "(Z)Landroidx/camera/core/impl/StreamSpec$Builder;", "GetSetZslDisabled_ZHandler")]
		public unsafe override Builder SetZslDisabled(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setZslDisabled.(Z)Landroidx/camera/core/impl/StreamSpec$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/StreamSpec", typeof(StreamSpec));

	private static Delegate? cb_getDynamicRange;

	private static Delegate? cb_getExpectedFrameRateRange;

	private static Delegate? cb_getImplementationOptions;

	private static Delegate? cb_getResolution;

	private static Delegate? cb_getZslDisabled;

	private static Delegate? cb_toBuilder;

	[Register("FRAME_RATE_RANGE_UNSPECIFIED")]
	public static Android.Util.Range? FrameRateRangeUnspecified => Java.Lang.Object.GetObject<Android.Util.Range>(_members.StaticFields.GetObjectValue("FRAME_RATE_RANGE_UNSPECIFIED.Landroid/util/Range;").Handle, JniHandleOwnership.TransferLocalRef);

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract DynamicRange DynamicRange
	{
		[Register("getDynamicRange", "()Landroidx/camera/core/DynamicRange;", "GetGetDynamicRangeHandler")]
		get;
	}

	public abstract Android.Util.Range ExpectedFrameRateRange
	{
		[Register("getExpectedFrameRateRange", "()Landroid/util/Range;", "GetGetExpectedFrameRateRangeHandler")]
		get;
	}

	public abstract IConfig? ImplementationOptions
	{
		[Register("getImplementationOptions", "()Landroidx/camera/core/impl/Config;", "GetGetImplementationOptionsHandler")]
		get;
	}

	public abstract Size Resolution
	{
		[Register("getResolution", "()Landroid/util/Size;", "GetGetResolutionHandler")]
		get;
	}

	public abstract bool ZslDisabled
	{
		[Register("getZslDisabled", "()Z", "GetGetZslDisabledHandler")]
		get;
	}

	protected StreamSpec(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe StreamSpec()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StreamSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DynamicRange);
	}

	private static Delegate GetGetExpectedFrameRateRangeHandler()
	{
		if ((object)cb_getExpectedFrameRateRange == null)
		{
			cb_getExpectedFrameRateRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExpectedFrameRateRange));
		}
		return cb_getExpectedFrameRateRange;
	}

	private static nint n_GetExpectedFrameRateRange(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StreamSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpectedFrameRateRange);
	}

	private static Delegate GetGetImplementationOptionsHandler()
	{
		if ((object)cb_getImplementationOptions == null)
		{
			cb_getImplementationOptions = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImplementationOptions));
		}
		return cb_getImplementationOptions;
	}

	private static nint n_GetImplementationOptions(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StreamSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImplementationOptions);
	}

	private static Delegate GetGetResolutionHandler()
	{
		if ((object)cb_getResolution == null)
		{
			cb_getResolution = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetResolution));
		}
		return cb_getResolution;
	}

	private static nint n_GetResolution(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StreamSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resolution);
	}

	private static Delegate GetGetZslDisabledHandler()
	{
		if ((object)cb_getZslDisabled == null)
		{
			cb_getZslDisabled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetZslDisabled));
		}
		return cb_getZslDisabled;
	}

	private static bool n_GetZslDisabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<StreamSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZslDisabled;
	}

	[Register("builder", "(Landroid/util/Size;)Landroidx/camera/core/impl/StreamSpec$Builder;", "")]
	public unsafe static Builder InvokeBuilder(Size resolution)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resolution?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.(Landroid/util/Size;)Landroidx/camera/core/impl/StreamSpec$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resolution);
		}
	}

	private static Delegate GetToBuilderHandler()
	{
		if ((object)cb_toBuilder == null)
		{
			cb_toBuilder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToBuilder));
		}
		return cb_toBuilder;
	}

	private static nint n_ToBuilder(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StreamSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBuilder());
	}

	[Register("toBuilder", "()Landroidx/camera/core/impl/StreamSpec$Builder;", "GetToBuilderHandler")]
	public abstract Builder ToBuilder();
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CaptureConfig", DoNotGenerateAcw = true)]
public sealed class CaptureConfig : Java.Lang.Object
{
	[Register("androidx/camera/core/impl/CaptureConfig$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CaptureConfig$Builder", typeof(Builder));

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

		public unsafe Android.Util.Range? ExpectedFrameRateRange
		{
			[Register("getExpectedFrameRateRange", "()Landroid/util/Range;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExpectedFrameRateRange.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setExpectedFrameRateRange", "(Landroid/util/Range;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setExpectedFrameRateRange.(Landroid/util/Range;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe IConfig ImplementationOptions
		{
			[Register("getImplementationOptions", "()Landroidx/camera/core/impl/Config;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImplementationOptions.()Landroidx/camera/core/impl/Config;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setImplementationOptions", "(Landroidx/camera/core/impl/Config;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setImplementationOptions.(Landroidx/camera/core/impl/Config;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe ICollection<DeferrableSurface> Surfaces
		{
			[Register("getSurfaces", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<DeferrableSurface>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSurfaces.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int TemplateType
		{
			[Register("getTemplateType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getTemplateType.()I", this, null);
			}
			[Register("setTemplateType", "(I)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTemplateType.(I)V", this, ptr);
			}
		}

		public unsafe bool UseRepeatingSurface
		{
			[Register("isUseRepeatingSurface", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isUseRepeatingSurface.()Z", this, null);
			}
			[Register("setUseRepeatingSurface", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setUseRepeatingSurface.(Z)V", this, ptr);
			}
		}

		internal Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Builder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("addAllCameraCaptureCallbacks", "(Ljava/util/Collection;)V", "")]
		public unsafe void AddAllCameraCaptureCallbacks(ICollection<CameraCaptureCallback> cameraCaptureCallbacks)
		{
			nint num = JavaCollection<CameraCaptureCallback>.ToLocalJniHandle(cameraCaptureCallbacks);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addAllCameraCaptureCallbacks.(Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(cameraCaptureCallbacks);
			}
		}

		[Register("addAllTags", "(Landroidx/camera/core/impl/TagBundle;)V", "")]
		public unsafe void AddAllTags(TagBundle bundle)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addAllTags.(Landroidx/camera/core/impl/TagBundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bundle);
			}
		}

		[Register("addCameraCaptureCallback", "(Landroidx/camera/core/impl/CameraCaptureCallback;)V", "")]
		public unsafe void AddCameraCaptureCallback(CameraCaptureCallback cameraCaptureCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cameraCaptureCallback?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addCameraCaptureCallback.(Landroidx/camera/core/impl/CameraCaptureCallback;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cameraCaptureCallback);
			}
		}

		[Register("addImplementationOption", "(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe void AddImplementationOption(ConfigOption option, Java.Lang.Object value)
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(option?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addImplementationOption.(Landroidx/camera/core/impl/Config$Option;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(option);
				GC.KeepAlive(value);
			}
		}

		[Register("addImplementationOptions", "(Landroidx/camera/core/impl/Config;)V", "")]
		public unsafe void AddImplementationOptions(IConfig config)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addImplementationOptions.(Landroidx/camera/core/impl/Config;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(config);
			}
		}

		[Register("addSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)V", "")]
		public unsafe void AddSurface(DeferrableSurface surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addSurface.(Landroidx/camera/core/impl/DeferrableSurface;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		[Register("addTag", "(Ljava/lang/String;Ljava/lang/Object;)V", "")]
		public unsafe void AddTag(string key, Java.Lang.Object tag)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("addTag.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(tag);
			}
		}

		[Register("build", "()Landroidx/camera/core/impl/CaptureConfig;", "")]
		public unsafe CaptureConfig Build()
		{
			return Java.Lang.Object.GetObject<CaptureConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroidx/camera/core/impl/CaptureConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("clearSurfaces", "()V", "")]
		public unsafe void ClearSurfaces()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("clearSurfaces.()V", this, null);
		}

		[Register("createFrom", "(Landroidx/camera/core/impl/UseCaseConfig;)Landroidx/camera/core/impl/CaptureConfig$Builder;", "")]
		public unsafe static Builder CreateFrom(IUseCaseConfig config)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("createFrom.(Landroidx/camera/core/impl/UseCaseConfig;)Landroidx/camera/core/impl/CaptureConfig$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(config);
			}
		}

		[Register("from", "(Landroidx/camera/core/impl/CaptureConfig;)Landroidx/camera/core/impl/CaptureConfig$Builder;", "")]
		public unsafe static Builder From(CaptureConfig @base)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@base?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("from.(Landroidx/camera/core/impl/CaptureConfig;)Landroidx/camera/core/impl/CaptureConfig$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(@base);
			}
		}

		[Register("getTag", "(Ljava/lang/String;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object? GetTag(string key)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTag.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("removeCameraCaptureCallback", "(Landroidx/camera/core/impl/CameraCaptureCallback;)Z", "")]
		public unsafe bool RemoveCameraCaptureCallback(CameraCaptureCallback cameraCaptureCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cameraCaptureCallback?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("removeCameraCaptureCallback.(Landroidx/camera/core/impl/CameraCaptureCallback;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cameraCaptureCallback);
			}
		}

		[Register("removeSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)V", "")]
		public unsafe void RemoveSurface(DeferrableSurface surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("removeSurface.(Landroidx/camera/core/impl/DeferrableSurface;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		[Register("setCameraCaptureResult", "(Landroidx/camera/core/impl/CameraCaptureResult;)V", "")]
		public unsafe void SetCameraCaptureResult(ICameraCaptureResult cameraCaptureResult)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cameraCaptureResult == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraCaptureResult).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setCameraCaptureResult.(Landroidx/camera/core/impl/CameraCaptureResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cameraCaptureResult);
			}
		}

		[Register("setId", "(I)V", "")]
		public unsafe void SetId(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setId.(I)V", this, ptr);
		}

		[Register("setPostviewEnabled", "(Z)V", "")]
		public unsafe void SetPostviewEnabled(bool postviewEnabled)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(postviewEnabled);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setPostviewEnabled.(Z)V", this, ptr);
		}

		[Register("setPreviewStabilization", "(I)V", "")]
		public unsafe void SetPreviewStabilization(int mode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setPreviewStabilization.(I)V", this, ptr);
		}

		[Register("setVideoStabilization", "(I)V", "")]
		public unsafe void SetVideoStabilization(int mode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setVideoStabilization.(I)V", this, ptr);
		}
	}

	[Register("androidx/camera/core/impl/CaptureConfig$OptionUnpacker", "", "AndroidX.Camera.Core.Impl.CaptureConfig/IOptionUnpackerInvoker")]
	public interface IOptionUnpacker : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("unpack", "(Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/CaptureConfig$Builder;)V", "GetUnpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_Handler:AndroidX.Camera.Core.Impl.CaptureConfig/IOptionUnpackerInvoker, Xamarin.AndroidX.Camera.Core")]
		void Unpack(IUseCaseConfig p0, Builder p1);
	}

	[Register("androidx/camera/core/impl/CaptureConfig$OptionUnpacker", DoNotGenerateAcw = true)]
	internal class IOptionUnpackerInvoker : Java.Lang.Object, IOptionUnpacker, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CaptureConfig$OptionUnpacker", typeof(IOptionUnpackerInvoker));

		private nint class_ref;

		private static Delegate? cb_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_;

		private nint id_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_;

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

		public static IOptionUnpacker? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOptionUnpacker>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.CaptureConfig.OptionUnpacker'.");
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

		public IOptionUnpackerInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetUnpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_Handler()
		{
			if ((object)cb_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_ == null)
			{
				cb_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_));
			}
			return cb_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_;
		}

		private static void n_Unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
		{
			IOptionUnpacker? optionUnpacker = Java.Lang.Object.GetObject<IOptionUnpacker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IUseCaseConfig p = Java.Lang.Object.GetObject<IUseCaseConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
			Builder p2 = Java.Lang.Object.GetObject<Builder>(native_p1, JniHandleOwnership.DoNotTransfer);
			optionUnpacker.Unpack(p, p2);
		}

		public unsafe void Unpack(IUseCaseConfig p0, Builder p1)
		{
			if (id_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_ == IntPtr.Zero)
			{
				id_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_ = JNIEnv.GetMethodID(class_ref, "unpack", "(Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/CaptureConfig$Builder;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_unpack_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_CaptureConfig_Builder_, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CaptureConfig", typeof(CaptureConfig));

	[Register("OPTION_JPEG_QUALITY")]
	public static ConfigOption? OptionJpegQuality => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_JPEG_QUALITY.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_ROTATION")]
	public static ConfigOption? OptionRotation => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_ROTATION.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe IList<CameraCaptureCallback> CameraCaptureCallbacks
	{
		[Register("getCameraCaptureCallbacks", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<CameraCaptureCallback>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getCameraCaptureCallbacks.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ICameraCaptureResult? CameraCaptureResult
	{
		[Register("getCameraCaptureResult", "()Landroidx/camera/core/impl/CameraCaptureResult;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraCaptureResult>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCameraCaptureResult.()Landroidx/camera/core/impl/CameraCaptureResult;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Android.Util.Range ExpectedFrameRateRange
	{
		[Register("getExpectedFrameRateRange", "()Landroid/util/Range;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExpectedFrameRateRange.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int Id
	{
		[Register("getId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getId.()I", this, null);
		}
	}

	public unsafe IConfig ImplementationOptions
	{
		[Register("getImplementationOptions", "()Landroidx/camera/core/impl/Config;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImplementationOptions.()Landroidx/camera/core/impl/Config;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsPostviewEnabled
	{
		[Register("isPostviewEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isPostviewEnabled.()Z", this, null);
		}
	}

	public unsafe bool IsUseRepeatingSurface
	{
		[Register("isUseRepeatingSurface", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isUseRepeatingSurface.()Z", this, null);
		}
	}

	public unsafe int PreviewStabilizationMode
	{
		[Register("getPreviewStabilizationMode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getPreviewStabilizationMode.()I", this, null);
		}
	}

	public unsafe IList<DeferrableSurface> Surfaces
	{
		[Register("getSurfaces", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<DeferrableSurface>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSurfaces.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe TagBundle TagBundle
	{
		[Register("getTagBundle", "()Landroidx/camera/core/impl/TagBundle;", "")]
		get
		{
			return Java.Lang.Object.GetObject<TagBundle>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTagBundle.()Landroidx/camera/core/impl/TagBundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int TemplateType
	{
		[Register("getTemplateType", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getTemplateType.()I", this, null);
		}
	}

	public unsafe int VideoStabilizationMode
	{
		[Register("getVideoStabilizationMode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getVideoStabilizationMode.()I", this, null);
		}
	}

	internal CaptureConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("defaultEmptyCaptureConfig", "()Landroidx/camera/core/impl/CaptureConfig;", "")]
	public unsafe static CaptureConfig DefaultEmptyCaptureConfig()
	{
		return Java.Lang.Object.GetObject<CaptureConfig>(_members.StaticMethods.InvokeObjectMethod("defaultEmptyCaptureConfig.()Landroidx/camera/core/impl/CaptureConfig;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}

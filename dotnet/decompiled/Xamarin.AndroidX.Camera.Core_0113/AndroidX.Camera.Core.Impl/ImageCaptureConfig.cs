using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.ResolutionSelector;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ImageCaptureConfig", DoNotGenerateAcw = true)]
public sealed class ImageCaptureConfig : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/ImageCaptureConfig", typeof(ImageCaptureConfig));

	[Register("OPTION_BUFFER_FORMAT")]
	public static ConfigOption? OptionBufferFormat => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_BUFFER_FORMAT.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_CAPTURE_BUNDLE")]
	public static ConfigOption? OptionCaptureBundle => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_CAPTURE_BUNDLE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_FLASH_MODE")]
	public static ConfigOption? OptionFlashMode => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_FLASH_MODE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_FLASH_TYPE")]
	public static ConfigOption? OptionFlashType => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_FLASH_TYPE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_IMAGE_CAPTURE_MODE")]
	public static ConfigOption? OptionImageCaptureMode => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_IMAGE_CAPTURE_MODE.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_IMAGE_READER_PROXY_PROVIDER")]
	public static ConfigOption? OptionImageReaderProxyProvider => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_IMAGE_READER_PROXY_PROVIDER.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_JPEG_COMPRESSION_QUALITY")]
	public static ConfigOption? OptionJpegCompressionQuality => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_JPEG_COMPRESSION_QUALITY.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_MAX_CAPTURE_STAGES")]
	public static ConfigOption? OptionMaxCaptureStages => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_MAX_CAPTURE_STAGES.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_OUTPUT_FORMAT")]
	public static ConfigOption? OptionOutputFormat => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_OUTPUT_FORMAT.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_POSTVIEW_ENABLED")]
	public static ConfigOption? OptionPostviewEnabled => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_POSTVIEW_ENABLED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_POSTVIEW_RESOLUTION_SELECTOR")]
	public static ConfigOption? OptionPostviewResolutionSelector => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_POSTVIEW_RESOLUTION_SELECTOR.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_SCREEN_FLASH")]
	public static ConfigOption? OptionScreenFlash => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_SCREEN_FLASH.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_USE_SOFTWARE_JPEG_ENCODER")]
	public static ConfigOption? OptionUseSoftwareJpegEncoder => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_USE_SOFTWARE_JPEG_ENCODER.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe Integer BufferFormat
	{
		[Register("getBufferFormat", "()Ljava/lang/Integer;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBufferFormat.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ICaptureBundle CaptureBundle
	{
		[Register("getCaptureBundle", "()Landroidx/camera/core/impl/CaptureBundle;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICaptureBundle>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCaptureBundle.()Landroidx/camera/core/impl/CaptureBundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int CaptureMode
	{
		[Register("getCaptureMode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getCaptureMode.()I", this, null);
		}
	}

	public unsafe IConfig Config
	{
		[Register("getConfig", "()Landroidx/camera/core/impl/Config;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConfig.()Landroidx/camera/core/impl/Config;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int FlashMode
	{
		[Register("getFlashMode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getFlashMode.()I", this, null);
		}
	}

	public unsafe int FlashType
	{
		[Register("getFlashType", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getFlashType.()I", this, null);
		}
	}

	public unsafe bool HasCaptureMode
	{
		[Register("hasCaptureMode", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasCaptureMode.()Z", this, null);
		}
	}

	public unsafe IImageReaderProxyProvider? ImageReaderProxyProvider
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getImageReaderProxyProvider", "()Landroidx/camera/core/ImageReaderProxyProvider;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IImageReaderProxyProvider>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImageReaderProxyProvider.()Landroidx/camera/core/ImageReaderProxyProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int InputFormat
	{
		[Register("getInputFormat", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getInputFormat.()I", this, null);
		}
	}

	public unsafe IExecutor IoExecutor
	{
		[Register("getIoExecutor", "()Ljava/util/concurrent/Executor;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIoExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe bool IsSoftwareJpegEncoderRequested
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isSoftwareJpegEncoderRequested", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isSoftwareJpegEncoderRequested.()Z", this, null);
		}
	}

	public unsafe int JpegQuality
	{
		[Register("getJpegQuality", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getJpegQuality.()I", this, null);
		}
	}

	public unsafe int MaxCaptureStages
	{
		[Register("getMaxCaptureStages", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxCaptureStages.()I", this, null);
		}
	}

	public unsafe AndroidX.Camera.Core.ResolutionSelector.ResolutionSelector? PostviewResolutionSelector
	{
		[Register("getPostviewResolutionSelector", "()Landroidx/camera/core/resolutionselector/ResolutionSelector;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Camera.Core.ResolutionSelector.ResolutionSelector>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPostviewResolutionSelector.()Landroidx/camera/core/resolutionselector/ResolutionSelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ImageCapture.IScreenFlash? ScreenFlash
	{
		[Register("getScreenFlash", "()Landroidx/camera/core/ImageCapture$ScreenFlash;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ImageCapture.IScreenFlash>(_members.InstanceMethods.InvokeAbstractObjectMethod("getScreenFlash.()Landroidx/camera/core/ImageCapture$ScreenFlash;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal ImageCaptureConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/camera/core/impl/OptionsBundle;)V", "")]
	public unsafe ImageCaptureConfig(OptionsBundle config)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/camera/core/impl/OptionsBundle;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/camera/core/impl/OptionsBundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(config);
		}
	}

	[Register("getBufferFormat", "(Ljava/lang/Integer;)Ljava/lang/Integer;", "")]
	public unsafe Integer? GetBufferFormat(Integer? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(valueIfMissing?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBufferFormat.(Ljava/lang/Integer;)Ljava/lang/Integer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	[Register("getCaptureBundle", "(Landroidx/camera/core/impl/CaptureBundle;)Landroidx/camera/core/impl/CaptureBundle;", "")]
	public unsafe ICaptureBundle? GetCaptureBundle(ICaptureBundle? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((valueIfMissing == null) ? IntPtr.Zero : ((Java.Lang.Object)valueIfMissing).Handle);
			return Java.Lang.Object.GetObject<ICaptureBundle>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCaptureBundle.(Landroidx/camera/core/impl/CaptureBundle;)Landroidx/camera/core/impl/CaptureBundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	[Register("getFlashMode", "(I)I", "")]
	public unsafe int GetFlashMode(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getFlashMode.(I)I", this, ptr);
	}

	[Register("getFlashType", "(I)I", "")]
	public unsafe int GetFlashType(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getFlashType.(I)I", this, ptr);
	}

	[Register("getIoExecutor", "(Ljava/util/concurrent/Executor;)Ljava/util/concurrent/Executor;", "")]
	public unsafe IExecutor? GetIoExecutor(IExecutor? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((valueIfMissing == null) ? IntPtr.Zero : ((Java.Lang.Object)valueIfMissing).Handle);
			return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIoExecutor.(Ljava/util/concurrent/Executor;)Ljava/util/concurrent/Executor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	[Register("getJpegQuality", "(I)I", "")]
	public unsafe int GetJpegQuality(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getJpegQuality.(I)I", this, ptr);
	}

	[Register("getMaxCaptureStages", "(I)I", "")]
	public unsafe int GetMaxCaptureStages(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxCaptureStages.(I)I", this, ptr);
	}
}

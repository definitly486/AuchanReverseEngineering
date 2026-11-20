using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ImageAnalysisConfig", DoNotGenerateAcw = true)]
public sealed class ImageAnalysisConfig : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/ImageAnalysisConfig", typeof(ImageAnalysisConfig));

	[Register("OPTION_BACKPRESSURE_STRATEGY")]
	public static ConfigOption? OptionBackpressureStrategy => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_BACKPRESSURE_STRATEGY.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_IMAGE_QUEUE_DEPTH")]
	public static ConfigOption? OptionImageQueueDepth => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_IMAGE_QUEUE_DEPTH.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_IMAGE_READER_PROXY_PROVIDER")]
	public static ConfigOption? OptionImageReaderProxyProvider => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_IMAGE_READER_PROXY_PROVIDER.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_ONE_PIXEL_SHIFT_ENABLED")]
	public static ConfigOption? OptionOnePixelShiftEnabled => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_ONE_PIXEL_SHIFT_ENABLED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_OUTPUT_IMAGE_FORMAT")]
	public static ConfigOption? OptionOutputImageFormat => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_OUTPUT_IMAGE_FORMAT.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OPTION_OUTPUT_IMAGE_ROTATION_ENABLED")]
	public static ConfigOption? OptionOutputImageRotationEnabled => Java.Lang.Object.GetObject<ConfigOption>(_members.StaticFields.GetObjectValue("OPTION_OUTPUT_IMAGE_ROTATION_ENABLED.Landroidx/camera/core/impl/Config$Option;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe int BackpressureStrategy
	{
		[Register("getBackpressureStrategy", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBackpressureStrategy.()I", this, null);
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

	public unsafe int ImageQueueDepth
	{
		[Register("getImageQueueDepth", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getImageQueueDepth.()I", this, null);
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

	internal ImageAnalysisConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/camera/core/impl/OptionsBundle;)V", "")]
	public unsafe ImageAnalysisConfig(OptionsBundle config)
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

	[Register("getBackpressureStrategy", "(I)I", "")]
	public unsafe int GetBackpressureStrategy(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getBackpressureStrategy.(I)I", this, ptr);
	}

	[Register("getImageQueueDepth", "(I)I", "")]
	public unsafe int GetImageQueueDepth(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getImageQueueDepth.(I)I", this, ptr);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getOnePixelShiftEnabled", "(Ljava/lang/Boolean;)Ljava/lang/Boolean;", "")]
	public unsafe Java.Lang.Boolean? GetOnePixelShiftEnabled(Java.Lang.Boolean? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(valueIfMissing?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOnePixelShiftEnabled.(Ljava/lang/Boolean;)Ljava/lang/Boolean;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}

	[Register("getOutputImageFormat", "(I)I", "")]
	public unsafe int GetOutputImageFormat(int valueIfMissing)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(valueIfMissing);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getOutputImageFormat.(I)I", this, ptr);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isOutputImageRotationEnabled", "(Ljava/lang/Boolean;)Ljava/lang/Boolean;", "")]
	public unsafe Java.Lang.Boolean? IsOutputImageRotationEnabled(Java.Lang.Boolean? valueIfMissing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(valueIfMissing?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("isOutputImageRotationEnabled.(Ljava/lang/Boolean;)Ljava/lang/Boolean;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(valueIfMissing);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core.Impl;
using AndroidX.Camera.Core.ResolutionSelector;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageAnalysis", DoNotGenerateAcw = true)]
public sealed class ImageAnalysis : UseCase
{
	[Register("androidx/camera/core/ImageAnalysis$Analyzer", "", "AndroidX.Camera.Core.ImageAnalysis/IAnalyzerInvoker")]
	public interface IAnalyzer : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageAnalysis$Analyzer", typeof(IAnalyzer), isInterface: true);

		private static Delegate? cb_getDefaultTargetResolution;

		private static Delegate? cb_getTargetCoordinateSystem;

		private static Delegate? cb_updateTransform_Landroid_graphics_Matrix_;

		unsafe Size? DefaultTargetResolution
		{
			[Register("getDefaultTargetResolution", "()Landroid/util/Size;", "GetGetDefaultTargetResolutionHandler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzer, Xamarin.AndroidX.Camera.Core")]
			get
			{
				return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultTargetResolution.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		unsafe int TargetCoordinateSystem
		{
			[Register("getTargetCoordinateSystem", "()I", "GetGetTargetCoordinateSystemHandler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzer, Xamarin.AndroidX.Camera.Core")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTargetCoordinateSystem.()I", this, null);
			}
		}

		private static Delegate GetGetDefaultTargetResolutionHandler()
		{
			if ((object)cb_getDefaultTargetResolution == null)
			{
				cb_getDefaultTargetResolution = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDefaultTargetResolution));
			}
			return cb_getDefaultTargetResolution;
		}

		private static nint n_GetDefaultTargetResolution(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IAnalyzer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultTargetResolution);
		}

		private static Delegate GetGetTargetCoordinateSystemHandler()
		{
			if ((object)cb_getTargetCoordinateSystem == null)
			{
				cb_getTargetCoordinateSystem = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargetCoordinateSystem));
			}
			return cb_getTargetCoordinateSystem;
		}

		private static int n_GetTargetCoordinateSystem(nint jnienv, nint native__this)
		{
			return Java.Lang.Object.GetObject<IAnalyzer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetCoordinateSystem;
		}

		[Register("analyze", "(Landroidx/camera/core/ImageProxy;)V", "GetAnalyze_Landroidx_camera_core_ImageProxy_Handler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzerInvoker, Xamarin.AndroidX.Camera.Core")]
		void Analyze(IImageProxy p0);

		private static Delegate GetUpdateTransform_Landroid_graphics_Matrix_Handler()
		{
			if ((object)cb_updateTransform_Landroid_graphics_Matrix_ == null)
			{
				cb_updateTransform_Landroid_graphics_Matrix_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateTransform_Landroid_graphics_Matrix_));
			}
			return cb_updateTransform_Landroid_graphics_Matrix_;
		}

		private static void n_UpdateTransform_Landroid_graphics_Matrix_(nint jnienv, nint native__this, nint native_matrix)
		{
			IAnalyzer? analyzer = Java.Lang.Object.GetObject<IAnalyzer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Matrix matrix = Java.Lang.Object.GetObject<Matrix>(native_matrix, JniHandleOwnership.DoNotTransfer);
			analyzer.UpdateTransform(matrix);
		}

		[Register("updateTransform", "(Landroid/graphics/Matrix;)V", "GetUpdateTransform_Landroid_graphics_Matrix_Handler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzer, Xamarin.AndroidX.Camera.Core")]
		unsafe void UpdateTransform(Matrix? matrix)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateTransform.(Landroid/graphics/Matrix;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(matrix);
			}
		}
	}

	[Register("androidx/camera/core/ImageAnalysis$Analyzer", DoNotGenerateAcw = true)]
	internal class IAnalyzerInvoker : Java.Lang.Object, IAnalyzer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageAnalysis$Analyzer", typeof(IAnalyzerInvoker));

		private nint class_ref;

		private static Delegate? cb_analyze_Landroidx_camera_core_ImageProxy_;

		private nint id_analyze_Landroidx_camera_core_ImageProxy_;

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

		public static IAnalyzer? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IAnalyzer>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageAnalysis.Analyzer'.");
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

		public IAnalyzerInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAnalyze_Landroidx_camera_core_ImageProxy_Handler()
		{
			if ((object)cb_analyze_Landroidx_camera_core_ImageProxy_ == null)
			{
				cb_analyze_Landroidx_camera_core_ImageProxy_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Analyze_Landroidx_camera_core_ImageProxy_));
			}
			return cb_analyze_Landroidx_camera_core_ImageProxy_;
		}

		private static void n_Analyze_Landroidx_camera_core_ImageProxy_(nint jnienv, nint native__this, nint native_p0)
		{
			IAnalyzer? analyzer = Java.Lang.Object.GetObject<IAnalyzer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IImageProxy p = Java.Lang.Object.GetObject<IImageProxy>(native_p0, JniHandleOwnership.DoNotTransfer);
			analyzer.Analyze(p);
		}

		public unsafe void Analyze(IImageProxy p0)
		{
			if (id_analyze_Landroidx_camera_core_ImageProxy_ == IntPtr.Zero)
			{
				id_analyze_Landroidx_camera_core_ImageProxy_ = JNIEnv.GetMethodID(class_ref, "analyze", "(Landroidx/camera/core/ImageProxy;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_analyze_Landroidx_camera_core_ImageProxy_, ptr);
		}
	}

	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/camera/core/ImageAnalysis$Defaults", DoNotGenerateAcw = true)]
	public sealed class Defaults : Java.Lang.Object, IConfigProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageAnalysis$Defaults", typeof(Defaults));

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

		public unsafe ImageAnalysisConfig Config
		{
			[Register("getConfig", "()Landroidx/camera/core/impl/ImageAnalysisConfig;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ImageAnalysisConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConfig.()Landroidx/camera/core/impl/ImageAnalysisConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		Java.Lang.Object IConfigProvider.Config
		{
			[Register("getConfig", "()Landroidx/camera/core/impl/Config;", "GetGetConfigHandler:AndroidX.Camera.Core.Impl.IConfigProviderInvoker, Xamarin.AndroidX.Camera.Core")]
			get
			{
				return Config;
			}
		}

		internal Defaults(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Defaults()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageAnalysis", typeof(ImageAnalysis));

	[Register("DEFAULT_CONFIG")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public static Defaults? DefaultConfig => Java.Lang.Object.GetObject<Defaults>(_members.StaticFields.GetObjectValue("DEFAULT_CONFIG.Landroidx/camera/core/ImageAnalysis$Defaults;").Handle, JniHandleOwnership.TransferLocalRef);

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe IExecutor? BackgroundExecutor
	{
		[Register("getBackgroundExecutor", "()Ljava/util/concurrent/Executor;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBackgroundExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int BackpressureStrategy
	{
		[Register("getBackpressureStrategy", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBackpressureStrategy.()I", this, null);
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

	public unsafe bool IsOutputImageRotationEnabled
	{
		[Register("isOutputImageRotationEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isOutputImageRotationEnabled.()Z", this, null);
		}
	}

	public unsafe Java.Lang.Boolean? OnePixelShiftEnabled
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getOnePixelShiftEnabled", "()Ljava/lang/Boolean;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOnePixelShiftEnabled.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int OutputImageFormat
	{
		[Register("getOutputImageFormat", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getOutputImageFormat.()I", this, null);
		}
	}

	public unsafe ResolutionInfo? ResolutionInfo
	{
		[Register("getResolutionInfo", "()Landroidx/camera/core/ResolutionInfo;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ResolutionInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolutionInfo.()Landroidx/camera/core/ResolutionInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe AndroidX.Camera.Core.ResolutionSelector.ResolutionSelector? ResolutionSelector
	{
		[Register("getResolutionSelector", "()Landroidx/camera/core/resolutionselector/ResolutionSelector;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Camera.Core.ResolutionSelector.ResolutionSelector>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolutionSelector.()Landroidx/camera/core/resolutionselector/ResolutionSelector;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int TargetRotation
	{
		[Register("getTargetRotation", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getTargetRotation.()I", this, null);
		}
		[Register("setTargetRotation", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setTargetRotation.(I)V", this, ptr);
		}
	}

	internal ImageAnalysis(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("clearAnalyzer", "()V", "")]
	public unsafe void ClearAnalyzer()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("clearAnalyzer.()V", this, null);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getDefaultConfig", "(ZLandroidx/camera/core/impl/UseCaseConfigFactory;)Landroidx/camera/core/impl/UseCaseConfig;", "")]
	public unsafe override IUseCaseConfig? GetDefaultConfig(bool applyDefaultConfig, IUseCaseConfigFactory factory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(applyDefaultConfig);
			ptr[1] = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			return Java.Lang.Object.GetObject<IUseCaseConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDefaultConfig.(ZLandroidx/camera/core/impl/UseCaseConfigFactory;)Landroidx/camera/core/impl/UseCaseConfig;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(factory);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getUseCaseConfigBuilder", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/UseCaseConfig$Builder;", "")]
	public unsafe override IUseCaseConfigBuilder GetUseCaseConfigBuilder(IConfig config)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
			return Java.Lang.Object.GetObject<IUseCaseConfigBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("getUseCaseConfigBuilder.(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/UseCaseConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(config);
		}
	}

	[Register("setAnalyzer", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageAnalysis$Analyzer;)V", "")]
	public unsafe void SetAnalyzer(IExecutor executor, IAnalyzer analyzer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((analyzer == null) ? IntPtr.Zero : ((Java.Lang.Object)analyzer).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setAnalyzer.(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageAnalysis$Analyzer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(analyzer);
		}
	}
}

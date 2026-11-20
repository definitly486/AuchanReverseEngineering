using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core.Impl;
using AndroidX.Camera.Core.Processing;
using AndroidX.Camera.Core.ResolutionSelector;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/Preview", DoNotGenerateAcw = true)]
public sealed class Preview : UseCase
{
	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/camera/core/Preview$Defaults", DoNotGenerateAcw = true)]
	public sealed class Defaults : Java.Lang.Object, IConfigProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/Preview$Defaults", typeof(Defaults));

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

		public unsafe PreviewConfig Config
		{
			[Register("getConfig", "()Landroidx/camera/core/impl/PreviewConfig;", "")]
			get
			{
				return Java.Lang.Object.GetObject<PreviewConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConfig.()Landroidx/camera/core/impl/PreviewConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	[Register("androidx/camera/core/Preview$SurfaceProvider", "", "AndroidX.Camera.Core.Preview/ISurfaceProviderInvoker")]
	public interface ISurfaceProvider : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSurfaceRequested", "(Landroidx/camera/core/SurfaceRequest;)V", "GetOnSurfaceRequested_Landroidx_camera_core_SurfaceRequest_Handler:AndroidX.Camera.Core.Preview/ISurfaceProviderInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnSurfaceRequested(SurfaceRequest p0);
	}

	[Register("androidx/camera/core/Preview$SurfaceProvider", DoNotGenerateAcw = true)]
	internal class ISurfaceProviderInvoker : Java.Lang.Object, ISurfaceProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/Preview$SurfaceProvider", typeof(ISurfaceProviderInvoker));

		private nint class_ref;

		private static Delegate? cb_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_;

		private nint id_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_;

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

		public static ISurfaceProvider? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISurfaceProvider>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.Preview.SurfaceProvider'.");
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

		public ISurfaceProviderInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnSurfaceRequested_Landroidx_camera_core_SurfaceRequest_Handler()
		{
			if ((object)cb_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_ == null)
			{
				cb_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnSurfaceRequested_Landroidx_camera_core_SurfaceRequest_));
			}
			return cb_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_;
		}

		private static void n_OnSurfaceRequested_Landroidx_camera_core_SurfaceRequest_(nint jnienv, nint native__this, nint native_p0)
		{
			ISurfaceProvider? surfaceProvider = Java.Lang.Object.GetObject<ISurfaceProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SurfaceRequest p = Java.Lang.Object.GetObject<SurfaceRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
			surfaceProvider.OnSurfaceRequested(p);
		}

		public unsafe void OnSurfaceRequested(SurfaceRequest p0)
		{
			if (id_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_ == IntPtr.Zero)
			{
				id_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_ = JNIEnv.GetMethodID(class_ref, "onSurfaceRequested", "(Landroidx/camera/core/SurfaceRequest;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onSurfaceRequested_Landroidx_camera_core_SurfaceRequest_, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/Preview", typeof(Preview));

	[Register("DEFAULT_CONFIG")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public static Defaults? DefaultConfig => Java.Lang.Object.GetObject<Defaults>(_members.StaticFields.GetObjectValue("DEFAULT_CONFIG.Landroidx/camera/core/Preview$Defaults;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe SurfaceEdge CameraEdge
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getCameraEdge", "()Landroidx/camera/core/processing/SurfaceEdge;", "")]
		get
		{
			return Java.Lang.Object.GetObject<SurfaceEdge>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCameraEdge.()Landroidx/camera/core/processing/SurfaceEdge;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe DynamicRange DynamicRange
	{
		[Register("getDynamicRange", "()Landroidx/camera/core/DynamicRange;", "")]
		get
		{
			return Java.Lang.Object.GetObject<DynamicRange>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDynamicRange.()Landroidx/camera/core/DynamicRange;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsPreviewStabilizationEnabled
	{
		[Register("isPreviewStabilizationEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isPreviewStabilizationEnabled.()Z", this, null);
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

	protected unsafe override ICollection<Integer> SupportedEffectTargets
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSupportedEffectTargets", "()Ljava/util/Set;", "")]
		get
		{
			return JavaSet<Integer>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSupportedEffectTargets.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ISurfaceProvider? SurfaceProvider
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getSurfaceProvider", "()Landroidx/camera/core/Preview$SurfaceProvider;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ISurfaceProvider>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSurfaceProvider.()Landroidx/camera/core/Preview$SurfaceProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSurfaceProvider", "(Landroidx/camera/core/Preview$SurfaceProvider;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSurfaceProvider.(Landroidx/camera/core/Preview$SurfaceProvider;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe Android.Util.Range TargetFrameRate
	{
		[Register("getTargetFrameRate", "()Landroid/util/Range;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTargetFrameRate.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	internal Preview(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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

	[Register("getPreviewCapabilities", "(Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/PreviewCapabilities;", "")]
	public unsafe static IPreviewCapabilities GetPreviewCapabilities(ICameraInfo cameraInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cameraInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInfo).Handle);
			return Java.Lang.Object.GetObject<IPreviewCapabilities>(_members.StaticMethods.InvokeObjectMethod("getPreviewCapabilities.(Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/PreviewCapabilities;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInfo);
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

	[Register("setSurfaceProvider", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/Preview$SurfaceProvider;)V", "")]
	public unsafe void SetSurfaceProvider(IExecutor executor, ISurfaceProvider? surfaceProvider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((surfaceProvider == null) ? IntPtr.Zero : ((Java.Lang.Object)surfaceProvider).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setSurfaceProvider.(Ljava/util/concurrent/Executor;Landroidx/camera/core/Preview$SurfaceProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(surfaceProvider);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Camera.Core.Impl;
using AndroidX.Core.Util;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/SurfaceRequest", DoNotGenerateAcw = true)]
public sealed class SurfaceRequest : Java.Lang.Object
{
	[Register("androidx/camera/core/SurfaceRequest$TransformationInfo", DoNotGenerateAcw = true)]
	public abstract class TransformationInfo : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceRequest$TransformationInfo", typeof(TransformationInfo));

		private static Delegate? cb_getCropRect;

		private static Delegate? cb_hasCameraTransform;

		private static Delegate? cb_isMirroring;

		private static Delegate? cb_getRotationDegrees;

		private static Delegate? cb_getSensorToBufferTransform;

		private static Delegate? cb_getTargetRotation;

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

		public abstract Rect CropRect
		{
			[Register("getCropRect", "()Landroid/graphics/Rect;", "GetGetCropRectHandler")]
			get;
		}

		public abstract bool HasCameraTransform
		{
			[Register("hasCameraTransform", "()Z", "GetHasCameraTransformHandler")]
			get;
		}

		public abstract bool IsMirroring
		{
			[Register("isMirroring", "()Z", "GetIsMirroringHandler")]
			get;
		}

		public abstract int RotationDegrees
		{
			[Register("getRotationDegrees", "()I", "GetGetRotationDegreesHandler")]
			get;
		}

		public abstract Matrix SensorToBufferTransform
		{
			[Register("getSensorToBufferTransform", "()Landroid/graphics/Matrix;", "GetGetSensorToBufferTransformHandler")]
			get;
		}

		public abstract int TargetRotation
		{
			[Register("getTargetRotation", "()I", "GetGetTargetRotationHandler")]
			get;
		}

		protected TransformationInfo(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetCropRectHandler()
		{
			if ((object)cb_getCropRect == null)
			{
				cb_getCropRect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCropRect));
			}
			return cb_getCropRect;
		}

		private static nint n_GetCropRect(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TransformationInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CropRect);
		}

		private static Delegate GetHasCameraTransformHandler()
		{
			if ((object)cb_hasCameraTransform == null)
			{
				cb_hasCameraTransform = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasCameraTransform));
			}
			return cb_hasCameraTransform;
		}

		private static bool n_HasCameraTransform(nint jnienv, nint native__this)
		{
			return Java.Lang.Object.GetObject<TransformationInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasCameraTransform;
		}

		private static Delegate GetIsMirroringHandler()
		{
			if ((object)cb_isMirroring == null)
			{
				cb_isMirroring = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsMirroring));
			}
			return cb_isMirroring;
		}

		private static bool n_IsMirroring(nint jnienv, nint native__this)
		{
			return Java.Lang.Object.GetObject<TransformationInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsMirroring;
		}

		private static Delegate GetGetRotationDegreesHandler()
		{
			if ((object)cb_getRotationDegrees == null)
			{
				cb_getRotationDegrees = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRotationDegrees));
			}
			return cb_getRotationDegrees;
		}

		private static int n_GetRotationDegrees(nint jnienv, nint native__this)
		{
			return Java.Lang.Object.GetObject<TransformationInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationDegrees;
		}

		private static Delegate GetGetSensorToBufferTransformHandler()
		{
			if ((object)cb_getSensorToBufferTransform == null)
			{
				cb_getSensorToBufferTransform = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSensorToBufferTransform));
			}
			return cb_getSensorToBufferTransform;
		}

		private static nint n_GetSensorToBufferTransform(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TransformationInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorToBufferTransform);
		}

		private static Delegate GetGetTargetRotationHandler()
		{
			if ((object)cb_getTargetRotation == null)
			{
				cb_getTargetRotation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargetRotation));
			}
			return cb_getTargetRotation;
		}

		private static int n_GetTargetRotation(nint jnienv, nint native__this)
		{
			return Java.Lang.Object.GetObject<TransformationInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetRotation;
		}

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("of", "(Landroid/graphics/Rect;IIZLandroid/graphics/Matrix;Z)Landroidx/camera/core/SurfaceRequest$TransformationInfo;", "")]
		public unsafe static TransformationInfo Of(Rect cropRect, int rotationDegrees, int targetRotation, bool hasCameraTransform, Matrix sensorToBufferTransform, bool mirroring)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(cropRect?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(rotationDegrees);
				ptr[2] = new JniArgumentValue(targetRotation);
				ptr[3] = new JniArgumentValue(hasCameraTransform);
				ptr[4] = new JniArgumentValue(sensorToBufferTransform?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(mirroring);
				return Java.Lang.Object.GetObject<TransformationInfo>(_members.StaticMethods.InvokeObjectMethod("of.(Landroid/graphics/Rect;IIZLandroid/graphics/Matrix;Z)Landroidx/camera/core/SurfaceRequest$TransformationInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cropRect);
				GC.KeepAlive(sensorToBufferTransform);
			}
		}
	}

	[Register("androidx/camera/core/SurfaceRequest$TransformationInfo", DoNotGenerateAcw = true)]
	internal class TransformationInfoInvoker : TransformationInfo
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceRequest$TransformationInfo", typeof(TransformationInfoInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override Rect CropRect
		{
			[Register("getCropRect", "()Landroid/graphics/Rect;", "GetGetCropRectHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCropRect.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override bool HasCameraTransform
		{
			[Register("hasCameraTransform", "()Z", "GetHasCameraTransformHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasCameraTransform.()Z", this, null);
			}
		}

		public unsafe override bool IsMirroring
		{
			[Register("isMirroring", "()Z", "GetIsMirroringHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isMirroring.()Z", this, null);
			}
		}

		public unsafe override int RotationDegrees
		{
			[Register("getRotationDegrees", "()I", "GetGetRotationDegreesHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getRotationDegrees.()I", this, null);
			}
		}

		public unsafe override Matrix SensorToBufferTransform
		{
			[Register("getSensorToBufferTransform", "()Landroid/graphics/Matrix;", "GetGetSensorToBufferTransformHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSensorToBufferTransform.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override int TargetRotation
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getTargetRotation", "()I", "GetGetTargetRotationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getTargetRotation.()I", this, null);
			}
		}

		public TransformationInfoInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/camera/core/SurfaceRequest$TransformationInfoListener", "", "AndroidX.Camera.Core.SurfaceRequest/ITransformationInfoListenerInvoker")]
	public interface ITransformationInfoListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onTransformationInfoUpdate", "(Landroidx/camera/core/SurfaceRequest$TransformationInfo;)V", "GetOnTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_Handler:AndroidX.Camera.Core.SurfaceRequest/ITransformationInfoListenerInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnTransformationInfoUpdate(TransformationInfo p0);
	}

	[Register("androidx/camera/core/SurfaceRequest$TransformationInfoListener", DoNotGenerateAcw = true)]
	internal class ITransformationInfoListenerInvoker : Java.Lang.Object, ITransformationInfoListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceRequest$TransformationInfoListener", typeof(ITransformationInfoListenerInvoker));

		private nint class_ref;

		private static Delegate? cb_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_;

		private nint id_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_;

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

		public static ITransformationInfoListener? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITransformationInfoListener>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.SurfaceRequest.TransformationInfoListener'.");
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

		public ITransformationInfoListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_Handler()
		{
			if ((object)cb_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_ == null)
			{
				cb_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_));
			}
			return cb_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_;
		}

		private static void n_OnTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_(nint jnienv, nint native__this, nint native_p0)
		{
			ITransformationInfoListener? transformationInfoListener = Java.Lang.Object.GetObject<ITransformationInfoListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TransformationInfo p = Java.Lang.Object.GetObject<TransformationInfo>(native_p0, JniHandleOwnership.DoNotTransfer);
			transformationInfoListener.OnTransformationInfoUpdate(p);
		}

		public unsafe void OnTransformationInfoUpdate(TransformationInfo p0)
		{
			if (id_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_ == IntPtr.Zero)
			{
				id_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_ = JNIEnv.GetMethodID(class_ref, "onTransformationInfoUpdate", "(Landroidx/camera/core/SurfaceRequest$TransformationInfo;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onTransformationInfoUpdate_Landroidx_camera_core_SurfaceRequest_TransformationInfo_, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceRequest", typeof(SurfaceRequest));

	[Register("FRAME_RATE_RANGE_UNSPECIFIED")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
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

	public unsafe ICameraInternal Camera
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getCamera", "()Landroidx/camera/core/impl/CameraInternal;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraInternal>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCamera.()Landroidx/camera/core/impl/CameraInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe DeferrableSurface DeferrableSurface
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getDeferrableSurface", "()Landroidx/camera/core/impl/DeferrableSurface;", "")]
		get
		{
			return Java.Lang.Object.GetObject<DeferrableSurface>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDeferrableSurface.()Landroidx/camera/core/impl/DeferrableSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe Android.Util.Range ExpectedFrameRate
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getExpectedFrameRate", "()Landroid/util/Range;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExpectedFrameRate.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsPrimary
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isPrimary", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isPrimary.()Z", this, null);
		}
	}

	public unsafe bool IsServiced
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isServiced", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isServiced.()Z", this, null);
		}
	}

	public unsafe Size Resolution
	{
		[Register("getResolution", "()Landroid/util/Size;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResolution.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal SurfaceRequest(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/DynamicRange;Landroid/util/Range;Ljava/lang/Runnable;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public unsafe SurfaceRequest(Size resolution, ICameraInternal camera, DynamicRange dynamicRange, Android.Util.Range expectedFrameRate, IRunnable onInvalidated)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(resolution?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((camera == null) ? IntPtr.Zero : ((Java.Lang.Object)camera).Handle);
			ptr[2] = new JniArgumentValue(dynamicRange?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(expectedFrameRate?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue((onInvalidated == null) ? IntPtr.Zero : ((Java.Lang.Object)onInvalidated).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/DynamicRange;Landroid/util/Range;Ljava/lang/Runnable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;Landroidx/camera/core/DynamicRange;Landroid/util/Range;Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(resolution);
			GC.KeepAlive(camera);
			GC.KeepAlive(dynamicRange);
			GC.KeepAlive(expectedFrameRate);
			GC.KeepAlive(onInvalidated);
		}
	}

	[Register(".ctor", "(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;ZLandroidx/camera/core/DynamicRange;Landroid/util/Range;Ljava/lang/Runnable;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public unsafe SurfaceRequest(Size resolution, ICameraInternal camera, bool isPrimary, DynamicRange dynamicRange, Android.Util.Range expectedFrameRate, IRunnable onInvalidated)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(resolution?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((camera == null) ? IntPtr.Zero : ((Java.Lang.Object)camera).Handle);
			ptr[2] = new JniArgumentValue(isPrimary);
			ptr[3] = new JniArgumentValue(dynamicRange?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(expectedFrameRate?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue((onInvalidated == null) ? IntPtr.Zero : ((Java.Lang.Object)onInvalidated).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;ZLandroidx/camera/core/DynamicRange;Landroid/util/Range;Ljava/lang/Runnable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;ZLandroidx/camera/core/DynamicRange;Landroid/util/Range;Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(resolution);
			GC.KeepAlive(camera);
			GC.KeepAlive(dynamicRange);
			GC.KeepAlive(expectedFrameRate);
			GC.KeepAlive(onInvalidated);
		}
	}

	[Register(".ctor", "(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;Ljava/lang/Runnable;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public unsafe SurfaceRequest(Size resolution, ICameraInternal camera, IRunnable onInvalidated)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(resolution?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((camera == null) ? IntPtr.Zero : ((Java.Lang.Object)camera).Handle);
			ptr[2] = new JniArgumentValue((onInvalidated == null) ? IntPtr.Zero : ((Java.Lang.Object)onInvalidated).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;Ljava/lang/Runnable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Size;Landroidx/camera/core/impl/CameraInternal;Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(resolution);
			GC.KeepAlive(camera);
			GC.KeepAlive(onInvalidated);
		}
	}

	[Register("addRequestCancellationListener", "(Ljava/util/concurrent/Executor;Ljava/lang/Runnable;)V", "")]
	public unsafe void AddRequestCancellationListener(IExecutor executor, IRunnable listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addRequestCancellationListener.(Ljava/util/concurrent/Executor;Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	[Register("clearTransformationInfoListener", "()V", "")]
	public unsafe void ClearTransformationInfoListener()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("clearTransformationInfoListener.()V", this, null);
	}

	[Register("invalidate", "()Z", "")]
	public unsafe bool Invalidate()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("invalidate.()Z", this, null);
	}

	[Register("provideSurface", "(Landroid/view/Surface;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)V", "")]
	public unsafe void ProvideSurface(Surface surface, IExecutor executor, IConsumer resultListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue((resultListener == null) ? IntPtr.Zero : ((Java.Lang.Object)resultListener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("provideSurface.(Landroid/view/Surface;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(surface);
			GC.KeepAlive(executor);
			GC.KeepAlive(resultListener);
		}
	}

	[Register("setTransformationInfoListener", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/SurfaceRequest$TransformationInfoListener;)V", "")]
	public unsafe void SetTransformationInfoListener(IExecutor executor, ITransformationInfoListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setTransformationInfoListener.(Ljava/util/concurrent/Executor;Landroidx/camera/core/SurfaceRequest$TransformationInfoListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("updateTransformationInfo", "(Landroidx/camera/core/SurfaceRequest$TransformationInfo;)V", "")]
	public unsafe void UpdateTransformationInfo(TransformationInfo transformationInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transformationInfo?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("updateTransformationInfo.(Landroidx/camera/core/SurfaceRequest$TransformationInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transformationInfo);
		}
	}

	[Register("willNotProvideSurface", "()Z", "")]
	public unsafe bool WillNotProvideSurface()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("willNotProvideSurface.()Z", this, null);
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Processing;
using AndroidX.Core.Util;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/CameraEffect", DoNotGenerateAcw = true)]
public abstract class CameraEffect : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/CameraEffect", typeof(CameraEffect));

	private static Delegate? cb_getErrorListener;

	private static Delegate? cb_getExecutor;

	private static Delegate? cb_getImageProcessor;

	private static Delegate? cb_getOutputOption;

	private static Delegate? cb_getSurfaceProcessor;

	private static Delegate? cb_getTargets;

	private static Delegate? cb_getTransformation;

	private static Delegate? cb_createSurfaceProcessorInternal;

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

	public unsafe virtual IConsumer ErrorListener
	{
		[Register("getErrorListener", "()Landroidx/core/util/Consumer;", "GetGetErrorListenerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IConsumer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getErrorListener.()Landroidx/core/util/Consumer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IExecutor Executor
	{
		[Register("getExecutor", "()Ljava/util/concurrent/Executor;", "GetGetExecutorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IImageProcessor? ImageProcessor
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getImageProcessor", "()Landroidx/camera/core/ImageProcessor;", "GetGetImageProcessorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IImageProcessor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageProcessor.()Landroidx/camera/core/ImageProcessor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int OutputOption
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getOutputOption", "()I", "GetGetOutputOptionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOutputOption.()I", this, null);
		}
	}

	public unsafe virtual ISurfaceProcessor? SurfaceProcessor
	{
		[Register("getSurfaceProcessor", "()Landroidx/camera/core/SurfaceProcessor;", "GetGetSurfaceProcessorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ISurfaceProcessor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSurfaceProcessor.()Landroidx/camera/core/SurfaceProcessor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Targets
	{
		[Register("getTargets", "()I", "GetGetTargetsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTargets.()I", this, null);
		}
	}

	public unsafe virtual int Transformation
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getTransformation", "()I", "GetGetTransformationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTransformation.()I", this, null);
		}
	}

	protected CameraEffect(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(IIILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected unsafe CameraEffect(int targets, int outputOption, int transformation, IExecutor executor, ISurfaceProcessor surfaceProcessor, IConsumer errorListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(targets);
			ptr[1] = new JniArgumentValue(outputOption);
			ptr[2] = new JniArgumentValue(transformation);
			ptr[3] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[4] = new JniArgumentValue((surfaceProcessor == null) ? IntPtr.Zero : ((Java.Lang.Object)surfaceProcessor).Handle);
			ptr[5] = new JniArgumentValue((errorListener == null) ? IntPtr.Zero : ((Java.Lang.Object)errorListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IIILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IIILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(surfaceProcessor);
			GC.KeepAlive(errorListener);
		}
	}

	[Register(".ctor", "(IILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected unsafe CameraEffect(int targets, int transformation, IExecutor executor, ISurfaceProcessor surfaceProcessor, IConsumer errorListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(targets);
			ptr[1] = new JniArgumentValue(transformation);
			ptr[2] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[3] = new JniArgumentValue((surfaceProcessor == null) ? IntPtr.Zero : ((Java.Lang.Object)surfaceProcessor).Handle);
			ptr[4] = new JniArgumentValue((errorListener == null) ? IntPtr.Zero : ((Java.Lang.Object)errorListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(surfaceProcessor);
			GC.KeepAlive(errorListener);
		}
	}

	[Register(".ctor", "(ILjava/util/concurrent/Executor;Landroidx/camera/core/ImageProcessor;Landroidx/core/util/Consumer;)V", "")]
	protected unsafe CameraEffect(int targets, IExecutor executor, IImageProcessor imageProcessor, IConsumer errorListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(targets);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue((imageProcessor == null) ? IntPtr.Zero : ((Java.Lang.Object)imageProcessor).Handle);
			ptr[3] = new JniArgumentValue((errorListener == null) ? IntPtr.Zero : ((Java.Lang.Object)errorListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/util/concurrent/Executor;Landroidx/camera/core/ImageProcessor;Landroidx/core/util/Consumer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ILjava/util/concurrent/Executor;Landroidx/camera/core/ImageProcessor;Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(imageProcessor);
			GC.KeepAlive(errorListener);
		}
	}

	[Register(".ctor", "(ILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", "")]
	protected unsafe CameraEffect(int targets, IExecutor executor, ISurfaceProcessor surfaceProcessor, IConsumer errorListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(targets);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue((surfaceProcessor == null) ? IntPtr.Zero : ((Java.Lang.Object)surfaceProcessor).Handle);
			ptr[3] = new JniArgumentValue((errorListener == null) ? IntPtr.Zero : ((Java.Lang.Object)errorListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(ILjava/util/concurrent/Executor;Landroidx/camera/core/SurfaceProcessor;Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(surfaceProcessor);
			GC.KeepAlive(errorListener);
		}
	}

	private static Delegate GetGetErrorListenerHandler()
	{
		if ((object)cb_getErrorListener == null)
		{
			cb_getErrorListener = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetErrorListener));
		}
		return cb_getErrorListener;
	}

	private static nint n_GetErrorListener(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorListener);
	}

	private static Delegate GetGetExecutorHandler()
	{
		if ((object)cb_getExecutor == null)
		{
			cb_getExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExecutor));
		}
		return cb_getExecutor;
	}

	private static nint n_GetExecutor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Executor);
	}

	private static Delegate GetGetImageProcessorHandler()
	{
		if ((object)cb_getImageProcessor == null)
		{
			cb_getImageProcessor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageProcessor));
		}
		return cb_getImageProcessor;
	}

	private static nint n_GetImageProcessor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageProcessor);
	}

	private static Delegate GetGetOutputOptionHandler()
	{
		if ((object)cb_getOutputOption == null)
		{
			cb_getOutputOption = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOutputOption));
		}
		return cb_getOutputOption;
	}

	private static int n_GetOutputOption(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutputOption;
	}

	private static Delegate GetGetSurfaceProcessorHandler()
	{
		if ((object)cb_getSurfaceProcessor == null)
		{
			cb_getSurfaceProcessor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSurfaceProcessor));
		}
		return cb_getSurfaceProcessor;
	}

	private static nint n_GetSurfaceProcessor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SurfaceProcessor);
	}

	private static Delegate GetGetTargetsHandler()
	{
		if ((object)cb_getTargets == null)
		{
			cb_getTargets = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargets));
		}
		return cb_getTargets;
	}

	private static int n_GetTargets(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Targets;
	}

	private static Delegate GetGetTransformationHandler()
	{
		if ((object)cb_getTransformation == null)
		{
			cb_getTransformation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTransformation));
		}
		return cb_getTransformation;
	}

	private static int n_GetTransformation(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Transformation;
	}

	private static Delegate GetCreateSurfaceProcessorInternalHandler()
	{
		if ((object)cb_createSurfaceProcessorInternal == null)
		{
			cb_createSurfaceProcessorInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateSurfaceProcessorInternal));
		}
		return cb_createSurfaceProcessorInternal;
	}

	private static nint n_CreateSurfaceProcessorInternal(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraEffect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateSurfaceProcessorInternal());
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("createSurfaceProcessorInternal", "()Landroidx/camera/core/processing/SurfaceProcessorInternal;", "GetCreateSurfaceProcessorInternalHandler")]
	public unsafe virtual ISurfaceProcessorInternal CreateSurfaceProcessorInternal()
	{
		return Java.Lang.Object.GetObject<ISurfaceProcessorInternal>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSurfaceProcessorInternal.()Landroidx/camera/core/processing/SurfaceProcessorInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}

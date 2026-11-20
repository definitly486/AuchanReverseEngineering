using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Camera.Core;
using AndroidX.Camera.View.Transform;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.View;

[Register("androidx/camera/view/PreviewView", DoNotGenerateAcw = true)]
public sealed class PreviewView : FrameLayout
{
	[Register("androidx/camera/view/PreviewView$ImplementationMode", DoNotGenerateAcw = true)]
	public sealed class ImplementationMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/PreviewView$ImplementationMode", typeof(ImplementationMode));

		[Register("COMPATIBLE")]
		public static ImplementationMode? Compatible => Java.Lang.Object.GetObject<ImplementationMode>(_members.StaticFields.GetObjectValue("COMPATIBLE.Landroidx/camera/view/PreviewView$ImplementationMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("PERFORMANCE")]
		public static ImplementationMode? Performance => Java.Lang.Object.GetObject<ImplementationMode>(_members.StaticFields.GetObjectValue("PERFORMANCE.Landroidx/camera/view/PreviewView$ImplementationMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ImplementationMode(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/view/PreviewView$ImplementationMode;", "")]
		public unsafe static ImplementationMode? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<ImplementationMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/view/PreviewView$ImplementationMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/view/PreviewView$ImplementationMode;", "")]
		public unsafe static ImplementationMode[]? Values()
		{
			return (ImplementationMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/view/PreviewView$ImplementationMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ImplementationMode));
		}
	}

	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/camera/view/PreviewView$OnFrameUpdateListener", "", "AndroidX.Camera.View.PreviewView/IOnFrameUpdateListenerInvoker")]
	public interface IOnFrameUpdateListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onFrameUpdate", "(J)V", "GetOnFrameUpdate_JHandler:AndroidX.Camera.View.PreviewView/IOnFrameUpdateListenerInvoker, Xamarin.AndroidX.Camera.View")]
		void OnFrameUpdate(long p0);
	}

	[Register("androidx/camera/view/PreviewView$OnFrameUpdateListener", DoNotGenerateAcw = true)]
	internal class IOnFrameUpdateListenerInvoker : Java.Lang.Object, IOnFrameUpdateListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/PreviewView$OnFrameUpdateListener", typeof(IOnFrameUpdateListenerInvoker));

		private nint class_ref;

		private static Delegate? cb_onFrameUpdate_J;

		private nint id_onFrameUpdate_J;

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

		public static IOnFrameUpdateListener? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnFrameUpdateListener>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.view.PreviewView.OnFrameUpdateListener'.");
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

		public IOnFrameUpdateListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnFrameUpdate_JHandler()
		{
			if ((object)cb_onFrameUpdate_J == null)
			{
				cb_onFrameUpdate_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_OnFrameUpdate_J));
			}
			return cb_onFrameUpdate_J;
		}

		private static void n_OnFrameUpdate_J(nint jnienv, nint native__this, long p0)
		{
			Java.Lang.Object.GetObject<IOnFrameUpdateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFrameUpdate(p0);
		}

		public unsafe void OnFrameUpdate(long p0)
		{
			if (id_onFrameUpdate_J == IntPtr.Zero)
			{
				id_onFrameUpdate_J = JNIEnv.GetMethodID(class_ref, "onFrameUpdate", "(J)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0);
			JNIEnv.CallVoidMethod(base.Handle, id_onFrameUpdate_J, ptr);
		}
	}

	[Register("androidx/camera/view/PreviewView$ScaleType", DoNotGenerateAcw = true)]
	public sealed class ScaleType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/PreviewView$ScaleType", typeof(ScaleType));

		[Register("FILL_CENTER")]
		public static ScaleType? FillCenter => Java.Lang.Object.GetObject<ScaleType>(_members.StaticFields.GetObjectValue("FILL_CENTER.Landroidx/camera/view/PreviewView$ScaleType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FILL_END")]
		public static ScaleType? FillEnd => Java.Lang.Object.GetObject<ScaleType>(_members.StaticFields.GetObjectValue("FILL_END.Landroidx/camera/view/PreviewView$ScaleType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FILL_START")]
		public static ScaleType? FillStart => Java.Lang.Object.GetObject<ScaleType>(_members.StaticFields.GetObjectValue("FILL_START.Landroidx/camera/view/PreviewView$ScaleType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FIT_CENTER")]
		public static ScaleType? FitCenter => Java.Lang.Object.GetObject<ScaleType>(_members.StaticFields.GetObjectValue("FIT_CENTER.Landroidx/camera/view/PreviewView$ScaleType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FIT_END")]
		public static ScaleType? FitEnd => Java.Lang.Object.GetObject<ScaleType>(_members.StaticFields.GetObjectValue("FIT_END.Landroidx/camera/view/PreviewView$ScaleType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FIT_START")]
		public static ScaleType? FitStart => Java.Lang.Object.GetObject<ScaleType>(_members.StaticFields.GetObjectValue("FIT_START.Landroidx/camera/view/PreviewView$ScaleType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ScaleType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/view/PreviewView$ScaleType;", "")]
		public unsafe static ScaleType? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<ScaleType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/view/PreviewView$ScaleType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/view/PreviewView$ScaleType;", "")]
		public unsafe static ScaleType[]? Values()
		{
			return (ScaleType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/view/PreviewView$ScaleType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ScaleType));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/view/PreviewView", typeof(PreviewView));

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

	public unsafe Bitmap? Bitmap
	{
		[Register("getBitmap", "()Landroid/graphics/Bitmap;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBitmap.()Landroid/graphics/Bitmap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe CameraController? Controller
	{
		[Register("getController", "()Landroidx/camera/view/CameraController;", "")]
		get
		{
			return Java.Lang.Object.GetObject<CameraController>(_members.InstanceMethods.InvokeAbstractObjectMethod("getController.()Landroidx/camera/view/CameraController;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setController", "(Landroidx/camera/view/CameraController;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setController.(Landroidx/camera/view/CameraController;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe MeteringPointFactory MeteringPointFactory
	{
		[Register("getMeteringPointFactory", "()Landroidx/camera/core/MeteringPointFactory;", "")]
		get
		{
			return Java.Lang.Object.GetObject<MeteringPointFactory>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMeteringPointFactory.()Landroidx/camera/core/MeteringPointFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe OutputTransform? OutputTransform
	{
		[Register("getOutputTransform", "()Landroidx/camera/view/transform/OutputTransform;", "")]
		get
		{
			return Java.Lang.Object.GetObject<OutputTransform>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOutputTransform.()Landroidx/camera/view/transform/OutputTransform;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe LiveData PreviewStreamState
	{
		[Register("getPreviewStreamState", "()Landroidx/lifecycle/LiveData;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPreviewStreamState.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe Matrix? SensorToViewTransform
	{
		[Register("getSensorToViewTransform", "()Landroid/graphics/Matrix;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSensorToViewTransform.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Preview.ISurfaceProvider SurfaceProvider
	{
		[Register("getSurfaceProvider", "()Landroidx/camera/core/Preview$SurfaceProvider;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Preview.ISurfaceProvider>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSurfaceProvider.()Landroidx/camera/core/Preview$SurfaceProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ViewPort? ViewPort
	{
		[Register("getViewPort", "()Landroidx/camera/core/ViewPort;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ViewPort>(_members.InstanceMethods.InvokeAbstractObjectMethod("getViewPort.()Landroidx/camera/core/ViewPort;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal PreviewView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe PreviewView(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe PreviewView(Context context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe PreviewView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe PreviewView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register("getImplementationMode", "()Landroidx/camera/view/PreviewView$ImplementationMode;", "")]
	public unsafe ImplementationMode GetImplementationMode()
	{
		return Java.Lang.Object.GetObject<ImplementationMode>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImplementationMode.()Landroidx/camera/view/PreviewView$ImplementationMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getScaleType", "()Landroidx/camera/view/PreviewView$ScaleType;", "")]
	public unsafe ScaleType GetScaleType()
	{
		return Java.Lang.Object.GetObject<ScaleType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getScaleType.()Landroidx/camera/view/PreviewView$ScaleType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getViewPort", "(I)Landroidx/camera/core/ViewPort;", "")]
	public unsafe ViewPort? GetViewPort(int targetRotation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(targetRotation);
		return Java.Lang.Object.GetObject<ViewPort>(_members.InstanceMethods.InvokeAbstractObjectMethod("getViewPort.(I)Landroidx/camera/core/ViewPort;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setFrameUpdateListener", "(Ljava/util/concurrent/Executor;Landroidx/camera/view/PreviewView$OnFrameUpdateListener;)V", "")]
	public unsafe void SetFrameUpdateListener(IExecutor executor, IOnFrameUpdateListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setFrameUpdateListener.(Ljava/util/concurrent/Executor;Landroidx/camera/view/PreviewView$OnFrameUpdateListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	[Register("setImplementationMode", "(Landroidx/camera/view/PreviewView$ImplementationMode;)V", "")]
	public unsafe void SetImplementationMode(ImplementationMode implementationMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(implementationMode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setImplementationMode.(Landroidx/camera/view/PreviewView$ImplementationMode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(implementationMode);
		}
	}

	[Register("setScaleType", "(Landroidx/camera/view/PreviewView$ScaleType;)V", "")]
	public unsafe void SetScaleType(ScaleType scaleType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(scaleType?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setScaleType.(Landroidx/camera/view/PreviewView$ScaleType;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(scaleType);
		}
	}

	[Register("setScreenFlashOverlayColor", "(I)V", "")]
	public unsafe void SetScreenFlashOverlayColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setScreenFlashOverlayColor.(I)V", this, ptr);
	}

	[Register("setScreenFlashWindow", "(Landroid/view/Window;)V", "")]
	public unsafe void SetScreenFlashWindow(Window? screenFlashWindow)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(screenFlashWindow?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setScreenFlashWindow.(Landroid/view/Window;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(screenFlashWindow);
		}
	}
}

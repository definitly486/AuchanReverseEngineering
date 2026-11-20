using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Android.Content;
using Android.Graphics;
using Android.Locations;
using Android.Net;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core.Impl;
using AndroidX.Camera.Core.ResolutionSelector;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageCapture", DoNotGenerateAcw = true)]
public sealed class ImageCapture : UseCase
{
	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/camera/core/ImageCapture$Defaults", DoNotGenerateAcw = true)]
	public sealed class Defaults : Java.Lang.Object, IConfigProvider, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$Defaults", typeof(Defaults));

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

		public unsafe ImageCaptureConfig Config
		{
			[Register("getConfig", "()Landroidx/camera/core/impl/ImageCaptureConfig;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ImageCaptureConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getConfig.()Landroidx/camera/core/impl/ImageCaptureConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	[Register("androidx/camera/core/ImageCapture$Metadata", DoNotGenerateAcw = true)]
	public sealed class Metadata : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$Metadata", typeof(Metadata));

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

		public unsafe bool IsReversedHorizontalSet
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("isReversedHorizontalSet", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isReversedHorizontalSet.()Z", this, null);
			}
		}

		public unsafe Location? Location
		{
			[Register("getLocation", "()Landroid/location/Location;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Location>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLocation.()Landroid/location/Location;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setLocation", "(Landroid/location/Location;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setLocation.(Landroid/location/Location;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool ReversedHorizontal
		{
			[Register("isReversedHorizontal", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isReversedHorizontal.()Z", this, null);
			}
			[Register("setReversedHorizontal", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setReversedHorizontal.(Z)V", this, ptr);
			}
		}

		public unsafe bool ReversedVertical
		{
			[Register("isReversedVertical", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isReversedVertical.()Z", this, null);
			}
			[Register("setReversedVertical", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setReversedVertical.(Z)V", this, ptr);
			}
		}

		internal Metadata(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Metadata()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}

	[Register("androidx/camera/core/ImageCapture$OnImageCapturedCallback", DoNotGenerateAcw = true)]
	public abstract class OnImageCapturedCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$OnImageCapturedCallback", typeof(OnImageCapturedCallback));

		private static Delegate? cb_onCaptureProcessProgressed_I;

		private static Delegate? cb_onCaptureStarted;

		private static Delegate? cb_onCaptureSuccess_Landroidx_camera_core_ImageProxy_;

		private static Delegate? cb_onError_Landroidx_camera_core_ImageCaptureException_;

		private static Delegate? cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_;

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

		protected OnImageCapturedCallback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnImageCapturedCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnCaptureProcessProgressed_IHandler()
		{
			if ((object)cb_onCaptureProcessProgressed_I == null)
			{
				cb_onCaptureProcessProgressed_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureProcessProgressed_I));
			}
			return cb_onCaptureProcessProgressed_I;
		}

		private static void n_OnCaptureProcessProgressed_I(nint jnienv, nint native__this, int progress)
		{
			Java.Lang.Object.GetObject<OnImageCapturedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureProcessProgressed(progress);
		}

		[Register("onCaptureProcessProgressed", "(I)V", "GetOnCaptureProcessProgressed_IHandler")]
		public unsafe virtual void OnCaptureProcessProgressed(int progress)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(progress);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureProcessProgressed.(I)V", this, ptr);
		}

		private static Delegate GetOnCaptureStartedHandler()
		{
			if ((object)cb_onCaptureStarted == null)
			{
				cb_onCaptureStarted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCaptureStarted));
			}
			return cb_onCaptureStarted;
		}

		private static void n_OnCaptureStarted(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<OnImageCapturedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureStarted();
		}

		[Register("onCaptureStarted", "()V", "GetOnCaptureStartedHandler")]
		public unsafe virtual void OnCaptureStarted()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureStarted.()V", this, null);
		}

		private static Delegate GetOnCaptureSuccess_Landroidx_camera_core_ImageProxy_Handler()
		{
			if ((object)cb_onCaptureSuccess_Landroidx_camera_core_ImageProxy_ == null)
			{
				cb_onCaptureSuccess_Landroidx_camera_core_ImageProxy_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCaptureSuccess_Landroidx_camera_core_ImageProxy_));
			}
			return cb_onCaptureSuccess_Landroidx_camera_core_ImageProxy_;
		}

		private static void n_OnCaptureSuccess_Landroidx_camera_core_ImageProxy_(nint jnienv, nint native__this, nint native_image)
		{
			OnImageCapturedCallback? onImageCapturedCallback = Java.Lang.Object.GetObject<OnImageCapturedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IImageProxy image = Java.Lang.Object.GetObject<IImageProxy>(native_image, JniHandleOwnership.DoNotTransfer);
			onImageCapturedCallback.OnCaptureSuccess(image);
		}

		[Register("onCaptureSuccess", "(Landroidx/camera/core/ImageProxy;)V", "GetOnCaptureSuccess_Landroidx_camera_core_ImageProxy_Handler")]
		public unsafe virtual void OnCaptureSuccess(IImageProxy image)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((image == null) ? IntPtr.Zero : ((Java.Lang.Object)image).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureSuccess.(Landroidx/camera/core/ImageProxy;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(image);
			}
		}

		private static Delegate GetOnError_Landroidx_camera_core_ImageCaptureException_Handler()
		{
			if ((object)cb_onError_Landroidx_camera_core_ImageCaptureException_ == null)
			{
				cb_onError_Landroidx_camera_core_ImageCaptureException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Landroidx_camera_core_ImageCaptureException_));
			}
			return cb_onError_Landroidx_camera_core_ImageCaptureException_;
		}

		private static void n_OnError_Landroidx_camera_core_ImageCaptureException_(nint jnienv, nint native__this, nint native_exception)
		{
			OnImageCapturedCallback? onImageCapturedCallback = Java.Lang.Object.GetObject<OnImageCapturedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ImageCaptureException exception = Java.Lang.Object.GetObject<ImageCaptureException>(native_exception, JniHandleOwnership.DoNotTransfer);
			onImageCapturedCallback.OnError(exception);
		}

		[Register("onError", "(Landroidx/camera/core/ImageCaptureException;)V", "GetOnError_Landroidx_camera_core_ImageCaptureException_Handler")]
		public unsafe virtual void OnError(ImageCaptureException exception)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onError.(Landroidx/camera/core/ImageCaptureException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(exception);
			}
		}

		private static Delegate GetOnPostviewBitmapAvailable_Landroid_graphics_Bitmap_Handler()
		{
			if ((object)cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_ == null)
			{
				cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPostviewBitmapAvailable_Landroid_graphics_Bitmap_));
			}
			return cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_;
		}

		private static void n_OnPostviewBitmapAvailable_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_bitmap)
		{
			OnImageCapturedCallback? onImageCapturedCallback = Java.Lang.Object.GetObject<OnImageCapturedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			onImageCapturedCallback.OnPostviewBitmapAvailable(bitmap);
		}

		[Register("onPostviewBitmapAvailable", "(Landroid/graphics/Bitmap;)V", "GetOnPostviewBitmapAvailable_Landroid_graphics_Bitmap_Handler")]
		public unsafe virtual void OnPostviewBitmapAvailable(Bitmap bitmap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onPostviewBitmapAvailable.(Landroid/graphics/Bitmap;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bitmap);
			}
		}
	}

	[Register("androidx/camera/core/ImageCapture$OnImageCapturedCallback", DoNotGenerateAcw = true)]
	internal class OnImageCapturedCallbackInvoker : OnImageCapturedCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$OnImageCapturedCallback", typeof(OnImageCapturedCallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnImageCapturedCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/camera/core/ImageCapture$OnImageSavedCallback", "", "AndroidX.Camera.Core.ImageCapture/IOnImageSavedCallbackInvoker")]
	public interface IOnImageSavedCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$OnImageSavedCallback", typeof(IOnImageSavedCallback), isInterface: true);

		private static Delegate? cb_onCaptureProcessProgressed_I;

		private static Delegate? cb_onCaptureStarted;

		private static Delegate? cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_;

		[Register("onError", "(Landroidx/camera/core/ImageCaptureException;)V", "GetOnError_Landroidx_camera_core_ImageCaptureException_Handler:AndroidX.Camera.Core.ImageCapture/IOnImageSavedCallbackInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnError(ImageCaptureException p0);

		[Register("onImageSaved", "(Landroidx/camera/core/ImageCapture$OutputFileResults;)V", "GetOnImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_Handler:AndroidX.Camera.Core.ImageCapture/IOnImageSavedCallbackInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnImageSaved(OutputFileResults p0);

		private static Delegate GetOnCaptureProcessProgressed_IHandler()
		{
			if ((object)cb_onCaptureProcessProgressed_I == null)
			{
				cb_onCaptureProcessProgressed_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureProcessProgressed_I));
			}
			return cb_onCaptureProcessProgressed_I;
		}

		private static void n_OnCaptureProcessProgressed_I(nint jnienv, nint native__this, int progress)
		{
			Java.Lang.Object.GetObject<IOnImageSavedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureProcessProgressed(progress);
		}

		[Register("onCaptureProcessProgressed", "(I)V", "GetOnCaptureProcessProgressed_IHandler:AndroidX.Camera.Core.ImageCapture/IOnImageSavedCallback, Xamarin.AndroidX.Camera.Core")]
		unsafe void OnCaptureProcessProgressed(int progress)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(progress);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureProcessProgressed.(I)V", this, ptr);
		}

		private static Delegate GetOnCaptureStartedHandler()
		{
			if ((object)cb_onCaptureStarted == null)
			{
				cb_onCaptureStarted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCaptureStarted));
			}
			return cb_onCaptureStarted;
		}

		private static void n_OnCaptureStarted(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<IOnImageSavedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureStarted();
		}

		[Register("onCaptureStarted", "()V", "GetOnCaptureStartedHandler:AndroidX.Camera.Core.ImageCapture/IOnImageSavedCallback, Xamarin.AndroidX.Camera.Core")]
		unsafe void OnCaptureStarted()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureStarted.()V", this, null);
		}

		private static Delegate GetOnPostviewBitmapAvailable_Landroid_graphics_Bitmap_Handler()
		{
			if ((object)cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_ == null)
			{
				cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPostviewBitmapAvailable_Landroid_graphics_Bitmap_));
			}
			return cb_onPostviewBitmapAvailable_Landroid_graphics_Bitmap_;
		}

		private static void n_OnPostviewBitmapAvailable_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_bitmap)
		{
			IOnImageSavedCallback? onImageSavedCallback = Java.Lang.Object.GetObject<IOnImageSavedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap bitmap = Java.Lang.Object.GetObject<Bitmap>(native_bitmap, JniHandleOwnership.DoNotTransfer);
			onImageSavedCallback.OnPostviewBitmapAvailable(bitmap);
		}

		[Register("onPostviewBitmapAvailable", "(Landroid/graphics/Bitmap;)V", "GetOnPostviewBitmapAvailable_Landroid_graphics_Bitmap_Handler:AndroidX.Camera.Core.ImageCapture/IOnImageSavedCallback, Xamarin.AndroidX.Camera.Core")]
		unsafe void OnPostviewBitmapAvailable(Bitmap bitmap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onPostviewBitmapAvailable.(Landroid/graphics/Bitmap;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bitmap);
			}
		}
	}

	[Register("androidx/camera/core/ImageCapture$OnImageSavedCallback", DoNotGenerateAcw = true)]
	internal class IOnImageSavedCallbackInvoker : Java.Lang.Object, IOnImageSavedCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$OnImageSavedCallback", typeof(IOnImageSavedCallbackInvoker));

		private nint class_ref;

		private static Delegate? cb_onError_Landroidx_camera_core_ImageCaptureException_;

		private nint id_onError_Landroidx_camera_core_ImageCaptureException_;

		private static Delegate? cb_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_;

		private nint id_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_;

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

		public static IOnImageSavedCallback? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOnImageSavedCallback>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageCapture.OnImageSavedCallback'.");
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

		public IOnImageSavedCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnError_Landroidx_camera_core_ImageCaptureException_Handler()
		{
			if ((object)cb_onError_Landroidx_camera_core_ImageCaptureException_ == null)
			{
				cb_onError_Landroidx_camera_core_ImageCaptureException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Landroidx_camera_core_ImageCaptureException_));
			}
			return cb_onError_Landroidx_camera_core_ImageCaptureException_;
		}

		private static void n_OnError_Landroidx_camera_core_ImageCaptureException_(nint jnienv, nint native__this, nint native_p0)
		{
			IOnImageSavedCallback? onImageSavedCallback = Java.Lang.Object.GetObject<IOnImageSavedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ImageCaptureException p = Java.Lang.Object.GetObject<ImageCaptureException>(native_p0, JniHandleOwnership.DoNotTransfer);
			onImageSavedCallback.OnError(p);
		}

		public unsafe void OnError(ImageCaptureException p0)
		{
			if (id_onError_Landroidx_camera_core_ImageCaptureException_ == IntPtr.Zero)
			{
				id_onError_Landroidx_camera_core_ImageCaptureException_ = JNIEnv.GetMethodID(class_ref, "onError", "(Landroidx/camera/core/ImageCaptureException;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onError_Landroidx_camera_core_ImageCaptureException_, ptr);
		}

		private static Delegate GetOnImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_Handler()
		{
			if ((object)cb_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_ == null)
			{
				cb_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_));
			}
			return cb_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_;
		}

		private static void n_OnImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_(nint jnienv, nint native__this, nint native_p0)
		{
			IOnImageSavedCallback? onImageSavedCallback = Java.Lang.Object.GetObject<IOnImageSavedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OutputFileResults p = Java.Lang.Object.GetObject<OutputFileResults>(native_p0, JniHandleOwnership.DoNotTransfer);
			onImageSavedCallback.OnImageSaved(p);
		}

		public unsafe void OnImageSaved(OutputFileResults p0)
		{
			if (id_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_ == IntPtr.Zero)
			{
				id_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_ = JNIEnv.GetMethodID(class_ref, "onImageSaved", "(Landroidx/camera/core/ImageCapture$OutputFileResults;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onImageSaved_Landroidx_camera_core_ImageCapture_OutputFileResults_, ptr);
		}
	}

	[Register("androidx/camera/core/ImageCapture$OutputFileOptions", DoNotGenerateAcw = true)]
	public sealed class OutputFileOptions : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$OutputFileOptions", typeof(OutputFileOptions));

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

		public unsafe ContentResolver? ContentResolver
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getContentResolver", "()Landroid/content/ContentResolver;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ContentResolver>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentResolver.()Landroid/content/ContentResolver;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ContentValues? ContentValues
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getContentValues", "()Landroid/content/ContentValues;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ContentValues>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentValues.()Landroid/content/ContentValues;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.IO.File? File
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getFile", "()Ljava/io/File;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.IO.File>(_members.InstanceMethods.InvokeAbstractObjectMethod("getFile.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Metadata Metadata
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getMetadata", "()Landroidx/camera/core/ImageCapture$Metadata;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Metadata>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMetadata.()Landroidx/camera/core/ImageCapture$Metadata;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Stream? OutputStream
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getOutputStream", "()Ljava/io/OutputStream;", "")]
			get
			{
				return OutputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getOutputStream.()Ljava/io/OutputStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Android.Net.Uri? SaveCollection
		{
			[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
			[Register("getSaveCollection", "()Landroid/net/Uri;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSaveCollection.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal OutputFileOptions(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("androidx/camera/core/ImageCapture$OutputFileResults", DoNotGenerateAcw = true)]
	public class OutputFileResults : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$OutputFileResults", typeof(OutputFileResults));

		private static Delegate? cb_getSavedUri;

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

		public unsafe virtual Android.Net.Uri? SavedUri
		{
			[Register("getSavedUri", "()Landroid/net/Uri;", "GetGetSavedUriHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSavedUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected OutputFileResults(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/net/Uri;)V", "")]
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		public unsafe OutputFileResults(Android.Net.Uri? savedUri)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(savedUri?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/net/Uri;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/net/Uri;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(savedUri);
			}
		}

		private static Delegate GetGetSavedUriHandler()
		{
			if ((object)cb_getSavedUri == null)
			{
				cb_getSavedUri = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSavedUri));
			}
			return cb_getSavedUri;
		}

		private static nint n_GetSavedUri(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputFileResults>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SavedUri);
		}
	}

	[Register("androidx/camera/core/ImageCapture$ScreenFlash", "", "AndroidX.Camera.Core.ImageCapture/IScreenFlashInvoker")]
	public interface IScreenFlash : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("apply", "(JLandroidx/camera/core/ImageCapture$ScreenFlashListener;)V", "GetApply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_Handler:AndroidX.Camera.Core.ImageCapture/IScreenFlashInvoker, Xamarin.AndroidX.Camera.Core")]
		void Apply(long p0, IScreenFlashListener p1);

		[Register("clear", "()V", "GetClearHandler:AndroidX.Camera.Core.ImageCapture/IScreenFlashInvoker, Xamarin.AndroidX.Camera.Core")]
		void Clear();
	}

	[Register("androidx/camera/core/ImageCapture$ScreenFlash", DoNotGenerateAcw = true)]
	internal class IScreenFlashInvoker : Java.Lang.Object, IScreenFlash, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$ScreenFlash", typeof(IScreenFlashInvoker));

		private nint class_ref;

		private static Delegate? cb_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_;

		private nint id_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_;

		private static Delegate? cb_clear;

		private nint id_clear;

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

		public static IScreenFlash? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IScreenFlash>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageCapture.ScreenFlash'.");
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

		public IScreenFlashInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetApply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_Handler()
		{
			if ((object)cb_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_ == null)
			{
				cb_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJL_V(n_Apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_));
			}
			return cb_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_;
		}

		private static void n_Apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_(nint jnienv, nint native__this, long p0, nint native_p1)
		{
			IScreenFlash? screenFlash = Java.Lang.Object.GetObject<IScreenFlash>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IScreenFlashListener p1 = Java.Lang.Object.GetObject<IScreenFlashListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			screenFlash.Apply(p0, p1);
		}

		public unsafe void Apply(long p0, IScreenFlashListener p1)
		{
			if (id_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_ == IntPtr.Zero)
			{
				id_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_ = JNIEnv.GetMethodID(class_ref, "apply", "(JLandroidx/camera/core/ImageCapture$ScreenFlashListener;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_apply_JLandroidx_camera_core_ImageCapture_ScreenFlashListener_, ptr);
		}

		private static Delegate GetClearHandler()
		{
			if ((object)cb_clear == null)
			{
				cb_clear = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
			}
			return cb_clear;
		}

		private static void n_Clear(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<IScreenFlash>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
		}

		public void Clear()
		{
			if (id_clear == IntPtr.Zero)
			{
				id_clear = JNIEnv.GetMethodID(class_ref, "clear", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_clear);
		}
	}

	[Register("androidx/camera/core/ImageCapture$ScreenFlashListener", "", "AndroidX.Camera.Core.ImageCapture/IScreenFlashListenerInvoker")]
	public interface IScreenFlashListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onCompleted", "()V", "GetOnCompletedHandler:AndroidX.Camera.Core.ImageCapture/IScreenFlashListenerInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnCompleted();
	}

	[Register("androidx/camera/core/ImageCapture$ScreenFlashListener", DoNotGenerateAcw = true)]
	internal class IScreenFlashListenerInvoker : Java.Lang.Object, IScreenFlashListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture$ScreenFlashListener", typeof(IScreenFlashListenerInvoker));

		private nint class_ref;

		private static Delegate? cb_onCompleted;

		private nint id_onCompleted;

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

		public static IScreenFlashListener? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IScreenFlashListener>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageCapture.ScreenFlashListener'.");
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

		public IScreenFlashListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCompletedHandler()
		{
			if ((object)cb_onCompleted == null)
			{
				cb_onCompleted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCompleted));
			}
			return cb_onCompleted;
		}

		private static void n_OnCompleted(nint jnienv, nint native__this)
		{
			Java.Lang.Object.GetObject<IScreenFlashListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCompleted();
		}

		public void OnCompleted()
		{
			if (id_onCompleted == IntPtr.Zero)
			{
				id_onCompleted = JNIEnv.GetMethodID(class_ref, "onCompleted", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onCompleted);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCapture", typeof(ImageCapture));

	[Register("DEFAULT_CONFIG")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public static Defaults? DefaultConfig => Java.Lang.Object.GetObject<Defaults>(_members.StaticFields.GetObjectValue("DEFAULT_CONFIG.Landroidx/camera/core/ImageCapture$Defaults;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe int CaptureMode
	{
		[Register("getCaptureMode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getCaptureMode.()I", this, null);
		}
	}

	public unsafe int FlashMode
	{
		[Register("getFlashMode", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getFlashMode.()I", this, null);
		}
		[Register("setFlashMode", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setFlashMode.(I)V", this, ptr);
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

	public unsafe int JpegQuality
	{
		[Register("getJpegQuality", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getJpegQuality.()I", this, null);
		}
	}

	public unsafe int OutputFormat
	{
		[Register("getOutputFormat", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getOutputFormat.()I", this, null);
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

	public unsafe ImageCaptureLatencyEstimate RealtimeCaptureLatencyEstimate
	{
		[Register("getRealtimeCaptureLatencyEstimate", "()Landroidx/camera/core/ImageCaptureLatencyEstimate;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ImageCaptureLatencyEstimate>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRealtimeCaptureLatencyEstimate.()Landroidx/camera/core/ImageCaptureLatencyEstimate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe IScreenFlash? ScreenFlash
	{
		[Register("getScreenFlash", "()Landroidx/camera/core/ImageCapture$ScreenFlash;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IScreenFlash>(_members.InstanceMethods.InvokeAbstractObjectMethod("getScreenFlash.()Landroidx/camera/core/ImageCapture$ScreenFlash;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setScreenFlash", "(Landroidx/camera/core/ImageCapture$ScreenFlash;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setScreenFlash.(Landroidx/camera/core/ImageCapture$ScreenFlash;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
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

	internal ImageCapture(nint javaReference, JniHandleOwnership transfer)
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

	[Register("getImageCaptureCapabilities", "(Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/ImageCaptureCapabilities;", "")]
	public unsafe static IImageCaptureCapabilities GetImageCaptureCapabilities(ICameraInfo cameraInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cameraInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInfo).Handle);
			return Java.Lang.Object.GetObject<IImageCaptureCapabilities>(_members.StaticMethods.InvokeObjectMethod("getImageCaptureCapabilities.(Landroidx/camera/core/CameraInfo;)Landroidx/camera/core/ImageCaptureCapabilities;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	[Register("setCropAspectRatio", "(Landroid/util/Rational;)V", "")]
	public unsafe void SetCropAspectRatio(Rational aspectRatio)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(aspectRatio?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setCropAspectRatio.(Landroid/util/Rational;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(aspectRatio);
		}
	}

	[Register("takePicture", "(Landroidx/camera/core/ImageCapture$OutputFileOptions;Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageSavedCallback;)V", "")]
	public unsafe void TakePicture(OutputFileOptions outputFileOptions, IExecutor executor, IOnImageSavedCallback imageSavedCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(outputFileOptions?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue((imageSavedCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)imageSavedCallback).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("takePicture.(Landroidx/camera/core/ImageCapture$OutputFileOptions;Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageSavedCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outputFileOptions);
			GC.KeepAlive(executor);
			GC.KeepAlive(imageSavedCallback);
		}
	}

	[Register("takePicture", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageCapturedCallback;)V", "")]
	public unsafe void TakePicture(IExecutor executor, OnImageCapturedCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("takePicture.(Ljava/util/concurrent/Executor;Landroidx/camera/core/ImageCapture$OnImageCapturedCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}
}

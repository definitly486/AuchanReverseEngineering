using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/TextureView", DoNotGenerateAcw = true)]
public class TextureView : View
{
	[Register("android/view/TextureView$SurfaceTextureListener", "", "Android.Views.TextureView/ISurfaceTextureListenerInvoker")]
	public interface ISurfaceTextureListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSurfaceTextureAvailable", "(Landroid/graphics/SurfaceTexture;II)V", "GetOnSurfaceTextureAvailable_Landroid_graphics_SurfaceTexture_IIHandler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height);

		[Register("onSurfaceTextureDestroyed", "(Landroid/graphics/SurfaceTexture;)Z", "GetOnSurfaceTextureDestroyed_Landroid_graphics_SurfaceTexture_Handler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnSurfaceTextureDestroyed(SurfaceTexture surface);

		[Register("onSurfaceTextureSizeChanged", "(Landroid/graphics/SurfaceTexture;II)V", "GetOnSurfaceTextureSizeChanged_Landroid_graphics_SurfaceTexture_IIHandler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height);

		[Register("onSurfaceTextureUpdated", "(Landroid/graphics/SurfaceTexture;)V", "GetOnSurfaceTextureUpdated_Landroid_graphics_SurfaceTexture_Handler:Android.Views.TextureView/ISurfaceTextureListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnSurfaceTextureUpdated(SurfaceTexture surface);
	}

	[Register("android/view/TextureView$SurfaceTextureListener", DoNotGenerateAcw = true)]
	internal class ISurfaceTextureListenerInvoker : Java.Lang.Object, ISurfaceTextureListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_TextureView_SurfaceTextureListener = new XAPeerMembers("android/view/TextureView$SurfaceTextureListener", typeof(ISurfaceTextureListenerInvoker));

		private static Delegate? cb_onSurfaceTextureAvailable_OnSurfaceTextureAvailable_Landroid_graphics_SurfaceTexture_II_V;

		private static Delegate? cb_onSurfaceTextureDestroyed_OnSurfaceTextureDestroyed_Landroid_graphics_SurfaceTexture__Z;

		private static Delegate? cb_onSurfaceTextureSizeChanged_OnSurfaceTextureSizeChanged_Landroid_graphics_SurfaceTexture_II_V;

		private static Delegate? cb_onSurfaceTextureUpdated_OnSurfaceTextureUpdated_Landroid_graphics_SurfaceTexture__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_TextureView_SurfaceTextureListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_TextureView_SurfaceTextureListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_TextureView_SurfaceTextureListener.ManagedPeerType;

		public ISurfaceTextureListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSurfaceTextureAvailable_Landroid_graphics_SurfaceTexture_II(nint jnienv, nint native__this, nint native_surface, int width, int height)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ISurfaceTextureListener? surfaceTextureListener = Java.Lang.Object.GetObject<ISurfaceTextureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SurfaceTexture surface = Java.Lang.Object.GetObject<SurfaceTexture>(native_surface, JniHandleOwnership.DoNotTransfer);
				surfaceTextureListener.OnSurfaceTextureAvailable(surface, width, height);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(width);
				ptr[2] = new JniArgumentValue(height);
				_members_android_view_TextureView_SurfaceTextureListener.InstanceMethods.InvokeAbstractVoidMethod("onSurfaceTextureAvailable.(Landroid/graphics/SurfaceTexture;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnSurfaceTextureDestroyed_Landroid_graphics_SurfaceTexture_(nint jnienv, nint native__this, nint native_surface)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ISurfaceTextureListener? surfaceTextureListener = Java.Lang.Object.GetObject<ISurfaceTextureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SurfaceTexture surface = Java.Lang.Object.GetObject<SurfaceTexture>(native_surface, JniHandleOwnership.DoNotTransfer);
				return surfaceTextureListener.OnSurfaceTextureDestroyed(surface) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				return _members_android_view_TextureView_SurfaceTextureListener.InstanceMethods.InvokeAbstractBooleanMethod("onSurfaceTextureDestroyed.(Landroid/graphics/SurfaceTexture;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSurfaceTextureSizeChanged_Landroid_graphics_SurfaceTexture_II(nint jnienv, nint native__this, nint native_surface, int width, int height)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ISurfaceTextureListener? surfaceTextureListener = Java.Lang.Object.GetObject<ISurfaceTextureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SurfaceTexture surface = Java.Lang.Object.GetObject<SurfaceTexture>(native_surface, JniHandleOwnership.DoNotTransfer);
				surfaceTextureListener.OnSurfaceTextureSizeChanged(surface, width, height);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(width);
				ptr[2] = new JniArgumentValue(height);
				_members_android_view_TextureView_SurfaceTextureListener.InstanceMethods.InvokeAbstractVoidMethod("onSurfaceTextureSizeChanged.(Landroid/graphics/SurfaceTexture;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSurfaceTextureUpdated_Landroid_graphics_SurfaceTexture_(nint jnienv, nint native__this, nint native_surface)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ISurfaceTextureListener? surfaceTextureListener = Java.Lang.Object.GetObject<ISurfaceTextureListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SurfaceTexture surface = Java.Lang.Object.GetObject<SurfaceTexture>(native_surface, JniHandleOwnership.DoNotTransfer);
				surfaceTextureListener.OnSurfaceTextureUpdated(surface);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnSurfaceTextureUpdated(SurfaceTexture surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				_members_android_view_TextureView_SurfaceTextureListener.InstanceMethods.InvokeAbstractVoidMethod("onSurfaceTextureUpdated.(Landroid/graphics/SurfaceTexture;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}

		[UnmanagedCallersOnly]
		private static void n_OnSurfaceTextureAvailable_Landroid_graphics_SurfaceTexture_II_mm_wrapper(nint jnienv, nint native__this, nint native_surface, int width, int height)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnSurfaceTextureAvailable_Landroid_graphics_SurfaceTexture_II(jnienv, native__this, native_surface, width, height);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnSurfaceTextureDestroyed_Landroid_graphics_SurfaceTexture__mm_wrapper(nint jnienv, nint native__this, nint native_surface)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnSurfaceTextureDestroyed_Landroid_graphics_SurfaceTexture_(jnienv, native__this, native_surface);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnSurfaceTextureSizeChanged_Landroid_graphics_SurfaceTexture_II_mm_wrapper(nint jnienv, nint native__this, nint native_surface, int width, int height)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnSurfaceTextureSizeChanged_Landroid_graphics_SurfaceTexture_II(jnienv, native__this, native_surface, width, height);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnSurfaceTextureUpdated_Landroid_graphics_SurfaceTexture__mm_wrapper(nint jnienv, nint native__this, nint native_surface)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnSurfaceTextureUpdated_Landroid_graphics_SurfaceTexture_(jnienv, native__this, native_surface);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/TextureView", typeof(TextureView));

	private static Delegate? cb_getSurfaceTexture_GetSurfaceTexture_Landroid_graphics_SurfaceTexture_;

	private static Delegate? cb_setSurfaceTextureListener_SetSurfaceTextureListener_Landroid_view_TextureView_SurfaceTextureListener__V;

	private static Delegate? cb_setOpaque_SetOpaque_Z_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual SurfaceTexture? SurfaceTexture
	{
		[Register("getSurfaceTexture", "()Landroid/graphics/SurfaceTexture;", "GetGetSurfaceTextureHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SurfaceTexture>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSurfaceTexture.()Landroid/graphics/SurfaceTexture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ISurfaceTextureListener? SurfaceTextureListener
	{
		[Register("setSurfaceTextureListener", "(Landroid/view/TextureView$SurfaceTextureListener;)V", "GetSetSurfaceTextureListener_Landroid_view_TextureView_SurfaceTextureListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSurfaceTextureListener.(Landroid/view/TextureView$SurfaceTextureListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected TextureView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe TextureView(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe TextureView(Context context, IAttributeSet? attrs)
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

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe TextureView(Context context)
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

	private static Delegate GetGetSurfaceTextureHandler()
	{
		return new _JniMarshal_PP_L(n_GetSurfaceTexture);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSurfaceTexture(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TextureView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SurfaceTexture);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetSurfaceTextureListener_Landroid_view_TextureView_SurfaceTextureListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetSurfaceTextureListener_Landroid_view_TextureView_SurfaceTextureListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSurfaceTextureListener_Landroid_view_TextureView_SurfaceTextureListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextureView? textureView = Java.Lang.Object.GetObject<TextureView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISurfaceTextureListener surfaceTextureListener = Java.Lang.Object.GetObject<ISurfaceTextureListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			textureView.SurfaceTextureListener = surfaceTextureListener;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("draw", "(Landroid/graphics/Canvas;)V", "")]
	public unsafe sealed override void Draw(Canvas? canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("draw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	[Register("onDraw", "(Landroid/graphics/Canvas;)V", "")]
	protected unsafe sealed override void OnDraw(Canvas? canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	private static Delegate GetSetOpaque_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetOpaque_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOpaque_Z(nint jnienv, nint native__this, sbyte native_opaque)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TextureView? textureView = Java.Lang.Object.GetObject<TextureView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool opaque = native_opaque != 0;
			textureView.SetOpaque(opaque);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setOpaque", "(Z)V", "GetSetOpaque_ZHandler")]
	public unsafe virtual void SetOpaque(bool opaque)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(opaque ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOpaque.(Z)V", this, ptr);
	}
}

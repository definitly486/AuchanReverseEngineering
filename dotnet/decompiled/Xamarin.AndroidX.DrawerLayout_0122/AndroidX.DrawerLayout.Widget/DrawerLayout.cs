using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.DrawerLayout.Widget;

[Register("androidx/drawerlayout/widget/DrawerLayout", DoNotGenerateAcw = true)]
public class DrawerLayout : ViewGroup, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/drawerlayout/widget/DrawerLayout$DrawerListener", "", "AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker")]
	public interface IDrawerListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDrawerClosed", "(Landroid/view/View;)V", "GetOnDrawerClosed_Landroid_view_View_Handler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
		void OnDrawerClosed(View drawerView);

		[Register("onDrawerOpened", "(Landroid/view/View;)V", "GetOnDrawerOpened_Landroid_view_View_Handler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
		void OnDrawerOpened(View drawerView);

		[Register("onDrawerSlide", "(Landroid/view/View;F)V", "GetOnDrawerSlide_Landroid_view_View_FHandler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
		void OnDrawerSlide(View drawerView, float slideOffset);

		[Register("onDrawerStateChanged", "(I)V", "GetOnDrawerStateChanged_IHandler:AndroidX.DrawerLayout.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.AndroidX.DrawerLayout")]
		void OnDrawerStateChanged(int newState);
	}

	[Register("androidx/drawerlayout/widget/DrawerLayout$DrawerListener", DoNotGenerateAcw = true)]
	internal class IDrawerListenerInvoker : Java.Lang.Object, IDrawerListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener = new XAPeerMembers("androidx/drawerlayout/widget/DrawerLayout$DrawerListener", typeof(IDrawerListenerInvoker));

		private static Delegate? cb_onDrawerClosed_OnDrawerClosed_Landroid_view_View__V;

		private static Delegate? cb_onDrawerOpened_OnDrawerOpened_Landroid_view_View__V;

		private static Delegate? cb_onDrawerSlide_OnDrawerSlide_Landroid_view_View_F_V;

		private static Delegate? cb_onDrawerStateChanged_OnDrawerStateChanged_I_V;

		private static nint java_class_ref => _members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener.ManagedPeerType;

		public IDrawerListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDrawerClosed_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawerView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IDrawerListener? drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
				drawerListener.OnDrawerClosed(drawerView);
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

		public unsafe void OnDrawerClosed(View drawerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				_members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener.InstanceMethods.InvokeAbstractVoidMethod("onDrawerClosed.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDrawerOpened_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawerView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IDrawerListener? drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
				drawerListener.OnDrawerOpened(drawerView);
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

		public unsafe void OnDrawerOpened(View drawerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				_members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener.InstanceMethods.InvokeAbstractVoidMethod("onDrawerOpened.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDrawerSlide_Landroid_view_View_F(nint jnienv, nint native__this, nint native_drawerView, float slideOffset)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IDrawerListener? drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
				drawerListener.OnDrawerSlide(drawerView, slideOffset);
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

		public unsafe void OnDrawerSlide(View drawerView, float slideOffset)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(slideOffset);
				_members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener.InstanceMethods.InvokeAbstractVoidMethod("onDrawerSlide.(Landroid/view/View;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(drawerView);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDrawerStateChanged_I(nint jnienv, nint native__this, int newState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IDrawerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDrawerStateChanged(newState);
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

		public unsafe void OnDrawerStateChanged(int newState)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newState);
			_members_androidx_drawerlayout_widget_DrawerLayout_DrawerListener.InstanceMethods.InvokeAbstractVoidMethod("onDrawerStateChanged.(I)V", this, ptr);
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
		private static void n_OnDrawerClosed_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_drawerView)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDrawerClosed_Landroid_view_View_(jnienv, native__this, native_drawerView);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDrawerOpened_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_drawerView)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDrawerOpened_Landroid_view_View_(jnienv, native__this, native_drawerView);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDrawerSlide_Landroid_view_View_F_mm_wrapper(nint jnienv, nint native__this, nint native_drawerView, float slideOffset)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDrawerSlide_Landroid_view_View_F(jnienv, native__this, native_drawerView, slideOffset);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDrawerStateChanged_I_mm_wrapper(nint jnienv, nint native__this, int newState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDrawerStateChanged_I(jnienv, native__this, newState);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class DrawerClosedEventArgs : EventArgs
	{
		private View drawerView;

		public DrawerClosedEventArgs(View drawerView)
		{
			this.drawerView = drawerView;
		}
	}

	public class DrawerOpenedEventArgs : EventArgs
	{
		private View drawerView;

		public DrawerOpenedEventArgs(View drawerView)
		{
			this.drawerView = drawerView;
		}
	}

	public class DrawerSlideEventArgs : EventArgs
	{
		private View drawerView;

		private float slideOffset;

		public DrawerSlideEventArgs(View drawerView, float slideOffset)
		{
			this.drawerView = drawerView;
			this.slideOffset = slideOffset;
		}
	}

	public class DrawerStateChangedEventArgs : EventArgs
	{
		private int newState;

		public DrawerStateChangedEventArgs(int newState)
		{
			this.newState = newState;
		}
	}

	[Register("mono/androidx/drawerlayout/widget/DrawerLayout_DrawerListenerImplementor")]
	internal sealed class IDrawerListenerImplementor : Java.Lang.Object, IDrawerListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<DrawerClosedEventArgs>? OnDrawerClosedHandler;

		public EventHandler<DrawerOpenedEventArgs>? OnDrawerOpenedHandler;

		public EventHandler<DrawerSlideEventArgs>? OnDrawerSlideHandler;

		public EventHandler<DrawerStateChangedEventArgs>? OnDrawerStateChangedHandler;

		public unsafe IDrawerListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnDrawerClosed(View drawerView)
		{
			OnDrawerClosedHandler?.Invoke(sender, new DrawerClosedEventArgs(drawerView));
		}

		public void OnDrawerOpened(View drawerView)
		{
			OnDrawerOpenedHandler?.Invoke(sender, new DrawerOpenedEventArgs(drawerView));
		}

		public void OnDrawerSlide(View drawerView, float slideOffset)
		{
			OnDrawerSlideHandler?.Invoke(sender, new DrawerSlideEventArgs(drawerView, slideOffset));
		}

		public void OnDrawerStateChanged(int newState)
		{
			OnDrawerStateChangedHandler?.Invoke(sender, new DrawerStateChangedEventArgs(newState));
		}

		internal static bool __IsEmpty(IDrawerListenerImplementor value)
		{
			if (value.OnDrawerClosedHandler == null && value.OnDrawerOpenedHandler == null && value.OnDrawerSlideHandler == null)
			{
				return value.OnDrawerStateChangedHandler == null;
			}
			return false;
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/drawerlayout/widget/DrawerLayout", typeof(DrawerLayout));

	private static Delegate? cb_getDrawerElevation_GetDrawerElevation_F;

	private static Delegate? cb_setDrawerElevation_SetDrawerElevation_F_V;

	private static Delegate? cb_isOpen_IsOpen_Z;

	private static Delegate? cb_getStatusBarBackgroundDrawable_GetStatusBarBackgroundDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_addDrawerListener_AddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener__V;

	private static Delegate? cb_addFocusables_AddFocusables_Ljava_util_ArrayList_II_V;

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_closeDrawer_CloseDrawer_Landroid_view_View__V;

	private static Delegate? cb_closeDrawer_CloseDrawer_Landroid_view_View_Z_V;

	private static Delegate? cb_closeDrawer_CloseDrawer_I_V;

	private static Delegate? cb_closeDrawer_CloseDrawer_IZ_V;

	private static Delegate? cb_closeDrawers_CloseDrawers_V;

	private static Delegate? cb_getDrawerLockMode_GetDrawerLockMode_Landroid_view_View__I;

	private static Delegate? cb_getDrawerLockMode_GetDrawerLockMode_I_I;

	private static Delegate? cb_getDrawerTitle_GetDrawerTitle_I_Ljava_lang_CharSequence_;

	private static Delegate? cb_isDrawerOpen_IsDrawerOpen_Landroid_view_View__Z;

	private static Delegate? cb_isDrawerOpen_IsDrawerOpen_I_Z;

	private static Delegate? cb_isDrawerVisible_IsDrawerVisible_Landroid_view_View__Z;

	private static Delegate? cb_isDrawerVisible_IsDrawerVisible_I_Z;

	private static Delegate? cb_onDraw_OnDraw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_open_Open_V;

	private static Delegate? cb_openDrawer_OpenDrawer_Landroid_view_View__V;

	private static Delegate? cb_openDrawer_OpenDrawer_Landroid_view_View_Z_V;

	private static Delegate? cb_openDrawer_OpenDrawer_I_V;

	private static Delegate? cb_openDrawer_OpenDrawer_IZ_V;

	private static Delegate? cb_removeDrawerListener_RemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener__V;

	private static Delegate? cb_setChildInsets_SetChildInsets_Landroidx_core_view_WindowInsetsCompat_Z_V;

	private static Delegate? cb_setDrawerListener_SetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener__V;

	private static Delegate? cb_setDrawerLockMode_SetDrawerLockMode_I_V;

	private static Delegate? cb_setDrawerLockMode_SetDrawerLockMode_ILandroid_view_View__V;

	private static Delegate? cb_setDrawerLockMode_SetDrawerLockMode_II_V;

	private static Delegate? cb_setDrawerShadow_SetDrawerShadow_Landroid_graphics_drawable_Drawable_I_V;

	private static Delegate? cb_setDrawerShadow_SetDrawerShadow_II_V;

	private static Delegate? cb_setDrawerTitle_SetDrawerTitle_ILjava_lang_CharSequence__V;

	private static Delegate? cb_setScrimColor_SetScrimColor_I_V;

	private static Delegate? cb_setStatusBarBackground_SetStatusBarBackground_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setStatusBarBackground_SetStatusBarBackground_I_V;

	private static Delegate? cb_setStatusBarBackgroundColor_SetStatusBarBackgroundColor_I_V;

	private WeakReference? weak_implementor_AddDrawerListener;

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

	public unsafe virtual float DrawerElevation
	{
		[Register("getDrawerElevation", "()F", "GetGetDrawerElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getDrawerElevation.()F", this, null);
		}
		[Register("setDrawerElevation", "(F)V", "GetSetDrawerElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool IsOpen
	{
		[Register("isOpen", "()Z", "GetIsOpenHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOpen.()Z", this, null);
		}
	}

	public unsafe virtual Drawable? StatusBarBackgroundDrawable
	{
		[Register("getStatusBarBackgroundDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetStatusBarBackgroundDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStatusBarBackgroundDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public event EventHandler<DrawerClosedEventArgs> DrawerClosed
	{
		add
		{
			EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerClosedHandler = (EventHandler<DrawerClosedEventArgs>)Delegate.Combine(__h.OnDrawerClosedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
			{
				RemoveDrawerListener(__v);
			}, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerClosedHandler = (EventHandler<DrawerClosedEventArgs>)Delegate.Remove(__h.OnDrawerClosedHandler, value);
			});
		}
	}

	public event EventHandler<DrawerOpenedEventArgs> DrawerOpened
	{
		add
		{
			EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerOpenedHandler = (EventHandler<DrawerOpenedEventArgs>)Delegate.Combine(__h.OnDrawerOpenedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
			{
				RemoveDrawerListener(__v);
			}, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerOpenedHandler = (EventHandler<DrawerOpenedEventArgs>)Delegate.Remove(__h.OnDrawerOpenedHandler, value);
			});
		}
	}

	public event EventHandler<DrawerSlideEventArgs> DrawerSlide
	{
		add
		{
			EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerSlideHandler = (EventHandler<DrawerSlideEventArgs>)Delegate.Combine(__h.OnDrawerSlideHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
			{
				RemoveDrawerListener(__v);
			}, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerSlideHandler = (EventHandler<DrawerSlideEventArgs>)Delegate.Remove(__h.OnDrawerSlideHandler, value);
			});
		}
	}

	public event EventHandler<DrawerStateChangedEventArgs> DrawerStateChanged
	{
		add
		{
			EventHelper.AddEventHandler<IDrawerListener, IDrawerListenerImplementor>(ref weak_implementor_AddDrawerListener, __CreateIDrawerListenerImplementor, AddDrawerListener, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerStateChangedHandler = (EventHandler<DrawerStateChangedEventArgs>)Delegate.Combine(__h.OnDrawerStateChangedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddDrawerListener, IDrawerListenerImplementor.__IsEmpty, delegate(IDrawerListener __v)
			{
				RemoveDrawerListener(__v);
			}, delegate(IDrawerListenerImplementor __h)
			{
				__h.OnDrawerStateChangedHandler = (EventHandler<DrawerStateChangedEventArgs>)Delegate.Remove(__h.OnDrawerStateChangedHandler, value);
			});
		}
	}

	protected DrawerLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe DrawerLayout(Context context)
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
	public unsafe DrawerLayout(Context context, IAttributeSet? attrs)
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
	public unsafe DrawerLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetDrawerElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetDrawerElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetDrawerElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerElevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetDrawerElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetDrawerElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerElevation_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerElevation = elevation;
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

	private static Delegate GetIsOpenHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOpen);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOpen(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetStatusBarBackgroundDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStatusBarBackgroundDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStatusBarBackgroundDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StatusBarBackgroundDrawable);
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

	private static Delegate GetAddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDrawerListener listener = Java.Lang.Object.GetObject<IDrawerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			drawerLayout.AddDrawerListener(listener);
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

	[Register("addDrawerListener", "(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", "GetAddDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler")]
	public unsafe virtual void AddDrawerListener(IDrawerListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addDrawerListener.(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddFocusables_Ljava_util_ArrayList_IIHandler()
	{
		return new global::_JniMarshal_PPLII_V(n_AddFocusables_Ljava_util_ArrayList_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFocusables_Ljava_util_ArrayList_II(nint jnienv, nint native__this, nint native_views, int direction, int focusableMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			drawerLayout.AddFocusables(views, direction, focusableMode);
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

	[Register("addFocusables", "(Ljava/util/ArrayList;II)V", "GetAddFocusables_Ljava_util_ArrayList_IIHandler")]
	public unsafe virtual void AddFocusables(IList<View>? views, int direction, int focusableMode)
	{
		nint num = JavaList<View>.ToLocalJniHandle(views);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(direction);
			ptr[2] = new JniArgumentValue(focusableMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFocusables.(Ljava/util/ArrayList;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(views);
		}
	}

	private static Delegate GetCloseHandler()
	{
		return new global::_JniMarshal_PP_V(n_Close);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	[Register("close", "()V", "GetCloseHandler")]
	public unsafe virtual void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}

	private static Delegate GetCloseDrawer_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_CloseDrawer_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CloseDrawer_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawerView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.CloseDrawer(drawerView);
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

	[Register("closeDrawer", "(Landroid/view/View;)V", "GetCloseDrawer_Landroid_view_View_Handler")]
	public unsafe virtual void CloseDrawer(View drawerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetCloseDrawer_Landroid_view_View_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_CloseDrawer_Landroid_view_View_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CloseDrawer_Landroid_view_View_Z(nint jnienv, nint native__this, nint native_drawerView, sbyte native_animate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			bool animate = native_animate != 0;
			drawerLayout.CloseDrawer(drawerView, animate);
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

	[Register("closeDrawer", "(Landroid/view/View;Z)V", "GetCloseDrawer_Landroid_view_View_ZHandler")]
	public unsafe virtual void CloseDrawer(View drawerView, bool animate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(animate ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(Landroid/view/View;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetCloseDrawer_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_CloseDrawer_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CloseDrawer_I(nint jnienv, nint native__this, int gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloseDrawer(gravity);
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

	[Register("closeDrawer", "(I)V", "GetCloseDrawer_IHandler")]
	public unsafe virtual void CloseDrawer(int gravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(gravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(I)V", this, ptr);
	}

	private static Delegate GetCloseDrawer_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_CloseDrawer_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CloseDrawer_IZ(nint jnienv, nint native__this, int gravity, sbyte native_animate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool animate = native_animate != 0;
			drawerLayout.CloseDrawer(gravity, animate);
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

	[Register("closeDrawer", "(IZ)V", "GetCloseDrawer_IZHandler")]
	public unsafe virtual void CloseDrawer(int gravity, bool animate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(gravity);
		ptr[1] = new JniArgumentValue(animate ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawer.(IZ)V", this, ptr);
	}

	private static Delegate GetCloseDrawersHandler()
	{
		return new global::_JniMarshal_PP_V(n_CloseDrawers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CloseDrawers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CloseDrawers();
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

	[Register("closeDrawers", "()V", "GetCloseDrawersHandler")]
	public unsafe virtual void CloseDrawers()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("closeDrawers.()V", this, null);
	}

	private static Delegate GetGetDrawerLockMode_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetDrawerLockMode_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDrawerLockMode_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawerView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			return drawerLayout.GetDrawerLockMode(drawerView);
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

	[Register("getDrawerLockMode", "(Landroid/view/View;)I", "GetGetDrawerLockMode_Landroid_view_View_Handler")]
	public unsafe virtual int GetDrawerLockMode(View drawerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDrawerLockMode.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetGetDrawerLockMode_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetDrawerLockMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDrawerLockMode_I(nint jnienv, nint native__this, int edgeGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDrawerLockMode(edgeGravity);
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

	[Register("getDrawerLockMode", "(I)I", "GetGetDrawerLockMode_IHandler")]
	public unsafe virtual int GetDrawerLockMode(int edgeGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(edgeGravity);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getDrawerLockMode.(I)I", this, ptr);
	}

	private static Delegate GetGetDrawerTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetDrawerTitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDrawerTitle_I(nint jnienv, nint native__this, int edgeGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDrawerTitleFormatted(edgeGravity));
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

	[Register("getDrawerTitle", "(I)Ljava/lang/CharSequence;", "GetGetDrawerTitle_IHandler")]
	public unsafe virtual ICharSequence? GetDrawerTitleFormatted(int edgeGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(edgeGravity);
		return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDrawerTitle.(I)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public string? GetDrawerTitle(int edgeGravity)
	{
		return GetDrawerTitleFormatted(edgeGravity)?.ToString();
	}

	private static Delegate GetIsDrawerOpen_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsDrawerOpen_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDrawerOpen_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawer = Java.Lang.Object.GetObject<View>(native_drawer, JniHandleOwnership.DoNotTransfer);
			return drawerLayout.IsDrawerOpen(drawer) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isDrawerOpen", "(Landroid/view/View;)Z", "GetIsDrawerOpen_Landroid_view_View_Handler")]
	public unsafe virtual bool IsDrawerOpen(View drawer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawer?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerOpen.(Landroid/view/View;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawer);
		}
	}

	private static Delegate GetIsDrawerOpen_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_IsDrawerOpen_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDrawerOpen_I(nint jnienv, nint native__this, int drawerGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDrawerOpen(drawerGravity) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isDrawerOpen", "(I)Z", "GetIsDrawerOpen_IHandler")]
	public unsafe virtual bool IsDrawerOpen(int drawerGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(drawerGravity);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerOpen.(I)Z", this, ptr);
	}

	private static Delegate GetIsDrawerVisible_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsDrawerVisible_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDrawerVisible_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawer = Java.Lang.Object.GetObject<View>(native_drawer, JniHandleOwnership.DoNotTransfer);
			return drawerLayout.IsDrawerVisible(drawer) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isDrawerVisible", "(Landroid/view/View;)Z", "GetIsDrawerVisible_Landroid_view_View_Handler")]
	public unsafe virtual bool IsDrawerVisible(View drawer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawer?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerVisible.(Landroid/view/View;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawer);
		}
	}

	private static Delegate GetIsDrawerVisible_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_IsDrawerVisible_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDrawerVisible_I(nint jnienv, nint native__this, int drawerGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDrawerVisible(drawerGravity) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isDrawerVisible", "(I)Z", "GetIsDrawerVisible_IHandler")]
	public unsafe virtual bool IsDrawerVisible(int drawerGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(drawerGravity);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerVisible.(I)Z", this, ptr);
	}

	private static Delegate GetOnDraw_Landroid_graphics_Canvas_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnDraw_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDraw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			drawerLayout.OnDraw(c);
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

	[Register("onDraw", "(Landroid/graphics/Canvas;)V", "GetOnDraw_Landroid_graphics_Canvas_Handler")]
	public new unsafe virtual void OnDraw(Canvas c)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new global::_JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int l, int t, int r, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			drawerLayout.OnLayout(changed, l, t, r, b);
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

	[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
	protected unsafe override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(l);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	private static Delegate GetOpenHandler()
	{
		return new global::_JniMarshal_PP_V(n_Open);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Open(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Open();
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

	[Register("open", "()V", "GetOpenHandler")]
	public unsafe virtual void Open()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("open.()V", this, null);
	}

	private static Delegate GetOpenDrawer_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OpenDrawer_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OpenDrawer_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawerView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.OpenDrawer(drawerView);
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

	[Register("openDrawer", "(Landroid/view/View;)V", "GetOpenDrawer_Landroid_view_View_Handler")]
	public unsafe virtual void OpenDrawer(View drawerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetOpenDrawer_Landroid_view_View_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_OpenDrawer_Landroid_view_View_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OpenDrawer_Landroid_view_View_Z(nint jnienv, nint native__this, nint native_drawerView, sbyte native_animate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			bool animate = native_animate != 0;
			drawerLayout.OpenDrawer(drawerView, animate);
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

	[Register("openDrawer", "(Landroid/view/View;Z)V", "GetOpenDrawer_Landroid_view_View_ZHandler")]
	public unsafe virtual void OpenDrawer(View drawerView, bool animate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(animate ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(Landroid/view/View;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetOpenDrawer_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OpenDrawer_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OpenDrawer_I(nint jnienv, nint native__this, int gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OpenDrawer(gravity);
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

	[Register("openDrawer", "(I)V", "GetOpenDrawer_IHandler")]
	public unsafe virtual void OpenDrawer(int gravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(gravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(I)V", this, ptr);
	}

	private static Delegate GetOpenDrawer_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_OpenDrawer_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OpenDrawer_IZ(nint jnienv, nint native__this, int gravity, sbyte native_animate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool animate = native_animate != 0;
			drawerLayout.OpenDrawer(gravity, animate);
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

	[Register("openDrawer", "(IZ)V", "GetOpenDrawer_IZHandler")]
	public unsafe virtual void OpenDrawer(int gravity, bool animate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(gravity);
		ptr[1] = new JniArgumentValue(animate ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("openDrawer.(IZ)V", this, ptr);
	}

	private static Delegate GetRemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDrawerListener listener = Java.Lang.Object.GetObject<IDrawerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			drawerLayout.RemoveDrawerListener(listener);
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

	[Register("removeDrawerListener", "(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", "GetRemoveDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler")]
	public unsafe virtual void RemoveDrawerListener(IDrawerListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeDrawerListener.(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetChildInsets_Landroidx_core_view_WindowInsetsCompat_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_SetChildInsets_Landroidx_core_view_WindowInsetsCompat_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChildInsets_Landroidx_core_view_WindowInsetsCompat_Z(nint jnienv, nint native__this, nint native_insets, sbyte native_draw)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WindowInsetsCompat insets = Java.Lang.Object.GetObject<WindowInsetsCompat>(native_insets, JniHandleOwnership.DoNotTransfer);
			bool draw = native_draw != 0;
			drawerLayout.SetChildInsets(insets, draw);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setChildInsets", "(Landroidx/core/view/WindowInsetsCompat;Z)V", "GetSetChildInsets_Landroidx_core_view_WindowInsetsCompat_ZHandler")]
	public unsafe virtual void SetChildInsets(WindowInsetsCompat? insets, bool draw)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(draw ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setChildInsets.(Landroidx/core/view/WindowInsetsCompat;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(insets);
		}
	}

	[Obsolete]
	private static Delegate GetSetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDrawerListener drawerListener = Java.Lang.Object.GetObject<IDrawerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerListener(drawerListener);
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

	[Obsolete("deprecated")]
	[Register("setDrawerListener", "(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", "GetSetDrawerListener_Landroidx_drawerlayout_widget_DrawerLayout_DrawerListener_Handler")]
	public unsafe virtual void SetDrawerListener(IDrawerListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerListener.(Landroidx/drawerlayout/widget/DrawerLayout$DrawerListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetDrawerLockMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDrawerLockMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerLockMode_I(nint jnienv, nint native__this, int lockMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDrawerLockMode(lockMode);
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

	[Register("setDrawerLockMode", "(I)V", "GetSetDrawerLockMode_IHandler")]
	public unsafe virtual void SetDrawerLockMode(int lockMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(lockMode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerLockMode.(I)V", this, ptr);
	}

	private static Delegate GetSetDrawerLockMode_ILandroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_SetDrawerLockMode_ILandroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerLockMode_ILandroid_view_View_(nint jnienv, nint native__this, int lockMode, nint native_drawerView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View drawerView = Java.Lang.Object.GetObject<View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerLockMode(lockMode, drawerView);
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

	[Register("setDrawerLockMode", "(ILandroid/view/View;)V", "GetSetDrawerLockMode_ILandroid_view_View_Handler")]
	public unsafe virtual void SetDrawerLockMode(int lockMode, View drawerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(lockMode);
			ptr[1] = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerLockMode.(ILandroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetSetDrawerLockMode_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetDrawerLockMode_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerLockMode_II(nint jnienv, nint native__this, int lockMode, int edgeGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDrawerLockMode(lockMode, edgeGravity);
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

	[Register("setDrawerLockMode", "(II)V", "GetSetDrawerLockMode_IIHandler")]
	public unsafe virtual void SetDrawerLockMode(int lockMode, int edgeGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(lockMode);
		ptr[1] = new JniArgumentValue(edgeGravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerLockMode.(II)V", this, ptr);
	}

	private static Delegate GetSetDrawerShadow_Landroid_graphics_drawable_Drawable_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetDrawerShadow_Landroid_graphics_drawable_Drawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerShadow_Landroid_graphics_drawable_Drawable_I(nint jnienv, nint native__this, nint native_shadowDrawable, int gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable shadowDrawable = Java.Lang.Object.GetObject<Drawable>(native_shadowDrawable, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerShadow(shadowDrawable, gravity);
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

	[Register("setDrawerShadow", "(Landroid/graphics/drawable/Drawable;I)V", "GetSetDrawerShadow_Landroid_graphics_drawable_Drawable_IHandler")]
	public unsafe virtual void SetDrawerShadow(Drawable? shadowDrawable, int gravity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(shadowDrawable?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(gravity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerShadow.(Landroid/graphics/drawable/Drawable;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shadowDrawable);
		}
	}

	private static Delegate GetSetDrawerShadow_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetDrawerShadow_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerShadow_II(nint jnienv, nint native__this, int resId, int gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDrawerShadow(resId, gravity);
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

	[Register("setDrawerShadow", "(II)V", "GetSetDrawerShadow_IIHandler")]
	public unsafe virtual void SetDrawerShadow(int resId, int gravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(resId);
		ptr[1] = new JniArgumentValue(gravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerShadow.(II)V", this, ptr);
	}

	private static Delegate GetSetDrawerTitle_ILjava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_SetDrawerTitle_ILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerTitle_ILjava_lang_CharSequence_(nint jnienv, nint native__this, int edgeGravity, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetDrawerTitle(edgeGravity, title);
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

	[Register("setDrawerTitle", "(ILjava/lang/CharSequence;)V", "GetSetDrawerTitle_ILjava_lang_CharSequence_Handler")]
	public unsafe virtual void SetDrawerTitle(int edgeGravity, ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(edgeGravity);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerTitle.(ILjava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public void SetDrawerTitle(int edgeGravity, string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		SetDrawerTitle(edgeGravity, obj);
		obj?.Dispose();
	}

	private static Delegate GetSetScrimColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetScrimColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScrimColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScrimColor(color);
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

	[Register("setScrimColor", "(I)V", "GetSetScrimColor_IHandler")]
	public unsafe virtual void SetScrimColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScrimColor.(I)V", this, ptr);
	}

	private static Delegate GetSetStatusBarBackground_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStatusBarBackground_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarBackground_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_bg)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			DrawerLayout? drawerLayout = Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable statusBarBackground = Java.Lang.Object.GetObject<Drawable>(native_bg, JniHandleOwnership.DoNotTransfer);
			drawerLayout.SetStatusBarBackground(statusBarBackground);
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

	[Register("setStatusBarBackground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetStatusBarBackground_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetStatusBarBackground(Drawable? bg)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bg?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bg);
		}
	}

	private static Delegate GetSetStatusBarBackground_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStatusBarBackground_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarBackground_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackground(resId);
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

	[Register("setStatusBarBackground", "(I)V", "GetSetStatusBarBackground_IHandler")]
	public unsafe virtual void SetStatusBarBackground(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackground.(I)V", this, ptr);
	}

	private static Delegate GetSetStatusBarBackgroundColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStatusBarBackgroundColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarBackgroundColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<DrawerLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackgroundColor(color);
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

	[Register("setStatusBarBackgroundColor", "(I)V", "GetSetStatusBarBackgroundColor_IHandler")]
	public unsafe virtual void SetStatusBarBackgroundColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackgroundColor.(I)V", this, ptr);
	}

	private IDrawerListenerImplementor __CreateIDrawerListenerImplementor()
	{
		return new IDrawerListenerImplementor(this);
	}
}

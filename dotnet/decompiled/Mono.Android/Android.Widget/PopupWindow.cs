using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/PopupWindow", DoNotGenerateAcw = true)]
public class PopupWindow : Java.Lang.Object
{
	[Register("android/widget/PopupWindow$OnDismissListener", "", "Android.Widget.PopupWindow/IOnDismissListenerInvoker")]
	public interface IOnDismissListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onDismiss", "()V", "GetOnDismissHandler:Android.Widget.PopupWindow/IOnDismissListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnDismiss();
	}

	[Register("android/widget/PopupWindow$OnDismissListener", DoNotGenerateAcw = true)]
	internal class IOnDismissListenerInvoker : Java.Lang.Object, IOnDismissListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_widget_PopupWindow_OnDismissListener = new XAPeerMembers("android/widget/PopupWindow$OnDismissListener", typeof(IOnDismissListenerInvoker));

		private static Delegate? cb_onDismiss_OnDismiss_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_widget_PopupWindow_OnDismissListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_widget_PopupWindow_OnDismissListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_widget_PopupWindow_OnDismissListener.ManagedPeerType;

		public IOnDismissListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDismiss(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnDismissListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDismiss();
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

		public unsafe void OnDismiss()
		{
			_members_android_widget_PopupWindow_OnDismissListener.InstanceMethods.InvokeAbstractVoidMethod("onDismiss.()V", this, null);
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
		private static void n_OnDismiss_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDismiss(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("mono/android/widget/PopupWindow_OnDismissListenerImplementor")]
	internal sealed class IOnDismissListenerImplementor : Java.Lang.Object, IOnDismissListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler? Handler;

		public unsafe IOnDismissListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnDismiss()
		{
			Handler?.Invoke(sender, new EventArgs());
		}

		internal static bool __IsEmpty(IOnDismissListenerImplementor value)
		{
			return value.Handler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/PopupWindow", typeof(PopupWindow));

	private static Delegate? cb_getContentView_GetContentView_Landroid_view_View_;

	private static Delegate? cb_setContentView_SetContentView_Landroid_view_View__V;

	private static Delegate? cb_setFocusable_SetFocusable_Z_V;

	private static Delegate? cb_getHeight_GetHeight_I;

	private static Delegate? cb_setOutsideTouchable_SetOutsideTouchable_Z_V;

	private static Delegate? cb_setSoftInputMode_SetSoftInputMode_I_V;

	private static Delegate? cb_setTouchable_SetTouchable_Z_V;

	private static Delegate? cb_getWidth_GetWidth_I;

	private static Delegate? cb_setWindowLayoutType_SetWindowLayoutType_I_V;

	private static Delegate? cb_dismiss_Dismiss_V;

	private static Delegate? cb_setBackgroundDrawable_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setOnDismissListener_SetOnDismissListener_Landroid_widget_PopupWindow_OnDismissListener__V;

	private static Delegate? cb_setTouchInterceptor_SetTouchInterceptor_Landroid_view_View_OnTouchListener__V;

	private static Delegate? cb_showAsDropDown_ShowAsDropDown_Landroid_view_View_III_V;

	private static Delegate? cb_showAtLocation_ShowAtLocation_Landroid_view_View_III_V;

	private WeakReference? weak_implementor_SetOnDismissListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual View? ContentView
	{
		[Register("getContentView", "()Landroid/view/View;", "GetGetContentViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setContentView", "(Landroid/view/View;)V", "GetSetContentView_Landroid_view_View_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setContentView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool Focusable
	{
		[Register("setFocusable", "(Z)V", "GetSetFocusable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFocusable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.()I", this, null);
		}
	}

	public unsafe virtual bool OutsideTouchable
	{
		[Register("setOutsideTouchable", "(Z)V", "GetSetOutsideTouchable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOutsideTouchable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual SoftInput SoftInputMode
	{
		[Register("setSoftInputMode", "(I)V", "GetSetSoftInputMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSoftInputMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool Touchable
	{
		[Register("setTouchable", "(Z)V", "GetSetTouchable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTouchable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.()I", this, null);
		}
	}

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual WindowManagerTypes WindowLayoutType
	{
		[SupportedOSPlatform("android23.0")]
		[Register("setWindowLayoutType", "(I)V", "GetSetWindowLayoutType_IHandler", ApiSince = 23)]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWindowLayoutType.(I)V", this, ptr);
		}
	}

	public event EventHandler DismissEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnDismissListener, IOnDismissListenerImplementor>(ref weak_implementor_SetOnDismissListener, __CreateIOnDismissListenerImplementor, SetOnDismissListener, delegate(IOnDismissListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnDismissListener, IOnDismissListenerImplementor>(ref weak_implementor_SetOnDismissListener, IOnDismissListenerImplementor.__IsEmpty, delegate
			{
				SetOnDismissListener(null);
			}, delegate(IOnDismissListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected PopupWindow(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe PopupWindow(Context? context, IAttributeSet? attrs, int defStyleAttr)
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
	public unsafe PopupWindow(Context? context, IAttributeSet? attrs)
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

	[Register(".ctor", "(Landroid/view/View;II)V", "")]
	public unsafe PopupWindow(View? contentView, int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(contentView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(width);
			ptr[2] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(contentView);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe PopupWindow(int width, int height)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}

	private static Delegate GetGetContentViewHandler()
	{
		return new _JniMarshal_PP_L(n_GetContentView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentView);
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

	private static Delegate GetSetContentView_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetContentView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentView_Landroid_view_View_(nint jnienv, nint native__this, nint native_contentView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View contentView = Java.Lang.Object.GetObject<View>(native_contentView, JniHandleOwnership.DoNotTransfer);
			popupWindow.ContentView = contentView;
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

	private static Delegate GetSetFocusable_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetFocusable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFocusable_Z(nint jnienv, nint native__this, sbyte native_focusable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool focusable = native_focusable != 0;
			popupWindow.Focusable = focusable;
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

	private static Delegate GetGetHeightHandler()
	{
		return new _JniMarshal_PP_I(n_GetHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
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

	private static Delegate GetSetOutsideTouchable_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetOutsideTouchable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOutsideTouchable_Z(nint jnienv, nint native__this, sbyte native_touchable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool outsideTouchable = native_touchable != 0;
			popupWindow.OutsideTouchable = outsideTouchable;
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

	private static Delegate GetSetSoftInputMode_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetSoftInputMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSoftInputMode_I(nint jnienv, nint native__this, int native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SoftInputMode = (SoftInput)native_mode;
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

	private static Delegate GetSetTouchable_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetTouchable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTouchable_Z(nint jnienv, nint native__this, sbyte native_touchable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool touchable = native_touchable != 0;
			popupWindow.Touchable = touchable;
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

	private static Delegate GetGetWidthHandler()
	{
		return new _JniMarshal_PP_I(n_GetWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
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

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetSetWindowLayoutType_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetWindowLayoutType_I);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWindowLayoutType_I(nint jnienv, nint native__this, int native_layoutType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WindowLayoutType = (WindowManagerTypes)native_layoutType;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dismiss(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismiss();
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

	[Register("dismiss", "()V", "GetDismissHandler")]
	public unsafe virtual void Dismiss()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismiss.()V", this, null);
	}

	private static Delegate GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_background)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable backgroundDrawable = Java.Lang.Object.GetObject<Drawable>(native_background, JniHandleOwnership.DoNotTransfer);
			popupWindow.SetBackgroundDrawable(backgroundDrawable);
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

	[Register("setBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetBackgroundDrawable(Drawable? background)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(background?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBackgroundDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(background);
		}
	}

	private static Delegate GetSetOnDismissListener_Landroid_widget_PopupWindow_OnDismissListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnDismissListener_Landroid_widget_PopupWindow_OnDismissListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnDismissListener_Landroid_widget_PopupWindow_OnDismissListener_(nint jnienv, nint native__this, nint native_onDismissListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnDismissListener onDismissListener = Java.Lang.Object.GetObject<IOnDismissListener>(native_onDismissListener, JniHandleOwnership.DoNotTransfer);
			popupWindow.SetOnDismissListener(onDismissListener);
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

	[Register("setOnDismissListener", "(Landroid/widget/PopupWindow$OnDismissListener;)V", "GetSetOnDismissListener_Landroid_widget_PopupWindow_OnDismissListener_Handler")]
	public unsafe virtual void SetOnDismissListener(IOnDismissListener? onDismissListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((onDismissListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onDismissListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnDismissListener.(Landroid/widget/PopupWindow$OnDismissListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onDismissListener);
		}
	}

	private static Delegate GetSetTouchInterceptor_Landroid_view_View_OnTouchListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetTouchInterceptor_Landroid_view_View_OnTouchListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTouchInterceptor_Landroid_view_View_OnTouchListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View.IOnTouchListener touchInterceptor = Java.Lang.Object.GetObject<View.IOnTouchListener>(native_l, JniHandleOwnership.DoNotTransfer);
			popupWindow.SetTouchInterceptor(touchInterceptor);
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

	[Register("setTouchInterceptor", "(Landroid/view/View$OnTouchListener;)V", "GetSetTouchInterceptor_Landroid_view_View_OnTouchListener_Handler")]
	public unsafe virtual void SetTouchInterceptor(View.IOnTouchListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTouchInterceptor.(Landroid/view/View$OnTouchListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	private static Delegate GetShowAsDropDown_Landroid_view_View_IIIHandler()
	{
		return new _JniMarshal_PPLIII_V(n_ShowAsDropDown_Landroid_view_View_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ShowAsDropDown_Landroid_view_View_III(nint jnienv, nint native__this, nint native_anchor, int xoff, int yoff, int native_gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View anchor = Java.Lang.Object.GetObject<View>(native_anchor, JniHandleOwnership.DoNotTransfer);
			popupWindow.ShowAsDropDown(anchor, xoff, yoff, (GravityFlags)native_gravity);
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

	[Register("showAsDropDown", "(Landroid/view/View;III)V", "GetShowAsDropDown_Landroid_view_View_IIIHandler")]
	public unsafe virtual void ShowAsDropDown(View? anchor, int xoff, int yoff, GravityFlags gravity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(xoff);
			ptr[2] = new JniArgumentValue(yoff);
			ptr[3] = new JniArgumentValue((int)gravity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("showAsDropDown.(Landroid/view/View;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchor);
		}
	}

	private static Delegate GetShowAtLocation_Landroid_view_View_IIIHandler()
	{
		return new _JniMarshal_PPLIII_V(n_ShowAtLocation_Landroid_view_View_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ShowAtLocation_Landroid_view_View_III(nint jnienv, nint native__this, nint native_parent, int native_gravity, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PopupWindow? popupWindow = Java.Lang.Object.GetObject<PopupWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View parent = Java.Lang.Object.GetObject<View>(native_parent, JniHandleOwnership.DoNotTransfer);
			popupWindow.ShowAtLocation(parent, (GravityFlags)native_gravity, x, y);
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

	[Register("showAtLocation", "(Landroid/view/View;III)V", "GetShowAtLocation_Landroid_view_View_IIIHandler")]
	public unsafe virtual void ShowAtLocation(View? parent, GravityFlags gravity, int x, int y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)gravity);
			ptr[2] = new JniArgumentValue(x);
			ptr[3] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeVirtualVoidMethod("showAtLocation.(Landroid/view/View;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parent);
		}
	}

	private IOnDismissListenerImplementor __CreateIOnDismissListenerImplementor()
	{
		return new IOnDismissListenerImplementor(this);
	}

	[UnmanagedCallersOnly]
	private static void n_Dismiss_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Dismiss(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}

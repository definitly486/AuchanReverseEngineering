using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views.Accessibility;
using Android.Views.Animations;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/View", DoNotGenerateAcw = true)]
public class View : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/view/View$AccessibilityDelegate", DoNotGenerateAcw = true)]
	public class AccessibilityDelegate : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/View$AccessibilityDelegate", typeof(AccessibilityDelegate));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AccessibilityDelegate(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/view/View$DragShadowBuilder", DoNotGenerateAcw = true)]
	public class DragShadowBuilder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/View$DragShadowBuilder", typeof(DragShadowBuilder));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected DragShadowBuilder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("android/view/View$MeasureSpec", DoNotGenerateAcw = true)]
	public class MeasureSpec : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/View$MeasureSpec", typeof(MeasureSpec));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected MeasureSpec(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getMode", "(I)I", "")]
		public unsafe static MeasureSpecMode GetMode(int measureSpec)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(measureSpec);
			return (MeasureSpecMode)_members.StaticMethods.InvokeInt32Method("getMode.(I)I", ptr);
		}

		[Register("getSize", "(I)I", "")]
		public unsafe static int GetSize(int measureSpec)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(measureSpec);
			return _members.StaticMethods.InvokeInt32Method("getSize.(I)I", ptr);
		}

		[Register("makeMeasureSpec", "(II)I", "")]
		public unsafe static int MakeMeasureSpec(int size, MeasureSpecMode mode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(size);
			ptr[1] = new JniArgumentValue((int)mode);
			return _members.StaticMethods.InvokeInt32Method("makeMeasureSpec.(II)I", ptr);
		}
	}

	[Register("android/view/View$OnAttachStateChangeListener", "", "Android.Views.View/IOnAttachStateChangeListenerInvoker")]
	public interface IOnAttachStateChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onViewAttachedToWindow", "(Landroid/view/View;)V", "GetOnViewAttachedToWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnViewAttachedToWindow(View attachedView);

		[Register("onViewDetachedFromWindow", "(Landroid/view/View;)V", "GetOnViewDetachedFromWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnViewDetachedFromWindow(View detachedView);
	}

	[Register("android/view/View$OnAttachStateChangeListener", DoNotGenerateAcw = true)]
	internal class IOnAttachStateChangeListenerInvoker : Java.Lang.Object, IOnAttachStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnAttachStateChangeListener = new XAPeerMembers("android/view/View$OnAttachStateChangeListener", typeof(IOnAttachStateChangeListenerInvoker));

		private static Delegate? cb_onViewAttachedToWindow_OnViewAttachedToWindow_Landroid_view_View__V;

		private static Delegate? cb_onViewDetachedFromWindow_OnViewDetachedFromWindow_Landroid_view_View__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnAttachStateChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnAttachStateChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnAttachStateChangeListener.ManagedPeerType;

		public IOnAttachStateChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnViewAttachedToWindow_Landroid_view_View_(nint jnienv, nint native__this, nint native_attachedView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnAttachStateChangeListener? onAttachStateChangeListener = Java.Lang.Object.GetObject<IOnAttachStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View attachedView = Java.Lang.Object.GetObject<View>(native_attachedView, JniHandleOwnership.DoNotTransfer);
				onAttachStateChangeListener.OnViewAttachedToWindow(attachedView);
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

		public unsafe void OnViewAttachedToWindow(View attachedView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(attachedView?.Handle ?? IntPtr.Zero);
				_members_android_view_View_OnAttachStateChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onViewAttachedToWindow.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(attachedView);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnViewDetachedFromWindow_Landroid_view_View_(nint jnienv, nint native__this, nint native_detachedView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnAttachStateChangeListener? onAttachStateChangeListener = Java.Lang.Object.GetObject<IOnAttachStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View detachedView = Java.Lang.Object.GetObject<View>(native_detachedView, JniHandleOwnership.DoNotTransfer);
				onAttachStateChangeListener.OnViewDetachedFromWindow(detachedView);
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

		public unsafe void OnViewDetachedFromWindow(View detachedView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(detachedView?.Handle ?? IntPtr.Zero);
				_members_android_view_View_OnAttachStateChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onViewDetachedFromWindow.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(detachedView);
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
		private static void n_OnViewAttachedToWindow_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_attachedView)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnViewAttachedToWindow_Landroid_view_View_(jnienv, native__this, native_attachedView);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnViewDetachedFromWindow_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_detachedView)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnViewDetachedFromWindow_Landroid_view_View_(jnienv, native__this, native_detachedView);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ViewAttachedToWindowEventArgs : EventArgs
	{
		private View attachedView;

		public View AttachedView => attachedView;

		public ViewAttachedToWindowEventArgs(View attachedView)
		{
			this.attachedView = attachedView;
		}
	}

	public class ViewDetachedFromWindowEventArgs : EventArgs
	{
		private View detachedView;

		public ViewDetachedFromWindowEventArgs(View detachedView)
		{
			this.detachedView = detachedView;
		}
	}

	[Register("mono/android/view/View_OnAttachStateChangeListenerImplementor")]
	internal sealed class IOnAttachStateChangeListenerImplementor : Java.Lang.Object, IOnAttachStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ViewAttachedToWindowEventArgs>? OnViewAttachedToWindowHandler;

		public EventHandler<ViewDetachedFromWindowEventArgs>? OnViewDetachedFromWindowHandler;

		public unsafe IOnAttachStateChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnViewAttachedToWindow(View attachedView)
		{
			OnViewAttachedToWindowHandler?.Invoke(sender, new ViewAttachedToWindowEventArgs(attachedView));
		}

		public void OnViewDetachedFromWindow(View detachedView)
		{
			OnViewDetachedFromWindowHandler?.Invoke(sender, new ViewDetachedFromWindowEventArgs(detachedView));
		}

		internal static bool __IsEmpty(IOnAttachStateChangeListenerImplementor value)
		{
			if (value.OnViewAttachedToWindowHandler == null)
			{
				return value.OnViewDetachedFromWindowHandler == null;
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

	[Register("android/view/View$OnClickListener", "", "Android.Views.View/IOnClickListenerInvoker")]
	public interface IOnClickListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onClick", "(Landroid/view/View;)V", "GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnClick(View? v);
	}

	[Register("android/view/View$OnClickListener", DoNotGenerateAcw = true)]
	internal class IOnClickListenerInvoker : Java.Lang.Object, IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnClickListener = new XAPeerMembers("android/view/View$OnClickListener", typeof(IOnClickListenerInvoker));

		private static Delegate? cb_onClick_OnClick_Landroid_view_View__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnClickListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnClickListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnClickListener.ManagedPeerType;

		public IOnClickListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnClick_Landroid_view_View_(nint jnienv, nint native__this, nint native_v)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnClickListener? onClickListener = Java.Lang.Object.GetObject<IOnClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				onClickListener.OnClick(v);
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

		public unsafe void OnClick(View? v)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				_members_android_view_View_OnClickListener.InstanceMethods.InvokeAbstractVoidMethod("onClick.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
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
		private static void n_OnClick_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_v)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnClick_Landroid_view_View_(jnienv, native__this, native_v);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("mono/android/view/View_OnClickListenerImplementor")]
	internal sealed class IOnClickListenerImplementor : Java.Lang.Object, IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler? Handler;

		public unsafe IOnClickListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public void OnClick(View? v)
		{
			Handler?.Invoke(v, new EventArgs());
		}

		internal static bool __IsEmpty(IOnClickListenerImplementor value)
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

	[Register("android/view/View$OnFocusChangeListener", "", "Android.Views.View/IOnFocusChangeListenerInvoker")]
	public interface IOnFocusChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onFocusChange", "(Landroid/view/View;Z)V", "GetOnFocusChange_Landroid_view_View_ZHandler:Android.Views.View/IOnFocusChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnFocusChange(View? v, bool hasFocus);
	}

	[Register("android/view/View$OnFocusChangeListener", DoNotGenerateAcw = true)]
	internal class IOnFocusChangeListenerInvoker : Java.Lang.Object, IOnFocusChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnFocusChangeListener = new XAPeerMembers("android/view/View$OnFocusChangeListener", typeof(IOnFocusChangeListenerInvoker));

		private static Delegate? cb_onFocusChange_OnFocusChange_Landroid_view_View_Z_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnFocusChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnFocusChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnFocusChangeListener.ManagedPeerType;

		public IOnFocusChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnFocusChange_Landroid_view_View_Z(nint jnienv, nint native__this, nint native_v, sbyte native_hasFocus)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnFocusChangeListener? onFocusChangeListener = Java.Lang.Object.GetObject<IOnFocusChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				bool hasFocus = native_hasFocus != 0;
				onFocusChangeListener.OnFocusChange(v, hasFocus);
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

		public unsafe void OnFocusChange(View? v, bool hasFocus)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(hasFocus ? ((sbyte)1) : ((sbyte)0));
				_members_android_view_View_OnFocusChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onFocusChange.(Landroid/view/View;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
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
		private static void n_OnFocusChange_Landroid_view_View_Z_mm_wrapper(nint jnienv, nint native__this, nint native_v, sbyte native_hasFocus)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnFocusChange_Landroid_view_View_Z(jnienv, native__this, native_v, native_hasFocus);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class FocusChangeEventArgs : EventArgs
	{
		private bool hasFocus;

		public bool HasFocus => hasFocus;

		public FocusChangeEventArgs(bool hasFocus)
		{
			this.hasFocus = hasFocus;
		}
	}

	[Register("mono/android/view/View_OnFocusChangeListenerImplementor")]
	internal sealed class IOnFocusChangeListenerImplementor : Java.Lang.Object, IOnFocusChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<FocusChangeEventArgs>? Handler;

		public unsafe IOnFocusChangeListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public void OnFocusChange(View? v, bool hasFocus)
		{
			Handler?.Invoke(v, new FocusChangeEventArgs(hasFocus));
		}

		internal static bool __IsEmpty(IOnFocusChangeListenerImplementor value)
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

	[Register("android/view/View$OnKeyListener", "", "Android.Views.View/IOnKeyListenerInvoker")]
	public interface IOnKeyListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onKey", "(Landroid/view/View;ILandroid/view/KeyEvent;)Z", "GetOnKey_Landroid_view_View_ILandroid_view_KeyEvent_Handler:Android.Views.View/IOnKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnKey(View? v, Keycode keyCode, KeyEvent? e);
	}

	[Register("android/view/View$OnKeyListener", DoNotGenerateAcw = true)]
	internal class IOnKeyListenerInvoker : Java.Lang.Object, IOnKeyListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnKeyListener = new XAPeerMembers("android/view/View$OnKeyListener", typeof(IOnKeyListenerInvoker));

		private static Delegate? cb_onKey_OnKey_Landroid_view_View_ILandroid_view_KeyEvent__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnKeyListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnKeyListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnKeyListener.ManagedPeerType;

		public IOnKeyListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnKey_Landroid_view_View_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_v, int native_keyCode, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnKeyListener? onKeyListener = Java.Lang.Object.GetObject<IOnKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onKeyListener.OnKey(v, (Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnKey(View? v, Keycode keyCode, KeyEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((int)keyCode);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_View_OnKeyListener.InstanceMethods.InvokeAbstractBooleanMethod("onKey.(Landroid/view/View;ILandroid/view/KeyEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
				GC.KeepAlive(e);
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
		private static sbyte n_OnKey_Landroid_view_View_ILandroid_view_KeyEvent__mm_wrapper(nint jnienv, nint native__this, nint native_v, int native_keyCode, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnKey_Landroid_view_View_ILandroid_view_KeyEvent_(jnienv, native__this, native_v, native_keyCode, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("android/view/View$OnLayoutChangeListener", "", "Android.Views.View/IOnLayoutChangeListenerInvoker")]
	public interface IOnLayoutChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onLayoutChange", "(Landroid/view/View;IIIIIIII)V", "GetOnLayoutChange_Landroid_view_View_IIIIIIIIHandler:Android.Views.View/IOnLayoutChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnLayoutChange(View? v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom);
	}

	[Register("android/view/View$OnLayoutChangeListener", DoNotGenerateAcw = true)]
	internal class IOnLayoutChangeListenerInvoker : Java.Lang.Object, IOnLayoutChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnLayoutChangeListener = new XAPeerMembers("android/view/View$OnLayoutChangeListener", typeof(IOnLayoutChangeListenerInvoker));

		private static Delegate? cb_onLayoutChange_OnLayoutChange_Landroid_view_View_IIIIIIII_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnLayoutChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnLayoutChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnLayoutChangeListener.ManagedPeerType;

		public IOnLayoutChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLayoutChange_Landroid_view_View_IIIIIIII(nint jnienv, nint native__this, nint native_v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnLayoutChangeListener? onLayoutChangeListener = Java.Lang.Object.GetObject<IOnLayoutChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				onLayoutChangeListener.OnLayoutChange(v, left, top, right, bottom, oldLeft, oldTop, oldRight, oldBottom);
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

		public unsafe void OnLayoutChange(View? v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(left);
				ptr[2] = new JniArgumentValue(top);
				ptr[3] = new JniArgumentValue(right);
				ptr[4] = new JniArgumentValue(bottom);
				ptr[5] = new JniArgumentValue(oldLeft);
				ptr[6] = new JniArgumentValue(oldTop);
				ptr[7] = new JniArgumentValue(oldRight);
				ptr[8] = new JniArgumentValue(oldBottom);
				_members_android_view_View_OnLayoutChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onLayoutChange.(Landroid/view/View;IIIIIIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
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
		private static void n_OnLayoutChange_Landroid_view_View_IIIIIIII_mm_wrapper(nint jnienv, nint native__this, nint native_v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnLayoutChange_Landroid_view_View_IIIIIIII(jnienv, native__this, native_v, left, top, right, bottom, oldLeft, oldTop, oldRight, oldBottom);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class LayoutChangeEventArgs : EventArgs
	{
		private int left;

		private int top;

		private int right;

		private int bottom;

		private int oldLeft;

		private int oldTop;

		private int oldRight;

		private int oldBottom;

		public int Right => right;

		public int Bottom => bottom;

		public int OldBottom => oldBottom;

		public LayoutChangeEventArgs(int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
			this.oldLeft = oldLeft;
			this.oldTop = oldTop;
			this.oldRight = oldRight;
			this.oldBottom = oldBottom;
		}
	}

	[Register("mono/android/view/View_OnLayoutChangeListenerImplementor")]
	internal sealed class IOnLayoutChangeListenerImplementor : Java.Lang.Object, IOnLayoutChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<LayoutChangeEventArgs>? Handler;

		public unsafe IOnLayoutChangeListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public void OnLayoutChange(View? v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
		{
			Handler?.Invoke(v, new LayoutChangeEventArgs(left, top, right, bottom, oldLeft, oldTop, oldRight, oldBottom));
		}

		internal static bool __IsEmpty(IOnLayoutChangeListenerImplementor value)
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

	[Register("android/view/View$OnLongClickListener", "", "Android.Views.View/IOnLongClickListenerInvoker")]
	public interface IOnLongClickListener : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/View$OnLongClickListener", typeof(IOnLongClickListener), isInterface: true);

		private static Delegate? cb_onLongClickUseDefaultHapticFeedback_OnLongClickUseDefaultHapticFeedback_Landroid_view_View__Z;

		[Register("onLongClick", "(Landroid/view/View;)Z", "GetOnLongClick_Landroid_view_View_Handler:Android.Views.View/IOnLongClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnLongClick(View? v);

		[SupportedOSPlatform("android34.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnLongClickUseDefaultHapticFeedback_Landroid_view_View_(nint jnienv, nint native__this, nint native_v)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnLongClickListener? onLongClickListener = Java.Lang.Object.GetObject<IOnLongClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				return onLongClickListener.OnLongClickUseDefaultHapticFeedback(v) ? ((sbyte)1) : ((sbyte)0);
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

		[SupportedOSPlatform("android34.0")]
		[Register("onLongClickUseDefaultHapticFeedback", "(Landroid/view/View;)Z", "GetOnLongClickUseDefaultHapticFeedback_Landroid_view_View_Handler:Android.Views.View/IOnLongClickListener, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 34)]
		unsafe bool OnLongClickUseDefaultHapticFeedback(View v)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onLongClickUseDefaultHapticFeedback.(Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnLongClickUseDefaultHapticFeedback_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_v)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnLongClickUseDefaultHapticFeedback_Landroid_view_View_(jnienv, native__this, native_v);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("android/view/View$OnLongClickListener", DoNotGenerateAcw = true)]
	internal class IOnLongClickListenerInvoker : Java.Lang.Object, IOnLongClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnLongClickListener = new XAPeerMembers("android/view/View$OnLongClickListener", typeof(IOnLongClickListenerInvoker));

		private static Delegate? cb_onLongClick_OnLongClick_Landroid_view_View__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnLongClickListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnLongClickListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnLongClickListener.ManagedPeerType;

		public IOnLongClickListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnLongClick_Landroid_view_View_(nint jnienv, nint native__this, nint native_v)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnLongClickListener? onLongClickListener = Java.Lang.Object.GetObject<IOnLongClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				return onLongClickListener.OnLongClick(v) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnLongClick(View? v)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				return _members_android_view_View_OnLongClickListener.InstanceMethods.InvokeAbstractBooleanMethod("onLongClick.(Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
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
		private static sbyte n_OnLongClick_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_v)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnLongClick_Landroid_view_View_(jnienv, native__this, native_v);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class LongClickEventArgs : EventArgs
	{
		private bool handled;

		public bool Handled
		{
			get
			{
				return handled;
			}
			set
			{
				handled = value;
			}
		}

		public LongClickEventArgs(bool handled)
		{
			this.handled = handled;
		}
	}

	public class LongClickUseDefaultHapticFeedbackEventArgs : EventArgs
	{
		private bool handled;

		private View v;

		public bool Handled => handled;

		public LongClickUseDefaultHapticFeedbackEventArgs(bool handled, View v)
		{
			this.handled = handled;
			this.v = v;
		}
	}

	[Register("mono/android/view/View_OnLongClickListenerImplementor")]
	internal sealed class IOnLongClickListenerImplementor : Java.Lang.Object, IOnLongClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<LongClickEventArgs>? OnLongClickHandler;

		public EventHandler<LongClickUseDefaultHapticFeedbackEventArgs>? OnLongClickUseDefaultHapticFeedbackHandler;

		public unsafe IOnLongClickListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnLongClick(View? v)
		{
			EventHandler<LongClickEventArgs> onLongClickHandler = OnLongClickHandler;
			if (onLongClickHandler == null)
			{
				return false;
			}
			LongClickEventArgs e = new LongClickEventArgs(handled: true);
			onLongClickHandler(sender, e);
			return e.Handled;
		}

		public bool OnLongClickUseDefaultHapticFeedback(View v)
		{
			EventHandler<LongClickUseDefaultHapticFeedbackEventArgs> onLongClickUseDefaultHapticFeedbackHandler = OnLongClickUseDefaultHapticFeedbackHandler;
			if (onLongClickUseDefaultHapticFeedbackHandler == null)
			{
				return false;
			}
			LongClickUseDefaultHapticFeedbackEventArgs e = new LongClickUseDefaultHapticFeedbackEventArgs(handled: true, v);
			onLongClickUseDefaultHapticFeedbackHandler(sender, e);
			return e.Handled;
		}

		internal static bool __IsEmpty(IOnLongClickListenerImplementor value)
		{
			if (value.OnLongClickHandler == null)
			{
				return value.OnLongClickUseDefaultHapticFeedbackHandler == null;
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

	[Register("android/view/View$OnScrollChangeListener", "", "Android.Views.View/IOnScrollChangeListenerInvoker", ApiSince = 23)]
	public interface IOnScrollChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[SupportedOSPlatform("android23.0")]
		[Register("onScrollChange", "(Landroid/view/View;IIII)V", "GetOnScrollChange_Landroid_view_View_IIIIHandler:Android.Views.View/IOnScrollChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 23)]
		void OnScrollChange(View? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY);
	}

	[Register("android/view/View$OnScrollChangeListener", DoNotGenerateAcw = true, ApiSince = 23)]
	internal class IOnScrollChangeListenerInvoker : Java.Lang.Object, IOnScrollChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnScrollChangeListener = new XAPeerMembers("android/view/View$OnScrollChangeListener", typeof(IOnScrollChangeListenerInvoker));

		private static Delegate? cb_onScrollChange_OnScrollChange_Landroid_view_View_IIII_V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnScrollChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnScrollChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnScrollChangeListener.ManagedPeerType;

		public IOnScrollChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[SupportedOSPlatform("android23.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnScrollChange_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnScrollChangeListener? onScrollChangeListener = Java.Lang.Object.GetObject<IOnScrollChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				onScrollChangeListener.OnScrollChange(v, scrollX, scrollY, oldScrollX, oldScrollY);
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

		[SupportedOSPlatform("android23.0")]
		public unsafe void OnScrollChange(View? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(scrollX);
				ptr[2] = new JniArgumentValue(scrollY);
				ptr[3] = new JniArgumentValue(oldScrollX);
				ptr[4] = new JniArgumentValue(oldScrollY);
				_members_android_view_View_OnScrollChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onScrollChange.(Landroid/view/View;IIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
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
		private static void n_OnScrollChange_Landroid_view_View_IIII_mm_wrapper(nint jnienv, nint native__this, nint native_v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnScrollChange_Landroid_view_View_IIII(jnienv, native__this, native_v, scrollX, scrollY, oldScrollX, oldScrollY);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ScrollChangeEventArgs : EventArgs
	{
		private View? v;

		private int scrollX;

		private int scrollY;

		private int oldScrollX;

		private int oldScrollY;

		public ScrollChangeEventArgs(View? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			this.v = v;
			this.scrollX = scrollX;
			this.scrollY = scrollY;
			this.oldScrollX = oldScrollX;
			this.oldScrollY = oldScrollY;
		}
	}

	[Register("mono/android/view/View_OnScrollChangeListenerImplementor", ApiSince = 23)]
	internal sealed class IOnScrollChangeListenerImplementor : Java.Lang.Object, IOnScrollChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ScrollChangeEventArgs>? Handler;

		public unsafe IOnScrollChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnScrollChange(View? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			Handler?.Invoke(sender, new ScrollChangeEventArgs(v, scrollX, scrollY, oldScrollX, oldScrollY));
		}

		internal static bool __IsEmpty(IOnScrollChangeListenerImplementor value)
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

	[Register("android/view/View$OnTouchListener", "", "Android.Views.View/IOnTouchListenerInvoker")]
	public interface IOnTouchListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onTouch", "(Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		bool OnTouch(View? v, MotionEvent? e);
	}

	[Register("android/view/View$OnTouchListener", DoNotGenerateAcw = true)]
	internal class IOnTouchListenerInvoker : Java.Lang.Object, IOnTouchListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_view_View_OnTouchListener = new XAPeerMembers("android/view/View$OnTouchListener", typeof(IOnTouchListenerInvoker));

		private static Delegate? cb_onTouch_OnTouch_Landroid_view_View_Landroid_view_MotionEvent__Z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_view_View_OnTouchListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_view_View_OnTouchListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_view_View_OnTouchListener.ManagedPeerType;

		public IOnTouchListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnTouch_Landroid_view_View_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_v, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnTouchListener? onTouchListener = Java.Lang.Object.GetObject<IOnTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onTouchListener.OnTouch(v, e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe bool OnTouch(View? v, MotionEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_android_view_View_OnTouchListener.InstanceMethods.InvokeAbstractBooleanMethod("onTouch.(Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(v);
				GC.KeepAlive(e);
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
		private static sbyte n_OnTouch_Landroid_view_View_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_v, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnTouch_Landroid_view_View_Landroid_view_MotionEvent_(jnienv, native__this, native_v, native_e);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class TouchEventArgs : EventArgs
	{
		private bool handled;

		private MotionEvent? e;

		public bool Handled
		{
			get
			{
				return handled;
			}
			set
			{
				handled = value;
			}
		}

		public MotionEvent? Event => e;

		public TouchEventArgs(bool handled, MotionEvent? e)
		{
			this.handled = handled;
			this.e = e;
		}
	}

	[Register("mono/android/view/View_OnTouchListenerImplementor")]
	internal sealed class IOnTouchListenerImplementor : Java.Lang.Object, IOnTouchListener, IJavaObject, IDisposable, IJavaPeerable
	{
		public EventHandler<TouchEventArgs>? Handler;

		public unsafe IOnTouchListenerImplementor()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		public bool OnTouch(View? v, MotionEvent? e)
		{
			EventHandler<TouchEventArgs> handler = Handler;
			if (handler == null)
			{
				return false;
			}
			TouchEventArgs e2 = new TouchEventArgs(handled: true, e);
			handler(v, e2);
			return e2.Handled;
		}

		internal static bool __IsEmpty(IOnTouchListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/View", typeof(View));

	private static Delegate? cb_getAccessibilityClassName_GetAccessibilityClassName_Ljava_lang_CharSequence_;

	private static Delegate? cb_isActivated_IsActivated_Z;

	private static Delegate? cb_setActivated_SetActivated_Z_V;

	private static Delegate? cb_getAlpha_GetAlpha_F;

	private static Delegate? cb_setAlpha_SetAlpha_F_V;

	private static Delegate? cb_getBackground_GetBackground_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setBackground_SetBackground_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setBackgroundTintList_SetBackgroundTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setBackgroundTintMode_SetBackgroundTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_getBottomFadingEdgeStrength_GetBottomFadingEdgeStrength_F;

	private static Delegate? cb_isClickable_IsClickable_Z;

	private static Delegate? cb_setClickable_SetClickable_Z_V;

	private static Delegate? cb_getContentDescription_GetContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setContentDescription_SetContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setElevation_SetElevation_F_V;

	private static Delegate? cb_isEnabled_IsEnabled_Z;

	private static Delegate? cb_setEnabled_SetEnabled_Z_V;

	private static Delegate? cb_hasFocus_HasFocus_Z;

	private static Delegate? cb_hasOnClickListeners_HasOnClickListeners_Z;

	private static Delegate? cb_setHorizontalScrollBarEnabled_SetHorizontalScrollBarEnabled_Z_V;

	private static Delegate? cb_setHovered_SetHovered_Z_V;

	private static Delegate? cb_getId_GetId_I;

	private static Delegate? cb_setId_SetId_I_V;

	private static Delegate? cb_isAttachedToWindow_IsAttachedToWindow_Z;

	private static Delegate? cb_isFocused_IsFocused_Z;

	private static Delegate? cb_isHardwareAccelerated_IsHardwareAccelerated_Z;

	private static Delegate? cb_isInEditMode_IsInEditMode_Z;

	private static Delegate? cb_isLayoutDirectionResolved_IsLayoutDirectionResolved_Z;

	private static Delegate? cb_isLayoutRequested_IsLayoutRequested_Z;

	private static Delegate? cb_isShown_IsShown_Z;

	private static Delegate? cb_isTextAlignmentResolved_IsTextAlignmentResolved_Z;

	private static Delegate? cb_isTextDirectionResolved_IsTextDirectionResolved_Z;

	private static Delegate? cb_getLayoutDirection_GetLayoutDirection_I;

	private static Delegate? cb_getLayoutParams_GetLayoutParameters_Landroid_view_ViewGroup_LayoutParams_;

	private static Delegate? cb_setLayoutParams_SetLayoutParameters_Landroid_view_ViewGroup_LayoutParams__V;

	private static Delegate? cb_getMinimumHeight_GetMinimumHeight_I;

	private static Delegate? cb_setNestedScrollingEnabled_SetNestedScrollingEnabled_Z_V;

	private static Delegate? cb_setOnFocusChangeListener_SetOnFocusChangeListener_Landroid_view_View_OnFocusChangeListener__V;

	private static Delegate? cb_setOutlineProvider_SetOutlineProvider_Landroid_view_ViewOutlineProvider__V;

	private static Delegate? cb_getPaddingBottom_GetPaddingBottom_I;

	private static Delegate? cb_getPaddingEnd_GetPaddingEnd_I;

	private static Delegate? cb_getPaddingLeft_GetPaddingLeft_I;

	private static Delegate? cb_getPaddingRight_GetPaddingRight_I;

	private static Delegate? cb_getPaddingStart_GetPaddingStart_I;

	private static Delegate? cb_getPaddingTop_GetPaddingTop_I;

	private static Delegate? cb_getParentForAccessibility_GetParentForAccessibility_Landroid_view_ViewParent_;

	private static Delegate? cb_setPressed_SetPressed_Z_V;

	private static Delegate? cb_getResources_GetResources_Landroid_content_res_Resources_;

	private static Delegate? cb_getRootView_GetRootView_Landroid_view_View_;

	private static Delegate? cb_getRootWindowInsets_GetRootWindowInsets_Landroid_view_WindowInsets_;

	private static Delegate? cb_getRotation_GetRotation_F;

	private static Delegate? cb_setRotation_SetRotation_F_V;

	private static Delegate? cb_isSelected_IsSelected_Z;

	private static Delegate? cb_setSelected_SetSelected_Z_V;

	private static Delegate? cb_getSystemUiVisibility_GetSystemUiVisibility_I;

	private static Delegate? cb_setSystemUiVisibility_SetSystemUiVisibility_I_V;

	private static Delegate? cb_getTextAlignment_GetTextAlignment_I;

	private static Delegate? cb_setTextAlignment_SetTextAlignment_I_V;

	private static Delegate? cb_getTextDirection_GetTextDirection_I;

	private static Delegate? cb_getTopFadingEdgeStrength_GetTopFadingEdgeStrength_F;

	private static Delegate? cb_setTranslationX_SetTranslationX_F_V;

	private static Delegate? cb_setTranslationY_SetTranslationY_F_V;

	private static Delegate? cb_setVerticalScrollBarEnabled_SetVerticalScrollBarEnabled_Z_V;

	private static Delegate? cb_getViewTreeObserver_GetViewTreeObserver_Landroid_view_ViewTreeObserver_;

	private static Delegate? cb_getVisibility_GetVisibility_I;

	private static Delegate? cb_setVisibility_SetVisibility_I_V;

	private static Delegate? cb_getWindowToken_GetWindowToken_Landroid_os_IBinder_;

	private static Delegate? cb_addOnAttachStateChangeListener_AddOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener__V;

	private static Delegate? cb_addOnLayoutChangeListener_AddOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener__V;

	private static Delegate? cb_addTouchables_AddTouchables_Ljava_util_ArrayList__V;

	private static Delegate? cb_animate_Animate_Landroid_view_ViewPropertyAnimator_;

	private static Delegate? cb_bringToFront_BringToFront_V;

	private static Delegate? cb_callOnClick_CallOnClick_Z;

	private static Delegate? cb_canResolveLayoutDirection_CanResolveLayoutDirection_Z;

	private static Delegate? cb_canResolveTextAlignment_CanResolveTextAlignment_Z;

	private static Delegate? cb_canResolveTextDirection_CanResolveTextDirection_Z;

	private static Delegate? cb_canScrollVertically_CanScrollVertically_I_Z;

	private static Delegate? cb_clearAnimation_ClearAnimation_V;

	private static Delegate? cb_clearFocus_ClearFocus_V;

	private static Delegate? cb_computeHorizontalScrollExtent_ComputeHorizontalScrollExtent_I;

	private static Delegate? cb_computeHorizontalScrollOffset_ComputeHorizontalScrollOffset_I;

	private static Delegate? cb_computeHorizontalScrollRange_ComputeHorizontalScrollRange_I;

	private static Delegate? cb_computeVerticalScrollExtent_ComputeVerticalScrollExtent_I;

	private static Delegate? cb_computeVerticalScrollOffset_ComputeVerticalScrollOffset_I;

	private static Delegate? cb_computeVerticalScrollRange_ComputeVerticalScrollRange_I;

	private static Delegate? cb_createContextMenu_CreateContextMenu_Landroid_view_ContextMenu__V;

	private static Delegate? cb_dispatchDraw_DispatchDraw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_dispatchHoverEvent_DispatchHoverEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_dispatchKeyEvent_DispatchKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_dispatchRestoreInstanceState_DispatchRestoreInstanceState_Landroid_util_SparseArray__V;

	private static Delegate? cb_dispatchSaveInstanceState_DispatchSaveInstanceState_Landroid_util_SparseArray__V;

	private static Delegate? cb_dispatchTouchEvent_DispatchTouchEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_draw_Draw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_findFocus_FindFocus_Landroid_view_View_;

	private static Delegate? cb_getHitRect_GetHitRect_Landroid_graphics_Rect__V;

	private static Delegate? cb_getLocationInWindow_GetLocationInWindow_arrayI_V;

	private static Delegate? cb_getLocationOnScreen_GetLocationOnScreen_arrayI_V;

	private static Delegate? cb_getTag_GetTag_I_Ljava_lang_Object_;

	private static Delegate? cb_getWindowVisibleDisplayFrame_GetWindowVisibleDisplayFrame_Landroid_graphics_Rect__V;

	private static Delegate? cb_invalidate_Invalidate_V;

	private static Delegate? cb_keyboardNavigationClusterSearch_KeyboardNavigationClusterSearch_Landroid_view_View_I_Landroid_view_View_;

	private static Delegate? cb_layout_Layout_IIII_V;

	private static Delegate? cb_onAttachedToWindow_OnAttachedToWindow_V;

	private static Delegate? cb_onCreateDrawableState_OnCreateDrawableState_I_arrayI;

	private static Delegate? cb_onDetachedFromWindow_OnDetachedFromWindow_V;

	private static Delegate? cb_onDraw_OnDraw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_onFinishInflate_OnFinishInflate_V;

	private static Delegate? cb_onInitializeAccessibilityNodeInfo_OnInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo__V;

	private static Delegate? cb_onKeyDown_OnKeyDown_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyPreIme_OnKeyPreIme_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyUp_OnKeyUp_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_onMeasure_OnMeasure_II_V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_onSizeChanged_OnSizeChanged_IIII_V;

	private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_onVisibilityChanged_OnVisibilityChanged_Landroid_view_View_I_V;

	private static Delegate? cb_performClick_PerformClick_Z;

	private static Delegate? cb_post_Post_Ljava_lang_Runnable__Z;

	private static Delegate? cb_postDelayed_PostDelayed_Ljava_lang_Runnable_J_Z;

	private static Delegate? cb_postInvalidate_PostInvalidate_V;

	private static Delegate? cb_removeCallbacks_RemoveCallbacks_Ljava_lang_Runnable__Z;

	private static Delegate? cb_removeOnAttachStateChangeListener_RemoveOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener__V;

	private static Delegate? cb_removeOnLayoutChangeListener_RemoveOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener__V;

	private static Delegate? cb_requestApplyInsets_RequestApplyInsets_V;

	private static Delegate? cb_requestFitSystemWindows_RequestFitSystemWindows_V;

	private static Delegate? cb_requestFocus_RequestFocus_ILandroid_graphics_Rect__Z;

	private static Delegate? cb_requestLayout_RequestLayout_V;

	private static Delegate? cb_scrollBy_ScrollBy_II_V;

	private static Delegate? cb_scrollTo_ScrollTo_II_V;

	private static Delegate? cb_setBackgroundColor_SetBackgroundColor_I_V;

	private static Delegate? cb_setBackgroundResource_SetBackgroundResource_I_V;

	private static Delegate? cb_setFitsSystemWindows_SetFitsSystemWindows_Z_V;

	private static Delegate? cb_setForegroundGravity_SetForegroundGravity_I_V;

	private static Delegate? cb_setLayerType_SetLayerType_ILandroid_graphics_Paint__V;

	private static Delegate? cb_setMinimumHeight_SetMinimumHeight_I_V;

	private static Delegate? cb_setMinimumWidth_SetMinimumWidth_I_V;

	private static Delegate? cb_setOnClickListener_SetOnClickListener_Landroid_view_View_OnClickListener__V;

	private static Delegate? cb_setOnKeyListener_SetOnKeyListener_Landroid_view_View_OnKeyListener__V;

	private static Delegate? cb_setOnLongClickListener_SetOnLongClickListener_Landroid_view_View_OnLongClickListener__V;

	private static Delegate? cb_setOnScrollChangeListener_SetOnScrollChangeListener_Landroid_view_View_OnScrollChangeListener__V;

	private static Delegate? cb_setOnTouchListener_SetOnTouchListener_Landroid_view_View_OnTouchListener__V;

	private static Delegate? cb_setPadding_SetPadding_IIII_V;

	private static Delegate? cb_setTag_SetTag_ILjava_lang_Object__V;

	private static Delegate? cb_setWillNotDraw_SetWillNotDraw_Z_V;

	private static Delegate? cb_setX_SetX_F_V;

	private static Delegate? cb_setY_SetY_F_V;

	private static Delegate? cb_startAnimation_StartAnimation_Landroid_view_animation_Animation__V;

	private WeakReference? weak_implementor_AddOnAttachStateChangeListener;

	private WeakReference? weak_implementor_AddOnLayoutChangeListener;

	private WeakReference? weak_implementor_SetOnClickListener;

	private WeakReference? weak_implementor_SetOnLongClickListener;

	private WeakReference? weak_implementor_SetOnScrollChangeListener;

	private WeakReference? weak_implementor_SetOnTouchListener;

	private WeakReference? weak_implementor___SetOnFocusChangeListener;

	[ObsoletedOSPlatform("android30.0", "These flags are deprecated. Use WindowInsetsController instead.")]
	public SystemUiFlags SystemUiFlags
	{
		set
		{
			SystemUiVisibility = (StatusBarVisibility)value;
		}
	}

	[Register("SCALE_X")]
	public static Property? ScaleXs => Java.Lang.Object.GetObject<Property>(_members.StaticFields.GetObjectValue("SCALE_X.Landroid/util/Property;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SCALE_Y")]
	public static Property? ScaleYs => Java.Lang.Object.GetObject<Property>(_members.StaticFields.GetObjectValue("SCALE_Y.Landroid/util/Property;").Handle, JniHandleOwnership.TransferLocalRef);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual ICharSequence? AccessibilityClassNameFormatted
	{
		[Register("getAccessibilityClassName", "()Ljava/lang/CharSequence;", "GetGetAccessibilityClassNameHandler", ApiSince = 23)]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAccessibilityClassName.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool Activated
	{
		[Register("isActivated", "()Z", "GetIsActivatedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isActivated.()Z", this, null);
		}
		[Register("setActivated", "(Z)V", "GetSetActivated_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setActivated.(Z)V", this, ptr);
		}
	}

	public unsafe virtual float Alpha
	{
		[Register("getAlpha", "()F", "GetGetAlphaHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getAlpha.()F", this, null);
		}
		[Register("setAlpha", "(F)V", "GetSetAlpha_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAlpha.(F)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? Background
	{
		[Register("getBackground", "()Landroid/graphics/drawable/Drawable;", "GetGetBackgroundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBackground.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setBackground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetBackground_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBackground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? BackgroundTintList
	{
		[Register("setBackgroundTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetBackgroundTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBackgroundTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? BackgroundTintMode
	{
		[Register("setBackgroundTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBackgroundTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe int Bottom
	{
		[Register("getBottom", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getBottom.()I", this, null);
		}
	}

	protected unsafe virtual float BottomFadingEdgeStrength
	{
		[Register("getBottomFadingEdgeStrength", "()F", "GetGetBottomFadingEdgeStrengthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBottomFadingEdgeStrength.()F", this, null);
		}
	}

	public unsafe virtual bool Clickable
	{
		[Register("isClickable", "()Z", "GetIsClickableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isClickable.()Z", this, null);
		}
		[Register("setClickable", "(Z)V", "GetSetClickable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setClickable.(Z)V", this, ptr);
		}
	}

	public unsafe bool ClipToOutline
	{
		[Register("setClipToOutline", "(Z)V", "GetSetClipToOutline_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setClipToOutline.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? ContentDescriptionFormatted
	{
		[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? ContentDescription
	{
		get
		{
			if (ContentDescriptionFormatted != null)
			{
				return ContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe Context? Context
	{
		[Register("getContext", "()Landroid/content/Context;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float Elevation
	{
		[Register("setElevation", "(F)V", "GetSetElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool Enabled
	{
		[Register("isEnabled", "()Z", "GetIsEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEnabled.()Z", this, null);
		}
		[Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe bool Focusable
	{
		[Register("setFocusable", "(Z)V", "GetSetFocusable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFocusable.(Z)V", this, ptr);
		}
	}

	public unsafe bool FocusableInTouchMode
	{
		[Register("setFocusableInTouchMode", "(Z)V", "GetSetFocusableInTouchMode_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFocusableInTouchMode.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool HasFocus
	{
		[Register("hasFocus", "()Z", "GetHasFocusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasFocus.()Z", this, null);
		}
	}

	public unsafe virtual bool HasOnClickListeners
	{
		[Register("hasOnClickListeners", "()Z", "GetHasOnClickListenersHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasOnClickListeners.()Z", this, null);
		}
	}

	public unsafe int Height
	{
		[Register("getHeight", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getHeight.()I", this, null);
		}
	}

	public unsafe virtual bool HorizontalScrollBarEnabled
	{
		[Register("setHorizontalScrollBarEnabled", "(Z)V", "GetSetHorizontalScrollBarEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalScrollBarEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Hovered
	{
		[Register("setHovered", "(Z)V", "GetSetHovered_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHovered.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int Id
	{
		[Register("getId", "()I", "GetGetIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
		}
		[Register("setId", "(I)V", "GetSetId_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setId.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool IsAttachedToWindow
	{
		[Register("isAttachedToWindow", "()Z", "GetIsAttachedToWindowHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAttachedToWindow.()Z", this, null);
		}
	}

	public unsafe virtual bool IsFocused
	{
		[Register("isFocused", "()Z", "GetIsFocusedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFocused.()Z", this, null);
		}
	}

	public unsafe virtual bool IsHardwareAccelerated
	{
		[Register("isHardwareAccelerated", "()Z", "GetIsHardwareAcceleratedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHardwareAccelerated.()Z", this, null);
		}
	}

	public unsafe virtual bool IsInEditMode
	{
		[Register("isInEditMode", "()Z", "GetIsInEditModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInEditMode.()Z", this, null);
		}
	}

	public unsafe virtual bool IsLayoutDirectionResolved
	{
		[Register("isLayoutDirectionResolved", "()Z", "GetIsLayoutDirectionResolvedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutDirectionResolved.()Z", this, null);
		}
	}

	public unsafe virtual bool IsLayoutRequested
	{
		[Register("isLayoutRequested", "()Z", "GetIsLayoutRequestedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutRequested.()Z", this, null);
		}
	}

	public unsafe virtual bool IsShown
	{
		[Register("isShown", "()Z", "GetIsShownHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShown.()Z", this, null);
		}
	}

	public unsafe virtual bool IsTextAlignmentResolved
	{
		[Register("isTextAlignmentResolved", "()Z", "GetIsTextAlignmentResolvedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTextAlignmentResolved.()Z", this, null);
		}
	}

	public unsafe virtual bool IsTextDirectionResolved
	{
		[Register("isTextDirectionResolved", "()Z", "GetIsTextDirectionResolvedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTextDirectionResolved.()Z", this, null);
		}
	}

	public unsafe virtual LayoutDirection LayoutDirection
	{
		[Register("getLayoutDirection", "()I", "GetGetLayoutDirectionHandler")]
		get
		{
			return (LayoutDirection)_members.InstanceMethods.InvokeVirtualInt32Method("getLayoutDirection.()I", this, null);
		}
	}

	public unsafe virtual ViewGroup.LayoutParams? LayoutParameters
	{
		[Register("getLayoutParams", "()Landroid/view/ViewGroup$LayoutParams;", "GetGetLayoutParametersHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutParams.()Landroid/view/ViewGroup$LayoutParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setLayoutParams", "(Landroid/view/ViewGroup$LayoutParams;)V", "GetSetLayoutParameters_Landroid_view_ViewGroup_LayoutParams_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutParams.(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe int Left
	{
		[Register("getLeft", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLeft.()I", this, null);
		}
	}

	public unsafe int MeasuredHeight
	{
		[Register("getMeasuredHeight", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMeasuredHeight.()I", this, null);
		}
	}

	public unsafe int MeasuredWidth
	{
		[Register("getMeasuredWidth", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMeasuredWidth.()I", this, null);
		}
	}

	public unsafe virtual int MinimumHeight
	{
		[Register("getMinimumHeight", "()I", "GetGetMinimumHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinimumHeight.()I", this, null);
		}
	}

	public unsafe virtual bool NestedScrollingEnabled
	{
		[Register("setNestedScrollingEnabled", "(Z)V", "GetSetNestedScrollingEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setNestedScrollingEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual IOnFocusChangeListener? OnFocusChangeListener
	{
		[Register("setOnFocusChangeListener", "(Landroid/view/View$OnFocusChangeListener;)V", "GetSetOnFocusChangeListener_Landroid_view_View_OnFocusChangeListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnFocusChangeListener.(Landroid/view/View$OnFocusChangeListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ViewOutlineProvider? OutlineProvider
	{
		[Register("setOutlineProvider", "(Landroid/view/ViewOutlineProvider;)V", "GetSetOutlineProvider_Landroid_view_ViewOutlineProvider_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOutlineProvider.(Landroid/view/ViewOutlineProvider;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int PaddingBottom
	{
		[Register("getPaddingBottom", "()I", "GetGetPaddingBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingBottom.()I", this, null);
		}
	}

	public unsafe virtual int PaddingEnd
	{
		[Register("getPaddingEnd", "()I", "GetGetPaddingEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingEnd.()I", this, null);
		}
	}

	public unsafe virtual int PaddingLeft
	{
		[Register("getPaddingLeft", "()I", "GetGetPaddingLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingLeft.()I", this, null);
		}
	}

	public unsafe virtual int PaddingRight
	{
		[Register("getPaddingRight", "()I", "GetGetPaddingRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingRight.()I", this, null);
		}
	}

	public unsafe virtual int PaddingStart
	{
		[Register("getPaddingStart", "()I", "GetGetPaddingStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingStart.()I", this, null);
		}
	}

	public unsafe virtual int PaddingTop
	{
		[Register("getPaddingTop", "()I", "GetGetPaddingTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingTop.()I", this, null);
		}
	}

	public unsafe IViewParent? Parent
	{
		[Register("getParent", "()Landroid/view/ViewParent;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IViewParent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getParent.()Landroid/view/ViewParent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IViewParent? ParentForAccessibility
	{
		[Register("getParentForAccessibility", "()Landroid/view/ViewParent;", "GetGetParentForAccessibilityHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IViewParent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParentForAccessibility.()Landroid/view/ViewParent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool Pressed
	{
		[Register("setPressed", "(Z)V", "GetSetPressed_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPressed.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Resources? Resources
	{
		[Register("getResources", "()Landroid/content/res/Resources;", "GetGetResourcesHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Resources>(_members.InstanceMethods.InvokeVirtualObjectMethod("getResources.()Landroid/content/res/Resources;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int Right
	{
		[Register("getRight", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getRight.()I", this, null);
		}
	}

	public unsafe virtual View? RootView
	{
		[Register("getRootView", "()Landroid/view/View;", "GetGetRootViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRootView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android23.0")]
	public unsafe virtual WindowInsets? RootWindowInsets
	{
		[Register("getRootWindowInsets", "()Landroid/view/WindowInsets;", "GetGetRootWindowInsetsHandler", ApiSince = 23)]
		get
		{
			return Java.Lang.Object.GetObject<WindowInsets>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRootWindowInsets.()Landroid/view/WindowInsets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float Rotation
	{
		[Register("getRotation", "()F", "GetGetRotationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRotation.()F", this, null);
		}
		[Register("setRotation", "(F)V", "GetSetRotation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRotation.(F)V", this, ptr);
		}
	}

	public unsafe int ScrollX
	{
		[Register("getScrollX", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getScrollX.()I", this, null);
		}
	}

	public unsafe int ScrollY
	{
		[Register("getScrollY", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getScrollY.()I", this, null);
		}
	}

	public unsafe virtual bool Selected
	{
		[Register("isSelected", "()Z", "GetIsSelectedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSelected.()Z", this, null);
		}
		[Register("setSelected", "(Z)V", "GetSetSelected_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSelected.(Z)V", this, ptr);
		}
	}

	[Obsolete("This property has an incorrect enumeration type. Use the SystemUiFlags property instead.")]
	public unsafe virtual StatusBarVisibility SystemUiVisibility
	{
		[Register("getSystemUiVisibility", "()I", "GetGetSystemUiVisibilityHandler")]
		get
		{
			return (StatusBarVisibility)_members.InstanceMethods.InvokeVirtualInt32Method("getSystemUiVisibility.()I", this, null);
		}
		[Register("setSystemUiVisibility", "(I)V", "GetSetSystemUiVisibility_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSystemUiVisibility.(I)V", this, ptr);
		}
	}

	public unsafe virtual TextAlignment TextAlignment
	{
		[Register("getTextAlignment", "()I", "GetGetTextAlignmentHandler")]
		get
		{
			return (TextAlignment)_members.InstanceMethods.InvokeVirtualInt32Method("getTextAlignment.()I", this, null);
		}
		[Register("setTextAlignment", "(I)V", "GetSetTextAlignment_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextAlignment.(I)V", this, ptr);
		}
	}

	public unsafe virtual TextDirection TextDirection
	{
		[Register("getTextDirection", "()I", "GetGetTextDirectionHandler")]
		get
		{
			return (TextDirection)_members.InstanceMethods.InvokeVirtualInt32Method("getTextDirection.()I", this, null);
		}
	}

	public unsafe int Top
	{
		[Register("getTop", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getTop.()I", this, null);
		}
		[Register("setTop", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setTop.(I)V", this, ptr);
		}
	}

	protected unsafe virtual float TopFadingEdgeStrength
	{
		[Register("getTopFadingEdgeStrength", "()F", "GetGetTopFadingEdgeStrengthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTopFadingEdgeStrength.()F", this, null);
		}
	}

	public unsafe virtual float TranslationX
	{
		[Register("setTranslationX", "(F)V", "GetSetTranslationX_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationX.(F)V", this, ptr);
		}
	}

	public unsafe virtual float TranslationY
	{
		[Register("setTranslationY", "(F)V", "GetSetTranslationY_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationY.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool VerticalScrollBarEnabled
	{
		[Register("setVerticalScrollBarEnabled", "(Z)V", "GetSetVerticalScrollBarEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalScrollBarEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ViewTreeObserver? ViewTreeObserver
	{
		[Register("getViewTreeObserver", "()Landroid/view/ViewTreeObserver;", "GetGetViewTreeObserverHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewTreeObserver>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewTreeObserver.()Landroid/view/ViewTreeObserver;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ViewStates Visibility
	{
		[Register("getVisibility", "()I", "GetGetVisibilityHandler")]
		get
		{
			return (ViewStates)_members.InstanceMethods.InvokeVirtualInt32Method("getVisibility.()I", this, null);
		}
		[Register("setVisibility", "(I)V", "GetSetVisibility_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((int)value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibility.(I)V", this, ptr);
		}
	}

	public unsafe int Width
	{
		[Register("getWidth", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getWidth.()I", this, null);
		}
	}

	public unsafe virtual IBinder? WindowToken
	{
		[Register("getWindowToken", "()Landroid/os/IBinder;", "GetGetWindowTokenHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IBinder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWindowToken.()Landroid/os/IBinder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public event EventHandler<ViewAttachedToWindowEventArgs> ViewAttachedToWindow
	{
		add
		{
			EventHelper.AddEventHandler<IOnAttachStateChangeListener, IOnAttachStateChangeListenerImplementor>(ref weak_implementor_AddOnAttachStateChangeListener, __CreateIOnAttachStateChangeListenerImplementor, AddOnAttachStateChangeListener, delegate(IOnAttachStateChangeListenerImplementor __h)
			{
				__h.OnViewAttachedToWindowHandler = (EventHandler<ViewAttachedToWindowEventArgs>)Delegate.Combine(__h.OnViewAttachedToWindowHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnAttachStateChangeListener, IOnAttachStateChangeListenerImplementor.__IsEmpty, delegate(IOnAttachStateChangeListener __v)
			{
				RemoveOnAttachStateChangeListener(__v);
			}, delegate(IOnAttachStateChangeListenerImplementor __h)
			{
				__h.OnViewAttachedToWindowHandler = (EventHandler<ViewAttachedToWindowEventArgs>)Delegate.Remove(__h.OnViewAttachedToWindowHandler, value);
			});
		}
	}

	public event EventHandler<ViewDetachedFromWindowEventArgs> ViewDetachedFromWindow
	{
		add
		{
			EventHelper.AddEventHandler<IOnAttachStateChangeListener, IOnAttachStateChangeListenerImplementor>(ref weak_implementor_AddOnAttachStateChangeListener, __CreateIOnAttachStateChangeListenerImplementor, AddOnAttachStateChangeListener, delegate(IOnAttachStateChangeListenerImplementor __h)
			{
				__h.OnViewDetachedFromWindowHandler = (EventHandler<ViewDetachedFromWindowEventArgs>)Delegate.Combine(__h.OnViewDetachedFromWindowHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnAttachStateChangeListener, IOnAttachStateChangeListenerImplementor.__IsEmpty, delegate(IOnAttachStateChangeListener __v)
			{
				RemoveOnAttachStateChangeListener(__v);
			}, delegate(IOnAttachStateChangeListenerImplementor __h)
			{
				__h.OnViewDetachedFromWindowHandler = (EventHandler<ViewDetachedFromWindowEventArgs>)Delegate.Remove(__h.OnViewDetachedFromWindowHandler, value);
			});
		}
	}

	public event EventHandler<LayoutChangeEventArgs> LayoutChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnLayoutChangeListener, IOnLayoutChangeListenerImplementor>(ref weak_implementor_AddOnLayoutChangeListener, __CreateIOnLayoutChangeListenerImplementor, AddOnLayoutChangeListener, delegate(IOnLayoutChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<LayoutChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnLayoutChangeListener, IOnLayoutChangeListenerImplementor.__IsEmpty, delegate(IOnLayoutChangeListener __v)
			{
				RemoveOnLayoutChangeListener(__v);
			}, delegate(IOnLayoutChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<LayoutChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler Click
	{
		add
		{
			EventHelper.AddEventHandler<IOnClickListener, IOnClickListenerImplementor>(ref weak_implementor_SetOnClickListener, __CreateIOnClickListenerImplementor, SetOnClickListener, delegate(IOnClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnClickListener, IOnClickListenerImplementor>(ref weak_implementor_SetOnClickListener, IOnClickListenerImplementor.__IsEmpty, delegate
			{
				SetOnClickListener(null);
			}, delegate(IOnClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<LongClickEventArgs> LongClick
	{
		add
		{
			EventHelper.AddEventHandler<IOnLongClickListener, IOnLongClickListenerImplementor>(ref weak_implementor_SetOnLongClickListener, __CreateIOnLongClickListenerImplementor, SetOnLongClickListener, delegate(IOnLongClickListenerImplementor __h)
			{
				__h.OnLongClickHandler = (EventHandler<LongClickEventArgs>)Delegate.Combine(__h.OnLongClickHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnLongClickListener, IOnLongClickListenerImplementor>(ref weak_implementor_SetOnLongClickListener, IOnLongClickListenerImplementor.__IsEmpty, delegate
			{
				SetOnLongClickListener(null);
			}, delegate(IOnLongClickListenerImplementor __h)
			{
				__h.OnLongClickHandler = (EventHandler<LongClickEventArgs>)Delegate.Remove(__h.OnLongClickHandler, value);
			});
		}
	}

	[SupportedOSPlatform("android23.0")]
	public event EventHandler<ScrollChangeEventArgs> ScrollChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnScrollChangeListener, IOnScrollChangeListenerImplementor>(ref weak_implementor_SetOnScrollChangeListener, __CreateIOnScrollChangeListenerImplementor, SetOnScrollChangeListener, delegate(IOnScrollChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ScrollChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnScrollChangeListener, IOnScrollChangeListenerImplementor>(ref weak_implementor_SetOnScrollChangeListener, IOnScrollChangeListenerImplementor.__IsEmpty, delegate
			{
				SetOnScrollChangeListener(null);
			}, delegate(IOnScrollChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ScrollChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<TouchEventArgs> Touch
	{
		add
		{
			EventHelper.AddEventHandler<IOnTouchListener, IOnTouchListenerImplementor>(ref weak_implementor_SetOnTouchListener, __CreateIOnTouchListenerImplementor, SetOnTouchListener, delegate(IOnTouchListenerImplementor __h)
			{
				__h.Handler = (EventHandler<TouchEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnTouchListener, IOnTouchListenerImplementor>(ref weak_implementor_SetOnTouchListener, IOnTouchListenerImplementor.__IsEmpty, delegate
			{
				SetOnTouchListener(null);
			}, delegate(IOnTouchListenerImplementor __h)
			{
				__h.Handler = (EventHandler<TouchEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<FocusChangeEventArgs> FocusChange
	{
		add
		{
			EventHelper.AddEventHandler(ref weak_implementor___SetOnFocusChangeListener, __CreateIOnFocusChangeListenerImplementor, delegate(IOnFocusChangeListener __v)
			{
				OnFocusChangeListener = __v;
			}, delegate(IOnFocusChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FocusChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnFocusChangeListener, IOnFocusChangeListenerImplementor>(ref weak_implementor___SetOnFocusChangeListener, IOnFocusChangeListenerImplementor.__IsEmpty, delegate
			{
				OnFocusChangeListener = null;
			}, delegate(IOnFocusChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<FocusChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public T? FindViewById<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(int id) where T : View
	{
		return Extensions.JavaCast<T>(FindViewById(id));
	}

	public T RequireViewById<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(int id) where T : View
	{
		return FindViewById<T>(id) ?? throw new IllegalArgumentException($"Parameter 'id' of value 0x{id:X} does not reference a View of type '{typeof(T)}' inside this View");
	}

	public bool Post(System.Action action)
	{
		Thread.RunnableImplementor runnableImplementor = new Thread.RunnableImplementor(action, removable: true);
		if (Post(runnableImplementor))
		{
			return true;
		}
		runnableImplementor.Dispose();
		return false;
	}

	public bool PostDelayed(System.Action action, long delayMillis)
	{
		Thread.RunnableImplementor runnableImplementor = new Thread.RunnableImplementor(action, removable: true);
		if (PostDelayed(runnableImplementor, delayMillis))
		{
			return true;
		}
		runnableImplementor.Dispose();
		return false;
	}

	protected View(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe View(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe View(Context? context, IAttributeSet? attrs, int defStyleAttr)
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
	public unsafe View(Context? context, IAttributeSet? attrs)
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
	public unsafe View(Context? context)
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

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetGetAccessibilityClassNameHandler()
	{
		return new _JniMarshal_PP_L(n_GetAccessibilityClassName);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAccessibilityClassName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AccessibilityClassNameFormatted);
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

	private static Delegate GetIsActivatedHandler()
	{
		return new _JniMarshal_PP_B(n_IsActivated);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsActivated(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Activated ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetActivated_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetActivated_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActivated_Z(nint jnienv, nint native__this, sbyte native_activated)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool activated = native_activated != 0;
			view.Activated = activated;
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

	private static Delegate GetGetAlphaHandler()
	{
		return new _JniMarshal_PP_F(n_GetAlpha);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetAlpha(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Alpha;
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

	private static Delegate GetSetAlpha_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetAlpha_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAlpha_F(nint jnienv, nint native__this, float alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Alpha = alpha;
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
	private static nint n_GetBackground(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Background);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackground_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_background)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable background = Java.Lang.Object.GetObject<Drawable>(native_background, JniHandleOwnership.DoNotTransfer);
			view.Background = background;
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

	private static Delegate GetSetBackgroundTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetBackgroundTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList backgroundTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			view.BackgroundTintList = backgroundTintList;
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

	private static Delegate GetSetBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode backgroundTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			view.BackgroundTintMode = backgroundTintMode;
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
	private static float n_GetBottomFadingEdgeStrength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomFadingEdgeStrength;
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

	private static Delegate GetIsClickableHandler()
	{
		return new _JniMarshal_PP_B(n_IsClickable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsClickable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clickable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetClickable_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetClickable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetClickable_Z(nint jnienv, nint native__this, sbyte native_clickable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool clickable = native_clickable != 0;
			view.Clickable = clickable;
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

	private static Delegate GetGetContentDescriptionHandler()
	{
		return new _JniMarshal_PP_L(n_GetContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentDescriptionFormatted);
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

	private static Delegate GetSetContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_contentDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence contentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_contentDescription, JniHandleOwnership.DoNotTransfer);
			view.ContentDescriptionFormatted = contentDescriptionFormatted;
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

	private static Delegate GetSetElevation_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetElevation_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Elevation = elevation;
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
	private static sbyte n_IsEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Enabled ? ((sbyte)1) : ((sbyte)0);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enabled = native_enabled != 0;
			view.Enabled = enabled;
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

	private static Delegate GetHasFocusHandler()
	{
		return new _JniMarshal_PP_B(n_HasFocus);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasFocus(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFocus ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasOnClickListenersHandler()
	{
		return new _JniMarshal_PP_B(n_HasOnClickListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasOnClickListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasOnClickListeners ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHorizontalScrollBarEnabled_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetHorizontalScrollBarEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalScrollBarEnabled_Z(nint jnienv, nint native__this, sbyte native_horizontalScrollBarEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool horizontalScrollBarEnabled = native_horizontalScrollBarEnabled != 0;
			view.HorizontalScrollBarEnabled = horizontalScrollBarEnabled;
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

	private static Delegate GetSetHovered_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetHovered_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHovered_Z(nint jnienv, nint native__this, sbyte native_hovered)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hovered = native_hovered != 0;
			view.Hovered = hovered;
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

	private static Delegate GetGetIdHandler()
	{
		return new _JniMarshal_PP_I(n_GetId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

	private static Delegate GetSetId_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetId_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id = id;
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

	private static Delegate GetIsAttachedToWindowHandler()
	{
		return new _JniMarshal_PP_B(n_IsAttachedToWindow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAttachedToWindow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAttachedToWindow ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsFocusedHandler()
	{
		return new _JniMarshal_PP_B(n_IsFocused);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFocused(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFocused ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsHardwareAcceleratedHandler()
	{
		return new _JniMarshal_PP_B(n_IsHardwareAccelerated);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHardwareAccelerated(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHardwareAccelerated ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsInEditModeHandler()
	{
		return new _JniMarshal_PP_B(n_IsInEditMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInEditMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInEditMode ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsLayoutDirectionResolvedHandler()
	{
		return new _JniMarshal_PP_B(n_IsLayoutDirectionResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLayoutDirectionResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutDirectionResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsLayoutRequestedHandler()
	{
		return new _JniMarshal_PP_B(n_IsLayoutRequested);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLayoutRequested(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutRequested ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsShownHandler()
	{
		return new _JniMarshal_PP_B(n_IsShown);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShown ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsTextAlignmentResolvedHandler()
	{
		return new _JniMarshal_PP_B(n_IsTextAlignmentResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTextAlignmentResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTextAlignmentResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsTextDirectionResolvedHandler()
	{
		return new _JniMarshal_PP_B(n_IsTextDirectionResolved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTextDirectionResolved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTextDirectionResolved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLayoutDirectionHandler()
	{
		return new _JniMarshal_PP_I(n_GetLayoutDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLayoutDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDirection;
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

	private static Delegate GetGetLayoutParametersHandler()
	{
		return new _JniMarshal_PP_L(n_GetLayoutParameters);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLayoutParameters(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutParameters);
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

	private static Delegate GetSetLayoutParameters_Landroid_view_ViewGroup_LayoutParams_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetLayoutParameters_Landroid_view_ViewGroup_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLayoutParameters_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams layoutParameters = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			view.LayoutParameters = layoutParameters;
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

	private static Delegate GetGetMinimumHeightHandler()
	{
		return new _JniMarshal_PP_I(n_GetMinimumHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinimumHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumHeight;
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

	private static Delegate GetSetNestedScrollingEnabled_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetNestedScrollingEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNestedScrollingEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool nestedScrollingEnabled = native_enabled != 0;
			view.NestedScrollingEnabled = nestedScrollingEnabled;
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

	private static Delegate GetSetOnFocusChangeListener_Landroid_view_View_OnFocusChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnFocusChangeListener_Landroid_view_View_OnFocusChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnFocusChangeListener_Landroid_view_View_OnFocusChangeListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnFocusChangeListener onFocusChangeListener = Java.Lang.Object.GetObject<IOnFocusChangeListener>(native_l, JniHandleOwnership.DoNotTransfer);
			view.OnFocusChangeListener = onFocusChangeListener;
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

	private static Delegate GetSetOutlineProvider_Landroid_view_ViewOutlineProvider_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOutlineProvider_Landroid_view_ViewOutlineProvider_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOutlineProvider_Landroid_view_ViewOutlineProvider_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewOutlineProvider outlineProvider = Java.Lang.Object.GetObject<ViewOutlineProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			view.OutlineProvider = outlineProvider;
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

	private static Delegate GetGetPaddingBottomHandler()
	{
		return new _JniMarshal_PP_I(n_GetPaddingBottom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPaddingBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingBottom;
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

	private static Delegate GetGetPaddingEndHandler()
	{
		return new _JniMarshal_PP_I(n_GetPaddingEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPaddingEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingEnd;
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

	private static Delegate GetGetPaddingLeftHandler()
	{
		return new _JniMarshal_PP_I(n_GetPaddingLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPaddingLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingLeft;
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

	private static Delegate GetGetPaddingRightHandler()
	{
		return new _JniMarshal_PP_I(n_GetPaddingRight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPaddingRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingRight;
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

	private static Delegate GetGetPaddingStartHandler()
	{
		return new _JniMarshal_PP_I(n_GetPaddingStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPaddingStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingStart;
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

	private static Delegate GetGetPaddingTopHandler()
	{
		return new _JniMarshal_PP_I(n_GetPaddingTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPaddingTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingTop;
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

	private static Delegate GetGetParentForAccessibilityHandler()
	{
		return new _JniMarshal_PP_L(n_GetParentForAccessibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParentForAccessibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParentForAccessibility);
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

	private static Delegate GetSetPressed_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetPressed_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPressed_Z(nint jnienv, nint native__this, sbyte native_pressed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool pressed = native_pressed != 0;
			view.Pressed = pressed;
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

	private static Delegate GetGetResourcesHandler()
	{
		return new _JniMarshal_PP_L(n_GetResources);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResources(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resources);
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

	private static Delegate GetGetRootViewHandler()
	{
		return new _JniMarshal_PP_L(n_GetRootView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRootView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootView);
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
	private static Delegate GetGetRootWindowInsetsHandler()
	{
		return new _JniMarshal_PP_L(n_GetRootWindowInsets);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRootWindowInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootWindowInsets);
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

	private static Delegate GetGetRotationHandler()
	{
		return new _JniMarshal_PP_F(n_GetRotation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRotation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rotation;
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

	private static Delegate GetSetRotation_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetRotation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRotation_F(nint jnienv, nint native__this, float rotation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rotation = rotation;
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

	private static Delegate GetIsSelectedHandler()
	{
		return new _JniMarshal_PP_B(n_IsSelected);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSelected(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Selected ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSelected_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetSelected_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelected_Z(nint jnienv, nint native__this, sbyte native_selected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool selected = native_selected != 0;
			view.Selected = selected;
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

	[Obsolete]
	private static Delegate GetGetSystemUiVisibilityHandler()
	{
		return new _JniMarshal_PP_I(n_GetSystemUiVisibility);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSystemUiVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemUiVisibility;
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

	[Obsolete]
	private static Delegate GetSetSystemUiVisibility_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetSystemUiVisibility_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSystemUiVisibility_I(nint jnienv, nint native__this, int native_visibility)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemUiVisibility = (StatusBarVisibility)native_visibility;
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

	private static Delegate GetGetTextAlignmentHandler()
	{
		return new _JniMarshal_PP_I(n_GetTextAlignment);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTextAlignment(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextAlignment;
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

	private static Delegate GetSetTextAlignment_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetTextAlignment_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextAlignment_I(nint jnienv, nint native__this, int native_textAlignment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextAlignment = (TextAlignment)native_textAlignment;
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

	private static Delegate GetGetTextDirectionHandler()
	{
		return new _JniMarshal_PP_I(n_GetTextDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTextDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextDirection;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTopFadingEdgeStrength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopFadingEdgeStrength;
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

	private static Delegate GetSetTranslationX_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetTranslationX_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationX_F(nint jnienv, nint native__this, float translationX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationX = translationX;
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

	private static Delegate GetSetTranslationY_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetTranslationY_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationY_F(nint jnienv, nint native__this, float translationY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationY = translationY;
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

	private static Delegate GetSetVerticalScrollBarEnabled_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetVerticalScrollBarEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalScrollBarEnabled_Z(nint jnienv, nint native__this, sbyte native_verticalScrollBarEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool verticalScrollBarEnabled = native_verticalScrollBarEnabled != 0;
			view.VerticalScrollBarEnabled = verticalScrollBarEnabled;
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

	private static Delegate GetGetViewTreeObserverHandler()
	{
		return new _JniMarshal_PP_L(n_GetViewTreeObserver);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewTreeObserver(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewTreeObserver);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibility_I(nint jnienv, nint native__this, int native_visibility)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility = (ViewStates)native_visibility;
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

	private static Delegate GetGetWindowTokenHandler()
	{
		return new _JniMarshal_PP_L(n_GetWindowToken);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetWindowToken(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WindowToken);
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

	private static Delegate GetAddOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnAttachStateChangeListener listener = Java.Lang.Object.GetObject<IOnAttachStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			view.AddOnAttachStateChangeListener(listener);
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

	[Register("addOnAttachStateChangeListener", "(Landroid/view/View$OnAttachStateChangeListener;)V", "GetAddOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_Handler")]
	public unsafe virtual void AddOnAttachStateChangeListener(IOnAttachStateChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnAttachStateChangeListener.(Landroid/view/View$OnAttachStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLayoutChangeListener listener = Java.Lang.Object.GetObject<IOnLayoutChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			view.AddOnLayoutChangeListener(listener);
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

	[Register("addOnLayoutChangeListener", "(Landroid/view/View$OnLayoutChangeListener;)V", "GetAddOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_Handler")]
	public unsafe virtual void AddOnLayoutChangeListener(IOnLayoutChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnLayoutChangeListener.(Landroid/view/View$OnLayoutChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddTouchables_Ljava_util_ArrayList_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddTouchables_Ljava_util_ArrayList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTouchables_Ljava_util_ArrayList_(nint jnienv, nint native__this, nint native_views)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			view.AddTouchables(views);
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

	[Register("addTouchables", "(Ljava/util/ArrayList;)V", "GetAddTouchables_Ljava_util_ArrayList_Handler")]
	public unsafe virtual void AddTouchables(IList<View>? views)
	{
		nint num = JavaList<View>.ToLocalJniHandle(views);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTouchables.(Ljava/util/ArrayList;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(views);
		}
	}

	private static Delegate GetAnimateHandler()
	{
		return new _JniMarshal_PP_L(n_Animate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Animate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Animate());
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

	[Register("animate", "()Landroid/view/ViewPropertyAnimator;", "GetAnimateHandler")]
	public unsafe virtual ViewPropertyAnimator? Animate()
	{
		return Java.Lang.Object.GetObject<ViewPropertyAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("animate.()Landroid/view/ViewPropertyAnimator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetBringToFrontHandler()
	{
		return new _JniMarshal_PP_V(n_BringToFront);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BringToFront(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BringToFront();
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

	[Register("bringToFront", "()V", "GetBringToFrontHandler")]
	public unsafe virtual void BringToFront()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("bringToFront.()V", this, null);
	}

	private static Delegate GetCallOnClickHandler()
	{
		return new _JniMarshal_PP_B(n_CallOnClick);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CallOnClick(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CallOnClick() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("callOnClick", "()Z", "GetCallOnClickHandler")]
	public unsafe virtual bool CallOnClick()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("callOnClick.()Z", this, null);
	}

	[Register("cancelPendingInputEvents", "()V", "")]
	public unsafe void CancelPendingInputEvents()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("cancelPendingInputEvents.()V", this, null);
	}

	private static Delegate GetCanResolveLayoutDirectionHandler()
	{
		return new _JniMarshal_PP_B(n_CanResolveLayoutDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanResolveLayoutDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanResolveLayoutDirection() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canResolveLayoutDirection", "()Z", "GetCanResolveLayoutDirectionHandler")]
	public unsafe virtual bool CanResolveLayoutDirection()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canResolveLayoutDirection.()Z", this, null);
	}

	private static Delegate GetCanResolveTextAlignmentHandler()
	{
		return new _JniMarshal_PP_B(n_CanResolveTextAlignment);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanResolveTextAlignment(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanResolveTextAlignment() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canResolveTextAlignment", "()Z", "GetCanResolveTextAlignmentHandler")]
	public unsafe virtual bool CanResolveTextAlignment()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canResolveTextAlignment.()Z", this, null);
	}

	private static Delegate GetCanResolveTextDirectionHandler()
	{
		return new _JniMarshal_PP_B(n_CanResolveTextDirection);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanResolveTextDirection(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanResolveTextDirection() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canResolveTextDirection", "()Z", "GetCanResolveTextDirectionHandler")]
	public unsafe virtual bool CanResolveTextDirection()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canResolveTextDirection.()Z", this, null);
	}

	private static Delegate GetCanScrollVertically_IHandler()
	{
		return new _JniMarshal_PPI_B(n_CanScrollVertically_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanScrollVertically_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanScrollVertically(direction) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canScrollVertically", "(I)Z", "GetCanScrollVertically_IHandler")]
	public unsafe virtual bool CanScrollVertically(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canScrollVertically.(I)Z", this, ptr);
	}

	private static Delegate GetClearAnimationHandler()
	{
		return new _JniMarshal_PP_V(n_ClearAnimation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearAnimation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearAnimation();
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

	[Register("clearAnimation", "()V", "GetClearAnimationHandler")]
	public unsafe virtual void ClearAnimation()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearAnimation.()V", this, null);
	}

	private static Delegate GetClearFocusHandler()
	{
		return new _JniMarshal_PP_V(n_ClearFocus);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearFocus(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearFocus();
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

	[Register("clearFocus", "()V", "GetClearFocusHandler")]
	public unsafe virtual void ClearFocus()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearFocus.()V", this, null);
	}

	private static Delegate GetComputeHorizontalScrollExtentHandler()
	{
		return new _JniMarshal_PP_I(n_ComputeHorizontalScrollExtent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeHorizontalScrollExtent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollExtent();
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

	[Register("computeHorizontalScrollExtent", "()I", "GetComputeHorizontalScrollExtentHandler")]
	protected unsafe virtual int ComputeHorizontalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollOffsetHandler()
	{
		return new _JniMarshal_PP_I(n_ComputeHorizontalScrollOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeHorizontalScrollOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollOffset();
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

	[Register("computeHorizontalScrollOffset", "()I", "GetComputeHorizontalScrollOffsetHandler")]
	protected unsafe virtual int ComputeHorizontalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollRangeHandler()
	{
		return new _JniMarshal_PP_I(n_ComputeHorizontalScrollRange);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeHorizontalScrollRange(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollRange();
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

	[Register("computeHorizontalScrollRange", "()I", "GetComputeHorizontalScrollRangeHandler")]
	protected unsafe virtual int ComputeHorizontalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollRange.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollExtentHandler()
	{
		return new _JniMarshal_PP_I(n_ComputeVerticalScrollExtent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeVerticalScrollExtent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollExtent();
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

	[Register("computeVerticalScrollExtent", "()I", "GetComputeVerticalScrollExtentHandler")]
	protected unsafe virtual int ComputeVerticalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollOffsetHandler()
	{
		return new _JniMarshal_PP_I(n_ComputeVerticalScrollOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeVerticalScrollOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollOffset();
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

	[Register("computeVerticalScrollOffset", "()I", "GetComputeVerticalScrollOffsetHandler")]
	protected unsafe virtual int ComputeVerticalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollRangeHandler()
	{
		return new _JniMarshal_PP_I(n_ComputeVerticalScrollRange);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeVerticalScrollRange(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollRange();
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

	[Register("computeVerticalScrollRange", "()I", "GetComputeVerticalScrollRangeHandler")]
	protected unsafe virtual int ComputeVerticalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollRange.()I", this, null);
	}

	private static Delegate GetCreateContextMenu_Landroid_view_ContextMenu_Handler()
	{
		return new _JniMarshal_PPL_V(n_CreateContextMenu_Landroid_view_ContextMenu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CreateContextMenu_Landroid_view_ContextMenu_(nint jnienv, nint native__this, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContextMenu menu = Java.Lang.Object.GetObject<IContextMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			view.CreateContextMenu(menu);
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

	[Register("createContextMenu", "(Landroid/view/ContextMenu;)V", "GetCreateContextMenu_Landroid_view_ContextMenu_Handler")]
	public unsafe virtual void CreateContextMenu(IContextMenu? menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("createContextMenu.(Landroid/view/ContextMenu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchDraw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			view.DispatchDraw(canvas);
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

	[Register("dispatchDraw", "(Landroid/graphics/Canvas;)V", "GetDispatchDraw_Landroid_graphics_Canvas_Handler")]
	protected unsafe virtual void DispatchDraw(Canvas canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchDraw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	private static Delegate GetDispatchHoverEvent_Landroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchHoverEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchHoverEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return view.DispatchHoverEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchHoverEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchHoverEvent_Landroid_view_MotionEvent_Handler")]
	protected unsafe virtual bool DispatchHoverEvent(MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchHoverEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_DispatchKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return view.DispatchKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool DispatchKeyEvent(KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler()
	{
		return new _JniMarshal_PPL_V(n_DispatchRestoreInstanceState_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchRestoreInstanceState_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
			view.DispatchRestoreInstanceState(container);
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

	[Register("dispatchRestoreInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler")]
	protected unsafe virtual void DispatchRestoreInstanceState(SparseArray? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchRestoreInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetDispatchSaveInstanceState_Landroid_util_SparseArray_Handler()
	{
		return new _JniMarshal_PPL_V(n_DispatchSaveInstanceState_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchSaveInstanceState_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
			view.DispatchSaveInstanceState(container);
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

	[Register("dispatchSaveInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchSaveInstanceState_Landroid_util_SparseArray_Handler")]
	protected unsafe virtual void DispatchSaveInstanceState(SparseArray? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchSaveInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return view.DispatchTouchEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchTouchEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool DispatchTouchEvent(MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetDraw_Landroid_graphics_Canvas_Handler()
	{
		return new _JniMarshal_PPL_V(n_Draw_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Draw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			view.Draw(canvas);
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

	[Register("draw", "(Landroid/graphics/Canvas;)V", "GetDraw_Landroid_graphics_Canvas_Handler")]
	public unsafe virtual void Draw(Canvas canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("draw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	private static Delegate GetFindFocusHandler()
	{
		return new _JniMarshal_PP_L(n_FindFocus);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindFocus(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFocus());
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

	[Register("findFocus", "()Landroid/view/View;", "GetFindFocusHandler")]
	public unsafe virtual View? FindFocus()
	{
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findFocus.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("findViewById", "(I)Landroid/view/View;", "")]
	public unsafe View? FindViewById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("findViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("generateViewId", "()I", "")]
	public unsafe static int GenerateViewId()
	{
		return _members.StaticMethods.InvokeInt32Method("generateViewId.()I", null);
	}

	[Register("getGlobalVisibleRect", "(Landroid/graphics/Rect;)Z", "")]
	public unsafe bool GetGlobalVisibleRect(Rect? r)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(r?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getGlobalVisibleRect.(Landroid/graphics/Rect;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(r);
		}
	}

	private static Delegate GetGetHitRect_Landroid_graphics_Rect_Handler()
	{
		return new _JniMarshal_PPL_V(n_GetHitRect_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetHitRect_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_outRect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
			view.GetHitRect(outRect);
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

	[Register("getHitRect", "(Landroid/graphics/Rect;)V", "GetGetHitRect_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetHitRect(Rect? outRect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getHitRect.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outRect);
		}
	}

	private static Delegate GetGetLocationInWindow_arrayIHandler()
	{
		return new _JniMarshal_PPL_V(n_GetLocationInWindow_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetLocationInWindow_arrayI(nint jnienv, nint native__this, nint native_outLocation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_outLocation, JniHandleOwnership.DoNotTransfer, typeof(int));
			view.GetLocationInWindow(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_outLocation);
			}
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

	[Register("getLocationInWindow", "([I)V", "GetGetLocationInWindow_arrayIHandler")]
	public unsafe virtual void GetLocationInWindow(int[]? outLocation)
	{
		nint num = JNIEnv.NewArray(outLocation);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getLocationInWindow.([I)V", this, ptr);
		}
		finally
		{
			if (outLocation != null)
			{
				JNIEnv.CopyArray(num, outLocation);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(outLocation);
		}
	}

	private static Delegate GetGetLocationOnScreen_arrayIHandler()
	{
		return new _JniMarshal_PPL_V(n_GetLocationOnScreen_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetLocationOnScreen_arrayI(nint jnienv, nint native__this, nint native_outLocation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_outLocation, JniHandleOwnership.DoNotTransfer, typeof(int));
			view.GetLocationOnScreen(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_outLocation);
			}
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

	[Register("getLocationOnScreen", "([I)V", "GetGetLocationOnScreen_arrayIHandler")]
	public unsafe virtual void GetLocationOnScreen(int[]? outLocation)
	{
		nint num = JNIEnv.NewArray(outLocation);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getLocationOnScreen.([I)V", this, ptr);
		}
		finally
		{
			if (outLocation != null)
			{
				JNIEnv.CopyArray(num, outLocation);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(outLocation);
		}
	}

	private static Delegate GetGetTag_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetTag_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTag_I(nint jnienv, nint native__this, int key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTag(key));
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

	[Register("getTag", "(I)Ljava/lang/Object;", "GetGetTag_IHandler")]
	public unsafe virtual Java.Lang.Object? GetTag(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTag.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetWindowVisibleDisplayFrame_Landroid_graphics_Rect_Handler()
	{
		return new _JniMarshal_PPL_V(n_GetWindowVisibleDisplayFrame_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetWindowVisibleDisplayFrame_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_outRect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
			view.GetWindowVisibleDisplayFrame(outRect);
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

	[Register("getWindowVisibleDisplayFrame", "(Landroid/graphics/Rect;)V", "GetGetWindowVisibleDisplayFrame_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetWindowVisibleDisplayFrame(Rect? outRect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getWindowVisibleDisplayFrame.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outRect);
		}
	}

	[Register("inflate", "(Landroid/content/Context;ILandroid/view/ViewGroup;)Landroid/view/View;", "")]
	public unsafe static View? Inflate(Context? context, int resource, ViewGroup? root)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resource);
			ptr[2] = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.StaticMethods.InvokeObjectMethod("inflate.(Landroid/content/Context;ILandroid/view/ViewGroup;)Landroid/view/View;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetInvalidateHandler()
	{
		return new _JniMarshal_PP_V(n_Invalidate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Invalidate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invalidate();
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

	[Register("invalidate", "()V", "GetInvalidateHandler")]
	public unsafe virtual void Invalidate()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidate.()V", this, null);
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetKeyboardNavigationClusterSearch_Landroid_view_View_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_KeyboardNavigationClusterSearch_Landroid_view_View_I);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_KeyboardNavigationClusterSearch_Landroid_view_View_I(nint jnienv, nint native__this, nint native_currentCluster, int native_direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View currentCluster = Java.Lang.Object.GetObject<View>(native_currentCluster, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(view.KeyboardNavigationClusterSearch(currentCluster, (FocusSearchDirection)native_direction));
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

	[SupportedOSPlatform("android26.0")]
	[Register("keyboardNavigationClusterSearch", "(Landroid/view/View;I)Landroid/view/View;", "GetKeyboardNavigationClusterSearch_Landroid_view_View_IHandler", ApiSince = 26)]
	public unsafe virtual View? KeyboardNavigationClusterSearch(View? currentCluster, FocusSearchDirection direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(currentCluster?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)direction);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("keyboardNavigationClusterSearch.(Landroid/view/View;I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(currentCluster);
		}
	}

	private static Delegate GetLayout_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_Layout_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Layout_IIII(nint jnienv, nint native__this, int l, int t, int r, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Layout(l, t, r, b);
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

	[Register("layout", "(IIII)V", "GetLayout_IIIIHandler")]
	public unsafe virtual void Layout(int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(l);
		ptr[1] = new JniArgumentValue(t);
		ptr[2] = new JniArgumentValue(r);
		ptr[3] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeVirtualVoidMethod("layout.(IIII)V", this, ptr);
	}

	[Register("measure", "(II)V", "")]
	public unsafe void Measure(int widthMeasureSpec, int heightMeasureSpec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(widthMeasureSpec);
		ptr[1] = new JniArgumentValue(heightMeasureSpec);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("measure.(II)V", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAttachedToWindow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
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

	[Register("onAttachedToWindow", "()V", "GetOnAttachedToWindowHandler")]
	protected unsafe virtual void OnAttachedToWindow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.()V", this, null);
	}

	private static Delegate GetOnCreateDrawableState_IHandler()
	{
		return new _JniMarshal_PPI_L(n_OnCreateDrawableState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateDrawableState_I(nint jnienv, nint native__this, int extraSpace)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreateDrawableState(extraSpace));
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

	[Register("onCreateDrawableState", "(I)[I", "GetOnCreateDrawableState_IHandler")]
	protected unsafe virtual int[]? OnCreateDrawableState(int extraSpace)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(extraSpace);
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateDrawableState.(I)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDetachedFromWindow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromWindow();
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

	[Register("onDetachedFromWindow", "()V", "GetOnDetachedFromWindowHandler")]
	protected unsafe virtual void OnDetachedFromWindow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDraw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			view.OnDraw(canvas);
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
	protected unsafe virtual void OnDraw(Canvas canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnFinishInflate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFinishInflate();
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

	[Register("onFinishInflate", "()V", "GetOnFinishInflateHandler")]
	protected unsafe virtual void OnFinishInflate()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onFinishInflate.()V", this, null);
	}

	private static Delegate GetOnInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_(nint jnienv, nint native__this, nint native_info)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityNodeInfo info = Java.Lang.Object.GetObject<AccessibilityNodeInfo>(native_info, JniHandleOwnership.DoNotTransfer);
			view.OnInitializeAccessibilityNodeInfo(info);
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

	[Register("onInitializeAccessibilityNodeInfo", "(Landroid/view/accessibility/AccessibilityNodeInfo;)V", "GetOnInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_Handler")]
	public unsafe virtual void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityNodeInfo.(Landroid/view/accessibility/AccessibilityNodeInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(info);
		}
	}

	private static Delegate GetOnKeyDown_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPIL_B(n_OnKeyDown_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyDown_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return view.OnKeyDown((Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onKeyDown", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyDown_ILandroid_view_KeyEvent_Handler")]
	public unsafe virtual bool OnKeyDown(Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)keyCode);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyDown.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyPreIme_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return view.OnKeyPreIme((Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onKeyPreIme", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyPreIme_ILandroid_view_KeyEvent_Handler")]
	public unsafe virtual bool OnKeyPreIme(Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)keyCode);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyPreIme.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnKeyUp_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPIL_B(n_OnKeyUp_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyUp_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return view.OnKeyUp((Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onKeyUp", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyUp_ILandroid_view_KeyEvent_Handler")]
	public unsafe virtual bool OnKeyUp(Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)keyCode);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyUp.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new _JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			view.OnLayout(changed, left, top, right, bottom);
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
	protected unsafe virtual void OnLayout(bool changed, int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(left);
		ptr[2] = new JniArgumentValue(top);
		ptr[3] = new JniArgumentValue(right);
		ptr[4] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnMeasure_II(nint jnienv, nint native__this, int widthMeasureSpec, int heightMeasureSpec)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMeasure(widthMeasureSpec, heightMeasureSpec);
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

	[Register("onMeasure", "(II)V", "GetOnMeasure_IIHandler")]
	protected unsafe virtual void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(widthMeasureSpec);
		ptr[1] = new JniArgumentValue(heightMeasureSpec);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasure.(II)V", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			view.OnRestoreInstanceState(state);
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

	[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
	protected unsafe virtual void OnRestoreInstanceState(IParcelable? state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSaveInstanceState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
	protected unsafe virtual IParcelable? OnSaveInstanceState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSizeChanged_IIII(nint jnienv, nint native__this, int w, int h, int oldw, int oldh)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSizeChanged(w, h, oldw, oldh);
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

	[Register("onSizeChanged", "(IIII)V", "GetOnSizeChanged_IIIIHandler")]
	protected unsafe virtual void OnSizeChanged(int w, int h, int oldw, int oldh)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(w);
		ptr[1] = new JniArgumentValue(h);
		ptr[2] = new JniArgumentValue(oldw);
		ptr[3] = new JniArgumentValue(oldh);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onSizeChanged.(IIII)V", this, ptr);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return view.OnTouchEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe virtual bool OnTouchEvent(MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnVisibilityChanged_Landroid_view_View_I(nint jnienv, nint native__this, nint native_changedView, int native_visibility)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View changedView = Java.Lang.Object.GetObject<View>(native_changedView, JniHandleOwnership.DoNotTransfer);
			view.OnVisibilityChanged(changedView, (ViewStates)native_visibility);
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

	[Register("onVisibilityChanged", "(Landroid/view/View;I)V", "GetOnVisibilityChanged_Landroid_view_View_IHandler")]
	protected unsafe virtual void OnVisibilityChanged(View changedView, ViewStates visibility)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(changedView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)visibility);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onVisibilityChanged.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(changedView);
		}
	}

	private static Delegate GetPerformClickHandler()
	{
		return new _JniMarshal_PP_B(n_PerformClick);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformClick(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PerformClick() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performClick", "()Z", "GetPerformClickHandler")]
	public unsafe virtual bool PerformClick()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("performClick.()Z", this, null);
	}

	private static Delegate GetPost_Ljava_lang_Runnable_Handler()
	{
		return new _JniMarshal_PPL_B(n_Post_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Post_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable action = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
			return view.Post(action) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("post", "(Ljava/lang/Runnable;)Z", "GetPost_Ljava_lang_Runnable_Handler")]
	public unsafe virtual bool Post(IRunnable? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("post.(Ljava/lang/Runnable;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	private static Delegate GetPostDelayed_Ljava_lang_Runnable_JHandler()
	{
		return new _JniMarshal_PPLJ_B(n_PostDelayed_Ljava_lang_Runnable_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PostDelayed_Ljava_lang_Runnable_J(nint jnienv, nint native__this, nint native_action, long delayMillis)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable action = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
			return view.PostDelayed(action, delayMillis) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("postDelayed", "(Ljava/lang/Runnable;J)Z", "GetPostDelayed_Ljava_lang_Runnable_JHandler")]
	public unsafe virtual bool PostDelayed(IRunnable? action, long delayMillis)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			ptr[1] = new JniArgumentValue(delayMillis);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("postDelayed.(Ljava/lang/Runnable;J)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	private static Delegate GetPostInvalidateHandler()
	{
		return new _JniMarshal_PP_V(n_PostInvalidate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PostInvalidate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PostInvalidate();
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

	[Register("postInvalidate", "()V", "GetPostInvalidateHandler")]
	public unsafe virtual void PostInvalidate()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("postInvalidate.()V", this, null);
	}

	private static Delegate GetRemoveCallbacks_Ljava_lang_Runnable_Handler()
	{
		return new _JniMarshal_PPL_B(n_RemoveCallbacks_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveCallbacks_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable action = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
			return view.RemoveCallbacks(action) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("removeCallbacks", "(Ljava/lang/Runnable;)Z", "GetRemoveCallbacks_Ljava_lang_Runnable_Handler")]
	public unsafe virtual bool RemoveCallbacks(IRunnable? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeCallbacks.(Ljava/lang/Runnable;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	private static Delegate GetRemoveOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnAttachStateChangeListener listener = Java.Lang.Object.GetObject<IOnAttachStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			view.RemoveOnAttachStateChangeListener(listener);
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

	[Register("removeOnAttachStateChangeListener", "(Landroid/view/View$OnAttachStateChangeListener;)V", "GetRemoveOnAttachStateChangeListener_Landroid_view_View_OnAttachStateChangeListener_Handler")]
	public unsafe virtual void RemoveOnAttachStateChangeListener(IOnAttachStateChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnAttachStateChangeListener.(Landroid/view/View$OnAttachStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLayoutChangeListener listener = Java.Lang.Object.GetObject<IOnLayoutChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			view.RemoveOnLayoutChangeListener(listener);
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

	[Register("removeOnLayoutChangeListener", "(Landroid/view/View$OnLayoutChangeListener;)V", "GetRemoveOnLayoutChangeListener_Landroid_view_View_OnLayoutChangeListener_Handler")]
	public unsafe virtual void RemoveOnLayoutChangeListener(IOnLayoutChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnLayoutChangeListener.(Landroid/view/View$OnLayoutChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRequestApplyInsetsHandler()
	{
		return new _JniMarshal_PP_V(n_RequestApplyInsets);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestApplyInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestApplyInsets();
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

	[Register("requestApplyInsets", "()V", "GetRequestApplyInsetsHandler")]
	public unsafe virtual void RequestApplyInsets()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("requestApplyInsets.()V", this, null);
	}

	[Obsolete]
	private static Delegate GetRequestFitSystemWindowsHandler()
	{
		return new _JniMarshal_PP_V(n_RequestFitSystemWindows);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestFitSystemWindows(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestFitSystemWindows();
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
	[Register("requestFitSystemWindows", "()V", "GetRequestFitSystemWindowsHandler")]
	public unsafe virtual void RequestFitSystemWindows()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("requestFitSystemWindows.()V", this, null);
	}

	[Register("requestFocus", "()Z", "")]
	public unsafe bool RequestFocus()
	{
		return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("requestFocus.()Z", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RequestFocus_ILandroid_graphics_Rect_(nint jnienv, nint native__this, int native_direction, nint native_previouslyFocusedRect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect previouslyFocusedRect = Java.Lang.Object.GetObject<Rect>(native_previouslyFocusedRect, JniHandleOwnership.DoNotTransfer);
			return view.RequestFocus((FocusSearchDirection)native_direction, previouslyFocusedRect) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("requestFocus", "(ILandroid/graphics/Rect;)Z", "GetRequestFocus_ILandroid_graphics_Rect_Handler")]
	public unsafe virtual bool RequestFocus(FocusSearchDirection direction, Rect? previouslyFocusedRect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)direction);
			ptr[1] = new JniArgumentValue(previouslyFocusedRect?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("requestFocus.(ILandroid/graphics/Rect;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(previouslyFocusedRect);
		}
	}

	[Register("requestFocusFromTouch", "()Z", "")]
	public unsafe bool RequestFocusFromTouch()
	{
		return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("requestFocusFromTouch.()Z", this, null);
	}

	private static Delegate GetRequestLayoutHandler()
	{
		return new _JniMarshal_PP_V(n_RequestLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestLayout();
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

	[Register("requestLayout", "()V", "GetRequestLayoutHandler")]
	public unsafe virtual void RequestLayout()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("requestLayout.()V", this, null);
	}

	private static Delegate GetScrollBy_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_ScrollBy_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ScrollBy_II(nint jnienv, nint native__this, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollBy(x, y);
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

	[Register("scrollBy", "(II)V", "GetScrollBy_IIHandler")]
	public unsafe virtual void ScrollBy(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scrollBy.(II)V", this, ptr);
	}

	private static Delegate GetScrollTo_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_ScrollTo_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ScrollTo_II(nint jnienv, nint native__this, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollTo(x, y);
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

	[Register("scrollTo", "(II)V", "GetScrollTo_IIHandler")]
	public unsafe virtual void ScrollTo(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scrollTo.(II)V", this, ptr);
	}

	private static Delegate GetSetBackgroundColor_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetBackgroundColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundColor_I(nint jnienv, nint native__this, int native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Color backgroundColor = new Color(native_color);
			view.SetBackgroundColor(backgroundColor);
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

	[Register("setBackgroundColor", "(I)V", "GetSetBackgroundColor_IHandler")]
	public unsafe virtual void SetBackgroundColor(Color color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color.ToArgb());
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBackgroundColor.(I)V", this, ptr);
	}

	private static Delegate GetSetBackgroundResource_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetBackgroundResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundResource_I(nint jnienv, nint native__this, int resid)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBackgroundResource(resid);
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

	[Register("setBackgroundResource", "(I)V", "GetSetBackgroundResource_IHandler")]
	public unsafe virtual void SetBackgroundResource(int resid)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resid);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBackgroundResource.(I)V", this, ptr);
	}

	private static Delegate GetSetFitsSystemWindows_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetFitsSystemWindows_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFitsSystemWindows_Z(nint jnienv, nint native__this, sbyte native_fitSystemWindows)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool fitsSystemWindows = native_fitSystemWindows != 0;
			view.SetFitsSystemWindows(fitsSystemWindows);
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

	[Register("setFitsSystemWindows", "(Z)V", "GetSetFitsSystemWindows_ZHandler")]
	public unsafe virtual void SetFitsSystemWindows(bool fitSystemWindows)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(fitSystemWindows ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFitsSystemWindows.(Z)V", this, ptr);
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetSetForegroundGravity_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetForegroundGravity_I);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetForegroundGravity_I(nint jnienv, nint native__this, int native_gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetForegroundGravity((GravityFlags)native_gravity);
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

	[SupportedOSPlatform("android23.0")]
	[Register("setForegroundGravity", "(I)V", "GetSetForegroundGravity_IHandler", ApiSince = 23)]
	public unsafe virtual void SetForegroundGravity(GravityFlags gravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)gravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setForegroundGravity.(I)V", this, ptr);
	}

	private static Delegate GetSetLayerType_ILandroid_graphics_Paint_Handler()
	{
		return new _JniMarshal_PPIL_V(n_SetLayerType_ILandroid_graphics_Paint_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLayerType_ILandroid_graphics_Paint_(nint jnienv, nint native__this, int native_layerType, nint native_paint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			view.SetLayerType((LayerType)native_layerType, paint);
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

	[Register("setLayerType", "(ILandroid/graphics/Paint;)V", "GetSetLayerType_ILandroid_graphics_Paint_Handler")]
	public unsafe virtual void SetLayerType(LayerType layerType, Paint? paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)layerType);
			ptr[1] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLayerType.(ILandroid/graphics/Paint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(paint);
		}
	}

	[Register("setMeasuredDimension", "(II)V", "")]
	protected unsafe void SetMeasuredDimension(int measuredWidth, int measuredHeight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(measuredWidth);
		ptr[1] = new JniArgumentValue(measuredHeight);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("setMeasuredDimension.(II)V", this, ptr);
	}

	private static Delegate GetSetMinimumHeight_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetMinimumHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinimumHeight_I(nint jnienv, nint native__this, int minHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMinimumHeight(minHeight);
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

	[Register("setMinimumHeight", "(I)V", "GetSetMinimumHeight_IHandler")]
	public unsafe virtual void SetMinimumHeight(int minHeight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(minHeight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMinimumHeight.(I)V", this, ptr);
	}

	private static Delegate GetSetMinimumWidth_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetMinimumWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinimumWidth_I(nint jnienv, nint native__this, int minWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMinimumWidth(minWidth);
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

	[Register("setMinimumWidth", "(I)V", "GetSetMinimumWidth_IHandler")]
	public unsafe virtual void SetMinimumWidth(int minWidth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(minWidth);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMinimumWidth.(I)V", this, ptr);
	}

	private static Delegate GetSetOnClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnClickListener_Landroid_view_View_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnClickListener_Landroid_view_View_OnClickListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener onClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_l, JniHandleOwnership.DoNotTransfer);
			view.SetOnClickListener(onClickListener);
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

	[Register("setOnClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetOnClickListener_Landroid_view_View_OnClickListener_Handler")]
	public unsafe virtual void SetOnClickListener(IOnClickListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	private static Delegate GetSetOnKeyListener_Landroid_view_View_OnKeyListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnKeyListener_Landroid_view_View_OnKeyListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnKeyListener_Landroid_view_View_OnKeyListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnKeyListener onKeyListener = Java.Lang.Object.GetObject<IOnKeyListener>(native_l, JniHandleOwnership.DoNotTransfer);
			view.SetOnKeyListener(onKeyListener);
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

	[Register("setOnKeyListener", "(Landroid/view/View$OnKeyListener;)V", "GetSetOnKeyListener_Landroid_view_View_OnKeyListener_Handler")]
	public unsafe virtual void SetOnKeyListener(IOnKeyListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnKeyListener.(Landroid/view/View$OnKeyListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	private static Delegate GetSetOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnLongClickListener_Landroid_view_View_OnLongClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnLongClickListener_Landroid_view_View_OnLongClickListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnLongClickListener onLongClickListener = Java.Lang.Object.GetObject<IOnLongClickListener>(native_l, JniHandleOwnership.DoNotTransfer);
			view.SetOnLongClickListener(onLongClickListener);
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

	[Register("setOnLongClickListener", "(Landroid/view/View$OnLongClickListener;)V", "GetSetOnLongClickListener_Landroid_view_View_OnLongClickListener_Handler")]
	public unsafe virtual void SetOnLongClickListener(IOnLongClickListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnLongClickListener.(Landroid/view/View$OnLongClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetSetOnScrollChangeListener_Landroid_view_View_OnScrollChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnScrollChangeListener_Landroid_view_View_OnScrollChangeListener_);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnScrollChangeListener_Landroid_view_View_OnScrollChangeListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnScrollChangeListener onScrollChangeListener = Java.Lang.Object.GetObject<IOnScrollChangeListener>(native_l, JniHandleOwnership.DoNotTransfer);
			view.SetOnScrollChangeListener(onScrollChangeListener);
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

	[SupportedOSPlatform("android23.0")]
	[Register("setOnScrollChangeListener", "(Landroid/view/View$OnScrollChangeListener;)V", "GetSetOnScrollChangeListener_Landroid_view_View_OnScrollChangeListener_Handler", ApiSince = 23)]
	public unsafe virtual void SetOnScrollChangeListener(IOnScrollChangeListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnScrollChangeListener.(Landroid/view/View$OnScrollChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	private static Delegate GetSetOnTouchListener_Landroid_view_View_OnTouchListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetOnTouchListener_Landroid_view_View_OnTouchListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnTouchListener_Landroid_view_View_OnTouchListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTouchListener onTouchListener = Java.Lang.Object.GetObject<IOnTouchListener>(native_l, JniHandleOwnership.DoNotTransfer);
			view.SetOnTouchListener(onTouchListener);
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

	[Register("setOnTouchListener", "(Landroid/view/View$OnTouchListener;)V", "GetSetOnTouchListener_Landroid_view_View_OnTouchListener_Handler")]
	public unsafe virtual void SetOnTouchListener(IOnTouchListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnTouchListener.(Landroid/view/View$OnTouchListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	private static Delegate GetSetPadding_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_V(n_SetPadding_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPadding_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPadding(left, top, right, bottom);
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

	[Register("setPadding", "(IIII)V", "GetSetPadding_IIIIHandler")]
	public unsafe virtual void SetPadding(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPadding.(IIII)V", this, ptr);
	}

	private static Delegate GetSetTag_ILjava_lang_Object_Handler()
	{
		return new _JniMarshal_PPIL_V(n_SetTag_ILjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTag_ILjava_lang_Object_(nint jnienv, nint native__this, int key, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			view.SetTag(key, tag);
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

	[Register("setTag", "(ILjava/lang/Object;)V", "GetSetTag_ILjava_lang_Object_Handler")]
	public unsafe virtual void SetTag(int key, Java.Lang.Object? tag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTag.(ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tag);
		}
	}

	private static Delegate GetSetWillNotDraw_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetWillNotDraw_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWillNotDraw_Z(nint jnienv, nint native__this, sbyte native_willNotDraw)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool willNotDraw = native_willNotDraw != 0;
			view.SetWillNotDraw(willNotDraw);
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

	[Register("setWillNotDraw", "(Z)V", "GetSetWillNotDraw_ZHandler")]
	public unsafe virtual void SetWillNotDraw(bool willNotDraw)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(willNotDraw ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setWillNotDraw.(Z)V", this, ptr);
	}

	private static Delegate GetSetX_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetX_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetX_F(nint jnienv, nint native__this, float x)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetX(x);
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

	[Register("setX", "(F)V", "GetSetX_FHandler")]
	public unsafe virtual void SetX(float x)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(x);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setX.(F)V", this, ptr);
	}

	private static Delegate GetSetY_FHandler()
	{
		return new _JniMarshal_PPF_V(n_SetY_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetY_F(nint jnienv, nint native__this, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetY(y);
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

	[Register("setY", "(F)V", "GetSetY_FHandler")]
	public unsafe virtual void SetY(float y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setY.(F)V", this, ptr);
	}

	private static Delegate GetStartAnimation_Landroid_view_animation_Animation_Handler()
	{
		return new _JniMarshal_PPL_V(n_StartAnimation_Landroid_view_animation_Animation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartAnimation_Landroid_view_animation_Animation_(nint jnienv, nint native__this, nint native_animation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			View? view = Java.Lang.Object.GetObject<View>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.Animations.Animation animation = Java.Lang.Object.GetObject<Android.Views.Animations.Animation>(native_animation, JniHandleOwnership.DoNotTransfer);
			view.StartAnimation(animation);
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

	[Register("startAnimation", "(Landroid/view/animation/Animation;)V", "GetStartAnimation_Landroid_view_animation_Animation_Handler")]
	public unsafe virtual void StartAnimation(Android.Views.Animations.Animation? animation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startAnimation.(Landroid/view/animation/Animation;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animation);
		}
	}

	private IOnAttachStateChangeListenerImplementor __CreateIOnAttachStateChangeListenerImplementor()
	{
		return new IOnAttachStateChangeListenerImplementor(this);
	}

	private IOnLayoutChangeListenerImplementor __CreateIOnLayoutChangeListenerImplementor()
	{
		return new IOnLayoutChangeListenerImplementor();
	}

	private IOnClickListenerImplementor __CreateIOnClickListenerImplementor()
	{
		return new IOnClickListenerImplementor();
	}

	private IOnLongClickListenerImplementor __CreateIOnLongClickListenerImplementor()
	{
		return new IOnLongClickListenerImplementor(this);
	}

	private IOnScrollChangeListenerImplementor __CreateIOnScrollChangeListenerImplementor()
	{
		return new IOnScrollChangeListenerImplementor(this);
	}

	private IOnTouchListenerImplementor __CreateIOnTouchListenerImplementor()
	{
		return new IOnTouchListenerImplementor();
	}

	private IOnFocusChangeListenerImplementor __CreateIOnFocusChangeListenerImplementor()
	{
		return new IOnFocusChangeListenerImplementor();
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
	private static void n_OnAttachedToWindow_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnAttachedToWindow(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDetachedFromWindow_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDetachedFromWindow(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDraw_Landroid_graphics_Canvas__mm_wrapper(nint jnienv, nint native__this, nint native_canvas)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDraw_Landroid_graphics_Canvas_(jnienv, native__this, native_canvas);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnSizeChanged_IIII_mm_wrapper(nint jnienv, nint native__this, int w, int h, int oldw, int oldh)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnSizeChanged_IIII(jnienv, native__this, w, h, oldw, oldh);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_IsEnabled_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_IsEnabled(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetEnabled_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_enabled)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetEnabled_Z(jnienv, native__this, native_enabled);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_OnTouchEvent_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnTouchEvent_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnMeasure_II_mm_wrapper(nint jnienv, nint native__this, int widthMeasureSpec, int heightMeasureSpec)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnMeasure_II(jnienv, native__this, widthMeasureSpec, heightMeasureSpec);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_OnSaveInstanceState_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnSaveInstanceState(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnRestoreInstanceState_Landroid_os_Parcelable__mm_wrapper(nint jnienv, nint native__this, nint native_state)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnRestoreInstanceState_Landroid_os_Parcelable_(jnienv, native__this, native_state);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_DispatchDraw_Landroid_graphics_Canvas__mm_wrapper(nint jnienv, nint native__this, nint native_canvas)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_DispatchDraw_Landroid_graphics_Canvas_(jnienv, native__this, native_canvas);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static float n_GetTopFadingEdgeStrength_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetTopFadingEdgeStrength(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0f;
		}
	}

	[UnmanagedCallersOnly]
	private static float n_GetBottomFadingEdgeStrength_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetBottomFadingEdgeStrength(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0f;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetVisibility_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetVisibility(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetVisibility_I_mm_wrapper(nint jnienv, nint native__this, int native_visibility)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetVisibility_I(jnienv, native__this, native_visibility);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnFinishInflate_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnFinishInflate(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_OnKeyPreIme_ILandroid_view_KeyEvent__mm_wrapper(nint jnienv, nint native__this, int native_keyCode, nint native_e)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_OnKeyPreIme_ILandroid_view_KeyEvent_(jnienv, native__this, native_keyCode, native_e);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetBackground_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetBackground(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_SetBackground_Landroid_graphics_drawable_Drawable__mm_wrapper(nint jnienv, nint native__this, nint native_background)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_SetBackground_Landroid_graphics_drawable_Drawable_(jnienv, native__this, native_background);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnVisibilityChanged_Landroid_view_View_I_mm_wrapper(nint jnienv, nint native__this, nint native_changedView, int native_visibility)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnVisibilityChanged_Landroid_view_View_I(jnienv, native__this, native_changedView, native_visibility);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_RequestFocus_ILandroid_graphics_Rect__mm_wrapper(nint jnienv, nint native__this, int native_direction, nint native_previouslyFocusedRect)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_RequestFocus_ILandroid_graphics_Rect_(jnienv, native__this, native_direction, native_previouslyFocusedRect);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_DispatchTouchEvent_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_e)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_DispatchTouchEvent_Landroid_view_MotionEvent_(jnienv, native__this, native_e);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}

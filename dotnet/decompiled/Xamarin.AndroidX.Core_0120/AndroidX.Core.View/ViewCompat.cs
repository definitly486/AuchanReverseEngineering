using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Accessibility;
using AndroidX.Core.View.Accessibility;
using AndroidX.Core.View.AutoFill;
using AndroidX.Core.View.ContentCapture;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ViewCompat", DoNotGenerateAcw = true)]
public class ViewCompat : Java.Lang.Object
{
	[Register("androidx/core/view/ViewCompat$OnUnhandledKeyEventListenerCompat", "", "AndroidX.Core.View.ViewCompat/IOnUnhandledKeyEventListenerCompatInvoker")]
	public interface IOnUnhandledKeyEventListenerCompat : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onUnhandledKeyEvent", "(Landroid/view/View;Landroid/view/KeyEvent;)Z", "GetOnUnhandledKeyEvent_Landroid_view_View_Landroid_view_KeyEvent_Handler:AndroidX.Core.View.ViewCompat/IOnUnhandledKeyEventListenerCompatInvoker, Xamarin.AndroidX.Core")]
		bool OnUnhandledKeyEvent(Android.Views.View? v, KeyEvent? e);
	}

	[Register("androidx/core/view/ViewCompat$OnUnhandledKeyEventListenerCompat", DoNotGenerateAcw = true)]
	internal class IOnUnhandledKeyEventListenerCompatInvoker : Java.Lang.Object, IOnUnhandledKeyEventListenerCompat, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_view_ViewCompat_OnUnhandledKeyEventListenerCompat = new XAPeerMembers("androidx/core/view/ViewCompat$OnUnhandledKeyEventListenerCompat", typeof(IOnUnhandledKeyEventListenerCompatInvoker));

		private static Delegate? cb_onUnhandledKeyEvent_OnUnhandledKeyEvent_Landroid_view_View_Landroid_view_KeyEvent__Z;

		private static nint java_class_ref => _members_androidx_core_view_ViewCompat_OnUnhandledKeyEventListenerCompat.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_ViewCompat_OnUnhandledKeyEventListenerCompat;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_view_ViewCompat_OnUnhandledKeyEventListenerCompat.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_view_ViewCompat_OnUnhandledKeyEventListenerCompat.ManagedPeerType;

		public IOnUnhandledKeyEventListenerCompatInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnUnhandledKeyEvent_Landroid_view_View_Landroid_view_KeyEvent_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_OnUnhandledKeyEvent_Landroid_view_View_Landroid_view_KeyEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnUnhandledKeyEvent_Landroid_view_View_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_v, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnUnhandledKeyEventListenerCompat? onUnhandledKeyEventListenerCompat = Java.Lang.Object.GetObject<IOnUnhandledKeyEventListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Android.Views.View v = Java.Lang.Object.GetObject<Android.Views.View>(native_v, JniHandleOwnership.DoNotTransfer);
				KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return onUnhandledKeyEventListenerCompat.OnUnhandledKeyEvent(v, e) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnUnhandledKeyEvent(Android.Views.View? v, KeyEvent? e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members_androidx_core_view_ViewCompat_OnUnhandledKeyEventListenerCompat.InstanceMethods.InvokeAbstractBooleanMethod("onUnhandledKeyEvent.(Landroid/view/View;Landroid/view/KeyEvent;)Z", this, ptr);
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/ViewCompat", typeof(ViewCompat));

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

	protected ViewCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	[Obsolete("deprecated")]
	protected unsafe ViewCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("addAccessibilityAction", "(Landroid/view/View;Ljava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)I", "")]
	public unsafe static int AddAccessibilityAction(Android.Views.View? view, ICharSequence? label, IAccessibilityViewCommand? command)
	{
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
			return _members.StaticMethods.InvokeInt32Method("addAccessibilityAction.(Landroid/view/View;Ljava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(label);
			GC.KeepAlive(command);
		}
	}

	public static int AddAccessibilityAction(Android.Views.View? view, string? label, IAccessibilityViewCommand? command)
	{
		Java.Lang.String obj = ((label == null) ? null : new Java.Lang.String(label));
		int result = AddAccessibilityAction(view, obj, command);
		obj?.Dispose();
		return result;
	}

	[Register("addKeyboardNavigationClusters", "(Landroid/view/View;Ljava/util/Collection;I)V", "")]
	public unsafe static void AddKeyboardNavigationClusters(Android.Views.View? view, ICollection<Android.Views.View>? views, int direction)
	{
		nint num = JavaCollection<Android.Views.View>.ToLocalJniHandle(views);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(direction);
			_members.StaticMethods.InvokeVoidMethod("addKeyboardNavigationClusters.(Landroid/view/View;Ljava/util/Collection;I)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(views);
		}
	}

	[Register("addOnUnhandledKeyEventListener", "(Landroid/view/View;Landroidx/core/view/ViewCompat$OnUnhandledKeyEventListenerCompat;)V", "")]
	public unsafe static void AddOnUnhandledKeyEventListener(Android.Views.View? v, IOnUnhandledKeyEventListenerCompat? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("addOnUnhandledKeyEventListener.(Landroid/view/View;Landroidx/core/view/ViewCompat$OnUnhandledKeyEventListenerCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(listener);
		}
	}

	[Register("addOverlayView", "(Landroid/view/ViewGroup;Landroid/view/View;)V", "")]
	public unsafe static void AddOverlayView(ViewGroup? overlayHost, Android.Views.View? overlay)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(overlayHost?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(overlay?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("addOverlayView.(Landroid/view/ViewGroup;Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(overlayHost);
			GC.KeepAlive(overlay);
		}
	}

	[Obsolete("deprecated")]
	[Register("animate", "(Landroid/view/View;)Landroidx/core/view/ViewPropertyAnimatorCompat;", "")]
	public unsafe static ViewPropertyAnimatorCompat? Animate(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members.StaticMethods.InvokeObjectMethod("animate.(Landroid/view/View;)Landroidx/core/view/ViewPropertyAnimatorCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("canScrollHorizontally", "(Landroid/view/View;I)Z", "")]
	public unsafe static bool CanScrollHorizontally(Android.Views.View? view, int direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(direction);
			return _members.StaticMethods.InvokeBooleanMethod("canScrollHorizontally.(Landroid/view/View;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("canScrollVertically", "(Landroid/view/View;I)Z", "")]
	public unsafe static bool CanScrollVertically(Android.Views.View? view, int direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(direction);
			return _members.StaticMethods.InvokeBooleanMethod("canScrollVertically.(Landroid/view/View;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("cancelDragAndDrop", "(Landroid/view/View;)V", "")]
	public unsafe static void CancelDragAndDrop(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("cancelDragAndDrop.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("combineMeasuredStates", "(II)I", "")]
	public unsafe static int CombineMeasuredStates(int curState, int newState)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(curState);
		ptr[1] = new JniArgumentValue(newState);
		return _members.StaticMethods.InvokeInt32Method("combineMeasuredStates.(II)I", ptr);
	}

	[Register("computeSystemWindowInsets", "(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;Landroid/graphics/Rect;)Landroidx/core/view/WindowInsetsCompat;", "")]
	public unsafe static WindowInsetsCompat? ComputeSystemWindowInsets(Android.Views.View? view, WindowInsetsCompat? insets, Rect? outLocalInsets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(outLocalInsets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.StaticMethods.InvokeObjectMethod("computeSystemWindowInsets.(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;Landroid/graphics/Rect;)Landroidx/core/view/WindowInsetsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(insets);
			GC.KeepAlive(outLocalInsets);
		}
	}

	[Register("dispatchApplyWindowInsets", "(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", "")]
	public unsafe static WindowInsetsCompat? DispatchApplyWindowInsets(Android.Views.View? view, WindowInsetsCompat? insets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.StaticMethods.InvokeObjectMethod("dispatchApplyWindowInsets.(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(insets);
		}
	}

	[Register("dispatchFinishTemporaryDetach", "(Landroid/view/View;)V", "")]
	public unsafe static void DispatchFinishTemporaryDetach(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("dispatchFinishTemporaryDetach.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("dispatchNestedFling", "(Landroid/view/View;FFZ)Z", "")]
	public unsafe static bool DispatchNestedFling(Android.Views.View? view, float velocityX, float velocityY, bool consumed)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(velocityX);
			ptr[2] = new JniArgumentValue(velocityY);
			ptr[3] = new JniArgumentValue(consumed ? ((sbyte)1) : ((sbyte)0));
			return _members.StaticMethods.InvokeBooleanMethod("dispatchNestedFling.(Landroid/view/View;FFZ)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("dispatchNestedPreFling", "(Landroid/view/View;FF)Z", "")]
	public unsafe static bool DispatchNestedPreFling(Android.Views.View? view, float velocityX, float velocityY)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(velocityX);
			ptr[2] = new JniArgumentValue(velocityY);
			return _members.StaticMethods.InvokeBooleanMethod("dispatchNestedPreFling.(Landroid/view/View;FF)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("dispatchNestedPreScroll", "(Landroid/view/View;II[I[I)Z", "")]
	public unsafe static bool DispatchNestedPreScroll(Android.Views.View? view, int dx, int dy, int[]? consumed, int[]? offsetInWindow)
	{
		nint num = JNIEnv.NewArray(consumed);
		nint num2 = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dx);
			ptr[2] = new JniArgumentValue(dy);
			ptr[3] = new JniArgumentValue(num);
			ptr[4] = new JniArgumentValue(num2);
			return _members.StaticMethods.InvokeBooleanMethod("dispatchNestedPreScroll.(Landroid/view/View;II[I[I)Z", ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num2, offsetInWindow);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(consumed);
			GC.KeepAlive(offsetInWindow);
		}
	}

	[Register("dispatchNestedPreScroll", "(Landroid/view/View;II[I[II)Z", "")]
	public unsafe static bool DispatchNestedPreScroll(Android.Views.View? view, int dx, int dy, int[]? consumed, int[]? offsetInWindow, int type)
	{
		nint num = JNIEnv.NewArray(consumed);
		nint num2 = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dx);
			ptr[2] = new JniArgumentValue(dy);
			ptr[3] = new JniArgumentValue(num);
			ptr[4] = new JniArgumentValue(num2);
			ptr[5] = new JniArgumentValue(type);
			return _members.StaticMethods.InvokeBooleanMethod("dispatchNestedPreScroll.(Landroid/view/View;II[I[II)Z", ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num2, offsetInWindow);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(consumed);
			GC.KeepAlive(offsetInWindow);
		}
	}

	[Register("dispatchNestedScroll", "(Landroid/view/View;IIII[I)Z", "")]
	public unsafe static bool DispatchNestedScroll(Android.Views.View? view, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow)
	{
		nint num = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			ptr[5] = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeBooleanMethod("dispatchNestedScroll.(Landroid/view/View;IIII[I)Z", ptr);
		}
		finally
		{
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num, offsetInWindow);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(offsetInWindow);
		}
	}

	[Register("dispatchNestedScroll", "(Landroid/view/View;IIII[II)Z", "")]
	public unsafe static bool DispatchNestedScroll(Android.Views.View? view, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow, int type)
	{
		nint num = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			ptr[5] = new JniArgumentValue(num);
			ptr[6] = new JniArgumentValue(type);
			return _members.StaticMethods.InvokeBooleanMethod("dispatchNestedScroll.(Landroid/view/View;IIII[II)Z", ptr);
		}
		finally
		{
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num, offsetInWindow);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(offsetInWindow);
		}
	}

	[Register("dispatchNestedScroll", "(Landroid/view/View;IIII[II[I)V", "")]
	public unsafe static void DispatchNestedScroll(Android.Views.View? view, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow, int type, int[]? consumed)
	{
		nint num = JNIEnv.NewArray(offsetInWindow);
		nint num2 = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			ptr[5] = new JniArgumentValue(num);
			ptr[6] = new JniArgumentValue(type);
			ptr[7] = new JniArgumentValue(num2);
			_members.StaticMethods.InvokeVoidMethod("dispatchNestedScroll.(Landroid/view/View;IIII[II[I)V", ptr);
		}
		finally
		{
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num, offsetInWindow);
				JNIEnv.DeleteLocalRef(num);
			}
			if (consumed != null)
			{
				JNIEnv.CopyArray(num2, consumed);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(offsetInWindow);
			GC.KeepAlive(consumed);
		}
	}

	[Register("dispatchStartTemporaryDetach", "(Landroid/view/View;)V", "")]
	public unsafe static void DispatchStartTemporaryDetach(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("dispatchStartTemporaryDetach.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("enableAccessibleClickableSpanSupport", "(Landroid/view/View;)V", "")]
	public unsafe static void EnableAccessibleClickableSpanSupport(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("enableAccessibleClickableSpanSupport.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("generateViewId", "()I", "")]
	public unsafe static int GenerateViewId()
	{
		return _members.StaticMethods.InvokeInt32Method("generateViewId.()I", null);
	}

	[Register("getAccessibilityDelegate", "(Landroid/view/View;)Landroidx/core/view/AccessibilityDelegateCompat;", "")]
	public unsafe static AccessibilityDelegateCompat? GetAccessibilityDelegate(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AccessibilityDelegateCompat>(_members.StaticMethods.InvokeObjectMethod("getAccessibilityDelegate.(Landroid/view/View;)Landroidx/core/view/AccessibilityDelegateCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getAccessibilityLiveRegion", "(Landroid/view/View;)I", "")]
	public unsafe static int GetAccessibilityLiveRegion(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getAccessibilityLiveRegion.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getAccessibilityNodeProvider", "(Landroid/view/View;)Landroidx/core/view/accessibility/AccessibilityNodeProviderCompat;", "")]
	public unsafe static AccessibilityNodeProviderCompat? GetAccessibilityNodeProvider(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AccessibilityNodeProviderCompat>(_members.StaticMethods.InvokeObjectMethod("getAccessibilityNodeProvider.(Landroid/view/View;)Landroidx/core/view/accessibility/AccessibilityNodeProviderCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getAccessibilityPaneTitle", "(Landroid/view/View;)Ljava/lang/CharSequence;", "")]
	public unsafe static ICharSequence? GetAccessibilityPaneTitleFormatted(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ICharSequence>(_members.StaticMethods.InvokeObjectMethod("getAccessibilityPaneTitle.(Landroid/view/View;)Ljava/lang/CharSequence;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	public static string? GetAccessibilityPaneTitle(Android.Views.View? view)
	{
		return GetAccessibilityPaneTitleFormatted(view)?.ToString();
	}

	[Obsolete("deprecated")]
	[Register("getAlpha", "(Landroid/view/View;)F", "")]
	public unsafe static float GetAlpha(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getAlpha.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getAutofillId", "(Landroid/view/View;)Landroidx/core/view/autofill/AutofillIdCompat;", "")]
	public unsafe static AutofillIdCompat? GetAutofillId(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AutofillIdCompat>(_members.StaticMethods.InvokeObjectMethod("getAutofillId.(Landroid/view/View;)Landroidx/core/view/autofill/AutofillIdCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("getBackgroundTintList", "(Landroid/view/View;)Landroid/content/res/ColorStateList;", "")]
	public unsafe static ColorStateList? GetBackgroundTintList(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ColorStateList>(_members.StaticMethods.InvokeObjectMethod("getBackgroundTintList.(Landroid/view/View;)Landroid/content/res/ColorStateList;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getBackgroundTintMode", "(Landroid/view/View;)Landroid/graphics/PorterDuff$Mode;", "")]
	public unsafe static PorterDuff.Mode? GetBackgroundTintMode(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.StaticMethods.InvokeObjectMethod("getBackgroundTintMode.(Landroid/view/View;)Landroid/graphics/PorterDuff$Mode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getClipBounds", "(Landroid/view/View;)Landroid/graphics/Rect;", "")]
	public unsafe static Rect? GetClipBounds(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Rect>(_members.StaticMethods.InvokeObjectMethod("getClipBounds.(Landroid/view/View;)Landroid/graphics/Rect;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getContentCaptureSession", "(Landroid/view/View;)Landroidx/core/view/contentcapture/ContentCaptureSessionCompat;", "")]
	public unsafe static ContentCaptureSessionCompat? GetContentCaptureSession(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ContentCaptureSessionCompat>(_members.StaticMethods.InvokeObjectMethod("getContentCaptureSession.(Landroid/view/View;)Landroidx/core/view/contentcapture/ContentCaptureSessionCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("getDisplay", "(Landroid/view/View;)Landroid/view/Display;", "")]
	public unsafe static Display? GetDisplay(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Display>(_members.StaticMethods.InvokeObjectMethod("getDisplay.(Landroid/view/View;)Landroid/view/Display;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getElevation", "(Landroid/view/View;)F", "")]
	public unsafe static float GetElevation(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getElevation.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getFitsSystemWindows", "(Landroid/view/View;)Z", "")]
	public unsafe static bool GetFitsSystemWindows(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("getFitsSystemWindows.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("getImportantForAccessibility", "(Landroid/view/View;)I", "")]
	public unsafe static int GetImportantForAccessibility(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getImportantForAccessibility.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getImportantForAutofill", "(Landroid/view/View;)I", "")]
	public unsafe static int GetImportantForAutofill(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getImportantForAutofill.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("getImportantForContentCapture", "(Landroid/view/View;)I", "")]
	public unsafe static int GetImportantForContentCapture(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getImportantForContentCapture.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("getLabelFor", "(Landroid/view/View;)I", "")]
	public unsafe static int GetLabelFor(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getLabelFor.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getLayerType", "(Landroid/view/View;)I", "")]
	public unsafe static int GetLayerType(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getLayerType.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getLayoutDirection", "(Landroid/view/View;)I", "")]
	public unsafe static int GetLayoutDirection(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getLayoutDirection.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMatrix", "(Landroid/view/View;)Landroid/graphics/Matrix;", "")]
	public unsafe static Matrix? GetMatrix(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Matrix>(_members.StaticMethods.InvokeObjectMethod("getMatrix.(Landroid/view/View;)Landroid/graphics/Matrix;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMeasuredHeightAndState", "(Landroid/view/View;)I", "")]
	public unsafe static int GetMeasuredHeightAndState(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getMeasuredHeightAndState.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMeasuredState", "(Landroid/view/View;)I", "")]
	public unsafe static int GetMeasuredState(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getMeasuredState.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMeasuredWidthAndState", "(Landroid/view/View;)I", "")]
	public unsafe static int GetMeasuredWidthAndState(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getMeasuredWidthAndState.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMinimumHeight", "(Landroid/view/View;)I", "")]
	public unsafe static int GetMinimumHeight(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getMinimumHeight.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getMinimumWidth", "(Landroid/view/View;)I", "")]
	public unsafe static int GetMinimumWidth(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getMinimumWidth.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getNextClusterForwardId", "(Landroid/view/View;)I", "")]
	public unsafe static int GetNextClusterForwardId(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getNextClusterForwardId.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getOnReceiveContentMimeTypes", "(Landroid/view/View;)[Ljava/lang/String;", "")]
	public unsafe static string[]? GetOnReceiveContentMimeTypes(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return (string[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("getOnReceiveContentMimeTypes.(Landroid/view/View;)[Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getOverScrollMode", "(Landroid/view/View;)I", "")]
	public unsafe static int GetOverScrollMode(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getOverScrollMode.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("getPaddingEnd", "(Landroid/view/View;)I", "")]
	public unsafe static int GetPaddingEnd(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getPaddingEnd.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getPaddingStart", "(Landroid/view/View;)I", "")]
	public unsafe static int GetPaddingStart(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getPaddingStart.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getParentForAccessibility", "(Landroid/view/View;)Landroid/view/ViewParent;", "")]
	public unsafe static IViewParent? GetParentForAccessibility(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IViewParent>(_members.StaticMethods.InvokeObjectMethod("getParentForAccessibility.(Landroid/view/View;)Landroid/view/ViewParent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getPivotX", "(Landroid/view/View;)F", "")]
	public unsafe static float GetPivotX(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getPivotX.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getPivotY", "(Landroid/view/View;)F", "")]
	public unsafe static float GetPivotY(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getPivotY.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getRootWindowInsets", "(Landroid/view/View;)Landroidx/core/view/WindowInsetsCompat;", "")]
	public unsafe static WindowInsetsCompat? GetRootWindowInsets(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.StaticMethods.InvokeObjectMethod("getRootWindowInsets.(Landroid/view/View;)Landroidx/core/view/WindowInsetsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getRotation", "(Landroid/view/View;)F", "")]
	public unsafe static float GetRotation(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getRotation.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getRotationX", "(Landroid/view/View;)F", "")]
	public unsafe static float GetRotationX(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getRotationX.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getRotationY", "(Landroid/view/View;)F", "")]
	public unsafe static float GetRotationY(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getRotationY.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getScaleX", "(Landroid/view/View;)F", "")]
	public unsafe static float GetScaleX(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getScaleX.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getScaleY", "(Landroid/view/View;)F", "")]
	public unsafe static float GetScaleY(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getScaleY.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getScrollIndicators", "(Landroid/view/View;)I", "")]
	public unsafe static int GetScrollIndicators(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getScrollIndicators.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getStateDescription", "(Landroid/view/View;)Ljava/lang/CharSequence;", "")]
	public unsafe static ICharSequence? GetStateDescriptionFormatted(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ICharSequence>(_members.StaticMethods.InvokeObjectMethod("getStateDescription.(Landroid/view/View;)Ljava/lang/CharSequence;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	public static string? GetStateDescription(Android.Views.View? view)
	{
		return GetStateDescriptionFormatted(view)?.ToString();
	}

	[Register("getSystemGestureExclusionRects", "(Landroid/view/View;)Ljava/util/List;", "")]
	public unsafe static IList<Rect>? GetSystemGestureExclusionRects(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return JavaList<Rect>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getSystemGestureExclusionRects.(Landroid/view/View;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getTransitionName", "(Landroid/view/View;)Ljava/lang/String;", "")]
	public unsafe static string? GetTransitionName(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getTransitionName.(Landroid/view/View;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getTranslationX", "(Landroid/view/View;)F", "")]
	public unsafe static float GetTranslationX(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getTranslationX.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getTranslationY", "(Landroid/view/View;)F", "")]
	public unsafe static float GetTranslationY(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getTranslationY.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getTranslationZ", "(Landroid/view/View;)F", "")]
	public unsafe static float GetTranslationZ(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getTranslationZ.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getWindowInsetsController", "(Landroid/view/View;)Landroidx/core/view/WindowInsetsControllerCompat;", "")]
	public unsafe static WindowInsetsControllerCompat? GetWindowInsetsController(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsControllerCompat>(_members.StaticMethods.InvokeObjectMethod("getWindowInsetsController.(Landroid/view/View;)Landroidx/core/view/WindowInsetsControllerCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getWindowSystemUiVisibility", "(Landroid/view/View;)I", "")]
	public unsafe static int GetWindowSystemUiVisibility(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getWindowSystemUiVisibility.(Landroid/view/View;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getX", "(Landroid/view/View;)F", "")]
	public unsafe static float GetX(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getX.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("getY", "(Landroid/view/View;)F", "")]
	public unsafe static float GetY(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getY.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("getZ", "(Landroid/view/View;)F", "")]
	public unsafe static float GetZ(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("getZ.(Landroid/view/View;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("hasAccessibilityDelegate", "(Landroid/view/View;)Z", "")]
	public unsafe static bool HasAccessibilityDelegate(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasAccessibilityDelegate.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("hasExplicitFocusable", "(Landroid/view/View;)Z", "")]
	public unsafe static bool HasExplicitFocusable(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasExplicitFocusable.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("hasNestedScrollingParent", "(Landroid/view/View;)Z", "")]
	public unsafe static bool HasNestedScrollingParent(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasNestedScrollingParent.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("hasNestedScrollingParent", "(Landroid/view/View;I)Z", "")]
	public unsafe static bool HasNestedScrollingParent(Android.Views.View? view, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type);
			return _members.StaticMethods.InvokeBooleanMethod("hasNestedScrollingParent.(Landroid/view/View;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("hasOnClickListeners", "(Landroid/view/View;)Z", "")]
	public unsafe static bool HasOnClickListeners(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasOnClickListeners.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("hasOverlappingRendering", "(Landroid/view/View;)Z", "")]
	public unsafe static bool HasOverlappingRendering(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasOverlappingRendering.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("hasTransientState", "(Landroid/view/View;)Z", "")]
	public unsafe static bool HasTransientState(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("hasTransientState.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("isAccessibilityHeading", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsAccessibilityHeading(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isAccessibilityHeading.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("isAttachedToWindow", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsAttachedToWindow(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isAttachedToWindow.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("isFocusedByDefault", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsFocusedByDefault(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isFocusedByDefault.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("isImportantForAccessibility", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsImportantForAccessibility(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isImportantForAccessibility.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("isImportantForAutofill", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsImportantForAutofill(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isImportantForAutofill.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("isImportantForContentCapture", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsImportantForContentCapture(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isImportantForContentCapture.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("isInLayout", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsInLayout(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isInLayout.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("isKeyboardNavigationCluster", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsKeyboardNavigationCluster(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isKeyboardNavigationCluster.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("isLaidOut", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsLaidOut(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isLaidOut.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("isLayoutDirectionResolved", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsLayoutDirectionResolved(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isLayoutDirectionResolved.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("isNestedScrollingEnabled", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsNestedScrollingEnabled(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isNestedScrollingEnabled.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("isOpaque", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsOpaque(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isOpaque.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("isPaddingRelative", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsPaddingRelative(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isPaddingRelative.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("isScreenReaderFocusable", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsScreenReaderFocusable(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isScreenReaderFocusable.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("jumpDrawablesToCurrentState", "(Landroid/view/View;)V", "")]
	public unsafe static void JumpDrawablesToCurrentState(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("jumpDrawablesToCurrentState.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("keyboardNavigationClusterSearch", "(Landroid/view/View;Landroid/view/View;I)Landroid/view/View;", "")]
	public unsafe static Android.Views.View? KeyboardNavigationClusterSearch(Android.Views.View? view, Android.Views.View? currentCluster, int direction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(currentCluster?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(direction);
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.StaticMethods.InvokeObjectMethod("keyboardNavigationClusterSearch.(Landroid/view/View;Landroid/view/View;I)Landroid/view/View;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(currentCluster);
		}
	}

	[Register("offsetLeftAndRight", "(Landroid/view/View;I)V", "")]
	public unsafe static void OffsetLeftAndRight(Android.Views.View? view, int offset)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(offset);
			_members.StaticMethods.InvokeVoidMethod("offsetLeftAndRight.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("offsetTopAndBottom", "(Landroid/view/View;I)V", "")]
	public unsafe static void OffsetTopAndBottom(Android.Views.View? view, int offset)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(offset);
			_members.StaticMethods.InvokeVoidMethod("offsetTopAndBottom.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("onApplyWindowInsets", "(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", "")]
	public unsafe static WindowInsetsCompat? OnApplyWindowInsets(Android.Views.View? view, WindowInsetsCompat? insets)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.StaticMethods.InvokeObjectMethod("onApplyWindowInsets.(Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(insets);
		}
	}

	[Obsolete("deprecated")]
	[Register("onInitializeAccessibilityEvent", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", "")]
	public unsafe static void OnInitializeAccessibilityEvent(Android.Views.View? v, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onInitializeAccessibilityEvent.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(e);
		}
	}

	[Obsolete("deprecated")]
	[Register("onInitializeAccessibilityNodeInfo", "(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", "")]
	public unsafe static void OnInitializeAccessibilityNodeInfo(Android.Views.View? v, AccessibilityNodeInfoCompat? info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onInitializeAccessibilityNodeInfo.(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(info);
		}
	}

	[Obsolete("deprecated")]
	[Register("onPopulateAccessibilityEvent", "(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", "")]
	public unsafe static void OnPopulateAccessibilityEvent(Android.Views.View? v, AccessibilityEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("onPopulateAccessibilityEvent.(Landroid/view/View;Landroid/view/accessibility/AccessibilityEvent;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(e);
		}
	}

	[Obsolete("deprecated")]
	[Register("performAccessibilityAction", "(Landroid/view/View;ILandroid/os/Bundle;)Z", "")]
	public unsafe static bool PerformAccessibilityAction(Android.Views.View? view, int action, Bundle? arguments)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(action);
			ptr[2] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("performAccessibilityAction.(Landroid/view/View;ILandroid/os/Bundle;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(arguments);
		}
	}

	[Register("performHapticFeedback", "(Landroid/view/View;I)Z", "")]
	public unsafe static bool PerformHapticFeedback(Android.Views.View? view, int feedbackConstant)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(feedbackConstant);
			return _members.StaticMethods.InvokeBooleanMethod("performHapticFeedback.(Landroid/view/View;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("performHapticFeedback", "(Landroid/view/View;II)Z", "")]
	public unsafe static bool PerformHapticFeedback(Android.Views.View? view, int feedbackConstant, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(feedbackConstant);
			ptr[2] = new JniArgumentValue(flags);
			return _members.StaticMethods.InvokeBooleanMethod("performHapticFeedback.(Landroid/view/View;II)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("performReceiveContent", "(Landroid/view/View;Landroidx/core/view/ContentInfoCompat;)Landroidx/core/view/ContentInfoCompat;", "")]
	public unsafe static ContentInfoCompat? PerformReceiveContent(Android.Views.View? view, ContentInfoCompat? payload)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ContentInfoCompat>(_members.StaticMethods.InvokeObjectMethod("performReceiveContent.(Landroid/view/View;Landroidx/core/view/ContentInfoCompat;)Landroidx/core/view/ContentInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(payload);
		}
	}

	[Obsolete("deprecated")]
	[Register("postInvalidateOnAnimation", "(Landroid/view/View;)V", "")]
	public unsafe static void PostInvalidateOnAnimation(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("postInvalidateOnAnimation.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("postInvalidateOnAnimation", "(Landroid/view/View;IIII)V", "")]
	public unsafe static void PostInvalidateOnAnimation(Android.Views.View? view, int left, int top, int right, int bottom)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(left);
			ptr[2] = new JniArgumentValue(top);
			ptr[3] = new JniArgumentValue(right);
			ptr[4] = new JniArgumentValue(bottom);
			_members.StaticMethods.InvokeVoidMethod("postInvalidateOnAnimation.(Landroid/view/View;IIII)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("postOnAnimation", "(Landroid/view/View;Ljava/lang/Runnable;)V", "")]
	public unsafe static void PostOnAnimation(Android.Views.View? view, IRunnable? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			_members.StaticMethods.InvokeVoidMethod("postOnAnimation.(Landroid/view/View;Ljava/lang/Runnable;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(action);
		}
	}

	[Obsolete("deprecated")]
	[Register("postOnAnimationDelayed", "(Landroid/view/View;Ljava/lang/Runnable;J)V", "")]
	public unsafe static void PostOnAnimationDelayed(Android.Views.View? view, IRunnable? action, long delayMillis)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
			ptr[2] = new JniArgumentValue(delayMillis);
			_members.StaticMethods.InvokeVoidMethod("postOnAnimationDelayed.(Landroid/view/View;Ljava/lang/Runnable;J)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(action);
		}
	}

	[Register("removeAccessibilityAction", "(Landroid/view/View;I)V", "")]
	public unsafe static void RemoveAccessibilityAction(Android.Views.View? view, int actionId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(actionId);
			_members.StaticMethods.InvokeVoidMethod("removeAccessibilityAction.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("removeOnUnhandledKeyEventListener", "(Landroid/view/View;Landroidx/core/view/ViewCompat$OnUnhandledKeyEventListenerCompat;)V", "")]
	public unsafe static void RemoveOnUnhandledKeyEventListener(Android.Views.View? v, IOnUnhandledKeyEventListenerCompat? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("removeOnUnhandledKeyEventListener.(Landroid/view/View;Landroidx/core/view/ViewCompat$OnUnhandledKeyEventListenerCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(listener);
		}
	}

	[Register("replaceAccessibilityAction", "(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;Ljava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", "")]
	public unsafe static void ReplaceAccessibilityAction(Android.Views.View? view, AccessibilityNodeInfoCompat.AccessibilityActionCompat? replacedAction, ICharSequence? label, IAccessibilityViewCommand? command)
	{
		nint num = CharSequence.ToLocalJniHandle(label);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(replacedAction?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
			_members.StaticMethods.InvokeVoidMethod("replaceAccessibilityAction.(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;Ljava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(replacedAction);
			GC.KeepAlive(label);
			GC.KeepAlive(command);
		}
	}

	public static void ReplaceAccessibilityAction(Android.Views.View? view, AccessibilityNodeInfoCompat.AccessibilityActionCompat? replacedAction, string? label, IAccessibilityViewCommand? command)
	{
		Java.Lang.String obj = ((label == null) ? null : new Java.Lang.String(label));
		ReplaceAccessibilityAction(view, replacedAction, obj, command);
		obj?.Dispose();
	}

	[Register("requestApplyInsets", "(Landroid/view/View;)V", "")]
	public unsafe static void RequestApplyInsets(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("requestApplyInsets.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("requireViewById", "(Landroid/view/View;I)Landroid/view/View;", "")]
	[JavaTypeParameters(new string[] { "T extends android.view.View" })]
	public unsafe static Java.Lang.Object? RequireViewById(Android.Views.View? view, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("requireViewById.(Landroid/view/View;I)Landroid/view/View;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("resolveSizeAndState", "(III)I", "")]
	public unsafe static int ResolveSizeAndState(int size, int measureSpec, int childMeasuredState)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(size);
		ptr[1] = new JniArgumentValue(measureSpec);
		ptr[2] = new JniArgumentValue(childMeasuredState);
		return _members.StaticMethods.InvokeInt32Method("resolveSizeAndState.(III)I", ptr);
	}

	[Register("restoreDefaultFocus", "(Landroid/view/View;)Z", "")]
	public unsafe static bool RestoreDefaultFocus(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("restoreDefaultFocus.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("saveAttributeDataForStyleable", "(Landroid/view/View;Landroid/content/Context;[ILandroid/util/AttributeSet;Landroid/content/res/TypedArray;II)V", "")]
	public unsafe static void SaveAttributeDataForStyleable(Android.Views.View? view, Context? context, int[]? styleable, IAttributeSet? attrs, TypedArray? t, int defStyleAttr, int defStyleRes)
	{
		nint num = JNIEnv.NewArray(styleable);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[4] = new JniArgumentValue(t?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(defStyleAttr);
			ptr[6] = new JniArgumentValue(defStyleRes);
			_members.StaticMethods.InvokeVoidMethod("saveAttributeDataForStyleable.(Landroid/view/View;Landroid/content/Context;[ILandroid/util/AttributeSet;Landroid/content/res/TypedArray;II)V", ptr);
		}
		finally
		{
			if (styleable != null)
			{
				JNIEnv.CopyArray(num, styleable);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(context);
			GC.KeepAlive(styleable);
			GC.KeepAlive(attrs);
			GC.KeepAlive(t);
		}
	}

	[Register("setAccessibilityDelegate", "(Landroid/view/View;Landroidx/core/view/AccessibilityDelegateCompat;)V", "")]
	public unsafe static void SetAccessibilityDelegate(Android.Views.View? v, AccessibilityDelegateCompat? @delegate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@delegate?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setAccessibilityDelegate.(Landroid/view/View;Landroidx/core/view/AccessibilityDelegateCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(@delegate);
		}
	}

	[Register("setAccessibilityHeading", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetAccessibilityHeading(Android.Views.View? view, bool isHeading)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isHeading ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setAccessibilityHeading.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setAccessibilityLiveRegion", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetAccessibilityLiveRegion(Android.Views.View? view, int mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(mode);
			_members.StaticMethods.InvokeVoidMethod("setAccessibilityLiveRegion.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setAccessibilityPaneTitle", "(Landroid/view/View;Ljava/lang/CharSequence;)V", "")]
	public unsafe static void SetAccessibilityPaneTitle(Android.Views.View? view, ICharSequence? accessibilityPaneTitle)
	{
		nint num = CharSequence.ToLocalJniHandle(accessibilityPaneTitle);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setAccessibilityPaneTitle.(Landroid/view/View;Ljava/lang/CharSequence;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(accessibilityPaneTitle);
		}
	}

	public static void SetAccessibilityPaneTitle(Android.Views.View? view, string? accessibilityPaneTitle)
	{
		Java.Lang.String obj = ((accessibilityPaneTitle == null) ? null : new Java.Lang.String(accessibilityPaneTitle));
		SetAccessibilityPaneTitle(view, obj);
		obj?.Dispose();
	}

	[Obsolete("deprecated")]
	[Register("setActivated", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetActivated(Android.Views.View? view, bool activated)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(activated ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setActivated.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setAlpha", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetAlpha(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setAlpha.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setAutofillHints", "(Landroid/view/View;[Ljava/lang/String;)V", "")]
	public unsafe static void SetAutofillHints(Android.Views.View? v, params string[]? autofillHints)
	{
		nint num = JNIEnv.NewArray(autofillHints);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setAutofillHints.(Landroid/view/View;[Ljava/lang/String;)V", ptr);
		}
		finally
		{
			if (autofillHints != null)
			{
				JNIEnv.CopyArray(num, autofillHints);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(v);
			GC.KeepAlive(autofillHints);
		}
	}

	[Register("setAutofillId", "(Landroid/view/View;Landroidx/core/view/autofill/AutofillIdCompat;)V", "")]
	public unsafe static void SetAutofillId(Android.Views.View? v, AutofillIdCompat? id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setAutofillId.(Landroid/view/View;Landroidx/core/view/autofill/AutofillIdCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(id);
		}
	}

	[Obsolete("deprecated")]
	[Register("setBackground", "(Landroid/view/View;Landroid/graphics/drawable/Drawable;)V", "")]
	public unsafe static void SetBackground(Android.Views.View? view, Drawable? background)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(background?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setBackground.(Landroid/view/View;Landroid/graphics/drawable/Drawable;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(background);
		}
	}

	[Register("setBackgroundTintList", "(Landroid/view/View;Landroid/content/res/ColorStateList;)V", "")]
	public unsafe static void SetBackgroundTintList(Android.Views.View? view, ColorStateList? tintList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(tintList?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setBackgroundTintList.(Landroid/view/View;Landroid/content/res/ColorStateList;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(tintList);
		}
	}

	[Register("setBackgroundTintMode", "(Landroid/view/View;Landroid/graphics/PorterDuff$Mode;)V", "")]
	public unsafe static void SetBackgroundTintMode(Android.Views.View? view, PorterDuff.Mode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setBackgroundTintMode.(Landroid/view/View;Landroid/graphics/PorterDuff$Mode;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(mode);
		}
	}

	[Obsolete("deprecated")]
	[Register("setChildrenDrawingOrderEnabled", "(Landroid/view/ViewGroup;Z)V", "")]
	public unsafe static void SetChildrenDrawingOrderEnabled(ViewGroup? viewGroup, bool enabled)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewGroup?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setChildrenDrawingOrderEnabled.(Landroid/view/ViewGroup;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(viewGroup);
		}
	}

	[Obsolete("deprecated")]
	[Register("setClipBounds", "(Landroid/view/View;Landroid/graphics/Rect;)V", "")]
	public unsafe static void SetClipBounds(Android.Views.View? view, Rect? clipBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(clipBounds?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setClipBounds.(Landroid/view/View;Landroid/graphics/Rect;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(clipBounds);
		}
	}

	[Register("setContentCaptureSession", "(Landroid/view/View;Landroidx/core/view/contentcapture/ContentCaptureSessionCompat;)V", "")]
	public unsafe static void SetContentCaptureSession(Android.Views.View? v, ContentCaptureSessionCompat? contentCaptureSession)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(contentCaptureSession?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setContentCaptureSession.(Landroid/view/View;Landroidx/core/view/contentcapture/ContentCaptureSessionCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(contentCaptureSession);
		}
	}

	[Register("setElevation", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetElevation(Android.Views.View? view, float elevation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(elevation);
			_members.StaticMethods.InvokeVoidMethod("setElevation.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setFitsSystemWindows", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetFitsSystemWindows(Android.Views.View? view, bool fitSystemWindows)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(fitSystemWindows ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setFitsSystemWindows.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setFocusedByDefault", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetFocusedByDefault(Android.Views.View? view, bool isFocusedByDefault)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isFocusedByDefault ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setFocusedByDefault.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setHasTransientState", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetHasTransientState(Android.Views.View? view, bool hasTransientState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(hasTransientState ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setHasTransientState.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setImportantForAccessibility", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetImportantForAccessibility(Android.Views.View? view, int mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(mode);
			_members.StaticMethods.InvokeVoidMethod("setImportantForAccessibility.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setImportantForAutofill", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetImportantForAutofill(Android.Views.View? v, int mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(mode);
			_members.StaticMethods.InvokeVoidMethod("setImportantForAutofill.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("setImportantForContentCapture", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetImportantForContentCapture(Android.Views.View? v, int mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(mode);
			_members.StaticMethods.InvokeVoidMethod("setImportantForContentCapture.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("setKeyboardNavigationCluster", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetKeyboardNavigationCluster(Android.Views.View? view, bool isCluster)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isCluster ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setKeyboardNavigationCluster.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setLabelFor", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetLabelFor(Android.Views.View? view, int labeledId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(labeledId);
			_members.StaticMethods.InvokeVoidMethod("setLabelFor.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setLayerPaint", "(Landroid/view/View;Landroid/graphics/Paint;)V", "")]
	public unsafe static void SetLayerPaint(Android.Views.View? view, Paint? paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setLayerPaint.(Landroid/view/View;Landroid/graphics/Paint;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(paint);
		}
	}

	[Obsolete("deprecated")]
	[Register("setLayerType", "(Landroid/view/View;ILandroid/graphics/Paint;)V", "")]
	public unsafe static void SetLayerType(Android.Views.View? view, int layerType, Paint? paint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(layerType);
			ptr[2] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setLayerType.(Landroid/view/View;ILandroid/graphics/Paint;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(paint);
		}
	}

	[Obsolete("deprecated")]
	[Register("setLayoutDirection", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetLayoutDirection(Android.Views.View? view, int layoutDirection)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(layoutDirection);
			_members.StaticMethods.InvokeVoidMethod("setLayoutDirection.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setNestedScrollingEnabled", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetNestedScrollingEnabled(Android.Views.View? view, bool enabled)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setNestedScrollingEnabled.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setNextClusterForwardId", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetNextClusterForwardId(Android.Views.View? view, int nextClusterForwardId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(nextClusterForwardId);
			_members.StaticMethods.InvokeVoidMethod("setNextClusterForwardId.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setOnApplyWindowInsetsListener", "(Landroid/view/View;Landroidx/core/view/OnApplyWindowInsetsListener;)V", "")]
	public unsafe static void SetOnApplyWindowInsetsListener(Android.Views.View? v, IOnApplyWindowInsetsListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("setOnApplyWindowInsetsListener.(Landroid/view/View;Landroidx/core/view/OnApplyWindowInsetsListener;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(listener);
		}
	}

	[Register("setOnReceiveContentListener", "(Landroid/view/View;[Ljava/lang/String;Landroidx/core/view/OnReceiveContentListener;)V", "")]
	public unsafe static void SetOnReceiveContentListener(Android.Views.View? view, string[]? mimeTypes, IOnReceiveContentListener? listener)
	{
		nint num = JNIEnv.NewArray(mimeTypes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("setOnReceiveContentListener.(Landroid/view/View;[Ljava/lang/String;Landroidx/core/view/OnReceiveContentListener;)V", ptr);
		}
		finally
		{
			if (mimeTypes != null)
			{
				JNIEnv.CopyArray(num, mimeTypes);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(mimeTypes);
			GC.KeepAlive(listener);
		}
	}

	[Obsolete("deprecated")]
	[Register("setOverScrollMode", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetOverScrollMode(Android.Views.View? v, int overScrollMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(overScrollMode);
			_members.StaticMethods.InvokeVoidMethod("setOverScrollMode.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("setPaddingRelative", "(Landroid/view/View;IIII)V", "")]
	public unsafe static void SetPaddingRelative(Android.Views.View? view, int start, int top, int end, int bottom)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(top);
			ptr[3] = new JniArgumentValue(end);
			ptr[4] = new JniArgumentValue(bottom);
			_members.StaticMethods.InvokeVoidMethod("setPaddingRelative.(Landroid/view/View;IIII)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setPivotX", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetPivotX(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setPivotX.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setPivotY", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetPivotY(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setPivotY.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setPointerIcon", "(Landroid/view/View;Landroidx/core/view/PointerIconCompat;)V", "")]
	public unsafe static void SetPointerIcon(Android.Views.View? view, PointerIconCompat? pointerIcon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(pointerIcon?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setPointerIcon.(Landroid/view/View;Landroidx/core/view/PointerIconCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(pointerIcon);
		}
	}

	[Obsolete("deprecated")]
	[Register("setRotation", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetRotation(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setRotation.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setRotationX", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetRotationX(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setRotationX.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setRotationY", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetRotationY(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setRotationY.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setSaveFromParentEnabled", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetSaveFromParentEnabled(Android.Views.View? v, bool enabled)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setSaveFromParentEnabled.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Obsolete("deprecated")]
	[Register("setScaleX", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetScaleX(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setScaleX.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setScaleY", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetScaleY(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setScaleY.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setScreenReaderFocusable", "(Landroid/view/View;Z)V", "")]
	public unsafe static void SetScreenReaderFocusable(Android.Views.View? view, bool screenReaderFocusable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(screenReaderFocusable ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setScreenReaderFocusable.(Landroid/view/View;Z)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setScrollIndicators", "(Landroid/view/View;I)V", "")]
	public unsafe static void SetScrollIndicators(Android.Views.View? view, int indicators)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(indicators);
			_members.StaticMethods.InvokeVoidMethod("setScrollIndicators.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setScrollIndicators", "(Landroid/view/View;II)V", "")]
	public unsafe static void SetScrollIndicators(Android.Views.View? view, int indicators, int mask)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(indicators);
			ptr[2] = new JniArgumentValue(mask);
			_members.StaticMethods.InvokeVoidMethod("setScrollIndicators.(Landroid/view/View;II)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setStateDescription", "(Landroid/view/View;Ljava/lang/CharSequence;)V", "")]
	public unsafe static void SetStateDescription(Android.Views.View? view, ICharSequence? stateDescription)
	{
		nint num = CharSequence.ToLocalJniHandle(stateDescription);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setStateDescription.(Landroid/view/View;Ljava/lang/CharSequence;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(stateDescription);
		}
	}

	public static void SetStateDescription(Android.Views.View? view, string? stateDescription)
	{
		Java.Lang.String obj = ((stateDescription == null) ? null : new Java.Lang.String(stateDescription));
		SetStateDescription(view, obj);
		obj?.Dispose();
	}

	[Register("setSystemGestureExclusionRects", "(Landroid/view/View;Ljava/util/List;)V", "")]
	public unsafe static void SetSystemGestureExclusionRects(Android.Views.View? view, IList<Rect>? rects)
	{
		nint num = JavaList<Rect>.ToLocalJniHandle(rects);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setSystemGestureExclusionRects.(Landroid/view/View;Ljava/util/List;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(rects);
		}
	}

	[Register("setTooltipText", "(Landroid/view/View;Ljava/lang/CharSequence;)V", "")]
	public unsafe static void SetTooltipText(Android.Views.View? view, ICharSequence? tooltipText)
	{
		nint num = CharSequence.ToLocalJniHandle(tooltipText);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setTooltipText.(Landroid/view/View;Ljava/lang/CharSequence;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(tooltipText);
		}
	}

	public static void SetTooltipText(Android.Views.View? view, string? tooltipText)
	{
		Java.Lang.String obj = ((tooltipText == null) ? null : new Java.Lang.String(tooltipText));
		SetTooltipText(view, obj);
		obj?.Dispose();
	}

	[Register("setTransitionName", "(Landroid/view/View;Ljava/lang/String;)V", "")]
	public unsafe static void SetTransitionName(Android.Views.View? view, string? transitionName)
	{
		nint num = JNIEnv.NewString(transitionName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setTransitionName.(Landroid/view/View;Ljava/lang/String;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setTranslationX", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetTranslationX(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setTranslationX.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setTranslationY", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetTranslationY(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setTranslationY.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setTranslationZ", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetTranslationZ(Android.Views.View? view, float translationZ)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(translationZ);
			_members.StaticMethods.InvokeVoidMethod("setTranslationZ.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setWindowInsetsAnimationCallback", "(Landroid/view/View;Landroidx/core/view/WindowInsetsAnimationCompat$Callback;)V", "")]
	public unsafe static void SetWindowInsetsAnimationCallback(Android.Views.View? view, WindowInsetsAnimationCompat.Callback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("setWindowInsetsAnimationCallback.(Landroid/view/View;Landroidx/core/view/WindowInsetsAnimationCompat$Callback;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(callback);
		}
	}

	[Obsolete("deprecated")]
	[Register("setX", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetX(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setX.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Obsolete("deprecated")]
	[Register("setY", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetY(Android.Views.View? view, float value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setY.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setZ", "(Landroid/view/View;F)V", "")]
	public unsafe static void SetZ(Android.Views.View? view, float z)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(z);
			_members.StaticMethods.InvokeVoidMethod("setZ.(Landroid/view/View;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("startDragAndDrop", "(Landroid/view/View;Landroid/content/ClipData;Landroid/view/View$DragShadowBuilder;Ljava/lang/Object;I)Z", "")]
	public unsafe static bool StartDragAndDrop(Android.Views.View? v, ClipData? data, Android.Views.View.DragShadowBuilder? shadowBuilder, Java.Lang.Object? localState, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(shadowBuilder?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(localState?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(flags);
			return _members.StaticMethods.InvokeBooleanMethod("startDragAndDrop.(Landroid/view/View;Landroid/content/ClipData;Landroid/view/View$DragShadowBuilder;Ljava/lang/Object;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(data);
			GC.KeepAlive(shadowBuilder);
			GC.KeepAlive(localState);
		}
	}

	[Register("startNestedScroll", "(Landroid/view/View;I)Z", "")]
	public unsafe static bool StartNestedScroll(Android.Views.View? view, int axes)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(axes);
			return _members.StaticMethods.InvokeBooleanMethod("startNestedScroll.(Landroid/view/View;I)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("startNestedScroll", "(Landroid/view/View;II)Z", "")]
	public unsafe static bool StartNestedScroll(Android.Views.View? view, int axes, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(axes);
			ptr[2] = new JniArgumentValue(type);
			return _members.StaticMethods.InvokeBooleanMethod("startNestedScroll.(Landroid/view/View;II)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("stopNestedScroll", "(Landroid/view/View;)V", "")]
	public unsafe static void StopNestedScroll(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("stopNestedScroll.(Landroid/view/View;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("stopNestedScroll", "(Landroid/view/View;I)V", "")]
	public unsafe static void StopNestedScroll(Android.Views.View? view, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type);
			_members.StaticMethods.InvokeVoidMethod("stopNestedScroll.(Landroid/view/View;I)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("transformMatrixToGlobal", "(Landroid/view/View;Landroid/graphics/Matrix;)V", "")]
	public unsafe static void TransformMatrixToGlobal(Android.Views.View? view, Matrix? matrix)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(matrix?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("transformMatrixToGlobal.(Landroid/view/View;Landroid/graphics/Matrix;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(matrix);
		}
	}

	[Register("updateDragShadow", "(Landroid/view/View;Landroid/view/View$DragShadowBuilder;)V", "")]
	public unsafe static void UpdateDragShadow(Android.Views.View? v, Android.Views.View.DragShadowBuilder? shadowBuilder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(shadowBuilder?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("updateDragShadow.(Landroid/view/View;Landroid/view/View$DragShadowBuilder;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(shadowBuilder);
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.CoordinatorLayout.Widget;

[Register("androidx/coordinatorlayout/widget/CoordinatorLayout", DoNotGenerateAcw = true)]
public class CoordinatorLayout : ViewGroup, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "V extends android.view.View" })]
	public abstract class Behavior : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", typeof(Behavior));

		private static Delegate? cb_blocksInteractionBelow_BlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View__Z;

		private static Delegate? cb_getInsetDodgeRect_GetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect__Z;

		private static Delegate? cb_getScrimColor_GetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View__I;

		private static Delegate? cb_getScrimOpacity_GetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View__F;

		private static Delegate? cb_layoutDependsOn_LayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View__Z;

		private static Delegate? cb_onApplyWindowInsets_OnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat__Landroidx_core_view_WindowInsetsCompat_;

		private static Delegate? cb_onAttachedToLayoutParams_OnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams__V;

		private static Delegate? cb_onDependentViewChanged_OnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View__Z;

		private static Delegate? cb_onDependentViewRemoved_OnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View__V;

		private static Delegate? cb_onDetachedFromLayoutParams_OnDetachedFromLayoutParams_V;

		private static Delegate? cb_onInterceptTouchEvent_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onLayoutChild_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I_Z;

		private static Delegate? cb_onMeasureChild_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII_Z;

		private static Delegate? cb_onNestedFling_OnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ_Z;

		private static Delegate? cb_onNestedPreFling_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF_Z;

		private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI_V;

		private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII_V;

		private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII_V;

		private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII_V;

		private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI_V;

		private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I_V;

		private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II_V;

		private static Delegate? cb_onRequestChildRectangleOnScreen_OnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z_Z;

		private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable__V;

		private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View__Landroid_os_Parcelable_;

		private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I_Z;

		private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II_Z;

		private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View__V;

		private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I_V;

		private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent__Z;

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

		protected Behavior(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Behavior()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe Behavior(Context? context, IAttributeSet? attrs)
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

		private static Delegate GetBlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_BlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_BlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.BlocksInteractionBelow(parent, child) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("blocksInteractionBelow", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Z", "GetBlocksInteractionBelow_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
		public unsafe virtual bool BlocksInteractionBelow(CoordinatorLayout? parent, Java.Lang.Object? child)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("blocksInteractionBelow.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_GetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_GetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_rect)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
				return behavior.GetInsetDodgeRect(parent, child, rect) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("getInsetDodgeRect", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;)Z", "GetGetInsetDodgeRect_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Handler")]
		public unsafe virtual bool GetInsetDodgeRect(CoordinatorLayout? parent, Java.Lang.Object? child, Rect? rect)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getInsetDodgeRect.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(rect);
			}
		}

		private static Delegate GetGetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLL_I(n_GetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.GetScrimColor(parent, child);
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

		[Register("getScrimColor", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)I", "GetGetScrimColor_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
		public unsafe virtual int GetScrimColor(CoordinatorLayout? parent, Java.Lang.Object? child)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getScrimColor.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
		{
			return new _JniMarshal_PPLL_F(n_GetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.GetScrimOpacity(parent, child);
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

		[Register("getScrimOpacity", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)F", "GetGetScrimOpacity_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
		public unsafe virtual float GetScrimOpacity(CoordinatorLayout? parent, Java.Lang.Object? child)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getScrimOpacity.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)F", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
			}
		}

		[Register("getTag", "(Landroid/view/View;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? GetTag(View? child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("getTag.(Landroid/view/View;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetLayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_LayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_LayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_dependency)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View dependency = Java.Lang.Object.GetObject<View>(native_dependency, JniHandleOwnership.DoNotTransfer);
				return behavior.LayoutDependsOn(parent, child, dependency) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("layoutDependsOn", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", "GetLayoutDependsOn_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual bool LayoutDependsOn(CoordinatorLayout? parent, Java.Lang.Object? child, View? dependency)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(dependency?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("layoutDependsOn.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(dependency);
			}
		}

		private static Delegate GetOnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_Handler()
		{
			return new global::_JniMarshal_PPLLL_L(n_OnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_insets)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				WindowInsetsCompat insets = Java.Lang.Object.GetObject<WindowInsetsCompat>(native_insets, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(behavior.OnApplyWindowInsets(coordinatorLayout, child, insets));
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

		[Register("onApplyWindowInsets", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", "GetOnApplyWindowInsets_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroidx_core_view_WindowInsetsCompat_Handler")]
		public unsafe virtual WindowInsetsCompat? OnApplyWindowInsets(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, WindowInsetsCompat? insets)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("onApplyWindowInsets.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroidx/core/view/WindowInsetsCompat;)Landroidx/core/view/WindowInsetsCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(insets);
			}
		}

		private static Delegate GetOnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_(nint jnienv, nint native__this, nint native__params)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
				behavior.OnAttachedToLayoutParams(layoutParams);
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

		[Register("onAttachedToLayoutParams", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", "GetOnAttachedToLayoutParams_Landroidx_coordinatorlayout_widget_CoordinatorLayout_LayoutParams_Handler")]
		public unsafe virtual void OnAttachedToLayoutParams(LayoutParams? @params)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToLayoutParams.(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@params);
			}
		}

		private static Delegate GetOnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_OnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_dependency)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View dependency = Java.Lang.Object.GetObject<View>(native_dependency, JniHandleOwnership.DoNotTransfer);
				return behavior.OnDependentViewChanged(parent, child, dependency) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onDependentViewChanged", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", "GetOnDependentViewChanged_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual bool OnDependentViewChanged(CoordinatorLayout? parent, Java.Lang.Object? child, View? dependency)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(dependency?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onDependentViewChanged.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(dependency);
			}
		}

		private static Delegate GetOnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_dependency)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View dependency = Java.Lang.Object.GetObject<View>(native_dependency, JniHandleOwnership.DoNotTransfer);
				behavior.OnDependentViewRemoved(parent, child, dependency);
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

		[Register("onDependentViewRemoved", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", "GetOnDependentViewRemoved_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual void OnDependentViewRemoved(CoordinatorLayout? parent, Java.Lang.Object? child, View? dependency)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(dependency?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDependentViewRemoved.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(dependency);
			}
		}

		private static Delegate GetOnDetachedFromLayoutParamsHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnDetachedFromLayoutParams);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDetachedFromLayoutParams(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromLayoutParams();
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

		[Register("onDetachedFromLayoutParams", "()V", "GetOnDetachedFromLayoutParamsHandler")]
		public unsafe virtual void OnDetachedFromLayoutParams()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromLayoutParams.()V", this, null);
		}

		private static Delegate GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_ev)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
				return behavior.OnInterceptTouchEvent(parent, child, ev) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onInterceptTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnInterceptTouchEvent(CoordinatorLayout? parent, Java.Lang.Object? child, MotionEvent? ev)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(ev);
			}
		}

		private static Delegate GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler()
		{
			return new global::_JniMarshal_PPLLI_B(n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_I(nint jnienv, nint native__this, nint native_parent, nint native_child, int layoutDirection)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.OnLayoutChild(parent, child, layoutDirection) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onLayoutChild", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", "GetOnLayoutChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IHandler")]
		public unsafe virtual bool OnLayoutChild(CoordinatorLayout? parent, Java.Lang.Object? child, int layoutDirection)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(layoutDirection);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onLayoutChild.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;I)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetOnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIIIHandler()
		{
			return new _JniMarshal_PPLLIIII_B(n_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_parent, nint native_child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return behavior.OnMeasureChild(parent, child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onMeasureChild", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;IIII)Z", "GetOnMeasureChild_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_IIIIHandler")]
		public unsafe virtual bool OnMeasureChild(CoordinatorLayout? parent, Java.Lang.Object? child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(parentWidthMeasureSpec);
				ptr[3] = new JniArgumentValue(widthUsed);
				ptr[4] = new JniArgumentValue(parentHeightMeasureSpec);
				ptr[5] = new JniArgumentValue(heightUsed);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onMeasureChild.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;IIII)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetOnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZHandler()
		{
			return new _JniMarshal_PPLLLFFB_B(n_OnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZ(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, float velocityX, float velocityY, sbyte native_consumed)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				bool consumed = native_consumed != 0;
				return behavior.OnNestedFling(coordinatorLayout, child, target, velocityX, velocityY, consumed) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onNestedFling", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FFZ)Z", "GetOnNestedFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFZHandler")]
		public unsafe virtual bool OnNestedFling(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, float velocityX, float velocityY, bool consumed)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(velocityX);
				ptr[4] = new JniArgumentValue(velocityY);
				ptr[5] = new JniArgumentValue(consumed ? ((sbyte)1) : ((sbyte)0));
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedFling.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FFZ)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFHandler()
		{
			return new _JniMarshal_PPLLLFF_B(n_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FF(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, float velocityX, float velocityY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				return behavior.OnNestedPreFling(coordinatorLayout, child, target, velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onNestedPreFling", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FF)Z", "GetOnNestedPreFling_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_FFHandler")]
		public unsafe virtual bool OnNestedPreFling(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, float velocityX, float velocityY)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(velocityX);
				ptr[4] = new JniArgumentValue(velocityY);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onNestedPreFling.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;FF)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		[Obsolete]
		private static Delegate GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIHandler()
		{
			return new _JniMarshal_PPLLLIIL_V(n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayI(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int dx, int dy, nint native_consumed)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
				behavior.OnNestedPreScroll(coordinatorLayout, child, target, dx, dy, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_consumed);
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

		[Obsolete("deprecated")]
		[Register("onNestedPreScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[I)V", "GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIHandler")]
		public unsafe virtual void OnNestedPreScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, int dx, int dy, int[]? consumed)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			nint num2 = JNIEnv.NewArray(consumed);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(dx);
				ptr[4] = new JniArgumentValue(dy);
				ptr[5] = new JniArgumentValue(num2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				if (consumed != null)
				{
					JNIEnv.CopyArray(num2, consumed);
					JNIEnv.DeleteLocalRef(num2);
				}
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
				GC.KeepAlive(consumed);
			}
		}

		private static Delegate GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIIHandler()
		{
			return new _JniMarshal_PPLLLIILI_V(n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayII(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int dx, int dy, nint native_consumed, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
				behavior.OnNestedPreScroll(coordinatorLayout, child, target, dx, dy, array, type);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_consumed);
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

		[Register("onNestedPreScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[II)V", "GetOnNestedPreScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIarrayIIHandler")]
		public unsafe virtual void OnNestedPreScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, int dx, int dy, int[]? consumed, int type)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			nint num2 = JNIEnv.NewArray(consumed);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(dx);
				ptr[4] = new JniArgumentValue(dy);
				ptr[5] = new JniArgumentValue(num2);
				ptr[6] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;II[II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				if (consumed != null)
				{
					JNIEnv.CopyArray(num2, consumed);
					JNIEnv.DeleteLocalRef(num2);
				}
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
				GC.KeepAlive(consumed);
			}
		}

		[Obsolete]
		private static Delegate GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIHandler()
		{
			return new _JniMarshal_PPLLLIIII_V(n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed);
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
		[Register("onNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIII)V", "GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIHandler")]
		public unsafe virtual void OnNestedScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(dxConsumed);
				ptr[4] = new JniArgumentValue(dyConsumed);
				ptr[5] = new JniArgumentValue(dxUnconsumed);
				ptr[6] = new JniArgumentValue(dyUnconsumed);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIII)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		[Obsolete]
		private static Delegate GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIHandler()
		{
			return new _JniMarshal_PPLLLIIIII_V(n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIII(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
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
		[Register("onNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII)V", "GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIHandler")]
		public unsafe virtual void OnNestedScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(dxConsumed);
				ptr[4] = new JniArgumentValue(dyConsumed);
				ptr[5] = new JniArgumentValue(dxUnconsumed);
				ptr[6] = new JniArgumentValue(dyUnconsumed);
				ptr[7] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayIHandler()
		{
			return new _JniMarshal_PPLLLIIIIIL_V(n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayI(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, nint native_consumed)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
				behavior.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_consumed);
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

		[Register("onNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII[I)V", "GetOnNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IIIIIarrayIHandler")]
		public unsafe virtual void OnNestedScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[]? consumed)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			nint num2 = JNIEnv.NewArray(consumed);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(dxConsumed);
				ptr[4] = new JniArgumentValue(dyConsumed);
				ptr[5] = new JniArgumentValue(dxUnconsumed);
				ptr[6] = new JniArgumentValue(dyUnconsumed);
				ptr[7] = new JniArgumentValue(type);
				ptr[8] = new JniArgumentValue(num2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;IIIII[I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				if (consumed != null)
				{
					JNIEnv.CopyArray(num2, consumed);
					JNIEnv.DeleteLocalRef(num2);
				}
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
				GC.KeepAlive(consumed);
			}
		}

		[Obsolete]
		private static Delegate GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler()
		{
			return new _JniMarshal_PPLLLLI_V(n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_directTargetChild, nint native_target, int axes)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScrollAccepted(coordinatorLayout, child, directTargetChild, target, axes);
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
		[Register("onNestedScrollAccepted", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)V", "GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler")]
		public unsafe virtual void OnNestedScrollAccepted(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? directTargetChild, View? target, int axes)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(axes);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(directTargetChild);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler()
		{
			return new _JniMarshal_PPLLLLII_V(n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_directTargetChild, nint native_target, int axes, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnNestedScrollAccepted(coordinatorLayout, child, directTargetChild, target, axes, type);
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

		[Register("onNestedScrollAccepted", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)V", "GetOnNestedScrollAccepted_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler")]
		public unsafe virtual void OnNestedScrollAccepted(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? directTargetChild, View? target, int axes, int type)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(axes);
				ptr[5] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(directTargetChild);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_ZHandler()
		{
			return new _JniMarshal_PPLLLB_B(n_OnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_Z(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_rectangle, sbyte native_immediate)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				Rect rectangle = Java.Lang.Object.GetObject<Rect>(native_rectangle, JniHandleOwnership.DoNotTransfer);
				bool immediate = native_immediate != 0;
				return behavior.OnRequestChildRectangleOnScreen(coordinatorLayout, child, rectangle, immediate) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onRequestChildRectangleOnScreen", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;Z)Z", "GetOnRequestChildRectangleOnScreen_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_graphics_Rect_ZHandler")]
		public unsafe virtual bool OnRequestChildRectangleOnScreen(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, Rect? rectangle, bool immediate)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(rectangle?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(immediate ? ((sbyte)1) : ((sbyte)0));
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onRequestChildRectangleOnScreen.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/graphics/Rect;Z)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(rectangle);
			}
		}

		private static Delegate GetOnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
				behavior.OnRestoreInstanceState(parent, child, state);
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

		[Register("onRestoreInstanceState", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_os_Parcelable_Handler")]
		public unsafe virtual void OnRestoreInstanceState(CoordinatorLayout? parent, Java.Lang.Object? child, IParcelable? state)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/os/Parcelable;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(behavior.OnSaveInstanceState(parent, child));
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

		[Register("onSaveInstanceState", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Landroid/os/Parcelable;", "GetOnSaveInstanceState_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Handler")]
		public unsafe virtual IParcelable? OnSaveInstanceState(CoordinatorLayout? parent, Java.Lang.Object? child)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;)Landroid/os/Parcelable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
			}
		}

		[Obsolete]
		private static Delegate GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler()
		{
			return new _JniMarshal_PPLLLLI_B(n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_directTargetChild, nint native_target, int axes)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				return behavior.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, axes) ? ((sbyte)1) : ((sbyte)0);
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

		[Obsolete("deprecated")]
		[Register("onStartNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)Z", "GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IHandler")]
		public unsafe virtual bool OnStartNestedScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? directTargetChild, View? target, int axes)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(axes);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;I)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(directTargetChild);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler()
		{
			return new _JniMarshal_PPLLLLII_B(n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_directTargetChild, nint native_target, int axes, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View directTargetChild = Java.Lang.Object.GetObject<View>(native_directTargetChild, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				return behavior.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, axes, type) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onStartNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)Z", "GetOnStartNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Landroid_view_View_IIHandler")]
		public unsafe virtual bool OnStartNestedScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? directTargetChild, View? target, int axes, int type)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(directTargetChild?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(axes);
				ptr[5] = new JniArgumentValue(type);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;Landroid/view/View;II)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(directTargetChild);
				GC.KeepAlive(target);
			}
		}

		[Obsolete]
		private static Delegate GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnStopNestedScroll(coordinatorLayout, child, target);
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
		[Register("onStopNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", "GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual void OnStopNestedScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IHandler()
		{
			return new _JniMarshal_PPLLLI_V(n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_I(nint jnienv, nint native__this, nint native_coordinatorLayout, nint native_child, nint native_target, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(native_coordinatorLayout, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
				behavior.OnStopNestedScroll(coordinatorLayout, child, target, type);
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

		[Register("onStopNestedScroll", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;I)V", "GetOnStopNestedScroll_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_View_IHandler")]
		public unsafe virtual void OnStopNestedScroll(CoordinatorLayout? coordinatorLayout, Java.Lang.Object? child, View? target, int type)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(coordinatorLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(type);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(coordinatorLayout);
				GC.KeepAlive(child);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_ev)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Behavior? behavior = Java.Lang.Object.GetObject<Behavior>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				CoordinatorLayout parent = Java.Lang.Object.GetObject<CoordinatorLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object child = Java.Lang.Object.GetObject<Java.Lang.Object>(native_child, JniHandleOwnership.DoNotTransfer);
				MotionEvent ev = Java.Lang.Object.GetObject<MotionEvent>(native_ev, JniHandleOwnership.DoNotTransfer);
				return behavior.OnTouchEvent(parent, child, ev) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onTouchEvent", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnTouchEvent(CoordinatorLayout? parent, Java.Lang.Object? child, MotionEvent? ev)
		{
			nint num = JNIEnv.ToLocalJniHandle(child);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(ev?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroidx/coordinatorlayout/widget/CoordinatorLayout;Landroid/view/View;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(ev);
			}
		}

		[Register("setTag", "(Landroid/view/View;Ljava/lang/Object;)V", "")]
		public unsafe static void SetTag(View? child, Java.Lang.Object? tag)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setTag.(Landroid/view/View;Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(tag);
			}
		}
	}

	[Register("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", DoNotGenerateAcw = true)]
	internal class BehaviorInvoker : Behavior
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior", typeof(BehaviorInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public BehaviorInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams", DoNotGenerateAcw = true)]
	public new class LayoutParams : MarginLayoutParams
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams", typeof(LayoutParams));

		private static Delegate? cb_getAnchorId_GetAnchorId_I;

		private static Delegate? cb_setAnchorId_SetAnchorId_I_V;

		private static Delegate? cb_getBehavior_GetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_;

		private static Delegate? cb_setBehavior_SetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior__V;

		[Register("anchorGravity")]
		public int AnchorGravity
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("anchorGravity.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("anchorGravity.I", this, value);
			}
		}

		[Register("dodgeInsetEdges")]
		public int DodgeInsetEdges
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("dodgeInsetEdges.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("dodgeInsetEdges.I", this, value);
			}
		}

		[Register("gravity")]
		public int Gravity
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("gravity.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("gravity.I", this, value);
			}
		}

		[Register("insetEdge")]
		public int InsetEdge
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("insetEdge.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("insetEdge.I", this, value);
			}
		}

		[Register("keyline")]
		public int Keyline
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("keyline.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("keyline.I", this, value);
			}
		}

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

		public unsafe virtual int AnchorId
		{
			[Register("getAnchorId", "()I", "GetGetAnchorIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAnchorId.()I", this, null);
			}
			[Register("setAnchorId", "(I)V", "GetSetAnchorId_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAnchorId.(I)V", this, ptr);
			}
		}

		public unsafe virtual Behavior? Behavior
		{
			[Register("getBehavior", "()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", "GetGetBehaviorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Behavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBehavior.()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setBehavior", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;)V", "GetSetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setBehavior.(Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected LayoutParams(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
		public unsafe LayoutParams(ViewGroup.LayoutParams? p)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$MarginLayoutParams;)V", "")]
		public unsafe LayoutParams(MarginLayoutParams? p)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p);
			}
		}

		[Register(".ctor", "(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", "")]
		public unsafe LayoutParams(LayoutParams? p)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe LayoutParams(int width, int height)
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

		private static Delegate GetGetAnchorIdHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetAnchorId);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetAnchorId(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorId;
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

		private static Delegate GetSetAnchorId_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetAnchorId_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetAnchorId_I(nint jnienv, nint native__this, int id)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorId = id;
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

		private static Delegate GetGetBehaviorHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetBehavior);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetBehavior(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Behavior);
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

		private static Delegate GetSetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_(nint jnienv, nint native__this, nint native_behavior)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutParams? layoutParams = Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Behavior behavior = Java.Lang.Object.GetObject<Behavior>(native_behavior, JniHandleOwnership.DoNotTransfer);
				layoutParams.Behavior = behavior;
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/coordinatorlayout/widget/CoordinatorLayout", typeof(CoordinatorLayout));

	private static Delegate? cb_getStatusBarBackground_GetStatusBarBackground_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setStatusBarBackground_SetStatusBarBackground_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_dispatchDependentViewsChanged_DispatchDependentViewsChanged_Landroid_view_View__V;

	private static Delegate? cb_doViewsOverlap_DoViewsOverlap_Landroid_view_View_Landroid_view_View__Z;

	private static Delegate? cb_getDependencies_GetDependencies_Landroid_view_View__Ljava_util_List_;

	private static Delegate? cb_getDependents_GetDependents_Landroid_view_View__Ljava_util_List_;

	private static Delegate? cb_isPointInChildBounds_IsPointInChildBounds_Landroid_view_View_II_Z;

	private static Delegate? cb_onAttachedToWindow_OnAttachedToWindow_V;

	private static Delegate? cb_onDetachedFromWindow_OnDetachedFromWindow_V;

	private static Delegate? cb_onDraw_OnDraw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_onLayoutChild_OnLayoutChild_Landroid_view_View_I_V;

	private static Delegate? cb_onMeasureChild_OnMeasureChild_Landroid_view_View_IIII_V;

	private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroid_view_View_IIarrayII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIIIarrayI_V;

	private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II_V;

	private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II_Z;

	private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroid_view_View_I_V;

	private static Delegate? cb_setStatusBarBackgroundColor_SetStatusBarBackgroundColor_I_V;

	private static Delegate? cb_setStatusBarBackgroundResource_SetStatusBarBackgroundResource_I_V;

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

	public unsafe WindowInsetsCompat? LastWindowInsets
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getLastWindowInsets", "()Landroidx/core/view/WindowInsetsCompat;", "")]
		get
		{
			return Java.Lang.Object.GetObject<WindowInsetsCompat>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLastWindowInsets.()Landroidx/core/view/WindowInsetsCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Drawable? StatusBarBackground
	{
		[Register("getStatusBarBackground", "()Landroid/graphics/drawable/Drawable;", "GetGetStatusBarBackgroundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStatusBarBackground.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStatusBarBackground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetStatusBarBackground_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public virtual void OnNestedScrollAccepted(View child, View target, int nestedScrollAxes, int type)
	{
		OnNestedScrollAccepted(child, target, (ScrollAxis)nestedScrollAxes, type);
	}

	public virtual bool OnStartNestedScroll(View child, View target, int axes, int type)
	{
		return OnStartNestedScroll(child, target, (ScrollAxis)axes, type);
	}

	protected CoordinatorLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe CoordinatorLayout(Context? context)
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
	public unsafe CoordinatorLayout(Context? context, IAttributeSet? attrs)
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
	public unsafe CoordinatorLayout(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetStatusBarBackgroundHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStatusBarBackground);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStatusBarBackground(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StatusBarBackground);
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
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable statusBarBackground = Java.Lang.Object.GetObject<Drawable>(native_bg, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.StatusBarBackground = statusBarBackground;
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

	private static Delegate GetDispatchDependentViewsChanged_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_DispatchDependentViewsChanged_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchDependentViewsChanged_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.DispatchDependentViewsChanged(view);
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

	[Register("dispatchDependentViewsChanged", "(Landroid/view/View;)V", "GetDispatchDependentViewsChanged_Landroid_view_View_Handler")]
	public unsafe virtual void DispatchDependentViewsChanged(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchDependentViewsChanged.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetDoViewsOverlap_Landroid_view_View_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_DoViewsOverlap_Landroid_view_View_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DoViewsOverlap_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_first, nint native_second)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View first = Java.Lang.Object.GetObject<View>(native_first, JniHandleOwnership.DoNotTransfer);
			View second = Java.Lang.Object.GetObject<View>(native_second, JniHandleOwnership.DoNotTransfer);
			return coordinatorLayout.DoViewsOverlap(first, second) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("doViewsOverlap", "(Landroid/view/View;Landroid/view/View;)Z", "GetDoViewsOverlap_Landroid_view_View_Landroid_view_View_Handler")]
	public unsafe virtual bool DoViewsOverlap(View? first, View? second)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(first?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(second?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("doViewsOverlap.(Landroid/view/View;Landroid/view/View;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(first);
			GC.KeepAlive(second);
		}
	}

	private static Delegate GetGetDependencies_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetDependencies_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDependencies_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return JavaList<View>.ToLocalJniHandle(coordinatorLayout.GetDependencies(child));
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

	[Register("getDependencies", "(Landroid/view/View;)Ljava/util/List;", "GetGetDependencies_Landroid_view_View_Handler")]
	public unsafe virtual IList<View>? GetDependencies(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return JavaList<View>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDependencies.(Landroid/view/View;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetDependents_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetDependents_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDependents_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return JavaList<View>.ToLocalJniHandle(coordinatorLayout.GetDependents(child));
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

	[Register("getDependents", "(Landroid/view/View;)Ljava/util/List;", "GetGetDependents_Landroid_view_View_Handler")]
	public unsafe virtual IList<View>? GetDependents(View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return JavaList<View>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDependents.(Landroid/view/View;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetIsPointInChildBounds_Landroid_view_View_IIHandler()
	{
		return new global::_JniMarshal_PPLII_B(n_IsPointInChildBounds_Landroid_view_View_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsPointInChildBounds_Landroid_view_View_II(nint jnienv, nint native__this, nint native_child, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return coordinatorLayout.IsPointInChildBounds(child, x, y) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isPointInChildBounds", "(Landroid/view/View;II)Z", "GetIsPointInChildBounds_Landroid_view_View_IIHandler")]
	public unsafe virtual bool IsPointInChildBounds(View? child, int x, int y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(x);
			ptr[2] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPointInChildBounds.(Landroid/view/View;II)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnAttachedToWindowHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnAttachedToWindow);
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
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
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
	public new unsafe virtual void OnAttachedToWindow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.()V", this, null);
	}

	private static Delegate GetOnDetachedFromWindowHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnDetachedFromWindow);
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
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromWindow();
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
	public new unsafe virtual void OnDetachedFromWindow()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.()V", this, null);
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
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnDraw(c);
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
	public new unsafe virtual void OnDraw(Canvas? c)
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
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			coordinatorLayout.OnLayout(changed, l, t, r, b);
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

	private static Delegate GetOnLayoutChild_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_OnLayoutChild_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayoutChild_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, int layoutDirection)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnLayoutChild(child, layoutDirection);
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

	[Register("onLayoutChild", "(Landroid/view/View;I)V", "GetOnLayoutChild_Landroid_view_View_IHandler")]
	public unsafe virtual void OnLayoutChild(View? child, int layoutDirection)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(layoutDirection);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLayoutChild.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnMeasureChild_Landroid_view_View_IIIIHandler()
	{
		return new global::_JniMarshal_PPLIIII_V(n_OnMeasureChild_Landroid_view_View_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnMeasureChild_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnMeasureChild(child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed);
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

	[Register("onMeasureChild", "(Landroid/view/View;IIII)V", "GetOnMeasureChild_Landroid_view_View_IIIIHandler")]
	public unsafe virtual void OnMeasureChild(View? child, int parentWidthMeasureSpec, int widthUsed, int parentHeightMeasureSpec, int heightUsed)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(parentWidthMeasureSpec);
			ptr[2] = new JniArgumentValue(widthUsed);
			ptr[3] = new JniArgumentValue(parentHeightMeasureSpec);
			ptr[4] = new JniArgumentValue(heightUsed);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasureChild.(Landroid/view/View;IIII)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnNestedPreScroll_Landroid_view_View_IIarrayIIHandler()
	{
		return new global::_JniMarshal_PPLIILI_V(n_OnNestedPreScroll_Landroid_view_View_IIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedPreScroll_Landroid_view_View_IIarrayII(nint jnienv, nint native__this, nint native_target, int dx, int dy, nint native_consumed, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			coordinatorLayout.OnNestedPreScroll(target, dx, dy, array, type);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
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

	[Register("onNestedPreScroll", "(Landroid/view/View;II[II)V", "GetOnNestedPreScroll_Landroid_view_View_IIarrayIIHandler")]
	public unsafe virtual void OnNestedPreScroll(View? target, int dx, int dy, int[]? consumed, int type)
	{
		nint num = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dx);
			ptr[2] = new JniArgumentValue(dy);
			ptr[3] = new JniArgumentValue(num);
			ptr[4] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedPreScroll.(Landroid/view/View;II[II)V", this, ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(target);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetOnNestedScroll_Landroid_view_View_IIIIIHandler()
	{
		return new global::_JniMarshal_PPLIIIII_V(n_OnNestedScroll_Landroid_view_View_IIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScroll_Landroid_view_View_IIIII(nint jnienv, nint native__this, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
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

	[Register("onNestedScroll", "(Landroid/view/View;IIIII)V", "GetOnNestedScroll_Landroid_view_View_IIIIIHandler")]
	public unsafe virtual void OnNestedScroll(View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			ptr[5] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroid/view/View;IIIII)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnNestedScroll_Landroid_view_View_IIIIIarrayIHandler()
	{
		return new global::_JniMarshal_PPLIIIIIL_V(n_OnNestedScroll_Landroid_view_View_IIIIIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScroll_Landroid_view_View_IIIIIarrayI(nint jnienv, nint native__this, nint native_target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, nint native_consumed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			coordinatorLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
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

	[Register("onNestedScroll", "(Landroid/view/View;IIIII[I)V", "GetOnNestedScroll_Landroid_view_View_IIIIIarrayIHandler")]
	public unsafe virtual void OnNestedScroll(View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[]? consumed)
	{
		nint num = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dxConsumed);
			ptr[2] = new JniArgumentValue(dyConsumed);
			ptr[3] = new JniArgumentValue(dxUnconsumed);
			ptr[4] = new JniArgumentValue(dyUnconsumed);
			ptr[5] = new JniArgumentValue(type);
			ptr[6] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScroll.(Landroid/view/View;IIIII[I)V", this, ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(target);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IIHandler()
	{
		return new global::_JniMarshal_PPLLII_V(n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_child, nint native_target, int native_axes, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnNestedScrollAccepted(child, target, (ScrollAxis)native_axes, type);
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

	[Register("onNestedScrollAccepted", "(Landroid/view/View;Landroid/view/View;II)V", "GetOnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_IIHandler")]
	public unsafe virtual void OnNestedScrollAccepted(View? child, View? target, ScrollAxis axes, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)axes);
			ptr[3] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNestedScrollAccepted.(Landroid/view/View;Landroid/view/View;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IIHandler()
	{
		return new global::_JniMarshal_PPLLII_B(n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_child, nint native_target, int native_axes, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return coordinatorLayout.OnStartNestedScroll(child, target, (ScrollAxis)native_axes, type) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onStartNestedScroll", "(Landroid/view/View;Landroid/view/View;II)Z", "GetOnStartNestedScroll_Landroid_view_View_Landroid_view_View_IIHandler")]
	public unsafe virtual bool OnStartNestedScroll(View? child, View? target, ScrollAxis axes, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)axes);
			ptr[3] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStartNestedScroll.(Landroid/view/View;Landroid/view/View;II)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetOnStopNestedScroll_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_OnStopNestedScroll_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStopNestedScroll_Landroid_view_View_I(nint jnienv, nint native__this, nint native_target, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CoordinatorLayout? coordinatorLayout = Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			coordinatorLayout.OnStopNestedScroll(target, type);
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

	[Register("onStopNestedScroll", "(Landroid/view/View;I)V", "GetOnStopNestedScroll_Landroid_view_View_IHandler")]
	public unsafe virtual void OnStopNestedScroll(View? target, int type)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(type);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStopNestedScroll.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
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
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackgroundColor(color);
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

	private static Delegate GetSetStatusBarBackgroundResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStatusBarBackgroundResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarBackgroundResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CoordinatorLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarBackgroundResource(resId);
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

	[Register("setStatusBarBackgroundResource", "(I)V", "GetSetStatusBarBackgroundResource_IHandler")]
	public unsafe virtual void SetStatusBarBackgroundResource(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarBackgroundResource.(I)V", this, ptr);
	}
}

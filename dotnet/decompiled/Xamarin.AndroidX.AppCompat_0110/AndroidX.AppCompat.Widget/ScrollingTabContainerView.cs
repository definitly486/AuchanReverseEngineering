using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Animation;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Widget;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/appcompat/widget/ScrollingTabContainerView", DoNotGenerateAcw = true)]
public class ScrollingTabContainerView : HorizontalScrollView, AdapterView.IOnItemSelectedListener, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/appcompat/widget/ScrollingTabContainerView$VisibilityAnimListener", DoNotGenerateAcw = true)]
	protected internal class VisibilityAnimListener : AnimatorListenerAdapter
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/widget/ScrollingTabContainerView$VisibilityAnimListener", typeof(VisibilityAnimListener));

		private static Delegate? cb_withFinalVisibility_WithFinalVisibility_Landroid_view_ViewPropertyAnimator_I_Landroid_animation_AnimatorListenerAdapter_;

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

		protected VisibilityAnimListener(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/appcompat/widget/ScrollingTabContainerView;)V", "")]
		protected unsafe VisibilityAnimListener(ScrollingTabContainerView? __self)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";)V";
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
			}
			finally
			{
				GC.KeepAlive(__self);
			}
		}

		private static Delegate GetWithFinalVisibility_Landroid_view_ViewPropertyAnimator_IHandler()
		{
			return new global::_JniMarshal_PPLI_L(n_WithFinalVisibility_Landroid_view_ViewPropertyAnimator_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_WithFinalVisibility_Landroid_view_ViewPropertyAnimator_I(nint jnienv, nint native__this, nint native_animation, int visibility)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				VisibilityAnimListener? visibilityAnimListener = Java.Lang.Object.GetObject<VisibilityAnimListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewPropertyAnimator animation = Java.Lang.Object.GetObject<ViewPropertyAnimator>(native_animation, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(visibilityAnimListener.WithFinalVisibility(animation, visibility));
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

		[Register("withFinalVisibility", "(Landroid/view/ViewPropertyAnimator;I)Landroid/animation/AnimatorListenerAdapter;", "GetWithFinalVisibility_Landroid_view_ViewPropertyAnimator_IHandler")]
		public unsafe virtual AnimatorListenerAdapter? WithFinalVisibility(ViewPropertyAnimator? animation, int visibility)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(visibility);
				return Java.Lang.Object.GetObject<AnimatorListenerAdapter>(_members.InstanceMethods.InvokeVirtualObjectMethod("withFinalVisibility.(Landroid/view/ViewPropertyAnimator;I)Landroid/animation/AnimatorListenerAdapter;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(animation);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/widget/ScrollingTabContainerView", typeof(ScrollingTabContainerView));

	private static Delegate? cb_addTab_AddTab_Landroidx_appcompat_app_ActionBar_Tab_Z_V;

	private static Delegate? cb_addTab_AddTab_Landroidx_appcompat_app_ActionBar_Tab_IZ_V;

	private static Delegate? cb_animateToTab_AnimateToTab_I_V;

	private static Delegate? cb_animateToVisibility_AnimateToVisibility_I_V;

	private static Delegate? cb_onAttachedToWindow_OnAttachedToWindow_V;

	private static Delegate? cb_onDetachedFromWindow_OnDetachedFromWindow_V;

	private static Delegate? cb_onItemSelected_OnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJ_V;

	private static Delegate? cb_onMeasure_OnMeasure_II_V;

	private static Delegate? cb_onNothingSelected_OnNothingSelected_Landroid_widget_AdapterView__V;

	private static Delegate? cb_removeAllTabs_RemoveAllTabs_V;

	private static Delegate? cb_removeTabAt_RemoveTabAt_I_V;

	private static Delegate? cb_setAllowCollapse_SetAllowCollapse_Z_V;

	private static Delegate? cb_setContentHeight_SetContentHeight_I_V;

	private static Delegate? cb_setTabSelected_SetTabSelected_I_V;

	private static Delegate? cb_updateTab_UpdateTab_I_V;

	[Register("mVisAnimListener")]
	protected VisibilityAnimListener? MVisAnimListener
	{
		get
		{
			return Java.Lang.Object.GetObject<VisibilityAnimListener>(_members.InstanceFields.GetObjectValue("mVisAnimListener.Landroidx/appcompat/widget/ScrollingTabContainerView$VisibilityAnimListener;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mVisAnimListener.Landroidx/appcompat/widget/ScrollingTabContainerView$VisibilityAnimListener;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mVisibilityAnim")]
	protected ViewPropertyAnimator? MVisibilityAnim
	{
		get
		{
			return Java.Lang.Object.GetObject<ViewPropertyAnimator>(_members.InstanceFields.GetObjectValue("mVisibilityAnim.Landroid/view/ViewPropertyAnimator;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mVisibilityAnim.Landroid/view/ViewPropertyAnimator;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
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

	protected ScrollingTabContainerView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ScrollingTabContainerView(Context context)
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

	private static Delegate GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_Z(nint jnienv, nint native__this, nint native_tab, sbyte native_setSelected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ScrollingTabContainerView? scrollingTabContainerView = Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionBar.Tab tab = Java.Lang.Object.GetObject<ActionBar.Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			bool setSelected = native_setSelected != 0;
			scrollingTabContainerView.AddTab(tab, setSelected);
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

	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;Z)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_ZHandler")]
	public unsafe virtual void AddTab(ActionBar.Tab? tab, bool setSelected)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(setSelected ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTab.(Landroidx/appcompat/app/ActionBar$Tab;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IZHandler()
	{
		return new global::_JniMarshal_PPLIB_V(n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Landroidx_appcompat_app_ActionBar_Tab_IZ(nint jnienv, nint native__this, nint native_tab, int position, sbyte native_setSelected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ScrollingTabContainerView? scrollingTabContainerView = Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionBar.Tab tab = Java.Lang.Object.GetObject<ActionBar.Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			bool setSelected = native_setSelected != 0;
			scrollingTabContainerView.AddTab(tab, position, setSelected);
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

	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;IZ)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IZHandler")]
	public unsafe virtual void AddTab(ActionBar.Tab? tab, int position, bool setSelected)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(setSelected ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTab.(Landroidx/appcompat/app/ActionBar$Tab;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetAnimateToTab_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_AnimateToTab_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AnimateToTab_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateToTab(position);
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

	[Register("animateToTab", "(I)V", "GetAnimateToTab_IHandler")]
	public unsafe virtual void AnimateToTab(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("animateToTab.(I)V", this, ptr);
	}

	private static Delegate GetAnimateToVisibility_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_AnimateToVisibility_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AnimateToVisibility_I(nint jnienv, nint native__this, int visibility)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateToVisibility(visibility);
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

	[Register("animateToVisibility", "(I)V", "GetAnimateToVisibility_IHandler")]
	public unsafe virtual void AnimateToVisibility(int visibility)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(visibility);
		_members.InstanceMethods.InvokeVirtualVoidMethod("animateToVisibility.(I)V", this, ptr);
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
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
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
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDetachedFromWindow();
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

	private static Delegate GetOnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJHandler()
	{
		return new global::_JniMarshal_PPLLIJ_V(n_OnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJ(nint jnienv, nint native__this, nint native_adapterView, nint native_view, int position, long id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ScrollingTabContainerView? scrollingTabContainerView = Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AdapterView adapterView = Java.Lang.Object.GetObject<AdapterView>(native_adapterView, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			scrollingTabContainerView.OnItemSelected(adapterView, view, position, id);
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

	[Register("onItemSelected", "(Landroid/widget/AdapterView;Landroid/view/View;IJ)V", "GetOnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJHandler")]
	public unsafe virtual void OnItemSelected(AdapterView? adapterView, Android.Views.View? view, int position, long id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(adapterView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(position);
			ptr[3] = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemSelected.(Landroid/widget/AdapterView;Landroid/view/View;IJ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapterView);
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetOnMeasure_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_OnMeasure_II);
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
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMeasure(widthMeasureSpec, heightMeasureSpec);
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
	public new unsafe virtual void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(widthMeasureSpec);
		ptr[1] = new JniArgumentValue(heightMeasureSpec);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasure.(II)V", this, ptr);
	}

	private static Delegate GetOnNothingSelected_Landroid_widget_AdapterView_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnNothingSelected_Landroid_widget_AdapterView_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNothingSelected_Landroid_widget_AdapterView_(nint jnienv, nint native__this, nint native_adapterView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ScrollingTabContainerView? scrollingTabContainerView = Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AdapterView adapterView = Java.Lang.Object.GetObject<AdapterView>(native_adapterView, JniHandleOwnership.DoNotTransfer);
			scrollingTabContainerView.OnNothingSelected(adapterView);
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

	[Register("onNothingSelected", "(Landroid/widget/AdapterView;)V", "GetOnNothingSelected_Landroid_widget_AdapterView_Handler")]
	public unsafe virtual void OnNothingSelected(AdapterView? adapterView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(adapterView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onNothingSelected.(Landroid/widget/AdapterView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapterView);
		}
	}

	private static Delegate GetRemoveAllTabsHandler()
	{
		return new global::_JniMarshal_PP_V(n_RemoveAllTabs);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveAllTabs(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllTabs();
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

	[Register("removeAllTabs", "()V", "GetRemoveAllTabsHandler")]
	public unsafe virtual void RemoveAllTabs()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllTabs.()V", this, null);
	}

	private static Delegate GetRemoveTabAt_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveTabAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveTabAt_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveTabAt(position);
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

	[Register("removeTabAt", "(I)V", "GetRemoveTabAt_IHandler")]
	public unsafe virtual void RemoveTabAt(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeTabAt.(I)V", this, ptr);
	}

	private static Delegate GetSetAllowCollapse_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAllowCollapse_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAllowCollapse_Z(nint jnienv, nint native__this, sbyte native_allowCollapse)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ScrollingTabContainerView? scrollingTabContainerView = Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool allowCollapse = native_allowCollapse != 0;
			scrollingTabContainerView.SetAllowCollapse(allowCollapse);
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

	[Register("setAllowCollapse", "(Z)V", "GetSetAllowCollapse_ZHandler")]
	public unsafe virtual void SetAllowCollapse(bool allowCollapse)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(allowCollapse ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAllowCollapse.(Z)V", this, ptr);
	}

	private static Delegate GetSetContentHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetContentHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentHeight_I(nint jnienv, nint native__this, int contentHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentHeight(contentHeight);
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

	[Register("setContentHeight", "(I)V", "GetSetContentHeight_IHandler")]
	public unsafe virtual void SetContentHeight(int contentHeight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(contentHeight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentHeight.(I)V", this, ptr);
	}

	private static Delegate GetSetTabSelected_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTabSelected_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabSelected_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTabSelected(position);
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

	[Register("setTabSelected", "(I)V", "GetSetTabSelected_IHandler")]
	public unsafe virtual void SetTabSelected(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTabSelected.(I)V", this, ptr);
	}

	private static Delegate GetUpdateTab_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_UpdateTab_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateTab_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ScrollingTabContainerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateTab(position);
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

	[Register("updateTab", "(I)V", "GetUpdateTab_IHandler")]
	public unsafe virtual void UpdateTab(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateTab.(I)V", this, ptr);
	}
}

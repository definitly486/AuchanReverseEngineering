using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Widget;

[Register("androidx/core/widget/NestedScrollView", DoNotGenerateAcw = true)]
public class NestedScrollView : FrameLayout, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/core/widget/NestedScrollView$OnScrollChangeListener", "", "AndroidX.Core.Widget.NestedScrollView/IOnScrollChangeListenerInvoker")]
	public new interface IOnScrollChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onScrollChange", "(Landroidx/core/widget/NestedScrollView;IIII)V", "GetOnScrollChange_Landroidx_core_widget_NestedScrollView_IIIIHandler:AndroidX.Core.Widget.NestedScrollView/IOnScrollChangeListenerInvoker, Xamarin.AndroidX.Core")]
		void OnScrollChange(NestedScrollView? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY);
	}

	[Register("androidx/core/widget/NestedScrollView$OnScrollChangeListener", DoNotGenerateAcw = true)]
	internal class IOnScrollChangeListenerInvoker : Java.Lang.Object, IOnScrollChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_widget_NestedScrollView_OnScrollChangeListener = new XAPeerMembers("androidx/core/widget/NestedScrollView$OnScrollChangeListener", typeof(IOnScrollChangeListenerInvoker));

		private static Delegate? cb_onScrollChange_OnScrollChange_Landroidx_core_widget_NestedScrollView_IIII_V;

		private static nint java_class_ref => _members_androidx_core_widget_NestedScrollView_OnScrollChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_widget_NestedScrollView_OnScrollChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_widget_NestedScrollView_OnScrollChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_widget_NestedScrollView_OnScrollChangeListener.ManagedPeerType;

		public IOnScrollChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnScrollChange_Landroidx_core_widget_NestedScrollView_IIII(nint jnienv, nint native__this, nint native_v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnScrollChangeListener? onScrollChangeListener = Java.Lang.Object.GetObject<IOnScrollChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				NestedScrollView v = Java.Lang.Object.GetObject<NestedScrollView>(native_v, JniHandleOwnership.DoNotTransfer);
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

		public unsafe void OnScrollChange(NestedScrollView? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(scrollX);
				ptr[2] = new JniArgumentValue(scrollY);
				ptr[3] = new JniArgumentValue(oldScrollX);
				ptr[4] = new JniArgumentValue(oldScrollY);
				_members_androidx_core_widget_NestedScrollView_OnScrollChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onScrollChange.(Landroidx/core/widget/NestedScrollView;IIII)V", this, ptr);
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
		private static void n_OnScrollChange_Landroidx_core_widget_NestedScrollView_IIII_mm_wrapper(nint jnienv, nint native__this, nint native_v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnScrollChange_Landroidx_core_widget_NestedScrollView_IIII(jnienv, native__this, native_v, scrollX, scrollY, oldScrollX, oldScrollY);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public new class ScrollChangeEventArgs : EventArgs
	{
		private NestedScrollView? v;

		private int scrollX;

		private int scrollY;

		private int oldScrollX;

		private int oldScrollY;

		public int ScrollY => scrollY;

		public int OldScrollY => oldScrollY;

		public ScrollChangeEventArgs(NestedScrollView? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
		{
			this.v = v;
			this.scrollX = scrollX;
			this.scrollY = scrollY;
			this.oldScrollX = oldScrollX;
			this.oldScrollY = oldScrollY;
		}
	}

	[Register("mono/androidx/core/widget/NestedScrollView_OnScrollChangeListenerImplementor")]
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

		public void OnScrollChange(NestedScrollView? v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/widget/NestedScrollView", typeof(NestedScrollView));

	private static Delegate? cb_isFillViewport_IsFillViewport_Z;

	private static Delegate? cb_setFillViewport_SetFillViewport_Z_V;

	private static Delegate? cb_getMaxScrollAmount_GetMaxScrollAmount_I;

	private static Delegate? cb_isSmoothScrollingEnabled_IsSmoothScrollingEnabled_Z;

	private static Delegate? cb_setSmoothScrollingEnabled_SetSmoothScrollingEnabled_Z_V;

	private static Delegate? cb_arrowScroll_ArrowScroll_I_Z;

	private static Delegate? cb_computeHorizontalScrollExtent_ComputeHorizontalScrollExtent_I;

	private static Delegate? cb_computeHorizontalScrollOffset_ComputeHorizontalScrollOffset_I;

	private static Delegate? cb_computeHorizontalScrollRange_ComputeHorizontalScrollRange_I;

	private static Delegate? cb_computeScrollDeltaToGetChildRectOnScreen_ComputeScrollDeltaToGetChildRectOnScreen_Landroid_graphics_Rect__I;

	private static Delegate? cb_computeVerticalScrollExtent_ComputeVerticalScrollExtent_I;

	private static Delegate? cb_computeVerticalScrollOffset_ComputeVerticalScrollOffset_I;

	private static Delegate? cb_computeVerticalScrollRange_ComputeVerticalScrollRange_I;

	private static Delegate? cb_dispatchNestedPreScroll_DispatchNestedPreScroll_IIarrayIarrayII_Z;

	private static Delegate? cb_dispatchNestedScroll_DispatchNestedScroll_IIIIarrayII_Z;

	private static Delegate? cb_dispatchNestedScroll_DispatchNestedScroll_IIIIarrayIIarrayI_V;

	private static Delegate? cb_executeKeyEvent_ExecuteKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_fling_Fling_I_V;

	private static Delegate? cb_fullScroll_FullScroll_I_Z;

	private static Delegate? cb_hasNestedScrollingParent_InvokeHasNestedScrollingParent_I_Z;

	private static Delegate? cb_onAttachedToWindow_OnAttachedToWindow_V;

	private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroid_view_View_IIarrayII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIIIarrayI_V;

	private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II_V;

	private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II_Z;

	private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroid_view_View_I_V;

	private static Delegate? cb_pageScroll_PageScroll_I_Z;

	private static Delegate? cb_setOnScrollChangeListener_SetOnScrollChangeListener_Landroidx_core_widget_NestedScrollView_OnScrollChangeListener__V;

	private static Delegate? cb_startNestedScroll_StartNestedScroll_II_Z;

	private static Delegate? cb_stopNestedScroll_StopNestedScroll_I_V;

	private WeakReference? weak_implementor_SetOnScrollChangeListener;

	[Register("mEdgeGlowBottom")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public EdgeEffect? MEdgeGlowBottom
	{
		get
		{
			return Java.Lang.Object.GetObject<EdgeEffect>(_members.InstanceFields.GetObjectValue("mEdgeGlowBottom.Landroid/widget/EdgeEffect;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mEdgeGlowBottom.Landroid/widget/EdgeEffect;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mEdgeGlowTop")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public EdgeEffect? MEdgeGlowTop
	{
		get
		{
			return Java.Lang.Object.GetObject<EdgeEffect>(_members.InstanceFields.GetObjectValue("mEdgeGlowTop.Landroid/widget/EdgeEffect;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mEdgeGlowTop.Landroid/widget/EdgeEffect;", this, new JniObjectReference(num));
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

	public unsafe virtual bool FillViewport
	{
		[Register("isFillViewport", "()Z", "GetIsFillViewportHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFillViewport.()Z", this, null);
		}
		[Register("setFillViewport", "(Z)V", "GetSetFillViewport_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFillViewport.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int MaxScrollAmount
	{
		[Register("getMaxScrollAmount", "()I", "GetGetMaxScrollAmountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxScrollAmount.()I", this, null);
		}
	}

	public unsafe virtual bool SmoothScrollingEnabled
	{
		[Register("isSmoothScrollingEnabled", "()Z", "GetIsSmoothScrollingEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSmoothScrollingEnabled.()Z", this, null);
		}
		[Register("setSmoothScrollingEnabled", "(Z)V", "GetSetSmoothScrollingEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSmoothScrollingEnabled.(Z)V", this, ptr);
		}
	}

	public new event EventHandler<ScrollChangeEventArgs> ScrollChange
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

	public virtual void OnNestedScrollAccepted(Android.Views.View child, Android.Views.View target, int axes, int type)
	{
		OnNestedScrollAccepted(child, target, (ScrollAxis)axes, type);
	}

	public override void OnNestedScrollAccepted(Android.Views.View child, Android.Views.View target, ScrollAxis axes)
	{
		OnStartNestedScroll(child, target, axes);
	}

	public virtual bool OnStartNestedScroll(Android.Views.View child, Android.Views.View target, int axes, int type)
	{
		return OnStartNestedScroll(child, target, (ScrollAxis)axes, type);
	}

	protected NestedScrollView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe NestedScrollView(Context? context)
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
	public unsafe NestedScrollView(Context? context, IAttributeSet? attrs)
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
	public unsafe NestedScrollView(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetIsFillViewportHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFillViewport);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFillViewport(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FillViewport ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetFillViewport_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetFillViewport_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFillViewport_Z(nint jnienv, nint native__this, sbyte native_fillViewport)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool fillViewport = native_fillViewport != 0;
			nestedScrollView.FillViewport = fillViewport;
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

	private static Delegate GetGetMaxScrollAmountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxScrollAmount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxScrollAmount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxScrollAmount;
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

	private static Delegate GetIsSmoothScrollingEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSmoothScrollingEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSmoothScrollingEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollingEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSmoothScrollingEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSmoothScrollingEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSmoothScrollingEnabled_Z(nint jnienv, nint native__this, sbyte native_smoothScrollingEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool smoothScrollingEnabled = native_smoothScrollingEnabled != 0;
			nestedScrollView.SmoothScrollingEnabled = smoothScrollingEnabled;
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

	private static Delegate GetArrowScroll_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_ArrowScroll_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ArrowScroll_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrowScroll(direction) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("arrowScroll", "(I)Z", "GetArrowScroll_IHandler")]
	public unsafe virtual bool ArrowScroll(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("arrowScroll.(I)Z", this, ptr);
	}

	private static Delegate GetComputeHorizontalScrollExtentHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollExtent);
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
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollExtent();
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("computeHorizontalScrollExtent", "()I", "GetComputeHorizontalScrollExtentHandler")]
	public new unsafe virtual int ComputeHorizontalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollOffset);
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
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollOffset();
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("computeHorizontalScrollOffset", "()I", "GetComputeHorizontalScrollOffsetHandler")]
	public new unsafe virtual int ComputeHorizontalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollRangeHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollRange);
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
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollRange();
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("computeHorizontalScrollRange", "()I", "GetComputeHorizontalScrollRangeHandler")]
	public new unsafe virtual int ComputeHorizontalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollRange.()I", this, null);
	}

	private static Delegate GetComputeScrollDeltaToGetChildRectOnScreen_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_ComputeScrollDeltaToGetChildRectOnScreen_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeScrollDeltaToGetChildRectOnScreen_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_rect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
			return nestedScrollView.ComputeScrollDeltaToGetChildRectOnScreen(rect);
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

	[Register("computeScrollDeltaToGetChildRectOnScreen", "(Landroid/graphics/Rect;)I", "GetComputeScrollDeltaToGetChildRectOnScreen_Landroid_graphics_Rect_Handler")]
	protected unsafe virtual int ComputeScrollDeltaToGetChildRectOnScreen(Rect? rect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("computeScrollDeltaToGetChildRectOnScreen.(Landroid/graphics/Rect;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rect);
		}
	}

	private static Delegate GetComputeVerticalScrollExtentHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeVerticalScrollExtent);
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
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollExtent();
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("computeVerticalScrollExtent", "()I", "GetComputeVerticalScrollExtentHandler")]
	public new unsafe virtual int ComputeVerticalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeVerticalScrollOffset);
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
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollOffset();
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("computeVerticalScrollOffset", "()I", "GetComputeVerticalScrollOffsetHandler")]
	public new unsafe virtual int ComputeVerticalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollRangeHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeVerticalScrollRange);
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
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollRange();
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("computeVerticalScrollRange", "()I", "GetComputeVerticalScrollRangeHandler")]
	public new unsafe virtual int ComputeVerticalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollRange.()I", this, null);
	}

	private static Delegate GetDispatchNestedPreScroll_IIarrayIarrayIIHandler()
	{
		return new _JniMarshal_PPIILLI_B(n_DispatchNestedPreScroll_IIarrayIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchNestedPreScroll_IIarrayIarrayII(nint jnienv, nint native__this, int dx, int dy, nint native_consumed, nint native_offsetInWindow, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (nestedScrollView.DispatchNestedPreScroll(dx, dy, array, array2, type) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_offsetInWindow);
			}
			return result;
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

	[Register("dispatchNestedPreScroll", "(II[I[II)Z", "GetDispatchNestedPreScroll_IIarrayIarrayIIHandler")]
	public unsafe virtual bool DispatchNestedPreScroll(int dx, int dy, int[]? consumed, int[]? offsetInWindow, int type)
	{
		nint num = JNIEnv.NewArray(consumed);
		nint num2 = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(dx);
			ptr[1] = new JniArgumentValue(dy);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(num2);
			ptr[4] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchNestedPreScroll.(II[I[II)Z", this, ptr);
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
			GC.KeepAlive(consumed);
			GC.KeepAlive(offsetInWindow);
		}
	}

	private static Delegate GetDispatchNestedScroll_IIIIarrayIIHandler()
	{
		return new _JniMarshal_PPIIIILI_B(n_DispatchNestedScroll_IIIIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchNestedScroll_IIIIarrayII(nint jnienv, nint native__this, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, nint native_offsetInWindow, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (nestedScrollView.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_offsetInWindow);
			}
			return result;
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

	[Register("dispatchNestedScroll", "(IIII[II)Z", "GetDispatchNestedScroll_IIIIarrayIIHandler")]
	public unsafe virtual bool DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow, int type)
	{
		nint num = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(dxConsumed);
			ptr[1] = new JniArgumentValue(dyConsumed);
			ptr[2] = new JniArgumentValue(dxUnconsumed);
			ptr[3] = new JniArgumentValue(dyUnconsumed);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchNestedScroll.(IIII[II)Z", this, ptr);
		}
		finally
		{
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num, offsetInWindow);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(offsetInWindow);
		}
	}

	private static Delegate GetDispatchNestedScroll_IIIIarrayIIarrayIHandler()
	{
		return new _JniMarshal_PPIIIILIL_V(n_DispatchNestedScroll_IIIIarrayIIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchNestedScroll_IIIIarrayIIarrayI(nint jnienv, nint native__this, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, nint native_offsetInWindow, int type, nint native_consumed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			nestedScrollView.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_offsetInWindow);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_consumed);
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

	[Register("dispatchNestedScroll", "(IIII[II[I)V", "GetDispatchNestedScroll_IIIIarrayIIarrayIHandler")]
	public unsafe virtual void DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow, int type, int[]? consumed)
	{
		nint num = JNIEnv.NewArray(offsetInWindow);
		nint num2 = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(dxConsumed);
			ptr[1] = new JniArgumentValue(dyConsumed);
			ptr[2] = new JniArgumentValue(dxUnconsumed);
			ptr[3] = new JniArgumentValue(dyUnconsumed);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(type);
			ptr[6] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchNestedScroll.(IIII[II[I)V", this, ptr);
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
			GC.KeepAlive(offsetInWindow);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetExecuteKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ExecuteKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ExecuteKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return nestedScrollView.ExecuteKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("executeKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetExecuteKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool ExecuteKeyEvent(KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("executeKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetFling_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_Fling_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Fling_I(nint jnienv, nint native__this, int velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fling(velocityY);
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

	[Register("fling", "(I)V", "GetFling_IHandler")]
	public unsafe virtual void Fling(int velocityY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(velocityY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("fling.(I)V", this, ptr);
	}

	private static Delegate GetFullScroll_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_FullScroll_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_FullScroll_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FullScroll(direction) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("fullScroll", "(I)Z", "GetFullScroll_IHandler")]
	public unsafe virtual bool FullScroll(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("fullScroll.(I)Z", this, ptr);
	}

	private static Delegate GetInvokeHasNestedScrollingParent_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_InvokeHasNestedScrollingParent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_InvokeHasNestedScrollingParent_I(nint jnienv, nint native__this, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvokeHasNestedScrollingParent(type) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasNestedScrollingParent", "(I)Z", "GetInvokeHasNestedScrollingParent_IHandler")]
	public unsafe virtual bool InvokeHasNestedScrollingParent(int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(type);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasNestedScrollingParent.(I)Z", this, ptr);
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
			Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAttachedToWindow();
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

	private static Delegate GetOnNestedPreScroll_Landroid_view_View_IIarrayIIHandler()
	{
		return new _JniMarshal_PPLIILI_V(n_OnNestedPreScroll_Landroid_view_View_IIarrayII);
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
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View target = Java.Lang.Object.GetObject<Android.Views.View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			nestedScrollView.OnNestedPreScroll(target, dx, dy, array, type);
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
	public unsafe virtual void OnNestedPreScroll(Android.Views.View? target, int dx, int dy, int[]? consumed, int type)
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
		return new _JniMarshal_PPLIIIII_V(n_OnNestedScroll_Landroid_view_View_IIIII);
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
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View target = Java.Lang.Object.GetObject<Android.Views.View>(native_target, JniHandleOwnership.DoNotTransfer);
			nestedScrollView.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
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
	public unsafe virtual void OnNestedScroll(Android.Views.View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
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
		return new _JniMarshal_PPLIIIIIL_V(n_OnNestedScroll_Landroid_view_View_IIIIIarrayI);
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
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View target = Java.Lang.Object.GetObject<Android.Views.View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			nestedScrollView.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
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
	public unsafe virtual void OnNestedScroll(Android.Views.View? target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[]? consumed)
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
		return new _JniMarshal_PPLLII_V(n_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II);
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
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View child = Java.Lang.Object.GetObject<Android.Views.View>(native_child, JniHandleOwnership.DoNotTransfer);
			Android.Views.View target = Java.Lang.Object.GetObject<Android.Views.View>(native_target, JniHandleOwnership.DoNotTransfer);
			nestedScrollView.OnNestedScrollAccepted(child, target, (ScrollAxis)native_axes, type);
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
	public unsafe virtual void OnNestedScrollAccepted(Android.Views.View? child, Android.Views.View? target, ScrollAxis axes, int type)
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
		return new _JniMarshal_PPLLII_B(n_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II);
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
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View child = Java.Lang.Object.GetObject<Android.Views.View>(native_child, JniHandleOwnership.DoNotTransfer);
			Android.Views.View target = Java.Lang.Object.GetObject<Android.Views.View>(native_target, JniHandleOwnership.DoNotTransfer);
			return nestedScrollView.OnStartNestedScroll(child, target, (ScrollAxis)native_axes, type) ? ((sbyte)1) : ((sbyte)0);
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
	public unsafe virtual bool OnStartNestedScroll(Android.Views.View? child, Android.Views.View? target, ScrollAxis axes, int type)
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
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View target = Java.Lang.Object.GetObject<Android.Views.View>(native_target, JniHandleOwnership.DoNotTransfer);
			nestedScrollView.OnStopNestedScroll(target, type);
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
	public unsafe virtual void OnStopNestedScroll(Android.Views.View? target, int type)
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

	private static Delegate GetPageScroll_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_PageScroll_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PageScroll_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PageScroll(direction) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("pageScroll", "(I)Z", "GetPageScroll_IHandler")]
	public unsafe virtual bool PageScroll(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("pageScroll.(I)Z", this, ptr);
	}

	private static Delegate GetSetOnScrollChangeListener_Landroidx_core_widget_NestedScrollView_OnScrollChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnScrollChangeListener_Landroidx_core_widget_NestedScrollView_OnScrollChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnScrollChangeListener_Landroidx_core_widget_NestedScrollView_OnScrollChangeListener_(nint jnienv, nint native__this, nint native_l)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NestedScrollView? nestedScrollView = Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnScrollChangeListener onScrollChangeListener = Java.Lang.Object.GetObject<IOnScrollChangeListener>(native_l, JniHandleOwnership.DoNotTransfer);
			nestedScrollView.SetOnScrollChangeListener(onScrollChangeListener);
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

	[Register("setOnScrollChangeListener", "(Landroidx/core/widget/NestedScrollView$OnScrollChangeListener;)V", "GetSetOnScrollChangeListener_Landroidx_core_widget_NestedScrollView_OnScrollChangeListener_Handler")]
	public unsafe virtual void SetOnScrollChangeListener(IOnScrollChangeListener? l)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((l == null) ? IntPtr.Zero : ((Java.Lang.Object)l).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnScrollChangeListener.(Landroidx/core/widget/NestedScrollView$OnScrollChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(l);
		}
	}

	[Register("smoothScrollBy", "(II)V", "")]
	public unsafe void SmoothScrollBy(int dx, int dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("smoothScrollBy.(II)V", this, ptr);
	}

	[Register("smoothScrollBy", "(III)V", "")]
	public unsafe void SmoothScrollBy(int dx, int dy, int scrollDurationMs)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		ptr[2] = new JniArgumentValue(scrollDurationMs);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("smoothScrollBy.(III)V", this, ptr);
	}

	[Register("smoothScrollTo", "(II)V", "")]
	public unsafe void SmoothScrollTo(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("smoothScrollTo.(II)V", this, ptr);
	}

	[Register("smoothScrollTo", "(III)V", "")]
	public unsafe void SmoothScrollTo(int x, int y, int scrollDurationMs)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		ptr[2] = new JniArgumentValue(scrollDurationMs);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("smoothScrollTo.(III)V", this, ptr);
	}

	private static Delegate GetStartNestedScroll_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_StartNestedScroll_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_StartNestedScroll_II(nint jnienv, nint native__this, int native_axes, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartNestedScroll((ScrollAxis)native_axes, type) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("startNestedScroll", "(II)Z", "GetStartNestedScroll_IIHandler")]
	public unsafe virtual bool StartNestedScroll(ScrollAxis axes, int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((int)axes);
		ptr[1] = new JniArgumentValue(type);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("startNestedScroll.(II)Z", this, ptr);
	}

	private static Delegate GetStopNestedScroll_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_StopNestedScroll_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StopNestedScroll_I(nint jnienv, nint native__this, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NestedScrollView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopNestedScroll(type);
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

	[Register("stopNestedScroll", "(I)V", "GetStopNestedScroll_IHandler")]
	public unsafe virtual void StopNestedScroll(int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(type);
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopNestedScroll.(I)V", this, ptr);
	}

	private IOnScrollChangeListenerImplementor __CreateIOnScrollChangeListenerImplementor()
	{
		return new IOnScrollChangeListenerImplementor(this);
	}
}

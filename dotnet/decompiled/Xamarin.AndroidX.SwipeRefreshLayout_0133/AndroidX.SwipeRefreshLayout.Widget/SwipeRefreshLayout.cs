using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.SwipeRefreshLayout.Widget;

[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout", DoNotGenerateAcw = true)]
public class SwipeRefreshLayout : ViewGroup, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback", "", "AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnChildScrollUpCallbackInvoker")]
	public interface IOnChildScrollUpCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("canChildScrollUp", "(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout;Landroid/view/View;)Z", "GetCanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_Handler:AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnChildScrollUpCallbackInvoker, Xamarin.AndroidX.SwipeRefreshLayout")]
		bool CanChildScrollUp(SwipeRefreshLayout parent, View? child);
	}

	[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback", DoNotGenerateAcw = true)]
	internal class IOnChildScrollUpCallbackInvoker : Java.Lang.Object, IOnChildScrollUpCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback = new XAPeerMembers("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback", typeof(IOnChildScrollUpCallbackInvoker));

		private static Delegate? cb_canChildScrollUp_CanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View__Z;

		private static nint java_class_ref => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback.ManagedPeerType;

		public IOnChildScrollUpCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetCanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_CanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_CanChildScrollUp_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnChildScrollUpCallback? onChildScrollUpCallback = Java.Lang.Object.GetObject<IOnChildScrollUpCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SwipeRefreshLayout parent = Java.Lang.Object.GetObject<SwipeRefreshLayout>(native_parent, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return onChildScrollUpCallback.CanChildScrollUp(parent, child) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool CanChildScrollUp(SwipeRefreshLayout parent, View? child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback.InstanceMethods.InvokeAbstractBooleanMethod("canChildScrollUp.(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
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

	[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener", "", "AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnRefreshListenerInvoker")]
	public interface IOnRefreshListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onRefresh", "()V", "GetOnRefreshHandler:AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout/IOnRefreshListenerInvoker, Xamarin.AndroidX.SwipeRefreshLayout")]
		void OnRefresh();
	}

	[Register("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener", DoNotGenerateAcw = true)]
	internal class IOnRefreshListenerInvoker : Java.Lang.Object, IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener = new XAPeerMembers("androidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener", typeof(IOnRefreshListenerInvoker));

		private static Delegate? cb_onRefresh_OnRefresh_V;

		private static nint java_class_ref => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener.ManagedPeerType;

		public IOnRefreshListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnRefresh(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnRefreshListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRefresh();
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

		public unsafe void OnRefresh()
		{
			_members_androidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener.InstanceMethods.InvokeAbstractVoidMethod("onRefresh.()V", this, null);
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
		private static void n_OnRefresh_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnRefresh(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("mono/androidx/swiperefreshlayout/widget/SwipeRefreshLayout_OnRefreshListenerImplementor")]
	internal sealed class IOnRefreshListenerImplementor : Java.Lang.Object, IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler? Handler;

		public unsafe IOnRefreshListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnRefresh()
		{
			Handler?.Invoke(sender, new EventArgs());
		}

		internal static bool __IsEmpty(IOnRefreshListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/swiperefreshlayout/widget/SwipeRefreshLayout", typeof(SwipeRefreshLayout));

	private static Delegate? cb_getProgressCircleDiameter_GetProgressCircleDiameter_I;

	private static Delegate? cb_getProgressViewEndOffset_GetProgressViewEndOffset_I;

	private static Delegate? cb_getProgressViewStartOffset_GetProgressViewStartOffset_I;

	private static Delegate? cb_isRefreshing_IsRefreshing_Z;

	private static Delegate? cb_setRefreshing_SetRefreshing_Z_V;

	private static Delegate? cb_canChildScrollUp_CanChildScrollUp_Z;

	private static Delegate? cb_dispatchNestedPreScroll_DispatchNestedPreScroll_IIarrayIarrayII_Z;

	private static Delegate? cb_dispatchNestedScroll_DispatchNestedScroll_IIIIarrayII_Z;

	private static Delegate? cb_dispatchNestedScroll_DispatchNestedScroll_IIIIarrayIIarrayI_V;

	private static Delegate? cb_hasNestedScrollingParent_InvokeHasNestedScrollingParent_I_Z;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_onMeasure_OnMeasure_II_V;

	private static Delegate? cb_onNestedPreScroll_OnNestedPreScroll_Landroid_view_View_IIarrayII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIII_V;

	private static Delegate? cb_onNestedScroll_OnNestedScroll_Landroid_view_View_IIIIIarrayI_V;

	private static Delegate? cb_onNestedScrollAccepted_OnNestedScrollAccepted_Landroid_view_View_Landroid_view_View_II_V;

	private static Delegate? cb_onStartNestedScroll_OnStartNestedScroll_Landroid_view_View_Landroid_view_View_II_Z;

	private static Delegate? cb_onStopNestedScroll_OnStopNestedScroll_Landroid_view_View_I_V;

	private static Delegate? cb_setColorScheme_SetColorScheme_arrayI_V;

	private static Delegate? cb_setColorSchemeColors_SetColorSchemeColors_arrayI_V;

	private static Delegate? cb_setColorSchemeResources_SetColorSchemeResources_arrayI_V;

	private static Delegate? cb_setDistanceToTriggerSync_SetDistanceToTriggerSync_I_V;

	private static Delegate? cb_setLegacyRequestDisallowInterceptTouchEventEnabled_SetLegacyRequestDisallowInterceptTouchEventEnabled_Z_V;

	private static Delegate? cb_setOnChildScrollUpCallback_SetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback__V;

	private static Delegate? cb_setOnRefreshListener_SetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener__V;

	private static Delegate? cb_setProgressBackgroundColor_SetProgressBackgroundColor_I_V;

	private static Delegate? cb_setProgressBackgroundColorSchemeColor_SetProgressBackgroundColorSchemeColor_I_V;

	private static Delegate? cb_setProgressBackgroundColorSchemeResource_SetProgressBackgroundColorSchemeResource_I_V;

	private static Delegate? cb_setProgressViewEndTarget_SetProgressViewEndTarget_ZI_V;

	private static Delegate? cb_setProgressViewOffset_SetProgressViewOffset_ZII_V;

	private static Delegate? cb_setSize_SetSize_I_V;

	private static Delegate? cb_setSlingshotDistance_SetSlingshotDistance_I_V;

	private static Delegate? cb_startNestedScroll_StartNestedScroll_II_Z;

	private static Delegate? cb_stopNestedScroll_StopNestedScroll_I_V;

	private WeakReference? weak_implementor_SetOnRefreshListener;

	[Register("mFrom")]
	protected int MFrom
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mFrom.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mFrom.I", this, value);
		}
	}

	[Register("mOriginalOffsetTop")]
	protected int MOriginalOffsetTop
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mOriginalOffsetTop.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mOriginalOffsetTop.I", this, value);
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

	public unsafe virtual int ProgressCircleDiameter
	{
		[Register("getProgressCircleDiameter", "()I", "GetGetProgressCircleDiameterHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getProgressCircleDiameter.()I", this, null);
		}
	}

	public unsafe virtual int ProgressViewEndOffset
	{
		[Register("getProgressViewEndOffset", "()I", "GetGetProgressViewEndOffsetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getProgressViewEndOffset.()I", this, null);
		}
	}

	public unsafe virtual int ProgressViewStartOffset
	{
		[Register("getProgressViewStartOffset", "()I", "GetGetProgressViewStartOffsetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getProgressViewStartOffset.()I", this, null);
		}
	}

	public unsafe virtual bool Refreshing
	{
		[Register("isRefreshing", "()Z", "GetIsRefreshingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRefreshing.()Z", this, null);
		}
		[Register("setRefreshing", "(Z)V", "GetSetRefreshing_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRefreshing.(Z)V", this, ptr);
		}
	}

	public event EventHandler Refresh
	{
		add
		{
			EventHelper.AddEventHandler<IOnRefreshListener, IOnRefreshListenerImplementor>(ref weak_implementor_SetOnRefreshListener, __CreateIOnRefreshListenerImplementor, SetOnRefreshListener, delegate(IOnRefreshListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnRefreshListener, IOnRefreshListenerImplementor>(ref weak_implementor_SetOnRefreshListener, IOnRefreshListenerImplementor.__IsEmpty, delegate
			{
				SetOnRefreshListener(null);
			}, delegate(IOnRefreshListenerImplementor __h)
			{
				__h.Handler = (EventHandler)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public virtual void OnNestedScrollAccepted(View child, View target, int axes, int type)
	{
		OnNestedScrollAccepted(child, target, (ScrollAxis)axes, type);
	}

	public virtual bool OnStartNestedScroll(View child, View target, int axes, int type)
	{
		return OnStartNestedScroll(child, target, (ScrollAxis)axes, type);
	}

	protected SwipeRefreshLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe SwipeRefreshLayout(Context context)
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
	public unsafe SwipeRefreshLayout(Context context, IAttributeSet? attrs)
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

	private static Delegate GetGetProgressCircleDiameterHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetProgressCircleDiameter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetProgressCircleDiameter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProgressCircleDiameter;
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

	private static Delegate GetGetProgressViewEndOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetProgressViewEndOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetProgressViewEndOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProgressViewEndOffset;
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

	private static Delegate GetGetProgressViewStartOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetProgressViewStartOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetProgressViewStartOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ProgressViewStartOffset;
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

	private static Delegate GetIsRefreshingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRefreshing);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRefreshing(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Refreshing ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetRefreshing_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetRefreshing_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRefreshing_Z(nint jnienv, nint native__this, sbyte native_refreshing)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool refreshing = native_refreshing != 0;
			swipeRefreshLayout.Refreshing = refreshing;
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

	private static Delegate GetCanChildScrollUpHandler()
	{
		return new global::_JniMarshal_PP_B(n_CanChildScrollUp);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanChildScrollUp(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanChildScrollUp() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canChildScrollUp", "()Z", "GetCanChildScrollUpHandler")]
	public unsafe virtual bool CanChildScrollUp()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canChildScrollUp.()Z", this, null);
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (swipeRefreshLayout.DispatchNestedPreScroll(dx, dy, array, array2, type) ? ((sbyte)1) : ((sbyte)0));
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (swipeRefreshLayout.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type) ? ((sbyte)1) : ((sbyte)0));
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type, array2);
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
	public unsafe virtual void DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow, int type, int[] consumed)
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
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvokeHasNestedScrollingParent(type) ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new global::_JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			swipeRefreshLayout.OnLayout(changed, left, top, right, bottom);
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
	protected unsafe override void OnLayout(bool changed, int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(left);
		ptr[2] = new JniArgumentValue(top);
		ptr[3] = new JniArgumentValue(right);
		ptr[4] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
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
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMeasure(widthMeasureSpec, heightMeasureSpec);
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.OnNestedPreScroll(target, dx, dy, array, type);
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.OnNestedScroll(target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type, array);
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
	public unsafe virtual void OnNestedScroll(View target, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type, int[] consumed)
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.OnNestedScrollAccepted(child, target, (ScrollAxis)native_axes, type);
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			return swipeRefreshLayout.OnStartNestedScroll(child, target, (ScrollAxis)native_axes, type) ? ((sbyte)1) : ((sbyte)0);
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
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.OnStopNestedScroll(target, type);
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

	[Obsolete]
	private static Delegate GetSetColorScheme_arrayIHandler()
	{
		return new global::_JniMarshal_PPL_V(n_SetColorScheme_arrayI);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorScheme_arrayI(nint jnienv, nint native__this, nint native_colors)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_colors, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.SetColorScheme(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_colors);
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
	[Register("setColorScheme", "([I)V", "GetSetColorScheme_arrayIHandler")]
	public unsafe virtual void SetColorScheme(params int[]? colors)
	{
		nint num = JNIEnv.NewArray(colors);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorScheme.([I)V", this, ptr);
		}
		finally
		{
			if (colors != null)
			{
				JNIEnv.CopyArray(num, colors);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(colors);
		}
	}

	private static Delegate GetSetColorSchemeColors_arrayIHandler()
	{
		return new global::_JniMarshal_PPL_V(n_SetColorSchemeColors_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorSchemeColors_arrayI(nint jnienv, nint native__this, nint native_colors)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_colors, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.SetColorSchemeColors(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_colors);
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

	[Register("setColorSchemeColors", "([I)V", "GetSetColorSchemeColors_arrayIHandler")]
	public unsafe virtual void SetColorSchemeColors(params int[]? colors)
	{
		nint num = JNIEnv.NewArray(colors);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorSchemeColors.([I)V", this, ptr);
		}
		finally
		{
			if (colors != null)
			{
				JNIEnv.CopyArray(num, colors);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(colors);
		}
	}

	private static Delegate GetSetColorSchemeResources_arrayIHandler()
	{
		return new global::_JniMarshal_PPL_V(n_SetColorSchemeResources_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorSchemeResources_arrayI(nint jnienv, nint native__this, nint native_colorResIds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_colorResIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			swipeRefreshLayout.SetColorSchemeResources(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_colorResIds);
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

	[Register("setColorSchemeResources", "([I)V", "GetSetColorSchemeResources_arrayIHandler")]
	public unsafe virtual void SetColorSchemeResources(params int[]? colorResIds)
	{
		nint num = JNIEnv.NewArray(colorResIds);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorSchemeResources.([I)V", this, ptr);
		}
		finally
		{
			if (colorResIds != null)
			{
				JNIEnv.CopyArray(num, colorResIds);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(colorResIds);
		}
	}

	private static Delegate GetSetDistanceToTriggerSync_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDistanceToTriggerSync_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDistanceToTriggerSync_I(nint jnienv, nint native__this, int distance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDistanceToTriggerSync(distance);
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

	[Register("setDistanceToTriggerSync", "(I)V", "GetSetDistanceToTriggerSync_IHandler")]
	public unsafe virtual void SetDistanceToTriggerSync(int distance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(distance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setDistanceToTriggerSync.(I)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetLegacyRequestDisallowInterceptTouchEventEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetLegacyRequestDisallowInterceptTouchEventEnabled_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLegacyRequestDisallowInterceptTouchEventEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool legacyRequestDisallowInterceptTouchEventEnabled = native_enabled != 0;
			swipeRefreshLayout.SetLegacyRequestDisallowInterceptTouchEventEnabled(legacyRequestDisallowInterceptTouchEventEnabled);
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
	[Register("setLegacyRequestDisallowInterceptTouchEventEnabled", "(Z)V", "GetSetLegacyRequestDisallowInterceptTouchEventEnabled_ZHandler")]
	public unsafe virtual void SetLegacyRequestDisallowInterceptTouchEventEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLegacyRequestDisallowInterceptTouchEventEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnChildScrollUpCallback onChildScrollUpCallback = Java.Lang.Object.GetObject<IOnChildScrollUpCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.SetOnChildScrollUpCallback(onChildScrollUpCallback);
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

	[Register("setOnChildScrollUpCallback", "(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback;)V", "GetSetOnChildScrollUpCallback_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnChildScrollUpCallback_Handler")]
	public unsafe virtual void SetOnChildScrollUpCallback(IOnChildScrollUpCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnChildScrollUpCallback.(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnChildScrollUpCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnRefreshListener onRefreshListener = Java.Lang.Object.GetObject<IOnRefreshListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			swipeRefreshLayout.SetOnRefreshListener(onRefreshListener);
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

	[Register("setOnRefreshListener", "(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener;)V", "GetSetOnRefreshListener_Landroidx_swiperefreshlayout_widget_SwipeRefreshLayout_OnRefreshListener_Handler")]
	public unsafe virtual void SetOnRefreshListener(IOnRefreshListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnRefreshListener.(Landroidx/swiperefreshlayout/widget/SwipeRefreshLayout$OnRefreshListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Obsolete]
	private static Delegate GetSetProgressBackgroundColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetProgressBackgroundColor_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgressBackgroundColor_I(nint jnienv, nint native__this, int colorRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressBackgroundColor(colorRes);
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
	[Register("setProgressBackgroundColor", "(I)V", "GetSetProgressBackgroundColor_IHandler")]
	public unsafe virtual void SetProgressBackgroundColor(int colorRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(colorRes);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressBackgroundColor.(I)V", this, ptr);
	}

	private static Delegate GetSetProgressBackgroundColorSchemeColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetProgressBackgroundColorSchemeColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgressBackgroundColorSchemeColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressBackgroundColorSchemeColor(color);
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

	[Register("setProgressBackgroundColorSchemeColor", "(I)V", "GetSetProgressBackgroundColorSchemeColor_IHandler")]
	public unsafe virtual void SetProgressBackgroundColorSchemeColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressBackgroundColorSchemeColor.(I)V", this, ptr);
	}

	private static Delegate GetSetProgressBackgroundColorSchemeResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetProgressBackgroundColorSchemeResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgressBackgroundColorSchemeResource_I(nint jnienv, nint native__this, int colorRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetProgressBackgroundColorSchemeResource(colorRes);
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

	[Register("setProgressBackgroundColorSchemeResource", "(I)V", "GetSetProgressBackgroundColorSchemeResource_IHandler")]
	public unsafe virtual void SetProgressBackgroundColorSchemeResource(int colorRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(colorRes);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressBackgroundColorSchemeResource.(I)V", this, ptr);
	}

	private static Delegate GetSetProgressViewEndTarget_ZIHandler()
	{
		return new _JniMarshal_PPBI_V(n_SetProgressViewEndTarget_ZI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgressViewEndTarget_ZI(nint jnienv, nint native__this, sbyte native_scale, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool scale = native_scale != 0;
			swipeRefreshLayout.SetProgressViewEndTarget(scale, end);
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

	[Register("setProgressViewEndTarget", "(ZI)V", "GetSetProgressViewEndTarget_ZIHandler")]
	public unsafe virtual void SetProgressViewEndTarget(bool scale, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(scale ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(end);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressViewEndTarget.(ZI)V", this, ptr);
	}

	private static Delegate GetSetProgressViewOffset_ZIIHandler()
	{
		return new _JniMarshal_PPBII_V(n_SetProgressViewOffset_ZII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetProgressViewOffset_ZII(nint jnienv, nint native__this, sbyte native_scale, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			SwipeRefreshLayout? swipeRefreshLayout = Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool scale = native_scale != 0;
			swipeRefreshLayout.SetProgressViewOffset(scale, start, end);
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

	[Register("setProgressViewOffset", "(ZII)V", "GetSetProgressViewOffset_ZIIHandler")]
	public unsafe virtual void SetProgressViewOffset(bool scale, int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(scale ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(start);
		ptr[2] = new JniArgumentValue(end);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setProgressViewOffset.(ZII)V", this, ptr);
	}

	private static Delegate GetSetSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSize_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSize(size);
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

	[Register("setSize", "(I)V", "GetSetSize_IHandler")]
	public unsafe virtual void SetSize(int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSize.(I)V", this, ptr);
	}

	private static Delegate GetSetSlingshotDistance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSlingshotDistance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSlingshotDistance_I(nint jnienv, nint native__this, int slingshotDistance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSlingshotDistance(slingshotDistance);
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

	[Register("setSlingshotDistance", "(I)V", "GetSetSlingshotDistance_IHandler")]
	public unsafe virtual void SetSlingshotDistance(int slingshotDistance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(slingshotDistance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSlingshotDistance.(I)V", this, ptr);
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
			return Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartNestedScroll((ScrollAxis)native_axes, type) ? ((sbyte)1) : ((sbyte)0);
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
			Java.Lang.Object.GetObject<SwipeRefreshLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopNestedScroll(type);
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

	private IOnRefreshListenerImplementor __CreateIOnRefreshListenerImplementor()
	{
		return new IOnRefreshListenerImplementor(this);
	}
}

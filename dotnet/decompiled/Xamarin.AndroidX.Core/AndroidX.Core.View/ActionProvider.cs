using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ActionProvider", DoNotGenerateAcw = true)]
public abstract class ActionProvider : Java.Lang.Object
{
	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/core/view/ActionProvider$SubUiVisibilityListener", "", "AndroidX.Core.View.ActionProvider/ISubUiVisibilityListenerInvoker")]
	public interface ISubUiVisibilityListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onSubUiVisibilityChanged", "(Z)V", "GetOnSubUiVisibilityChanged_ZHandler:AndroidX.Core.View.ActionProvider/ISubUiVisibilityListenerInvoker, Xamarin.AndroidX.Core")]
		void OnSubUiVisibilityChanged(bool isVisible);
	}

	[Register("androidx/core/view/ActionProvider$SubUiVisibilityListener", DoNotGenerateAcw = true)]
	internal class ISubUiVisibilityListenerInvoker : Java.Lang.Object, ISubUiVisibilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_view_ActionProvider_SubUiVisibilityListener = new XAPeerMembers("androidx/core/view/ActionProvider$SubUiVisibilityListener", typeof(ISubUiVisibilityListenerInvoker));

		private static Delegate? cb_onSubUiVisibilityChanged_OnSubUiVisibilityChanged_Z_V;

		private static nint java_class_ref => _members_androidx_core_view_ActionProvider_SubUiVisibilityListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_ActionProvider_SubUiVisibilityListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_view_ActionProvider_SubUiVisibilityListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_view_ActionProvider_SubUiVisibilityListener.ManagedPeerType;

		public ISubUiVisibilityListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSubUiVisibilityChanged_Z(nint jnienv, nint native__this, sbyte native_isVisible)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ISubUiVisibilityListener? subUiVisibilityListener = Java.Lang.Object.GetObject<ISubUiVisibilityListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool isVisible = native_isVisible != 0;
				subUiVisibilityListener.OnSubUiVisibilityChanged(isVisible);
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

		public unsafe void OnSubUiVisibilityChanged(bool isVisible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isVisible ? ((sbyte)1) : ((sbyte)0));
			_members_androidx_core_view_ActionProvider_SubUiVisibilityListener.InstanceMethods.InvokeAbstractVoidMethod("onSubUiVisibilityChanged.(Z)V", this, ptr);
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
		private static void n_OnSubUiVisibilityChanged_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_isVisible)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnSubUiVisibilityChanged_Z(jnienv, native__this, native_isVisible);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class SubUiVisibilityEventArgs : EventArgs
	{
		private bool isVisible;

		public SubUiVisibilityEventArgs(bool isVisible)
		{
			this.isVisible = isVisible;
		}
	}

	[Register("mono/androidx/core/view/ActionProvider_SubUiVisibilityListenerImplementor")]
	internal sealed class ISubUiVisibilityListenerImplementor : Java.Lang.Object, ISubUiVisibilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<SubUiVisibilityEventArgs>? Handler;

		public unsafe ISubUiVisibilityListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnSubUiVisibilityChanged(bool isVisible)
		{
			Handler?.Invoke(sender, new SubUiVisibilityEventArgs(isVisible));
		}

		internal static bool __IsEmpty(ISubUiVisibilityListenerImplementor value)
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

	[Register("androidx/core/view/ActionProvider$VisibilityListener", "", "AndroidX.Core.View.ActionProvider/IVisibilityListenerInvoker")]
	public interface IVisibilityListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onActionProviderVisibilityChanged", "(Z)V", "GetOnActionProviderVisibilityChanged_ZHandler:AndroidX.Core.View.ActionProvider/IVisibilityListenerInvoker, Xamarin.AndroidX.Core")]
		void OnActionProviderVisibilityChanged(bool isVisible);
	}

	[Register("androidx/core/view/ActionProvider$VisibilityListener", DoNotGenerateAcw = true)]
	internal class IVisibilityListenerInvoker : Java.Lang.Object, IVisibilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_core_view_ActionProvider_VisibilityListener = new XAPeerMembers("androidx/core/view/ActionProvider$VisibilityListener", typeof(IVisibilityListenerInvoker));

		private static Delegate? cb_onActionProviderVisibilityChanged_OnActionProviderVisibilityChanged_Z_V;

		private static nint java_class_ref => _members_androidx_core_view_ActionProvider_VisibilityListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_ActionProvider_VisibilityListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_core_view_ActionProvider_VisibilityListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_core_view_ActionProvider_VisibilityListener.ManagedPeerType;

		public IVisibilityListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActionProviderVisibilityChanged_Z(nint jnienv, nint native__this, sbyte native_isVisible)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IVisibilityListener? visibilityListener = Java.Lang.Object.GetObject<IVisibilityListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool isVisible = native_isVisible != 0;
				visibilityListener.OnActionProviderVisibilityChanged(isVisible);
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

		public unsafe void OnActionProviderVisibilityChanged(bool isVisible)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(isVisible ? ((sbyte)1) : ((sbyte)0));
			_members_androidx_core_view_ActionProvider_VisibilityListener.InstanceMethods.InvokeAbstractVoidMethod("onActionProviderVisibilityChanged.(Z)V", this, ptr);
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
		private static void n_OnActionProviderVisibilityChanged_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_isVisible)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActionProviderVisibilityChanged_Z(jnienv, native__this, native_isVisible);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class VisibilityEventArgs : EventArgs
	{
		private bool isVisible;

		public VisibilityEventArgs(bool isVisible)
		{
			this.isVisible = isVisible;
		}
	}

	[Register("mono/androidx/core/view/ActionProvider_VisibilityListenerImplementor")]
	internal sealed class IVisibilityListenerImplementor : Java.Lang.Object, IVisibilityListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<VisibilityEventArgs>? Handler;

		public unsafe IVisibilityListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnActionProviderVisibilityChanged(bool isVisible)
		{
			Handler?.Invoke(sender, new VisibilityEventArgs(isVisible));
		}

		internal static bool __IsEmpty(IVisibilityListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/ActionProvider", typeof(ActionProvider));

	private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

	private static Delegate? cb_hasSubMenu_HasSubMenu_Z;

	private static Delegate? cb_isVisible_IsVisible_Z;

	private static Delegate? cb_onCreateActionView_OnCreateActionView_Landroid_view_View_;

	private static Delegate? cb_onCreateActionView_OnCreateActionView_Landroid_view_MenuItem__Landroid_view_View_;

	private static Delegate? cb_onPerformDefaultAction_OnPerformDefaultAction_Z;

	private static Delegate? cb_onPrepareSubMenu_OnPrepareSubMenu_Landroid_view_SubMenu__V;

	private static Delegate? cb_overridesItemVisibility_OverridesItemVisibility_Z;

	private static Delegate? cb_refreshVisibility_RefreshVisibility_V;

	private static Delegate? cb_reset_Reset_V;

	private static Delegate? cb_setSubUiVisibilityListener_SetSubUiVisibilityListener_Landroidx_core_view_ActionProvider_SubUiVisibilityListener__V;

	private static Delegate? cb_setVisibilityListener_SetVisibilityListener_Landroidx_core_view_ActionProvider_VisibilityListener__V;

	private static Delegate? cb_subUiVisibilityChanged_SubUiVisibilityChanged_Z_V;

	private WeakReference? weak_implementor_SetSubUiVisibilityListener;

	private WeakReference? weak_implementor_SetVisibilityListener;

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

	public unsafe virtual Context? Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool HasSubMenu
	{
		[Register("hasSubMenu", "()Z", "GetHasSubMenuHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasSubMenu.()Z", this, null);
		}
	}

	public unsafe virtual bool IsVisible
	{
		[Register("isVisible", "()Z", "GetIsVisibleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isVisible.()Z", this, null);
		}
	}

	public event EventHandler<SubUiVisibilityEventArgs> SubUiVisibility
	{
		add
		{
			EventHelper.AddEventHandler<ISubUiVisibilityListener, ISubUiVisibilityListenerImplementor>(ref weak_implementor_SetSubUiVisibilityListener, __CreateISubUiVisibilityListenerImplementor, SetSubUiVisibilityListener, delegate(ISubUiVisibilityListenerImplementor __h)
			{
				__h.Handler = (EventHandler<SubUiVisibilityEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<ISubUiVisibilityListener, ISubUiVisibilityListenerImplementor>(ref weak_implementor_SetSubUiVisibilityListener, ISubUiVisibilityListenerImplementor.__IsEmpty, delegate
			{
				SetSubUiVisibilityListener(null);
			}, delegate(ISubUiVisibilityListenerImplementor __h)
			{
				__h.Handler = (EventHandler<SubUiVisibilityEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<VisibilityEventArgs> Visibility
	{
		add
		{
			EventHelper.AddEventHandler<IVisibilityListener, IVisibilityListenerImplementor>(ref weak_implementor_SetVisibilityListener, __CreateIVisibilityListenerImplementor, SetVisibilityListener, delegate(IVisibilityListenerImplementor __h)
			{
				__h.Handler = (EventHandler<VisibilityEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IVisibilityListener, IVisibilityListenerImplementor>(ref weak_implementor_SetVisibilityListener, IVisibilityListenerImplementor.__IsEmpty, delegate
			{
				SetVisibilityListener(null);
			}, delegate(IVisibilityListenerImplementor __h)
			{
				__h.Handler = (EventHandler<VisibilityEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected ActionProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ActionProvider(Context? context)
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

	private static Delegate GetGetContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

	private static Delegate GetHasSubMenuHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasSubMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasSubMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasSubMenu ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsVisibleHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsVisible);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsVisible(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVisible ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetOnCreateActionViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnCreateActionView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateActionView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreateActionView());
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

	[Register("onCreateActionView", "()Landroid/view/View;", "GetOnCreateActionViewHandler")]
	public abstract Android.Views.View? OnCreateActionView();

	private static Delegate GetOnCreateActionView_Landroid_view_MenuItem_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_OnCreateActionView_Landroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateActionView_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_forItem)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActionProvider? actionProvider = Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem forItem = Java.Lang.Object.GetObject<IMenuItem>(native_forItem, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(actionProvider.OnCreateActionView(forItem));
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

	[Register("onCreateActionView", "(Landroid/view/MenuItem;)Landroid/view/View;", "GetOnCreateActionView_Landroid_view_MenuItem_Handler")]
	public unsafe virtual Android.Views.View? OnCreateActionView(IMenuItem? forItem)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((forItem == null) ? IntPtr.Zero : ((Java.Lang.Object)forItem).Handle);
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateActionView.(Landroid/view/MenuItem;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(forItem);
		}
	}

	private static Delegate GetOnPerformDefaultActionHandler()
	{
		return new global::_JniMarshal_PP_B(n_OnPerformDefaultAction);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnPerformDefaultAction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPerformDefaultAction() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onPerformDefaultAction", "()Z", "GetOnPerformDefaultActionHandler")]
	public unsafe virtual bool OnPerformDefaultAction()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onPerformDefaultAction.()Z", this, null);
	}

	private static Delegate GetOnPrepareSubMenu_Landroid_view_SubMenu_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnPrepareSubMenu_Landroid_view_SubMenu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPrepareSubMenu_Landroid_view_SubMenu_(nint jnienv, nint native__this, nint native_subMenu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionProvider? actionProvider = Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISubMenu subMenu = Java.Lang.Object.GetObject<ISubMenu>(native_subMenu, JniHandleOwnership.DoNotTransfer);
			actionProvider.OnPrepareSubMenu(subMenu);
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

	[Register("onPrepareSubMenu", "(Landroid/view/SubMenu;)V", "GetOnPrepareSubMenu_Landroid_view_SubMenu_Handler")]
	public unsafe virtual void OnPrepareSubMenu(ISubMenu? subMenu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((subMenu == null) ? IntPtr.Zero : ((Java.Lang.Object)subMenu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPrepareSubMenu.(Landroid/view/SubMenu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(subMenu);
		}
	}

	private static Delegate GetOverridesItemVisibilityHandler()
	{
		return new global::_JniMarshal_PP_B(n_OverridesItemVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OverridesItemVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OverridesItemVisibility() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("overridesItemVisibility", "()Z", "GetOverridesItemVisibilityHandler")]
	public unsafe virtual bool OverridesItemVisibility()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("overridesItemVisibility.()Z", this, null);
	}

	private static Delegate GetRefreshVisibilityHandler()
	{
		return new global::_JniMarshal_PP_V(n_RefreshVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RefreshVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RefreshVisibility();
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

	[Register("refreshVisibility", "()V", "GetRefreshVisibilityHandler")]
	public unsafe virtual void RefreshVisibility()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("refreshVisibility.()V", this, null);
	}

	private static Delegate GetResetHandler()
	{
		return new global::_JniMarshal_PP_V(n_Reset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Reset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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
	[Register("reset", "()V", "GetResetHandler")]
	public unsafe virtual void Reset()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
	}

	private static Delegate GetSetSubUiVisibilityListener_Landroidx_core_view_ActionProvider_SubUiVisibilityListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSubUiVisibilityListener_Landroidx_core_view_ActionProvider_SubUiVisibilityListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubUiVisibilityListener_Landroidx_core_view_ActionProvider_SubUiVisibilityListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionProvider? actionProvider = Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISubUiVisibilityListener subUiVisibilityListener = Java.Lang.Object.GetObject<ISubUiVisibilityListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			actionProvider.SetSubUiVisibilityListener(subUiVisibilityListener);
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
	[Register("setSubUiVisibilityListener", "(Landroidx/core/view/ActionProvider$SubUiVisibilityListener;)V", "GetSetSubUiVisibilityListener_Landroidx_core_view_ActionProvider_SubUiVisibilityListener_Handler")]
	public unsafe virtual void SetSubUiVisibilityListener(ISubUiVisibilityListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSubUiVisibilityListener.(Landroidx/core/view/ActionProvider$SubUiVisibilityListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetVisibilityListener_Landroidx_core_view_ActionProvider_VisibilityListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetVisibilityListener_Landroidx_core_view_ActionProvider_VisibilityListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibilityListener_Landroidx_core_view_ActionProvider_VisibilityListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionProvider? actionProvider = Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IVisibilityListener visibilityListener = Java.Lang.Object.GetObject<IVisibilityListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			actionProvider.SetVisibilityListener(visibilityListener);
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

	[Register("setVisibilityListener", "(Landroidx/core/view/ActionProvider$VisibilityListener;)V", "GetSetVisibilityListener_Landroidx_core_view_ActionProvider_VisibilityListener_Handler")]
	public unsafe virtual void SetVisibilityListener(IVisibilityListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibilityListener.(Landroidx/core/view/ActionProvider$VisibilityListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSubUiVisibilityChanged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SubUiVisibilityChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SubUiVisibilityChanged_Z(nint jnienv, nint native__this, sbyte native_isVisible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionProvider? actionProvider = Java.Lang.Object.GetObject<ActionProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool isVisible = native_isVisible != 0;
			actionProvider.SubUiVisibilityChanged(isVisible);
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
	[Register("subUiVisibilityChanged", "(Z)V", "GetSubUiVisibilityChanged_ZHandler")]
	public unsafe virtual void SubUiVisibilityChanged(bool isVisible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isVisible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("subUiVisibilityChanged.(Z)V", this, ptr);
	}

	private ISubUiVisibilityListenerImplementor __CreateISubUiVisibilityListenerImplementor()
	{
		return new ISubUiVisibilityListenerImplementor(this);
	}

	private IVisibilityListenerImplementor __CreateIVisibilityListenerImplementor()
	{
		return new IVisibilityListenerImplementor(this);
	}
}

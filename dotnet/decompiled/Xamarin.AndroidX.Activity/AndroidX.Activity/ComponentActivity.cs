using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using AndroidX.Activity.ContextAware;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using AndroidX.Core.App;
using AndroidX.Core.Util;
using AndroidX.Core.View;
using AndroidX.Lifecycle;
using AndroidX.Lifecycle.ViewModels;
using AndroidX.SavedState;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity;

[Register("androidx/activity/ComponentActivity", DoNotGenerateAcw = true)]
public class ComponentActivity : AndroidX.Core.App.ComponentActivity, IJavaObject, IDisposable, IJavaPeerable, ILifecycleOwner, IViewModelStoreOwner
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/ComponentActivity", typeof(ComponentActivity));

	private static Delegate? cb_getDefaultViewModelCreationExtras_GetDefaultViewModelCreationExtras_Landroidx_lifecycle_viewmodel_CreationExtras_;

	private static Delegate? cb_getDefaultViewModelProviderFactory_GetDefaultViewModelProviderFactory_Landroidx_lifecycle_ViewModelProvider_Factory_;

	private static Delegate? cb_getFullyDrawnReporter_GetFullyDrawnReporter_Landroidx_activity_FullyDrawnReporter_;

	private static Delegate? cb_getLastCustomNonConfigurationInstance_GetLastCustomNonConfigurationInstance_Ljava_lang_Object_;

	private static Delegate? cb_getViewModelStore_GetViewModelStore_Landroidx_lifecycle_ViewModelStore_;

	private static Delegate? cb_addMenuProvider_AddMenuProvider_Landroidx_core_view_MenuProvider__V;

	private static Delegate? cb_addMenuProvider_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_addMenuProvider_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State__V;

	private static Delegate? cb_initializeViewTreeOwners_InitializeViewTreeOwners_V;

	private static Delegate? cb_invalidateMenu_InvalidateMenu_V;

	private static Delegate? cb_onRetainCustomNonConfigurationInstance_OnRetainCustomNonConfigurationInstance_Ljava_lang_Object_;

	private static Delegate? cb_peekAvailableContext_PeekAvailableContext_Landroid_content_Context_;

	private static Delegate? cb_removeMenuProvider_RemoveMenuProvider_Landroidx_core_view_MenuProvider__V;

	private WeakReference? weak_implementor_AddOnContextAvailableListener;

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

	public unsafe ActivityResultRegistry ActivityResultRegistry
	{
		[Register("getActivityResultRegistry", "()Landroidx/activity/result/ActivityResultRegistry;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ActivityResultRegistry>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getActivityResultRegistry.()Landroidx/activity/result/ActivityResultRegistry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CreationExtras DefaultViewModelCreationExtras
	{
		[Register("getDefaultViewModelCreationExtras", "()Landroidx/lifecycle/viewmodel/CreationExtras;", "GetGetDefaultViewModelCreationExtrasHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CreationExtras>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultViewModelCreationExtras.()Landroidx/lifecycle/viewmodel/CreationExtras;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ViewModelProvider.IFactory DefaultViewModelProviderFactory
	{
		[Register("getDefaultViewModelProviderFactory", "()Landroidx/lifecycle/ViewModelProvider$Factory;", "GetGetDefaultViewModelProviderFactoryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewModelProvider.IFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefaultViewModelProviderFactory.()Landroidx/lifecycle/ViewModelProvider$Factory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual FullyDrawnReporter FullyDrawnReporter
	{
		[Register("getFullyDrawnReporter", "()Landroidx/activity/FullyDrawnReporter;", "GetGetFullyDrawnReporterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FullyDrawnReporter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFullyDrawnReporter.()Landroidx/activity/FullyDrawnReporter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual Java.Lang.Object? LastCustomNonConfigurationInstance
	{
		[Register("getLastCustomNonConfigurationInstance", "()Ljava/lang/Object;", "GetGetLastCustomNonConfigurationInstanceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLastCustomNonConfigurationInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe OnBackPressedDispatcher OnBackPressedDispatcher
	{
		[Register("getOnBackPressedDispatcher", "()Landroidx/activity/OnBackPressedDispatcher;", "")]
		get
		{
			return Java.Lang.Object.GetObject<OnBackPressedDispatcher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOnBackPressedDispatcher.()Landroidx/activity/OnBackPressedDispatcher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe SavedStateRegistry SavedStateRegistry
	{
		[Register("getSavedStateRegistry", "()Landroidx/savedstate/SavedStateRegistry;", "")]
		get
		{
			return Java.Lang.Object.GetObject<SavedStateRegistry>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getSavedStateRegistry.()Landroidx/savedstate/SavedStateRegistry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ViewModelStore ViewModelStore
	{
		[Register("getViewModelStore", "()Landroidx/lifecycle/ViewModelStore;", "GetGetViewModelStoreHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ViewModelStore>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewModelStore.()Landroidx/lifecycle/ViewModelStore;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public event EventHandler<ContextAvailableEventArgs> ContextAvailable
	{
		add
		{
			EventHelper.AddEventHandler<IOnContextAvailableListener, IOnContextAvailableListenerImplementor>(ref weak_implementor_AddOnContextAvailableListener, __CreateIOnContextAvailableListenerImplementor, AddOnContextAvailableListener, delegate(IOnContextAvailableListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ContextAvailableEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnContextAvailableListener, IOnContextAvailableListenerImplementor.__IsEmpty, delegate(IOnContextAvailableListener __v)
			{
				RemoveOnContextAvailableListener(__v);
			}, delegate(IOnContextAvailableListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ContextAvailableEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected ComponentActivity(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ComponentActivity()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe ComponentActivity(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetGetDefaultViewModelCreationExtrasHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDefaultViewModelCreationExtras);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefaultViewModelCreationExtras(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultViewModelCreationExtras);
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

	private static Delegate GetGetDefaultViewModelProviderFactoryHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDefaultViewModelProviderFactory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefaultViewModelProviderFactory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultViewModelProviderFactory);
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

	private static Delegate GetGetFullyDrawnReporterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetFullyDrawnReporter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFullyDrawnReporter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FullyDrawnReporter);
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
	private static Delegate GetGetLastCustomNonConfigurationInstanceHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLastCustomNonConfigurationInstance);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLastCustomNonConfigurationInstance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastCustomNonConfigurationInstance);
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

	private static Delegate GetGetViewModelStoreHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetViewModelStore);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewModelStore(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewModelStore);
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

	private static Delegate GetAddMenuProvider_Landroidx_core_view_MenuProvider_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddMenuProvider_Landroidx_core_view_MenuProvider_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuProvider_Landroidx_core_view_MenuProvider_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ComponentActivity? componentActivity = Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			componentActivity.AddMenuProvider(provider);
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

	[Register("addMenuProvider", "(Landroidx/core/view/MenuProvider;)V", "GetAddMenuProvider_Landroidx_core_view_MenuProvider_Handler")]
	public unsafe virtual void AddMenuProvider(IMenuProvider provider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuProvider.(Landroidx/core/view/MenuProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
		}
	}

	private static Delegate GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_provider, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ComponentActivity? componentActivity = Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			componentActivity.AddMenuProvider(provider, owner);
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

	[Register("addMenuProvider", "(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;)V", "GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Handler")]
	public unsafe virtual void AddMenuProvider(IMenuProvider provider, ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			ptr[1] = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuProvider.(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
			GC.KeepAlive(owner);
		}
	}

	private static Delegate GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_(nint jnienv, nint native__this, nint native_provider, nint native_owner, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ComponentActivity? componentActivity = Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			AndroidX.Lifecycle.Lifecycle.State state = Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle.State>(native_state, JniHandleOwnership.DoNotTransfer);
			componentActivity.AddMenuProvider(provider, owner, state);
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

	[Register("addMenuProvider", "(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$State;)V", "GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_Handler")]
	public unsafe virtual void AddMenuProvider(IMenuProvider provider, ILifecycleOwner owner, AndroidX.Lifecycle.Lifecycle.State state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			ptr[1] = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuProvider.(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$State;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
			GC.KeepAlive(owner);
			GC.KeepAlive(state);
		}
	}

	[Register("addOnConfigurationChangedListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void AddOnConfigurationChangedListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnConfigurationChangedListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("addOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V", "")]
	public unsafe void AddOnContextAvailableListener(IOnContextAvailableListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnContextAvailableListener.(Landroidx/activity/contextaware/OnContextAvailableListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("addOnMultiWindowModeChangedListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void AddOnMultiWindowModeChangedListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnMultiWindowModeChangedListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("addOnNewIntentListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void AddOnNewIntentListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnNewIntentListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("addOnPictureInPictureModeChangedListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void AddOnPictureInPictureModeChangedListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnPictureInPictureModeChangedListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("addOnTrimMemoryListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void AddOnTrimMemoryListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnTrimMemoryListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("addOnUserLeaveHintListener", "(Ljava/lang/Runnable;)V", "")]
	public unsafe void AddOnUserLeaveHintListener(IRunnable listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("addOnUserLeaveHintListener.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetInitializeViewTreeOwnersHandler()
	{
		return new global::_JniMarshal_PP_V(n_InitializeViewTreeOwners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InitializeViewTreeOwners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitializeViewTreeOwners();
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

	[Register("initializeViewTreeOwners", "()V", "GetInitializeViewTreeOwnersHandler")]
	public unsafe virtual void InitializeViewTreeOwners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("initializeViewTreeOwners.()V", this, null);
	}

	private static Delegate GetInvalidateMenuHandler()
	{
		return new global::_JniMarshal_PP_V(n_InvalidateMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InvalidateMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateMenu();
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

	[Register("invalidateMenu", "()V", "GetInvalidateMenuHandler")]
	public unsafe virtual void InvalidateMenu()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateMenu.()V", this, null);
	}

	[Obsolete]
	private static Delegate GetOnRetainCustomNonConfigurationInstanceHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnRetainCustomNonConfigurationInstance);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnRetainCustomNonConfigurationInstance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRetainCustomNonConfigurationInstance());
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
	[Register("onRetainCustomNonConfigurationInstance", "()Ljava/lang/Object;", "GetOnRetainCustomNonConfigurationInstanceHandler")]
	public unsafe virtual Java.Lang.Object? OnRetainCustomNonConfigurationInstance()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("onRetainCustomNonConfigurationInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("onRetainNonConfigurationInstance", "()Ljava/lang/Object;", "")]
	public unsafe sealed override Java.Lang.Object? OnRetainNonConfigurationInstance()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("onRetainNonConfigurationInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPeekAvailableContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_PeekAvailableContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PeekAvailableContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeekAvailableContext());
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

	[Register("peekAvailableContext", "()Landroid/content/Context;", "GetPeekAvailableContextHandler")]
	public unsafe virtual Context? PeekAvailableContext()
	{
		return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("peekAvailableContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, IActivityResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contract);
			GC.KeepAlive(callback);
		}
	}

	[Register("registerForActivityResult", "(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher RegisterForActivityResult(ActivityResultContract contract, ActivityResultRegistry registry, IActivityResultCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(registry?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("registerForActivityResult.(Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultRegistry;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(contract);
			GC.KeepAlive(registry);
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetRemoveMenuProvider_Landroidx_core_view_MenuProvider_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveMenuProvider_Landroidx_core_view_MenuProvider_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveMenuProvider_Landroidx_core_view_MenuProvider_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ComponentActivity? componentActivity = Java.Lang.Object.GetObject<ComponentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			componentActivity.RemoveMenuProvider(provider);
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

	[Register("removeMenuProvider", "(Landroidx/core/view/MenuProvider;)V", "GetRemoveMenuProvider_Landroidx_core_view_MenuProvider_Handler")]
	public unsafe virtual void RemoveMenuProvider(IMenuProvider provider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeMenuProvider.(Landroidx/core/view/MenuProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
		}
	}

	[Register("removeOnConfigurationChangedListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void RemoveOnConfigurationChangedListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnConfigurationChangedListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("removeOnContextAvailableListener", "(Landroidx/activity/contextaware/OnContextAvailableListener;)V", "")]
	public unsafe void RemoveOnContextAvailableListener(IOnContextAvailableListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnContextAvailableListener.(Landroidx/activity/contextaware/OnContextAvailableListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("removeOnMultiWindowModeChangedListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void RemoveOnMultiWindowModeChangedListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnMultiWindowModeChangedListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("removeOnNewIntentListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void RemoveOnNewIntentListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnNewIntentListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("removeOnPictureInPictureModeChangedListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void RemoveOnPictureInPictureModeChangedListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnPictureInPictureModeChangedListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("removeOnTrimMemoryListener", "(Landroidx/core/util/Consumer;)V", "")]
	public unsafe void RemoveOnTrimMemoryListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnTrimMemoryListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("removeOnUserLeaveHintListener", "(Ljava/lang/Runnable;)V", "")]
	public unsafe void RemoveOnUserLeaveHintListener(IRunnable listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeOnUserLeaveHintListener.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private IOnContextAvailableListenerImplementor __CreateIOnContextAvailableListenerImplementor()
	{
		return new IOnContextAvailableListenerImplementor(this);
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Runtime;
using AndroidX.Lifecycle;
using AndroidX.SavedState;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity;

[Register("androidx/activity/ComponentDialog", DoNotGenerateAcw = true)]
public class ComponentDialog : Dialog, ILifecycleOwner, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/ComponentDialog", typeof(ComponentDialog));

	private static Delegate? cb_getLifecycle_GetLifecycle_Landroidx_lifecycle_Lifecycle_;

	private static Delegate? cb_getSavedStateRegistry_GetSavedStateRegistry_Landroidx_savedstate_SavedStateRegistry_;

	private static Delegate? cb_initializeViewTreeOwners_InitializeViewTreeOwners_V;

	private static Delegate? cb_getOnBackPressedDispatcher_GetOnBackPressedDispatcher_Landroidx_activity_OnBackPressedDispatcher_;

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

	public unsafe virtual AndroidX.Lifecycle.Lifecycle Lifecycle
	{
		[Register("getLifecycle", "()Landroidx/lifecycle/Lifecycle;", "GetGetLifecycleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLifecycle.()Landroidx/lifecycle/Lifecycle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual SavedStateRegistry SavedStateRegistry
	{
		[Register("getSavedStateRegistry", "()Landroidx/savedstate/SavedStateRegistry;", "GetGetSavedStateRegistryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SavedStateRegistry>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSavedStateRegistry.()Landroidx/savedstate/SavedStateRegistry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ComponentDialog(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ComponentDialog(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;I)V", "")]
	public unsafe ComponentDialog(Context context, int themeResId)
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
			ptr[1] = new JniArgumentValue(themeResId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetLifecycleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLifecycle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLifecycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Lifecycle);
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

	private static Delegate GetGetSavedStateRegistryHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSavedStateRegistry);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSavedStateRegistry(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SavedStateRegistry);
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
			Java.Lang.Object.GetObject<ComponentDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitializeViewTreeOwners();
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

	private static Delegate GetGetOnBackPressedDispatcherHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetOnBackPressedDispatcher);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOnBackPressedDispatcher(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ComponentDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetOnBackPressedDispatcher());
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

	[Register("getOnBackPressedDispatcher", "()Landroidx/activity/OnBackPressedDispatcher;", "GetGetOnBackPressedDispatcherHandler")]
	public unsafe virtual OnBackPressedDispatcher GetOnBackPressedDispatcher()
	{
		return Java.Lang.Object.GetObject<OnBackPressedDispatcher>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOnBackPressedDispatcher.()Landroidx/activity/OnBackPressedDispatcher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}

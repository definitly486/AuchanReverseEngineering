using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Activity;
using AndroidX.Core.App;
using AndroidX.Lifecycle;
using AndroidX.Loader.App;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentActivity", DoNotGenerateAcw = true)]
public class FragmentActivity : AndroidX.Activity.ComponentActivity, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentActivity", typeof(FragmentActivity));

	private static Delegate? cb_getSupportFragmentManager_GetSupportFragmentManager_Landroidx_fragment_app_FragmentManager_;

	private static Delegate? cb_getSupportLoaderManager_GetSupportLoaderManager_Landroidx_loader_app_LoaderManager_;

	private static Delegate? cb_onAttachFragment_OnAttachFragment_Landroidx_fragment_app_Fragment__V;

	private static Delegate? cb_onResumeFragments_OnResumeFragments_V;

	private static Delegate? cb_setEnterSharedElementCallback_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback__V;

	private static Delegate? cb_setExitSharedElementCallback_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback__V;

	private static Delegate? cb_startActivityFromFragment_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I_V;

	private static Delegate? cb_startActivityFromFragment_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle__V;

	private static Delegate? cb_startIntentSenderFromFragment_StartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle__V;

	private static Delegate? cb_supportFinishAfterTransition_SupportFinishAfterTransition_V;

	private static Delegate? cb_supportInvalidateOptionsMenu_SupportInvalidateOptionsMenu_V;

	private static Delegate? cb_supportPostponeEnterTransition_SupportPostponeEnterTransition_V;

	private static Delegate? cb_supportStartPostponedEnterTransition_SupportStartPostponedEnterTransition_V;

	public override AndroidX.Lifecycle.Lifecycle Lifecycle => base.Lifecycle;

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

	public unsafe virtual FragmentManager SupportFragmentManager
	{
		[Register("getSupportFragmentManager", "()Landroidx/fragment/app/FragmentManager;", "GetGetSupportFragmentManagerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FragmentManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportFragmentManager.()Landroidx/fragment/app/FragmentManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual LoaderManager SupportLoaderManager
	{
		[Register("getSupportLoaderManager", "()Landroidx/loader/app/LoaderManager;", "GetGetSupportLoaderManagerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LoaderManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportLoaderManager.()Landroidx/loader/app/LoaderManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected FragmentActivity(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FragmentActivity()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe FragmentActivity(int contentLayoutId)
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

	private static Delegate GetGetSupportFragmentManagerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportFragmentManager);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportFragmentManager(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportFragmentManager);
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
	private static Delegate GetGetSupportLoaderManagerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportLoaderManager);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportLoaderManager(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportLoaderManager);
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
	private static Delegate GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnAttachFragment_Landroidx_fragment_app_Fragment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAttachFragment_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentActivity? fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			fragmentActivity.OnAttachFragment(fragment);
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
	[Register("onAttachFragment", "(Landroidx/fragment/app/Fragment;)V", "GetOnAttachFragment_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual void OnAttachFragment(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachFragment.(Landroidx/fragment/app/Fragment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetOnResumeFragmentsHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnResumeFragments);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnResumeFragments(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnResumeFragments();
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

	[Register("onResumeFragments", "()V", "GetOnResumeFragmentsHandler")]
	protected unsafe virtual void OnResumeFragments()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onResumeFragments.()V", this, null);
	}

	private static Delegate GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentActivity? fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SharedElementCallback enterSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			fragmentActivity.SetEnterSharedElementCallback(enterSharedElementCallback);
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

	[Register("setEnterSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetEnterSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetEnterSharedElementCallback(SharedElementCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEnterSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentActivity? fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SharedElementCallback exitSharedElementCallback = Java.Lang.Object.GetObject<SharedElementCallback>(native_listener, JniHandleOwnership.DoNotTransfer);
			fragmentActivity.SetExitSharedElementCallback(exitSharedElementCallback);
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

	[Register("setExitSharedElementCallback", "(Landroidx/core/app/SharedElementCallback;)V", "GetSetExitSharedElementCallback_Landroidx_core_app_SharedElementCallback_Handler")]
	public unsafe virtual void SetExitSharedElementCallback(SharedElementCallback? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExitSharedElementCallback.(Landroidx/core/app/SharedElementCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_IHandler()
	{
		return new global::_JniMarshal_PPLLI_V(n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_I(nint jnienv, nint native__this, nint native_fragment, nint native_intent, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentActivity? fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			fragmentActivity.StartActivityFromFragment(fragment, intent, requestCode);
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

	[Register("startActivityFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/Intent;I)V", "GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_IHandler")]
	public unsafe virtual void StartActivityFromFragment(Fragment fragment, Intent intent, int requestCode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/Intent;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPLLIL_V(n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_fragment, nint native_intent, int requestCode, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentActivity? fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
			fragmentActivity.StartActivityFromFragment(fragment, intent, requestCode, options);
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

	[Register("startActivityFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V", "GetStartActivityFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartActivityFromFragment(Fragment fragment, Intent intent, int requestCode, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startActivityFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
			GC.KeepAlive(options);
		}
	}

	[Obsolete]
	private static Delegate GetStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPLLILIIIL_V(n_StartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_fragment, nint native_intent, int requestCode, nint native_fillInIntent, int flagsMask, int flagsValues, int extraFlags, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FragmentActivity? fragmentActivity = Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			IntentSender intent = Java.Lang.Object.GetObject<IntentSender>(native_intent, JniHandleOwnership.DoNotTransfer);
			Intent fillInIntent = Java.Lang.Object.GetObject<Intent>(native_fillInIntent, JniHandleOwnership.DoNotTransfer);
			Bundle options = Java.Lang.Object.GetObject<Bundle>(native_options, JniHandleOwnership.DoNotTransfer);
			fragmentActivity.StartIntentSenderFromFragment(fragment, intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
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
	[Register("startIntentSenderFromFragment", "(Landroidx/fragment/app/Fragment;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", "GetStartIntentSenderFromFragment_Landroidx_fragment_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler")]
	public unsafe virtual void StartIntentSenderFromFragment(Fragment fragment, IntentSender intent, int requestCode, Intent? fillInIntent, int flagsMask, int flagsValues, int extraFlags, Bundle? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(requestCode);
			ptr[3] = new JniArgumentValue(fillInIntent?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(flagsMask);
			ptr[5] = new JniArgumentValue(flagsValues);
			ptr[6] = new JniArgumentValue(extraFlags);
			ptr[7] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startIntentSenderFromFragment.(Landroidx/fragment/app/Fragment;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(intent);
			GC.KeepAlive(fillInIntent);
			GC.KeepAlive(options);
		}
	}

	private static Delegate GetSupportFinishAfterTransitionHandler()
	{
		return new global::_JniMarshal_PP_V(n_SupportFinishAfterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SupportFinishAfterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportFinishAfterTransition();
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

	[Register("supportFinishAfterTransition", "()V", "GetSupportFinishAfterTransitionHandler")]
	public unsafe virtual void SupportFinishAfterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportFinishAfterTransition.()V", this, null);
	}

	[Obsolete]
	private static Delegate GetSupportInvalidateOptionsMenuHandler()
	{
		return new global::_JniMarshal_PP_V(n_SupportInvalidateOptionsMenu);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SupportInvalidateOptionsMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportInvalidateOptionsMenu();
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
	[Register("supportInvalidateOptionsMenu", "()V", "GetSupportInvalidateOptionsMenuHandler")]
	public unsafe virtual void SupportInvalidateOptionsMenu()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportInvalidateOptionsMenu.()V", this, null);
	}

	private static Delegate GetSupportPostponeEnterTransitionHandler()
	{
		return new global::_JniMarshal_PP_V(n_SupportPostponeEnterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SupportPostponeEnterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportPostponeEnterTransition();
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

	[Register("supportPostponeEnterTransition", "()V", "GetSupportPostponeEnterTransitionHandler")]
	public unsafe virtual void SupportPostponeEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportPostponeEnterTransition.()V", this, null);
	}

	private static Delegate GetSupportStartPostponedEnterTransitionHandler()
	{
		return new global::_JniMarshal_PP_V(n_SupportStartPostponedEnterTransition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SupportStartPostponedEnterTransition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportStartPostponedEnterTransition();
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

	[Register("supportStartPostponedEnterTransition", "()V", "GetSupportStartPostponedEnterTransitionHandler")]
	public unsafe virtual void SupportStartPostponedEnterTransition()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("supportStartPostponedEnterTransition.()V", this, null);
	}

	[Obsolete("deprecated")]
	[Register("validateRequestPermissionsRequestCode", "(I)V", "")]
	public unsafe void ValidateRequestPermissionsRequestCode(int requestCode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(requestCode);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("validateRequestPermissionsRequestCode.(I)V", this, ptr);
	}
}

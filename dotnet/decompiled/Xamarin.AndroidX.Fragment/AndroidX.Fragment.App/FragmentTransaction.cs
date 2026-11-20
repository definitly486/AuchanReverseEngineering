using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentTransaction", DoNotGenerateAcw = true)]
public abstract class FragmentTransaction : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentTransaction", typeof(FragmentTransaction));

	private static Delegate? cb_isAddToBackStackAllowed_IsAddToBackStackAllowed_Z;

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_add_Add_Landroidx_fragment_app_Fragment_Ljava_lang_String__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_add_Add_ILandroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_add_Add_ILandroidx_fragment_app_Fragment_Ljava_lang_String__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_addSharedElement_AddSharedElement_Landroid_view_View_Ljava_lang_String__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_addToBackStack_AddToBackStack_Ljava_lang_String__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_attach_Attach_Landroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_commit_Commit_I;

	private static Delegate? cb_commitAllowingStateLoss_CommitAllowingStateLoss_I;

	private static Delegate? cb_commitNow_CommitNow_V;

	private static Delegate? cb_commitNowAllowingStateLoss_CommitNowAllowingStateLoss_V;

	private static Delegate? cb_detach_Detach_Landroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_disallowAddToBackStack_DisallowAddToBackStack_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_hide_Hide_Landroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_remove_Remove_Landroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_replace_Replace_ILandroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_replace_Replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_runOnCommit_RunOnCommit_Ljava_lang_Runnable__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setAllowOptimization_SetAllowOptimization_Z_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setBreadCrumbShortTitle_SetBreadCrumbShortTitle_I_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setBreadCrumbShortTitle_SetBreadCrumbShortTitle_Ljava_lang_CharSequence__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setBreadCrumbTitle_SetBreadCrumbTitle_I_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setBreadCrumbTitle_SetBreadCrumbTitle_Ljava_lang_CharSequence__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setCustomAnimations_SetCustomAnimations_II_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setCustomAnimations_SetCustomAnimations_IIII_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setMaxLifecycle_SetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setPrimaryNavigationFragment_SetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setReorderingAllowed_SetReorderingAllowed_Z_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setTransition_SetTransition_I_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_setTransitionStyle_SetTransitionStyle_I_Landroidx_fragment_app_FragmentTransaction_;

	private static Delegate? cb_show_Show_Landroidx_fragment_app_Fragment__Landroidx_fragment_app_FragmentTransaction_;

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

	public unsafe virtual bool IsAddToBackStackAllowed
	{
		[Register("isAddToBackStackAllowed", "()Z", "GetIsAddToBackStackAllowedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAddToBackStackAllowed.()Z", this, null);
		}
	}

	public unsafe virtual bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	protected FragmentTransaction(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	[Obsolete("deprecated")]
	public unsafe FragmentTransaction()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetIsAddToBackStackAllowedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAddToBackStackAllowed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAddToBackStackAllowed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAddToBackStackAllowed ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsEmptyHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEmpty);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmpty(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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

	[Register("add", "(Landroid/view/ViewGroup;Landroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Add(ViewGroup container, Fragment fragment, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Landroid/view/ViewGroup;Landroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(container);
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetAdd_Landroidx_fragment_app_Fragment_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Add_Landroidx_fragment_app_Fragment_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_Landroidx_fragment_app_Fragment_Ljava_lang_String_(nint jnienv, nint native__this, nint native_fragment, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Add(fragment, tag));
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

	[Register("add", "(Landroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAdd_Landroidx_fragment_app_Fragment_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction Add(Fragment fragment, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(Landroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetAdd_ILandroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_Add_ILandroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_ILandroidx_fragment_app_Fragment_(nint jnienv, nint native__this, int containerViewId, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Add(containerViewId, fragment));
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

	[Register("add", "(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetAdd_ILandroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Add(int containerViewId, Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetAdd_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPILL_L(n_Add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_ILandroidx_fragment_app_Fragment_Ljava_lang_String_(nint jnienv, nint native__this, int containerViewId, nint native_fragment, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Add(containerViewId, fragment, tag));
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

	[Register("add", "(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAdd_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction Add(int containerViewId, Fragment fragment, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(fragment);
		}
	}

	[Register("add", "(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Add(int containerViewId, Class fragmentClass, Bundle? args)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	[Register("add", "(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Add(int containerViewId, Class fragmentClass, Bundle? args, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	[Register("add", "(Ljava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Add(Class fragmentClass, Bundle? args, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("add.(Ljava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetAddSharedElement_Landroid_view_View_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddSharedElement_Landroid_view_View_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSharedElement_Landroid_view_View_Ljava_lang_String_(nint jnienv, nint native__this, nint native_sharedElement, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View sharedElement = Java.Lang.Object.GetObject<View>(native_sharedElement, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.AddSharedElement(sharedElement, name));
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

	[Register("addSharedElement", "(Landroid/view/View;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAddSharedElement_Landroid_view_View_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction AddSharedElement(View sharedElement, string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(sharedElement?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSharedElement.(Landroid/view/View;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(sharedElement);
		}
	}

	private static Delegate GetAddToBackStack_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddToBackStack_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddToBackStack_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.AddToBackStack(name));
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

	[Register("addToBackStack", "(Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetAddToBackStack_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction AddToBackStack(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("addToBackStack.(Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetAttach_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Attach_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Attach_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Attach(fragment));
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

	[Register("attach", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetAttach_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Attach(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("attach.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetCommitHandler()
	{
		return new global::_JniMarshal_PP_I(n_Commit);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Commit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Commit();
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

	[Register("commit", "()I", "GetCommitHandler")]
	public abstract int Commit();

	private static Delegate GetCommitAllowingStateLossHandler()
	{
		return new global::_JniMarshal_PP_I(n_CommitAllowingStateLoss);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CommitAllowingStateLoss(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitAllowingStateLoss();
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

	[Register("commitAllowingStateLoss", "()I", "GetCommitAllowingStateLossHandler")]
	public abstract int CommitAllowingStateLoss();

	private static Delegate GetCommitNowHandler()
	{
		return new global::_JniMarshal_PP_V(n_CommitNow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CommitNow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitNow();
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

	[Register("commitNow", "()V", "GetCommitNowHandler")]
	public abstract void CommitNow();

	private static Delegate GetCommitNowAllowingStateLossHandler()
	{
		return new global::_JniMarshal_PP_V(n_CommitNowAllowingStateLoss);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CommitNowAllowingStateLoss(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CommitNowAllowingStateLoss();
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

	[Register("commitNowAllowingStateLoss", "()V", "GetCommitNowAllowingStateLossHandler")]
	public abstract void CommitNowAllowingStateLoss();

	private static Delegate GetDetach_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Detach_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Detach_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Detach(fragment));
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

	[Register("detach", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetDetach_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Detach(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("detach.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetDisallowAddToBackStackHandler()
	{
		return new global::_JniMarshal_PP_L(n_DisallowAddToBackStack);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_DisallowAddToBackStack(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisallowAddToBackStack());
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

	[Register("disallowAddToBackStack", "()Landroidx/fragment/app/FragmentTransaction;", "GetDisallowAddToBackStackHandler")]
	public unsafe virtual FragmentTransaction DisallowAddToBackStack()
	{
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("disallowAddToBackStack.()Landroidx/fragment/app/FragmentTransaction;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetHide_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Hide_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Hide_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Hide(fragment));
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

	[Register("hide", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetHide_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Hide(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("hide.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetRemove_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Remove_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Remove_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Remove(fragment));
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

	[Register("remove", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetRemove_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Remove(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("remove.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetReplace_ILandroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_Replace_ILandroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Replace_ILandroidx_fragment_app_Fragment_(nint jnienv, nint native__this, int containerViewId, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Replace(containerViewId, fragment));
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

	[Register("replace", "(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetReplace_ILandroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Replace(int containerViewId, Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(ILandroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetReplace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPILL_L(n_Replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Replace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_(nint jnienv, nint native__this, int containerViewId, nint native_fragment, nint native_tag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Replace(containerViewId, fragment, tag));
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

	[Register("replace", "(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "GetReplace_ILandroidx_fragment_app_Fragment_Ljava_lang_String_Handler")]
	public unsafe virtual FragmentTransaction Replace(int containerViewId, Fragment fragment, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(ILandroidx/fragment/app/Fragment;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(fragment);
		}
	}

	[Register("replace", "(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Replace(int containerViewId, Class fragmentClass, Bundle? args)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("replace.(ILjava/lang/Class;Landroid/os/Bundle;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	[Register("replace", "(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", "")]
	public unsafe FragmentTransaction Replace(int containerViewId, Class fragmentClass, Bundle? args, string? tag)
	{
		nint num = JNIEnv.NewString(tag);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(containerViewId);
			ptr[1] = new JniArgumentValue(fragmentClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("replace.(ILjava/lang/Class;Landroid/os/Bundle;Ljava/lang/String;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(fragmentClass);
			GC.KeepAlive(args);
		}
	}

	private static Delegate GetRunOnCommit_Ljava_lang_Runnable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_RunOnCommit_Ljava_lang_Runnable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RunOnCommit_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_runnable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable runnable = Java.Lang.Object.GetObject<IRunnable>(native_runnable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.RunOnCommit(runnable));
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

	[Register("runOnCommit", "(Ljava/lang/Runnable;)Landroidx/fragment/app/FragmentTransaction;", "GetRunOnCommit_Ljava_lang_Runnable_Handler")]
	public unsafe virtual FragmentTransaction RunOnCommit(IRunnable runnable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("runOnCommit.(Ljava/lang/Runnable;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(runnable);
		}
	}

	[Obsolete]
	private static Delegate GetSetAllowOptimization_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_SetAllowOptimization_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetAllowOptimization_Z(nint jnienv, nint native__this, sbyte native_allowOptimization)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool allowOptimization = native_allowOptimization != 0;
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetAllowOptimization(allowOptimization));
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
	[Register("setAllowOptimization", "(Z)Landroidx/fragment/app/FragmentTransaction;", "GetSetAllowOptimization_ZHandler")]
	public unsafe virtual FragmentTransaction SetAllowOptimization(bool allowOptimization)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(allowOptimization ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAllowOptimization.(Z)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetSetBreadCrumbShortTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetBreadCrumbShortTitle_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetBreadCrumbShortTitle_I(nint jnienv, nint native__this, int res)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBreadCrumbShortTitle(res));
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
	[Register("setBreadCrumbShortTitle", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbShortTitle_IHandler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbShortTitle(int res)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(res);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbShortTitle.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetSetBreadCrumbShortTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetBreadCrumbShortTitle_Ljava_lang_CharSequence_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetBreadCrumbShortTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence breadCrumbShortTitle = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetBreadCrumbShortTitle(breadCrumbShortTitle));
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
	[Register("setBreadCrumbShortTitle", "(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbShortTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbShortTitle(ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbShortTitle.(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	[Obsolete("deprecated")]
	public FragmentTransaction SetBreadCrumbShortTitle(string? text)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		FragmentTransaction result = SetBreadCrumbShortTitle(obj);
		obj?.Dispose();
		return result;
	}

	[Obsolete]
	private static Delegate GetSetBreadCrumbTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetBreadCrumbTitle_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetBreadCrumbTitle_I(nint jnienv, nint native__this, int res)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBreadCrumbTitle(res));
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
	[Register("setBreadCrumbTitle", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbTitle_IHandler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbTitle(int res)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(res);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbTitle.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetSetBreadCrumbTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetBreadCrumbTitle_Ljava_lang_CharSequence_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetBreadCrumbTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence breadCrumbTitle = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetBreadCrumbTitle(breadCrumbTitle));
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
	[Register("setBreadCrumbTitle", "(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", "GetSetBreadCrumbTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual FragmentTransaction SetBreadCrumbTitle(ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setBreadCrumbTitle.(Ljava/lang/CharSequence;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	[Obsolete("deprecated")]
	public FragmentTransaction SetBreadCrumbTitle(string? text)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		FragmentTransaction result = SetBreadCrumbTitle(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetSetCustomAnimations_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_SetCustomAnimations_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetCustomAnimations_II(nint jnienv, nint native__this, int enter, int exit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomAnimations(enter, exit));
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

	[Register("setCustomAnimations", "(II)Landroidx/fragment/app/FragmentTransaction;", "GetSetCustomAnimations_IIHandler")]
	public unsafe virtual FragmentTransaction SetCustomAnimations(int enter, int exit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(enter);
		ptr[1] = new JniArgumentValue(exit);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCustomAnimations.(II)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetCustomAnimations_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_L(n_SetCustomAnimations_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetCustomAnimations_IIII(nint jnienv, nint native__this, int enter, int exit, int popEnter, int popExit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomAnimations(enter, exit, popEnter, popExit));
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

	[Register("setCustomAnimations", "(IIII)Landroidx/fragment/app/FragmentTransaction;", "GetSetCustomAnimations_IIIIHandler")]
	public unsafe virtual FragmentTransaction SetCustomAnimations(int enter, int exit, int popEnter, int popExit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(enter);
		ptr[1] = new JniArgumentValue(exit);
		ptr[2] = new JniArgumentValue(popEnter);
		ptr[3] = new JniArgumentValue(popExit);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCustomAnimations.(IIII)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_SetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_(nint jnienv, nint native__this, nint native_fragment, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			AndroidX.Lifecycle.Lifecycle.State state = Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle.State>(native_state, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetMaxLifecycle(fragment, state));
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

	[Register("setMaxLifecycle", "(Landroidx/fragment/app/Fragment;Landroidx/lifecycle/Lifecycle$State;)Landroidx/fragment/app/FragmentTransaction;", "GetSetMaxLifecycle_Landroidx_fragment_app_Fragment_Landroidx_lifecycle_Lifecycle_State_Handler")]
	public unsafe virtual FragmentTransaction SetMaxLifecycle(Fragment fragment, AndroidX.Lifecycle.Lifecycle.State state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMaxLifecycle.(Landroidx/fragment/app/Fragment;Landroidx/lifecycle/Lifecycle$State;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetSetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment primaryNavigationFragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetPrimaryNavigationFragment(primaryNavigationFragment));
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

	[Register("setPrimaryNavigationFragment", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetSetPrimaryNavigationFragment_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction SetPrimaryNavigationFragment(Fragment? fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPrimaryNavigationFragment.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	private static Delegate GetSetReorderingAllowed_ZHandler()
	{
		return new global::_JniMarshal_PPB_L(n_SetReorderingAllowed_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetReorderingAllowed_Z(nint jnienv, nint native__this, sbyte native_reorderingAllowed)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool reorderingAllowed = native_reorderingAllowed != 0;
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.SetReorderingAllowed(reorderingAllowed));
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

	[Register("setReorderingAllowed", "(Z)Landroidx/fragment/app/FragmentTransaction;", "GetSetReorderingAllowed_ZHandler")]
	public unsafe virtual FragmentTransaction SetReorderingAllowed(bool reorderingAllowed)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(reorderingAllowed ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setReorderingAllowed.(Z)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTransition_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetTransition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTransition_I(nint jnienv, nint native__this, int transit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransition(transit));
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

	[Register("setTransition", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetTransition_IHandler")]
	public unsafe virtual FragmentTransaction SetTransition(int transit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(transit);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTransition.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetSetTransitionStyle_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetTransitionStyle_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTransitionStyle_I(nint jnienv, nint native__this, int styleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransitionStyle(styleRes));
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
	[Register("setTransitionStyle", "(I)Landroidx/fragment/app/FragmentTransaction;", "GetSetTransitionStyle_IHandler")]
	public unsafe virtual FragmentTransaction SetTransitionStyle(int styleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(styleRes);
		return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTransitionStyle.(I)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetShow_Landroidx_fragment_app_Fragment_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Show_Landroidx_fragment_app_Fragment_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Show_Landroidx_fragment_app_Fragment_(nint jnienv, nint native__this, nint native_fragment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FragmentTransaction? fragmentTransaction = Java.Lang.Object.GetObject<FragmentTransaction>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Fragment fragment = Java.Lang.Object.GetObject<Fragment>(native_fragment, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fragmentTransaction.Show(fragment));
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

	[Register("show", "(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", "GetShow_Landroidx_fragment_app_Fragment_Handler")]
	public unsafe virtual FragmentTransaction Show(Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FragmentTransaction>(_members.InstanceMethods.InvokeVirtualObjectMethod("show.(Landroidx/fragment/app/Fragment;)Landroidx/fragment/app/FragmentTransaction;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}
}

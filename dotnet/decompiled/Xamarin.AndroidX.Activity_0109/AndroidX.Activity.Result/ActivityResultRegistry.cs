using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Activity.Result.Contract;
using AndroidX.Core.App;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.Result;

[Register("androidx/activity/result/ActivityResultRegistry", DoNotGenerateAcw = true)]
public abstract class ActivityResultRegistry : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultRegistry", typeof(ActivityResultRegistry));

	private static Delegate? cb_onLaunch_OnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat__V;

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

	protected ActivityResultRegistry(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ActivityResultRegistry()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("dispatchResult", "(IILandroid/content/Intent;)Z", "")]
	public unsafe bool DispatchResult(int requestCode, int resultCode, Intent? data)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(resultCode);
			ptr[2] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("dispatchResult.(IILandroid/content/Intent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(data);
		}
	}

	[Register("dispatchResult", "(ILjava/lang/Object;)Z", "")]
	[JavaTypeParameters(new string[] { "O" })]
	public unsafe bool DispatchResult(int requestCode, Java.Lang.Object? result)
	{
		nint num = JNIEnv.ToLocalJniHandle(result);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("dispatchResult.(ILjava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(result);
		}
	}

	private static Delegate GetOnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler()
	{
		return new global::_JniMarshal_PPILLL_V(n_OnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_(nint jnienv, nint native__this, int requestCode, nint native_contract, nint native_input, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActivityResultRegistry? activityResultRegistry = Java.Lang.Object.GetObject<ActivityResultRegistry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActivityResultContract contract = Java.Lang.Object.GetObject<ActivityResultContract>(native_contract, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			ActivityOptionsCompat options = Java.Lang.Object.GetObject<ActivityOptionsCompat>(native_options, JniHandleOwnership.DoNotTransfer);
			activityResultRegistry.OnLaunch(requestCode, contract, input, options);
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

	[Register("onLaunch", "(ILandroidx/activity/result/contract/ActivityResultContract;Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetOnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public abstract void OnLaunch(int requestCode, ActivityResultContract contract, Java.Lang.Object? input, ActivityOptionsCompat? options);

	[Register("onRestoreInstanceState", "(Landroid/os/Bundle;)V", "")]
	public unsafe void OnRestoreInstanceState(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	[Register("onSaveInstanceState", "(Landroid/os/Bundle;)V", "")]
	public unsafe void OnSaveInstanceState(Bundle outState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onSaveInstanceState.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outState);
		}
	}

	[Register("register", "(Ljava/lang/String;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher Register(string key, ActivityResultContract contract, IActivityResultCallback callback)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("register.(Ljava/lang/String;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(contract);
			GC.KeepAlive(callback);
		}
	}

	[Register("register", "(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", "")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe ActivityResultLauncher Register(string key, ILifecycleOwner lifecycleOwner, ActivityResultContract contract, IActivityResultCallback callback)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((lifecycleOwner == null) ? IntPtr.Zero : ((Java.Lang.Object)lifecycleOwner).Handle);
			ptr[2] = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActivityResultLauncher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("register.(Ljava/lang/String;Landroidx/lifecycle/LifecycleOwner;Landroidx/activity/result/contract/ActivityResultContract;Landroidx/activity/result/ActivityResultCallback;)Landroidx/activity/result/ActivityResultLauncher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(lifecycleOwner);
			GC.KeepAlive(contract);
			GC.KeepAlive(callback);
		}
	}
}

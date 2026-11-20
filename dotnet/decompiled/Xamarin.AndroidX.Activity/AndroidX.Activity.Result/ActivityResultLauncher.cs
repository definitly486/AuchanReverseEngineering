using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Activity.Result.Contract;
using AndroidX.Core.App;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.Result;

[Register("androidx/activity/result/ActivityResultLauncher", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "I" })]
public abstract class ActivityResultLauncher : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultLauncher", typeof(ActivityResultLauncher));

	private static Delegate? cb_getContract_GetContract_Landroidx_activity_result_contract_ActivityResultContract_;

	private static Delegate? cb_launch_Launch_Ljava_lang_Object__V;

	private static Delegate? cb_launch_Launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat__V;

	private static Delegate? cb_unregister_Unregister_V;

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

	protected abstract ActivityResultContract RawContract
	{
		[Register("getContract", "()Landroidx/activity/result/contract/ActivityResultContract;", "GetGetContractHandler")]
		get;
	}

	protected ActivityResultLauncher(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ActivityResultLauncher()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetContractHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContract);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContract(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RawContract);
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

	private static Delegate GetLaunch_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Launch_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Launch_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_input)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActivityResultLauncher? activityResultLauncher = Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			activityResultLauncher.Launch(input);
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

	[Register("launch", "(Ljava/lang/Object;)V", "GetLaunch_Ljava_lang_Object_Handler")]
	public unsafe virtual void Launch(Java.Lang.Object? input)
	{
		nint num = JNIEnv.ToLocalJniHandle(input);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("launch.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(input);
		}
	}

	private static Delegate GetLaunch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Launch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_(nint jnienv, nint native__this, nint native_input, nint native_options)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActivityResultLauncher? activityResultLauncher = Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object input = Java.Lang.Object.GetObject<Java.Lang.Object>(native_input, JniHandleOwnership.DoNotTransfer);
			ActivityOptionsCompat options = Java.Lang.Object.GetObject<ActivityOptionsCompat>(native_options, JniHandleOwnership.DoNotTransfer);
			activityResultLauncher.Launch(input, options);
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

	[Register("launch", "(Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetLaunch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
	public abstract void Launch(Java.Lang.Object? input, ActivityOptionsCompat? options);

	private static Delegate GetUnregisterHandler()
	{
		return new global::_JniMarshal_PP_V(n_Unregister);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Unregister(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActivityResultLauncher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Unregister();
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

	[Register("unregister", "()V", "GetUnregisterHandler")]
	public abstract void Unregister();
}

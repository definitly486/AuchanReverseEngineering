using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace Android.Gms.Tasks;

[Preserve]
[Register("com/google/android/gms/tasks/Task", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "TResult" })]
public abstract class Task : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/Task", typeof(Task));

	private static Delegate? cb_getException_GetException_Ljava_lang_Exception_;

	private static Delegate? cb_isCanceled_IsCanceled_Z;

	private static Delegate? cb_isComplete_IsComplete_Z;

	private static Delegate? cb_isSuccessful_IsSuccessful_Z;

	private static Delegate? cb_getResult_GetResult_Ljava_lang_Object_;

	private static Delegate? cb_addOnCanceledListener_AddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnCanceledListener_AddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnCanceledListener_AddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnCompleteListener_AddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnCompleteListener_AddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnCompleteListener_AddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnFailureListener_AddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnFailureListener_AddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnFailureListener_AddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnSuccessListener_AddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnSuccessListener_AddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_addOnSuccessListener_AddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_continueWith_ContinueWith_Lcom_google_android_gms_tasks_Continuation__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_continueWith_ContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_continueWithTask_ContinueWithTask_Lcom_google_android_gms_tasks_Continuation__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_continueWithTask_ContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_getResult_GetResult_Ljava_lang_Class__Ljava_lang_Object_;

	private static Delegate? cb_onSuccessTask_OnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation__Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_onSuccessTask_OnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation__Lcom_google_android_gms_tasks_Task_;

	[Preserve]
	public virtual Java.Lang.Object Result => RawResult;

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

	public abstract Java.Lang.Exception? Exception
	{
		[Register("getException", "()Ljava/lang/Exception;", "GetGetExceptionHandler")]
		get;
	}

	public abstract bool IsCanceled
	{
		[Register("isCanceled", "()Z", "GetIsCanceledHandler")]
		get;
	}

	public abstract bool IsComplete
	{
		[Register("isComplete", "()Z", "GetIsCompleteHandler")]
		get;
	}

	public abstract bool IsSuccessful
	{
		[Register("isSuccessful", "()Z", "GetIsSuccessfulHandler")]
		get;
	}

	protected abstract Java.Lang.Object? RawResult
	{
		[Register("getResult", "()Ljava/lang/Object;", "GetGetResultHandler")]
		get;
	}

	protected Task(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Task()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetExceptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetException);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetException(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Exception);
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

	private static Delegate GetIsCanceledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCanceled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCanceled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCanceled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsCompleteHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsComplete);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsComplete(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsComplete ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsSuccessfulHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSuccessful);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSuccessful(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSuccessful ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetResultHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetResult);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResult(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RawResult);
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

	private static Delegate GetAddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCanceledListener p2 = Java.Lang.Object.GetObject<IOnCanceledListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCanceledListener(p, p2));
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

	[Register("addOnCanceledListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCanceledListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCanceledListener_Handler")]
	public unsafe virtual Task AddOnCanceledListener(Activity p0, IOnCanceledListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCanceledListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetAddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCanceledListener p = Java.Lang.Object.GetObject<IOnCanceledListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCanceledListener(p));
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

	[Register("addOnCanceledListener", "(Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCanceledListener_Lcom_google_android_gms_tasks_OnCanceledListener_Handler")]
	public unsafe virtual Task AddOnCanceledListener(IOnCanceledListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCanceledListener.(Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCanceledListener p2 = Java.Lang.Object.GetObject<IOnCanceledListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCanceledListener(p, p2));
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

	[Register("addOnCanceledListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCanceledListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCanceledListener_Handler")]
	public unsafe virtual Task AddOnCanceledListener(IExecutor p0, IOnCanceledListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCanceledListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCanceledListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetAddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCompleteListener p2 = Java.Lang.Object.GetObject<IOnCompleteListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCompleteListener(p, p2));
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

	[Register("addOnCompleteListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCompleteListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnCompleteListener_Handler")]
	public unsafe virtual Task AddOnCompleteListener(Activity p0, IOnCompleteListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCompleteListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetAddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnCompleteListener p = Java.Lang.Object.GetObject<IOnCompleteListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCompleteListener(p));
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

	[Register("addOnCompleteListener", "(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCompleteListener_Lcom_google_android_gms_tasks_OnCompleteListener_Handler")]
	public unsafe virtual Task AddOnCompleteListener(IOnCompleteListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCompleteListener.(Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnCompleteListener p2 = Java.Lang.Object.GetObject<IOnCompleteListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnCompleteListener(p, p2));
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

	[Register("addOnCompleteListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnCompleteListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnCompleteListener_Handler")]
	public unsafe virtual Task AddOnCompleteListener(IExecutor p0, IOnCompleteListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOnCompleteListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnCompleteListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetAddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnFailureListener p2 = Java.Lang.Object.GetObject<IOnFailureListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnFailureListener(p, p2));
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

	[Register("addOnFailureListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
	public abstract Task AddOnFailureListener(Activity p0, IOnFailureListener p1);

	private static Delegate GetAddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnFailureListener p = Java.Lang.Object.GetObject<IOnFailureListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnFailureListener(p));
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

	[Register("addOnFailureListener", "(Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
	public abstract Task AddOnFailureListener(IOnFailureListener p0);

	private static Delegate GetAddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnFailureListener p2 = Java.Lang.Object.GetObject<IOnFailureListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnFailureListener(p, p2));
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

	[Register("addOnFailureListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
	public abstract Task AddOnFailureListener(IExecutor p0, IOnFailureListener p1);

	private static Delegate GetAddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnSuccessListener p2 = Java.Lang.Object.GetObject<IOnSuccessListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnSuccessListener(p, p2));
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

	[Register("addOnSuccessListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
	public abstract Task AddOnSuccessListener(Activity p0, IOnSuccessListener p1);

	private static Delegate GetAddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnSuccessListener p = Java.Lang.Object.GetObject<IOnSuccessListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnSuccessListener(p));
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

	[Register("addOnSuccessListener", "(Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
	public abstract Task AddOnSuccessListener(IOnSuccessListener p0);

	private static Delegate GetAddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_AddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IOnSuccessListener p2 = Java.Lang.Object.GetObject<IOnSuccessListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.AddOnSuccessListener(p, p2));
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

	[Register("addOnSuccessListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
	public abstract Task AddOnSuccessListener(IExecutor p0, IOnSuccessListener p1);

	private static Delegate GetContinueWith_Lcom_google_android_gms_tasks_Continuation_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_ContinueWith_Lcom_google_android_gms_tasks_Continuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ContinueWith_Lcom_google_android_gms_tasks_Continuation_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWith(p));
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

	[Register("continueWith", "(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWith_Lcom_google_android_gms_tasks_Continuation_Handler")]
	[JavaTypeParameters(new string[] { "TContinuationResult" })]
	public unsafe virtual Task ContinueWith(IContinuation p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWith.(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_ContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IContinuation p2 = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWith(p, p2));
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

	[Register("continueWith", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWith_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler")]
	[JavaTypeParameters(new string[] { "TContinuationResult" })]
	public unsafe virtual Task ContinueWith(IExecutor p0, IContinuation p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWith.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetContinueWithTask_Lcom_google_android_gms_tasks_Continuation_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_ContinueWithTask_Lcom_google_android_gms_tasks_Continuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ContinueWithTask_Lcom_google_android_gms_tasks_Continuation_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWithTask(p));
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

	[Register("continueWithTask", "(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWithTask_Lcom_google_android_gms_tasks_Continuation_Handler")]
	[JavaTypeParameters(new string[] { "TContinuationResult" })]
	public unsafe virtual Task ContinueWithTask(IContinuation p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWithTask.(Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_ContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			IContinuation p2 = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.ContinueWithTask(p, p2));
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

	[Register("continueWithTask", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", "GetContinueWithTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_Continuation_Handler")]
	[JavaTypeParameters(new string[] { "TContinuationResult" })]
	public unsafe virtual Task ContinueWithTask(IExecutor p0, IContinuation p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("continueWithTask.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/Continuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetGetResult_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetResult_Ljava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetResult_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class p = Java.Lang.Object.GetObject<Class>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.GetResult(p));
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

	[Register("getResult", "(Ljava/lang/Class;)Ljava/lang/Object;", "GetGetResult_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "X extends java.lang.Throwable" })]
	public abstract Java.Lang.Object? GetResult(Class p0);

	private static Delegate GetOnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_OnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISuccessContinuation p = Java.Lang.Object.GetObject<ISuccessContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.OnSuccessTask(p));
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

	[Register("onSuccessTask", "(Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", "GetOnSuccessTask_Lcom_google_android_gms_tasks_SuccessContinuation_Handler")]
	[JavaTypeParameters(new string[] { "TContinuationResult" })]
	public unsafe virtual Task OnSuccessTask(ISuccessContinuation p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSuccessTask.(Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_OnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Task? task = Java.Lang.Object.GetObject<Task>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
			ISuccessContinuation p2 = Java.Lang.Object.GetObject<ISuccessContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(task.OnSuccessTask(p, p2));
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

	[Register("onSuccessTask", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", "GetOnSuccessTask_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_SuccessContinuation_Handler")]
	[JavaTypeParameters(new string[] { "TContinuationResult" })]
	public unsafe virtual Task OnSuccessTask(IExecutor p0, ISuccessContinuation p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSuccessTask.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/SuccessContinuation;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}
}

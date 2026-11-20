using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Preserve]
[Register("com/google/android/gms/tasks/TaskCompletionSource", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "TResult" })]
public class TaskCompletionSource : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/TaskCompletionSource", typeof(TaskCompletionSource));

	private static Delegate? cb_getTask_GetTask_Lcom_google_android_gms_tasks_Task_;

	private static Delegate? cb_setException_SetException_Ljava_lang_Exception__V;

	private static Delegate? cb_setResult_SetResult_Ljava_lang_Object__V;

	private static Delegate? cb_trySetException_TrySetException_Ljava_lang_Exception__Z;

	private static Delegate? cb_trySetResult_TrySetResult_Ljava_lang_Object__Z;

	[Preserve]
	public virtual Task Task => GetTask();

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

	protected TaskCompletionSource(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe TaskCompletionSource()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/google/android/gms/tasks/CancellationToken;)V", "")]
	public unsafe TaskCompletionSource(CancellationToken cancellationToken)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cancellationToken?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/gms/tasks/CancellationToken;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/gms/tasks/CancellationToken;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cancellationToken);
		}
	}

	private static Delegate GetGetTaskHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTask);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTask(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTask());
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

	[Register("getTask", "()Lcom/google/android/gms/tasks/Task;", "GetGetTaskHandler")]
	public unsafe virtual Task GetTask()
	{
		return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTask.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetException_Ljava_lang_Exception_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetException_Ljava_lang_Exception_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetException_Ljava_lang_Exception_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TaskCompletionSource? taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception exception = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			taskCompletionSource.SetException(exception);
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

	[Register("setException", "(Ljava/lang/Exception;)V", "GetSetException_Ljava_lang_Exception_Handler")]
	public unsafe virtual void SetException(Java.Lang.Exception e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setException.(Ljava/lang/Exception;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetSetResult_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetResult_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetResult_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_result)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TaskCompletionSource? taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			taskCompletionSource.SetResult(result);
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

	[Register("setResult", "(Ljava/lang/Object;)V", "GetSetResult_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetResult(Java.Lang.Object? result)
	{
		nint num = JNIEnv.ToLocalJniHandle(result);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setResult.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(result);
		}
	}

	private static Delegate GetTrySetException_Ljava_lang_Exception_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_TrySetException_Ljava_lang_Exception_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_TrySetException_Ljava_lang_Exception_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			TaskCompletionSource? taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception e = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_e, JniHandleOwnership.DoNotTransfer);
			return taskCompletionSource.TrySetException(e) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("trySetException", "(Ljava/lang/Exception;)Z", "GetTrySetException_Ljava_lang_Exception_Handler")]
	public unsafe virtual bool TrySetException(Java.Lang.Exception e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("trySetException.(Ljava/lang/Exception;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetTrySetResult_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_TrySetResult_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_TrySetResult_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_result)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			TaskCompletionSource? taskCompletionSource = Java.Lang.Object.GetObject<TaskCompletionSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			return taskCompletionSource.TrySetResult(result) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("trySetResult", "(Ljava/lang/Object;)Z", "GetTrySetResult_Ljava_lang_Object_Handler")]
	public unsafe virtual bool TrySetResult(Java.Lang.Object? result)
	{
		nint num = JNIEnv.ToLocalJniHandle(result);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("trySetResult.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(result);
		}
	}
}

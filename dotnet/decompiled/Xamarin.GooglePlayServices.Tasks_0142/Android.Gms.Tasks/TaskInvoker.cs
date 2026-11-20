using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/Task", DoNotGenerateAcw = true)]
internal class TaskInvoker : Task
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/Task", typeof(TaskInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override Java.Lang.Exception? Exception
	{
		[Register("getException", "()Ljava/lang/Exception;", "GetGetExceptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Exception>(_members.InstanceMethods.InvokeAbstractObjectMethod("getException.()Ljava/lang/Exception;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override bool IsCanceled
	{
		[Register("isCanceled", "()Z", "GetIsCanceledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCanceled.()Z", this, null);
		}
	}

	public unsafe override bool IsComplete
	{
		[Register("isComplete", "()Z", "GetIsCompleteHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isComplete.()Z", this, null);
		}
	}

	public unsafe override bool IsSuccessful
	{
		[Register("isSuccessful", "()Z", "GetIsSuccessfulHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isSuccessful.()Z", this, null);
		}
	}

	protected unsafe override Java.Lang.Object? RawResult
	{
		[Register("getResult", "()Ljava/lang/Object;", "GetGetResultHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResult.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public TaskInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("addOnFailureListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
	public unsafe override Task AddOnFailureListener(Activity p0, IOnFailureListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnFailureListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Register("addOnFailureListener", "(Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
	public unsafe override Task AddOnFailureListener(IOnFailureListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnFailureListener.(Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("addOnFailureListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnFailureListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnFailureListener_Handler")]
	public unsafe override Task AddOnFailureListener(IExecutor p0, IOnFailureListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnFailureListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnFailureListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Register("addOnSuccessListener", "(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Landroid_app_Activity_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
	public unsafe override Task AddOnSuccessListener(Activity p0, IOnSuccessListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnSuccessListener.(Landroid/app/Activity;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Register("addOnSuccessListener", "(Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
	public unsafe override Task AddOnSuccessListener(IOnSuccessListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnSuccessListener.(Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("addOnSuccessListener", "(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", "GetAddOnSuccessListener_Ljava_util_concurrent_Executor_Lcom_google_android_gms_tasks_OnSuccessListener_Handler")]
	public unsafe override Task AddOnSuccessListener(IExecutor p0, IOnSuccessListener p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeAbstractObjectMethod("addOnSuccessListener.(Ljava/util/concurrent/Executor;Lcom/google/android/gms/tasks/OnSuccessListener;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Register("getResult", "(Ljava/lang/Class;)Ljava/lang/Object;", "GetGetResult_Ljava_lang_Class_Handler")]
	[JavaTypeParameters(new string[] { "X extends java.lang.Throwable" })]
	public unsafe override Java.Lang.Object? GetResult(Class p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getResult.(Ljava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}

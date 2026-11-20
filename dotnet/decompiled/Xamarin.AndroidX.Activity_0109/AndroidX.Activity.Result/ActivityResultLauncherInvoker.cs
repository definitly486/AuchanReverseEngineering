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
internal class ActivityResultLauncherInvoker : ActivityResultLauncher
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultLauncher", typeof(ActivityResultLauncherInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe override ActivityResultContract RawContract
	{
		[Register("getContract", "()Landroidx/activity/result/contract/ActivityResultContract;", "GetGetContractHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ActivityResultContract>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContract.()Landroidx/activity/result/contract/ActivityResultContract;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public ActivityResultLauncherInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("launch", "(Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetLaunch_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
	public unsafe override void Launch(Java.Lang.Object? input, ActivityOptionsCompat? options)
	{
		nint num = JNIEnv.ToLocalJniHandle(input);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("launch.(Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(input);
			GC.KeepAlive(options);
		}
	}

	[Register("unregister", "()V", "GetUnregisterHandler")]
	public unsafe override void Unregister()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("unregister.()V", this, null);
	}
}

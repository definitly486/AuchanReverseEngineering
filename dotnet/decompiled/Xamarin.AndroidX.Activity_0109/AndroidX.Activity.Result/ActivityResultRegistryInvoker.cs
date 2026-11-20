using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Activity.Result.Contract;
using AndroidX.Core.App;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.Result;

[Register("androidx/activity/result/ActivityResultRegistry", DoNotGenerateAcw = true)]
internal class ActivityResultRegistryInvoker : ActivityResultRegistry
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/ActivityResultRegistry", typeof(ActivityResultRegistryInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ActivityResultRegistryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("onLaunch", "(ILandroidx/activity/result/contract/ActivityResultContract;Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", "GetOnLaunch_ILandroidx_activity_result_contract_ActivityResultContract_Ljava_lang_Object_Landroidx_core_app_ActivityOptionsCompat_Handler")]
	[JavaTypeParameters(new string[] { "I", "O" })]
	public unsafe override void OnLaunch(int requestCode, ActivityResultContract contract, Java.Lang.Object? input, ActivityOptionsCompat? options)
	{
		nint num = JNIEnv.ToLocalJniHandle(input);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(requestCode);
			ptr[1] = new JniArgumentValue(contract?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onLaunch.(ILandroidx/activity/result/contract/ActivityResultContract;Ljava/lang/Object;Landroidx/core/app/ActivityOptionsCompat;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(contract);
			GC.KeepAlive(input);
			GC.KeepAlive(options);
		}
	}
}

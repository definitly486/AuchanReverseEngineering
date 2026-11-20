using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.Result.Contract;

[Register("androidx/activity/result/contract/ActivityResultContract", DoNotGenerateAcw = true)]
internal class ActivityResultContractInvoker : ActivityResultContract
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/result/contract/ActivityResultContract", typeof(ActivityResultContractInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ActivityResultContractInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("createIntent", "(Landroid/content/Context;Ljava/lang/Object;)Landroid/content/Intent;", "GetCreateIntent_Landroid_content_Context_Ljava_lang_Object_Handler")]
	public unsafe override Intent CreateIntent(Context context, Java.Lang.Object? input)
	{
		nint num = JNIEnv.ToLocalJniHandle(input);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("createIntent.(Landroid/content/Context;Ljava/lang/Object;)Landroid/content/Intent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(input);
		}
	}

	[Register("parseResult", "(ILandroid/content/Intent;)Ljava/lang/Object;", "GetParseResult_ILandroid_content_Intent_Handler")]
	public unsafe override Java.Lang.Object? ParseResult(int resultCode, Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(resultCode);
			ptr[1] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("parseResult.(ILandroid/content/Intent;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}
}

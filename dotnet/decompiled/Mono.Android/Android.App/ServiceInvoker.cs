using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/Service", DoNotGenerateAcw = true)]
internal class ServiceInvoker : Service
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/Service", typeof(ServiceInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ServiceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("onBind", "(Landroid/content/Intent;)Landroid/os/IBinder;", "GetOnBind_Landroid_content_Intent_Handler")]
	public unsafe override IBinder? OnBind(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IBinder>(_members.InstanceMethods.InvokeAbstractObjectMethod("onBind.(Landroid/content/Intent;)Landroid/os/IBinder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}
}

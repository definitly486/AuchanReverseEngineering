using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/InputEvent", DoNotGenerateAcw = true)]
internal class InputEventInvoker : InputEvent
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/InputEvent", typeof(InputEventInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public InputEventInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler")]
	public unsafe override void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dest);
		}
	}
}

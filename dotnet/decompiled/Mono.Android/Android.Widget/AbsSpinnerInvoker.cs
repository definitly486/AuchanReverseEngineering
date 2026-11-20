using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/AbsSpinner", DoNotGenerateAcw = true)]
internal class AbsSpinnerInvoker : AbsSpinner
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/AbsSpinner", typeof(AbsSpinnerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe override Java.Lang.Object? RawAdapter
	{
		[Register("setAdapter", "(Landroid/widget/Adapter;)V", "GetSetAdapter_Landroid_widget_Adapter_Handler")]
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setAdapter.(Landroid/widget/Adapter;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public AbsSpinnerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text.Method;

[Register("android/text/method/NumberKeyListener", DoNotGenerateAcw = true)]
internal class NumberKeyListenerInvoker : NumberKeyListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/method/NumberKeyListener", typeof(NumberKeyListenerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override InputTypes InputType
	{
		[Register("getInputType", "()I", "GetGetInputTypeHandler")]
		get
		{
			return (InputTypes)_members.InstanceMethods.InvokeAbstractInt32Method("getInputType.()I", this, null);
		}
	}

	public NumberKeyListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

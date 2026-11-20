using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text;

[Register("android/text/Layout", DoNotGenerateAcw = true)]
internal class LayoutInvoker : Layout
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/Layout", typeof(LayoutInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int LineCount
	{
		[Register("getLineCount", "()I", "GetGetLineCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getLineCount.()I", this, null);
		}
	}

	public LayoutInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getEllipsisCount", "(I)I", "GetGetEllipsisCount_IHandler")]
	public unsafe override int GetEllipsisCount(int line)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(line);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getEllipsisCount.(I)I", this, ptr);
	}
}

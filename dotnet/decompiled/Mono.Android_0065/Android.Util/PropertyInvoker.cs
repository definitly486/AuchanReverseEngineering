using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Util;

[Register("android/util/Property", DoNotGenerateAcw = true)]
internal class PropertyInvoker : Property
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/util/Property", typeof(PropertyInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public PropertyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

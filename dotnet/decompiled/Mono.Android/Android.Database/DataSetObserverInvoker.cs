using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Database;

[Register("android/database/DataSetObserver", DoNotGenerateAcw = true)]
internal class DataSetObserverInvoker : DataSetObserver
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/database/DataSetObserver", typeof(DataSetObserverInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public DataSetObserverInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

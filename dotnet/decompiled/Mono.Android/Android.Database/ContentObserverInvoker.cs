using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Database;

[Register("android/database/ContentObserver", DoNotGenerateAcw = true)]
internal class ContentObserverInvoker : ContentObserver
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/database/ContentObserver", typeof(ContentObserverInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ContentObserverInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

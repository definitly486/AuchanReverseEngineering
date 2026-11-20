using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/ContentResolver", DoNotGenerateAcw = true)]
internal class ContentResolverInvoker : ContentResolver
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ContentResolver", typeof(ContentResolverInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ContentResolverInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

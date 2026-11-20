using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/BaseRequestOptions", DoNotGenerateAcw = true)]
internal class BaseRequestOptionsInvoker : BaseRequestOptions
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/BaseRequestOptions", typeof(BaseRequestOptionsInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public BaseRequestOptionsInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

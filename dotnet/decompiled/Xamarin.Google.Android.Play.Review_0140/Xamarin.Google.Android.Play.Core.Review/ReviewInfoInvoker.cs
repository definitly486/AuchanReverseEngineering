using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.Android.Play.Core.Review;

[Register("com/google/android/play/core/review/ReviewInfo", DoNotGenerateAcw = true)]
internal class ReviewInfoInvoker : ReviewInfo
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/play/core/review/ReviewInfo", typeof(ReviewInfoInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ReviewInfoInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

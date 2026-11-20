using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Xamarin.Google.Android.Play.Core.Review;

[Register("com/google/android/play/core/review/ReviewManagerFactory", DoNotGenerateAcw = true)]
public class ReviewManagerFactory : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/play/core/review/ReviewManagerFactory", typeof(ReviewManagerFactory));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ReviewManagerFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("create", "(Landroid/content/Context;)Lcom/google/android/play/core/review/ReviewManager;", "")]
	public unsafe static IReviewManager Create(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IReviewManager>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;)Lcom/google/android/play/core/review/ReviewManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}

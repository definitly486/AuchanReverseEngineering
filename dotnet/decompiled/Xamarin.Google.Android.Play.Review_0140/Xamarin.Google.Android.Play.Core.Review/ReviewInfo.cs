using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Xamarin.Google.Android.Play.Core.Review;

[Register("com/google/android/play/core/review/ReviewInfo", DoNotGenerateAcw = true)]
public abstract class ReviewInfo : Java.Lang.Object, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/play/core/review/ReviewInfo", typeof(ReviewInfo));

	[Register("CREATOR")]
	public static IParcelableCreator? Creator => Java.Lang.Object.GetObject<IParcelableCreator>(_members.StaticFields.GetObjectValue("CREATOR.Landroid/os/Parcelable$Creator;").Handle, JniHandleOwnership.TransferLocalRef);

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

	protected ReviewInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ReviewInfo()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("describeContents", "()I", "")]
	public unsafe int DescribeContents()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("describeContents.()I", this, null);
	}

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "")]
	public unsafe void WriteToParcel(Parcel? p0, ParcelableWriteFlags p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)p1);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("zzc", "(Landroid/app/PendingIntent;Z)Lcom/google/android/play/core/review/ReviewInfo;", "")]
	public unsafe static ReviewInfo? Zzc(PendingIntent? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<ReviewInfo>(_members.StaticMethods.InvokeObjectMethod("zzc.(Landroid/app/PendingIntent;Z)Lcom/google/android/play/core/review/ReviewInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}

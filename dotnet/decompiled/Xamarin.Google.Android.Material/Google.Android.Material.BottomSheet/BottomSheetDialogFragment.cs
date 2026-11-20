using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.BottomSheet;

[Register("com/google/android/material/bottomsheet/BottomSheetDialogFragment", DoNotGenerateAcw = true)]
public class BottomSheetDialogFragment : AppCompatDialogFragment
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/bottomsheet/BottomSheetDialogFragment", typeof(BottomSheetDialogFragment));

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

	protected BottomSheetDialogFragment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BottomSheetDialogFragment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (((Java.Lang.Object)(object)this).Handle == IntPtr.Zero)
		{
			((Java.Lang.Object)(object)this).SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", (IJavaPeerable)this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe BottomSheetDialogFragment(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (((Java.Lang.Object)(object)this).Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			((Java.Lang.Object)(object)this).SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", (IJavaPeerable)this, ptr);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentTransaction", DoNotGenerateAcw = true)]
internal class FragmentTransactionInvoker : FragmentTransaction
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentTransaction", typeof(FragmentTransactionInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public FragmentTransactionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("commit", "()I", "GetCommitHandler")]
	public unsafe override int Commit()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("commit.()I", this, null);
	}

	[Register("commitAllowingStateLoss", "()I", "GetCommitAllowingStateLossHandler")]
	public unsafe override int CommitAllowingStateLoss()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("commitAllowingStateLoss.()I", this, null);
	}

	[Register("commitNow", "()V", "GetCommitNowHandler")]
	public unsafe override void CommitNow()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("commitNow.()V", this, null);
	}

	[Register("commitNowAllowingStateLoss", "()V", "GetCommitNowAllowingStateLossHandler")]
	public unsafe override void CommitNowAllowingStateLoss()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("commitNowAllowingStateLoss.()V", this, null);
	}
}

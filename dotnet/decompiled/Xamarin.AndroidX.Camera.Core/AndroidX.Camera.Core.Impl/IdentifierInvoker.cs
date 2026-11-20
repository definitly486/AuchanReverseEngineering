using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Identifier", DoNotGenerateAcw = true)]
internal class IdentifierInvoker : Identifier
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Identifier", typeof(IdentifierInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override Java.Lang.Object Value
	{
		[Register("getValue", "()Ljava/lang/Object;", "GetGetValueHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public IdentifierInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

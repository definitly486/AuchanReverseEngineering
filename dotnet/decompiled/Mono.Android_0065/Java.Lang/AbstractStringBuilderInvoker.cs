using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/AbstractStringBuilder", DoNotGenerateAcw = true)]
internal class AbstractStringBuilderInvoker : AbstractStringBuilder
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/AbstractStringBuilder", typeof(AbstractStringBuilderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public AbstractStringBuilderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android26.0")]
	public unsafe override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/WebResourceError", DoNotGenerateAcw = true, ApiSince = 23)]
[SupportedOSPlatform("android23.0")]
internal class WebResourceErrorInvoker : WebResourceError
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/WebResourceError", typeof(WebResourceErrorInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[SupportedOSPlatform("android23.0")]
	public unsafe override ICharSequence? DescriptionFormatted
	{
		[Register("getDescription", "()Ljava/lang/CharSequence;", "GetGetDescriptionHandler", ApiSince = 23)]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android23.0")]
	public unsafe override ClientError ErrorCode
	{
		[Register("getErrorCode", "()I", "GetGetErrorCodeHandler", ApiSince = 23)]
		get
		{
			return (ClientError)_members.InstanceMethods.InvokeAbstractInt32Method("getErrorCode.()I", this, null);
		}
	}

	public WebResourceErrorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}

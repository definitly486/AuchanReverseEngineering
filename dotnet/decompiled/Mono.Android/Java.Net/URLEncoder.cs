using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Net;

[Register("java/net/URLEncoder", DoNotGenerateAcw = true)]
public class URLEncoder : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/net/URLEncoder", typeof(URLEncoder));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected URLEncoder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("encode", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "")]
	public unsafe static string? Encode(string? s, string? enc)
	{
		nint num = JNIEnv.NewString(s);
		nint num2 = JNIEnv.NewString(enc);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("encode.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Provider;

[Register("android/provider/DocumentsContract", DoNotGenerateAcw = true)]
public sealed class DocumentsContract : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/provider/DocumentsContract", typeof(DocumentsContract));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal DocumentsContract(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe static string? GetDocumentId(Android.Net.Uri? documentUri)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(documentUri?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getDocumentId.(Landroid/net/Uri;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(documentUri);
		}
	}

	public unsafe static bool IsDocumentUri(Context? context, Android.Net.Uri? uri)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isDocumentUri.(Landroid/content/Context;Landroid/net/Uri;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(uri);
		}
	}
}

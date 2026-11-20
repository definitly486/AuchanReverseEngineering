using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/MimeTypeMap", DoNotGenerateAcw = true)]
public class MimeTypeMap : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/webkit/MimeTypeMap", typeof(MimeTypeMap));

	private static Delegate? cb_getExtensionFromMimeType_GetExtensionFromMimeType_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getMimeTypeFromExtension_GetMimeTypeFromExtension_Ljava_lang_String__Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static MimeTypeMap? Singleton
	{
		[Register("getSingleton", "()Landroid/webkit/MimeTypeMap;", "")]
		get
		{
			return Java.Lang.Object.GetObject<MimeTypeMap>(_members.StaticMethods.InvokeObjectMethod("getSingleton.()Landroid/webkit/MimeTypeMap;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected MimeTypeMap(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetExtensionFromMimeType_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetExtensionFromMimeType_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExtensionFromMimeType_Ljava_lang_String_(nint jnienv, nint native__this, nint native_mimeType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MimeTypeMap? mimeTypeMap = Java.Lang.Object.GetObject<MimeTypeMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string mimeType = JNIEnv.GetString(native_mimeType, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(mimeTypeMap.GetExtensionFromMimeType(mimeType));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getExtensionFromMimeType", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetExtensionFromMimeType_Ljava_lang_String_Handler")]
	public unsafe virtual string? GetExtensionFromMimeType(string? mimeType)
	{
		nint num = JNIEnv.NewString(mimeType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtensionFromMimeType.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetMimeTypeFromExtension_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetMimeTypeFromExtension_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMimeTypeFromExtension_Ljava_lang_String_(nint jnienv, nint native__this, nint native_extension)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MimeTypeMap? mimeTypeMap = Java.Lang.Object.GetObject<MimeTypeMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string extension = JNIEnv.GetString(native_extension, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(mimeTypeMap.GetMimeTypeFromExtension(extension));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getMimeTypeFromExtension", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetMimeTypeFromExtension_Ljava_lang_String_Handler")]
	public unsafe virtual string? GetMimeTypeFromExtension(string? extension)
	{
		nint num = JNIEnv.NewString(extension);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMimeTypeFromExtension.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}

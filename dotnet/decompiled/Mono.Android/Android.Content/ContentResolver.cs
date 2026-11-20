using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Android.Content.Res;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/ContentResolver", DoNotGenerateAcw = true)]
public abstract class ContentResolver : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ContentResolver", typeof(ContentResolver));

	private static Delegate? cb_getStreamTypes_GetStreamTypes_Landroid_net_Uri_Ljava_lang_String__arrayLjava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ContentResolver(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetStreamTypes_Landroid_net_Uri_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_GetStreamTypes_Landroid_net_Uri_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStreamTypes_Landroid_net_Uri_Ljava_lang_String_(nint jnienv, nint native__this, nint native_url, nint native_mimeTypeFilter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ContentResolver? contentResolver = Java.Lang.Object.GetObject<ContentResolver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri url = Java.Lang.Object.GetObject<Android.Net.Uri>(native_url, JniHandleOwnership.DoNotTransfer);
			string mimeTypeFilter = JNIEnv.GetString(native_mimeTypeFilter, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(contentResolver.GetStreamTypes(url, mimeTypeFilter));
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

	[Register("getStreamTypes", "(Landroid/net/Uri;Ljava/lang/String;)[Ljava/lang/String;", "GetGetStreamTypes_Landroid_net_Uri_Ljava_lang_String_Handler")]
	public unsafe virtual string[]? GetStreamTypes(Android.Net.Uri url, string mimeTypeFilter)
	{
		nint num = JNIEnv.NewString(mimeTypeFilter);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getStreamTypes.(Landroid/net/Uri;Ljava/lang/String;)[Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(url);
		}
	}

	[Register("getType", "(Landroid/net/Uri;)Ljava/lang/String;", "")]
	public unsafe string? GetType(Android.Net.Uri url)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getType.(Landroid/net/Uri;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(url);
		}
	}

	[Register("openInputStream", "(Landroid/net/Uri;)Ljava/io/InputStream;", "")]
	public unsafe Stream? OpenInputStream(Android.Net.Uri uri)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			return InputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("openInputStream.(Landroid/net/Uri;)Ljava/io/InputStream;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uri);
		}
	}

	[Register("openTypedAssetFileDescriptor", "(Landroid/net/Uri;Ljava/lang/String;Landroid/os/Bundle;)Landroid/content/res/AssetFileDescriptor;", "")]
	public unsafe AssetFileDescriptor? OpenTypedAssetFileDescriptor(Android.Net.Uri uri, string mimeType, Bundle? opts)
	{
		nint num = JNIEnv.NewString(mimeType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(opts?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AssetFileDescriptor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("openTypedAssetFileDescriptor.(Landroid/net/Uri;Ljava/lang/String;Landroid/os/Bundle;)Landroid/content/res/AssetFileDescriptor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(uri);
			GC.KeepAlive(opts);
		}
	}

	[Register("query", "(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;", "")]
	public unsafe ICursor? Query(Android.Net.Uri uri, string[]? projection, string? selection, string[]? selectionArgs, string? sortOrder)
	{
		nint num = JNIEnv.NewArray(projection);
		nint num2 = JNIEnv.NewString(selection);
		nint num3 = JNIEnv.NewArray(selectionArgs);
		nint num4 = JNIEnv.NewString(sortOrder);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(num3);
			ptr[4] = new JniArgumentValue(num4);
			return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("query.(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (projection != null)
			{
				JNIEnv.CopyArray(num, projection);
				JNIEnv.DeleteLocalRef(num);
			}
			JNIEnv.DeleteLocalRef(num2);
			if (selectionArgs != null)
			{
				JNIEnv.CopyArray(num3, selectionArgs);
				JNIEnv.DeleteLocalRef(num3);
			}
			JNIEnv.DeleteLocalRef(num4);
			GC.KeepAlive(uri);
			GC.KeepAlive(projection);
			GC.KeepAlive(selectionArgs);
		}
	}
}

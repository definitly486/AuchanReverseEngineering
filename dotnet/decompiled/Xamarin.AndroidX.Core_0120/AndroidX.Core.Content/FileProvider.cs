using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Database;
using Android.Net;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Content;

[Register("androidx/core/content/FileProvider", DoNotGenerateAcw = true)]
public class FileProvider : ContentProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/content/FileProvider", typeof(FileProvider));

	private static Delegate? cb_delete_Delete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String__I;

	private static Delegate? cb_getType_GetType_Landroid_net_Uri__Ljava_lang_String_;

	private static Delegate? cb_insert_Insert_Landroid_net_Uri_Landroid_content_ContentValues__Landroid_net_Uri_;

	private static Delegate? cb_onCreate_OnCreate_Z;

	private static Delegate? cb_query_Query_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String__Landroid_database_Cursor_;

	private static Delegate? cb_update_Update_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String__I;

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

	protected FileProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FileProvider()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	protected unsafe FileProvider(int resourceId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	private static Delegate GetDelete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLLL_I(n_Delete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Delete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_uri, nint native_selection, nint native_selectionArgs)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FileProvider? fileProvider = Java.Lang.Object.GetObject<FileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Uri uri = Java.Lang.Object.GetObject<Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			string selection = JNIEnv.GetString(native_selection, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_selectionArgs, JniHandleOwnership.DoNotTransfer, typeof(string));
			int result = fileProvider.Delete(uri, selection, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_selectionArgs);
			}
			return result;
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

	[Register("delete", "(Landroid/net/Uri;Ljava/lang/String;[Ljava/lang/String;)I", "GetDelete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String_Handler")]
	public unsafe override int Delete(Uri? uri, string? selection, string[]? selectionArgs)
	{
		nint num = JNIEnv.NewString(selection);
		nint num2 = JNIEnv.NewArray(selectionArgs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			return _members.InstanceMethods.InvokeVirtualInt32Method("delete.(Landroid/net/Uri;Ljava/lang/String;[Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (selectionArgs != null)
			{
				JNIEnv.CopyArray(num2, selectionArgs);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(uri);
			GC.KeepAlive(selectionArgs);
		}
	}

	private static Delegate GetGetType_Landroid_net_Uri_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetType_Landroid_net_Uri_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType_Landroid_net_Uri_(nint jnienv, nint native__this, nint native_uri)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FileProvider? fileProvider = Java.Lang.Object.GetObject<FileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Uri uri = Java.Lang.Object.GetObject<Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(fileProvider.GetType(uri));
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

	[Register("getType", "(Landroid/net/Uri;)Ljava/lang/String;", "GetGetType_Landroid_net_Uri_Handler")]
	public unsafe override string? GetType(Uri? uri)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.(Landroid/net/Uri;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uri);
		}
	}

	[Register("getUriForFile", "(Landroid/content/Context;Ljava/lang/String;Ljava/io/File;)Landroid/net/Uri;", "")]
	public unsafe static Uri? GetUriForFile(Context? context, string? authority, File? file)
	{
		nint num = JNIEnv.NewString(authority);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Uri>(_members.StaticMethods.InvokeObjectMethod("getUriForFile.(Landroid/content/Context;Ljava/lang/String;Ljava/io/File;)Landroid/net/Uri;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(file);
		}
	}

	[Register("getUriForFile", "(Landroid/content/Context;Ljava/lang/String;Ljava/io/File;Ljava/lang/String;)Landroid/net/Uri;", "")]
	public unsafe static Uri? GetUriForFile(Context? context, string? authority, File? file, string? displayName)
	{
		nint num = JNIEnv.NewString(authority);
		nint num2 = JNIEnv.NewString(displayName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Uri>(_members.StaticMethods.InvokeObjectMethod("getUriForFile.(Landroid/content/Context;Ljava/lang/String;Ljava/io/File;Ljava/lang/String;)Landroid/net/Uri;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(context);
			GC.KeepAlive(file);
		}
	}

	private static Delegate GetInsert_Landroid_net_Uri_Landroid_content_ContentValues_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Insert_Landroid_net_Uri_Landroid_content_ContentValues_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Insert_Landroid_net_Uri_Landroid_content_ContentValues_(nint jnienv, nint native__this, nint native_uri, nint native_values)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FileProvider? fileProvider = Java.Lang.Object.GetObject<FileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Uri uri = Java.Lang.Object.GetObject<Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			ContentValues values = Java.Lang.Object.GetObject<ContentValues>(native_values, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fileProvider.Insert(uri, values));
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

	[Register("insert", "(Landroid/net/Uri;Landroid/content/ContentValues;)Landroid/net/Uri;", "GetInsert_Landroid_net_Uri_Landroid_content_ContentValues_Handler")]
	public unsafe override Uri? Insert(Uri? uri, ContentValues? values)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Uri>(_members.InstanceMethods.InvokeVirtualObjectMethod("insert.(Landroid/net/Uri;Landroid/content/ContentValues;)Landroid/net/Uri;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uri);
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetOnCreateHandler()
	{
		return new global::_JniMarshal_PP_B(n_OnCreate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnCreate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreate() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onCreate", "()Z", "GetOnCreateHandler")]
	public unsafe override bool OnCreate()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onCreate.()Z", this, null);
	}

	private static Delegate GetQuery_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLLLLL_L(n_Query_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Query_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_uri, nint native_projection, nint native_selection, nint native_selectionArgs, nint native_sortOrder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FileProvider? fileProvider = Java.Lang.Object.GetObject<FileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Uri uri = Java.Lang.Object.GetObject<Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_projection, JniHandleOwnership.DoNotTransfer, typeof(string));
			string selection = JNIEnv.GetString(native_selection, JniHandleOwnership.DoNotTransfer);
			string[] array2 = (string[])JNIEnv.GetArray(native_selectionArgs, JniHandleOwnership.DoNotTransfer, typeof(string));
			string sortOrder = JNIEnv.GetString(native_sortOrder, JniHandleOwnership.DoNotTransfer);
			nint result = JNIEnv.ToLocalJniHandle(fileProvider.Query(uri, array, selection, array2, sortOrder));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_projection);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_selectionArgs);
			}
			return result;
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

	[Register("query", "(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;", "GetQuery_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Handler")]
	public unsafe override ICursor? Query(Uri? uri, string[]? projection, string? selection, string[]? selectionArgs, string? sortOrder)
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
			return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeVirtualObjectMethod("query.(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	private static Delegate GetUpdate_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLLLL_I(n_Update_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Update_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_uri, nint native_values, nint native_selection, nint native_selectionArgs)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FileProvider? fileProvider = Java.Lang.Object.GetObject<FileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Uri uri = Java.Lang.Object.GetObject<Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			ContentValues values = Java.Lang.Object.GetObject<ContentValues>(native_values, JniHandleOwnership.DoNotTransfer);
			string selection = JNIEnv.GetString(native_selection, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_selectionArgs, JniHandleOwnership.DoNotTransfer, typeof(string));
			int result = fileProvider.Update(uri, values, selection, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_selectionArgs);
			}
			return result;
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

	[Register("update", "(Landroid/net/Uri;Landroid/content/ContentValues;Ljava/lang/String;[Ljava/lang/String;)I", "GetUpdate_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_Handler")]
	public unsafe override int Update(Uri? uri, ContentValues? values, string? selection, string[]? selectionArgs)
	{
		nint num = JNIEnv.NewString(selection);
		nint num2 = JNIEnv.NewArray(selectionArgs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(num2);
			return _members.InstanceMethods.InvokeVirtualInt32Method("update.(Landroid/net/Uri;Landroid/content/ContentValues;Ljava/lang/String;[Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (selectionArgs != null)
			{
				JNIEnv.CopyArray(num2, selectionArgs);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(uri);
			GC.KeepAlive(values);
			GC.KeepAlive(selectionArgs);
		}
	}
}

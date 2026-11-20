using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Database;
using Android.Net;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/ContentProvider", DoNotGenerateAcw = true)]
public abstract class ContentProvider : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ContentProvider", typeof(ContentProvider));

	private static Delegate? cb_delete_Delete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String__I;

	private static Delegate? cb_getType_GetType_Landroid_net_Uri__Ljava_lang_String_;

	private static Delegate? cb_insert_Insert_Landroid_net_Uri_Landroid_content_ContentValues__Landroid_net_Uri_;

	private static Delegate? cb_onCreate_OnCreate_Z;

	private static Delegate? cb_query_Query_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String__Landroid_database_Cursor_;

	private static Delegate? cb_update_Update_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String__I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ContentProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetDelete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLL_I(n_Delete_Landroid_net_Uri_Ljava_lang_String_arrayLjava_lang_String_);
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
			ContentProvider? contentProvider = Java.Lang.Object.GetObject<ContentProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri uri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			string selection = JNIEnv.GetString(native_selection, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_selectionArgs, JniHandleOwnership.DoNotTransfer, typeof(string));
			int result = contentProvider.Delete(uri, selection, array);
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

	public abstract int Delete(Android.Net.Uri uri, string? selection, string[]? selectionArgs);

	private static Delegate GetGetType_Landroid_net_Uri_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetType_Landroid_net_Uri_);
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
			ContentProvider? contentProvider = Java.Lang.Object.GetObject<ContentProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri uri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(contentProvider.GetType(uri));
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

	public abstract string? GetType(Android.Net.Uri uri);

	private static Delegate GetInsert_Landroid_net_Uri_Landroid_content_ContentValues_Handler()
	{
		return new _JniMarshal_PPLL_L(n_Insert_Landroid_net_Uri_Landroid_content_ContentValues_);
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
			ContentProvider? contentProvider = Java.Lang.Object.GetObject<ContentProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri uri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			ContentValues values = Java.Lang.Object.GetObject<ContentValues>(native_values, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(contentProvider.Insert(uri, values));
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

	public abstract Android.Net.Uri? Insert(Android.Net.Uri uri, ContentValues? values);

	private static Delegate GetOnCreateHandler()
	{
		return new _JniMarshal_PP_B(n_OnCreate);
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
			return Java.Lang.Object.GetObject<ContentProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreate() ? ((sbyte)1) : ((sbyte)0);
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

	public abstract bool OnCreate();

	private static Delegate GetQuery_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLLLL_L(n_Query_Landroid_net_Uri_arrayLjava_lang_String_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_);
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
			ContentProvider? contentProvider = Java.Lang.Object.GetObject<ContentProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri uri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_projection, JniHandleOwnership.DoNotTransfer, typeof(string));
			string selection = JNIEnv.GetString(native_selection, JniHandleOwnership.DoNotTransfer);
			string[] array2 = (string[])JNIEnv.GetArray(native_selectionArgs, JniHandleOwnership.DoNotTransfer, typeof(string));
			string sortOrder = JNIEnv.GetString(native_sortOrder, JniHandleOwnership.DoNotTransfer);
			nint result = JNIEnv.ToLocalJniHandle(contentProvider.Query(uri, array, selection, array2, sortOrder));
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

	public abstract ICursor? Query(Android.Net.Uri uri, string[]? projection, string? selection, string[]? selectionArgs, string? sortOrder);

	private static Delegate GetUpdate_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLLL_I(n_Update_Landroid_net_Uri_Landroid_content_ContentValues_Ljava_lang_String_arrayLjava_lang_String_);
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
			ContentProvider? contentProvider = Java.Lang.Object.GetObject<ContentProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri uri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			ContentValues values = Java.Lang.Object.GetObject<ContentValues>(native_values, JniHandleOwnership.DoNotTransfer);
			string selection = JNIEnv.GetString(native_selection, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_selectionArgs, JniHandleOwnership.DoNotTransfer, typeof(string));
			int result = contentProvider.Update(uri, values, selection, array);
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

	public abstract int Update(Android.Net.Uri uri, ContentValues? values, string? selection, string[]? selectionArgs);

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}

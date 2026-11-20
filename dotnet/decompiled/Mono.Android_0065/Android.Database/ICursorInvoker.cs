using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Android.Database;

[Register("android/database/Cursor", DoNotGenerateAcw = true)]
internal class ICursorInvoker : Java.Lang.Object, ICursor, ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_database_Cursor = new XAPeerMembers("android/database/Cursor", typeof(ICursorInvoker));

	private static readonly JniPeerMembers _members_java_io_Closeable = new XAPeerMembers("java/io/Closeable", typeof(ICursorInvoker));

	private static Delegate? cb_getColumnCount_GetColumnCount_I;

	private static Delegate? cb_getCount_GetCount_I;

	private static Delegate? cb_getExtras_GetExtras_Landroid_os_Bundle_;

	private static Delegate? cb_setExtras_SetExtras_Landroid_os_Bundle__V;

	private static Delegate? cb_isAfterLast_IsAfterLast_Z;

	private static Delegate? cb_isBeforeFirst_IsBeforeFirst_Z;

	private static Delegate? cb_isClosed_IsClosed_Z;

	private static Delegate? cb_isFirst_IsFirst_Z;

	private static Delegate? cb_isLast_IsLast_Z;

	private static Delegate? cb_getNotificationUri_GetNotificationUri_Landroid_net_Uri_;

	private static Delegate? cb_getPosition_GetPosition_I;

	private static Delegate? cb_getWantsAllOnMoveCalls_GetWantsAllOnMoveCalls_Z;

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_copyStringToBuffer_CopyStringToBuffer_ILandroid_database_CharArrayBuffer__V;

	private static Delegate? cb_deactivate_Deactivate_V;

	private static Delegate? cb_getBlob_GetBlob_I_arrayB;

	private static Delegate? cb_getColumnIndex_GetColumnIndex_Ljava_lang_String__I;

	private static Delegate? cb_getColumnIndexOrThrow_GetColumnIndexOrThrow_Ljava_lang_String__I;

	private static Delegate? cb_getColumnName_GetColumnName_I_Ljava_lang_String_;

	private static Delegate? cb_getColumnNames_GetColumnNames_arrayLjava_lang_String_;

	private static Delegate? cb_getDouble_GetDouble_I_D;

	private static Delegate? cb_getFloat_GetFloat_I_F;

	private static Delegate? cb_getInt_GetInt_I_I;

	private static Delegate? cb_getLong_GetLong_I_J;

	private static Delegate? cb_getShort_GetShort_I_S;

	private static Delegate? cb_getString_GetString_I_Ljava_lang_String_;

	private static Delegate? cb_getType_GetType_I_I;

	private static Delegate? cb_isNull_IsNull_I_Z;

	private static Delegate? cb_move_Move_I_Z;

	private static Delegate? cb_moveToFirst_MoveToFirst_Z;

	private static Delegate? cb_moveToLast_MoveToLast_Z;

	private static Delegate? cb_moveToNext_MoveToNext_Z;

	private static Delegate? cb_moveToPosition_MoveToPosition_I_Z;

	private static Delegate? cb_moveToPrevious_MoveToPrevious_Z;

	private static Delegate? cb_registerContentObserver_RegisterContentObserver_Landroid_database_ContentObserver__V;

	private static Delegate? cb_registerDataSetObserver_RegisterDataSetObserver_Landroid_database_DataSetObserver__V;

	private static Delegate? cb_requery_Requery_Z;

	private static Delegate? cb_respond_Respond_Landroid_os_Bundle__Landroid_os_Bundle_;

	private static Delegate? cb_setNotificationUri_SetNotificationUri_Landroid_content_ContentResolver_Landroid_net_Uri__V;

	private static Delegate? cb_unregisterContentObserver_UnregisterContentObserver_Landroid_database_ContentObserver__V;

	private static Delegate? cb_unregisterDataSetObserver_UnregisterDataSetObserver_Landroid_database_DataSetObserver__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_database_Cursor;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_database_Cursor.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_database_Cursor.ManagedPeerType;

	public unsafe int ColumnCount => _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt32Method("getColumnCount.()I", this, null);

	public unsafe int Count => _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);

	public unsafe Bundle? Extras
	{
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members_android_database_Cursor.InstanceMethods.InvokeAbstractObjectMethod("getExtras.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("setExtras.(Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool IsAfterLast => _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("isAfterLast.()Z", this, null);

	public unsafe bool IsBeforeFirst => _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("isBeforeFirst.()Z", this, null);

	public unsafe bool IsClosed => _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("isClosed.()Z", this, null);

	public unsafe bool IsFirst => _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("isFirst.()Z", this, null);

	public unsafe bool IsLast => _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("isLast.()Z", this, null);

	public unsafe Android.Net.Uri? NotificationUri => Java.Lang.Object.GetObject<Android.Net.Uri>(_members_android_database_Cursor.InstanceMethods.InvokeAbstractObjectMethod("getNotificationUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int Position => _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt32Method("getPosition.()I", this, null);

	public unsafe bool WantsAllOnMoveCalls => _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("getWantsAllOnMoveCalls.()Z", this, null);

	public ICursorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetColumnCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetColumnCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColumnCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnCount;
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

	private static Delegate GetGetCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
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

	private static Delegate GetGetExtrasHandler()
	{
		return new _JniMarshal_PP_L(n_GetExtras);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExtras(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Extras);
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

	[SupportedOSPlatform("android23.0")]
	private static Delegate GetSetExtras_Landroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetExtras_Landroid_os_Bundle_);
	}

	[SupportedOSPlatform("android23.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExtras_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_extras)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			cursor.Extras = extras;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsAfterLastHandler()
	{
		return new _JniMarshal_PP_B(n_IsAfterLast);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAfterLast(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAfterLast ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsBeforeFirstHandler()
	{
		return new _JniMarshal_PP_B(n_IsBeforeFirst);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsBeforeFirst(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsBeforeFirst ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsClosedHandler()
	{
		return new _JniMarshal_PP_B(n_IsClosed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsClosed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsClosed ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsFirstHandler()
	{
		return new _JniMarshal_PP_B(n_IsFirst);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFirst(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFirst ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsLastHandler()
	{
		return new _JniMarshal_PP_B(n_IsLast);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLast(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLast ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetNotificationUriHandler()
	{
		return new _JniMarshal_PP_L(n_GetNotificationUri);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNotificationUri(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NotificationUri);
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

	private static Delegate GetGetPositionHandler()
	{
		return new _JniMarshal_PP_I(n_GetPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position;
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

	private static Delegate GetGetWantsAllOnMoveCallsHandler()
	{
		return new _JniMarshal_PP_B(n_GetWantsAllOnMoveCalls);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetWantsAllOnMoveCalls(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WantsAllOnMoveCalls ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetCloseHandler()
	{
		return new _JniMarshal_PP_V(n_Close);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void Close()
	{
		_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}

	private static Delegate GetCopyStringToBuffer_ILandroid_database_CharArrayBuffer_Handler()
	{
		return new _JniMarshal_PPIL_V(n_CopyStringToBuffer_ILandroid_database_CharArrayBuffer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CopyStringToBuffer_ILandroid_database_CharArrayBuffer_(nint jnienv, nint native__this, int columnIndex, nint native_buffer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CharArrayBuffer buffer = Java.Lang.Object.GetObject<CharArrayBuffer>(native_buffer, JniHandleOwnership.DoNotTransfer);
			cursor.CopyStringToBuffer(columnIndex, buffer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void CopyStringToBuffer(int columnIndex, CharArrayBuffer? buffer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(columnIndex);
			ptr[1] = new JniArgumentValue(buffer?.Handle ?? IntPtr.Zero);
			_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("copyStringToBuffer.(ILandroid/database/CharArrayBuffer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(buffer);
		}
	}

	[Obsolete]
	private static Delegate GetDeactivateHandler()
	{
		return new _JniMarshal_PP_V(n_Deactivate);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Deactivate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Deactivate();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void Deactivate()
	{
		_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("deactivate.()V", this, null);
	}

	private static Delegate GetGetBlob_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetBlob_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBlob_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBlob(columnIndex));
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

	public unsafe byte[]? GetBlob(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return (byte[])JNIEnv.GetArray(_members_android_database_Cursor.InstanceMethods.InvokeAbstractObjectMethod("getBlob.(I)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}

	private static Delegate GetGetColumnIndex_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetColumnIndex_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColumnIndex_Ljava_lang_String_(nint jnienv, nint native__this, nint native_columnName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string columnName = JNIEnv.GetString(native_columnName, JniHandleOwnership.DoNotTransfer);
			return cursor.GetColumnIndex(columnName);
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

	public unsafe int GetColumnIndex(string? columnName)
	{
		nint num = JNIEnv.NewString(columnName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt32Method("getColumnIndex.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetColumnIndexOrThrow_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetColumnIndexOrThrow_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColumnIndexOrThrow_Ljava_lang_String_(nint jnienv, nint native__this, nint native_columnName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string columnName = JNIEnv.GetString(native_columnName, JniHandleOwnership.DoNotTransfer);
			return cursor.GetColumnIndexOrThrow(columnName);
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

	public unsafe int GetColumnIndexOrThrow(string? columnName)
	{
		nint num = JNIEnv.NewString(columnName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt32Method("getColumnIndexOrThrow.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetColumnName_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetColumnName_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetColumnName_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetColumnName(columnIndex));
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

	public unsafe string? GetColumnName(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return JNIEnv.GetString(_members_android_database_Cursor.InstanceMethods.InvokeAbstractObjectMethod("getColumnName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetColumnNamesHandler()
	{
		return new _JniMarshal_PP_L(n_GetColumnNames);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetColumnNames(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetColumnNames());
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

	public unsafe string[]? GetColumnNames()
	{
		return (string[])JNIEnv.GetArray(_members_android_database_Cursor.InstanceMethods.InvokeAbstractObjectMethod("getColumnNames.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
	}

	private static Delegate GetGetDouble_IHandler()
	{
		return new _JniMarshal_PPI_D(n_GetDouble_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static double n_GetDouble_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0.0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDouble(columnIndex);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0.0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe double GetDouble(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractDoubleMethod("getDouble.(I)D", this, ptr);
	}

	private static Delegate GetGetFloat_IHandler()
	{
		return new _JniMarshal_PPI_F(n_GetFloat_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloat_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFloat(columnIndex);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe float GetFloat(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractSingleMethod("getFloat.(I)F", this, ptr);
	}

	private static Delegate GetGetInt_IHandler()
	{
		return new _JniMarshal_PPI_I(n_GetInt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInt_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetInt(columnIndex);
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

	public unsafe int GetInt(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt32Method("getInt.(I)I", this, ptr);
	}

	private static Delegate GetGetLong_IHandler()
	{
		return new _JniMarshal_PPI_J(n_GetLong_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetLong_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLong(columnIndex);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe long GetLong(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt64Method("getLong.(I)J", this, ptr);
	}

	private static Delegate GetGetShort_IHandler()
	{
		return new _JniMarshal_PPI_S(n_GetShort_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static short n_GetShort_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetShort(columnIndex);
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

	public unsafe short GetShort(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractInt16Method("getShort.(I)S", this, ptr);
	}

	private static Delegate GetGetString_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetString_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetString_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetString(columnIndex));
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

	public unsafe string? GetString(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return JNIEnv.GetString(_members_android_database_Cursor.InstanceMethods.InvokeAbstractObjectMethod("getString.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetType_IHandler()
	{
		return new _JniMarshal_PPI_I(n_GetType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetType_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetType(columnIndex);
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

	public unsafe FieldType GetType(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return (FieldType)_members_android_database_Cursor.InstanceMethods.InvokeAbstractInt32Method("getType.(I)I", this, ptr);
	}

	private static Delegate GetIsNull_IHandler()
	{
		return new _JniMarshal_PPI_B(n_IsNull_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsNull_I(nint jnienv, nint native__this, int columnIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsNull(columnIndex) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool IsNull(int columnIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(columnIndex);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("isNull.(I)Z", this, ptr);
	}

	private static Delegate GetMove_IHandler()
	{
		return new _JniMarshal_PPI_B(n_Move_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Move_I(nint jnienv, nint native__this, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Move(offset) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Move(int offset)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(offset);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("move.(I)Z", this, ptr);
	}

	private static Delegate GetMoveToFirstHandler()
	{
		return new _JniMarshal_PP_B(n_MoveToFirst);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_MoveToFirst(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveToFirst() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool MoveToFirst()
	{
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("moveToFirst.()Z", this, null);
	}

	private static Delegate GetMoveToLastHandler()
	{
		return new _JniMarshal_PP_B(n_MoveToLast);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_MoveToLast(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveToLast() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool MoveToLast()
	{
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("moveToLast.()Z", this, null);
	}

	private static Delegate GetMoveToNextHandler()
	{
		return new _JniMarshal_PP_B(n_MoveToNext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_MoveToNext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveToNext() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool MoveToNext()
	{
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("moveToNext.()Z", this, null);
	}

	private static Delegate GetMoveToPosition_IHandler()
	{
		return new _JniMarshal_PPI_B(n_MoveToPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_MoveToPosition_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveToPosition(position) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool MoveToPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("moveToPosition.(I)Z", this, ptr);
	}

	private static Delegate GetMoveToPreviousHandler()
	{
		return new _JniMarshal_PP_B(n_MoveToPrevious);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_MoveToPrevious(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveToPrevious() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool MoveToPrevious()
	{
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("moveToPrevious.()Z", this, null);
	}

	private static Delegate GetRegisterContentObserver_Landroid_database_ContentObserver_Handler()
	{
		return new _JniMarshal_PPL_V(n_RegisterContentObserver_Landroid_database_ContentObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterContentObserver_Landroid_database_ContentObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContentObserver observer = Java.Lang.Object.GetObject<ContentObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			cursor.RegisterContentObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void RegisterContentObserver(ContentObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("registerContentObserver.(Landroid/database/ContentObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	private static Delegate GetRegisterDataSetObserver_Landroid_database_DataSetObserver_Handler()
	{
		return new _JniMarshal_PPL_V(n_RegisterDataSetObserver_Landroid_database_DataSetObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterDataSetObserver_Landroid_database_DataSetObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			cursor.RegisterDataSetObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void RegisterDataSetObserver(DataSetObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("registerDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	[Obsolete]
	private static Delegate GetRequeryHandler()
	{
		return new _JniMarshal_PP_B(n_Requery);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Requery(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Requery() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Requery()
	{
		return _members_android_database_Cursor.InstanceMethods.InvokeAbstractBooleanMethod("requery.()Z", this, null);
	}

	private static Delegate GetRespond_Landroid_os_Bundle_Handler()
	{
		return new _JniMarshal_PPL_L(n_Respond_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Respond_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_extras)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursor.Respond(extras));
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

	public unsafe Bundle? Respond(Bundle? extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Bundle>(_members_android_database_Cursor.InstanceMethods.InvokeAbstractObjectMethod("respond.(Landroid/os/Bundle;)Landroid/os/Bundle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(extras);
		}
	}

	private static Delegate GetSetNotificationUri_Landroid_content_ContentResolver_Landroid_net_Uri_Handler()
	{
		return new _JniMarshal_PPLL_V(n_SetNotificationUri_Landroid_content_ContentResolver_Landroid_net_Uri_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNotificationUri_Landroid_content_ContentResolver_Landroid_net_Uri_(nint jnienv, nint native__this, nint native_cr, nint native_uri)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContentResolver cr = Java.Lang.Object.GetObject<ContentResolver>(native_cr, JniHandleOwnership.DoNotTransfer);
			Android.Net.Uri uri = Java.Lang.Object.GetObject<Android.Net.Uri>(native_uri, JniHandleOwnership.DoNotTransfer);
			cursor.SetNotificationUri(cr, uri);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void SetNotificationUri(ContentResolver? cr, Android.Net.Uri? uri)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cr?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("setNotificationUri.(Landroid/content/ContentResolver;Landroid/net/Uri;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cr);
			GC.KeepAlive(uri);
		}
	}

	private static Delegate GetUnregisterContentObserver_Landroid_database_ContentObserver_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterContentObserver_Landroid_database_ContentObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterContentObserver_Landroid_database_ContentObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ContentObserver observer = Java.Lang.Object.GetObject<ContentObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			cursor.UnregisterContentObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void UnregisterContentObserver(ContentObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("unregisterContentObserver.(Landroid/database/ContentObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	private static Delegate GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterDataSetObserver_Landroid_database_DataSetObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterDataSetObserver_Landroid_database_DataSetObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ICursor? cursor = Java.Lang.Object.GetObject<ICursor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			cursor.UnregisterDataSetObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void UnregisterDataSetObserver(DataSetObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members_android_database_Cursor.InstanceMethods.InvokeAbstractVoidMethod("unregisterDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

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

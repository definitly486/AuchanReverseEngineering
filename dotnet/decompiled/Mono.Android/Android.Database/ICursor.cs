using System;
using System.Runtime.Versioning;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Android.Database;

[Register("android/database/Cursor", "", "Android.Database.ICursorInvoker")]
public interface ICursor : ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	int ColumnCount
	{
		[Register("getColumnCount", "()I", "GetGetColumnCountHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	Bundle? Extras
	{
		[Register("getExtras", "()Landroid/os/Bundle;", "GetGetExtrasHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
		[SupportedOSPlatform("android23.0")]
		[Register("setExtras", "(Landroid/os/Bundle;)V", "GetSetExtras_Landroid_os_Bundle_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 23)]
		set;
	}

	bool IsAfterLast
	{
		[Register("isAfterLast", "()Z", "GetIsAfterLastHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsBeforeFirst
	{
		[Register("isBeforeFirst", "()Z", "GetIsBeforeFirstHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsClosed
	{
		[Register("isClosed", "()Z", "GetIsClosedHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsFirst
	{
		[Register("isFirst", "()Z", "GetIsFirstHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsLast
	{
		[Register("isLast", "()Z", "GetIsLastHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	Android.Net.Uri? NotificationUri
	{
		[Register("getNotificationUri", "()Landroid/net/Uri;", "GetGetNotificationUriHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int Position
	{
		[Register("getPosition", "()I", "GetGetPositionHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool WantsAllOnMoveCalls
	{
		[Register("getWantsAllOnMoveCalls", "()Z", "GetGetWantsAllOnMoveCallsHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("close", "()V", "GetCloseHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new void Close();

	[Register("copyStringToBuffer", "(ILandroid/database/CharArrayBuffer;)V", "GetCopyStringToBuffer_ILandroid_database_CharArrayBuffer_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void CopyStringToBuffer(int columnIndex, CharArrayBuffer? buffer);

	[Obsolete("deprecated")]
	[Register("deactivate", "()V", "GetDeactivateHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Deactivate();

	[Register("getBlob", "(I)[B", "GetGetBlob_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	byte[]? GetBlob(int columnIndex);

	[Register("getColumnIndex", "(Ljava/lang/String;)I", "GetGetColumnIndex_Ljava_lang_String_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetColumnIndex(string? columnName);

	[Register("getColumnIndexOrThrow", "(Ljava/lang/String;)I", "GetGetColumnIndexOrThrow_Ljava_lang_String_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetColumnIndexOrThrow(string? columnName);

	[Register("getColumnName", "(I)Ljava/lang/String;", "GetGetColumnName_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetColumnName(int columnIndex);

	[Register("getColumnNames", "()[Ljava/lang/String;", "GetGetColumnNamesHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string[]? GetColumnNames();

	[Register("getDouble", "(I)D", "GetGetDouble_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	double GetDouble(int columnIndex);

	[Register("getFloat", "(I)F", "GetGetFloat_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	float GetFloat(int columnIndex);

	[Register("getInt", "(I)I", "GetGetInt_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetInt(int columnIndex);

	[Register("getLong", "(I)J", "GetGetLong_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	long GetLong(int columnIndex);

	[Register("getShort", "(I)S", "GetGetShort_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	short GetShort(int columnIndex);

	[Register("getString", "(I)Ljava/lang/String;", "GetGetString_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetString(int columnIndex);

	[Register("getType", "(I)I", "GetGetType_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	FieldType GetType(int columnIndex);

	[Register("isNull", "(I)Z", "GetIsNull_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool IsNull(int columnIndex);

	[Register("move", "(I)Z", "GetMove_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Move(int offset);

	[Register("moveToFirst", "()Z", "GetMoveToFirstHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool MoveToFirst();

	[Register("moveToLast", "()Z", "GetMoveToLastHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool MoveToLast();

	[Register("moveToNext", "()Z", "GetMoveToNextHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool MoveToNext();

	[Register("moveToPosition", "(I)Z", "GetMoveToPosition_IHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool MoveToPosition(int position);

	[Register("moveToPrevious", "()Z", "GetMoveToPreviousHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool MoveToPrevious();

	[Register("registerContentObserver", "(Landroid/database/ContentObserver;)V", "GetRegisterContentObserver_Landroid_database_ContentObserver_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RegisterContentObserver(ContentObserver? observer);

	[Register("registerDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetRegisterDataSetObserver_Landroid_database_DataSetObserver_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RegisterDataSetObserver(DataSetObserver? observer);

	[Obsolete("deprecated")]
	[Register("requery", "()Z", "GetRequeryHandler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Requery();

	[Register("respond", "(Landroid/os/Bundle;)Landroid/os/Bundle;", "GetRespond_Landroid_os_Bundle_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Bundle? Respond(Bundle? extras);

	[Register("setNotificationUri", "(Landroid/content/ContentResolver;Landroid/net/Uri;)V", "GetSetNotificationUri_Landroid_content_ContentResolver_Landroid_net_Uri_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetNotificationUri(ContentResolver? cr, Android.Net.Uri? uri);

	[Register("unregisterContentObserver", "(Landroid/database/ContentObserver;)V", "GetUnregisterContentObserver_Landroid_database_ContentObserver_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void UnregisterContentObserver(ContentObserver? observer);

	[Register("unregisterDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler:Android.Database.ICursorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void UnregisterDataSetObserver(DataSetObserver? observer);
}

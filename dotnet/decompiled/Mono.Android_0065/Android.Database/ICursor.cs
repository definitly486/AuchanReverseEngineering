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
	int ColumnCount { get; }

	int Count { get; }

	Bundle? Extras
	{
		get; [SupportedOSPlatform("android23.0")]
		set;
	}

	bool IsAfterLast { get; }

	bool IsBeforeFirst { get; }

	bool IsClosed { get; }

	bool IsFirst { get; }

	bool IsLast { get; }

	Android.Net.Uri? NotificationUri { get; }

	int Position { get; }

	bool WantsAllOnMoveCalls { get; }

	new void Close();

	void CopyStringToBuffer(int columnIndex, CharArrayBuffer? buffer);

	[Obsolete("deprecated")]
	void Deactivate();

	byte[]? GetBlob(int columnIndex);

	int GetColumnIndex(string? columnName);

	int GetColumnIndexOrThrow(string? columnName);

	string? GetColumnName(int columnIndex);

	string[]? GetColumnNames();

	double GetDouble(int columnIndex);

	float GetFloat(int columnIndex);

	int GetInt(int columnIndex);

	long GetLong(int columnIndex);

	short GetShort(int columnIndex);

	string? GetString(int columnIndex);

	FieldType GetType(int columnIndex);

	bool IsNull(int columnIndex);

	bool Move(int offset);

	bool MoveToFirst();

	bool MoveToLast();

	bool MoveToNext();

	bool MoveToPosition(int position);

	bool MoveToPrevious();

	void RegisterContentObserver(ContentObserver? observer);

	void RegisterDataSetObserver(DataSetObserver? observer);

	[Obsolete("deprecated")]
	bool Requery();

	Bundle? Respond(Bundle? extras);

	void SetNotificationUri(ContentResolver? cr, Android.Net.Uri? uri);

	void UnregisterContentObserver(ContentObserver? observer);

	void UnregisterDataSetObserver(DataSetObserver? observer);
}

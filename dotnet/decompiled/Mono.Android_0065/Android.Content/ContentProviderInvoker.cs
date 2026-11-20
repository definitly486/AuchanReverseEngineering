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
internal class ContentProviderInvoker : ContentProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/ContentProvider", typeof(ContentProviderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ContentProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override int Delete(Android.Net.Uri uri, string? selection, string[]? selectionArgs)
	{
		nint num = JNIEnv.NewString(selection);
		nint num2 = JNIEnv.NewArray(selectionArgs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			return _members.InstanceMethods.InvokeAbstractInt32Method("delete.(Landroid/net/Uri;Ljava/lang/String;[Ljava/lang/String;)I", this, ptr);
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

	public unsafe override string? GetType(Android.Net.Uri uri)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getType.(Landroid/net/Uri;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uri);
		}
	}

	public unsafe override Android.Net.Uri? Insert(Android.Net.Uri uri, ContentValues? values)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(values?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("insert.(Landroid/net/Uri;Landroid/content/ContentValues;)Landroid/net/Uri;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(uri);
			GC.KeepAlive(values);
		}
	}

	public unsafe override bool OnCreate()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("onCreate.()Z", this, null);
	}

	public unsafe override ICursor? Query(Android.Net.Uri uri, string[]? projection, string? selection, string[]? selectionArgs, string? sortOrder)
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
			return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeAbstractObjectMethod("query.(Landroid/net/Uri;[Ljava/lang/String;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe override int Update(Android.Net.Uri uri, ContentValues? values, string? selection, string[]? selectionArgs)
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
			return _members.InstanceMethods.InvokeAbstractInt32Method("update.(Landroid/net/Uri;Landroid/content/ContentValues;Ljava/lang/String;[Ljava/lang/String;)I", this, ptr);
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

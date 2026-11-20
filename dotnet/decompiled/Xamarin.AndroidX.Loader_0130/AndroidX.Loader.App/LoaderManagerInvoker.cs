using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using AndroidX.Loader.Content;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Loader.App;

[Register("androidx/loader/app/LoaderManager", DoNotGenerateAcw = true)]
internal class LoaderManagerInvoker : LoaderManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/loader/app/LoaderManager", typeof(LoaderManagerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public LoaderManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("destroyLoader", "(I)V", "GetDestroyLoader_IHandler")]
	public unsafe override void DestroyLoader(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeAbstractVoidMethod("destroyLoader.(I)V", this, ptr);
	}

	[Obsolete("deprecated")]
	[Register("dump", "(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", "GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler")]
	public unsafe override void Dump(string? p0, FileDescriptor? p1, PrintWriter? p2, string[]? p3)
	{
		nint num = JNIEnv.NewString(p0);
		nint num2 = JNIEnv.NewArray(p3);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("dump.(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (p3 != null)
			{
				JNIEnv.CopyArray(num2, p3);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
			GC.KeepAlive(p3);
		}
	}

	[Register("getLoader", "(I)Landroidx/loader/content/Loader;", "GetGetLoader_IHandler")]
	[JavaTypeParameters(new string[] { "D" })]
	public unsafe override AndroidX.Loader.Content.Loader? GetLoader(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLoader.(I)Landroidx/loader/content/Loader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("initLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetInitLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
	[JavaTypeParameters(new string[] { "D" })]
	public unsafe override AndroidX.Loader.Content.Loader InitLoader(int p0, Bundle? p1, ILoaderCallbacks p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(_members.InstanceMethods.InvokeAbstractObjectMethod("initLoader.(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	[Register("markForRedelivery", "()V", "GetMarkForRedeliveryHandler")]
	public unsafe override void MarkForRedelivery()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("markForRedelivery.()V", this, null);
	}

	[Register("restartLoader", "(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", "GetRestartLoader_ILandroid_os_Bundle_Landroidx_loader_app_LoaderManager_LoaderCallbacks_Handler")]
	[JavaTypeParameters(new string[] { "D" })]
	public unsafe override AndroidX.Loader.Content.Loader RestartLoader(int p0, Bundle? p1, ILoaderCallbacks p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			return Java.Lang.Object.GetObject<AndroidX.Loader.Content.Loader>(_members.InstanceMethods.InvokeAbstractObjectMethod("restartLoader.(ILandroid/os/Bundle;Landroidx/loader/app/LoaderManager$LoaderCallbacks;)Landroidx/loader/content/Loader;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}
}

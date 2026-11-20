using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Environment", DoNotGenerateAcw = true)]
public class Environment : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Environment", typeof(Environment));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static File? ExternalStorageDirectory
	{
		[Register("getExternalStorageDirectory", "()Ljava/io/File;", "")]
		get
		{
			return Java.Lang.Object.GetObject<File>(_members.StaticMethods.InvokeObjectMethod("getExternalStorageDirectory.()Ljava/io/File;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android30.0")]
	public unsafe static bool IsExternalStorageManager
	{
		[Register("isExternalStorageManager", "()Z", "", ApiSince = 30)]
		get
		{
			return _members.StaticMethods.InvokeBooleanMethod("isExternalStorageManager.()Z", null);
		}
	}

	protected Environment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getExternalStorageState", "(Ljava/io/File;)Ljava/lang/String;", "")]
	public unsafe static string? GetExternalStorageState(File? path)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(path?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getExternalStorageState.(Ljava/io/File;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(path);
		}
	}
}

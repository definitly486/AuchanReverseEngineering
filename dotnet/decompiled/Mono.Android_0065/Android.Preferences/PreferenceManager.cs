using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Preferences;

[ObsoletedOSPlatform("android29.0", "This class is obsoleted in this android platform")]
[Register("android/preference/PreferenceManager", DoNotGenerateAcw = true)]
public class PreferenceManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/preference/PreferenceManager", typeof(PreferenceManager));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PreferenceManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android29.0")]
	public unsafe static ISharedPreferences? GetDefaultSharedPreferences(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISharedPreferences>(_members.StaticMethods.InvokeObjectMethod("getDefaultSharedPreferences.(Landroid/content/Context;)Landroid/content/SharedPreferences;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}

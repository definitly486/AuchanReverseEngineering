using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content.PM;

[SupportedOSPlatform("android25.0")]
[Register("android/content/pm/ShortcutManager", DoNotGenerateAcw = true, ApiSince = 25)]
public class ShortcutManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/ShortcutManager", typeof(ShortcutManager));

	private static Delegate? cb_setDynamicShortcuts_SetDynamicShortcuts_Ljava_util_List__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ShortcutManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android25.0")]
	private static Delegate GetSetDynamicShortcuts_Ljava_util_List_Handler()
	{
		return new _JniMarshal_PPL_B(n_SetDynamicShortcuts_Ljava_util_List_);
	}

	[SupportedOSPlatform("android25.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetDynamicShortcuts_Ljava_util_List_(nint jnienv, nint native__this, nint native_shortcutInfoList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ShortcutManager? shortcutManager = Java.Lang.Object.GetObject<ShortcutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<ShortcutInfo> dynamicShortcuts = JavaList<ShortcutInfo>.FromJniHandle(native_shortcutInfoList, JniHandleOwnership.DoNotTransfer);
			return shortcutManager.SetDynamicShortcuts(dynamicShortcuts) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android25.0")]
	[Register("setDynamicShortcuts", "(Ljava/util/List;)Z", "GetSetDynamicShortcuts_Ljava_util_List_Handler", ApiSince = 25)]
	public unsafe virtual bool SetDynamicShortcuts(IList<ShortcutInfo> shortcutInfoList)
	{
		nint num = JavaList<ShortcutInfo>.ToLocalJniHandle(shortcutInfoList);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setDynamicShortcuts.(Ljava/util/List;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(shortcutInfoList);
		}
	}
}

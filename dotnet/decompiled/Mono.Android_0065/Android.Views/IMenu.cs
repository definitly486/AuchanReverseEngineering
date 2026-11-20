using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/Menu", "", "Android.Views.IMenuInvoker")]
public interface IMenu : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/Menu", typeof(IMenu), isInterface: true);

	private static Delegate? cb_setGroupDividerEnabled_SetGroupDividerEnabled_Z_V;

	bool HasVisibleItems { get; }

	IMenuItem? Add(int groupId, int itemId, int order, int titleRes);

	IMenuItem? Add(int groupId, int itemId, int order, ICharSequence? title);

	IMenuItem? Add(int titleRes);

	IMenuItem? Add(ICharSequence? title);

	int AddIntentOptions(int groupId, int itemId, int order, ComponentName? caller, Intent[]? specifics, Intent? intent, MenuAppendFlags flags, IMenuItem[]? outSpecificItems);

	ISubMenu? AddSubMenu(int groupId, int itemId, int order, int titleRes);

	ISubMenu? AddSubMenu(int groupId, int itemId, int order, ICharSequence? title);

	ISubMenu? AddSubMenu(int titleRes);

	ISubMenu? AddSubMenu(ICharSequence? title);

	void Clear();

	void Close();

	IMenuItem? FindItem(int id);

	IMenuItem? GetItem(int index);

	bool IsShortcutKey(Keycode keyCode, KeyEvent? e);

	bool PerformIdentifierAction(int id, MenuPerformFlags flags);

	bool PerformShortcut(Keycode keyCode, KeyEvent? e, MenuPerformFlags flags);

	void RemoveGroup(int groupId);

	void RemoveItem(int id);

	void SetGroupCheckable(int group, bool checkable, bool exclusive);

	void SetGroupEnabled(int group, bool enabled);

	void SetGroupVisible(int group, bool visible);

	void SetQwertyMode(bool isQwerty);

	int Size();

	[SupportedOSPlatform("android28.0")]
	private static Delegate GetSetGroupDividerEnabled_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetGroupDividerEnabled_Z);
	}

	[SupportedOSPlatform("android28.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupDividerEnabled_Z(nint jnienv, nint native__this, sbyte native_groupDividerEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool groupDividerEnabled = native_groupDividerEnabled != 0;
			menu.SetGroupDividerEnabled(groupDividerEnabled);
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

	[SupportedOSPlatform("android28.0")]
	unsafe void SetGroupDividerEnabled(bool groupDividerEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(groupDividerEnabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGroupDividerEnabled.(Z)V", this, ptr);
	}
}

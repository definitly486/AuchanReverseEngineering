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

	bool HasVisibleItems
	{
		[Register("hasVisibleItems", "()Z", "GetHasVisibleItemsHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("add", "(IIII)Landroid/view/MenuItem;", "GetAdd_IIIIHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem? Add(int groupId, int itemId, int order, int titleRes);

	[Register("add", "(IIILjava/lang/CharSequence;)Landroid/view/MenuItem;", "GetAdd_IIILjava_lang_CharSequence_Handler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem? Add(int groupId, int itemId, int order, ICharSequence? title);

	[Register("add", "(I)Landroid/view/MenuItem;", "GetAdd_IHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem? Add(int titleRes);

	[Register("add", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "GetAdd_Ljava_lang_CharSequence_Handler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem? Add(ICharSequence? title);

	[Register("addIntentOptions", "(IIILandroid/content/ComponentName;[Landroid/content/Intent;Landroid/content/Intent;I[Landroid/view/MenuItem;)I", "GetAddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_Handler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int AddIntentOptions(int groupId, int itemId, int order, ComponentName? caller, Intent[]? specifics, Intent? intent, MenuAppendFlags flags, IMenuItem[]? outSpecificItems);

	[Register("addSubMenu", "(IIII)Landroid/view/SubMenu;", "GetAddSubMenu_IIIIHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? AddSubMenu(int groupId, int itemId, int order, int titleRes);

	[Register("addSubMenu", "(IIILjava/lang/CharSequence;)Landroid/view/SubMenu;", "GetAddSubMenu_IIILjava_lang_CharSequence_Handler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? AddSubMenu(int groupId, int itemId, int order, ICharSequence? title);

	[Register("addSubMenu", "(I)Landroid/view/SubMenu;", "GetAddSubMenu_IHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? AddSubMenu(int titleRes);

	[Register("addSubMenu", "(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", "GetAddSubMenu_Ljava_lang_CharSequence_Handler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? AddSubMenu(ICharSequence? title);

	[Register("clear", "()V", "GetClearHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Clear();

	[Register("close", "()V", "GetCloseHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Close();

	[Register("findItem", "(I)Landroid/view/MenuItem;", "GetFindItem_IHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem? FindItem(int id);

	[Register("getItem", "(I)Landroid/view/MenuItem;", "GetGetItem_IHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem? GetItem(int index);

	[Register("isShortcutKey", "(ILandroid/view/KeyEvent;)Z", "GetIsShortcutKey_ILandroid_view_KeyEvent_Handler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool IsShortcutKey(Keycode keyCode, KeyEvent? e);

	[Register("performIdentifierAction", "(II)Z", "GetPerformIdentifierAction_IIHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool PerformIdentifierAction(int id, MenuPerformFlags flags);

	[Register("performShortcut", "(ILandroid/view/KeyEvent;I)Z", "GetPerformShortcut_ILandroid_view_KeyEvent_IHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool PerformShortcut(Keycode keyCode, KeyEvent? e, MenuPerformFlags flags);

	[Register("removeGroup", "(I)V", "GetRemoveGroup_IHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RemoveGroup(int groupId);

	[Register("removeItem", "(I)V", "GetRemoveItem_IHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RemoveItem(int id);

	[Register("setGroupCheckable", "(IZZ)V", "GetSetGroupCheckable_IZZHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetGroupCheckable(int group, bool checkable, bool exclusive);

	[Register("setGroupEnabled", "(IZ)V", "GetSetGroupEnabled_IZHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetGroupEnabled(int group, bool enabled);

	[Register("setGroupVisible", "(IZ)V", "GetSetGroupVisible_IZHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetGroupVisible(int group, bool visible);

	[Register("setQwertyMode", "(Z)V", "GetSetQwertyMode_ZHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetQwertyMode(bool isQwerty);

	[Register("size", "()I", "GetSizeHandler:Android.Views.IMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
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
	[Register("setGroupDividerEnabled", "(Z)V", "GetSetGroupDividerEnabled_ZHandler:Android.Views.IMenu, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 28)]
	unsafe void SetGroupDividerEnabled(bool groupDividerEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(groupDividerEnabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGroupDividerEnabled.(Z)V", this, ptr);
	}
}

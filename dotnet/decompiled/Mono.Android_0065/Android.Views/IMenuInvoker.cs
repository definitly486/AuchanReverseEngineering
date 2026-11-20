using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/Menu", DoNotGenerateAcw = true)]
internal class IMenuInvoker : Java.Lang.Object, IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_Menu = new XAPeerMembers("android/view/Menu", typeof(IMenuInvoker));

	private static Delegate? cb_hasVisibleItems_HasVisibleItems_Z;

	private static Delegate? cb_add_Add_IIII_Landroid_view_MenuItem_;

	private static Delegate? cb_add_Add_IIILjava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_add_Add_I_Landroid_view_MenuItem_;

	private static Delegate? cb_add_Add_Ljava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_addIntentOptions_AddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem__I;

	private static Delegate? cb_addSubMenu_AddSubMenu_IIII_Landroid_view_SubMenu_;

	private static Delegate? cb_addSubMenu_AddSubMenu_IIILjava_lang_CharSequence__Landroid_view_SubMenu_;

	private static Delegate? cb_addSubMenu_AddSubMenu_I_Landroid_view_SubMenu_;

	private static Delegate? cb_addSubMenu_AddSubMenu_Ljava_lang_CharSequence__Landroid_view_SubMenu_;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_findItem_FindItem_I_Landroid_view_MenuItem_;

	private static Delegate? cb_getItem_GetItem_I_Landroid_view_MenuItem_;

	private static Delegate? cb_isShortcutKey_IsShortcutKey_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_performIdentifierAction_PerformIdentifierAction_II_Z;

	private static Delegate? cb_performShortcut_PerformShortcut_ILandroid_view_KeyEvent_I_Z;

	private static Delegate? cb_removeGroup_RemoveGroup_I_V;

	private static Delegate? cb_removeItem_RemoveItem_I_V;

	private static Delegate? cb_setGroupCheckable_SetGroupCheckable_IZZ_V;

	private static Delegate? cb_setGroupEnabled_SetGroupEnabled_IZ_V;

	private static Delegate? cb_setGroupVisible_SetGroupVisible_IZ_V;

	private static Delegate? cb_setQwertyMode_SetQwertyMode_Z_V;

	private static Delegate? cb_size_Size_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_Menu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_Menu.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_Menu.ManagedPeerType;

	public unsafe bool HasVisibleItems => _members_android_view_Menu.InstanceMethods.InvokeAbstractBooleanMethod("hasVisibleItems.()Z", this, null);

	public IMenuInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetHasVisibleItemsHandler()
	{
		return new _JniMarshal_PP_B(n_HasVisibleItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasVisibleItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasVisibleItems ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetAdd_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_L(n_Add_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_IIII(nint jnienv, nint native__this, int groupId, int itemId, int order, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(groupId, itemId, order, titleRes));
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

	public unsafe IMenuItem? Add(int groupId, int itemId, int order, int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(groupId);
		ptr[1] = new JniArgumentValue(itemId);
		ptr[2] = new JniArgumentValue(order);
		ptr[3] = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("add.(IIII)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAdd_IIILjava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPIIIL_L(n_Add_IIILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_IIILjava_lang_CharSequence_(nint jnienv, nint native__this, int groupId, int itemId, int order, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menu.Add(groupId, itemId, order, title));
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

	public unsafe IMenuItem? Add(int groupId, int itemId, int order, ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(groupId);
			ptr[1] = new JniArgumentValue(itemId);
			ptr[2] = new JniArgumentValue(order);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("add.(IIILjava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	private static Delegate GetAdd_IHandler()
	{
		return new _JniMarshal_PPI_L(n_Add_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_I(nint jnienv, nint native__this, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(titleRes));
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

	public unsafe IMenuItem? Add(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("add.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAdd_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_Add_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menu.Add(title));
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

	public unsafe IMenuItem? Add(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("add.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	private static Delegate GetAddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_Handler()
	{
		return new _JniMarshal_PPIIILLLIL_I(n_AddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_AddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_(nint jnienv, nint native__this, int groupId, int itemId, int order, nint native_caller, nint native_specifics, nint native_intent, int native_flags, nint native_outSpecificItems)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName caller = Java.Lang.Object.GetObject<ComponentName>(native_caller, JniHandleOwnership.DoNotTransfer);
			Intent[] array = (Intent[])JNIEnv.GetArray(native_specifics, JniHandleOwnership.DoNotTransfer, typeof(Intent));
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			IMenuItem[] array2 = (IMenuItem[])JNIEnv.GetArray(native_outSpecificItems, JniHandleOwnership.DoNotTransfer, typeof(IMenuItem));
			int result = menu.AddIntentOptions(groupId, itemId, order, caller, array, intent, (MenuAppendFlags)native_flags, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_specifics);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_outSpecificItems);
			}
			return result;
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

	public unsafe int AddIntentOptions(int groupId, int itemId, int order, ComponentName? caller, Intent[]? specifics, Intent? intent, MenuAppendFlags flags, IMenuItem[]? outSpecificItems)
	{
		nint num = JNIEnv.NewArray(specifics);
		nint num2 = JNIEnv.NewArray(outSpecificItems);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(groupId);
			ptr[1] = new JniArgumentValue(itemId);
			ptr[2] = new JniArgumentValue(order);
			ptr[3] = new JniArgumentValue(caller?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue((int)flags);
			ptr[7] = new JniArgumentValue(num2);
			return _members_android_view_Menu.InstanceMethods.InvokeAbstractInt32Method("addIntentOptions.(IIILandroid/content/ComponentName;[Landroid/content/Intent;Landroid/content/Intent;I[Landroid/view/MenuItem;)I", this, ptr);
		}
		finally
		{
			if (specifics != null)
			{
				JNIEnv.CopyArray(num, specifics);
				JNIEnv.DeleteLocalRef(num);
			}
			if (outSpecificItems != null)
			{
				JNIEnv.CopyArray(num2, outSpecificItems);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(caller);
			GC.KeepAlive(specifics);
			GC.KeepAlive(intent);
			GC.KeepAlive(outSpecificItems);
		}
	}

	private static Delegate GetAddSubMenu_IIIIHandler()
	{
		return new _JniMarshal_PPIIII_L(n_AddSubMenu_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_IIII(nint jnienv, nint native__this, int groupId, int itemId, int order, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddSubMenu(groupId, itemId, order, titleRes));
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

	public unsafe ISubMenu? AddSubMenu(int groupId, int itemId, int order, int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(groupId);
		ptr[1] = new JniArgumentValue(itemId);
		ptr[2] = new JniArgumentValue(order);
		ptr[3] = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("addSubMenu.(IIII)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddSubMenu_IIILjava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPIIIL_L(n_AddSubMenu_IIILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_IIILjava_lang_CharSequence_(nint jnienv, nint native__this, int groupId, int itemId, int order, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menu.AddSubMenu(groupId, itemId, order, title));
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

	public unsafe ISubMenu? AddSubMenu(int groupId, int itemId, int order, ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(groupId);
			ptr[1] = new JniArgumentValue(itemId);
			ptr[2] = new JniArgumentValue(order);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("addSubMenu.(IIILjava/lang/CharSequence;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	private static Delegate GetAddSubMenu_IHandler()
	{
		return new _JniMarshal_PPI_L(n_AddSubMenu_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_I(nint jnienv, nint native__this, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddSubMenu(titleRes));
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

	public unsafe ISubMenu? AddSubMenu(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("addSubMenu.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddSubMenu_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_AddSubMenu_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menu.AddSubMenu(title));
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

	public unsafe ISubMenu? AddSubMenu(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("addSubMenu.(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	private static Delegate GetClearHandler()
	{
		return new _JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	public unsafe void Clear()
	{
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
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
			Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}

	private static Delegate GetFindItem_IHandler()
	{
		return new _JniMarshal_PPI_L(n_FindItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindItem_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindItem(id));
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

	public unsafe IMenuItem? FindItem(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("findItem.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItem_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItem_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(index));
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

	public unsafe IMenuItem? GetItem(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("getItem.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIsShortcutKey_ILandroid_view_KeyEvent_Handler()
	{
		return new _JniMarshal_PPIL_B(n_IsShortcutKey_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShortcutKey_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return menu.IsShortcutKey((Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool IsShortcutKey(Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)keyCode);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_view_Menu.InstanceMethods.InvokeAbstractBooleanMethod("isShortcutKey.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetPerformIdentifierAction_IIHandler()
	{
		return new _JniMarshal_PPII_B(n_PerformIdentifierAction_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformIdentifierAction_II(nint jnienv, nint native__this, int id, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PerformIdentifierAction(id, (MenuPerformFlags)native_flags) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool PerformIdentifierAction(int id, MenuPerformFlags flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue((int)flags);
		return _members_android_view_Menu.InstanceMethods.InvokeAbstractBooleanMethod("performIdentifierAction.(II)Z", this, ptr);
	}

	private static Delegate GetPerformShortcut_ILandroid_view_KeyEvent_IHandler()
	{
		return new _JniMarshal_PPILI_B(n_PerformShortcut_ILandroid_view_KeyEvent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformShortcut_ILandroid_view_KeyEvent_I(nint jnienv, nint native__this, int native_keyCode, nint native_e, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return menu.PerformShortcut((Keycode)native_keyCode, e, (MenuPerformFlags)native_flags) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool PerformShortcut(Keycode keyCode, KeyEvent? e, MenuPerformFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((int)keyCode);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)flags);
			return _members_android_view_Menu.InstanceMethods.InvokeAbstractBooleanMethod("performShortcut.(ILandroid/view/KeyEvent;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetRemoveGroup_IHandler()
	{
		return new _JniMarshal_PPI_V(n_RemoveGroup_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveGroup_I(nint jnienv, nint native__this, int groupId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveGroup(groupId);
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

	public unsafe void RemoveGroup(int groupId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(groupId);
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("removeGroup.(I)V", this, ptr);
	}

	private static Delegate GetRemoveItem_IHandler()
	{
		return new _JniMarshal_PPI_V(n_RemoveItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveItem_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveItem(id);
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

	public unsafe void RemoveItem(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("removeItem.(I)V", this, ptr);
	}

	private static Delegate GetSetGroupCheckable_IZZHandler()
	{
		return new _JniMarshal_PPIBB_V(n_SetGroupCheckable_IZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupCheckable_IZZ(nint jnienv, nint native__this, int group, sbyte native_checkable, sbyte native_exclusive)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool checkable = native_checkable != 0;
			bool exclusive = native_exclusive != 0;
			menu.SetGroupCheckable(group, checkable, exclusive);
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

	public unsafe void SetGroupCheckable(int group, bool checkable, bool exclusive)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(checkable ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(exclusive ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setGroupCheckable.(IZZ)V", this, ptr);
	}

	private static Delegate GetSetGroupEnabled_IZHandler()
	{
		return new _JniMarshal_PPIB_V(n_SetGroupEnabled_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupEnabled_IZ(nint jnienv, nint native__this, int group, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enabled = native_enabled != 0;
			menu.SetGroupEnabled(group, enabled);
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

	public unsafe void SetGroupEnabled(int group, bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setGroupEnabled.(IZ)V", this, ptr);
	}

	private static Delegate GetSetGroupVisible_IZHandler()
	{
		return new _JniMarshal_PPIB_V(n_SetGroupVisible_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupVisible_IZ(nint jnienv, nint native__this, int group, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool visible = native_visible != 0;
			menu.SetGroupVisible(group, visible);
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

	public unsafe void SetGroupVisible(int group, bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setGroupVisible.(IZ)V", this, ptr);
	}

	private static Delegate GetSetQwertyMode_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_SetQwertyMode_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetQwertyMode_Z(nint jnienv, nint native__this, sbyte native_isQwerty)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenu? menu = Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool qwertyMode = native_isQwerty != 0;
			menu.SetQwertyMode(qwertyMode);
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

	public unsafe void SetQwertyMode(bool isQwerty)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isQwerty ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setQwertyMode.(Z)V", this, ptr);
	}

	private static Delegate GetSizeHandler()
	{
		return new _JniMarshal_PP_I(n_Size);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Size(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

	public unsafe int Size()
	{
		return _members_android_view_Menu.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
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

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/SubMenu", DoNotGenerateAcw = true)]
internal class ISubMenuInvoker : Java.Lang.Object, ISubMenu, IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_Menu = new XAPeerMembers("android/view/Menu", typeof(ISubMenuInvoker));

	private static readonly JniPeerMembers _members_android_view_SubMenu = new XAPeerMembers("android/view/SubMenu", typeof(ISubMenuInvoker));

	private static Delegate? cb_getItem_GetItem_Landroid_view_MenuItem_;

	private static Delegate? cb_clearHeader_ClearHeader_V;

	private static Delegate? cb_setHeaderIcon_SetHeaderIcon_Landroid_graphics_drawable_Drawable__Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderIcon_SetHeaderIcon_I_Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderTitle_SetHeaderTitle_I_Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderTitle_SetHeaderTitle_Ljava_lang_CharSequence__Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderView_SetHeaderView_Landroid_view_View__Landroid_view_SubMenu_;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__Landroid_view_SubMenu_;

	private static Delegate? cb_setIcon_SetIcon_I_Landroid_view_SubMenu_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_SubMenu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_SubMenu.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_SubMenu.ManagedPeerType;

	public unsafe IMenuItem? Item => Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("getItem.()Landroid/view/MenuItem;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool HasVisibleItems => _members_android_view_Menu.InstanceMethods.InvokeAbstractBooleanMethod("hasVisibleItems.()Z", this, null);

	public ISubMenuInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetItemHandler()
	{
		return new _JniMarshal_PP_L(n_GetItem);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItem(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Item);
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

	private static Delegate GetClearHeaderHandler()
	{
		return new _JniMarshal_PP_V(n_ClearHeader);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearHeader(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearHeader();
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

	public unsafe void ClearHeader()
	{
		_members_android_view_SubMenu.InstanceMethods.InvokeAbstractVoidMethod("clearHeader.()V", this, null);
	}

	private static Delegate GetSetHeaderIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetHeaderIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISubMenu? subMenu = Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable headerIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenu.SetHeaderIcon(headerIcon));
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

	public unsafe ISubMenu? SetHeaderIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("setHeaderIcon.(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	private static Delegate GetSetHeaderIcon_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetHeaderIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderIcon_I(nint jnienv, nint native__this, int iconRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHeaderIcon(iconRes));
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

	public unsafe ISubMenu? SetHeaderIcon(int iconRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("setHeaderIcon.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetHeaderTitle_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetHeaderTitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderTitle_I(nint jnienv, nint native__this, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHeaderTitle(titleRes));
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

	public unsafe ISubMenu? SetHeaderTitle(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("setHeaderTitle.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetHeaderTitle_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetHeaderTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISubMenu? subMenu = Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence headerTitle = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenu.SetHeaderTitle(headerTitle));
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

	public unsafe ISubMenu? SetHeaderTitle(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("setHeaderTitle.(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	private static Delegate GetSetHeaderView_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetHeaderView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISubMenu? subMenu = Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View headerView = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenu.SetHeaderView(headerView));
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

	public unsafe ISubMenu? SetHeaderView(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("setHeaderView.(Landroid/view/View;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISubMenu? subMenu = Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenu.SetIcon(icon));
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

	public unsafe ISubMenu? SetIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	private static Delegate GetSetIcon_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIcon_I(nint jnienv, nint native__this, int iconRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISubMenu>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(iconRes));
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

	public unsafe ISubMenu? SetIcon(int iconRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_SubMenu.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe IMenuItem? Add(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("add.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe ISubMenu? AddSubMenu(int groupId, int itemId, int order, int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(groupId);
		ptr[1] = new JniArgumentValue(itemId);
		ptr[2] = new JniArgumentValue(order);
		ptr[3] = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("addSubMenu.(IIII)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe ISubMenu? AddSubMenu(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("addSubMenu.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe void Clear()
	{
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	public unsafe void Close()
	{
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
	}

	public unsafe IMenuItem? FindItem(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("findItem.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe IMenuItem? GetItem(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_Menu.InstanceMethods.InvokeAbstractObjectMethod("getItem.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe bool PerformIdentifierAction(int id, MenuPerformFlags flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue((int)flags);
		return _members_android_view_Menu.InstanceMethods.InvokeAbstractBooleanMethod("performIdentifierAction.(II)Z", this, ptr);
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

	public unsafe void RemoveGroup(int groupId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(groupId);
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("removeGroup.(I)V", this, ptr);
	}

	public unsafe void RemoveItem(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("removeItem.(I)V", this, ptr);
	}

	public unsafe void SetGroupCheckable(int group, bool checkable, bool exclusive)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(checkable ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(exclusive ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setGroupCheckable.(IZZ)V", this, ptr);
	}

	public unsafe void SetGroupEnabled(int group, bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setGroupEnabled.(IZ)V", this, ptr);
	}

	public unsafe void SetGroupVisible(int group, bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setGroupVisible.(IZ)V", this, ptr);
	}

	public unsafe void SetQwertyMode(bool isQwerty)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isQwerty ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_Menu.InstanceMethods.InvokeAbstractVoidMethod("setQwertyMode.(Z)V", this, ptr);
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

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View.Menu;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/appcompat/view/menu/SubMenuBuilder", DoNotGenerateAcw = true)]
public class SubMenuBuilder : MenuBuilder, ISubMenu, IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/view/menu/SubMenuBuilder", typeof(SubMenuBuilder));

	private static Delegate? cb_getActionViewStatesKey_GetActionViewStatesKey_Ljava_lang_String_;

	private static Delegate? cb_isQwertyMode_IsQwertyMode_Z;

	private static Delegate? cb_getItem_GetItem_Landroid_view_MenuItem_;

	private static Delegate? cb_getParentMenu_GetParentMenu_Landroid_view_Menu_;

	private static Delegate? cb_setHeaderIcon_SetHeaderIcon_Landroid_graphics_drawable_Drawable__Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderIcon_SetHeaderIcon_I_Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderTitle_SetHeaderTitle_I_Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderTitle_SetHeaderTitle_Ljava_lang_CharSequence__Landroid_view_SubMenu_;

	private static Delegate? cb_setHeaderView_SetHeaderView_Landroid_view_View__Landroid_view_SubMenu_;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__Landroid_view_SubMenu_;

	private static Delegate? cb_setIcon_SetIcon_I_Landroid_view_SubMenu_;

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe override string? ActionViewStatesKey
	{
		[Register("getActionViewStatesKey", "()Ljava/lang/String;", "GetGetActionViewStatesKeyHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getActionViewStatesKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsQwertyMode
	{
		[Register("isQwertyMode", "()Z", "GetIsQwertyModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isQwertyMode.()Z", this, null);
		}
	}

	public unsafe virtual IMenuItem? Item
	{
		[Register("getItem", "()Landroid/view/MenuItem;", "GetGetItemHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItem.()Landroid/view/MenuItem;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IMenu? ParentMenu
	{
		[Register("getParentMenu", "()Landroid/view/Menu;", "GetGetParentMenuHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParentMenu.()Landroid/view/Menu;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected SubMenuBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)V", "")]
	public unsafe SubMenuBuilder(Context? context, MenuBuilder? parentMenu, MenuItemImpl? item)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(parentMenu?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(item?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(parentMenu);
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetGetActionViewStatesKeyHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetActionViewStatesKey);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetActionViewStatesKey(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActionViewStatesKey);
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

	private static Delegate GetIsQwertyModeHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsQwertyMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsQwertyMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsQwertyMode ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetItemHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItem);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Item);
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

	private static Delegate GetGetParentMenuHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParentMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParentMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParentMenu);
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

	private static Delegate GetSetHeaderIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetHeaderIcon_Landroid_graphics_drawable_Drawable_);
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
			SubMenuBuilder? subMenuBuilder = Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable headerIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenuBuilder.SetHeaderIcon(headerIcon));
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

	[Register("setHeaderIcon", "(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", "GetSetHeaderIcon_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual ISubMenu? SetHeaderIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderIcon.(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	private static Delegate GetSetHeaderIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetHeaderIcon_I);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHeaderIcon(iconRes));
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

	[Register("setHeaderIcon", "(I)Landroid/view/SubMenu;", "GetSetHeaderIcon_IHandler")]
	public unsafe virtual ISubMenu? SetHeaderIcon(int iconRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderIcon.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetHeaderTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetHeaderTitle_I);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHeaderTitle(titleRes));
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

	[Register("setHeaderTitle", "(I)Landroid/view/SubMenu;", "GetSetHeaderTitle_IHandler")]
	public unsafe virtual ISubMenu? SetHeaderTitle(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderTitle.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetHeaderTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetHeaderTitle_Ljava_lang_CharSequence_);
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
			SubMenuBuilder? subMenuBuilder = Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence headerTitle = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenuBuilder.SetHeaderTitle(headerTitle));
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

	[Register("setHeaderTitle", "(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", "GetSetHeaderTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual ISubMenu? SetHeaderTitle(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderTitle.(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public ISubMenu? SetHeaderTitle(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		ISubMenu? result = SetHeaderTitle(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetSetHeaderView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetHeaderView_Landroid_view_View_);
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
			SubMenuBuilder? subMenuBuilder = Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View headerView = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenuBuilder.SetHeaderView(headerView));
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

	[Register("setHeaderView", "(Landroid/view/View;)Landroid/view/SubMenu;", "GetSetHeaderView_Landroid_view_View_Handler")]
	public unsafe virtual ISubMenu? SetHeaderView(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderView.(Landroid/view/View;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetIcon_Landroid_graphics_drawable_Drawable_);
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
			SubMenuBuilder? subMenuBuilder = Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(subMenuBuilder.SetIcon(icon));
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

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual ISubMenu? SetIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIcon.(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	private static Delegate GetSetIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetIcon_I);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SubMenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(iconRes));
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

	[Register("setIcon", "(I)Landroid/view/SubMenu;", "GetSetIcon_IHandler")]
	public unsafe virtual ISubMenu? SetIcon(int iconRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIcon.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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

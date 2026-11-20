using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.View.Menu;
using Google.Android.Material.Badge;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Navigation;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("com/google/android/material/navigation/NavigationBarItemView", DoNotGenerateAcw = true)]
public abstract class NavigationBarItemView : FrameLayout, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/navigation/NavigationBarItemView", typeof(NavigationBarItemView));

	private static Delegate? cb_getActiveIndicatorDrawable_GetActiveIndicatorDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setActiveIndicatorDrawable_SetActiveIndicatorDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getBadge_GetBadge_Lcom_google_android_material_badge_BadgeDrawable_;

	private static Delegate? cb_getItemBackgroundResId_GetItemBackgroundResId_I;

	private static Delegate? cb_getItemData_GetItemData_Landroidx_appcompat_view_menu_MenuItemImpl_;

	private static Delegate? cb_getItemDefaultMarginResId_GetItemDefaultMarginResId_I;

	private static Delegate? cb_getItemLayoutResId_GetItemLayoutResId_I;

	private static Delegate? cb_getItemPosition_GetItemPosition_I;

	private static Delegate? cb_setItemPosition_SetItemPosition_I_V;

	private static Delegate? cb_initialize_Initialize_Landroidx_appcompat_view_menu_MenuItemImpl_I_V;

	private static Delegate? cb_onCreateDrawableState_OnCreateDrawableState_I_arrayI;

	private static Delegate? cb_prefersCondensedTitle_PrefersCondensedTitle_Z;

	private static Delegate? cb_setActiveIndicatorEnabled_SetActiveIndicatorEnabled_Z_V;

	private static Delegate? cb_setActiveIndicatorHeight_SetActiveIndicatorHeight_I_V;

	private static Delegate? cb_setActiveIndicatorLabelPadding_SetActiveIndicatorLabelPadding_I_V;

	private static Delegate? cb_setActiveIndicatorMarginHorizontal_SetActiveIndicatorMarginHorizontal_I_V;

	private static Delegate? cb_setActiveIndicatorResizeable_SetActiveIndicatorResizeable_Z_V;

	private static Delegate? cb_setActiveIndicatorWidth_SetActiveIndicatorWidth_I_V;

	private static Delegate? cb_setCheckable_SetCheckable_Z_V;

	private static Delegate? cb_setChecked_SetChecked_Z_V;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setIconSize_SetIconSize_I_V;

	private static Delegate? cb_setIconTintList_SetIconTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setItemBackground_SetItemBackground_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setItemBackground_SetItemBackground_I_V;

	private static Delegate? cb_setItemPaddingBottom_SetItemPaddingBottom_I_V;

	private static Delegate? cb_setItemPaddingTop_SetItemPaddingTop_I_V;

	private static Delegate? cb_setItemRippleColor_SetItemRippleColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setLabelVisibilityMode_SetLabelVisibilityMode_I_V;

	private static Delegate? cb_setShifting_SetShifting_Z_V;

	private static Delegate? cb_setShortcut_SetShortcut_ZC_V;

	private static Delegate? cb_setTextAppearanceActive_SetTextAppearanceActive_I_V;

	private static Delegate? cb_setTextAppearanceActiveBoldEnabled_SetTextAppearanceActiveBoldEnabled_Z_V;

	private static Delegate? cb_setTextAppearanceInactive_SetTextAppearanceInactive_I_V;

	private static Delegate? cb_setTextColor_SetTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_showsIcon_ShowsIcon_Z;

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			base.Enabled = value;
		}
	}

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual Drawable? ActiveIndicatorDrawable
	{
		[Register("getActiveIndicatorDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetActiveIndicatorDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getActiveIndicatorDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setActiveIndicatorDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetActiveIndicatorDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual BadgeDrawable? Badge
	{
		[Register("getBadge", "()Lcom/google/android/material/badge/BadgeDrawable;", "GetGetBadgeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBadge.()Lcom/google/android/material/badge/BadgeDrawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual int ItemBackgroundResId
	{
		[Register("getItemBackgroundResId", "()I", "GetGetItemBackgroundResIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemBackgroundResId.()I", this, null);
		}
	}

	public unsafe virtual MenuItemImpl? ItemData
	{
		[Register("getItemData", "()Landroidx/appcompat/view/menu/MenuItemImpl;", "GetGetItemDataHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MenuItemImpl>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemData.()Landroidx/appcompat/view/menu/MenuItemImpl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual int ItemDefaultMarginResId
	{
		[Register("getItemDefaultMarginResId", "()I", "GetGetItemDefaultMarginResIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemDefaultMarginResId.()I", this, null);
		}
	}

	protected abstract int ItemLayoutResId
	{
		[Register("getItemLayoutResId", "()I", "GetGetItemLayoutResIdHandler")]
		get;
	}

	public unsafe virtual int ItemPosition
	{
		[Register("getItemPosition", "()I", "GetGetItemPositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemPosition.()I", this, null);
		}
		[Register("setItemPosition", "(I)V", "GetSetItemPosition_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemPosition.(I)V", this, ptr);
		}
	}

	public void SetEnabled(bool enabled)
	{
		Enabled = enabled;
	}

	protected NavigationBarItemView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe NavigationBarItemView(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetActiveIndicatorDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetActiveIndicatorDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetActiveIndicatorDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActiveIndicatorDrawable);
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

	private static Delegate GetSetActiveIndicatorDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetActiveIndicatorDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveIndicatorDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_activeIndicatorDrawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable activeIndicatorDrawable = Java.Lang.Object.GetObject<Drawable>(native_activeIndicatorDrawable, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.ActiveIndicatorDrawable = activeIndicatorDrawable;
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

	private static Delegate GetGetBadgeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBadge);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBadge(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Badge);
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

	private static Delegate GetGetItemBackgroundResIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemBackgroundResId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemBackgroundResId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemBackgroundResId;
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

	private static Delegate GetGetItemDataHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemData);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemData(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemData);
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

	private static Delegate GetGetItemDefaultMarginResIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemDefaultMarginResId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemDefaultMarginResId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemDefaultMarginResId;
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

	private static Delegate GetGetItemLayoutResIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemLayoutResId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemLayoutResId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemLayoutResId;
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

	private static Delegate GetGetItemPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPosition;
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

	private static Delegate GetSetItemPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemPosition_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPosition = position;
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

	private static Delegate GetInitialize_Landroidx_appcompat_view_menu_MenuItemImpl_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_Initialize_Landroidx_appcompat_view_menu_MenuItemImpl_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Initialize_Landroidx_appcompat_view_menu_MenuItemImpl_I(nint jnienv, nint native__this, nint native_itemData, int menuType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuItemImpl itemData = Java.Lang.Object.GetObject<MenuItemImpl>(native_itemData, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.Initialize(itemData, menuType);
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

	[Register("initialize", "(Landroidx/appcompat/view/menu/MenuItemImpl;I)V", "GetInitialize_Landroidx_appcompat_view_menu_MenuItemImpl_IHandler")]
	public unsafe virtual void Initialize(MenuItemImpl itemData, int menuType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(itemData?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(menuType);
			_members.InstanceMethods.InvokeVirtualVoidMethod("initialize.(Landroidx/appcompat/view/menu/MenuItemImpl;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(itemData);
		}
	}

	private static Delegate GetOnCreateDrawableState_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_OnCreateDrawableState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnCreateDrawableState_I(nint jnienv, nint native__this, int extraSpace)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreateDrawableState(extraSpace));
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

	[Register("onCreateDrawableState", "(I)[I", "GetOnCreateDrawableState_IHandler")]
	public new unsafe virtual int[] OnCreateDrawableState(int extraSpace)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(extraSpace);
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("onCreateDrawableState.(I)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetPrefersCondensedTitleHandler()
	{
		return new global::_JniMarshal_PP_B(n_PrefersCondensedTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PrefersCondensedTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrefersCondensedTitle() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("prefersCondensedTitle", "()Z", "GetPrefersCondensedTitleHandler")]
	public unsafe virtual bool PrefersCondensedTitle()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("prefersCondensedTitle.()Z", this, null);
	}

	private static Delegate GetSetActiveIndicatorEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetActiveIndicatorEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveIndicatorEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool activeIndicatorEnabled = native_enabled != 0;
			navigationBarItemView.SetActiveIndicatorEnabled(activeIndicatorEnabled);
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

	[Register("setActiveIndicatorEnabled", "(Z)V", "GetSetActiveIndicatorEnabled_ZHandler")]
	public unsafe virtual void SetActiveIndicatorEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetActiveIndicatorHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetActiveIndicatorHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveIndicatorHeight_I(nint jnienv, nint native__this, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActiveIndicatorHeight(height);
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

	[Register("setActiveIndicatorHeight", "(I)V", "GetSetActiveIndicatorHeight_IHandler")]
	public unsafe virtual void SetActiveIndicatorHeight(int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorHeight.(I)V", this, ptr);
	}

	private static Delegate GetSetActiveIndicatorLabelPadding_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetActiveIndicatorLabelPadding_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveIndicatorLabelPadding_I(nint jnienv, nint native__this, int activeIndicatorLabelPadding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActiveIndicatorLabelPadding(activeIndicatorLabelPadding);
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

	[Register("setActiveIndicatorLabelPadding", "(I)V", "GetSetActiveIndicatorLabelPadding_IHandler")]
	public unsafe virtual void SetActiveIndicatorLabelPadding(int activeIndicatorLabelPadding)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(activeIndicatorLabelPadding);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorLabelPadding.(I)V", this, ptr);
	}

	private static Delegate GetSetActiveIndicatorMarginHorizontal_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetActiveIndicatorMarginHorizontal_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveIndicatorMarginHorizontal_I(nint jnienv, nint native__this, int marginHorizontal)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActiveIndicatorMarginHorizontal(marginHorizontal);
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

	[Register("setActiveIndicatorMarginHorizontal", "(I)V", "GetSetActiveIndicatorMarginHorizontal_IHandler")]
	public unsafe virtual void SetActiveIndicatorMarginHorizontal(int marginHorizontal)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(marginHorizontal);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorMarginHorizontal.(I)V", this, ptr);
	}

	private static Delegate GetSetActiveIndicatorResizeable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetActiveIndicatorResizeable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveIndicatorResizeable_Z(nint jnienv, nint native__this, sbyte native_resizeable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool activeIndicatorResizeable = native_resizeable != 0;
			navigationBarItemView.SetActiveIndicatorResizeable(activeIndicatorResizeable);
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

	[Register("setActiveIndicatorResizeable", "(Z)V", "GetSetActiveIndicatorResizeable_ZHandler")]
	public unsafe virtual void SetActiveIndicatorResizeable(bool resizeable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resizeable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorResizeable.(Z)V", this, ptr);
	}

	private static Delegate GetSetActiveIndicatorWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetActiveIndicatorWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveIndicatorWidth_I(nint jnienv, nint native__this, int width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActiveIndicatorWidth(width);
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

	[Register("setActiveIndicatorWidth", "(I)V", "GetSetActiveIndicatorWidth_IHandler")]
	public unsafe virtual void SetActiveIndicatorWidth(int width)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(width);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorWidth.(I)V", this, ptr);
	}

	private static Delegate GetSetCheckable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCheckable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckable_Z(nint jnienv, nint native__this, sbyte native_checkable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool checkable = native_checkable != 0;
			navigationBarItemView.SetCheckable(checkable);
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

	[Register("setCheckable", "(Z)V", "GetSetCheckable_ZHandler")]
	public unsafe virtual void SetCheckable(bool checkable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(checkable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckable.(Z)V", this, ptr);
	}

	private static Delegate GetSetChecked_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetChecked_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChecked_Z(nint jnienv, nint native__this, sbyte native__checked)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native__checked != 0;
			navigationBarItemView.SetChecked(flag);
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

	[Register("setChecked", "(Z)V", "GetSetChecked_ZHandler")]
	public unsafe virtual void SetChecked(bool @checked)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(@checked ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setChecked.(Z)V", this, ptr);
	}

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_iconDrawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_iconDrawable, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.SetIcon(icon);
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

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetIcon(Drawable? iconDrawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(iconDrawable?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(iconDrawable);
		}
	}

	private static Delegate GetSetIconSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIconSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconSize_I(nint jnienv, nint native__this, int iconSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIconSize(iconSize);
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

	[Register("setIconSize", "(I)V", "GetSetIconSize_IHandler")]
	public unsafe virtual void SetIconSize(int iconSize)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconSize);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIconSize.(I)V", this, ptr);
	}

	private static Delegate GetSetIconTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIconTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIconTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList iconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.SetIconTintList(iconTintList);
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

	[Register("setIconTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetIconTintList_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetIconTintList(ColorStateList? tint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tint?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tint);
		}
	}

	private static Delegate GetSetItemBackground_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetItemBackground_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemBackground_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_background)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable itemBackground = Java.Lang.Object.GetObject<Drawable>(native_background, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.SetItemBackground(itemBackground);
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

	[Register("setItemBackground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetItemBackground_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetItemBackground(Drawable? background)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(background?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemBackground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(background);
		}
	}

	private static Delegate GetSetItemBackground_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemBackground_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemBackground_I(nint jnienv, nint native__this, int background)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetItemBackground(background);
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

	[Register("setItemBackground", "(I)V", "GetSetItemBackground_IHandler")]
	public unsafe virtual void SetItemBackground(int background)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(background);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setItemBackground.(I)V", this, ptr);
	}

	private static Delegate GetSetItemPaddingBottom_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemPaddingBottom_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemPaddingBottom_I(nint jnienv, nint native__this, int paddingBottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetItemPaddingBottom(paddingBottom);
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

	[Register("setItemPaddingBottom", "(I)V", "GetSetItemPaddingBottom_IHandler")]
	public unsafe virtual void SetItemPaddingBottom(int paddingBottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(paddingBottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setItemPaddingBottom.(I)V", this, ptr);
	}

	private static Delegate GetSetItemPaddingTop_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemPaddingTop_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemPaddingTop_I(nint jnienv, nint native__this, int paddingTop)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetItemPaddingTop(paddingTop);
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

	[Register("setItemPaddingTop", "(I)V", "GetSetItemPaddingTop_IHandler")]
	public unsafe virtual void SetItemPaddingTop(int paddingTop)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(paddingTop);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setItemPaddingTop.(I)V", this, ptr);
	}

	private static Delegate GetSetItemRippleColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetItemRippleColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemRippleColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_itemRippleColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemRippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_itemRippleColor, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.SetItemRippleColor(itemRippleColor);
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

	[Register("setItemRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetItemRippleColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetItemRippleColor(ColorStateList? itemRippleColor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(itemRippleColor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(itemRippleColor);
		}
	}

	private static Delegate GetSetLabelVisibilityMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLabelVisibilityMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabelVisibilityMode_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLabelVisibilityMode(mode);
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

	[Register("setLabelVisibilityMode", "(I)V", "GetSetLabelVisibilityMode_IHandler")]
	public unsafe virtual void SetLabelVisibilityMode(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLabelVisibilityMode.(I)V", this, ptr);
	}

	private static Delegate GetSetShifting_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShifting_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShifting_Z(nint jnienv, nint native__this, sbyte native_shifting)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shifting = native_shifting != 0;
			navigationBarItemView.SetShifting(shifting);
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

	[Register("setShifting", "(Z)V", "GetSetShifting_ZHandler")]
	public unsafe virtual void SetShifting(bool shifting)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shifting ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShifting.(Z)V", this, ptr);
	}

	private static Delegate GetSetShortcut_ZCHandler()
	{
		return new _JniMarshal_PPBs_V(n_SetShortcut_ZC);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShortcut_ZC(nint jnienv, nint native__this, sbyte native_showShortcut, ushort native_shortcutKey)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool showShortcut = native_showShortcut != 0;
			char shortcutKey = (char)native_shortcutKey;
			navigationBarItemView.SetShortcut(showShortcut, shortcutKey);
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

	[Register("setShortcut", "(ZC)V", "GetSetShortcut_ZCHandler")]
	public unsafe virtual void SetShortcut(bool showShortcut, char shortcutKey)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(showShortcut ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue((ushort)shortcutKey);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShortcut.(ZC)V", this, ptr);
	}

	private static Delegate GetSetTextAppearanceActive_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTextAppearanceActive_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextAppearanceActive_I(nint jnienv, nint native__this, int activeTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextAppearanceActive(activeTextAppearance);
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

	[Register("setTextAppearanceActive", "(I)V", "GetSetTextAppearanceActive_IHandler")]
	public unsafe virtual void SetTextAppearanceActive(int activeTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(activeTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextAppearanceActive.(I)V", this, ptr);
	}

	private static Delegate GetSetTextAppearanceActiveBoldEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetTextAppearanceActiveBoldEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextAppearanceActiveBoldEnabled_Z(nint jnienv, nint native__this, sbyte native_isBold)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool textAppearanceActiveBoldEnabled = native_isBold != 0;
			navigationBarItemView.SetTextAppearanceActiveBoldEnabled(textAppearanceActiveBoldEnabled);
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

	[Register("setTextAppearanceActiveBoldEnabled", "(Z)V", "GetSetTextAppearanceActiveBoldEnabled_ZHandler")]
	public unsafe virtual void SetTextAppearanceActiveBoldEnabled(bool isBold)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isBold ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextAppearanceActiveBoldEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetTextAppearanceInactive_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTextAppearanceInactive_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextAppearanceInactive_I(nint jnienv, nint native__this, int inactiveTextAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextAppearanceInactive(inactiveTextAppearance);
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

	[Register("setTextAppearanceInactive", "(I)V", "GetSetTextAppearanceInactive_IHandler")]
	public unsafe virtual void SetTextAppearanceInactive(int inactiveTextAppearance)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(inactiveTextAppearance);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextAppearanceInactive.(I)V", this, ptr);
	}

	private static Delegate GetSetTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList textColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.SetTextColor(textColor);
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

	[Register("setTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetTextColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetTextColor(ColorStateList? color)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(color);
		}
	}

	private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarItemView? navigationBarItemView = Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			navigationBarItemView.SetTitle(title);
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

	[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetTitle(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public void SetTitle(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		SetTitle(obj);
		obj?.Dispose();
	}

	private static Delegate GetShowsIconHandler()
	{
		return new global::_JniMarshal_PP_B(n_ShowsIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShowsIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowsIcon() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("showsIcon", "()Z", "GetShowsIconHandler")]
	public unsafe virtual bool ShowsIcon()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("showsIcon.()Z", this, null);
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.View.Menu;
using Google.Android.Material.Badge;
using Google.Android.Material.Shape;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Navigation;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("com/google/android/material/navigation/NavigationBarMenuView", DoNotGenerateAcw = true)]
public abstract class NavigationBarMenuView : ViewGroup, IMenuView, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/navigation/NavigationBarMenuView", typeof(NavigationBarMenuView));

	private static Delegate? cb_getActiveIndicatorLabelPadding_GetActiveIndicatorLabelPadding_I;

	private static Delegate? cb_setActiveIndicatorLabelPadding_SetActiveIndicatorLabelPadding_I_V;

	private static Delegate? cb_getIconTintList_GetIconTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setIconTintList_SetIconTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getItemActiveIndicatorColor_GetItemActiveIndicatorColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setItemActiveIndicatorColor_SetItemActiveIndicatorColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getItemActiveIndicatorEnabled_GetItemActiveIndicatorEnabled_Z;

	private static Delegate? cb_setItemActiveIndicatorEnabled_SetItemActiveIndicatorEnabled_Z_V;

	private static Delegate? cb_getItemActiveIndicatorHeight_GetItemActiveIndicatorHeight_I;

	private static Delegate? cb_setItemActiveIndicatorHeight_SetItemActiveIndicatorHeight_I_V;

	private static Delegate? cb_getItemActiveIndicatorMarginHorizontal_GetItemActiveIndicatorMarginHorizontal_I;

	private static Delegate? cb_setItemActiveIndicatorMarginHorizontal_SetItemActiveIndicatorMarginHorizontal_I_V;

	private static Delegate? cb_isItemActiveIndicatorResizeable_IsItemActiveIndicatorResizeable_Z;

	private static Delegate? cb_setItemActiveIndicatorResizeable_SetItemActiveIndicatorResizeable_Z_V;

	private static Delegate? cb_getItemActiveIndicatorShapeAppearance_GetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_setItemActiveIndicatorShapeAppearance_SetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel__V;

	private static Delegate? cb_getItemActiveIndicatorWidth_GetItemActiveIndicatorWidth_I;

	private static Delegate? cb_setItemActiveIndicatorWidth_SetItemActiveIndicatorWidth_I_V;

	private static Delegate? cb_getItemBackground_GetItemBackground_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setItemBackground_SetItemBackground_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getItemBackgroundRes_GetItemBackgroundRes_I;

	private static Delegate? cb_setItemBackgroundRes_SetItemBackgroundRes_I_V;

	private static Delegate? cb_getItemIconSize_GetItemIconSize_I;

	private static Delegate? cb_setItemIconSize_SetItemIconSize_I_V;

	private static Delegate? cb_getItemPaddingBottom_GetItemPaddingBottom_I;

	private static Delegate? cb_setItemPaddingBottom_SetItemPaddingBottom_I_V;

	private static Delegate? cb_getItemPaddingTop_GetItemPaddingTop_I;

	private static Delegate? cb_setItemPaddingTop_SetItemPaddingTop_I_V;

	private static Delegate? cb_getItemRippleColor_GetItemRippleColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setItemRippleColor_SetItemRippleColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getItemTextAppearanceActive_GetItemTextAppearanceActive_I;

	private static Delegate? cb_setItemTextAppearanceActive_SetItemTextAppearanceActive_I_V;

	private static Delegate? cb_getItemTextAppearanceInactive_GetItemTextAppearanceInactive_I;

	private static Delegate? cb_setItemTextAppearanceInactive_SetItemTextAppearanceInactive_I_V;

	private static Delegate? cb_getItemTextColor_GetItemTextColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setItemTextColor_SetItemTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getLabelVisibilityMode_GetLabelVisibilityMode_I;

	private static Delegate? cb_setLabelVisibilityMode_SetLabelVisibilityMode_I_V;

	private static Delegate? cb_getMenu_GetMenu_Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_getSelectedItemId_GetSelectedItemId_I;

	private static Delegate? cb_getSelectedItemPosition_GetSelectedItemPosition_I;

	private static Delegate? cb_getWindowAnimations_GetWindowAnimations_I;

	private static Delegate? cb_buildMenuView_BuildMenuView_V;

	private static Delegate? cb_createDefaultColorStateList_CreateDefaultColorStateList_I_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_createNavigationBarItemView_CreateNavigationBarItemView_Landroid_content_Context__Lcom_google_android_material_navigation_NavigationBarItemView_;

	private static Delegate? cb_findItemView_FindItemView_I_Lcom_google_android_material_navigation_NavigationBarItemView_;

	private static Delegate? cb_getBadge_GetBadge_I_Lcom_google_android_material_badge_BadgeDrawable_;

	private static Delegate? cb_initialize_Initialize_Landroidx_appcompat_view_menu_MenuBuilder__V;

	private static Delegate? cb_isShifting_IsShifting_II_Z;

	private static Delegate? cb_setItemOnTouchListener_SetItemOnTouchListener_ILandroid_view_View_OnTouchListener__V;

	private static Delegate? cb_setItemTextAppearanceActiveBoldEnabled_SetItemTextAppearanceActiveBoldEnabled_Z_V;

	private static Delegate? cb_setPresenter_SetPresenter_Lcom_google_android_material_navigation_NavigationBarPresenter__V;

	private static Delegate? cb_updateMenuView_UpdateMenuView_V;

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

	public unsafe virtual int ActiveIndicatorLabelPadding
	{
		[Register("getActiveIndicatorLabelPadding", "()I", "GetGetActiveIndicatorLabelPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getActiveIndicatorLabelPadding.()I", this, null);
		}
		[Register("setActiveIndicatorLabelPadding", "(I)V", "GetSetActiveIndicatorLabelPadding_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveIndicatorLabelPadding.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? IconTintList
	{
		[Register("getIconTintList", "()Landroid/content/res/ColorStateList;", "GetGetIconTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setIconTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetIconTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setIconTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? ItemActiveIndicatorColor
	{
		[Register("getItemActiveIndicatorColor", "()Landroid/content/res/ColorStateList;", "GetGetItemActiveIndicatorColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemActiveIndicatorColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setItemActiveIndicatorColor", "(Landroid/content/res/ColorStateList;)V", "GetSetItemActiveIndicatorColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setItemActiveIndicatorColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool ItemActiveIndicatorEnabled
	{
		[Register("getItemActiveIndicatorEnabled", "()Z", "GetGetItemActiveIndicatorEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getItemActiveIndicatorEnabled.()Z", this, null);
		}
		[Register("setItemActiveIndicatorEnabled", "(Z)V", "GetSetItemActiveIndicatorEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemActiveIndicatorEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ItemActiveIndicatorHeight
	{
		[Register("getItemActiveIndicatorHeight", "()I", "GetGetItemActiveIndicatorHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemActiveIndicatorHeight.()I", this, null);
		}
		[Register("setItemActiveIndicatorHeight", "(I)V", "GetSetItemActiveIndicatorHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemActiveIndicatorHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ItemActiveIndicatorMarginHorizontal
	{
		[Register("getItemActiveIndicatorMarginHorizontal", "()I", "GetGetItemActiveIndicatorMarginHorizontalHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemActiveIndicatorMarginHorizontal.()I", this, null);
		}
		[Register("setItemActiveIndicatorMarginHorizontal", "(I)V", "GetSetItemActiveIndicatorMarginHorizontal_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemActiveIndicatorMarginHorizontal.(I)V", this, ptr);
		}
	}

	protected unsafe virtual bool ItemActiveIndicatorResizeable
	{
		[Register("isItemActiveIndicatorResizeable", "()Z", "GetIsItemActiveIndicatorResizeableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemActiveIndicatorResizeable.()Z", this, null);
		}
		[Register("setItemActiveIndicatorResizeable", "(Z)V", "GetSetItemActiveIndicatorResizeable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemActiveIndicatorResizeable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ShapeAppearanceModel? ItemActiveIndicatorShapeAppearance
	{
		[Register("getItemActiveIndicatorShapeAppearance", "()Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetGetItemActiveIndicatorShapeAppearanceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemActiveIndicatorShapeAppearance.()Lcom/google/android/material/shape/ShapeAppearanceModel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setItemActiveIndicatorShapeAppearance", "(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", "GetSetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setItemActiveIndicatorShapeAppearance.(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ItemActiveIndicatorWidth
	{
		[Register("getItemActiveIndicatorWidth", "()I", "GetGetItemActiveIndicatorWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemActiveIndicatorWidth.()I", this, null);
		}
		[Register("setItemActiveIndicatorWidth", "(I)V", "GetSetItemActiveIndicatorWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemActiveIndicatorWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? ItemBackground
	{
		[Register("getItemBackground", "()Landroid/graphics/drawable/Drawable;", "GetGetItemBackgroundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemBackground.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setItemBackground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetItemBackground_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setItemBackground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ItemBackgroundRes
	{
		[Obsolete("deprecated")]
		[Register("getItemBackgroundRes", "()I", "GetGetItemBackgroundResHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemBackgroundRes.()I", this, null);
		}
		[Register("setItemBackgroundRes", "(I)V", "GetSetItemBackgroundRes_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemBackgroundRes.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ItemIconSize
	{
		[Register("getItemIconSize", "()I", "GetGetItemIconSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemIconSize.()I", this, null);
		}
		[Register("setItemIconSize", "(I)V", "GetSetItemIconSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemIconSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ItemPaddingBottom
	{
		[Register("getItemPaddingBottom", "()I", "GetGetItemPaddingBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemPaddingBottom.()I", this, null);
		}
		[Register("setItemPaddingBottom", "(I)V", "GetSetItemPaddingBottom_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemPaddingBottom.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ItemPaddingTop
	{
		[Register("getItemPaddingTop", "()I", "GetGetItemPaddingTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemPaddingTop.()I", this, null);
		}
		[Register("setItemPaddingTop", "(I)V", "GetSetItemPaddingTop_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemPaddingTop.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? ItemRippleColor
	{
		[Register("getItemRippleColor", "()Landroid/content/res/ColorStateList;", "GetGetItemRippleColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemRippleColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setItemRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetItemRippleColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setItemRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ItemTextAppearanceActive
	{
		[Register("getItemTextAppearanceActive", "()I", "GetGetItemTextAppearanceActiveHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemTextAppearanceActive.()I", this, null);
		}
		[Register("setItemTextAppearanceActive", "(I)V", "GetSetItemTextAppearanceActive_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemTextAppearanceActive.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ItemTextAppearanceInactive
	{
		[Register("getItemTextAppearanceInactive", "()I", "GetGetItemTextAppearanceInactiveHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemTextAppearanceInactive.()I", this, null);
		}
		[Register("setItemTextAppearanceInactive", "(I)V", "GetSetItemTextAppearanceInactive_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemTextAppearanceInactive.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? ItemTextColor
	{
		[Register("getItemTextColor", "()Landroid/content/res/ColorStateList;", "GetGetItemTextColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemTextColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setItemTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetItemTextColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setItemTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int LabelVisibilityMode
	{
		[Register("getLabelVisibilityMode", "()I", "GetGetLabelVisibilityModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLabelVisibilityMode.()I", this, null);
		}
		[Register("setLabelVisibilityMode", "(I)V", "GetSetLabelVisibilityMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLabelVisibilityMode.(I)V", this, ptr);
		}
	}

	protected unsafe virtual MenuBuilder? Menu
	{
		[Register("getMenu", "()Landroidx/appcompat/view/menu/MenuBuilder;", "GetGetMenuHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMenu.()Landroidx/appcompat/view/menu/MenuBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int SelectedItemId
	{
		[Register("getSelectedItemId", "()I", "GetGetSelectedItemIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectedItemId.()I", this, null);
		}
	}

	protected unsafe virtual int SelectedItemPosition
	{
		[Register("getSelectedItemPosition", "()I", "GetGetSelectedItemPositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectedItemPosition.()I", this, null);
		}
	}

	public unsafe virtual int WindowAnimations
	{
		[Register("getWindowAnimations", "()I", "GetGetWindowAnimationsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWindowAnimations.()I", this, null);
		}
	}

	protected NavigationBarMenuView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe NavigationBarMenuView(Context context)
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

	private static Delegate GetGetActiveIndicatorLabelPaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetActiveIndicatorLabelPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetActiveIndicatorLabelPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActiveIndicatorLabelPadding;
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
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActiveIndicatorLabelPadding = activeIndicatorLabelPadding;
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

	private static Delegate GetGetIconTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetIconTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIconTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTintList);
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
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList iconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.IconTintList = iconTintList;
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

	private static Delegate GetGetItemActiveIndicatorColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemActiveIndicatorColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemActiveIndicatorColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorColor);
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

	private static Delegate GetSetItemActiveIndicatorColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetItemActiveIndicatorColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemActiveIndicatorColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_csl)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemActiveIndicatorColor = Java.Lang.Object.GetObject<ColorStateList>(native_csl, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.ItemActiveIndicatorColor = itemActiveIndicatorColor;
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

	private static Delegate GetGetItemActiveIndicatorEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetItemActiveIndicatorEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetItemActiveIndicatorEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetItemActiveIndicatorEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetItemActiveIndicatorEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemActiveIndicatorEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool itemActiveIndicatorEnabled = native_enabled != 0;
			navigationBarMenuView.ItemActiveIndicatorEnabled = itemActiveIndicatorEnabled;
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

	private static Delegate GetGetItemActiveIndicatorHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemActiveIndicatorHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemActiveIndicatorHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorHeight;
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

	private static Delegate GetSetItemActiveIndicatorHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemActiveIndicatorHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemActiveIndicatorHeight_I(nint jnienv, nint native__this, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorHeight = height;
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

	private static Delegate GetGetItemActiveIndicatorMarginHorizontalHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemActiveIndicatorMarginHorizontal);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemActiveIndicatorMarginHorizontal(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorMarginHorizontal;
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

	private static Delegate GetSetItemActiveIndicatorMarginHorizontal_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemActiveIndicatorMarginHorizontal_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemActiveIndicatorMarginHorizontal_I(nint jnienv, nint native__this, int marginHorizontal)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorMarginHorizontal = marginHorizontal;
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

	private static Delegate GetIsItemActiveIndicatorResizeableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsItemActiveIndicatorResizeable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsItemActiveIndicatorResizeable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorResizeable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetItemActiveIndicatorResizeable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetItemActiveIndicatorResizeable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemActiveIndicatorResizeable_Z(nint jnienv, nint native__this, sbyte native_resizeable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool itemActiveIndicatorResizeable = native_resizeable != 0;
			navigationBarMenuView.ItemActiveIndicatorResizeable = itemActiveIndicatorResizeable;
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

	private static Delegate GetGetItemActiveIndicatorShapeAppearanceHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemActiveIndicatorShapeAppearance);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemActiveIndicatorShapeAppearance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorShapeAppearance);
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

	private static Delegate GetSetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel_(nint jnienv, nint native__this, nint native_shapeAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapeAppearanceModel itemActiveIndicatorShapeAppearance = Java.Lang.Object.GetObject<ShapeAppearanceModel>(native_shapeAppearance, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.ItemActiveIndicatorShapeAppearance = itemActiveIndicatorShapeAppearance;
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

	private static Delegate GetGetItemActiveIndicatorWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemActiveIndicatorWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemActiveIndicatorWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorWidth;
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

	private static Delegate GetSetItemActiveIndicatorWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemActiveIndicatorWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemActiveIndicatorWidth_I(nint jnienv, nint native__this, int width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorWidth = width;
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

	private static Delegate GetGetItemBackgroundHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemBackground);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemBackground(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemBackground);
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
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable itemBackground = Java.Lang.Object.GetObject<Drawable>(native_background, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.ItemBackground = itemBackground;
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

	[Obsolete]
	private static Delegate GetGetItemBackgroundResHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemBackgroundRes);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemBackgroundRes(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemBackgroundRes;
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

	private static Delegate GetSetItemBackgroundRes_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemBackgroundRes_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemBackgroundRes_I(nint jnienv, nint native__this, int background)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemBackgroundRes = background;
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

	private static Delegate GetGetItemIconSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemIconSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemIconSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemIconSize;
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

	private static Delegate GetSetItemIconSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemIconSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemIconSize_I(nint jnienv, nint native__this, int iconSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemIconSize = iconSize;
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

	private static Delegate GetGetItemPaddingBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemPaddingBottom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemPaddingBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingBottom;
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
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingBottom = paddingBottom;
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

	private static Delegate GetGetItemPaddingTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemPaddingTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemPaddingTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingTop;
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
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingTop = paddingTop;
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

	private static Delegate GetGetItemRippleColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemRippleColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemRippleColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemRippleColor);
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
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemRippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_itemRippleColor, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.ItemRippleColor = itemRippleColor;
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

	private static Delegate GetGetItemTextAppearanceActiveHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemTextAppearanceActive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemTextAppearanceActive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceActive;
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

	private static Delegate GetSetItemTextAppearanceActive_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemTextAppearanceActive_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemTextAppearanceActive_I(nint jnienv, nint native__this, int textAppearanceRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceActive = textAppearanceRes;
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

	private static Delegate GetGetItemTextAppearanceInactiveHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemTextAppearanceInactive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemTextAppearanceInactive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceInactive;
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

	private static Delegate GetSetItemTextAppearanceInactive_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemTextAppearanceInactive_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemTextAppearanceInactive_I(nint jnienv, nint native__this, int textAppearanceRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceInactive = textAppearanceRes;
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

	private static Delegate GetGetItemTextColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextColor);
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

	private static Delegate GetSetItemTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetItemTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.ItemTextColor = itemTextColor;
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

	private static Delegate GetGetLabelVisibilityModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLabelVisibilityMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLabelVisibilityMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelVisibilityMode;
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

	private static Delegate GetSetLabelVisibilityMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLabelVisibilityMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabelVisibilityMode_I(nint jnienv, nint native__this, int labelVisibilityMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelVisibilityMode = labelVisibilityMode;
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

	private static Delegate GetGetMenuHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Menu);
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

	private static Delegate GetGetSelectedItemIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSelectedItemId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSelectedItemId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedItemId;
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

	private static Delegate GetGetSelectedItemPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSelectedItemPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSelectedItemPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedItemPosition;
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

	private static Delegate GetGetWindowAnimationsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetWindowAnimations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWindowAnimations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WindowAnimations;
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

	private static Delegate GetBuildMenuViewHandler()
	{
		return new global::_JniMarshal_PP_V(n_BuildMenuView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BuildMenuView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BuildMenuView();
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

	[Register("buildMenuView", "()V", "GetBuildMenuViewHandler")]
	public unsafe virtual void BuildMenuView()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("buildMenuView.()V", this, null);
	}

	private static Delegate GetCreateDefaultColorStateList_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_CreateDefaultColorStateList_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateDefaultColorStateList_I(nint jnienv, nint native__this, int baseColorThemeAttr)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateDefaultColorStateList(baseColorThemeAttr));
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

	[Register("createDefaultColorStateList", "(I)Landroid/content/res/ColorStateList;", "GetCreateDefaultColorStateList_IHandler")]
	public unsafe virtual ColorStateList? CreateDefaultColorStateList(int baseColorThemeAttr)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(baseColorThemeAttr);
		return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("createDefaultColorStateList.(I)Landroid/content/res/ColorStateList;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCreateNavigationBarItemView_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_CreateNavigationBarItemView_Landroid_content_Context_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateNavigationBarItemView_Landroid_content_Context_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(navigationBarMenuView.CreateNavigationBarItemView(p));
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

	[Register("createNavigationBarItemView", "(Landroid/content/Context;)Lcom/google/android/material/navigation/NavigationBarItemView;", "GetCreateNavigationBarItemView_Landroid_content_Context_Handler")]
	protected abstract NavigationBarItemView CreateNavigationBarItemView(Context p0);

	private static Delegate GetFindItemView_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindItemView_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindItemView_I(nint jnienv, nint native__this, int menuItemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindItemView(menuItemId));
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

	[Register("findItemView", "(I)Lcom/google/android/material/navigation/NavigationBarItemView;", "GetFindItemView_IHandler")]
	public unsafe virtual NavigationBarItemView? FindItemView(int menuItemId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(menuItemId);
		return Java.Lang.Object.GetObject<NavigationBarItemView>(_members.InstanceMethods.InvokeVirtualObjectMethod("findItemView.(I)Lcom/google/android/material/navigation/NavigationBarItemView;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetBadge_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetBadge_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBadge_I(nint jnienv, nint native__this, int menuItemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBadge(menuItemId));
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

	[Register("getBadge", "(I)Lcom/google/android/material/badge/BadgeDrawable;", "GetGetBadge_IHandler")]
	public unsafe virtual BadgeDrawable? GetBadge(int menuItemId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(menuItemId);
		return Java.Lang.Object.GetObject<BadgeDrawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBadge.(I)Lcom/google/android/material/badge/BadgeDrawable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetInitialize_Landroidx_appcompat_view_menu_MenuBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Initialize_Landroidx_appcompat_view_menu_MenuBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Initialize_Landroidx_appcompat_view_menu_MenuBuilder_(nint jnienv, nint native__this, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder menu = Java.Lang.Object.GetObject<MenuBuilder>(native_menu, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.Initialize(menu);
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

	[Register("initialize", "(Landroidx/appcompat/view/menu/MenuBuilder;)V", "GetInitialize_Landroidx_appcompat_view_menu_MenuBuilder_Handler")]
	public unsafe virtual void Initialize(MenuBuilder menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(menu?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("initialize.(Landroidx/appcompat/view/menu/MenuBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetIsShifting_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_IsShifting_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShifting_II(nint jnienv, nint native__this, int labelVisibilityMode, int childCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsShifting(labelVisibilityMode, childCount) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isShifting", "(II)Z", "GetIsShifting_IIHandler")]
	protected unsafe virtual bool IsShifting(int labelVisibilityMode, int childCount)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(labelVisibilityMode);
		ptr[1] = new JniArgumentValue(childCount);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShifting.(II)Z", this, ptr);
	}

	private static Delegate GetSetItemOnTouchListener_ILandroid_view_View_OnTouchListener_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_SetItemOnTouchListener_ILandroid_view_View_OnTouchListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemOnTouchListener_ILandroid_view_View_OnTouchListener_(nint jnienv, nint native__this, int menuItemId, nint native_onTouchListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTouchListener onTouchListener = Java.Lang.Object.GetObject<IOnTouchListener>(native_onTouchListener, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.SetItemOnTouchListener(menuItemId, onTouchListener);
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

	[Register("setItemOnTouchListener", "(ILandroid/view/View$OnTouchListener;)V", "GetSetItemOnTouchListener_ILandroid_view_View_OnTouchListener_Handler")]
	public unsafe virtual void SetItemOnTouchListener(int menuItemId, IOnTouchListener? onTouchListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(menuItemId);
			ptr[1] = new JniArgumentValue((onTouchListener == null) ? IntPtr.Zero : ((Java.Lang.Object)onTouchListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemOnTouchListener.(ILandroid/view/View$OnTouchListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onTouchListener);
		}
	}

	private static Delegate GetSetItemTextAppearanceActiveBoldEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetItemTextAppearanceActiveBoldEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemTextAppearanceActiveBoldEnabled_Z(nint jnienv, nint native__this, sbyte native_isBold)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool itemTextAppearanceActiveBoldEnabled = native_isBold != 0;
			navigationBarMenuView.SetItemTextAppearanceActiveBoldEnabled(itemTextAppearanceActiveBoldEnabled);
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

	[Register("setItemTextAppearanceActiveBoldEnabled", "(Z)V", "GetSetItemTextAppearanceActiveBoldEnabled_ZHandler")]
	public unsafe virtual void SetItemTextAppearanceActiveBoldEnabled(bool isBold)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isBold ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setItemTextAppearanceActiveBoldEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetPresenter_Lcom_google_android_material_navigation_NavigationBarPresenter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPresenter_Lcom_google_android_material_navigation_NavigationBarPresenter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPresenter_Lcom_google_android_material_navigation_NavigationBarPresenter_(nint jnienv, nint native__this, nint native_presenter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarMenuView? navigationBarMenuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NavigationBarPresenter presenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(native_presenter, JniHandleOwnership.DoNotTransfer);
			navigationBarMenuView.SetPresenter(presenter);
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

	[Register("setPresenter", "(Lcom/google/android/material/navigation/NavigationBarPresenter;)V", "GetSetPresenter_Lcom_google_android_material_navigation_NavigationBarPresenter_Handler")]
	public unsafe virtual void SetPresenter(NavigationBarPresenter presenter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(presenter?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPresenter.(Lcom/google/android/material/navigation/NavigationBarPresenter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(presenter);
		}
	}

	private static Delegate GetUpdateMenuViewHandler()
	{
		return new global::_JniMarshal_PP_V(n_UpdateMenuView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateMenuView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateMenuView();
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

	[Register("updateMenuView", "()V", "GetUpdateMenuViewHandler")]
	public unsafe virtual void UpdateMenuView()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateMenuView.()V", this, null);
	}
}

using System;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Internal.View;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/core/internal/view/SupportMenuItem", "", "AndroidX.Core.Internal.View.ISupportMenuItemInvoker")]
public interface ISupportMenuItem : IMenuItem, IJavaObject, IDisposable, IJavaPeerable
{
	new Android.Views.View? ActionView
	{
		[Register("getActionView", "()Landroid/view/View;", "GetGetActionViewHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	new int AlphabeticModifiers
	{
		[Register("getAlphabeticModifiers", "()I", "GetGetAlphabeticModifiersHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	new ICharSequence? ContentDescriptionFormatted
	{
		[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	new ColorStateList? IconTintList
	{
		[Register("getIconTintList", "()Landroid/content/res/ColorStateList;", "GetGetIconTintListHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	new PorterDuff.Mode? IconTintMode
	{
		[Register("getIconTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetIconTintModeHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	new bool IsActionViewExpanded
	{
		[Register("isActionViewExpanded", "()Z", "GetIsActionViewExpandedHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	new int NumericModifiers
	{
		[Register("getNumericModifiers", "()I", "GetGetNumericModifiersHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	AndroidX.Core.View.ActionProvider? SupportActionProvider
	{
		[Register("getSupportActionProvider", "()Landroidx/core/view/ActionProvider;", "GetGetSupportActionProviderHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	new ICharSequence? TooltipTextFormatted
	{
		[Register("getTooltipText", "()Ljava/lang/CharSequence;", "GetGetTooltipTextHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
		get;
	}

	[Register("collapseActionView", "()Z", "GetCollapseActionViewHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new bool CollapseActionView();

	[Register("expandActionView", "()Z", "GetExpandActionViewHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new bool ExpandActionView();

	[Register("requiresActionButton", "()Z", "GetRequiresActionButtonHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	bool RequiresActionButton();

	[Register("requiresOverflow", "()Z", "GetRequiresOverflowHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	bool RequiresOverflow();

	[Register("setActionView", "(Landroid/view/View;)Landroid/view/MenuItem;", "GetSetActionView_Landroid_view_View_Handler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetActionView(Android.Views.View? view);

	[Register("setActionView", "(I)Landroid/view/MenuItem;", "GetSetActionView_IHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetActionView(int resId);

	[Register("setAlphabeticShortcut", "(CI)Landroid/view/MenuItem;", "GetSetAlphabeticShortcut_CIHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetAlphabeticShortcut(char alphaChar, int alphaModifiers);

	[Register("setContentDescription", "(Ljava/lang/CharSequence;)Landroidx/core/internal/view/SupportMenuItem;", "GetSetContentDescription_Ljava_lang_CharSequence_Handler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new ISupportMenuItem? SetContentDescription(ICharSequence? contentDescription);

	[Register("setIconTintList", "(Landroid/content/res/ColorStateList;)Landroid/view/MenuItem;", "GetSetIconTintList_Landroid_content_res_ColorStateList_Handler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetIconTintList(ColorStateList? tint);

	[Register("setIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)Landroid/view/MenuItem;", "GetSetIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetIconTintMode(PorterDuff.Mode? tintMode);

	[Register("setNumericShortcut", "(CI)Landroid/view/MenuItem;", "GetSetNumericShortcut_CIHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetNumericShortcut(char numericChar, int numericModifiers);

	[Register("setShortcut", "(CCII)Landroid/view/MenuItem;", "GetSetShortcut_CCIIHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetShortcut(char numericChar, char alphaChar, int numericModifiers, int alphaModifiers);

	[Register("setShowAsAction", "(I)V", "GetSetShowAsAction_IHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new void SetShowAsAction(ShowAsAction actionEnum);

	[Register("setShowAsActionFlags", "(I)Landroid/view/MenuItem;", "GetSetShowAsActionFlags_IHandler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new IMenuItem? SetShowAsActionFlags(ShowAsAction actionEnum);

	[Register("setSupportActionProvider", "(Landroidx/core/view/ActionProvider;)Landroidx/core/internal/view/SupportMenuItem;", "GetSetSupportActionProvider_Landroidx_core_view_ActionProvider_Handler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	ISupportMenuItem? SetSupportActionProvider(AndroidX.Core.View.ActionProvider? actionProvider);

	[Register("setTooltipText", "(Ljava/lang/CharSequence;)Landroidx/core/internal/view/SupportMenuItem;", "GetSetTooltipText_Ljava_lang_CharSequence_Handler:AndroidX.Core.Internal.View.ISupportMenuItemInvoker, Xamarin.AndroidX.Core")]
	new ISupportMenuItem? SetTooltipText(ICharSequence? tooltipText);
}

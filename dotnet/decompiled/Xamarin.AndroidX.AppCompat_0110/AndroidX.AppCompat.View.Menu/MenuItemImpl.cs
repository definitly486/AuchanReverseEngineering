using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.Internal.View;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View.Menu;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/appcompat/view/menu/MenuItemImpl", DoNotGenerateAcw = true)]
public sealed class MenuItemImpl : Java.Lang.Object, ISupportMenuItem, IMenuItem, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/view/menu/MenuItemImpl", typeof(MenuItemImpl));

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

	public unsafe Android.Views.ActionProvider? ActionProvider
	{
		[Register("getActionProvider", "()Landroid/view/ActionProvider;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.ActionProvider>(_members.InstanceMethods.InvokeAbstractObjectMethod("getActionProvider.()Landroid/view/ActionProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Android.Views.View? ActionView
	{
		[Register("getActionView", "()Landroid/view/View;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getActionView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int AlphabeticModifiers
	{
		[Register("getAlphabeticModifiers", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getAlphabeticModifiers.()I", this, null);
		}
	}

	public unsafe char AlphabeticShortcut
	{
		[Register("getAlphabeticShortcut", "()C", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractCharMethod("getAlphabeticShortcut.()C", this, null);
		}
	}

	public unsafe ICharSequence? ContentDescriptionFormatted
	{
		[Register("getContentDescription", "()Ljava/lang/CharSequence;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? ContentDescription
	{
		get
		{
			if (ContentDescriptionFormatted != null)
			{
				return ContentDescriptionFormatted.ToString();
			}
			return null;
		}
	}

	public unsafe bool ExclusiveCheckable
	{
		[Register("isExclusiveCheckable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isExclusiveCheckable.()Z", this, null);
		}
		[Register("setExclusiveCheckable", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setExclusiveCheckable.(Z)V", this, ptr);
		}
	}

	public unsafe int GroupId
	{
		[Register("getGroupId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getGroupId.()I", this, null);
		}
	}

	public unsafe bool HasCollapsibleActionView
	{
		[Register("hasCollapsibleActionView", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasCollapsibleActionView.()Z", this, null);
		}
	}

	public unsafe bool HasSubMenu
	{
		[Register("hasSubMenu", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasSubMenu.()Z", this, null);
		}
	}

	public unsafe Drawable? Icon
	{
		[Register("getIcon", "()Landroid/graphics/drawable/Drawable;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ColorStateList? IconTintList
	{
		[Register("getIconTintList", "()Landroid/content/res/ColorStateList;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIconTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe PorterDuff.Mode? IconTintMode
	{
		[Register("getIconTintMode", "()Landroid/graphics/PorterDuff$Mode;", "")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIconTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Intent? Intent
	{
		[Register("getIntent", "()Landroid/content/Intent;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeAbstractObjectMethod("getIntent.()Landroid/content/Intent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe bool IsActionButton
	{
		[Register("isActionButton", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isActionButton.()Z", this, null);
		}
		[Register("setIsActionButton", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setIsActionButton.(Z)V", this, ptr);
		}
	}

	public unsafe bool IsActionViewExpanded
	{
		[Register("isActionViewExpanded", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isActionViewExpanded.()Z", this, null);
		}
	}

	public unsafe bool IsCheckable
	{
		[Register("isCheckable", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCheckable.()Z", this, null);
		}
	}

	public unsafe bool IsChecked
	{
		[Register("isChecked", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isChecked.()Z", this, null);
		}
	}

	public unsafe bool IsEnabled
	{
		[Register("isEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isEnabled.()Z", this, null);
		}
	}

	public unsafe bool IsVisible
	{
		[Register("isVisible", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
		}
	}

	public unsafe int ItemId
	{
		[Register("getItemId", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getItemId.()I", this, null);
		}
	}

	public unsafe IContextMenuContextMenuInfo? MenuInfo
	{
		[Register("getMenuInfo", "()Landroid/view/ContextMenu$ContextMenuInfo;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IContextMenuContextMenuInfo>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMenuInfo.()Landroid/view/ContextMenu$ContextMenuInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int NumericModifiers
	{
		[Register("getNumericModifiers", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getNumericModifiers.()I", this, null);
		}
	}

	public unsafe char NumericShortcut
	{
		[Register("getNumericShortcut", "()C", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractCharMethod("getNumericShortcut.()C", this, null);
		}
	}

	public unsafe int Order
	{
		[Register("getOrder", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getOrder.()I", this, null);
		}
	}

	public unsafe int Ordering
	{
		[Register("getOrdering", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getOrdering.()I", this, null);
		}
	}

	public unsafe ISubMenu? SubMenu
	{
		[Register("getSubMenu", "()Landroid/view/SubMenu;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSubMenu.()Landroid/view/SubMenu;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe AndroidX.Core.View.ActionProvider? SupportActionProvider
	{
		[Register("getSupportActionProvider", "()Landroidx/core/view/ActionProvider;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.Core.View.ActionProvider>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSupportActionProvider.()Landroidx/core/view/ActionProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? Title
	{
		get
		{
			if (TitleFormatted != null)
			{
				return TitleFormatted.ToString();
			}
			return null;
		}
	}

	public unsafe ICharSequence? TitleCondensedFormatted
	{
		[Register("getTitleCondensed", "()Ljava/lang/CharSequence;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitleCondensed.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? TitleCondensed
	{
		get
		{
			if (TitleCondensedFormatted != null)
			{
				return TitleCondensedFormatted.ToString();
			}
			return null;
		}
	}

	public unsafe ICharSequence? TooltipTextFormatted
	{
		[Register("getTooltipText", "()Ljava/lang/CharSequence;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTooltipText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? TooltipText
	{
		get
		{
			if (TooltipTextFormatted != null)
			{
				return TooltipTextFormatted.ToString();
			}
			return null;
		}
	}

	internal MenuItemImpl(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("actionFormatChanged", "()V", "")]
	public unsafe void ActionFormatChanged()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("actionFormatChanged.()V", this, null);
	}

	[Register("collapseActionView", "()Z", "")]
	public unsafe bool CollapseActionView()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("collapseActionView.()Z", this, null);
	}

	[Register("expandActionView", "()Z", "")]
	public unsafe bool ExpandActionView()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("expandActionView.()Z", this, null);
	}

	[Register("invoke", "()Z", "")]
	public unsafe bool Invoke()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("invoke.()Z", this, null);
	}

	[Register("requestsActionButton", "()Z", "")]
	public unsafe bool RequestsActionButton()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("requestsActionButton.()Z", this, null);
	}

	[Register("requiresActionButton", "()Z", "")]
	public unsafe bool RequiresActionButton()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("requiresActionButton.()Z", this, null);
	}

	[Register("requiresOverflow", "()Z", "")]
	public unsafe bool RequiresOverflow()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("requiresOverflow.()Z", this, null);
	}

	[Register("setActionProvider", "(Landroid/view/ActionProvider;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetActionProvider(Android.Views.ActionProvider? actionProvider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(actionProvider?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionProvider.(Landroid/view/ActionProvider;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(actionProvider);
		}
	}

	[Register("setActionView", "(Landroid/view/View;)Landroidx/core/internal/view/SupportMenuItem;", "")]
	public unsafe IMenuItem SetActionView(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionView.(Landroid/view/View;)Landroidx/core/internal/view/SupportMenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("setActionView", "(I)Landroidx/core/internal/view/SupportMenuItem;", "")]
	public unsafe IMenuItem SetActionView(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setActionView.(I)Landroidx/core/internal/view/SupportMenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setActionViewExpanded", "(Z)V", "")]
	public unsafe void SetActionViewExpanded(bool isExpanded)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isExpanded ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setActionViewExpanded.(Z)V", this, ptr);
	}

	[Register("setAlphabeticShortcut", "(C)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetAlphabeticShortcut(char alphaChar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)alphaChar);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAlphabeticShortcut.(C)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setAlphabeticShortcut", "(CI)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem SetAlphabeticShortcut(char alphaChar, int alphaModifiers)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((ushort)alphaChar);
		ptr[1] = new JniArgumentValue(alphaModifiers);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAlphabeticShortcut.(CI)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setCallback", "(Ljava/lang/Runnable;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetCallback(IRunnable? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCallback.(Ljava/lang/Runnable;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("setCheckable", "(Z)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetCheckable(bool checkable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(checkable ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setCheckable.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setChecked", "(Z)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetChecked(bool @checked)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(@checked ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setChecked.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setContentDescription", "(Ljava/lang/CharSequence;)Landroidx/core/internal/view/SupportMenuItem;", "")]
	public unsafe ISupportMenuItem SetContentDescription(ICharSequence? contentDescription)
	{
		nint num = CharSequence.ToLocalJniHandle(contentDescription);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISupportMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setContentDescription.(Ljava/lang/CharSequence;)Landroidx/core/internal/view/SupportMenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(contentDescription);
		}
	}

	public ISupportMenuItem SetContentDescription(string? contentDescription)
	{
		Java.Lang.String obj = ((contentDescription == null) ? null : new Java.Lang.String(contentDescription));
		ISupportMenuItem result = SetContentDescription(obj);
		obj?.Dispose();
		return result;
	}

	[Register("setEnabled", "(Z)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setEnabled.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(Landroid/graphics/drawable/Drawable;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	[Register("setIcon", "(I)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetIcon(int iconResId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconResId);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setIconTintList", "(Landroid/content/res/ColorStateList;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem SetIconTintList(ColorStateList? iconTintList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(iconTintList?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIconTintList.(Landroid/content/res/ColorStateList;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(iconTintList);
		}
	}

	[Register("setIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem SetIconTintMode(PorterDuff.Mode? iconTintMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(iconTintMode?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIconTintMode.(Landroid/graphics/PorterDuff$Mode;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(iconTintMode);
		}
	}

	[Register("setIntent", "(Landroid/content/Intent;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetIntent(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIntent.(Landroid/content/Intent;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	[Register("setNumericShortcut", "(C)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetNumericShortcut(char numericChar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)numericChar);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNumericShortcut.(C)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setNumericShortcut", "(CI)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem SetNumericShortcut(char numericChar, int numericModifiers)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((ushort)numericChar);
		ptr[1] = new JniArgumentValue(numericModifiers);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setNumericShortcut.(CI)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setOnActionExpandListener", "(Landroid/view/MenuItem$OnActionExpandListener;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetOnActionExpandListener(IMenuItemOnActionExpandListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnActionExpandListener.(Landroid/view/MenuItem$OnActionExpandListener;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("setOnMenuItemClickListener", "(Landroid/view/MenuItem$OnMenuItemClickListener;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetOnMenuItemClickListener(IMenuItemOnMenuItemClickListener? clickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((clickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)clickListener).Handle);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setOnMenuItemClickListener.(Landroid/view/MenuItem$OnMenuItemClickListener;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(clickListener);
		}
	}

	[Register("setShortcut", "(CC)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetShortcut(char numericChar, char alphaChar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((ushort)numericChar);
		ptr[1] = new JniArgumentValue((ushort)alphaChar);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShortcut.(CC)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setShortcut", "(CCII)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem SetShortcut(char numericChar, char alphaChar, int numericModifiers, int alphaModifiers)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue((ushort)numericChar);
		ptr[1] = new JniArgumentValue((ushort)alphaChar);
		ptr[2] = new JniArgumentValue(numericModifiers);
		ptr[3] = new JniArgumentValue(alphaModifiers);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShortcut.(CCII)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setShowAsAction", "(I)V", "")]
	public unsafe void SetShowAsAction(ShowAsAction actionEnum)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)actionEnum);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setShowAsAction.(I)V", this, ptr);
	}

	[Register("setShowAsActionFlags", "(I)Landroidx/core/internal/view/SupportMenuItem;", "")]
	public unsafe IMenuItem SetShowAsActionFlags(ShowAsAction actionEnum)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)actionEnum);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setShowAsActionFlags.(I)Landroidx/core/internal/view/SupportMenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setSubMenu", "(Landroidx/appcompat/view/menu/SubMenuBuilder;)V", "")]
	public unsafe void SetSubMenu(SubMenuBuilder? subMenu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(subMenu?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setSubMenu.(Landroidx/appcompat/view/menu/SubMenuBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(subMenu);
		}
	}

	[Register("setSupportActionProvider", "(Landroidx/core/view/ActionProvider;)Landroidx/core/internal/view/SupportMenuItem;", "")]
	public unsafe ISupportMenuItem SetSupportActionProvider(AndroidX.Core.View.ActionProvider? actionProvider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(actionProvider?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ISupportMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSupportActionProvider.(Landroidx/core/view/ActionProvider;)Landroidx/core/internal/view/SupportMenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(actionProvider);
		}
	}

	[Register("setTitle", "(I)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetTitle(int title)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(title);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTitle.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setTitle", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetTitle(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTitle.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public IMenuItem? SetTitle(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		IMenuItem? result = SetTitle(obj);
		obj?.Dispose();
		return result;
	}

	[Register("setTitleCondensed", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetTitleCondensed(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTitleCondensed.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public IMenuItem? SetTitleCondensed(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		IMenuItem? result = SetTitleCondensed(obj);
		obj?.Dispose();
		return result;
	}

	[Register("setTooltipText", "(Ljava/lang/CharSequence;)Landroidx/core/internal/view/SupportMenuItem;", "")]
	public unsafe ISupportMenuItem SetTooltipText(ICharSequence? tooltipText)
	{
		nint num = CharSequence.ToLocalJniHandle(tooltipText);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISupportMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTooltipText.(Ljava/lang/CharSequence;)Landroidx/core/internal/view/SupportMenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tooltipText);
		}
	}

	public ISupportMenuItem SetTooltipText(string? tooltipText)
	{
		Java.Lang.String obj = ((tooltipText == null) ? null : new Java.Lang.String(tooltipText));
		ISupportMenuItem result = SetTooltipText(obj);
		obj?.Dispose();
		return result;
	}

	[Register("setVisible", "(Z)Landroid/view/MenuItem;", "")]
	public unsafe IMenuItem? SetVisible(bool shown)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shown ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeAbstractObjectMethod("setVisible.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("shouldShowIcon", "()Z", "")]
	public unsafe bool ShouldShowIcon()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("shouldShowIcon.()Z", this, null);
	}

	[Register("showsTextAsAction", "()Z", "")]
	public unsafe bool ShowsTextAsAction()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("showsTextAsAction.()Z", this, null);
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

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/ActionBar", DoNotGenerateAcw = true)]
internal class ActionBarInvoker : ActionBar
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/ActionBar", typeof(ActionBarInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override Android.Views.View? CustomView
	{
		[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCustomView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCustomView", "(Landroid/view/View;)V", "GetSetCustomView_Landroid_view_View_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setCustomView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe override int DisplayOptions
	{
		[Register("getDisplayOptions", "()I", "GetGetDisplayOptionsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getDisplayOptions.()I", this, null);
		}
		[Register("setDisplayOptions", "(I)V", "GetSetDisplayOptions_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayOptions.(I)V", this, ptr);
		}
	}

	public unsafe override int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);
		}
	}

	public unsafe override bool IsShowing
	{
		[Register("isShowing", "()Z", "GetIsShowingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isShowing.()Z", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe override int NavigationItemCount
	{
		[Register("getNavigationItemCount", "()I", "GetGetNavigationItemCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getNavigationItemCount.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe override int NavigationMode
	{
		[Register("getNavigationMode", "()I", "GetGetNavigationModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getNavigationMode.()I", this, null);
		}
		[Register("setNavigationMode", "(I)V", "GetSetNavigationMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setNavigationMode.(I)V", this, ptr);
		}
	}

	[Obsolete("deprecated")]
	public unsafe override int SelectedNavigationIndex
	{
		[Register("getSelectedNavigationIndex", "()I", "GetGetSelectedNavigationIndexHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSelectedNavigationIndex.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe override Tab? SelectedTab
	{
		[Register("getSelectedTab", "()Landroidx/appcompat/app/ActionBar$Tab;", "GetGetSelectedTabHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSelectedTab.()Landroidx/appcompat/app/ActionBar$Tab;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override ICharSequence? SubtitleFormatted
	{
		[Register("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSubtitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetSubtitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setSubtitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe override int TabCount
	{
		[Register("getTabCount", "()I", "GetGetTabCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getTabCount.()I", this, null);
		}
	}

	public unsafe override ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public ActionBarInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("addOnMenuVisibilityListener", "(Landroidx/appcompat/app/ActionBar$OnMenuVisibilityListener;)V", "GetAddOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_Handler")]
	public unsafe override void AddOnMenuVisibilityListener(IOnMenuVisibilityListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addOnMenuVisibilityListener.(Landroidx/appcompat/app/ActionBar$OnMenuVisibilityListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Obsolete("deprecated")]
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_Handler")]
	public unsafe override void AddTab(Tab? tab)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addTab.(Landroidx/appcompat/app/ActionBar$Tab;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	[Obsolete("deprecated")]
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;Z)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_ZHandler")]
	public unsafe override void AddTab(Tab? tab, bool setSelected)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(setSelected ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("addTab.(Landroidx/appcompat/app/ActionBar$Tab;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	[Obsolete("deprecated")]
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;I)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IHandler")]
	public unsafe override void AddTab(Tab? tab, int position)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addTab.(Landroidx/appcompat/app/ActionBar$Tab;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	[Obsolete("deprecated")]
	[Register("addTab", "(Landroidx/appcompat/app/ActionBar$Tab;IZ)V", "GetAddTab_Landroidx_appcompat_app_ActionBar_Tab_IZHandler")]
	public unsafe override void AddTab(Tab? tab, int position, bool setSelected)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(setSelected ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("addTab.(Landroidx/appcompat/app/ActionBar$Tab;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	[Obsolete("deprecated")]
	[Register("getTabAt", "(I)Landroidx/appcompat/app/ActionBar$Tab;", "GetGetTabAt_IHandler")]
	public unsafe override Tab? GetTabAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTabAt.(I)Landroidx/appcompat/app/ActionBar$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("hide", "()V", "GetHideHandler")]
	public unsafe override void Hide()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("hide.()V", this, null);
	}

	[Obsolete("deprecated")]
	[Register("newTab", "()Landroidx/appcompat/app/ActionBar$Tab;", "GetNewTabHandler")]
	public unsafe override Tab? NewTab()
	{
		return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("newTab.()Landroidx/appcompat/app/ActionBar$Tab;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("deprecated")]
	[Register("removeAllTabs", "()V", "GetRemoveAllTabsHandler")]
	public unsafe override void RemoveAllTabs()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("removeAllTabs.()V", this, null);
	}

	[Register("removeOnMenuVisibilityListener", "(Landroidx/appcompat/app/ActionBar$OnMenuVisibilityListener;)V", "GetRemoveOnMenuVisibilityListener_Landroidx_appcompat_app_ActionBar_OnMenuVisibilityListener_Handler")]
	public unsafe override void RemoveOnMenuVisibilityListener(IOnMenuVisibilityListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeOnMenuVisibilityListener.(Landroidx/appcompat/app/ActionBar$OnMenuVisibilityListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Obsolete("deprecated")]
	[Register("removeTab", "(Landroidx/appcompat/app/ActionBar$Tab;)V", "GetRemoveTab_Landroidx_appcompat_app_ActionBar_Tab_Handler")]
	public unsafe override void RemoveTab(Tab? tab)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeTab.(Landroidx/appcompat/app/ActionBar$Tab;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	[Obsolete("deprecated")]
	[Register("removeTabAt", "(I)V", "GetRemoveTabAt_IHandler")]
	public unsafe override void RemoveTabAt(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeAbstractVoidMethod("removeTabAt.(I)V", this, ptr);
	}

	[Obsolete("deprecated")]
	[Register("selectTab", "(Landroidx/appcompat/app/ActionBar$Tab;)V", "GetSelectTab_Landroidx_appcompat_app_ActionBar_Tab_Handler")]
	public unsafe override void SelectTab(Tab? tab)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("selectTab.(Landroidx/appcompat/app/ActionBar$Tab;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	[Register("setBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe override void SetBackgroundDrawable(Drawable? d)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setBackgroundDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(d);
		}
	}

	[Register("setCustomView", "(Landroid/view/View;Landroidx/appcompat/app/ActionBar$LayoutParams;)V", "GetSetCustomView_Landroid_view_View_Landroidx_appcompat_app_ActionBar_LayoutParams_Handler")]
	public unsafe override void SetCustomView(Android.Views.View? view, LayoutParams? layoutParams)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setCustomView.(Landroid/view/View;Landroidx/appcompat/app/ActionBar$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(layoutParams);
		}
	}

	[Register("setCustomView", "(I)V", "GetSetCustomView_IHandler")]
	public unsafe override void SetCustomView(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setCustomView.(I)V", this, ptr);
	}

	[Register("setDisplayHomeAsUpEnabled", "(Z)V", "GetSetDisplayHomeAsUpEnabled_ZHandler")]
	public unsafe override void SetDisplayHomeAsUpEnabled(bool showHomeAsUp)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(showHomeAsUp ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayHomeAsUpEnabled.(Z)V", this, ptr);
	}

	[Register("setDisplayOptions", "(II)V", "GetSetDisplayOptions_IIHandler")]
	public unsafe override void SetDisplayOptions(int options, int mask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(options);
		ptr[1] = new JniArgumentValue(mask);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayOptions.(II)V", this, ptr);
	}

	[Register("setDisplayShowCustomEnabled", "(Z)V", "GetSetDisplayShowCustomEnabled_ZHandler")]
	public unsafe override void SetDisplayShowCustomEnabled(bool showCustom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(showCustom ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayShowCustomEnabled.(Z)V", this, ptr);
	}

	[Register("setDisplayShowHomeEnabled", "(Z)V", "GetSetDisplayShowHomeEnabled_ZHandler")]
	public unsafe override void SetDisplayShowHomeEnabled(bool showHome)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(showHome ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayShowHomeEnabled.(Z)V", this, ptr);
	}

	[Register("setDisplayShowTitleEnabled", "(Z)V", "GetSetDisplayShowTitleEnabled_ZHandler")]
	public unsafe override void SetDisplayShowTitleEnabled(bool showTitle)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(showTitle ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayShowTitleEnabled.(Z)V", this, ptr);
	}

	[Register("setDisplayUseLogoEnabled", "(Z)V", "GetSetDisplayUseLogoEnabled_ZHandler")]
	public unsafe override void SetDisplayUseLogoEnabled(bool useLogo)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(useLogo ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setDisplayUseLogoEnabled.(Z)V", this, ptr);
	}

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe override void SetIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	[Register("setIcon", "(I)V", "GetSetIcon_IHandler")]
	public unsafe override void SetIcon(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(I)V", this, ptr);
	}

	[Obsolete("deprecated")]
	[Register("setListNavigationCallbacks", "(Landroid/widget/SpinnerAdapter;Landroidx/appcompat/app/ActionBar$OnNavigationListener;)V", "GetSetListNavigationCallbacks_Landroid_widget_SpinnerAdapter_Landroidx_appcompat_app_ActionBar_OnNavigationListener_Handler")]
	public unsafe override void SetListNavigationCallbacks(ISpinnerAdapter? adapter, IOnNavigationListener? callback_)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((adapter == null) ? IntPtr.Zero : ((Java.Lang.Object)adapter).Handle);
			ptr[1] = new JniArgumentValue((callback_ == null) ? IntPtr.Zero : ((Java.Lang.Object)callback_).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setListNavigationCallbacks.(Landroid/widget/SpinnerAdapter;Landroidx/appcompat/app/ActionBar$OnNavigationListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
			GC.KeepAlive(callback_);
		}
	}

	[Register("setLogo", "(Landroid/graphics/drawable/Drawable;)V", "GetSetLogo_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe override void SetLogo(Drawable? logo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(logo?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setLogo.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(logo);
		}
	}

	[Register("setLogo", "(I)V", "GetSetLogo_IHandler")]
	public unsafe override void SetLogo(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setLogo.(I)V", this, ptr);
	}

	[Obsolete("deprecated")]
	[Register("setSelectedNavigationItem", "(I)V", "GetSetSelectedNavigationItem_IHandler")]
	public unsafe override void SetSelectedNavigationItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setSelectedNavigationItem.(I)V", this, ptr);
	}

	[Register("setSubtitle", "(I)V", "GetSetSubtitle_IHandler")]
	public unsafe override void SetSubtitle(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setSubtitle.(I)V", this, ptr);
	}

	[Register("setTitle", "(I)V", "GetSetTitle_IHandler")]
	public unsafe override void SetTitle(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(I)V", this, ptr);
	}

	[Register("show", "()V", "GetShowHandler")]
	public unsafe override void Show()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("show.()V", this, null);
	}
}

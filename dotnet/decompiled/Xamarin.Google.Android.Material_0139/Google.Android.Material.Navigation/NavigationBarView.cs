using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.View.Menu;
using Google.Android.Material.Badge;
using Google.Android.Material.Shape;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Navigation;

[Register("com/google/android/material/navigation/NavigationBarView", DoNotGenerateAcw = true)]
public abstract class NavigationBarView : FrameLayout
{
	public class ItemSelectedEventArgs : EventArgs
	{
		private bool handled;

		private IMenuItem p0;

		public IMenuItem Item => P0;

		public bool Handled
		{
			get
			{
				return handled;
			}
			set
			{
				handled = value;
			}
		}

		public IMenuItem P0 => p0;

		public ItemSelectedEventArgs(bool handled, IMenuItem p0)
		{
			this.handled = handled;
			this.p0 = p0;
		}
	}

	public class ItemReselectedEventArgs : EventArgs
	{
		private IMenuItem p0;

		public ItemReselectedEventArgs(IMenuItem p0)
		{
			this.p0 = p0;
		}
	}

	[Register("com/google/android/material/navigation/NavigationBarView$OnItemReselectedListener", "", "Google.Android.Material.Navigation.NavigationBarView/IOnItemReselectedListenerInvoker")]
	public interface IOnItemReselectedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onNavigationItemReselected", "(Landroid/view/MenuItem;)V", "GetOnNavigationItemReselected_Landroid_view_MenuItem_Handler:Google.Android.Material.Navigation.NavigationBarView/IOnItemReselectedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnNavigationItemReselected(IMenuItem p0);
	}

	[Register("com/google/android/material/navigation/NavigationBarView$OnItemReselectedListener", DoNotGenerateAcw = true)]
	internal class IOnItemReselectedListenerInvoker : Java.Lang.Object, IOnItemReselectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_navigation_NavigationBarView_OnItemReselectedListener = new XAPeerMembers("com/google/android/material/navigation/NavigationBarView$OnItemReselectedListener", typeof(IOnItemReselectedListenerInvoker));

		private static Delegate? cb_onNavigationItemReselected_OnNavigationItemReselected_Landroid_view_MenuItem__V;

		private static nint java_class_ref => _members_com_google_android_material_navigation_NavigationBarView_OnItemReselectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_navigation_NavigationBarView_OnItemReselectedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_navigation_NavigationBarView_OnItemReselectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_navigation_NavigationBarView_OnItemReselectedListener.ManagedPeerType;

		public IOnItemReselectedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnNavigationItemReselected_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnItemReselectedListener? onItemReselectedListener = Java.Lang.Object.GetObject<IOnItemReselectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenuItem p = Java.Lang.Object.GetObject<IMenuItem>(native_p0, JniHandleOwnership.DoNotTransfer);
				onItemReselectedListener.OnNavigationItemReselected(p);
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

		public unsafe void OnNavigationItemReselected(IMenuItem p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				_members_com_google_android_material_navigation_NavigationBarView_OnItemReselectedListener.InstanceMethods.InvokeAbstractVoidMethod("onNavigationItemReselected.(Landroid/view/MenuItem;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
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

		[UnmanagedCallersOnly]
		private static void n_OnNavigationItemReselected_Landroid_view_MenuItem__mm_wrapper(nint jnienv, nint native__this, nint native_p0)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnNavigationItemReselected_Landroid_view_MenuItem_(jnienv, native__this, native_p0);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("mono/com/google/android/material/navigation/NavigationBarView_OnItemReselectedListenerImplementor")]
	internal sealed class IOnItemReselectedListenerImplementor : Java.Lang.Object, IOnItemReselectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ItemReselectedEventArgs>? Handler;

		public unsafe IOnItemReselectedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnNavigationItemReselected(IMenuItem p0)
		{
			Handler?.Invoke(sender, new ItemReselectedEventArgs(p0));
		}

		internal static bool __IsEmpty(IOnItemReselectedListenerImplementor value)
		{
			return value.Handler == null;
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

	[Register("com/google/android/material/navigation/NavigationBarView$OnItemSelectedListener", "", "Google.Android.Material.Navigation.NavigationBarView/IOnItemSelectedListenerInvoker")]
	public interface IOnItemSelectedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onNavigationItemSelected", "(Landroid/view/MenuItem;)Z", "GetOnNavigationItemSelected_Landroid_view_MenuItem_Handler:Google.Android.Material.Navigation.NavigationBarView/IOnItemSelectedListenerInvoker, Xamarin.Google.Android.Material")]
		bool OnNavigationItemSelected(IMenuItem p0);
	}

	[Register("com/google/android/material/navigation/NavigationBarView$OnItemSelectedListener", DoNotGenerateAcw = true)]
	internal class IOnItemSelectedListenerInvoker : Java.Lang.Object, IOnItemSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_navigation_NavigationBarView_OnItemSelectedListener = new XAPeerMembers("com/google/android/material/navigation/NavigationBarView$OnItemSelectedListener", typeof(IOnItemSelectedListenerInvoker));

		private static Delegate? cb_onNavigationItemSelected_OnNavigationItemSelected_Landroid_view_MenuItem__Z;

		private static nint java_class_ref => _members_com_google_android_material_navigation_NavigationBarView_OnItemSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_navigation_NavigationBarView_OnItemSelectedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_navigation_NavigationBarView_OnItemSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_navigation_NavigationBarView_OnItemSelectedListener.ManagedPeerType;

		public IOnItemSelectedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnNavigationItemSelected_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnItemSelectedListener? onItemSelectedListener = Java.Lang.Object.GetObject<IOnItemSelectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenuItem p = Java.Lang.Object.GetObject<IMenuItem>(native_p0, JniHandleOwnership.DoNotTransfer);
				return onItemSelectedListener.OnNavigationItemSelected(p) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnNavigationItemSelected(IMenuItem p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return _members_com_google_android_material_navigation_NavigationBarView_OnItemSelectedListener.InstanceMethods.InvokeAbstractBooleanMethod("onNavigationItemSelected.(Landroid/view/MenuItem;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
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

		[UnmanagedCallersOnly]
		private static sbyte n_OnNavigationItemSelected_Landroid_view_MenuItem__mm_wrapper(nint jnienv, nint native__this, nint native_p0)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnNavigationItemSelected_Landroid_view_MenuItem_(jnienv, native__this, native_p0);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("mono/com/google/android/material/navigation/NavigationBarView_OnItemSelectedListenerImplementor")]
	internal sealed class IOnItemSelectedListenerImplementor : Java.Lang.Object, IOnItemSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ItemSelectedEventArgs>? Handler;

		public unsafe IOnItemSelectedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnNavigationItemSelected(IMenuItem p0)
		{
			EventHandler<ItemSelectedEventArgs> handler = Handler;
			if (handler == null)
			{
				return false;
			}
			ItemSelectedEventArgs e = new ItemSelectedEventArgs(handled: true, p0);
			handler(sender, e);
			return e.Handled;
		}

		internal static bool __IsEmpty(IOnItemSelectedListenerImplementor value)
		{
			return value.Handler == null;
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/navigation/NavigationBarView", typeof(NavigationBarView));

	private static Delegate? cb_getActiveIndicatorLabelPadding_GetActiveIndicatorLabelPadding_I;

	private static Delegate? cb_setActiveIndicatorLabelPadding_SetActiveIndicatorLabelPadding_I_V;

	private static Delegate? cb_getItemActiveIndicatorColor_GetItemActiveIndicatorColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setItemActiveIndicatorColor_SetItemActiveIndicatorColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_isItemActiveIndicatorEnabled_IsItemActiveIndicatorEnabled_Z;

	private static Delegate? cb_setItemActiveIndicatorEnabled_SetItemActiveIndicatorEnabled_Z_V;

	private static Delegate? cb_getItemActiveIndicatorHeight_GetItemActiveIndicatorHeight_I;

	private static Delegate? cb_setItemActiveIndicatorHeight_SetItemActiveIndicatorHeight_I_V;

	private static Delegate? cb_getItemActiveIndicatorMarginHorizontal_GetItemActiveIndicatorMarginHorizontal_I;

	private static Delegate? cb_setItemActiveIndicatorMarginHorizontal_SetItemActiveIndicatorMarginHorizontal_I_V;

	private static Delegate? cb_getItemActiveIndicatorShapeAppearance_GetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_setItemActiveIndicatorShapeAppearance_SetItemActiveIndicatorShapeAppearance_Lcom_google_android_material_shape_ShapeAppearanceModel__V;

	private static Delegate? cb_getItemActiveIndicatorWidth_GetItemActiveIndicatorWidth_I;

	private static Delegate? cb_setItemActiveIndicatorWidth_SetItemActiveIndicatorWidth_I_V;

	private static Delegate? cb_getItemBackground_GetItemBackground_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setItemBackground_SetItemBackground_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getItemBackgroundResource_GetItemBackgroundResource_I;

	private static Delegate? cb_setItemBackgroundResource_SetItemBackgroundResource_I_V;

	private static Delegate? cb_getItemIconSize_GetItemIconSize_I;

	private static Delegate? cb_setItemIconSize_SetItemIconSize_I_V;

	private static Delegate? cb_getItemIconTintList_GetItemIconTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setItemIconTintList_SetItemIconTintList_Landroid_content_res_ColorStateList__V;

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

	private static Delegate? cb_getMaxItemCount_GetMaxItemCount_I;

	private static Delegate? cb_getMenu_GetMenu_Landroid_view_Menu_;

	private static Delegate? cb_getMenuView_GetMenuView_Landroidx_appcompat_view_menu_MenuView_;

	private static Delegate? cb_getPresenter_GetPresenter_Lcom_google_android_material_navigation_NavigationBarPresenter_;

	private static Delegate? cb_getSelectedItemId_GetSelectedItemId_I;

	private static Delegate? cb_setSelectedItemId_SetSelectedItemId_I_V;

	private static Delegate? cb_createNavigationBarMenuView_CreateNavigationBarMenuView_Landroid_content_Context__Lcom_google_android_material_navigation_NavigationBarMenuView_;

	private static Delegate? cb_getBadge_GetBadge_I_Lcom_google_android_material_badge_BadgeDrawable_;

	private static Delegate? cb_getOrCreateBadge_GetOrCreateBadge_I_Lcom_google_android_material_badge_BadgeDrawable_;

	private static Delegate? cb_inflateMenu_InflateMenu_I_V;

	private static Delegate? cb_removeBadge_RemoveBadge_I_V;

	private static Delegate? cb_setItemIconSizeRes_SetItemIconSizeRes_I_V;

	private static Delegate? cb_setItemOnTouchListener_SetItemOnTouchListener_ILandroid_view_View_OnTouchListener__V;

	private static Delegate? cb_setItemTextAppearanceActiveBoldEnabled_SetItemTextAppearanceActiveBoldEnabled_Z_V;

	private static Delegate? cb_setOnItemReselectedListener_SetOnItemReselectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemReselectedListener__V;

	private static Delegate? cb_setOnItemSelectedListener_SetOnItemSelectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemSelectedListener__V;

	private WeakReference? weak_implementor_SetOnItemReselectedListener;

	private WeakReference? weak_implementor_SetOnItemSelectedListener;

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
		[Register("isItemActiveIndicatorEnabled", "()Z", "GetIsItemActiveIndicatorEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemActiveIndicatorEnabled.()Z", this, null);
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

	public unsafe virtual int ItemBackgroundResource
	{
		[Obsolete("deprecated")]
		[Register("getItemBackgroundResource", "()I", "GetGetItemBackgroundResourceHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemBackgroundResource.()I", this, null);
		}
		[Register("setItemBackgroundResource", "(I)V", "GetSetItemBackgroundResource_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemBackgroundResource.(I)V", this, ptr);
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

	public unsafe virtual ColorStateList? ItemIconTintList
	{
		[Register("getItemIconTintList", "()Landroid/content/res/ColorStateList;", "GetGetItemIconTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemIconTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setItemIconTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetItemIconTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setItemIconTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
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

	public abstract int MaxItemCount
	{
		[Register("getMaxItemCount", "()I", "GetGetMaxItemCountHandler")]
		get;
	}

	public unsafe virtual IMenu Menu
	{
		[Register("getMenu", "()Landroid/view/Menu;", "GetGetMenuHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMenu.()Landroid/view/Menu;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IMenuView MenuView
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getMenuView", "()Landroidx/appcompat/view/menu/MenuView;", "GetGetMenuViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMenuView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMenuView.()Landroidx/appcompat/view/menu/MenuView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual NavigationBarPresenter Presenter
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getPresenter", "()Lcom/google/android/material/navigation/NavigationBarPresenter;", "GetGetPresenterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<NavigationBarPresenter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPresenter.()Lcom/google/android/material/navigation/NavigationBarPresenter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int SelectedItemId
	{
		[Register("getSelectedItemId", "()I", "GetGetSelectedItemIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectedItemId.()I", this, null);
		}
		[Register("setSelectedItemId", "(I)V", "GetSetSelectedItemId_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSelectedItemId.(I)V", this, ptr);
		}
	}

	public event EventHandler<ItemReselectedEventArgs> ItemReselected
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemReselectedListener, IOnItemReselectedListenerImplementor>(ref weak_implementor_SetOnItemReselectedListener, __CreateIOnItemReselectedListenerImplementor, SetOnItemReselectedListener, delegate(IOnItemReselectedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemReselectedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnItemReselectedListener, IOnItemReselectedListenerImplementor>(ref weak_implementor_SetOnItemReselectedListener, IOnItemReselectedListenerImplementor.__IsEmpty, delegate
			{
				SetOnItemReselectedListener(null);
			}, delegate(IOnItemReselectedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemReselectedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<ItemSelectedEventArgs> ItemSelected
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemSelectedListener, IOnItemSelectedListenerImplementor>(ref weak_implementor_SetOnItemSelectedListener, __CreateIOnItemSelectedListenerImplementor, SetOnItemSelectedListener, delegate(IOnItemSelectedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemSelectedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnItemSelectedListener, IOnItemSelectedListenerImplementor>(ref weak_implementor_SetOnItemSelectedListener, IOnItemSelectedListenerImplementor.__IsEmpty, delegate
			{
				SetOnItemSelectedListener(null);
			}, delegate(IOnItemSelectedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<ItemSelectedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected NavigationBarView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe NavigationBarView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActiveIndicatorLabelPadding;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActiveIndicatorLabelPadding = activeIndicatorLabelPadding;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorColor);
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
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemActiveIndicatorColor = Java.Lang.Object.GetObject<ColorStateList>(native_csl, JniHandleOwnership.DoNotTransfer);
			navigationBarView.ItemActiveIndicatorColor = itemActiveIndicatorColor;
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

	private static Delegate GetIsItemActiveIndicatorEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsItemActiveIndicatorEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsItemActiveIndicatorEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorEnabled ? ((sbyte)1) : ((sbyte)0);
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
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool itemActiveIndicatorEnabled = native_enabled != 0;
			navigationBarView.ItemActiveIndicatorEnabled = itemActiveIndicatorEnabled;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorHeight;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorHeight = height;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorMarginHorizontal;
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
	private static void n_SetItemActiveIndicatorMarginHorizontal_I(nint jnienv, nint native__this, int horizontalMargin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorMarginHorizontal = horizontalMargin;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorShapeAppearance);
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
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapeAppearanceModel itemActiveIndicatorShapeAppearance = Java.Lang.Object.GetObject<ShapeAppearanceModel>(native_shapeAppearance, JniHandleOwnership.DoNotTransfer);
			navigationBarView.ItemActiveIndicatorShapeAppearance = itemActiveIndicatorShapeAppearance;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorWidth;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemActiveIndicatorWidth = width;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemBackground);
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
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable itemBackground = Java.Lang.Object.GetObject<Drawable>(native_background, JniHandleOwnership.DoNotTransfer);
			navigationBarView.ItemBackground = itemBackground;
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
	private static Delegate GetGetItemBackgroundResourceHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemBackgroundResource);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemBackgroundResource(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemBackgroundResource;
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

	private static Delegate GetSetItemBackgroundResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemBackgroundResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemBackgroundResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemBackgroundResource = resId;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemIconSize;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemIconSize = iconSize;
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

	private static Delegate GetGetItemIconTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemIconTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemIconTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemIconTintList);
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

	private static Delegate GetSetItemIconTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetItemIconTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemIconTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemIconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			navigationBarView.ItemIconTintList = itemIconTintList;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingBottom;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingBottom = paddingBottom;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingTop;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemPaddingTop = paddingTop;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemRippleColor);
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
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemRippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_itemRippleColor, JniHandleOwnership.DoNotTransfer);
			navigationBarView.ItemRippleColor = itemRippleColor;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceActive;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceActive = textAppearanceRes;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceInactive;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextAppearanceInactive = textAppearanceRes;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemTextColor);
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
	private static void n_SetItemTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_textColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList itemTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_textColor, JniHandleOwnership.DoNotTransfer);
			navigationBarView.ItemTextColor = itemTextColor;
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelVisibilityMode;
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
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelVisibilityMode = labelVisibilityMode;
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

	private static Delegate GetGetMaxItemCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxItemCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxItemCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxItemCount;
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Menu);
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

	private static Delegate GetGetMenuViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMenuView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenuView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MenuView);
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

	private static Delegate GetGetPresenterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPresenter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPresenter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Presenter);
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
			return Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedItemId;
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

	private static Delegate GetSetSelectedItemId_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSelectedItemId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelectedItemId_I(nint jnienv, nint native__this, int itemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedItemId = itemId;
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

	private static Delegate GetCreateNavigationBarMenuView_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_CreateNavigationBarMenuView_Landroid_content_Context_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateNavigationBarMenuView_Landroid_content_Context_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(navigationBarView.CreateNavigationBarMenuView(p));
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("createNavigationBarMenuView", "(Landroid/content/Context;)Lcom/google/android/material/navigation/NavigationBarMenuView;", "GetCreateNavigationBarMenuView_Landroid_content_Context_Handler")]
	protected abstract NavigationBarMenuView CreateNavigationBarMenuView(Context p0);

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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBadge(menuItemId));
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

	private static Delegate GetGetOrCreateBadge_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetOrCreateBadge_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOrCreateBadge_I(nint jnienv, nint native__this, int menuItemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetOrCreateBadge(menuItemId));
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

	[Register("getOrCreateBadge", "(I)Lcom/google/android/material/badge/BadgeDrawable;", "GetGetOrCreateBadge_IHandler")]
	public unsafe virtual BadgeDrawable GetOrCreateBadge(int menuItemId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(menuItemId);
		return Java.Lang.Object.GetObject<BadgeDrawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrCreateBadge.(I)Lcom/google/android/material/badge/BadgeDrawable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetInflateMenu_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_InflateMenu_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InflateMenu_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InflateMenu(resId);
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

	[Register("inflateMenu", "(I)V", "GetInflateMenu_IHandler")]
	public unsafe virtual void InflateMenu(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("inflateMenu.(I)V", this, ptr);
	}

	private static Delegate GetRemoveBadge_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveBadge_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveBadge_I(nint jnienv, nint native__this, int menuItemId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveBadge(menuItemId);
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

	[Register("removeBadge", "(I)V", "GetRemoveBadge_IHandler")]
	public unsafe virtual void RemoveBadge(int menuItemId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(menuItemId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeBadge.(I)V", this, ptr);
	}

	private static Delegate GetSetItemIconSizeRes_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemIconSizeRes_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemIconSizeRes_I(nint jnienv, nint native__this, int iconSizeRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetItemIconSizeRes(iconSizeRes);
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

	[Register("setItemIconSizeRes", "(I)V", "GetSetItemIconSizeRes_IHandler")]
	public unsafe virtual void SetItemIconSizeRes(int iconSizeRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconSizeRes);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setItemIconSizeRes.(I)V", this, ptr);
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
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTouchListener onTouchListener = Java.Lang.Object.GetObject<IOnTouchListener>(native_onTouchListener, JniHandleOwnership.DoNotTransfer);
			navigationBarView.SetItemOnTouchListener(menuItemId, onTouchListener);
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
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool itemTextAppearanceActiveBoldEnabled = native_isBold != 0;
			navigationBarView.SetItemTextAppearanceActiveBoldEnabled(itemTextAppearanceActiveBoldEnabled);
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

	private static Delegate GetSetOnItemReselectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemReselectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnItemReselectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemReselectedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnItemReselectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemReselectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnItemReselectedListener onItemReselectedListener = Java.Lang.Object.GetObject<IOnItemReselectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			navigationBarView.SetOnItemReselectedListener(onItemReselectedListener);
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

	[Register("setOnItemReselectedListener", "(Lcom/google/android/material/navigation/NavigationBarView$OnItemReselectedListener;)V", "GetSetOnItemReselectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemReselectedListener_Handler")]
	public unsafe virtual void SetOnItemReselectedListener(IOnItemReselectedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnItemReselectedListener.(Lcom/google/android/material/navigation/NavigationBarView$OnItemReselectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnItemSelectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnItemSelectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemSelectedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnItemSelectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarView? navigationBarView = Java.Lang.Object.GetObject<NavigationBarView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnItemSelectedListener onItemSelectedListener = Java.Lang.Object.GetObject<IOnItemSelectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			navigationBarView.SetOnItemSelectedListener(onItemSelectedListener);
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

	[Register("setOnItemSelectedListener", "(Lcom/google/android/material/navigation/NavigationBarView$OnItemSelectedListener;)V", "GetSetOnItemSelectedListener_Lcom_google_android_material_navigation_NavigationBarView_OnItemSelectedListener_Handler")]
	public unsafe virtual void SetOnItemSelectedListener(IOnItemSelectedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnItemSelectedListener.(Lcom/google/android/material/navigation/NavigationBarView$OnItemSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private IOnItemReselectedListenerImplementor __CreateIOnItemReselectedListenerImplementor()
	{
		return new IOnItemReselectedListenerImplementor(this);
	}

	private IOnItemSelectedListenerImplementor __CreateIOnItemSelectedListenerImplementor()
	{
		return new IOnItemSelectedListenerImplementor(this);
	}
}

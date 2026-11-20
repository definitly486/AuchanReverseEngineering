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
using AndroidX.ViewPager.Widget;
using Google.Android.Material.Badge;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Tabs;

[Register("com/google/android/material/tabs/TabLayout", DoNotGenerateAcw = true)]
public class TabLayout : HorizontalScrollView
{
	[Register("com/google/android/material/tabs/TabLayout$TabView", DoNotGenerateAcw = true)]
	public sealed class TabView : LinearLayout
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/tabs/TabLayout$TabView", typeof(TabView));

		public override bool Selected
		{
			get
			{
				return base.Selected;
			}
			set
			{
				base.Selected = value;
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

		public unsafe Tab? Tab
		{
			[Register("getTab", "()Lcom/google/android/material/tabs/TabLayout$Tab;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTab.()Lcom/google/android/material/tabs/TabLayout$Tab;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public void SetSelected(bool selected)
		{
			Selected = selected;
		}

		internal TabView(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lcom/google/android/material/tabs/TabLayout;Landroid/content/Context;)V", "")]
		public unsafe TabView(TabLayout? __self, Context context)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";Landroid/content/Context;)V";
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
			}
			finally
			{
				GC.KeepAlive(__self);
				GC.KeepAlive(context);
			}
		}

		[Register("onMeasure", "(II)V", "")]
		public new unsafe void OnMeasure(int origWidthMeasureSpec, int origHeightMeasureSpec)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(origWidthMeasureSpec);
			ptr[1] = new JniArgumentValue(origHeightMeasureSpec);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onMeasure.(II)V", this, ptr);
		}
	}

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener", "", "Google.Android.Material.Tabs.TabLayout/IOnTabSelectedListenerInvoker")]
	[JavaTypeParameters(new string[] { "T extends com.google.android.material.tabs.TabLayout.Tab" })]
	public interface IOnTabSelectedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onTabReselected", "(Lcom/google/android/material/tabs/TabLayout$Tab;)V", "GetOnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab_Handler:Google.Android.Material.Tabs.TabLayout/IOnTabSelectedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnTabReselected(Tab? tab);

		[Register("onTabSelected", "(Lcom/google/android/material/tabs/TabLayout$Tab;)V", "GetOnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab_Handler:Google.Android.Material.Tabs.TabLayout/IOnTabSelectedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnTabSelected(Tab? tab);

		[Register("onTabUnselected", "(Lcom/google/android/material/tabs/TabLayout$Tab;)V", "GetOnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab_Handler:Google.Android.Material.Tabs.TabLayout/IOnTabSelectedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnTabUnselected(Tab? tab);
	}

	[Register("com/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener", DoNotGenerateAcw = true)]
	[Obsolete("This class is obsoleted in this android platform")]
	internal class IOnTabSelectedListenerInvoker : Java.Lang.Object, IOnTabSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener = new XAPeerMembers("com/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener", typeof(IOnTabSelectedListenerInvoker));

		private static Delegate? cb_onTabReselected_OnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab__V;

		private static Delegate? cb_onTabSelected_OnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab__V;

		private static Delegate? cb_onTabUnselected_OnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab__V;

		private static nint java_class_ref => _members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.ManagedPeerType;

		public IOnTabSelectedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnTabSelectedListener? onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				onTabSelectedListener.OnTabReselected(tab);
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

		public unsafe void OnTabReselected(Tab? tab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onTabReselected.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnTabSelectedListener? onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				onTabSelectedListener.OnTabSelected(tab);
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

		public unsafe void OnTabSelected(Tab? tab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onTabSelected.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnTabSelectedListener? onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				onTabSelectedListener.OnTabUnselected(tab);
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

		public unsafe void OnTabUnselected(Tab? tab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onTabUnselected.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
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
		private static void n_OnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab__mm_wrapper(nint jnienv, nint native__this, nint native_tab)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab_(jnienv, native__this, native_tab);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab__mm_wrapper(nint jnienv, nint native__this, nint native_tab)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab_(jnienv, native__this, native_tab);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab__mm_wrapper(nint jnienv, nint native__this, nint native_tab)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab_(jnienv, native__this, native_tab);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class TabReselectedEventArgs : EventArgs
	{
		private Tab? tab;

		public TabReselectedEventArgs(Tab? tab)
		{
			this.tab = tab;
		}
	}

	public class TabSelectedEventArgs : EventArgs
	{
		private Tab? tab;

		public TabSelectedEventArgs(Tab? tab)
		{
			this.tab = tab;
		}
	}

	public class TabUnselectedEventArgs : EventArgs
	{
		private Tab? tab;

		public TabUnselectedEventArgs(Tab? tab)
		{
			this.tab = tab;
		}
	}

	[Register("mono/com/google/android/material/tabs/TabLayout_BaseOnTabSelectedListenerImplementor")]
	internal sealed class IOnTabSelectedListenerImplementor : Java.Lang.Object, IOnTabSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<TabReselectedEventArgs>? OnTabReselectedHandler;

		public EventHandler<TabSelectedEventArgs>? OnTabSelectedHandler;

		public EventHandler<TabUnselectedEventArgs>? OnTabUnselectedHandler;

		public unsafe IOnTabSelectedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnTabReselected(Tab? tab)
		{
			OnTabReselectedHandler?.Invoke(sender, new TabReselectedEventArgs(tab));
		}

		public void OnTabSelected(Tab? tab)
		{
			OnTabSelectedHandler?.Invoke(sender, new TabSelectedEventArgs(tab));
		}

		public void OnTabUnselected(Tab? tab)
		{
			OnTabUnselectedHandler?.Invoke(sender, new TabUnselectedEventArgs(tab));
		}

		internal static bool __IsEmpty(IOnTabSelectedListenerImplementor value)
		{
			if (value.OnTabReselectedHandler == null && value.OnTabSelectedHandler == null)
			{
				return value.OnTabUnselectedHandler == null;
			}
			return false;
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

	[Register("com/google/android/material/tabs/TabLayout$OnTabSelectedListener", "", "Google.Android.Material.Tabs.TabLayout/IOnTabSelectedListener2Invoker")]
	public interface IOnTabSelectedListener2 : IOnTabSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
	}

	[Register("com/google/android/material/tabs/TabLayout$OnTabSelectedListener", DoNotGenerateAcw = true)]
	internal class IOnTabSelectedListener2Invoker : Java.Lang.Object, IOnTabSelectedListener2, IOnTabSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener = new XAPeerMembers("com/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener", typeof(IOnTabSelectedListener2Invoker));

		private static readonly JniPeerMembers _members_com_google_android_material_tabs_TabLayout_OnTabSelectedListener = new XAPeerMembers("com/google/android/material/tabs/TabLayout$OnTabSelectedListener", typeof(IOnTabSelectedListener2Invoker));

		private static Delegate? cb_onTabReselected_OnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab__V;

		private static Delegate? cb_onTabSelected_OnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab__V;

		private static Delegate? cb_onTabUnselected_OnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab__V;

		private static nint java_class_ref => _members_com_google_android_material_tabs_TabLayout_OnTabSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_tabs_TabLayout_OnTabSelectedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_tabs_TabLayout_OnTabSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_tabs_TabLayout_OnTabSelectedListener.ManagedPeerType;

		public IOnTabSelectedListener2Invoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabReselected_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnTabSelectedListener2? onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener2>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				onTabSelectedListener.OnTabReselected(tab);
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

		public unsafe void OnTabReselected(Tab? tab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onTabReselected.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
			}
		}

		private static Delegate GetOnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabSelected_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnTabSelectedListener2? onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener2>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				onTabSelectedListener.OnTabSelected(tab);
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

		public unsafe void OnTabSelected(Tab? tab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onTabSelected.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
			}
		}

		private static Delegate GetOnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTabUnselected_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnTabSelectedListener2? onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener2>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
				onTabSelectedListener.OnTabUnselected(tab);
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

		public unsafe void OnTabUnselected(Tab? tab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
				_members_com_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener.InstanceMethods.InvokeAbstractVoidMethod("onTabUnselected.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(tab);
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
	}

	[Register("com/google/android/material/tabs/TabLayout$Tab", DoNotGenerateAcw = true)]
	public class Tab : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/tabs/TabLayout$Tab", typeof(Tab));

		private static Delegate? cb_getBadge_GetBadge_Lcom_google_android_material_badge_BadgeDrawable_;

		private static Delegate? cb_getContentDescription_GetContentDescription_Ljava_lang_CharSequence_;

		private static Delegate? cb_getCustomView_GetCustomView_Landroid_view_View_;

		private static Delegate? cb_getIcon_GetIcon_Landroid_graphics_drawable_Drawable_;

		private static Delegate? cb_getId_GetId_I;

		private static Delegate? cb_isSelected_IsSelected_Z;

		private static Delegate? cb_getOrCreateBadge_GetOrCreateBadge_Lcom_google_android_material_badge_BadgeDrawable_;

		private static Delegate? cb_getPosition_GetPosition_I;

		private static Delegate? cb_getTabLabelVisibility_GetTabLabelVisibility_I;

		private static Delegate? cb_getTag_GetTag_Ljava_lang_Object_;

		private static Delegate? cb_getText_GetText_Ljava_lang_CharSequence_;

		private static Delegate? cb_removeBadge_RemoveBadge_V;

		private static Delegate? cb_select_Select_V;

		private static Delegate? cb_setContentDescription_SetContentDescription_I_Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setContentDescription_SetContentDescription_Ljava_lang_CharSequence__Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setCustomView_SetCustomView_Landroid_view_View__Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setCustomView_SetCustomView_I_Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setIcon_SetIcon_I_Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setId_SetId_I_Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setTabLabelVisibility_SetTabLabelVisibility_I_Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setTag_SetTag_Ljava_lang_Object__Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setText_SetText_I_Lcom_google_android_material_tabs_TabLayout_Tab_;

		private static Delegate? cb_setText_SetText_Ljava_lang_CharSequence__Lcom_google_android_material_tabs_TabLayout_Tab_;

		[Register("parent")]
		public TabLayout? Parent
		{
			get
			{
				return Java.Lang.Object.GetObject<TabLayout>(_members.InstanceFields.GetObjectValue("parent.Lcom/google/android/material/tabs/TabLayout;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("parent.Lcom/google/android/material/tabs/TabLayout;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("view")]
		public TabView View
		{
			get
			{
				return Java.Lang.Object.GetObject<TabView>(_members.InstanceFields.GetObjectValue("view.Lcom/google/android/material/tabs/TabLayout$TabView;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("view.Lcom/google/android/material/tabs/TabLayout$TabView;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
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

		public unsafe virtual BadgeDrawable? Badge
		{
			[Register("getBadge", "()Lcom/google/android/material/badge/BadgeDrawable;", "GetGetBadgeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BadgeDrawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBadge.()Lcom/google/android/material/badge/BadgeDrawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ICharSequence? ContentDescriptionFormatted
		{
			[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

		public unsafe virtual View? CustomView
		{
			[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler")]
			get
			{
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Drawable? Icon
		{
			[Register("getIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetIconHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Id
		{
			[Register("getId", "()I", "GetGetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
			}
		}

		public unsafe virtual bool IsSelected
		{
			[Register("isSelected", "()Z", "GetIsSelectedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSelected.()Z", this, null);
			}
		}

		public unsafe virtual BadgeDrawable OrCreateBadge
		{
			[Register("getOrCreateBadge", "()Lcom/google/android/material/badge/BadgeDrawable;", "GetGetOrCreateBadgeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BadgeDrawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOrCreateBadge.()Lcom/google/android/material/badge/BadgeDrawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int Position
		{
			[Register("getPosition", "()I", "GetGetPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPosition.()I", this, null);
			}
		}

		public unsafe virtual int TabLabelVisibility
		{
			[Register("getTabLabelVisibility", "()I", "GetGetTabLabelVisibilityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTabLabelVisibility.()I", this, null);
			}
		}

		public unsafe virtual Java.Lang.Object? Tag
		{
			[Register("getTag", "()Ljava/lang/Object;", "GetGetTagHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTag.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ICharSequence? TextFormatted
		{
			[Register("getText", "()Ljava/lang/CharSequence;", "GetGetTextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public string? Text
		{
			get
			{
				if (TextFormatted != null)
				{
					return TextFormatted.ToString();
				}
				return null;
			}
		}

		protected Tab(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Tab()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
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
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Badge);
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

		private static Delegate GetGetContentDescriptionHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetContentDescription);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetContentDescription(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentDescriptionFormatted);
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

		private static Delegate GetGetCustomViewHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetCustomView);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetCustomView(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomView);
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

		private static Delegate GetGetIconHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetIcon);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetIcon(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Icon);
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

		private static Delegate GetGetIdHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetId);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetId(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

		private static Delegate GetIsSelectedHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsSelected);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsSelected(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSelected ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetOrCreateBadgeHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetOrCreateBadge);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetOrCreateBadge(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OrCreateBadge);
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

		private static Delegate GetGetPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position;
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

		private static Delegate GetGetTabLabelVisibilityHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetTabLabelVisibility);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetTabLabelVisibility(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabLabelVisibility;
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

		private static Delegate GetGetTagHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetTag);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetTag(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Tag);
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

		private static Delegate GetGetTextHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetText);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetText(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextFormatted);
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

		private static Delegate GetRemoveBadgeHandler()
		{
			return new global::_JniMarshal_PP_V(n_RemoveBadge);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveBadge(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveBadge();
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

		[Register("removeBadge", "()V", "GetRemoveBadgeHandler")]
		public unsafe virtual void RemoveBadge()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeBadge.()V", this, null);
		}

		private static Delegate GetSelectHandler()
		{
			return new global::_JniMarshal_PP_V(n_Select);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Select(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Select();
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

		[Register("select", "()V", "GetSelectHandler")]
		public unsafe virtual void Select()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("select.()V", this, null);
		}

		private static Delegate GetSetContentDescription_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetContentDescription_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetContentDescription_I(nint jnienv, nint native__this, int resId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentDescription(resId));
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

		[Register("setContentDescription", "(I)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetContentDescription_IHandler")]
		public unsafe virtual Tab SetContentDescription(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setContentDescription.(I)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetContentDescription_Ljava_lang_CharSequence_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetContentDescription_Ljava_lang_CharSequence_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_contentDesc)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence contentDescription = Java.Lang.Object.GetObject<ICharSequence>(native_contentDesc, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetContentDescription(contentDescription));
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

		[Register("setContentDescription", "(Ljava/lang/CharSequence;)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetContentDescription_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Tab SetContentDescription(ICharSequence? contentDesc)
		{
			nint num = CharSequence.ToLocalJniHandle(contentDesc);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setContentDescription.(Ljava/lang/CharSequence;)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(contentDesc);
			}
		}

		public Tab SetContentDescription(string? contentDesc)
		{
			Java.Lang.String obj = ((contentDesc == null) ? null : new Java.Lang.String(contentDesc));
			Tab result = SetContentDescription(obj);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSetCustomView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetCustomView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCustomView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View customView = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetCustomView(customView));
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

		[Register("setCustomView", "(Landroid/view/View;)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetCustomView_Landroid_view_View_Handler")]
		public unsafe virtual Tab SetCustomView(View? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCustomView.(Landroid/view/View;)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetSetCustomView_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetCustomView_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetCustomView_I(nint jnienv, nint native__this, int resId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomView(resId));
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

		[Register("setCustomView", "(I)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetCustomView_IHandler")]
		public unsafe virtual Tab SetCustomView(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCustomView.(I)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetIcon(icon));
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

		[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler")]
		public unsafe virtual Tab SetIcon(Drawable? icon)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIcon.(Landroid/graphics/drawable/Drawable;)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
		private static nint n_SetIcon_I(nint jnienv, nint native__this, int resId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(resId));
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

		[Register("setIcon", "(I)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetIcon_IHandler")]
		public unsafe virtual Tab SetIcon(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIcon.(I)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetId_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetId_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetId_I(nint jnienv, nint native__this, int id)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetId(id));
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

		[Register("setId", "(I)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetId_IHandler")]
		public unsafe virtual Tab SetId(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setId.(I)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetTabLabelVisibility_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetTabLabelVisibility_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetTabLabelVisibility_I(nint jnienv, nint native__this, int mode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTabLabelVisibility(mode));
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

		[Register("setTabLabelVisibility", "(I)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetTabLabelVisibility_IHandler")]
		public unsafe virtual Tab SetTabLabelVisibility(int mode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTabLabelVisibility.(I)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetTag_Ljava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetTag_Ljava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetTag_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_tag)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetTag(tag));
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

		[Register("setTag", "(Ljava/lang/Object;)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetTag_Ljava_lang_Object_Handler")]
		public unsafe virtual Tab SetTag(Java.Lang.Object? tag)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTag.(Ljava/lang/Object;)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(tag);
			}
		}

		private static Delegate GetSetText_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_SetText_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetText_I(nint jnienv, nint native__this, int resId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetText(resId));
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

		[Register("setText", "(I)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetText_IHandler")]
		public unsafe virtual Tab SetText(int resId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resId);
			return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setText.(I)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetText_Ljava_lang_CharSequence_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_SetText_Ljava_lang_CharSequence_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_SetText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_text)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Tab? tab = Java.Lang.Object.GetObject<Tab>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(tab.SetText(text));
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

		[Register("setText", "(Ljava/lang/CharSequence;)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetSetText_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual Tab SetText(ICharSequence? text)
		{
			nint num = CharSequence.ToLocalJniHandle(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("setText.(Ljava/lang/CharSequence;)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(text);
			}
		}

		public Tab SetText(string? text)
		{
			Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
			Tab result = SetText(obj);
			obj?.Dispose();
			return result;
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/tabs/TabLayout", typeof(TabLayout));

	private static Delegate? cb_hasUnboundedRipple_HasUnboundedRipple_Z;

	private static Delegate? cb_isInlineLabel_IsInlineLabel_Z;

	private static Delegate? cb_setInlineLabel_SetInlineLabel_Z_V;

	private static Delegate? cb_getSelectedTabPosition_GetSelectedTabPosition_I;

	private static Delegate? cb_getTabCount_GetTabCount_I;

	private static Delegate? cb_getTabGravity_GetTabGravity_I;

	private static Delegate? cb_setTabGravity_SetTabGravity_I_V;

	private static Delegate? cb_getTabIconTint_GetTabIconTint_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTabIconTint_SetTabIconTint_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTabIndicatorAnimationMode_GetTabIndicatorAnimationMode_I;

	private static Delegate? cb_setTabIndicatorAnimationMode_SetTabIndicatorAnimationMode_I_V;

	private static Delegate? cb_isTabIndicatorFullWidth_IsTabIndicatorFullWidth_Z;

	private static Delegate? cb_setTabIndicatorFullWidth_SetTabIndicatorFullWidth_Z_V;

	private static Delegate? cb_getTabIndicatorGravity_GetTabIndicatorGravity_I;

	private static Delegate? cb_getTabMode_GetTabMode_I;

	private static Delegate? cb_setTabMode_SetTabMode_I_V;

	private static Delegate? cb_getTabRippleColor_GetTabRippleColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTabRippleColor_SetTabRippleColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTabSelectedIndicator_GetTabSelectedIndicator_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_getTabTextColors_GetTabTextColors_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTabTextColors_SetTabTextColors_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_addOnTabSelectedListener_AddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener__V;

	private static Delegate? cb_addOnTabSelectedListener_AddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener__V;

	private static Delegate? cb_addTab_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab__V;

	private static Delegate? cb_addTab_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_Z_V;

	private static Delegate? cb_addTab_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_I_V;

	private static Delegate? cb_addTab_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_IZ_V;

	private static Delegate? cb_clearOnTabSelectedListeners_ClearOnTabSelectedListeners_V;

	private static Delegate? cb_createTabFromPool_CreateTabFromPool_Lcom_google_android_material_tabs_TabLayout_Tab_;

	private static Delegate? cb_getTabAt_GetTabAt_I_Lcom_google_android_material_tabs_TabLayout_Tab_;

	private static Delegate? cb_newTab_NewTab_Lcom_google_android_material_tabs_TabLayout_Tab_;

	private static Delegate? cb_releaseFromTabPool_ReleaseFromTabPool_Lcom_google_android_material_tabs_TabLayout_Tab__Z;

	private static Delegate? cb_removeAllTabs_RemoveAllTabs_V;

	private static Delegate? cb_removeOnTabSelectedListener_RemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener__V;

	private static Delegate? cb_removeOnTabSelectedListener_RemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener__V;

	private static Delegate? cb_removeTab_RemoveTab_Lcom_google_android_material_tabs_TabLayout_Tab__V;

	private static Delegate? cb_removeTabAt_RemoveTabAt_I_V;

	private static Delegate? cb_selectTab_SelectTab_Lcom_google_android_material_tabs_TabLayout_Tab__V;

	private static Delegate? cb_selectTab_SelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_Z_V;

	private static Delegate? cb_setInlineLabelResource_SetInlineLabelResource_I_V;

	private static Delegate? cb_setOnTabSelectedListener_SetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener__V;

	private static Delegate? cb_setOnTabSelectedListener_SetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener__V;

	private static Delegate? cb_setScrollPosition_SetScrollPosition_IFZ_V;

	private static Delegate? cb_setScrollPosition_SetScrollPosition_IFZZ_V;

	private static Delegate? cb_setSelectedTabIndicator_SetSelectedTabIndicator_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setSelectedTabIndicator_SetSelectedTabIndicator_I_V;

	private static Delegate? cb_setSelectedTabIndicatorColor_SetSelectedTabIndicatorColor_I_V;

	private static Delegate? cb_setSelectedTabIndicatorGravity_SetSelectedTabIndicatorGravity_I_V;

	private static Delegate? cb_setSelectedTabIndicatorHeight_SetSelectedTabIndicatorHeight_I_V;

	private static Delegate? cb_setTabIconTintResource_SetTabIconTintResource_I_V;

	private static Delegate? cb_setTabRippleColorResource_SetTabRippleColorResource_I_V;

	private static Delegate? cb_setTabTextColors_SetTabTextColors_II_V;

	private static Delegate? cb_setTabsFromPagerAdapter_SetTabsFromPagerAdapter_Landroidx_viewpager_widget_PagerAdapter__V;

	private static Delegate? cb_setUnboundedRipple_SetUnboundedRipple_Z_V;

	private static Delegate? cb_setUnboundedRippleResource_SetUnboundedRippleResource_I_V;

	private static Delegate? cb_setupWithViewPager_SetupWithViewPager_Landroidx_viewpager_widget_ViewPager__V;

	private static Delegate? cb_setupWithViewPager_SetupWithViewPager_Landroidx_viewpager_widget_ViewPager_Z_V;

	private WeakReference? weak_implementor_AddOnTabSelectedListener;

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

	public unsafe virtual bool HasUnboundedRipple
	{
		[Register("hasUnboundedRipple", "()Z", "GetHasUnboundedRippleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasUnboundedRipple.()Z", this, null);
		}
	}

	public unsafe virtual bool InlineLabel
	{
		[Register("isInlineLabel", "()Z", "GetIsInlineLabelHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInlineLabel.()Z", this, null);
		}
		[Register("setInlineLabel", "(Z)V", "GetSetInlineLabel_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInlineLabel.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int SelectedTabPosition
	{
		[Register("getSelectedTabPosition", "()I", "GetGetSelectedTabPositionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectedTabPosition.()I", this, null);
		}
	}

	public unsafe virtual int TabCount
	{
		[Register("getTabCount", "()I", "GetGetTabCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTabCount.()I", this, null);
		}
	}

	public unsafe virtual int TabGravity
	{
		[Register("getTabGravity", "()I", "GetGetTabGravityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTabGravity.()I", this, null);
		}
		[Register("setTabGravity", "(I)V", "GetSetTabGravity_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTabGravity.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? TabIconTint
	{
		[Register("getTabIconTint", "()Landroid/content/res/ColorStateList;", "GetGetTabIconTintHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTabIconTint.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTabIconTint", "(Landroid/content/res/ColorStateList;)V", "GetSetTabIconTint_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTabIconTint.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int TabIndicatorAnimationMode
	{
		[Register("getTabIndicatorAnimationMode", "()I", "GetGetTabIndicatorAnimationModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTabIndicatorAnimationMode.()I", this, null);
		}
		[Register("setTabIndicatorAnimationMode", "(I)V", "GetSetTabIndicatorAnimationMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTabIndicatorAnimationMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool TabIndicatorFullWidth
	{
		[Register("isTabIndicatorFullWidth", "()Z", "GetIsTabIndicatorFullWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTabIndicatorFullWidth.()Z", this, null);
		}
		[Register("setTabIndicatorFullWidth", "(Z)V", "GetSetTabIndicatorFullWidth_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTabIndicatorFullWidth.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int TabIndicatorGravity
	{
		[Register("getTabIndicatorGravity", "()I", "GetGetTabIndicatorGravityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTabIndicatorGravity.()I", this, null);
		}
	}

	public unsafe virtual int TabMode
	{
		[Register("getTabMode", "()I", "GetGetTabModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTabMode.()I", this, null);
		}
		[Register("setTabMode", "(I)V", "GetSetTabMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTabMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? TabRippleColor
	{
		[Register("getTabRippleColor", "()Landroid/content/res/ColorStateList;", "GetGetTabRippleColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTabRippleColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTabRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetTabRippleColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTabRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Drawable TabSelectedIndicator
	{
		[Register("getTabSelectedIndicator", "()Landroid/graphics/drawable/Drawable;", "GetGetTabSelectedIndicatorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTabSelectedIndicator.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ColorStateList? TabTextColors
	{
		[Register("getTabTextColors", "()Landroid/content/res/ColorStateList;", "GetGetTabTextColorsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTabTextColors.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTabTextColors", "(Landroid/content/res/ColorStateList;)V", "GetSetTabTextColors_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTabTextColors.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public event EventHandler<TabReselectedEventArgs> TabReselected
	{
		add
		{
			EventHelper.AddEventHandler<IOnTabSelectedListener, IOnTabSelectedListenerImplementor>(ref weak_implementor_AddOnTabSelectedListener, __CreateIOnTabSelectedListenerImplementor, AddOnTabSelectedListener, delegate(IOnTabSelectedListenerImplementor __h)
			{
				__h.OnTabReselectedHandler = (EventHandler<TabReselectedEventArgs>)Delegate.Combine(__h.OnTabReselectedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnTabSelectedListener, IOnTabSelectedListenerImplementor.__IsEmpty, delegate(IOnTabSelectedListener __v)
			{
				RemoveOnTabSelectedListener(__v);
			}, delegate(IOnTabSelectedListenerImplementor __h)
			{
				__h.OnTabReselectedHandler = (EventHandler<TabReselectedEventArgs>)Delegate.Remove(__h.OnTabReselectedHandler, value);
			});
		}
	}

	public event EventHandler<TabSelectedEventArgs> TabSelected
	{
		add
		{
			EventHelper.AddEventHandler<IOnTabSelectedListener, IOnTabSelectedListenerImplementor>(ref weak_implementor_AddOnTabSelectedListener, __CreateIOnTabSelectedListenerImplementor, AddOnTabSelectedListener, delegate(IOnTabSelectedListenerImplementor __h)
			{
				__h.OnTabSelectedHandler = (EventHandler<TabSelectedEventArgs>)Delegate.Combine(__h.OnTabSelectedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnTabSelectedListener, IOnTabSelectedListenerImplementor.__IsEmpty, delegate(IOnTabSelectedListener __v)
			{
				RemoveOnTabSelectedListener(__v);
			}, delegate(IOnTabSelectedListenerImplementor __h)
			{
				__h.OnTabSelectedHandler = (EventHandler<TabSelectedEventArgs>)Delegate.Remove(__h.OnTabSelectedHandler, value);
			});
		}
	}

	public event EventHandler<TabUnselectedEventArgs> TabUnselected
	{
		add
		{
			EventHelper.AddEventHandler<IOnTabSelectedListener, IOnTabSelectedListenerImplementor>(ref weak_implementor_AddOnTabSelectedListener, __CreateIOnTabSelectedListenerImplementor, AddOnTabSelectedListener, delegate(IOnTabSelectedListenerImplementor __h)
			{
				__h.OnTabUnselectedHandler = (EventHandler<TabUnselectedEventArgs>)Delegate.Combine(__h.OnTabUnselectedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnTabSelectedListener, IOnTabSelectedListenerImplementor.__IsEmpty, delegate(IOnTabSelectedListener __v)
			{
				RemoveOnTabSelectedListener(__v);
			}, delegate(IOnTabSelectedListenerImplementor __h)
			{
				__h.OnTabUnselectedHandler = (EventHandler<TabUnselectedEventArgs>)Delegate.Remove(__h.OnTabUnselectedHandler, value);
			});
		}
	}

	protected TabLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe TabLayout(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe TabLayout(Context context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe TabLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
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
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetHasUnboundedRippleHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasUnboundedRipple);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasUnboundedRipple(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasUnboundedRipple ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsInlineLabelHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInlineLabel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInlineLabel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InlineLabel ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetInlineLabel_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetInlineLabel_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInlineLabel_Z(nint jnienv, nint native__this, sbyte native_inline)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool inlineLabel = native_inline != 0;
			tabLayout.InlineLabel = inlineLabel;
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

	private static Delegate GetGetSelectedTabPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSelectedTabPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSelectedTabPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectedTabPosition;
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

	private static Delegate GetGetTabCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTabCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTabCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabCount;
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

	private static Delegate GetGetTabGravityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTabGravity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTabGravity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabGravity;
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

	private static Delegate GetSetTabGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTabGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabGravity_I(nint jnienv, nint native__this, int gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabGravity = gravity;
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

	private static Delegate GetGetTabIconTintHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTabIconTint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTabIconTint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabIconTint);
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

	private static Delegate GetSetTabIconTint_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTabIconTint_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabIconTint_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_iconTint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList tabIconTint = Java.Lang.Object.GetObject<ColorStateList>(native_iconTint, JniHandleOwnership.DoNotTransfer);
			tabLayout.TabIconTint = tabIconTint;
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

	private static Delegate GetGetTabIndicatorAnimationModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTabIndicatorAnimationMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTabIndicatorAnimationMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabIndicatorAnimationMode;
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

	private static Delegate GetSetTabIndicatorAnimationMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTabIndicatorAnimationMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabIndicatorAnimationMode_I(nint jnienv, nint native__this, int tabIndicatorAnimationMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabIndicatorAnimationMode = tabIndicatorAnimationMode;
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

	private static Delegate GetIsTabIndicatorFullWidthHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTabIndicatorFullWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTabIndicatorFullWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabIndicatorFullWidth ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetTabIndicatorFullWidth_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetTabIndicatorFullWidth_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabIndicatorFullWidth_Z(nint jnienv, nint native__this, sbyte native_tabIndicatorFullWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool tabIndicatorFullWidth = native_tabIndicatorFullWidth != 0;
			tabLayout.TabIndicatorFullWidth = tabIndicatorFullWidth;
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

	private static Delegate GetGetTabIndicatorGravityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTabIndicatorGravity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTabIndicatorGravity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabIndicatorGravity;
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

	private static Delegate GetGetTabModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTabMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTabMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabMode;
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

	private static Delegate GetSetTabMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTabMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabMode_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabMode = mode;
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

	private static Delegate GetGetTabRippleColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTabRippleColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTabRippleColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabRippleColor);
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

	private static Delegate GetSetTabRippleColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTabRippleColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabRippleColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList tabRippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			tabLayout.TabRippleColor = tabRippleColor;
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

	private static Delegate GetGetTabSelectedIndicatorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTabSelectedIndicator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTabSelectedIndicator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabSelectedIndicator);
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

	private static Delegate GetGetTabTextColorsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTabTextColors);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTabTextColors(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TabTextColors);
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

	private static Delegate GetSetTabTextColors_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTabTextColors_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabTextColors_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_textColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList tabTextColors = Java.Lang.Object.GetObject<ColorStateList>(native_textColor, JniHandleOwnership.DoNotTransfer);
			tabLayout.TabTextColors = tabTextColors;
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
	private static Delegate GetAddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTabSelectedListener listener = Java.Lang.Object.GetObject<IOnTabSelectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			tabLayout.AddOnTabSelectedListener(listener);
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

	[Obsolete("deprecated")]
	[Register("addOnTabSelectedListener", "(Lcom/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener;)V", "GetAddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_Handler")]
	public unsafe virtual void AddOnTabSelectedListener(IOnTabSelectedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnTabSelectedListener.(Lcom/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTabSelectedListener2 listener = Java.Lang.Object.GetObject<IOnTabSelectedListener2>(native_listener, JniHandleOwnership.DoNotTransfer);
			tabLayout.AddOnTabSelectedListener(listener);
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

	[Register("addOnTabSelectedListener", "(Lcom/google/android/material/tabs/TabLayout$OnTabSelectedListener;)V", "GetAddOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_Handler")]
	public unsafe virtual void AddOnTabSelectedListener(IOnTabSelectedListener2 listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnTabSelectedListener.(Lcom/google/android/material/tabs/TabLayout$OnTabSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			tabLayout.AddTab(tab);
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

	[Register("addTab", "(Lcom/google/android/material/tabs/TabLayout$Tab;)V", "GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_Handler")]
	public unsafe virtual void AddTab(Tab tab)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTab.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_Z(nint jnienv, nint native__this, nint native_tab, sbyte native_setSelected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			bool setSelected = native_setSelected != 0;
			tabLayout.AddTab(tab, setSelected);
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

	[Register("addTab", "(Lcom/google/android/material/tabs/TabLayout$Tab;Z)V", "GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_ZHandler")]
	public unsafe virtual void AddTab(Tab tab, bool setSelected)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(setSelected ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTab.(Lcom/google/android/material/tabs/TabLayout$Tab;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_I(nint jnienv, nint native__this, nint native_tab, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			tabLayout.AddTab(tab, position);
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

	[Register("addTab", "(Lcom/google/android/material/tabs/TabLayout$Tab;I)V", "GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_IHandler")]
	public unsafe virtual void AddTab(Tab tab, int position)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTab.(Lcom/google/android/material/tabs/TabLayout$Tab;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_IZHandler()
	{
		return new global::_JniMarshal_PPLIB_V(n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTab_Lcom_google_android_material_tabs_TabLayout_Tab_IZ(nint jnienv, nint native__this, nint native_tab, int position, sbyte native_setSelected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			bool setSelected = native_setSelected != 0;
			tabLayout.AddTab(tab, position, setSelected);
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

	[Register("addTab", "(Lcom/google/android/material/tabs/TabLayout$Tab;IZ)V", "GetAddTab_Lcom_google_android_material_tabs_TabLayout_Tab_IZHandler")]
	public unsafe virtual void AddTab(Tab tab, int position, bool setSelected)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(setSelected ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTab.(Lcom/google/android/material/tabs/TabLayout$Tab;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetClearOnTabSelectedListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnTabSelectedListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnTabSelectedListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnTabSelectedListeners();
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

	[Register("clearOnTabSelectedListeners", "()V", "GetClearOnTabSelectedListenersHandler")]
	public unsafe virtual void ClearOnTabSelectedListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnTabSelectedListeners.()V", this, null);
	}

	private static Delegate GetCreateTabFromPoolHandler()
	{
		return new global::_JniMarshal_PP_L(n_CreateTabFromPool);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateTabFromPool(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateTabFromPool());
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

	[Register("createTabFromPool", "()Lcom/google/android/material/tabs/TabLayout$Tab;", "GetCreateTabFromPoolHandler")]
	protected unsafe virtual Tab? CreateTabFromPool()
	{
		return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("createTabFromPool.()Lcom/google/android/material/tabs/TabLayout$Tab;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetTabAt_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetTabAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTabAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTabAt(index));
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

	[Register("getTabAt", "(I)Lcom/google/android/material/tabs/TabLayout$Tab;", "GetGetTabAt_IHandler")]
	public unsafe virtual Tab? GetTabAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTabAt.(I)Lcom/google/android/material/tabs/TabLayout$Tab;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetNewTabHandler()
	{
		return new global::_JniMarshal_PP_L(n_NewTab);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewTab(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewTab());
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

	[Register("newTab", "()Lcom/google/android/material/tabs/TabLayout$Tab;", "GetNewTabHandler")]
	public unsafe virtual Tab NewTab()
	{
		return Java.Lang.Object.GetObject<Tab>(_members.InstanceMethods.InvokeVirtualObjectMethod("newTab.()Lcom/google/android/material/tabs/TabLayout$Tab;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetReleaseFromTabPool_Lcom_google_android_material_tabs_TabLayout_Tab_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ReleaseFromTabPool_Lcom_google_android_material_tabs_TabLayout_Tab_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ReleaseFromTabPool_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			return tabLayout.ReleaseFromTabPool(tab) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("releaseFromTabPool", "(Lcom/google/android/material/tabs/TabLayout$Tab;)Z", "GetReleaseFromTabPool_Lcom_google_android_material_tabs_TabLayout_Tab_Handler")]
	protected unsafe virtual bool ReleaseFromTabPool(Tab? tab)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("releaseFromTabPool.(Lcom/google/android/material/tabs/TabLayout$Tab;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetRemoveAllTabsHandler()
	{
		return new global::_JniMarshal_PP_V(n_RemoveAllTabs);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveAllTabs(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllTabs();
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

	[Register("removeAllTabs", "()V", "GetRemoveAllTabsHandler")]
	public unsafe virtual void RemoveAllTabs()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllTabs.()V", this, null);
	}

	[Obsolete]
	private static Delegate GetRemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTabSelectedListener listener = Java.Lang.Object.GetObject<IOnTabSelectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			tabLayout.RemoveOnTabSelectedListener(listener);
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

	[Obsolete("deprecated")]
	[Register("removeOnTabSelectedListener", "(Lcom/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener;)V", "GetRemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_Handler")]
	public unsafe virtual void RemoveOnTabSelectedListener(IOnTabSelectedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnTabSelectedListener.(Lcom/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTabSelectedListener2 listener = Java.Lang.Object.GetObject<IOnTabSelectedListener2>(native_listener, JniHandleOwnership.DoNotTransfer);
			tabLayout.RemoveOnTabSelectedListener(listener);
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

	[Register("removeOnTabSelectedListener", "(Lcom/google/android/material/tabs/TabLayout$OnTabSelectedListener;)V", "GetRemoveOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_Handler")]
	public unsafe virtual void RemoveOnTabSelectedListener(IOnTabSelectedListener2 listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnTabSelectedListener.(Lcom/google/android/material/tabs/TabLayout$OnTabSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveTab_Lcom_google_android_material_tabs_TabLayout_Tab_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveTab_Lcom_google_android_material_tabs_TabLayout_Tab_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveTab_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			tabLayout.RemoveTab(tab);
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

	[Register("removeTab", "(Lcom/google/android/material/tabs/TabLayout$Tab;)V", "GetRemoveTab_Lcom_google_android_material_tabs_TabLayout_Tab_Handler")]
	public unsafe virtual void RemoveTab(Tab tab)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeTab.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetRemoveTabAt_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveTabAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveTabAt_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveTabAt(position);
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

	[Register("removeTabAt", "(I)V", "GetRemoveTabAt_IHandler")]
	public unsafe virtual void RemoveTabAt(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeTabAt.(I)V", this, ptr);
	}

	private static Delegate GetSelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_(nint jnienv, nint native__this, nint native_tab)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			tabLayout.SelectTab(tab);
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

	[Register("selectTab", "(Lcom/google/android/material/tabs/TabLayout$Tab;)V", "GetSelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_Handler")]
	public unsafe virtual void SelectTab(Tab? tab)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("selectTab.(Lcom/google/android/material/tabs/TabLayout$Tab;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetSelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_SelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_Z(nint jnienv, nint native__this, nint native_tab, sbyte native_updateIndicator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Tab tab = Java.Lang.Object.GetObject<Tab>(native_tab, JniHandleOwnership.DoNotTransfer);
			bool updateIndicator = native_updateIndicator != 0;
			tabLayout.SelectTab(tab, updateIndicator);
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

	[Register("selectTab", "(Lcom/google/android/material/tabs/TabLayout$Tab;Z)V", "GetSelectTab_Lcom_google_android_material_tabs_TabLayout_Tab_ZHandler")]
	public unsafe virtual void SelectTab(Tab? tab, bool updateIndicator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(tab?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(updateIndicator ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("selectTab.(Lcom/google/android/material/tabs/TabLayout$Tab;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tab);
		}
	}

	private static Delegate GetSetInlineLabelResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetInlineLabelResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInlineLabelResource_I(nint jnienv, nint native__this, int inlineResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetInlineLabelResource(inlineResourceId);
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

	[Register("setInlineLabelResource", "(I)V", "GetSetInlineLabelResource_IHandler")]
	public unsafe virtual void SetInlineLabelResource(int inlineResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(inlineResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setInlineLabelResource.(I)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTabSelectedListener onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			tabLayout.SetOnTabSelectedListener(onTabSelectedListener);
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

	[Obsolete("deprecated")]
	[Register("setOnTabSelectedListener", "(Lcom/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener;)V", "GetSetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_BaseOnTabSelectedListener_Handler")]
	public unsafe virtual void SetOnTabSelectedListener(IOnTabSelectedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnTabSelectedListener.(Lcom/google/android/material/tabs/TabLayout$BaseOnTabSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Obsolete]
	private static Delegate GetSetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnTabSelectedListener2 onTabSelectedListener = Java.Lang.Object.GetObject<IOnTabSelectedListener2>(native_listener, JniHandleOwnership.DoNotTransfer);
			tabLayout.SetOnTabSelectedListener(onTabSelectedListener);
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

	[Obsolete("deprecated")]
	[Register("setOnTabSelectedListener", "(Lcom/google/android/material/tabs/TabLayout$OnTabSelectedListener;)V", "GetSetOnTabSelectedListener_Lcom_google_android_material_tabs_TabLayout_OnTabSelectedListener_Handler")]
	public unsafe virtual void SetOnTabSelectedListener(IOnTabSelectedListener2? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnTabSelectedListener.(Lcom/google/android/material/tabs/TabLayout$OnTabSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetScrollPosition_IFZHandler()
	{
		return new _JniMarshal_PPIFB_V(n_SetScrollPosition_IFZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScrollPosition_IFZ(nint jnienv, nint native__this, int position, float positionOffset, sbyte native_updateSelectedTabView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool updateSelectedTabView = native_updateSelectedTabView != 0;
			tabLayout.SetScrollPosition(position, positionOffset, updateSelectedTabView);
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

	[Register("setScrollPosition", "(IFZ)V", "GetSetScrollPosition_IFZHandler")]
	public unsafe virtual void SetScrollPosition(int position, float positionOffset, bool updateSelectedTabView)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(positionOffset);
		ptr[2] = new JniArgumentValue(updateSelectedTabView ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScrollPosition.(IFZ)V", this, ptr);
	}

	private static Delegate GetSetScrollPosition_IFZZHandler()
	{
		return new _JniMarshal_PPIFBB_V(n_SetScrollPosition_IFZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScrollPosition_IFZZ(nint jnienv, nint native__this, int position, float positionOffset, sbyte native_updateSelectedTabView, sbyte native_updateIndicatorPosition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool updateSelectedTabView = native_updateSelectedTabView != 0;
			bool updateIndicatorPosition = native_updateIndicatorPosition != 0;
			tabLayout.SetScrollPosition(position, positionOffset, updateSelectedTabView, updateIndicatorPosition);
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

	[Register("setScrollPosition", "(IFZZ)V", "GetSetScrollPosition_IFZZHandler")]
	public unsafe virtual void SetScrollPosition(int position, float positionOffset, bool updateSelectedTabView, bool updateIndicatorPosition)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(positionOffset);
		ptr[2] = new JniArgumentValue(updateSelectedTabView ? ((sbyte)1) : ((sbyte)0));
		ptr[3] = new JniArgumentValue(updateIndicatorPosition ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScrollPosition.(IFZZ)V", this, ptr);
	}

	private static Delegate GetSetSelectedTabIndicator_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSelectedTabIndicator_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelectedTabIndicator_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_tabSelectedIndicator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable selectedTabIndicator = Java.Lang.Object.GetObject<Drawable>(native_tabSelectedIndicator, JniHandleOwnership.DoNotTransfer);
			tabLayout.SetSelectedTabIndicator(selectedTabIndicator);
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

	[Register("setSelectedTabIndicator", "(Landroid/graphics/drawable/Drawable;)V", "GetSetSelectedTabIndicator_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetSelectedTabIndicator(Drawable? tabSelectedIndicator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tabSelectedIndicator?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSelectedTabIndicator.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tabSelectedIndicator);
		}
	}

	private static Delegate GetSetSelectedTabIndicator_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSelectedTabIndicator_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelectedTabIndicator_I(nint jnienv, nint native__this, int tabSelectedIndicatorResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSelectedTabIndicator(tabSelectedIndicatorResourceId);
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

	[Register("setSelectedTabIndicator", "(I)V", "GetSetSelectedTabIndicator_IHandler")]
	public unsafe virtual void SetSelectedTabIndicator(int tabSelectedIndicatorResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(tabSelectedIndicatorResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSelectedTabIndicator.(I)V", this, ptr);
	}

	private static Delegate GetSetSelectedTabIndicatorColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSelectedTabIndicatorColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelectedTabIndicatorColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSelectedTabIndicatorColor(color);
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

	[Register("setSelectedTabIndicatorColor", "(I)V", "GetSetSelectedTabIndicatorColor_IHandler")]
	public unsafe virtual void SetSelectedTabIndicatorColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSelectedTabIndicatorColor.(I)V", this, ptr);
	}

	private static Delegate GetSetSelectedTabIndicatorGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSelectedTabIndicatorGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelectedTabIndicatorGravity_I(nint jnienv, nint native__this, int indicatorGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSelectedTabIndicatorGravity(indicatorGravity);
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

	[Register("setSelectedTabIndicatorGravity", "(I)V", "GetSetSelectedTabIndicatorGravity_IHandler")]
	public unsafe virtual void SetSelectedTabIndicatorGravity(int indicatorGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(indicatorGravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSelectedTabIndicatorGravity.(I)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetSelectedTabIndicatorHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSelectedTabIndicatorHeight_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelectedTabIndicatorHeight_I(nint jnienv, nint native__this, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSelectedTabIndicatorHeight(height);
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

	[Obsolete("deprecated")]
	[Register("setSelectedTabIndicatorHeight", "(I)V", "GetSetSelectedTabIndicatorHeight_IHandler")]
	public unsafe virtual void SetSelectedTabIndicatorHeight(int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSelectedTabIndicatorHeight.(I)V", this, ptr);
	}

	private static Delegate GetSetTabIconTintResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTabIconTintResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabIconTintResource_I(nint jnienv, nint native__this, int iconTintResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTabIconTintResource(iconTintResourceId);
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

	[Register("setTabIconTintResource", "(I)V", "GetSetTabIconTintResource_IHandler")]
	public unsafe virtual void SetTabIconTintResource(int iconTintResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconTintResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTabIconTintResource.(I)V", this, ptr);
	}

	private static Delegate GetSetTabRippleColorResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTabRippleColorResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabRippleColorResource_I(nint jnienv, nint native__this, int tabRippleColorResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTabRippleColorResource(tabRippleColorResourceId);
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

	[Register("setTabRippleColorResource", "(I)V", "GetSetTabRippleColorResource_IHandler")]
	public unsafe virtual void SetTabRippleColorResource(int tabRippleColorResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(tabRippleColorResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTabRippleColorResource.(I)V", this, ptr);
	}

	private static Delegate GetSetTabTextColors_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetTabTextColors_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabTextColors_II(nint jnienv, nint native__this, int normalColor, int selectedColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTabTextColors(normalColor, selectedColor);
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

	[Register("setTabTextColors", "(II)V", "GetSetTabTextColors_IIHandler")]
	public unsafe virtual void SetTabTextColors(int normalColor, int selectedColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(normalColor);
		ptr[1] = new JniArgumentValue(selectedColor);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTabTextColors.(II)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetTabsFromPagerAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTabsFromPagerAdapter_Landroidx_viewpager_widget_PagerAdapter_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTabsFromPagerAdapter_Landroidx_viewpager_widget_PagerAdapter_(nint jnienv, nint native__this, nint native_adapter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PagerAdapter tabsFromPagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			tabLayout.SetTabsFromPagerAdapter(tabsFromPagerAdapter);
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

	[Obsolete("deprecated")]
	[Register("setTabsFromPagerAdapter", "(Landroidx/viewpager/widget/PagerAdapter;)V", "GetSetTabsFromPagerAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler")]
	public unsafe virtual void SetTabsFromPagerAdapter(PagerAdapter? adapter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTabsFromPagerAdapter.(Landroidx/viewpager/widget/PagerAdapter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}

	private static Delegate GetSetUnboundedRipple_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUnboundedRipple_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUnboundedRipple_Z(nint jnienv, nint native__this, sbyte native_unboundedRipple)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool unboundedRipple = native_unboundedRipple != 0;
			tabLayout.SetUnboundedRipple(unboundedRipple);
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

	[Register("setUnboundedRipple", "(Z)V", "GetSetUnboundedRipple_ZHandler")]
	public unsafe virtual void SetUnboundedRipple(bool unboundedRipple)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(unboundedRipple ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setUnboundedRipple.(Z)V", this, ptr);
	}

	private static Delegate GetSetUnboundedRippleResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetUnboundedRippleResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUnboundedRippleResource_I(nint jnienv, nint native__this, int unboundedRippleResourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetUnboundedRippleResource(unboundedRippleResourceId);
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

	[Register("setUnboundedRippleResource", "(I)V", "GetSetUnboundedRippleResource_IHandler")]
	public unsafe virtual void SetUnboundedRippleResource(int unboundedRippleResourceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(unboundedRippleResourceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setUnboundedRippleResource.(I)V", this, ptr);
	}

	private static Delegate GetSetupWithViewPager_Landroidx_viewpager_widget_ViewPager_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetupWithViewPager_Landroidx_viewpager_widget_ViewPager_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetupWithViewPager_Landroidx_viewpager_widget_ViewPager_(nint jnienv, nint native__this, nint native_viewPager)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(native_viewPager, JniHandleOwnership.DoNotTransfer);
			tabLayout.SetupWithViewPager(viewPager);
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

	[Register("setupWithViewPager", "(Landroidx/viewpager/widget/ViewPager;)V", "GetSetupWithViewPager_Landroidx_viewpager_widget_ViewPager_Handler")]
	public unsafe virtual void SetupWithViewPager(ViewPager? viewPager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewPager?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupWithViewPager.(Landroidx/viewpager/widget/ViewPager;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(viewPager);
		}
	}

	private static Delegate GetSetupWithViewPager_Landroidx_viewpager_widget_ViewPager_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_SetupWithViewPager_Landroidx_viewpager_widget_ViewPager_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetupWithViewPager_Landroidx_viewpager_widget_ViewPager_Z(nint jnienv, nint native__this, nint native_viewPager, sbyte native_autoRefresh)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			TabLayout? tabLayout = Java.Lang.Object.GetObject<TabLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(native_viewPager, JniHandleOwnership.DoNotTransfer);
			bool autoRefresh = native_autoRefresh != 0;
			tabLayout.SetupWithViewPager(viewPager, autoRefresh);
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

	[Register("setupWithViewPager", "(Landroidx/viewpager/widget/ViewPager;Z)V", "GetSetupWithViewPager_Landroidx_viewpager_widget_ViewPager_ZHandler")]
	public unsafe virtual void SetupWithViewPager(ViewPager? viewPager, bool autoRefresh)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewPager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(autoRefresh ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupWithViewPager.(Landroidx/viewpager/widget/ViewPager;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(viewPager);
		}
	}

	private IOnTabSelectedListenerImplementor __CreateIOnTabSelectedListenerImplementor()
	{
		return new IOnTabSelectedListenerImplementor(this);
	}
}

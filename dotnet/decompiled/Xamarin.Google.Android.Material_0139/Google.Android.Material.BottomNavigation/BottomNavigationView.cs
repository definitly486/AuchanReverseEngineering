using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Google.Android.Material.Navigation;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.BottomNavigation;

[Register("com/google/android/material/bottomnavigation/BottomNavigationView", DoNotGenerateAcw = true)]
public class BottomNavigationView : NavigationBarView
{
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemReselectedListener", "", "Google.Android.Material.BottomNavigation.BottomNavigationView/IOnNavigationItemReselectedListenerInvoker")]
	public interface IOnNavigationItemReselectedListener : IOnItemReselectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
	}

	[Register("com/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemReselectedListener", DoNotGenerateAcw = true)]
	[Obsolete("This class is obsoleted in this android platform")]
	internal class IOnNavigationItemReselectedListenerInvoker : Java.Lang.Object, IOnNavigationItemReselectedListener, IOnItemReselectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener = new XAPeerMembers("com/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemReselectedListener", typeof(IOnNavigationItemReselectedListenerInvoker));

		private static readonly JniPeerMembers _members_com_google_android_material_navigation_NavigationBarView_OnItemReselectedListener = new XAPeerMembers("com/google/android/material/navigation/NavigationBarView$OnItemReselectedListener", typeof(IOnNavigationItemReselectedListenerInvoker));

		private static Delegate? cb_onNavigationItemReselected_OnNavigationItemReselected_Landroid_view_MenuItem__V;

		private static nint java_class_ref => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener.ManagedPeerType;

		public IOnNavigationItemReselectedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnNavigationItemReselected_Landroid_view_MenuItem_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnNavigationItemReselected_Landroid_view_MenuItem_);
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
				IOnNavigationItemReselectedListener? onNavigationItemReselectedListener = Java.Lang.Object.GetObject<IOnNavigationItemReselectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenuItem p = Java.Lang.Object.GetObject<IMenuItem>(native_p0, JniHandleOwnership.DoNotTransfer);
				onNavigationItemReselectedListener.OnNavigationItemReselected(p);
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
	}

	[Obsolete("This class is obsoleted in this android platform")]
	[Register("com/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemSelectedListener", "", "Google.Android.Material.BottomNavigation.BottomNavigationView/IOnNavigationItemSelectedListenerInvoker")]
	public interface IOnNavigationItemSelectedListener : IOnItemSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
	}

	[Register("com/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemSelectedListener", DoNotGenerateAcw = true)]
	[Obsolete("This class is obsoleted in this android platform")]
	internal class IOnNavigationItemSelectedListenerInvoker : Java.Lang.Object, IOnNavigationItemSelectedListener, IOnItemSelectedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener = new XAPeerMembers("com/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemSelectedListener", typeof(IOnNavigationItemSelectedListenerInvoker));

		private static readonly JniPeerMembers _members_com_google_android_material_navigation_NavigationBarView_OnItemSelectedListener = new XAPeerMembers("com/google/android/material/navigation/NavigationBarView$OnItemSelectedListener", typeof(IOnNavigationItemSelectedListenerInvoker));

		private static Delegate? cb_onNavigationItemSelected_OnNavigationItemSelected_Landroid_view_MenuItem__Z;

		private static nint java_class_ref => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener.ManagedPeerType;

		public IOnNavigationItemSelectedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnNavigationItemSelected_Landroid_view_MenuItem_Handler()
		{
			return new global::_JniMarshal_PPL_B(n_OnNavigationItemSelected_Landroid_view_MenuItem_);
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
				IOnNavigationItemSelectedListener? onNavigationItemSelectedListener = Java.Lang.Object.GetObject<IOnNavigationItemSelectedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenuItem p = Java.Lang.Object.GetObject<IMenuItem>(native_p0, JniHandleOwnership.DoNotTransfer);
				return onNavigationItemSelectedListener.OnNavigationItemSelected(p) ? ((sbyte)1) : ((sbyte)0);
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/bottomnavigation/BottomNavigationView", typeof(BottomNavigationView));

	private static Delegate? cb_isItemHorizontalTranslationEnabled_IsItemHorizontalTranslationEnabled_Z;

	private static Delegate? cb_setItemHorizontalTranslationEnabled_SetItemHorizontalTranslationEnabled_Z_V;

	private static Delegate? cb_getMaxItemCount_GetMaxItemCount_I;

	private static Delegate? cb_createNavigationBarMenuView_CreateNavigationBarMenuView_Landroid_content_Context__Lcom_google_android_material_navigation_NavigationBarMenuView_;

	private static Delegate? cb_setOnNavigationItemReselectedListener_SetOnNavigationItemReselectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener__V;

	private static Delegate? cb_setOnNavigationItemSelectedListener_SetOnNavigationItemSelectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener__V;

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

	public unsafe virtual bool ItemHorizontalTranslationEnabled
	{
		[Register("isItemHorizontalTranslationEnabled", "()Z", "GetIsItemHorizontalTranslationEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemHorizontalTranslationEnabled.()Z", this, null);
		}
		[Register("setItemHorizontalTranslationEnabled", "(Z)V", "GetSetItemHorizontalTranslationEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemHorizontalTranslationEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe override int MaxItemCount
	{
		[Register("getMaxItemCount", "()I", "GetGetMaxItemCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxItemCount.()I", this, null);
		}
	}

	protected BottomNavigationView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe BottomNavigationView(Context context)
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
	public unsafe BottomNavigationView(Context context, IAttributeSet? attrs)
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
	public unsafe BottomNavigationView(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe BottomNavigationView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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

	private static Delegate GetIsItemHorizontalTranslationEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsItemHorizontalTranslationEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsItemHorizontalTranslationEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BottomNavigationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemHorizontalTranslationEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetItemHorizontalTranslationEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetItemHorizontalTranslationEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemHorizontalTranslationEnabled_Z(nint jnienv, nint native__this, sbyte native_itemHorizontalTranslationEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomNavigationView? bottomNavigationView = Java.Lang.Object.GetObject<BottomNavigationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool itemHorizontalTranslationEnabled = native_itemHorizontalTranslationEnabled != 0;
			bottomNavigationView.ItemHorizontalTranslationEnabled = itemHorizontalTranslationEnabled;
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
			return Java.Lang.Object.GetObject<BottomNavigationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxItemCount;
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

	private static Delegate GetCreateNavigationBarMenuView_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_CreateNavigationBarMenuView_Landroid_content_Context_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateNavigationBarMenuView_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BottomNavigationView? bottomNavigationView = Java.Lang.Object.GetObject<BottomNavigationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bottomNavigationView.CreateNavigationBarMenuView(p));
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
	protected unsafe override NavigationBarMenuView CreateNavigationBarMenuView(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(_members.InstanceMethods.InvokeVirtualObjectMethod("createNavigationBarMenuView.(Landroid/content/Context;)Lcom/google/android/material/navigation/NavigationBarMenuView;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Obsolete]
	private static Delegate GetSetOnNavigationItemReselectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnNavigationItemReselectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnNavigationItemReselectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomNavigationView? bottomNavigationView = Java.Lang.Object.GetObject<BottomNavigationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnNavigationItemReselectedListener onNavigationItemReselectedListener = Java.Lang.Object.GetObject<IOnNavigationItemReselectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			bottomNavigationView.SetOnNavigationItemReselectedListener(onNavigationItemReselectedListener);
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
	[Register("setOnNavigationItemReselectedListener", "(Lcom/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemReselectedListener;)V", "GetSetOnNavigationItemReselectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemReselectedListener_Handler")]
	public unsafe virtual void SetOnNavigationItemReselectedListener(IOnNavigationItemReselectedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnNavigationItemReselectedListener.(Lcom/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemReselectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Obsolete]
	private static Delegate GetSetOnNavigationItemSelectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnNavigationItemSelectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnNavigationItemSelectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BottomNavigationView? bottomNavigationView = Java.Lang.Object.GetObject<BottomNavigationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnNavigationItemSelectedListener onNavigationItemSelectedListener = Java.Lang.Object.GetObject<IOnNavigationItemSelectedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			bottomNavigationView.SetOnNavigationItemSelectedListener(onNavigationItemSelectedListener);
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
	[Register("setOnNavigationItemSelectedListener", "(Lcom/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemSelectedListener;)V", "GetSetOnNavigationItemSelectedListener_Lcom_google_android_material_bottomnavigation_BottomNavigationView_OnNavigationItemSelectedListener_Handler")]
	public unsafe virtual void SetOnNavigationItemSelectedListener(IOnNavigationItemSelectedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnNavigationItemSelectedListener.(Lcom/google/android/material/bottomnavigation/BottomNavigationView$OnNavigationItemSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}
}

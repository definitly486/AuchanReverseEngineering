using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.Shape;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.AppBar;

[Register("com/google/android/material/appbar/AppBarLayout", DoNotGenerateAcw = true)]
public class AppBarLayout : LinearLayout, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/google/android/material/appbar/AppBarLayout$LiftOnScrollListener", "", "Google.Android.Material.AppBar.AppBarLayout/ILiftOnScrollListenerInvoker")]
	public interface ILiftOnScrollListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onUpdate", "(FI)V", "GetOnUpdate_FIHandler:Google.Android.Material.AppBar.AppBarLayout/ILiftOnScrollListenerInvoker, Xamarin.Google.Android.Material")]
		void OnUpdate(float p0, int p1);
	}

	[Register("com/google/android/material/appbar/AppBarLayout$LiftOnScrollListener", DoNotGenerateAcw = true)]
	internal class ILiftOnScrollListenerInvoker : Java.Lang.Object, ILiftOnScrollListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_appbar_AppBarLayout_LiftOnScrollListener = new XAPeerMembers("com/google/android/material/appbar/AppBarLayout$LiftOnScrollListener", typeof(ILiftOnScrollListenerInvoker));

		private static Delegate? cb_onUpdate_OnUpdate_FI_V;

		private static nint java_class_ref => _members_com_google_android_material_appbar_AppBarLayout_LiftOnScrollListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_appbar_AppBarLayout_LiftOnScrollListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_appbar_AppBarLayout_LiftOnScrollListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_appbar_AppBarLayout_LiftOnScrollListener.ManagedPeerType;

		public ILiftOnScrollListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnUpdate_FI(nint jnienv, nint native__this, float p0, int p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ILiftOnScrollListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnUpdate(p0, p1);
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

		public unsafe void OnUpdate(float p0, int p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			_members_com_google_android_material_appbar_AppBarLayout_LiftOnScrollListener.InstanceMethods.InvokeAbstractVoidMethod("onUpdate.(FI)V", this, ptr);
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
		private static void n_OnUpdate_FI_mm_wrapper(nint jnienv, nint native__this, float p0, int p1)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnUpdate_FI(jnienv, native__this, p0, p1);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class LiftOnScrollEventArgs : EventArgs
	{
		private float p0;

		private int p1;

		public LiftOnScrollEventArgs(float p0, int p1)
		{
			this.p0 = p0;
			this.p1 = p1;
		}
	}

	[Register("mono/com/google/android/material/appbar/AppBarLayout_LiftOnScrollListenerImplementor")]
	internal sealed class ILiftOnScrollListenerImplementor : Java.Lang.Object, ILiftOnScrollListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<LiftOnScrollEventArgs>? Handler;

		public unsafe ILiftOnScrollListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnUpdate(float p0, int p1)
		{
			Handler?.Invoke(sender, new LiftOnScrollEventArgs(p0, p1));
		}

		internal static bool __IsEmpty(ILiftOnScrollListenerImplementor value)
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

	[Register("com/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener", "", "Google.Android.Material.AppBar.AppBarLayout/IOnOffsetChangedListenerInvoker")]
	public interface IOnOffsetChangedListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onOffsetChanged", "(Lcom/google/android/material/appbar/AppBarLayout;I)V", "GetOnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_IHandler:Google.Android.Material.AppBar.AppBarLayout/IOnOffsetChangedListenerInvoker, Xamarin.Google.Android.Material")]
		void OnOffsetChanged(AppBarLayout? appBarLayout, int verticalOffset);
	}

	[Register("com/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener", DoNotGenerateAcw = true)]
	internal class IOnOffsetChangedListenerInvoker : Java.Lang.Object, IOnOffsetChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener = new XAPeerMembers("com/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener", typeof(IOnOffsetChangedListenerInvoker));

		private static Delegate? cb_onOffsetChanged_OnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I_V;

		private static nint java_class_ref => _members_com_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener.ManagedPeerType;

		public IOnOffsetChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I(nint jnienv, nint native__this, nint native_appBarLayout, int verticalOffset)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnOffsetChangedListener? onOffsetChangedListener = Java.Lang.Object.GetObject<IOnOffsetChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AppBarLayout appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(native_appBarLayout, JniHandleOwnership.DoNotTransfer);
				onOffsetChangedListener.OnOffsetChanged(appBarLayout, verticalOffset);
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

		public unsafe void OnOffsetChanged(AppBarLayout? appBarLayout, int verticalOffset)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(appBarLayout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(verticalOffset);
				_members_com_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onOffsetChanged.(Lcom/google/android/material/appbar/AppBarLayout;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(appBarLayout);
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
		private static void n_OnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I_mm_wrapper(nint jnienv, nint native__this, nint native_appBarLayout, int verticalOffset)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnOffsetChanged_Lcom_google_android_material_appbar_AppBarLayout_I(jnienv, native__this, native_appBarLayout, verticalOffset);
			}
			catch (System.Exception e)
			{
				global::Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class OffsetChangedEventArgs : EventArgs
	{
		private AppBarLayout? appBarLayout;

		private int verticalOffset;

		public OffsetChangedEventArgs(AppBarLayout? appBarLayout, int verticalOffset)
		{
			this.appBarLayout = appBarLayout;
			this.verticalOffset = verticalOffset;
		}
	}

	[Register("mono/com/google/android/material/appbar/AppBarLayout_OnOffsetChangedListenerImplementor")]
	internal sealed class IOnOffsetChangedListenerImplementor : Java.Lang.Object, IOnOffsetChangedListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<OffsetChangedEventArgs>? Handler;

		public unsafe IOnOffsetChangedListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnOffsetChanged(AppBarLayout? appBarLayout, int verticalOffset)
		{
			Handler?.Invoke(sender, new OffsetChangedEventArgs(appBarLayout, verticalOffset));
		}

		internal static bool __IsEmpty(IOnOffsetChangedListenerImplementor value)
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/appbar/AppBarLayout", typeof(AppBarLayout));

	private static Delegate? cb_isLifted_IsLifted_Z;

	private static Delegate? cb_isLiftOnScroll_IsLiftOnScroll_Z;

	private static Delegate? cb_setLiftOnScroll_SetLiftOnScroll_Z_V;

	private static Delegate? cb_getLiftOnScrollTargetViewId_GetLiftOnScrollTargetViewId_I;

	private static Delegate? cb_setLiftOnScrollTargetViewId_SetLiftOnScrollTargetViewId_I_V;

	private static Delegate? cb_getMaterialShapeBackground_GetMaterialShapeBackground_Lcom_google_android_material_shape_MaterialShapeDrawable_;

	private static Delegate? cb_getStatusBarForeground_GetStatusBarForeground_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setStatusBarForeground_SetStatusBarForeground_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getTargetElevation_GetTargetElevation_F;

	private static Delegate? cb_setTargetElevation_SetTargetElevation_F_V;

	private static Delegate? cb_addLiftOnScrollListener_AddLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener__V;

	private static Delegate? cb_addOnOffsetChangedListener_AddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener__V;

	private static Delegate? cb_clearLiftOnScrollListener_ClearLiftOnScrollListener_V;

	private static Delegate? cb_getBehavior_GetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_;

	private static Delegate? cb_removeLiftOnScrollListener_RemoveLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener__Z;

	private static Delegate? cb_removeOnOffsetChangedListener_RemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener__V;

	private static Delegate? cb_setExpanded_SetExpanded_Z_V;

	private static Delegate? cb_setExpanded_SetExpanded_ZZ_V;

	private static Delegate? cb_setLiftOnScrollTargetView_SetLiftOnScrollTargetView_Landroid_view_View__V;

	private static Delegate? cb_setLiftable_SetLiftable_Z_Z;

	private static Delegate? cb_setLiftableOverrideEnabled_SetLiftableOverrideEnabled_Z_V;

	private static Delegate? cb_setLifted_SetLifted_Z_Z;

	private static Delegate? cb_setStatusBarForegroundColor_SetStatusBarForegroundColor_I_V;

	private static Delegate? cb_setStatusBarForegroundResource_SetStatusBarForegroundResource_I_V;

	private WeakReference? weak_implementor_AddLiftOnScrollListener;

	private WeakReference? weak_implementor_AddOnOffsetChangedListener;

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

	public unsafe virtual bool IsLifted
	{
		[Register("isLifted", "()Z", "GetIsLiftedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLifted.()Z", this, null);
		}
	}

	public unsafe virtual bool LiftOnScroll
	{
		[Register("isLiftOnScroll", "()Z", "GetIsLiftOnScrollHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLiftOnScroll.()Z", this, null);
		}
		[Register("setLiftOnScroll", "(Z)V", "GetSetLiftOnScroll_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLiftOnScroll.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int LiftOnScrollTargetViewId
	{
		[Register("getLiftOnScrollTargetViewId", "()I", "GetGetLiftOnScrollTargetViewIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLiftOnScrollTargetViewId.()I", this, null);
		}
		[Register("setLiftOnScrollTargetViewId", "(I)V", "GetSetLiftOnScrollTargetViewId_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLiftOnScrollTargetViewId.(I)V", this, ptr);
		}
	}

	public unsafe virtual MaterialShapeDrawable? MaterialShapeBackground
	{
		[Register("getMaterialShapeBackground", "()Lcom/google/android/material/shape/MaterialShapeDrawable;", "GetGetMaterialShapeBackgroundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMaterialShapeBackground.()Lcom/google/android/material/shape/MaterialShapeDrawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int MinimumHeightForVisibleOverlappingContent
	{
		[Register("getMinimumHeightForVisibleOverlappingContent", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getMinimumHeightForVisibleOverlappingContent.()I", this, null);
		}
	}

	public unsafe virtual Drawable? StatusBarForeground
	{
		[Register("getStatusBarForeground", "()Landroid/graphics/drawable/Drawable;", "GetGetStatusBarForegroundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStatusBarForeground.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStatusBarForeground", "(Landroid/graphics/drawable/Drawable;)V", "GetSetStatusBarForeground_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarForeground.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual float TargetElevation
	{
		[Register("getTargetElevation", "()F", "GetGetTargetElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTargetElevation.()F", this, null);
		}
		[Register("setTargetElevation", "(F)V", "GetSetTargetElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTargetElevation.(F)V", this, ptr);
		}
	}

	public unsafe int TotalScrollRange
	{
		[Register("getTotalScrollRange", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getTotalScrollRange.()I", this, null);
		}
	}

	public event EventHandler<LiftOnScrollEventArgs> LiftOnScrollEvent
	{
		add
		{
			EventHelper.AddEventHandler<ILiftOnScrollListener, ILiftOnScrollListenerImplementor>(ref weak_implementor_AddLiftOnScrollListener, __CreateILiftOnScrollListenerImplementor, AddLiftOnScrollListener, delegate(ILiftOnScrollListenerImplementor __h)
			{
				__h.Handler = (EventHandler<LiftOnScrollEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddLiftOnScrollListener, ILiftOnScrollListenerImplementor.__IsEmpty, delegate(ILiftOnScrollListener __v)
			{
				RemoveLiftOnScrollListener(__v);
			}, delegate(ILiftOnScrollListenerImplementor __h)
			{
				__h.Handler = (EventHandler<LiftOnScrollEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<OffsetChangedEventArgs> OffsetChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnOffsetChangedListener, IOnOffsetChangedListenerImplementor>(ref weak_implementor_AddOnOffsetChangedListener, __CreateIOnOffsetChangedListenerImplementor, AddOnOffsetChangedListener, delegate(IOnOffsetChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<OffsetChangedEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnOffsetChangedListener, IOnOffsetChangedListenerImplementor.__IsEmpty, delegate(IOnOffsetChangedListener __v)
			{
				RemoveOnOffsetChangedListener(__v);
			}, delegate(IOnOffsetChangedListenerImplementor __h)
			{
				__h.Handler = (EventHandler<OffsetChangedEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected AppBarLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe AppBarLayout(Context context)
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
	public unsafe AppBarLayout(Context context, IAttributeSet? attrs)
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
	public unsafe AppBarLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetIsLiftedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsLifted);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLifted(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLifted ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsLiftOnScrollHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsLiftOnScroll);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLiftOnScroll(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LiftOnScroll ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetLiftOnScroll_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetLiftOnScroll_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLiftOnScroll_Z(nint jnienv, nint native__this, sbyte native_liftOnScroll)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool liftOnScroll = native_liftOnScroll != 0;
			appBarLayout.LiftOnScroll = liftOnScroll;
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

	private static Delegate GetGetLiftOnScrollTargetViewIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLiftOnScrollTargetViewId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLiftOnScrollTargetViewId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LiftOnScrollTargetViewId;
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

	private static Delegate GetSetLiftOnScrollTargetViewId_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLiftOnScrollTargetViewId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLiftOnScrollTargetViewId_I(nint jnienv, nint native__this, int liftOnScrollTargetViewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LiftOnScrollTargetViewId = liftOnScrollTargetViewId;
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

	private static Delegate GetGetMaterialShapeBackgroundHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMaterialShapeBackground);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMaterialShapeBackground(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaterialShapeBackground);
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

	private static Delegate GetGetStatusBarForegroundHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStatusBarForeground);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStatusBarForeground(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StatusBarForeground);
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

	private static Delegate GetSetStatusBarForeground_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStatusBarForeground_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarForeground_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable statusBarForeground = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			appBarLayout.StatusBarForeground = statusBarForeground;
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
	private static Delegate GetGetTargetElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTargetElevation);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTargetElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetElevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetSetTargetElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetTargetElevation_F);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTargetElevation_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetElevation = elevation;
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

	private static Delegate GetAddLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_(nint jnienv, nint native__this, nint native_liftOnScrollListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILiftOnScrollListener liftOnScrollListener = Java.Lang.Object.GetObject<ILiftOnScrollListener>(native_liftOnScrollListener, JniHandleOwnership.DoNotTransfer);
			appBarLayout.AddLiftOnScrollListener(liftOnScrollListener);
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

	[Register("addLiftOnScrollListener", "(Lcom/google/android/material/appbar/AppBarLayout$LiftOnScrollListener;)V", "GetAddLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_Handler")]
	public unsafe virtual void AddLiftOnScrollListener(ILiftOnScrollListener liftOnScrollListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((liftOnScrollListener == null) ? IntPtr.Zero : ((Java.Lang.Object)liftOnScrollListener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addLiftOnScrollListener.(Lcom/google/android/material/appbar/AppBarLayout$LiftOnScrollListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(liftOnScrollListener);
		}
	}

	private static Delegate GetAddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnOffsetChangedListener listener = Java.Lang.Object.GetObject<IOnOffsetChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			appBarLayout.AddOnOffsetChangedListener(listener);
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

	[Register("addOnOffsetChangedListener", "(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", "GetAddOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler")]
	public unsafe virtual void AddOnOffsetChangedListener(IOnOffsetChangedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnOffsetChangedListener.(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearLiftOnScrollListenerHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearLiftOnScrollListener);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearLiftOnScrollListener(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearLiftOnScrollListener();
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

	[Register("clearLiftOnScrollListener", "()V", "GetClearLiftOnScrollListenerHandler")]
	public unsafe virtual void ClearLiftOnScrollListener()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearLiftOnScrollListener.()V", this, null);
	}

	private static Delegate GetGetBehaviorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBehavior);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBehavior(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBehavior());
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

	[Register("getBehavior", "()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", "GetGetBehaviorHandler")]
	public unsafe virtual CoordinatorLayout.Behavior GetBehavior()
	{
		return Java.Lang.Object.GetObject<CoordinatorLayout.Behavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBehavior.()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_RemoveLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_(nint jnienv, nint native__this, nint native_liftOnScrollListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILiftOnScrollListener liftOnScrollListener = Java.Lang.Object.GetObject<ILiftOnScrollListener>(native_liftOnScrollListener, JniHandleOwnership.DoNotTransfer);
			return appBarLayout.RemoveLiftOnScrollListener(liftOnScrollListener) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("removeLiftOnScrollListener", "(Lcom/google/android/material/appbar/AppBarLayout$LiftOnScrollListener;)Z", "GetRemoveLiftOnScrollListener_Lcom_google_android_material_appbar_AppBarLayout_LiftOnScrollListener_Handler")]
	public unsafe virtual bool RemoveLiftOnScrollListener(ILiftOnScrollListener liftOnScrollListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((liftOnScrollListener == null) ? IntPtr.Zero : ((Java.Lang.Object)liftOnScrollListener).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeLiftOnScrollListener.(Lcom/google/android/material/appbar/AppBarLayout$LiftOnScrollListener;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(liftOnScrollListener);
		}
	}

	private static Delegate GetRemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnOffsetChangedListener listener = Java.Lang.Object.GetObject<IOnOffsetChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			appBarLayout.RemoveOnOffsetChangedListener(listener);
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

	[Register("removeOnOffsetChangedListener", "(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", "GetRemoveOnOffsetChangedListener_Lcom_google_android_material_appbar_AppBarLayout_OnOffsetChangedListener_Handler")]
	public unsafe virtual void RemoveOnOffsetChangedListener(IOnOffsetChangedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnOffsetChangedListener.(Lcom/google/android/material/appbar/AppBarLayout$OnOffsetChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetExpanded_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetExpanded_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExpanded_Z(nint jnienv, nint native__this, sbyte native_expanded)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool expanded = native_expanded != 0;
			appBarLayout.SetExpanded(expanded);
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

	[Register("setExpanded", "(Z)V", "GetSetExpanded_ZHandler")]
	public unsafe virtual void SetExpanded(bool expanded)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(expanded ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setExpanded.(Z)V", this, ptr);
	}

	private static Delegate GetSetExpanded_ZZHandler()
	{
		return new _JniMarshal_PPBB_V(n_SetExpanded_ZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExpanded_ZZ(nint jnienv, nint native__this, sbyte native_expanded, sbyte native_animate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool expanded = native_expanded != 0;
			bool animate = native_animate != 0;
			appBarLayout.SetExpanded(expanded, animate);
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

	[Register("setExpanded", "(ZZ)V", "GetSetExpanded_ZZHandler")]
	public unsafe virtual void SetExpanded(bool expanded, bool animate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(expanded ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(animate ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setExpanded.(ZZ)V", this, ptr);
	}

	private static Delegate GetSetLiftOnScrollTargetView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLiftOnScrollTargetView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLiftOnScrollTargetView_Landroid_view_View_(nint jnienv, nint native__this, nint native_liftOnScrollTargetView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View liftOnScrollTargetView = Java.Lang.Object.GetObject<View>(native_liftOnScrollTargetView, JniHandleOwnership.DoNotTransfer);
			appBarLayout.SetLiftOnScrollTargetView(liftOnScrollTargetView);
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

	[Register("setLiftOnScrollTargetView", "(Landroid/view/View;)V", "GetSetLiftOnScrollTargetView_Landroid_view_View_Handler")]
	public unsafe virtual void SetLiftOnScrollTargetView(View? liftOnScrollTargetView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(liftOnScrollTargetView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLiftOnScrollTargetView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(liftOnScrollTargetView);
		}
	}

	private static Delegate GetSetLiftable_ZHandler()
	{
		return new global::_JniMarshal_PPB_B(n_SetLiftable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetLiftable_Z(nint jnienv, nint native__this, sbyte native_liftable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool liftable = native_liftable != 0;
			return appBarLayout.SetLiftable(liftable) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setLiftable", "(Z)Z", "GetSetLiftable_ZHandler")]
	public unsafe virtual bool SetLiftable(bool liftable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(liftable ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setLiftable.(Z)Z", this, ptr);
	}

	private static Delegate GetSetLiftableOverrideEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetLiftableOverrideEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLiftableOverrideEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool liftableOverrideEnabled = native_enabled != 0;
			appBarLayout.SetLiftableOverrideEnabled(liftableOverrideEnabled);
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

	[Register("setLiftableOverrideEnabled", "(Z)V", "GetSetLiftableOverrideEnabled_ZHandler")]
	public unsafe virtual void SetLiftableOverrideEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLiftableOverrideEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetLifted_ZHandler()
	{
		return new global::_JniMarshal_PPB_B(n_SetLifted_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetLifted_Z(nint jnienv, nint native__this, sbyte native_lifted)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppBarLayout? appBarLayout = Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool lifted = native_lifted != 0;
			return appBarLayout.SetLifted(lifted) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setLifted", "(Z)Z", "GetSetLifted_ZHandler")]
	public unsafe virtual bool SetLifted(bool lifted)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(lifted ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setLifted.(Z)Z", this, ptr);
	}

	private static Delegate GetSetStatusBarForegroundColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStatusBarForegroundColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarForegroundColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarForegroundColor(color);
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

	[Register("setStatusBarForegroundColor", "(I)V", "GetSetStatusBarForegroundColor_IHandler")]
	public unsafe virtual void SetStatusBarForegroundColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarForegroundColor.(I)V", this, ptr);
	}

	private static Delegate GetSetStatusBarForegroundResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStatusBarForegroundResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStatusBarForegroundResource_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppBarLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStatusBarForegroundResource(resId);
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

	[Register("setStatusBarForegroundResource", "(I)V", "GetSetStatusBarForegroundResource_IHandler")]
	public unsafe virtual void SetStatusBarForegroundResource(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStatusBarForegroundResource.(I)V", this, ptr);
	}

	private ILiftOnScrollListenerImplementor __CreateILiftOnScrollListenerImplementor()
	{
		return new ILiftOnScrollListenerImplementor(this);
	}

	private IOnOffsetChangedListenerImplementor __CreateIOnOffsetChangedListenerImplementor()
	{
		return new IOnOffsetChangedListenerImplementor(this);
	}
}

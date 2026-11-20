using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ViewPager.Widget;

[Register("androidx/viewpager/widget/ViewPager", DoNotGenerateAcw = true)]
public class ViewPager : ViewGroup
{
	[Register("androidx/viewpager/widget/ViewPager$OnAdapterChangeListener", "", "AndroidX.ViewPager.Widget.ViewPager/IOnAdapterChangeListenerInvoker")]
	public interface IOnAdapterChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onAdapterChanged", "(Landroidx/viewpager/widget/ViewPager;Landroidx/viewpager/widget/PagerAdapter;Landroidx/viewpager/widget/PagerAdapter;)V", "GetOnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler:AndroidX.ViewPager.Widget.ViewPager/IOnAdapterChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
		void OnAdapterChanged(ViewPager viewPager, PagerAdapter? oldAdapter, PagerAdapter? newAdapter);
	}

	[Register("androidx/viewpager/widget/ViewPager$OnAdapterChangeListener", DoNotGenerateAcw = true)]
	internal class IOnAdapterChangeListenerInvoker : Java.Lang.Object, IOnAdapterChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_viewpager_widget_ViewPager_OnAdapterChangeListener = new XAPeerMembers("androidx/viewpager/widget/ViewPager$OnAdapterChangeListener", typeof(IOnAdapterChangeListenerInvoker));

		private static Delegate? cb_onAdapterChanged_OnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter__V;

		private static nint java_class_ref => _members_androidx_viewpager_widget_ViewPager_OnAdapterChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_viewpager_widget_ViewPager_OnAdapterChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_viewpager_widget_ViewPager_OnAdapterChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_viewpager_widget_ViewPager_OnAdapterChangeListener.ManagedPeerType;

		public IOnAdapterChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_(nint jnienv, nint native__this, nint native_viewPager, nint native_oldAdapter, nint native_newAdapter)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnAdapterChangeListener? onAdapterChangeListener = Java.Lang.Object.GetObject<IOnAdapterChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewPager viewPager = Java.Lang.Object.GetObject<ViewPager>(native_viewPager, JniHandleOwnership.DoNotTransfer);
				PagerAdapter oldAdapter = Java.Lang.Object.GetObject<PagerAdapter>(native_oldAdapter, JniHandleOwnership.DoNotTransfer);
				PagerAdapter newAdapter = Java.Lang.Object.GetObject<PagerAdapter>(native_newAdapter, JniHandleOwnership.DoNotTransfer);
				onAdapterChangeListener.OnAdapterChanged(viewPager, oldAdapter, newAdapter);
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

		public unsafe void OnAdapterChanged(ViewPager viewPager, PagerAdapter? oldAdapter, PagerAdapter? newAdapter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewPager?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(oldAdapter?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(newAdapter?.Handle ?? IntPtr.Zero);
				_members_androidx_viewpager_widget_ViewPager_OnAdapterChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onAdapterChanged.(Landroidx/viewpager/widget/ViewPager;Landroidx/viewpager/widget/PagerAdapter;Landroidx/viewpager/widget/PagerAdapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewPager);
				GC.KeepAlive(oldAdapter);
				GC.KeepAlive(newAdapter);
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
		private static void n_OnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter__mm_wrapper(nint jnienv, nint native__this, nint native_viewPager, nint native_oldAdapter, nint native_newAdapter)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAdapterChanged_Landroidx_viewpager_widget_ViewPager_Landroidx_viewpager_widget_PagerAdapter_Landroidx_viewpager_widget_PagerAdapter_(jnienv, native__this, native_viewPager, native_oldAdapter, native_newAdapter);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class AdapterChangeEventArgs : EventArgs
	{
		private ViewPager viewPager;

		private PagerAdapter? oldAdapter;

		private PagerAdapter? newAdapter;

		public AdapterChangeEventArgs(ViewPager viewPager, PagerAdapter? oldAdapter, PagerAdapter? newAdapter)
		{
			this.viewPager = viewPager;
			this.oldAdapter = oldAdapter;
			this.newAdapter = newAdapter;
		}
	}

	[Register("mono/androidx/viewpager/widget/ViewPager_OnAdapterChangeListenerImplementor")]
	internal sealed class IOnAdapterChangeListenerImplementor : Java.Lang.Object, IOnAdapterChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<AdapterChangeEventArgs>? Handler;

		public unsafe IOnAdapterChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnAdapterChanged(ViewPager viewPager, PagerAdapter? oldAdapter, PagerAdapter? newAdapter)
		{
			Handler?.Invoke(sender, new AdapterChangeEventArgs(viewPager, oldAdapter, newAdapter));
		}

		internal static bool __IsEmpty(IOnAdapterChangeListenerImplementor value)
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

	[Register("androidx/viewpager/widget/ViewPager$OnPageChangeListener", "", "AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker")]
	public interface IOnPageChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onPageScrollStateChanged", "(I)V", "GetOnPageScrollStateChanged_IHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
		void OnPageScrollStateChanged(int state);

		[Register("onPageScrolled", "(IFI)V", "GetOnPageScrolled_IFIHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
		void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels);

		[Register("onPageSelected", "(I)V", "GetOnPageSelected_IHandler:AndroidX.ViewPager.Widget.ViewPager/IOnPageChangeListenerInvoker, Xamarin.AndroidX.ViewPager")]
		void OnPageSelected(int position);
	}

	[Register("androidx/viewpager/widget/ViewPager$OnPageChangeListener", DoNotGenerateAcw = true)]
	internal class IOnPageChangeListenerInvoker : Java.Lang.Object, IOnPageChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_viewpager_widget_ViewPager_OnPageChangeListener = new XAPeerMembers("androidx/viewpager/widget/ViewPager$OnPageChangeListener", typeof(IOnPageChangeListenerInvoker));

		private static Delegate? cb_onPageScrollStateChanged_OnPageScrollStateChanged_I_V;

		private static Delegate? cb_onPageScrolled_OnPageScrolled_IFI_V;

		private static Delegate? cb_onPageSelected_OnPageSelected_I_V;

		private static nint java_class_ref => _members_androidx_viewpager_widget_ViewPager_OnPageChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_viewpager_widget_ViewPager_OnPageChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_viewpager_widget_ViewPager_OnPageChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_viewpager_widget_ViewPager_OnPageChangeListener.ManagedPeerType;

		public IOnPageChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnPageScrollStateChanged_I(nint jnienv, nint native__this, int state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnPageChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrollStateChanged(state);
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

		public unsafe void OnPageScrollStateChanged(int state)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state);
			_members_androidx_viewpager_widget_ViewPager_OnPageChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onPageScrollStateChanged.(I)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnPageScrolled_IFI(nint jnienv, nint native__this, int position, float positionOffset, int positionOffsetPixels)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnPageChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrolled(position, positionOffset, positionOffsetPixels);
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

		public unsafe void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(positionOffset);
			ptr[2] = new JniArgumentValue(positionOffsetPixels);
			_members_androidx_viewpager_widget_ViewPager_OnPageChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onPageScrolled.(IFI)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnPageSelected_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IOnPageChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageSelected(position);
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

		public unsafe void OnPageSelected(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members_androidx_viewpager_widget_ViewPager_OnPageChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onPageSelected.(I)V", this, ptr);
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
		private static void n_OnPageScrollStateChanged_I_mm_wrapper(nint jnienv, nint native__this, int state)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnPageScrollStateChanged_I(jnienv, native__this, state);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnPageScrolled_IFI_mm_wrapper(nint jnienv, nint native__this, int position, float positionOffset, int positionOffsetPixels)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnPageScrolled_IFI(jnienv, native__this, position, positionOffset, positionOffsetPixels);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnPageSelected_I_mm_wrapper(nint jnienv, nint native__this, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnPageSelected_I(jnienv, native__this, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class PageScrollStateChangedEventArgs : EventArgs
	{
		private int state;

		public PageScrollStateChangedEventArgs(int state)
		{
			this.state = state;
		}
	}

	public class PageScrolledEventArgs : EventArgs
	{
		private int position;

		private float positionOffset;

		private int positionOffsetPixels;

		public PageScrolledEventArgs(int position, float positionOffset, int positionOffsetPixels)
		{
			this.position = position;
			this.positionOffset = positionOffset;
			this.positionOffsetPixels = positionOffsetPixels;
		}
	}

	public class PageSelectedEventArgs : EventArgs
	{
		private int position;

		public PageSelectedEventArgs(int position)
		{
			this.position = position;
		}
	}

	[Register("mono/androidx/viewpager/widget/ViewPager_OnPageChangeListenerImplementor")]
	internal sealed class IOnPageChangeListenerImplementor : Java.Lang.Object, IOnPageChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<PageScrollStateChangedEventArgs>? OnPageScrollStateChangedHandler;

		public EventHandler<PageScrolledEventArgs>? OnPageScrolledHandler;

		public EventHandler<PageSelectedEventArgs>? OnPageSelectedHandler;

		public unsafe IOnPageChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnPageScrollStateChanged(int state)
		{
			OnPageScrollStateChangedHandler?.Invoke(sender, new PageScrollStateChangedEventArgs(state));
		}

		public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
		{
			OnPageScrolledHandler?.Invoke(sender, new PageScrolledEventArgs(position, positionOffset, positionOffsetPixels));
		}

		public void OnPageSelected(int position)
		{
			OnPageSelectedHandler?.Invoke(sender, new PageSelectedEventArgs(position));
		}

		internal static bool __IsEmpty(IOnPageChangeListenerImplementor value)
		{
			if (value.OnPageScrollStateChangedHandler == null && value.OnPageScrolledHandler == null)
			{
				return value.OnPageSelectedHandler == null;
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

	[Register("androidx/viewpager/widget/ViewPager$PageTransformer", "", "AndroidX.ViewPager.Widget.ViewPager/IPageTransformerInvoker")]
	public interface IPageTransformer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("transformPage", "(Landroid/view/View;F)V", "GetTransformPage_Landroid_view_View_FHandler:AndroidX.ViewPager.Widget.ViewPager/IPageTransformerInvoker, Xamarin.AndroidX.ViewPager")]
		void TransformPage(View page, float position);
	}

	[Register("androidx/viewpager/widget/ViewPager$PageTransformer", DoNotGenerateAcw = true)]
	internal class IPageTransformerInvoker : Java.Lang.Object, IPageTransformer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_viewpager_widget_ViewPager_PageTransformer = new XAPeerMembers("androidx/viewpager/widget/ViewPager$PageTransformer", typeof(IPageTransformerInvoker));

		private static Delegate? cb_transformPage_TransformPage_Landroid_view_View_F_V;

		private static nint java_class_ref => _members_androidx_viewpager_widget_ViewPager_PageTransformer.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_viewpager_widget_ViewPager_PageTransformer;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_viewpager_widget_ViewPager_PageTransformer.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_viewpager_widget_ViewPager_PageTransformer.ManagedPeerType;

		public IPageTransformerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetTransformPage_Landroid_view_View_FHandler()
		{
			return new global::_JniMarshal_PPLF_V(n_TransformPage_Landroid_view_View_F);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_TransformPage_Landroid_view_View_F(nint jnienv, nint native__this, nint native_page, float position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IPageTransformer? pageTransformer = Java.Lang.Object.GetObject<IPageTransformer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View page = Java.Lang.Object.GetObject<View>(native_page, JniHandleOwnership.DoNotTransfer);
				pageTransformer.TransformPage(page, position);
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

		public unsafe void TransformPage(View page, float position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(page?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				_members_androidx_viewpager_widget_ViewPager_PageTransformer.InstanceMethods.InvokeAbstractVoidMethod("transformPage.(Landroid/view/View;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(page);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/ViewPager", typeof(ViewPager));

	private static Delegate? cb_getAdapter_GetAdapter_Landroidx_viewpager_widget_PagerAdapter_;

	private static Delegate? cb_setAdapter_SetAdapter_Landroidx_viewpager_widget_PagerAdapter__V;

	private static Delegate? cb_getCurrentItem_GetCurrentItem_I;

	private static Delegate? cb_setCurrentItem_SetCurrentItem_I_V;

	private static Delegate? cb_isDragInGutterEnabled_IsDragInGutterEnabled_Z;

	private static Delegate? cb_setDragInGutterEnabled_SetDragInGutterEnabled_Z_V;

	private static Delegate? cb_isFakeDragging_IsFakeDragging_Z;

	private static Delegate? cb_getOffscreenPageLimit_GetOffscreenPageLimit_I;

	private static Delegate? cb_setOffscreenPageLimit_SetOffscreenPageLimit_I_V;

	private static Delegate? cb_getPageMargin_GetPageMargin_I;

	private static Delegate? cb_setPageMargin_SetPageMargin_I_V;

	private static Delegate? cb_addFocusables_AddFocusables_Ljava_util_ArrayList_II_V;

	private static Delegate? cb_addOnAdapterChangeListener_AddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener__V;

	private static Delegate? cb_addOnPageChangeListener_AddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener__V;

	private static Delegate? cb_addTouchables_AddTouchables_Ljava_util_ArrayList__V;

	private static Delegate? cb_arrowScroll_ArrowScroll_I_Z;

	private static Delegate? cb_beginFakeDrag_BeginFakeDrag_Z;

	private static Delegate? cb_canScroll_CanScroll_Landroid_view_View_ZIII_Z;

	private static Delegate? cb_clearOnPageChangeListeners_ClearOnPageChangeListeners_V;

	private static Delegate? cb_endFakeDrag_EndFakeDrag_V;

	private static Delegate? cb_executeKeyEvent_ExecuteKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_fakeDragBy_FakeDragBy_F_V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_onPageScrolled_OnPageScrolled_IFI_V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_removeOnAdapterChangeListener_RemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener__V;

	private static Delegate? cb_removeOnPageChangeListener_RemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener__V;

	private static Delegate? cb_setCurrentItem_SetCurrentItem_IZ_V;

	private static Delegate? cb_setOnPageChangeListener_SetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener__V;

	private static Delegate? cb_setPageMarginDrawable_SetPageMarginDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setPageMarginDrawable_SetPageMarginDrawable_I_V;

	private static Delegate? cb_setPageTransformer_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer__V;

	private static Delegate? cb_setPageTransformer_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I_V;

	private WeakReference? weak_implementor_AddOnAdapterChangeListener;

	private WeakReference? weak_implementor_AddOnPageChangeListener;

	[Register("mLeftEdge")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public EdgeEffect MLeftEdge
	{
		get
		{
			return Java.Lang.Object.GetObject<EdgeEffect>(_members.InstanceFields.GetObjectValue("mLeftEdge.Landroid/widget/EdgeEffect;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mLeftEdge.Landroid/widget/EdgeEffect;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mRightEdge")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public EdgeEffect MRightEdge
	{
		get
		{
			return Java.Lang.Object.GetObject<EdgeEffect>(_members.InstanceFields.GetObjectValue("mRightEdge.Landroid/widget/EdgeEffect;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mRightEdge.Landroid/widget/EdgeEffect;", this, new JniObjectReference(num));
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

	public unsafe virtual PagerAdapter? Adapter
	{
		[Register("getAdapter", "()Landroidx/viewpager/widget/PagerAdapter;", "GetGetAdapterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PagerAdapter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAdapter.()Landroidx/viewpager/widget/PagerAdapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setAdapter", "(Landroidx/viewpager/widget/PagerAdapter;)V", "GetSetAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAdapter.(Landroidx/viewpager/widget/PagerAdapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int CurrentItem
	{
		[Register("getCurrentItem", "()I", "GetGetCurrentItemHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentItem.()I", this, null);
		}
		[Register("setCurrentItem", "(I)V", "GetSetCurrentItem_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCurrentItem.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool DragInGutterEnabled
	{
		[Register("isDragInGutterEnabled", "()Z", "GetIsDragInGutterEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDragInGutterEnabled.()Z", this, null);
		}
		[Register("setDragInGutterEnabled", "(Z)V", "GetSetDragInGutterEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDragInGutterEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool IsFakeDragging
	{
		[Register("isFakeDragging", "()Z", "GetIsFakeDraggingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFakeDragging.()Z", this, null);
		}
	}

	public unsafe virtual int OffscreenPageLimit
	{
		[Register("getOffscreenPageLimit", "()I", "GetGetOffscreenPageLimitHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOffscreenPageLimit.()I", this, null);
		}
		[Register("setOffscreenPageLimit", "(I)V", "GetSetOffscreenPageLimit_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOffscreenPageLimit.(I)V", this, ptr);
		}
	}

	public unsafe virtual int PageMargin
	{
		[Register("getPageMargin", "()I", "GetGetPageMarginHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPageMargin.()I", this, null);
		}
		[Register("setPageMargin", "(I)V", "GetSetPageMargin_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPageMargin.(I)V", this, ptr);
		}
	}

	public event EventHandler<AdapterChangeEventArgs> AdapterChange
	{
		add
		{
			EventHelper.AddEventHandler<IOnAdapterChangeListener, IOnAdapterChangeListenerImplementor>(ref weak_implementor_AddOnAdapterChangeListener, __CreateIOnAdapterChangeListenerImplementor, AddOnAdapterChangeListener, delegate(IOnAdapterChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<AdapterChangeEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnAdapterChangeListener, IOnAdapterChangeListenerImplementor.__IsEmpty, delegate(IOnAdapterChangeListener __v)
			{
				RemoveOnAdapterChangeListener(__v);
			}, delegate(IOnAdapterChangeListenerImplementor __h)
			{
				__h.Handler = (EventHandler<AdapterChangeEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	public event EventHandler<PageScrollStateChangedEventArgs> PageScrollStateChanged
	{
		add
		{
			EventHelper.AddEventHandler<IOnPageChangeListener, IOnPageChangeListenerImplementor>(ref weak_implementor_AddOnPageChangeListener, __CreateIOnPageChangeListenerImplementor, AddOnPageChangeListener, delegate(IOnPageChangeListenerImplementor __h)
			{
				__h.OnPageScrollStateChangedHandler = (EventHandler<PageScrollStateChangedEventArgs>)Delegate.Combine(__h.OnPageScrollStateChangedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnPageChangeListener, IOnPageChangeListenerImplementor.__IsEmpty, delegate(IOnPageChangeListener __v)
			{
				RemoveOnPageChangeListener(__v);
			}, delegate(IOnPageChangeListenerImplementor __h)
			{
				__h.OnPageScrollStateChangedHandler = (EventHandler<PageScrollStateChangedEventArgs>)Delegate.Remove(__h.OnPageScrollStateChangedHandler, value);
			});
		}
	}

	public event EventHandler<PageScrolledEventArgs> PageScrolled
	{
		add
		{
			EventHelper.AddEventHandler<IOnPageChangeListener, IOnPageChangeListenerImplementor>(ref weak_implementor_AddOnPageChangeListener, __CreateIOnPageChangeListenerImplementor, AddOnPageChangeListener, delegate(IOnPageChangeListenerImplementor __h)
			{
				__h.OnPageScrolledHandler = (EventHandler<PageScrolledEventArgs>)Delegate.Combine(__h.OnPageScrolledHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnPageChangeListener, IOnPageChangeListenerImplementor.__IsEmpty, delegate(IOnPageChangeListener __v)
			{
				RemoveOnPageChangeListener(__v);
			}, delegate(IOnPageChangeListenerImplementor __h)
			{
				__h.OnPageScrolledHandler = (EventHandler<PageScrolledEventArgs>)Delegate.Remove(__h.OnPageScrolledHandler, value);
			});
		}
	}

	public event EventHandler<PageSelectedEventArgs> PageSelected
	{
		add
		{
			EventHelper.AddEventHandler<IOnPageChangeListener, IOnPageChangeListenerImplementor>(ref weak_implementor_AddOnPageChangeListener, __CreateIOnPageChangeListenerImplementor, AddOnPageChangeListener, delegate(IOnPageChangeListenerImplementor __h)
			{
				__h.OnPageSelectedHandler = (EventHandler<PageSelectedEventArgs>)Delegate.Combine(__h.OnPageSelectedHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnPageChangeListener, IOnPageChangeListenerImplementor.__IsEmpty, delegate(IOnPageChangeListener __v)
			{
				RemoveOnPageChangeListener(__v);
			}, delegate(IOnPageChangeListenerImplementor __h)
			{
				__h.OnPageSelectedHandler = (EventHandler<PageSelectedEventArgs>)Delegate.Remove(__h.OnPageSelectedHandler, value);
			});
		}
	}

	protected ViewPager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ViewPager(Context context)
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
	public unsafe ViewPager(Context context, IAttributeSet? attrs)
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

	private static Delegate GetGetAdapterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAdapter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAdapter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Adapter);
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

	private static Delegate GetSetAdapter_Landroidx_viewpager_widget_PagerAdapter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetAdapter_Landroidx_viewpager_widget_PagerAdapter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAdapter_Landroidx_viewpager_widget_PagerAdapter_(nint jnienv, nint native__this, nint native_adapter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PagerAdapter adapter = Java.Lang.Object.GetObject<PagerAdapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			viewPager.Adapter = adapter;
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

	private static Delegate GetGetCurrentItemHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCurrentItem);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCurrentItem(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentItem;
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

	private static Delegate GetSetCurrentItem_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCurrentItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCurrentItem_I(nint jnienv, nint native__this, int item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentItem = item;
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

	private static Delegate GetIsDragInGutterEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDragInGutterEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDragInGutterEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DragInGutterEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDragInGutterEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDragInGutterEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDragInGutterEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool dragInGutterEnabled = native_enabled != 0;
			viewPager.DragInGutterEnabled = dragInGutterEnabled;
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

	private static Delegate GetIsFakeDraggingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFakeDragging);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFakeDragging(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFakeDragging ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetOffscreenPageLimitHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOffscreenPageLimit);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOffscreenPageLimit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffscreenPageLimit;
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

	private static Delegate GetSetOffscreenPageLimit_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetOffscreenPageLimit_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOffscreenPageLimit_I(nint jnienv, nint native__this, int limit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffscreenPageLimit = limit;
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

	private static Delegate GetGetPageMarginHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetPageMargin);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPageMargin(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PageMargin;
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

	private static Delegate GetSetPageMargin_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPageMargin_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPageMargin_I(nint jnienv, nint native__this, int marginPixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PageMargin = marginPixels;
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

	private static Delegate GetAddFocusables_Ljava_util_ArrayList_IIHandler()
	{
		return new global::_JniMarshal_PPLII_V(n_AddFocusables_Ljava_util_ArrayList_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFocusables_Ljava_util_ArrayList_II(nint jnienv, nint native__this, nint native_views, int direction, int focusableMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			viewPager.AddFocusables(views, direction, focusableMode);
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

	[Register("addFocusables", "(Ljava/util/ArrayList;II)V", "GetAddFocusables_Ljava_util_ArrayList_IIHandler")]
	public unsafe virtual void AddFocusables(IList<View>? views, int direction, int focusableMode)
	{
		nint num = JavaList<View>.ToLocalJniHandle(views);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(direction);
			ptr[2] = new JniArgumentValue(focusableMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFocusables.(Ljava/util/ArrayList;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(views);
		}
	}

	private static Delegate GetAddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnAdapterChangeListener listener = Java.Lang.Object.GetObject<IOnAdapterChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.AddOnAdapterChangeListener(listener);
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

	[Register("addOnAdapterChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", "GetAddOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler")]
	public unsafe virtual void AddOnAdapterChangeListener(IOnAdapterChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnAdapterChangeListener.(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnPageChangeListener listener = Java.Lang.Object.GetObject<IOnPageChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.AddOnPageChangeListener(listener);
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

	[Register("addOnPageChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", "GetAddOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler")]
	public unsafe virtual void AddOnPageChangeListener(IOnPageChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnPageChangeListener.(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddTouchables_Ljava_util_ArrayList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddTouchables_Ljava_util_ArrayList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTouchables_Ljava_util_ArrayList_(nint jnienv, nint native__this, nint native_views)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			viewPager.AddTouchables(views);
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

	[Register("addTouchables", "(Ljava/util/ArrayList;)V", "GetAddTouchables_Ljava_util_ArrayList_Handler")]
	public new unsafe virtual void AddTouchables(IList<View>? views)
	{
		nint num = JavaList<View>.ToLocalJniHandle(views);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTouchables.(Ljava/util/ArrayList;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(views);
		}
	}

	private static Delegate GetArrowScroll_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_ArrowScroll_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ArrowScroll_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrowScroll(direction) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("arrowScroll", "(I)Z", "GetArrowScroll_IHandler")]
	public unsafe virtual bool ArrowScroll(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("arrowScroll.(I)Z", this, ptr);
	}

	private static Delegate GetBeginFakeDragHandler()
	{
		return new global::_JniMarshal_PP_B(n_BeginFakeDrag);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_BeginFakeDrag(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BeginFakeDrag() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("beginFakeDrag", "()Z", "GetBeginFakeDragHandler")]
	public unsafe virtual bool BeginFakeDrag()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("beginFakeDrag.()Z", this, null);
	}

	private static Delegate GetCanScroll_Landroid_view_View_ZIIIHandler()
	{
		return new _JniMarshal_PPLBIII_B(n_CanScroll_Landroid_view_View_ZIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanScroll_Landroid_view_View_ZIII(nint jnienv, nint native__this, nint native_v, sbyte native_checkV, int dx, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View v = Java.Lang.Object.GetObject<View>(native_v, JniHandleOwnership.DoNotTransfer);
			bool checkV = native_checkV != 0;
			return viewPager.CanScroll(v, checkV, dx, x, y) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canScroll", "(Landroid/view/View;ZIII)Z", "GetCanScroll_Landroid_view_View_ZIIIHandler")]
	protected unsafe virtual bool CanScroll(View v, bool checkV, int dx, int x, int y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(checkV ? ((sbyte)1) : ((sbyte)0));
			ptr[2] = new JniArgumentValue(dx);
			ptr[3] = new JniArgumentValue(x);
			ptr[4] = new JniArgumentValue(y);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canScroll.(Landroid/view/View;ZIII)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	private static Delegate GetClearOnPageChangeListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnPageChangeListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnPageChangeListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnPageChangeListeners();
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

	[Register("clearOnPageChangeListeners", "()V", "GetClearOnPageChangeListenersHandler")]
	public unsafe virtual void ClearOnPageChangeListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnPageChangeListeners.()V", this, null);
	}

	private static Delegate GetEndFakeDragHandler()
	{
		return new global::_JniMarshal_PP_V(n_EndFakeDrag);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EndFakeDrag(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndFakeDrag();
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

	[Register("endFakeDrag", "()V", "GetEndFakeDragHandler")]
	public unsafe virtual void EndFakeDrag()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("endFakeDrag.()V", this, null);
	}

	private static Delegate GetExecuteKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ExecuteKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ExecuteKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return viewPager.ExecuteKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("executeKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetExecuteKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe virtual bool ExecuteKeyEvent(KeyEvent e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("executeKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetFakeDragBy_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_FakeDragBy_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FakeDragBy_F(nint jnienv, nint native__this, float xOffset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FakeDragBy(xOffset);
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

	[Register("fakeDragBy", "(F)V", "GetFakeDragBy_FHandler")]
	public unsafe virtual void FakeDragBy(float xOffset)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(xOffset);
		_members.InstanceMethods.InvokeVirtualVoidMethod("fakeDragBy.(F)V", this, ptr);
	}

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new global::_JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int l, int t, int r, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			viewPager.OnLayout(changed, l, t, r, b);
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

	[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
	protected unsafe override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(l);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	private static Delegate GetOnPageScrolled_IFIHandler()
	{
		return new _JniMarshal_PPIFI_V(n_OnPageScrolled_IFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPageScrolled_IFI(nint jnienv, nint native__this, int position, float offset, int offsetPixels)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrolled(position, offset, offsetPixels);
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

	[Register("onPageScrolled", "(IFI)V", "GetOnPageScrolled_IFIHandler")]
	protected unsafe virtual void OnPageScrolled(int position, float offset, int offsetPixels)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(offset);
		ptr[2] = new JniArgumentValue(offsetPixels);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onPageScrolled.(IFI)V", this, ptr);
	}

	private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnRestoreInstanceState_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			viewPager.OnRestoreInstanceState(state);
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

	[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
	public new unsafe virtual void OnRestoreInstanceState(IParcelable? state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetOnSaveInstanceStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnSaveInstanceState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSaveInstanceState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
	public new unsafe virtual IParcelable OnSaveInstanceState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnAdapterChangeListener listener = Java.Lang.Object.GetObject<IOnAdapterChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.RemoveOnAdapterChangeListener(listener);
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

	[Register("removeOnAdapterChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", "GetRemoveOnAdapterChangeListener_Landroidx_viewpager_widget_ViewPager_OnAdapterChangeListener_Handler")]
	public unsafe virtual void RemoveOnAdapterChangeListener(IOnAdapterChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnAdapterChangeListener.(Landroidx/viewpager/widget/ViewPager$OnAdapterChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnPageChangeListener listener = Java.Lang.Object.GetObject<IOnPageChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.RemoveOnPageChangeListener(listener);
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

	[Register("removeOnPageChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", "GetRemoveOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler")]
	public unsafe virtual void RemoveOnPageChangeListener(IOnPageChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnPageChangeListener.(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetCurrentItem_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_SetCurrentItem_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCurrentItem_IZ(nint jnienv, nint native__this, int item, sbyte native_smoothScroll)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool smoothScroll = native_smoothScroll != 0;
			viewPager.SetCurrentItem(item, smoothScroll);
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

	[Register("setCurrentItem", "(IZ)V", "GetSetCurrentItem_IZHandler")]
	public unsafe virtual void SetCurrentItem(int item, bool smoothScroll)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(item);
		ptr[1] = new JniArgumentValue(smoothScroll ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCurrentItem.(IZ)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnPageChangeListener onPageChangeListener = Java.Lang.Object.GetObject<IOnPageChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			viewPager.SetOnPageChangeListener(onPageChangeListener);
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
	[Register("setOnPageChangeListener", "(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", "GetSetOnPageChangeListener_Landroidx_viewpager_widget_ViewPager_OnPageChangeListener_Handler")]
	public unsafe virtual void SetOnPageChangeListener(IOnPageChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnPageChangeListener.(Landroidx/viewpager/widget/ViewPager$OnPageChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetPageMarginDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPageMarginDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPageMarginDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_d)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable pageMarginDrawable = Java.Lang.Object.GetObject<Drawable>(native_d, JniHandleOwnership.DoNotTransfer);
			viewPager.SetPageMarginDrawable(pageMarginDrawable);
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

	[Register("setPageMarginDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetPageMarginDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetPageMarginDrawable(Drawable? d)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPageMarginDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(d);
		}
	}

	private static Delegate GetSetPageMarginDrawable_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPageMarginDrawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPageMarginDrawable_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPageMarginDrawable(resId);
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

	[Register("setPageMarginDrawable", "(I)V", "GetSetPageMarginDrawable_IHandler")]
	public unsafe virtual void SetPageMarginDrawable(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPageMarginDrawable.(I)V", this, ptr);
	}

	private static Delegate GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_Handler()
	{
		return new global::_JniMarshal_PPBL_V(n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_(nint jnienv, nint native__this, sbyte native_reverseDrawingOrder, nint native_transformer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool reverseDrawingOrder = native_reverseDrawingOrder != 0;
			IPageTransformer transformer = Java.Lang.Object.GetObject<IPageTransformer>(native_transformer, JniHandleOwnership.DoNotTransfer);
			viewPager.SetPageTransformer(reverseDrawingOrder, transformer);
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

	[Register("setPageTransformer", "(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;)V", "GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_Handler")]
	public unsafe virtual void SetPageTransformer(bool reverseDrawingOrder, IPageTransformer? transformer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(reverseDrawingOrder ? ((sbyte)1) : ((sbyte)0));
			ptr[1] = new JniArgumentValue((transformer == null) ? IntPtr.Zero : ((Java.Lang.Object)transformer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPageTransformer.(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transformer);
		}
	}

	private static Delegate GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_IHandler()
	{
		return new _JniMarshal_PPBLI_V(n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_I(nint jnienv, nint native__this, sbyte native_reverseDrawingOrder, nint native_transformer, int pageLayerType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ViewPager? viewPager = Java.Lang.Object.GetObject<ViewPager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool reverseDrawingOrder = native_reverseDrawingOrder != 0;
			IPageTransformer transformer = Java.Lang.Object.GetObject<IPageTransformer>(native_transformer, JniHandleOwnership.DoNotTransfer);
			viewPager.SetPageTransformer(reverseDrawingOrder, transformer, pageLayerType);
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

	[Register("setPageTransformer", "(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;I)V", "GetSetPageTransformer_ZLandroidx_viewpager_widget_ViewPager_PageTransformer_IHandler")]
	public unsafe virtual void SetPageTransformer(bool reverseDrawingOrder, IPageTransformer? transformer, int pageLayerType)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(reverseDrawingOrder ? ((sbyte)1) : ((sbyte)0));
			ptr[1] = new JniArgumentValue((transformer == null) ? IntPtr.Zero : ((Java.Lang.Object)transformer).Handle);
			ptr[2] = new JniArgumentValue(pageLayerType);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPageTransformer.(ZLandroidx/viewpager/widget/ViewPager$PageTransformer;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transformer);
		}
	}

	private IOnAdapterChangeListenerImplementor __CreateIOnAdapterChangeListenerImplementor()
	{
		return new IOnAdapterChangeListenerImplementor(this);
	}

	private IOnPageChangeListenerImplementor __CreateIOnPageChangeListenerImplementor()
	{
		return new IOnPageChangeListenerImplementor(this);
	}
}

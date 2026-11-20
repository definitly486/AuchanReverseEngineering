using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ViewPager2.Widget;

[Register("androidx/viewpager2/widget/ViewPager2", DoNotGenerateAcw = true)]
public sealed class ViewPager2 : ViewGroup
{
	[Register("androidx/viewpager2/widget/ViewPager2$OnPageChangeCallback", DoNotGenerateAcw = true)]
	public abstract class OnPageChangeCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager2/widget/ViewPager2$OnPageChangeCallback", typeof(OnPageChangeCallback));

		private static Delegate? cb_onPageScrollStateChanged_OnPageScrollStateChanged_I_V;

		private static Delegate? cb_onPageScrolled_OnPageScrolled_IFI_V;

		private static Delegate? cb_onPageSelected_OnPageSelected_I_V;

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

		protected OnPageChangeCallback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnPageChangeCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
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
				Java.Lang.Object.GetObject<OnPageChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrollStateChanged(state);
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

		[Register("onPageScrollStateChanged", "(I)V", "GetOnPageScrollStateChanged_IHandler")]
		public unsafe virtual void OnPageScrollStateChanged(int state)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPageScrollStateChanged.(I)V", this, ptr);
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
				Java.Lang.Object.GetObject<OnPageChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageScrolled(position, positionOffset, positionOffsetPixels);
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
		public unsafe virtual void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(positionOffset);
			ptr[2] = new JniArgumentValue(positionOffsetPixels);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPageScrolled.(IFI)V", this, ptr);
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
				Java.Lang.Object.GetObject<OnPageChangeCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPageSelected(position);
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

		[Register("onPageSelected", "(I)V", "GetOnPageSelected_IHandler")]
		public unsafe virtual void OnPageSelected(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPageSelected.(I)V", this, ptr);
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
	}

	[Register("androidx/viewpager2/widget/ViewPager2$OnPageChangeCallback", DoNotGenerateAcw = true)]
	internal class OnPageChangeCallbackInvoker : OnPageChangeCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager2/widget/ViewPager2$OnPageChangeCallback", typeof(OnPageChangeCallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnPageChangeCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/viewpager2/widget/ViewPager2$PageTransformer", "", "AndroidX.ViewPager2.Widget.ViewPager2/IPageTransformerInvoker")]
	public interface IPageTransformer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("transformPage", "(Landroid/view/View;F)V", "GetTransformPage_Landroid_view_View_FHandler:AndroidX.ViewPager2.Widget.ViewPager2/IPageTransformerInvoker, Xamarin.AndroidX.ViewPager2")]
		void TransformPage(View p0, float p1);
	}

	[Register("androidx/viewpager2/widget/ViewPager2$PageTransformer", DoNotGenerateAcw = true)]
	internal class IPageTransformerInvoker : Java.Lang.Object, IPageTransformer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_viewpager2_widget_ViewPager2_PageTransformer = new XAPeerMembers("androidx/viewpager2/widget/ViewPager2$PageTransformer", typeof(IPageTransformerInvoker));

		private static Delegate? cb_transformPage_TransformPage_Landroid_view_View_F_V;

		private static nint java_class_ref => _members_androidx_viewpager2_widget_ViewPager2_PageTransformer.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_viewpager2_widget_ViewPager2_PageTransformer;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_viewpager2_widget_ViewPager2_PageTransformer.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_viewpager2_widget_ViewPager2_PageTransformer.ManagedPeerType;

		public IPageTransformerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetTransformPage_Landroid_view_View_FHandler()
		{
			return new global::_JniMarshal_PPLF_V(n_TransformPage_Landroid_view_View_F);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_TransformPage_Landroid_view_View_F(nint jnienv, nint native__this, nint native_p0, float p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IPageTransformer? pageTransformer = Java.Lang.Object.GetObject<IPageTransformer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View p2 = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
				pageTransformer.TransformPage(p2, p1);
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

		public unsafe void TransformPage(View p0, float p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				_members_androidx_viewpager2_widget_ViewPager2_PageTransformer.InstanceMethods.InvokeAbstractVoidMethod("transformPage.(Landroid/view/View;F)V", this, ptr);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager2/widget/ViewPager2", typeof(ViewPager2));

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

	public unsafe AndroidX.RecyclerView.Widget.RecyclerView.Adapter? Adapter
	{
		[Register("getAdapter", "()Landroidx/recyclerview/widget/RecyclerView$Adapter;", "")]
		get
		{
			return Java.Lang.Object.GetObject<AndroidX.RecyclerView.Widget.RecyclerView.Adapter>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAdapter.()Landroidx/recyclerview/widget/RecyclerView$Adapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setAdapter", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setAdapter.(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe int CurrentItem
	{
		[Register("getCurrentItem", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getCurrentItem.()I", this, null);
		}
		[Register("setCurrentItem", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setCurrentItem.(I)V", this, ptr);
		}
	}

	public unsafe bool IsFakeDragging
	{
		[Register("isFakeDragging", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isFakeDragging.()Z", this, null);
		}
	}

	public unsafe int ItemDecorationCount
	{
		[Register("getItemDecorationCount", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getItemDecorationCount.()I", this, null);
		}
	}

	public unsafe int OffscreenPageLimit
	{
		[Register("getOffscreenPageLimit", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getOffscreenPageLimit.()I", this, null);
		}
		[Register("setOffscreenPageLimit", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setOffscreenPageLimit.(I)V", this, ptr);
		}
	}

	public unsafe int Orientation
	{
		[Register("getOrientation", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getOrientation.()I", this, null);
		}
		[Register("setOrientation", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setOrientation.(I)V", this, ptr);
		}
	}

	public unsafe int ScrollState
	{
		[Register("getScrollState", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getScrollState.()I", this, null);
		}
	}

	public unsafe bool UserInputEnabled
	{
		[Register("isUserInputEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isUserInputEnabled.()Z", this, null);
		}
		[Register("setUserInputEnabled", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setUserInputEnabled.(Z)V", this, ptr);
		}
	}

	internal ViewPager2(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ViewPager2(Context context)
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
	public unsafe ViewPager2(Context context, IAttributeSet? attrs)
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
	public unsafe ViewPager2(Context context, IAttributeSet? attrs, int defStyleAttr)
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
	public unsafe ViewPager2(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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

	[Register("addItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", "")]
	public unsafe void AddItemDecoration(AndroidX.RecyclerView.Widget.RecyclerView.ItemDecoration decor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	[Register("addItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;I)V", "")]
	public unsafe void AddItemDecoration(AndroidX.RecyclerView.Widget.RecyclerView.ItemDecoration decor, int index)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	[Register("beginFakeDrag", "()Z", "")]
	public unsafe bool BeginFakeDrag()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("beginFakeDrag.()Z", this, null);
	}

	[Register("dispatchRestoreInstanceState", "(Landroid/util/SparseArray;)V", "")]
	protected unsafe override void DispatchRestoreInstanceState(SparseArray? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("dispatchRestoreInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	[Register("endFakeDrag", "()Z", "")]
	public unsafe bool EndFakeDrag()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("endFakeDrag.()Z", this, null);
	}

	[Register("fakeDragBy", "(F)Z", "")]
	public unsafe bool FakeDragBy(float offsetPxFloat)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(offsetPxFloat);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("fakeDragBy.(F)Z", this, ptr);
	}

	[Register("getItemDecorationAt", "(I)Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;", "")]
	public unsafe AndroidX.RecyclerView.Widget.RecyclerView.ItemDecoration GetItemDecorationAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<AndroidX.RecyclerView.Widget.RecyclerView.ItemDecoration>(_members.InstanceMethods.InvokeAbstractObjectMethod("getItemDecorationAt.(I)Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("invalidateItemDecorations", "()V", "")]
	public unsafe void InvalidateItemDecorations()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("invalidateItemDecorations.()V", this, null);
	}

	[Register("onLayout", "(ZIIII)V", "")]
	protected unsafe override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(l);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeAbstractVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	[Register("registerOnPageChangeCallback", "(Landroidx/viewpager2/widget/ViewPager2$OnPageChangeCallback;)V", "")]
	public unsafe void RegisterOnPageChangeCallback(OnPageChangeCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("registerOnPageChangeCallback.(Landroidx/viewpager2/widget/ViewPager2$OnPageChangeCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[Register("removeItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", "")]
	public unsafe void RemoveItemDecoration(AndroidX.RecyclerView.Widget.RecyclerView.ItemDecoration decor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	[Register("removeItemDecorationAt", "(I)V", "")]
	public unsafe void RemoveItemDecorationAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeAbstractVoidMethod("removeItemDecorationAt.(I)V", this, ptr);
	}

	[Register("requestTransform", "()V", "")]
	public unsafe void RequestTransform()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("requestTransform.()V", this, null);
	}

	[Register("setCurrentItem", "(IZ)V", "")]
	public unsafe void SetCurrentItem(int item, bool smoothScroll)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(item);
		ptr[1] = new JniArgumentValue(smoothScroll ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeAbstractVoidMethod("setCurrentItem.(IZ)V", this, ptr);
	}

	[Register("setPageTransformer", "(Landroidx/viewpager2/widget/ViewPager2$PageTransformer;)V", "")]
	public unsafe void SetPageTransformer(IPageTransformer? transformer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((transformer == null) ? IntPtr.Zero : ((Java.Lang.Object)transformer).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setPageTransformer.(Landroidx/viewpager2/widget/ViewPager2$PageTransformer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transformer);
		}
	}

	[Register("unregisterOnPageChangeCallback", "(Landroidx/viewpager2/widget/ViewPager2$OnPageChangeCallback;)V", "")]
	public unsafe void UnregisterOnPageChangeCallback(OnPageChangeCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("unregisterOnPageChangeCallback.(Landroidx/viewpager2/widget/ViewPager2$OnPageChangeCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}
}

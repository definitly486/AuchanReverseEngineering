using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace Com.Zerobranch.Layout;

[Register("com/zerobranch/layout/SwipeLayout", DoNotGenerateAcw = true)]
public class SwipeLayout : FrameLayout
{
	[Register("com/zerobranch/layout/SwipeLayout$SwipeActionsListener", "", "Com.Zerobranch.Layout.SwipeLayout/ISwipeActionsListenerInvoker")]
	public interface ISwipeActionsListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onClose", "()V", "GetOnCloseHandler:Com.Zerobranch.Layout.SwipeLayout/ISwipeActionsListenerInvoker, ZeroBranch.SwipeLayout")]
		void OnClose();

		[Register("onOpen", "(IZ)V", "GetOnOpen_IZHandler:Com.Zerobranch.Layout.SwipeLayout/ISwipeActionsListenerInvoker, ZeroBranch.SwipeLayout")]
		void OnOpen(int p0, bool p1);
	}

	[Register("com/zerobranch/layout/SwipeLayout$SwipeActionsListener", DoNotGenerateAcw = true)]
	internal class ISwipeActionsListenerInvoker : Java.Lang.Object, ISwipeActionsListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/zerobranch/layout/SwipeLayout$SwipeActionsListener", typeof(ISwipeActionsListenerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onClose;

		private IntPtr id_onClose;

		private static Delegate cb_onOpen_IZ;

		private IntPtr id_onOpen_IZ;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISwipeActionsListener GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISwipeActionsListener>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.zerobranch.layout.SwipeLayout.SwipeActionsListener"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public ISwipeActionsListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnCloseHandler()
		{
			if ((object)cb_onClose == null)
			{
				cb_onClose = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnClose));
			}
			return cb_onClose;
		}

		private static void n_OnClose(IntPtr jnienv, IntPtr native__this)
		{
			ISwipeActionsListener swipeActionsListener = Java.Lang.Object.GetObject<ISwipeActionsListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			swipeActionsListener.OnClose();
		}

		public void OnClose()
		{
			if (id_onClose == IntPtr.Zero)
			{
				id_onClose = JNIEnv.GetMethodID(class_ref, "onClose", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onClose);
		}

		private static Delegate GetOnOpen_IZHandler()
		{
			if ((object)cb_onOpen_IZ == null)
			{
				cb_onOpen_IZ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, bool>(n_OnOpen_IZ));
			}
			return cb_onOpen_IZ;
		}

		private static void n_OnOpen_IZ(IntPtr jnienv, IntPtr native__this, int p0, bool p1)
		{
			ISwipeActionsListener swipeActionsListener = Java.Lang.Object.GetObject<ISwipeActionsListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			swipeActionsListener.OnOpen(p0, p1);
		}

		public unsafe void OnOpen(int p0, bool p1)
		{
			if (id_onOpen_IZ == IntPtr.Zero)
			{
				id_onOpen_IZ = JNIEnv.GetMethodID(class_ref, "onOpen", "(IZ)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_onOpen_IZ, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/zerobranch/layout/SwipeLayout", typeof(SwipeLayout));

	private static Delegate cb_getCurrentDirection;

	private static Delegate cb_isEnabledSwipe;

	private static Delegate cb_setEnabledSwipe_Z;

	private static Delegate cb_isClosed;

	private static Delegate cb_isContinuousSwipe;

	private static Delegate cb_isFreeDragAfterOpen;

	private static Delegate cb_isFreeHorizontalDrag;

	private static Delegate cb_isLeftOpen;

	private static Delegate cb_isMoving;

	private static Delegate cb_isRightOpen;

	private static Delegate cb_isTogether;

	private static Delegate cb_getLeftDragViewPadding;

	private static Delegate cb_getRightDragViewPadding;

	private static Delegate cb_close;

	private static Delegate cb_close_Z;

	private static Delegate cb_enableTouchForViewGroup_Landroid_view_ViewGroup_;

	private static Delegate cb_openLeft;

	private static Delegate cb_openLeft_Z;

	private static Delegate cb_openLeftCompletely;

	private static Delegate cb_openLeftCompletely_Z;

	private static Delegate cb_openRight;

	private static Delegate cb_openRight_Z;

	private static Delegate cb_openRightCompletely;

	private static Delegate cb_openRightCompletely_Z;

	private static Delegate cb_setContinuousSwipe_Z;

	private static Delegate cb_setCurrentDirection_I;

	private static Delegate cb_setFreeDragAfterOpen_Z;

	private static Delegate cb_setFreeHorizontalDrag_Z;

	private static Delegate cb_setLeftDragViewPadding_I;

	private static Delegate cb_setOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_;

	private static Delegate cb_setRightDragViewPadding_I;

	private static Delegate cb_setTogether_Z;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int CurrentDirection
	{
		[Register("getCurrentDirection", "()I", "GetGetCurrentDirectionHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentDirection.()I", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool EnabledSwipe
	{
		[Register("isEnabledSwipe", "()Z", "GetIsEnabledSwipeHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEnabledSwipe.()Z", this, null);
			}
			finally
			{
			}
		}
		[Register("setEnabledSwipe", "(Z)V", "GetSetEnabledSwipe_ZHandler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEnabledSwipe.(Z)V", this, ptr);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsClosed
	{
		[Register("isClosed", "()Z", "GetIsClosedHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isClosed.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsContinuousSwipe
	{
		[Register("isContinuousSwipe", "()Z", "GetIsContinuousSwipeHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isContinuousSwipe.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsFreeDragAfterOpen
	{
		[Register("isFreeDragAfterOpen", "()Z", "GetIsFreeDragAfterOpenHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFreeDragAfterOpen.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsFreeHorizontalDrag
	{
		[Register("isFreeHorizontalDrag", "()Z", "GetIsFreeHorizontalDragHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFreeHorizontalDrag.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsLeftOpen
	{
		[Register("isLeftOpen", "()Z", "GetIsLeftOpenHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLeftOpen.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsMoving
	{
		[Register("isMoving", "()Z", "GetIsMovingHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMoving.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsRightOpen
	{
		[Register("isRightOpen", "()Z", "GetIsRightOpenHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRightOpen.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual bool IsTogether
	{
		[Register("isTogether", "()Z", "GetIsTogetherHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTogether.()Z", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual int LeftDragViewPadding
	{
		[Register("getLeftDragViewPadding", "()I", "GetGetLeftDragViewPaddingHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLeftDragViewPadding.()I", this, null);
			}
			finally
			{
			}
		}
	}

	public unsafe virtual int RightDragViewPadding
	{
		[Register("getRightDragViewPadding", "()I", "GetGetRightDragViewPaddingHandler")]
		get
		{
			try
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRightDragViewPadding.()I", this, null);
			}
			finally
			{
			}
		}
	}

	protected SwipeLayout(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe SwipeLayout(Context context, IAttributeSet attrs)
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

	private static Delegate GetGetCurrentDirectionHandler()
	{
		if ((object)cb_getCurrentDirection == null)
		{
			cb_getCurrentDirection = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetCurrentDirection));
		}
		return cb_getCurrentDirection;
	}

	private static int n_GetCurrentDirection(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.CurrentDirection;
	}

	private static Delegate GetIsEnabledSwipeHandler()
	{
		if ((object)cb_isEnabledSwipe == null)
		{
			cb_isEnabledSwipe = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsEnabledSwipe));
		}
		return cb_isEnabledSwipe;
	}

	private static bool n_IsEnabledSwipe(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.EnabledSwipe;
	}

	private static Delegate GetSetEnabledSwipe_ZHandler()
	{
		if ((object)cb_setEnabledSwipe_Z == null)
		{
			cb_setEnabledSwipe_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetEnabledSwipe_Z));
		}
		return cb_setEnabledSwipe_Z;
	}

	private static void n_SetEnabledSwipe_Z(IntPtr jnienv, IntPtr native__this, bool enabledSwipe)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.EnabledSwipe = enabledSwipe;
	}

	private static Delegate GetIsClosedHandler()
	{
		if ((object)cb_isClosed == null)
		{
			cb_isClosed = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsClosed));
		}
		return cb_isClosed;
	}

	private static bool n_IsClosed(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsClosed;
	}

	private static Delegate GetIsContinuousSwipeHandler()
	{
		if ((object)cb_isContinuousSwipe == null)
		{
			cb_isContinuousSwipe = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsContinuousSwipe));
		}
		return cb_isContinuousSwipe;
	}

	private static bool n_IsContinuousSwipe(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsContinuousSwipe;
	}

	private static Delegate GetIsFreeDragAfterOpenHandler()
	{
		if ((object)cb_isFreeDragAfterOpen == null)
		{
			cb_isFreeDragAfterOpen = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsFreeDragAfterOpen));
		}
		return cb_isFreeDragAfterOpen;
	}

	private static bool n_IsFreeDragAfterOpen(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsFreeDragAfterOpen;
	}

	private static Delegate GetIsFreeHorizontalDragHandler()
	{
		if ((object)cb_isFreeHorizontalDrag == null)
		{
			cb_isFreeHorizontalDrag = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsFreeHorizontalDrag));
		}
		return cb_isFreeHorizontalDrag;
	}

	private static bool n_IsFreeHorizontalDrag(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsFreeHorizontalDrag;
	}

	private static Delegate GetIsLeftOpenHandler()
	{
		if ((object)cb_isLeftOpen == null)
		{
			cb_isLeftOpen = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsLeftOpen));
		}
		return cb_isLeftOpen;
	}

	private static bool n_IsLeftOpen(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsLeftOpen;
	}

	private static Delegate GetIsMovingHandler()
	{
		if ((object)cb_isMoving == null)
		{
			cb_isMoving = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsMoving));
		}
		return cb_isMoving;
	}

	private static bool n_IsMoving(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsMoving;
	}

	private static Delegate GetIsRightOpenHandler()
	{
		if ((object)cb_isRightOpen == null)
		{
			cb_isRightOpen = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsRightOpen));
		}
		return cb_isRightOpen;
	}

	private static bool n_IsRightOpen(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsRightOpen;
	}

	private static Delegate GetIsTogetherHandler()
	{
		if ((object)cb_isTogether == null)
		{
			cb_isTogether = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsTogether));
		}
		return cb_isTogether;
	}

	private static bool n_IsTogether(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.IsTogether;
	}

	private static Delegate GetGetLeftDragViewPaddingHandler()
	{
		if ((object)cb_getLeftDragViewPadding == null)
		{
			cb_getLeftDragViewPadding = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetLeftDragViewPadding));
		}
		return cb_getLeftDragViewPadding;
	}

	private static int n_GetLeftDragViewPadding(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.LeftDragViewPadding;
	}

	private static Delegate GetGetRightDragViewPaddingHandler()
	{
		if ((object)cb_getRightDragViewPadding == null)
		{
			cb_getRightDragViewPadding = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetRightDragViewPadding));
		}
		return cb_getRightDragViewPadding;
	}

	private static int n_GetRightDragViewPadding(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return swipeLayout.RightDragViewPadding;
	}

	private static Delegate GetCloseHandler()
	{
		if ((object)cb_close == null)
		{
			cb_close = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Close));
		}
		return cb_close;
	}

	private static void n_Close(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.Close();
	}

	[Register("close", "()V", "GetCloseHandler")]
	public unsafe virtual void Close()
	{
		try
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}
		finally
		{
		}
	}

	private static Delegate GetClose_ZHandler()
	{
		if ((object)cb_close_Z == null)
		{
			cb_close_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_Close_Z));
		}
		return cb_close_Z;
	}

	private static void n_Close_Z(IntPtr jnienv, IntPtr native__this, bool animated)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.Close(animated);
	}

	[Register("close", "(Z)V", "GetClose_ZHandler")]
	public unsafe virtual void Close(bool animated)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animated);
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.(Z)V", this, ptr);
		}
		finally
		{
		}
	}

	private static Delegate GetEnableTouchForViewGroup_Landroid_view_ViewGroup_Handler()
	{
		if ((object)cb_enableTouchForViewGroup_Landroid_view_ViewGroup_ == null)
		{
			cb_enableTouchForViewGroup_Landroid_view_ViewGroup_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_EnableTouchForViewGroup_Landroid_view_ViewGroup_));
		}
		return cb_enableTouchForViewGroup_Landroid_view_ViewGroup_;
	}

	private static void n_EnableTouchForViewGroup_Landroid_view_ViewGroup_(IntPtr jnienv, IntPtr native__this, IntPtr native_viewGroup)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewGroup viewGroup = Java.Lang.Object.GetObject<ViewGroup>(native_viewGroup, JniHandleOwnership.DoNotTransfer);
		swipeLayout.EnableTouchForViewGroup(viewGroup);
	}

	[Register("enableTouchForViewGroup", "(Landroid/view/ViewGroup;)V", "GetEnableTouchForViewGroup_Landroid_view_ViewGroup_Handler")]
	public unsafe virtual void EnableTouchForViewGroup(ViewGroup viewGroup)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewGroup?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("enableTouchForViewGroup.(Landroid/view/ViewGroup;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(viewGroup);
		}
	}

	private static Delegate GetOpenLeftHandler()
	{
		if ((object)cb_openLeft == null)
		{
			cb_openLeft = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OpenLeft));
		}
		return cb_openLeft;
	}

	private static void n_OpenLeft(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenLeft();
	}

	[Register("openLeft", "()V", "GetOpenLeftHandler")]
	public unsafe virtual void OpenLeft()
	{
		try
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("openLeft.()V", this, null);
		}
		finally
		{
		}
	}

	private static Delegate GetOpenLeft_ZHandler()
	{
		if ((object)cb_openLeft_Z == null)
		{
			cb_openLeft_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_OpenLeft_Z));
		}
		return cb_openLeft_Z;
	}

	private static void n_OpenLeft_Z(IntPtr jnienv, IntPtr native__this, bool animated)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenLeft(animated);
	}

	[Register("openLeft", "(Z)V", "GetOpenLeft_ZHandler")]
	public unsafe virtual void OpenLeft(bool animated)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animated);
			_members.InstanceMethods.InvokeVirtualVoidMethod("openLeft.(Z)V", this, ptr);
		}
		finally
		{
		}
	}

	private static Delegate GetOpenLeftCompletelyHandler()
	{
		if ((object)cb_openLeftCompletely == null)
		{
			cb_openLeftCompletely = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OpenLeftCompletely));
		}
		return cb_openLeftCompletely;
	}

	private static void n_OpenLeftCompletely(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenLeftCompletely();
	}

	[Register("openLeftCompletely", "()V", "GetOpenLeftCompletelyHandler")]
	public unsafe virtual void OpenLeftCompletely()
	{
		try
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("openLeftCompletely.()V", this, null);
		}
		finally
		{
		}
	}

	private static Delegate GetOpenLeftCompletely_ZHandler()
	{
		if ((object)cb_openLeftCompletely_Z == null)
		{
			cb_openLeftCompletely_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_OpenLeftCompletely_Z));
		}
		return cb_openLeftCompletely_Z;
	}

	private static void n_OpenLeftCompletely_Z(IntPtr jnienv, IntPtr native__this, bool animated)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenLeftCompletely(animated);
	}

	[Register("openLeftCompletely", "(Z)V", "GetOpenLeftCompletely_ZHandler")]
	public unsafe virtual void OpenLeftCompletely(bool animated)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animated);
			_members.InstanceMethods.InvokeVirtualVoidMethod("openLeftCompletely.(Z)V", this, ptr);
		}
		finally
		{
		}
	}

	private static Delegate GetOpenRightHandler()
	{
		if ((object)cb_openRight == null)
		{
			cb_openRight = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OpenRight));
		}
		return cb_openRight;
	}

	private static void n_OpenRight(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenRight();
	}

	[Register("openRight", "()V", "GetOpenRightHandler")]
	public unsafe virtual void OpenRight()
	{
		try
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("openRight.()V", this, null);
		}
		finally
		{
		}
	}

	private static Delegate GetOpenRight_ZHandler()
	{
		if ((object)cb_openRight_Z == null)
		{
			cb_openRight_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_OpenRight_Z));
		}
		return cb_openRight_Z;
	}

	private static void n_OpenRight_Z(IntPtr jnienv, IntPtr native__this, bool animated)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenRight(animated);
	}

	[Register("openRight", "(Z)V", "GetOpenRight_ZHandler")]
	public unsafe virtual void OpenRight(bool animated)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animated);
			_members.InstanceMethods.InvokeVirtualVoidMethod("openRight.(Z)V", this, ptr);
		}
		finally
		{
		}
	}

	private static Delegate GetOpenRightCompletelyHandler()
	{
		if ((object)cb_openRightCompletely == null)
		{
			cb_openRightCompletely = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OpenRightCompletely));
		}
		return cb_openRightCompletely;
	}

	private static void n_OpenRightCompletely(IntPtr jnienv, IntPtr native__this)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenRightCompletely();
	}

	[Register("openRightCompletely", "()V", "GetOpenRightCompletelyHandler")]
	public unsafe virtual void OpenRightCompletely()
	{
		try
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("openRightCompletely.()V", this, null);
		}
		finally
		{
		}
	}

	private static Delegate GetOpenRightCompletely_ZHandler()
	{
		if ((object)cb_openRightCompletely_Z == null)
		{
			cb_openRightCompletely_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_OpenRightCompletely_Z));
		}
		return cb_openRightCompletely_Z;
	}

	private static void n_OpenRightCompletely_Z(IntPtr jnienv, IntPtr native__this, bool animated)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		swipeLayout.OpenRightCompletely(animated);
	}

	[Register("openRightCompletely", "(Z)V", "GetOpenRightCompletely_ZHandler")]
	public unsafe virtual void OpenRightCompletely(bool animated)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animated);
			_members.InstanceMethods.InvokeVirtualVoidMethod("openRightCompletely.(Z)V", this, ptr);
		}
		finally
		{
		}
	}

	private static Delegate GetSetContinuousSwipe_ZHandler()
	{
		if ((object)cb_setContinuousSwipe_Z == null)
		{
			cb_setContinuousSwipe_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, IntPtr>(n_SetContinuousSwipe_Z));
		}
		return cb_setContinuousSwipe_Z;
	}

	private static IntPtr n_SetContinuousSwipe_Z(IntPtr jnienv, IntPtr native__this, bool continuousSwipe)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetContinuousSwipe(continuousSwipe));
	}

	[Register("setContinuousSwipe", "(Z)Lcom/zerobranch/layout/SwipeLayout;", "GetSetContinuousSwipe_ZHandler")]
	public unsafe virtual SwipeLayout SetContinuousSwipe(bool continuousSwipe)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(continuousSwipe);
			return Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setContinuousSwipe.(Z)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
	}

	private static Delegate GetSetCurrentDirection_IHandler()
	{
		if ((object)cb_setCurrentDirection_I == null)
		{
			cb_setCurrentDirection_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetCurrentDirection_I));
		}
		return cb_setCurrentDirection_I;
	}

	private static IntPtr n_SetCurrentDirection_I(IntPtr jnienv, IntPtr native__this, int currentDirection)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetCurrentDirection(currentDirection));
	}

	[Register("setCurrentDirection", "(I)Lcom/zerobranch/layout/SwipeLayout;", "GetSetCurrentDirection_IHandler")]
	public unsafe virtual SwipeLayout SetCurrentDirection(int currentDirection)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(currentDirection);
			return Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setCurrentDirection.(I)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
	}

	private static Delegate GetSetFreeDragAfterOpen_ZHandler()
	{
		if ((object)cb_setFreeDragAfterOpen_Z == null)
		{
			cb_setFreeDragAfterOpen_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, IntPtr>(n_SetFreeDragAfterOpen_Z));
		}
		return cb_setFreeDragAfterOpen_Z;
	}

	private static IntPtr n_SetFreeDragAfterOpen_Z(IntPtr jnienv, IntPtr native__this, bool freeDragAfterOpen)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetFreeDragAfterOpen(freeDragAfterOpen));
	}

	[Register("setFreeDragAfterOpen", "(Z)Lcom/zerobranch/layout/SwipeLayout;", "GetSetFreeDragAfterOpen_ZHandler")]
	public unsafe virtual SwipeLayout SetFreeDragAfterOpen(bool freeDragAfterOpen)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(freeDragAfterOpen);
			return Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFreeDragAfterOpen.(Z)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
	}

	private static Delegate GetSetFreeHorizontalDrag_ZHandler()
	{
		if ((object)cb_setFreeHorizontalDrag_Z == null)
		{
			cb_setFreeHorizontalDrag_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, IntPtr>(n_SetFreeHorizontalDrag_Z));
		}
		return cb_setFreeHorizontalDrag_Z;
	}

	private static IntPtr n_SetFreeHorizontalDrag_Z(IntPtr jnienv, IntPtr native__this, bool freeHorizontalDrag)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetFreeHorizontalDrag(freeHorizontalDrag));
	}

	[Register("setFreeHorizontalDrag", "(Z)Lcom/zerobranch/layout/SwipeLayout;", "GetSetFreeHorizontalDrag_ZHandler")]
	public unsafe virtual SwipeLayout SetFreeHorizontalDrag(bool freeHorizontalDrag)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(freeHorizontalDrag);
			return Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFreeHorizontalDrag.(Z)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
	}

	private static Delegate GetSetLeftDragViewPadding_IHandler()
	{
		if ((object)cb_setLeftDragViewPadding_I == null)
		{
			cb_setLeftDragViewPadding_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetLeftDragViewPadding_I));
		}
		return cb_setLeftDragViewPadding_I;
	}

	private static IntPtr n_SetLeftDragViewPadding_I(IntPtr jnienv, IntPtr native__this, int minLeftDragViewPadding)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetLeftDragViewPadding(minLeftDragViewPadding));
	}

	[Register("setLeftDragViewPadding", "(I)Lcom/zerobranch/layout/SwipeLayout;", "GetSetLeftDragViewPadding_IHandler")]
	public unsafe virtual SwipeLayout SetLeftDragViewPadding(int minLeftDragViewPadding)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(minLeftDragViewPadding);
			return Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setLeftDragViewPadding.(I)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
	}

	private static Delegate GetSetOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_Handler()
	{
		if ((object)cb_setOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_ == null)
		{
			cb_setOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_SetOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_));
		}
		return cb_setOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_;
	}

	private static IntPtr n_SetOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_(IntPtr jnienv, IntPtr native__this, IntPtr native_actionsListener)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ISwipeActionsListener onActionsListener = Java.Lang.Object.GetObject<ISwipeActionsListener>(native_actionsListener, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetOnActionsListener(onActionsListener));
	}

	[Register("setOnActionsListener", "(Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;)Lcom/zerobranch/layout/SwipeLayout;", "GetSetOnActionsListener_Lcom_zerobranch_layout_SwipeLayout_SwipeActionsListener_Handler")]
	public unsafe virtual SwipeLayout SetOnActionsListener(ISwipeActionsListener actionsListener)
	{
		SwipeLayout result;
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((actionsListener == null) ? IntPtr.Zero : ((Java.Lang.Object)actionsListener).Handle);
			result = Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setOnActionsListener.(Lcom/zerobranch/layout/SwipeLayout$SwipeActionsListener;)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
		GC.KeepAlive(actionsListener);
		return result;
	}

	private static Delegate GetSetRightDragViewPadding_IHandler()
	{
		if ((object)cb_setRightDragViewPadding_I == null)
		{
			cb_setRightDragViewPadding_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_SetRightDragViewPadding_I));
		}
		return cb_setRightDragViewPadding_I;
	}

	private static IntPtr n_SetRightDragViewPadding_I(IntPtr jnienv, IntPtr native__this, int minRightDragViewPadding)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetRightDragViewPadding(minRightDragViewPadding));
	}

	[Register("setRightDragViewPadding", "(I)Lcom/zerobranch/layout/SwipeLayout;", "GetSetRightDragViewPadding_IHandler")]
	public unsafe virtual SwipeLayout SetRightDragViewPadding(int minRightDragViewPadding)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(minRightDragViewPadding);
			return Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setRightDragViewPadding.(I)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
	}

	private static Delegate GetSetTogether_ZHandler()
	{
		if ((object)cb_setTogether_Z == null)
		{
			cb_setTogether_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, IntPtr>(n_SetTogether_Z));
		}
		return cb_setTogether_Z;
	}

	private static IntPtr n_SetTogether_Z(IntPtr jnienv, IntPtr native__this, bool together)
	{
		SwipeLayout swipeLayout = Java.Lang.Object.GetObject<SwipeLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(swipeLayout.SetTogether(together));
	}

	[Register("setTogether", "(Z)Lcom/zerobranch/layout/SwipeLayout;", "GetSetTogether_ZHandler")]
	public unsafe virtual SwipeLayout SetTogether(bool together)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(together);
			return Java.Lang.Object.GetObject<SwipeLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTogether.(Z)Lcom/zerobranch/layout/SwipeLayout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
		}
	}
}

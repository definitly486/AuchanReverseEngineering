using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/LinearLayoutManager", DoNotGenerateAcw = true)]
public class LinearLayoutManager : RecyclerView.LayoutManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/LinearLayoutManager", typeof(LinearLayoutManager));

	private static Delegate? cb_getInitialPrefetchItemCount_GetInitialPrefetchItemCount_I;

	private static Delegate? cb_setInitialPrefetchItemCount_SetInitialPrefetchItemCount_I_V;

	private static Delegate? cb_isLayoutRTL_IsLayoutRTL_Z;

	private static Delegate? cb_getOrientation_GetOrientation_I;

	private static Delegate? cb_setOrientation_SetOrientation_I_V;

	private static Delegate? cb_getRecycleChildrenOnDetach_GetRecycleChildrenOnDetach_Z;

	private static Delegate? cb_setRecycleChildrenOnDetach_SetRecycleChildrenOnDetach_Z_V;

	private static Delegate? cb_getReverseLayout_GetReverseLayout_Z;

	private static Delegate? cb_setReverseLayout_SetReverseLayout_Z_V;

	private static Delegate? cb_isSmoothScrollbarEnabled_IsSmoothScrollbarEnabled_Z;

	private static Delegate? cb_setSmoothScrollbarEnabled_SetSmoothScrollbarEnabled_Z_V;

	private static Delegate? cb_getStackFromEnd_GetStackFromEnd_Z;

	private static Delegate? cb_setStackFromEnd_SetStackFromEnd_Z_V;

	private static Delegate? cb_calculateExtraLayoutSpace_CalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI_V;

	private static Delegate? cb_computeScrollVectorForPosition_ComputeScrollVectorForPosition_I_Landroid_graphics_PointF_;

	private static Delegate? cb_findFirstCompletelyVisibleItemPosition_FindFirstCompletelyVisibleItemPosition_I;

	private static Delegate? cb_findFirstVisibleItemPosition_FindFirstVisibleItemPosition_I;

	private static Delegate? cb_findLastCompletelyVisibleItemPosition_FindLastCompletelyVisibleItemPosition_I;

	private static Delegate? cb_findLastVisibleItemPosition_FindLastVisibleItemPosition_I;

	private static Delegate? cb_generateDefaultLayoutParams_GenerateDefaultLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_;

	private static Delegate? cb_getExtraLayoutSpace_GetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State__I;

	private static Delegate? cb_prepareForDrop_PrepareForDrop_Landroid_view_View_Landroid_view_View_II_V;

	private static Delegate? cb_scrollToPositionWithOffset_ScrollToPositionWithOffset_II_V;

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

	public unsafe virtual int InitialPrefetchItemCount
	{
		[Register("getInitialPrefetchItemCount", "()I", "GetGetInitialPrefetchItemCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInitialPrefetchItemCount.()I", this, null);
		}
		[Register("setInitialPrefetchItemCount", "(I)V", "GetSetInitialPrefetchItemCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInitialPrefetchItemCount.(I)V", this, ptr);
		}
	}

	protected unsafe virtual bool IsLayoutRTL
	{
		[Register("isLayoutRTL", "()Z", "GetIsLayoutRTLHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutRTL.()Z", this, null);
		}
	}

	public unsafe virtual int Orientation
	{
		[Register("getOrientation", "()I", "GetGetOrientationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOrientation.()I", this, null);
		}
		[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOrientation.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool RecycleChildrenOnDetach
	{
		[Register("getRecycleChildrenOnDetach", "()Z", "GetGetRecycleChildrenOnDetachHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getRecycleChildrenOnDetach.()Z", this, null);
		}
		[Register("setRecycleChildrenOnDetach", "(Z)V", "GetSetRecycleChildrenOnDetach_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRecycleChildrenOnDetach.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool ReverseLayout
	{
		[Register("getReverseLayout", "()Z", "GetGetReverseLayoutHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getReverseLayout.()Z", this, null);
		}
		[Register("setReverseLayout", "(Z)V", "GetSetReverseLayout_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setReverseLayout.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool SmoothScrollbarEnabled
	{
		[Register("isSmoothScrollbarEnabled", "()Z", "GetIsSmoothScrollbarEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSmoothScrollbarEnabled.()Z", this, null);
		}
		[Register("setSmoothScrollbarEnabled", "(Z)V", "GetSetSmoothScrollbarEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSmoothScrollbarEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool StackFromEnd
	{
		[Register("getStackFromEnd", "()Z", "GetGetStackFromEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getStackFromEnd.()Z", this, null);
		}
		[Register("setStackFromEnd", "(Z)V", "GetSetStackFromEnd_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStackFromEnd.(Z)V", this, ptr);
		}
	}

	protected LinearLayoutManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe LinearLayoutManager(Context? context)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe LinearLayoutManager(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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

	[Register(".ctor", "(Landroid/content/Context;IZ)V", "")]
	public unsafe LinearLayoutManager(Context? context, int orientation, bool reverseLayout)
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
			ptr[1] = new JniArgumentValue(orientation);
			ptr[2] = new JniArgumentValue(reverseLayout ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;IZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;IZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetInitialPrefetchItemCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInitialPrefetchItemCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInitialPrefetchItemCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitialPrefetchItemCount;
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

	private static Delegate GetSetInitialPrefetchItemCount_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetInitialPrefetchItemCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInitialPrefetchItemCount_I(nint jnienv, nint native__this, int itemCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitialPrefetchItemCount = itemCount;
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

	private static Delegate GetIsLayoutRTLHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsLayoutRTL);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLayoutRTL(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutRTL ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetOrientationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOrientation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOrientation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
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

	private static Delegate GetSetOrientation_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetOrientation_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOrientation_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
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

	private static Delegate GetGetRecycleChildrenOnDetachHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetRecycleChildrenOnDetach);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetRecycleChildrenOnDetach(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RecycleChildrenOnDetach ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetRecycleChildrenOnDetach_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetRecycleChildrenOnDetach_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRecycleChildrenOnDetach_Z(nint jnienv, nint native__this, sbyte native_recycleChildrenOnDetach)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutManager? linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool recycleChildrenOnDetach = native_recycleChildrenOnDetach != 0;
			linearLayoutManager.RecycleChildrenOnDetach = recycleChildrenOnDetach;
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

	private static Delegate GetGetReverseLayoutHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetReverseLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetReverseLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReverseLayout ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetReverseLayout_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetReverseLayout_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetReverseLayout_Z(nint jnienv, nint native__this, sbyte native_reverseLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutManager? linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool reverseLayout = native_reverseLayout != 0;
			linearLayoutManager.ReverseLayout = reverseLayout;
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

	private static Delegate GetIsSmoothScrollbarEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSmoothScrollbarEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSmoothScrollbarEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollbarEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSmoothScrollbarEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSmoothScrollbarEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSmoothScrollbarEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutManager? linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool smoothScrollbarEnabled = native_enabled != 0;
			linearLayoutManager.SmoothScrollbarEnabled = smoothScrollbarEnabled;
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

	private static Delegate GetGetStackFromEndHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetStackFromEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetStackFromEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StackFromEnd ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetStackFromEnd_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetStackFromEnd_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStackFromEnd_Z(nint jnienv, nint native__this, sbyte native_stackFromEnd)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutManager? linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool stackFromEnd = native_stackFromEnd != 0;
			linearLayoutManager.StackFromEnd = stackFromEnd;
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

	private static Delegate GetCalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayIHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_CalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayI(nint jnienv, nint native__this, nint native_state, nint native_extraLayoutSpace)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutManager? linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.State state = Java.Lang.Object.GetObject<RecyclerView.State>(native_state, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_extraLayoutSpace, JniHandleOwnership.DoNotTransfer, typeof(int));
			linearLayoutManager.CalculateExtraLayoutSpace(state, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_extraLayoutSpace);
			}
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

	[Register("calculateExtraLayoutSpace", "(Landroidx/recyclerview/widget/RecyclerView$State;[I)V", "GetCalculateExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_arrayIHandler")]
	protected unsafe virtual void CalculateExtraLayoutSpace(RecyclerView.State state, int[] extraLayoutSpace)
	{
		nint num = JNIEnv.NewArray(extraLayoutSpace);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("calculateExtraLayoutSpace.(Landroidx/recyclerview/widget/RecyclerView$State;[I)V", this, ptr);
		}
		finally
		{
			if (extraLayoutSpace != null)
			{
				JNIEnv.CopyArray(num, extraLayoutSpace);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(state);
			GC.KeepAlive(extraLayoutSpace);
		}
	}

	private static Delegate GetComputeScrollVectorForPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_ComputeScrollVectorForPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ComputeScrollVectorForPosition_I(nint jnienv, nint native__this, int targetPosition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeScrollVectorForPosition(targetPosition));
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

	[Register("computeScrollVectorForPosition", "(I)Landroid/graphics/PointF;", "GetComputeScrollVectorForPosition_IHandler")]
	public unsafe virtual PointF? ComputeScrollVectorForPosition(int targetPosition)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(targetPosition);
		return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeVirtualObjectMethod("computeScrollVectorForPosition.(I)Landroid/graphics/PointF;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindFirstCompletelyVisibleItemPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_FindFirstCompletelyVisibleItemPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindFirstCompletelyVisibleItemPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFirstCompletelyVisibleItemPosition();
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

	[Register("findFirstCompletelyVisibleItemPosition", "()I", "GetFindFirstCompletelyVisibleItemPositionHandler")]
	public unsafe virtual int FindFirstCompletelyVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findFirstCompletelyVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindFirstVisibleItemPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_FindFirstVisibleItemPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindFirstVisibleItemPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFirstVisibleItemPosition();
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

	[Register("findFirstVisibleItemPosition", "()I", "GetFindFirstVisibleItemPositionHandler")]
	public unsafe virtual int FindFirstVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findFirstVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindLastCompletelyVisibleItemPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_FindLastCompletelyVisibleItemPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindLastCompletelyVisibleItemPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindLastCompletelyVisibleItemPosition();
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

	[Register("findLastCompletelyVisibleItemPosition", "()I", "GetFindLastCompletelyVisibleItemPositionHandler")]
	public unsafe virtual int FindLastCompletelyVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findLastCompletelyVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindLastVisibleItemPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_FindLastVisibleItemPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindLastVisibleItemPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindLastVisibleItemPosition();
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

	[Register("findLastVisibleItemPosition", "()I", "GetFindLastVisibleItemPositionHandler")]
	public unsafe virtual int FindLastVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findLastVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetGenerateDefaultLayoutParamsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GenerateDefaultLayoutParams);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GenerateDefaultLayoutParams(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GenerateDefaultLayoutParams());
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

	[Register("generateDefaultLayoutParams", "()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateDefaultLayoutParamsHandler")]
	public unsafe override RecyclerView.LayoutParams? GenerateDefaultLayoutParams()
	{
		return Java.Lang.Object.GetObject<RecyclerView.LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("generateDefaultLayoutParams.()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetGetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LinearLayoutManager? linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerView.State state = Java.Lang.Object.GetObject<RecyclerView.State>(native_state, JniHandleOwnership.DoNotTransfer);
			return linearLayoutManager.GetExtraLayoutSpace(state);
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

	[Obsolete("deprecated")]
	[Register("getExtraLayoutSpace", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetExtraLayoutSpace_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
	protected unsafe virtual int GetExtraLayoutSpace(RecyclerView.State? state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getExtraLayoutSpace.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetPrepareForDrop_Landroid_view_View_Landroid_view_View_IIHandler()
	{
		return new global::_JniMarshal_PPLLII_V(n_PrepareForDrop_Landroid_view_View_Landroid_view_View_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PrepareForDrop_Landroid_view_View_Landroid_view_View_II(nint jnienv, nint native__this, nint native_view, nint native_target, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutManager? linearLayoutManager = Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			View target = Java.Lang.Object.GetObject<View>(native_target, JniHandleOwnership.DoNotTransfer);
			linearLayoutManager.PrepareForDrop(view, target, x, y);
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

	[Register("prepareForDrop", "(Landroid/view/View;Landroid/view/View;II)V", "GetPrepareForDrop_Landroid_view_View_Landroid_view_View_IIHandler")]
	public unsafe virtual void PrepareForDrop(View view, View target, int x, int y)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(x);
			ptr[3] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeVirtualVoidMethod("prepareForDrop.(Landroid/view/View;Landroid/view/View;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetScrollToPositionWithOffset_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ScrollToPositionWithOffset_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ScrollToPositionWithOffset_II(nint jnienv, nint native__this, int position, int offset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollToPositionWithOffset(position, offset);
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

	[Register("scrollToPositionWithOffset", "(II)V", "GetScrollToPositionWithOffset_IIHandler")]
	public unsafe virtual void ScrollToPositionWithOffset(int position, int offset)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(offset);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scrollToPositionWithOffset.(II)V", this, ptr);
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

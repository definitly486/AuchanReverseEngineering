using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Java.Interop;
using Java.Lang;

namespace Google.Flexbox;

[Register("com/google/android/flexbox/FlexboxLayoutManager", DoNotGenerateAcw = true)]
public class FlexboxLayoutManager : RecyclerView.LayoutManager, IJavaObject, IDisposable, IJavaPeerable
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/flexbox/FlexboxLayoutManager", typeof(FlexboxLayoutManager));

	private static Delegate cb_getAlignContent;

	private static Delegate cb_setAlignContent_I;

	private static Delegate cb_getAlignItems;

	private static Delegate cb_setAlignItems_I;

	private static Delegate cb_getFlexDirection;

	private static Delegate cb_setFlexDirection_I;

	private static Delegate cb_getFlexItemCount;

	private static Delegate cb_getFlexLines;

	private static Delegate cb_setFlexLines_Ljava_util_List_;

	private static Delegate cb_getFlexLinesInternal;

	private static Delegate cb_getFlexWrap;

	private static Delegate cb_setFlexWrap_I;

	private static Delegate cb_isMainAxisDirectionHorizontal;

	private static Delegate cb_getJustifyContent;

	private static Delegate cb_setJustifyContent_I;

	private static Delegate cb_getLargestMainSize;

	private static Delegate cb_getMaxLine;

	private static Delegate cb_setMaxLine_I;

	private static Delegate cb_getRecycleChildrenOnDetach;

	private static Delegate cb_setRecycleChildrenOnDetach_Z;

	private static Delegate cb_getSumOfCrossSize;

	private static Delegate cb_computeScrollVectorForPosition_I;

	private static Delegate cb_findFirstCompletelyVisibleItemPosition;

	private static Delegate cb_findFirstVisibleItemPosition;

	private static Delegate cb_findLastCompletelyVisibleItemPosition;

	private static Delegate cb_findLastVisibleItemPosition;

	private static Delegate cb_generateDefaultLayoutParams;

	private static Delegate cb_getChildHeightMeasureSpec_III;

	private static Delegate cb_getChildWidthMeasureSpec_III;

	private static Delegate cb_getDecorationLengthCrossAxis_Landroid_view_View_;

	private static Delegate cb_getDecorationLengthMainAxis_Landroid_view_View_II;

	private static Delegate cb_getFlexItemAt_I;

	private static Delegate cb_getReorderedFlexItemAt_I;

	private static Delegate cb_onNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_;

	private static Delegate cb_onNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_;

	private static Delegate cb_updateViewCache_ILandroid_view_View_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual int AlignContent
	{
		[Register("getAlignContent", "()I", "GetGetAlignContentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAlignContent.()I", this, null);
		}
		[Register("setAlignContent", "(I)V", "GetSetAlignContent_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAlignContent.(I)V", this, ptr);
		}
	}

	public unsafe virtual int AlignItems
	{
		[Register("getAlignItems", "()I", "GetGetAlignItemsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAlignItems.()I", this, null);
		}
		[Register("setAlignItems", "(I)V", "GetSetAlignItems_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAlignItems.(I)V", this, ptr);
		}
	}

	public unsafe virtual int FlexDirection
	{
		[Register("getFlexDirection", "()I", "GetGetFlexDirectionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFlexDirection.()I", this, null);
		}
		[Register("setFlexDirection", "(I)V", "GetSetFlexDirection_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFlexDirection.(I)V", this, ptr);
		}
	}

	public unsafe virtual int FlexItemCount
	{
		[Register("getFlexItemCount", "()I", "GetGetFlexItemCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFlexItemCount.()I", this, null);
		}
	}

	public unsafe virtual IList<FlexLine> FlexLines
	{
		[Register("getFlexLines", "()Ljava/util/List;", "GetGetFlexLinesHandler")]
		get
		{
			return JavaList<FlexLine>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFlexLines.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setFlexLines", "(Ljava/util/List;)V", "GetSetFlexLines_Ljava_util_List_Handler")]
		set
		{
			IntPtr intPtr = JavaList<FlexLine>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFlexLines.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual IList<FlexLine> FlexLinesInternal
	{
		[Register("getFlexLinesInternal", "()Ljava/util/List;", "GetGetFlexLinesInternalHandler")]
		get
		{
			return JavaList<FlexLine>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getFlexLinesInternal.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int FlexWrap
	{
		[Register("getFlexWrap", "()I", "GetGetFlexWrapHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFlexWrap.()I", this, null);
		}
		[Register("setFlexWrap", "(I)V", "GetSetFlexWrap_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFlexWrap.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool IsMainAxisDirectionHorizontal
	{
		[Register("isMainAxisDirectionHorizontal", "()Z", "GetIsMainAxisDirectionHorizontalHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMainAxisDirectionHorizontal.()Z", this, null);
		}
	}

	public unsafe virtual int JustifyContent
	{
		[Register("getJustifyContent", "()I", "GetGetJustifyContentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getJustifyContent.()I", this, null);
		}
		[Register("setJustifyContent", "(I)V", "GetSetJustifyContent_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setJustifyContent.(I)V", this, ptr);
		}
	}

	public unsafe virtual int LargestMainSize
	{
		[Register("getLargestMainSize", "()I", "GetGetLargestMainSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLargestMainSize.()I", this, null);
		}
	}

	public unsafe virtual int MaxLine
	{
		[Register("getMaxLine", "()I", "GetGetMaxLineHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxLine.()I", this, null);
		}
		[Register("setMaxLine", "(I)V", "GetSetMaxLine_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxLine.(I)V", this, ptr);
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
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRecycleChildrenOnDetach.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int SumOfCrossSize
	{
		[Register("getSumOfCrossSize", "()I", "GetGetSumOfCrossSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSumOfCrossSize.()I", this, null);
		}
	}

	protected FlexboxLayoutManager(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe FlexboxLayoutManager(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe FlexboxLayoutManager(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;I)V", "")]
	public unsafe FlexboxLayoutManager(Context context, int flexDirection)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(flexDirection);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;II)V", "")]
	public unsafe FlexboxLayoutManager(Context context, int flexDirection, int flexWrap)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(flexDirection);
			ptr[2] = new JniArgumentValue(flexWrap);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;II)V", this, ptr);
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetAlignContentHandler()
	{
		if ((object)cb_getAlignContent == null)
		{
			cb_getAlignContent = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetAlignContent));
		}
		return cb_getAlignContent;
	}

	private static int n_GetAlignContent(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignContent;
	}

	private static Delegate GetSetAlignContent_IHandler()
	{
		if ((object)cb_setAlignContent_I == null)
		{
			cb_setAlignContent_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetAlignContent_I));
		}
		return cb_setAlignContent_I;
	}

	private static void n_SetAlignContent_I(IntPtr jnienv, IntPtr native__this, int alignContent)
	{
		Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignContent = alignContent;
	}

	private static Delegate GetGetAlignItemsHandler()
	{
		if ((object)cb_getAlignItems == null)
		{
			cb_getAlignItems = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetAlignItems));
		}
		return cb_getAlignItems;
	}

	private static int n_GetAlignItems(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignItems;
	}

	private static Delegate GetSetAlignItems_IHandler()
	{
		if ((object)cb_setAlignItems_I == null)
		{
			cb_setAlignItems_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetAlignItems_I));
		}
		return cb_setAlignItems_I;
	}

	private static void n_SetAlignItems_I(IntPtr jnienv, IntPtr native__this, int alignItems)
	{
		Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignItems = alignItems;
	}

	private static Delegate GetGetFlexDirectionHandler()
	{
		if ((object)cb_getFlexDirection == null)
		{
			cb_getFlexDirection = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetFlexDirection));
		}
		return cb_getFlexDirection;
	}

	private static int n_GetFlexDirection(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlexDirection;
	}

	private static Delegate GetSetFlexDirection_IHandler()
	{
		if ((object)cb_setFlexDirection_I == null)
		{
			cb_setFlexDirection_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetFlexDirection_I));
		}
		return cb_setFlexDirection_I;
	}

	private static void n_SetFlexDirection_I(IntPtr jnienv, IntPtr native__this, int flexDirection)
	{
		Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlexDirection = flexDirection;
	}

	private static Delegate GetGetFlexItemCountHandler()
	{
		if ((object)cb_getFlexItemCount == null)
		{
			cb_getFlexItemCount = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetFlexItemCount));
		}
		return cb_getFlexItemCount;
	}

	private static int n_GetFlexItemCount(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlexItemCount;
	}

	private static Delegate GetGetFlexLinesHandler()
	{
		if ((object)cb_getFlexLines == null)
		{
			cb_getFlexLines = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetFlexLines));
		}
		return cb_getFlexLines;
	}

	private static IntPtr n_GetFlexLines(IntPtr jnienv, IntPtr native__this)
	{
		return JavaList<FlexLine>.ToLocalJniHandle(Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlexLines);
	}

	private static Delegate GetSetFlexLines_Ljava_util_List_Handler()
	{
		if ((object)cb_setFlexLines_Ljava_util_List_ == null)
		{
			cb_setFlexLines_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetFlexLines_Ljava_util_List_));
		}
		return cb_setFlexLines_Ljava_util_List_;
	}

	private static void n_SetFlexLines_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_flexLines)
	{
		FlexboxLayoutManager? flexboxLayoutManager = Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<FlexLine> flexLines = JavaList<FlexLine>.FromJniHandle(native_flexLines, JniHandleOwnership.DoNotTransfer);
		flexboxLayoutManager.FlexLines = flexLines;
	}

	private static Delegate GetGetFlexLinesInternalHandler()
	{
		if ((object)cb_getFlexLinesInternal == null)
		{
			cb_getFlexLinesInternal = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetFlexLinesInternal));
		}
		return cb_getFlexLinesInternal;
	}

	private static IntPtr n_GetFlexLinesInternal(IntPtr jnienv, IntPtr native__this)
	{
		return JavaList<FlexLine>.ToLocalJniHandle(Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlexLinesInternal);
	}

	private static Delegate GetGetFlexWrapHandler()
	{
		if ((object)cb_getFlexWrap == null)
		{
			cb_getFlexWrap = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetFlexWrap));
		}
		return cb_getFlexWrap;
	}

	private static int n_GetFlexWrap(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlexWrap;
	}

	private static Delegate GetSetFlexWrap_IHandler()
	{
		if ((object)cb_setFlexWrap_I == null)
		{
			cb_setFlexWrap_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetFlexWrap_I));
		}
		return cb_setFlexWrap_I;
	}

	private static void n_SetFlexWrap_I(IntPtr jnienv, IntPtr native__this, int flexWrap)
	{
		Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlexWrap = flexWrap;
	}

	private static Delegate GetIsMainAxisDirectionHorizontalHandler()
	{
		if ((object)cb_isMainAxisDirectionHorizontal == null)
		{
			cb_isMainAxisDirectionHorizontal = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsMainAxisDirectionHorizontal));
		}
		return cb_isMainAxisDirectionHorizontal;
	}

	private static bool n_IsMainAxisDirectionHorizontal(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsMainAxisDirectionHorizontal;
	}

	private static Delegate GetGetJustifyContentHandler()
	{
		if ((object)cb_getJustifyContent == null)
		{
			cb_getJustifyContent = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetJustifyContent));
		}
		return cb_getJustifyContent;
	}

	private static int n_GetJustifyContent(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).JustifyContent;
	}

	private static Delegate GetSetJustifyContent_IHandler()
	{
		if ((object)cb_setJustifyContent_I == null)
		{
			cb_setJustifyContent_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetJustifyContent_I));
		}
		return cb_setJustifyContent_I;
	}

	private static void n_SetJustifyContent_I(IntPtr jnienv, IntPtr native__this, int justifyContent)
	{
		Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).JustifyContent = justifyContent;
	}

	private static Delegate GetGetLargestMainSizeHandler()
	{
		if ((object)cb_getLargestMainSize == null)
		{
			cb_getLargestMainSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetLargestMainSize));
		}
		return cb_getLargestMainSize;
	}

	private static int n_GetLargestMainSize(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LargestMainSize;
	}

	private static Delegate GetGetMaxLineHandler()
	{
		if ((object)cb_getMaxLine == null)
		{
			cb_getMaxLine = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetMaxLine));
		}
		return cb_getMaxLine;
	}

	private static int n_GetMaxLine(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxLine;
	}

	private static Delegate GetSetMaxLine_IHandler()
	{
		if ((object)cb_setMaxLine_I == null)
		{
			cb_setMaxLine_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_SetMaxLine_I));
		}
		return cb_setMaxLine_I;
	}

	private static void n_SetMaxLine_I(IntPtr jnienv, IntPtr native__this, int maxLine)
	{
		Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxLine = maxLine;
	}

	private static Delegate GetGetRecycleChildrenOnDetachHandler()
	{
		if ((object)cb_getRecycleChildrenOnDetach == null)
		{
			cb_getRecycleChildrenOnDetach = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_GetRecycleChildrenOnDetach));
		}
		return cb_getRecycleChildrenOnDetach;
	}

	private static bool n_GetRecycleChildrenOnDetach(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RecycleChildrenOnDetach;
	}

	private static Delegate GetSetRecycleChildrenOnDetach_ZHandler()
	{
		if ((object)cb_setRecycleChildrenOnDetach_Z == null)
		{
			cb_setRecycleChildrenOnDetach_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetRecycleChildrenOnDetach_Z));
		}
		return cb_setRecycleChildrenOnDetach_Z;
	}

	private static void n_SetRecycleChildrenOnDetach_Z(IntPtr jnienv, IntPtr native__this, bool recycleChildrenOnDetach)
	{
		Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RecycleChildrenOnDetach = recycleChildrenOnDetach;
	}

	private static Delegate GetGetSumOfCrossSizeHandler()
	{
		if ((object)cb_getSumOfCrossSize == null)
		{
			cb_getSumOfCrossSize = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetSumOfCrossSize));
		}
		return cb_getSumOfCrossSize;
	}

	private static int n_GetSumOfCrossSize(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SumOfCrossSize;
	}

	private static Delegate GetComputeScrollVectorForPosition_IHandler()
	{
		if ((object)cb_computeScrollVectorForPosition_I == null)
		{
			cb_computeScrollVectorForPosition_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_ComputeScrollVectorForPosition_I));
		}
		return cb_computeScrollVectorForPosition_I;
	}

	private static IntPtr n_ComputeScrollVectorForPosition_I(IntPtr jnienv, IntPtr native__this, int targetPosition)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeScrollVectorForPosition(targetPosition));
	}

	[Register("computeScrollVectorForPosition", "(I)Landroid/graphics/PointF;", "GetComputeScrollVectorForPosition_IHandler")]
	public unsafe virtual PointF ComputeScrollVectorForPosition(int targetPosition)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(targetPosition);
		return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeVirtualObjectMethod("computeScrollVectorForPosition.(I)Landroid/graphics/PointF;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindFirstCompletelyVisibleItemPositionHandler()
	{
		if ((object)cb_findFirstCompletelyVisibleItemPosition == null)
		{
			cb_findFirstCompletelyVisibleItemPosition = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_FindFirstCompletelyVisibleItemPosition));
		}
		return cb_findFirstCompletelyVisibleItemPosition;
	}

	private static int n_FindFirstCompletelyVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFirstCompletelyVisibleItemPosition();
	}

	[Register("findFirstCompletelyVisibleItemPosition", "()I", "GetFindFirstCompletelyVisibleItemPositionHandler")]
	public unsafe virtual int FindFirstCompletelyVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findFirstCompletelyVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindFirstVisibleItemPositionHandler()
	{
		if ((object)cb_findFirstVisibleItemPosition == null)
		{
			cb_findFirstVisibleItemPosition = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_FindFirstVisibleItemPosition));
		}
		return cb_findFirstVisibleItemPosition;
	}

	private static int n_FindFirstVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFirstVisibleItemPosition();
	}

	[Register("findFirstVisibleItemPosition", "()I", "GetFindFirstVisibleItemPositionHandler")]
	public unsafe virtual int FindFirstVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findFirstVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindLastCompletelyVisibleItemPositionHandler()
	{
		if ((object)cb_findLastCompletelyVisibleItemPosition == null)
		{
			cb_findLastCompletelyVisibleItemPosition = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_FindLastCompletelyVisibleItemPosition));
		}
		return cb_findLastCompletelyVisibleItemPosition;
	}

	private static int n_FindLastCompletelyVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindLastCompletelyVisibleItemPosition();
	}

	[Register("findLastCompletelyVisibleItemPosition", "()I", "GetFindLastCompletelyVisibleItemPositionHandler")]
	public unsafe virtual int FindLastCompletelyVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findLastCompletelyVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetFindLastVisibleItemPositionHandler()
	{
		if ((object)cb_findLastVisibleItemPosition == null)
		{
			cb_findLastVisibleItemPosition = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_FindLastVisibleItemPosition));
		}
		return cb_findLastVisibleItemPosition;
	}

	private static int n_FindLastVisibleItemPosition(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindLastVisibleItemPosition();
	}

	[Register("findLastVisibleItemPosition", "()I", "GetFindLastVisibleItemPositionHandler")]
	public unsafe virtual int FindLastVisibleItemPosition()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("findLastVisibleItemPosition.()I", this, null);
	}

	private static Delegate GetGenerateDefaultLayoutParamsHandler()
	{
		if ((object)cb_generateDefaultLayoutParams == null)
		{
			cb_generateDefaultLayoutParams = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GenerateDefaultLayoutParams));
		}
		return cb_generateDefaultLayoutParams;
	}

	private static IntPtr n_GenerateDefaultLayoutParams(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GenerateDefaultLayoutParams());
	}

	[Register("generateDefaultLayoutParams", "()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateDefaultLayoutParamsHandler")]
	public unsafe override RecyclerView.LayoutParams GenerateDefaultLayoutParams()
	{
		return Java.Lang.Object.GetObject<RecyclerView.LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("generateDefaultLayoutParams.()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetChildHeightMeasureSpec_IIIHandler()
	{
		if ((object)cb_getChildHeightMeasureSpec_III == null)
		{
			cb_getChildHeightMeasureSpec_III = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, int, int, int>(n_GetChildHeightMeasureSpec_III));
		}
		return cb_getChildHeightMeasureSpec_III;
	}

	private static int n_GetChildHeightMeasureSpec_III(IntPtr jnienv, IntPtr native__this, int heightSpec, int padding, int childDimension)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChildHeightMeasureSpec(heightSpec, padding, childDimension);
	}

	[Register("getChildHeightMeasureSpec", "(III)I", "GetGetChildHeightMeasureSpec_IIIHandler")]
	public unsafe virtual int GetChildHeightMeasureSpec(int heightSpec, int padding, int childDimension)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(heightSpec);
		ptr[1] = new JniArgumentValue(padding);
		ptr[2] = new JniArgumentValue(childDimension);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getChildHeightMeasureSpec.(III)I", this, ptr);
	}

	private static Delegate GetGetChildWidthMeasureSpec_IIIHandler()
	{
		if ((object)cb_getChildWidthMeasureSpec_III == null)
		{
			cb_getChildWidthMeasureSpec_III = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, int, int, int>(n_GetChildWidthMeasureSpec_III));
		}
		return cb_getChildWidthMeasureSpec_III;
	}

	private static int n_GetChildWidthMeasureSpec_III(IntPtr jnienv, IntPtr native__this, int widthSpec, int padding, int childDimension)
	{
		return Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChildWidthMeasureSpec(widthSpec, padding, childDimension);
	}

	[Register("getChildWidthMeasureSpec", "(III)I", "GetGetChildWidthMeasureSpec_IIIHandler")]
	public unsafe virtual int GetChildWidthMeasureSpec(int widthSpec, int padding, int childDimension)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(widthSpec);
		ptr[1] = new JniArgumentValue(padding);
		ptr[2] = new JniArgumentValue(childDimension);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getChildWidthMeasureSpec.(III)I", this, ptr);
	}

	private static Delegate GetGetDecorationLengthCrossAxis_Landroid_view_View_Handler()
	{
		if ((object)cb_getDecorationLengthCrossAxis_Landroid_view_View_ == null)
		{
			cb_getDecorationLengthCrossAxis_Landroid_view_View_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, int>(n_GetDecorationLengthCrossAxis_Landroid_view_View_));
		}
		return cb_getDecorationLengthCrossAxis_Landroid_view_View_;
	}

	private static int n_GetDecorationLengthCrossAxis_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_view)
	{
		FlexboxLayoutManager? flexboxLayoutManager = Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		return flexboxLayoutManager.GetDecorationLengthCrossAxis(view);
	}

	[Register("getDecorationLengthCrossAxis", "(Landroid/view/View;)I", "GetGetDecorationLengthCrossAxis_Landroid_view_View_Handler")]
	public unsafe virtual int GetDecorationLengthCrossAxis(View view)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
		int result = _members.InstanceMethods.InvokeVirtualInt32Method("getDecorationLengthCrossAxis.(Landroid/view/View;)I", this, ptr);
		GC.KeepAlive(view);
		return result;
	}

	private static Delegate GetGetDecorationLengthMainAxis_Landroid_view_View_IIHandler()
	{
		if ((object)cb_getDecorationLengthMainAxis_Landroid_view_View_II == null)
		{
			cb_getDecorationLengthMainAxis_Landroid_view_View_II = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, int, int, int>(n_GetDecorationLengthMainAxis_Landroid_view_View_II));
		}
		return cb_getDecorationLengthMainAxis_Landroid_view_View_II;
	}

	private static int n_GetDecorationLengthMainAxis_Landroid_view_View_II(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int index, int indexInFlexLine)
	{
		FlexboxLayoutManager? flexboxLayoutManager = Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		return flexboxLayoutManager.GetDecorationLengthMainAxis(view, index, indexInFlexLine);
	}

	[Register("getDecorationLengthMainAxis", "(Landroid/view/View;II)I", "GetGetDecorationLengthMainAxis_Landroid_view_View_IIHandler")]
	public unsafe virtual int GetDecorationLengthMainAxis(View view, int index, int indexInFlexLine)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue(index);
		ptr[2] = new JniArgumentValue(indexInFlexLine);
		int result = _members.InstanceMethods.InvokeVirtualInt32Method("getDecorationLengthMainAxis.(Landroid/view/View;II)I", this, ptr);
		GC.KeepAlive(view);
		return result;
	}

	private static Delegate GetGetFlexItemAt_IHandler()
	{
		if ((object)cb_getFlexItemAt_I == null)
		{
			cb_getFlexItemAt_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_GetFlexItemAt_I));
		}
		return cb_getFlexItemAt_I;
	}

	private static IntPtr n_GetFlexItemAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetFlexItemAt(index));
	}

	[Register("getFlexItemAt", "(I)Landroid/view/View;", "GetGetFlexItemAt_IHandler")]
	public unsafe virtual View GetFlexItemAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFlexItemAt.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetReorderedFlexItemAt_IHandler()
	{
		if ((object)cb_getReorderedFlexItemAt_I == null)
		{
			cb_getReorderedFlexItemAt_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_GetReorderedFlexItemAt_I));
		}
		return cb_getReorderedFlexItemAt_I;
	}

	private static IntPtr n_GetReorderedFlexItemAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetReorderedFlexItemAt(index));
	}

	[Register("getReorderedFlexItemAt", "(I)Landroid/view/View;", "GetGetReorderedFlexItemAt_IHandler")]
	public unsafe virtual View GetReorderedFlexItemAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getReorderedFlexItemAt.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_Handler()
	{
		if ((object)cb_onNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_ == null)
		{
			cb_onNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, int, int, IntPtr>(n_OnNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_));
		}
		return cb_onNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_;
	}

	private static void n_OnNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, int index, int indexInFlexLine, IntPtr native_flexLine)
	{
		FlexboxLayoutManager? flexboxLayoutManager = Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		FlexLine flexLine = Java.Lang.Object.GetObject<FlexLine>(native_flexLine, JniHandleOwnership.DoNotTransfer);
		flexboxLayoutManager.OnNewFlexItemAdded(view, index, indexInFlexLine, flexLine);
	}

	[Register("onNewFlexItemAdded", "(Landroid/view/View;IILcom/google/android/flexbox/FlexLine;)V", "GetOnNewFlexItemAdded_Landroid_view_View_IILcom_google_android_flexbox_FlexLine_Handler")]
	public unsafe virtual void OnNewFlexItemAdded(View view, int index, int indexInFlexLine, FlexLine flexLine)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
		ptr[1] = new JniArgumentValue(index);
		ptr[2] = new JniArgumentValue(indexInFlexLine);
		ptr[3] = new JniArgumentValue(flexLine?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onNewFlexItemAdded.(Landroid/view/View;IILcom/google/android/flexbox/FlexLine;)V", this, ptr);
		GC.KeepAlive(view);
		GC.KeepAlive(flexLine);
	}

	private static Delegate GetOnNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_Handler()
	{
		if ((object)cb_onNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_ == null)
		{
			cb_onNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_));
		}
		return cb_onNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_;
	}

	private static void n_OnNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_(IntPtr jnienv, IntPtr native__this, IntPtr native_flexLine)
	{
		FlexboxLayoutManager? flexboxLayoutManager = Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FlexLine flexLine = Java.Lang.Object.GetObject<FlexLine>(native_flexLine, JniHandleOwnership.DoNotTransfer);
		flexboxLayoutManager.OnNewFlexLineAdded(flexLine);
	}

	[Register("onNewFlexLineAdded", "(Lcom/google/android/flexbox/FlexLine;)V", "GetOnNewFlexLineAdded_Lcom_google_android_flexbox_FlexLine_Handler")]
	public unsafe virtual void OnNewFlexLineAdded(FlexLine flexLine)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flexLine?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onNewFlexLineAdded.(Lcom/google/android/flexbox/FlexLine;)V", this, ptr);
		GC.KeepAlive(flexLine);
	}

	private static Delegate GetUpdateViewCache_ILandroid_view_View_Handler()
	{
		if ((object)cb_updateViewCache_ILandroid_view_View_ == null)
		{
			cb_updateViewCache_ILandroid_view_View_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, IntPtr>(n_UpdateViewCache_ILandroid_view_View_));
		}
		return cb_updateViewCache_ILandroid_view_View_;
	}

	private static void n_UpdateViewCache_ILandroid_view_View_(IntPtr jnienv, IntPtr native__this, int position, IntPtr native_view)
	{
		FlexboxLayoutManager? flexboxLayoutManager = Java.Lang.Object.GetObject<FlexboxLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
		flexboxLayoutManager.UpdateViewCache(position, view);
	}

	[Register("updateViewCache", "(ILandroid/view/View;)V", "GetUpdateViewCache_ILandroid_view_View_Handler")]
	public unsafe virtual void UpdateViewCache(int position, View view)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(position);
		ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateViewCache.(ILandroid/view/View;)V", this, ptr);
		GC.KeepAlive(view);
	}
}

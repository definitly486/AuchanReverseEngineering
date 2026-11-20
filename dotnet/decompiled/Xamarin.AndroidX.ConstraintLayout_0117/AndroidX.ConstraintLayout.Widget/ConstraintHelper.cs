using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.ConstraintLayout.Core.Widgets;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintHelper", DoNotGenerateAcw = true)]
public abstract class ConstraintHelper : View
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintHelper", typeof(ConstraintHelper));

	private static Delegate? cb_addView_AddView_Landroid_view_View__V;

	private static Delegate? cb_applyHelperParams_ApplyHelperParams_V;

	private static Delegate? cb_applyLayoutFeatures_ApplyLayoutFeatures_V;

	private static Delegate? cb_applyLayoutFeatures_ApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_applyLayoutFeaturesInConstraintSet_ApplyLayoutFeaturesInConstraintSet_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_containsId_ContainsId_I_Z;

	private static Delegate? cb_getReferencedIds_GetReferencedIds_arrayI;

	private static Delegate? cb_getViews_GetViews_Landroidx_constraintlayout_widget_ConstraintLayout__arrayLandroid_view_View_;

	private static Delegate? cb_indexFromId_IndexFromId_I_I;

	private static Delegate? cb_init_Init_Landroid_util_AttributeSet__V;

	private static Delegate? cb_loadParameters_LoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_core_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray__V;

	private static Delegate? cb_onDraw_OnDraw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_removeView_RemoveView_Landroid_view_View__I;

	private static Delegate? cb_resolveRtl_ResolveRtl_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Z_V;

	private static Delegate? cb_setIds_SetIds_Ljava_lang_String__V;

	private static Delegate? cb_setReferenceTags_SetReferenceTags_Ljava_lang_String__V;

	private static Delegate? cb_setReferencedIds_SetReferencedIds_arrayI_V;

	private static Delegate? cb_updatePostConstraints_UpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_updatePostLayout_UpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_updatePostMeasure_UpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_updatePreDraw_UpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_updatePreLayout_UpdatePreLayout_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_widgets_Helper_Landroid_util_SparseArray__V;

	private static Delegate? cb_updatePreLayout_UpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_validateParams_ValidateParams_V;

	[Register("mCount")]
	protected int MCount
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mCount.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mCount.I", this, value);
		}
	}

	[Register("mHelperWidget")]
	protected IHelper? MHelperWidget
	{
		get
		{
			return Java.Lang.Object.GetObject<IHelper>(_members.InstanceFields.GetObjectValue("mHelperWidget.Landroidx/constraintlayout/core/widgets/Helper;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mHelperWidget.Landroidx/constraintlayout/core/widgets/Helper;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mIds")]
	protected IList<int>? MIds
	{
		get
		{
			return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mIds.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mIds.[I", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mMap")]
	protected IDictionary? MMap
	{
		get
		{
			return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("mMap.Ljava/util/HashMap;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JavaDictionary.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mMap.Ljava/util/HashMap;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mReferenceIds")]
	protected string? MReferenceIds
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mReferenceIds.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("mReferenceIds.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mReferenceTags")]
	protected string? MReferenceTags
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mReferenceTags.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("mReferenceTags.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mUseViewMeasure")]
	protected bool MUseViewMeasure
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mUseViewMeasure.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mUseViewMeasure.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("myContext")]
	protected Context? MyContext
	{
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceFields.GetObjectValue("myContext.Landroid/content/Context;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("myContext.Landroid/content/Context;", this, new JniObjectReference(num));
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

	protected ConstraintHelper(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ConstraintHelper(Context? context)
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
	public unsafe ConstraintHelper(Context? context, IAttributeSet? attrs)
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
	public unsafe ConstraintHelper(Context? context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetAddView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			constraintHelper.AddView(view);
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

	[Register("addView", "(Landroid/view/View;)V", "GetAddView_Landroid_view_View_Handler")]
	public unsafe virtual void AddView(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetApplyHelperParamsHandler()
	{
		return new global::_JniMarshal_PP_V(n_ApplyHelperParams);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyHelperParams(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyHelperParams();
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

	[Register("applyHelperParams", "()V", "GetApplyHelperParamsHandler")]
	public unsafe virtual void ApplyHelperParams()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("applyHelperParams.()V", this, null);
	}

	private static Delegate GetApplyLayoutFeaturesHandler()
	{
		return new global::_JniMarshal_PP_V(n_ApplyLayoutFeatures);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyLayoutFeatures(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyLayoutFeatures();
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

	[Register("applyLayoutFeatures", "()V", "GetApplyLayoutFeaturesHandler")]
	protected unsafe virtual void ApplyLayoutFeatures()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("applyLayoutFeatures.()V", this, null);
	}

	private static Delegate GetApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.ApplyLayoutFeatures(container);
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

	[Register("applyLayoutFeatures", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyLayoutFeatures_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	protected unsafe virtual void ApplyLayoutFeatures(ConstraintLayout? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyLayoutFeatures.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetApplyLayoutFeaturesInConstraintSet_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyLayoutFeaturesInConstraintSet_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyLayoutFeaturesInConstraintSet_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.ApplyLayoutFeaturesInConstraintSet(container);
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

	[Register("applyLayoutFeaturesInConstraintSet", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyLayoutFeaturesInConstraintSet_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	protected unsafe virtual void ApplyLayoutFeaturesInConstraintSet(ConstraintLayout? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyLayoutFeaturesInConstraintSet.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetContainsId_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_ContainsId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ContainsId_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainsId(id) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("containsId", "(I)Z", "GetContainsId_IHandler")]
	public unsafe virtual bool ContainsId(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsId.(I)Z", this, ptr);
	}

	private static Delegate GetGetReferencedIdsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetReferencedIds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetReferencedIds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetReferencedIds());
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

	[Register("getReferencedIds", "()[I", "GetGetReferencedIdsHandler")]
	public unsafe virtual int[]? GetReferencedIds()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getReferencedIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetGetViews_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetViews_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViews_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_layout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout layout = Java.Lang.Object.GetObject<ConstraintLayout>(native_layout, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(constraintHelper.GetViews(layout));
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

	[Register("getViews", "(Landroidx/constraintlayout/widget/ConstraintLayout;)[Landroid/view/View;", "GetGetViews_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	protected unsafe virtual View[]? GetViews(ConstraintLayout? layout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			return (View[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getViews.(Landroidx/constraintlayout/widget/ConstraintLayout;)[Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(View));
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetIndexFromId_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_IndexFromId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_IndexFromId_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndexFromId(id);
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

	[Register("indexFromId", "(I)I", "GetIndexFromId_IHandler")]
	public unsafe virtual int IndexFromId(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeVirtualInt32Method("indexFromId.(I)I", this, ptr);
	}

	private static Delegate GetInit_Landroid_util_AttributeSet_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Init_Landroid_util_AttributeSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Init_Landroid_util_AttributeSet_(nint jnienv, nint native__this, nint native_attrs)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			constraintHelper.Init(attrs);
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

	[Register("init", "(Landroid/util/AttributeSet;)V", "GetInit_Landroid_util_AttributeSet_Handler")]
	protected unsafe virtual void Init(IAttributeSet? attrs)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("init.(Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(attrs);
		}
	}

	[Register("isChildOfHelper", "(Landroid/view/View;)Z", "")]
	public unsafe static bool IsChildOfHelper(View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isChildOfHelper.(Landroid/view/View;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	private static Delegate GetLoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_core_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_LoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_core_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_core_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_constraint, nint native_child, nint native_layoutParams, nint native_mapIdToWidget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet.Constraint constraint = Java.Lang.Object.GetObject<ConstraintSet.Constraint>(native_constraint, JniHandleOwnership.DoNotTransfer);
			HelperWidget child = Java.Lang.Object.GetObject<HelperWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout.LayoutParams layoutParams = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			SparseArray mapIdToWidget = Java.Lang.Object.GetObject<SparseArray>(native_mapIdToWidget, JniHandleOwnership.DoNotTransfer);
			constraintHelper.LoadParameters(constraint, child, layoutParams, mapIdToWidget);
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

	[Register("loadParameters", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Landroidx/constraintlayout/core/widgets/HelperWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", "GetLoadParameters_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Landroidx_constraintlayout_core_widgets_HelperWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler")]
	public unsafe virtual void LoadParameters(ConstraintSet.Constraint? constraint, HelperWidget? child, ConstraintLayout.LayoutParams? layoutParams, SparseArray? mapIdToWidget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(constraint?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(mapIdToWidget?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("loadParameters.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Landroidx/constraintlayout/core/widgets/HelperWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraint);
			GC.KeepAlive(child);
			GC.KeepAlive(layoutParams);
			GC.KeepAlive(mapIdToWidget);
		}
	}

	private static Delegate GetOnDraw_Landroid_graphics_Canvas_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnDraw_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDraw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			constraintHelper.OnDraw(canvas);
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

	[Register("onDraw", "(Landroid/graphics/Canvas;)V", "GetOnDraw_Landroid_graphics_Canvas_Handler")]
	public new unsafe virtual void OnDraw(Canvas canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	private static Delegate GetRemoveView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_RemoveView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_RemoveView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return constraintHelper.RemoveView(view);
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

	[Register("removeView", "(Landroid/view/View;)I", "GetRemoveView_Landroid_view_View_Handler")]
	public unsafe virtual int RemoveView(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("removeView.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetResolveRtl_Landroidx_constraintlayout_core_widgets_ConstraintWidget_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_ResolveRtl_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResolveRtl_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Z(nint jnienv, nint native__this, nint native_widget, sbyte native_isRtl)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			bool isRtl = native_isRtl != 0;
			constraintHelper.ResolveRtl(widget, isRtl);
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

	[Register("resolveRtl", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Z)V", "GetResolveRtl_Landroidx_constraintlayout_core_widgets_ConstraintWidget_ZHandler")]
	public unsafe virtual void ResolveRtl(ConstraintWidget? widget, bool isRtl)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(isRtl ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("resolveRtl.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetSetIds_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIds_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIds_Ljava_lang_String_(nint jnienv, nint native__this, nint native_idList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string ids = JNIEnv.GetString(native_idList, JniHandleOwnership.DoNotTransfer);
			constraintHelper.SetIds(ids);
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

	[Register("setIds", "(Ljava/lang/String;)V", "GetSetIds_Ljava_lang_String_Handler")]
	protected unsafe virtual void SetIds(string? idList)
	{
		nint num = JNIEnv.NewString(idList);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIds.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetReferenceTags_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetReferenceTags_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetReferenceTags_Ljava_lang_String_(nint jnienv, nint native__this, nint native_tagList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string referenceTags = JNIEnv.GetString(native_tagList, JniHandleOwnership.DoNotTransfer);
			constraintHelper.SetReferenceTags(referenceTags);
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

	[Register("setReferenceTags", "(Ljava/lang/String;)V", "GetSetReferenceTags_Ljava_lang_String_Handler")]
	protected unsafe virtual void SetReferenceTags(string? tagList)
	{
		nint num = JNIEnv.NewString(tagList);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setReferenceTags.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetReferencedIds_arrayIHandler()
	{
		return new global::_JniMarshal_PPL_V(n_SetReferencedIds_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetReferencedIds_arrayI(nint jnienv, nint native__this, nint native_ids)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_ids, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintHelper.SetReferencedIds(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ids);
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

	[Register("setReferencedIds", "([I)V", "GetSetReferencedIds_arrayIHandler")]
	public unsafe virtual void SetReferencedIds(int[]? ids)
	{
		nint num = JNIEnv.NewArray(ids);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setReferencedIds.([I)V", this, ptr);
		}
		finally
		{
			if (ids != null)
			{
				JNIEnv.CopyArray(num, ids);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(ids);
		}
	}

	private static Delegate GetUpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePostConstraints(container);
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

	[Register("updatePostConstraints", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePostConstraints_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void UpdatePostConstraints(ConstraintLayout? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updatePostConstraints.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetUpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePostLayout(container);
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

	[Register("updatePostLayout", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePostLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void UpdatePostLayout(ConstraintLayout? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updatePostLayout.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetUpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePostMeasure(container);
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

	[Register("updatePostMeasure", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePostMeasure_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void UpdatePostMeasure(ConstraintLayout? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updatePostMeasure.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetUpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePreDraw(container);
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

	[Register("updatePreDraw", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePreDraw_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void UpdatePreDraw(ConstraintLayout? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updatePreDraw.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetUpdatePreLayout_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_widgets_Helper_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_UpdatePreLayout_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_widgets_Helper_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdatePreLayout_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_widgets_Helper_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_container, nint native_helper, nint native_map)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer container = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_container, JniHandleOwnership.DoNotTransfer);
			IHelper helper = Java.Lang.Object.GetObject<IHelper>(native_helper, JniHandleOwnership.DoNotTransfer);
			SparseArray map = Java.Lang.Object.GetObject<SparseArray>(native_map, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePreLayout(container, helper, map);
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

	[Register("updatePreLayout", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/core/widgets/Helper;Landroid/util/SparseArray;)V", "GetUpdatePreLayout_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_core_widgets_Helper_Landroid_util_SparseArray_Handler")]
	public unsafe virtual void UpdatePreLayout(ConstraintWidgetContainer? container, IHelper? helper, SparseArray? map)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((helper == null) ? IntPtr.Zero : ((Java.Lang.Object)helper).Handle);
			ptr[2] = new JniArgumentValue(map?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updatePreLayout.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/core/widgets/Helper;Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
			GC.KeepAlive(helper);
			GC.KeepAlive(map);
		}
	}

	private static Delegate GetUpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintHelper? constraintHelper = Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout container = Java.Lang.Object.GetObject<ConstraintLayout>(native_container, JniHandleOwnership.DoNotTransfer);
			constraintHelper.UpdatePreLayout(container);
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

	[Register("updatePreLayout", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetUpdatePreLayout_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void UpdatePreLayout(ConstraintLayout? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updatePreLayout.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetValidateParamsHandler()
	{
		return new global::_JniMarshal_PP_V(n_ValidateParams);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ValidateParams(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValidateParams();
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

	[Register("validateParams", "()V", "GetValidateParamsHandler")]
	public unsafe virtual void ValidateParams()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("validateParams.()V", this, null);
	}
}

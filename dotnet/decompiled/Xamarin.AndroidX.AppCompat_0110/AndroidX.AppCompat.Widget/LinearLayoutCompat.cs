using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Widget;

[Register("androidx/appcompat/widget/LinearLayoutCompat", DoNotGenerateAcw = true)]
public class LinearLayoutCompat : ViewGroup
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/widget/LinearLayoutCompat", typeof(LinearLayoutCompat));

	private static Delegate? cb_isBaselineAligned_IsBaselineAligned_Z;

	private static Delegate? cb_setBaselineAligned_SetBaselineAligned_Z_V;

	private static Delegate? cb_getBaselineAlignedChildIndex_GetBaselineAlignedChildIndex_I;

	private static Delegate? cb_setBaselineAlignedChildIndex_SetBaselineAlignedChildIndex_I_V;

	private static Delegate? cb_getDividerDrawable_GetDividerDrawable_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setDividerDrawable_SetDividerDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getDividerPadding_GetDividerPadding_I;

	private static Delegate? cb_setDividerPadding_SetDividerPadding_I_V;

	private static Delegate? cb_getDividerWidth_GetDividerWidth_I;

	private static Delegate? cb_getGravity_GetGravity_I;

	private static Delegate? cb_setGravity_SetGravity_I_V;

	private static Delegate? cb_isMeasureWithLargestChildEnabled_IsMeasureWithLargestChildEnabled_Z;

	private static Delegate? cb_setMeasureWithLargestChildEnabled_SetMeasureWithLargestChildEnabled_Z_V;

	private static Delegate? cb_getOrientation_GetOrientation_I;

	private static Delegate? cb_setOrientation_SetOrientation_I_V;

	private static Delegate? cb_getShowDividers_GetShowDividers_I;

	private static Delegate? cb_setShowDividers_SetShowDividers_I_V;

	private static Delegate? cb_getWeightSum_GetWeightSum_F;

	private static Delegate? cb_setWeightSum_SetWeightSum_F_V;

	private static Delegate? cb_hasDividerBeforeChildAt_HasDividerBeforeChildAt_I_Z;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_setHorizontalGravity_SetHorizontalGravity_I_V;

	private static Delegate? cb_setVerticalGravity_SetVerticalGravity_I_V;

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

	public unsafe virtual bool BaselineAligned
	{
		[Register("isBaselineAligned", "()Z", "GetIsBaselineAlignedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isBaselineAligned.()Z", this, null);
		}
		[Register("setBaselineAligned", "(Z)V", "GetSetBaselineAligned_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBaselineAligned.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int BaselineAlignedChildIndex
	{
		[Register("getBaselineAlignedChildIndex", "()I", "GetGetBaselineAlignedChildIndexHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBaselineAlignedChildIndex.()I", this, null);
		}
		[Register("setBaselineAlignedChildIndex", "(I)V", "GetSetBaselineAlignedChildIndex_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBaselineAlignedChildIndex.(I)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? DividerDrawable
	{
		[Register("getDividerDrawable", "()Landroid/graphics/drawable/Drawable;", "GetGetDividerDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDividerDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setDividerDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetDividerDrawable_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDividerDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int DividerPadding
	{
		[Register("getDividerPadding", "()I", "GetGetDividerPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDividerPadding.()I", this, null);
		}
		[Register("setDividerPadding", "(I)V", "GetSetDividerPadding_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDividerPadding.(I)V", this, ptr);
		}
	}

	public unsafe virtual int DividerWidth
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getDividerWidth", "()I", "GetGetDividerWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDividerWidth.()I", this, null);
		}
	}

	public unsafe virtual int Gravity
	{
		[Register("getGravity", "()I", "GetGetGravityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getGravity.()I", this, null);
		}
		[Register("setGravity", "(I)V", "GetSetGravity_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGravity.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool MeasureWithLargestChildEnabled
	{
		[Register("isMeasureWithLargestChildEnabled", "()Z", "GetIsMeasureWithLargestChildEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMeasureWithLargestChildEnabled.()Z", this, null);
		}
		[Register("setMeasureWithLargestChildEnabled", "(Z)V", "GetSetMeasureWithLargestChildEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasureWithLargestChildEnabled.(Z)V", this, ptr);
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

	public unsafe virtual int ShowDividers
	{
		[Register("getShowDividers", "()I", "GetGetShowDividersHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShowDividers.()I", this, null);
		}
		[Register("setShowDividers", "(I)V", "GetSetShowDividers_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShowDividers.(I)V", this, ptr);
		}
	}

	public unsafe virtual float WeightSum
	{
		[Register("getWeightSum", "()F", "GetGetWeightSumHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getWeightSum.()F", this, null);
		}
		[Register("setWeightSum", "(F)V", "GetSetWeightSum_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setWeightSum.(F)V", this, ptr);
		}
	}

	protected LinearLayoutCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe LinearLayoutCompat(Context context)
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
	public unsafe LinearLayoutCompat(Context context, IAttributeSet? attrs)
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
	public unsafe LinearLayoutCompat(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetIsBaselineAlignedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsBaselineAligned);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsBaselineAligned(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BaselineAligned ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetBaselineAligned_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetBaselineAligned_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBaselineAligned_Z(nint jnienv, nint native__this, sbyte native_baselineAligned)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutCompat? linearLayoutCompat = Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool baselineAligned = native_baselineAligned != 0;
			linearLayoutCompat.BaselineAligned = baselineAligned;
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

	private static Delegate GetGetBaselineAlignedChildIndexHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBaselineAlignedChildIndex);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBaselineAlignedChildIndex(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BaselineAlignedChildIndex;
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

	private static Delegate GetSetBaselineAlignedChildIndex_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBaselineAlignedChildIndex_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBaselineAlignedChildIndex_I(nint jnienv, nint native__this, int i)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BaselineAlignedChildIndex = i;
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

	private static Delegate GetGetDividerDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDividerDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDividerDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DividerDrawable);
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

	private static Delegate GetSetDividerDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDividerDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDividerDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_divider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutCompat? linearLayoutCompat = Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable dividerDrawable = Java.Lang.Object.GetObject<Drawable>(native_divider, JniHandleOwnership.DoNotTransfer);
			linearLayoutCompat.DividerDrawable = dividerDrawable;
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

	private static Delegate GetGetDividerPaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDividerPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDividerPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DividerPadding;
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

	private static Delegate GetSetDividerPadding_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDividerPadding_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDividerPadding_I(nint jnienv, nint native__this, int padding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DividerPadding = padding;
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

	private static Delegate GetGetDividerWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDividerWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDividerWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DividerWidth;
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

	private static Delegate GetGetGravityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetGravity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetGravity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Gravity;
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

	private static Delegate GetSetGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGravity_I(nint jnienv, nint native__this, int gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Gravity = gravity;
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

	private static Delegate GetIsMeasureWithLargestChildEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsMeasureWithLargestChildEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsMeasureWithLargestChildEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasureWithLargestChildEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetMeasureWithLargestChildEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetMeasureWithLargestChildEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMeasureWithLargestChildEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LinearLayoutCompat? linearLayoutCompat = Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool measureWithLargestChildEnabled = native_enabled != 0;
			linearLayoutCompat.MeasureWithLargestChildEnabled = measureWithLargestChildEnabled;
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
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
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
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
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

	private static Delegate GetGetShowDividersHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShowDividers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShowDividers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowDividers;
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

	private static Delegate GetSetShowDividers_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShowDividers_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowDividers_I(nint jnienv, nint native__this, int showDividers)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowDividers = showDividers;
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

	private static Delegate GetGetWeightSumHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetWeightSum);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetWeightSum(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WeightSum;
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

	private static Delegate GetSetWeightSum_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetWeightSum_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWeightSum_F(nint jnienv, nint native__this, float weightSum)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WeightSum = weightSum;
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

	private static Delegate GetHasDividerBeforeChildAt_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_HasDividerBeforeChildAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasDividerBeforeChildAt_I(nint jnienv, nint native__this, int childIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDividerBeforeChildAt(childIndex) ? ((sbyte)1) : ((sbyte)0);
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
	[Register("hasDividerBeforeChildAt", "(I)Z", "GetHasDividerBeforeChildAt_IHandler")]
	protected unsafe virtual bool HasDividerBeforeChildAt(int childIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(childIndex);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDividerBeforeChildAt.(I)Z", this, ptr);
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
			LinearLayoutCompat? linearLayoutCompat = Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			linearLayoutCompat.OnLayout(changed, l, t, r, b);
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

	private static Delegate GetSetHorizontalGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHorizontalGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalGravity_I(nint jnienv, nint native__this, int horizontalGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalGravity(horizontalGravity);
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

	[Register("setHorizontalGravity", "(I)V", "GetSetHorizontalGravity_IHandler")]
	public unsafe virtual void SetHorizontalGravity(int horizontalGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(horizontalGravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalGravity.(I)V", this, ptr);
	}

	private static Delegate GetSetVerticalGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVerticalGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalGravity_I(nint jnienv, nint native__this, int verticalGravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LinearLayoutCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalGravity(verticalGravity);
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

	[Register("setVerticalGravity", "(I)V", "GetSetVerticalGravity_IHandler")]
	public unsafe virtual void SetVerticalGravity(int verticalGravity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(verticalGravity);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalGravity.(I)V", this, ptr);
	}
}

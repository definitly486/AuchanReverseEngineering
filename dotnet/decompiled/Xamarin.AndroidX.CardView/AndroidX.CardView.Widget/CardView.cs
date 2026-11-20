using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.CardView.Widget;

[Register("androidx/cardview/widget/CardView", DoNotGenerateAcw = true)]
public class CardView : FrameLayout
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/cardview/widget/CardView", typeof(CardView));

	private static Delegate? cb_getCardBackgroundColor_GetCardBackgroundColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setCardBackgroundColor_SetCardBackgroundColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getCardElevation_GetCardElevation_F;

	private static Delegate? cb_setCardElevation_SetCardElevation_F_V;

	private static Delegate? cb_getContentPaddingBottom_GetContentPaddingBottom_I;

	private static Delegate? cb_getContentPaddingLeft_GetContentPaddingLeft_I;

	private static Delegate? cb_getContentPaddingRight_GetContentPaddingRight_I;

	private static Delegate? cb_getContentPaddingTop_GetContentPaddingTop_I;

	private static Delegate? cb_getMaxCardElevation_GetMaxCardElevation_F;

	private static Delegate? cb_setMaxCardElevation_SetMaxCardElevation_F_V;

	private static Delegate? cb_getPreventCornerOverlap_GetPreventCornerOverlap_Z;

	private static Delegate? cb_setPreventCornerOverlap_SetPreventCornerOverlap_Z_V;

	private static Delegate? cb_getRadius_GetRadius_F;

	private static Delegate? cb_setRadius_SetRadius_F_V;

	private static Delegate? cb_getUseCompatPadding_GetUseCompatPadding_Z;

	private static Delegate? cb_setUseCompatPadding_SetUseCompatPadding_Z_V;

	private static Delegate? cb_setCardBackgroundColor_SetCardBackgroundColor_I_V;

	private static Delegate? cb_setContentPadding_SetContentPadding_IIII_V;

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

	public unsafe virtual ColorStateList CardBackgroundColor
	{
		[Register("getCardBackgroundColor", "()Landroid/content/res/ColorStateList;", "GetGetCardBackgroundColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCardBackgroundColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCardBackgroundColor", "(Landroid/content/res/ColorStateList;)V", "GetSetCardBackgroundColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCardBackgroundColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual float CardElevation
	{
		[Register("getCardElevation", "()F", "GetGetCardElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCardElevation.()F", this, null);
		}
		[Register("setCardElevation", "(F)V", "GetSetCardElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCardElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual int ContentPaddingBottom
	{
		[Register("getContentPaddingBottom", "()I", "GetGetContentPaddingBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingBottom.()I", this, null);
		}
	}

	public unsafe virtual int ContentPaddingLeft
	{
		[Register("getContentPaddingLeft", "()I", "GetGetContentPaddingLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingLeft.()I", this, null);
		}
	}

	public unsafe virtual int ContentPaddingRight
	{
		[Register("getContentPaddingRight", "()I", "GetGetContentPaddingRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingRight.()I", this, null);
		}
	}

	public unsafe virtual int ContentPaddingTop
	{
		[Register("getContentPaddingTop", "()I", "GetGetContentPaddingTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentPaddingTop.()I", this, null);
		}
	}

	public unsafe virtual float MaxCardElevation
	{
		[Register("getMaxCardElevation", "()F", "GetGetMaxCardElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMaxCardElevation.()F", this, null);
		}
		[Register("setMaxCardElevation", "(F)V", "GetSetMaxCardElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxCardElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool PreventCornerOverlap
	{
		[Register("getPreventCornerOverlap", "()Z", "GetGetPreventCornerOverlapHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getPreventCornerOverlap.()Z", this, null);
		}
		[Register("setPreventCornerOverlap", "(Z)V", "GetSetPreventCornerOverlap_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPreventCornerOverlap.(Z)V", this, ptr);
		}
	}

	public unsafe virtual float Radius
	{
		[Register("getRadius", "()F", "GetGetRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRadius.()F", this, null);
		}
		[Register("setRadius", "(F)V", "GetSetRadius_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRadius.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool UseCompatPadding
	{
		[Register("getUseCompatPadding", "()Z", "GetGetUseCompatPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getUseCompatPadding.()Z", this, null);
		}
		[Register("setUseCompatPadding", "(Z)V", "GetSetUseCompatPadding_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUseCompatPadding.(Z)V", this, ptr);
		}
	}

	protected CardView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe CardView(Context context)
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
	public unsafe CardView(Context context, IAttributeSet? attrs)
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
	public unsafe CardView(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetCardBackgroundColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCardBackgroundColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCardBackgroundColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CardBackgroundColor);
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

	private static Delegate GetSetCardBackgroundColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCardBackgroundColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCardBackgroundColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CardView? cardView = Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList cardBackgroundColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			cardView.CardBackgroundColor = cardBackgroundColor;
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

	private static Delegate GetGetCardElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetCardElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCardElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CardElevation;
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

	private static Delegate GetSetCardElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetCardElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCardElevation_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CardElevation = elevation;
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

	private static Delegate GetGetContentPaddingBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentPaddingBottom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentPaddingBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingBottom;
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

	private static Delegate GetGetContentPaddingLeftHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentPaddingLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentPaddingLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingLeft;
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

	private static Delegate GetGetContentPaddingRightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentPaddingRight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentPaddingRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingRight;
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

	private static Delegate GetGetContentPaddingTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentPaddingTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentPaddingTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentPaddingTop;
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

	private static Delegate GetGetMaxCardElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetMaxCardElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetMaxCardElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxCardElevation;
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

	private static Delegate GetSetMaxCardElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetMaxCardElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxCardElevation_F(nint jnienv, nint native__this, float maxElevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxCardElevation = maxElevation;
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

	private static Delegate GetGetPreventCornerOverlapHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetPreventCornerOverlap);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetPreventCornerOverlap(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreventCornerOverlap ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetPreventCornerOverlap_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetPreventCornerOverlap_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPreventCornerOverlap_Z(nint jnienv, nint native__this, sbyte native_preventCornerOverlap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CardView? cardView = Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool preventCornerOverlap = native_preventCornerOverlap != 0;
			cardView.PreventCornerOverlap = preventCornerOverlap;
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

	private static Delegate GetGetRadiusHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetRadius);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRadius(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Radius;
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

	private static Delegate GetSetRadius_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetRadius_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRadius_F(nint jnienv, nint native__this, float radius)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Radius = radius;
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

	private static Delegate GetGetUseCompatPaddingHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetUseCompatPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetUseCompatPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCompatPadding ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetUseCompatPadding_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUseCompatPadding_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUseCompatPadding_Z(nint jnienv, nint native__this, sbyte native_useCompatPadding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CardView? cardView = Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool useCompatPadding = native_useCompatPadding != 0;
			cardView.UseCompatPadding = useCompatPadding;
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

	private static Delegate GetSetCardBackgroundColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCardBackgroundColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCardBackgroundColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCardBackgroundColor(color);
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

	[Register("setCardBackgroundColor", "(I)V", "GetSetCardBackgroundColor_IHandler")]
	public unsafe virtual void SetCardBackgroundColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCardBackgroundColor.(I)V", this, ptr);
	}

	private static Delegate GetSetContentPadding_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_SetContentPadding_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentPadding_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CardView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentPadding(left, top, right, bottom);
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

	[Register("setContentPadding", "(IIII)V", "GetSetContentPadding_IIIIHandler")]
	public unsafe virtual void SetContentPadding(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentPadding.(IIII)V", this, ptr);
	}
}

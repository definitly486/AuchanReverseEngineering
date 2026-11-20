using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using AndroidX.ConstraintLayout.Core.State;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion;

[Register("androidx/constraintlayout/core/motion/MotionWidget", DoNotGenerateAcw = true)]
public class MotionWidget : Java.Lang.Object, ITypedValues, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/MotionWidget", typeof(MotionWidget));

	private static Delegate? cb_getAlpha_GetAlpha_F;

	private static Delegate? cb_getBottom_GetBottom_I;

	private static Delegate? cb_getCustomAttributeNames_GetCustomAttributeNames_Ljava_util_Set_;

	private static Delegate? cb_getHeight_GetHeight_I;

	private static Delegate? cb_getLeft_GetLeft_I;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getParent_GetParent_Landroidx_constraintlayout_core_motion_MotionWidget_;

	private static Delegate? cb_getPivotX_GetPivotX_F;

	private static Delegate? cb_setPivotX_SetPivotX_F_V;

	private static Delegate? cb_getPivotY_GetPivotY_F;

	private static Delegate? cb_setPivotY_SetPivotY_F_V;

	private static Delegate? cb_getRight_GetRight_I;

	private static Delegate? cb_getRotationX_GetRotationX_F;

	private static Delegate? cb_setRotationX_SetRotationX_F_V;

	private static Delegate? cb_getRotationY_GetRotationY_F;

	private static Delegate? cb_setRotationY_SetRotationY_F_V;

	private static Delegate? cb_getRotationZ_GetRotationZ_F;

	private static Delegate? cb_setRotationZ_SetRotationZ_F_V;

	private static Delegate? cb_getScaleX_GetScaleX_F;

	private static Delegate? cb_setScaleX_SetScaleX_F_V;

	private static Delegate? cb_getScaleY_GetScaleY_F;

	private static Delegate? cb_setScaleY_SetScaleY_F_V;

	private static Delegate? cb_getTop_GetTop_I;

	private static Delegate? cb_getTranslationX_GetTranslationX_F;

	private static Delegate? cb_setTranslationX_SetTranslationX_F_V;

	private static Delegate? cb_getTranslationY_GetTranslationY_F;

	private static Delegate? cb_setTranslationY_SetTranslationY_F_V;

	private static Delegate? cb_getTranslationZ_GetTranslationZ_F;

	private static Delegate? cb_setTranslationZ_SetTranslationZ_F_V;

	private static Delegate? cb_getVisibility_GetVisibility_I;

	private static Delegate? cb_setVisibility_SetVisibility_I_V;

	private static Delegate? cb_getWidgetFrame_GetWidgetFrame_Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_getWidth_GetWidth_I;

	private static Delegate? cb_findViewById_FindViewById_I_Landroidx_constraintlayout_core_motion_MotionWidget_;

	private static Delegate? cb_getCustomAttribute_GetCustomAttribute_Ljava_lang_String__Landroidx_constraintlayout_core_motion_CustomVariable_;

	private static Delegate? cb_getId_GetId_Ljava_lang_String__I;

	private static Delegate? cb_getValueAttributes_GetValueAttributes_I_F;

	private static Delegate? cb_getX_GetX_I;

	private static Delegate? cb_getY_GetY_I;

	private static Delegate? cb_layout_Layout_IIII_V;

	private static Delegate? cb_setBounds_SetBounds_IIII_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_IZ_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_IF_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_II_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_ILjava_lang_String__V;

	private static Delegate? cb_setInterpolatedValue_SetInterpolatedValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayF_V;

	private static Delegate? cb_setValue_SetValue_IZ_Z;

	private static Delegate? cb_setValue_SetValue_IF_Z;

	private static Delegate? cb_setValue_SetValue_II_Z;

	private static Delegate? cb_setValue_SetValue_ILjava_lang_String__Z;

	private static Delegate? cb_setValueAttributes_SetValueAttributes_IF_Z;

	private static Delegate? cb_setValueMotion_SetValueMotion_IF_Z;

	private static Delegate? cb_setValueMotion_SetValueMotion_II_Z;

	private static Delegate? cb_setValueMotion_SetValueMotion_ILjava_lang_String__Z;

	private static Delegate? cb_updateMotion_UpdateMotion_Landroidx_constraintlayout_core_motion_utils_TypedValues__V;

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

	public unsafe virtual float Alpha
	{
		[Register("getAlpha", "()F", "GetGetAlphaHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getAlpha.()F", this, null);
		}
	}

	public unsafe virtual int Bottom
	{
		[Register("getBottom", "()I", "GetGetBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBottom.()I", this, null);
		}
	}

	public unsafe virtual ICollection<string>? CustomAttributeNames
	{
		[Register("getCustomAttributeNames", "()Ljava/util/Set;", "GetGetCustomAttributeNamesHandler")]
		get
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomAttributeNames.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.()I", this, null);
		}
	}

	public unsafe virtual int Left
	{
		[Register("getLeft", "()I", "GetGetLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLeft.()I", this, null);
		}
	}

	public unsafe virtual string? Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual MotionWidget? Parent
	{
		[Register("getParent", "()Landroidx/constraintlayout/core/motion/MotionWidget;", "GetGetParentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MotionWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParent.()Landroidx/constraintlayout/core/motion/MotionWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float PivotX
	{
		[Register("getPivotX", "()F", "GetGetPivotXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getPivotX.()F", this, null);
		}
		[Register("setPivotX", "(F)V", "GetSetPivotX_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPivotX.(F)V", this, ptr);
		}
	}

	public unsafe virtual float PivotY
	{
		[Register("getPivotY", "()F", "GetGetPivotYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getPivotY.()F", this, null);
		}
		[Register("setPivotY", "(F)V", "GetSetPivotY_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPivotY.(F)V", this, ptr);
		}
	}

	public unsafe virtual int Right
	{
		[Register("getRight", "()I", "GetGetRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRight.()I", this, null);
		}
	}

	public unsafe virtual float RotationX
	{
		[Register("getRotationX", "()F", "GetGetRotationXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRotationX.()F", this, null);
		}
		[Register("setRotationX", "(F)V", "GetSetRotationX_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationX.(F)V", this, ptr);
		}
	}

	public unsafe virtual float RotationY
	{
		[Register("getRotationY", "()F", "GetGetRotationYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRotationY.()F", this, null);
		}
		[Register("setRotationY", "(F)V", "GetSetRotationY_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationY.(F)V", this, ptr);
		}
	}

	public unsafe virtual float RotationZ
	{
		[Register("getRotationZ", "()F", "GetGetRotationZHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRotationZ.()F", this, null);
		}
		[Register("setRotationZ", "(F)V", "GetSetRotationZ_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationZ.(F)V", this, ptr);
		}
	}

	public unsafe virtual float ScaleX
	{
		[Register("getScaleX", "()F", "GetGetScaleXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getScaleX.()F", this, null);
		}
		[Register("setScaleX", "(F)V", "GetSetScaleX_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleX.(F)V", this, ptr);
		}
	}

	public unsafe virtual float ScaleY
	{
		[Register("getScaleY", "()F", "GetGetScaleYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getScaleY.()F", this, null);
		}
		[Register("setScaleY", "(F)V", "GetSetScaleY_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleY.(F)V", this, ptr);
		}
	}

	public unsafe virtual int Top
	{
		[Register("getTop", "()I", "GetGetTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTop.()I", this, null);
		}
	}

	public unsafe virtual float TranslationX
	{
		[Register("getTranslationX", "()F", "GetGetTranslationXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTranslationX.()F", this, null);
		}
		[Register("setTranslationX", "(F)V", "GetSetTranslationX_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationX.(F)V", this, ptr);
		}
	}

	public unsafe virtual float TranslationY
	{
		[Register("getTranslationY", "()F", "GetGetTranslationYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTranslationY.()F", this, null);
		}
		[Register("setTranslationY", "(F)V", "GetSetTranslationY_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationY.(F)V", this, ptr);
		}
	}

	public unsafe virtual float TranslationZ
	{
		[Register("getTranslationZ", "()F", "GetGetTranslationZHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTranslationZ.()F", this, null);
		}
		[Register("setTranslationZ", "(F)V", "GetSetTranslationZ_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationZ.(F)V", this, ptr);
		}
	}

	public unsafe virtual int Visibility
	{
		[Register("getVisibility", "()I", "GetGetVisibilityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVisibility.()I", this, null);
		}
		[Register("setVisibility", "(I)V", "GetSetVisibility_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibility.(I)V", this, ptr);
		}
	}

	public unsafe virtual WidgetFrame? WidgetFrame
	{
		[Register("getWidgetFrame", "()Landroidx/constraintlayout/core/state/WidgetFrame;", "GetGetWidgetFrameHandler")]
		get
		{
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWidgetFrame.()Landroidx/constraintlayout/core/state/WidgetFrame;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Width
	{
		[Register("getWidth", "()I", "GetGetWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.()I", this, null);
		}
	}

	protected MotionWidget(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MotionWidget()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/state/WidgetFrame;)V", "")]
	public unsafe MotionWidget(WidgetFrame? f)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(f?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/state/WidgetFrame;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/state/WidgetFrame;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(f);
		}
	}

	private static Delegate GetGetAlphaHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetAlpha);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetAlpha(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Alpha;
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

	private static Delegate GetGetBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBottom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Bottom;
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

	private static Delegate GetGetCustomAttributeNamesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCustomAttributeNames);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCustomAttributeNames(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaSet<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomAttributeNames);
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

	private static Delegate GetGetHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
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

	private static Delegate GetGetLeftHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Left;
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

	private static Delegate GetGetNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	private static Delegate GetGetParentHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
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

	private static Delegate GetGetPivotXHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetPivotX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetPivotX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PivotX;
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

	private static Delegate GetSetPivotX_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetPivotX_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPivotX_F(nint jnienv, nint native__this, float px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PivotX = px;
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

	private static Delegate GetGetPivotYHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetPivotY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetPivotY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PivotY;
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

	private static Delegate GetSetPivotY_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetPivotY_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPivotY_F(nint jnienv, nint native__this, float py)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PivotY = py;
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

	private static Delegate GetGetRightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Right;
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

	private static Delegate GetGetRotationXHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetRotationX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRotationX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationX;
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

	private static Delegate GetSetRotationX_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetRotationX_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRotationX_F(nint jnienv, nint native__this, float rotationX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationX = rotationX;
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

	private static Delegate GetGetRotationYHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetRotationY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRotationY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationY;
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

	private static Delegate GetSetRotationY_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetRotationY_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRotationY_F(nint jnienv, nint native__this, float rotationY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationY = rotationY;
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

	private static Delegate GetGetRotationZHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetRotationZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetRotationZ(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationZ;
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

	private static Delegate GetSetRotationZ_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetRotationZ_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRotationZ_F(nint jnienv, nint native__this, float rotationZ)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationZ = rotationZ;
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

	private static Delegate GetGetScaleXHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetScaleX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetScaleX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaleX;
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

	private static Delegate GetSetScaleX_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetScaleX_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScaleX_F(nint jnienv, nint native__this, float scaleX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaleX = scaleX;
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

	private static Delegate GetGetScaleYHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetScaleY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetScaleY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaleY;
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

	private static Delegate GetSetScaleY_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetScaleY_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScaleY_F(nint jnienv, nint native__this, float scaleY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaleY = scaleY;
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

	private static Delegate GetGetTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Top;
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

	private static Delegate GetGetTranslationXHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTranslationX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTranslationX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationX;
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

	private static Delegate GetSetTranslationX_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetTranslationX_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationX_F(nint jnienv, nint native__this, float translationX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationX = translationX;
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

	private static Delegate GetGetTranslationYHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTranslationY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTranslationY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationY;
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

	private static Delegate GetSetTranslationY_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetTranslationY_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationY_F(nint jnienv, nint native__this, float translationY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationY = translationY;
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

	private static Delegate GetGetTranslationZHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTranslationZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTranslationZ(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationZ;
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

	private static Delegate GetSetTranslationZ_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetTranslationZ_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationZ_F(nint jnienv, nint native__this, float tz)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationZ = tz;
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

	private static Delegate GetGetVisibilityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility;
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

	private static Delegate GetSetVisibility_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVisibility_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibility_I(nint jnienv, nint native__this, int visibility)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility = visibility;
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

	private static Delegate GetGetWidgetFrameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetWidgetFrame);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetWidgetFrame(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WidgetFrame);
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

	private static Delegate GetGetWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
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

	private static Delegate GetFindViewById_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindViewById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindViewById_I(nint jnienv, nint native__this, int mTransformPivotTarget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewById(mTransformPivotTarget));
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

	[Register("findViewById", "(I)Landroidx/constraintlayout/core/motion/MotionWidget;", "GetFindViewById_IHandler")]
	public unsafe virtual MotionWidget? FindViewById(int mTransformPivotTarget)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mTransformPivotTarget);
		return Java.Lang.Object.GetObject<MotionWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewById.(I)Landroidx/constraintlayout/core/motion/MotionWidget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetCustomAttribute_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetCustomAttribute_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCustomAttribute_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionWidget.GetCustomAttribute(name));
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

	[Register("getCustomAttribute", "(Ljava/lang/String;)Landroidx/constraintlayout/core/motion/CustomVariable;", "GetGetCustomAttribute_Ljava_lang_String_Handler")]
	public unsafe virtual CustomVariable? GetCustomAttribute(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CustomVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomAttribute.(Ljava/lang/String;)Landroidx/constraintlayout/core/motion/CustomVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetId_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetId_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return motionWidget.GetId(name);
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

	[Register("getId", "(Ljava/lang/String;)I", "GetGetId_Ljava_lang_String_Handler")]
	public unsafe virtual int GetId(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetValueAttributes_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetValueAttributes_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetValueAttributes_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetValueAttributes(id);
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

	[Register("getValueAttributes", "(I)F", "GetGetValueAttributes_IHandler")]
	public unsafe virtual float GetValueAttributes(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getValueAttributes.(I)F", this, ptr);
	}

	private static Delegate GetGetXHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetX();
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

	[Register("getX", "()I", "GetGetXHandler")]
	public unsafe virtual int GetX()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("getX.()I", this, null);
	}

	private static Delegate GetGetYHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetY();
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

	[Register("getY", "()I", "GetGetYHandler")]
	public unsafe virtual int GetY()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("getY.()I", this, null);
	}

	private static Delegate GetLayout_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_Layout_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Layout_IIII(nint jnienv, nint native__this, int l, int t, int r, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Layout(l, t, r, b);
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

	[Register("layout", "(IIII)V", "GetLayout_IIIIHandler")]
	public unsafe virtual void Layout(int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(l);
		ptr[1] = new JniArgumentValue(t);
		ptr[2] = new JniArgumentValue(r);
		ptr[3] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeVirtualVoidMethod("layout.(IIII)V", this, ptr);
	}

	private static Delegate GetSetBounds_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_SetBounds_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBounds_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBounds(left, top, right, bottom);
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

	[Register("setBounds", "(IIII)V", "GetSetBounds_IIIIHandler")]
	public unsafe virtual void SetBounds(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBounds.(IIII)V", this, ptr);
	}

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_IZHandler()
	{
		return new global::_JniMarshal_PPLIB_V(n_SetCustomAttribute_Ljava_lang_String_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_IZ(nint jnienv, nint native__this, nint native_name, int type, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			motionWidget.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;IZ)V", "GetSetCustomAttribute_Ljava_lang_String_IZHandler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, bool value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;IZ)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_IFHandler()
	{
		return new _JniMarshal_PPLIF_V(n_SetCustomAttribute_Ljava_lang_String_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_IF(nint jnienv, nint native__this, nint native_name, int type, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			motionWidget.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;IF)V", "GetSetCustomAttribute_Ljava_lang_String_IFHandler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, float value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;IF)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_IIHandler()
	{
		return new global::_JniMarshal_PPLII_V(n_SetCustomAttribute_Ljava_lang_String_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_II(nint jnienv, nint native__this, nint native_name, int type, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			motionWidget.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;II)V", "GetSetCustomAttribute_Ljava_lang_String_IIHandler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, int value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetCustomAttribute_Ljava_lang_String_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_SetCustomAttribute_Ljava_lang_String_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomAttribute_Ljava_lang_String_ILjava_lang_String_(nint jnienv, nint native__this, nint native_name, int type, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			motionWidget.SetCustomAttribute(name, type, value);
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

	[Register("setCustomAttribute", "(Ljava/lang/String;ILjava/lang/String;)V", "GetSetCustomAttribute_Ljava_lang_String_ILjava_lang_String_Handler")]
	public unsafe virtual void SetCustomAttribute(string? name, int type, string? value)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomAttribute.(Ljava/lang/String;ILjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetSetInterpolatedValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayFHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetInterpolatedValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInterpolatedValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayF(nint jnienv, nint native__this, nint native_attribute, nint native_mCache)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CustomAttribute attribute = Java.Lang.Object.GetObject<CustomAttribute>(native_attribute, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_mCache, JniHandleOwnership.DoNotTransfer, typeof(float));
			motionWidget.SetInterpolatedValue(attribute, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_mCache);
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

	[Register("setInterpolatedValue", "(Landroidx/constraintlayout/core/motion/CustomAttribute;[F)V", "GetSetInterpolatedValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayFHandler")]
	public unsafe virtual void SetInterpolatedValue(CustomAttribute? attribute, float[]? mCache)
	{
		nint num = JNIEnv.NewArray(mCache);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(attribute?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolatedValue.(Landroidx/constraintlayout/core/motion/CustomAttribute;[F)V", this, ptr);
		}
		finally
		{
			if (mCache != null)
			{
				JNIEnv.CopyArray(num, mCache);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(attribute);
			GC.KeepAlive(mCache);
		}
	}

	private static Delegate GetSetValue_IZHandler()
	{
		return new global::_JniMarshal_PPIB_B(n_SetValue_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IZ(nint jnienv, nint native__this, int id, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			return motionWidget.SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(IZ)Z", "GetSetValue_IZHandler")]
	public unsafe virtual bool SetValue(int id, bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(IZ)Z", this, ptr);
	}

	private static Delegate GetSetValue_IFHandler()
	{
		return new _JniMarshal_PPIF_B(n_SetValue_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_IF(nint jnienv, nint native__this, int id, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(IF)Z", "GetSetValue_IFHandler")]
	public unsafe virtual bool SetValue(int id, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(IF)Z", this, ptr);
	}

	private static Delegate GetSetValue_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_SetValue_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_II(nint jnienv, nint native__this, int id, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(II)Z", "GetSetValue_IIHandler")]
	public unsafe virtual bool SetValue(int id, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(II)Z", this, ptr);
	}

	private static Delegate GetSetValue_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_SetValue_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_ILjava_lang_String_(nint jnienv, nint native__this, int id, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return motionWidget.SetValue(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(ILjava/lang/String;)Z", "GetSetValue_ILjava_lang_String_Handler")]
	public unsafe virtual bool SetValue(int id, string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetValueAttributes_IFHandler()
	{
		return new _JniMarshal_PPIF_B(n_SetValueAttributes_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValueAttributes_IF(nint jnienv, nint native__this, int id, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValueAttributes(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValueAttributes", "(IF)Z", "GetSetValueAttributes_IFHandler")]
	public unsafe virtual bool SetValueAttributes(int id, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValueAttributes.(IF)Z", this, ptr);
	}

	private static Delegate GetSetValueMotion_IFHandler()
	{
		return new _JniMarshal_PPIF_B(n_SetValueMotion_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValueMotion_IF(nint jnienv, nint native__this, int id, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValueMotion(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValueMotion", "(IF)Z", "GetSetValueMotion_IFHandler")]
	public unsafe virtual bool SetValueMotion(int id, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValueMotion.(IF)Z", this, ptr);
	}

	private static Delegate GetSetValueMotion_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_SetValueMotion_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValueMotion_II(nint jnienv, nint native__this, int id, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetValueMotion(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValueMotion", "(II)Z", "GetSetValueMotion_IIHandler")]
	public unsafe virtual bool SetValueMotion(int id, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(value);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValueMotion.(II)Z", this, ptr);
	}

	private static Delegate GetSetValueMotion_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_SetValueMotion_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValueMotion_ILjava_lang_String_(nint jnienv, nint native__this, int id, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return motionWidget.SetValueMotion(id, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValueMotion", "(ILjava/lang/String;)Z", "GetSetValueMotion_ILjava_lang_String_Handler")]
	public unsafe virtual bool SetValueMotion(int id, string? value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValueMotion.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetUpdateMotion_Landroidx_constraintlayout_core_motion_utils_TypedValues_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateMotion_Landroidx_constraintlayout_core_motion_utils_TypedValues_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateMotion_Landroidx_constraintlayout_core_motion_utils_TypedValues_(nint jnienv, nint native__this, nint native_toUpdate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionWidget? motionWidget = Java.Lang.Object.GetObject<MotionWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITypedValues toUpdate = Java.Lang.Object.GetObject<ITypedValues>(native_toUpdate, JniHandleOwnership.DoNotTransfer);
			motionWidget.UpdateMotion(toUpdate);
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

	[Register("updateMotion", "(Landroidx/constraintlayout/core/motion/utils/TypedValues;)V", "GetUpdateMotion_Landroidx_constraintlayout_core_motion_utils_TypedValues_Handler")]
	public unsafe virtual void UpdateMotion(ITypedValues? toUpdate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((toUpdate == null) ? IntPtr.Zero : ((Java.Lang.Object)toUpdate).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateMotion.(Landroidx/constraintlayout/core/motion/utils/TypedValues;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(toUpdate);
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

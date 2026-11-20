using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.ConstraintLayout.Core.Motion;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using AndroidX.ConstraintLayout.Core.Parser;
using AndroidX.ConstraintLayout.Core.Widgets;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.State;

[Register("androidx/constraintlayout/core/state/WidgetFrame", DoNotGenerateAcw = true)]
public class WidgetFrame : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/state/WidgetFrame", typeof(WidgetFrame));

	private static Delegate? cb_getCustomAttributeNames_GetCustomAttributeNames_Ljava_util_Set_;

	private static Delegate? cb_getId_GetId_Ljava_lang_String_;

	private static Delegate? cb_isDefaultTransform_IsDefaultTransform_Z;

	private static Delegate? cb_getMotionProperties_GetMotionProperties_Landroidx_constraintlayout_core_motion_utils_TypedBundle_;

	private static Delegate? cb_addCustomColor_AddCustomColor_Ljava_lang_String_I_V;

	private static Delegate? cb_addCustomFloat_AddCustomFloat_Ljava_lang_String_F_V;

	private static Delegate? cb_centerX_CenterX_F;

	private static Delegate? cb_centerY_CenterY_F;

	private static Delegate? cb_containsCustom_ContainsCustom_Ljava_lang_String__Z;

	private static Delegate? cb_getCustomAttribute_GetCustomAttribute_Ljava_lang_String__Landroidx_constraintlayout_core_motion_CustomVariable_;

	private static Delegate? cb_getCustomColor_GetCustomColor_Ljava_lang_String__I;

	private static Delegate? cb_getCustomFloat_GetCustomFloat_Ljava_lang_String__F;

	private static Delegate? cb_height_Height_I;

	private static Delegate? cb_serialize_Serialize_Ljava_lang_StringBuilder__Ljava_lang_StringBuilder_;

	private static Delegate? cb_serialize_Serialize_Ljava_lang_StringBuilder_Z_Ljava_lang_StringBuilder_;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_IZ_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_IF_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_II_V;

	private static Delegate? cb_setCustomAttribute_SetCustomAttribute_Ljava_lang_String_ILjava_lang_String__V;

	private static Delegate? cb_setCustomValue_SetCustomValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayF_V;

	private static Delegate? cb_setValue_SetValue_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement__Z;

	private static Delegate? cb_update_Update_Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_update_Update_Landroidx_constraintlayout_core_widgets_ConstraintWidget__Landroidx_constraintlayout_core_state_WidgetFrame_;

	private static Delegate? cb_updateAttributes_UpdateAttributes_Landroidx_constraintlayout_core_state_WidgetFrame__V;

	private static Delegate? cb_width_Width_I;

	[Register("alpha")]
	public float Alpha
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("alpha.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("alpha.F", this, value);
		}
	}

	[Register("bottom")]
	public int Bottom
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("bottom.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("bottom.I", this, value);
		}
	}

	[Register("interpolatedPos")]
	public float InterpolatedPos
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("interpolatedPos.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("interpolatedPos.F", this, value);
		}
	}

	[Register("left")]
	public int Left
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("left.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("left.I", this, value);
		}
	}

	[Register("name")]
	public string? Name
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("name.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("name.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("phone_orientation")]
	public static float PhoneOrientation
	{
		get
		{
			return _members.StaticFields.GetSingleValue("phone_orientation.F");
		}
		set
		{
			_members.StaticFields.SetValue("phone_orientation.F", value);
		}
	}

	[Register("pivotX")]
	public float PivotX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("pivotX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("pivotX.F", this, value);
		}
	}

	[Register("pivotY")]
	public float PivotY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("pivotY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("pivotY.F", this, value);
		}
	}

	[Register("right")]
	public int Right
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("right.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("right.I", this, value);
		}
	}

	[Register("rotationX")]
	public float RotationX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("rotationX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("rotationX.F", this, value);
		}
	}

	[Register("rotationY")]
	public float RotationY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("rotationY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("rotationY.F", this, value);
		}
	}

	[Register("rotationZ")]
	public float RotationZ
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("rotationZ.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("rotationZ.F", this, value);
		}
	}

	[Register("scaleX")]
	public float ScaleX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("scaleX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("scaleX.F", this, value);
		}
	}

	[Register("scaleY")]
	public float ScaleY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("scaleY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("scaleY.F", this, value);
		}
	}

	[Register("top")]
	public int Top
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("top.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("top.I", this, value);
		}
	}

	[Register("translationX")]
	public float TranslationX
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("translationX.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("translationX.F", this, value);
		}
	}

	[Register("translationY")]
	public float TranslationY
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("translationY.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("translationY.F", this, value);
		}
	}

	[Register("translationZ")]
	public float TranslationZ
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("translationZ.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("translationZ.F", this, value);
		}
	}

	[Register("visibility")]
	public int Visibility
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("visibility.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("visibility.I", this, value);
		}
	}

	[Register("widget")]
	public ConstraintWidget? Widget
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceFields.GetObjectValue("widget.Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("widget.Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, new JniObjectReference(num));
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

	public unsafe virtual ICollection<string>? CustomAttributeNames
	{
		[Register("getCustomAttributeNames", "()Ljava/util/Set;", "GetGetCustomAttributeNamesHandler")]
		get
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomAttributeNames.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsDefaultTransform
	{
		[Register("isDefaultTransform", "()Z", "GetIsDefaultTransformHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDefaultTransform.()Z", this, null);
		}
	}

	public unsafe virtual TypedBundle? MotionProperties
	{
		[Register("getMotionProperties", "()Landroidx/constraintlayout/core/motion/utils/TypedBundle;", "GetGetMotionPropertiesHandler")]
		get
		{
			return Java.Lang.Object.GetObject<TypedBundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMotionProperties.()Landroidx/constraintlayout/core/motion/utils/TypedBundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected WidgetFrame(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe WidgetFrame()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/state/WidgetFrame;)V", "")]
	public unsafe WidgetFrame(WidgetFrame? frame)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(frame?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/state/WidgetFrame;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/state/WidgetFrame;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(frame);
		}
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", "")]
	public unsafe WidgetFrame(ConstraintWidget? widget)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
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
			return JavaSet<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomAttributeNames);
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

	private static Delegate GetGetIdHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
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

	private static Delegate GetIsDefaultTransformHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDefaultTransform);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDefaultTransform(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDefaultTransform ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetMotionPropertiesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMotionProperties);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMotionProperties(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MotionProperties);
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

	private static Delegate GetAddCustomColor_Ljava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddCustomColor_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCustomColor_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_name, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			widgetFrame.AddCustomColor(name, color);
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

	[Register("addCustomColor", "(Ljava/lang/String;I)V", "GetAddCustomColor_Ljava_lang_String_IHandler")]
	public unsafe virtual void AddCustomColor(string? name, int color)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(color);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCustomColor.(Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetAddCustomFloat_Ljava_lang_String_FHandler()
	{
		return new global::_JniMarshal_PPLF_V(n_AddCustomFloat_Ljava_lang_String_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCustomFloat_Ljava_lang_String_F(nint jnienv, nint native__this, nint native_name, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			widgetFrame.AddCustomFloat(name, value);
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

	[Register("addCustomFloat", "(Ljava/lang/String;F)V", "GetAddCustomFloat_Ljava_lang_String_FHandler")]
	public unsafe virtual void AddCustomFloat(string? name, float value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCustomFloat.(Ljava/lang/String;F)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetCenterXHandler()
	{
		return new global::_JniMarshal_PP_F(n_CenterX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_CenterX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterX();
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

	[Register("centerX", "()F", "GetCenterXHandler")]
	public unsafe virtual float CenterX()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("centerX.()F", this, null);
	}

	private static Delegate GetCenterYHandler()
	{
		return new global::_JniMarshal_PP_F(n_CenterY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_CenterY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterY();
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

	[Register("centerY", "()F", "GetCenterYHandler")]
	public unsafe virtual float CenterY()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("centerY.()F", this, null);
	}

	private static Delegate GetContainsCustom_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ContainsCustom_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ContainsCustom_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return widgetFrame.ContainsCustom(name) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("containsCustom", "(Ljava/lang/String;)Z", "GetContainsCustom_Ljava_lang_String_Handler")]
	public unsafe virtual bool ContainsCustom(string name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsCustom.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
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
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(widgetFrame.GetCustomAttribute(name));
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

	private static Delegate GetGetCustomColor_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetCustomColor_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCustomColor_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return widgetFrame.GetCustomColor(name);
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

	[Register("getCustomColor", "(Ljava/lang/String;)I", "GetGetCustomColor_Ljava_lang_String_Handler")]
	public unsafe virtual int GetCustomColor(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCustomColor.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetCustomFloat_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_F(n_GetCustomFloat_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCustomFloat_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return widgetFrame.GetCustomFloat(name);
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

	[Register("getCustomFloat", "(Ljava/lang/String;)F", "GetGetCustomFloat_Ljava_lang_String_Handler")]
	public unsafe virtual float GetCustomFloat(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCustomFloat.(Ljava/lang/String;)F", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_Height);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Height(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height();
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

	[Register("height", "()I", "GetHeightHandler")]
	public unsafe virtual int Height()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("height.()I", this, null);
	}

	[Register("interpolate", "(IILandroidx/constraintlayout/core/state/WidgetFrame;Landroidx/constraintlayout/core/state/WidgetFrame;Landroidx/constraintlayout/core/state/WidgetFrame;Landroidx/constraintlayout/core/state/Transition;F)V", "")]
	public unsafe static void Interpolate(int parentWidth, int parentHeight, WidgetFrame? frame, WidgetFrame? start, WidgetFrame? end, Transition? transition, float progress)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(parentWidth);
			ptr[1] = new JniArgumentValue(parentHeight);
			ptr[2] = new JniArgumentValue(frame?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(start?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(end?.Handle ?? IntPtr.Zero);
			ptr[5] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(progress);
			_members.StaticMethods.InvokeVoidMethod("interpolate.(IILandroidx/constraintlayout/core/state/WidgetFrame;Landroidx/constraintlayout/core/state/WidgetFrame;Landroidx/constraintlayout/core/state/WidgetFrame;Landroidx/constraintlayout/core/state/Transition;F)V", ptr);
		}
		finally
		{
			GC.KeepAlive(frame);
			GC.KeepAlive(start);
			GC.KeepAlive(end);
			GC.KeepAlive(transition);
		}
	}

	private static Delegate GetSerialize_Ljava_lang_StringBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Serialize_Ljava_lang_StringBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Serialize_Ljava_lang_StringBuilder_(nint jnienv, nint native__this, nint native_ret)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StringBuilder ret = Java.Lang.Object.GetObject<StringBuilder>(native_ret, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(widgetFrame.Serialize(ret));
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

	[Register("serialize", "(Ljava/lang/StringBuilder;)Ljava/lang/StringBuilder;", "GetSerialize_Ljava_lang_StringBuilder_Handler")]
	public unsafe virtual StringBuilder? Serialize(StringBuilder? ret)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ret?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<StringBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("serialize.(Ljava/lang/StringBuilder;)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(ret);
		}
	}

	private static Delegate GetSerialize_Ljava_lang_StringBuilder_ZHandler()
	{
		return new global::_JniMarshal_PPLB_L(n_Serialize_Ljava_lang_StringBuilder_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Serialize_Ljava_lang_StringBuilder_Z(nint jnienv, nint native__this, nint native_ret, sbyte native_sendPhoneOrientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StringBuilder ret = Java.Lang.Object.GetObject<StringBuilder>(native_ret, JniHandleOwnership.DoNotTransfer);
			bool sendPhoneOrientation = native_sendPhoneOrientation != 0;
			return JNIEnv.ToLocalJniHandle(widgetFrame.Serialize(ret, sendPhoneOrientation));
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

	[Register("serialize", "(Ljava/lang/StringBuilder;Z)Ljava/lang/StringBuilder;", "GetSerialize_Ljava_lang_StringBuilder_ZHandler")]
	public unsafe virtual StringBuilder? Serialize(StringBuilder? ret, bool sendPhoneOrientation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(ret?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(sendPhoneOrientation ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<StringBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("serialize.(Ljava/lang/StringBuilder;Z)Ljava/lang/StringBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(ret);
		}
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
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			widgetFrame.SetCustomAttribute(name, type, value);
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
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			widgetFrame.SetCustomAttribute(name, type, value);
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
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			widgetFrame.SetCustomAttribute(name, type, value);
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
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			widgetFrame.SetCustomAttribute(name, type, value);
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

	private static Delegate GetSetCustomValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayFHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetCustomValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayF(nint jnienv, nint native__this, nint native_valueAt, nint native_mTempValues)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CustomAttribute valueAt = Java.Lang.Object.GetObject<CustomAttribute>(native_valueAt, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_mTempValues, JniHandleOwnership.DoNotTransfer, typeof(float));
			widgetFrame.SetCustomValue(valueAt, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_mTempValues);
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

	[Register("setCustomValue", "(Landroidx/constraintlayout/core/motion/CustomAttribute;[F)V", "GetSetCustomValue_Landroidx_constraintlayout_core_motion_CustomAttribute_arrayFHandler")]
	public unsafe virtual void SetCustomValue(CustomAttribute? valueAt, float[]? mTempValues)
	{
		nint num = JNIEnv.NewArray(mTempValues);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(valueAt?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomValue.(Landroidx/constraintlayout/core/motion/CustomAttribute;[F)V", this, ptr);
		}
		finally
		{
			if (mTempValues != null)
			{
				JNIEnv.CopyArray(num, mTempValues);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(valueAt);
			GC.KeepAlive(mTempValues);
		}
	}

	private static Delegate GetSetValue_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_SetValue_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetValue_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_(nint jnienv, nint native__this, nint native_key, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			CLElement value = Java.Lang.Object.GetObject<CLElement>(native_value, JniHandleOwnership.DoNotTransfer);
			return widgetFrame.SetValue(key, value) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setValue", "(Ljava/lang/String;Landroidx/constraintlayout/core/parser/CLElement;)Z", "GetSetValue_Ljava_lang_String_Landroidx_constraintlayout_core_parser_CLElement_Handler")]
	public unsafe virtual bool SetValue(string? key, CLElement? value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("setValue.(Ljava/lang/String;Landroidx/constraintlayout/core/parser/CLElement;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetUpdateHandler()
	{
		return new global::_JniMarshal_PP_L(n_Update);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Update(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Update());
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

	[Register("update", "()Landroidx/constraintlayout/core/state/WidgetFrame;", "GetUpdateHandler")]
	public unsafe virtual WidgetFrame? Update()
	{
		return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("update.()Landroidx/constraintlayout/core/state/WidgetFrame;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUpdate_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Update_Landroidx_constraintlayout_core_widgets_ConstraintWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Update_Landroidx_constraintlayout_core_widgets_ConstraintWidget_(nint jnienv, nint native__this, nint native_widget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(widgetFrame.Update(widget));
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

	[Register("update", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", "GetUpdate_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Handler")]
	public unsafe virtual WidgetFrame? Update(ConstraintWidget? widget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<WidgetFrame>(_members.InstanceMethods.InvokeVirtualObjectMethod("update.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;)Landroidx/constraintlayout/core/state/WidgetFrame;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}

	private static Delegate GetUpdateAttributes_Landroidx_constraintlayout_core_state_WidgetFrame_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateAttributes_Landroidx_constraintlayout_core_state_WidgetFrame_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateAttributes_Landroidx_constraintlayout_core_state_WidgetFrame_(nint jnienv, nint native__this, nint native_frame)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			WidgetFrame? widgetFrame = Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WidgetFrame frame = Java.Lang.Object.GetObject<WidgetFrame>(native_frame, JniHandleOwnership.DoNotTransfer);
			widgetFrame.UpdateAttributes(frame);
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

	[Register("updateAttributes", "(Landroidx/constraintlayout/core/state/WidgetFrame;)V", "GetUpdateAttributes_Landroidx_constraintlayout_core_state_WidgetFrame_Handler")]
	public unsafe virtual void UpdateAttributes(WidgetFrame? frame)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(frame?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateAttributes.(Landroidx/constraintlayout/core/state/WidgetFrame;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(frame);
		}
	}

	private static Delegate GetWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_Width);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Width(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<WidgetFrame>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width();
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

	[Register("width", "()I", "GetWidthHandler")]
	public unsafe virtual int Width()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("width.()I", this, null);
	}
}

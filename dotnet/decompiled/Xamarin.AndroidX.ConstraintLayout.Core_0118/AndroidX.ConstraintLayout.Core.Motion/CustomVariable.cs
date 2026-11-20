using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion;

[Register("androidx/constraintlayout/core/motion/CustomVariable", DoNotGenerateAcw = true)]
public class CustomVariable : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/CustomVariable", typeof(CustomVariable));

	private static Delegate? cb_getBooleanValue_GetBooleanValue_Z;

	private static Delegate? cb_setBooleanValue_SetBooleanValue_Z_V;

	private static Delegate? cb_getColorValue_GetColorValue_I;

	private static Delegate? cb_getFloatValue_GetFloatValue_F;

	private static Delegate? cb_setFloatValue_SetFloatValue_F_V;

	private static Delegate? cb_getIntegerValue_GetIntegerValue_I;

	private static Delegate? cb_isContinuous_IsContinuous_Z;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getStringValue_GetStringValue_Ljava_lang_String_;

	private static Delegate? cb_setStringValue_SetStringValue_Ljava_lang_String__V;

	private static Delegate? cb_getType_GetType_I;

	private static Delegate? cb_getValueToInterpolate_GetValueToInterpolate_F;

	private static Delegate? cb_applyToWidget_ApplyToWidget_Landroidx_constraintlayout_core_motion_MotionWidget__V;

	private static Delegate? cb_copy_Copy_Landroidx_constraintlayout_core_motion_CustomVariable_;

	private static Delegate? cb_diff_Diff_Landroidx_constraintlayout_core_motion_CustomVariable__Z;

	private static Delegate? cb_getInterpolatedColor_GetInterpolatedColor_arrayF_I;

	private static Delegate? cb_getValuesToInterpolate_GetValuesToInterpolate_arrayF_V;

	private static Delegate? cb_numberOfInterpolatedValues_NumberOfInterpolatedValues_I;

	private static Delegate? cb_setIntValue_SetIntValue_I_V;

	private static Delegate? cb_setInterpolatedValue_SetInterpolatedValue_Landroidx_constraintlayout_core_motion_MotionWidget_arrayF_V;

	private static Delegate? cb_setValue_SetValue_arrayF_V;

	private static Delegate? cb_setValue_SetValue_Ljava_lang_Object__V;

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

	public unsafe virtual bool BooleanValue
	{
		[Register("getBooleanValue", "()Z", "GetGetBooleanValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getBooleanValue.()Z", this, null);
		}
		[Register("setBooleanValue", "(Z)V", "GetSetBooleanValue_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBooleanValue.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ColorValue
	{
		[Register("getColorValue", "()I", "GetGetColorValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getColorValue.()I", this, null);
		}
	}

	public unsafe virtual float FloatValue
	{
		[Register("getFloatValue", "()F", "GetGetFloatValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getFloatValue.()F", this, null);
		}
		[Register("setFloatValue", "(F)V", "GetSetFloatValue_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFloatValue.(F)V", this, ptr);
		}
	}

	public unsafe virtual int IntegerValue
	{
		[Register("getIntegerValue", "()I", "GetGetIntegerValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getIntegerValue.()I", this, null);
		}
	}

	public unsafe virtual bool IsContinuous
	{
		[Register("isContinuous", "()Z", "GetIsContinuousHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isContinuous.()Z", this, null);
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

	public unsafe virtual string? StringValue
	{
		[Register("getStringValue", "()Ljava/lang/String;", "GetGetStringValueHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStringValue.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStringValue", "(Ljava/lang/String;)V", "GetSetStringValue_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStringValue.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual int Type
	{
		[Register("getType", "()I", "GetGetTypeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getType.()I", this, null);
		}
	}

	public unsafe virtual float ValueToInterpolate
	{
		[Register("getValueToInterpolate", "()F", "GetGetValueToInterpolateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getValueToInterpolate.()F", this, null);
		}
	}

	protected CustomVariable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/motion/CustomVariable;)V", "")]
	public unsafe CustomVariable(CustomVariable? c)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/motion/CustomVariable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/motion/CustomVariable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(c);
		}
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/motion/CustomVariable;Ljava/lang/Object;)V", "")]
	public unsafe CustomVariable(CustomVariable? source, Java.Lang.Object? value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/motion/CustomVariable;Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/motion/CustomVariable;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(source);
			GC.KeepAlive(value);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;I)V", "")]
	public unsafe CustomVariable(string? name, int attributeType)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(attributeType);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;IZ)V", "")]
	public unsafe CustomVariable(string? name, int type, bool value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;IZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;IZ)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;IF)V", "")]
	public unsafe CustomVariable(string? name, int type, float value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;IF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;IF)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;II)V", "")]
	public unsafe CustomVariable(string? name, int type, int value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(value);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;ILjava/lang/Object;)V", "")]
	public unsafe CustomVariable(string? name, int attributeType, Java.Lang.Object? value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(attributeType);
			ptr[2] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;ILjava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;ILjava/lang/String;)V", "")]
	public unsafe CustomVariable(string? name, int type, string? value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(type);
			ptr[2] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;ILjava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;ILjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetGetBooleanValueHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetBooleanValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetBooleanValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BooleanValue ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetBooleanValue_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetBooleanValue_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBooleanValue_Z(nint jnienv, nint native__this, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool booleanValue = native_value != 0;
			customVariable.BooleanValue = booleanValue;
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

	private static Delegate GetGetColorValueHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetColorValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColorValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColorValue;
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

	private static Delegate GetGetFloatValueHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetFloatValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloatValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FloatValue;
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

	private static Delegate GetSetFloatValue_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetFloatValue_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFloatValue_F(nint jnienv, nint native__this, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FloatValue = value;
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

	private static Delegate GetGetIntegerValueHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetIntegerValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetIntegerValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntegerValue;
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

	private static Delegate GetIsContinuousHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsContinuous);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsContinuous(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsContinuous ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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

	private static Delegate GetGetStringValueHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStringValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStringValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StringValue);
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

	private static Delegate GetSetStringValue_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStringValue_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStringValue_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string stringValue = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			customVariable.StringValue = stringValue;
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

	private static Delegate GetGetTypeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type;
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

	private static Delegate GetGetValueToInterpolateHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetValueToInterpolate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetValueToInterpolate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueToInterpolate;
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

	private static Delegate GetApplyToWidget_Landroidx_constraintlayout_core_motion_MotionWidget_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyToWidget_Landroidx_constraintlayout_core_motion_MotionWidget_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyToWidget_Landroidx_constraintlayout_core_motion_MotionWidget_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget view = Java.Lang.Object.GetObject<MotionWidget>(native_view, JniHandleOwnership.DoNotTransfer);
			customVariable.ApplyToWidget(view);
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

	[Register("applyToWidget", "(Landroidx/constraintlayout/core/motion/MotionWidget;)V", "GetApplyToWidget_Landroidx_constraintlayout_core_motion_MotionWidget_Handler")]
	public unsafe virtual void ApplyToWidget(MotionWidget? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToWidget.(Landroidx/constraintlayout/core/motion/MotionWidget;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("colorString", "(I)Ljava/lang/String;", "")]
	public unsafe static string? ColorString(int v)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(v);
		return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("colorString.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCopyHandler()
	{
		return new global::_JniMarshal_PP_L(n_Copy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Copy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Copy());
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

	[Register("copy", "()Landroidx/constraintlayout/core/motion/CustomVariable;", "GetCopyHandler")]
	public unsafe virtual CustomVariable? Copy()
	{
		return Java.Lang.Object.GetObject<CustomVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("copy.()Landroidx/constraintlayout/core/motion/CustomVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetDiff_Landroidx_constraintlayout_core_motion_CustomVariable_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Diff_Landroidx_constraintlayout_core_motion_CustomVariable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Diff_Landroidx_constraintlayout_core_motion_CustomVariable_(nint jnienv, nint native__this, nint native_customAttribute)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CustomVariable customAttribute = Java.Lang.Object.GetObject<CustomVariable>(native_customAttribute, JniHandleOwnership.DoNotTransfer);
			return customVariable.Diff(customAttribute) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("diff", "(Landroidx/constraintlayout/core/motion/CustomVariable;)Z", "GetDiff_Landroidx_constraintlayout_core_motion_CustomVariable_Handler")]
	public unsafe virtual bool Diff(CustomVariable? customAttribute)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(customAttribute?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("diff.(Landroidx/constraintlayout/core/motion/CustomVariable;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(customAttribute);
		}
	}

	private static Delegate GetGetInterpolatedColor_arrayFHandler()
	{
		return new global::_JniMarshal_PPL_I(n_GetInterpolatedColor_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInterpolatedColor_arrayF(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			int interpolatedColor = customVariable.GetInterpolatedColor(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
			}
			return interpolatedColor;
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

	[Register("getInterpolatedColor", "([F)I", "GetGetInterpolatedColor_arrayFHandler")]
	public unsafe virtual int GetInterpolatedColor(float[]? value)
	{
		nint num = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInterpolatedColor.([F)I", this, ptr);
		}
		finally
		{
			if (value != null)
			{
				JNIEnv.CopyArray(num, value);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetGetValuesToInterpolate_arrayFHandler()
	{
		return new global::_JniMarshal_PPL_V(n_GetValuesToInterpolate_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetValuesToInterpolate_arrayF(nint jnienv, nint native__this, nint native_ret)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_ret, JniHandleOwnership.DoNotTransfer, typeof(float));
			customVariable.GetValuesToInterpolate(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ret);
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

	[Register("getValuesToInterpolate", "([F)V", "GetGetValuesToInterpolate_arrayFHandler")]
	public unsafe virtual void GetValuesToInterpolate(float[]? ret)
	{
		nint num = JNIEnv.NewArray(ret);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getValuesToInterpolate.([F)V", this, ptr);
		}
		finally
		{
			if (ret != null)
			{
				JNIEnv.CopyArray(num, ret);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(ret);
		}
	}

	[Register("hsvToRgb", "(FFF)I", "")]
	public unsafe static int HsvToRgb(float hue, float saturation, float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(hue);
		ptr[1] = new JniArgumentValue(saturation);
		ptr[2] = new JniArgumentValue(value);
		return _members.StaticMethods.InvokeInt32Method("hsvToRgb.(FFF)I", ptr);
	}

	private static Delegate GetNumberOfInterpolatedValuesHandler()
	{
		return new global::_JniMarshal_PP_I(n_NumberOfInterpolatedValues);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NumberOfInterpolatedValues(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumberOfInterpolatedValues();
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

	[Register("numberOfInterpolatedValues", "()I", "GetNumberOfInterpolatedValuesHandler")]
	public unsafe virtual int NumberOfInterpolatedValues()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("numberOfInterpolatedValues.()I", this, null);
	}

	[Register("rgbaTocColor", "(FFFF)I", "")]
	public unsafe static int RgbaTocColor(float r, float g, float b, float a)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(r);
		ptr[1] = new JniArgumentValue(g);
		ptr[2] = new JniArgumentValue(b);
		ptr[3] = new JniArgumentValue(a);
		return _members.StaticMethods.InvokeInt32Method("rgbaTocColor.(FFFF)I", ptr);
	}

	private static Delegate GetSetIntValue_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIntValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIntValue_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIntValue(value);
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

	[Register("setIntValue", "(I)V", "GetSetIntValue_IHandler")]
	public unsafe virtual void SetIntValue(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setIntValue.(I)V", this, ptr);
	}

	private static Delegate GetSetInterpolatedValue_Landroidx_constraintlayout_core_motion_MotionWidget_arrayFHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetInterpolatedValue_Landroidx_constraintlayout_core_motion_MotionWidget_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInterpolatedValue_Landroidx_constraintlayout_core_motion_MotionWidget_arrayF(nint jnienv, nint native__this, nint native_view, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionWidget view = Java.Lang.Object.GetObject<MotionWidget>(native_view, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			customVariable.SetInterpolatedValue(view, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
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

	[Register("setInterpolatedValue", "(Landroidx/constraintlayout/core/motion/MotionWidget;[F)V", "GetSetInterpolatedValue_Landroidx_constraintlayout_core_motion_MotionWidget_arrayFHandler")]
	public unsafe virtual void SetInterpolatedValue(MotionWidget? view, float[]? value)
	{
		nint num = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolatedValue.(Landroidx/constraintlayout/core/motion/MotionWidget;[F)V", this, ptr);
		}
		finally
		{
			if (value != null)
			{
				JNIEnv.CopyArray(num, value);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetSetValue_arrayFHandler()
	{
		return new global::_JniMarshal_PPL_V(n_SetValue_arrayF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValue_arrayF(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			customVariable.SetValue(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
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

	[Register("setValue", "([F)V", "GetSetValue_arrayFHandler")]
	public unsafe virtual void SetValue(float[]? value)
	{
		nint num = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValue.([F)V", this, ptr);
		}
		finally
		{
			if (value != null)
			{
				JNIEnv.CopyArray(num, value);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetSetValue_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetValue_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValue_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CustomVariable? customVariable = Java.Lang.Object.GetObject<CustomVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			customVariable.SetValue(value);
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

	[Register("setValue", "(Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetValue(Java.Lang.Object? value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValue.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}
}

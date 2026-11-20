using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintAttribute", DoNotGenerateAcw = true)]
public class ConstraintAttribute : Java.Lang.Object
{
	[Register("androidx/constraintlayout/widget/ConstraintAttribute$AttributeType", DoNotGenerateAcw = true)]
	public sealed class AttributeType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintAttribute$AttributeType", typeof(AttributeType));

		[Register("BOOLEAN_TYPE")]
		public static AttributeType? BooleanType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("BOOLEAN_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("COLOR_DRAWABLE_TYPE")]
		public static AttributeType? ColorDrawableType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("COLOR_DRAWABLE_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("COLOR_TYPE")]
		public static AttributeType? ColorType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("COLOR_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DIMENSION_TYPE")]
		public static AttributeType? DimensionType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("DIMENSION_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FLOAT_TYPE")]
		public static AttributeType? FloatType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("FLOAT_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INT_TYPE")]
		public static AttributeType? IntType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("INT_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("REFERENCE_TYPE")]
		public static AttributeType? ReferenceType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("REFERENCE_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRING_TYPE")]
		public static AttributeType? StringType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("STRING_TYPE.Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal AttributeType(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", "")]
		public unsafe static AttributeType? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AttributeType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", "")]
		public unsafe static AttributeType[]? Values()
		{
			return (AttributeType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AttributeType));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintAttribute", typeof(ConstraintAttribute));

	private static Delegate? cb_getColorValue_GetColorValue_I;

	private static Delegate? cb_setColorValue_SetColorValue_I_V;

	private static Delegate? cb_getFloatValue_GetFloatValue_F;

	private static Delegate? cb_setFloatValue_SetFloatValue_F_V;

	private static Delegate? cb_getIntegerValue_GetIntegerValue_I;

	private static Delegate? cb_isBooleanValue_IsBooleanValue_Z;

	private static Delegate? cb_isContinuous_IsContinuous_Z;

	private static Delegate? cb_isMethod_IsMethod_Z;

	private static Delegate? cb_getName_GetName_Ljava_lang_String_;

	private static Delegate? cb_getStringValue_GetStringValue_Ljava_lang_String_;

	private static Delegate? cb_setStringValue_SetStringValue_Ljava_lang_String__V;

	private static Delegate? cb_getType_GetType_Landroidx_constraintlayout_widget_ConstraintAttribute_AttributeType_;

	private static Delegate? cb_getValueToInterpolate_GetValueToInterpolate_F;

	private static Delegate? cb_applyCustom_ApplyCustom_Landroid_view_View__V;

	private static Delegate? cb_diff_Diff_Landroidx_constraintlayout_widget_ConstraintAttribute__Z;

	private static Delegate? cb_getValuesToInterpolate_GetValuesToInterpolate_arrayF_V;

	private static Delegate? cb_numberOfInterpolatedValues_NumberOfInterpolatedValues_I;

	private static Delegate? cb_setIntValue_SetIntValue_I_V;

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

	public unsafe virtual int ColorValue
	{
		[Register("getColorValue", "()I", "GetGetColorValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getColorValue.()I", this, null);
		}
		[Register("setColorValue", "(I)V", "GetSetColorValue_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorValue.(I)V", this, ptr);
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

	public unsafe virtual bool IsBooleanValue
	{
		[Register("isBooleanValue", "()Z", "GetIsBooleanValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isBooleanValue.()Z", this, null);
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

	public unsafe virtual bool IsMethod
	{
		[Register("isMethod", "()Z", "GetIsMethodHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMethod.()Z", this, null);
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

	public unsafe virtual AttributeType? Type
	{
		[Register("getType", "()Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", "GetGetTypeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AttributeType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	protected ConstraintAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/widget/ConstraintAttribute;Ljava/lang/Object;)V", "")]
	public unsafe ConstraintAttribute(ConstraintAttribute? source, Java.Lang.Object? value)
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
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/widget/ConstraintAttribute;Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/widget/ConstraintAttribute;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(source);
			GC.KeepAlive(value);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;)V", "")]
	public unsafe ConstraintAttribute(string? name, AttributeType? attributeType)
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
			ptr[1] = new JniArgumentValue(attributeType?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(attributeType);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;Ljava/lang/Object;Z)V", "")]
	public unsafe ConstraintAttribute(string? name, AttributeType? attributeType, Java.Lang.Object? value, bool method)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(attributeType?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(method ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;Ljava/lang/Object;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/widget/ConstraintAttribute$AttributeType;Ljava/lang/Object;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(attributeType);
			GC.KeepAlive(value);
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
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColorValue;
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

	private static Delegate GetSetColorValue_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetColorValue_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorValue_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColorValue = value;
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
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FloatValue;
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
			Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FloatValue = value;
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
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IntegerValue;
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

	private static Delegate GetIsBooleanValueHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsBooleanValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsBooleanValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsBooleanValue ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsContinuous ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsMethodHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsMethod);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsMethod(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsMethod ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StringValue);
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
			ConstraintAttribute? constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string stringValue = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			constraintAttribute.StringValue = stringValue;
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
		return new global::_JniMarshal_PP_L(n_GetType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
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
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueToInterpolate;
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

	private static Delegate GetApplyCustom_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyCustom_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyCustom_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintAttribute? constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			constraintAttribute.ApplyCustom(view);
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

	[Register("applyCustom", "(Landroid/view/View;)V", "GetApplyCustom_Landroid_view_View_Handler")]
	public unsafe virtual void ApplyCustom(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyCustom.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetDiff_Landroidx_constraintlayout_widget_ConstraintAttribute_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Diff_Landroidx_constraintlayout_widget_ConstraintAttribute_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Diff_Landroidx_constraintlayout_widget_ConstraintAttribute_(nint jnienv, nint native__this, nint native_constraintAttribute)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintAttribute? constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAttribute constraintAttribute2 = Java.Lang.Object.GetObject<ConstraintAttribute>(native_constraintAttribute, JniHandleOwnership.DoNotTransfer);
			return constraintAttribute.Diff(constraintAttribute2) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("diff", "(Landroidx/constraintlayout/widget/ConstraintAttribute;)Z", "GetDiff_Landroidx_constraintlayout_widget_ConstraintAttribute_Handler")]
	public unsafe virtual bool Diff(ConstraintAttribute? constraintAttribute)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintAttribute?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("diff.(Landroidx/constraintlayout/widget/ConstraintAttribute;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintAttribute);
		}
	}

	[Register("extractAttributes", "(Ljava/util/HashMap;Landroid/view/View;)Ljava/util/HashMap;", "")]
	public unsafe static IDictionary<string, ConstraintAttribute>? ExtractAttributes(IDictionary<string, ConstraintAttribute>? @base, View? view)
	{
		nint num = JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(@base);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return JavaDictionary<string, ConstraintAttribute>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("extractAttributes.(Ljava/util/HashMap;Landroid/view/View;)Ljava/util/HashMap;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(@base);
			GC.KeepAlive(view);
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
			ConstraintAttribute? constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_ret, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintAttribute.GetValuesToInterpolate(array);
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
			return Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumberOfInterpolatedValues();
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

	[Register("parse", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;Ljava/util/HashMap;)V", "")]
	public unsafe static void Parse(Context? context, XmlReader? parser, IDictionary<string, ConstraintAttribute>? custom)
	{
		nint num = XmlReaderPullParser.ToLocalJniHandle(parser);
		nint num2 = JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(custom);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			_members.StaticMethods.InvokeVoidMethod("parse.(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;Ljava/util/HashMap;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(context);
			GC.KeepAlive(parser);
			GC.KeepAlive(custom);
		}
	}

	[Register("setAttributes", "(Landroid/view/View;Ljava/util/HashMap;)V", "")]
	public unsafe static void SetAttributes(View? view, IDictionary<string, ConstraintAttribute>? map)
	{
		nint num = JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(map);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.StaticMethods.InvokeVoidMethod("setAttributes.(Landroid/view/View;Ljava/util/HashMap;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(map);
		}
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
			Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIntValue(value);
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
			ConstraintAttribute? constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintAttribute.SetValue(array);
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
			ConstraintAttribute? constraintAttribute = Java.Lang.Object.GetObject<ConstraintAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			constraintAttribute.SetValue(value);
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

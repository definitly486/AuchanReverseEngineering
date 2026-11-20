using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion;

[Register("androidx/constraintlayout/core/motion/CustomAttribute", DoNotGenerateAcw = true)]
public class CustomAttribute : Java.Lang.Object
{
	[Register("androidx/constraintlayout/core/motion/CustomAttribute$AttributeType", DoNotGenerateAcw = true)]
	public sealed class AttributeType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/CustomAttribute$AttributeType", typeof(AttributeType));

		[Register("BOOLEAN_TYPE")]
		public static AttributeType? BooleanType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("BOOLEAN_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("COLOR_DRAWABLE_TYPE")]
		public static AttributeType? ColorDrawableType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("COLOR_DRAWABLE_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("COLOR_TYPE")]
		public static AttributeType? ColorType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("COLOR_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DIMENSION_TYPE")]
		public static AttributeType? DimensionType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("DIMENSION_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FLOAT_TYPE")]
		public static AttributeType? FloatType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("FLOAT_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("INT_TYPE")]
		public static AttributeType? IntType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("INT_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("REFERENCE_TYPE")]
		public static AttributeType? ReferenceType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("REFERENCE_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STRING_TYPE")]
		public static AttributeType? StringType => Java.Lang.Object.GetObject<AttributeType>(_members.StaticFields.GetObjectValue("STRING_TYPE.Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;", "")]
		public unsafe static AttributeType? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<AttributeType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;", "")]
		public unsafe static AttributeType[]? Values()
		{
			return (AttributeType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AttributeType));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/CustomAttribute", typeof(CustomAttribute));

	private static Delegate? cb_isContinuous_IsContinuous_Z;

	private static Delegate? cb_getType_GetType_Landroidx_constraintlayout_core_motion_CustomAttribute_AttributeType_;

	private static Delegate? cb_getValueToInterpolate_GetValueToInterpolate_F;

	private static Delegate? cb_diff_Diff_Landroidx_constraintlayout_core_motion_CustomAttribute__Z;

	private static Delegate? cb_getValuesToInterpolate_GetValuesToInterpolate_arrayF_V;

	private static Delegate? cb_numberOfInterpolatedValues_NumberOfInterpolatedValues_I;

	private static Delegate? cb_setColorValue_SetColorValue_I_V;

	private static Delegate? cb_setFloatValue_SetFloatValue_F_V;

	private static Delegate? cb_setIntValue_SetIntValue_I_V;

	private static Delegate? cb_setStringValue_SetStringValue_Ljava_lang_String__V;

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

	public unsafe virtual bool IsContinuous
	{
		[Register("isContinuous", "()Z", "GetIsContinuousHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isContinuous.()Z", this, null);
		}
	}

	public unsafe virtual AttributeType? Type
	{
		[Register("getType", "()Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;", "GetGetTypeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AttributeType>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	protected CustomAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/motion/CustomAttribute;Ljava/lang/Object;)V", "")]
	public unsafe CustomAttribute(CustomAttribute? source, Java.Lang.Object? value)
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
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/motion/CustomAttribute;Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/motion/CustomAttribute;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(source);
			GC.KeepAlive(value);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;)V", "")]
	public unsafe CustomAttribute(string? name, AttributeType? attributeType)
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
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(attributeType);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;Ljava/lang/Object;Z)V", "")]
	public unsafe CustomAttribute(string? name, AttributeType? attributeType, Java.Lang.Object? value, bool method)
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
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;Ljava/lang/Object;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/core/motion/CustomAttribute$AttributeType;Ljava/lang/Object;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(attributeType);
			GC.KeepAlive(value);
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
			return Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsContinuous ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
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
			return Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueToInterpolate;
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

	private static Delegate GetDiff_Landroidx_constraintlayout_core_motion_CustomAttribute_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Diff_Landroidx_constraintlayout_core_motion_CustomAttribute_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Diff_Landroidx_constraintlayout_core_motion_CustomAttribute_(nint jnienv, nint native__this, nint native_customAttribute)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CustomAttribute? customAttribute = Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CustomAttribute customAttribute2 = Java.Lang.Object.GetObject<CustomAttribute>(native_customAttribute, JniHandleOwnership.DoNotTransfer);
			return customAttribute.Diff(customAttribute2) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("diff", "(Landroidx/constraintlayout/core/motion/CustomAttribute;)Z", "GetDiff_Landroidx_constraintlayout_core_motion_CustomAttribute_Handler")]
	public unsafe virtual bool Diff(CustomAttribute? customAttribute)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(customAttribute?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("diff.(Landroidx/constraintlayout/core/motion/CustomAttribute;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(customAttribute);
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
			CustomAttribute? customAttribute = Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_ret, JniHandleOwnership.DoNotTransfer, typeof(float));
			customAttribute.GetValuesToInterpolate(array);
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
			return Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumberOfInterpolatedValues();
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
			Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetColorValue(value);
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

	[Register("setColorValue", "(I)V", "GetSetColorValue_IHandler")]
	public unsafe virtual void SetColorValue(int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setColorValue.(I)V", this, ptr);
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
			Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFloatValue(value);
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

	[Register("setFloatValue", "(F)V", "GetSetFloatValue_FHandler")]
	public unsafe virtual void SetFloatValue(float value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setFloatValue.(F)V", this, ptr);
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
			Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIntValue(value);
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
			CustomAttribute? customAttribute = Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string stringValue = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			customAttribute.SetStringValue(stringValue);
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

	[Register("setStringValue", "(Ljava/lang/String;)V", "GetSetStringValue_Ljava_lang_String_Handler")]
	public unsafe virtual void SetStringValue(string? value)
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
			CustomAttribute? customAttribute = Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			float[] array = (float[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(float));
			customAttribute.SetValue(array);
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
			CustomAttribute? customAttribute = Java.Lang.Object.GetObject<CustomAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			customAttribute.SetValue(value);
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

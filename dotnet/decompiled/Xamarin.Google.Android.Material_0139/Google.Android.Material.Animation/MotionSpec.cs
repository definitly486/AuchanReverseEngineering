using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Animation;

[Register("com/google/android/material/animation/MotionSpec", DoNotGenerateAcw = true)]
public class MotionSpec : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/animation/MotionSpec", typeof(MotionSpec));

	private static Delegate? cb_getTotalDuration_GetTotalDuration_J;

	private static Delegate? cb_getAnimator_GetAnimator_Ljava_lang_String_Ljava_lang_Object_Landroid_util_Property__Landroid_animation_ObjectAnimator_;

	private static Delegate? cb_getPropertyValues_GetPropertyValues_Ljava_lang_String__arrayLandroid_animation_PropertyValuesHolder_;

	private static Delegate? cb_getTiming_GetTiming_Ljava_lang_String__Lcom_google_android_material_animation_MotionTiming_;

	private static Delegate? cb_hasPropertyValues_HasPropertyValues_Ljava_lang_String__Z;

	private static Delegate? cb_hasTiming_HasTiming_Ljava_lang_String__Z;

	private static Delegate? cb_setPropertyValues_SetPropertyValues_Ljava_lang_String_arrayLandroid_animation_PropertyValuesHolder__V;

	private static Delegate? cb_setTiming_SetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming__V;

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

	public unsafe virtual long TotalDuration
	{
		[Register("getTotalDuration", "()J", "GetGetTotalDurationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getTotalDuration.()J", this, null);
		}
	}

	protected MotionSpec(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MotionSpec()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetTotalDurationHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetTotalDuration);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetTotalDuration(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TotalDuration;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("createFromAttribute", "(Landroid/content/Context;Landroid/content/res/TypedArray;I)Lcom/google/android/material/animation/MotionSpec;", "")]
	public unsafe static MotionSpec? CreateFromAttribute(Context context, TypedArray attributes, int index)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(attributes?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<MotionSpec>(_members.StaticMethods.InvokeObjectMethod("createFromAttribute.(Landroid/content/Context;Landroid/content/res/TypedArray;I)Lcom/google/android/material/animation/MotionSpec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attributes);
		}
	}

	[Register("createFromResource", "(Landroid/content/Context;I)Lcom/google/android/material/animation/MotionSpec;", "")]
	public unsafe static MotionSpec? CreateFromResource(Context context, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<MotionSpec>(_members.StaticMethods.InvokeObjectMethod("createFromResource.(Landroid/content/Context;I)Lcom/google/android/material/animation/MotionSpec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetAnimator_Ljava_lang_String_Ljava_lang_Object_Landroid_util_Property_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_GetAnimator_Ljava_lang_String_Ljava_lang_Object_Landroid_util_Property_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnimator_Ljava_lang_String_Ljava_lang_Object_Landroid_util_Property_(nint jnienv, nint native__this, nint native_name, nint native_target, nint native_property)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionSpec? motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object target = Java.Lang.Object.GetObject<Java.Lang.Object>(native_target, JniHandleOwnership.DoNotTransfer);
			Property property = Java.Lang.Object.GetObject<Property>(native_property, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionSpec.GetAnimator(name, target, property));
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

	[Register("getAnimator", "(Ljava/lang/String;Ljava/lang/Object;Landroid/util/Property;)Landroid/animation/ObjectAnimator;", "GetGetAnimator_Ljava_lang_String_Ljava_lang_Object_Landroid_util_Property_Handler")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe virtual ObjectAnimator GetAnimator(string name, Java.Lang.Object target, Property property)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.ToLocalJniHandle(target);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(property?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ObjectAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnimator.(Ljava/lang/String;Ljava/lang/Object;Landroid/util/Property;)Landroid/animation/ObjectAnimator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(target);
			GC.KeepAlive(property);
		}
	}

	private static Delegate GetGetPropertyValues_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetPropertyValues_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPropertyValues_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionSpec? motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(motionSpec.GetPropertyValues(name));
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

	[Register("getPropertyValues", "(Ljava/lang/String;)[Landroid/animation/PropertyValuesHolder;", "GetGetPropertyValues_Ljava_lang_String_Handler")]
	public unsafe virtual PropertyValuesHolder[] GetPropertyValues(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (PropertyValuesHolder[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getPropertyValues.(Ljava/lang/String;)[Landroid/animation/PropertyValuesHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(PropertyValuesHolder));
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetTiming_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetTiming_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTiming_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionSpec? motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionSpec.GetTiming(name));
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

	[Register("getTiming", "(Ljava/lang/String;)Lcom/google/android/material/animation/MotionTiming;", "GetGetTiming_Ljava_lang_String_Handler")]
	public unsafe virtual MotionTiming? GetTiming(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<MotionTiming>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTiming.(Ljava/lang/String;)Lcom/google/android/material/animation/MotionTiming;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetHasPropertyValues_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_HasPropertyValues_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasPropertyValues_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionSpec? motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return motionSpec.HasPropertyValues(name) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasPropertyValues", "(Ljava/lang/String;)Z", "GetHasPropertyValues_Ljava_lang_String_Handler")]
	public unsafe virtual bool HasPropertyValues(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasPropertyValues.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetHasTiming_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_HasTiming_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasTiming_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionSpec? motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return motionSpec.HasTiming(name) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasTiming", "(Ljava/lang/String;)Z", "GetHasTiming_Ljava_lang_String_Handler")]
	public unsafe virtual bool HasTiming(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasTiming.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetPropertyValues_Ljava_lang_String_arrayLandroid_animation_PropertyValuesHolder_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetPropertyValues_Ljava_lang_String_arrayLandroid_animation_PropertyValuesHolder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPropertyValues_Ljava_lang_String_arrayLandroid_animation_PropertyValuesHolder_(nint jnienv, nint native__this, nint native_name, nint native_values)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionSpec? motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			PropertyValuesHolder[] array = (PropertyValuesHolder[])JNIEnv.GetArray(native_values, JniHandleOwnership.DoNotTransfer, typeof(PropertyValuesHolder));
			motionSpec.SetPropertyValues(name, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_values);
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

	[Register("setPropertyValues", "(Ljava/lang/String;[Landroid/animation/PropertyValuesHolder;)V", "GetSetPropertyValues_Ljava_lang_String_arrayLandroid_animation_PropertyValuesHolder_Handler")]
	public unsafe virtual void SetPropertyValues(string? name, PropertyValuesHolder[]? values)
	{
		nint num = JNIEnv.NewString(name);
		nint num2 = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPropertyValues.(Ljava/lang/String;[Landroid/animation/PropertyValuesHolder;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (values != null)
			{
				JNIEnv.CopyArray(num2, values);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetSetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_(nint jnienv, nint native__this, nint native_name, nint native_timing)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionSpec? motionSpec = Java.Lang.Object.GetObject<MotionSpec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			MotionTiming timing = Java.Lang.Object.GetObject<MotionTiming>(native_timing, JniHandleOwnership.DoNotTransfer);
			motionSpec.SetTiming(name, timing);
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

	[Register("setTiming", "(Ljava/lang/String;Lcom/google/android/material/animation/MotionTiming;)V", "GetSetTiming_Ljava_lang_String_Lcom_google_android_material_animation_MotionTiming_Handler")]
	public unsafe virtual void SetTiming(string? name, MotionTiming? timing)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(timing?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTiming.(Ljava/lang/String;Lcom/google/android/material/animation/MotionTiming;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(timing);
		}
	}
}

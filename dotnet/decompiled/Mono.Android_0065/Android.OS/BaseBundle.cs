using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/BaseBundle", DoNotGenerateAcw = true)]
public class BaseBundle : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/BaseBundle", typeof(BaseBundle));

	private static Delegate? cb_containsKey_ContainsKey_Ljava_lang_String__Z;

	private static Delegate? cb_getBoolean_GetBoolean_Ljava_lang_String_Z_Z;

	private static Delegate? cb_getInt_GetInt_Ljava_lang_String_I_I;

	private static Delegate? cb_getInt_GetInt_Ljava_lang_String__I;

	private static Delegate? cb_getString_GetString_Ljava_lang_String_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getString_GetString_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_putBoolean_PutBoolean_Ljava_lang_String_Z_V;

	private static Delegate? cb_putInt_PutInt_Ljava_lang_String_I_V;

	private static Delegate? cb_putString_PutString_Ljava_lang_String_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected BaseBundle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetContainsKey_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_B(n_ContainsKey_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ContainsKey_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return baseBundle.ContainsKey(key) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe virtual bool ContainsKey(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsKey.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[SupportedOSPlatform("android22.0")]
	private static Delegate GetGetBoolean_Ljava_lang_String_ZHandler()
	{
		return new _JniMarshal_PPLB_B(n_GetBoolean_Ljava_lang_String_Z);
	}

	[SupportedOSPlatform("android22.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetBoolean_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_key, sbyte native_defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			bool defaultValue = native_defaultValue != 0;
			return baseBundle.GetBoolean(key, defaultValue) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android22.0")]
	public unsafe virtual bool GetBoolean(string? key, bool defaultValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defaultValue ? ((sbyte)1) : ((sbyte)0));
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getBoolean.(Ljava/lang/String;Z)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetInt_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_I(n_GetInt_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInt_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_key, int defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return baseBundle.GetInt(key, defaultValue);
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

	public unsafe virtual int GetInt(string? key, int defaultValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defaultValue);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInt.(Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetInt_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_I(n_GetInt_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInt_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return baseBundle.GetInt(key);
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

	public unsafe virtual int GetInt(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInt.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetString_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_GetString_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetString_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_defaultValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string defaultValue = JNIEnv.GetString(native_defaultValue, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(baseBundle.GetString(key, defaultValue));
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

	public unsafe virtual string? GetString(string? key, string? defaultValue)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(defaultValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getString.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetGetString_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetString_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetString_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(baseBundle.GetString(key));
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

	public unsafe virtual string? GetString(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getString.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[SupportedOSPlatform("android22.0")]
	private static Delegate GetPutBoolean_Ljava_lang_String_ZHandler()
	{
		return new _JniMarshal_PPLB_V(n_PutBoolean_Ljava_lang_String_Z);
	}

	[SupportedOSPlatform("android22.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutBoolean_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_key, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			baseBundle.PutBoolean(key, value);
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

	[SupportedOSPlatform("android22.0")]
	public unsafe virtual void PutBoolean(string? key, bool value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("putBoolean.(Ljava/lang/String;Z)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutInt_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_PutInt_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutInt_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_key, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			baseBundle.PutInt(key, value);
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

	public unsafe virtual void PutInt(string? key, int value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putInt.(Ljava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutString_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_PutString_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutString_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BaseBundle? baseBundle = Java.Lang.Object.GetObject<BaseBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			baseBundle.PutString(key, value);
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

	public unsafe virtual void PutString(string? key, string? value)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putString.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}

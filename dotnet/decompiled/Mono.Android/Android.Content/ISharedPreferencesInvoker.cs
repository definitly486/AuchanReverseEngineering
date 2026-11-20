using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/SharedPreferences", DoNotGenerateAcw = true)]
internal class ISharedPreferencesInvoker : Java.Lang.Object, ISharedPreferences, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_SharedPreferences = new XAPeerMembers("android/content/SharedPreferences", typeof(ISharedPreferencesInvoker));

	private static Delegate? cb_getAll_GetAll_Ljava_util_Map_;

	private static Delegate? cb_contains_Contains_Ljava_lang_String__Z;

	private static Delegate? cb_edit_Edit_Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_getBoolean_GetBoolean_Ljava_lang_String_Z_Z;

	private static Delegate? cb_getFloat_GetFloat_Ljava_lang_String_F_F;

	private static Delegate? cb_getInt_GetInt_Ljava_lang_String_I_I;

	private static Delegate? cb_getLong_GetLong_Ljava_lang_String_J_J;

	private static Delegate? cb_getString_GetString_Ljava_lang_String_Ljava_lang_String__Ljava_lang_String_;

	private static Delegate? cb_getStringSet_GetStringSet_Ljava_lang_String_Ljava_util_Set__Ljava_util_Set_;

	private static Delegate? cb_registerOnSharedPreferenceChangeListener_RegisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener__V;

	private static Delegate? cb_unregisterOnSharedPreferenceChangeListener_UnregisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_SharedPreferences;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_SharedPreferences.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_SharedPreferences.ManagedPeerType;

	public unsafe IDictionary<string, object>? All => JavaDictionary<string, object>.FromJniHandle(_members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractObjectMethod("getAll.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public ISharedPreferencesInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetAllHandler()
	{
		return new _JniMarshal_PP_L(n_GetAll);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAll(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaDictionary<string, object>.ToLocalJniHandle(Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).All);
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

	private static Delegate GetContains_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_B(n_Contains_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Contains_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return sharedPreferences.Contains(key) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Contains(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetEditHandler()
	{
		return new _JniMarshal_PP_L(n_Edit);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Edit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Edit());
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

	public unsafe ISharedPreferencesEditor? Edit()
	{
		return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractObjectMethod("edit.()Landroid/content/SharedPreferences$Editor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetBoolean_Ljava_lang_String_ZHandler()
	{
		return new _JniMarshal_PPLB_B(n_GetBoolean_Ljava_lang_String_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetBoolean_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_key, sbyte native_defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			bool defValue = native_defValue != 0;
			return sharedPreferences.GetBoolean(key, defValue) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool GetBoolean(string? key, bool defValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defValue ? ((sbyte)1) : ((sbyte)0));
			return _members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractBooleanMethod("getBoolean.(Ljava/lang/String;Z)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetFloat_Ljava_lang_String_FHandler()
	{
		return new _JniMarshal_PPLF_F(n_GetFloat_Ljava_lang_String_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetFloat_Ljava_lang_String_F(nint jnienv, nint native__this, nint native_key, float defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return sharedPreferences.GetFloat(key, defValue);
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

	public unsafe float GetFloat(string? key, float defValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defValue);
			return _members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractSingleMethod("getFloat.(Ljava/lang/String;F)F", this, ptr);
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
	private static int n_GetInt_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_key, int defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return sharedPreferences.GetInt(key, defValue);
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

	public unsafe int GetInt(string? key, int defValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defValue);
			return _members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractInt32Method("getInt.(Ljava/lang/String;I)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetLong_Ljava_lang_String_JHandler()
	{
		return new _JniMarshal_PPLJ_J(n_GetLong_Ljava_lang_String_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetLong_Ljava_lang_String_J(nint jnienv, nint native__this, nint native_key, long defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return sharedPreferences.GetLong(key, defValue);
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

	public unsafe long GetLong(string? key, long defValue)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(defValue);
			return _members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractInt64Method("getLong.(Ljava/lang/String;J)J", this, ptr);
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
	private static nint n_GetString_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_defValue)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string defValue = JNIEnv.GetString(native_defValue, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(sharedPreferences.GetString(key, defValue));
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

	public unsafe string? GetString(string? key, string? defValue)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(defValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractObjectMethod("getString.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetGetStringSet_Ljava_lang_String_Ljava_util_Set_Handler()
	{
		return new _JniMarshal_PPLL_L(n_GetStringSet_Ljava_lang_String_Ljava_util_Set_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStringSet_Ljava_lang_String_Ljava_util_Set_(nint jnienv, nint native__this, nint native_key, nint native_defValues)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			ICollection<string> defValues = JavaSet<string>.FromJniHandle(native_defValues, JniHandleOwnership.DoNotTransfer);
			return JavaSet<string>.ToLocalJniHandle(sharedPreferences.GetStringSet(key, defValues));
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

	public unsafe ICollection<string>? GetStringSet(string? key, ICollection<string>? defValues)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JavaSet<string>.ToLocalJniHandle(defValues);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JavaSet<string>.FromJniHandle(_members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractObjectMethod("getStringSet.(Ljava/lang/String;Ljava/util/Set;)Ljava/util/Set;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(defValues);
		}
	}

	private static Delegate GetRegisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_RegisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISharedPreferencesOnSharedPreferenceChangeListener listener = Java.Lang.Object.GetObject<ISharedPreferencesOnSharedPreferenceChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			sharedPreferences.RegisterOnSharedPreferenceChangeListener(listener);
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

	public unsafe void RegisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractVoidMethod("registerOnSharedPreferenceChangeListener.(Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetUnregisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterOnSharedPreferenceChangeListener_Landroid_content_SharedPreferences_OnSharedPreferenceChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ISharedPreferences? sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISharedPreferencesOnSharedPreferenceChangeListener listener = Java.Lang.Object.GetObject<ISharedPreferencesOnSharedPreferenceChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			sharedPreferences.UnregisterOnSharedPreferenceChangeListener(listener);
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

	public unsafe void UnregisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members_android_content_SharedPreferences.InstanceMethods.InvokeAbstractVoidMethod("unregisterOnSharedPreferenceChangeListener.(Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/SharedPreferences$Editor", DoNotGenerateAcw = true)]
internal class ISharedPreferencesEditorInvoker : Java.Lang.Object, ISharedPreferencesEditor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_SharedPreferences_Editor = new XAPeerMembers("android/content/SharedPreferences$Editor", typeof(ISharedPreferencesEditorInvoker));

	private static Delegate? cb_apply_Apply_V;

	private static Delegate? cb_clear_Clear_Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_commit_Commit_Z;

	private static Delegate? cb_putBoolean_PutBoolean_Ljava_lang_String_Z_Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_putFloat_PutFloat_Ljava_lang_String_F_Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_putInt_PutInt_Ljava_lang_String_I_Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_putLong_PutLong_Ljava_lang_String_J_Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_putString_PutString_Ljava_lang_String_Ljava_lang_String__Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_putStringSet_PutStringSet_Ljava_lang_String_Ljava_util_Set__Landroid_content_SharedPreferences_Editor_;

	private static Delegate? cb_remove_Remove_Ljava_lang_String__Landroid_content_SharedPreferences_Editor_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_SharedPreferences_Editor;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_SharedPreferences_Editor.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_SharedPreferences_Editor.ManagedPeerType;

	public ISharedPreferencesEditorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetApplyHandler()
	{
		return new _JniMarshal_PP_V(n_Apply);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Apply(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Apply();
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

	public unsafe void Apply()
	{
		_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractVoidMethod("apply.()V", this, null);
	}

	private static Delegate GetClearHandler()
	{
		return new _JniMarshal_PP_L(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear());
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

	public unsafe ISharedPreferencesEditor? Clear()
	{
		return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("clear.()Landroid/content/SharedPreferences$Editor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCommitHandler()
	{
		return new _JniMarshal_PP_B(n_Commit);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Commit(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Commit() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Commit()
	{
		return _members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractBooleanMethod("commit.()Z", this, null);
	}

	private static Delegate GetPutBoolean_Ljava_lang_String_ZHandler()
	{
		return new _JniMarshal_PPLB_L(n_PutBoolean_Ljava_lang_String_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutBoolean_Ljava_lang_String_Z(nint jnienv, nint native__this, nint native_key, sbyte native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferencesEditor? sharedPreferencesEditor = Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			bool value = native_value != 0;
			return JNIEnv.ToLocalJniHandle(sharedPreferencesEditor.PutBoolean(key, value));
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

	public unsafe ISharedPreferencesEditor? PutBoolean(string? key, bool value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("putBoolean.(Ljava/lang/String;Z)Landroid/content/SharedPreferences$Editor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutFloat_Ljava_lang_String_FHandler()
	{
		return new _JniMarshal_PPLF_L(n_PutFloat_Ljava_lang_String_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutFloat_Ljava_lang_String_F(nint jnienv, nint native__this, nint native_key, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferencesEditor? sharedPreferencesEditor = Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedPreferencesEditor.PutFloat(key, value));
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

	public unsafe ISharedPreferencesEditor? PutFloat(string? key, float value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("putFloat.(Ljava/lang/String;F)Landroid/content/SharedPreferences$Editor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutInt_Ljava_lang_String_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_PutInt_Ljava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutInt_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_key, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferencesEditor? sharedPreferencesEditor = Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedPreferencesEditor.PutInt(key, value));
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

	public unsafe ISharedPreferencesEditor? PutInt(string? key, int value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("putInt.(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutLong_Ljava_lang_String_JHandler()
	{
		return new _JniMarshal_PPLJ_L(n_PutLong_Ljava_lang_String_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutLong_Ljava_lang_String_J(nint jnienv, nint native__this, nint native_key, long value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferencesEditor? sharedPreferencesEditor = Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedPreferencesEditor.PutLong(key, value));
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

	public unsafe ISharedPreferencesEditor? PutLong(string? key, long value)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value);
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("putLong.(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetPutString_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_L(n_PutString_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutString_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferencesEditor? sharedPreferencesEditor = Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedPreferencesEditor.PutString(key, value));
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

	public unsafe ISharedPreferencesEditor? PutString(string? key, string? value)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("putString.(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetPutStringSet_Ljava_lang_String_Ljava_util_Set_Handler()
	{
		return new _JniMarshal_PPLL_L(n_PutStringSet_Ljava_lang_String_Ljava_util_Set_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_PutStringSet_Ljava_lang_String_Ljava_util_Set_(nint jnienv, nint native__this, nint native_key, nint native_values)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferencesEditor? sharedPreferencesEditor = Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			ICollection<string> values = JavaSet<string>.FromJniHandle(native_values, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedPreferencesEditor.PutStringSet(key, values));
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

	public unsafe ISharedPreferencesEditor? PutStringSet(string? key, ICollection<string>? values)
	{
		nint num = JNIEnv.NewString(key);
		nint num2 = JavaSet<string>.ToLocalJniHandle(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("putStringSet.(Ljava/lang/String;Ljava/util/Set;)Landroid/content/SharedPreferences$Editor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetRemove_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_Remove_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Remove_Ljava_lang_String_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISharedPreferencesEditor? sharedPreferencesEditor = Java.Lang.Object.GetObject<ISharedPreferencesEditor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedPreferencesEditor.Remove(key));
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

	public unsafe ISharedPreferencesEditor? Remove(string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISharedPreferencesEditor>(_members_android_content_SharedPreferences_Editor.InstanceMethods.InvokeAbstractObjectMethod("remove.(Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
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

using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Content;

[Register("android/content/SharedPreferences$OnSharedPreferenceChangeListener", DoNotGenerateAcw = true)]
internal class ISharedPreferencesOnSharedPreferenceChangeListenerInvoker : Java.Lang.Object, ISharedPreferencesOnSharedPreferenceChangeListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_content_SharedPreferences_OnSharedPreferenceChangeListener = new XAPeerMembers("android/content/SharedPreferences$OnSharedPreferenceChangeListener", typeof(ISharedPreferencesOnSharedPreferenceChangeListenerInvoker));

	private static Delegate? cb_onSharedPreferenceChanged_OnSharedPreferenceChanged_Landroid_content_SharedPreferences_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_content_SharedPreferences_OnSharedPreferenceChangeListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_content_SharedPreferences_OnSharedPreferenceChangeListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_content_SharedPreferences_OnSharedPreferenceChangeListener.ManagedPeerType;

	public ISharedPreferencesOnSharedPreferenceChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnSharedPreferenceChanged_Landroid_content_SharedPreferences_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_OnSharedPreferenceChanged_Landroid_content_SharedPreferences_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSharedPreferenceChanged_Landroid_content_SharedPreferences_Ljava_lang_String_(nint jnienv, nint native__this, nint native_sharedPreferences, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ISharedPreferencesOnSharedPreferenceChangeListener? sharedPreferencesOnSharedPreferenceChangeListener = Java.Lang.Object.GetObject<ISharedPreferencesOnSharedPreferenceChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISharedPreferences sharedPreferences = Java.Lang.Object.GetObject<ISharedPreferences>(native_sharedPreferences, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			sharedPreferencesOnSharedPreferenceChangeListener.OnSharedPreferenceChanged(sharedPreferences, key);
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

	public unsafe void OnSharedPreferenceChanged(ISharedPreferences? sharedPreferences, string? key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((sharedPreferences == null) ? IntPtr.Zero : ((Java.Lang.Object)sharedPreferences).Handle);
			ptr[1] = new JniArgumentValue(num);
			_members_android_content_SharedPreferences_OnSharedPreferenceChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onSharedPreferenceChanged.(Landroid/content/SharedPreferences;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(sharedPreferences);
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

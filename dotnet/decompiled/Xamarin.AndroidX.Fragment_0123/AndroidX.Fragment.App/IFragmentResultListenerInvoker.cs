using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentResultListener", DoNotGenerateAcw = true)]
internal class IFragmentResultListenerInvoker : Java.Lang.Object, IFragmentResultListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_fragment_app_FragmentResultListener = new XAPeerMembers("androidx/fragment/app/FragmentResultListener", typeof(IFragmentResultListenerInvoker));

	private static Delegate? cb_onFragmentResult_OnFragmentResult_Ljava_lang_String_Landroid_os_Bundle__V;

	private static nint java_class_ref => _members_androidx_fragment_app_FragmentResultListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_fragment_app_FragmentResultListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_fragment_app_FragmentResultListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_fragment_app_FragmentResultListener.ManagedPeerType;

	public IFragmentResultListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IFragmentResultListener? fragmentResultListener = Java.Lang.Object.GetObject<IFragmentResultListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			Bundle p2 = Java.Lang.Object.GetObject<Bundle>(native_p1, JniHandleOwnership.DoNotTransfer);
			fragmentResultListener.OnFragmentResult(p, p2);
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

	public unsafe void OnFragmentResult(string p0, Bundle p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_androidx_fragment_app_FragmentResultListener.InstanceMethods.InvokeAbstractVoidMethod("onFragmentResult.(Ljava/lang/String;Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
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

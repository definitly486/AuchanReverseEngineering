using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/ICrashTransformer", DoNotGenerateAcw = true)]
internal class ICrashTransformerInvoker : Java.Lang.Object, ICrashTransformer, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_ICrashTransformer = new XAPeerMembers("io/appmetrica/analytics/ICrashTransformer", typeof(ICrashTransformerInvoker));

	private static Delegate? cb_process_Process_Ljava_lang_Throwable__Ljava_lang_Throwable_;

	private static nint java_class_ref => _members_io_appmetrica_analytics_ICrashTransformer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_ICrashTransformer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_ICrashTransformer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_ICrashTransformer.ManagedPeerType;

	public ICrashTransformerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetProcess_Ljava_lang_Throwable_Handler()
	{
		if ((object)cb_process_Process_Ljava_lang_Throwable__Ljava_lang_Throwable_ == null)
		{
			cb_process_Process_Ljava_lang_Throwable__Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Process_Ljava_lang_Throwable_));
		}
		return cb_process_Process_Ljava_lang_Throwable__Ljava_lang_Throwable_;
	}

	private static nint n_Process_Ljava_lang_Throwable_(nint jnienv, nint native__this, nint native_p0)
	{
		ICrashTransformer? crashTransformer = Java.Lang.Object.GetObject<ICrashTransformer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(crashTransformer.Process(p));
	}

	public unsafe Throwable? Process(Throwable p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Throwable>(_members_io_appmetrica_analytics_ICrashTransformer.InstanceMethods.InvokeAbstractObjectMethod("process.(Ljava/lang/Throwable;)Ljava/lang/Throwable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}

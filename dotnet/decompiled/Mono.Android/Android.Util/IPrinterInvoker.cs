using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/Printer", DoNotGenerateAcw = true)]
internal class IPrinterInvoker : Java.Lang.Object, IPrinter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_util_Printer = new XAPeerMembers("android/util/Printer", typeof(IPrinterInvoker));

	private static Delegate? cb_println_Println_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_util_Printer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_util_Printer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_util_Printer.ManagedPeerType;

	public IPrinterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetPrintln_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_V(n_Println_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Println_Ljava_lang_String_(nint jnienv, nint native__this, nint native_x)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IPrinter? printer = Java.Lang.Object.GetObject<IPrinter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string x = JNIEnv.GetString(native_x, JniHandleOwnership.DoNotTransfer);
			printer.Println(x);
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

	public unsafe void Println(string? x)
	{
		nint num = JNIEnv.NewString(x);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_android_util_Printer.InstanceMethods.InvokeAbstractVoidMethod("println.(Ljava/lang/String;)V", this, ptr);
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

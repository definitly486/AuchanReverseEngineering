using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/TextWatcher", DoNotGenerateAcw = true)]
internal class ITextWatcherInvoker : Java.Lang.Object, ITextWatcher, INoCopySpan, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_NoCopySpan = new XAPeerMembers("android/text/NoCopySpan", typeof(ITextWatcherInvoker));

	private static readonly JniPeerMembers _members_android_text_TextWatcher = new XAPeerMembers("android/text/TextWatcher", typeof(ITextWatcherInvoker));

	private static Delegate? cb_afterTextChanged_AfterTextChanged_Landroid_text_Editable__V;

	private static Delegate? cb_beforeTextChanged_BeforeTextChanged_Ljava_lang_CharSequence_III_V;

	private static Delegate? cb_onTextChanged_OnTextChanged_Ljava_lang_CharSequence_III_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_TextWatcher;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_TextWatcher.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_TextWatcher.ManagedPeerType;

	public ITextWatcherInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AfterTextChanged_Landroid_text_Editable_(nint jnienv, nint native__this, nint native_s)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ITextWatcher? textWatcher = Java.Lang.Object.GetObject<ITextWatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IEditable s = Java.Lang.Object.GetObject<IEditable>(native_s, JniHandleOwnership.DoNotTransfer);
			textWatcher.AfterTextChanged(s);
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

	public unsafe void AfterTextChanged(IEditable? s)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((s == null) ? IntPtr.Zero : ((Java.Lang.Object)s).Handle);
			_members_android_text_TextWatcher.InstanceMethods.InvokeAbstractVoidMethod("afterTextChanged.(Landroid/text/Editable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(s);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BeforeTextChanged_Ljava_lang_CharSequence_III(nint jnienv, nint native__this, nint native_s, int start, int count, int after)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ITextWatcher? textWatcher = Java.Lang.Object.GetObject<ITextWatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence s = Java.Lang.Object.GetObject<ICharSequence>(native_s, JniHandleOwnership.DoNotTransfer);
			textWatcher.BeforeTextChanged(s, start, count, after);
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

	public unsafe void BeforeTextChanged(ICharSequence? s, int start, int count, int after)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(count);
			ptr[3] = new JniArgumentValue(after);
			_members_android_text_TextWatcher.InstanceMethods.InvokeAbstractVoidMethod("beforeTextChanged.(Ljava/lang/CharSequence;III)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTextChanged_Ljava_lang_CharSequence_III(nint jnienv, nint native__this, nint native_s, int start, int before, int count)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ITextWatcher? textWatcher = Java.Lang.Object.GetObject<ITextWatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence s = Java.Lang.Object.GetObject<ICharSequence>(native_s, JniHandleOwnership.DoNotTransfer);
			textWatcher.OnTextChanged(s, start, before, count);
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

	public unsafe void OnTextChanged(ICharSequence? s, int start, int before, int count)
	{
		nint num = CharSequence.ToLocalJniHandle(s);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(before);
			ptr[3] = new JniArgumentValue(count);
			_members_android_text_TextWatcher.InstanceMethods.InvokeAbstractVoidMethod("onTextChanged.(Ljava/lang/CharSequence;III)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(s);
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

	[UnmanagedCallersOnly]
	private static void n_AfterTextChanged_Landroid_text_Editable__mm_wrapper(nint jnienv, nint native__this, nint native_s)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_AfterTextChanged_Landroid_text_Editable_(jnienv, native__this, native_s);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_BeforeTextChanged_Ljava_lang_CharSequence_III_mm_wrapper(nint jnienv, nint native__this, nint native_s, int start, int count, int after)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_BeforeTextChanged_Ljava_lang_CharSequence_III(jnienv, native__this, native_s, start, count, after);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnTextChanged_Ljava_lang_CharSequence_III_mm_wrapper(nint jnienv, nint native__this, nint native_s, int start, int before, int count)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnTextChanged_Ljava_lang_CharSequence_III(jnienv, native__this, native_s, start, before, count);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/InputFilter", DoNotGenerateAcw = true)]
internal class IInputFilterInvoker : Java.Lang.Object, IInputFilter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_InputFilter = new XAPeerMembers("android/text/InputFilter", typeof(IInputFilterInvoker));

	private static Delegate? cb_filter_Filter_Ljava_lang_CharSequence_IILandroid_text_Spanned_II_Ljava_lang_CharSequence_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_InputFilter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_InputFilter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_InputFilter.ManagedPeerType;

	public IInputFilterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Filter_Ljava_lang_CharSequence_IILandroid_text_Spanned_II(nint jnienv, nint native__this, nint native_source, int start, int end, nint native_dest, int dstart, int dend)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IInputFilter? inputFilter = Java.Lang.Object.GetObject<IInputFilter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence source = Java.Lang.Object.GetObject<ICharSequence>(native_source, JniHandleOwnership.DoNotTransfer);
			ISpanned dest = Java.Lang.Object.GetObject<ISpanned>(native_dest, JniHandleOwnership.DoNotTransfer);
			return CharSequence.ToLocalJniHandle(inputFilter.FilterFormatted(source, start, end, dest, dstart, dend));
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

	public unsafe ICharSequence? FilterFormatted(ICharSequence? source, int start, int end, ISpanned? dest, int dstart, int dend)
	{
		nint num = CharSequence.ToLocalJniHandle(source);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			ptr[3] = new JniArgumentValue((dest == null) ? IntPtr.Zero : ((Java.Lang.Object)dest).Handle);
			ptr[4] = new JniArgumentValue(dstart);
			ptr[5] = new JniArgumentValue(dend);
			return Java.Lang.Object.GetObject<ICharSequence>(_members_android_text_InputFilter.InstanceMethods.InvokeAbstractObjectMethod("filter.(Ljava/lang/CharSequence;IILandroid/text/Spanned;II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(source);
			GC.KeepAlive(dest);
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
	private static nint n_Filter_Ljava_lang_CharSequence_IILandroid_text_Spanned_II_mm_wrapper(nint jnienv, nint native__this, nint native_source, int start, int end, nint native_dest, int dstart, int dend)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Filter_Ljava_lang_CharSequence_IILandroid_text_Spanned_II(jnienv, native__this, native_source, start, end, native_dest, dstart, dend);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}

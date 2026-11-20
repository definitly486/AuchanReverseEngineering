using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Method;

[Register("android/text/method/NumberKeyListener", DoNotGenerateAcw = true)]
public abstract class NumberKeyListener : BaseKeyListener, IInputFilter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/method/NumberKeyListener", typeof(NumberKeyListener));

	private static Delegate? cb_filter_Filter_Ljava_lang_CharSequence_IILandroid_text_Spanned_II_Ljava_lang_CharSequence_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected NumberKeyListener(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetFilter_Ljava_lang_CharSequence_IILandroid_text_Spanned_IIHandler()
	{
		return new _JniMarshal_PPLIILII_L(n_Filter_Ljava_lang_CharSequence_IILandroid_text_Spanned_II);
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
			NumberKeyListener? numberKeyListener = Java.Lang.Object.GetObject<NumberKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence source = Java.Lang.Object.GetObject<ICharSequence>(native_source, JniHandleOwnership.DoNotTransfer);
			ISpanned dest = Java.Lang.Object.GetObject<ISpanned>(native_dest, JniHandleOwnership.DoNotTransfer);
			return CharSequence.ToLocalJniHandle(numberKeyListener.FilterFormatted(source, start, end, dest, dstart, dend));
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

	[Register("filter", "(Ljava/lang/CharSequence;IILandroid/text/Spanned;II)Ljava/lang/CharSequence;", "GetFilter_Ljava_lang_CharSequence_IILandroid_text_Spanned_IIHandler")]
	public unsafe virtual ICharSequence? FilterFormatted(ICharSequence? source, int start, int end, ISpanned? dest, int dstart, int dend)
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
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("filter.(Ljava/lang/CharSequence;IILandroid/text/Spanned;II)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
}

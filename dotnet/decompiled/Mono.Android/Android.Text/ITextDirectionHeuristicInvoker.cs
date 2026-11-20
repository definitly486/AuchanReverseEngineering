using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/TextDirectionHeuristic", DoNotGenerateAcw = true)]
internal class ITextDirectionHeuristicInvoker : Java.Lang.Object, ITextDirectionHeuristic, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_text_TextDirectionHeuristic = new XAPeerMembers("android/text/TextDirectionHeuristic", typeof(ITextDirectionHeuristicInvoker));

	private static Delegate? cb_isRtl_IsRtl_arrayCII_Z;

	private static Delegate? cb_isRtl_IsRtl_Ljava_lang_CharSequence_II_Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_text_TextDirectionHeuristic;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_text_TextDirectionHeuristic.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_text_TextDirectionHeuristic.ManagedPeerType;

	public ITextDirectionHeuristicInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsRtl_arrayCIIHandler()
	{
		return new _JniMarshal_PPLII_B(n_IsRtl_arrayCII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRtl_arrayCII(nint jnienv, nint native__this, nint native_array, int start, int count)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITextDirectionHeuristic? textDirectionHeuristic = Java.Lang.Object.GetObject<ITextDirectionHeuristic>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_array, JniHandleOwnership.DoNotTransfer, typeof(char));
			sbyte result = (textDirectionHeuristic.IsRtl(array, start, count) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_array);
			}
			return result;
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

	public unsafe bool IsRtl(char[]? array, int start, int count)
	{
		nint num = JNIEnv.NewArray(array);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(count);
			return _members_android_text_TextDirectionHeuristic.InstanceMethods.InvokeAbstractBooleanMethod("isRtl.([CII)Z", this, ptr);
		}
		finally
		{
			if (array != null)
			{
				JNIEnv.CopyArray(num, array);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(array);
		}
	}

	private static Delegate GetIsRtl_Ljava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPLII_B(n_IsRtl_Ljava_lang_CharSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRtl_Ljava_lang_CharSequence_II(nint jnienv, nint native__this, nint native_cs, int start, int count)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITextDirectionHeuristic? textDirectionHeuristic = Java.Lang.Object.GetObject<ITextDirectionHeuristic>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence cs = Java.Lang.Object.GetObject<ICharSequence>(native_cs, JniHandleOwnership.DoNotTransfer);
			return textDirectionHeuristic.IsRtl(cs, start, count) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool IsRtl(ICharSequence? cs, int start, int count)
	{
		nint num = CharSequence.ToLocalJniHandle(cs);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(count);
			return _members_android_text_TextDirectionHeuristic.InstanceMethods.InvokeAbstractBooleanMethod("isRtl.(Ljava/lang/CharSequence;II)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cs);
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

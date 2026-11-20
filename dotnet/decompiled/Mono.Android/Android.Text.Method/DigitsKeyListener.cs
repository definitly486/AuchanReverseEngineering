using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Method;

[Register("android/text/method/DigitsKeyListener", DoNotGenerateAcw = true)]
public class DigitsKeyListener : NumberKeyListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/method/DigitsKeyListener", typeof(DigitsKeyListener));

	private static Delegate? cb_getInputType_GetInputType_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override InputTypes InputType
	{
		[Register("getInputType", "()I", "GetGetInputTypeHandler")]
		get
		{
			return (InputTypes)_members.InstanceMethods.InvokeVirtualInt32Method("getInputType.()I", this, null);
		}
	}

	protected DigitsKeyListener(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetInputTypeHandler()
	{
		return new _JniMarshal_PP_I(n_GetInputType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInputType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return (int)Java.Lang.Object.GetObject<DigitsKeyListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType;
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

	[Register("getInstance", "(Ljava/lang/String;)Landroid/text/method/DigitsKeyListener;", "")]
	public unsafe static DigitsKeyListener GetInstance(string accepted)
	{
		nint num = JNIEnv.NewString(accepted);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<DigitsKeyListener>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Ljava/lang/String;)Landroid/text/method/DigitsKeyListener;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}

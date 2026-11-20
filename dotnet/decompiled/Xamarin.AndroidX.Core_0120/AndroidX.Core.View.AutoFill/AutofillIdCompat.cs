using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views.Autofill;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View.AutoFill;

[Register("androidx/core/view/autofill/AutofillIdCompat", DoNotGenerateAcw = true)]
public class AutofillIdCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/autofill/AutofillIdCompat", typeof(AutofillIdCompat));

	private static Delegate? cb_toAutofillId_ToAutofillId_Landroid_view_autofill_AutofillId_;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected AutofillIdCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetToAutofillIdHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToAutofillId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToAutofillId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AutofillIdCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToAutofillId());
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

	[Register("toAutofillId", "()Landroid/view/autofill/AutofillId;", "GetToAutofillIdHandler")]
	public unsafe virtual AutofillId? ToAutofillId()
	{
		return Java.Lang.Object.GetObject<AutofillId>(_members.InstanceMethods.InvokeVirtualObjectMethod("toAutofillId.()Landroid/view/autofill/AutofillId;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("toAutofillIdCompat", "(Landroid/view/autofill/AutofillId;)Landroidx/core/view/autofill/AutofillIdCompat;", "")]
	public unsafe static AutofillIdCompat? ToAutofillIdCompat(AutofillId? autofillId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(autofillId?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AutofillIdCompat>(_members.StaticMethods.InvokeObjectMethod("toAutofillIdCompat.(Landroid/view/autofill/AutofillId;)Landroidx/core/view/autofill/AutofillIdCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(autofillId);
		}
	}
}

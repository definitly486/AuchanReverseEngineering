using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View.Accessibility;

[Register("androidx/core/view/accessibility/AccessibilityViewCommand$CommandArguments", DoNotGenerateAcw = true)]
public abstract class AccessibilityViewCommandCommandArguments : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityViewCommand$CommandArguments", typeof(AccessibilityViewCommandCommandArguments));

	private static Delegate? cb_setBundle_SetBundle_Landroid_os_Bundle__V;

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

	protected AccessibilityViewCommandCommandArguments(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe AccessibilityViewCommandCommandArguments()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetSetBundle_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBundle_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBundle_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_bundle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityViewCommandCommandArguments? accessibilityViewCommandCommandArguments = Java.Lang.Object.GetObject<AccessibilityViewCommandCommandArguments>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle bundle = Java.Lang.Object.GetObject<Bundle>(native_bundle, JniHandleOwnership.DoNotTransfer);
			accessibilityViewCommandCommandArguments.SetBundle(bundle);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setBundle", "(Landroid/os/Bundle;)V", "GetSetBundle_Landroid_os_Bundle_Handler")]
	public unsafe virtual void SetBundle(Bundle? bundle)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bundle?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBundle.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bundle);
		}
	}
}

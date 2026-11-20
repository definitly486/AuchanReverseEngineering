using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Biometric;

[Register("androidx/biometric/BiometricManager", DoNotGenerateAcw = true)]
public class BiometricManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricManager", typeof(BiometricManager));

	private static Delegate? cb_canAuthenticate_CanAuthenticate_I;

	private static Delegate? cb_canAuthenticate_CanAuthenticate_I_I;

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

	protected BiometricManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Obsolete]
	private static Delegate GetCanAuthenticateHandler()
	{
		return new global::_JniMarshal_PP_I(n_CanAuthenticate);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CanAuthenticate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BiometricManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanAuthenticate();
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

	[Obsolete("deprecated")]
	[Register("canAuthenticate", "()I", "GetCanAuthenticateHandler")]
	public unsafe virtual int CanAuthenticate()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("canAuthenticate.()I", this, null);
	}

	private static Delegate GetCanAuthenticate_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_CanAuthenticate_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CanAuthenticate_I(nint jnienv, nint native__this, int authenticators)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BiometricManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanAuthenticate(authenticators);
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

	[Register("canAuthenticate", "(I)I", "GetCanAuthenticate_IHandler")]
	public unsafe virtual int CanAuthenticate(int authenticators)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(authenticators);
		return _members.InstanceMethods.InvokeVirtualInt32Method("canAuthenticate.(I)I", this, ptr);
	}

	[Register("from", "(Landroid/content/Context;)Landroidx/biometric/BiometricManager;", "")]
	public unsafe static BiometricManager From(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<BiometricManager>(_members.StaticMethods.InvokeObjectMethod("from.(Landroid/content/Context;)Landroidx/biometric/BiometricManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}

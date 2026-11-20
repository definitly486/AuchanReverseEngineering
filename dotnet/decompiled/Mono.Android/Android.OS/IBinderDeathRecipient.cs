using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/IBinder$DeathRecipient", "", "Android.OS.IBinderDeathRecipientInvoker")]
public interface IBinderDeathRecipient : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/IBinder$DeathRecipient", typeof(IBinderDeathRecipient), isInterface: true);

	private static Delegate? cb_binderDied_BinderDied_Landroid_os_IBinder__V;

	[Register("binderDied", "()V", "GetBinderDiedHandler:Android.OS.IBinderDeathRecipientInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void BinderDied();

	[SupportedOSPlatform("android34.0")]
	private static Delegate GetBinderDied_Landroid_os_IBinder_Handler()
	{
		return new _JniMarshal_PPL_V(n_BinderDied_Landroid_os_IBinder_);
	}

	[SupportedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BinderDied_Landroid_os_IBinder_(nint jnienv, nint native__this, nint native_who)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IBinderDeathRecipient? binderDeathRecipient = Java.Lang.Object.GetObject<IBinderDeathRecipient>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBinder who = Java.Lang.Object.GetObject<IBinder>(native_who, JniHandleOwnership.DoNotTransfer);
			binderDeathRecipient.BinderDied(who);
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

	[SupportedOSPlatform("android34.0")]
	[Register("binderDied", "(Landroid/os/IBinder;)V", "GetBinderDied_Landroid_os_IBinder_Handler:Android.OS.IBinderDeathRecipient, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 34)]
	unsafe void BinderDied(IBinder who)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((who == null) ? IntPtr.Zero : ((Java.Lang.Object)who).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("binderDied.(Landroid/os/IBinder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(who);
		}
	}
}

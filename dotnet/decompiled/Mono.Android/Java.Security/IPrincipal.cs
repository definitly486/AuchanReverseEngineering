using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Javax.Security.Auth;

namespace Java.Security;

[Register("java/security/Principal", "", "Java.Security.IPrincipalInvoker")]
public interface IPrincipal : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/Principal", typeof(IPrincipal), isInterface: true);

	private static Delegate? cb_implies_Implies_Ljavax_security_auth_Subject__Z;

	string? Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:Java.Security.IPrincipalInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler:Java.Security.IPrincipalInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Equals(Java.Lang.Object? another);

	[Register("hashCode", "()I", "GetGetHashCodeHandler:Java.Security.IPrincipalInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new int GetHashCode();

	[Register("toString", "()Ljava/lang/String;", "GetToStringHandler:Java.Security.IPrincipalInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new string? ToString();

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetImplies_Ljavax_security_auth_Subject_Handler()
	{
		return new _JniMarshal_PPL_B(n_Implies_Ljavax_security_auth_Subject_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Implies_Ljavax_security_auth_Subject_(nint jnienv, nint native__this, nint native_subject)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IPrincipal? principal = Java.Lang.Object.GetObject<IPrincipal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Subject subject = Java.Lang.Object.GetObject<Subject>(native_subject, JniHandleOwnership.DoNotTransfer);
			return principal.Implies(subject) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android26.0")]
	[Register("implies", "(Ljavax/security/auth/Subject;)Z", "GetImplies_Ljavax_security_auth_Subject_Handler:Java.Security.IPrincipal, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
	unsafe bool Implies(Subject? subject)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(subject?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("implies.(Ljavax/security/auth/Subject;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(subject);
		}
	}
}

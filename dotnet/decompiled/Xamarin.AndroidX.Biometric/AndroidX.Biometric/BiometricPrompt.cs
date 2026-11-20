using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Security.Identity;
using AndroidX.Fragment.App;
using Java.Interop;
using Java.Lang;
using Java.Security;
using Java.Util.Concurrent;
using Javax.Crypto;

namespace AndroidX.Biometric;

[Register("androidx/biometric/BiometricPrompt", DoNotGenerateAcw = true)]
public class BiometricPrompt : Java.Lang.Object
{
	[Register("androidx/biometric/BiometricPrompt$AuthenticationCallback", DoNotGenerateAcw = true)]
	public abstract class AuthenticationCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricPrompt$AuthenticationCallback", typeof(AuthenticationCallback));

		private static Delegate? cb_onAuthenticationError_OnAuthenticationError_ILjava_lang_CharSequence__V;

		private static Delegate? cb_onAuthenticationFailed_OnAuthenticationFailed_V;

		private static Delegate? cb_onAuthenticationSucceeded_OnAuthenticationSucceeded_Landroidx_biometric_BiometricPrompt_AuthenticationResult__V;

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

		protected AuthenticationCallback(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AuthenticationCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAuthenticationError_ILjava_lang_CharSequence_(nint jnienv, nint native__this, int errorCode, nint native_errString)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				AuthenticationCallback? authenticationCallback = Java.Lang.Object.GetObject<AuthenticationCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence errString = Java.Lang.Object.GetObject<ICharSequence>(native_errString, JniHandleOwnership.DoNotTransfer);
				authenticationCallback.OnAuthenticationError(errorCode, errString);
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

		[Register("onAuthenticationError", "(ILjava/lang/CharSequence;)V", "GetOnAuthenticationError_ILjava_lang_CharSequence_Handler")]
		public unsafe virtual void OnAuthenticationError(int errorCode, ICharSequence errString)
		{
			nint num = CharSequence.ToLocalJniHandle(errString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(errorCode);
				ptr[1] = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAuthenticationError.(ILjava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(errString);
			}
		}

		public void OnAuthenticationError(int errorCode, string errString)
		{
			Java.Lang.String obj = ((errString == null) ? null : new Java.Lang.String(errString));
			OnAuthenticationError(errorCode, obj);
			obj?.Dispose();
		}

		private static Delegate GetOnAuthenticationFailedHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnAuthenticationFailed);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAuthenticationFailed(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<AuthenticationCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAuthenticationFailed();
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

		[Register("onAuthenticationFailed", "()V", "GetOnAuthenticationFailedHandler")]
		public unsafe virtual void OnAuthenticationFailed()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAuthenticationFailed.()V", this, null);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAuthenticationSucceeded_Landroidx_biometric_BiometricPrompt_AuthenticationResult_(nint jnienv, nint native__this, nint native_result)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				AuthenticationCallback? authenticationCallback = Java.Lang.Object.GetObject<AuthenticationCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AuthenticationResult result = Java.Lang.Object.GetObject<AuthenticationResult>(native_result, JniHandleOwnership.DoNotTransfer);
				authenticationCallback.OnAuthenticationSucceeded(result);
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

		[Register("onAuthenticationSucceeded", "(Landroidx/biometric/BiometricPrompt$AuthenticationResult;)V", "GetOnAuthenticationSucceeded_Landroidx_biometric_BiometricPrompt_AuthenticationResult_Handler")]
		public unsafe virtual void OnAuthenticationSucceeded(AuthenticationResult result)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(result?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAuthenticationSucceeded.(Landroidx/biometric/BiometricPrompt$AuthenticationResult;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(result);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnAuthenticationError_ILjava_lang_CharSequence__mm_wrapper(nint jnienv, nint native__this, int errorCode, nint native_errString)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAuthenticationError_ILjava_lang_CharSequence_(jnienv, native__this, errorCode, native_errString);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnAuthenticationSucceeded_Landroidx_biometric_BiometricPrompt_AuthenticationResult__mm_wrapper(nint jnienv, nint native__this, nint native_result)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAuthenticationSucceeded_Landroidx_biometric_BiometricPrompt_AuthenticationResult_(jnienv, native__this, native_result);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("androidx/biometric/BiometricPrompt$AuthenticationCallback", DoNotGenerateAcw = true)]
	internal class AuthenticationCallbackInvoker : AuthenticationCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricPrompt$AuthenticationCallback", typeof(AuthenticationCallbackInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public AuthenticationCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/biometric/BiometricPrompt$AuthenticationResult", DoNotGenerateAcw = true)]
	public class AuthenticationResult : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricPrompt$AuthenticationResult", typeof(AuthenticationResult));

		private static Delegate? cb_getAuthenticationType_GetAuthenticationType_I;

		private static Delegate? cb_getCryptoObject_GetCryptoObject_Landroidx_biometric_BiometricPrompt_CryptoObject_;

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

		public unsafe virtual int AuthenticationType
		{
			[Register("getAuthenticationType", "()I", "GetGetAuthenticationTypeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAuthenticationType.()I", this, null);
			}
		}

		public unsafe virtual CryptoObject? CryptoObject
		{
			[Register("getCryptoObject", "()Landroidx/biometric/BiometricPrompt$CryptoObject;", "GetGetCryptoObjectHandler")]
			get
			{
				return Java.Lang.Object.GetObject<CryptoObject>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCryptoObject.()Landroidx/biometric/BiometricPrompt$CryptoObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected AuthenticationResult(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetAuthenticationTypeHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetAuthenticationType);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetAuthenticationType(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<AuthenticationResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AuthenticationType;
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

		private static Delegate GetGetCryptoObjectHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetCryptoObject);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetCryptoObject(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AuthenticationResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CryptoObject);
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
	}

	[Register("androidx/biometric/BiometricPrompt$CryptoObject", DoNotGenerateAcw = true)]
	public class CryptoObject : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricPrompt$CryptoObject", typeof(CryptoObject));

		private static Delegate? cb_getCipher_GetCipher_Ljavax_crypto_Cipher_;

		private static Delegate? cb_getIdentityCredential_GetIdentityCredential_Landroid_security_identity_IdentityCredential_;

		private static Delegate? cb_getMac_GetMac_Ljavax_crypto_Mac_;

		private static Delegate? cb_getSignature_GetSignature_Ljava_security_Signature_;

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

		public unsafe virtual Cipher? Cipher
		{
			[Register("getCipher", "()Ljavax/crypto/Cipher;", "GetGetCipherHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Cipher>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCipher.()Ljavax/crypto/Cipher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IdentityCredential? IdentityCredential
		{
			[Register("getIdentityCredential", "()Landroid/security/identity/IdentityCredential;", "GetGetIdentityCredentialHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IdentityCredential>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIdentityCredential.()Landroid/security/identity/IdentityCredential;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Mac? Mac
		{
			[Register("getMac", "()Ljavax/crypto/Mac;", "GetGetMacHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Mac>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMac.()Ljavax/crypto/Mac;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Signature? Signature
		{
			[Register("getSignature", "()Ljava/security/Signature;", "GetGetSignatureHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Signature>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSignature.()Ljava/security/Signature;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected CryptoObject(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/security/identity/IdentityCredential;)V", "")]
		public unsafe CryptoObject(IdentityCredential identityCredential)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(identityCredential?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/security/identity/IdentityCredential;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/security/identity/IdentityCredential;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(identityCredential);
			}
		}

		[Register(".ctor", "(Ljava/security/Signature;)V", "")]
		public unsafe CryptoObject(Signature signature)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(signature?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/security/Signature;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/security/Signature;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(signature);
			}
		}

		[Register(".ctor", "(Ljavax/crypto/Cipher;)V", "")]
		public unsafe CryptoObject(Cipher cipher)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cipher?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljavax/crypto/Cipher;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljavax/crypto/Cipher;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cipher);
			}
		}

		[Register(".ctor", "(Ljavax/crypto/Mac;)V", "")]
		public unsafe CryptoObject(Mac mac)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(mac?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljavax/crypto/Mac;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljavax/crypto/Mac;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(mac);
			}
		}

		private static Delegate GetGetCipherHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetCipher);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetCipher(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CryptoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cipher);
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

		private static Delegate GetGetIdentityCredentialHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetIdentityCredential);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetIdentityCredential(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CryptoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IdentityCredential);
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

		private static Delegate GetGetMacHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetMac);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetMac(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CryptoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mac);
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

		private static Delegate GetGetSignatureHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetSignature);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetSignature(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CryptoObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Signature);
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
	}

	[Register("androidx/biometric/BiometricPrompt$PromptInfo", DoNotGenerateAcw = true)]
	public class PromptInfo : Java.Lang.Object
	{
		[Register("androidx/biometric/BiometricPrompt$PromptInfo$Builder", DoNotGenerateAcw = true)]
		public class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricPrompt$PromptInfo$Builder", typeof(Builder));

			private static Delegate? cb_build_Build_Landroidx_biometric_BiometricPrompt_PromptInfo_;

			private static Delegate? cb_setAllowedAuthenticators_SetAllowedAuthenticators_I_Landroidx_biometric_BiometricPrompt_PromptInfo_Builder_;

			private static Delegate? cb_setConfirmationRequired_SetConfirmationRequired_Z_Landroidx_biometric_BiometricPrompt_PromptInfo_Builder_;

			private static Delegate? cb_setDescription_SetDescription_Ljava_lang_CharSequence__Landroidx_biometric_BiometricPrompt_PromptInfo_Builder_;

			private static Delegate? cb_setDeviceCredentialAllowed_SetDeviceCredentialAllowed_Z_Landroidx_biometric_BiometricPrompt_PromptInfo_Builder_;

			private static Delegate? cb_setNegativeButtonText_SetNegativeButtonText_Ljava_lang_CharSequence__Landroidx_biometric_BiometricPrompt_PromptInfo_Builder_;

			private static Delegate? cb_setSubtitle_SetSubtitle_Ljava_lang_CharSequence__Landroidx_biometric_BiometricPrompt_PromptInfo_Builder_;

			private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__Landroidx_biometric_BiometricPrompt_PromptInfo_Builder_;

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

			protected Builder(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Builder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle == IntPtr.Zero)
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetBuildHandler()
			{
				return new global::_JniMarshal_PP_L(n_Build);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_Build(nint jnienv, nint native__this)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
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

			[Register("build", "()Landroidx/biometric/BiometricPrompt$PromptInfo;", "GetBuildHandler")]
			public unsafe virtual PromptInfo Build()
			{
				return Java.Lang.Object.GetObject<PromptInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Landroidx/biometric/BiometricPrompt$PromptInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetAllowedAuthenticators_IHandler()
			{
				return new global::_JniMarshal_PPI_L(n_SetAllowedAuthenticators_I);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetAllowedAuthenticators_I(nint jnienv, nint native__this, int allowedAuthenticators)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAllowedAuthenticators(allowedAuthenticators));
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

			[Register("setAllowedAuthenticators", "(I)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", "GetSetAllowedAuthenticators_IHandler")]
			public unsafe virtual Builder SetAllowedAuthenticators(int allowedAuthenticators)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(allowedAuthenticators);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAllowedAuthenticators.(I)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetConfirmationRequired_ZHandler()
			{
				return new global::_JniMarshal_PPB_L(n_SetConfirmationRequired_Z);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetConfirmationRequired_Z(nint jnienv, nint native__this, sbyte native_confirmationRequired)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					bool confirmationRequired = native_confirmationRequired != 0;
					return JNIEnv.ToLocalJniHandle(builder.SetConfirmationRequired(confirmationRequired));
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

			[Register("setConfirmationRequired", "(Z)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", "GetSetConfirmationRequired_ZHandler")]
			public unsafe virtual Builder SetConfirmationRequired(bool confirmationRequired)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(confirmationRequired ? ((sbyte)1) : ((sbyte)0));
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setConfirmationRequired.(Z)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetDescription_Ljava_lang_CharSequence_Handler()
			{
				return new global::_JniMarshal_PPL_L(n_SetDescription_Ljava_lang_CharSequence_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_description)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					ICharSequence description = Java.Lang.Object.GetObject<ICharSequence>(native_description, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(builder.SetDescription(description));
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

			[Register("setDescription", "(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", "GetSetDescription_Ljava_lang_CharSequence_Handler")]
			public unsafe virtual Builder SetDescription(ICharSequence? description)
			{
				nint num = CharSequence.ToLocalJniHandle(description);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDescription.(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(description);
				}
			}

			public Builder SetDescription(string? description)
			{
				Java.Lang.String obj = ((description == null) ? null : new Java.Lang.String(description));
				Builder result = SetDescription(obj);
				obj?.Dispose();
				return result;
			}

			[Obsolete]
			private static Delegate GetSetDeviceCredentialAllowed_ZHandler()
			{
				return new global::_JniMarshal_PPB_L(n_SetDeviceCredentialAllowed_Z);
			}

			[Obsolete]
			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetDeviceCredentialAllowed_Z(nint jnienv, nint native__this, sbyte native_deviceCredentialAllowed)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					bool deviceCredentialAllowed = native_deviceCredentialAllowed != 0;
					return JNIEnv.ToLocalJniHandle(builder.SetDeviceCredentialAllowed(deviceCredentialAllowed));
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
			[Register("setDeviceCredentialAllowed", "(Z)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", "GetSetDeviceCredentialAllowed_ZHandler")]
			public unsafe virtual Builder SetDeviceCredentialAllowed(bool deviceCredentialAllowed)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(deviceCredentialAllowed ? ((sbyte)1) : ((sbyte)0));
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDeviceCredentialAllowed.(Z)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetSetNegativeButtonText_Ljava_lang_CharSequence_Handler()
			{
				return new global::_JniMarshal_PPL_L(n_SetNegativeButtonText_Ljava_lang_CharSequence_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetNegativeButtonText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_negativeButtonText)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					ICharSequence negativeButtonText = Java.Lang.Object.GetObject<ICharSequence>(native_negativeButtonText, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(builder.SetNegativeButtonText(negativeButtonText));
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

			[Register("setNegativeButtonText", "(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", "GetSetNegativeButtonText_Ljava_lang_CharSequence_Handler")]
			public unsafe virtual Builder SetNegativeButtonText(ICharSequence negativeButtonText)
			{
				nint num = CharSequence.ToLocalJniHandle(negativeButtonText);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNegativeButtonText.(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(negativeButtonText);
				}
			}

			public Builder SetNegativeButtonText(string negativeButtonText)
			{
				Java.Lang.String obj = ((negativeButtonText == null) ? null : new Java.Lang.String(negativeButtonText));
				Builder result = SetNegativeButtonText(obj);
				obj?.Dispose();
				return result;
			}

			private static Delegate GetSetSubtitle_Ljava_lang_CharSequence_Handler()
			{
				return new global::_JniMarshal_PPL_L(n_SetSubtitle_Ljava_lang_CharSequence_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetSubtitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_subtitle)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					ICharSequence subtitle = Java.Lang.Object.GetObject<ICharSequence>(native_subtitle, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(builder.SetSubtitle(subtitle));
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

			[Register("setSubtitle", "(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", "GetSetSubtitle_Ljava_lang_CharSequence_Handler")]
			public unsafe virtual Builder SetSubtitle(ICharSequence? subtitle)
			{
				nint num = CharSequence.ToLocalJniHandle(subtitle);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSubtitle.(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(subtitle);
				}
			}

			public Builder SetSubtitle(string? subtitle)
			{
				Java.Lang.String obj = ((subtitle == null) ? null : new Java.Lang.String(subtitle));
				Builder result = SetSubtitle(obj);
				obj?.Dispose();
				return result;
			}

			private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
			{
				return new global::_JniMarshal_PPL_L(n_SetTitle_Ljava_lang_CharSequence_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(builder.SetTitle(title));
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

			[Register("setTitle", "(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
			public unsafe virtual Builder SetTitle(ICharSequence title)
			{
				nint num = CharSequence.ToLocalJniHandle(title);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTitle.(Ljava/lang/CharSequence;)Landroidx/biometric/BiometricPrompt$PromptInfo$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(title);
				}
			}

			public Builder SetTitle(string title)
			{
				Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
				Builder result = SetTitle(obj);
				obj?.Dispose();
				return result;
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricPrompt$PromptInfo", typeof(PromptInfo));

		private static Delegate? cb_getAllowedAuthenticators_GetAllowedAuthenticators_I;

		private static Delegate? cb_getDescription_GetDescription_Ljava_lang_CharSequence_;

		private static Delegate? cb_isConfirmationRequired_IsConfirmationRequired_Z;

		private static Delegate? cb_isDeviceCredentialAllowed_IsDeviceCredentialAllowed_Z;

		private static Delegate? cb_getNegativeButtonText_GetNegativeButtonText_Ljava_lang_CharSequence_;

		private static Delegate? cb_getSubtitle_GetSubtitle_Ljava_lang_CharSequence_;

		private static Delegate? cb_getTitle_GetTitle_Ljava_lang_CharSequence_;

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

		public unsafe virtual int AllowedAuthenticators
		{
			[Register("getAllowedAuthenticators", "()I", "GetGetAllowedAuthenticatorsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAllowedAuthenticators.()I", this, null);
			}
		}

		public unsafe virtual ICharSequence? DescriptionFormatted
		{
			[Register("getDescription", "()Ljava/lang/CharSequence;", "GetGetDescriptionHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public string? Description
		{
			get
			{
				if (DescriptionFormatted != null)
				{
					return DescriptionFormatted.ToString();
				}
				return null;
			}
		}

		public unsafe virtual bool IsConfirmationRequired
		{
			[Register("isConfirmationRequired", "()Z", "GetIsConfirmationRequiredHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConfirmationRequired.()Z", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual bool IsDeviceCredentialAllowed
		{
			[Register("isDeviceCredentialAllowed", "()Z", "GetIsDeviceCredentialAllowedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDeviceCredentialAllowed.()Z", this, null);
			}
		}

		public unsafe virtual ICharSequence NegativeButtonTextFormatted
		{
			[Register("getNegativeButtonText", "()Ljava/lang/CharSequence;", "GetGetNegativeButtonTextHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNegativeButtonText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public string? NegativeButtonText
		{
			get
			{
				if (NegativeButtonTextFormatted != null)
				{
					return NegativeButtonTextFormatted.ToString();
				}
				return null;
			}
		}

		public unsafe virtual ICharSequence? SubtitleFormatted
		{
			[Register("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSubtitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public string? Subtitle
		{
			get
			{
				if (SubtitleFormatted != null)
				{
					return SubtitleFormatted.ToString();
				}
				return null;
			}
		}

		public unsafe virtual ICharSequence TitleFormatted
		{
			[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public string? Title
		{
			get
			{
				if (TitleFormatted != null)
				{
					return TitleFormatted.ToString();
				}
				return null;
			}
		}

		protected PromptInfo(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetAllowedAuthenticatorsHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetAllowedAuthenticators);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetAllowedAuthenticators(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<PromptInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowedAuthenticators;
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

		private static Delegate GetGetDescriptionHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetDescription);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetDescription(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<PromptInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DescriptionFormatted);
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

		private static Delegate GetIsConfirmationRequiredHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsConfirmationRequired);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsConfirmationRequired(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<PromptInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConfirmationRequired ? ((sbyte)1) : ((sbyte)0);
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

		[Obsolete]
		private static Delegate GetIsDeviceCredentialAllowedHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsDeviceCredentialAllowed);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsDeviceCredentialAllowed(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<PromptInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDeviceCredentialAllowed ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetNegativeButtonTextHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetNegativeButtonText);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetNegativeButtonText(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<PromptInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NegativeButtonTextFormatted);
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

		private static Delegate GetGetSubtitleHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetSubtitle);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetSubtitle(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<PromptInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubtitleFormatted);
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

		private static Delegate GetGetTitleHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetTitle);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetTitle(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<PromptInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleFormatted);
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/biometric/BiometricPrompt", typeof(BiometricPrompt));

	private static Delegate? cb_authenticate_Authenticate_Landroidx_biometric_BiometricPrompt_PromptInfo__V;

	private static Delegate? cb_authenticate_Authenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_Landroidx_biometric_BiometricPrompt_CryptoObject__V;

	private static Delegate? cb_cancelAuthentication_CancelAuthentication_V;

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

	protected BiometricPrompt(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/fragment/app/Fragment;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", "")]
	public unsafe BiometricPrompt(AndroidX.Fragment.App.Fragment fragment, AuthenticationCallback callback)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(callback);
		}
	}

	[Register(".ctor", "(Landroidx/fragment/app/Fragment;Ljava/util/concurrent/Executor;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", "")]
	public unsafe BiometricPrompt(AndroidX.Fragment.App.Fragment fragment, IExecutor executor, AuthenticationCallback callback)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/Fragment;Ljava/util/concurrent/Executor;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/Fragment;Ljava/util/concurrent/Executor;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(fragment);
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}

	[Register(".ctor", "(Landroidx/fragment/app/FragmentActivity;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", "")]
	public unsafe BiometricPrompt(FragmentActivity activity, AuthenticationCallback callback)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(((Java.Lang.Object)(object)activity)?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/FragmentActivity;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/FragmentActivity;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(callback);
		}
	}

	[Register(".ctor", "(Landroidx/fragment/app/FragmentActivity;Ljava/util/concurrent/Executor;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", "")]
	public unsafe BiometricPrompt(FragmentActivity activity, IExecutor executor, AuthenticationCallback callback)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(((Java.Lang.Object)(object)activity)?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/fragment/app/FragmentActivity;Ljava/util/concurrent/Executor;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/fragment/app/FragmentActivity;Ljava/util/concurrent/Executor;Landroidx/biometric/BiometricPrompt$AuthenticationCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetAuthenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Authenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Authenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_(nint jnienv, nint native__this, nint native_info)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BiometricPrompt? biometricPrompt = Java.Lang.Object.GetObject<BiometricPrompt>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PromptInfo info = Java.Lang.Object.GetObject<PromptInfo>(native_info, JniHandleOwnership.DoNotTransfer);
			biometricPrompt.Authenticate(info);
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

	[Register("authenticate", "(Landroidx/biometric/BiometricPrompt$PromptInfo;)V", "GetAuthenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_Handler")]
	public unsafe virtual void Authenticate(PromptInfo info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("authenticate.(Landroidx/biometric/BiometricPrompt$PromptInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(info);
		}
	}

	private static Delegate GetAuthenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_Landroidx_biometric_BiometricPrompt_CryptoObject_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Authenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_Landroidx_biometric_BiometricPrompt_CryptoObject_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Authenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_Landroidx_biometric_BiometricPrompt_CryptoObject_(nint jnienv, nint native__this, nint native_info, nint native_crypto)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BiometricPrompt? biometricPrompt = Java.Lang.Object.GetObject<BiometricPrompt>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PromptInfo info = Java.Lang.Object.GetObject<PromptInfo>(native_info, JniHandleOwnership.DoNotTransfer);
			CryptoObject crypto = Java.Lang.Object.GetObject<CryptoObject>(native_crypto, JniHandleOwnership.DoNotTransfer);
			biometricPrompt.Authenticate(info, crypto);
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

	[Register("authenticate", "(Landroidx/biometric/BiometricPrompt$PromptInfo;Landroidx/biometric/BiometricPrompt$CryptoObject;)V", "GetAuthenticate_Landroidx_biometric_BiometricPrompt_PromptInfo_Landroidx_biometric_BiometricPrompt_CryptoObject_Handler")]
	public unsafe virtual void Authenticate(PromptInfo info, CryptoObject crypto)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(crypto?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("authenticate.(Landroidx/biometric/BiometricPrompt$PromptInfo;Landroidx/biometric/BiometricPrompt$CryptoObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(info);
			GC.KeepAlive(crypto);
		}
	}

	private static Delegate GetCancelAuthenticationHandler()
	{
		return new global::_JniMarshal_PP_V(n_CancelAuthentication);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CancelAuthentication(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BiometricPrompt>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelAuthentication();
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

	[Register("cancelAuthentication", "()V", "GetCancelAuthenticationHandler")]
	public unsafe virtual void CancelAuthentication()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("cancelAuthentication.()V", this, null);
	}
}

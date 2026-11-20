using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Net;
using Java.Security;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/GlideUrl", DoNotGenerateAcw = true)]
public class GlideUrl : Java.Lang.Object, IKey, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/model/GlideUrl", typeof(GlideUrl));

	private static Delegate? cb_getCacheKey_GetCacheKey_Ljava_lang_String_;

	private static Delegate? cb_getHeaders_GetHeaders_Ljava_util_Map_;

	private static Delegate? cb_toStringUrl_ToStringUrl_Ljava_lang_String_;

	private static Delegate? cb_toURL_ToURL_Ljava_net_URL_;

	private static Delegate? cb_updateDiskCacheKey_UpdateDiskCacheKey_Ljava_security_MessageDigest__V;

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

	public unsafe virtual string? CacheKey
	{
		[Register("getCacheKey", "()Ljava/lang/String;", "GetGetCacheKeyHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getCacheKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IDictionary<string, string>? Headers
	{
		[Register("getHeaders", "()Ljava/util/Map;", "GetGetHeadersHandler")]
		get
		{
			return JavaDictionary<string, string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeaders.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected GlideUrl(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe GlideUrl(string? url)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(url);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Lcom/bumptech/glide/load/model/Headers;)V", "")]
	public unsafe GlideUrl(string? url, IHeaders? headers)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(url);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((headers == null) ? IntPtr.Zero : ((Java.Lang.Object)headers).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/bumptech/glide/load/model/Headers;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/bumptech/glide/load/model/Headers;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(headers);
		}
	}

	[Register(".ctor", "(Ljava/net/URL;)V", "")]
	public unsafe GlideUrl(URL? url)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/net/URL;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/net/URL;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(url);
		}
	}

	[Register(".ctor", "(Ljava/net/URL;Lcom/bumptech/glide/load/model/Headers;)V", "")]
	public unsafe GlideUrl(URL? url, IHeaders? headers)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(url?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((headers == null) ? IntPtr.Zero : ((Java.Lang.Object)headers).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/net/URL;Lcom/bumptech/glide/load/model/Headers;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/net/URL;Lcom/bumptech/glide/load/model/Headers;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(url);
			GC.KeepAlive(headers);
		}
	}

	private static Delegate GetGetCacheKeyHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCacheKey);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCacheKey(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<GlideUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CacheKey);
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

	private static Delegate GetGetHeadersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHeaders);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHeaders(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<GlideUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Headers);
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

	private static Delegate GetToStringUrlHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToStringUrl);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToStringUrl(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<GlideUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToStringUrl());
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

	[Register("toStringUrl", "()Ljava/lang/String;", "GetToStringUrlHandler")]
	public unsafe virtual string? ToStringUrl()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toStringUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetToURLHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToURL);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToURL(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GlideUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToURL());
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

	[Register("toURL", "()Ljava/net/URL;", "GetToURLHandler")]
	public unsafe virtual URL? ToURL()
	{
		return Java.Lang.Object.GetObject<URL>(_members.InstanceMethods.InvokeVirtualObjectMethod("toURL.()Ljava/net/URL;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateDiskCacheKey_Ljava_security_MessageDigest_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDiskCacheKey_Ljava_security_MessageDigest_(nint jnienv, nint native__this, nint native_messageDigest)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GlideUrl? glideUrl = Java.Lang.Object.GetObject<GlideUrl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MessageDigest messageDigest = Java.Lang.Object.GetObject<MessageDigest>(native_messageDigest, JniHandleOwnership.DoNotTransfer);
			glideUrl.UpdateDiskCacheKey(messageDigest);
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

	[Register("updateDiskCacheKey", "(Ljava/security/MessageDigest;)V", "GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler")]
	public unsafe virtual void UpdateDiskCacheKey(MessageDigest messageDigest)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(messageDigest?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateDiskCacheKey.(Ljava/security/MessageDigest;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(messageDigest);
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

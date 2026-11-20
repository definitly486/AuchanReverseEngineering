using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Config$Option", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T" })]
public abstract class ConfigOption : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Config$Option", typeof(ConfigOption));

	private static Delegate? cb_getId;

	private static Delegate? cb_getToken;

	private static Delegate? cb_getValueClass;

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

	public abstract string Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
		get;
	}

	public abstract Java.Lang.Object? Token
	{
		[Register("getToken", "()Ljava/lang/Object;", "GetGetTokenHandler")]
		get;
	}

	public abstract Class ValueClass
	{
		[Register("getValueClass", "()Ljava/lang/Class;", "GetGetValueClassHandler")]
		get;
	}

	protected ConfigOption(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetIdHandler()
	{
		if ((object)cb_getId == null)
		{
			cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetId));
		}
		return cb_getId;
	}

	private static nint n_GetId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ConfigOption>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
	}

	private static Delegate GetGetTokenHandler()
	{
		if ((object)cb_getToken == null)
		{
			cb_getToken = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetToken));
		}
		return cb_getToken;
	}

	private static nint n_GetToken(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConfigOption>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Token);
	}

	private static Delegate GetGetValueClassHandler()
	{
		if ((object)cb_getValueClass == null)
		{
			cb_getValueClass = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetValueClass));
		}
		return cb_getValueClass;
	}

	private static nint n_GetValueClass(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConfigOption>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueClass);
	}

	[Register("create", "(Ljava/lang/String;Ljava/lang/Class;)Landroidx/camera/core/impl/Config$Option;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static ConfigOption Create(string id, Class valueClass)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(valueClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ConfigOption>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/String;Ljava/lang/Class;)Landroidx/camera/core/impl/Config$Option;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(valueClass);
		}
	}

	[Register("create", "(Ljava/lang/String;Ljava/lang/Class;Ljava/lang/Object;)Landroidx/camera/core/impl/Config$Option;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static ConfigOption Create(string id, Class valueClass, Java.Lang.Object? token)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(valueClass?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(token?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ConfigOption>(_members.StaticMethods.InvokeObjectMethod("create.(Ljava/lang/String;Ljava/lang/Class;Ljava/lang/Object;)Landroidx/camera/core/impl/Config$Option;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(valueClass);
			GC.KeepAlive(token);
		}
	}
}

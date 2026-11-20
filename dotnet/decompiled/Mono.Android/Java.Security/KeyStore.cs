using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security.Cert;

namespace Java.Security;

[Register("java/security/KeyStore", DoNotGenerateAcw = true)]
public class KeyStore : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/KeyStore", typeof(KeyStore));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static string? DefaultType
	{
		[Register("getDefaultType", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getDefaultType.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected KeyStore(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getInstance", "(Ljava/lang/String;)Ljava/security/KeyStore;", "")]
	public unsafe static KeyStore? GetInstance(string? type)
	{
		nint num = JNIEnv.NewString(type);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<KeyStore>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Ljava/lang/String;)Ljava/security/KeyStore;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("load", "(Ljava/io/InputStream;[C)V", "")]
	public unsafe void Load(Stream? stream, char[]? password)
	{
		nint num = InputStreamAdapter.ToLocalJniHandle(stream);
		nint num2 = JNIEnv.NewArray(password);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("load.(Ljava/io/InputStream;[C)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (password != null)
			{
				JNIEnv.CopyArray(num2, password);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(stream);
			GC.KeepAlive(password);
		}
	}

	[Register("setCertificateEntry", "(Ljava/lang/String;Ljava/security/cert/Certificate;)V", "")]
	public unsafe void SetCertificateEntry(string? alias, Certificate? cert)
	{
		nint num = JNIEnv.NewString(alias);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(cert?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setCertificateEntry.(Ljava/lang/String;Ljava/security/cert/Certificate;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cert);
		}
	}

	[Register("setKeyEntry", "(Ljava/lang/String;Ljava/security/Key;[C[Ljava/security/cert/Certificate;)V", "")]
	public unsafe void SetKeyEntry(string? alias, IKey? key, char[]? password, Certificate[]? chain)
	{
		nint num = JNIEnv.NewString(alias);
		nint num2 = JNIEnv.NewArray(password);
		nint num3 = JNIEnv.NewArray(chain);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(num3);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setKeyEntry.(Ljava/lang/String;Ljava/security/Key;[C[Ljava/security/cert/Certificate;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			if (password != null)
			{
				JNIEnv.CopyArray(num2, password);
				JNIEnv.DeleteLocalRef(num2);
			}
			if (chain != null)
			{
				JNIEnv.CopyArray(num3, chain);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(key);
			GC.KeepAlive(password);
			GC.KeepAlive(chain);
		}
	}
}

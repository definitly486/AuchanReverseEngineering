using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/Options", DoNotGenerateAcw = true)]
public sealed class Options : Java.Lang.Object, IKey, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/Options", typeof(Options));

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

	internal Options(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Options()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("get", "(Lcom/bumptech/glide/load/Option;)Ljava/lang/Object;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe Java.Lang.Object? Get(Option option)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(option?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(Lcom/bumptech/glide/load/Option;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(option);
		}
	}

	[Register("putAll", "(Lcom/bumptech/glide/load/Options;)V", "")]
	public unsafe void PutAll(Options other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("putAll.(Lcom/bumptech/glide/load/Options;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	[Register("remove", "(Lcom/bumptech/glide/load/Option;)Lcom/bumptech/glide/load/Options;", "")]
	public unsafe Options? Remove(Option option)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(option?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Options>(_members.InstanceMethods.InvokeAbstractObjectMethod("remove.(Lcom/bumptech/glide/load/Option;)Lcom/bumptech/glide/load/Options;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(option);
		}
	}

	[Register("set", "(Lcom/bumptech/glide/load/Option;Ljava/lang/Object;)Lcom/bumptech/glide/load/Options;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe Options Set(Option option, Java.Lang.Object value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(option?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Options>(_members.InstanceMethods.InvokeAbstractObjectMethod("set.(Lcom/bumptech/glide/load/Option;Ljava/lang/Object;)Lcom/bumptech/glide/load/Options;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(option);
			GC.KeepAlive(value);
		}
	}

	[Register("updateDiskCacheKey", "(Ljava/security/MessageDigest;)V", "")]
	public unsafe void UpdateDiskCacheKey(MessageDigest messageDigest)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(messageDigest?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("updateDiskCacheKey.(Ljava/security/MessageDigest;)V", this, ptr);
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

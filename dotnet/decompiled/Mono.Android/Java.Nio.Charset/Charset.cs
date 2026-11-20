using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Nio.Charset;

[Register("java/nio/charset/Charset", DoNotGenerateAcw = true)]
public abstract class Charset : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/nio/charset/Charset", typeof(Charset));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Charset(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "")]
	public unsafe sealed override bool Equals(Java.Lang.Object? ob)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(ob?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(ob);
		}
	}

	[Register("hashCode", "()I", "")]
	public unsafe sealed override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
	}

	[Register("toString", "()Ljava/lang/String;", "")]
	public unsafe sealed override string? ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

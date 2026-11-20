using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Enum", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "E extends java.lang.Enum<E>" })]
public abstract class Enum : Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Enum", typeof(Enum));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Enum(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("clone", "()Ljava/lang/Object;", "")]
	protected unsafe sealed override Object Clone()
	{
		return Object.GetObject<Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("clone.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "")]
	public unsafe sealed override bool Equals(Object? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	[Register("hashCode", "()I", "")]
	public unsafe sealed override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeNonvirtualInt32Method("hashCode.()I", this, null);
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

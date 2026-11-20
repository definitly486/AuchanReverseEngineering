using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang.Reflect;

[Register("java/lang/reflect/Field", DoNotGenerateAcw = true)]
public sealed class Field : AccessibleObject, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/reflect/Field", typeof(Field));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal Field(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("get", "(Ljava/lang/Object;)Ljava/lang/Object;", "")]
	public unsafe Object? Get(Object? obj)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			return Object.GetObject<Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(Ljava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(obj);
		}
	}

	[Register("set", "(Ljava/lang/Object;Ljava/lang/Object;)V", "")]
	public unsafe void Set(Object? obj, Object? value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("set.(Ljava/lang/Object;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
			GC.KeepAlive(value);
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

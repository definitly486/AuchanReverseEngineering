using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/AbstractSet", DoNotGenerateAcw = true)]
internal class AbstractSetInvoker : AbstractSet, ISet, ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/AbstractSet", typeof(AbstractSetInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public AbstractSetInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("iterator", "()Ljava/util/Iterator;", "GetIteratorHandler")]
	public unsafe override IIterator Iterator()
	{
		return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("size", "()I", "GetSizeHandler")]
	public unsafe override int Size()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
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

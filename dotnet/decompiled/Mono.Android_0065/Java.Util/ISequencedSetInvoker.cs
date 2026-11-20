using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/SequencedSet", DoNotGenerateAcw = true, ApiSince = 35)]
internal class ISequencedSetInvoker : Java.Lang.Object, ISequencedSet, ISequencedCollection, ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable, ISet
{
	private static readonly JniPeerMembers _members_java_lang_Iterable = new XAPeerMembers("java/lang/Iterable", typeof(ISequencedSetInvoker));

	private static readonly JniPeerMembers _members_java_util_Collection = new XAPeerMembers("java/util/Collection", typeof(ISequencedSetInvoker));

	private static readonly JniPeerMembers _members_java_util_SequencedCollection = new XAPeerMembers("java/util/SequencedCollection", typeof(ISequencedSetInvoker));

	private static readonly JniPeerMembers _members_java_util_SequencedSet = new XAPeerMembers("java/util/SequencedSet", typeof(ISequencedSetInvoker));

	private static readonly JniPeerMembers _members_java_util_Set = new XAPeerMembers("java/util/Set", typeof(ISequencedSetInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_SequencedSet;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_SequencedSet.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_SequencedSet.ManagedPeerType;

	public unsafe bool IsEmpty => _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	public ISequencedSetInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android35.0")]
	public unsafe ISequencedCollection? Reversed()
	{
		return Java.Lang.Object.GetObject<ISequencedCollection>(_members_java_util_SequencedCollection.InstanceMethods.InvokeAbstractObjectMethod("reversed.()Ljava/util/SequencedCollection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe bool Add(Java.Lang.Object? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(e);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("add.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e);
		}
	}

	public unsafe bool AddAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("addAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	public unsafe void Clear()
	{
		_members_java_util_Collection.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	public unsafe bool Contains(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	public unsafe bool ContainsAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("containsAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	public new unsafe bool Equals(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	public new unsafe int GetHashCode()
	{
		return _members_java_util_Collection.InstanceMethods.InvokeAbstractInt32Method("hashCode.()I", this, null);
	}

	public unsafe IIterator Iterator()
	{
		return Java.Lang.Object.GetObject<IIterator>(_members_java_util_Collection.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe bool Remove(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("remove.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	public unsafe bool RemoveAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("removeAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	public unsafe bool RetainAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("retainAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	public unsafe int Size()
	{
		return _members_java_util_Collection.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
	}

	public unsafe Java.Lang.Object[] ToArray()
	{
		return (Java.Lang.Object[])JNIEnv.GetArray(_members_java_util_Collection.InstanceMethods.InvokeAbstractObjectMethod("toArray.()[Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
	}

	public unsafe Java.Lang.Object[] ToArray(Java.Lang.Object[] a)
	{
		nint num = JNIEnv.NewArray(a);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members_java_util_Collection.InstanceMethods.InvokeAbstractObjectMethod("toArray.([Ljava/lang/Object;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
		}
		finally
		{
			if (a != null)
			{
				JNIEnv.CopyArray(num, a);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(a);
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

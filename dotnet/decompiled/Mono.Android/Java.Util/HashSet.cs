using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/HashSet", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "E" })]
public class HashSet : AbstractSet, ISerializable, IJavaObject, IDisposable, IJavaPeerable, ISet, ICollection, IIterable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/HashSet", typeof(HashSet));

	private static Delegate? cb_clone_Clone_Ljava_lang_Object_;

	private static Delegate? cb_iterator_Iterator_Ljava_util_Iterator_;

	private static Delegate? cb_size_Size_I;

	private static Delegate? cb_spliterator_Spliterator_Ljava_util_Spliterator_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected HashSet(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetCloneHandler()
	{
		return new _JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<HashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Ljava/lang/Object;", "GetCloneHandler")]
	public new unsafe virtual Java.Lang.Object Clone()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIteratorHandler()
	{
		return new _JniMarshal_PP_L(n_Iterator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Iterator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<HashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Iterator());
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

	[Register("iterator", "()Ljava/util/Iterator;", "GetIteratorHandler")]
	public unsafe override IIterator Iterator()
	{
		return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSizeHandler()
	{
		return new _JniMarshal_PP_I(n_Size);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Size(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<HashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

	[Register("size", "()I", "GetSizeHandler")]
	public unsafe override int Size()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetSpliteratorHandler()
	{
		return new _JniMarshal_PP_L(n_Spliterator);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Spliterator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<HashSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Spliterator());
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

	[SupportedOSPlatform("android24.0")]
	[Register("spliterator", "()Ljava/util/Spliterator;", "GetSpliteratorHandler", ApiSince = 24)]
	public unsafe virtual ISpliterator Spliterator()
	{
		return Java.Lang.Object.GetObject<ISpliterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("spliterator.()Ljava/util/Spliterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

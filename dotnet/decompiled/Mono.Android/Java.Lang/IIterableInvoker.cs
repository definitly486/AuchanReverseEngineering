using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Util;

namespace Java.Lang;

[Register("java/lang/Iterable", DoNotGenerateAcw = true)]
internal class IIterableInvoker : Object, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_lang_Iterable = new XAPeerMembers("java/lang/Iterable", typeof(IIterableInvoker));

	private static Delegate? cb_iterator_Iterator_Ljava_util_Iterator_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_lang_Iterable;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_lang_Iterable.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_lang_Iterable.ManagedPeerType;

	public IIterableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			return JNIEnv.ToLocalJniHandle(Object.GetObject<IIterable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Iterator());
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

	public unsafe IIterator Iterator()
	{
		return Object.GetObject<IIterator>(_members_java_lang_Iterable.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

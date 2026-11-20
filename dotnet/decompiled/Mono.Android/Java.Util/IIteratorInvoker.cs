using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Iterator", DoNotGenerateAcw = true)]
internal class IIteratorInvoker : Java.Lang.Object, IIterator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_Iterator = new XAPeerMembers("java/util/Iterator", typeof(IIteratorInvoker));

	private static Delegate? cb_hasNext_HasNext_Z;

	private static Delegate? cb_next_Next_Ljava_lang_Object_;

	private static Delegate? cb_remove_Remove_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_Iterator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_Iterator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_Iterator.ManagedPeerType;

	public unsafe bool HasNext => _members_java_util_Iterator.InstanceMethods.InvokeAbstractBooleanMethod("hasNext.()Z", this, null);

	public IIteratorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetHasNextHandler()
	{
		return new _JniMarshal_PP_B(n_HasNext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasNext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasNext ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetNextHandler()
	{
		return new _JniMarshal_PP_L(n_Next);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Next(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Next());
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

	public unsafe Java.Lang.Object? Next()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_Iterator.InstanceMethods.InvokeAbstractObjectMethod("next.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveHandler()
	{
		return new _JniMarshal_PP_V(n_Remove);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Remove(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void Remove()
	{
		_members_java_util_Iterator.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
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

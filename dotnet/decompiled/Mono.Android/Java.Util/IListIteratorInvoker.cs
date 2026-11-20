using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/ListIterator", DoNotGenerateAcw = true)]
internal class IListIteratorInvoker : Java.Lang.Object, IListIterator, IIterator, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_Iterator = new XAPeerMembers("java/util/Iterator", typeof(IListIteratorInvoker));

	private static readonly JniPeerMembers _members_java_util_ListIterator = new XAPeerMembers("java/util/ListIterator", typeof(IListIteratorInvoker));

	private static Delegate? cb_hasNext_HasNext_Z;

	private static Delegate? cb_hasPrevious_HasPrevious_Z;

	private static Delegate? cb_add_Add_Ljava_lang_Object__V;

	private static Delegate? cb_next_Next_Ljava_lang_Object_;

	private static Delegate? cb_nextIndex_NextIndex_I;

	private static Delegate? cb_previous_Previous_Ljava_lang_Object_;

	private static Delegate? cb_previousIndex_PreviousIndex_I;

	private static Delegate? cb_remove_Remove_V;

	private static Delegate? cb_set_Set_Ljava_lang_Object__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_ListIterator;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_ListIterator.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_ListIterator.ManagedPeerType;

	public unsafe bool HasNext => _members_java_util_ListIterator.InstanceMethods.InvokeAbstractBooleanMethod("hasNext.()Z", this, null);

	public unsafe bool HasPrevious => _members_java_util_ListIterator.InstanceMethods.InvokeAbstractBooleanMethod("hasPrevious.()Z", this, null);

	public IListIteratorInvoker(nint handle, JniHandleOwnership transfer)
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
			return Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasNext ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasPreviousHandler()
	{
		return new _JniMarshal_PP_B(n_HasPrevious);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasPrevious(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasPrevious ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetAdd_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_Add_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IListIterator? listIterator = Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			listIterator.Add(e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void Add(Java.Lang.Object? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(e);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_java_util_ListIterator.InstanceMethods.InvokeAbstractVoidMethod("add.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Next());
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
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_ListIterator.InstanceMethods.InvokeAbstractObjectMethod("next.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetNextIndexHandler()
	{
		return new _JniMarshal_PP_I(n_NextIndex);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_NextIndex(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NextIndex();
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

	public unsafe int NextIndex()
	{
		return _members_java_util_ListIterator.InstanceMethods.InvokeAbstractInt32Method("nextIndex.()I", this, null);
	}

	private static Delegate GetPreviousHandler()
	{
		return new _JniMarshal_PP_L(n_Previous);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Previous(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Previous());
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

	public unsafe Java.Lang.Object? Previous()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_ListIterator.InstanceMethods.InvokeAbstractObjectMethod("previous.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetPreviousIndexHandler()
	{
		return new _JniMarshal_PP_I(n_PreviousIndex);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_PreviousIndex(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviousIndex();
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

	public unsafe int PreviousIndex()
	{
		return _members_java_util_ListIterator.InstanceMethods.InvokeAbstractInt32Method("previousIndex.()I", this, null);
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
			Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
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
		_members_java_util_ListIterator.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}

	private static Delegate GetSet_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_Set_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Set_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IListIterator? listIterator = Java.Lang.Object.GetObject<IListIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			listIterator.Set(e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void Set(Java.Lang.Object? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(e);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_java_util_ListIterator.InstanceMethods.InvokeAbstractVoidMethod("set.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e);
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

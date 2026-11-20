using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/AbstractCollection", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "E" })]
public abstract class AbstractCollection : Java.Lang.Object, ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/AbstractCollection", typeof(AbstractCollection));

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_add_Add_Ljava_lang_Object__Z;

	private static Delegate? cb_addAll_AddAll_Ljava_util_Collection__Z;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_contains_Contains_Ljava_lang_Object__Z;

	private static Delegate? cb_containsAll_ContainsAll_Ljava_util_Collection__Z;

	private static Delegate? cb_iterator_Iterator_Ljava_util_Iterator_;

	private static Delegate? cb_remove_Remove_Ljava_lang_Object__Z;

	private static Delegate? cb_removeAll_RemoveAll_Ljava_util_Collection__Z;

	private static Delegate? cb_retainAll_RetainAll_Ljava_util_Collection__Z;

	private static Delegate? cb_size_Size_I;

	private static Delegate? cb_toArray_ToArray_arrayLjava_lang_Object_;

	private static Delegate? cb_toArray_ToArray_arrayLjava_lang_Object__arrayLjava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	protected AbstractCollection(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetIsEmptyHandler()
	{
		return new _JniMarshal_PP_B(n_IsEmpty);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmpty(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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
		return new _JniMarshal_PPL_B(n_Add_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Add_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			return abstractCollection.Add(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("add", "(Ljava/lang/Object;)Z", "GetAdd_Ljava_lang_Object_Handler")]
	public unsafe virtual bool Add(Java.Lang.Object? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("add.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetAddAll_Ljava_util_Collection_Handler()
	{
		return new _JniMarshal_PPL_B(n_AddAll_Ljava_util_Collection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_AddAll_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return abstractCollection.AddAll(c) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("addAll", "(Ljava/util/Collection;)Z", "GetAddAll_Ljava_util_Collection_Handler")]
	public unsafe virtual bool AddAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("addAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetClearHandler()
	{
		return new _JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	[Register("clear", "()V", "GetClearHandler")]
	public unsafe virtual void Clear()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetContains_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_B(n_Contains_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Contains_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return abstractCollection.Contains(o) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("contains", "(Ljava/lang/Object;)Z", "GetContains_Ljava_lang_Object_Handler")]
	public unsafe virtual bool Contains(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("contains.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetContainsAll_Ljava_util_Collection_Handler()
	{
		return new _JniMarshal_PPL_B(n_ContainsAll_Ljava_util_Collection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ContainsAll_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return abstractCollection.ContainsAll(c) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("containsAll", "(Ljava/util/Collection;)Z", "GetContainsAll_Ljava_util_Collection_Handler")]
	public unsafe virtual bool ContainsAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Iterator());
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
	public abstract IIterator Iterator();

	private static Delegate GetRemove_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_B(n_Remove_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Remove_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return abstractCollection.Remove(o) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("remove", "(Ljava/lang/Object;)Z", "GetRemove_Ljava_lang_Object_Handler")]
	public unsafe virtual bool Remove(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("remove.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetRemoveAll_Ljava_util_Collection_Handler()
	{
		return new _JniMarshal_PPL_B(n_RemoveAll_Ljava_util_Collection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveAll_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return abstractCollection.RemoveAll(c) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("removeAll", "(Ljava/util/Collection;)Z", "GetRemoveAll_Ljava_util_Collection_Handler")]
	public unsafe virtual bool RemoveAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetRetainAll_Ljava_util_Collection_Handler()
	{
		return new _JniMarshal_PPL_B(n_RetainAll_Ljava_util_Collection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RetainAll_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return abstractCollection.RetainAll(c) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("retainAll", "(Ljava/util/Collection;)Z", "GetRetainAll_Ljava_util_Collection_Handler")]
	public unsafe virtual bool RetainAll(System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("retainAll.(Ljava/util/Collection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
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
			return Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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
	public abstract int Size();

	private static Delegate GetToArrayHandler()
	{
		return new _JniMarshal_PP_L(n_ToArray);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToArray(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToArray());
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

	[Register("toArray", "()[Ljava/lang/Object;", "GetToArrayHandler")]
	public unsafe virtual Java.Lang.Object[] ToArray()
	{
		return (Java.Lang.Object[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("toArray.()[Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
	}

	private static Delegate GetToArray_arrayLjava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_L(n_ToArray_arrayLjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToArray_arrayLjava_lang_Object_(nint jnienv, nint native__this, nint native_a)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AbstractCollection? abstractCollection = Java.Lang.Object.GetObject<AbstractCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_a, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
			nint result = JNIEnv.NewArray(abstractCollection.ToArray(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_a);
			}
			return result;
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

	[Register("toArray", "([Ljava/lang/Object;)[Ljava/lang/Object;", "GetToArray_arrayLjava_lang_Object_Handler")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe virtual Java.Lang.Object[] ToArray(Java.Lang.Object[] a)
	{
		nint num = JNIEnv.NewArray(a);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("toArray.([Ljava/lang/Object;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
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

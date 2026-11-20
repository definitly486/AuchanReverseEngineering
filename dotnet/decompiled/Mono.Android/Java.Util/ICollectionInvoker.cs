using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Collection", DoNotGenerateAcw = true)]
internal class ICollectionInvoker : Java.Lang.Object, ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_lang_Iterable = new XAPeerMembers("java/lang/Iterable", typeof(ICollectionInvoker));

	private static readonly JniPeerMembers _members_java_util_Collection = new XAPeerMembers("java/util/Collection", typeof(ICollectionInvoker));

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_add_Add_Ljava_lang_Object__Z;

	private static Delegate? cb_addAll_AddAll_Ljava_util_Collection__Z;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_contains_Contains_Ljava_lang_Object__Z;

	private static Delegate? cb_containsAll_ContainsAll_Ljava_util_Collection__Z;

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	private static Delegate? cb_hashCode_GetHashCode_I;

	private static Delegate? cb_iterator_Iterator_Ljava_util_Iterator_;

	private static Delegate? cb_remove_Remove_Ljava_lang_Object__Z;

	private static Delegate? cb_removeAll_RemoveAll_Ljava_util_Collection__Z;

	private static Delegate? cb_retainAll_RetainAll_Ljava_util_Collection__Z;

	private static Delegate? cb_size_Size_I;

	private static Delegate? cb_toArray_ToArray_arrayLjava_lang_Object_;

	private static Delegate? cb_toArray_ToArray_arrayLjava_lang_Object__arrayLjava_lang_Object_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_Collection;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_Collection.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_Collection.ManagedPeerType;

	public unsafe bool IsEmpty => _members_java_util_Collection.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	public ICollectionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
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
			return Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			return collection.Add(e) ? ((sbyte)1) : ((sbyte)0);
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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return collection.AddAll(c) ? ((sbyte)1) : ((sbyte)0);
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
			Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	public unsafe void Clear()
	{
		_members_java_util_Collection.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return collection.Contains(o) ? ((sbyte)1) : ((sbyte)0);
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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return collection.ContainsAll(c) ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_B(n_Equals_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Equals_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return collection.Equals(o) ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetHashCodeHandler()
	{
		return new _JniMarshal_PP_I(n_GetHashCode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHashCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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

	public new unsafe int GetHashCode()
	{
		return _members_java_util_Collection.InstanceMethods.InvokeAbstractInt32Method("hashCode.()I", this, null);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Iterator());
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
		return Java.Lang.Object.GetObject<IIterator>(_members_java_util_Collection.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return collection.Remove(o) ? ((sbyte)1) : ((sbyte)0);
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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return collection.RemoveAll(c) ? ((sbyte)1) : ((sbyte)0);
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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return collection.RetainAll(c) ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

	public unsafe int Size()
	{
		return _members_java_util_Collection.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
	}

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
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToArray());
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

	public unsafe Java.Lang.Object[] ToArray()
	{
		return (Java.Lang.Object[])JNIEnv.GetArray(_members_java_util_Collection.InstanceMethods.InvokeAbstractObjectMethod("toArray.()[Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
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
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_a, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
			nint result = JNIEnv.NewArray(collection.ToArray(array));
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

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Kotlin.Jvm.Internal.Markers;

namespace Kotlin.Enums;

[Register("kotlin/enums/EnumEntries", DoNotGenerateAcw = true)]
internal class IEnumEntriesInvoker : Java.Lang.Object, IEnumEntries, Java.Util.IList, Java.Util.ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable, ISequencedCollection, IKMappedMarker
{
	private static readonly JniPeerMembers _members_Android_Runtime_IJavaObject = new XAPeerMembers("Android/Runtime/IJavaObject", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_Java_Interop_IJavaPeerable = new XAPeerMembers("Java/Interop/IJavaPeerable", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_java_lang_Iterable = new XAPeerMembers("java/lang/Iterable", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_java_util_Collection = new XAPeerMembers("java/util/Collection", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_java_util_List = new XAPeerMembers("java/util/List", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_java_util_SequencedCollection = new XAPeerMembers("java/util/SequencedCollection", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_kotlin_enums_EnumEntries = new XAPeerMembers("kotlin/enums/EnumEntries", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_kotlin_jvm_internal_markers_KMappedMarker = new XAPeerMembers("kotlin/jvm/internal/markers/KMappedMarker", typeof(IEnumEntriesInvoker));

	private static readonly JniPeerMembers _members_System_IDisposable = new XAPeerMembers("System/IDisposable", typeof(IEnumEntriesInvoker));

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_add_Add_Ljava_lang_Object__Z;

	private static Delegate? cb_add_Add_ILjava_lang_Object__V;

	private static Delegate? cb_addAll_AddAll_ILSystem_Collections_ICollection__Z;

	private static Delegate? cb_addAll_AddAll_LSystem_Collections_ICollection__Z;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_contains_Contains_Ljava_lang_Object__Z;

	private static Delegate? cb_containsAll_ContainsAll_LSystem_Collections_ICollection__Z;

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	private static Delegate? cb_get_Get_I_Ljava_lang_Object_;

	private static Delegate? cb_hashCode_GetHashCode_I;

	private static Delegate? cb_indexOf_IndexOf_Ljava_lang_Object__I;

	private static Delegate? cb_iterator_Iterator_Ljava_util_Iterator_;

	private static Delegate? cb_lastIndexOf_LastIndexOf_Ljava_lang_Object__I;

	private static Delegate? cb_listIterator_ListIterator_Ljava_util_ListIterator_;

	private static Delegate? cb_listIterator_ListIterator_I_Ljava_util_ListIterator_;

	private static Delegate? cb_remove_Remove_I_Ljava_lang_Object_;

	private static Delegate? cb_remove_Remove_Ljava_lang_Object__Z;

	private static Delegate? cb_removeAll_RemoveAll_LSystem_Collections_ICollection__Z;

	private static Delegate? cb_retainAll_RetainAll_LSystem_Collections_ICollection__Z;

	private static Delegate? cb_set_Set_ILjava_lang_Object__Ljava_lang_Object_;

	private static Delegate? cb_size_Size_I;

	private static Delegate? cb_subList_SubList_II_Ljava_util_List_;

	private static Delegate? cb_toArray_ToArray_arrayLjava_lang_Object_;

	private static Delegate? cb_toArray_ToArray_arrayLjava_lang_Object__arrayLjava_lang_Object_;

	private static Delegate? cb_reversed_Reversed_Ljava_util_SequencedCollection_;

	private static nint java_class_ref => _members_kotlin_enums_EnumEntries.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_enums_EnumEntries;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_enums_EnumEntries.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_enums_EnumEntries.ManagedPeerType;

	public unsafe bool IsEmpty => _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	public IEnumEntriesInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsEmptyHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEmpty);
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
			return Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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
		return new global::_JniMarshal_PPL_B(n_Add_Ljava_lang_Object_);
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
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			return enumEntries.Add(e) ? ((sbyte)1) : ((sbyte)0);
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
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("add.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetAdd_ILjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_Add_ILjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Add_ILjava_lang_Object_(nint jnienv, nint native__this, int index, nint native_element)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object element = Java.Lang.Object.GetObject<Java.Lang.Object>(native_element, JniHandleOwnership.DoNotTransfer);
			enumEntries.Add(index, element);
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

	public unsafe void Add(int index, Java.Lang.Object? element)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(index);
			ptr[1] = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
			_members_java_util_List.InstanceMethods.InvokeAbstractVoidMethod("add.(ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(element);
		}
	}

	private static Delegate GetAddAll_ILSystem_Collections_ICollection_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_AddAll_ILSystem_Collections_ICollection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_AddAll_ILSystem_Collections_ICollection_(nint jnienv, nint native__this, int index, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return enumEntries.AddAll(index, c) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool AddAll(int index, System.Collections.ICollection c)
	{
		nint num = JavaCollection.ToLocalJniHandle(c);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(index);
			ptr[1] = new JniArgumentValue(num);
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("addAll.(ILSystem/Collections/ICollection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetAddAll_LSystem_Collections_ICollection_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_AddAll_LSystem_Collections_ICollection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_AddAll_LSystem_Collections_ICollection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return enumEntries.AddAll(c) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("addAll.(LSystem/Collections/ICollection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetClearHandler()
	{
		return new global::_JniMarshal_PP_V(n_Clear);
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
			Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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
		_members_java_util_List.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetContains_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Contains_Ljava_lang_Object_);
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
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return enumEntries.Contains(o) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetContainsAll_LSystem_Collections_ICollection_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ContainsAll_LSystem_Collections_ICollection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ContainsAll_LSystem_Collections_ICollection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return enumEntries.ContainsAll(c) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("containsAll.(LSystem/Collections/ICollection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Equals_Ljava_lang_Object_);
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
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return enumEntries.Equals(o) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetGet_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Get_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(index));
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

	public unsafe Java.Lang.Object? Get(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("get.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetHashCodeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHashCode);
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
			return Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
		return _members_java_util_List.InstanceMethods.InvokeAbstractInt32Method("hashCode.()I", this, null);
	}

	private static Delegate GetIndexOf_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_IndexOf_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_IndexOf_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return enumEntries.IndexOf(o);
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

	public unsafe int IndexOf(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members_java_util_List.InstanceMethods.InvokeAbstractInt32Method("indexOf.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetIteratorHandler()
	{
		return new global::_JniMarshal_PP_L(n_Iterator);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Iterator());
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
		return Java.Lang.Object.GetObject<IIterator>(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetLastIndexOf_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_LastIndexOf_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_LastIndexOf_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_o)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return enumEntries.LastIndexOf(o);
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

	public unsafe int LastIndexOf(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members_java_util_List.InstanceMethods.InvokeAbstractInt32Method("lastIndexOf.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetListIteratorHandler()
	{
		return new global::_JniMarshal_PP_L(n_ListIterator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ListIterator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListIterator());
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

	public unsafe IListIterator ListIterator()
	{
		return Java.Lang.Object.GetObject<IListIterator>(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("listIterator.()Ljava/util/ListIterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetListIterator_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_ListIterator_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ListIterator_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ListIterator(index));
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

	public unsafe IListIterator ListIterator(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<IListIterator>(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("listIterator.(I)Ljava/util/ListIterator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemove_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Remove_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Remove_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(index));
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

	public unsafe Java.Lang.Object? Remove(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("remove.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemove_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Remove_Ljava_lang_Object_);
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
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
			return enumEntries.Remove(o) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("remove.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	private static Delegate GetRemoveAll_LSystem_Collections_ICollection_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_RemoveAll_LSystem_Collections_ICollection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveAll_LSystem_Collections_ICollection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return enumEntries.RemoveAll(c) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("removeAll.(LSystem/Collections/ICollection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetRetainAll_LSystem_Collections_ICollection_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_RetainAll_LSystem_Collections_ICollection_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RetainAll_LSystem_Collections_ICollection_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			System.Collections.ICollection c = JavaCollection.FromJniHandle(native_c, JniHandleOwnership.DoNotTransfer);
			return enumEntries.RetainAll(c) ? ((sbyte)1) : ((sbyte)0);
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
			return _members_java_util_List.InstanceMethods.InvokeAbstractBooleanMethod("retainAll.(LSystem/Collections/ICollection;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetSet_ILjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_Set_ILjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Set_ILjava_lang_Object_(nint jnienv, nint native__this, int index, nint native_element)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object element = Java.Lang.Object.GetObject<Java.Lang.Object>(native_element, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(enumEntries.Set(index, element));
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

	public unsafe Java.Lang.Object? Set(int index, Java.Lang.Object? element)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(index);
			ptr[1] = new JniArgumentValue(element?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("set.(ILjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(element);
		}
	}

	private static Delegate GetSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_Size);
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
			return Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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
		return _members_java_util_List.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
	}

	private static Delegate GetSubList_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_SubList_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SubList_II(nint jnienv, nint native__this, int fromIndex, int toIndex)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubList(fromIndex, toIndex));
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

	public unsafe System.Collections.IList SubList(int fromIndex, int toIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(fromIndex);
		ptr[1] = new JniArgumentValue(toIndex);
		return JavaList.FromJniHandle(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("subList.(II)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetToArrayHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToArray);
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
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToArray());
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
		return (Java.Lang.Object[])JNIEnv.GetArray(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("toArray.()[Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
	}

	private static Delegate GetToArray_arrayLjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_ToArray_arrayLjava_lang_Object_);
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
			IEnumEntries? enumEntries = Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_a, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
			nint result = JNIEnv.NewArray(enumEntries.ToArray(array));
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
			return (Java.Lang.Object[])JNIEnv.GetArray(_members_java_util_List.InstanceMethods.InvokeAbstractObjectMethod("toArray.([Ljava/lang/Object;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
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

	private static Delegate GetReversedHandler()
	{
		return new global::_JniMarshal_PP_L(n_Reversed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Reversed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEnumEntries>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reversed());
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

	public unsafe ISequencedCollection? Reversed()
	{
		return Java.Lang.Object.GetObject<ISequencedCollection>(_members_java_util_SequencedCollection.InstanceMethods.InvokeAbstractObjectMethod("reversed.()Ljava/util/SequencedCollection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

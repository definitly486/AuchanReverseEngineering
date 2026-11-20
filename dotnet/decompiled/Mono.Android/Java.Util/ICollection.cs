using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Functions;

namespace Java.Util;

[Register("java/util/Collection", "", "Java.Util.ICollectionInvoker")]
[JavaTypeParameters(new string[] { "E" })]
public interface ICollection : IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Collection", typeof(ICollection), isInterface: true);

	private static Delegate? cb_removeIf_RemoveIf_Ljava_util_function_Predicate__Z;

	private static Delegate? cb_spliterator_Spliterator_Ljava_util_Spliterator_;

	private static Delegate? cb_toArray_ToArray_Ljava_util_function_IntFunction__arrayLjava_lang_Object_;

	bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("add", "(Ljava/lang/Object;)Z", "GetAdd_Ljava_lang_Object_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Add(Java.Lang.Object? e);

	[Register("addAll", "(Ljava/util/Collection;)Z", "GetAddAll_Ljava_util_Collection_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool AddAll(System.Collections.ICollection c);

	[Register("clear", "()V", "GetClearHandler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Clear();

	[Register("contains", "(Ljava/lang/Object;)Z", "GetContains_Ljava_lang_Object_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Contains(Java.Lang.Object? o);

	[Register("containsAll", "(Ljava/util/Collection;)Z", "GetContainsAll_Ljava_util_Collection_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool ContainsAll(System.Collections.ICollection c);

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Equals(Java.Lang.Object? o);

	[Register("hashCode", "()I", "GetGetHashCodeHandler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new int GetHashCode();

	[Register("iterator", "()Ljava/util/Iterator;", "GetIteratorHandler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new IIterator Iterator();

	[Register("remove", "(Ljava/lang/Object;)Z", "GetRemove_Ljava_lang_Object_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Remove(Java.Lang.Object? o);

	[Register("removeAll", "(Ljava/util/Collection;)Z", "GetRemoveAll_Ljava_util_Collection_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool RemoveAll(System.Collections.ICollection c);

	[Register("retainAll", "(Ljava/util/Collection;)Z", "GetRetainAll_Ljava_util_Collection_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool RetainAll(System.Collections.ICollection c);

	[Register("size", "()I", "GetSizeHandler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int Size();

	[Register("toArray", "()[Ljava/lang/Object;", "GetToArrayHandler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object[] ToArray();

	[Register("toArray", "([Ljava/lang/Object;)[Ljava/lang/Object;", "GetToArray_arrayLjava_lang_Object_Handler:Java.Util.ICollectionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object[] ToArray(Java.Lang.Object[] a);

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetRemoveIf_Ljava_util_function_Predicate_Handler()
	{
		return new _JniMarshal_PPL_B(n_RemoveIf_Ljava_util_function_Predicate_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveIf_Ljava_util_function_Predicate_(nint jnienv, nint native__this, nint native_filter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IPredicate filter = Java.Lang.Object.GetObject<IPredicate>(native_filter, JniHandleOwnership.DoNotTransfer);
			return collection.RemoveIf(filter) ? ((sbyte)1) : ((sbyte)0);
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
	[Register("removeIf", "(Ljava/util/function/Predicate;)Z", "GetRemoveIf_Ljava_util_function_Predicate_Handler:Java.Util.ICollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe bool RemoveIf(IPredicate filter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((filter == null) ? IntPtr.Zero : ((Java.Lang.Object)filter).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeIf.(Ljava/util/function/Predicate;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(filter);
		}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Spliterator());
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
	[Register("spliterator", "()Ljava/util/Spliterator;", "GetSpliteratorHandler:Java.Util.ICollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe ISpliterator IIterable.Spliterator()
	{
		return Java.Lang.Object.GetObject<ISpliterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("spliterator.()Ljava/util/Spliterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android33.0")]
	private static Delegate GetToArray_Ljava_util_function_IntFunction_Handler()
	{
		return new _JniMarshal_PPL_L(n_ToArray_Ljava_util_function_IntFunction_);
	}

	[SupportedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToArray_Ljava_util_function_IntFunction_(nint jnienv, nint native__this, nint native_generator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICollection? collection = Java.Lang.Object.GetObject<ICollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IIntFunction generator = Java.Lang.Object.GetObject<IIntFunction>(native_generator, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(collection.ToArray(generator));
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

	[SupportedOSPlatform("android33.0")]
	[Register("toArray", "(Ljava/util/function/IntFunction;)[Ljava/lang/Object;", "GetToArray_Ljava_util_function_IntFunction_Handler:Java.Util.ICollection, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 33)]
	[JavaTypeParameters(new string[] { "T" })]
	unsafe Java.Lang.Object[] ToArray(IIntFunction generator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((generator == null) ? IntPtr.Zero : ((Java.Lang.Object)generator).Handle);
			return (Java.Lang.Object[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("toArray.(Ljava/util/function/IntFunction;)[Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Object));
		}
		finally
		{
			GC.KeepAlive(generator);
		}
	}
}

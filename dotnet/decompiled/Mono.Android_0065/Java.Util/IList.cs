using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Functions;

namespace Java.Util;

[Register("java/util/List", "", "Java.Util.IListInvoker")]
[JavaTypeParameters(new string[] { "E" })]
public interface IList : ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable, ISequencedCollection
{
	private static Delegate? cb_reversed;

	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/List", typeof(IList), isInterface: true);

	private static Delegate? cb_getFirst_GetFirst_Ljava_lang_Object_;

	private static Delegate? cb_getLast_GetLast_Ljava_lang_Object_;

	private static Delegate? cb_addFirst_AddFirst_Ljava_lang_Object__V;

	private static Delegate? cb_addLast_AddLast_Ljava_lang_Object__V;

	private static Delegate? cb_removeFirst_RemoveFirst_Ljava_lang_Object_;

	private static Delegate? cb_removeLast_RemoveLast_Ljava_lang_Object_;

	private static Delegate? cb_replaceAll_ReplaceAll_Ljava_util_function_UnaryOperator__V;

	private static Delegate? cb_sort_Sort_Ljava_util_Comparator__V;

	private static Delegate? cb_spliterator_Spliterator_Ljava_util_Spliterator_;

	new bool IsEmpty { get; }

	[SupportedOSPlatform("android35.0")]
	unsafe Java.Lang.Object? First => Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFirst.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android35.0")]
	unsafe Java.Lang.Object? Last => Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLast.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetReversedHandler()
	{
		return new _JniMarshal_PP_L(n_Reversed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	[SupportedOSPlatform("android35.0")]
	private static nint n_Reversed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reversed());
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

	[SupportedOSPlatform("android35.0")]
	unsafe ISequencedCollection ISequencedCollection.Reversed()
	{
		return Java.Lang.Object.GetObject<ISequencedCollection>(_members.InstanceMethods.InvokeVirtualObjectMethod("reversed.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetGetFirstHandler()
	{
		return new _JniMarshal_PP_L(n_GetFirst);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFirst(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).First);
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

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetGetLastHandler()
	{
		return new _JniMarshal_PP_L(n_GetLast);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLast(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Last);
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

	new bool Add(Java.Lang.Object? e);

	void Add(int index, Java.Lang.Object? element);

	bool AddAll(int index, System.Collections.ICollection c);

	new bool AddAll(System.Collections.ICollection c);

	new void Clear();

	new bool Contains(Java.Lang.Object? o);

	new bool ContainsAll(System.Collections.ICollection c);

	new bool Equals(Java.Lang.Object? o);

	Java.Lang.Object? Get(int index);

	new int GetHashCode();

	int IndexOf(Java.Lang.Object? o);

	new IIterator Iterator();

	int LastIndexOf(Java.Lang.Object? o);

	IListIterator ListIterator();

	IListIterator ListIterator(int index);

	Java.Lang.Object? Remove(int index);

	new bool Remove(Java.Lang.Object? o);

	new bool RemoveAll(System.Collections.ICollection c);

	new bool RetainAll(System.Collections.ICollection c);

	Java.Lang.Object? Set(int index, Java.Lang.Object? element);

	new int Size();

	System.Collections.IList SubList(int fromIndex, int toIndex);

	new Java.Lang.Object[] ToArray();

	[JavaTypeParameters(new string[] { "T" })]
	new Java.Lang.Object[] ToArray(Java.Lang.Object[] a);

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetAddFirst_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddFirst_Ljava_lang_Object_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFirst_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IList? list = Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			list.AddFirst(e);
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

	[SupportedOSPlatform("android35.0")]
	unsafe void ISequencedCollection.AddFirst(Java.Lang.Object? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(e);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFirst.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetAddLast_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddLast_Ljava_lang_Object_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddLast_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IList? list = Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object e = Java.Lang.Object.GetObject<Java.Lang.Object>(native_e, JniHandleOwnership.DoNotTransfer);
			list.AddLast(e);
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

	[SupportedOSPlatform("android35.0")]
	unsafe void ISequencedCollection.AddLast(Java.Lang.Object? e)
	{
		nint num = JNIEnv.ToLocalJniHandle(e);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addLast.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e);
		}
	}

	[SupportedOSPlatform("android31.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList CopyOf(System.Collections.ICollection coll)
	{
		nint num = JavaCollection.ToLocalJniHandle(coll);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("copyOf.(Ljava/util/Collection;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(coll);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of()
	{
		return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.()Ljava/util/List;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7, Java.Lang.Object e8, Java.Lang.Object e9, Java.Lang.Object e10)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		nint num4 = JNIEnv.ToLocalJniHandle(e4);
		nint num5 = JNIEnv.ToLocalJniHandle(e5);
		nint num6 = JNIEnv.ToLocalJniHandle(e6);
		nint num7 = JNIEnv.ToLocalJniHandle(e7);
		nint num8 = JNIEnv.ToLocalJniHandle(e8);
		nint num9 = JNIEnv.ToLocalJniHandle(e9);
		nint num10 = JNIEnv.ToLocalJniHandle(e10);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			ptr[4] = new JniArgumentValue(num5);
			ptr[5] = new JniArgumentValue(num6);
			ptr[6] = new JniArgumentValue(num7);
			ptr[7] = new JniArgumentValue(num8);
			ptr[8] = new JniArgumentValue(num9);
			ptr[9] = new JniArgumentValue(num10);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			JNIEnv.DeleteLocalRef(num5);
			JNIEnv.DeleteLocalRef(num6);
			JNIEnv.DeleteLocalRef(num7);
			JNIEnv.DeleteLocalRef(num8);
			JNIEnv.DeleteLocalRef(num9);
			JNIEnv.DeleteLocalRef(num10);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
			GC.KeepAlive(e4);
			GC.KeepAlive(e5);
			GC.KeepAlive(e6);
			GC.KeepAlive(e7);
			GC.KeepAlive(e8);
			GC.KeepAlive(e9);
			GC.KeepAlive(e10);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7, Java.Lang.Object e8, Java.Lang.Object e9)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		nint num4 = JNIEnv.ToLocalJniHandle(e4);
		nint num5 = JNIEnv.ToLocalJniHandle(e5);
		nint num6 = JNIEnv.ToLocalJniHandle(e6);
		nint num7 = JNIEnv.ToLocalJniHandle(e7);
		nint num8 = JNIEnv.ToLocalJniHandle(e8);
		nint num9 = JNIEnv.ToLocalJniHandle(e9);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			ptr[4] = new JniArgumentValue(num5);
			ptr[5] = new JniArgumentValue(num6);
			ptr[6] = new JniArgumentValue(num7);
			ptr[7] = new JniArgumentValue(num8);
			ptr[8] = new JniArgumentValue(num9);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			JNIEnv.DeleteLocalRef(num5);
			JNIEnv.DeleteLocalRef(num6);
			JNIEnv.DeleteLocalRef(num7);
			JNIEnv.DeleteLocalRef(num8);
			JNIEnv.DeleteLocalRef(num9);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
			GC.KeepAlive(e4);
			GC.KeepAlive(e5);
			GC.KeepAlive(e6);
			GC.KeepAlive(e7);
			GC.KeepAlive(e8);
			GC.KeepAlive(e9);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7, Java.Lang.Object e8)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		nint num4 = JNIEnv.ToLocalJniHandle(e4);
		nint num5 = JNIEnv.ToLocalJniHandle(e5);
		nint num6 = JNIEnv.ToLocalJniHandle(e6);
		nint num7 = JNIEnv.ToLocalJniHandle(e7);
		nint num8 = JNIEnv.ToLocalJniHandle(e8);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			ptr[4] = new JniArgumentValue(num5);
			ptr[5] = new JniArgumentValue(num6);
			ptr[6] = new JniArgumentValue(num7);
			ptr[7] = new JniArgumentValue(num8);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			JNIEnv.DeleteLocalRef(num5);
			JNIEnv.DeleteLocalRef(num6);
			JNIEnv.DeleteLocalRef(num7);
			JNIEnv.DeleteLocalRef(num8);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
			GC.KeepAlive(e4);
			GC.KeepAlive(e5);
			GC.KeepAlive(e6);
			GC.KeepAlive(e7);
			GC.KeepAlive(e8);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		nint num4 = JNIEnv.ToLocalJniHandle(e4);
		nint num5 = JNIEnv.ToLocalJniHandle(e5);
		nint num6 = JNIEnv.ToLocalJniHandle(e6);
		nint num7 = JNIEnv.ToLocalJniHandle(e7);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			ptr[4] = new JniArgumentValue(num5);
			ptr[5] = new JniArgumentValue(num6);
			ptr[6] = new JniArgumentValue(num7);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			JNIEnv.DeleteLocalRef(num5);
			JNIEnv.DeleteLocalRef(num6);
			JNIEnv.DeleteLocalRef(num7);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
			GC.KeepAlive(e4);
			GC.KeepAlive(e5);
			GC.KeepAlive(e6);
			GC.KeepAlive(e7);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		nint num4 = JNIEnv.ToLocalJniHandle(e4);
		nint num5 = JNIEnv.ToLocalJniHandle(e5);
		nint num6 = JNIEnv.ToLocalJniHandle(e6);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			ptr[4] = new JniArgumentValue(num5);
			ptr[5] = new JniArgumentValue(num6);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			JNIEnv.DeleteLocalRef(num5);
			JNIEnv.DeleteLocalRef(num6);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
			GC.KeepAlive(e4);
			GC.KeepAlive(e5);
			GC.KeepAlive(e6);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		nint num4 = JNIEnv.ToLocalJniHandle(e4);
		nint num5 = JNIEnv.ToLocalJniHandle(e5);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			ptr[4] = new JniArgumentValue(num5);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			JNIEnv.DeleteLocalRef(num5);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
			GC.KeepAlive(e4);
			GC.KeepAlive(e5);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		nint num4 = JNIEnv.ToLocalJniHandle(e4);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			ptr[3] = new JniArgumentValue(num4);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			JNIEnv.DeleteLocalRef(num4);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
			GC.KeepAlive(e4);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		nint num3 = JNIEnv.ToLocalJniHandle(e3);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
			GC.KeepAlive(e3);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1, Java.Lang.Object e2)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(e1);
			GC.KeepAlive(e2);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(params Java.Lang.Object[] elements)
	{
		nint num = JNIEnv.NewArray(elements);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.([Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (elements != null)
			{
				JNIEnv.CopyArray(num, elements);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(elements);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.IList Of(Java.Lang.Object e1)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e1);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRemoveFirstHandler()
	{
		return new _JniMarshal_PP_L(n_RemoveFirst);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RemoveFirst(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveFirst());
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

	[SupportedOSPlatform("android35.0")]
	unsafe Java.Lang.Object? ISequencedCollection.RemoveFirst()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeFirst.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRemoveLastHandler()
	{
		return new _JniMarshal_PP_L(n_RemoveLast);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RemoveLast(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveLast());
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

	[SupportedOSPlatform("android35.0")]
	unsafe Java.Lang.Object? ISequencedCollection.RemoveLast()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeLast.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetReplaceAll_Ljava_util_function_UnaryOperator_Handler()
	{
		return new _JniMarshal_PPL_V(n_ReplaceAll_Ljava_util_function_UnaryOperator_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ReplaceAll_Ljava_util_function_UnaryOperator_(nint jnienv, nint native__this, nint native__operator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IList? list = Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IUnaryOperator unaryOperator = Java.Lang.Object.GetObject<IUnaryOperator>(native__operator, JniHandleOwnership.DoNotTransfer);
			list.ReplaceAll(unaryOperator);
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

	[SupportedOSPlatform("android24.0")]
	unsafe void ReplaceAll(IUnaryOperator @operator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((@operator == null) ? IntPtr.Zero : ((Java.Lang.Object)@operator).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("replaceAll.(Ljava/util/function/UnaryOperator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@operator);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetSort_Ljava_util_Comparator_Handler()
	{
		return new _JniMarshal_PPL_V(n_Sort_Ljava_util_Comparator_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Sort_Ljava_util_Comparator_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IList? list = Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IComparator c = Java.Lang.Object.GetObject<IComparator>(native_c, JniHandleOwnership.DoNotTransfer);
			list.Sort(c);
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

	[SupportedOSPlatform("android24.0")]
	unsafe void Sort(IComparator? c)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("sort.(Ljava/util/Comparator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(c);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IList>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Spliterator());
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
	unsafe ISpliterator IIterable.Spliterator()
	{
		return Java.Lang.Object.GetObject<ISpliterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("spliterator.()Ljava/util/Spliterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}

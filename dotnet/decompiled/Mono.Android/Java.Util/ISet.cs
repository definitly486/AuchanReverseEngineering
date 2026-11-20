using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/Set", "", "Java.Util.ISetInvoker")]
[JavaTypeParameters(new string[] { "E" })]
public interface ISet : ICollection, IIterable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/util/Set", typeof(ISet), isInterface: true);

	private static Delegate? cb_spliterator_Spliterator_Ljava_util_Spliterator_;

	new bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("add", "(Ljava/lang/Object;)Z", "GetAdd_Ljava_lang_Object_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool Add(Java.Lang.Object? e);

	[Register("addAll", "(Ljava/util/Collection;)Z", "GetAddAll_Ljava_util_Collection_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool AddAll(System.Collections.ICollection c);

	[Register("clear", "()V", "GetClearHandler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new void Clear();

	[Register("contains", "(Ljava/lang/Object;)Z", "GetContains_Ljava_lang_Object_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool Contains(Java.Lang.Object? o);

	[Register("containsAll", "(Ljava/util/Collection;)Z", "GetContainsAll_Ljava_util_Collection_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool ContainsAll(System.Collections.ICollection c);

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool Equals(Java.Lang.Object? o);

	[Register("hashCode", "()I", "GetGetHashCodeHandler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new int GetHashCode();

	[Register("iterator", "()Ljava/util/Iterator;", "GetIteratorHandler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new IIterator Iterator();

	[Register("remove", "(Ljava/lang/Object;)Z", "GetRemove_Ljava_lang_Object_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool Remove(Java.Lang.Object? o);

	[Register("removeAll", "(Ljava/util/Collection;)Z", "GetRemoveAll_Ljava_util_Collection_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool RemoveAll(System.Collections.ICollection c);

	[Register("retainAll", "(Ljava/util/Collection;)Z", "GetRetainAll_Ljava_util_Collection_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new bool RetainAll(System.Collections.ICollection c);

	[Register("size", "()I", "GetSizeHandler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new int Size();

	[Register("toArray", "()[Ljava/lang/Object;", "GetToArrayHandler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new Java.Lang.Object[] ToArray();

	[Register("toArray", "([Ljava/lang/Object;)[Ljava/lang/Object;", "GetToArray_arrayLjava_lang_Object_Handler:Java.Util.ISetInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	new Java.Lang.Object[] ToArray(Java.Lang.Object[] a);

	[SupportedOSPlatform("android31.0")]
	[Register("copyOf", "(Ljava/util/Collection;)Ljava/util/Set;", "", ApiSince = 31)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection CopyOf(System.Collections.ICollection coll)
	{
		nint num = JavaCollection.ToLocalJniHandle(coll);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("copyOf.(Ljava/util/Collection;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(coll);
		}
	}

	[SupportedOSPlatform("android30.0")]
	[Register("of", "()Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of()
	{
		return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.()Ljava/util/Set;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android30.0")]
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7, Java.Lang.Object e8, Java.Lang.Object e9, Java.Lang.Object e10)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7, Java.Lang.Object e8, Java.Lang.Object e9)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7, Java.Lang.Object e8)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6, Java.Lang.Object e7)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5, Java.Lang.Object e6)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4, Java.Lang.Object e5)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3, Java.Lang.Object e4)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2, Java.Lang.Object e3)
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
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1, Java.Lang.Object e2)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		nint num2 = JNIEnv.ToLocalJniHandle(e2);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "([Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(params Java.Lang.Object[] elements)
	{
		nint num = JNIEnv.NewArray(elements);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.([Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
	[Register("of", "(Ljava/lang/Object;)Ljava/util/Set;", "", ApiSince = 30)]
	[JavaTypeParameters(new string[] { "E" })]
	static unsafe System.Collections.ICollection Of(Java.Lang.Object e1)
	{
		nint num = JNIEnv.ToLocalJniHandle(e1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaSet.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/lang/Object;)Ljava/util/Set;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(e1);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Spliterator());
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
	[Register("spliterator", "()Ljava/util/Spliterator;", "GetSpliteratorHandler:Java.Util.ISet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 24)]
	unsafe ISpliterator IIterable.Spliterator()
	{
		return Java.Lang.Object.GetObject<ISpliterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("spliterator.()Ljava/util/Spliterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}

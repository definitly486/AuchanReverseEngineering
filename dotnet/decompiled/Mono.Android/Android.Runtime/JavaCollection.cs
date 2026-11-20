using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace Android.Runtime;

[Register("java/util/Collection", DoNotGenerateAcw = true)]
public class JavaCollection : Java.Lang.Object, System.Collections.ICollection, IEnumerable
{
	internal static nint collection_class = JNIEnv.FindClass("java/util/Collection");

	internal static nint id_add;

	private static nint id_iterator;

	private static nint id_size;

	internal static nint id_toArray;

	public int Count
	{
		get
		{
			if (id_size == IntPtr.Zero)
			{
				id_size = JNIEnv.GetMethodID(collection_class, "size", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_size);
		}
	}

	public bool IsSynchronized => false;

	public object? SyncRoot => null;

	public JavaCollection(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	internal JavaCollection(IEnumerable items)
		: base(JNIEnv.StartCreateInstance("java/util/ArrayList", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		if (items == null)
		{
			Dispose();
			throw new ArgumentNullException("items");
		}
		foreach (object item in items)
		{
			Add(item);
		}
	}

	internal void Add(object item)
	{
		if (id_add == IntPtr.Zero)
		{
			id_add = JNIEnv.GetMethodID(collection_class, "add", "(Ljava/lang/Object;)Z");
		}
		JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				JNIEnv.CallBooleanMethod(base.Handle, id_add, new JValue(lref));
			}
			catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Add"))
			{
				throw new NotSupportedException(ex.Message, ex);
			}
			catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Add"))
			{
				throw new InvalidCastException(ex2.Message, ex2);
			}
			catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Add"))
			{
				throw new NullReferenceException(ex3.Message, ex3);
			}
			catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "Add"))
			{
				throw new ArgumentException(ex4.Message, ex4);
			}
			catch (IllegalStateException ex5) when (JNIEnv.ShouldWrapJavaException(ex5, "Add"))
			{
				throw new InvalidOperationException(ex5.Message, ex5);
			}
			return IntPtr.Zero;
		});
	}

	internal IIterator Iterator()
	{
		if (id_iterator == IntPtr.Zero)
		{
			id_iterator = JNIEnv.GetMethodID(collection_class, "iterator", "()Ljava/util/Iterator;");
		}
		return Java.Lang.Object.GetObject<IIterator>(JNIEnv.CallObjectMethod(base.Handle, id_iterator), JniHandleOwnership.TransferLocalRef);
	}

	public void CopyTo(Array array, int array_index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (array_index < 0)
		{
			throw new ArgumentOutOfRangeException("array_index");
		}
		if (array.Length < array_index + Count)
		{
			throw new ArgumentException("array");
		}
		if (id_toArray == IntPtr.Zero)
		{
			id_toArray = JNIEnv.GetMethodID(collection_class, "toArray", "()[Ljava/lang/Object;");
		}
		nint num = JNIEnv.CallObjectMethod(base.Handle, id_toArray);
		for (int i = 0; i < Count; i++)
		{
			array.SetValue(JavaConvert.FromJniHandle(JNIEnv.GetObjectArrayElement(num, i), JniHandleOwnership.TransferLocalRef, GetElementType(array)), array_index + i);
		}
		JNIEnv.DeleteLocalRef(num);
		[UnconditionalSuppressMessage("Trimming", "IL2073", Justification = "JavaCollection<T> constructors are preserved by the MarkJavaObjects trimmer step.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
		static Type GetElementType(Array array2)
		{
			return array2.GetType().GetElementType();
		}
	}

	public IEnumerator GetEnumerator()
	{
		return Iterator().ToEnumerator_Dispose();
	}

	public static System.Collections.ICollection? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle);
		if (javaObject == null)
		{
			javaObject = new JavaCollection(handle, transfer);
		}
		else
		{
			JNIEnv.DeleteRef(handle, transfer);
		}
		return (System.Collections.ICollection)javaObject;
	}

	public static nint ToLocalJniHandle(System.Collections.ICollection? items)
	{
		if (items == null)
		{
			return IntPtr.Zero;
		}
		if (items is JavaCollection value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaCollection value2;
		using (value2 = new JavaCollection(items))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}
}
[Register("java/util/Collection", DoNotGenerateAcw = true)]
public sealed class JavaCollection<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : JavaCollection, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private static nint id_clear;

	private static nint id_contains;

	private static nint id_remove;

	public bool IsReadOnly => false;

	public JavaCollection(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	internal JavaCollection(IEnumerable<T> items)
		: base(JNIEnv.StartCreateInstance("java/util/ArrayList", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		if (items == null)
		{
			Dispose();
			throw new ArgumentNullException("items");
		}
		foreach (T item in items)
		{
			Add(item);
		}
	}

	public void Add(T item)
	{
		if (JavaCollection.id_add == IntPtr.Zero)
		{
			JavaCollection.id_add = JNIEnv.GetMethodID(JavaCollection.collection_class, "add", "(Ljava/lang/Object;)Z");
		}
		JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				JNIEnv.CallBooleanMethod(base.Handle, JavaCollection.id_add, new JValue(lref));
			}
			catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Add"))
			{
				throw new NotSupportedException(ex.Message, ex);
			}
			catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Add"))
			{
				throw new InvalidCastException(ex2.Message, ex2);
			}
			catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Add"))
			{
				throw new NullReferenceException(ex3.Message, ex3);
			}
			catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "Add"))
			{
				throw new ArgumentException(ex4.Message, ex4);
			}
			catch (IllegalStateException ex5) when (JNIEnv.ShouldWrapJavaException(ex5, "Add"))
			{
				throw new InvalidOperationException(ex5.Message, ex5);
			}
			return IntPtr.Zero;
		});
	}

	public void Clear()
	{
		if (id_clear == IntPtr.Zero)
		{
			id_clear = JNIEnv.GetMethodID(JavaCollection.collection_class, "clear", "()V");
		}
		try
		{
			JNIEnv.CallVoidMethod(base.Handle, id_clear);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Clear"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
	}

	public bool Contains(T item)
	{
		if (id_contains == IntPtr.Zero)
		{
			id_contains = JNIEnv.GetMethodID(JavaCollection.collection_class, "contains", "(Ljava/lang/Object;)Z");
		}
		return JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_contains, new JValue(lref));
			}
			catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Contains"))
			{
				throw new InvalidCastException(ex.Message, ex);
			}
			catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Contains"))
			{
				throw new NullReferenceException(ex2.Message, ex2);
			}
		});
	}

	public void CopyTo(T[] array, int array_index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (array_index < 0)
		{
			throw new ArgumentOutOfRangeException("array_index");
		}
		if (array.Length < array_index + base.Count)
		{
			throw new ArgumentException("array");
		}
		if (JavaCollection.id_toArray == IntPtr.Zero)
		{
			JavaCollection.id_toArray = JNIEnv.GetMethodID(JavaCollection.collection_class, "toArray", "()[Ljava/lang/Object;");
		}
		nint num = JNIEnv.CallObjectMethod(base.Handle, JavaCollection.id_toArray);
		for (int i = 0; i < base.Count; i++)
		{
			array[array_index + i] = JavaConvert.FromJniHandle<T>(JNIEnv.GetObjectArrayElement(num, i), JniHandleOwnership.TransferLocalRef);
		}
		JNIEnv.DeleteLocalRef(num);
	}

	public bool Remove(T item)
	{
		if (id_remove == IntPtr.Zero)
		{
			id_remove = JNIEnv.GetMethodID(JavaCollection.collection_class, "remove", "(I)Ljava/lang/Object;");
		}
		return JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_remove, new JValue(lref));
			}
			catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Remove"))
			{
				throw new InvalidCastException(ex.Message, ex);
			}
			catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Remove"))
			{
				throw new NullReferenceException(ex2.Message, ex2);
			}
			catch (UnsupportedOperationException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Remove"))
			{
				throw new NotSupportedException(ex3.Message, ex3);
			}
		});
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public new IEnumerator<T?> GetEnumerator()
	{
		return Iterator().ToEnumerator_Dispose<T>();
	}

	public new static ICollection<T>? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle);
		if (javaObject == null)
		{
			javaObject = new JavaCollection<T>(handle, transfer);
		}
		else
		{
			JNIEnv.DeleteRef(handle, transfer);
		}
		return (ICollection<T>)javaObject;
	}

	public static nint ToLocalJniHandle(ICollection<T>? items)
	{
		if (items == null)
		{
			return IntPtr.Zero;
		}
		if (items is JavaCollection<T> value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaCollection<T> value2;
		using (value2 = new JavaCollection<T>(items))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}
}

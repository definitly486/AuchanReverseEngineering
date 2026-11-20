using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace Android.Runtime;

[Register("java/util/HashSet", DoNotGenerateAcw = true)]
public class JavaSet : Java.Lang.Object, System.Collections.ICollection, IEnumerable
{
	internal static nint set_class = JNIEnv.FindClass("java/util/Set");

	internal static nint id_add;

	internal static nint id_contains;

	internal static nint id_remove;

	private static nint id_iterator;

	private static nint id_size;

	private static nint id_clear;

	public int Count
	{
		get
		{
			if (id_size == IntPtr.Zero)
			{
				id_size = JNIEnv.GetMethodID(set_class, "size", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_size);
		}
	}

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	public object? SyncRoot => null;

	internal IIterator Iterator()
	{
		if (id_iterator == IntPtr.Zero)
		{
			id_iterator = JNIEnv.GetMethodID(set_class, "iterator", "()Ljava/util/Iterator;");
		}
		return Java.Lang.Object.GetObject<IIterator>(JNIEnv.CallObjectMethod(base.Handle, id_iterator), JniHandleOwnership.TransferLocalRef);
	}

	public JavaSet()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			if (GetType() == typeof(JavaSet))
			{
				SetHandle(JNIEnv.StartCreateInstance("java/util/HashSet", "()V"), JniHandleOwnership.TransferLocalRef);
			}
			else
			{
				SetHandle(JNIEnv.StartCreateInstance(GetType(), "()V"), JniHandleOwnership.TransferLocalRef);
			}
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
		}
	}

	public JavaSet(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public JavaSet(IEnumerable items)
		: this()
	{
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

	public void Add(object? item)
	{
		if (id_add == IntPtr.Zero)
		{
			id_add = JNIEnv.GetMethodID(set_class, "add", "(Ljava/lang/Object;)Z");
		}
		JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_add, new JValue(lref));
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
		});
	}

	public void Clear()
	{
		if (id_clear == IntPtr.Zero)
		{
			id_clear = JNIEnv.GetMethodID(set_class, "clear", "()V");
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
		int num = 0;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				array.SetValue(current, array_index + num++);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
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
			javaObject = new JavaSet(handle, transfer);
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
		if (items is JavaSet value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaSet value2;
		using (value2 = new JavaSet(items))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}
}
[Register("java/util/HashSet", DoNotGenerateAcw = true)]
public class JavaSet<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : JavaSet, ICollection<T>, IEnumerable<T>, IEnumerable
{
	public JavaSet()
	{
		if (base.Handle == IntPtr.Zero)
		{
			if (GetType() == typeof(JavaSet<T>))
			{
				SetHandle(JNIEnv.StartCreateInstance("java/util/HashSet", "()V"), JniHandleOwnership.TransferLocalRef);
			}
			else
			{
				SetHandle(JNIEnv.StartCreateInstance(GetType(), "()V"), JniHandleOwnership.TransferLocalRef);
			}
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
		}
	}

	public JavaSet(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public JavaSet(IEnumerable<T> items)
		: this()
	{
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
		if (JavaSet.id_add == IntPtr.Zero)
		{
			JavaSet.id_add = JNIEnv.GetMethodID(JavaSet.set_class, "add", "(Ljava/lang/Object;)Z");
		}
		JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, JavaSet.id_add, new JValue(lref));
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
		});
	}

	public bool Contains(T item)
	{
		if (JavaSet.id_contains == IntPtr.Zero)
		{
			JavaSet.id_contains = JNIEnv.GetMethodID(JavaSet.set_class, "contains", "(Ljava/lang/Object;)Z");
		}
		return JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, JavaSet.id_contains, new JValue(lref));
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
		int num = 0;
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			T current = enumerator.Current;
			array[array_index + num++] = current;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public new IEnumerator<T> GetEnumerator()
	{
		return Iterator().ToEnumerator_Dispose<T>();
	}

	public bool Remove(T item)
	{
		if (JavaSet.id_remove == IntPtr.Zero)
		{
			JavaSet.id_remove = JNIEnv.GetMethodID(JavaSet.set_class, "remove", "(Ljava/lang/Object;)Z");
		}
		return JavaConvert.WithLocalJniHandle(item, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, JavaSet.id_remove, new JValue(lref));
			}
			catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Remove"))
			{
				throw new NotSupportedException(ex.Message, ex);
			}
			catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Remove"))
			{
				throw new InvalidCastException(ex2.Message, ex2);
			}
			catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Remove"))
			{
				throw new NullReferenceException(ex3.Message, ex3);
			}
		});
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
			javaObject = new JavaSet<T>(handle, transfer);
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
		if (items is JavaSet<T> value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaSet<T> value2;
		using (value2 = new JavaSet<T>(items))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}
}

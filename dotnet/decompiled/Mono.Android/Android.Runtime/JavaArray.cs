using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Java.Lang;

namespace Android.Runtime;

[Register("mono/android/runtime/JavaArray", DoNotGenerateAcw = true)]
public sealed class JavaArray<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : Java.Lang.Object, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	public int Count => JNIEnv.GetArrayLength(base.Handle);

	public bool IsReadOnly => false;

	public T this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return JNIEnv.GetArrayItem<T>(base.Handle, index);
		}
		set
		{
			JNIEnv.SetArrayItem(base.Handle, index, value);
		}
	}

	public JavaArray(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public void Add(T item)
	{
		throw new InvalidOperationException();
	}

	public void Clear()
	{
		throw new InvalidOperationException();
	}

	public bool Contains(T item)
	{
		return IndexOf(item) >= 0;
	}

	public void CopyTo(T[] array, int array_index)
	{
		T[] array2 = JNIEnv.GetArray<T>(base.Handle);
		for (int i = 0; i < Count; i++)
		{
			array[array_index + i] = array2[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<T> GetEnumerator()
	{
		T[] items = JNIEnv.GetArray<T>(base.Handle);
		for (int i = 0; i < items.Length; i++)
		{
			yield return items[i];
		}
	}

	public int IndexOf(T item)
	{
		return Array.IndexOf(JNIEnv.GetArray<T>(base.Handle), item);
	}

	public void Insert(int index, T item)
	{
		throw new InvalidOperationException();
	}

	public bool Remove(T item)
	{
		throw new InvalidOperationException();
	}

	public void RemoveAt(int index)
	{
		throw new InvalidOperationException();
	}

	public static JavaArray<T>? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		if (Java.Lang.Object.PeekObject(handle) is JavaArray<T> result)
		{
			JNIEnv.DeleteRef(handle, transfer);
			return result;
		}
		return new JavaArray<T>(handle, transfer);
	}

	public static nint ToLocalJniHandle(IList<T>? value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		if (value is JavaArray<T> value2)
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
		T[] array = new T[value.Count];
		value.CopyTo(array, 0);
		return JNIEnv.NewArray(array, typeof(T));
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Java.Interop;
using Java.Lang;

namespace Android.Runtime;

[Register("java/util/HashMap", DoNotGenerateAcw = true)]
public class JavaDictionary : Java.Lang.Object, IDictionary, ICollection, IEnumerable
{
	private class DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		private IEnumerator simple_enumerator;

		public object? Current => simple_enumerator.Current;

		public DictionaryEntry Entry => (DictionaryEntry)Current;

		public object Key => Entry.Key;

		public object? Value => Entry.Value;

		public DictionaryEnumerator(JavaDictionary owner)
		{
			simple_enumerator = ((IEnumerable)owner).GetEnumerator();
		}

		public bool MoveNext()
		{
			return simple_enumerator.MoveNext();
		}

		public void Reset()
		{
			simple_enumerator.Reset();
		}
	}

	internal static nint map_class = JNIEnv.FindClass("java/util/Map");

	private static nint id_clear;

	internal static nint id_containsKey;

	internal static nint id_get;

	private static nint id_keySet;

	internal static nint id_put;

	internal static nint id_remove;

	private static nint id_size;

	private static nint id_values;

	public int Count
	{
		get
		{
			if (id_size == IntPtr.Zero)
			{
				id_size = JNIEnv.GetMethodID(map_class, "size", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_size);
		}
	}

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	public ICollection Keys => new JavaSet(GetKeys(), JniHandleOwnership.TransferLocalRef);

	public object? SyncRoot => null;

	public ICollection Values => new JavaCollection(GetValues(), JniHandleOwnership.TransferLocalRef);

	public object? this[object key]
	{
		get
		{
			return Get(key);
		}
		set
		{
			Put(key, value);
		}
	}

	internal object? Get(object key)
	{
		if (id_get == IntPtr.Zero)
		{
			id_get = JNIEnv.GetMethodID(map_class, "get", "(Ljava/lang/Object;)Ljava/lang/Object;");
		}
		return JavaConvert.FromJniHandle(JavaConvert.WithLocalJniHandle(key, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallObjectMethod(base.Handle, id_get, new JValue(lref));
			}
			catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Get"))
			{
				throw new InvalidCastException(ex.Message, ex);
			}
			catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Get"))
			{
				throw new NullReferenceException(ex2.Message, ex2);
			}
		}), JniHandleOwnership.TransferLocalRef);
	}

	internal nint GetKeys()
	{
		if (id_keySet == IntPtr.Zero)
		{
			id_keySet = JNIEnv.GetMethodID(map_class, "keySet", "()Ljava/util/Set;");
		}
		return JNIEnv.CallObjectMethod(base.Handle, id_keySet);
	}

	internal nint GetValues()
	{
		if (id_values == IntPtr.Zero)
		{
			id_values = JNIEnv.GetMethodID(map_class, "values", "()Ljava/util/Collection;");
		}
		return JNIEnv.CallObjectMethod(base.Handle, id_values);
	}

	internal void Put(object key, object? value)
	{
		if (id_put == IntPtr.Zero)
		{
			id_put = JNIEnv.GetMethodID(map_class, "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
		}
		JNIEnv.DeleteLocalRef(JavaConvert.WithLocalJniHandle(key, (nint lrefKey) => JavaConvert.WithLocalJniHandle(value, delegate(nint lrefValue)
		{
			try
			{
				return JNIEnv.CallObjectMethod(base.Handle, id_put, new JValue(lrefKey), new JValue(lrefValue));
			}
			catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Put"))
			{
				throw new NotSupportedException(ex.Message, ex);
			}
			catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Put"))
			{
				throw new InvalidCastException(ex2.Message, ex2);
			}
			catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Put"))
			{
				throw new NullReferenceException(ex3.Message, ex3);
			}
			catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "Put"))
			{
				throw new ArgumentException(ex4.Message, ex4);
			}
		})));
	}

	public JavaDictionary()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			if (GetType() == typeof(JavaDictionary))
			{
				SetHandle(JNIEnv.StartCreateInstance("java/util/HashMap", "()V"), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
			}
			else
			{
				SetHandle(JNIEnv.StartCreateInstance(GetType(), "()V"), JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(base.Handle, "()V");
			}
		}
	}

	public JavaDictionary(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public JavaDictionary(IDictionary items)
		: this()
	{
		if (items == null)
		{
			Dispose();
			throw new ArgumentNullException("items");
		}
		foreach (DictionaryEntry item in items)
		{
			Add(item.Key, item.Value);
		}
	}

	public void Add(object key, object? value)
	{
		if (Contains(key))
		{
			throw new ArgumentException("The key '" + key?.ToString() + "' already exists.", "key");
		}
		Put(key, value);
	}

	public void Clear()
	{
		if (id_clear == IntPtr.Zero)
		{
			id_clear = JNIEnv.GetMethodID(map_class, "clear", "()V");
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

	public bool Contains(object key)
	{
		if (id_containsKey == IntPtr.Zero)
		{
			id_containsKey = JNIEnv.GetMethodID(map_class, "containsKey", "(Ljava/lang/Object;)Z");
		}
		return JavaConvert.WithLocalJniHandle(key, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, id_containsKey, new JValue(lref));
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
		IDictionaryEnumerator dictionaryEnumerator = GetEnumerator();
		try
		{
			while (dictionaryEnumerator.MoveNext())
			{
				object current = dictionaryEnumerator.Current;
				array.SetValue(current, array_index + num++);
			}
		}
		finally
		{
			IDisposable disposable = dictionaryEnumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		foreach (object key in Keys)
		{
			yield return new DictionaryEntry(key, this[key]);
		}
	}

	public IDictionaryEnumerator GetEnumerator()
	{
		return new DictionaryEnumerator(this);
	}

	public void Remove(object key)
	{
		if (id_remove == IntPtr.Zero)
		{
			id_remove = JNIEnv.GetMethodID(map_class, "remove", "(Ljava/lang/Object;)Ljava/lang/Object;");
		}
		JNIEnv.DeleteLocalRef(JavaConvert.WithLocalJniHandle(key, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallObjectMethod(base.Handle, id_remove, new JValue(lref));
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
		}));
	}

	public static IDictionary? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle);
		if (javaObject == null)
		{
			javaObject = new JavaDictionary(handle, transfer);
		}
		else
		{
			JNIEnv.DeleteRef(handle, transfer);
		}
		return (IDictionary)javaObject;
	}

	public static nint ToLocalJniHandle(IDictionary? dictionary)
	{
		if (dictionary == null)
		{
			return IntPtr.Zero;
		}
		if (dictionary is JavaDictionary value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaDictionary value2;
		using (value2 = new JavaDictionary(dictionary))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}
}
[Register("java/util/HashMap", DoNotGenerateAcw = true)]
public class JavaDictionary<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] K, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] V> : JavaDictionary, IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable
{
	public V this[K key]
	{
		[return: MaybeNull]
		[return: MaybeNull]
		get
		{
			if (!Contains(key))
			{
				throw new KeyNotFoundException();
			}
			return Get(key);
		}
		set
		{
			Put(key, value);
		}
	}

	public new ICollection<K> Keys => new JavaSet<K>(GetKeys(), JniHandleOwnership.TransferLocalRef);

	public new ICollection<V> Values => new JavaCollection<V>(GetValues(), JniHandleOwnership.TransferLocalRef);

	public JavaDictionary()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			if (GetType() == typeof(JavaDictionary<K, V>))
			{
				SetHandle(JNIEnv.StartCreateInstance("java/util/HashMap", "()V"), JniHandleOwnership.TransferLocalRef);
			}
			else
			{
				SetHandle(JNIEnv.StartCreateInstance(GetType(), "()V"), JniHandleOwnership.TransferLocalRef);
			}
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
		}
	}

	public JavaDictionary(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public JavaDictionary(IDictionary<K, V> items)
		: this()
	{
		if (items == null)
		{
			Dispose();
			throw new ArgumentNullException("items");
		}
		foreach (K key in items.Keys)
		{
			Add(key, items[key]);
		}
	}

	internal V? Get(K key)
	{
		if (JavaDictionary.id_get == IntPtr.Zero)
		{
			JavaDictionary.id_get = JNIEnv.GetMethodID(JavaDictionary.map_class, "get", "(Ljava/lang/Object;)Ljava/lang/Object;");
		}
		return JavaConvert.FromJniHandle<V>(JavaConvert.WithLocalJniHandle(key, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallObjectMethod(base.Handle, JavaDictionary.id_get, new JValue(lref));
			}
			catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Get"))
			{
				throw new InvalidCastException(ex.Message, ex);
			}
			catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Get"))
			{
				throw new NullReferenceException(ex2.Message, ex2);
			}
		}), JniHandleOwnership.TransferLocalRef);
	}

	internal void Put(K key, V value)
	{
		if (JavaDictionary.id_put == IntPtr.Zero)
		{
			JavaDictionary.id_put = JNIEnv.GetMethodID(JavaDictionary.map_class, "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
		}
		JNIEnv.DeleteLocalRef(JavaConvert.WithLocalJniHandle(key, (nint lrefKey) => JavaConvert.WithLocalJniHandle(value, delegate(nint lrefValue)
		{
			try
			{
				return JNIEnv.CallObjectMethod(base.Handle, JavaDictionary.id_put, new JValue(lrefKey), new JValue(lrefValue));
			}
			catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Put"))
			{
				throw new NotSupportedException(ex.Message, ex);
			}
			catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Put"))
			{
				throw new InvalidCastException(ex2.Message, ex2);
			}
			catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Put"))
			{
				throw new NullReferenceException(ex3.Message, ex3);
			}
			catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "Put"))
			{
				throw new ArgumentException(ex4.Message, ex4);
			}
		})));
	}

	public void Add(KeyValuePair<K, V> item)
	{
		Add(item.Key, item.Value);
	}

	public void Add(K key, V value)
	{
		if (ContainsKey(key))
		{
			K val = key;
			throw new ArgumentException("The key '" + val?.ToString() + "' already exists.", "key");
		}
		Put(key, value);
	}

	public bool Contains(KeyValuePair<K, V> item)
	{
		return ContainsKey(item.Key);
	}

	public bool ContainsKey(K key)
	{
		if (JavaDictionary.id_containsKey == IntPtr.Zero)
		{
			JavaDictionary.id_containsKey = JNIEnv.GetMethodID(JavaDictionary.map_class, "containsKey", "(Ljava/lang/Object;)Z");
		}
		return JavaConvert.WithLocalJniHandle(key, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallBooleanMethod(base.Handle, JavaDictionary.id_containsKey, new JValue(lref));
			}
			catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "ContainsKey"))
			{
				throw new InvalidCastException(ex.Message, ex);
			}
			catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "ContainsKey"))
			{
				throw new NullReferenceException(ex2.Message, ex2);
			}
		});
	}

	public void CopyTo(KeyValuePair<K, V>[] array, int array_index)
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
		using IEnumerator<KeyValuePair<K, V>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<K, V> current = enumerator.Current;
			array[array_index + num++] = current;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public new IEnumerator<KeyValuePair<K, V>> GetEnumerator()
	{
		foreach (K key in Keys)
		{
			yield return new KeyValuePair<K, V>(key, this[key]);
		}
	}

	public bool Remove(KeyValuePair<K, V> pair)
	{
		return Remove(pair.Key);
	}

	public bool Remove(K key)
	{
		bool result = ContainsKey(key);
		if (JavaDictionary.id_remove == IntPtr.Zero)
		{
			JavaDictionary.id_remove = JNIEnv.GetMethodID(JavaDictionary.map_class, "remove", "(Ljava/lang/Object;)Ljava/lang/Object;");
		}
		JNIEnv.DeleteLocalRef(JavaConvert.WithLocalJniHandle(key, delegate(nint lref)
		{
			try
			{
				return JNIEnv.CallObjectMethod(base.Handle, JavaDictionary.id_remove, new JValue(lref));
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
		}));
		return result;
	}

	public bool TryGetValue(K key, out V value)
	{
		value = Get(key);
		return ContainsKey(key);
	}

	public new static IDictionary<K, V>? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle);
		if (javaObject == null)
		{
			javaObject = new JavaDictionary<K, V>(handle, transfer);
		}
		else
		{
			JNIEnv.DeleteRef(handle, transfer);
		}
		return (IDictionary<K, V>)javaObject;
	}

	public static nint ToLocalJniHandle(IDictionary<K, V>? dictionary)
	{
		if (dictionary == null)
		{
			return IntPtr.Zero;
		}
		if (dictionary is JavaDictionary<K, V> value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaDictionary<K, V> value2;
		using (value2 = new JavaDictionary<K, V>(dictionary))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}
}

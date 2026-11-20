using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace Android.Runtime;

[Register("java/util/ArrayList", DoNotGenerateAcw = true)]
public class JavaList : Java.Lang.Object, System.Collections.IList, System.Collections.ICollection, IEnumerable
{
	internal static readonly JniPeerMembers list_members = new XAPeerMembers("java/util/List", typeof(JavaList), isInterface: true);

	public unsafe int Count => list_members.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	public object? SyncRoot => null;

	public object? this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return InternalGet(index);
		}
		set
		{
			InternalSet(index, value);
		}
	}

	public virtual bool IsEmpty => Count == 0;

	internal unsafe object? InternalGet(int location, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null)
	{
		JniObjectReference jniObjectReference;
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(location)
			};
			jniObjectReference = list_members.InstanceMethods.InvokeAbstractObjectMethod("get.(I)Ljava/lang/Object;", this, parameters);
		}
		catch (IndexOutOfBoundsException ex) when (JNIEnv.ShouldWrapJavaException(ex, "InternalGet"))
		{
			throw new ArgumentOutOfRangeException(ex.Message, ex);
		}
		return JavaConvert.FromJniHandle(jniObjectReference.Handle, JniHandleOwnership.TransferLocalRef, targetType);
	}

	public unsafe virtual IIterator Iterator()
	{
		return Java.Lang.Object.GetObject<IIterator>(list_members.InstanceMethods.InvokeAbstractObjectMethod("iterator.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	internal unsafe void InternalSet(int location, object? value)
	{
		nint num = JavaConvert.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[2]
			{
				new JniArgumentValue(location),
				new JniArgumentValue(num)
			};
			JniObjectReference reference = list_members.InstanceMethods.InvokeAbstractObjectMethod("set.(ILjava/lang/Object;)Ljava/lang/Object;", this, parameters);
			JniObjectReference.Dispose(ref reference);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "InternalSet"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
		catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "InternalSet"))
		{
			throw new InvalidCastException(ex2.Message, ex2);
		}
		catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "InternalSet"))
		{
			throw new NullReferenceException(ex3.Message, ex3);
		}
		catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "InternalSet"))
		{
			throw new ArgumentException(ex4.Message, ex4);
		}
		catch (IndexOutOfBoundsException ex5) when (JNIEnv.ShouldWrapJavaException(ex5, "InternalSet"))
		{
			throw new ArgumentOutOfRangeException(ex5.Message, ex5);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	[Register(".ctor", "()V", "")]
	public unsafe JavaList()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniPeerMembers.JniInstanceMethods instanceMethods = JniPeerMembers.InstanceMethods;
			SetHandle(instanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			instanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	public JavaList(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public JavaList(IEnumerable items)
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

	public unsafe int Add(object? item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(num)
			};
			list_members.InstanceMethods.InvokeAbstractBooleanMethod("add.(Ljava/lang/Object;)Z", this, parameters);
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
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
		return Count - 1;
	}

	public unsafe void Clear()
	{
		try
		{
			list_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Clear"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
	}

	public unsafe bool Contains(object? item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(num)
			};
			return list_members.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Ljava/lang/Object;)Z", this, parameters);
		}
		catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Contains"))
		{
			throw new InvalidCastException(ex.Message, ex);
		}
		catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Contains"))
		{
			throw new NullReferenceException(ex2.Message, ex2);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
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
		Type targetType = GetElementType(array);
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			array.SetValue(InternalGet(i, targetType), array_index + i);
		}
		[UnconditionalSuppressMessage("Trimming", "IL2073", Justification = "JavaList<T> constructors are preserved by the MarkJavaObjects trimmer step.")]
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

	public unsafe virtual int IndexOf(object? item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(num)
			};
			return list_members.InstanceMethods.InvokeAbstractInt32Method("indexOf.(Ljava/lang/Object;)I", this, parameters);
		}
		catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "IndexOf"))
		{
			throw new InvalidCastException(ex.Message, ex);
		}
		catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "IndexOf"))
		{
			throw new NullReferenceException(ex2.Message, ex2);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
	}

	public unsafe virtual int LastIndexOf(object item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(num)
			};
			return list_members.InstanceMethods.InvokeAbstractInt32Method("lastIndexOf.(Ljava/lang/Object;)I", this, parameters);
		}
		catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "LastIndexOf"))
		{
			throw new InvalidCastException(ex.Message, ex);
		}
		catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "LastIndexOf"))
		{
			throw new NullReferenceException(ex2.Message, ex2);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
	}

	public unsafe void Insert(int index, object? item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[2]
			{
				new JniArgumentValue(index),
				new JniArgumentValue(num)
			};
			list_members.InstanceMethods.InvokeAbstractVoidMethod("add.(ILjava/lang/Object;)V", this, parameters);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Insert"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
		catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Insert"))
		{
			throw new InvalidCastException(ex2.Message, ex2);
		}
		catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Insert"))
		{
			throw new NullReferenceException(ex3.Message, ex3);
		}
		catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "Insert"))
		{
			throw new ArgumentException(ex4.Message, ex4);
		}
		catch (IndexOutOfBoundsException ex5) when (JNIEnv.ShouldWrapJavaException(ex5, "Insert"))
		{
			throw new ArgumentOutOfRangeException(ex5.Message, ex5);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
	}

	public void Remove(object? item)
	{
		int num = IndexOf(item);
		if (num >= 0 || num < Count)
		{
			RemoveAt(num);
		}
	}

	public unsafe void RemoveAt(int index)
	{
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(index)
			};
			JniObjectReference reference = list_members.InstanceMethods.InvokeAbstractObjectMethod("remove.(I)Ljava/lang/Object;", this, parameters);
			JniObjectReference.Dispose(ref reference);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "RemoveAt"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
		catch (IndexOutOfBoundsException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "RemoveAt"))
		{
			throw new ArgumentOutOfRangeException(ex2.Message, ex2);
		}
	}

	public unsafe virtual Java.Lang.Object? Set(int location, Java.Lang.Object item)
	{
		JniObjectReference jniObjectReference;
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[2]
			{
				new JniArgumentValue(location),
				new JniArgumentValue(item)
			};
			jniObjectReference = list_members.InstanceMethods.InvokeAbstractObjectMethod("set.(ILjava/lang/Object;)Ljava/lang/Object;", this, parameters);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Set"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
		catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Set"))
		{
			throw new InvalidCastException(ex2.Message, ex2);
		}
		catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Set"))
		{
			throw new NullReferenceException(ex3.Message, ex3);
		}
		catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "Set"))
		{
			throw new ArgumentException(ex4.Message, ex4);
		}
		catch (IndexOutOfBoundsException ex5) when (JNIEnv.ShouldWrapJavaException(ex5, "Set"))
		{
			throw new ArgumentOutOfRangeException(ex5.Message, ex5);
		}
		return Java.Lang.Object.GetObject<Java.Lang.Object>(jniObjectReference.Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe virtual JavaList SubList(int start, int end)
	{
		JniObjectReference jniObjectReference;
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[2]
			{
				new JniArgumentValue(start),
				new JniArgumentValue(end)
			};
			jniObjectReference = list_members.InstanceMethods.InvokeAbstractObjectMethod("subList.(II)Ljava/util/List;", this, parameters);
		}
		catch (IllegalArgumentException ex) when (JNIEnv.ShouldWrapJavaException(ex, "SubList"))
		{
			throw new ArgumentException(ex.Message, ex);
		}
		catch (IndexOutOfBoundsException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "SubList"))
		{
			throw new ArgumentOutOfRangeException(ex2.Message, ex2);
		}
		return new JavaList(jniObjectReference.Handle, JniHandleOwnership.TransferLocalRef);
	}

	public static System.Collections.IList? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle);
		if (javaObject == null)
		{
			javaObject = new JavaList(handle, transfer);
		}
		else
		{
			JNIEnv.DeleteRef(handle, transfer);
		}
		return (System.Collections.IList)javaObject;
	}

	public static nint ToLocalJniHandle(System.Collections.IList? items)
	{
		if (items == null)
		{
			return IntPtr.Zero;
		}
		if (items is JavaList value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaList value2;
		using (value2 = new JavaList(items))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}

	public virtual bool Add(Java.Lang.Object? item)
	{
		Add((object?)item);
		return true;
	}

	public virtual bool Add(int index, Java.Lang.Object? item)
	{
		Insert(index, item);
		return true;
	}

	public virtual bool Add(JavaList collection)
	{
		return AddAll(0, collection);
	}

	public virtual bool AddAll(int location, JavaList collection)
	{
		int num = location;
		bool flag = false;
		foreach (Java.Lang.Object item in collection)
		{
			flag |= Add(num++, item);
		}
		return flag;
	}

	public virtual bool Contains(Java.Lang.Object? item)
	{
		return Contains((object?)item);
	}

	public virtual bool ContainsAll(JavaList collection)
	{
		foreach (Java.Lang.Object item in collection)
		{
			if (!Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	public new virtual bool Equals(Java.Lang.Object obj)
	{
		if (!(obj is JavaList javaList) || Count != javaList.Count)
		{
			return false;
		}
		for (int i = 0; i < Count; i++)
		{
			object? obj2 = this[i];
			if (obj2 == null || !obj2.Equals(javaList[i]))
			{
				return false;
			}
		}
		return true;
	}

	public virtual Java.Lang.Object? Get(int location)
	{
		return (Java.Lang.Object)InternalGet(location);
	}

	public virtual int IndexOf(Java.Lang.Object? item)
	{
		return IndexOf((object?)item);
	}

	public virtual Java.Lang.Object? Remove(int location)
	{
		Java.Lang.Object? result = Get(location);
		RemoveAt(location);
		return result;
	}

	public virtual bool Remove(Java.Lang.Object? item)
	{
		int num = IndexOf(item);
		if (num < 0 && num >= Count)
		{
			return false;
		}
		RemoveAt(num);
		return true;
	}

	public virtual bool RemoveAll(JavaList collection)
	{
		bool flag = false;
		foreach (Java.Lang.Object item in collection)
		{
			flag |= Remove(item);
		}
		return flag;
	}

	public virtual bool RetainAll(JavaList collection)
	{
		bool result = false;
		for (int i = 0; i < Count; i++)
		{
			Java.Lang.Object item = Get(i);
			if (!collection.Contains(item))
			{
				Remove(item);
				result = true;
				i--;
			}
		}
		return result;
	}

	public virtual int Size()
	{
		return Count;
	}

	public virtual Java.Lang.Object[] ToArray(Java.Lang.Object[] array)
	{
		if (array.Length < Count)
		{
			array = new Java.Lang.Object[Count];
		}
		CopyTo(array, 0);
		return array;
	}

	public virtual Java.Lang.Object[] ToArray()
	{
		return ToArray(new Java.Lang.Object[0]);
	}
}
[Register("java/util/ArrayList", DoNotGenerateAcw = true)]
public class JavaList<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : JavaList, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	public new T this[int index]
	{
		[return: MaybeNull]
		[return: MaybeNull]
		get
		{
			if (index < 0 || index >= base.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return InternalGet(index);
		}
		set
		{
			InternalSet(index, value);
		}
	}

	[Register(".ctor", "()V", "")]
	public unsafe JavaList()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniPeerMembers.JniInstanceMethods instanceMethods = JniPeerMembers.InstanceMethods;
			SetHandle(instanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			instanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	public JavaList(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public JavaList(IEnumerable<T> items)
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

	internal unsafe T? InternalGet(int location)
	{
		JniObjectReference jniObjectReference;
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(location)
			};
			jniObjectReference = JavaList.list_members.InstanceMethods.InvokeAbstractObjectMethod("get.(I)Ljava/lang/Object;", this, parameters);
		}
		catch (IndexOutOfBoundsException ex) when (JNIEnv.ShouldWrapJavaException(ex, "InternalGet"))
		{
			throw new ArgumentOutOfRangeException(ex.Message, ex);
		}
		return JavaConvert.FromJniHandle<T>(jniObjectReference.Handle, JniHandleOwnership.TransferLocalRef);
	}

	internal unsafe void InternalSet(int location, T value)
	{
		nint num = JavaConvert.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[2]
			{
				new JniArgumentValue(location),
				new JniArgumentValue(num)
			};
			JniObjectReference reference = JavaList.list_members.InstanceMethods.InvokeAbstractObjectMethod("set.(ILjava/lang/Object;)Ljava/lang/Object;", this, parameters);
			JniObjectReference.Dispose(ref reference);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "InternalSet"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
		catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "InternalSet"))
		{
			throw new InvalidCastException(ex2.Message, ex2);
		}
		catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "InternalSet"))
		{
			throw new NullReferenceException(ex3.Message, ex3);
		}
		catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "InternalSet"))
		{
			throw new ArgumentException(ex4.Message, ex4);
		}
		catch (IndexOutOfBoundsException ex5) when (JNIEnv.ShouldWrapJavaException(ex5, "InternalSet"))
		{
			throw new ArgumentOutOfRangeException(ex5.Message, ex5);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	public unsafe void Add(T item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(num)
			};
			JavaList.list_members.InstanceMethods.InvokeAbstractBooleanMethod("add.(Ljava/lang/Object;)Z", this, parameters);
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
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
	}

	public unsafe bool Contains(T item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(num)
			};
			return JavaList.list_members.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Ljava/lang/Object;)Z", this, parameters);
		}
		catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Contains"))
		{
			throw new InvalidCastException(ex.Message, ex);
		}
		catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Contains"))
		{
			throw new NullReferenceException(ex2.Message, ex2);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
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
		for (int i = 0; i < base.Count; i++)
		{
			array[array_index + i] = this[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public new IEnumerator<T?> GetEnumerator()
	{
		return Iterator().ToEnumerator_Dispose<T>();
	}

	public unsafe int IndexOf(T item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[1]
			{
				new JniArgumentValue(num)
			};
			return JavaList.list_members.InstanceMethods.InvokeAbstractInt32Method("indexOf.(Ljava/lang/Object;)I", this, parameters);
		}
		catch (ClassCastException ex) when (JNIEnv.ShouldWrapJavaException(ex, "IndexOf"))
		{
			throw new InvalidCastException(ex.Message, ex);
		}
		catch (NullPointerException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "IndexOf"))
		{
			throw new NullReferenceException(ex2.Message, ex2);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
	}

	public unsafe void Insert(int index, T item)
	{
		nint num = JavaConvert.ToLocalJniHandle(item);
		try
		{
			JniArgumentValue* parameters = stackalloc JniArgumentValue[2]
			{
				new JniArgumentValue(index),
				new JniArgumentValue(num)
			};
			JavaList.list_members.InstanceMethods.InvokeAbstractVoidMethod("add.(ILjava/lang/Object;)V", this, parameters);
		}
		catch (UnsupportedOperationException ex) when (JNIEnv.ShouldWrapJavaException(ex, "Insert"))
		{
			throw new NotSupportedException(ex.Message, ex);
		}
		catch (ClassCastException ex2) when (JNIEnv.ShouldWrapJavaException(ex2, "Insert"))
		{
			throw new InvalidCastException(ex2.Message, ex2);
		}
		catch (NullPointerException ex3) when (JNIEnv.ShouldWrapJavaException(ex3, "Insert"))
		{
			throw new NullReferenceException(ex3.Message, ex3);
		}
		catch (IllegalArgumentException ex4) when (JNIEnv.ShouldWrapJavaException(ex4, "Insert"))
		{
			throw new ArgumentException(ex4.Message, ex4);
		}
		catch (IndexOutOfBoundsException ex5) when (JNIEnv.ShouldWrapJavaException(ex5, "Insert"))
		{
			throw new ArgumentOutOfRangeException(ex5.Message, ex5);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(item);
		}
	}

	public bool Remove(T item)
	{
		int num = IndexOf(item);
		if (num < 0 && num >= base.Count)
		{
			return false;
		}
		RemoveAt(num);
		return true;
	}

	public new static IList<T>? FromJniHandle(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaObject javaObject = (IJavaObject)Java.Lang.Object.PeekObject(handle, typeof(IList<T>));
		if (javaObject == null)
		{
			javaObject = new JavaList<T>(handle, transfer);
		}
		else
		{
			JNIEnv.DeleteRef(handle, transfer);
		}
		return (IList<T>)javaObject;
	}

	public static nint ToLocalJniHandle(IList<T>? items)
	{
		if (items == null)
		{
			return IntPtr.Zero;
		}
		if (items is JavaList<T> value)
		{
			return JNIEnv.ToLocalJniHandle(value);
		}
		JavaList<T> value2;
		using (value2 = new JavaList<T>(items))
		{
			return JNIEnv.ToLocalJniHandle(value2);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("java/lang/Object", ArrayRank = 1, GenerateJavaPeer = false)]
public abstract class JavaArray<T> : JavaObject, IList, ICollection, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>
{
	internal delegate TArray ArrayCreator<TArray>(ref JniObjectReference reference, JniObjectReferenceOptions transfer) where TArray : JavaArray<T>;

	internal bool forMarshalCollection;

	public int Length => JniEnvironment.Arrays.GetArrayLength(base.PeerReference);

	public abstract T this[int index]
	{
		[return: MaybeNull]
		get;
		set; }

	public bool IsReadOnly => false;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	int ICollection<T>.Count => Length;

	int ICollection.Count => Length;

	bool IList.IsFixedSize => true;

	object? IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = (T)value;
		}
	}

	internal JavaArray(ref JniObjectReference handle, JniObjectReferenceOptions transfer)
		: base(ref handle, transfer)
	{
	}

	public abstract void Clear();

	public abstract void CopyTo(T[] array, int arrayIndex);

	public abstract int IndexOf(T item);

	public virtual bool Contains(T item)
	{
		return IndexOf(item) >= 0;
	}

	public T[] ToArray()
	{
		T[] array = new T[Length];
		CopyTo(array, 0);
		return array;
	}

	public virtual IEnumerator<T> GetEnumerator()
	{
		int len = Length;
		int i = 0;
		while (i < len)
		{
			yield return this[i];
			int num = i + 1;
			i = num;
		}
	}

	internal static void CheckArrayCopy(int sourceIndex, int sourceLength, int destinationIndex, int destinationLength, int length)
	{
		if (sourceIndex < 0)
		{
			throw new ArgumentOutOfRangeException("sourceIndex", $"source index must be >= 0; was {sourceIndex}.");
		}
		if (sourceIndex != 0 && sourceIndex >= sourceLength)
		{
			throw new ArgumentException("source index is > source length.", "sourceIndex");
		}
		checked
		{
			if (sourceIndex + length > sourceLength)
			{
				throw new ArgumentException("source index + length >= source length", "length");
			}
			if (destinationIndex < 0)
			{
				throw new ArgumentOutOfRangeException("destinationIndex", $"destination index must be >= 0; was {destinationIndex}.");
			}
			if (destinationIndex != 0 && destinationIndex >= destinationLength)
			{
				throw new ArgumentException("destination index is > destination length.", "destinationIndex");
			}
			if (destinationIndex + length > destinationLength)
			{
				throw new ArgumentException("destination index + length >= destination length", "length");
			}
		}
	}

	internal static int CheckLength(int length)
	{
		if (length < 0)
		{
			throw new ArgumentException("'length' cannot be negative.", "length");
		}
		return length;
	}

	internal static int CheckLength(IList<T> value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		return value.Count;
	}

	internal IList<T> ToTargetType(Type? targetType, bool dispose)
	{
		if (TargetTypeIsCurrentType(targetType))
		{
			return this;
		}
		if (targetType == typeof(T[]) || targetType.IsAssignableFrom(typeof(IList<T>)))
		{
			try
			{
				return ToArray();
			}
			finally
			{
				if (dispose)
				{
					Dispose();
				}
			}
		}
		throw CreateMarshalNotSupportedException(GetType(), targetType);
	}

	internal virtual bool TargetTypeIsCurrentType([NotNullWhen(false)] Type? targetType)
	{
		if (!(targetType == null))
		{
			return targetType == typeof(JavaArray<T>);
		}
		return true;
	}

	internal static Exception CreateMarshalNotSupportedException(Type sourceType, Type? targetType)
	{
		return new NotSupportedException(string.Format("Do not know how to marshal a `{0}`{1}.", sourceType.FullName, (targetType != null) ? (" into a `" + targetType.FullName + "`") : ""));
	}

	internal static IList<T> CreateValue<TArray>(ref JniObjectReference reference, JniObjectReferenceOptions transfer, Type? targetType, ArrayCreator<TArray> creator) where TArray : JavaArray<T>
	{
		return creator(ref reference, transfer).ToTargetType(targetType, dispose: true);
	}

	internal static JniValueMarshalerState CreateArgumentState<TArray>(IList<T>? value, ParameterAttributes synchronize, Func<IList<T>, bool, TArray> creator) where TArray : JavaArray<T>
	{
		if (value == null)
		{
			return default(JniValueMarshalerState);
		}
		if (value is TArray peerableValue)
		{
			return new JniValueMarshalerState(peerableValue);
		}
		if (value == null)
		{
			throw CreateMarshalNotSupportedException(value.GetType(), typeof(TArray));
		}
		synchronize = GetCopyDirection(synchronize);
		bool arg = (synchronize & ParameterAttributes.In) == ParameterAttributes.In;
		return new JniValueMarshalerState(creator(value, arg));
	}

	internal static void DestroyArgumentState<TArray>(IList<T>? value, ref JniValueMarshalerState state, ParameterAttributes synchronize) where TArray : JavaArray<T>
	{
		TArray val = (TArray)state.PeerableValue;
		if (val == null)
		{
			return;
		}
		synchronize = GetCopyDirection(synchronize);
		if ((synchronize & ParameterAttributes.Out) == ParameterAttributes.Out)
		{
			T[] array = value as T[];
			if (array != null)
			{
				val.CopyTo(array, 0);
			}
			else if (value != null)
			{
				val.CopyToList(value, 0);
			}
		}
		if (val.forMarshalCollection)
		{
			val.Dispose();
		}
		state = default(JniValueMarshalerState);
	}

	internal static ParameterAttributes GetCopyDirection(ParameterAttributes value)
	{
		if ((value & (ParameterAttributes.In | ParameterAttributes.Out)) != ParameterAttributes.None)
		{
			return value & (ParameterAttributes.In | ParameterAttributes.Out);
		}
		return ParameterAttributes.In | ParameterAttributes.Out;
	}

	internal virtual void CopyToList(IList<T> list, int index)
	{
		int length = Length;
		for (int i = 0; i < length; i++)
		{
			list[index + i] = this[i];
		}
	}

	void ICollection.CopyTo(Array array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		CheckArrayCopy(0, Length, index, array.Length, Length);
		int length = Length;
		for (int i = 0; i < length; i++)
		{
			array.SetValue(this[i], index + i);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	void ICollection<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	bool IList.Contains(object? value)
	{
		if (value is T)
		{
			return Contains((T)value);
		}
		return false;
	}

	int IList.IndexOf(object? value)
	{
		if (value is T)
		{
			return IndexOf((T)value);
		}
		return -1;
	}

	int IList.Add(object? value)
	{
		throw new NotSupportedException();
	}

	void IList.Insert(int index, object? value)
	{
		throw new NotSupportedException();
	}

	void IList.Remove(object? value)
	{
		throw new NotSupportedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void IList<T>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	void IList<T>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}
}

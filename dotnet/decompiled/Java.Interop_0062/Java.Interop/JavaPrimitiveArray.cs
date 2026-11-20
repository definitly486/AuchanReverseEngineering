using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Java.Interop;

[JniTypeSignature("java/lang/Object", ArrayRank = 1, GenerateJavaPeer = false)]
public abstract class JavaPrimitiveArray<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : JavaArray<T>
{
	public override T this[int index]
	{
		get
		{
			T[] array = new T[1];
			CopyTo(index, array, 0, array.Length);
			return array[0];
		}
		set
		{
			if (index >= base.Length)
			{
				throw new ArgumentOutOfRangeException("index", "index >= Length");
			}
			T[] array = new T[1] { value };
			CopyFrom(array, 0, index, array.Length);
		}
	}

	internal JavaPrimitiveArray(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
		: base(ref reference, transfer)
	{
	}

	public override void DisposeUnlessReferenced()
	{
		if (forMarshalCollection)
		{
			Dispose();
		}
		else
		{
			base.DisposeUnlessReferenced();
		}
	}

	public abstract void CopyTo(int sourceIndex, T[] destinationArray, int destinationIndex, int length);

	public abstract void CopyFrom(T[] sourceArray, int sourceIndex, int destinationIndex, int length);

	public override void CopyTo(T[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, base.Length);
	}

	internal static T[] ToArray(IEnumerable<T> value)
	{
		if (value is T[] result)
		{
			return result;
		}
		return value.ToArray();
	}
}

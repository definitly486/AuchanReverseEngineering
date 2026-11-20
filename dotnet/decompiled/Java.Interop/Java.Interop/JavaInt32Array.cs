using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("I", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaInt32Array : JavaPrimitiveArray<int>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<int>>
	{
		public override IList<int> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<int>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaInt32Array(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<int> value, ParameterAttributes synchronize)
		{
			return JavaArray<int>.CreateArgumentState(value, synchronize, delegate(IList<int> list, bool copy)
			{
				JavaInt32Array obj = (copy ? new JavaInt32Array(list) : new JavaInt32Array(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<int> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<int>.DestroyArgumentState<JavaInt32Array>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaInt32Array(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaInt32Array(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewIntArray(JavaArray<int>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaInt32Array(IList<int> value)
		: this(JavaArray<int>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<int>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniInt32ArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		int* intArrayElements = JniEnvironment.Arrays.GetIntArrayElements(base.PeerReference, null);
		if (intArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetIntArrayElements()` returned NULL!");
		}
		return new JniInt32ArrayElements(base.PeerReference, intArrayElements, base.Length * 4);
	}

	public override int IndexOf(int item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniInt32ArrayElements jniInt32ArrayElements = GetElements())
		{
			if (jniInt32ArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniInt32ArrayElements[i] == item)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public override void Clear()
	{
		int length = base.Length;
		using JniInt32ArrayElements jniInt32ArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniInt32ArrayElements[i] = 0;
		}
	}

	public unsafe override void CopyTo(int sourceIndex, int[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<int>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (int* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetIntArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(int[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<int>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (int* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetIntArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<int>) == targetType))
		{
			return typeof(JavaInt32Array) == targetType;
		}
		return true;
	}
}

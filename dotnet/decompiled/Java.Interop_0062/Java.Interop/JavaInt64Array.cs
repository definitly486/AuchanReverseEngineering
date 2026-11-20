using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("J", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaInt64Array : JavaPrimitiveArray<long>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<long>>
	{
		public override IList<long> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<long>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaInt64Array(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<long> value, ParameterAttributes synchronize)
		{
			return JavaArray<long>.CreateArgumentState(value, synchronize, delegate(IList<long> list, bool copy)
			{
				JavaInt64Array obj = (copy ? new JavaInt64Array(list) : new JavaInt64Array(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<long> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<long>.DestroyArgumentState<JavaInt64Array>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaInt64Array(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaInt64Array(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewLongArray(JavaArray<long>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaInt64Array(IList<long> value)
		: this(JavaArray<long>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<long>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniInt64ArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		long* longArrayElements = JniEnvironment.Arrays.GetLongArrayElements(base.PeerReference, null);
		if (longArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetLongArrayElements()` returned NULL!");
		}
		return new JniInt64ArrayElements(base.PeerReference, longArrayElements, base.Length * 8);
	}

	public override int IndexOf(long item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniInt64ArrayElements jniInt64ArrayElements = GetElements())
		{
			if (jniInt64ArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniInt64ArrayElements[i] == item)
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
		using JniInt64ArrayElements jniInt64ArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniInt64ArrayElements[i] = 0L;
		}
	}

	public unsafe override void CopyTo(int sourceIndex, long[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<long>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (long* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetLongArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(long[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<long>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (long* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetLongArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<long>) == targetType))
		{
			return typeof(JavaInt64Array) == targetType;
		}
		return true;
	}
}

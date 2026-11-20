using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("B", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaSByteArray : JavaPrimitiveArray<sbyte>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<sbyte>>
	{
		public override IList<sbyte> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<sbyte>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaSByteArray(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<sbyte> value, ParameterAttributes synchronize)
		{
			return JavaArray<sbyte>.CreateArgumentState(value, synchronize, delegate(IList<sbyte> list, bool copy)
			{
				JavaSByteArray obj = (copy ? new JavaSByteArray(list) : new JavaSByteArray(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<sbyte> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<sbyte>.DestroyArgumentState<JavaSByteArray>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaSByteArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaSByteArray(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewByteArray(JavaArray<sbyte>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaSByteArray(IList<sbyte> value)
		: this(JavaArray<sbyte>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<sbyte>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniSByteArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		sbyte* byteArrayElements = JniEnvironment.Arrays.GetByteArrayElements(base.PeerReference, null);
		if (byteArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetByteArrayElements()` returned NULL!");
		}
		return new JniSByteArrayElements(base.PeerReference, byteArrayElements, base.Length);
	}

	public override int IndexOf(sbyte item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniSByteArrayElements jniSByteArrayElements = GetElements())
		{
			if (jniSByteArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniSByteArrayElements[i] == item)
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
		using JniSByteArrayElements jniSByteArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniSByteArrayElements[i] = 0;
		}
	}

	public unsafe override void CopyTo(int sourceIndex, sbyte[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<sbyte>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (sbyte* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetByteArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(sbyte[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<sbyte>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (sbyte* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetByteArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<sbyte>) == targetType))
		{
			return typeof(JavaSByteArray) == targetType;
		}
		return true;
	}
}

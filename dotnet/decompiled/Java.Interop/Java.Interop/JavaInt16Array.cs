using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("S", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaInt16Array : JavaPrimitiveArray<short>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<short>>
	{
		public override IList<short> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<short>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaInt16Array(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<short> value, ParameterAttributes synchronize)
		{
			return JavaArray<short>.CreateArgumentState(value, synchronize, delegate(IList<short> list, bool copy)
			{
				JavaInt16Array obj = (copy ? new JavaInt16Array(list) : new JavaInt16Array(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<short> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<short>.DestroyArgumentState<JavaInt16Array>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaInt16Array(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaInt16Array(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewShortArray(JavaArray<short>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaInt16Array(IList<short> value)
		: this(JavaArray<short>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<short>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniInt16ArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		short* shortArrayElements = JniEnvironment.Arrays.GetShortArrayElements(base.PeerReference, null);
		if (shortArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetShortArrayElements()` returned NULL!");
		}
		return new JniInt16ArrayElements(base.PeerReference, shortArrayElements, base.Length * 2);
	}

	public override int IndexOf(short item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniInt16ArrayElements jniInt16ArrayElements = GetElements())
		{
			if (jniInt16ArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniInt16ArrayElements[i] == item)
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
		using JniInt16ArrayElements jniInt16ArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniInt16ArrayElements[i] = 0;
		}
	}

	public unsafe override void CopyTo(int sourceIndex, short[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<short>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (short* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetShortArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(short[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<short>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (short* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetShortArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<short>) == targetType))
		{
			return typeof(JavaInt16Array) == targetType;
		}
		return true;
	}
}

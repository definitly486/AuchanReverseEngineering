using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("Z", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaBooleanArray : JavaPrimitiveArray<bool>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<bool>>
	{
		public override IList<bool> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<bool>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaBooleanArray(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<bool> value, ParameterAttributes synchronize)
		{
			return JavaArray<bool>.CreateArgumentState(value, synchronize, delegate(IList<bool> list, bool copy)
			{
				JavaBooleanArray obj = (copy ? new JavaBooleanArray(list) : new JavaBooleanArray(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<bool> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<bool>.DestroyArgumentState<JavaBooleanArray>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaBooleanArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaBooleanArray(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewBooleanArray(JavaArray<bool>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaBooleanArray(IList<bool> value)
		: this(JavaArray<bool>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<bool>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniBooleanArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		bool* booleanArrayElements = JniEnvironment.Arrays.GetBooleanArrayElements(base.PeerReference, null);
		if (booleanArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetBooleanArrayElements()` returned NULL!");
		}
		return new JniBooleanArrayElements(base.PeerReference, booleanArrayElements, base.Length);
	}

	public override int IndexOf(bool item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniBooleanArrayElements jniBooleanArrayElements = GetElements())
		{
			if (jniBooleanArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniBooleanArrayElements[i] == item)
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
		using JniBooleanArrayElements jniBooleanArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniBooleanArrayElements[i] = false;
		}
	}

	public unsafe override void CopyTo(int sourceIndex, bool[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<bool>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (bool* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetBooleanArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(bool[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<bool>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (bool* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetBooleanArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<bool>) == targetType))
		{
			return typeof(JavaBooleanArray) == targetType;
		}
		return true;
	}
}

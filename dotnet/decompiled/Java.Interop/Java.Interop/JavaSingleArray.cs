using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("F", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaSingleArray : JavaPrimitiveArray<float>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<float>>
	{
		public override IList<float> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<float>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaSingleArray(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<float> value, ParameterAttributes synchronize)
		{
			return JavaArray<float>.CreateArgumentState(value, synchronize, delegate(IList<float> list, bool copy)
			{
				JavaSingleArray obj = (copy ? new JavaSingleArray(list) : new JavaSingleArray(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<float> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<float>.DestroyArgumentState<JavaSingleArray>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaSingleArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaSingleArray(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewFloatArray(JavaArray<float>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaSingleArray(IList<float> value)
		: this(JavaArray<float>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<float>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniSingleArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		float* floatArrayElements = JniEnvironment.Arrays.GetFloatArrayElements(base.PeerReference, null);
		if (floatArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetFloatArrayElements()` returned NULL!");
		}
		return new JniSingleArrayElements(base.PeerReference, floatArrayElements, base.Length * 4);
	}

	public override int IndexOf(float item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniSingleArrayElements jniSingleArrayElements = GetElements())
		{
			if (jniSingleArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniSingleArrayElements[i] == item)
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
		using JniSingleArrayElements jniSingleArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniSingleArrayElements[i] = 0f;
		}
	}

	public unsafe override void CopyTo(int sourceIndex, float[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<float>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (float* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetFloatArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(float[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<float>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (float* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetFloatArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<float>) == targetType))
		{
			return typeof(JavaSingleArray) == targetType;
		}
		return true;
	}
}

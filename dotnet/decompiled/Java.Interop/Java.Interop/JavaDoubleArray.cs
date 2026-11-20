using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("D", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaDoubleArray : JavaPrimitiveArray<double>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<double>>
	{
		public override IList<double> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<double>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaDoubleArray(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<double> value, ParameterAttributes synchronize)
		{
			return JavaArray<double>.CreateArgumentState(value, synchronize, delegate(IList<double> list, bool copy)
			{
				JavaDoubleArray obj = (copy ? new JavaDoubleArray(list) : new JavaDoubleArray(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<double> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<double>.DestroyArgumentState<JavaDoubleArray>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaDoubleArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaDoubleArray(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewDoubleArray(JavaArray<double>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaDoubleArray(IList<double> value)
		: this(JavaArray<double>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<double>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniDoubleArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		double* doubleArrayElements = JniEnvironment.Arrays.GetDoubleArrayElements(base.PeerReference, null);
		if (doubleArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetDoubleArrayElements()` returned NULL!");
		}
		return new JniDoubleArrayElements(base.PeerReference, doubleArrayElements, base.Length * 8);
	}

	public override int IndexOf(double item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniDoubleArrayElements jniDoubleArrayElements = GetElements())
		{
			if (jniDoubleArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniDoubleArrayElements[i] == item)
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
		using JniDoubleArrayElements jniDoubleArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniDoubleArrayElements[i] = 0.0;
		}
	}

	public unsafe override void CopyTo(int sourceIndex, double[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<double>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (double* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetDoubleArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(double[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<double>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (double* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetDoubleArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<double>) == targetType))
		{
			return typeof(JavaDoubleArray) == targetType;
		}
		return true;
	}
}

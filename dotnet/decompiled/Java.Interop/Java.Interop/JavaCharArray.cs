using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("C", ArrayRank = 1, IsKeyword = true, GenerateJavaPeer = false)]
public sealed class JavaCharArray : JavaPrimitiveArray<char>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<char>>
	{
		public override IList<char> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<char>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
			{
				return new JavaCharArray(ref h, o);
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<char> value, ParameterAttributes synchronize)
		{
			return JavaArray<char>.CreateArgumentState(value, synchronize, delegate(IList<char> list, bool copy)
			{
				JavaCharArray obj = (copy ? new JavaCharArray(list) : new JavaCharArray(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<char> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<char>.DestroyArgumentState<JavaCharArray>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

	public JavaCharArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	public unsafe JavaCharArray(int length)
		: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = JniEnvironment.Arrays.NewCharArray(JavaArray<char>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaCharArray(IList<char> value)
		: this(JavaArray<char>.CheckLength(value))
	{
		CopyFrom(JavaPrimitiveArray<char>.ToArray(value), 0, 0, value.Count);
	}

	public unsafe JniCharArrayElements GetElements()
	{
		if (!base.PeerReference.IsValid)
		{
			throw JniEnvironment.CreateObjectDisposedException(this);
		}
		char* charArrayElements = JniEnvironment.Arrays.GetCharArrayElements(base.PeerReference, null);
		if (charArrayElements == null)
		{
			throw new InvalidOperationException("`JniEnvironment.Arrays.GetCharArrayElements()` returned NULL!");
		}
		return new JniCharArrayElements(base.PeerReference, charArrayElements, base.Length * 2);
	}

	public override int IndexOf(char item)
	{
		int length = base.Length;
		if (length == 0)
		{
			return -1;
		}
		using (JniCharArrayElements jniCharArrayElements = GetElements())
		{
			if (jniCharArrayElements == null)
			{
				return -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (jniCharArrayElements[i] == item)
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
		using JniCharArrayElements jniCharArrayElements = GetElements();
		for (int i = 0; i < length; i++)
		{
			jniCharArrayElements[i] = '\0';
		}
	}

	public unsafe override void CopyTo(int sourceIndex, char[] destinationArray, int destinationIndex, int length)
	{
		if (destinationArray == null)
		{
			throw new ArgumentNullException("destinationArray");
		}
		JavaArray<char>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
		if (destinationArray.Length != 0)
		{
			fixed (char* ptr = destinationArray)
			{
				JniEnvironment.Arrays.GetCharArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
			}
		}
	}

	public unsafe override void CopyFrom(char[] sourceArray, int sourceIndex, int destinationIndex, int length)
	{
		if (sourceArray == null)
		{
			throw new ArgumentNullException("sourceArray");
		}
		JavaArray<char>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
		if (sourceArray.Length != 0)
		{
			fixed (char* ptr = sourceArray)
			{
				JniEnvironment.Arrays.SetCharArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<char>) == targetType))
		{
			return typeof(JavaCharArray) == targetType;
		}
		return true;
	}
}

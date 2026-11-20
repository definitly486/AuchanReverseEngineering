using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

[JniTypeSignature("java/lang/Object", ArrayRank = 1, GenerateJavaPeer = false)]
public class JavaObjectArray<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : JavaArray<T>
{
	internal sealed class ValueMarshaler : JniValueMarshaler<IList<T>>
	{
		public override IList<T> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
		{
			return JavaArray<T>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions t)
			{
				return new JavaObjectArray<T>(ref h, t)
				{
					forMarshalCollection = true
				};
			});
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IList<T> value, ParameterAttributes synchronize)
		{
			return JavaArray<T>.CreateArgumentState(value, synchronize, delegate(IList<T> list, bool copy)
			{
				JavaObjectArray<T> obj = (copy ? new JavaObjectArray<T>(list) : new JavaObjectArray<T>(list.Count));
				obj.forMarshalCollection = true;
				return obj;
			});
		}

		public override void DestroyGenericArgumentState([AllowNull] IList<T> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JavaArray<T>.DestroyArgumentState<JavaObjectArray<T>>(value, ref state, synchronize);
		}
	}

	internal static readonly ValueMarshaler Instance = new ValueMarshaler();

	public override T this[int index]
	{
		[return: MaybeNull]
		get
		{
			if (index < 0 || index >= base.Length)
			{
				throw new ArgumentOutOfRangeException("index", "index < 0 || index >= Length");
			}
			return GetElementAt(index);
		}
		set
		{
			if (index < 0 || index >= base.Length)
			{
				throw new ArgumentOutOfRangeException("index", "index < 0 || index >= Length");
			}
			SetElementAt(index, value);
		}
	}

	public JavaObjectArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
		: base(ref handle, options)
	{
	}

	private static JniObjectReference NewArray(int length)
	{
		JniTypeSignature jniTypeSignature = JniEnvironment.Runtime.TypeManager.GetTypeSignature(typeof(T));
		if (jniTypeSignature.SimpleReference == null)
		{
			jniTypeSignature = new JniTypeSignature("java/lang/Object", jniTypeSignature.ArrayRank);
		}
		if (jniTypeSignature.IsKeyword && jniTypeSignature.ArrayRank == 0)
		{
			jniTypeSignature = jniTypeSignature.GetPrimitivePeerTypeSignature();
		}
		using JniType jniType = new JniType(jniTypeSignature.Name);
		return JniEnvironment.Arrays.NewObjectArray(length, jniType.PeerReference, default(JniObjectReference));
	}

	public unsafe JavaObjectArray(int length)
		: this(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		JniObjectReference reference = NewArray(JavaArray<T>.CheckLength(length));
		Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	public JavaObjectArray(IList<T> value)
		: this(JavaArray<T>.CheckLength(value))
	{
		for (int i = 0; i < value.Count; i++)
		{
			SetElementAt(i, value[i]);
		}
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

	[return: MaybeNull]
	private T GetElementAt(int index)
	{
		JniObjectReference reference = JniEnvironment.Arrays.GetObjectArrayElement(base.PeerReference, index);
		return JniEnvironment.Runtime.ValueManager.GetValue<T>(ref reference, JniObjectReferenceOptions.CopyAndDispose);
	}

	private void SetElementAt(int index, T value)
	{
		JniValueMarshaler<T> valueMarshaler = JniEnvironment.Runtime.ValueManager.GetValueMarshaler<T>();
		JniValueMarshalerState state = valueMarshaler.CreateGenericObjectReferenceArgumentState(value);
		JniEnvironment.Arrays.SetObjectArrayElement(base.PeerReference, index, state.ReferenceValue);
		valueMarshaler.DestroyGenericArgumentState(value, ref state);
	}

	public override IEnumerator<T> GetEnumerator()
	{
		int len = base.Length;
		int i = 0;
		while (i < len)
		{
			yield return GetElementAt(i);
			int num = i + 1;
			i = num;
		}
	}

	public override void Clear()
	{
		int length = base.Length;
		JniValueMarshaler<T> valueMarshaler = JniEnvironment.Runtime.ValueManager.GetValueMarshaler<T>();
		JniValueMarshalerState state = valueMarshaler.CreateArgumentState(default(T));
		for (int i = 0; i < length; i++)
		{
			JniEnvironment.Arrays.SetObjectArrayElement(base.PeerReference, i, state.ReferenceValue);
		}
		valueMarshaler.DestroyGenericArgumentState(default(T), ref state);
	}

	public override int IndexOf(T item)
	{
		int length = base.Length;
		for (int i = 0; i < length; i++)
		{
			T elementAt = GetElementAt(i);
			try
			{
				if (EqualityComparer<T>.Default.Equals(item, elementAt) || JniMarshal.RecursiveEquals(item, elementAt))
				{
					return i;
				}
			}
			finally
			{
				if (elementAt is IJavaPeerable javaPeerable)
				{
					javaPeerable.DisposeUnlessReferenced();
				}
			}
		}
		return -1;
	}

	public override void CopyTo(T[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		JavaArray<T>.CheckArrayCopy(0, base.Length, arrayIndex, array.Length, base.Length);
		CopyToList(array, arrayIndex);
	}

	internal override void CopyToList(IList<T> list, int index)
	{
		int length = base.Length;
		for (int i = 0; i < length; i++)
		{
			T val = (list[index + i] = GetElementAt(i));
			if (forMarshalCollection && val is IJavaPeerable javaPeerable)
			{
				javaPeerable.DisposeUnlessReferenced();
			}
		}
	}

	internal override bool TargetTypeIsCurrentType(Type? targetType)
	{
		if (!base.TargetTypeIsCurrentType(targetType))
		{
			return targetType == typeof(JavaObjectArray<T>);
		}
		return true;
	}
}

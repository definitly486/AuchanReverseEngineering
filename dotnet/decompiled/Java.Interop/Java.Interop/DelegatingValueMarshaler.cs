using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class DelegatingValueMarshaler<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : JniValueMarshaler<T>
{
	private JniValueMarshaler ValueMarshaler;

	public DelegatingValueMarshaler(JniValueMarshaler valueMarshaler)
	{
		ValueMarshaler = valueMarshaler;
	}

	[return: MaybeNull]
	public override T CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		return (T)ValueMarshaler.CreateValue(ref reference, options, targetType ?? typeof(T));
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] T value, ParameterAttributes synchronize)
	{
		return ValueMarshaler.CreateObjectReferenceArgumentState(value, synchronize);
	}

	public override void DestroyGenericArgumentState([AllowNull] T value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		ValueMarshaler.DestroyArgumentState(value, ref state, synchronize);
	}
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

public abstract class JniValueMarshaler
{
	public abstract object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null);

	public virtual JniValueMarshalerState CreateArgumentState(object? value, ParameterAttributes synchronize = ParameterAttributes.None)
	{
		return CreateObjectReferenceArgumentState(value, synchronize);
	}

	public abstract JniValueMarshalerState CreateObjectReferenceArgumentState(object? value, ParameterAttributes synchronize = ParameterAttributes.None);

	public abstract void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize = ParameterAttributes.None);
}
public abstract class JniValueMarshaler<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : JniValueMarshaler
{
	[return: MaybeNull]
	public abstract T CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null);

	public virtual JniValueMarshalerState CreateGenericArgumentState([MaybeNull] T value, ParameterAttributes synchronize = ParameterAttributes.None)
	{
		return CreateGenericObjectReferenceArgumentState(value, synchronize);
	}

	public abstract JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] T value, ParameterAttributes synchronize = ParameterAttributes.None);

	public abstract void DestroyGenericArgumentState([AllowNull] T value, ref JniValueMarshalerState state, ParameterAttributes synchronize = ParameterAttributes.None);

	public override object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType = null)
	{
		return CreateGenericValue(ref reference, options, targetType ?? typeof(T));
	}

	public override JniValueMarshalerState CreateArgumentState(object? value, ParameterAttributes synchronize = ParameterAttributes.None)
	{
		return CreateGenericArgumentState((T)value, synchronize);
	}

	public override JniValueMarshalerState CreateObjectReferenceArgumentState(object? value, ParameterAttributes synchronize = ParameterAttributes.None)
	{
		return CreateGenericObjectReferenceArgumentState((T)value, synchronize);
	}

	public override void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize = ParameterAttributes.None)
	{
		DestroyGenericArgumentState((T)value, ref state, synchronize);
	}
}

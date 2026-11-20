using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniBooleanValueMarshaler : JniValueMarshaler<bool>
{
	internal static readonly JniBooleanValueMarshaler Instance = new JniBooleanValueMarshaler();

	public override object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return CreateGenericValue(ref reference, options, targetType);
	}

	public override bool CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return false;
		}
		return JniBoolean.GetValueFromJni(ref reference, options, targetType);
	}

	public override JniValueMarshalerState CreateGenericArgumentState([MaybeNull] bool value, ParameterAttributes synchronize = ParameterAttributes.In)
	{
		return new JniValueMarshalerState(new JniArgumentValue(value));
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] bool value, ParameterAttributes synchronize)
	{
		return new JniValueMarshalerState(JniBoolean.CreateLocalRef(value));
	}

	public override void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}

	public override void DestroyGenericArgumentState(bool value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

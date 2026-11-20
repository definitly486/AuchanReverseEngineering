using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniCharValueMarshaler : JniValueMarshaler<char>
{
	internal static readonly JniCharValueMarshaler Instance = new JniCharValueMarshaler();

	public override object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return CreateGenericValue(ref reference, options, targetType);
	}

	public override char CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return '\0';
		}
		return JniCharacter.GetValueFromJni(ref reference, options, targetType);
	}

	public override JniValueMarshalerState CreateGenericArgumentState([MaybeNull] char value, ParameterAttributes synchronize = ParameterAttributes.In)
	{
		return new JniValueMarshalerState(new JniArgumentValue(value));
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] char value, ParameterAttributes synchronize)
	{
		return new JniValueMarshalerState(JniCharacter.CreateLocalRef(value));
	}

	public override void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}

	public override void DestroyGenericArgumentState(char value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniSingleValueMarshaler : JniValueMarshaler<float>
{
	internal static readonly JniSingleValueMarshaler Instance = new JniSingleValueMarshaler();

	public override object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return CreateGenericValue(ref reference, options, targetType);
	}

	public override float CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return 0f;
		}
		return JniFloat.GetValueFromJni(ref reference, options, targetType);
	}

	public override JniValueMarshalerState CreateGenericArgumentState([MaybeNull] float value, ParameterAttributes synchronize = ParameterAttributes.In)
	{
		return new JniValueMarshalerState(new JniArgumentValue(value));
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] float value, ParameterAttributes synchronize)
	{
		return new JniValueMarshalerState(JniFloat.CreateLocalRef(value));
	}

	public override void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}

	public override void DestroyGenericArgumentState(float value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniNullableSingleValueMarshaler : JniValueMarshaler<float?>
{
	internal static readonly JniNullableSingleValueMarshaler Instance = new JniNullableSingleValueMarshaler();

	public override float? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return JniFloat.GetValueFromJni(ref reference, options, null);
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] float? value, ParameterAttributes synchronize)
	{
		if (!value.HasValue)
		{
			return default(JniValueMarshalerState);
		}
		return new JniValueMarshalerState(JniFloat.CreateLocalRef(value.Value));
	}

	public override void DestroyGenericArgumentState(float? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

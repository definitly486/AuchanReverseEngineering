using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniNullableInt32ValueMarshaler : JniValueMarshaler<int?>
{
	internal static readonly JniNullableInt32ValueMarshaler Instance = new JniNullableInt32ValueMarshaler();

	public override int? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return JniInteger.GetValueFromJni(ref reference, options, null);
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] int? value, ParameterAttributes synchronize)
	{
		if (!value.HasValue)
		{
			return default(JniValueMarshalerState);
		}
		return new JniValueMarshalerState(JniInteger.CreateLocalRef(value.Value));
	}

	public override void DestroyGenericArgumentState(int? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

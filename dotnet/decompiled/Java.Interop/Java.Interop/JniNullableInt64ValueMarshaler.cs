using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniNullableInt64ValueMarshaler : JniValueMarshaler<long?>
{
	internal static readonly JniNullableInt64ValueMarshaler Instance = new JniNullableInt64ValueMarshaler();

	public override long? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return JniLong.GetValueFromJni(ref reference, options, null);
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] long? value, ParameterAttributes synchronize)
	{
		if (!value.HasValue)
		{
			return default(JniValueMarshalerState);
		}
		return new JniValueMarshalerState(JniLong.CreateLocalRef(value.Value));
	}

	public override void DestroyGenericArgumentState(long? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniNullableInt16ValueMarshaler : JniValueMarshaler<short?>
{
	internal static readonly JniNullableInt16ValueMarshaler Instance = new JniNullableInt16ValueMarshaler();

	public override short? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return JniShort.GetValueFromJni(ref reference, options, null);
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] short? value, ParameterAttributes synchronize)
	{
		if (!value.HasValue)
		{
			return default(JniValueMarshalerState);
		}
		return new JniValueMarshalerState(JniShort.CreateLocalRef(value.Value));
	}

	public override void DestroyGenericArgumentState(short? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

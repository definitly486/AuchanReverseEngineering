using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniNullableSByteValueMarshaler : JniValueMarshaler<sbyte?>
{
	internal static readonly JniNullableSByteValueMarshaler Instance = new JniNullableSByteValueMarshaler();

	public override sbyte? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return JniByte.GetValueFromJni(ref reference, options, null);
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] sbyte? value, ParameterAttributes synchronize)
	{
		if (!value.HasValue)
		{
			return default(JniValueMarshalerState);
		}
		return new JniValueMarshalerState(JniByte.CreateLocalRef(value.Value));
	}

	public override void DestroyGenericArgumentState(sbyte? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

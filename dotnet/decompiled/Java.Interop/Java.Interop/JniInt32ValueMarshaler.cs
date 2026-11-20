using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniInt32ValueMarshaler : JniValueMarshaler<int>
{
	internal static readonly JniInt32ValueMarshaler Instance = new JniInt32ValueMarshaler();

	public override object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return CreateGenericValue(ref reference, options, targetType);
	}

	public override int CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return 0;
		}
		return JniInteger.GetValueFromJni(ref reference, options, targetType);
	}

	public override JniValueMarshalerState CreateGenericArgumentState([MaybeNull] int value, ParameterAttributes synchronize = ParameterAttributes.In)
	{
		return new JniValueMarshalerState(new JniArgumentValue(value));
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] int value, ParameterAttributes synchronize)
	{
		return new JniValueMarshalerState(JniInteger.CreateLocalRef(value));
	}

	public override void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}

	public override void DestroyGenericArgumentState(int value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

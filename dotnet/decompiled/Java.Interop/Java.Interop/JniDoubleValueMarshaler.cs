using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniDoubleValueMarshaler : JniValueMarshaler<double>
{
	internal static readonly JniDoubleValueMarshaler Instance = new JniDoubleValueMarshaler();

	public override object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return null;
		}
		return CreateGenericValue(ref reference, options, targetType);
	}

	public override double CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		if (!reference.IsValid)
		{
			return 0.0;
		}
		return JniDouble.GetValueFromJni(ref reference, options, targetType);
	}

	public override JniValueMarshalerState CreateGenericArgumentState([MaybeNull] double value, ParameterAttributes synchronize = ParameterAttributes.In)
	{
		return new JniValueMarshalerState(new JniArgumentValue(value));
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] double value, ParameterAttributes synchronize)
	{
		return new JniValueMarshalerState(JniDouble.CreateLocalRef(value));
	}

	public override void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}

	public override void DestroyGenericArgumentState(double value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

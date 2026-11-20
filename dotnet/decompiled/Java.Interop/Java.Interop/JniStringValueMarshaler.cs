using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class JniStringValueMarshaler : JniValueMarshaler<string?>
{
	internal static readonly JniStringValueMarshaler Instance = new JniStringValueMarshaler();

	public override string? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		return JniEnvironment.Strings.ToString(ref reference, options, targetType ?? typeof(string));
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] string? value, ParameterAttributes synchronize)
	{
		return new JniValueMarshalerState(JniEnvironment.Strings.NewString(value));
	}

	public override void DestroyGenericArgumentState(string? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		JniObjectReference reference = state.ReferenceValue;
		JniObjectReference.Dispose(ref reference);
		state = default(JniValueMarshalerState);
	}
}

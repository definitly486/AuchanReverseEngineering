using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Java.Interop;

internal sealed class VoidValueMarshaler : JniValueMarshaler
{
	internal static VoidValueMarshaler Instance = new VoidValueMarshaler();

	public override object? CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		throw new NotSupportedException();
	}

	public override JniValueMarshalerState CreateObjectReferenceArgumentState(object? value, ParameterAttributes synchronize)
	{
		throw new NotSupportedException();
	}

	public override void DestroyArgumentState(object? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		throw new NotSupportedException();
	}
}

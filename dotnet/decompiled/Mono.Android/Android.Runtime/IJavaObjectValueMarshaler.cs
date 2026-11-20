using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Java.Interop;

namespace Android.Runtime;

internal sealed class IJavaObjectValueMarshaler : JniValueMarshaler<IJavaObject>
{
	public override IJavaObject CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type? targetType)
	{
		throw new NotImplementedException();
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] IJavaObject value, ParameterAttributes synchronize)
	{
		throw new NotImplementedException();
	}

	public override void DestroyGenericArgumentState([AllowNull] IJavaObject value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		throw new NotImplementedException();
	}
}

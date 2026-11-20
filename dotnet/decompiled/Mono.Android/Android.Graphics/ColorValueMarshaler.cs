using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Java.Interop;

namespace Android.Graphics;

public class ColorValueMarshaler : JniValueMarshaler<Color>
{
	public override Color CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type targetType)
	{
		throw new NotImplementedException();
	}

	public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState([MaybeNull] Color value, ParameterAttributes synchronize)
	{
		throw new NotImplementedException();
	}

	public override void DestroyGenericArgumentState(Color value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
	{
		throw new NotImplementedException();
	}
}

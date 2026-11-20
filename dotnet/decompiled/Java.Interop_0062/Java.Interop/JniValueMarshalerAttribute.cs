using System;
using System.Diagnostics.CodeAnalysis;

namespace Java.Interop;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
public class JniValueMarshalerAttribute : Attribute
{
	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
	public Type MarshalerType { get; }

	public JniValueMarshalerAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type marshalerType)
	{
		if (marshalerType == null)
		{
			throw new ArgumentNullException("marshalerType");
		}
		if (!typeof(JniValueMarshaler).IsAssignableFrom(marshalerType))
		{
			throw new ArgumentException($"`{marshalerType.FullName}` must inherit from JniValueMarshaler!", "marshalerType");
		}
		MarshalerType = marshalerType;
	}
}

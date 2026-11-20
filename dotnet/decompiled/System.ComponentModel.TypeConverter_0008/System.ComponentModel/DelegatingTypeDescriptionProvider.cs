using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

internal sealed class DelegatingTypeDescriptionProvider : TypeDescriptionProvider
{
	private readonly Type _type;

	internal TypeDescriptionProvider Provider => TypeDescriptor.GetProviderRecursive(_type);

	internal DelegatingTypeDescriptionProvider(Type type)
	{
		_type = type;
	}

	public override object CreateInstance(IServiceProvider provider, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type objectType, Type[] argTypes, object[] args)
	{
		return Provider.CreateInstance(provider, objectType, argTypes, args);
	}

	public override IDictionary GetCache(object instance)
	{
		return Provider.GetCache(instance);
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
	public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance)
	{
		return Provider.GetExtendedTypeDescriptor(instance);
	}

	protected internal override IExtenderProvider[] GetExtenderProviders(object instance)
	{
		return Provider.GetExtenderProviders(instance);
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public override Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type objectType, object instance)
	{
		return Provider.GetReflectionType(objectType, instance);
	}

	public override ICustomTypeDescriptor GetTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllConstructors | DynamicallyAccessedMemberTypes.AllNestedTypes | DynamicallyAccessedMemberTypes.AllMethods | DynamicallyAccessedMemberTypes.AllFields | DynamicallyAccessedMemberTypes.AllProperties | DynamicallyAccessedMemberTypes.AllEvents | DynamicallyAccessedMemberTypes.Interfaces)] Type objectType, object instance)
	{
		return Provider.GetTypeDescriptor(objectType, instance);
	}
}

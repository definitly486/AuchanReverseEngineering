using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

public abstract class TypeDescriptionProvider
{
	private sealed class EmptyCustomTypeDescriptor : CustomTypeDescriptor
	{
	}

	private readonly TypeDescriptionProvider _parent;

	private EmptyCustomTypeDescriptor _emptyDescriptor;

	protected TypeDescriptionProvider()
	{
	}

	protected TypeDescriptionProvider(TypeDescriptionProvider parent)
	{
		_parent = parent;
	}

	public virtual object? CreateInstance(IServiceProvider? provider, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type objectType, Type[]? argTypes, object?[]? args)
	{
		if (_parent != null)
		{
			return _parent.CreateInstance(provider, objectType, argTypes, args);
		}
		ArgumentNullException.ThrowIfNull(objectType, "objectType");
		return Activator.CreateInstance(objectType, args);
	}

	public virtual IDictionary? GetCache(object instance)
	{
		return _parent?.GetCache(instance);
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
	public virtual ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance)
	{
		if (_parent != null)
		{
			return _parent.GetExtendedTypeDescriptor(instance);
		}
		return _emptyDescriptor ?? (_emptyDescriptor = new EmptyCustomTypeDescriptor());
	}

	protected internal virtual IExtenderProvider[] GetExtenderProviders(object instance)
	{
		if (_parent != null)
		{
			return _parent.GetExtenderProviders(instance);
		}
		ArgumentNullException.ThrowIfNull(instance, "instance");
		return Array.Empty<IExtenderProvider>();
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type objectType)
	{
		return GetReflectionType(objectType, null);
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public virtual Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type objectType, object? instance)
	{
		if (_parent != null)
		{
			return _parent.GetReflectionType(objectType, instance);
		}
		return objectType;
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
	public ICustomTypeDescriptor? GetTypeDescriptor(object instance)
	{
		ArgumentNullException.ThrowIfNull(instance, "instance");
		return GetTypeDescriptor(instance.GetType(), instance);
	}

	public virtual ICustomTypeDescriptor? GetTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllConstructors | DynamicallyAccessedMemberTypes.AllNestedTypes | DynamicallyAccessedMemberTypes.AllMethods | DynamicallyAccessedMemberTypes.AllFields | DynamicallyAccessedMemberTypes.AllProperties | DynamicallyAccessedMemberTypes.AllEvents | DynamicallyAccessedMemberTypes.Interfaces)] Type objectType, object? instance)
	{
		if (_parent != null)
		{
			return _parent.GetTypeDescriptor(objectType, instance);
		}
		return _emptyDescriptor ?? (_emptyDescriptor = new EmptyCustomTypeDescriptor());
	}
}

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

public abstract class PropertyDescriptor : MemberDescriptor
{
	private TypeConverter _converter;

	private ConcurrentDictionary<object, EventHandler> _valueChangedHandlers;

	private object[] _editors;

	private Type[] _editorTypes;

	private int _editorCount;

	public abstract Type ComponentType { get; }

	public virtual TypeConverter Converter
	{
		[RequiresUnreferencedCode("PropertyDescriptor's PropertyType cannot be statically discovered.")]
		get
		{
			AttributeCollection attributes = Attributes;
			if (_converter == null)
			{
				TypeConverterAttribute typeConverterAttribute = (TypeConverterAttribute)attributes[typeof(TypeConverterAttribute)];
				if (typeConverterAttribute.ConverterTypeName != null && typeConverterAttribute.ConverterTypeName.Length > 0)
				{
					Type typeFromName = GetTypeFromName(typeConverterAttribute.ConverterTypeName);
					if (typeFromName != null && typeof(TypeConverter).IsAssignableFrom(typeFromName))
					{
						_converter = (TypeConverter)CreateInstance(typeFromName);
					}
				}
				if (_converter == null)
				{
					_converter = TypeDescriptor.GetConverter(PropertyType);
				}
			}
			return _converter;
		}
	}

	public abstract bool IsReadOnly { get; }

	public abstract Type PropertyType { get; }

	protected PropertyDescriptor(string name, Attribute[]? attrs)
		: base(name, attrs)
	{
	}

	protected PropertyDescriptor(MemberDescriptor descr, Attribute[]? attrs)
		: base(descr, attrs)
	{
	}

	public abstract bool CanResetValue(object component);

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		try
		{
			if (obj == this)
			{
				return true;
			}
			if (obj == null)
			{
				return false;
			}
			if (obj is PropertyDescriptor propertyDescriptor && propertyDescriptor.NameHashCode == NameHashCode && propertyDescriptor.PropertyType == PropertyType && propertyDescriptor.Name.Equals(Name))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	protected object? CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type)
	{
		Type[] array = new Type[1] { typeof(Type) };
		if (type.GetConstructor(array) != null)
		{
			return TypeDescriptor.CreateInstance(null, type, array, new object[1] { PropertyType });
		}
		return TypeDescriptor.CreateInstance(null, type, null, null);
	}

	protected override void FillAttributes(IList attributeList)
	{
		_converter = null;
		_editors = null;
		_editorTypes = null;
		_editorCount = 0;
		base.FillAttributes(attributeList);
	}

	public override int GetHashCode()
	{
		return NameHashCode ^ PropertyType.GetHashCode();
	}

	protected override object? GetInvocationTarget(Type type, object instance)
	{
		object obj = base.GetInvocationTarget(type, instance);
		if (obj is ICustomTypeDescriptor customTypeDescriptor)
		{
			obj = customTypeDescriptor.GetPropertyOwner(this);
		}
		return obj;
	}

	[RequiresUnreferencedCode("Calls ComponentType.Assembly.GetType on the non-fully qualified typeName, which the trimmer cannot recognize.")]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	protected Type? GetTypeFromName([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] string? typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return null;
		}
		Type type = Type.GetType(typeName);
		Type type2 = null;
		if (ComponentType != null && (type == null || ComponentType.Assembly.FullName.Equals(type.Assembly.FullName)))
		{
			int num = typeName.IndexOf(',');
			if (num != -1)
			{
				typeName = typeName.Substring(0, num);
			}
			type2 = ComponentType.Assembly.GetType(typeName);
		}
		return type2 ?? type;
	}

	public abstract object? GetValue(object? component);

	protected virtual void OnValueChanged(object? component, EventArgs e)
	{
		if (component != null)
		{
			_valueChangedHandlers?.GetValueOrDefault(component, null)?.Invoke(component, e);
		}
	}

	public abstract void ResetValue(object component);

	public abstract void SetValue(object? component, object? value);

	public abstract bool ShouldSerializeValue(object component);
}

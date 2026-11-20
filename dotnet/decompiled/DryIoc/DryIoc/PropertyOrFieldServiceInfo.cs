using System;
using System.Reflection;
using System.Text;

namespace DryIoc;

public abstract class PropertyOrFieldServiceInfo : ServiceInfo.Typed
{
	private class Property : PropertyOrFieldServiceInfo
	{
		private sealed class WithDetails : Property
		{
			public override ServiceDetails Details { get; }

			public WithDetails(PropertyInfo property, ServiceDetails details)
				: base(property)
			{
				Details = details;
			}

			public WithDetails(PropertyInfo property, Type serviceType, ServiceDetails details)
				: base(property, serviceType)
			{
				Details = details;
			}
		}

		internal sealed class RequiredProperty : Property
		{
			public override ServiceDetails Details => ServiceDetails.Default;

			public RequiredProperty(PropertyInfo property)
				: base(property)
			{
			}
		}

		private readonly PropertyInfo _property;

		public override MemberInfo Member => _property;

		public override void SetValue(object holder, object value)
		{
			_property.SetValue(holder, value, null);
		}

		public Property(PropertyInfo property)
			: base(property.PropertyType)
		{
			_property = property;
		}

		public Property(PropertyInfo property, Type serviceType)
			: base(serviceType)
		{
			_property = property;
		}

		public override ServiceInfo Create(Type serviceType, ServiceDetails details)
		{
			if (!(serviceType == ServiceType))
			{
				return new WithDetails(_property, serviceType, details);
			}
			return new WithDetails(_property, details);
		}

		public override string ToString()
		{
			return new StringBuilder().Print(this).Append(" as property ").Print(_property.Name)
				.ToString();
		}
	}

	private class Field : PropertyOrFieldServiceInfo
	{
		private sealed class WithDetails : Field
		{
			public override ServiceDetails Details { get; }

			public WithDetails(FieldInfo field, ServiceDetails details)
				: base(field)
			{
				Details = details;
			}

			public WithDetails(FieldInfo field, Type serviceType, ServiceDetails details)
				: base(field, serviceType)
			{
				Details = details;
			}
		}

		private readonly FieldInfo _field;

		public override MemberInfo Member => _field;

		public Field(FieldInfo field)
			: base(field.FieldType)
		{
			_field = field;
		}

		public Field(FieldInfo field, Type serviceType)
			: base(serviceType)
		{
			_field = field;
		}

		public override ServiceInfo Create(Type serviceType, ServiceDetails details)
		{
			if (!(serviceType == null))
			{
				return new WithDetails(_field, serviceType, details);
			}
			return new WithDetails(_field, details);
		}

		public override void SetValue(object holder, object value)
		{
			_field.SetValue(holder, value);
		}

		public override string ToString()
		{
			return new StringBuilder().Print(this).Append(" as field ").Print(_field.Name)
				.ToString();
		}
	}

	public override ServiceDetails Details => ServiceDetails.IfUnresolvedReturnDefaultIfNotRegistered;

	public abstract MemberInfo Member { get; }

	public PropertyOrFieldServiceInfo(Type serviceType)
		: base(serviceType)
	{
	}

	public abstract void SetValue(object holder, object value);

	public static PropertyOrFieldServiceInfo Of(MemberInfo member)
	{
		if (!(member.ThrowIfNull() is PropertyInfo))
		{
			return new Field((FieldInfo)member);
		}
		return new Property((PropertyInfo)member);
	}

	public static PropertyOrFieldServiceInfo Of(PropertyInfo property)
	{
		return new Property(property);
	}

	public static PropertyOrFieldServiceInfo OfRequiredProperty(PropertyInfo property)
	{
		return new Property.RequiredProperty(property);
	}

	public static PropertyOrFieldServiceInfo Of(FieldInfo field)
	{
		return new Field(field);
	}
}

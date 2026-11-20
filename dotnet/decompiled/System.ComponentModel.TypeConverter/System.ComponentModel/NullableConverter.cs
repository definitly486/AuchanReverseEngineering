using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel;

public class NullableConverter : TypeConverter
{
	private static readonly ConstructorInfo s_nullableConstructor = typeof(Nullable<>).GetConstructor(typeof(Nullable<>).GetGenericArguments());

	public Type NullableType { get; }

	public Type UnderlyingType { get; }

	public TypeConverter UnderlyingTypeConverter { get; }

	[RequiresUnreferencedCode("The UnderlyingType cannot be statically discovered.")]
	public NullableConverter(Type type)
	{
		NullableType = type;
		UnderlyingType = Nullable.GetUnderlyingType(type);
		if (UnderlyingType == null)
		{
			throw new ArgumentException("NullableConverterBadCtorArg", "type");
		}
		UnderlyingTypeConverter = TypeDescriptor.GetConverter(UnderlyingType);
	}

	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
	{
		if (sourceType == UnderlyingType)
		{
			return true;
		}
		if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.CanConvertFrom(context, sourceType);
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
	{
		if (value == null || value.GetType() == UnderlyingType)
		{
			return value;
		}
		if (value is string && string.IsNullOrEmpty(value as string))
		{
			return null;
		}
		if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.ConvertFrom(context, culture, value);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
	{
		if (destinationType == UnderlyingType)
		{
			return true;
		}
		if (destinationType == typeof(InstanceDescriptor))
		{
			return true;
		}
		if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.CanConvertTo(context, destinationType);
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		ArgumentNullException.ThrowIfNull(destinationType, "destinationType");
		if (destinationType == UnderlyingType && value != null && NullableType.IsInstanceOfType(value))
		{
			return value;
		}
		if (destinationType == typeof(InstanceDescriptor))
		{
			return new InstanceDescriptor((ConstructorInfo)NullableType.GetMemberWithSameMetadataDefinitionAs(s_nullableConstructor), new object[1] { value }, isComplete: true);
		}
		if (value == null)
		{
			if (destinationType == typeof(string))
			{
				return string.Empty;
			}
		}
		else if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.ConvertTo(context, culture, value, destinationType);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
	{
		if (UnderlyingTypeConverter != null)
		{
			StandardValuesCollection standardValues = UnderlyingTypeConverter.GetStandardValues(context);
			if (GetStandardValuesSupported(context) && standardValues != null)
			{
				object[] array = new object[standardValues.Count + 1];
				int num = 0;
				array[num++] = null;
				foreach (object item in standardValues)
				{
					array[num++] = item;
				}
				return new StandardValuesCollection(array);
			}
		}
		return base.GetStandardValues(context);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
	{
		if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.GetStandardValuesSupported(context);
		}
		return base.GetStandardValuesSupported(context);
	}
}

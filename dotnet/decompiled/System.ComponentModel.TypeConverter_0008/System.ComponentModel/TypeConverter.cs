using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel;

public class TypeConverter
{
	[DefaultMember("Item")]
	public class StandardValuesCollection : ICollection, IEnumerable
	{
		private readonly ICollection _values;

		private Array _valueArray;

		public int Count
		{
			get
			{
				if (_valueArray != null)
				{
					return _valueArray.Length;
				}
				return _values.Count;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		public StandardValuesCollection(ICollection? values)
		{
			if (values == null)
			{
				values = Array.Empty<object>();
			}
			if (values is Array valueArray)
			{
				_valueArray = valueArray;
			}
			_values = values;
		}

		public void CopyTo(Array array, int index)
		{
			_values.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return _values.GetEnumerator();
		}
	}

	public bool CanConvertFrom(Type sourceType)
	{
		return CanConvertFrom(null, sourceType);
	}

	public virtual bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
	{
		return sourceType == typeof(InstanceDescriptor);
	}

	public bool CanConvertTo([NotNullWhen(true)] Type? destinationType)
	{
		return CanConvertTo(null, destinationType);
	}

	public virtual bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
	{
		return destinationType == typeof(string);
	}

	public virtual object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value is InstanceDescriptor instanceDescriptor)
		{
			return instanceDescriptor.Invoke();
		}
		throw GetConvertFromException(value);
	}

	public object? ConvertFromInvariantString(string text)
	{
		return ConvertFromString(null, CultureInfo.InvariantCulture, text);
	}

	public object? ConvertFromString(ITypeDescriptorContext? context, CultureInfo? culture, string text)
	{
		return ConvertFrom(context, culture, text);
	}

	public object? ConvertTo(object? value, Type destinationType)
	{
		return ConvertTo(null, null, value, destinationType);
	}

	public virtual object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		ArgumentNullException.ThrowIfNull(destinationType, "destinationType");
		if (destinationType == typeof(string))
		{
			if (value == null)
			{
				return string.Empty;
			}
			if (culture != null && culture != CultureInfo.CurrentCulture && value is IFormattable formattable)
			{
				return formattable.ToString(null, culture);
			}
			return value.ToString();
		}
		throw GetConvertToException(value, destinationType);
	}

	public string? ConvertToInvariantString(object? value)
	{
		return ConvertToString(null, CultureInfo.InvariantCulture, value);
	}

	public string? ConvertToInvariantString(ITypeDescriptorContext? context, object? value)
	{
		return ConvertToString(context, CultureInfo.InvariantCulture, value);
	}

	public string? ConvertToString(object? value)
	{
		return (string)ConvertTo(null, CultureInfo.CurrentCulture, value, typeof(string));
	}

	public string? ConvertToString(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
	{
		return (string)ConvertTo(context, culture, value, typeof(string));
	}

	protected Exception GetConvertFromException(object? value)
	{
		object obj;
		if (value != null)
		{
			obj = value.GetType().FullName;
		}
		else
		{
			if (1 == 0)
			{
			}
			obj = "(null)";
		}
		string p = (string)obj;
		throw new NotSupportedException(System.SR.Format("ConvertFromException", GetType().Name, p));
	}

	protected Exception GetConvertToException(object? value, Type destinationType)
	{
		object obj;
		if (value != null)
		{
			obj = value.GetType().FullName;
		}
		else
		{
			if (1 == 0)
			{
			}
			obj = "(null)";
		}
		string p = (string)obj;
		throw new NotSupportedException(System.SR.Format("ConvertToException", GetType().Name, p, destinationType.FullName));
	}

	public virtual StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
	{
		return null;
	}

	public virtual bool GetStandardValuesSupported(ITypeDescriptorContext? context)
	{
		return false;
	}
}

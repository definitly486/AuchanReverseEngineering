using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NanoXLSX.Exceptions;

namespace NanoXLSX.Styles;

public abstract class AbstractStyle : IComparable<AbstractStyle>
{
	public class AppendAttribute : Attribute
	{
		public bool Ignore { get; set; }

		public bool NestedProperty { get; set; }

		public AppendAttribute()
		{
			Ignore = false;
			NestedProperty = false;
		}
	}

	[Append(Ignore = true)]
	public int? InternalID { get; set; }

	public abstract AbstractStyle Copy();

	internal void CopyProperties<T>(T source, T reference) where T : AbstractStyle
	{
		if (source == null || (GetType() != source.GetType() && GetType() != reference.GetType()))
		{
			throw new StyleException("The objects of the source, target and reference for style appending are not of the same type");
		}
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			IEnumerable<AppendAttribute> enumerable = (IEnumerable<AppendAttribute>)propertyInfo.GetCustomAttributes(typeof(AppendAttribute));
			if (!enumerable.Any() || HandleProperties(enumerable))
			{
				PropertyInfo property = source.GetType().GetProperty(propertyInfo.Name);
				PropertyInfo property2 = reference.GetType().GetProperty(propertyInfo.Name);
				if (!property.GetValue(source).Equals(property2.GetValue(reference)))
				{
					propertyInfo.SetValue(this, property.GetValue(source));
				}
			}
		}
	}

	private static bool HandleProperties(IEnumerable<AppendAttribute> attributes)
	{
		foreach (AppendAttribute attribute in attributes)
		{
			if (attribute.Ignore || attribute.NestedProperty)
			{
				return false;
			}
		}
		return true;
	}

	public int CompareTo(AbstractStyle other)
	{
		if (!InternalID.HasValue)
		{
			return -1;
		}
		if (other == null || !other.InternalID.HasValue)
		{
			return 1;
		}
		return InternalID.Value.CompareTo(other.InternalID.Value);
	}

	public bool Equals(AbstractStyle other)
	{
		if (other == null)
		{
			return false;
		}
		return GetHashCode() == other.GetHashCode();
	}

	internal static void AddPropertyAsJson(StringBuilder sb, string name, object value, bool terminate = false)
	{
		sb.Append("\"").Append(name).Append("\": ");
		if (value == null)
		{
			sb.Append("__null__");
		}
		else
		{
			sb.Append("\"").Append(value.ToString().Replace("\"", "\\\"")).Append("\"");
		}
		if (!terminate)
		{
			sb.Append(",\n");
		}
	}
}

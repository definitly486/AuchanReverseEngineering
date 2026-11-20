using System.Collections;
using System.Globalization;

namespace System.ComponentModel;

public class CollectionConverter : TypeConverter
{
	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is ICollection)
		{
			if (1 == 0)
			{
			}
			return "(Collection)";
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}

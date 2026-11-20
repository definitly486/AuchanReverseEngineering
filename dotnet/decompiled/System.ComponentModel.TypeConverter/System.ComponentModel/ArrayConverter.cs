using System.Globalization;

namespace System.ComponentModel;

public class ArrayConverter : CollectionConverter
{
	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is Array)
		{
			if (1 == 0)
			{
			}
			return System.SR.Format("{0} Array", value.GetType().Name);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}

using System.ComponentModel;

namespace System.Data;

internal sealed class DataTableTypeConverter : ReferenceConverter
{
	public DataTableTypeConverter()
		: base(typeof(DataTable))
	{
	}
}

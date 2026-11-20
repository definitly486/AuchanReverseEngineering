using System.Runtime.CompilerServices;

namespace System.Data;

public class DataColumnChangeEventArgs : EventArgs
{
	private DataColumn _column;

	[CompilerGenerated]
	private readonly DataRow _003CRow_003Ek__BackingField;

	public object? ProposedValue { get; set; }

	internal DataColumnChangeEventArgs(DataRow row)
	{
		_003CRow_003Ek__BackingField = row;
	}

	public DataColumnChangeEventArgs(DataRow row, DataColumn? column, object? value)
	{
		_003CRow_003Ek__BackingField = row;
		_column = column;
		ProposedValue = value;
	}

	internal void InitializeColumnChangeEvent(DataColumn column, object value)
	{
		_column = column;
		ProposedValue = value;
	}
}

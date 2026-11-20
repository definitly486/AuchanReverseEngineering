using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public class PropertyChangingEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly string _003CPropertyName_003Ek__BackingField;

	public PropertyChangingEventArgs(string? propertyName)
	{
		_003CPropertyName_003Ek__BackingField = propertyName;
	}
}

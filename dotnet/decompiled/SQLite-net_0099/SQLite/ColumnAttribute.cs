using System;
using System.Runtime.CompilerServices;

namespace SQLite;

[AttributeUsage(AttributeTargets.Property)]
public class ColumnAttribute : Attribute
{
	[CompilerGenerated]
	private string _003CName_003Ek__BackingField;

	public string Name
	{
		[CompilerGenerated]
		set
		{
			_003CName_003Ek__BackingField = value;
		}
	}

	public ColumnAttribute(string name)
	{
		Name = name;
	}
}

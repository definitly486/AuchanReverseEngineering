using System;
using System.Runtime.CompilerServices;

namespace SQLite;

public class NotifyTableChangedEventArgs : EventArgs
{
	[CompilerGenerated]
	private TableMapping _003CTable_003Ek__BackingField;

	[CompilerGenerated]
	private NotifyTableChangedAction _003CAction_003Ek__BackingField;

	private TableMapping Table
	{
		[CompilerGenerated]
		set
		{
			_003CTable_003Ek__BackingField = value;
		}
	}

	private NotifyTableChangedAction Action
	{
		[CompilerGenerated]
		set
		{
			_003CAction_003Ek__BackingField = value;
		}
	}

	public NotifyTableChangedEventArgs(TableMapping table, NotifyTableChangedAction action)
	{
		Table = table;
		Action = action;
	}
}

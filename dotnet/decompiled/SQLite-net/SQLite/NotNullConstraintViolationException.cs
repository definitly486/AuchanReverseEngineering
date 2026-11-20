using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SQLite;

public class NotNullConstraintViolationException : SQLiteException
{
	[CompilerGenerated]
	private IEnumerable<TableMapping.Column> _003CColumns_003Ek__BackingField;

	protected IEnumerable<TableMapping.Column> Columns
	{
		[CompilerGenerated]
		set
		{
			_003CColumns_003Ek__BackingField = value;
		}
	}

	protected NotNullConstraintViolationException(SQLite3.Result r, string message)
		: this(r, message, null, null)
	{
	}

	protected NotNullConstraintViolationException(SQLite3.Result r, string message, TableMapping mapping, object obj)
		: base(r, message)
	{
		if (mapping != null && obj != null)
		{
			Columns = mapping.Columns.Where((TableMapping.Column c) => !c.IsNullable && c.GetValue(obj) == null);
		}
	}

	public new static NotNullConstraintViolationException New(SQLite3.Result r, string message)
	{
		return new NotNullConstraintViolationException(r, message);
	}

	public static NotNullConstraintViolationException New(SQLite3.Result r, string message, TableMapping mapping, object obj)
	{
		return new NotNullConstraintViolationException(r, message, mapping, obj);
	}

	public static NotNullConstraintViolationException New(SQLiteException exception, TableMapping mapping, object obj)
	{
		return new NotNullConstraintViolationException(exception.Result, exception.Message, mapping, obj);
	}
}

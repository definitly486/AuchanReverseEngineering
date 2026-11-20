using System;
using System.Runtime.CompilerServices;

namespace SQLite;

public abstract class BaseTableQuery
{
	protected class Ordering
	{
		public string ColumnName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}

		public bool Ascending
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}
	}
}

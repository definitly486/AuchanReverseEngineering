using System;
using System.Runtime.CompilerServices;

namespace SQLite;

[AttributeUsage(AttributeTargets.Class)]
public class TableAttribute : Attribute
{
	public string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public bool WithoutRowId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}

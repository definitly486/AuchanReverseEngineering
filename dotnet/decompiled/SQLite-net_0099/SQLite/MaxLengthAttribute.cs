using System;
using System.Runtime.CompilerServices;

namespace SQLite;

[AttributeUsage(AttributeTargets.Property)]
public class MaxLengthAttribute : Attribute
{
	public int Value
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}

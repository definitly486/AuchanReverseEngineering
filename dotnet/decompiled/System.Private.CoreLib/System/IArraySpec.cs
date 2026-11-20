using System.Text;

namespace System;

internal sealed class IArraySpec : IModifierSpec
{
	private readonly int dimensions;

	private readonly bool bound;

	public int Rank => dimensions;

	public bool IsBound => bound;

	internal IArraySpec(int dimensions, bool bound)
	{
		this.dimensions = dimensions;
		this.bound = bound;
	}

	public Type Resolve(Type type)
	{
		if (bound)
		{
			return type.MakeArrayType(1);
		}
		if (dimensions == 1)
		{
			return type.MakeArrayType();
		}
		return type.MakeArrayType(dimensions);
	}

	public StringBuilder Append(StringBuilder sb)
	{
		if (bound)
		{
			return sb.Append("[*]");
		}
		return sb.Append('[').Append(',', dimensions - 1).Append(']');
	}

	public override string ToString()
	{
		return Append(new StringBuilder()).ToString();
	}
}

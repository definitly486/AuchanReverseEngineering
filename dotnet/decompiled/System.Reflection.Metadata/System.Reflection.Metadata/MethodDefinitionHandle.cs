namespace System.Reflection.Metadata;

public readonly struct MethodDefinitionHandle : IEquatable<MethodDefinitionHandle>
{
	private readonly int _rowId;

	private MethodDefinitionHandle(int rowId)
	{
		_rowId = rowId;
	}

	internal static MethodDefinitionHandle FromRowId(int rowId)
	{
		return new MethodDefinitionHandle(rowId);
	}

	public static bool operator ==(MethodDefinitionHandle left, MethodDefinitionHandle right)
	{
		return left._rowId == right._rowId;
	}

	public override bool Equals(object? obj)
	{
		if (obj is MethodDefinitionHandle)
		{
			return ((MethodDefinitionHandle)obj)._rowId == _rowId;
		}
		return false;
	}

	public bool Equals(MethodDefinitionHandle other)
	{
		return _rowId == other._rowId;
	}

	public override int GetHashCode()
	{
		return _rowId.GetHashCode();
	}

	public static bool operator !=(MethodDefinitionHandle left, MethodDefinitionHandle right)
	{
		return left._rowId != right._rowId;
	}
}

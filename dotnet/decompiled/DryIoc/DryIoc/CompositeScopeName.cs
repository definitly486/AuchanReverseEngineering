namespace DryIoc;

public sealed class CompositeScopeName : IScopeName
{
	private readonly object[] _names;

	public static CompositeScopeName Of(object[] names)
	{
		return new CompositeScopeName(names);
	}

	public bool Match(object scopeName)
	{
		object[] names = _names;
		foreach (object obj in names)
		{
			if (obj == scopeName)
			{
				return true;
			}
			if (obj is IScopeName scopeName2 && scopeName2.Match(scopeName))
			{
				return true;
			}
			if (scopeName != null && scopeName.Equals(obj))
			{
				return true;
			}
		}
		return false;
	}

	private CompositeScopeName(object[] names)
	{
		_names = names;
	}
}

using System;

namespace Refit;

internal readonly struct MethodTableKey : IEquatable<MethodTableKey>
{
	private string MethodName { get; }

	private Type[] Parameters { get; }

	private Type[] GenericArguments { get; }

	public MethodTableKey(string methodName, Type[] parameters, Type[] genericArguments)
	{
		MethodName = methodName;
		Parameters = parameters;
		GenericArguments = genericArguments;
	}

	public override int GetHashCode()
	{
		int num = MethodName.GetHashCode();
		Type[] parameters = Parameters;
		foreach (Type type in parameters)
		{
			num = (num * 397) ^ type.GetHashCode();
		}
		parameters = GenericArguments;
		foreach (Type type2 in parameters)
		{
			num = (num * 397) ^ type2.GetHashCode();
		}
		return num;
	}

	public bool Equals(MethodTableKey other)
	{
		if (Parameters.Length != other.Parameters.Length || GenericArguments.Length != other.GenericArguments.Length || MethodName != other.MethodName)
		{
			return false;
		}
		for (int i = 0; i < Parameters.Length; i++)
		{
			if (Parameters[i] != other.Parameters[i])
			{
				return false;
			}
		}
		for (int j = 0; j < GenericArguments.Length; j++)
		{
			if (GenericArguments[j] != other.GenericArguments[j])
			{
				return false;
			}
		}
		return true;
	}

	public override bool Equals(object? obj)
	{
		if (obj is MethodTableKey other)
		{
			return Equals(other);
		}
		return false;
	}
}

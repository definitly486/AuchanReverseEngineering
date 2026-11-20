using System;
using System.Reflection;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public sealed class DefaultKey : IConvertibleToExpression
{
	public static readonly DefaultKey Value = new DefaultKey(0);

	public readonly int RegistrationOrder;

	private static readonly MethodInfo _ofMethod = typeof(DefaultKey).GetMethod("Of");

	public static DefaultKey Of(int registrationOrder)
	{
		if (registrationOrder != 0)
		{
			return new DefaultKey(registrationOrder);
		}
		return Value;
	}

	public Expression ToExpression(Func<object, Expression> fallbackConverter)
	{
		return Expression.Call(_ofMethod, Expression.Constant(RegistrationOrder));
	}

	public DefaultKey Next()
	{
		return Of(RegistrationOrder + 1);
	}

	public override bool Equals(object key)
	{
		if (key != null)
		{
			return (key as DefaultKey)?.RegistrationOrder == RegistrationOrder;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return RegistrationOrder;
	}

	public override string ToString()
	{
		return GetType().Name + "(" + RegistrationOrder + ")";
	}

	private DefaultKey(int registrationOrder)
	{
		RegistrationOrder = registrationOrder;
	}
}

using System;
using System.Reflection;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public sealed class DefaultDynamicKey : IConvertibleToExpression
{
	public static readonly DefaultDynamicKey Value = new DefaultDynamicKey(0);

	public readonly int RegistrationOrder;

	private static readonly MethodInfo _ofMethod = typeof(DefaultDynamicKey).GetMethod("Of");

	public static DefaultDynamicKey Of(int registrationOrder)
	{
		if (registrationOrder != 0)
		{
			return new DefaultDynamicKey(registrationOrder);
		}
		return Value;
	}

	public Expression ToExpression(Func<object, Expression> fallbackConverter)
	{
		return Expression.Call(_ofMethod, Expression.Constant(RegistrationOrder));
	}

	public DefaultDynamicKey Next()
	{
		return Of(RegistrationOrder + 1);
	}

	public override bool Equals(object key)
	{
		if (key != null)
		{
			return (key as DefaultDynamicKey)?.RegistrationOrder == RegistrationOrder;
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

	private DefaultDynamicKey(int registrationOrder)
	{
		RegistrationOrder = registrationOrder;
	}
}

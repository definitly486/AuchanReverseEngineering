using System;
using System.Reflection;
using System.Text;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public sealed class OpenGenericTypeKey : IConvertibleToExpression
{
	public readonly Type RequiredServiceType;

	public readonly object ServiceKey;

	private static readonly ConstructorInfo _ctor = typeof(OpenGenericTypeKey).GetConstructors()[0];

	public OpenGenericTypeKey(Type requiredServiceType, object serviceKey)
	{
		RequiredServiceType = requiredServiceType.ThrowIfNull();
		ServiceKey = serviceKey;
	}

	public override string ToString()
	{
		return new StringBuilder("OpenGenericTypeKey").Append('(').Print(RequiredServiceType).Append(", ")
			.Print(ServiceKey)
			.Append(')')
			.ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj is OpenGenericTypeKey openGenericTypeKey && openGenericTypeKey.RequiredServiceType == RequiredServiceType)
		{
			return object.Equals(openGenericTypeKey.ServiceKey, ServiceKey);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Hasher.Combine(RequiredServiceType, ServiceKey);
	}

	public Expression ToExpression(Func<object, Expression> fallbackConverter)
	{
		return Expression.New(_ctor, Expression.ConstantOf(RequiredServiceType), fallbackConverter(ServiceKey));
	}
}

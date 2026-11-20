using System;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public interface IConvertibleToExpression
{
	Expression ToExpression(Func<object, Expression> fallbackConverter);
}

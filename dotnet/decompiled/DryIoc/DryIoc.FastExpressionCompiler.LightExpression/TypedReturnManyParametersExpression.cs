using System;
using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedReturnManyParametersExpression<TDelegate> : ManyParametersExpression<TDelegate> where TDelegate : Delegate
{
	public override Type ReturnType { get; }

	internal TypedReturnManyParametersExpression(Expression body, IReadOnlyList<ParameterExpression> parameters, Type returnType)
		: base(body, parameters)
	{
		ReturnType = returnType;
	}
}

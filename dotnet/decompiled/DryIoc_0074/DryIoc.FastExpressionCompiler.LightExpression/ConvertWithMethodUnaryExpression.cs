using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class ConvertWithMethodUnaryExpression : TypedUnaryExpression
{
	public override MethodInfo Method { get; }

	public ConvertWithMethodUnaryExpression(ExpressionType nodeType, Expression operand, Type type, MethodInfo method)
		: base(nodeType, operand, type)
	{
		Method = method;
	}
}

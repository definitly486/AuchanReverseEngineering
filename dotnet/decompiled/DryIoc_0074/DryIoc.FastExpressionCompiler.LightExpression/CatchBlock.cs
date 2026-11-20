using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class CatchBlock
{
	public readonly Type Test;

	public readonly ParameterExpression Variable;

	public readonly Expression Body;

	public readonly Expression Filter;

	internal CatchBlock(Type test, ParameterExpression variable, Expression body, Expression filter)
	{
		Test = test;
		Variable = variable;
		Body = body;
		Filter = filter;
	}
}

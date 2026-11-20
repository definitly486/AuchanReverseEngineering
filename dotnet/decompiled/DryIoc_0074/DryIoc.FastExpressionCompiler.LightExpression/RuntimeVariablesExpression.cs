using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class RuntimeVariablesExpression : Expression
{
	public readonly IReadOnlyList<ParameterExpression> Variables;

	public sealed override ExpressionType NodeType => ExpressionType.RuntimeVariables;

	public sealed override Type Type => typeof(IRuntimeVariables);

	internal RuntimeVariablesExpression(IReadOnlyList<ParameterExpression> variables)
	{
		Variables = variables;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> convertedExpressions)
	{
		return System.Linq.Expressions.Expression.RuntimeVariables(ParameterExpression.ToParameterExpressions(Variables, ref convertedExpressions));
	}
}

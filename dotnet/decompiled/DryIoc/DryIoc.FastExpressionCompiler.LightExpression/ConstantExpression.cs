using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class ConstantExpression : Expression
{
	public sealed override ExpressionType NodeType => ExpressionType.Constant;

	public abstract object Value { get; }

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> _)
	{
		return System.Linq.Expressions.Expression.Constant(Value, Type);
	}

	public override string ToString()
	{
		return $"Constant({Value}, typeof({Type.ToCode()}))";
	}
}

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class NotNullExpressionInvocationExpression : InvocationExpression
{
	public sealed override Expression Expression { get; }

	internal NotNullExpressionInvocationExpression(Expression expression)
	{
		Expression = expression;
	}
}

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class WithFinallyTryExpression : TryExpression
{
	public override Expression Finally { get; }

	internal WithFinallyTryExpression(Expression body, CatchBlock[] handlers, Expression @finally)
		: base(body, handlers)
	{
		Finally = @finally;
	}
}

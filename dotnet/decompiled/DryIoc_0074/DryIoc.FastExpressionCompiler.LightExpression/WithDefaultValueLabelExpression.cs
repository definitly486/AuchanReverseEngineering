namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class WithDefaultValueLabelExpression : LabelExpression
{
	public override Expression DefaultValue { get; }

	internal WithDefaultValueLabelExpression(LabelTarget target, Expression defaultValue)
		: base(target)
	{
		DefaultValue = defaultValue;
	}
}

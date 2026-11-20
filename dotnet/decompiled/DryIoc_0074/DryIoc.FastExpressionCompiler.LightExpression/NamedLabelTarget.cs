namespace DryIoc.FastExpressionCompiler.LightExpression;

public class NamedLabelTarget : LabelTarget
{
	public override string Name { get; }

	public NamedLabelTarget(string name)
	{
		Name = name;
	}
}

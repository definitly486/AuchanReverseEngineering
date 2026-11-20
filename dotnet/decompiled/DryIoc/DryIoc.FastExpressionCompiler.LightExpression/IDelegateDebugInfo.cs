namespace DryIoc.FastExpressionCompiler.LightExpression;

public interface IDelegateDebugInfo
{
	LambdaExpression Expression { get; }

	string ExpressionString { get; }

	string CSharpString { get; }
}

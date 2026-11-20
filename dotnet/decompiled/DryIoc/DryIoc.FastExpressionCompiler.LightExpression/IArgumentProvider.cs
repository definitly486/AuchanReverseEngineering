namespace DryIoc.FastExpressionCompiler.LightExpression;

public interface IArgumentProvider
{
	int ArgumentCount { get; }

	Expression GetArgument(int index);
}
public interface IArgumentProvider<T>
{
	int ArgumentCount { get; }

	T GetArgument(int index);
}

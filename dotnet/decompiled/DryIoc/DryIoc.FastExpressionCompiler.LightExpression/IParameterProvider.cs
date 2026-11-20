namespace DryIoc.FastExpressionCompiler.LightExpression;

public interface IParameterProvider
{
	int ParameterCount { get; }

	ParameterExpression GetParameter(int index);
}

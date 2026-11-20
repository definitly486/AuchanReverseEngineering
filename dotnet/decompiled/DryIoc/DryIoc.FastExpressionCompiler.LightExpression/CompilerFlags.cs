using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

[Flags]
public enum CompilerFlags
{
	Default = 0,
	NoInvocationLambdaInlining = 1,
	EnableDelegateDebugInfo = 2,
	ThrowOnNotSupportedExpression = 4
}

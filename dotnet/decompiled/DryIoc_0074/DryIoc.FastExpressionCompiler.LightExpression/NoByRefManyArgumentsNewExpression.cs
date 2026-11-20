using System.Collections.Generic;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NoByRefManyArgumentsNewExpression : ManyArgumentsNewExpression
{
	public override bool NoByRefArgs => true;

	internal NoByRefManyArgumentsNewExpression(ConstructorInfo constructor, IReadOnlyList<Expression> arguments)
		: base(constructor, arguments)
	{
	}
}

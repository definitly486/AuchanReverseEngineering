using System.Collections.Generic;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public struct SwitchCase
{
	public readonly IReadOnlyList<Expression> TestValues;

	public readonly Expression Body;

	public SwitchCase(Expression body, IEnumerable<Expression> testValues)
	{
		Body = body;
		TestValues = testValues.AsReadOnlyList();
	}

	public override bool Equals(object obj)
	{
		if (obj is SwitchCase switchCase && switchCase.Body == Body)
		{
			return switchCase.TestValues == TestValues;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCombiner.Combine(Body, TestValues).GetHashCode();
	}
}

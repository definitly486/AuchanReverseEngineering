using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class SwitchExpression : Expression
{
	public readonly Expression SwitchValue;

	private readonly SwitchCase[] _cases;

	public readonly Expression DefaultBody;

	public sealed override ExpressionType NodeType => ExpressionType.Switch;

	public sealed override Type Type { get; }

	public IReadOnlyList<SwitchCase> Cases => _cases;

	public virtual MethodInfo Comparison => null;

	public SwitchExpression(Type type, Expression switchValue, Expression defaultBody, SwitchCase[] cases)
	{
		Type = type;
		SwitchValue = switchValue;
		DefaultBody = defaultBody;
		_cases = cases;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.Switch(SwitchValue.ToExpression(ref exprsConverted), DefaultBody.ToExpression(ref exprsConverted), Comparison, ToSwitchCaseExpressions(_cases, ref exprsConverted));
	}

	internal static System.Linq.Expressions.SwitchCase ToSwitchCase(ref SwitchCase sw, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.SwitchCase(sw.Body.ToExpression(ref exprsConverted), Expression.ToExpressions(sw.TestValues, ref exprsConverted));
	}

	internal static System.Linq.Expressions.SwitchCase[] ToSwitchCaseExpressions(SwitchCase[] switchCases, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (switchCases.Length == 0)
		{
			return Tools.Empty<System.Linq.Expressions.SwitchCase>();
		}
		System.Linq.Expressions.SwitchCase[] array = new System.Linq.Expressions.SwitchCase[switchCases.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ToSwitchCase(ref switchCases[i], ref exprsConverted);
		}
		return array;
	}
}

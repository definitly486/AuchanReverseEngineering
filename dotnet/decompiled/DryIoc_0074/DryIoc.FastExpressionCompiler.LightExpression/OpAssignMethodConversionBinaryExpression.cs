using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class OpAssignMethodConversionBinaryExpression : OpAssignBinaryExpression
{
	public override MethodInfo Method { get; }

	public override LambdaExpression Conversion { get; }

	public bool LiftToNull { get; }

	internal OpAssignMethodConversionBinaryExpression(ExpressionType nodeType, Expression left, Expression right, MethodInfo method, LambdaExpression conversion, bool liftToNull)
		: base(nodeType, left, right)
	{
		Method = method;
		Conversion = conversion;
		LiftToNull = liftToNull;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MakeBinary(NodeType, Left.ToExpression(ref exprsConverted), Right.ToExpression(ref exprsConverted), LiftToNull, Method, Conversion.ToLambdaExpression());
	}
}

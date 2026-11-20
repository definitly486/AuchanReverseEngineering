using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class MethodBinaryExpression : BinaryExpression
{
	public override ExpressionType NodeType { get; }

	public override Type Type { get; }

	public override MethodInfo Method { get; }

	public MethodBinaryExpression(ExpressionType nodeType, Expression left, Expression right, Type type, MethodInfo method)
		: base(left, right)
	{
		NodeType = nodeType;
		Type = type;
		Method = method;
	}
}

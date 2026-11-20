using System.Linq.Expressions;
using System.Reflection;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class BinaryExpression : Expression
{
	public readonly Expression Left;

	public readonly Expression Right;

	public virtual MethodInfo Method => null;

	public virtual LambdaExpression Conversion => null;

	public bool IsLifted
	{
		get
		{
			if (NodeType != ExpressionType.Coalesce && NodeType != ExpressionType.Assign && Left.Type.IsNullable())
			{
				if (!(Method == null))
				{
					return !Method.GetParameters()[0].ParameterType.GetNonRef().IsEquivalentTo(Left.Type);
				}
				return true;
			}
			return false;
		}
	}

	public bool IsLiftedToNull
	{
		get
		{
			if (IsLifted)
			{
				return Type.IsNullable();
			}
			return false;
		}
	}

	protected BinaryExpression(Expression left, Expression right)
	{
		Left = left;
		Right = right;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MakeBinary(NodeType, Left.ToExpression(ref exprsConverted), Right.ToExpression(ref exprsConverted));
	}
}

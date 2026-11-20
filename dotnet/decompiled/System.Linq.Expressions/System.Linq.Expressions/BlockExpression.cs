using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic.Utils;
using System.Threading;

namespace System.Linq.Expressions;

[DebuggerTypeProxy(typeof(BlockExpressionProxy))]
public class BlockExpression : Expression
{
	public ReadOnlyCollection<Expression> Expressions => GetOrMakeExpressions();

	public ReadOnlyCollection<ParameterExpression> Variables => GetOrMakeVariables();

	public Expression Result => GetExpression(ExpressionCount - 1);

	public sealed override ExpressionType NodeType => ExpressionType.Block;

	public override Type Type => GetExpression(ExpressionCount - 1).Type;

	[ExcludeFromCodeCoverage(Justification = "Unreachable")]
	internal virtual int ExpressionCount
	{
		get
		{
			throw ContractUtils.Unreachable;
		}
	}

	internal BlockExpression()
	{
	}

	protected internal override Expression Accept(ExpressionVisitor visitor)
	{
		return visitor.VisitBlock(this);
	}

	[ExcludeFromCodeCoverage(Justification = "Unreachable")]
	internal virtual Expression GetExpression(int index)
	{
		throw ContractUtils.Unreachable;
	}

	[ExcludeFromCodeCoverage(Justification = "Unreachable")]
	internal virtual ReadOnlyCollection<Expression> GetOrMakeExpressions()
	{
		throw ContractUtils.Unreachable;
	}

	internal virtual ReadOnlyCollection<ParameterExpression> GetOrMakeVariables()
	{
		return ReadOnlyCollection<ParameterExpression>.Empty;
	}

	[ExcludeFromCodeCoverage(Justification = "Unreachable")]
	internal virtual BlockExpression Rewrite(ReadOnlyCollection<ParameterExpression> variables, Expression[] args)
	{
		throw ContractUtils.Unreachable;
	}

	internal static ReadOnlyCollection<Expression> ReturnReadOnlyExpressions(BlockExpression provider, ref object collection)
	{
		if (collection is Expression expression)
		{
			Interlocked.CompareExchange(ref collection, new ReadOnlyCollection<Expression>(new BlockExpressionList(provider, expression)), expression);
		}
		return (ReadOnlyCollection<Expression>)collection;
	}
}

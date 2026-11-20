using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public class TryExpression : Expression
{
	public readonly Expression Body;

	private readonly CatchBlock[] _handlers;

	public override ExpressionType NodeType => ExpressionType.Try;

	public override Type Type => Body.Type;

	public IReadOnlyList<CatchBlock> Handlers => _handlers;

	public virtual Expression Finally => null;

	internal TryExpression(Expression body, CatchBlock[] handlers)
	{
		Body = body;
		_handlers = handlers;
	}

	internal override System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (Finally != null)
		{
			if (Handlers != null)
			{
				return System.Linq.Expressions.Expression.TryCatchFinally(Body.ToExpression(ref exprsConverted), Finally.ToExpression(ref exprsConverted), ToCatchBlocks(_handlers, ref exprsConverted));
			}
			return System.Linq.Expressions.Expression.TryFinally(Body.ToExpression(ref exprsConverted), Finally.ToExpression(ref exprsConverted));
		}
		return System.Linq.Expressions.Expression.TryCatch(Body.ToExpression(ref exprsConverted), ToCatchBlocks(_handlers, ref exprsConverted));
	}

	private static System.Linq.Expressions.CatchBlock ToCatchBlock(ref CatchBlock cb, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		return System.Linq.Expressions.Expression.MakeCatchBlock(cb.Test, (System.Linq.Expressions.ParameterExpression)(cb.Variable?.ToExpression(ref exprsConverted)), cb.Body.ToExpression(ref exprsConverted), cb.Filter?.ToExpression(ref exprsConverted));
	}

	private static System.Linq.Expressions.CatchBlock[] ToCatchBlocks(CatchBlock[] hs, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (hs == null)
		{
			return Tools.Empty<System.Linq.Expressions.CatchBlock>();
		}
		System.Linq.Expressions.CatchBlock[] array = new System.Linq.Expressions.CatchBlock[hs.Length];
		for (int i = 0; i < hs.Length; i++)
		{
			array[i] = ToCatchBlock(ref hs[i], ref exprsConverted);
		}
		return array;
	}
}

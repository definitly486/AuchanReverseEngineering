using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

internal sealed class InvokeFactoryDelegateOfRootOrSelfExpression : InvokeFactoryDelegateExpression
{
	public override IReadOnlyList<Expression> Arguments => new Expression[1] { ResolverContext.RootOrSelfExpr };

	public override Expression GetArgument(int index)
	{
		return ResolverContext.RootOrSelfExpr;
	}

	public InvokeFactoryDelegateOfRootOrSelfExpression(Type type, FactoryDelegate f)
		: base(type, f)
	{
	}

	public sealed override bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		if (ExpressionCompiler.EmittingVisitor.TryEmitConstantOfNotNullValue(considerClosure: true, null, FactoryDelegate, il, ref closure) && ResolverContext.RootOrSelfExpr.TryEmit(config, ref closure, paramExprs, il, parent, byRefIndex) && ExpressionCompiler.EmittingVisitor.EmitMethodCall(il, FactoryDelegateCompiler.InvokeMethod))
		{
			return InvokeFactoryDelegateExpression.EmitConvertObjectTo(il, Type);
		}
		return false;
	}
}

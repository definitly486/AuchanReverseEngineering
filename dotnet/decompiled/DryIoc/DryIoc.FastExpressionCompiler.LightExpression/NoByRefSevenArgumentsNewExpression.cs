using System.Reflection;
using System.Reflection.Emit;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NoByRefSevenArgumentsNewExpression : SevenArgumentsNewExpression
{
	public override bool NoByRefArgs => true;

	public override bool IsIntrinsic => true;

	internal NoByRefSevenArgumentsNewExpression(ConstructorInfo constructor, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5, Expression a6)
		: base(constructor, a0, a1, a2, a3, a4, a5, a6)
	{
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		if (ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument0, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument1, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument2, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument3, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument4, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument5, paramExprs, isNestedLambda, ref rootClosure, config))
		{
			return ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument6, paramExprs, isNestedLambda, ref rootClosure, config);
		}
		return false;
	}

	public override bool TryEmit(CompilerFlags setup, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		bool result = ExpressionCompiler.EmittingVisitor.TryEmit(Argument0, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument1, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument2, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument3, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument4, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument5, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument6, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall);
		il.Emit(OpCodes.Newobj, Constructor);
		return result;
	}
}

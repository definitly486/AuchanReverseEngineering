using System.Reflection;
using System.Reflection.Emit;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NoByRefFourArgumentsNewExpression : FourArgumentsNewExpression
{
	public override bool NoByRefArgs => true;

	public override bool IsIntrinsic => true;

	internal NoByRefFourArgumentsNewExpression(ConstructorInfo constructor, Expression a0, Expression a1, Expression a2, Expression a3)
		: base(constructor, a0, a1, a2, a3)
	{
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		if (ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument0, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument1, paramExprs, isNestedLambda, ref rootClosure, config) && ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument2, paramExprs, isNestedLambda, ref rootClosure, config))
		{
			return ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument3, paramExprs, isNestedLambda, ref rootClosure, config);
		}
		return false;
	}

	public override bool TryEmit(CompilerFlags setup, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		bool result = ExpressionCompiler.EmittingVisitor.TryEmit(Argument0, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument1, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument2, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument3, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall);
		il.Emit(OpCodes.Newobj, Constructor);
		return result;
	}
}

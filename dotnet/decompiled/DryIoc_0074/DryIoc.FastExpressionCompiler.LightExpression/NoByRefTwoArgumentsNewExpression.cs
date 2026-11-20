using System.Reflection;
using System.Reflection.Emit;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NoByRefTwoArgumentsNewExpression : TwoArgumentsNewExpression
{
	public override bool NoByRefArgs => true;

	public override bool IsIntrinsic => true;

	internal NoByRefTwoArgumentsNewExpression(ConstructorInfo constructor, Expression a0, Expression a1)
		: base(constructor, a0, a1)
	{
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		if (ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument0, paramExprs, isNestedLambda, ref rootClosure, config))
		{
			return ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument1, paramExprs, isNestedLambda, ref rootClosure, config);
		}
		return false;
	}

	public override bool TryEmit(CompilerFlags setup, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		bool result = ExpressionCompiler.EmittingVisitor.TryEmit(Argument0, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall) && ExpressionCompiler.EmittingVisitor.TryEmit(Argument1, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall);
		il.Emit(OpCodes.Newobj, Constructor);
		return result;
	}
}

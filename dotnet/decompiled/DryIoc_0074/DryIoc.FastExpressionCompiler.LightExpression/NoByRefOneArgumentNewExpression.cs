using System.Reflection;
using System.Reflection.Emit;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NoByRefOneArgumentNewExpression : OneArgumentNewExpression
{
	public override bool NoByRefArgs => true;

	public override bool IsIntrinsic => true;

	internal NoByRefOneArgumentNewExpression(ConstructorInfo constructor, Expression argument)
		: base(constructor, argument)
	{
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		return ExpressionCompiler.TryCollectBoundConstants(ref closure, Argument, paramExprs, isNestedLambda, ref rootClosure, config);
	}

	public override bool TryEmit(CompilerFlags setup, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		bool result = ExpressionCompiler.EmittingVisitor.TryEmit(Argument, paramExprs, il, ref closure, setup, parent | ExpressionCompiler.ParentFlags.CtorCall);
		il.Emit(OpCodes.Newobj, Constructor);
		return result;
	}
}

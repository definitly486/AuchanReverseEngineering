using System.Reflection;
using System.Reflection.Emit;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NoArgsNewClassIntrinsicExpression : NewExpression
{
	public override bool IsIntrinsic => true;

	internal NoArgsNewClassIntrinsicExpression(ConstructorInfo constructor)
		: base(constructor)
	{
	}

	public override bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		return true;
	}

	public override bool TryEmit(CompilerFlags setup, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		il.Emit(OpCodes.Newobj, Constructor);
		return true;
	}
}

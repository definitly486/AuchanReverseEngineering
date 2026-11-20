using System;
using System.Linq.Expressions;
using System.Reflection;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public static class FactoryDelegateCompiler
{
	public static readonly DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression ResolverContextParamExpr = DryIoc.FastExpressionCompiler.LightExpression.Expression.ParameterOf<IResolverContext>("r");

	public static readonly DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression[] ResolverContextParamExprs = new DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression[1] { ResolverContextParamExpr };

	public static MethodInfo InvokeMethod = typeof(FactoryDelegate).GetMethod("Invoke");

	internal static readonly OneParameterLambdaExpression FactoryDelegateParamExprs = new OneParameterLambdaExpression(null, null, ResolverContextParamExpr);

	public static DryIoc.FastExpressionCompiler.LightExpression.Expression NormalizeExpression(this DryIoc.FastExpressionCompiler.LightExpression.Expression expr)
	{
		if (expr.NodeType == ExpressionType.Convert)
		{
			DryIoc.FastExpressionCompiler.LightExpression.Expression operand = ((DryIoc.FastExpressionCompiler.LightExpression.UnaryExpression)expr).Operand;
			if (operand.Type == typeof(object))
			{
				return operand;
			}
		}
		if (expr.Type != typeof(void) && expr.Type.IsValueType)
		{
			return DryIoc.FastExpressionCompiler.LightExpression.Expression.Convert<object>(expr);
		}
		return expr;
	}

	public static DryIoc.FastExpressionCompiler.LightExpression.Expression<FactoryDelegate> WrapInFactoryExpression(this DryIoc.FastExpressionCompiler.LightExpression.Expression expression)
	{
		return new FactoryDelegateExpression(expression.NormalizeExpression());
	}

	public static DryIoc.FastExpressionCompiler.LightExpression.Expression<FactoryDelegate> WrapInFactoryExpressionWithoutNormalization(this DryIoc.FastExpressionCompiler.LightExpression.Expression expression)
	{
		return new FactoryDelegateExpression(expression);
	}

	public static FactoryDelegate CompileToFactoryDelegate(this DryIoc.FastExpressionCompiler.LightExpression.Expression expression, bool preferInterpretation)
	{
		expression = expression.NormalizeExpression();
		if (expression is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression)
		{
			return constantExpression.Value.ToFactoryDelegate;
		}
		if (!preferInterpretation)
		{
			FactoryDelegate factoryDelegate = (FactoryDelegate)ExpressionCompiler.TryCompileBoundToFirstClosureParam(typeof(FactoryDelegate), expression, FactoryDelegateParamExprs, new Type[2]
			{
				typeof(ExpressionCompiler.ArrayClosure),
				typeof(IResolverContext)
			}, typeof(object), CompilerFlags.NoInvocationLambdaInlining);
			if (factoryDelegate != null)
			{
				return factoryDelegate;
			}
		}
		System.Linq.Expressions.Expression<FactoryDelegate> expression2 = new FactoryDelegateExpression(expression).ToLambdaExpression();
		if (preferInterpretation)
		{
			return expression2.Compile(preferInterpretation: true);
		}
		return expression2.Compile();
	}

	public static object CompileToFactoryDelegate(this DryIoc.FastExpressionCompiler.LightExpression.Expression expression, Type factoryDelegateType, Type resultType, bool preferInterpretation)
	{
		if (!preferInterpretation)
		{
			object obj = ExpressionCompiler.TryCompileBoundToFirstClosureParam(factoryDelegateType, expression, FactoryDelegateParamExprs, new Type[2]
			{
				typeof(ExpressionCompiler.ArrayClosure),
				typeof(IResolverContext)
			}, resultType, CompilerFlags.NoInvocationLambdaInlining);
			if (obj != null)
			{
				return obj;
			}
		}
		return DryIoc.FastExpressionCompiler.LightExpression.Expression.Lambda(factoryDelegateType, expression, ResolverContextParamExpr, resultType).ToLambdaExpression().Compile(preferInterpretation);
	}
}

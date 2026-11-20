using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public static class Interpreter
{
	public sealed class ParentLambdaArgs
	{
		public readonly ParentLambdaArgs ParentWithArgs;

		public readonly IParameterProvider ParamExprs;

		public readonly object ParamValues;

		public ParentLambdaArgs(ParentLambdaArgs parentWithArgs, IParameterProvider paramExprs, object paramValues)
		{
			ParentWithArgs = parentWithArgs;
			ParamExprs = paramExprs;
			ParamValues = paramValues;
		}
	}

	private static readonly MethodInfo _convertFuncMethod = typeof(Interpreter).GetMethod("ConvertFunc", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertOneArgFuncMethod = typeof(Interpreter).GetMethod("ConvertOneArgFunc", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertOneArgActionMethod = typeof(Interpreter).GetMethod("ConvertOneArgAction", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertTwoArgFuncMethod = typeof(Interpreter).GetMethod("ConvertTwoArgFunc", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertTwoArgActionMethod = typeof(Interpreter).GetMethod("ConvertTwoArgAction", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertThreeArgFuncMethod = typeof(Interpreter).GetMethod("ConvertThreeArgFunc", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertThreeArgActionMethod = typeof(Interpreter).GetMethod("ConvertThreeArgAction", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertFourArgFuncMethod = typeof(Interpreter).GetMethod("ConvertFourArgFunc", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _convertFourArgActionMethod = typeof(Interpreter).GetMethod("ConvertFourArgAction", BindingFlags.Static | BindingFlags.NonPublic);

	public static bool TryInterpretAndUnwrapContainerException(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.Expression expr, out object result)
	{
		try
		{
			return TryInterpret(r, expr, FactoryDelegateCompiler.FactoryDelegateParamExprs, r, null, out result);
		}
		catch (TargetInvocationException ex) when (ex.InnerException != null)
		{
			TrySetScopedItemException(r, ex.InnerException);
			throw ex.InnerException.TryRethrowWithPreservedStackTrace();
		}
	}

	private static void TrySetScopedItemException(IResolverContext r, Exception ex)
	{
		ScopedItemException ex2 = null;
		for (Scope scope = r.CurrentScope as Scope; scope != null; scope = scope.Parent as Scope)
		{
			ImMap<object>[] array = scope.CloneMaps();
			ImMap<object>[] array2 = array;
			foreach (ImMap<object> imMap in array2)
			{
				if (imMap.IsEmpty)
				{
					continue;
				}
				foreach (ImMapEntry<object> item in imMap.Enumerate())
				{
					if (item.Value == Scope.NoItem)
					{
						if (ex2 == null)
						{
							ex2 = new ScopedItemException(ex);
						}
						if (Interlocked.CompareExchange(ref item.Value, ex2, Scope.NoItem) == Scope.NoItem)
						{
							return;
						}
					}
				}
			}
		}
	}

	internal static bool TryInterpretSingletonAndUnwrapContainerException(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.Expression expr, ImMapEntry<object> itemRef, out object result)
	{
		try
		{
			return TryInterpret(r, expr, FactoryDelegateCompiler.FactoryDelegateParamExprs, r, null, out result);
		}
		catch (TargetInvocationException ex) when (ex.InnerException != null)
		{
			itemRef.Value = new ScopedItemException(ex.InnerException);
			throw ex.InnerException.TryRethrowWithPreservedStackTrace();
		}
	}

	public static bool TryInterpret(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.Expression expr, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs, out object result)
	{
		result = null;
		switch (expr.NodeType)
		{
		case ExpressionType.Constant:
			result = ((DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression)expr).Value;
			return true;
		case ExpressionType.New:
		{
			DryIoc.FastExpressionCompiler.LightExpression.NewExpression newExpression = (DryIoc.FastExpressionCompiler.LightExpression.NewExpression)expr;
			int argumentCount2 = newExpression.ArgumentCount;
			if (argumentCount2 == 0)
			{
				result = newExpression.Constructor.Invoke(ArrayTools.Empty<object>());
				return true;
			}
			object[] array4 = new object[argumentCount2];
			for (int l = 0; l < array4.Length; l++)
			{
				DryIoc.FastExpressionCompiler.LightExpression.Expression argument2 = newExpression.GetArgument(l);
				if (argument2 is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression3)
				{
					if (constantExpression3.Value is ScopedItemException ex2)
					{
						ex2.ReThrow();
					}
					array4[l] = constantExpression3.Value;
				}
				else if (!TryInterpret(r, argument2, paramExprs, paramValues, parentArgs, out array4[l]))
				{
					return false;
				}
			}
			result = newExpression.Constructor.Invoke(array4);
			return true;
		}
		case ExpressionType.Call:
		{
			bool flag = TryInterpretMethodCall(r, (DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression)expr, paramExprs, paramValues, parentArgs, ref result);
			if (flag && result is ScopedItemException ex)
			{
				ex.ReThrow();
			}
			return flag;
		}
		case ExpressionType.Convert:
		{
			object result4 = null;
			DryIoc.FastExpressionCompiler.LightExpression.UnaryExpression unaryExpression = (DryIoc.FastExpressionCompiler.LightExpression.UnaryExpression)expr;
			DryIoc.FastExpressionCompiler.LightExpression.Expression operand = unaryExpression.Operand;
			if (operand is DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression callExpr)
			{
				if (!TryInterpretMethodCall(r, callExpr, paramExprs, paramValues, parentArgs, ref result4))
				{
					return false;
				}
				if (result4 is ScopedItemException ex3)
				{
					ex3.ReThrow();
				}
			}
			else if (!TryInterpret(r, operand, paramExprs, paramValues, parentArgs, out result4))
			{
				return false;
			}
			if (result4 == null || (unaryExpression.Method == null && unaryExpression.Type.IsAssignableFrom(result4.GetType())))
			{
				result = result4;
			}
			else
			{
				result = Converter.ConvertWithOperator(result4, expr, unaryExpression.Type, unaryExpression.Method);
			}
			return true;
		}
		case ExpressionType.MemberAccess:
		{
			DryIoc.FastExpressionCompiler.LightExpression.MemberExpression memberExpression = (DryIoc.FastExpressionCompiler.LightExpression.MemberExpression)expr;
			DryIoc.FastExpressionCompiler.LightExpression.Expression expression2 = memberExpression.Expression;
			object result7 = null;
			if (expression2 != null && !TryInterpret(r, expression2, paramExprs, paramValues, parentArgs, out result7))
			{
				return false;
			}
			if (memberExpression.Member is FieldInfo fieldInfo2)
			{
				result = fieldInfo2.GetValue(result7);
				return true;
			}
			if (memberExpression.Member is PropertyInfo propertyInfo)
			{
				result = propertyInfo.GetValue(result7, null);
				return true;
			}
			return false;
		}
		case ExpressionType.MemberInit:
		{
			DryIoc.FastExpressionCompiler.LightExpression.MemberInitExpression memberInitExpression = (DryIoc.FastExpressionCompiler.LightExpression.MemberInitExpression)expr;
			if (!TryInterpret(r, memberInitExpression.NewExpression, paramExprs, paramValues, parentArgs, out var result5))
			{
				return false;
			}
			int argumentCount3 = memberInitExpression.ArgumentCount;
			for (int m = 0; m < argumentCount3; m++)
			{
				DryIoc.FastExpressionCompiler.LightExpression.MemberAssignment memberAssignment = (DryIoc.FastExpressionCompiler.LightExpression.MemberAssignment)memberInitExpression.GetArgument(m);
				if (!TryInterpret(r, memberAssignment.Expression, paramExprs, paramValues, parentArgs, out var result6))
				{
					return false;
				}
				FieldInfo fieldInfo = memberAssignment.Member as FieldInfo;
				if (fieldInfo != null)
				{
					fieldInfo.SetValue(result5, result6);
				}
				else
				{
					((PropertyInfo)memberAssignment.Member).SetValue(result5, result6, null);
				}
			}
			result = result5;
			return true;
		}
		case ExpressionType.NewArrayInit:
		{
			DryIoc.FastExpressionCompiler.LightExpression.NewArrayExpression newArrayExpression = (DryIoc.FastExpressionCompiler.LightExpression.NewArrayExpression)expr;
			object[] array5 = new object[newArrayExpression.ArgumentCount];
			for (int n = 0; n < array5.Length; n++)
			{
				DryIoc.FastExpressionCompiler.LightExpression.Expression argument3 = newArrayExpression.GetArgument(n);
				if (argument3 is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression4)
				{
					array5[n] = constantExpression4.Value;
				}
				else if (!TryInterpret(r, argument3, paramExprs, paramValues, parentArgs, out array5[n]))
				{
					return false;
				}
			}
			result = Converter.ConvertMany(array5, newArrayExpression.Type.GetElementType());
			return true;
		}
		case ExpressionType.Invoke:
		{
			DryIoc.FastExpressionCompiler.LightExpression.InvocationExpression invocationExpression = (DryIoc.FastExpressionCompiler.LightExpression.InvocationExpression)expr;
			if (invocationExpression is InvokeFactoryDelegateExpression invokeFactoryDelegateExpression)
			{
				result = invokeFactoryDelegateExpression.FactoryDelegate((invokeFactoryDelegateExpression is InvokeFactoryDelegateOfRootOrSelfExpression) ? (r.Root ?? r) : r);
				return true;
			}
			DryIoc.FastExpressionCompiler.LightExpression.Expression expression = invocationExpression.Expression;
			if (expression is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression { Value: FactoryDelegate value })
			{
				if (!TryInterpret(r, invocationExpression.GetArgument(0), paramExprs, paramValues, parentArgs, out var result2))
				{
					return false;
				}
				result = value((IResolverContext)result2);
				return true;
			}
			if (expression.Type == typeof(Func<object>) && expression is DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression lambdaExpression)
			{
				return TryInterpret(r, lambdaExpression.Body, paramExprs, paramValues, parentArgs, out result);
			}
			if (!TryInterpret(r, expression, paramExprs, paramValues, parentArgs, out var result3))
			{
				return false;
			}
			Delegate obj = (Delegate)result3;
			int argumentCount = invocationExpression.ArgumentCount;
			if (argumentCount == 0)
			{
				result = obj.GetMethodInfo().Invoke(obj.Target, ArrayTools.Empty<object>());
			}
			else
			{
				object[] array3 = new object[argumentCount];
				for (int k = 0; k < array3.Length; k++)
				{
					DryIoc.FastExpressionCompiler.LightExpression.Expression argument = invocationExpression.GetArgument(k);
					if (argument is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression2)
					{
						array3[k] = constantExpression2.Value;
					}
					else if (!TryInterpret(r, argument, paramExprs, paramValues, parentArgs, out array3[k]))
					{
						return false;
					}
				}
				result = obj.GetMethodInfo().Invoke(obj.Target, array3);
			}
			return true;
		}
		case ExpressionType.Parameter:
		{
			if (paramExprs != null)
			{
				if (paramExprs.ParameterCount == 1 && expr == paramExprs.GetParameter(0))
				{
					result = paramValues;
					return true;
				}
				if (paramValues is object[] array)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (expr == paramExprs.GetParameter(i))
						{
							result = array[i];
							return true;
						}
					}
				}
			}
			for (ParentLambdaArgs parentLambdaArgs = parentArgs; parentLambdaArgs != null; parentLambdaArgs = parentLambdaArgs.ParentWithArgs)
			{
				if ((paramExprs = parentLambdaArgs.ParamExprs) != null)
				{
					if (paramExprs.ParameterCount == 1 && expr == paramExprs.GetParameter(0))
					{
						result = parentLambdaArgs.ParamValues;
						return true;
					}
					if (parentLambdaArgs.ParamValues is object[] array2)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							if (expr == paramExprs.GetParameter(j))
							{
								result = array2[j];
								return true;
							}
						}
					}
				}
			}
			return false;
		}
		case ExpressionType.Lambda:
			return TryInterpretNestedLambda(r, (DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)expr, paramExprs, paramValues, parentArgs, ref result);
		default:
			return false;
		}
	}

	private static bool TryInterpretNestedLambda(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression lambdaExpr, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs, ref object result)
	{
		Type returnType = lambdaExpr.ReturnType;
		if (paramExprs != null)
		{
			parentArgs = new ParentLambdaArgs(parentArgs, paramExprs, paramValues);
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression bodyExpr = lambdaExpr.Body;
		int parameterCount = lambdaExpr.ParameterCount;
		if (parameterCount == 0)
		{
			if (returnType != typeof(void))
			{
				result = (Func<object>)(() => TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, null, null, parentArgs));
				if (returnType != typeof(object))
				{
					result = _convertFuncMethod.MakeGenericMethod(returnType).Invoke(null, new object[1] { result });
				}
			}
			else
			{
				result = (Action)delegate
				{
					TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, null, null, parentArgs);
				};
			}
		}
		else if (parameterCount == 1)
		{
			DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression parameter = lambdaExpr.GetParameter(0);
			if (returnType != typeof(void))
			{
				result = (Func<object, object>)((object arg) => TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, lambdaExpr, arg, parentArgs));
				if (parameter.Type != typeof(object) || returnType != typeof(object))
				{
					result = _convertOneArgFuncMethod.MakeGenericMethod(parameter.Type, returnType).Invoke(null, new object[1] { result });
				}
			}
			else
			{
				result = (Action<object>)delegate(object arg)
				{
					TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, lambdaExpr, arg, parentArgs);
				};
				if (parameter.Type != typeof(object))
				{
					result = _convertOneArgActionMethod.MakeGenericMethod(parameter.Type).Invoke(null, new object[1] { result });
				}
			}
		}
		else if (parameterCount == 2)
		{
			DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression parameter2 = lambdaExpr.GetParameter(0);
			DryIoc.FastExpressionCompiler.LightExpression.ParameterExpression parameter3 = lambdaExpr.GetParameter(1);
			if (returnType != typeof(void))
			{
				result = (Func<object, object, object>)((object a0, object a1) => TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, lambdaExpr, new object[2] { a0, a1 }, parentArgs));
				if (parameter2.Type != typeof(object) || parameter3.Type != typeof(object) || returnType != typeof(object))
				{
					result = _convertTwoArgFuncMethod.MakeGenericMethod(parameter2.Type, parameter3.Type, returnType).Invoke(null, new object[1] { result });
				}
			}
			else
			{
				result = (Action<object, object>)delegate(object a0, object a1)
				{
					TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, lambdaExpr, new object[2] { a0, a1 }, parentArgs);
				};
				if (parameter2.Type != typeof(object) || parameter3.Type != typeof(object))
				{
					result = _convertTwoArgActionMethod.MakeGenericMethod(parameter2.Type, parameter3.Type).Invoke(null, new object[1] { result });
				}
			}
		}
		else
		{
			if (parameterCount > 4)
			{
				return false;
			}
			if (returnType != typeof(void))
			{
				result = (Func<object[], object>)((object[] args) => TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, lambdaExpr, args, parentArgs));
				MethodInfo methodInfo = ((parameterCount == 3) ? _convertThreeArgFuncMethod : _convertFourArgFuncMethod);
				result = methodInfo.MakeGenericMethod(GetParamsAndReturnType(lambdaExpr, returnType)).Invoke(null, new object[1] { result });
			}
			else
			{
				result = (Action<object[]>)delegate(object[] args)
				{
					TryInterpretNestedLambdaBodyAndUnwrapException(r, bodyExpr, lambdaExpr, args, parentArgs);
				};
				MethodInfo methodInfo2 = ((parameterCount == 3) ? _convertThreeArgActionMethod : _convertFourArgActionMethod);
				result = methodInfo2.MakeGenericMethod(GetParamTypes(lambdaExpr)).Invoke(null, new object[1] { result });
			}
		}
		Type type = result.GetType();
		Type type2 = lambdaExpr.Type;
		if ((type.GetGenericDefinitionOrNull() ?? type) != (type2.GetGenericDefinitionOrNull() ?? type2))
		{
			result = ((Delegate)result).GetMethodInfo().CreateDelegate(type2, ((Delegate)result).Target);
		}
		return true;
	}

	private static Type[] GetParamTypes(IParameterProvider ps)
	{
		int parameterCount = ps.ParameterCount;
		Type[] array = new Type[parameterCount];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ps.GetParameter(i).Type;
		}
		return array;
	}

	private static Type[] GetParamsAndReturnType(IParameterProvider ps, Type returnType)
	{
		int parameterCount = ps.ParameterCount;
		Type[] array = new Type[parameterCount + 1];
		for (int i = 0; i < parameterCount; i++)
		{
			array[i] = ps.GetParameter(i).Type;
		}
		array[parameterCount] = returnType;
		return array;
	}

	private static object TryInterpretNestedLambdaBodyAndUnwrapException(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.Expression bodyExpr, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs)
	{
		try
		{
			if (!TryInterpret(r, bodyExpr, paramExprs, paramValues, parentArgs, out var result))
			{
				Throw.It(Error.UnableToInterpretTheNestedLambda, bodyExpr);
			}
			return result;
		}
		catch (TargetInvocationException ex) when (ex.InnerException != null)
		{
			throw ex.InnerException.TryRethrowWithPreservedStackTrace();
		}
	}

	internal static Func<R> ConvertFunc<R>(Func<object> f)
	{
		return () => (R)f();
	}

	internal static Func<T, R> ConvertOneArgFunc<T, R>(Func<object, object> f)
	{
		return (T a) => (R)f(a);
	}

	internal static Action<T> ConvertOneArgAction<T>(Action<object> f)
	{
		return delegate(T a)
		{
			f(a);
		};
	}

	internal static Func<T0, T1, R> ConvertTwoArgFunc<T0, T1, R>(Func<object, object, object> f)
	{
		return (T0 a0, T1 a1) => (R)f(a0, a1);
	}

	internal static Action<T0, T1> ConvertTwoArgAction<T0, T1>(Action<object, object> f)
	{
		return delegate(T0 a0, T1 a1)
		{
			f(a0, a1);
		};
	}

	internal static Func<T0, T1, T2, R> ConvertThreeArgFunc<T0, T1, T2, R>(Func<object[], object> f)
	{
		return (T0 a0, T1 a1, T2 a2) => (R)f(new object[3] { a0, a1, a2 });
	}

	internal static Action<T0, T1, T2> ConvertThreeArgAction<T0, T1, T2>(Action<object[]> f)
	{
		return delegate(T0 a0, T1 a1, T2 a2)
		{
			f(new object[3] { a0, a1, a2 });
		};
	}

	internal static Func<T0, T1, T2, T3, R> ConvertFourArgFunc<T0, T1, T2, T3, R>(Func<object[], object> f)
	{
		return (T0 a0, T1 a1, T2 a2, T3 a3) => (R)f(new object[4] { a0, a1, a2, a3 });
	}

	internal static Action<T0, T1, T2, T3> ConvertFourArgAction<T0, T1, T2, T3>(Action<object[]> f)
	{
		return delegate(T0 a0, T1 a1, T2 a2, T3 a3)
		{
			f(new object[4] { a0, a1, a2, a3 });
		};
	}

	private static bool TryInterpretMethodCall(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression callExpr, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs, ref object result)
	{
		if (callExpr is CurrentScopeReuse.GetScopedOrSingletonViaFactoryDelegateWithDisposalOrderExpression e)
		{
			result = InterpretGetScopedOrSingletonViaFactoryDelegateWithDisposalOrder(r, e, paramExprs, paramValues, parentArgs);
			return true;
		}
		if (callExpr is CurrentScopeReuse.GetScopedOrSingletonViaFactoryDelegateExpression e2)
		{
			result = InterpretGetScopedOrSingletonViaFactoryDelegate(r, e2, paramExprs, paramValues, parentArgs);
			return true;
		}
		if (callExpr is IFuncInvokeExpression)
		{
			return TryInterpretFuncInvoke(r, callExpr, paramExprs, paramValues, parentArgs, ref result);
		}
		MethodInfo method = callExpr.Method;
		Type declaringType = method.DeclaringType;
		if (declaringType == typeof(CurrentScopeReuse))
		{
			if (method == CurrentScopeReuse.GetNameScopedViaFactoryDelegateMethod)
			{
				result = InterpretGetNameScopedViaFactoryDelegate(r, callExpr, paramExprs, paramValues, parentArgs);
				return true;
			}
			IResolverContext r2 = r;
			DryIoc.FastExpressionCompiler.LightExpression.Expression argument = callExpr.GetArgument(0);
			if (argument != FactoryDelegateCompiler.ResolverContextParamExpr)
			{
				if (!TryInterpret(r2, argument, paramExprs, paramValues, parentArgs, out var result2))
				{
					return false;
				}
				r2 = (IResolverContext)result2;
			}
			if (method == CurrentScopeReuse.TrackScopedOrSingletonMethod)
			{
				TwoArgumentsMethodCallExpression twoArgumentsMethodCallExpression = (TwoArgumentsMethodCallExpression)callExpr;
				if (!TryInterpret(r2, twoArgumentsMethodCallExpression.Argument1, paramExprs, paramValues, parentArgs, out var result3))
				{
					return false;
				}
				result = CurrentScopeReuse.TrackScopedOrSingleton(r2, result3);
				return true;
			}
			if (method == CurrentScopeReuse.TrackScopedMethod)
			{
				ThreeArgumentsMethodCallExpression threeArgumentsMethodCallExpression = (ThreeArgumentsMethodCallExpression)callExpr;
				IScope currentScope = r2.GetCurrentScope((bool)ConstValue(threeArgumentsMethodCallExpression.Argument1));
				if (currentScope == null)
				{
					result = null;
				}
				else
				{
					if (!TryInterpret(r2, threeArgumentsMethodCallExpression.Argument2, paramExprs, paramValues, parentArgs, out var result4))
					{
						return false;
					}
					result = ((result4 is IDisposable disposable) ? currentScope.TrackDisposable(disposable) : result4);
				}
				return true;
			}
			if (method == CurrentScopeReuse.TrackNameScopedMethod)
			{
				FourArgumentsMethodCallExpression fourArgumentsMethodCallExpression = (FourArgumentsMethodCallExpression)callExpr;
				IScope namedScope = r2.GetNamedScope(ConstValue(fourArgumentsMethodCallExpression.Argument1), (bool)ConstValue(fourArgumentsMethodCallExpression.Argument2));
				if (namedScope == null)
				{
					result = null;
				}
				else
				{
					if (!TryInterpret(r2, fourArgumentsMethodCallExpression.Argument3, paramExprs, paramValues, parentArgs, out var result5))
					{
						return false;
					}
					result = ((result5 is IDisposable disposable2) ? namedScope.TrackDisposable(disposable2) : result5);
				}
				return true;
			}
		}
		else if (declaringType == typeof(IScope))
		{
			if (method == Scope.GetOrAddViaFactoryDelegateMethod)
			{
				InstanceThreeArgumentsMethodCallExpression instanceThreeArgumentsMethodCallExpression = (InstanceThreeArgumentsMethodCallExpression)callExpr;
				int id = DryIoc.FastExpressionCompiler.LightExpression.Expression.TryGetIntConstantValue(instanceThreeArgumentsMethodCallExpression.Argument0);
				if (!r.SingletonScope.TryGet(out result, id))
				{
					result = r.SingletonScope.TryGetOrAddWithoutClosure(id, r, ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)instanceThreeArgumentsMethodCallExpression.Argument1).Body, (IResolverContext rc, DryIoc.FastExpressionCompiler.LightExpression.Expression expression2) => TryInterpret(rc, expression2, paramExprs, paramValues, parentArgs, out var result15) ? result15 : expression2.CompileToFactoryDelegate(((IContainer)rc).Rules.UseInterpretation)(rc));
				}
				return true;
			}
			if (method == Scope.GetOrAddViaFactoryDelegateWithDisposalOrderMethod)
			{
				InstanceFourArgumentsMethodCallExpression instanceFourArgumentsMethodCallExpression = (InstanceFourArgumentsMethodCallExpression)callExpr;
				r = r.Root ?? r;
				int id2 = DryIoc.FastExpressionCompiler.LightExpression.Expression.TryGetIntConstantValue(instanceFourArgumentsMethodCallExpression.Argument0);
				if (!r.SingletonScope.TryGet(out result, id2))
				{
					result = r.SingletonScope.TryGetOrAddWithoutClosure(id2, r, ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)instanceFourArgumentsMethodCallExpression.Argument1).Body, (IResolverContext rc, DryIoc.FastExpressionCompiler.LightExpression.Expression expression2) => TryInterpret(rc, expression2, paramExprs, paramValues, parentArgs, out var result15) ? result15 : expression2.CompileToFactoryDelegate(((IContainer)rc).Rules.UseInterpretation)(rc), DryIoc.FastExpressionCompiler.LightExpression.Expression.TryGetIntConstantValue(instanceFourArgumentsMethodCallExpression.Argument3));
				}
				return true;
			}
			if (method.IsGenericMethod && method.GetGenericMethodDefinition() == Scope.TrackDisposableOpenGenericMethod)
			{
				InstanceTwoArgumentsMethodCallExpression instanceTwoArgumentsMethodCallExpression = (InstanceTwoArgumentsMethodCallExpression)callExpr;
				if (!TryInterpret(r, instanceTwoArgumentsMethodCallExpression.Argument0, paramExprs, paramValues, parentArgs, out var result6))
				{
					return false;
				}
				if (result6 is IDisposable disposable3)
				{
					result = r.SingletonScope.TrackDisposable(disposable3, DryIoc.FastExpressionCompiler.LightExpression.Expression.TryGetIntConstantValue(instanceTwoArgumentsMethodCallExpression.Argument1));
				}
				return true;
			}
		}
		else if (declaringType == typeof(IResolver))
		{
			IResolverContext resolverContext = r;
			if (callExpr.Object != FactoryDelegateCompiler.ResolverContextParamExpr)
			{
				if (!TryInterpret(resolverContext, callExpr.Object, paramExprs, paramValues, parentArgs, out var result7))
				{
					return false;
				}
				resolverContext = (IResolverContext)result7;
			}
			if (method == Resolver.ResolveFastMethod)
			{
				InstanceTwoArgumentsMethodCallExpression instanceTwoArgumentsMethodCallExpression2 = (InstanceTwoArgumentsMethodCallExpression)callExpr;
				result = resolverContext.Resolve((Type)ConstValue(instanceTwoArgumentsMethodCallExpression2.Argument0), (IfUnresolved)ConstValue(instanceTwoArgumentsMethodCallExpression2.Argument1));
				return true;
			}
			if (method == Resolver.ResolveMethod)
			{
				InstanceSixArgumentsMethodCallExpression instanceSixArgumentsMethodCallExpression = (InstanceSixArgumentsMethodCallExpression)callExpr;
				TryInterpret(resolverContext, instanceSixArgumentsMethodCallExpression.Argument1, paramExprs, paramValues, parentArgs, out var result8);
				TryInterpret(resolverContext, instanceSixArgumentsMethodCallExpression.Argument4, paramExprs, paramValues, parentArgs, out var result9);
				TryInterpret(resolverContext, instanceSixArgumentsMethodCallExpression.Argument5, paramExprs, paramValues, parentArgs, out var result10);
				result = resolverContext.Resolve((Type)ConstValue(instanceSixArgumentsMethodCallExpression.Argument0), result8, (IfUnresolved)ConstValue(instanceSixArgumentsMethodCallExpression.Argument2), (Type)ConstValue(instanceSixArgumentsMethodCallExpression.Argument3), (Request)result9, (object[])result10);
				return true;
			}
			if (method == Resolver.ResolveManyMethod)
			{
				InstanceFiveArgumentsMethodCallExpression instanceFiveArgumentsMethodCallExpression = (InstanceFiveArgumentsMethodCallExpression)callExpr;
				TryInterpret(resolverContext, instanceFiveArgumentsMethodCallExpression.Argument1, paramExprs, paramValues, parentArgs, out var result11);
				TryInterpret(resolverContext, instanceFiveArgumentsMethodCallExpression.Argument3, paramExprs, paramValues, parentArgs, out var result12);
				TryInterpret(resolverContext, instanceFiveArgumentsMethodCallExpression.Argument4, paramExprs, paramValues, parentArgs, out var result13);
				result = resolverContext.ResolveMany((Type)ConstValue(instanceFiveArgumentsMethodCallExpression.Argument0), result11, (Type)ConstValue(instanceFiveArgumentsMethodCallExpression.Argument2), (Request)result12, (object[])result13);
				return true;
			}
		}
		if (callExpr == ResolverContext.RootOrSelfExpr)
		{
			result = r.Root ?? r;
			return true;
		}
		object result14 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression expression = callExpr.Object;
		if (expression != null)
		{
			if (expression is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression)
			{
				result14 = constantExpression.Value;
			}
			else if (!TryInterpret(r, expression, paramExprs, paramValues, parentArgs, out result14))
			{
				return false;
			}
		}
		int argumentCount = callExpr.ArgumentCount;
		if (argumentCount == 0)
		{
			result = method.Invoke(result14, ArrayTools.Empty<object>());
		}
		else
		{
			object[] array = new object[argumentCount];
			for (int num = 0; num < array.Length; num++)
			{
				DryIoc.FastExpressionCompiler.LightExpression.Expression argument2 = callExpr.GetArgument(num);
				if (argument2 is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression2)
				{
					array[num] = constantExpression2.Value;
				}
				else if (!TryInterpret(r, argument2, paramExprs, paramValues, parentArgs, out array[num]))
				{
					return false;
				}
			}
			result = method.Invoke(result14, array);
		}
		return true;
	}

	private static bool TryInterpretFuncInvoke(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression e, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs, ref object result)
	{
		switch (e.ArgumentCount)
		{
		case 0:
			result = ((Func<object>)((FuncInvoke0Expression)e).Func)();
			break;
		case 1:
		{
			FuncInvoke1Expression funcInvoke1Expression = (FuncInvoke1Expression)e;
			if (!TryInterpret(r, funcInvoke1Expression.Argument, paramExprs, paramValues, parentArgs, out var result29))
			{
				return false;
			}
			result = ((Func<object, object>)funcInvoke1Expression.Func)(result29);
			break;
		}
		case 2:
		{
			FuncInvoke2Expression funcInvoke2Expression = (FuncInvoke2Expression)e;
			if (!TryInterpret(r, funcInvoke2Expression.Argument0, paramExprs, paramValues, parentArgs, out var result27) || !TryInterpret(r, funcInvoke2Expression.Argument1, paramExprs, paramValues, parentArgs, out var result28))
			{
				return false;
			}
			result = ((Func<object, object, object>)funcInvoke2Expression.Func)(result27, result28);
			break;
		}
		case 3:
		{
			FuncInvoke3Expression funcInvoke3Expression = (FuncInvoke3Expression)e;
			if (!TryInterpret(r, funcInvoke3Expression.Argument0, paramExprs, paramValues, parentArgs, out var result24) || !TryInterpret(r, funcInvoke3Expression.Argument1, paramExprs, paramValues, parentArgs, out var result25) || !TryInterpret(r, funcInvoke3Expression.Argument2, paramExprs, paramValues, parentArgs, out var result26))
			{
				return false;
			}
			result = ((Func<object, object, object, object>)funcInvoke3Expression.Func)(result24, result25, result26);
			break;
		}
		case 4:
		{
			FuncInvoke4Expression funcInvoke4Expression = (FuncInvoke4Expression)e;
			if (!TryInterpret(r, funcInvoke4Expression.Argument0, paramExprs, paramValues, parentArgs, out var result20) || !TryInterpret(r, funcInvoke4Expression.Argument1, paramExprs, paramValues, parentArgs, out var result21) || !TryInterpret(r, funcInvoke4Expression.Argument2, paramExprs, paramValues, parentArgs, out var result22) || !TryInterpret(r, funcInvoke4Expression.Argument3, paramExprs, paramValues, parentArgs, out var result23))
			{
				return false;
			}
			result = ((Func<object, object, object, object, object>)funcInvoke4Expression.Func)(result20, result21, result22, result23);
			break;
		}
		case 5:
		{
			FuncInvoke5Expression funcInvoke5Expression = (FuncInvoke5Expression)e;
			if (!TryInterpret(r, funcInvoke5Expression.Argument0, paramExprs, paramValues, parentArgs, out var result15) || !TryInterpret(r, funcInvoke5Expression.Argument1, paramExprs, paramValues, parentArgs, out var result16) || !TryInterpret(r, funcInvoke5Expression.Argument2, paramExprs, paramValues, parentArgs, out var result17) || !TryInterpret(r, funcInvoke5Expression.Argument3, paramExprs, paramValues, parentArgs, out var result18) || !TryInterpret(r, funcInvoke5Expression.Argument4, paramExprs, paramValues, parentArgs, out var result19))
			{
				return false;
			}
			result = ((Func<object, object, object, object, object, object>)funcInvoke5Expression.Func)(result15, result16, result17, result18, result19);
			break;
		}
		case 6:
		{
			FuncInvoke6Expression funcInvoke6Expression = (FuncInvoke6Expression)e;
			if (!TryInterpret(r, funcInvoke6Expression.Argument0, paramExprs, paramValues, parentArgs, out var result9) || !TryInterpret(r, funcInvoke6Expression.Argument1, paramExprs, paramValues, parentArgs, out var result10) || !TryInterpret(r, funcInvoke6Expression.Argument2, paramExprs, paramValues, parentArgs, out var result11) || !TryInterpret(r, funcInvoke6Expression.Argument3, paramExprs, paramValues, parentArgs, out var result12) || !TryInterpret(r, funcInvoke6Expression.Argument4, paramExprs, paramValues, parentArgs, out var result13) || !TryInterpret(r, funcInvoke6Expression.Argument5, paramExprs, paramValues, parentArgs, out var result14))
			{
				return false;
			}
			result = ((Func<object, object, object, object, object, object, object>)funcInvoke6Expression.Func)(result9, result10, result11, result12, result13, result14);
			break;
		}
		default:
		{
			FuncInvoke7Expression funcInvoke7Expression = (FuncInvoke7Expression)e;
			if (!TryInterpret(r, funcInvoke7Expression.Argument0, paramExprs, paramValues, parentArgs, out var result2) || !TryInterpret(r, funcInvoke7Expression.Argument1, paramExprs, paramValues, parentArgs, out var result3) || !TryInterpret(r, funcInvoke7Expression.Argument2, paramExprs, paramValues, parentArgs, out var result4) || !TryInterpret(r, funcInvoke7Expression.Argument3, paramExprs, paramValues, parentArgs, out var result5) || !TryInterpret(r, funcInvoke7Expression.Argument4, paramExprs, paramValues, parentArgs, out var result6) || !TryInterpret(r, funcInvoke7Expression.Argument5, paramExprs, paramValues, parentArgs, out var result7) || !TryInterpret(r, funcInvoke7Expression.Argument6, paramExprs, paramValues, parentArgs, out var result8))
			{
				return false;
			}
			result = ((Func<object, object, object, object, object, object, object, object>)funcInvoke7Expression.Func)(result2, result3, result4, result5, result6, result7, result8);
			break;
		}
		}
		return true;
	}

	private static object InterpretGetScopedOrSingletonViaFactoryDelegate(IResolverContext r, CurrentScopeReuse.GetScopedOrSingletonViaFactoryDelegateExpression e, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs)
	{
		Scope scope;
		if (e is CurrentScopeReuse.GetScopedViaFactoryDelegateExpression getScopedViaFactoryDelegateExpression)
		{
			scope = (Scope)r.CurrentScope;
			if (scope == null)
			{
				if (!getScopedViaFactoryDelegateExpression.ThrowIfNoScope)
				{
					return null;
				}
				return Throw.For<IScope>(Error.NoCurrentScope, r);
			}
		}
		else
		{
			scope = (Scope)r.CurrentOrSingletonScope;
		}
		int factoryId = e.FactoryId;
		object noItem = Scope.NoItem;
		ref ImMap<object> reference = ref scope._maps[factoryId & 0xF];
		ImMapEntry<object> entryOrDefault = reference.GetEntryOrDefault(factoryId);
		if (entryOrDefault != null && entryOrDefault.Value != noItem)
		{
			return entryOrDefault.Value;
		}
		if (scope.IsDisposed)
		{
			Throw.ScopeIsDisposed(scope, r);
		}
		entryOrDefault = new ImMapEntry<object>(factoryId, noItem);
		ImMap<object> imMap = reference;
		ImMap<object> imMap2 = imMap.AddOrKeepEntry(entryOrDefault);
		if (Interlocked.CompareExchange(ref reference, imMap2, imMap) != imMap)
		{
			imMap2 = Ref.SwapAndGetNewValue(ref reference, entryOrDefault, (ImMap<object> x, ImMapEntry<object> i) => x.AddOrKeepEntry(i));
			ImMapEntry<object> surePresentEntry = imMap2.GetSurePresentEntry(factoryId);
			if (surePresentEntry != entryOrDefault)
			{
				if (surePresentEntry.Value == noItem)
				{
					return Scope.WaitForItemIsSet(surePresentEntry);
				}
				return surePresentEntry.Value;
			}
		}
		else if (imMap2 == imMap)
		{
			ImMapEntry<object> surePresentEntry2 = imMap2.GetSurePresentEntry(factoryId);
			if (surePresentEntry2.Value == noItem)
			{
				return Scope.WaitForItemIsSet(surePresentEntry2);
			}
			return surePresentEntry2.Value;
		}
		object result = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression serviceFactoryExpr = e.ServiceFactoryExpr;
		if (serviceFactoryExpr is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression)
		{
			result = ((FactoryDelegate)constantExpression.Value)(r);
		}
		else if (!TryInterpret(r, ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)serviceFactoryExpr).Body, paramExprs, paramValues, parentArgs, out result))
		{
			result = ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)serviceFactoryExpr).Body.CompileToFactoryDelegate(((IContainer)r).Rules.UseInterpretation)(r);
		}
		entryOrDefault.Value = result;
		if (result is IDisposable disposable && disposable != scope)
		{
			scope.AddUnorderedDisposable(disposable);
		}
		return result;
	}

	private static object InterpretGetScopedOrSingletonViaFactoryDelegateWithDisposalOrder(IResolverContext r, CurrentScopeReuse.GetScopedOrSingletonViaFactoryDelegateWithDisposalOrderExpression e, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs)
	{
		Scope scope;
		if (e is CurrentScopeReuse.GetScopedViaFactoryDelegateWithDisposalOrderExpression getScopedViaFactoryDelegateWithDisposalOrderExpression)
		{
			scope = (Scope)r.CurrentScope;
			if (scope == null)
			{
				if (!getScopedViaFactoryDelegateWithDisposalOrderExpression.ThrowIfNoScope)
				{
					return null;
				}
				return Throw.For<IScope>(Error.NoCurrentScope, r);
			}
		}
		else
		{
			scope = (Scope)r.CurrentOrSingletonScope;
		}
		int factoryId = e.FactoryId;
		ref ImMap<object> reference = ref scope._maps[factoryId & 0xF];
		ImMapEntry<object> entryOrDefault = reference.GetEntryOrDefault(factoryId);
		if (entryOrDefault != null && entryOrDefault.Value != Scope.NoItem)
		{
			return entryOrDefault.Value;
		}
		if (scope.IsDisposed)
		{
			Throw.ScopeIsDisposed(scope, r);
		}
		entryOrDefault = new ImMapEntry<object>(factoryId, Scope.NoItem);
		ImMap<object> imMap = reference;
		ImMap<object> imMap2 = imMap.AddOrKeepEntry(entryOrDefault);
		if (Interlocked.CompareExchange(ref reference, imMap2, imMap) != imMap)
		{
			imMap2 = Ref.SwapAndGetNewValue(ref reference, entryOrDefault, (ImMap<object> x, ImMapEntry<object> i) => x.AddOrKeepEntry(i));
			ImMapEntry<object> surePresentEntry = imMap2.GetSurePresentEntry(factoryId);
			if (surePresentEntry != entryOrDefault)
			{
				if (surePresentEntry.Value == Scope.NoItem)
				{
					return Scope.WaitForItemIsSet(surePresentEntry);
				}
				return surePresentEntry.Value;
			}
		}
		else if (imMap2 == imMap)
		{
			ImMapEntry<object> surePresentEntry2 = imMap2.GetSurePresentEntry(factoryId);
			if (surePresentEntry2.Value == Scope.NoItem)
			{
				return Scope.WaitForItemIsSet(surePresentEntry2);
			}
			return surePresentEntry2.Value;
		}
		object result = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression serviceFactoryExpr = e.ServiceFactoryExpr;
		if (serviceFactoryExpr is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression)
		{
			result = ((FactoryDelegate)constantExpression.Value)(r);
		}
		else if (!TryInterpret(r, ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)serviceFactoryExpr).Body, paramExprs, paramValues, parentArgs, out result))
		{
			result = ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)serviceFactoryExpr).Body.CompileToFactoryDelegate(((IContainer)r).Rules.UseInterpretation)(r);
		}
		entryOrDefault.Value = result;
		if (result is IDisposable disposable && disposable != scope)
		{
			scope.AddDisposable(disposable, e.DisposalOrder);
		}
		return result;
	}

	private static object InterpretGetNameScopedViaFactoryDelegate(IResolverContext r, DryIoc.FastExpressionCompiler.LightExpression.MethodCallExpression callExpr, IParameterProvider paramExprs, object paramValues, ParentLambdaArgs parentArgs)
	{
		SixArgumentsMethodCallExpression sixArgumentsMethodCallExpression = (SixArgumentsMethodCallExpression)callExpr;
		if (sixArgumentsMethodCallExpression.Argument0 != FactoryDelegateCompiler.ResolverContextParamExpr)
		{
			if (!TryInterpret(r, sixArgumentsMethodCallExpression.Argument0, paramExprs, paramValues, parentArgs, out var result))
			{
				return false;
			}
			r = (IResolverContext)result;
		}
		Scope scope = (Scope)r.GetNamedScope(ConstValue(sixArgumentsMethodCallExpression.Argument1), (bool)ConstValue(sixArgumentsMethodCallExpression.Argument2));
		if (scope == null)
		{
			return null;
		}
		int num = DryIoc.FastExpressionCompiler.LightExpression.Expression.TryGetIntConstantValue(sixArgumentsMethodCallExpression.Argument3);
		ref ImMap<object> reference = ref scope._maps[num & 0xF];
		ImMapEntry<object> entryOrDefault = reference.GetEntryOrDefault(num);
		if (entryOrDefault != null && entryOrDefault.Value != Scope.NoItem)
		{
			return entryOrDefault.Value;
		}
		entryOrDefault = new ImMapEntry<object>(num, Scope.NoItem);
		ImMap<object> imMap = reference;
		ImMap<object> imMap2 = imMap.AddOrKeepEntry(entryOrDefault);
		if (Interlocked.CompareExchange(ref reference, imMap2, imMap) != imMap)
		{
			imMap2 = Ref.SwapAndGetNewValue(ref reference, entryOrDefault, (ImMap<object> x, ImMapEntry<object> i) => x.AddOrKeepEntry(i));
			ImMapEntry<object> surePresentEntry = imMap2.GetSurePresentEntry(num);
			if (surePresentEntry != entryOrDefault)
			{
				if (surePresentEntry.Value == Scope.NoItem)
				{
					return Scope.WaitForItemIsSet(surePresentEntry);
				}
				return surePresentEntry.Value;
			}
		}
		else if (imMap2 == imMap)
		{
			ImMapEntry<object> surePresentEntry2 = imMap2.GetSurePresentEntry(num);
			if (surePresentEntry2.Value == Scope.NoItem)
			{
				return Scope.WaitForItemIsSet(surePresentEntry2);
			}
			return surePresentEntry2.Value;
		}
		DryIoc.FastExpressionCompiler.LightExpression.Expression argument = sixArgumentsMethodCallExpression.Argument4;
		object result2 = null;
		if (argument is DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression constantExpression)
		{
			result2 = ((FactoryDelegate)constantExpression.Value)(r);
		}
		else if (!TryInterpret(r, ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)argument).Body, paramExprs, paramValues, parentArgs, out result2))
		{
			result2 = ((DryIoc.FastExpressionCompiler.LightExpression.LambdaExpression)argument).Body.CompileToFactoryDelegate(((IContainer)r).Rules.UseInterpretation)(r);
		}
		entryOrDefault.Value = result2;
		if (result2 is IDisposable disposable)
		{
			scope.AddDisposable(disposable, DryIoc.FastExpressionCompiler.LightExpression.Expression.TryGetIntConstantValue(sixArgumentsMethodCallExpression.Argument5));
		}
		return result2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static object ConstValue(DryIoc.FastExpressionCompiler.LightExpression.Expression expr)
	{
		return ((DryIoc.FastExpressionCompiler.LightExpression.ConstantExpression)expr).Value;
	}
}

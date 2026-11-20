using System;
using System.Linq.Expressions;
using System.Reflection;

namespace EBind;

public class OneTimeDelegate<T> : AbstractImplicitDelegate<T> where T : Delegate
{
	protected override T InnerDelegate { get; }

	public OneTimeDelegate(T delegatee, Action<T> unsubscribe)
	{
		if (delegatee == null)
		{
			throw new ArgumentNullException("delegatee");
		}
		if (unsubscribe == null)
		{
			throw new ArgumentNullException("unsubscribe");
		}
		T a = CreateUnsubscribeDelegate(unsubscribe);
		InnerDelegate = (T)Delegate.Combine(a, delegatee);
	}

	private T CreateUnsubscribeDelegate(Action<T> unsubscribe)
	{
		MethodInfo? method = typeof(T).GetMethod("Invoke");
		ParameterExpression[] parameters = ExpressionHelper.BuildParametersExpressions(method);
		Type returnType = method.ReturnType;
		return Expression.Lambda<T>(Expression.Block(Expression.Call(Expression.Constant(unsubscribe.Target), unsubscribe.Method, Expression.Property(Expression.Constant(this), "InnerDelegate")), Expression.Label(Expression.Label(returnType), Expression.Default(returnType))), parameters).Compile();
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NLog.Internal;

internal static class ReflectionHelpers
{
	public delegate object? LateBoundMethod(object target, object?[] arguments);

	public static bool IsStaticClass(this Type type)
	{
		if (type.IsClass && type.IsAbstract)
		{
			return type.IsSealed;
		}
		return false;
	}

	public static LateBoundMethod CreateLateBoundMethod(MethodInfo methodInfo)
	{
		if (1 == 0)
		{
		}
		return CompileLateBoundMethod(methodInfo);
	}

	private static LateBoundMethod CompileLateBoundMethod(MethodInfo methodInfo)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object[]), "parameters");
		IEnumerable<Expression> parameterExpressions = BuildParameterList(methodInfo, parameterExpression2);
		MethodCallExpression methodCallExpression = BuildMethodCall(methodInfo, parameterExpression, parameterExpressions);
		if (methodCallExpression.Type == typeof(void))
		{
			Expression<Action<object, object[]>> expression = Expression.Lambda<Action<object, object[]>>(methodCallExpression, new ParameterExpression[2] { parameterExpression, parameterExpression2 });
			Action<object, object?[]> execute = expression.Compile();
			return delegate(object instance, object?[] parameters)
			{
				execute(instance, parameters);
				return (object?)null;
			};
		}
		return Expression.Lambda<LateBoundMethod>(Expression.Convert(methodCallExpression, typeof(object)), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
	}

	private static IEnumerable<Expression> BuildParameterList(MethodBase methodInfo, ParameterExpression parametersParameter)
	{
		List<Expression> list = new List<Expression>();
		ParameterInfo[] parameters = methodInfo.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			BinaryExpression expression = Expression.ArrayIndex(parametersParameter, Expression.Constant(i));
			UnaryExpression item = CreateParameterExpression(parameters[i], expression);
			list.Add(item);
		}
		return list;
	}

	private static MethodCallExpression BuildMethodCall(MethodInfo methodInfo, ParameterExpression instanceParameter, IEnumerable<Expression> parameterExpressions)
	{
		return Expression.Call(methodInfo.IsStatic ? null : Expression.Convert(instanceParameter, methodInfo.DeclaringType), methodInfo, parameterExpressions);
	}

	private static UnaryExpression CreateParameterExpression(ParameterInfo parameterInfo, Expression expression)
	{
		Type type = parameterInfo.ParameterType;
		if (type.IsByRef)
		{
			type = type.GetElementType();
		}
		return Expression.Convert(expression, type);
	}

	public static TAttr? GetFirstCustomAttribute<TAttr>(this Type type) where TAttr : Attribute
	{
		return Attribute.GetCustomAttributes(type, typeof(TAttr)).FirstOrDefault() as TAttr;
	}

	public static TAttr? GetFirstCustomAttribute<TAttr>(this PropertyInfo info) where TAttr : Attribute
	{
		return Attribute.GetCustomAttributes(info, typeof(TAttr)).FirstOrDefault() as TAttr;
	}

	public static TAttr? GetFirstCustomAttribute<TAttr>(this Assembly assembly) where TAttr : Attribute
	{
		return Attribute.GetCustomAttributes(assembly, typeof(TAttr)).FirstOrDefault() as TAttr;
	}

	public static IEnumerable<TAttr> GetCustomAttributes<TAttr>(this Type type, bool inherit) where TAttr : Attribute
	{
		return (TAttr[])type.GetCustomAttributes(typeof(TAttr), inherit);
	}

	public static bool IsValidPublicProperty(this PropertyInfo p)
	{
		if (p != null && p.CanRead && p.GetIndexParameters().Length == 0)
		{
			return p.GetGetMethod() != null;
		}
		return false;
	}

	public static object GetPropertyValue(this PropertyInfo p, object instance)
	{
		return p.GetValue(instance);
	}
}

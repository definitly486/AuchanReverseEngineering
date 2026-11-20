using System.Linq.Expressions;
using System.Reflection;

namespace EBind;

internal static class ExpressionHelper
{
	public static ParameterExpression[] BuildParametersExpressions(MethodInfo method)
	{
		ParameterInfo[] parameters = method.GetParameters();
		ParameterExpression[] array = new ParameterExpression[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = Expression.Parameter(parameters[i].ParameterType, parameters[i].Name);
		}
		return array;
	}
}

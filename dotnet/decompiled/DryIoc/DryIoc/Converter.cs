using System;
using System.Reflection;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

internal static class Converter
{
	private static readonly MethodInfo _convertManyMethod = typeof(Converter).GetMethod("DoConvertMany");

	public static object ConvertWithOperator(object source, Expression expr, Type targetType, MethodInfo convertMethod = null)
	{
		if (convertMethod != null)
		{
			return convertMethod.Invoke(null, new object[1] { source });
		}
		Type type = source.GetType();
		MethodInfo methodInfo = type.FindConvertOperator(type, targetType);
		if (methodInfo != null)
		{
			return methodInfo.Invoke(null, new object[1] { source });
		}
		MethodInfo methodInfo2 = targetType.FindConvertOperator(type, targetType);
		if (methodInfo2 == null)
		{
			Throw.It(Error.NoConversionOperatorFoundWhenInterpretingTheConvertExpression, source, targetType, expr);
		}
		return methodInfo2.Invoke(null, new object[1] { source });
	}

	public static object ConvertMany(object[] source, Type targetType)
	{
		MethodInfo methodInfo = _convertManyMethod.MakeGenericMethod(targetType);
		object[] parameters = source.One();
		return methodInfo.Invoke(null, parameters);
	}

	public static R[] DoConvertMany<R>(object[] items)
	{
		if (items == null && items.Length == 0)
		{
			return ArrayTools.Empty<R>();
		}
		R[] array = new R[items.Length];
		for (int i = 0; i < items.Length; i++)
		{
			array[i] = (R)items[i];
		}
		return array;
	}
}

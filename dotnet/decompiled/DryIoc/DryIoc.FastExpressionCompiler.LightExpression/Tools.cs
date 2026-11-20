using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal static class Tools
{
	private static class EmptyArray<T>
	{
		public static readonly T[] Value = new T[0];
	}

	internal static MethodInfo DelegateTargetGetterMethod = typeof(Delegate).GetProperty("Target").GetMethod;

	internal static bool IsUnsigned(this Type type)
	{
		if (!(type == typeof(byte)) && !(type == typeof(ushort)) && !(type == typeof(uint)))
		{
			return type == typeof(ulong);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsNullable(this Type type)
	{
		if (type.IsValueType && type.IsGenericType)
		{
			return type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Type GetUnderlyingNullableTypeOrNull(this Type type)
	{
		if (!type.IsValueType || !type.IsGenericType || !(type.GetGenericTypeDefinition() == typeof(Nullable<>)))
		{
			return null;
		}
		return type.GetGenericArguments()[0];
	}

	public static string GetArithmeticBinaryOperatorMethodName(this ExpressionType nodeType)
	{
		return nodeType switch
		{
			ExpressionType.Add => "op_Addition", 
			ExpressionType.AddChecked => "op_Addition", 
			ExpressionType.Subtract => "op_Subtraction", 
			ExpressionType.SubtractChecked => "op_Subtraction", 
			ExpressionType.Multiply => "op_Multiply", 
			ExpressionType.MultiplyChecked => "op_Multiply", 
			ExpressionType.Divide => "op_Division", 
			ExpressionType.Modulo => "op_Modulus", 
			_ => null, 
		};
	}

	internal static MethodInfo FindMethod(this Type type, string methodName)
	{
		MethodInfo[] methods = type.GetMethods();
		for (int i = 0; i < methods.Length; i++)
		{
			if (methods[i].Name == methodName)
			{
				return methods[i];
			}
		}
		return type.BaseType?.FindMethod(methodName);
	}

	internal static MethodInfo FindDelegateInvokeMethod(this Type type)
	{
		return type.GetMethod("Invoke");
	}

	internal static MethodInfo FindNullableGetValueOrDefaultMethod(this Type type)
	{
		MethodInfo[] methods = type.GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			if (methodInfo.GetParameters().Length == 0 && methodInfo.Name == "GetValueOrDefault")
			{
				return methodInfo;
			}
		}
		return null;
	}

	internal static MethodInfo FindValueGetterMethod(this Type type)
	{
		return type.GetProperty("Value").GetMethod;
	}

	internal static MethodInfo FindNullableHasValueGetterMethod(this Type type)
	{
		return type.GetProperty("HasValue").GetMethod;
	}

	internal static MethodInfo FindConvertOperator(this Type type, Type sourceType, Type targetType)
	{
		MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
		foreach (MethodInfo methodInfo in methods)
		{
			if (methodInfo.IsSpecialName && methodInfo.ReturnType == targetType)
			{
				string name = methodInfo.Name;
				if (name.Length == 11 && name[2] == '_' && name[5] == 'p' && name[6] == 'l' && name[7] == 'i' && name[8] == 'c' && name[9] == 'i' && name[10] == 't' && methodInfo.GetParameters()[0].ParameterType == sourceType)
				{
					return methodInfo;
				}
			}
		}
		return null;
	}

	internal static ConstructorInfo FindSingleParamConstructor(this Type type, Type paramType)
	{
		ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (ConstructorInfo constructorInfo in constructors)
		{
			ParameterInfo[] parameters = constructorInfo.GetParameters();
			if (parameters.Length == 1 && parameters[0].ParameterType == paramType)
			{
				return constructorInfo;
			}
		}
		return null;
	}

	public static T[] AsArray<T>(this IEnumerable<T> xs)
	{
		if (xs is T[] result)
		{
			return result;
		}
		return xs?.ToArray();
	}

	public static T[] Empty<T>()
	{
		return EmptyArray<T>.Value;
	}

	public static Type[] GetParamTypes(IReadOnlyList<ParameterExpression> paramExprs)
	{
		if (paramExprs == null)
		{
			return Empty<Type>();
		}
		int count = paramExprs.Count;
		switch (count)
		{
		case 0:
			return Empty<Type>();
		case 1:
			return new Type[1] { paramExprs[0].IsByRef ? paramExprs[0].Type.MakeByRefType() : paramExprs[0].Type };
		default:
		{
			Type[] array = new Type[count];
			for (int i = 0; i < array.Length; i++)
			{
				ParameterExpression parameterExpression = paramExprs[i];
				array[i] = (parameterExpression.IsByRef ? parameterExpression.Type.MakeByRefType() : parameterExpression.Type);
			}
			return array;
		}
		}
	}

	public static Type GetFuncOrActionType(Type returnType)
	{
		if (!(returnType == typeof(void)))
		{
			return typeof(Func<>).MakeGenericType(returnType);
		}
		return typeof(Action);
	}

	public static Type GetFuncOrActionType(Type p, Type returnType)
	{
		if (!(returnType == typeof(void)))
		{
			return typeof(Func<, >).MakeGenericType(p, returnType);
		}
		return typeof(Action<>).MakeGenericType(p);
	}

	public static Type GetFuncOrActionType(Type p0, Type p1, Type returnType)
	{
		if (!(returnType == typeof(void)))
		{
			return typeof(Func<, , >).MakeGenericType(p0, p1, returnType);
		}
		return typeof(Action<, >).MakeGenericType(p0, p1);
	}

	public static Type GetFuncOrActionType(Type p0, Type p1, Type p2, Type returnType)
	{
		if (!(returnType == typeof(void)))
		{
			return typeof(Func<, , , >).MakeGenericType(p0, p1, p2, returnType);
		}
		return typeof(Action<, , >).MakeGenericType(p0, p1, p2);
	}

	public static Type GetFuncOrActionType(Type p0, Type p1, Type p2, Type p3, Type returnType)
	{
		if (!(returnType == typeof(void)))
		{
			return typeof(Func<, , , , >).MakeGenericType(p0, p1, p2, p3, returnType);
		}
		return typeof(Action<, , , >).MakeGenericType(p0, p1, p2, p3);
	}

	public static Type GetFuncOrActionType(Type p0, Type p1, Type p2, Type p3, Type p4, Type returnType)
	{
		if (!(returnType == typeof(void)))
		{
			return typeof(Func<, , , , , >).MakeGenericType(p0, p1, p2, p3, p4, returnType);
		}
		return typeof(Action<, , , , >).MakeGenericType(p0, p1, p2, p3, p4);
	}

	public static Type GetFuncOrActionType(Type p0, Type p1, Type p2, Type p3, Type p4, Type p5, Type returnType)
	{
		if (!(returnType == typeof(void)))
		{
			return typeof(Func<, , , , , , >).MakeGenericType(p0, p1, p2, p3, p4, p5, returnType);
		}
		return typeof(Action<, , , , , >).MakeGenericType(p0, p1, p2, p3, p4, p5);
	}

	public static Type GetFuncOrActionType(Type[] paramTypes, Type returnType)
	{
		if (returnType == typeof(void))
		{
			return paramTypes.Length switch
			{
				0 => typeof(Action), 
				1 => typeof(Action<>).MakeGenericType(paramTypes), 
				2 => typeof(Action<, >).MakeGenericType(paramTypes), 
				3 => typeof(Action<, , >).MakeGenericType(paramTypes), 
				4 => typeof(Action<, , , >).MakeGenericType(paramTypes), 
				5 => typeof(Action<, , , , >).MakeGenericType(paramTypes), 
				6 => typeof(Action<, , , , , >).MakeGenericType(paramTypes), 
				7 => typeof(Action<, , , , , , >).MakeGenericType(paramTypes), 
				_ => throw new NotSupportedException($"Action with so many ({paramTypes.Length}) parameters is not supported!"), 
			};
		}
		return paramTypes.Length switch
		{
			0 => typeof(Func<>).MakeGenericType(returnType), 
			1 => typeof(Func<, >).MakeGenericType(paramTypes[0], returnType), 
			2 => typeof(Func<, , >).MakeGenericType(paramTypes[0], paramTypes[1], returnType), 
			3 => typeof(Func<, , , >).MakeGenericType(paramTypes[0], paramTypes[1], paramTypes[2], returnType), 
			4 => typeof(Func<, , , , >).MakeGenericType(paramTypes[0], paramTypes[1], paramTypes[2], paramTypes[3], returnType), 
			5 => typeof(Func<, , , , , >).MakeGenericType(paramTypes[0], paramTypes[1], paramTypes[2], paramTypes[3], paramTypes[4], returnType), 
			6 => typeof(Func<, , , , , , >).MakeGenericType(paramTypes[0], paramTypes[1], paramTypes[2], paramTypes[3], paramTypes[4], paramTypes[5], returnType), 
			7 => typeof(Func<, , , , , , , >).MakeGenericType(paramTypes[0], paramTypes[1], paramTypes[2], paramTypes[3], paramTypes[4], paramTypes[5], paramTypes[6], returnType), 
			_ => throw new NotSupportedException($"Func with so many ({paramTypes.Length}) parameters is not supported!"), 
		};
	}

	public static T GetFirst<T>(this IEnumerable<T> source)
	{
		if (source is IList<T> list)
		{
			if (list.Count != 0)
			{
				return list[0];
			}
			return default(T);
		}
		using IEnumerator<T> enumerator = source.GetEnumerator();
		return enumerator.MoveNext() ? enumerator.Current : default(T);
	}

	public static T GetFirst<T>(this T[] source)
	{
		if (source.Length != 0)
		{
			return source[0];
		}
		return default(T);
	}
}

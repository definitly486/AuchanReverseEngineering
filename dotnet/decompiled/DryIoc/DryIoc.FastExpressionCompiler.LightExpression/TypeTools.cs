using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DryIoc.FastExpressionCompiler.LightExpression;

internal static class TypeTools
{
	internal const BindingFlags InstanceMethods = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	internal const BindingFlags StaticMethods = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	internal static Type GetNonRef(this Type type)
	{
		if (!type.IsByRef)
		{
			return type;
		}
		return type.GetElementType();
	}

	internal static bool IsAssignableFrom(this ParameterInfo p, Type argType)
	{
		Type nonRef = p.ParameterType.GetNonRef();
		if (!(nonRef == argType))
		{
			return nonRef.IsAssignableFrom(argType);
		}
		return true;
	}

	public static Type GetNonNullable(this Type type)
	{
		return type.GetGenericArguments()[0];
	}

	public static Type GetNonNullableOrSelf(this Type type)
	{
		if (!type.IsNullable())
		{
			return type;
		}
		return type.GetGenericArguments()[0];
	}

	public static Type GetNullable(this Type type)
	{
		return typeof(Nullable<>).MakeGenericType(type);
	}

	public static bool IsArithmetic(this Type type)
	{
		type = type.GetNonNullableOrSelf();
		if (!type.IsEnum)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 7) <= 7u)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsNumeric(this Type type)
	{
		type = type.GetNonNullableOrSelf();
		if (!type.IsEnum)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 4) <= 10u)
			{
				return true;
			}
		}
		return false;
	}

	internal static bool IsImplicitlyBoxingConvertibleTo(this Type source, Type target)
	{
		if (!source.IsValueType || (!(target == typeof(object)) && !(target == typeof(ValueType))))
		{
			if (source.GetTypeInfo().IsEnum)
			{
				return target == typeof(Enum);
			}
			return false;
		}
		return true;
	}

	internal static PropertyInfo FindProperty(this Type type, string propertyName)
	{
		PropertyInfo[] array = type.GetTypeInfo().DeclaredProperties.AsArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Name == propertyName)
			{
				return array[i];
			}
		}
		return type.GetTypeInfo().BaseType?.FindProperty(propertyName);
	}

	internal static FieldInfo FindField(this Type type, string fieldName)
	{
		FieldInfo[] array = type.GetTypeInfo().DeclaredFields.AsArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Name == fieldName)
			{
				return array[i];
			}
		}
		return type.GetTypeInfo().BaseType?.FindField(fieldName);
	}

	internal static MethodInfo MatchesArgumentTypes(this MethodInfo m, Type[] argTypes)
	{
		if (m == null)
		{
			return null;
		}
		ParameterInfo[] parameters = m.GetParameters();
		if (parameters.Length != argTypes.Length)
		{
			return null;
		}
		for (int i = 0; i < parameters.Length; i++)
		{
			Type parameterType = parameters[i].ParameterType;
			Type type = argTypes[i];
			if (parameterType != type && !parameterType.IsAssignableFrom(type))
			{
				return null;
			}
		}
		return m;
	}

	internal static MethodInfo FindMethodOrThrow(this Type type, string methodName, Type[] typeArgs, IReadOnlyList<Expression> argExprs, BindingFlags flags)
	{
		typeArgs = typeArgs ?? Type.EmptyTypes;
		argExprs = argExprs ?? Tools.Empty<Expression>();
		int num = typeArgs.Length;
		int count = argExprs.Count;
		MethodInfo[] methods = type.GetMethods(flags);
		MethodInfo methodInfo = null;
		int num2 = 0;
		if (num > 0)
		{
			for (int i = 0; i < methods.Length; i++)
			{
				MethodInfo methodInfo2 = methods[i];
				if (!methodInfo2.IsGenericMethod || methodInfo2.Name != methodName)
				{
					continue;
				}
				Type[] genericArguments = methodInfo2.GetGenericArguments();
				if (genericArguments.Length != num)
				{
					continue;
				}
				if (methodInfo2.IsGenericMethodDefinition)
				{
					methodInfo2 = methodInfo2.MakeGenericMethod(typeArgs);
				}
				ParameterInfo[] parameters = methodInfo2.GetParameters();
				if (parameters.Length != count)
				{
					continue;
				}
				if (argExprs.Count == 0)
				{
					if (methodInfo2.IsPublic)
					{
						return methodInfo2;
					}
					if (methodInfo != null)
					{
						return methodInfo;
					}
					methodInfo = methodInfo2;
					continue;
				}
				int scopeOfExpressionsAssignableToParams = GetScopeOfExpressionsAssignableToParams(argExprs, parameters);
				if (scopeOfExpressionsAssignableToParams == 0)
				{
					continue;
				}
				if (scopeOfExpressionsAssignableToParams == num2)
				{
					if (methodInfo2.IsPublic == methodInfo.IsPublic)
					{
						throw new InvalidOperationException($"More than one generic method '{methodInfo2.Name}' with {num} type parameter(s) in the type '{type.ToCode()}' is compatible with the supplied arguments.");
					}
					if (!methodInfo2.IsPublic)
					{
						continue;
					}
				}
				methodInfo = methodInfo2;
				num2 = scopeOfExpressionsAssignableToParams;
			}
		}
		else
		{
			foreach (MethodInfo methodInfo3 in methods)
			{
				if (methodInfo3.IsGenericMethod || methodInfo3.Name != methodName)
				{
					continue;
				}
				ParameterInfo[] parameters2 = methodInfo3.GetParameters();
				if (parameters2.Length != count)
				{
					continue;
				}
				if (argExprs.Count == 0)
				{
					if (methodInfo3.IsPublic)
					{
						return methodInfo3;
					}
					if (methodInfo != null)
					{
						return methodInfo;
					}
					methodInfo = methodInfo3;
					continue;
				}
				int scopeOfExpressionsAssignableToParams2 = GetScopeOfExpressionsAssignableToParams(argExprs, parameters2);
				if (scopeOfExpressionsAssignableToParams2 == 0)
				{
					continue;
				}
				if (scopeOfExpressionsAssignableToParams2 == num2)
				{
					if (methodInfo3.IsPublic == methodInfo.IsPublic)
					{
						throw new InvalidOperationException($"More than one non-generic method '{methodInfo3.Name}' in the type '{type.ToCode()}' is compatible with the supplied arguments.");
					}
					if (!methodInfo3.IsPublic)
					{
						continue;
					}
				}
				methodInfo = methodInfo3;
				num2 = scopeOfExpressionsAssignableToParams2;
			}
		}
		if (methodInfo == null)
		{
			throw new InvalidOperationException((num == 0) ? $"The non-generic method '{methodName}' is not found in the type '{type.ToCode()}'" : $"The generic method '{methodName}' with {num} type parameter(s) is not found in the type '{type.ToCode()}'");
		}
		return methodInfo;
	}

	private static int GetScopeOfExpressionsAssignableToParams(IReadOnlyList<Expression> argExprs, ParameterInfo[] pars)
	{
		int num = 0;
		for (int i = 0; i < pars.Length; i++)
		{
			Type type = pars[i].ParameterType;
			if (type.IsByRef)
			{
				type = type.GetElementType();
			}
			if (type == argExprs[i].Type)
			{
				num += 3;
				continue;
			}
			if (type == typeof(object))
			{
				num++;
				continue;
			}
			if (type.IsAssignableFrom(argExprs[i].Type))
			{
				num += 2;
				continue;
			}
			return 0;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IReadOnlyList<T> AsReadOnlyList<T>(this IEnumerable<T> xs)
	{
		if (xs is IReadOnlyList<T> result)
		{
			return result;
		}
		if (xs != null)
		{
			return new List<T>(xs);
		}
		return null;
	}

	internal static bool IsImplicitlyNumericConvertibleTo(this Type source, Type target)
	{
		if (source == typeof(char))
		{
			if (!(target == typeof(ushort)) && !(target == typeof(int)) && !(target == typeof(uint)) && !(target == typeof(long)) && !(target == typeof(ulong)) && !(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(sbyte))
		{
			if (!(target == typeof(short)) && !(target == typeof(int)) && !(target == typeof(long)) && !(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(byte))
		{
			if (!(target == typeof(short)) && !(target == typeof(ushort)) && !(target == typeof(int)) && !(target == typeof(uint)) && !(target == typeof(long)) && !(target == typeof(ulong)) && !(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(short))
		{
			if (!(target == typeof(int)) && !(target == typeof(long)) && !(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(ushort))
		{
			if (!(target == typeof(int)) && !(target == typeof(uint)) && !(target == typeof(long)) && !(target == typeof(ulong)) && !(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(int))
		{
			if (!(target == typeof(long)) && !(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(uint))
		{
			if (!(target == typeof(uint)) && !(target == typeof(ulong)) && !(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(long) || source == typeof(ulong))
		{
			if (!(target == typeof(float)) && !(target == typeof(double)))
			{
				return target == typeof(decimal);
			}
			return true;
		}
		if (source == typeof(float))
		{
			return target == typeof(double);
		}
		return false;
	}
}

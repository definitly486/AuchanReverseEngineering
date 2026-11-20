using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public static class Portable
{
	private static readonly Lazy<Func<Assembly, IEnumerable<Type>>> _getAssemblyTypes = Lazy.Of(GetAssemblyTypesMethod);

	private static readonly Lazy<Func<int>> _getEnvCurrentManagedThreadId = Lazy.Of(delegate
	{
		MethodInfo method = typeof(Environment).GetMethodOrNull("get_CurrentManagedThreadId", ArrayTools.Empty<Type>());
		return (method == null) ? null : ((Func<int>)(() => (int)method.Invoke(null, ArrayTools.Empty<object>())));
	});

	public static IEnumerable<Type> GetAssemblyTypes(Assembly a)
	{
		return _getAssemblyTypes.Value(a);
	}

	private static Func<Assembly, IEnumerable<Type>> GetAssemblyTypesMethod()
	{
		ParameterExpression parameterExpression = Expression.ParameterOf<Assembly>("a");
		PropertyInfo definedTypesProperty = typeof(Assembly).GetTypeInfo().GetDeclaredProperty("DefinedTypes");
		if (definedTypesProperty != null)
		{
			if (definedTypesProperty.PropertyType == typeof(IEnumerable<TypeInfo>))
			{
				return (Assembly a) => ((IEnumerable<TypeInfo>)definedTypesProperty.GetValue(a, null)).Select((TypeInfo t) => t.AsType());
			}
			return (Assembly a) => (IEnumerable<Type>)definedTypesProperty.GetValue(a, null);
		}
		MethodInfo getTypesMethod = typeof(Assembly).GetTypeInfo().GetDeclaredMethod("GetTypes");
		return (Assembly a) => (IEnumerable<Type>)getTypesMethod.Invoke(a, ArrayTools.Empty<object>());
	}

	public static MethodInfo GetGetMethodOrNull(this PropertyInfo p, bool includeNonPublic = false)
	{
		string text = "get_" + p.Name;
		MethodInfo[] array = p.DeclaringType.GetTypeInfo().DeclaredMethods.ToArrayOrSelf();
		foreach (MethodInfo methodInfo in array)
		{
			if (methodInfo.IsSpecialName && (includeNonPublic || methodInfo.IsPublic) && methodInfo.Name == text)
			{
				return methodInfo;
			}
		}
		return null;
	}

	public static MethodInfo GetSetMethodOrNull(this PropertyInfo p, bool includeNonPublic = false)
	{
		string text = "set_" + p.Name;
		MethodInfo[] array = p.DeclaringType.GetTypeInfo().DeclaredMethods.ToArrayOrSelf();
		foreach (MethodInfo methodInfo in array)
		{
			if (methodInfo.IsSpecialName && (includeNonPublic || methodInfo.IsPublic) && methodInfo.Name == text)
			{
				return methodInfo;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetCurrentManagedThreadID()
	{
		int num = -1;
		if (num == -1)
		{
			num = _getEnvCurrentManagedThreadId.Value();
		}
		return num;
	}
}

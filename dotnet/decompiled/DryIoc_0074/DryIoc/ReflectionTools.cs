using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public static class ReflectionTools
{
	[Flags]
	public enum AsImplementedType
	{
		None = 0,
		SourceType = 1,
		ObjectType = 2
	}

	internal static readonly PropertyInfo WeakReferenceValueProperty = typeof(WeakReference).GetProperty("Target");

	internal static readonly ConstructorInfo WeakReferenceCtor = typeof(WeakReference).GetConstructor(new Type[1] { typeof(object) });

	private static Lazy<Action<Exception>> _preserveExceptionStackTraceAction = new Lazy<Action<Exception>>(() => typeof(Exception).GetSingleMethodOrNull("InternalPreserveStackTrace", includeNonPublic: true)?.To((MethodInfo x) => x.CreateDelegate(typeof(Action<Exception>)).To<Action<Exception>>()));

	internal static readonly MethodInfo GetDefaultMethod = typeof(ReflectionTools).SingleMethod("GetDefault", includeNonPublic: true);

	public static Exception TryRethrowWithPreservedStackTrace(this Exception ex)
	{
		_preserveExceptionStackTraceAction.Value?.Invoke(ex);
		return ex;
	}

	public static Type[] GetImplementedTypes(this Type sourceType, AsImplementedType asImplementedType = AsImplementedType.None)
	{
		Type[] interfaces = sourceType.GetInterfaces();
		int num = (((asImplementedType & AsImplementedType.SourceType) != 0) ? 1 : 0);
		int num2 = (((asImplementedType & AsImplementedType.ObjectType) != 0) ? 1 : 0);
		int num3 = num + interfaces.Length;
		Type baseType = sourceType.BaseType;
		Type[] array;
		if (baseType == null || baseType == typeof(object))
		{
			array = new Type[num3 + num2];
		}
		else
		{
			List<Type> list = null;
			Type baseType2 = baseType.BaseType;
			while (baseType2 != null && baseType2 != typeof(object))
			{
				(list ?? (list = new List<Type>(2))).Add(baseType2);
				baseType2 = baseType2.BaseType;
			}
			if (list == null)
			{
				array = new Type[num3 + num2 + 1];
			}
			else
			{
				array = new Type[num3 + list.Count + num2 + 1];
				list.CopyTo(array, num3 + 1);
			}
			array[num3] = baseType;
		}
		if (interfaces.Length == 1)
		{
			array[num] = interfaces[0];
		}
		else if (interfaces.Length > 1)
		{
			Array.Copy(interfaces, 0, array, num, interfaces.Length);
		}
		if (num == 1)
		{
			array[0] = sourceType;
		}
		if (num2 == 1)
		{
			array[^1] = typeof(object);
		}
		return array;
	}

	public static IEnumerable<MemberInfo> GetAllMembers(this Type type, bool includeBase = false)
	{
		return type.GetMembers((TypeInfo t) => t.DeclaredMethods.Cast<MemberInfo>().Concat(t.DeclaredProperties.Cast<MemberInfo>().Concat(t.DeclaredFields.Cast<MemberInfo>())), includeBase);
	}

	public static bool ContainsAllGenericTypeParameters(this Type openGenericType, Type[] genericParameters)
	{
		if (!openGenericType.IsOpenGeneric())
		{
			return false;
		}
		Type[] array = genericParameters.Copy();
		ClearGenericParametersReferencedInConstraints(array);
		ClearMatchesFoundInGenericParameters(array, openGenericType.GetGenericArguments());
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				return false;
			}
		}
		return true;
	}

	internal static T TryCloseGenericTypeOrMethod<T>(this T openGenericTypeOrMethod, Type[] typeArgs, Func<T, Type[], T> closeGeneric, bool throwCondition, int error, Request r)
	{
		try
		{
			return closeGeneric(openGenericTypeOrMethod, typeArgs);
		}
		catch (ArgumentException inner)
		{
			if (throwCondition)
			{
				throw Throw.GetMatchedException(ErrorCheck.OperationThrows, error, openGenericTypeOrMethod, r, null, null, inner);
			}
			return default(T);
		}
	}

	public static bool IsCompilerGenerated(this Type type)
	{
		return type.Name[0] == '<';
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsClosedGeneric(this Type type)
	{
		if (type.IsGenericType)
		{
			return !type.ContainsGenericParameters;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsOpenGeneric(this Type type)
	{
		if (type.IsGenericType)
		{
			return type.ContainsGenericParameters;
		}
		return false;
	}

	public static Type GetGenericDefinitionOrNull(this Type type)
	{
		if (!type.IsGenericType)
		{
			return null;
		}
		return type.GetGenericTypeDefinition();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Type GetArrayElementTypeOrNull(this Type type)
	{
		if (!type.IsArray)
		{
			return null;
		}
		return type.GetElementType();
	}

	public static bool IsPublicOrNestedPublic(this Type type)
	{
		if (!type.IsPublic)
		{
			if (type.IsNestedPublic)
			{
				return type.DeclaringType.IsPublicOrNestedPublic();
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsStatic(this Type type)
	{
		if (type.IsAbstract)
		{
			return type.IsSealed;
		}
		return false;
	}

	public static bool HasConversionOperatorTo(this Type sourceType, Type targetType)
	{
		return sourceType.GetConversionOperatorOrNull(targetType) != null;
	}

	public static MethodInfo GetConversionOperatorOrNull(this Type sourceType, Type targetType)
	{
		return sourceType.FindConvertOperator(sourceType, targetType) ?? targetType.FindConvertOperator(sourceType, targetType);
	}

	public static MethodInfo GetSourceConversionOperatorToTarget(this Type sourceType, Type targetType)
	{
		return sourceType.FindConvertOperator(sourceType, targetType);
	}

	public static MethodInfo GetTargetConversionOperatorFromSource(this Type sourceType, Type targetType)
	{
		return targetType.FindConvertOperator(sourceType, targetType);
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

	public static bool IsAssignableTo(this Type type, Type other)
	{
		if (type != null && other != null)
		{
			return other.IsAssignableFrom(type);
		}
		return false;
	}

	public static bool IsAssignableTo<T>(this Type type)
	{
		if (type != null)
		{
			return typeof(T).IsAssignableFrom(type);
		}
		return false;
	}

	public static bool IsAssignableVariantGenericTypeFrom(this Type to, Type from)
	{
		if (from != to && from.IsGenericType && from.GetGenericTypeDefinition() == to.GetGenericTypeDefinition())
		{
			return to.IsAssignableFrom(from);
		}
		return false;
	}

	public static bool IsTypeOf(this Type type, object obj)
	{
		if (obj != null)
		{
			return type.IsAssignableFrom(obj.GetType());
		}
		return false;
	}

	public static bool IsPrimitive(this Type type, bool orArrayOfPrimitives = false)
	{
		if (!type.IsPrimitive && !type.IsEnum && !(type == typeof(string)))
		{
			if (orArrayOfPrimitives && type.IsArray)
			{
				return type.GetElementType().IsPrimitive(orArrayOfPrimitives: true);
			}
			return false;
		}
		return true;
	}

	public static Attribute[] GetAttributes(this Type type, Type attributeType = null, bool inherit = false)
	{
		return type.GetCustomAttributes(attributeType ?? typeof(Attribute), inherit).Cast<Attribute>().ToArrayOrSelf();
	}

	public static IEnumerable<TMember> GetMembers<TMember>(this Type type, Func<TypeInfo, IEnumerable<TMember>> getMembers, bool includeBase = false)
	{
		TypeInfo typeInfo = type.GetTypeInfo();
		IEnumerable<TMember> enumerable = getMembers(typeInfo);
		if (includeBase && !(typeInfo.BaseType == null) && !(typeInfo.BaseType == typeof(object)))
		{
			return enumerable.Append(typeInfo.BaseType.GetMembers(getMembers, includeBase: true));
		}
		return enumerable;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ConstructorInfo[] PublicConstructors(this Type type)
	{
		return type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerable<ConstructorInfo> PublicAndInternalConstructors(this Type type)
	{
		return type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
	}

	public static IEnumerable<ConstructorInfo> Constructors(this Type type, bool includeNonPublic = false, bool includeStatic = false)
	{
		BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
		if (includeNonPublic)
		{
			bindingFlags |= BindingFlags.NonPublic;
		}
		if (includeStatic)
		{
			bindingFlags |= BindingFlags.Static;
		}
		return type.GetConstructors(bindingFlags);
	}

	public static ConstructorInfo GetConstructorOrNull(this Type type, bool includeNonPublic = false, params Type[] args)
	{
		int num = args.Length;
		BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
		if (includeNonPublic)
		{
			bindingFlags |= BindingFlags.NonPublic;
		}
		return type.GetConstructor(bindingFlags, null, args, null);
	}

	public static ConstructorInfo GetConstructorOrNull(this Type type, params Type[] args)
	{
		return type.GetConstructorOrNull(includeNonPublic: true, args);
	}

	public static ConstructorInfo Constructor(this Type type, params Type[] args)
	{
		return type.GetConstructorOrNull(includeNonPublic: true, args).ThrowIfNull(Error.UnableToFindConstructorWithArgs, type, args);
	}

	public static ConstructorInfo GetSingleConstructorOrNull(this Type type, bool includeNonPublic = false)
	{
		ConstructorInfo constructorInfo = null;
		ConstructorInfo[] array = type.Constructors(includeNonPublic).ToArrayOrSelf();
		foreach (ConstructorInfo constructorInfo2 in array)
		{
			if (constructorInfo != null)
			{
				return null;
			}
			if (includeNonPublic || constructorInfo2.IsPublic)
			{
				constructorInfo = constructorInfo2;
			}
		}
		return constructorInfo;
	}

	public static ConstructorInfo SingleConstructor(this Type type, bool includeNonPublic = false)
	{
		return type.GetSingleConstructorOrNull(includeNonPublic).ThrowIfNull(Error.UnableToFindSingleConstructor, type, includeNonPublic);
	}

	public static MethodInfo GetSingleMethodOrNull(this Type type, string name, bool includeNonPublic = false)
	{
		if (includeNonPublic)
		{
			foreach (MethodInfo declaredMethod in type.GetTypeInfo().DeclaredMethods)
			{
				if (declaredMethod.Name == name)
				{
					return declaredMethod;
				}
			}
		}
		else
		{
			foreach (MethodInfo declaredMethod2 in type.GetTypeInfo().DeclaredMethods)
			{
				if (declaredMethod2.IsPublic && declaredMethod2.Name == name)
				{
					return declaredMethod2;
				}
			}
		}
		return null;
	}

	public static MethodInfo SingleMethod(this Type type, string name, bool includeNonPublic = false)
	{
		return type.GetSingleMethodOrNull(name, includeNonPublic).ThrowIfNull(Error.UndefinedMethodWhenGettingTheSingleMethod, name, type, includeNonPublic);
	}

	public static MethodInfo Method(this Type type, string name, params Type[] args)
	{
		return type.GetMethodOrNull(name, args).ThrowIfNull(Error.UndefinedMethodWhenGettingMethodWithSpecifiedParameters, name, type, args);
	}

	public static MethodInfo GetMethodOrNull(this Type type, string name, params Type[] paramTypes)
	{
		int num = paramTypes.Length;
		MethodInfo[] array = type.GetTypeInfo().DeclaredMethods.ToArrayOrSelf();
		MethodInfo[] array2 = array;
		foreach (MethodInfo methodInfo in array2)
		{
			if (!(methodInfo.Name == name))
			{
				continue;
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			if (parameters.Length != num)
			{
				continue;
			}
			int j;
			for (j = 0; j < num; j++)
			{
				Type parameterType = parameters[j].ParameterType;
				if (parameterType != paramTypes[j] && parameterType.GetGenericDefinitionOrNull() != paramTypes[j])
				{
					break;
				}
			}
			if (j == num)
			{
				return methodInfo;
			}
		}
		return null;
	}

	public static PropertyInfo Property(this Type type, string name, bool includeBase = false)
	{
		return type.GetPropertyOrNull(name, includeBase).ThrowIfNull(Error.UndefinedPropertyWhenGettingProperty, name, type);
	}

	public static PropertyInfo GetPropertyOrNull(this Type type, string name, bool includeBase = false)
	{
		PropertyInfo[] array = type.GetTypeInfo().DeclaredProperties.ToArrayOrSelf();
		foreach (PropertyInfo propertyInfo in array)
		{
			if (propertyInfo.Name == name)
			{
				return propertyInfo;
			}
		}
		if (includeBase)
		{
			return type.BaseType?.GetPropertyOrNull(name, includeBase);
		}
		return null;
	}

	public static FieldInfo Field(this Type type, string name, bool includeBase = false)
	{
		return type.GetFieldOrNull(name, includeBase).ThrowIfNull(Error.UndefinedFieldWhenGettingField, name, type);
	}

	public static FieldInfo GetFieldOrNull(this Type type, string name, bool includeBase = false)
	{
		FieldInfo[] array = type.GetTypeInfo().DeclaredFields.ToArrayOrSelf();
		foreach (FieldInfo fieldInfo in array)
		{
			if (fieldInfo.Name == name)
			{
				return fieldInfo;
			}
		}
		if (includeBase)
		{
			return type.BaseType?.GetFieldOrNull(name, includeBase);
		}
		return null;
	}

	public static Assembly GetAssembly(this Type type)
	{
		return type.Assembly;
	}

	public static bool IsExplicitlyImplemented(this PropertyInfo property)
	{
		return property.Name.Contains(".");
	}

	public static bool IsStatic(this MemberInfo member)
	{
		if (!(member is MethodInfo methodInfo))
		{
			if (!(member is FieldInfo fieldInfo))
			{
				if (member is PropertyInfo property && !property.IsExplicitlyImplemented())
				{
					return property.IsStatic(includeNonPublic: true);
				}
				return false;
			}
			return fieldInfo.IsStatic;
		}
		return methodInfo.IsStatic;
	}

	public static bool IsStatic(this PropertyInfo property, bool includeNonPublic = false)
	{
		string name = property.Name;
		MethodInfo[] array = property.DeclaringType.GetTypeInfo().DeclaredMethods.ToArrayOrSelf();
		foreach (MethodInfo methodInfo in array)
		{
			if (!methodInfo.IsSpecialName || (!includeNonPublic && !methodInfo.IsPublic))
			{
				continue;
			}
			string name2 = methodInfo.Name;
			int length = name2.Length;
			if (length > 4 && name2[3] == '_' && length - 4 == name.Length)
			{
				int num = 4;
				int num2 = 0;
				while (num < length && name2[num] == name[num2])
				{
					num++;
					num2++;
				}
				if (num == length)
				{
					return methodInfo.IsStatic;
				}
			}
		}
		return false;
	}

	public static Type GetReturnTypeOrDefault(this MemberInfo member)
	{
		object obj;
		if (!(member is ConstructorInfo))
		{
			obj = (member as MethodInfo)?.ReturnType;
			if (obj == null)
			{
				obj = (member as PropertyInfo)?.PropertyType;
				if (obj == null)
				{
					return (member as FieldInfo)?.FieldType;
				}
			}
		}
		else
		{
			obj = member.DeclaringType;
		}
		return (Type)obj;
	}

	public static bool IsBackingField(this FieldInfo field)
	{
		return field.Name[0] == '<';
	}

	public static bool IsIndexer(this PropertyInfo property)
	{
		return property.GetIndexParameters().Length != 0;
	}

	public static bool IsClosureType(this Type type)
	{
		return type.Name.Contains("<>c__DisplayClass");
	}

	public static IEnumerable<Attribute> GetAttributes(this MemberInfo member, Type attributeType = null, bool inherit = false)
	{
		return member.GetCustomAttributes(attributeType ?? typeof(Attribute), inherit).Cast<Attribute>();
	}

	public static IEnumerable<Attribute> GetAttributes(this ParameterInfo parameter, Type attributeType = null, bool inherit = false)
	{
		return parameter.GetCustomAttributes(attributeType ?? typeof(Attribute), inherit).Cast<Attribute>();
	}

	public static Type[] GetLoadedTypes(this Assembly assembly)
	{
		try
		{
			return Portable.GetAssemblyTypes(assembly).ToArrayOrSelf();
		}
		catch (ReflectionTypeLoadException ex)
		{
			return ex.Types.Where((Type type) => type != null).ToArray();
		}
	}

	private static void ClearGenericParametersReferencedInConstraints(Type[] genericParams)
	{
		foreach (Type type in genericParams)
		{
			if (type == null)
			{
				continue;
			}
			Type[] genericParameterConstraints = type.GetGenericParameterConstraints();
			foreach (Type type2 in genericParameterConstraints)
			{
				if (!type2.IsOpenGeneric())
				{
					continue;
				}
				Type[] genericArguments = type2.GetGenericArguments();
				foreach (Type type3 in genericArguments)
				{
					if (!(type3 != type))
					{
						continue;
					}
					for (int l = 0; l < genericParams.Length; l++)
					{
						if (genericParams[l] == type3)
						{
							genericParams[l] = null;
							break;
						}
					}
				}
			}
		}
	}

	private static void ClearMatchesFoundInGenericParameters(Type[] matchedParams, Type[] genericParams)
	{
		foreach (Type type in genericParams)
		{
			if (type.IsGenericParameter)
			{
				for (int j = 0; j < matchedParams.Length; j++)
				{
					if (matchedParams[j] == type)
					{
						matchedParams[j] = null;
						break;
					}
				}
			}
			else if (type.IsOpenGeneric())
			{
				ClearMatchesFoundInGenericParameters(matchedParams, type.GetGenericArguments());
			}
		}
	}

	internal static T GetDefault<T>()
	{
		return default(T);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Expression GetDefaultValueExpression(this Type type)
	{
		if (type.IsValueType)
		{
			return Expression.Call(GetDefaultMethod.MakeGenericMethod(type));
		}
		return ContainerTools.NullTypeConstant;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Expression Cast(this Type type, Expression source)
	{
		if (type.IsValueType)
		{
			return Expression.Convert(source, type);
		}
		return Expression.ConvertViaCastClassIntrinsic(source, type);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static object GetValueOrDefault(this ImHashMap<Type, object> map, Type t)
	{
		return map.GetValueOrDefaultByReferenceEquals(RuntimeHelpers.GetHashCode(t), t);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ImHashMap<Type, object> AddOrUpdate(this ImHashMap<Type, object> map, Type t, object value)
	{
		return map.AddOrUpdate(RuntimeHelpers.GetHashCode(t), t, value);
	}
}

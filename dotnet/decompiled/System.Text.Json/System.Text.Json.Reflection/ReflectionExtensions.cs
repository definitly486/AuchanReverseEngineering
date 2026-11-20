using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Text.Json.Reflection;

internal static class ReflectionExtensions
{
	private static readonly Type s_nullableType = typeof(Nullable<>);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNullableOfT(this Type type)
	{
		if (type.IsGenericType)
		{
			return type.GetGenericTypeDefinition() == s_nullableType;
		}
		return false;
	}

	public static object CreateInstanceNoWrapExceptions([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] this Type type, Type[] parameterTypes, object[] parameters)
	{
		return type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, parameterTypes, null).Invoke(BindingFlags.DoNotWrapExceptions, null, parameters, null);
	}
}

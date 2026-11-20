using Java.Lang;
using Java.Lang.Reflect;

namespace Auchan.Android.Extensions;

public static class JavaReflectionExtensions
{
	public static T GetField<T>(this Object javaObject, string fieldName)
	{
		Field declaredField = javaObject.Class.GetDeclaredField(fieldName);
		declaredField.Accessible = true;
		Object obj = declaredField.Get(javaObject);
		if (obj is T)
		{
			return (T)(object)((obj is T) ? obj : null);
		}
		return default(T);
	}

	public static Method GetMethod(this Object javaObject, string methodName, params Class[]? parameterTypes)
	{
		Method declaredMethod = javaObject.Class.GetDeclaredMethod(methodName, parameterTypes);
		declaredMethod.Accessible = true;
		return declaredMethod;
	}

	public static bool GetFieldSafe<T>(this Object javaObject, string fieldName, out T result)
	{
		result = default(T);
		try
		{
			result = javaObject.GetField<T>(fieldName);
			return true;
		}
		catch
		{
		}
		return false;
	}

	public static bool GetMethodSafe(this Object javaObject, string methodName, Class[]? parameterTypes, out Method? result)
	{
		result = null;
		try
		{
			result = javaObject.GetMethod(methodName, parameterTypes);
			return true;
		}
		catch
		{
		}
		return false;
	}
}

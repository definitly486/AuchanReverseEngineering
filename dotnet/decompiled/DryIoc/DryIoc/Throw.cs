using System;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public static class Throw
{
	public delegate Exception GetMatchedExceptionHandler(ErrorCheck errorCheck, int error, object arg0, object arg1, object arg2, object arg3, Exception inner);

	private static readonly string[] _defaultMessages = CreateDefaultMessages();

	public static GetMatchedExceptionHandler GetMatchedException = ContainerException.Of;

	private static string[] CreateDefaultMessages()
	{
		return new string[7] { "The error reason is unspecified, which is bad thing.", "Argument {0} of type {1} has invalid condition.", "Argument of type {0} is null.", "Argument {0} is not of type {1}.", "Type argument {0} is not assignable from type {1}.", "Invoked operation throws the inner exception {0}.", "Please check the `ContainerException.CollectedExceptions` for the details" };
	}

	public static string GetDefaultMessage(ErrorCheck error)
	{
		return _defaultMessages[(int)error];
	}

	public static void If(bool throwCondition, int error = -1, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		if (throwCondition)
		{
			throw GetMatchedException(ErrorCheck.InvalidCondition, error, arg0, arg1, arg2, arg3, null);
		}
	}

	public static T ThrowIf<T>(this T arg0, bool throwCondition, int error = -1, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		if (!throwCondition)
		{
			return arg0;
		}
		throw GetMatchedException(ErrorCheck.InvalidCondition, error, arg0, arg1, arg2, arg3, null);
	}

	public static T ThrowIfNull<T>(this T arg, int error = -1, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null) where T : class
	{
		if (arg != null)
		{
			return arg;
		}
		throw GetMatchedException(ErrorCheck.IsNull, error, arg0 ?? typeof(T), arg1, arg2, arg3, null);
	}

	public static T ThrowIfNotInstanceOf<T>(this T arg0, Type arg1, int error = -1, object arg2 = null, object arg3 = null) where T : class
	{
		if ((arg0 == null && (!arg1.IsValueType || (arg1.IsGenericType && arg1.GetGenericTypeDefinition() == typeof(Nullable<>)))) || arg1.IsAssignableFrom(arg0.GetType()))
		{
			return arg0;
		}
		throw GetMatchedException(ErrorCheck.IsNotOfType, error, arg0, arg1, arg2, arg3, null);
	}

	public static Type ThrowIfNotImplementedBy(this Type arg0, Type arg1, int error = -1, object arg2 = null, object arg3 = null)
	{
		if (arg0.IsAssignableFrom(arg1))
		{
			return arg0;
		}
		throw GetMatchedException(ErrorCheck.TypeIsNotOfType, error, arg0, arg1, arg2, arg3, null);
	}

	public static T IfThrows<TEx, T>(Func<T> operation, bool throwCondition, int error, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null) where TEx : Exception
	{
		try
		{
			return operation();
		}
		catch (TEx inner)
		{
			if (throwCondition)
			{
				throw GetMatchedException(ErrorCheck.OperationThrows, error, arg0, arg1, arg2, arg3, inner);
			}
			return default(T);
		}
	}

	public static object It(int error, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		throw GetMatchedException(ErrorCheck.Unspecified, error, arg0, arg1, arg2, arg3, null);
	}

	public static object WithDetails(object details, int error, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		return ContainerException.WithDetails(details, error, arg0, arg1, arg2, arg3);
	}

	public static T For<T>(int error, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		throw GetMatchedException(ErrorCheck.Unspecified, error, arg0, arg1, arg2, arg3, null);
	}

	public static T For<T>(bool throwCondition, int error, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		if (!throwCondition)
		{
			return default(T);
		}
		throw GetMatchedException(ErrorCheck.Unspecified, error, arg0, arg1, arg2, arg3, null);
	}

	public static bool When(bool throwIfInvalid, int error, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null)
	{
		if (!throwIfInvalid)
		{
			return false;
		}
		throw GetMatchedException(ErrorCheck.Unspecified, error, arg0, arg1, arg2, arg3, null);
	}

	public static void Many(int error, params ContainerException[] errors)
	{
		throw new ContainerException(error, errors);
	}

	public static void ScopeIsDisposed(IScope scope, IResolverContext r)
	{
		It(Error.ScopeIsDisposed, scope.ToString(), r?.DisposeInfo ?? "<not available>");
	}

	public static void StateIsRequiredToUseItem(object item, Type itemType = null)
	{
		It(Error.StateIsRequiredToUseItem, (itemType ?? item.GetType()).ToCode(stripNamespace: false, null, printGenericTypeArgs: true), item);
	}
}

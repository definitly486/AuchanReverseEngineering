using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;

namespace System.Data.Common;

internal static class ADP
{
	private static readonly Type s_stackOverflowType = typeof(StackOverflowException);

	private static readonly Type s_outOfMemoryType = typeof(OutOfMemoryException);

	private static readonly Type s_threadAbortType = typeof(ThreadAbortException);

	private static readonly Type s_nullReferenceType = typeof(NullReferenceException);

	private static readonly Type s_accessViolationType = typeof(AccessViolationException);

	private static readonly Type s_securityType = typeof(SecurityException);

	internal static ArgumentOutOfRangeException InvalidAcceptRejectRule(AcceptRejectRule value)
	{
		return InvalidEnumerationValue(typeof(AcceptRejectRule), (int)value);
	}

	internal static ArgumentOutOfRangeException InvalidMissingSchemaAction(MissingSchemaAction value)
	{
		return InvalidEnumerationValue(typeof(MissingSchemaAction), (int)value);
	}

	internal static ArgumentOutOfRangeException InvalidRule(Rule value)
	{
		return InvalidEnumerationValue(typeof(Rule), (int)value);
	}

	internal static Exception WrongType(Type got, Type expected)
	{
		return Argument(System.SR.Format("SQL_WrongType", got, expected));
	}

	private static void TraceException(string trace, Exception e)
	{
		if (e != null)
		{
			DataCommonEventSource.Log.Trace(trace, e);
		}
	}

	internal static void TraceExceptionAsReturnValue(Exception e)
	{
		TraceException("<comm.ADP.TraceException|ERR|THROW> '{0}'", e);
	}

	internal static void TraceExceptionWithoutRethrow(Exception e)
	{
		TraceException("<comm.ADP.TraceException|ERR|CATCH> '%ls'\n", e);
	}

	internal static ArgumentException Argument(string error)
	{
		ArgumentException ex = new ArgumentException(error);
		TraceExceptionAsReturnValue(ex);
		return ex;
	}

	internal static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName)
	{
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException(parameterName);
		TraceExceptionAsReturnValue(ex);
		return ex;
	}

	internal static ArgumentOutOfRangeException ArgumentOutOfRange(string message, string parameterName)
	{
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException(parameterName, message);
		TraceExceptionAsReturnValue(ex);
		return ex;
	}

	internal static InvalidOperationException InvalidOperation(string error)
	{
		InvalidOperationException ex = new InvalidOperationException(error);
		TraceExceptionAsReturnValue(ex);
		return ex;
	}

	internal static NotSupportedException NotSupported(string error)
	{
		NotSupportedException ex = new NotSupportedException(error);
		TraceExceptionAsReturnValue(ex);
		return ex;
	}

	internal static bool IsCatchableExceptionType(Exception e)
	{
		Type type = e.GetType();
		if (type != s_stackOverflowType && type != s_outOfMemoryType && type != s_threadAbortType && type != s_nullReferenceType && type != s_accessViolationType)
		{
			return !s_securityType.IsAssignableFrom(type);
		}
		return false;
	}

	internal static bool IsCatchableOrSecurityExceptionType(Exception e)
	{
		Type type = e.GetType();
		if (type != s_stackOverflowType && type != s_outOfMemoryType && type != s_threadAbortType && type != s_nullReferenceType)
		{
			return type != s_accessViolationType;
		}
		return false;
	}

	internal static ArgumentOutOfRangeException InvalidEnumerationValue(Type type, int value)
	{
		return ArgumentOutOfRange(System.SR.Format("ADP_InvalidEnumerationValue", type.Name, value.ToString(CultureInfo.InvariantCulture)), type.Name);
	}

	internal static Exception StreamClosed([CallerMemberName] string method = "")
	{
		return InvalidOperation(System.SR.Format("ADP_StreamClosed", method));
	}

	internal static Exception InvalidSeekOrigin(string parameterName)
	{
		return ArgumentOutOfRange("ADP_InvalidSeekOrigin", parameterName);
	}
}

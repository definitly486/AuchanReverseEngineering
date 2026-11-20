using System;
using System.Collections.Generic;
using System.Diagnostics;
using NLog.Common;
using NLog.Config;
using NLog.Filters;
using NLog.Internal;
using NLog.Targets;

namespace NLog;

internal static class LoggerImpl
{
	private const int StackTraceSkipMethods = 0;

	internal static void Write(Type loggerType, TargetWithFilterChain targetsForLevel, LogEventInfo logEvent, LogFactory logFactory)
	{
		logEvent.SetMessageFormatter(logFactory.ActiveMessageFormatter, (targetsForLevel.NextInChain == null) ? logFactory.SingleTargetMessageFormatter : null);
		StackTraceUsage stackTraceUsage = targetsForLevel.StackTraceUsage;
		if (stackTraceUsage != StackTraceUsage.None)
		{
			bool flag = targetsForLevel.TryCallSiteClassNameOptimization(stackTraceUsage, logEvent);
			if (flag && targetsForLevel.TryLookupCallSiteClassName(logEvent, out string callSiteClassName))
			{
				logEvent.GetCallSiteInformationInternal().CallerClassName = callSiteClassName;
			}
			else if (flag || targetsForLevel.MustCaptureStackTrace(stackTraceUsage, logEvent))
			{
				CaptureCallSiteInfo(logFactory, loggerType, logEvent, stackTraceUsage);
				if (flag)
				{
					targetsForLevel.TryRememberCallSiteClassName(logEvent);
				}
			}
		}
		AsyncContinuation onException = SingleCallContinuation.Completed;
		if (logFactory.ThrowExceptions)
		{
			int originalThreadId = AsyncHelpers.GetManagedThreadId();
			onException = delegate(Exception? ex)
			{
				if (ex != null && AsyncHelpers.GetManagedThreadId() == originalThreadId)
				{
					throw new NLogRuntimeException("Exception occurred in NLog", ex);
				}
			};
		}
		IList<Filter> list = ArrayHelper.Empty<Filter>();
		FilterResult filterResult = FilterResult.Neutral;
		TargetWithFilterChain targetWithFilterChain = targetsForLevel;
		while (targetWithFilterChain != null)
		{
			IList<Filter> filterChain = targetWithFilterChain.FilterChain;
			FilterResult filterResult2 = ((list == filterChain) ? filterResult : GetFilterResult(filterChain, logEvent, targetWithFilterChain.FilterDefaultAction));
			if (WriteToTargetWithFilterChain(targetWithFilterChain.Target, filterResult2, logEvent, onException))
			{
				filterResult = filterResult2;
				list = filterChain;
				targetWithFilterChain = targetWithFilterChain.NextInChain;
				continue;
			}
			break;
		}
	}

	private static void CaptureCallSiteInfo(LogFactory logFactory, Type loggerType, LogEventInfo logEvent, StackTraceUsage stackTraceUsage)
	{
		try
		{
			bool fNeedFileInfo = (stackTraceUsage & StackTraceUsage.WithFileNameAndLineNumber) != 0;
			StackTrace stackTrace = new StackTrace(0, fNeedFileInfo);
			logEvent.GetCallSiteInformationInternal().SetStackTrace(stackTrace, null, loggerType);
		}
		catch (Exception ex)
		{
			if (logFactory.ThrowExceptions || LogManager.ThrowExceptions)
			{
				throw;
			}
			InternalLogger.Error(ex, "{0} Failed to capture CallSite. Platform might not support ${{callsite}}", new ReadOnlySpan<object>(new object[1] { logEvent.LoggerName }));
		}
	}

	private static bool WriteToTargetWithFilterChain(Target target, FilterResult result, LogEventInfo logEvent, AsyncContinuation onException)
	{
		if (result == FilterResult.Ignore || result == FilterResult.IgnoreFinal)
		{
			if (InternalLogger.IsDebugEnabled)
			{
				InternalLogger.Debug("{0} [{1}] Rejecting message because of a filter.", logEvent.LoggerName, logEvent.Level);
			}
			if (result == FilterResult.IgnoreFinal)
			{
				return false;
			}
			return true;
		}
		target.WriteAsyncLogEvent(logEvent.WithContinuation(onException));
		if (result == FilterResult.LogFinal)
		{
			return false;
		}
		return true;
	}

	private static FilterResult GetFilterResult(IList<Filter> filterChain, LogEventInfo logEvent, FilterResult filterDefaultAction)
	{
		if (filterChain.Count == 0)
		{
			return FilterResult.Neutral;
		}
		try
		{
			for (int i = 0; i < filterChain.Count; i++)
			{
				FilterResult filterResult = filterChain[i].GetFilterResult(logEvent);
				if (filterResult != FilterResult.Neutral)
				{
					return filterResult;
				}
			}
			return filterDefaultAction;
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "Exception during filter evaluation. Message will be ignore.");
			if (ex.MustBeRethrown())
			{
				throw;
			}
			return FilterResult.Ignore;
		}
	}
}

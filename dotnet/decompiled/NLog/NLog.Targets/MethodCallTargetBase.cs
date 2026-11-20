using System;
using System.Collections.Generic;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets;

public abstract class MethodCallTargetBase : Target
{
	[ArrayParameter(typeof(MethodCallParameter), "parameter")]
	public IList<MethodCallParameter> Parameters { get; }

	protected MethodCallTargetBase()
	{
		Parameters = new List<MethodCallParameter>();
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		object[] array = ((Parameters.Count > 0) ? new object[Parameters.Count] : ArrayHelper.Empty<object>());
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				object obj = Parameters[i].RenderValue(logEvent.LogEvent);
				array[i] = obj;
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrownImmediately())
				{
					throw;
				}
				InternalLogger.Warn(ex, "{0}: Failed to get parameter value {1}", new ReadOnlySpan<object>(new object[2]
				{
					this,
					Parameters[i].Name
				}));
				throw;
			}
		}
		DoInvoke(array, logEvent);
	}

	protected virtual void DoInvoke(object?[] parameters, AsyncLogEventInfo logEvent)
	{
		try
		{
			DoInvoke(parameters);
			logEvent.Continuation(null);
		}
		catch (Exception exception)
		{
			if (ExceptionMustBeRethrown(exception, "DoInvoke"))
			{
				throw;
			}
			logEvent.Continuation(exception);
		}
	}

	protected abstract void DoInvoke(object?[] parameters);
}

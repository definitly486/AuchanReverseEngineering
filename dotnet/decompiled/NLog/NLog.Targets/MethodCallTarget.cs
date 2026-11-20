using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets;

[Target("MethodCall")]
public sealed class MethodCallTarget : MethodCallTargetBase
{
	private Action<LogEventInfo, object?[]>? _logEventAction;

	public string ClassName { get; set; } = string.Empty;

	public string MethodName { get; set; } = string.Empty;

	public MethodCallTarget()
	{
	}

	public MethodCallTarget(string name)
	{
		base.Name = name;
	}

	public MethodCallTarget(string name, Action<LogEventInfo, object?[]> logEventAction)
	{
		base.Name = name;
		_logEventAction = logEventAction;
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		if (!string.IsNullOrEmpty(ClassName) && !string.IsNullOrEmpty(MethodName))
		{
			_logEventAction = BuildLogEventAction(ClassName, MethodName);
		}
		else if (_logEventAction == null)
		{
			throw new NLogConfigurationException("MethodCallTarget: Missing configuration of ClassName and MethodName");
		}
	}

	[UnconditionalSuppressMessage("Trimming - Allow method lookup from config", "IL2075")]
	private static Action<LogEventInfo, object?[]> BuildLogEventAction(string className, string methodName)
	{
		Type type = PropertyTypeConverter.ConvertToType(className.Trim(), throwOnError: false);
		if ((object)type == null)
		{
			throw new NLogConfigurationException("MethodCallTarget: failed to get type from ClassName=" + className);
		}
		MethodInfo method = type.GetMethod(methodName);
		if ((object)method == null)
		{
			throw new NLogConfigurationException("MethodCallTarget: MethodName=" + methodName + " not found in ClassName=" + className + " - and must be static method");
		}
		if (!method.IsStatic)
		{
			throw new NLogConfigurationException("MethodCallTarget: MethodName=" + methodName + " found in ClassName=" + className + " - but not static method");
		}
		return BuildLogEventAction(method);
	}

	private static Action<LogEventInfo, object?[]> BuildLogEventAction(MethodInfo methodInfo)
	{
		int neededParameters = methodInfo.GetParameters().Length;
		ReflectionHelpers.LateBoundMethod lateBoundMethod = null;
		return delegate(LogEventInfo logEvent, object?[] parameters)
		{
			if (neededParameters - parameters.Length > 0)
			{
				object[] array = new object[neededParameters];
				for (int i = 0; i < parameters.Length; i++)
				{
					array[i] = parameters[i];
				}
				for (int j = parameters.Length; j < neededParameters; j++)
				{
					array[j] = Type.Missing;
				}
				parameters = array;
				methodInfo.Invoke(null, parameters);
			}
			else if (parameters.Length != neededParameters && neededParameters != 0)
			{
				methodInfo.Invoke(null, parameters);
			}
			else
			{
				parameters = ((neededParameters == 0) ? ArrayHelper.Empty<object>() : parameters);
				if (lateBoundMethod == null)
				{
					lateBoundMethod = CreateFastInvoke(methodInfo, parameters) ?? CreateNormalInvoke(methodInfo, parameters);
				}
				else
				{
					CallMethod(lateBoundMethod, parameters);
				}
			}
		};
	}

	private static ReflectionHelpers.LateBoundMethod? CreateFastInvoke(MethodInfo methodInfo, object?[] parameters)
	{
		try
		{
			ReflectionHelpers.LateBoundMethod lateBoundMethod = ReflectionHelpers.CreateLateBoundMethod(methodInfo);
			CallMethod(lateBoundMethod, parameters);
			return lateBoundMethod;
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "MethodCallTarget: Failed to create expression method {0} - {1}", new ReadOnlySpan<object>(new object[2] { methodInfo.Name, ex.Message }));
			return null;
		}
	}

	private static void CallMethod(ReflectionHelpers.LateBoundMethod lateBoundMethod, object?[] parameters)
	{
		lateBoundMethod(null, parameters);
	}

	private static ReflectionHelpers.LateBoundMethod CreateNormalInvoke(MethodInfo methodInfo, object?[] parameters)
	{
		ReflectionHelpers.LateBoundMethod lateBoundMethod = (object target, object?[] args) => methodInfo.Invoke(null, args);
		try
		{
			CallMethod(lateBoundMethod, parameters);
			return lateBoundMethod;
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "MethodCallTarget: Failed to invoke reflection method {0} - {1}", new ReadOnlySpan<object>(new object[2] { methodInfo.Name, ex.Message }));
			return lateBoundMethod;
		}
	}

	protected override void DoInvoke(object?[] parameters, AsyncLogEventInfo logEvent)
	{
		try
		{
			ExecuteLogMethod(parameters, logEvent.LogEvent);
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

	protected override void DoInvoke(object?[] parameters)
	{
		throw new NotSupportedException();
	}

	private void ExecuteLogMethod(object?[] parameters, LogEventInfo logEvent)
	{
		if (_logEventAction == null)
		{
			InternalLogger.Debug("{0}: No invoke because class/method was not found or set", this);
			return;
		}
		try
		{
			_logEventAction(logEvent, parameters);
		}
		catch (TargetInvocationException ex)
		{
			InternalLogger.Warn("{0}: Failed to invoke method - {1}", this, ex.Message);
			throw ex.InnerException;
		}
	}
}

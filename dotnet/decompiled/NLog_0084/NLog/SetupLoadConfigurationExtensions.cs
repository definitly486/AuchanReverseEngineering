using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using NLog.Conditions;
using NLog.Config;
using NLog.Filters;
using NLog.Internal;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Wrappers;
using NLog.Time;

namespace NLog;

public static class SetupLoadConfigurationExtensions
{
	public static ISetupLoadConfigurationBuilder SetTimeSource(this ISetupLoadConfigurationBuilder configBuilder, TimeSource timeSource)
	{
		TimeSource.Current = timeSource;
		return configBuilder;
	}

	public static ISetupLoadConfigurationBuilder SetGlobalContextProperty(this ISetupLoadConfigurationBuilder configBuilder, string name, string value)
	{
		GlobalDiagnosticsContext.Set(name, value);
		return configBuilder;
	}

	public static ISetupConfigurationLoggingRuleBuilder ForLogger(this ISetupLoadConfigurationBuilder configBuilder, string loggerNamePattern = "*", string? ruleName = null)
	{
		SetupConfigurationLoggingRuleBuilder setupConfigurationLoggingRuleBuilder = new SetupConfigurationLoggingRuleBuilder(configBuilder.LogFactory, configBuilder.Configuration, loggerNamePattern, ruleName);
		setupConfigurationLoggingRuleBuilder.LoggingRule.EnableLoggingForLevels(LogLevel.MinLevel, LogLevel.MaxLevel);
		return setupConfigurationLoggingRuleBuilder;
	}

	public static ISetupConfigurationLoggingRuleBuilder ForLogger(this ISetupLoadConfigurationBuilder configBuilder, LogLevel minLevel, string loggerNamePattern = "*", string? ruleName = null)
	{
		SetupConfigurationLoggingRuleBuilder setupConfigurationLoggingRuleBuilder = new SetupConfigurationLoggingRuleBuilder(configBuilder.LogFactory, configBuilder.Configuration, loggerNamePattern, ruleName);
		setupConfigurationLoggingRuleBuilder.LoggingRule.EnableLoggingForLevels(minLevel ?? LogLevel.MinLevel, LogLevel.MaxLevel);
		return setupConfigurationLoggingRuleBuilder;
	}

	public static ISetupConfigurationTargetBuilder ForTarget(this ISetupLoadConfigurationBuilder configBuilder, string? targetName = null)
	{
		return new SetupConfigurationTargetBuilder(configBuilder.LogFactory, configBuilder.Configuration, targetName);
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterMinLevel(this ISetupConfigurationLoggingRuleBuilder configBuilder, LogLevel minLevel)
	{
		Guard.ThrowIfNull(minLevel, "minLevel");
		configBuilder.LoggingRule.DisableLoggingForLevels(LogLevel.MinLevel, LogLevel.MaxLevel);
		configBuilder.LoggingRule.EnableLoggingForLevels(minLevel, LogLevel.MaxLevel);
		return configBuilder;
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterMaxLevel(this ISetupConfigurationLoggingRuleBuilder configBuilder, LogLevel maxLevel)
	{
		Guard.ThrowIfNull(maxLevel, "maxLevel");
		configBuilder.LoggingRule.DisableLoggingForLevels(LogLevel.MinLevel, LogLevel.MaxLevel);
		configBuilder.LoggingRule.EnableLoggingForLevels(LogLevel.MinLevel, maxLevel);
		return configBuilder;
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterLevel(this ISetupConfigurationLoggingRuleBuilder configBuilder, LogLevel logLevel)
	{
		Guard.ThrowIfNull(logLevel, "logLevel");
		if (configBuilder.LoggingRule.IsLoggingEnabledForLevel(logLevel))
		{
			configBuilder.LoggingRule.DisableLoggingForLevels(LogLevel.MinLevel, LogLevel.MaxLevel);
		}
		configBuilder.LoggingRule.EnableLoggingForLevel(logLevel);
		return configBuilder;
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterLevels(this ISetupConfigurationLoggingRuleBuilder configBuilder, LogLevel minLevel, LogLevel maxLevel)
	{
		configBuilder.LoggingRule.DisableLoggingForLevels(LogLevel.MinLevel, LogLevel.MaxLevel);
		configBuilder.LoggingRule.EnableLoggingForLevels(minLevel ?? LogLevel.MinLevel, maxLevel ?? LogLevel.MaxLevel);
		return configBuilder;
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterDynamic(this ISetupConfigurationLoggingRuleBuilder configBuilder, Filter filter, FilterResult? filterDefaultAction = null)
	{
		Guard.ThrowIfNull(filter, "filter");
		configBuilder.LoggingRule.Filters.Add(filter);
		if (filterDefaultAction.HasValue)
		{
			configBuilder.LoggingRule.FilterDefaultAction = filterDefaultAction.Value;
		}
		return configBuilder;
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterDynamic(this ISetupConfigurationLoggingRuleBuilder configBuilder, Func<LogEventInfo, FilterResult> filterMethod, FilterResult? filterDefaultAction = null)
	{
		Guard.ThrowIfNull(filterMethod, "filterMethod");
		return configBuilder.FilterDynamic(new WhenMethodFilter(filterMethod), filterDefaultAction);
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterDynamicIgnore(this ISetupConfigurationLoggingRuleBuilder configBuilder, Func<LogEventInfo, bool> filterMethod, bool final = false)
	{
		FilterResult matchResult = (final ? FilterResult.IgnoreFinal : FilterResult.Ignore);
		WhenMethodFilter filter = new WhenMethodFilter((LogEventInfo evt) => filterMethod(evt) ? matchResult : FilterResult.Neutral)
		{
			Action = matchResult
		};
		return configBuilder.FilterDynamic(filter, FilterResult.Neutral);
	}

	public static ISetupConfigurationLoggingRuleBuilder FilterDynamicLog(this ISetupConfigurationLoggingRuleBuilder configBuilder, Func<LogEventInfo, bool> filterMethod, bool final = false)
	{
		FilterResult matchResult = ((!final) ? FilterResult.Log : FilterResult.LogFinal);
		WhenMethodFilter filter = new WhenMethodFilter((LogEventInfo evt) => filterMethod(evt) ? matchResult : FilterResult.Neutral)
		{
			Action = matchResult
		};
		return configBuilder.FilterDynamic(filter, final ? FilterResult.IgnoreFinal : FilterResult.Ignore);
	}

	public static ISetupConfigurationLoggingRuleBuilder TopRule(this ISetupConfigurationLoggingRuleBuilder configBuilder, bool insertFirst = true)
	{
		LoggingRule loggingRule = configBuilder.LoggingRule;
		if (configBuilder.Configuration.LoggingRules.Contains(loggingRule))
		{
			if (!insertFirst)
			{
				return configBuilder;
			}
			configBuilder.Configuration.LoggingRules.Remove(loggingRule);
		}
		if (insertFirst)
		{
			configBuilder.Configuration.LoggingRules.Insert(0, loggingRule);
		}
		else
		{
			configBuilder.Configuration.LoggingRules.Add(loggingRule);
		}
		return configBuilder;
	}

	public static ISetupConfigurationTargetBuilder WriteTo(this ISetupConfigurationTargetBuilder configBuilder, Target target)
	{
		if (target != null)
		{
			if (string.IsNullOrEmpty(target.Name))
			{
				target.Name = EnsureUniqueTargetName(configBuilder.Configuration, target);
			}
			configBuilder.Targets.Add(target);
			configBuilder.Configuration.AddTarget(target);
		}
		return configBuilder;
	}

	public static ISetupConfigurationTargetBuilder WriteTo(this ISetupConfigurationTargetBuilder configBuilder, params Target[] targets)
	{
		if (targets != null && targets.Length != 0)
		{
			for (int i = 0; i < targets.Length; i++)
			{
				configBuilder.WriteTo(targets[i]);
			}
		}
		return configBuilder;
	}

	public static ISetupConfigurationTargetBuilder WriteTo(this ISetupConfigurationTargetBuilder configBuilder, ISetupConfigurationTargetBuilder targetBuilder)
	{
		if (configBuilder == targetBuilder)
		{
			throw new ArgumentException("ConfigBuilder and TargetBuilder cannot be the same object", "targetBuilder");
		}
		IList<Target> targets = targetBuilder.Targets;
		if (targets != null && targets.Count > 0)
		{
			for (int i = 0; i < targetBuilder.Targets.Count; i++)
			{
				configBuilder.WriteTo(targetBuilder.Targets[i]);
			}
		}
		return configBuilder;
	}

	public static void WriteToNil(this ISetupConfigurationLoggingRuleBuilder configBuilder, LogLevel? finalMinLevel = null)
	{
		LoggingRule loggingRule = configBuilder.LoggingRule;
		if (finalMinLevel != null)
		{
			if (loggingRule.Targets.Count == 0)
			{
				loggingRule = configBuilder.FilterMinLevel(finalMinLevel).LoggingRule;
			}
			loggingRule.FinalMinLevel = finalMinLevel;
		}
		else
		{
			if (loggingRule.Targets.Count == 0)
			{
				loggingRule = configBuilder.FilterMaxLevel(LogLevel.MaxLevel).LoggingRule;
			}
			if (loggingRule.Filters.Count == 0)
			{
				loggingRule.Final = true;
			}
		}
		if (loggingRule.Filters.Count > 0)
		{
			if (loggingRule.FilterDefaultAction == FilterResult.Ignore)
			{
				loggingRule.FilterDefaultAction = FilterResult.IgnoreFinal;
			}
			for (int i = 0; i < loggingRule.Filters.Count; i++)
			{
				if (loggingRule.Filters[i].Action == FilterResult.Ignore)
				{
					loggingRule.Filters[i].Action = FilterResult.IgnoreFinal;
				}
			}
			if (loggingRule.Targets.Count == 0)
			{
				loggingRule.Targets.Add(new NullTarget());
			}
		}
		if (!configBuilder.Configuration.LoggingRules.Contains(loggingRule))
		{
			configBuilder.Configuration.LoggingRules.Add(loggingRule);
		}
	}

	public static Target FirstTarget(this ISetupConfigurationTargetBuilder configBuilder)
	{
		return configBuilder.Targets.First();
	}

	public static T FirstTarget<T>(this ISetupConfigurationTargetBuilder configBuilder) where T : Target
	{
		Target target = configBuilder.Targets.First();
		for (int i = 0; i < configBuilder.Targets.Count; i++)
		{
			foreach (Target item in YieldAllTargets(configBuilder.Targets[i]))
			{
				if (item is T result)
				{
					return result;
				}
			}
		}
		throw new InvalidCastException($"Unable to cast object of type '{target.GetType()}' to type '{typeof(T)}'");
	}

	internal static IEnumerable<Target> YieldAllTargets(Target? target)
	{
		if (target != null)
		{
			yield return target;
		}
		if (target is WrapperTargetBase wrapperTargetBase)
		{
			foreach (Target item in YieldAllTargets(wrapperTargetBase.WrappedTarget))
			{
				yield return item;
			}
		}
		else
		{
			if (!(target is CompoundTargetBase compoundTargetBase))
			{
				yield break;
			}
			foreach (Target target2 in compoundTargetBase.Targets)
			{
				foreach (Target item2 in YieldAllTargets(target2))
				{
					yield return item2;
				}
			}
		}
	}

	public static ISetupConfigurationTargetBuilder WriteToMethodCall(this ISetupConfigurationTargetBuilder configBuilder, Action<LogEventInfo, object?[]> logEventAction, Layout[]? layouts = null)
	{
		Guard.ThrowIfNull(logEventAction, "logEventAction");
		MethodCallTarget methodCallTarget = new MethodCallTarget(string.Empty, logEventAction);
		if (layouts != null && layouts.Length != 0)
		{
			foreach (Layout layout in layouts)
			{
				methodCallTarget.Parameters.Add(new MethodCallParameter(layout));
			}
		}
		return configBuilder.WriteTo(methodCallTarget);
	}

	public static ISetupConfigurationTargetBuilder WriteToConsole(this ISetupConfigurationTargetBuilder configBuilder, Layout? layout = null, Encoding? encoding = null, bool stderr = false, bool detectConsoleAvailable = false, bool forceWriteLine = false)
	{
		ConsoleTarget consoleTarget = new ConsoleTarget();
		if (layout != null)
		{
			consoleTarget.Layout = layout;
		}
		if (encoding != null)
		{
			consoleTarget.Encoding = encoding;
		}
		if (stderr)
		{
			consoleTarget.StdErr = stderr;
		}
		consoleTarget.DetectConsoleAvailable = detectConsoleAvailable;
		consoleTarget.ForceWriteLine = forceWriteLine;
		return configBuilder.WriteTo(consoleTarget);
	}

	public static ISetupConfigurationTargetBuilder WriteToColoredConsole(this ISetupConfigurationTargetBuilder configBuilder, Layout? layout = null, bool highlightWordLevel = false, Encoding? encoding = null, bool stderr = false, bool detectConsoleAvailable = false, bool enableAnsiOutput = false)
	{
		ColoredConsoleTarget coloredConsoleTarget = new ColoredConsoleTarget();
		if (layout != null)
		{
			coloredConsoleTarget.Layout = layout;
		}
		if (encoding != null)
		{
			coloredConsoleTarget.Encoding = encoding;
		}
		coloredConsoleTarget.StdErr = stderr;
		coloredConsoleTarget.DetectConsoleAvailable = detectConsoleAvailable;
		coloredConsoleTarget.EnableAnsiOutput = enableAnsiOutput;
		coloredConsoleTarget.UseDefaultRowHighlightingRules = false;
		ConditionMethodExpression condition = ConditionMethodExpression.CreateMethodNoParameters("level == LogLevel.Fatal", (LogEventInfo evt) => evt.Level == LogLevel.Fatal);
		ConditionMethodExpression condition2 = ConditionMethodExpression.CreateMethodNoParameters("level == LogLevel.Error", (LogEventInfo evt) => evt.Level == LogLevel.Error);
		ConditionMethodExpression condition3 = ConditionMethodExpression.CreateMethodNoParameters("level == LogLevel.Warn", (LogEventInfo evt) => evt.Level == LogLevel.Warn);
		if (enableAnsiOutput)
		{
			if (highlightWordLevel)
			{
				coloredConsoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("Fatal", ConsoleOutputColor.DarkRed, ConsoleOutputColor.NoChange)
				{
					Condition = condition,
					IgnoreCase = true,
					WholeWords = true
				});
				coloredConsoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("Error", ConsoleOutputColor.DarkRed, ConsoleOutputColor.NoChange)
				{
					Condition = condition2,
					IgnoreCase = true,
					WholeWords = true
				});
				coloredConsoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("Warn", ConsoleOutputColor.DarkYellow, ConsoleOutputColor.NoChange)
				{
					Condition = condition3,
					IgnoreCase = true,
					WholeWords = true
				});
			}
			else
			{
				foreach (ConsoleRowHighlightingRule defaultConsoleRowHighlightingRule in new ColoredConsoleAnsiPrinter().DefaultConsoleRowHighlightingRules)
				{
					coloredConsoleTarget.RowHighlightingRules.Add(defaultConsoleRowHighlightingRule);
				}
			}
		}
		else if (highlightWordLevel)
		{
			coloredConsoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("Fatal", ConsoleOutputColor.White, ConsoleOutputColor.DarkRed)
			{
				Condition = condition,
				IgnoreCase = true,
				WholeWords = true
			});
			coloredConsoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("Error", ConsoleOutputColor.White, ConsoleOutputColor.DarkRed)
			{
				Condition = condition2,
				IgnoreCase = true,
				WholeWords = true
			});
			coloredConsoleTarget.WordHighlightingRules.Add(new ConsoleWordHighlightingRule("Warn", ConsoleOutputColor.Yellow, ConsoleOutputColor.NoChange)
			{
				Condition = condition3,
				IgnoreCase = true,
				WholeWords = true
			});
		}
		else
		{
			foreach (ConsoleRowHighlightingRule defaultConsoleRowHighlightingRule2 in new ColoredConsoleSystemPrinter().DefaultConsoleRowHighlightingRules)
			{
				coloredConsoleTarget.RowHighlightingRules.Add(defaultConsoleRowHighlightingRule2);
			}
		}
		return configBuilder.WriteTo(coloredConsoleTarget);
	}

	public static ISetupConfigurationTargetBuilder WriteToDebug(this ISetupConfigurationTargetBuilder configBuilder, Layout? layout = null)
	{
		DebugSystemTarget debugSystemTarget = new DebugSystemTarget();
		if (layout != null)
		{
			debugSystemTarget.Layout = layout;
		}
		return configBuilder.WriteTo(debugSystemTarget);
	}

	[Conditional("DEBUG")]
	public static void WriteToDebugConditional(this ISetupConfigurationTargetBuilder configBuilder, Layout? layout = null)
	{
		configBuilder.WriteToDebug(layout);
	}

	public static ISetupConfigurationTargetBuilder WriteToFile(this ISetupConfigurationTargetBuilder configBuilder, Layout fileName, Layout? layout = null, Encoding? encoding = null, LineEndingMode? lineEnding = null, bool keepFileOpen = true, long archiveAboveSize = -1L, int maxArchiveFiles = -1, int maxArchiveDays = -1)
	{
		Guard.ThrowIfNull(fileName, "fileName");
		FileTarget fileTarget = new FileTarget();
		fileTarget.FileName = fileName;
		fileTarget.KeepFileOpen = keepFileOpen;
		if (layout != null)
		{
			fileTarget.Layout = layout;
		}
		if (encoding != null)
		{
			fileTarget.Encoding = encoding;
		}
		if ((object)lineEnding != null)
		{
			fileTarget.LineEnding = lineEnding;
		}
		if (archiveAboveSize > 0)
		{
			fileTarget.ArchiveAboveSize = archiveAboveSize;
		}
		if (maxArchiveFiles >= 0)
		{
			fileTarget.MaxArchiveFiles = maxArchiveFiles;
		}
		if (maxArchiveDays > 0)
		{
			fileTarget.MaxArchiveDays = maxArchiveDays;
		}
		return configBuilder.WriteTo(fileTarget);
	}

	public static ISetupConfigurationTargetBuilder WithWrapper(this ISetupConfigurationTargetBuilder configBuilder, Func<Target, Target?> wrapperFactory)
	{
		Guard.ThrowIfNull(wrapperFactory, "wrapperFactory");
		IList<Target> targets = configBuilder.Targets;
		if (targets != null && targets.Count > 0)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				Target target = targets[i];
				Target target2 = wrapperFactory(target);
				if (target2 != null && target2 != target)
				{
					if (string.IsNullOrEmpty(target2.Name))
					{
						target2.Name = EnsureUniqueTargetName(configBuilder.Configuration, target2, target.Name);
					}
					targets[i] = target2;
					configBuilder.Configuration.AddTarget(target2);
				}
			}
			return configBuilder;
		}
		throw new ArgumentException("Must call WriteTo(...) before applying target wrapper");
	}

	public static ISetupConfigurationTargetBuilder WithAsync(this ISetupConfigurationTargetBuilder configBuilder, AsyncTargetWrapperOverflowAction overflowAction = AsyncTargetWrapperOverflowAction.Discard, int queueLimit = 10000, int batchSize = 200)
	{
		return configBuilder.WithWrapper(delegate(Target t)
		{
			if (t is AsyncTargetWrapper)
			{
				return (Target?)null;
			}
			return (t is AsyncTaskTarget) ? null : new AsyncTargetWrapper
			{
				WrappedTarget = t,
				OverflowAction = overflowAction,
				QueueLimit = queueLimit,
				BatchSize = batchSize
			};
		});
	}

	public static ISetupConfigurationTargetBuilder WithBuffering(this ISetupConfigurationTargetBuilder configBuilder, int? bufferSize = null, TimeSpan? flushTimeout = null, bool? slidingTimeout = null, BufferingTargetWrapperOverflowAction? overflowAction = null)
	{
		return configBuilder.WithWrapper(delegate(Target t)
		{
			BufferingTargetWrapper bufferingTargetWrapper = new BufferingTargetWrapper
			{
				WrappedTarget = t
			};
			if (bufferSize.HasValue)
			{
				bufferingTargetWrapper.BufferSize = bufferSize.Value;
			}
			if (flushTimeout.HasValue)
			{
				bufferingTargetWrapper.FlushTimeout = (int)flushTimeout.Value.TotalMilliseconds;
			}
			if (slidingTimeout.HasValue)
			{
				bufferingTargetWrapper.SlidingTimeout = slidingTimeout.Value;
			}
			if (overflowAction.HasValue)
			{
				bufferingTargetWrapper.OverflowAction = overflowAction.Value;
			}
			return bufferingTargetWrapper;
		});
	}

	public static ISetupConfigurationTargetBuilder WithAutoFlush(this ISetupConfigurationTargetBuilder configBuilder, Func<LogEventInfo, bool> conditionMethod, bool? flushOnConditionOnly = null)
	{
		return configBuilder.WithWrapper(delegate(Target t)
		{
			AutoFlushTargetWrapper autoFlushTargetWrapper = new AutoFlushTargetWrapper
			{
				WrappedTarget = t
			};
			ConditionMethodExpression condition = ConditionMethodExpression.CreateMethodNoParameters("AutoFlush", (LogEventInfo logEvent) => (!conditionMethod(logEvent)) ? ConditionExpression.BoxedFalse : ConditionExpression.BoxedTrue);
			autoFlushTargetWrapper.Condition = condition;
			if (flushOnConditionOnly.HasValue)
			{
				autoFlushTargetWrapper.FlushOnConditionOnly = flushOnConditionOnly.Value;
			}
			return autoFlushTargetWrapper;
		});
	}

	public static ISetupConfigurationTargetBuilder WithRetry(this ISetupConfigurationTargetBuilder configBuilder, int? retryCount = null, TimeSpan? retryDelay = null)
	{
		return configBuilder.WithWrapper(delegate(Target t)
		{
			RetryingTargetWrapper retryingTargetWrapper = new RetryingTargetWrapper
			{
				WrappedTarget = t
			};
			if (retryCount.HasValue)
			{
				retryingTargetWrapper.RetryCount = retryCount.Value;
			}
			if (retryDelay.HasValue)
			{
				retryingTargetWrapper.RetryDelayMilliseconds = (int)retryDelay.Value.TotalMilliseconds;
			}
			return retryingTargetWrapper;
		});
	}

	public static ISetupConfigurationTargetBuilder WithFallback(this ISetupConfigurationTargetBuilder configBuilder, Target fallbackTarget, bool returnToFirstOnSuccess = true)
	{
		Guard.ThrowIfNull(fallbackTarget, "fallbackTarget");
		if (string.IsNullOrEmpty(fallbackTarget.Name))
		{
			fallbackTarget.Name = EnsureUniqueTargetName(configBuilder.Configuration, fallbackTarget, "_Fallback");
		}
		return configBuilder.WithWrapper(delegate(Target t)
		{
			FallbackGroupTarget result = new FallbackGroupTarget
			{
				ReturnToFirstOnSuccess = returnToFirstOnSuccess,
				Targets = { t, fallbackTarget }
			};
			configBuilder.Configuration.AddTarget(fallbackTarget);
			return result;
		});
	}

	private static string EnsureUniqueTargetName(LoggingConfiguration configuration, Target target, string suffix = "")
	{
		ReadOnlyCollection<Target> allTargets = configuration.AllTargets;
		string text = target.Name;
		if (string.IsNullOrEmpty(text))
		{
			text = GenerateTargetName(target.GetType());
		}
		if (!string.IsNullOrEmpty(suffix))
		{
			text = text + "_" + suffix;
		}
		int num = 0;
		string text2 = text;
		while (!IsTargetNameUnique(allTargets, target, text2))
		{
			string text3 = text;
			int num2 = ++num;
			text2 = text3 + "_" + num2.ToString(CultureInfo.InvariantCulture);
		}
		return text2;
	}

	private static bool IsTargetNameUnique(IList<Target> allTargets, Target target, string targetName)
	{
		for (int i = 0; i < allTargets.Count; i++)
		{
			Target target2 = allTargets[i];
			if (target == target2)
			{
				return true;
			}
			if (string.CompareOrdinal(target2.Name, targetName) == 0)
			{
				return false;
			}
		}
		return true;
	}

	private static string GenerateTargetName(Type targetType)
	{
		string text = targetType.GetFirstCustomAttribute<TargetAttribute>()?.Name ?? targetType.Name;
		if (string.IsNullOrEmpty(text))
		{
			text = targetType.ToString();
		}
		if (text.EndsWith("TargetWrapper", StringComparison.Ordinal))
		{
			text = text.Substring(0, text.Length - 13);
		}
		if (text.EndsWith("Wrapper", StringComparison.Ordinal))
		{
			text = text.Substring(0, text.Length - 7);
		}
		if (text.EndsWith("GroupTarget", StringComparison.Ordinal))
		{
			text = text.Substring(0, text.Length - 12);
		}
		if (text.EndsWith("Group", StringComparison.Ordinal))
		{
			text = text.Substring(0, text.Length - 5);
		}
		if (text.EndsWith("Target", StringComparison.Ordinal))
		{
			text = text.Substring(0, text.Length - 6);
		}
		if (string.IsNullOrEmpty(text))
		{
			text = "Unknown";
		}
		return text;
	}
}

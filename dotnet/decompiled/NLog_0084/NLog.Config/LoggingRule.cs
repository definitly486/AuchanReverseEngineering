using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Filters;
using NLog.Internal;
using NLog.Layouts;
using NLog.Targets;

namespace NLog.Config;

[NLogConfigurationItem]
public class LoggingRule
{
	private ILoggingRuleLevelFilter _logLevelFilter = LoggingRuleLevelFilter.Off;

	private LoggerNameMatcher _loggerNameMatcher = LoggerNameMatcher.Off;

	private readonly List<Target> _targets = new List<Target>();

	[Obsolete("Very exotic feature without any unit-tests, not sure if it works. Marked obsolete with NLog v5.3")]
	private readonly List<LoggingRule> _childRules = new List<LoggingRule>();

	public string? RuleName { get; set; }

	public IList<Target> Targets => _targets;

	[Obsolete("Very exotic feature without any unit-tests, not sure if it works. Marked obsolete with NLog v5.3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IList<LoggingRule> ChildRules => _childRules;

	public IList<Filter> Filters { get; } = new List<Filter>();

	public bool Final { get; set; }

	public LogLevel? FinalMinLevel
	{
		get
		{
			return _logLevelFilter.FinalMinLevel;
		}
		set
		{
			_logLevelFilter = _logLevelFilter.GetSimpleFilterForUpdate().SetFinalMinLevel(value);
		}
	}

	public string LoggerNamePattern
	{
		get
		{
			return _loggerNameMatcher.Pattern;
		}
		set
		{
			_loggerNameMatcher = LoggerNameMatcher.Create(value);
		}
	}

	internal bool[] LogLevels => _logLevelFilter.LogLevels;

	[NLogConfigurationIgnoreProperty]
	public ReadOnlyCollection<LogLevel> Levels
	{
		get
		{
			List<LogLevel> list = new List<LogLevel>();
			bool[] logLevels = _logLevelFilter.LogLevels;
			for (int i = LogLevel.MinLevel.Ordinal; i <= LogLevel.MaxLevel.Ordinal; i++)
			{
				if (logLevels[i])
				{
					list.Add(LogLevel.FromOrdinal(i));
				}
			}
			return list.AsReadOnly();
		}
	}

	[Obsolete("Replaced by FilterDefaultAction. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public FilterResult DefaultFilterResult
	{
		get
		{
			return FilterDefaultAction;
		}
		set
		{
			FilterDefaultAction = value;
		}
	}

	public FilterResult FilterDefaultAction { get; set; } = FilterResult.Ignore;

	public LoggingRule()
	{
	}

	public LoggingRule(string? ruleName)
	{
		RuleName = ruleName;
	}

	public LoggingRule(string loggerNamePattern, LogLevel minLevel, LogLevel maxLevel, Target target)
	{
		Guard.ThrowIfNull(target, "target");
		LoggerNamePattern = loggerNamePattern;
		_targets.Add(target);
		EnableLoggingForLevels(minLevel, maxLevel);
	}

	public LoggingRule(string loggerNamePattern, LogLevel minLevel, Target target)
	{
		Guard.ThrowIfNull(target, "target");
		LoggerNamePattern = loggerNamePattern;
		_targets.Add(target);
		EnableLoggingForLevels(minLevel, LogLevel.MaxLevel);
	}

	public LoggingRule(string loggerNamePattern, Target target)
	{
		Guard.ThrowIfNull(target, "target");
		LoggerNamePattern = loggerNamePattern;
		_targets.Add(target);
	}

	[Obsolete("Very exotic feature without any unit-tests, not sure if it works. Marked obsolete with NLog v5.3")]
	internal LoggingRule[] GetChildRulesThreadSafe()
	{
		lock (_childRules)
		{
			return _childRules.ToArray();
		}
	}

	internal Target[] GetTargetsThreadSafe()
	{
		lock (_targets)
		{
			return (_targets.Count == 0) ? ArrayHelper.Empty<Target>() : _targets.ToArray();
		}
	}

	internal bool RemoveTargetThreadSafe(Target target)
	{
		lock (_targets)
		{
			return _targets.Remove(target);
		}
	}

	public void EnableLoggingForLevel(LogLevel level)
	{
		if (!(level == LogLevel.Off))
		{
			_logLevelFilter = _logLevelFilter.GetSimpleFilterForUpdate().SetLoggingLevels(level, level, enable: true);
		}
	}

	public void EnableLoggingForLevels(LogLevel minLevel, LogLevel maxLevel)
	{
		_logLevelFilter = _logLevelFilter.GetSimpleFilterForUpdate().SetLoggingLevels(minLevel, maxLevel, enable: true);
	}

	internal void EnableLoggingForLevelLayout(SimpleLayout? simpleLayout, SimpleLayout? finalMinLevel)
	{
		_logLevelFilter = new DynamicLogLevelFilter(this, simpleLayout, finalMinLevel);
	}

	internal void EnableLoggingForLevelsLayout(SimpleLayout? minLevel, SimpleLayout? maxLevel, SimpleLayout? finalMinLevel)
	{
		_logLevelFilter = new DynamicRangeLevelFilter(this, minLevel, maxLevel, finalMinLevel);
	}

	public void DisableLoggingForLevel(LogLevel level)
	{
		if (!(level == LogLevel.Off))
		{
			_logLevelFilter = _logLevelFilter.GetSimpleFilterForUpdate().SetLoggingLevels(level, level, enable: false);
		}
	}

	public void DisableLoggingForLevels(LogLevel minLevel, LogLevel maxLevel)
	{
		Guard.ThrowIfNull(minLevel, "minLevel");
		Guard.ThrowIfNull(maxLevel, "maxLevel");
		_logLevelFilter = _logLevelFilter.GetSimpleFilterForUpdate().SetLoggingLevels(minLevel, maxLevel, enable: false);
	}

	public void SetLoggingLevels(LogLevel minLevel, LogLevel maxLevel)
	{
		Guard.ThrowIfNull(minLevel, "minLevel");
		Guard.ThrowIfNull(maxLevel, "maxLevel");
		_logLevelFilter = _logLevelFilter.GetSimpleFilterForUpdate().SetLoggingLevels(LogLevel.MinLevel, LogLevel.MaxLevel, enable: false).SetLoggingLevels(minLevel, maxLevel, enable: true);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(_loggerNameMatcher.ToString());
		stringBuilder.Append(" levels: [ ");
		Target[] targetsThreadSafe = GetTargetsThreadSafe();
		bool[] logLevels = _logLevelFilter.LogLevels;
		for (int i = 0; i < logLevels.Length; i++)
		{
			if (targetsThreadSafe.Length == 0 && !Final && FinalMinLevel != null)
			{
				if (i < FinalMinLevel.Ordinal)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} ", LogLevel.FromOrdinal(i).ToString());
				}
			}
			else if (logLevels[i])
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} ", LogLevel.FromOrdinal(i).ToString());
			}
		}
		stringBuilder.Append("] writeTo: [ ");
		Target[] array = targetsThreadSafe;
		foreach (Target target in array)
		{
			string arg = (string.IsNullOrEmpty(target.Name) ? target.ToString() : target.Name);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} ", arg);
		}
		stringBuilder.Append(']');
		if (Final)
		{
			stringBuilder.Append(" final: True");
		}
		if (FinalMinLevel != null)
		{
			stringBuilder.Append(" finalMinLevel: ").Append(FinalMinLevel);
		}
		return stringBuilder.ToString();
	}

	public bool IsLoggingEnabledForLevel(LogLevel level)
	{
		if (level == LogLevel.Off)
		{
			return false;
		}
		return _logLevelFilter.LogLevels[level.Ordinal];
	}

	public bool NameMatches(string loggerName)
	{
		return _loggerNameMatcher.NameMatches(loggerName);
	}
}

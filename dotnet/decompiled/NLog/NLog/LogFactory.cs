using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.Fakeables;

namespace NLog;

public class LogFactory<T> : LogFactory where T : Logger, new()
{
	public new T GetLogger(string name)
	{
		return GetLogger<T>(name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public new T GetCurrentClassLogger()
	{
		string classFullName = StackTraceUsageUtils.GetClassFullName(new StackFrame(1, needFileInfo: false));
		return GetLogger(classFullName);
	}
}
public class LogFactory : IDisposable, IAsyncDisposable
{
	private readonly struct LoggerCacheKey : IEquatable<LoggerCacheKey>
	{
		public readonly string Name;

		public readonly Type ConcreteType;

		public LoggerCacheKey(string name, Type concreteType)
		{
			Name = name;
			ConcreteType = concreteType;
		}

		public override int GetHashCode()
		{
			return ConcreteType.GetHashCode() ^ Name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is LoggerCacheKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(LoggerCacheKey other)
		{
			if (ConcreteType == other.ConcreteType)
			{
				return string.Equals(other.Name, Name, StringComparison.Ordinal);
			}
			return false;
		}
	}

	private sealed class LoggerCache
	{
		private readonly Dictionary<LoggerCacheKey, WeakReference> _loggerCache = new Dictionary<LoggerCacheKey, WeakReference>();

		public int Count => _loggerCache.Count;

		public void InsertOrUpdate(LoggerCacheKey cacheKey, Logger logger)
		{
			_loggerCache[cacheKey] = new WeakReference(logger);
		}

		public Logger? Retrieve(LoggerCacheKey cacheKey)
		{
			if (_loggerCache.TryGetValue(cacheKey, out WeakReference value))
			{
				return value.Target as Logger;
			}
			return null;
		}

		public List<Logger> GetLoggers()
		{
			List<Logger> list = new List<Logger>(_loggerCache.Count);
			foreach (KeyValuePair<LoggerCacheKey, WeakReference> item2 in _loggerCache)
			{
				if (item2.Value.Target is Logger item)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public void Reset()
		{
			_loggerCache.Clear();
		}

		public void PurgeObsoleteLoggers()
		{
			foreach (LoggerCacheKey item in _loggerCache.Keys.ToList())
			{
				if (Retrieve(item) == null)
				{
					_loggerCache.Remove(item);
				}
			}
		}
	}

	private sealed class LogEnabler : IDisposable
	{
		private readonly LogFactory _factory;

		public LogEnabler(LogFactory factory)
		{
			_factory = factory;
		}

		void IDisposable.Dispose()
		{
			_factory.ResumeLogging();
		}
	}

	private static readonly TimeSpan DefaultFlushTimeout = TimeSpan.FromSeconds(15.0);

	private static AppEnvironmentWrapper? defaultAppEnvironment;

	internal readonly object _syncRoot = new object();

	private readonly LoggerCache _loggerCache = new LoggerCache();

	private readonly ServiceRepositoryInternal _serviceRepository;

	private readonly IAppEnvironment _currentAppEnvironment;

	internal LoggingConfiguration? _config;

	internal LogMessageFormatter ActiveMessageFormatter;

	internal LogMessageFormatter? SingleTargetMessageFormatter;

	internal LogMessageTemplateFormatter? AutoMessageTemplateFormatter;

	private LogLevel _globalThreshold = LogLevel.MinLevel;

	private bool _configLoaded;

	private int _supendLoggingCounter;

	[Obsolete("Replaced by LogFactory.Setup().LoadConfigurationFromFile(). Marked obsolete on NLog 5.2")]
	private List<string>? _candidateConfigFilePaths;

	private readonly ILoggingConfigurationLoader _configLoader;

	private bool _autoShutdown = true;

	internal CultureInfo? _defaultCultureInfo;

	private bool _isDisposing;

	internal static IAppEnvironment DefaultAppEnvironment => defaultAppEnvironment ?? (defaultAppEnvironment = new AppEnvironmentWrapper());

	internal IAppEnvironment CurrentAppEnvironment => _currentAppEnvironment;

	public ServiceRepository ServiceRepository => _serviceRepository;

	public bool ThrowExceptions { get; set; }

	public bool? ThrowConfigExceptions { get; set; }

	public bool KeepVariablesOnReload { get; set; } = true;

	public bool AutoShutdown
	{
		get
		{
			return _autoShutdown;
		}
		set
		{
			if (value != _autoShutdown)
			{
				_autoShutdown = value;
				LoggerShutdown -= OnStopLogging;
				if (value)
				{
					LoggerShutdown += OnStopLogging;
				}
			}
		}
	}

	[CanBeNull]
	public LoggingConfiguration? Configuration
	{
		get
		{
			if (_configLoaded)
			{
				return _config;
			}
			lock (_syncRoot)
			{
				if (_configLoaded || _isDisposing)
				{
					return _config;
				}
				LoggingConfiguration loggingConfiguration = _configLoader.Load(this);
				if (loggingConfiguration != null)
				{
					ActivateLoggingConfiguration(loggingConfiguration);
				}
				return _config;
			}
		}
		set
		{
			lock (_syncRoot)
			{
				LoggingConfiguration config = _config;
				if (config != null)
				{
					InternalLogger.Info("Closing old configuration.");
					config.OnConfigurationAssigned(null);
					Flush();
					config.Close();
				}
				if (value == null)
				{
					_config = value;
					_configLoaded = false;
				}
				else
				{
					ActivateLoggingConfiguration(value);
				}
				OnConfigurationChanged(new LoggingConfigurationChangedEventArgs(value, config));
			}
		}
	}

	public LogLevel GlobalThreshold
	{
		get
		{
			return _globalThreshold;
		}
		set
		{
			lock (_syncRoot)
			{
				if (_globalThreshold != value)
				{
					InternalLogger.Info("LogFactory GlobalThreshold changing to LogLevel: {0}", value);
				}
				_globalThreshold = value ?? LogLevel.MinLevel;
				ReconfigExistingLoggers();
			}
		}
	}

	public CultureInfo? DefaultCultureInfo
	{
		get
		{
			if (_config != null)
			{
				return _config.DefaultCultureInfo;
			}
			return _defaultCultureInfo;
		}
		set
		{
			if (_config != null && (_config.DefaultCultureInfo == _defaultCultureInfo || _config.DefaultCultureInfo == null))
			{
				_config.DefaultCultureInfo = value;
			}
			_defaultCultureInfo = value;
		}
	}

	public event EventHandler<LoggingConfigurationChangedEventArgs>? ConfigurationChanged;

	private static event EventHandler<EventArgs> LoggerShutdown
	{
		add
		{
			if (LogFactory._loggerShutdown == null)
			{
				InternalLogger.Debug("Registered shutdown event handler for ProcessExit.");
				DefaultAppEnvironment.ProcessExit += OnLoggerShutdown;
			}
			_loggerShutdown += value;
		}
		remove
		{
			_loggerShutdown -= value;
			if (LogFactory._loggerShutdown == null && defaultAppEnvironment != null)
			{
				InternalLogger.Debug("Unregistered shutdown event handler for ProcessExit.");
				defaultAppEnvironment.ProcessExit -= OnLoggerShutdown;
			}
		}
	}

	private static event EventHandler<EventArgs>? _loggerShutdown;

	public LogFactory()
		: this(new LoggingConfigurationFileLoader(DefaultAppEnvironment))
	{
	}

	[Obsolete("Constructor with LoggingConfiguration as parameter should not be used. Instead provide LogFactory as parameter when constructing LoggingConfiguration. Marked obsolete in NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public LogFactory(LoggingConfiguration config)
		: this()
	{
		Configuration = config;
	}

	internal LogFactory(ILoggingConfigurationLoader configLoader, IAppEnvironment? appEnvironment = null)
	{
		_configLoader = configLoader;
		_currentAppEnvironment = appEnvironment ?? DefaultAppEnvironment;
		LoggerShutdown += OnStopLogging;
		_serviceRepository = new ServiceRepositoryInternal(this);
		_serviceRepository.TypeRegistered += ServiceRepository_TypeRegistered;
		ActiveMessageFormatter = RefreshMessageFormatter();
	}

	private void ActivateLoggingConfiguration(LoggingConfiguration config)
	{
		if (_config == null)
		{
			LogNLogAssemblyVersion();
		}
		_config = config;
		_configLoaded = true;
		_config.OnConfigurationAssigned(this);
		_config.Dump();
		ReconfigExistingLoggers();
		InternalLogger.Info("Configuration initialized.");
	}

	private void ServiceRepository_TypeRegistered(object sender, ServiceRepositoryUpdateEventArgs e)
	{
		_config?.CheckForMissingServiceTypes(e.ServiceType);
		if (e.ServiceType == typeof(ILogMessageFormatter))
		{
			RefreshMessageFormatter();
		}
	}

	private LogMessageFormatter RefreshMessageFormatter()
	{
		ILogMessageFormatter service = _serviceRepository.GetService<ILogMessageFormatter>();
		ActiveMessageFormatter = service.FormatMessage;
		if (service is LogMessageTemplateFormatter logMessageTemplateFormatter)
		{
			LogMessageTemplateFormatter logMessageTemplateFormatter2 = new LogMessageTemplateFormatter(this, logMessageTemplateFormatter.EnableMessageTemplateParser == true, singleTargetOnly: true);
			SingleTargetMessageFormatter = logMessageTemplateFormatter2.FormatMessage;
			AutoMessageTemplateFormatter = ((logMessageTemplateFormatter.EnableMessageTemplateParser == true) ? null : logMessageTemplateFormatter2);
		}
		else
		{
			SingleTargetMessageFormatter = null;
			AutoMessageTemplateFormatter = null;
		}
		return ActiveMessageFormatter;
	}

	internal static void LogNLogAssemblyVersion()
	{
		try
		{
			AssemblyHelpers.LogAssemblyVersion(typeof(LogFactory).Assembly);
		}
		catch (Exception ex)
		{
			InternalLogger.Debug(ex, "Not running in full trust");
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public async ValueTask DisposeAsync()
	{
		lock (_syncRoot)
		{
			if (_config == null || !_configLoaded || _isDisposing)
			{
				DisposeInternal(closeConfig: false);
				return;
			}
		}
		try
		{
			await FlushAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "LogFactory DisposeAsync Flush Failed.");
		}
		try
		{
			Task task = Task.Delay(DefaultFlushTimeout).ContinueWith(delegate
			{
				throw new TaskCanceledException("NLog LogFactory Dispose Timeout");
			});
			await Task.WhenAny(new Task[2]
			{
				Task.Run(delegate
				{
					DisposeInternal();
				}),
				task
			}).Unwrap().ConfigureAwait(continueOnCapturedContext: false);
			GC.SuppressFinalize(this);
		}
		catch (Exception ex2)
		{
			InternalLogger.Error(ex2, "LogFactory DisposeAsync Failed.");
		}
	}

	public ISetupBuilder Setup()
	{
		return new SetupBuilder(this);
	}

	public LogFactory Setup(Action<ISetupBuilder> setupBuilder)
	{
		Guard.ThrowIfNull(setupBuilder, "setupBuilder");
		setupBuilder(new SetupBuilder(this));
		return this;
	}

	public Logger CreateNullLogger()
	{
		return new NullLogger(this);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Logger GetCurrentClassLogger()
	{
		string classFullName = StackTraceUsageUtils.GetClassFullName(new StackFrame(1, needFileInfo: false));
		return GetLogger(classFullName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetCurrentClassLogger<T>() where T : Logger, new()
	{
		string classFullName = StackTraceUsageUtils.GetClassFullName(new StackFrame(1, needFileInfo: false));
		return GetLogger<T>(classFullName);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Obsolete("Replaced by GetCurrentClassLogger<T>(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Logger GetCurrentClassLogger([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type loggerType)
	{
		string classFullName = StackTraceUsageUtils.GetClassFullName(new StackFrame(1, needFileInfo: false));
		return GetLogger(classFullName, loggerType ?? typeof(Logger));
	}

	public Logger GetLogger(string name)
	{
		return GetLoggerThreadSafe(name, Logger.DefaultLoggerType, (Type t) => new Logger());
	}

	public T GetLogger<T>(string name) where T : Logger, new()
	{
		return (T)GetLoggerThreadSafe(name, typeof(T), (Type t) => new T());
	}

	[Obsolete("Replaced by GetLogger<T>(). Marked obsolete on NLog 5.2")]
	[UnconditionalSuppressMessage("Trimming - Ignore since obsolete", "IL2067")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Logger GetLogger(string name, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type loggerType)
	{
		return GetLoggerThreadSafe(name, loggerType ?? typeof(Logger), (Type t) => (!Logger.DefaultLoggerType.IsAssignableFrom(t)) ? null : (Activator.CreateInstance(t, nonPublic: true) as Logger));
	}

	private bool RefreshExistingLoggers()
	{
		List<Logger> loggers;
		bool result;
		lock (_syncRoot)
		{
			_config?.InitializeAll();
			loggers = _loggerCache.GetLoggers();
			result = loggers.Count != _loggerCache.Count;
		}
		foreach (Logger item in loggers)
		{
			item.SetConfiguration(BuildLoggerConfiguration(item.Name));
		}
		return result;
	}

	public void ReconfigExistingLoggers()
	{
		RefreshExistingLoggers();
	}

	public void ReconfigExistingLoggers(bool purgeObsoleteLoggers)
	{
		purgeObsoleteLoggers = RefreshExistingLoggers() && purgeObsoleteLoggers;
		if (purgeObsoleteLoggers)
		{
			lock (_syncRoot)
			{
				_loggerCache.PurgeObsoleteLoggers();
			}
		}
	}

	public void Flush()
	{
		Flush(DefaultFlushTimeout);
	}

	public void Flush(TimeSpan timeout)
	{
		FlushInternal(timeout, null);
	}

	public void Flush(int timeoutMilliseconds)
	{
		Flush(TimeSpan.FromMilliseconds((double)timeoutMilliseconds));
	}

	public void Flush(AsyncContinuation asyncContinuation)
	{
		Flush(asyncContinuation, TimeSpan.MaxValue);
	}

	public void Flush(AsyncContinuation asyncContinuation, int timeoutMilliseconds)
	{
		Flush(asyncContinuation, TimeSpan.FromMilliseconds((double)timeoutMilliseconds));
	}

	public void Flush(AsyncContinuation asyncContinuation, TimeSpan timeout)
	{
		FlushInternal(timeout, asyncContinuation);
	}

	private bool FlushInternal(TimeSpan flushTimeout, AsyncContinuation? asyncContinuation)
	{
		InternalLogger.Debug("LogFactory Starting Flush with timeout={0} secs", flushTimeout.TotalSeconds);
		bool result;
		try
		{
			LoggingConfiguration loggingConfiguration;
			lock (_syncRoot)
			{
				loggingConfiguration = _config;
				if (!_configLoaded)
				{
					loggingConfiguration = null;
				}
			}
			if (loggingConfiguration == null)
			{
				asyncContinuation?.Invoke(null);
				result = true;
			}
			else
			{
				asyncContinuation = ((asyncContinuation == null) ? null : NLog.Common.AsyncHelpers.PreventMultipleCalls(asyncContinuation));
				using ManualResetEvent manualResetEvent = new ManualResetEvent(initialState: false);
				ManualResetEvent ev = manualResetEvent;
				AsyncContinuation asyncContinuation2 = loggingConfiguration.FlushAllTargets(delegate(Exception? exception)
				{
					asyncContinuation?.Invoke(exception);
					ev?.Set();
				});
				if (asyncContinuation2 == null)
				{
					asyncContinuation?.Invoke(null);
					result = true;
				}
				else
				{
					bool flag = manualResetEvent.WaitOne(flushTimeout);
					ev = null;
					asyncContinuation2(null);
					asyncContinuation?.Invoke(flag ? null : new NLogRuntimeException("LogFactory Flush Timeout"));
					result = flag;
				}
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "LogFactory failed to flush targets.");
			asyncContinuation?.Invoke(ex);
			result = false;
		}
		return result;
	}

	public Task FlushAsync(CancellationToken cancellationToken)
	{
		InternalLogger.Debug("LogFactory Starting Flush Async");
		LoggingConfiguration config;
		lock (_syncRoot)
		{
			config = _config;
			if (config == null || !_configLoaded)
			{
				return Task.CompletedTask;
			}
		}
		TaskCompletionSource<bool> flushCompleted = new TaskCompletionSource<bool>();
		AsyncContinuation flushTimeoutHandler = config.FlushAllTargets(delegate
		{
			flushCompleted.SetResult(result: true);
		});
		if (flushTimeoutHandler == null)
		{
			return Task.CompletedTask;
		}
		Task task = Task.Delay(cancellationToken.CanBeCanceled ? (-1) : ((int)DefaultFlushTimeout.TotalMilliseconds), cancellationToken).ContinueWith(delegate
		{
			throw new TaskCanceledException("NLog LogFactory Flush Timeout");
		});
		task.ContinueWith(delegate
		{
			flushTimeoutHandler(null);
			flushCompleted.TrySetCanceled();
		});
		return Task.WhenAny(new Task[2] { flushCompleted.Task, task }).Unwrap();
	}

	public IDisposable SuspendLogging()
	{
		lock (_syncRoot)
		{
			_supendLoggingCounter++;
			if (_supendLoggingCounter == 1)
			{
				ReconfigExistingLoggers();
			}
		}
		return new LogEnabler(this);
	}

	public void ResumeLogging()
	{
		lock (_syncRoot)
		{
			_supendLoggingCounter--;
			if (_supendLoggingCounter == 0)
			{
				ReconfigExistingLoggers();
			}
		}
	}

	public bool IsLoggingEnabled()
	{
		return _supendLoggingCounter <= 0;
	}

	protected virtual void OnConfigurationChanged(LoggingConfigurationChangedEventArgs e)
	{
		this.ConfigurationChanged?.Invoke(this, e);
	}

	internal ITargetWithFilterChain[] BuildLoggerConfiguration(string loggerName)
	{
		LogLevel globalLogLevel = (IsLoggingEnabled() ? GlobalThreshold : LogLevel.Off);
		return _config?.BuildLoggerConfiguration(loggerName, globalLogLevel) ?? TargetWithFilterChain.NoTargetsByLevel;
	}

	private void DisposeInternal(bool closeConfig = true)
	{
		if (_isDisposing)
		{
			return;
		}
		_isDisposing = true;
		_serviceRepository.TypeRegistered -= ServiceRepository_TypeRegistered;
		LoggerShutdown -= OnStopLogging;
		if (Monitor.TryEnter(_syncRoot, 500))
		{
			try
			{
				_configLoader.Dispose();
				LoggingConfiguration config = _config;
				if (_configLoaded && config != null)
				{
					if (closeConfig)
					{
						CloseOldConfig(config);
					}
					else
					{
						InternalLogger.Warn("Target flush timeout. One or more targets did not complete flush operation, skipping target close.");
					}
				}
			}
			finally
			{
				Monitor.Exit(_syncRoot);
				this.ConfigurationChanged = null;
			}
		}
		else
		{
			this.ConfigurationChanged = null;
		}
		InternalLogger.Info("LogFactory has been disposed.");
	}

	private void CloseOldConfig(LoggingConfiguration oldConfig)
	{
		try
		{
			oldConfig.OnConfigurationAssigned(null);
			_config = null;
			_configLoaded = true;
			ReconfigExistingLoggers();
			oldConfig.Close();
			OnConfigurationChanged(new LoggingConfigurationChangedEventArgs(null, oldConfig));
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "LogFactory failed to close NLog LoggingConfiguration.");
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			DisposeInternal();
		}
	}

	public void Shutdown()
	{
		InternalLogger.Info("LogFactory shutting down ...");
		if (!_isDisposing && _configLoaded)
		{
			lock (_syncRoot)
			{
				if (_isDisposing || !_configLoaded)
				{
					return;
				}
				Configuration = null;
				_configLoaded = true;
				ReconfigExistingLoggers();
			}
		}
		InternalLogger.Info("LogFactory shutdown completed.");
	}

	[Obsolete("Replaced by LogFactory.Setup().LoadConfigurationFromFile(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IEnumerable<string> GetCandidateConfigFilePaths()
	{
		if (_candidateConfigFilePaths != null)
		{
			return _candidateConfigFilePaths.AsReadOnly();
		}
		return _configLoader.GetDefaultCandidateConfigFilePaths();
	}

	[Obsolete("Replaced by chaining LogFactory.Setup().LoadConfigurationFromFile(). Marked obsolete on NLog 5.2")]
	internal IEnumerable<string> GetCandidateConfigFilePaths(string? filename)
	{
		if (_candidateConfigFilePaths != null)
		{
			return GetCandidateConfigFilePaths();
		}
		return _configLoader.GetDefaultCandidateConfigFilePaths(string.IsNullOrEmpty(filename) ? null : filename);
	}

	[Obsolete("Replaced by chaining LogFactory.Setup().LoadConfigurationFromFile(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void SetCandidateConfigFilePaths(IEnumerable<string> filePaths)
	{
		_candidateConfigFilePaths = new List<string>();
		if (filePaths != null)
		{
			_candidateConfigFilePaths.AddRange(filePaths);
		}
	}

	[Obsolete("Replaced by chaining LogFactory.Setup().LoadConfigurationFromFile(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ResetCandidateConfigFilePath()
	{
		_candidateConfigFilePaths = null;
	}

	private Logger GetLoggerThreadSafe(string name, Type loggerType, Func<Type, Logger?> loggerCreator)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name", "Name of logger cannot be null");
		}
		LoggerCacheKey cacheKey = new LoggerCacheKey(name, loggerType);
		lock (_syncRoot)
		{
			Logger logger = _loggerCache.Retrieve(cacheKey);
			if (logger != null)
			{
				return logger;
			}
			Logger logger2 = CreateNewLogger(loggerType, loggerCreator);
			if (logger2 == null)
			{
				cacheKey = new LoggerCacheKey(cacheKey.Name, typeof(Logger));
				logger2 = new Logger();
			}
			LoggingConfiguration? obj = _config ?? ((_loggerCache.Count == 0) ? Configuration : null);
			logger2.Initialize(name, BuildLoggerConfiguration(name), this);
			if (obj == null && _loggerCache.Count == 0)
			{
				InternalLogger.Info("NLog Configuration has not been loaded.");
			}
			_loggerCache.InsertOrUpdate(cacheKey, logger2);
			return logger2;
		}
	}

	internal Logger CreateNewLogger(Type loggerType, Func<Type, Logger?> loggerCreator)
	{
		try
		{
			Logger logger = loggerCreator(loggerType);
			if (logger != null)
			{
				return logger;
			}
			if (Logger.DefaultLoggerType.IsAssignableFrom(loggerType))
			{
				throw new NLogRuntimeException($"GetLogger / GetCurrentClassLogger with type '{loggerType}' could not create instance of NLog Logger");
			}
			if (ThrowExceptions || LogManager.ThrowExceptions)
			{
				throw new NLogRuntimeException($"GetLogger / GetCurrentClassLogger with type '{loggerType}' does not inherit from NLog Logger");
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "GetLogger / GetCurrentClassLogger. Cannot create instance of type '{0}'. It should have an default constructor.", new ReadOnlySpan<object>(new object[1] { loggerType }));
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
		return new Logger();
	}

	[Obsolete("Replaced by LogFactory.Setup().LoadConfigurationFromFile(). Marked obsolete on NLog 5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public LogFactory LoadConfiguration(string configFile)
	{
		return LoadConfiguration(configFile, optional: false);
	}

	internal LogFactory LoadConfiguration(string? configFile, bool optional)
	{
		string text = ((configFile == null || string.IsNullOrEmpty(configFile)) ? "NLog.config" : configFile);
		if (optional && string.Equals(text.Trim(), "NLog.config", StringComparison.OrdinalIgnoreCase) && _config != null)
		{
			return this;
		}
		LoggingConfiguration loggingConfiguration = _configLoader.Load(this, configFile);
		if (loggingConfiguration == null)
		{
			if (!optional)
			{
				throw new FileNotFoundException(CreateFileNotFoundMessage(configFile), text);
			}
			return this;
		}
		Configuration = loggingConfiguration;
		return this;
	}

	private string CreateFileNotFoundMessage(string? configFile)
	{
		StringBuilder stringBuilder = new StringBuilder("Failed to load NLog LoggingConfiguration.");
		try
		{
			HashSet<string> hashSet = new HashSet<string>(_configLoader.GetDefaultCandidateConfigFilePaths(configFile));
			stringBuilder.AppendLine(" Searched the following locations:");
			foreach (string item in hashSet)
			{
				stringBuilder.Append("- ");
				stringBuilder.AppendLine(item);
			}
		}
		catch (Exception arg)
		{
			InternalLogger.Debug("Failed to GetDefaultCandidateConfigFilePaths in CreateFileNotFoundMessage: {0}", arg);
		}
		return stringBuilder.ToString();
	}

	internal int ResetLoggerCache()
	{
		int count = _loggerCache.Count;
		_loggerCache.Reset();
		return count;
	}

	private static void OnLoggerShutdown(object sender, EventArgs args)
	{
		try
		{
			LogFactory._loggerShutdown?.Invoke(null, args);
		}
		catch (Exception ex)
		{
			if (ex.MustBeRethrownImmediately())
			{
				throw;
			}
			InternalLogger.Error(ex, "LogFactory failed to shutdown properly.");
		}
		finally
		{
			LogFactory._loggerShutdown = null;
			if (defaultAppEnvironment != null)
			{
				defaultAppEnvironment.ProcessExit -= OnLoggerShutdown;
			}
		}
	}

	private void OnStopLogging(object sender, EventArgs args)
	{
		try
		{
			InternalLogger.Info("AppDomain Shutting down. LogFactory closing...");
			bool closeConfig = true;
			if (PlatformDetector.IsWin32)
			{
				closeConfig = FlushInternal(TimeSpan.FromMilliseconds(1500.0), null);
			}
			DisposeInternal(closeConfig);
		}
		catch (Exception ex)
		{
			if (ex.MustBeRethrownImmediately())
			{
				throw;
			}
			InternalLogger.Error(ex, "LogFactory failed to close down.");
		}
	}
}

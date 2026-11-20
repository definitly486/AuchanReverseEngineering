using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets;

[NLogConfigurationItem]
public abstract class Target : ISupportsInitialize, IInternalLoggerContext, IDisposable
{
	internal string? _tostring;

	private Layout[] _allLayouts = ArrayHelper.Empty<Layout>();

	private bool _allLayoutsAreThreadAgnostic;

	private bool _anyLayoutsAreThreadAgnosticImmutable;

	private bool _scannedForLayouts;

	private Exception? _initializeException;

	private string _name = string.Empty;

	private bool? _optimizeBufferReuse;

	internal bool? _layoutWithLock;

	private volatile bool _isInitialized;

	internal readonly ReusableBuilderCreator ReusableLayoutBuilder = new ReusableBuilderCreator();

	private StringBuilderPool? _precalculateStringBuilderPool;

	internal StackTraceUsage StackTraceUsage { get; private set; }

	internal Exception? InitializeException => _initializeException;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
			_tostring = null;
		}
	}

	[Obsolete("No longer used, and always returns true. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool OptimizeBufferReuse
	{
		get
		{
			return _optimizeBufferReuse ?? true;
		}
		set
		{
			_optimizeBufferReuse = (value ? new bool?(true) : ((bool?)null));
		}
	}

	[Obsolete("Temporary workaround for broken Layout Renderers that are not threadsafe. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool LayoutWithLock
	{
		get
		{
			return _layoutWithLock == true;
		}
		set
		{
			_layoutWithLock = value;
		}
	}

	protected object SyncRoot { get; } = new object();

	protected LoggingConfiguration? LoggingConfiguration { get; private set; }

	LogFactory? IInternalLoggerContext.LogFactory => LoggingConfiguration?.LogFactory;

	protected bool IsInitialized
	{
		get
		{
			if (_isInitialized)
			{
				return true;
			}
			lock (SyncRoot)
			{
				return _isInitialized;
			}
		}
	}

	void ISupportsInitialize.Initialize(LoggingConfiguration? configuration)
	{
		lock (SyncRoot)
		{
			bool isInitialized = _isInitialized;
			Initialize(configuration);
			if (isInitialized && configuration != null)
			{
				FindAllLayouts();
			}
		}
	}

	void ISupportsInitialize.Close()
	{
		Close();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Flush(AsyncContinuation asyncContinuation)
	{
		Guard.ThrowIfNull(asyncContinuation, "asyncContinuation");
		asyncContinuation = NLog.Common.AsyncHelpers.PreventMultipleCalls(asyncContinuation);
		if (Monitor.TryEnter(SyncRoot, 15000))
		{
			try
			{
				if (!IsInitialized)
				{
					asyncContinuation(null);
					return;
				}
				try
				{
					FlushAsync(asyncContinuation);
					return;
				}
				catch (Exception exception)
				{
					if (ExceptionMustBeRethrown(exception, "Flush"))
					{
						throw;
					}
					asyncContinuation(exception);
					return;
				}
			}
			finally
			{
				Monitor.Exit(SyncRoot);
			}
		}
		asyncContinuation(new NLogRuntimeException($"Target {this} failed to flush after lock timeout."));
	}

	public void PrecalculateVolatileLayouts(LogEventInfo logEvent)
	{
		if ((!_allLayoutsAreThreadAgnostic || (_anyLayoutsAreThreadAgnosticImmutable && !logEvent.IsLogEventThreadAgnosticImmutable())) && IsInitialized)
		{
			if (_layoutWithLock == true)
			{
				PrecalculateVolatileLayoutsWithLock(logEvent);
			}
			else
			{
				PrecalculateVolatileLayoutsConcurrent(logEvent);
			}
		}
	}

	private void PrecalculateVolatileLayoutsConcurrent(LogEventInfo logEvent)
	{
		if (_precalculateStringBuilderPool == null)
		{
			Interlocked.CompareExchange(ref _precalculateStringBuilderPool, new StringBuilderPool(Environment.ProcessorCount * 2), null);
		}
		StringBuilderPool.ItemHolder itemHolder = _precalculateStringBuilderPool.Acquire();
		try
		{
			Layout[] allLayouts = _allLayouts;
			foreach (Layout obj in allLayouts)
			{
				itemHolder.Item.ClearBuilder();
				obj.PrecalculateBuilder(logEvent, itemHolder.Item);
			}
		}
		finally
		{
			((IDisposable)itemHolder/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private void PrecalculateVolatileLayoutsWithLock(LogEventInfo logEvent)
	{
		lock (SyncRoot)
		{
			ReusableObjectCreator<System.Text.StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
			try
			{
				Layout[] allLayouts = _allLayouts;
				foreach (Layout obj in allLayouts)
				{
					lockOject.Result.ClearBuilder();
					obj.PrecalculateBuilder(logEvent, lockOject.Result);
				}
			}
			finally
			{
				((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}

	public override string ToString()
	{
		return _tostring ?? (_tostring = GenerateTargetToString(targetWrapper: false));
	}

	internal string GenerateTargetToString(bool targetWrapper, string? targetName = null)
	{
		TargetAttribute firstCustomAttribute = GetType().GetFirstCustomAttribute<TargetAttribute>();
		string text = (firstCustomAttribute?.Name ?? GetType().Name).Trim();
		targetWrapper = targetWrapper || (firstCustomAttribute != null && firstCustomAttribute.IsCompound) || (firstCustomAttribute?.IsWrapper ?? false);
		if (!targetWrapper && text.IndexOf("Target", StringComparison.OrdinalIgnoreCase) < 0)
		{
			text += "Target";
		}
		targetName = targetName ?? Name;
		if (string.IsNullOrEmpty(targetName))
		{
			if (!targetWrapper)
			{
				return text + "([unnamed])";
			}
			return text;
		}
		return text + "(Name=" + targetName + ")";
	}

	public void WriteAsyncLogEvent(AsyncLogEventInfo logEvent)
	{
		if (!IsInitialized)
		{
			lock (SyncRoot)
			{
				logEvent.Continuation(null);
				return;
			}
		}
		if (_initializeException != null)
		{
			lock (SyncRoot)
			{
				WriteFailedNotInitialized(logEvent, _initializeException);
				return;
			}
		}
		AsyncContinuation asyncContinuation = NLog.Common.AsyncHelpers.PreventMultipleCalls(logEvent.Continuation);
		AsyncLogEventInfo logEvent2 = logEvent.LogEvent.WithContinuation(asyncContinuation);
		try
		{
			WriteAsyncThreadSafe(logEvent2);
		}
		catch (Exception exception)
		{
			if (ExceptionMustBeRethrown(exception, "WriteAsyncLogEvent"))
			{
				throw;
			}
			logEvent2.Continuation(exception);
		}
	}

	public void WriteAsyncLogEvents(params AsyncLogEventInfo[] logEvents)
	{
		if (logEvents != null && logEvents.Length != 0)
		{
			WriteAsyncLogEvents((IList<AsyncLogEventInfo>)logEvents);
		}
	}

	public void WriteAsyncLogEvents(IList<AsyncLogEventInfo> logEvents)
	{
		if (logEvents == null || logEvents.Count == 0)
		{
			return;
		}
		if (!IsInitialized)
		{
			lock (SyncRoot)
			{
				for (int i = 0; i < logEvents.Count; i++)
				{
					logEvents[i].Continuation(null);
				}
				return;
			}
		}
		if (_initializeException != null)
		{
			lock (SyncRoot)
			{
				for (int j = 0; j < logEvents.Count; j++)
				{
					WriteFailedNotInitialized(logEvents[j], _initializeException);
				}
				return;
			}
		}
		for (int k = 0; k < logEvents.Count; k++)
		{
			logEvents[k] = logEvents[k].LogEvent.WithContinuation(NLog.Common.AsyncHelpers.PreventMultipleCalls(logEvents[k].Continuation));
		}
		try
		{
			WriteAsyncThreadSafe(logEvents);
		}
		catch (Exception exception)
		{
			if (ExceptionMustBeRethrown(exception, "WriteAsyncLogEvents"))
			{
				throw;
			}
			for (int l = 0; l < logEvents.Count; l++)
			{
				logEvents[l].Continuation(exception);
			}
		}
	}

	protected virtual void WriteFailedNotInitialized(AsyncLogEventInfo logEvent, Exception initializeException)
	{
		if (!_scannedForLayouts)
		{
			_scannedForLayouts = true;
			InternalLogger.Error(_initializeException, "{0}: No output because target failed initialize.", new ReadOnlySpan<object>(new object[1] { this }));
		}
		else
		{
			InternalLogger.Debug("{0}: No output because target failed initialize. {1} {2}", this, _initializeException?.GetType(), _initializeException?.Message);
		}
		NLogRuntimeException exception = new NLogRuntimeException($"Target {this} failed to initialize.", initializeException);
		logEvent.Continuation(exception);
	}

	internal void Initialize(LoggingConfiguration? configuration)
	{
		lock (SyncRoot)
		{
			LoggingConfiguration = configuration;
			if (IsInitialized)
			{
				return;
			}
			try
			{
				_scannedForLayouts = false;
				InitializeTarget();
				_initializeException = null;
				if (!_scannedForLayouts)
				{
					InternalLogger.Debug("{0}: InitializeTarget is done but not scanned For Layouts", this);
					FindAllLayouts();
				}
			}
			catch (NLogDependencyResolveException initializeException)
			{
				NLogDependencyResolveException exception = (NLogDependencyResolveException)(_initializeException = initializeException);
				_scannedForLayouts = false;
				if (ExceptionMustBeRethrown(exception, "Initialize"))
				{
					throw;
				}
			}
			catch (Exception initializeException2)
			{
				Exception ex = (_initializeException = initializeException2);
				_scannedForLayouts = false;
				if (ExceptionMustBeRethrown(ex, "Initialize"))
				{
					throw;
				}
				LogFactory logFactory = LoggingConfiguration?.LogFactory ?? LogManager.LogFactory;
				if (logFactory.ThrowConfigExceptions ?? logFactory.ThrowExceptions)
				{
					throw new NLogConfigurationException($"Error during initialization of target {this}", ex);
				}
			}
			finally
			{
				_isInitialized = true;
			}
		}
	}

	internal void Close()
	{
		lock (SyncRoot)
		{
			LoggingConfiguration = null;
			if (!IsInitialized)
			{
				return;
			}
			_isInitialized = false;
			try
			{
				if (_initializeException == null)
				{
					InternalLogger.Debug("{0}: Closing...", this);
					CloseTarget();
					InternalLogger.Debug("{0}: Closed.", this);
				}
			}
			catch (Exception exception)
			{
				if (ExceptionMustBeRethrown(exception, "Close"))
				{
					throw;
				}
			}
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && _isInitialized)
		{
			_isInitialized = false;
			if (_initializeException == null)
			{
				CloseTarget();
			}
		}
	}

	protected virtual void InitializeTarget()
	{
		FindAllLayouts();
	}

	private void FindAllLayouts()
	{
		List<Layout> list = ObjectGraphScanner.FindReachableObjects<Layout>(ConfigurationItemFactory.Default, aggressiveSearch: false, new object[1] { this });
		InternalLogger.Trace("{0} has {1} layouts", this, list.Count);
		_allLayoutsAreThreadAgnostic = list.All((Layout layout) => layout.ThreadAgnostic);
		_anyLayoutsAreThreadAgnosticImmutable = _allLayoutsAreThreadAgnostic && list.Any((Layout layout) => layout.ThreadAgnosticImmutable);
		StackTraceUsage stackTraceUsage = list.Aggregate(StackTraceUsage.None, (StackTraceUsage agg, Layout layout) => agg | layout.StackTraceUsage);
		StackTraceUsage = stackTraceUsage | ((this as IUsesStackTrace)?.StackTraceUsage ?? StackTraceUsage.None);
		_allLayouts = list.Where((Layout l) => !l.ThreadAgnostic || l.ThreadAgnosticImmutable || !(l is SimpleLayout)).Distinct(SingleItemOptimizedHashSet<Layout>.ReferenceEqualityComparer.Default).ToArray();
		_scannedForLayouts = true;
	}

	protected virtual void CloseTarget()
	{
	}

	protected virtual void FlushAsync(AsyncContinuation asyncContinuation)
	{
		asyncContinuation(null);
	}

	protected virtual void Write(LogEventInfo logEvent)
	{
	}

	protected virtual void Write(AsyncLogEventInfo logEvent)
	{
		try
		{
			Write(logEvent.LogEvent);
			logEvent.Continuation(null);
		}
		catch (Exception exception)
		{
			if (ExceptionMustBeRethrown(exception, "Write"))
			{
				throw;
			}
			logEvent.Continuation(exception);
		}
	}

	protected virtual void WriteAsyncThreadSafe(AsyncLogEventInfo logEvent)
	{
		lock (SyncRoot)
		{
			if (!IsInitialized)
			{
				logEvent.Continuation(null);
			}
			else
			{
				Write(logEvent);
			}
		}
	}

	protected virtual void Write(IList<AsyncLogEventInfo> logEvents)
	{
		for (int i = 0; i < logEvents.Count; i++)
		{
			Write(logEvents[i]);
		}
	}

	protected virtual void WriteAsyncThreadSafe(IList<AsyncLogEventInfo> logEvents)
	{
		lock (SyncRoot)
		{
			if (!IsInitialized)
			{
				for (int i = 0; i < logEvents.Count; i++)
				{
					logEvents[i].Continuation(null);
				}
			}
			else
			{
				Write(logEvents);
			}
		}
	}

	[Obsolete("Logger.Trace(logEvent) now automatically captures the logEvent Properties. Marked obsolete on NLog 4.6")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected void MergeEventProperties(LogEventInfo logEvent)
	{
		if (logEvent.Parameters == null || logEvent.Parameters.Length == 0)
		{
			return;
		}
		for (int i = 0; i < logEvent.Parameters.Length; i++)
		{
			if (!(logEvent.Parameters[i] is LogEventInfo { HasProperties: not false } logEventInfo))
			{
				continue;
			}
			foreach (object key in logEventInfo.Properties.Keys)
			{
				logEvent.Properties.Add(key, logEventInfo.Properties[key]);
			}
			logEventInfo.Properties.Clear();
		}
	}

	protected string RenderLogEvent(Layout? layout, LogEventInfo logEvent)
	{
		if (layout == null || logEvent == null)
		{
			return string.Empty;
		}
		if (layout is IStringValueRenderer stringValueRenderer)
		{
			string formattedString = stringValueRenderer.GetFormattedString(logEvent);
			if (formattedString != null)
			{
				return formattedString;
			}
		}
		if (TryGetCachedValue(layout, logEvent, out object value))
		{
			return value?.ToString() ?? string.Empty;
		}
		ReusableObjectCreator<System.Text.StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
		try
		{
			return layout.RenderAllocateBuilder(logEvent, lockOject.Result);
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	protected T? RenderLogEvent<T>(Layout<T>? layout, LogEventInfo logEvent, T? defaultValue = default(T?))
	{
		if (layout == null)
		{
			return defaultValue;
		}
		if (layout.IsFixed)
		{
			return layout.FixedValue;
		}
		if (logEvent == null)
		{
			return defaultValue;
		}
		if (TryGetCachedValue(layout, logEvent, out object value))
		{
			if (value != null)
			{
				return (T)value;
			}
			return defaultValue;
		}
		ReusableObjectCreator<System.Text.StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
		try
		{
			return layout.RenderTypedValue(logEvent, lockOject.Result, defaultValue);
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	protected T ResolveService<T>() where T : class
	{
		return LoggingConfiguration.GetServiceProvider().ResolveService<T>(IsInitialized);
	}

	internal bool ExceptionMustBeRethrown(Exception exception, [CallerMemberName] string? callerMemberName = null)
	{
		return exception.MustBeRethrown(this, callerMemberName);
	}

	private static bool TryGetCachedValue(Layout layout, LogEventInfo logEvent, out object? value)
	{
		if (layout.ThreadAgnostic && !layout.ThreadAgnosticImmutable)
		{
			value = null;
			return false;
		}
		return logEvent.TryGetCachedLayoutValue(layout, out value);
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(string name) where T : Target
	{
		Type typeFromHandle = typeof(T);
		Register(name, typeFromHandle);
	}

	[Obsolete("Instead use LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Register(string name, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] Type targetType)
	{
		ConfigurationItemFactory.Default.GetTargetFactory().RegisterDefinition(name, targetType);
	}
}

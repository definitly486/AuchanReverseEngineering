using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;

namespace CsvHelper;

public class CsvReader : IReader, IReaderRow, IDisposable
{
	[CompilerGenerated]
	private sealed class _003CGetRecordsAsync_003Ed__91<T> : IAsyncEnumerable<T>, IAsyncEnumerator<T>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine where T : notnull
	{
		public int _003C_003E1__state;

		public AsyncIteratorMethodBuilder _003C_003Et__builder;

		public ManualResetValueTaskSourceCore<bool> _003C_003Ev__promiseOfValueOrEnd;

		private T _003C_003E2__current;

		private bool _003C_003Ew__disposeMode;

		private CancellationTokenSource _003C_003Ex__combinedTokens;

		private int _003C_003El__initialThreadId;

		public CsvReader _003C_003E4__this;

		private CancellationToken cancellationToken;

		public CancellationToken _003C_003E3__cancellationToken;

		private Func<T> _003Cread_003E5__2;

		private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

		T IAsyncEnumerator<T>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetRecordsAsync_003Ed__91(int _003C_003E1__state)
		{
			_003C_003Et__builder = AsyncIteratorMethodBuilder.Create();
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			CsvReader csvReader = _003C_003E4__this;
			try
			{
				ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter awaiter;
				T val;
				switch (num)
				{
				default:
					if (_003C_003Ew__disposeMode)
					{
						break;
					}
					num = (_003C_003E1__state = -1);
					if (csvReader.disposed)
					{
						throw new ObjectDisposedException("CsvReader", "GetRecords<T>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
					}
					if (csvReader.hasHeaderRecord && csvReader.headerRecord == null)
					{
						_003C_003E2__current = default(T);
						awaiter = csvReader.ReadAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetRecordsAsync_003Ed__91<T> stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00e0;
					}
					goto IL_0102;
				case 0:
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e0;
				case -4:
					num = (_003C_003E1__state = -1);
					if (_003C_003Ew__disposeMode)
					{
						break;
					}
					goto IL_01cd;
				case 1:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_023a;
					}
					IL_023a:
					if (!awaiter.GetResult())
					{
						break;
					}
					cancellationToken.ThrowIfCancellationRequested();
					try
					{
						if (_003Cread_003E5__2 == null)
						{
							_003Cread_003E5__2 = csvReader.recordManager.Value.GetReadDelegate<T>(typeof(T));
						}
						val = _003Cread_003E5__2();
					}
					catch (Exception ex)
					{
						CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(csvReader.context, "An unexpected error occurred.", ex);
						ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
						ReadingExceptionOccurred? readingExceptionOccurred = csvReader.readingExceptionOccurred;
						if (readingExceptionOccurred == null || readingExceptionOccurred(args))
						{
							if (ex is CsvHelperException)
							{
								throw;
							}
							throw ex2;
						}
						goto IL_01cd;
					}
					_003C_003E2__current = val;
					num = (_003C_003E1__state = -4);
					goto IL_02e6;
					IL_0102:
					_003Cread_003E5__2 = null;
					goto IL_01cd;
					IL_00e0:
					if (!awaiter.GetResult())
					{
						_003C_003Ew__disposeMode = true;
						break;
					}
					csvReader.ReadHeader();
					csvReader.ValidateHeader<T>();
					goto IL_0102;
					IL_01cd:
					_003C_003E2__current = default(T);
					awaiter = csvReader.ReadAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CGetRecordsAsync_003Ed__91<T> stateMachine = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
						return;
					}
					goto IL_023a;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cread_003E5__2 = null;
				if (_003C_003Ex__combinedTokens != null)
				{
					_003C_003Ex__combinedTokens.Dispose();
					_003C_003Ex__combinedTokens = null;
				}
				_003C_003E2__current = default(T);
				_003C_003Et__builder.Complete();
				_003C_003Ev__promiseOfValueOrEnd.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cread_003E5__2 = null;
			if (_003C_003Ex__combinedTokens != null)
			{
				_003C_003Ex__combinedTokens.Dispose();
				_003C_003Ex__combinedTokens = null;
			}
			_003C_003E2__current = default(T);
			_003C_003Et__builder.Complete();
			_003C_003Ev__promiseOfValueOrEnd.SetResult(result: false);
			return;
			IL_02e6:
			_003C_003Ev__promiseOfValueOrEnd.SetResult(result: true);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}

		[DebuggerHidden]
		IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CGetRecordsAsync_003Ed__91<T> _003CGetRecordsAsync_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = -3;
				_003C_003Et__builder = AsyncIteratorMethodBuilder.Create();
				_003C_003Ew__disposeMode = false;
				_003CGetRecordsAsync_003Ed__ = this;
			}
			else
			{
				_003CGetRecordsAsync_003Ed__ = new _003CGetRecordsAsync_003Ed__91<T>(-3)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			if (_003C_003E3__cancellationToken.Equals(default(CancellationToken)))
			{
				_003CGetRecordsAsync_003Ed__.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(_003C_003E3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				_003CGetRecordsAsync_003Ed__.cancellationToken = _003C_003E3__cancellationToken;
			}
			else
			{
				_003C_003Ex__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(_003C_003E3__cancellationToken, cancellationToken);
				_003CGetRecordsAsync_003Ed__.cancellationToken = _003C_003Ex__combinedTokens.Token;
			}
			return _003CGetRecordsAsync_003Ed__;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<T>.MoveNextAsync()
		{
			if (_003C_003E1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			_003C_003Ev__promiseOfValueOrEnd.Reset();
			_003CGetRecordsAsync_003Ed__91<T> stateMachine = this;
			_003C_003Et__builder.MoveNext(ref stateMachine);
			short version = _003C_003Ev__promiseOfValueOrEnd.Version;
			if (_003C_003Ev__promiseOfValueOrEnd.GetStatus(version) == ValueTaskSourceStatus.Succeeded)
			{
				return new ValueTask<bool>(_003C_003Ev__promiseOfValueOrEnd.GetResult(version));
			}
			return new ValueTask<bool>(this, version);
		}

		[DebuggerHidden]
		bool IValueTaskSource<bool>.GetResult(short token)
		{
			return _003C_003Ev__promiseOfValueOrEnd.GetResult(token);
		}

		[DebuggerHidden]
		ValueTaskSourceStatus IValueTaskSource<bool>.GetStatus(short token)
		{
			return _003C_003Ev__promiseOfValueOrEnd.GetStatus(token);
		}

		[DebuggerHidden]
		void IValueTaskSource<bool>.OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_003C_003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
		}

		[DebuggerHidden]
		void IValueTaskSource.GetResult(short token)
		{
			_003C_003Ev__promiseOfValueOrEnd.GetResult(token);
		}

		[DebuggerHidden]
		ValueTaskSourceStatus IValueTaskSource.GetStatus(short token)
		{
			return _003C_003Ev__promiseOfValueOrEnd.GetStatus(token);
		}

		[DebuggerHidden]
		void IValueTaskSource.OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_003C_003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
		}

		[DebuggerHidden]
		ValueTask IAsyncDisposable.DisposeAsync()
		{
			if (_003C_003E1__state >= -1)
			{
				throw new NotSupportedException();
			}
			if (_003C_003E1__state == -2)
			{
				return default(ValueTask);
			}
			_003C_003Ew__disposeMode = true;
			_003C_003Ev__promiseOfValueOrEnd.Reset();
			_003CGetRecordsAsync_003Ed__91<T> stateMachine = this;
			_003C_003Et__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, _003C_003Ev__promiseOfValueOrEnd.Version);
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetRecordsAsync_003Ed__93 : IAsyncEnumerable<object>, IAsyncEnumerator<object>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncIteratorMethodBuilder _003C_003Et__builder;

		public ManualResetValueTaskSourceCore<bool> _003C_003Ev__promiseOfValueOrEnd;

		private object _003C_003E2__current;

		private bool _003C_003Ew__disposeMode;

		private CancellationTokenSource _003C_003Ex__combinedTokens;

		private int _003C_003El__initialThreadId;

		public CsvReader _003C_003E4__this;

		private Type type;

		public Type _003C_003E3__type;

		private CancellationToken cancellationToken;

		public CancellationToken _003C_003E3__cancellationToken;

		private Func<object> _003Cread_003E5__2;

		private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

		object IAsyncEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetRecordsAsync_003Ed__93(int _003C_003E1__state)
		{
			_003C_003Et__builder = AsyncIteratorMethodBuilder.Create();
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			CsvReader csvReader = _003C_003E4__this;
			try
			{
				ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter awaiter;
				object obj;
				switch (num)
				{
				default:
					if (_003C_003Ew__disposeMode)
					{
						break;
					}
					num = (_003C_003E1__state = -1);
					if (csvReader.disposed)
					{
						throw new ObjectDisposedException("CsvReader", "GetRecords<object>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
					}
					if (csvReader.hasHeaderRecord && csvReader.headerRecord == null)
					{
						_003C_003E2__current = null;
						awaiter = csvReader.ReadAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetRecordsAsync_003Ed__93 stateMachine = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_00db;
					}
					goto IL_0103;
				case 0:
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00db;
				case -4:
					num = (_003C_003E1__state = -1);
					if (_003C_003Ew__disposeMode)
					{
						break;
					}
					goto IL_01ca;
				case 1:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0232;
					}
					IL_0232:
					if (!awaiter.GetResult())
					{
						break;
					}
					cancellationToken.ThrowIfCancellationRequested();
					try
					{
						if (_003Cread_003E5__2 == null)
						{
							_003Cread_003E5__2 = csvReader.recordManager.Value.GetReadDelegate<object>(type);
						}
						obj = _003Cread_003E5__2();
					}
					catch (Exception ex)
					{
						CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(csvReader.context, "An unexpected error occurred.", ex);
						ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
						ReadingExceptionOccurred? readingExceptionOccurred = csvReader.readingExceptionOccurred;
						if (readingExceptionOccurred == null || readingExceptionOccurred(args))
						{
							if (ex is CsvHelperException)
							{
								throw;
							}
							throw ex2;
						}
						goto IL_01ca;
					}
					_003C_003E2__current = obj;
					num = (_003C_003E1__state = -4);
					goto IL_02d4;
					IL_0103:
					_003Cread_003E5__2 = null;
					goto IL_01ca;
					IL_00db:
					if (!awaiter.GetResult())
					{
						_003C_003Ew__disposeMode = true;
						break;
					}
					csvReader.ReadHeader();
					csvReader.ValidateHeader(type);
					goto IL_0103;
					IL_01ca:
					_003C_003E2__current = null;
					awaiter = csvReader.ReadAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CGetRecordsAsync_003Ed__93 stateMachine = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
						return;
					}
					goto IL_0232;
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cread_003E5__2 = null;
				if (_003C_003Ex__combinedTokens != null)
				{
					_003C_003Ex__combinedTokens.Dispose();
					_003C_003Ex__combinedTokens = null;
				}
				_003C_003E2__current = null;
				_003C_003Et__builder.Complete();
				_003C_003Ev__promiseOfValueOrEnd.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cread_003E5__2 = null;
			if (_003C_003Ex__combinedTokens != null)
			{
				_003C_003Ex__combinedTokens.Dispose();
				_003C_003Ex__combinedTokens = null;
			}
			_003C_003E2__current = null;
			_003C_003Et__builder.Complete();
			_003C_003Ev__promiseOfValueOrEnd.SetResult(result: false);
			return;
			IL_02d4:
			_003C_003Ev__promiseOfValueOrEnd.SetResult(result: true);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}

		[DebuggerHidden]
		IAsyncEnumerator<object> IAsyncEnumerable<object>.GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CGetRecordsAsync_003Ed__93 _003CGetRecordsAsync_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = -3;
				_003C_003Et__builder = AsyncIteratorMethodBuilder.Create();
				_003C_003Ew__disposeMode = false;
				_003CGetRecordsAsync_003Ed__ = this;
			}
			else
			{
				_003CGetRecordsAsync_003Ed__ = new _003CGetRecordsAsync_003Ed__93(-3)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CGetRecordsAsync_003Ed__.type = _003C_003E3__type;
			if (_003C_003E3__cancellationToken.Equals(default(CancellationToken)))
			{
				_003CGetRecordsAsync_003Ed__.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(_003C_003E3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				_003CGetRecordsAsync_003Ed__.cancellationToken = _003C_003E3__cancellationToken;
			}
			else
			{
				_003C_003Ex__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(_003C_003E3__cancellationToken, cancellationToken);
				_003CGetRecordsAsync_003Ed__.cancellationToken = _003C_003Ex__combinedTokens.Token;
			}
			return _003CGetRecordsAsync_003Ed__;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<object>.MoveNextAsync()
		{
			if (_003C_003E1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			_003C_003Ev__promiseOfValueOrEnd.Reset();
			_003CGetRecordsAsync_003Ed__93 stateMachine = this;
			_003C_003Et__builder.MoveNext(ref stateMachine);
			short version = _003C_003Ev__promiseOfValueOrEnd.Version;
			if (_003C_003Ev__promiseOfValueOrEnd.GetStatus(version) == ValueTaskSourceStatus.Succeeded)
			{
				return new ValueTask<bool>(_003C_003Ev__promiseOfValueOrEnd.GetResult(version));
			}
			return new ValueTask<bool>(this, version);
		}

		[DebuggerHidden]
		bool IValueTaskSource<bool>.GetResult(short token)
		{
			return _003C_003Ev__promiseOfValueOrEnd.GetResult(token);
		}

		[DebuggerHidden]
		ValueTaskSourceStatus IValueTaskSource<bool>.GetStatus(short token)
		{
			return _003C_003Ev__promiseOfValueOrEnd.GetStatus(token);
		}

		[DebuggerHidden]
		void IValueTaskSource<bool>.OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_003C_003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
		}

		[DebuggerHidden]
		void IValueTaskSource.GetResult(short token)
		{
			_003C_003Ev__promiseOfValueOrEnd.GetResult(token);
		}

		[DebuggerHidden]
		ValueTaskSourceStatus IValueTaskSource.GetStatus(short token)
		{
			return _003C_003Ev__promiseOfValueOrEnd.GetStatus(token);
		}

		[DebuggerHidden]
		void IValueTaskSource.OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			_003C_003Ev__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
		}

		[DebuggerHidden]
		ValueTask IAsyncDisposable.DisposeAsync()
		{
			if (_003C_003E1__state >= -1)
			{
				throw new NotSupportedException();
			}
			if (_003C_003E1__state == -2)
			{
				return default(ValueTask);
			}
			_003C_003Ew__disposeMode = true;
			_003C_003Ev__promiseOfValueOrEnd.Reset();
			_003CGetRecordsAsync_003Ed__93 stateMachine = this;
			_003C_003Et__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, _003C_003Ev__promiseOfValueOrEnd.Version);
		}
	}

	private readonly Lazy<RecordManager> recordManager;

	private readonly bool detectColumnCountChanges;

	private readonly Dictionary<string, List<int>> namedIndexes = new Dictionary<string, List<int>>();

	private readonly Dictionary<string, (string, int)> namedIndexCache = new Dictionary<string, (string, int)>();

	private readonly Dictionary<Type, TypeConverterOptions> typeConverterOptionsCache = new Dictionary<Type, TypeConverterOptions>();

	private readonly MemberMapData reusableMemberMapData = new MemberMapData(null);

	private readonly bool hasHeaderRecord;

	private readonly HeaderValidated? headerValidated;

	private readonly ShouldSkipRecord? shouldSkipRecord;

	private readonly ReadingExceptionOccurred? readingExceptionOccurred;

	private readonly CultureInfo cultureInfo;

	private readonly bool ignoreBlankLines;

	private readonly MissingFieldFound? missingFieldFound;

	private readonly bool includePrivateMembers;

	private readonly PrepareHeaderForMatch prepareHeaderForMatch;

	private CsvContext context;

	private bool disposed;

	private IParser parser;

	private int prevColumnCount;

	private int currentIndex = -1;

	private bool hasBeenRead;

	private string[]? headerRecord;

	public virtual int ColumnCount => parser.Count;

	public virtual int CurrentIndex => currentIndex;

	public virtual string[]? HeaderRecord => headerRecord;

	public virtual CsvContext Context => context;

	public virtual IReaderConfiguration Configuration { get; private set; }

	public virtual IParser Parser => parser;

	public virtual string? this[int index]
	{
		get
		{
			CheckHasBeenRead();
			return GetField(index);
		}
	}

	public virtual string? this[string name]
	{
		get
		{
			CheckHasBeenRead();
			return GetField(name);
		}
	}

	public virtual string? this[string name, int index]
	{
		get
		{
			CheckHasBeenRead();
			return GetField(name, index);
		}
	}

	public CsvReader(TextReader reader, CultureInfo culture, bool leaveOpen = false)
		: this(new CsvParser(reader, culture, leaveOpen))
	{
	}

	public CsvReader(TextReader reader, IReaderConfiguration configuration, bool leaveOpen = false)
		: this(new CsvParser(reader, configuration, leaveOpen))
	{
	}

	public CsvReader(IParser parser)
	{
		Configuration = (parser.Configuration as IReaderConfiguration) ?? throw new ConfigurationException("The IParser configuration must implement IReaderConfiguration to be used in CsvReader.");
		this.parser = parser ?? throw new ArgumentNullException("parser");
		context = parser.Context ?? throw new InvalidOperationException("For IParser to be used in CsvReader, Context must also implement CsvContext.");
		context.Reader = this;
		recordManager = new Lazy<RecordManager>(() => ObjectResolver.Current.Resolve<RecordManager>(new object[1] { this }));
		cultureInfo = Configuration.CultureInfo;
		detectColumnCountChanges = Configuration.DetectColumnCountChanges;
		hasHeaderRecord = Configuration.HasHeaderRecord;
		headerValidated = Configuration.HeaderValidated;
		ignoreBlankLines = Configuration.IgnoreBlankLines;
		includePrivateMembers = Configuration.IncludePrivateMembers;
		missingFieldFound = Configuration.MissingFieldFound;
		prepareHeaderForMatch = Configuration.PrepareHeaderForMatch;
		readingExceptionOccurred = Configuration.ReadingExceptionOccurred;
		shouldSkipRecord = Configuration.ShouldSkipRecord;
	}

	public virtual bool ReadHeader()
	{
		if (!hasHeaderRecord)
		{
			throw new ReaderException(context, "Configuration.HasHeaderRecord is false.");
		}
		headerRecord = parser.Record;
		ParseNamedIndexes();
		return headerRecord != null;
	}

	public virtual void ValidateHeader<T>()
	{
		ValidateHeader(typeof(T));
	}

	public virtual void ValidateHeader(Type type)
	{
		if (!hasHeaderRecord)
		{
			throw new InvalidOperationException("Validation can't be performed on a the header if no header exists. HasHeaderRecord can't be false.");
		}
		CheckHasBeenRead();
		if (headerRecord == null)
		{
			throw new InvalidOperationException("The header must be read before it can be validated.");
		}
		if (context.Maps[type] == null)
		{
			context.Maps.Add(context.AutoMap(type));
		}
		ClassMap map = context.Maps[type];
		List<InvalidHeader> list = new List<InvalidHeader>();
		ValidateHeader(map, list);
		HeaderValidatedArgs args = new HeaderValidatedArgs(list.ToArray(), context);
		headerValidated?.Invoke(args);
	}

	protected virtual void ValidateHeader(ClassMap map, List<InvalidHeader> invalidHeaders)
	{
		foreach (ParameterMap parameterMap in map.ParameterMaps)
		{
			if (!parameterMap.Data.Ignore && !parameterMap.Data.IsConstantSet && (!parameterMap.Data.IsIndexSet || parameterMap.Data.IsNameSet))
			{
				if (parameterMap.ConstructorTypeMap != null)
				{
					ValidateHeader(parameterMap.ConstructorTypeMap, invalidHeaders);
				}
				else if (parameterMap.ReferenceMap != null)
				{
					ValidateHeader(parameterMap.ReferenceMap.Data.Mapping, invalidHeaders);
				}
				else if (GetFieldIndex(parameterMap.Data.Names, parameterMap.Data.NameIndex, isTryGet: true) == -1 && !parameterMap.Data.IsOptional)
				{
					invalidHeaders.Add(new InvalidHeader
					{
						Index = parameterMap.Data.NameIndex,
						Names = parameterMap.Data.Names.ToList()
					});
				}
			}
		}
		foreach (MemberMap memberMap in map.MemberMaps)
		{
			if (!memberMap.Data.Ignore && CanRead(memberMap) && memberMap.Data.ReadingConvertExpression == null && !memberMap.Data.IsConstantSet && (!memberMap.Data.IsIndexSet || memberMap.Data.IsNameSet) && GetFieldIndex(memberMap.Data.Names, memberMap.Data.NameIndex, isTryGet: true) == -1 && !memberMap.Data.IsOptional)
			{
				invalidHeaders.Add(new InvalidHeader
				{
					Index = memberMap.Data.NameIndex,
					Names = memberMap.Data.Names.ToList()
				});
			}
		}
		foreach (MemberReferenceMap referenceMap in map.ReferenceMaps)
		{
			if (CanRead(referenceMap))
			{
				ValidateHeader(referenceMap.Data.Mapping, invalidHeaders);
			}
		}
	}

	public virtual bool Read()
	{
		bool flag;
		ShouldSkipRecord? obj;
		do
		{
			flag = parser.Read();
			hasBeenRead = true;
			if (!flag)
			{
				break;
			}
			obj = shouldSkipRecord;
		}
		while (obj != null && obj(new ShouldSkipRecordArgs(this)));
		currentIndex = -1;
		if (detectColumnCountChanges && flag)
		{
			if (prevColumnCount > 0 && prevColumnCount != parser.Count)
			{
				BadDataException ex = new BadDataException(string.Empty, parser.RawRecord, context, "An inconsistent number of columns has been detected.");
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex);
				ReadingExceptionOccurred? obj2 = readingExceptionOccurred;
				if (obj2 == null || obj2(args))
				{
					throw ex;
				}
			}
			prevColumnCount = parser.Count;
		}
		return flag;
	}

	public virtual async Task<bool> ReadAsync()
	{
		bool flag;
		do
		{
			flag = await parser.ReadAsync().ConfigureAwait(continueOnCapturedContext: false);
			hasBeenRead = true;
		}
		while (flag && (shouldSkipRecord?.Invoke(new ShouldSkipRecordArgs(this)) ?? false));
		currentIndex = -1;
		if (detectColumnCountChanges && flag)
		{
			if (prevColumnCount > 0 && prevColumnCount != parser.Count)
			{
				BadDataException ex = new BadDataException(string.Empty, parser.RawRecord, context, "An inconsistent number of columns has been detected.");
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex);
				if (readingExceptionOccurred?.Invoke(args) ?? true)
				{
					throw ex;
				}
			}
			prevColumnCount = parser.Count;
		}
		return flag;
	}

	public virtual string? GetField(int index)
	{
		CheckHasBeenRead();
		currentIndex = index;
		if (index >= parser.Count || index < 0)
		{
			MissingFieldFoundArgs args = new MissingFieldFoundArgs(null, index, context);
			missingFieldFound?.Invoke(args);
			return null;
		}
		return parser[index];
	}

	public virtual string? GetField(string name)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name);
		if (fieldIndex < 0)
		{
			return null;
		}
		return GetField(fieldIndex);
	}

	public virtual string? GetField(string name, int index)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name, index);
		if (fieldIndex < 0)
		{
			return null;
		}
		return GetField(fieldIndex);
	}

	public virtual object? GetField(Type type, int index)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
		return GetField(type, index, converter);
	}

	public virtual object? GetField(Type type, string name)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
		return GetField(type, name, converter);
	}

	public virtual object? GetField(Type type, string name, int index)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
		return GetField(type, name, index, converter);
	}

	public virtual object? GetField(Type type, int index, ITypeConverter converter)
	{
		CheckHasBeenRead();
		reusableMemberMapData.Index = index;
		reusableMemberMapData.TypeConverter = converter;
		if (!typeConverterOptionsCache.TryGetValue(type, out TypeConverterOptions value))
		{
			value = TypeConverterOptions.Merge(new TypeConverterOptions
			{
				CultureInfo = cultureInfo
			}, context.TypeConverterOptionsCache.GetOptions(type));
			typeConverterOptionsCache.Add(type, value);
		}
		reusableMemberMapData.TypeConverterOptions = value;
		string field = GetField(index);
		return converter.ConvertFromString(field, this, reusableMemberMapData);
	}

	public virtual object? GetField(Type type, string name, ITypeConverter converter)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name);
		return GetField(type, fieldIndex, converter);
	}

	public virtual object? GetField(Type type, string name, int index, ITypeConverter converter)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name, index);
		return GetField(type, fieldIndex, converter);
	}

	public virtual T? GetField<T>(int index)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
		return GetField<T>(index, converter);
	}

	public virtual T? GetField<T>(string name)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
		return GetField<T>(name, converter);
	}

	public virtual T? GetField<T>(string name, int index)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
		return GetField<T>(name, index, converter);
	}

	public virtual T? GetField<T>(int index, ITypeConverter converter)
	{
		CheckHasBeenRead();
		if (index >= parser.Count || index < 0)
		{
			currentIndex = index;
			MissingFieldFoundArgs args = new MissingFieldFoundArgs(null, index, context);
			missingFieldFound?.Invoke(args);
			return default(T);
		}
		return (T)GetField(typeof(T), index, converter);
	}

	public virtual T? GetField<T>(string name, ITypeConverter converter)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name);
		return GetField<T>(fieldIndex, converter);
	}

	public virtual T? GetField<T>(string name, int index, ITypeConverter converter)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name, index);
		return GetField<T>(fieldIndex, converter);
	}

	public virtual T? GetField<T, TConverter>(int index) where TConverter : ITypeConverter
	{
		CheckHasBeenRead();
		TConverter val = ObjectResolver.Current.Resolve<TConverter>(Array.Empty<object>());
		return GetField<T>(index, val);
	}

	public virtual T? GetField<T, TConverter>(string name) where TConverter : ITypeConverter
	{
		CheckHasBeenRead();
		TConverter val = ObjectResolver.Current.Resolve<TConverter>(Array.Empty<object>());
		return GetField<T>(name, val);
	}

	public virtual T? GetField<T, TConverter>(string name, int index) where TConverter : ITypeConverter
	{
		CheckHasBeenRead();
		TConverter val = ObjectResolver.Current.Resolve<TConverter>(Array.Empty<object>());
		return GetField<T>(name, index, val);
	}

	public virtual bool TryGetField(Type type, int index, out object? field)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
		return TryGetField(type, index, converter, out field);
	}

	public virtual bool TryGetField(Type type, string name, out object? field)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
		return TryGetField(type, name, converter, out field);
	}

	public virtual bool TryGetField(Type type, string name, int index, out object? field)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
		return TryGetField(type, name, index, converter, out field);
	}

	public virtual bool TryGetField(Type type, int index, ITypeConverter converter, out object? field)
	{
		CheckHasBeenRead();
		try
		{
			field = GetField(type, index, converter);
			return true;
		}
		catch
		{
			field = (type.GetTypeInfo().IsValueType ? ObjectResolver.Current.Resolve(type) : null);
			return false;
		}
	}

	public virtual bool TryGetField(Type type, string name, ITypeConverter converter, out object? field)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name, 0, isTryGet: true);
		if (fieldIndex == -1)
		{
			field = (type.GetTypeInfo().IsValueType ? ObjectResolver.Current.Resolve(type) : null);
			return false;
		}
		return TryGetField(type, fieldIndex, converter, out field);
	}

	public virtual bool TryGetField(Type type, string name, int index, ITypeConverter converter, out object? field)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name, index, isTryGet: true);
		if (fieldIndex == -1)
		{
			field = (type.GetTypeInfo().IsValueType ? ObjectResolver.Current.Resolve(type) : null);
			return false;
		}
		return TryGetField(type, fieldIndex, converter, out field);
	}

	public virtual bool TryGetField<T>(int index, out T? field)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
		return TryGetField<T>(index, converter, out field);
	}

	public virtual bool TryGetField<T>(string name, out T? field)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
		return TryGetField<T>(name, converter, out field);
	}

	public virtual bool TryGetField<T>(string name, int index, out T? field)
	{
		CheckHasBeenRead();
		ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
		return TryGetField<T>(name, index, converter, out field);
	}

	public virtual bool TryGetField<T>(int index, ITypeConverter converter, out T? field)
	{
		CheckHasBeenRead();
		try
		{
			field = GetField<T>(index, converter);
			return true;
		}
		catch
		{
			field = default(T);
			return false;
		}
	}

	public virtual bool TryGetField<T>(string name, ITypeConverter converter, out T? field)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name, 0, isTryGet: true);
		if (fieldIndex == -1)
		{
			field = default(T);
			return false;
		}
		return TryGetField<T>(fieldIndex, converter, out field);
	}

	public virtual bool TryGetField<T>(string name, int index, ITypeConverter converter, out T? field)
	{
		CheckHasBeenRead();
		int fieldIndex = GetFieldIndex(name, index, isTryGet: true);
		if (fieldIndex == -1)
		{
			field = default(T);
			return false;
		}
		return TryGetField<T>(fieldIndex, converter, out field);
	}

	public virtual bool TryGetField<T, TConverter>(int index, out T? field) where TConverter : ITypeConverter
	{
		CheckHasBeenRead();
		TConverter val = ObjectResolver.Current.Resolve<TConverter>(Array.Empty<object>());
		return TryGetField<T>(index, val, out field);
	}

	public virtual bool TryGetField<T, TConverter>(string name, out T? field) where TConverter : ITypeConverter
	{
		CheckHasBeenRead();
		TConverter val = ObjectResolver.Current.Resolve<TConverter>(Array.Empty<object>());
		return TryGetField<T>(name, val, out field);
	}

	public virtual bool TryGetField<T, TConverter>(string name, int index, out T? field) where TConverter : ITypeConverter
	{
		CheckHasBeenRead();
		TConverter val = ObjectResolver.Current.Resolve<TConverter>(Array.Empty<object>());
		return TryGetField<T>(name, index, val, out field);
	}

	public virtual T GetRecord<T>()
	{
		CheckHasBeenRead();
		if (headerRecord == null && hasHeaderRecord)
		{
			ReadHeader();
			ValidateHeader<T>();
			if (!Read())
			{
				throw new ReaderException(context, "There are no records.");
			}
		}
		try
		{
			return recordManager.Value.GetReadDelegate<T>(typeof(T))();
		}
		catch (Exception ex)
		{
			CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
			ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
			ReadingExceptionOccurred? obj = readingExceptionOccurred;
			if (obj == null || obj(args))
			{
				if (ex is CsvHelperException)
				{
					throw;
				}
				throw ex2;
			}
			return (T)args.Record;
		}
	}

	public virtual T GetRecord<T>(T anonymousTypeDefinition)
	{
		if (anonymousTypeDefinition == null)
		{
			throw new ArgumentNullException("anonymousTypeDefinition");
		}
		if (!anonymousTypeDefinition.GetType().IsAnonymous())
		{
			throw new ArgumentException("Argument is not an anonymous type.", "anonymousTypeDefinition");
		}
		return GetRecord<T>();
	}

	public virtual object GetRecord(Type type)
	{
		CheckHasBeenRead();
		if (headerRecord == null && hasHeaderRecord)
		{
			ReadHeader();
			ValidateHeader(type);
			if (!Read())
			{
				throw new ReaderException(context, "There are no records.");
			}
		}
		try
		{
			return recordManager.Value.GetReadDelegate<object>(type)();
		}
		catch (Exception ex)
		{
			CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
			ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
			ReadingExceptionOccurred? obj = readingExceptionOccurred;
			if (obj == null || obj(args))
			{
				if (ex is CsvHelperException)
				{
					throw;
				}
				throw ex2;
			}
			return args.Record;
		}
	}

	public virtual IEnumerable<T> GetRecords<T>()
	{
		if (disposed)
		{
			throw new ObjectDisposedException("CsvReader", "GetRecords<T>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. e.g. .ToList() Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
		}
		if (hasHeaderRecord && headerRecord == null)
		{
			if (!Read())
			{
				yield break;
			}
			ReadHeader();
			ValidateHeader<T>();
		}
		Func<T> read = null;
		while (Read())
		{
			T val;
			try
			{
				if (read == null)
				{
					read = recordManager.Value.GetReadDelegate<T>(typeof(T));
				}
				val = read();
			}
			catch (Exception ex)
			{
				CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
				if (readingExceptionOccurred?.Invoke(args) ?? true)
				{
					if (ex is CsvHelperException)
					{
						throw;
					}
					throw ex2;
				}
				continue;
			}
			yield return val;
		}
	}

	public virtual IEnumerable<T> GetRecords<T>(T anonymousTypeDefinition)
	{
		if (anonymousTypeDefinition == null)
		{
			throw new ArgumentNullException("anonymousTypeDefinition");
		}
		if (!anonymousTypeDefinition.GetType().IsAnonymous())
		{
			throw new ArgumentException("Argument is not an anonymous type.", "anonymousTypeDefinition");
		}
		return GetRecords<T>();
	}

	public virtual IEnumerable<object> GetRecords(Type type)
	{
		if (disposed)
		{
			throw new ObjectDisposedException("CsvReader", "GetRecords<object>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. e.g. .ToList() Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
		}
		if (hasHeaderRecord && headerRecord == null)
		{
			if (!Read())
			{
				yield break;
			}
			ReadHeader();
			ValidateHeader(type);
		}
		Func<object> read = null;
		while (Read())
		{
			object obj;
			try
			{
				if (read == null)
				{
					read = recordManager.Value.GetReadDelegate<object>(type);
				}
				obj = read();
			}
			catch (Exception ex)
			{
				CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
				if (readingExceptionOccurred?.Invoke(args) ?? true)
				{
					if (ex is CsvHelperException)
					{
						throw;
					}
					throw ex2;
				}
				continue;
			}
			yield return obj;
		}
	}

	public virtual IEnumerable<T> EnumerateRecords<T>(T record)
	{
		if (disposed)
		{
			throw new ObjectDisposedException("CsvReader", "GetRecords<T>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. e.g. .ToList() Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
		}
		if (hasHeaderRecord && headerRecord == null)
		{
			if (!Read())
			{
				yield break;
			}
			ReadHeader();
			ValidateHeader<T>();
		}
		while (Read())
		{
			try
			{
				recordManager.Value.Hydrate(record);
			}
			catch (Exception ex)
			{
				CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
				if (readingExceptionOccurred?.Invoke(args) ?? true)
				{
					if (ex is CsvHelperException)
					{
						throw;
					}
					throw ex2;
				}
				continue;
			}
			yield return record;
		}
	}

	[AsyncIteratorStateMachine(typeof(_003CGetRecordsAsync_003Ed__91<>))]
	public virtual IAsyncEnumerable<T> GetRecordsAsync<T>([EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new _003CGetRecordsAsync_003Ed__91<T>(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__cancellationToken = cancellationToken
		};
	}

	public virtual IAsyncEnumerable<T> GetRecordsAsync<T>(T anonymousTypeDefinition, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (anonymousTypeDefinition == null)
		{
			throw new ArgumentNullException("anonymousTypeDefinition");
		}
		if (!anonymousTypeDefinition.GetType().IsAnonymous())
		{
			throw new ArgumentException("Argument is not an anonymous type.", "anonymousTypeDefinition");
		}
		return GetRecordsAsync<T>(cancellationToken);
	}

	[AsyncIteratorStateMachine(typeof(_003CGetRecordsAsync_003Ed__93))]
	public virtual IAsyncEnumerable<object> GetRecordsAsync(Type type, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new _003CGetRecordsAsync_003Ed__93(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__type = type,
			_003C_003E3__cancellationToken = cancellationToken
		};
	}

	public virtual async IAsyncEnumerable<T> EnumerateRecordsAsync<T>(T record, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		if (disposed)
		{
			throw new ObjectDisposedException("CsvReader", "GetRecords<T>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
		}
		if (hasHeaderRecord && headerRecord == null)
		{
			if (!(await ReadAsync().ConfigureAwait(continueOnCapturedContext: false)))
			{
				yield break;
			}
			ReadHeader();
			ValidateHeader<T>();
		}
		while (await ReadAsync().ConfigureAwait(continueOnCapturedContext: false))
		{
			cancellationToken.ThrowIfCancellationRequested();
			try
			{
				recordManager.Value.Hydrate(record);
			}
			catch (Exception ex)
			{
				CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
				if (readingExceptionOccurred?.Invoke(args) ?? true)
				{
					if (ex is CsvHelperException)
					{
						throw;
					}
					throw ex2;
				}
				continue;
			}
			yield return record;
		}
	}

	public virtual int GetFieldIndex(string name, int index = 0, bool isTryGet = false)
	{
		return GetFieldIndex(new string[1] { name }, index, isTryGet);
	}

	public virtual int GetFieldIndex(IEnumerable<string> names, int index = 0, bool isTryGet = false, bool isOptional = false)
	{
		if (names == null)
		{
			throw new ArgumentNullException("names");
		}
		if (!hasHeaderRecord)
		{
			throw new ReaderException(context, "There is no header record to determine the index by name.");
		}
		if (headerRecord == null)
		{
			throw new ReaderException(context, "The header has not been read. You must call ReadHeader() before any fields can be retrieved by name.");
		}
		string key = string.Join("_", names) + index;
		if (namedIndexCache.TryGetValue(key, out (string, int) value))
		{
			var (key2, index2) = value;
			return namedIndexes[key2][index2];
		}
		string text = null;
		int num = 0;
		foreach (string name in names)
		{
			PrepareHeaderForMatchArgs args = new PrepareHeaderForMatchArgs(name, num);
			string text2 = prepareHeaderForMatch(args);
			if (namedIndexes.ContainsKey(text2 ?? string.Empty))
			{
				text = text2;
				break;
			}
			num++;
		}
		if (text == null || index >= namedIndexes[text].Count)
		{
			if (!isTryGet && !isOptional)
			{
				MissingFieldFoundArgs args2 = new MissingFieldFoundArgs(names.ToArray(), index, context);
				missingFieldFound?.Invoke(args2);
			}
			return -1;
		}
		namedIndexCache.Add(key, (text, index));
		return namedIndexes[text][index];
	}

	public virtual bool CanRead(MemberMap memberMap)
	{
		bool flag = memberMap.Data.Ignore;
		PropertyInfo propertyInfo = memberMap.Data.Member as PropertyInfo;
		if (propertyInfo != null)
		{
			flag = flag || (propertyInfo.GetSetMethod() == null && !includePrivateMembers) || propertyInfo.GetSetMethod(nonPublic: true) == null;
		}
		return !flag;
	}

	public virtual bool CanRead(MemberReferenceMap memberReferenceMap)
	{
		bool flag = false;
		PropertyInfo propertyInfo = memberReferenceMap.Data.Member as PropertyInfo;
		if (propertyInfo != null)
		{
			flag = (propertyInfo.GetSetMethod() == null && !includePrivateMembers) || propertyInfo.GetSetMethod(nonPublic: true) == null;
		}
		return !flag;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				parser.Dispose();
			}
			disposed = true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected virtual void CheckHasBeenRead()
	{
		if (!hasBeenRead)
		{
			throw new ReaderException(context, "You must call read on the reader before accessing its data.");
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected virtual void ParseNamedIndexes()
	{
		if (headerRecord == null)
		{
			throw new ReaderException(context, "No header record was found.");
		}
		namedIndexes.Clear();
		namedIndexCache.Clear();
		for (int i = 0; i < headerRecord.Length; i++)
		{
			PrepareHeaderForMatchArgs args = new PrepareHeaderForMatchArgs(headerRecord[i], i);
			string key = prepareHeaderForMatch(args);
			if (namedIndexes.TryGetValue(key, out List<int> value))
			{
				value.Add(i);
				continue;
			}
			namedIndexes[key] = new List<int> { i };
		}
	}
}

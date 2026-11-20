using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace System.Diagnostics;

public class Activity : IDisposable
{
	public struct Enumerator<T>
	{
		private static readonly DiagNode<T> s_Empty = new DiagNode<T>(default(T));

		private DiagNode<T> _nextNode;

		private DiagNode<T> _currentNode;

		public readonly ref T Current => ref _currentNode.Value;

		internal Enumerator(DiagNode<T> head)
		{
			_nextNode = head;
			_currentNode = s_Empty;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public readonly Enumerator<T> GetEnumerator()
		{
			return this;
		}

		public bool MoveNext()
		{
			if (_nextNode == null)
			{
				_currentNode = s_Empty;
				return false;
			}
			_currentNode = _nextNode;
			_nextNode = _nextNode.Next;
			return true;
		}
	}

	private sealed class BaggageLinkedList : IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		public DiagNode<KeyValuePair<string, string>> First
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
		{
			throw new NotSupportedException("Linked away");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal sealed class TagsLinkedList : IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		private DiagNode<KeyValuePair<string, object>> _first;

		private DiagNode<KeyValuePair<string, object>> _last;

		private StringBuilder _stringBuilder;

		public DiagNode<KeyValuePair<string, object>> First => _first;

		public TagsLinkedList(KeyValuePair<string, object> firstValue, bool set = false)
		{
			_last = (_first = ((set && firstValue.Value == null) ? null : new DiagNode<KeyValuePair<string, object>>(firstValue)));
		}

		public TagsLinkedList(IEnumerator<KeyValuePair<string, object>> e)
		{
			_last = (_first = new DiagNode<KeyValuePair<string, object>>(e.Current));
			while (e.MoveNext())
			{
				_last.Next = new DiagNode<KeyValuePair<string, object>>(e.Current);
				_last = _last.Next;
			}
		}

		public TagsLinkedList(IEnumerable<KeyValuePair<string, object>> list)
		{
			Add(list);
		}

		public void Add(IEnumerable<KeyValuePair<string, object>> list)
		{
			IEnumerator<KeyValuePair<string, object>> enumerator = list.GetEnumerator();
			if (enumerator.MoveNext())
			{
				if (_first == null)
				{
					_last = (_first = new DiagNode<KeyValuePair<string, object>>(enumerator.Current));
				}
				else
				{
					_last.Next = new DiagNode<KeyValuePair<string, object>>(enumerator.Current);
					_last = _last.Next;
				}
				while (enumerator.MoveNext())
				{
					_last.Next = new DiagNode<KeyValuePair<string, object>>(enumerator.Current);
					_last = _last.Next;
				}
			}
		}

		public void Remove(string key)
		{
			lock (this)
			{
				if (_first == null)
				{
					return;
				}
				if (_first.Value.Key == key)
				{
					_first = _first.Next;
					if (_first == null)
					{
						_last = null;
					}
					return;
				}
				DiagNode<KeyValuePair<string, object>> diagNode = _first;
				while (diagNode.Next != null)
				{
					if (diagNode.Next.Value.Key == key)
					{
						if (_last == diagNode.Next)
						{
							_last = diagNode;
						}
						diagNode.Next = diagNode.Next.Next;
						break;
					}
					diagNode = diagNode.Next;
				}
			}
		}

		public void Set(KeyValuePair<string, object> value)
		{
			if (value.Value == null)
			{
				Remove(value.Key);
				return;
			}
			lock (this)
			{
				for (DiagNode<KeyValuePair<string, object>> diagNode = _first; diagNode != null; diagNode = diagNode.Next)
				{
					if (diagNode.Value.Key == value.Key)
					{
						diagNode.Value = value;
						return;
					}
				}
				DiagNode<KeyValuePair<string, object>> diagNode2 = new DiagNode<KeyValuePair<string, object>>(value);
				if (_first == null)
				{
					_first = (_last = diagNode2);
					return;
				}
				_last.Next = diagNode2;
				_last = diagNode2;
			}
		}

		public DiagEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return new DiagEnumerator<KeyValuePair<string, object>>(_first);
		}

		IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			lock (this)
			{
				if (_first == null)
				{
					return string.Empty;
				}
				if (_stringBuilder == null)
				{
					_stringBuilder = new StringBuilder();
				}
				_stringBuilder.Append(_first.Value.Key);
				_stringBuilder.Append(':');
				_stringBuilder.Append(_first.Value.Value);
				for (DiagNode<KeyValuePair<string, object>> next = _first.Next; next != null; next = next.Next)
				{
					_stringBuilder.Append(", ");
					_stringBuilder.Append(next.Value.Key);
					_stringBuilder.Append(':');
					_stringBuilder.Append(next.Value.Value);
				}
				string result = _stringBuilder.ToString();
				_stringBuilder.Clear();
				return result;
			}
		}
	}

	[Flags]
	private enum State : byte
	{
		None = 0,
		FormatUnknown = 0,
		FormatHierarchical = 1,
		FormatW3C = 2,
		FormatFlags = 3,
		IsStopped = 0x80
	}

	private static readonly IEnumerable<KeyValuePair<string, string>> s_emptyBaggageTags = new KeyValuePair<string, string>[0];

	private static readonly IEnumerable<KeyValuePair<string, object>> s_emptyTagObjects = new KeyValuePair<string, object>[0];

	private static readonly IEnumerable<ActivityLink> s_emptyLinks = new DiagLinkedList<ActivityLink>();

	private static readonly IEnumerable<ActivityEvent> s_emptyEvents = new DiagLinkedList<ActivityEvent>();

	private static readonly ActivitySource s_defaultSource = new ActivitySource(string.Empty);

	private static readonly AsyncLocal<Activity> s_current = new AsyncLocal<Activity>();

	private static readonly string s_uniqSuffix = $"-{GetRandomNumber():x}.";

	private static long s_currentRootId = (uint)GetRandomNumber();

	private static ActivityIdFormat s_defaultIdFormat;

	[CompilerGenerated]
	private static EventHandler<ActivityChangedEventArgs> CurrentChanged;

	private string _traceState;

	private State _state;

	private int _currentChildId;

	private string _id;

	private string _parentId;

	private string _parentSpanId;

	private string _traceId;

	private string _spanId;

	private byte _w3CIdFlags;

	private byte _parentTraceFlags;

	private TagsLinkedList _tags;

	private BaggageLinkedList _baggage;

	private DiagLinkedList<ActivityLink> _links;

	private DiagLinkedList<ActivityEvent> _events;

	private string _displayName;

	private ActivityStatusCode _statusCode;

	private string _statusDescription;

	private Activity _previousActiveActivity;

	[CompilerGenerated]
	private bool _003CHasRemoteParent_003Ek__BackingField;

	[CompilerGenerated]
	private ActivityKind _003CKind_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003COperationName_003Ek__BackingField;

	public static bool ForceDefaultIdFormat { get; }

	private bool HasRemoteParent
	{
		[CompilerGenerated]
		set
		{
			_003CHasRemoteParent_003Ek__BackingField = value;
		}
	}

	public static Activity? Current
	{
		get
		{
			return s_current.Value;
		}
		set
		{
			if (ValidateSetCurrent(value))
			{
				SetCurrent(value);
			}
		}
	}

	private ActivityKind Kind
	{
		[CompilerGenerated]
		set
		{
			_003CKind_003Ek__BackingField = value;
		}
	}

	public string DisplayName
	{
		set
		{
			_displayName = value ?? throw new ArgumentNullException("value");
		}
	}

	public ActivitySource Source { get; private set; }

	public Activity? Parent { get; private set; }

	public TimeSpan Duration { get; private set; }

	public DateTime StartTimeUtc { get; private set; }

	public string? Id
	{
		get
		{
			if (_id == null && _spanId != null)
			{
				Span<char> span = stackalloc char[2];
				System.HexConverter.ToCharsBuffer((byte)(-129 & _w3CIdFlags), span, 0, System.HexConverter.Casing.Lower);
				IFormatProvider formatProvider = null;
				IFormatProvider provider = formatProvider;
				Span<char> initialBuffer = stackalloc char[128];
				DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(5, 3, formatProvider, initialBuffer);
				handler.AppendLiteral("00-");
				handler.AppendFormatted(_traceId);
				handler.AppendLiteral("-");
				handler.AppendFormatted(_spanId);
				handler.AppendLiteral("-");
				handler.AppendFormatted((ReadOnlySpan<char>)span);
				string value = string.Create(provider, initialBuffer, ref handler);
				Interlocked.CompareExchange(ref _id, value, null);
			}
			return _id;
		}
	}

	public string? ParentId
	{
		get
		{
			if (_parentId == null)
			{
				if (_parentSpanId != null)
				{
					Span<char> span = stackalloc char[2];
					System.HexConverter.ToCharsBuffer((byte)(-129 & _parentTraceFlags), span, 0, System.HexConverter.Casing.Lower);
					IFormatProvider formatProvider = null;
					IFormatProvider provider = formatProvider;
					Span<char> initialBuffer = stackalloc char[128];
					DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(5, 3, formatProvider, initialBuffer);
					handler.AppendLiteral("00-");
					handler.AppendFormatted(_traceId);
					handler.AppendLiteral("-");
					handler.AppendFormatted(_parentSpanId);
					handler.AppendLiteral("-");
					handler.AppendFormatted((ReadOnlySpan<char>)span);
					string value = string.Create(provider, initialBuffer, ref handler);
					Interlocked.CompareExchange(ref _parentId, value, null);
				}
				else if (Parent != null)
				{
					Interlocked.CompareExchange(ref _parentId, Parent.Id, null);
				}
			}
			return _parentId;
		}
	}

	public IEnumerable<KeyValuePair<string, string?>> Baggage
	{
		get
		{
			for (Activity activity = this; activity != null; activity = activity.Parent)
			{
				if (activity._baggage != null)
				{
					return Iterate(activity);
				}
			}
			return s_emptyBaggageTags;
			static IEnumerable<KeyValuePair<string, string>> Iterate(Activity parent)
			{
				do
				{
					if (parent._baggage != null)
					{
						for (DiagNode<KeyValuePair<string, string>> current = parent._baggage.First; current != null; current = current.Next)
						{
							yield return current.Value;
						}
					}
					parent = parent.Parent;
				}
				while (parent != null);
			}
		}
	}

	public ActivityContext Context => new ActivityContext(TraceId, SpanId, ActivityTraceFlags, TraceStateString);

	public string? TraceStateString
	{
		get
		{
			for (Activity activity = this; activity != null; activity = activity.Parent)
			{
				string traceState = activity._traceState;
				if (traceState != null)
				{
					return traceState;
				}
			}
			return null;
		}
	}

	public ActivitySpanId SpanId
	{
		get
		{
			if (_spanId == null && _id != null && IdFormat == ActivityIdFormat.W3C)
			{
				string value = ActivitySpanId.CreateFromString(_id.AsSpan(36, 16)).ToHexString();
				Interlocked.CompareExchange(ref _spanId, value, null);
			}
			return new ActivitySpanId(_spanId);
		}
	}

	public ActivityTraceId TraceId
	{
		get
		{
			if (_traceId == null)
			{
				TrySetTraceIdFromParent();
			}
			return new ActivityTraceId(_traceId);
		}
	}

	public bool IsAllDataRequested { get; set; }

	public ActivityTraceFlags ActivityTraceFlags
	{
		get
		{
			if (!W3CIdFlagsSet)
			{
				TrySetTraceFlagsFromParent();
			}
			return (ActivityTraceFlags)(-129 & _w3CIdFlags);
		}
		set
		{
			_w3CIdFlags = (byte)(0x80 | (byte)value);
		}
	}

	public static Func<ActivityTraceId>? TraceIdGenerator { get; }

	public static ActivityIdFormat DefaultIdFormat
	{
		get
		{
			if (s_defaultIdFormat == ActivityIdFormat.Unknown)
			{
				s_defaultIdFormat = (System.LocalAppContextSwitches.DefaultActivityIdFormatIsHierarchial ? ActivityIdFormat.Hierarchical : ActivityIdFormat.W3C);
			}
			return s_defaultIdFormat;
		}
	}

	private bool W3CIdFlagsSet => (_w3CIdFlags & 0x80) != 0;

	public bool IsStopped
	{
		get
		{
			return (_state & State.IsStopped) != 0;
		}
		private set
		{
			if (value)
			{
				_state |= State.IsStopped;
			}
			else
			{
				_state &= ~State.IsStopped;
			}
		}
	}

	public ActivityIdFormat IdFormat
	{
		get
		{
			return (ActivityIdFormat)(_state & State.FormatFlags);
		}
		private set
		{
			_state = (State)((uint)(_state & ~State.FormatFlags) | (uint)(byte)((byte)value & 3));
		}
	}

	public Activity SetStatus(ActivityStatusCode code, string? description = null)
	{
		_statusCode = code;
		_statusDescription = ((code == ActivityStatusCode.Error) ? description : null);
		return this;
	}

	public Activity(string operationName)
	{
		Source = s_defaultSource;
		IsAllDataRequested = true;
		if (string.IsNullOrEmpty(operationName))
		{
			NotifyError(new ArgumentException("OperationNameInvalid"));
		}
		_003COperationName_003Ek__BackingField = operationName ?? string.Empty;
	}

	public Activity SetTag(string key, object? value)
	{
		KeyValuePair<string, object> keyValuePair = new KeyValuePair<string, object>(key, value);
		if (_tags != null || Interlocked.CompareExchange(ref _tags, new TagsLinkedList(keyValuePair, set: true), null) != null)
		{
			_tags.Set(keyValuePair);
		}
		return this;
	}

	public Activity AddEvent(ActivityEvent e)
	{
		if (_events != null || Interlocked.CompareExchange(ref _events, new DiagLinkedList<ActivityEvent>(e), null) != null)
		{
			_events.Add(e);
		}
		return this;
	}

	public Activity AddException(Exception exception, in TagList tags = default(TagList), DateTimeOffset timestamp = default(DateTimeOffset))
	{
		ArgumentNullException.ThrowIfNull(exception, "exception");
		TagList tags2 = tags;
		Source.NotifyActivityAddException(this, exception, ref tags2);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		for (int i = 0; i < tags2.Count; i++)
		{
			if (tags2[i].Key == "exception.message")
			{
				flag = true;
			}
			else if (tags2[i].Key == "exception.stacktrace")
			{
				flag2 = true;
			}
			else if (tags2[i].Key == "exception.type")
			{
				flag3 = true;
			}
		}
		if (!flag)
		{
			tags2.Add(new KeyValuePair<string, object>("exception.message", exception.Message));
		}
		if (!flag2)
		{
			tags2.Add(new KeyValuePair<string, object>("exception.stacktrace", exception.ToString()));
		}
		if (!flag3)
		{
			tags2.Add(new KeyValuePair<string, object>("exception.type", exception.GetType().ToString()));
		}
		return AddEvent(new ActivityEvent("exception", timestamp, ref tags2));
	}

	public Activity SetEndTime(DateTime endTimeUtc)
	{
		if (endTimeUtc.Kind != DateTimeKind.Utc)
		{
			NotifyError(new InvalidOperationException("EndTimeNotUtc"));
		}
		else
		{
			Duration = endTimeUtc - StartTimeUtc;
			if (Duration.Ticks <= 0)
			{
				Duration = new TimeSpan(1L);
			}
		}
		return this;
	}

	public Activity Start()
	{
		if (_id != null || _spanId != null)
		{
			NotifyError(new InvalidOperationException("ActivityStartAlreadyStarted"));
		}
		else
		{
			_previousActiveActivity = Current;
			if (_parentId == null && _parentSpanId == null && _previousActiveActivity != null)
			{
				Parent = _previousActiveActivity;
			}
			if (StartTimeUtc == default(DateTime))
			{
				StartTimeUtc = GetUtcNow();
			}
			if (IdFormat == ActivityIdFormat.Unknown)
			{
				IdFormat = (ForceDefaultIdFormat ? DefaultIdFormat : ((Parent != null) ? Parent.IdFormat : ((_parentSpanId != null) ? ActivityIdFormat.W3C : ((_parentId == null) ? DefaultIdFormat : ((!IsW3CId(_parentId)) ? ActivityIdFormat.Hierarchical : ActivityIdFormat.W3C)))));
			}
			if (IdFormat == ActivityIdFormat.W3C)
			{
				GenerateW3CId();
			}
			else
			{
				_id = GenerateHierarchicalId();
			}
			SetCurrent(this);
			Source.NotifyActivityStart(this);
		}
		return this;
	}

	public void Stop()
	{
		if (_id == null && _spanId == null)
		{
			NotifyError(new InvalidOperationException("ActivityNotStarted"));
		}
		else if (!IsStopped)
		{
			IsStopped = true;
			if (Duration == TimeSpan.Zero)
			{
				SetEndTime(GetUtcNow());
			}
			Source.NotifyActivityStop(this);
			SetCurrent(_previousActiveActivity);
		}
	}

	private static bool IsW3CId(string id)
	{
		if (id.Length == 55 && (('0' <= id[0] && id[0] <= '9') || ('a' <= id[0] && id[0] <= 'f')) && (('0' <= id[1] && id[1] <= '9') || ('a' <= id[1] && id[1] <= 'f')))
		{
			if (id[0] == 'f')
			{
				return id[1] != 'f';
			}
			return true;
		}
		return false;
	}

	internal static bool TryConvertIdToContext(string traceParent, string traceState, bool isRemote, out ActivityContext context)
	{
		context = default(ActivityContext);
		if (!IsW3CId(traceParent))
		{
			return false;
		}
		ReadOnlySpan<char> idData = traceParent.AsSpan(3, 32);
		ReadOnlySpan<char> idData2 = traceParent.AsSpan(36, 16);
		if (!ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData) || !ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData2) || !System.HexConverter.IsHexLowerChar(traceParent[53]) || !System.HexConverter.IsHexLowerChar(traceParent[54]))
		{
			return false;
		}
		context = new ActivityContext(new ActivityTraceId(idData.ToString()), new ActivitySpanId(idData2.ToString()), (ActivityTraceFlags)ActivityTraceId.HexByteFromChars(traceParent[53], traceParent[54]), traceState, isRemote);
		return true;
	}

	public void Dispose()
	{
		if (!IsStopped)
		{
			Stop();
		}
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	internal static Activity Create(ActivitySource source, string name, ActivityKind kind, string parentId, ActivityContext parentContext, IEnumerable<KeyValuePair<string, object>> tags, IEnumerable<ActivityLink> links, DateTimeOffset startTime, ActivityTagsCollection samplerTags, ActivitySamplingResult request, bool startIt, ActivityIdFormat idFormat, string traceState)
	{
		Activity activity = new Activity(name);
		activity.Source = source;
		activity.Kind = kind;
		activity.IdFormat = idFormat;
		activity._traceState = traceState;
		if (links != null)
		{
			using IEnumerator<ActivityLink> enumerator = links.GetEnumerator();
			if (enumerator.MoveNext())
			{
				activity._links = new DiagLinkedList<ActivityLink>(enumerator);
			}
		}
		if (tags != null)
		{
			using IEnumerator<KeyValuePair<string, object>> enumerator2 = tags.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				activity._tags = new TagsLinkedList(enumerator2);
			}
		}
		if (samplerTags != null)
		{
			if (activity._tags == null)
			{
				activity._tags = new TagsLinkedList(samplerTags);
			}
			else
			{
				activity._tags.Add(samplerTags);
			}
		}
		if (parentId != null)
		{
			activity._parentId = parentId;
		}
		else if (parentContext != default(ActivityContext))
		{
			activity._traceId = parentContext.TraceId.ToString();
			if (parentContext.SpanId != default(ActivitySpanId))
			{
				activity._parentSpanId = parentContext.SpanId.ToString();
			}
			activity.ActivityTraceFlags = parentContext.TraceFlags & ~ActivityTraceFlags.Recorded;
			activity._parentTraceFlags = (byte)parentContext.TraceFlags;
			activity.HasRemoteParent = parentContext.IsRemote;
		}
		activity.IsAllDataRequested = request == ActivitySamplingResult.AllData || request == ActivitySamplingResult.AllDataAndRecorded;
		if (request == ActivitySamplingResult.AllDataAndRecorded)
		{
			activity.ActivityTraceFlags |= ActivityTraceFlags.Recorded;
		}
		if (startTime != default(DateTimeOffset))
		{
			activity.StartTimeUtc = startTime.UtcDateTime;
		}
		if (startIt)
		{
			activity.Start();
		}
		return activity;
	}

	private static void SetCurrent(Activity activity)
	{
		EventHandler<ActivityChangedEventArgs> currentChanged = CurrentChanged;
		if (currentChanged == null)
		{
			s_current.Value = activity;
			return;
		}
		Activity value = s_current.Value;
		s_current.Value = activity;
		currentChanged(null, new ActivityChangedEventArgs(value, activity));
	}

	private void GenerateW3CId()
	{
		if (_traceId == null && !TrySetTraceIdFromParent())
		{
			_traceId = (TraceIdGenerator?.Invoke() ?? ActivityTraceId.CreateRandom()).ToHexString();
		}
		if (!W3CIdFlagsSet)
		{
			TrySetTraceFlagsFromParent();
		}
		_spanId = ActivitySpanId.CreateRandom().ToHexString();
	}

	private static void NotifyError(Exception exception)
	{
		try
		{
			throw exception;
		}
		catch
		{
		}
	}

	private string GenerateHierarchicalId()
	{
		if (Parent != null)
		{
			return AppendSuffix(Parent.Id, Interlocked.Increment(ref Parent._currentChildId).ToString(), '.');
		}
		if (ParentId != null)
		{
			string text = ((ParentId[0] == '|') ? ParentId : ("|" + ParentId));
			char c = text[text.Length - 1];
			if (c != '.' && c != '_')
			{
				text += ".";
			}
			return AppendSuffix(text, Interlocked.Increment(ref s_currentRootId).ToString("x"), '_');
		}
		return GenerateRootId();
	}

	private string AppendSuffix(string parentId, string suffix, char delimiter)
	{
		if (parentId.Length + suffix.Length < 1024)
		{
			return parentId + suffix + delimiter;
		}
		int num = 1015;
		while (num > 1 && parentId[num - 1] != '.' && parentId[num - 1] != '_')
		{
			num--;
		}
		if (num == 1)
		{
			return GenerateRootId();
		}
		string text = ((int)GetRandomNumber()).ToString("x8");
		return parentId.Substring(0, num) + text + "#";
	}

	private unsafe static long GetRandomNumber()
	{
		Guid guid = Guid.NewGuid();
		return *(long*)(&guid);
	}

	private static bool ValidateSetCurrent(Activity activity)
	{
		int num;
		if (activity != null)
		{
			if (activity.Id != null)
			{
				num = ((!activity.IsStopped) ? 1 : 0);
				if (num != 0)
				{
					goto IL_002c;
				}
			}
			else
			{
				num = 0;
			}
			NotifyError(new InvalidOperationException("ActivityNotRunning"));
		}
		else
		{
			num = 1;
		}
		goto IL_002c;
		IL_002c:
		return (byte)num != 0;
	}

	private bool TrySetTraceIdFromParent()
	{
		if (Parent != null && Parent.IdFormat == ActivityIdFormat.W3C)
		{
			_traceId = Parent.TraceId.ToHexString();
		}
		else if (_parentId != null && IsW3CId(_parentId))
		{
			try
			{
				_traceId = ActivityTraceId.CreateFromString(_parentId.AsSpan(3, 32)).ToHexString();
			}
			catch
			{
			}
		}
		return _traceId != null;
	}

	private void TrySetTraceFlagsFromParent()
	{
		if (W3CIdFlagsSet)
		{
			return;
		}
		if (Parent != null)
		{
			ActivityTraceFlags = Parent.ActivityTraceFlags;
		}
		else if (_parentId != null && IsW3CId(_parentId))
		{
			if (System.HexConverter.IsHexLowerChar(_parentId[53]) && System.HexConverter.IsHexLowerChar(_parentId[54]))
			{
				_w3CIdFlags = (byte)(ActivityTraceId.HexByteFromChars(_parentId[53], _parentId[54]) | 0x80);
			}
			else
			{
				_w3CIdFlags = 128;
			}
		}
	}

	private static string GenerateRootId()
	{
		Span<char> span = stackalloc char[17 + s_uniqSuffix.Length];
		span[0] = '|';
		Interlocked.Increment(ref s_currentRootId).TryFormat(span.Slice(1), out var charsWritten, "x".AsSpan());
		s_uniqSuffix.AsSpan().CopyTo(span.Slice(1 + charsWritten));
		return new string(span.Slice(0, 1 + charsWritten + s_uniqSuffix.Length));
	}

	internal static DateTime GetUtcNow()
	{
		return DateTime.UtcNow;
	}
}

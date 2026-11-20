using System.Buffers.Binary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading;

namespace System;

[Serializable]
[TypeForwardedFrom("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class TimeZoneInfo : IEquatable<TimeZoneInfo?>, ISerializable, IDeserializationCallback
{
	[Serializable]
	public sealed class AdjustmentRule : IEquatable<AdjustmentRule?>, ISerializable, IDeserializationCallback
	{
		private static readonly TimeSpan DaylightDeltaAdjustment = TimeSpan.FromHours(24.0);

		private static readonly TimeSpan MaxDaylightDelta = TimeSpan.FromHours(12.0);

		private readonly DateTime _dateStart;

		private readonly DateTime _dateEnd;

		private readonly TimeSpan _daylightDelta;

		private readonly TransitionTime _daylightTransitionStart;

		private readonly TransitionTime _daylightTransitionEnd;

		private readonly TimeSpan _baseUtcOffsetDelta;

		private readonly bool _noDaylightTransitions;

		public DateTime DateStart => _dateStart;

		public DateTime DateEnd => _dateEnd;

		public TimeSpan DaylightDelta => _daylightDelta;

		public TransitionTime DaylightTransitionStart => _daylightTransitionStart;

		public TransitionTime DaylightTransitionEnd => _daylightTransitionEnd;

		public TimeSpan BaseUtcOffsetDelta => _baseUtcOffsetDelta;

		internal bool NoDaylightTransitions => _noDaylightTransitions;

		internal bool HasDaylightSaving
		{
			get
			{
				if (!(DaylightDelta != TimeSpan.Zero) && (!(DaylightTransitionStart != default(TransitionTime)) || !(DaylightTransitionStart.TimeOfDay != DateTime.MinValue)))
				{
					if (DaylightTransitionEnd != default(TransitionTime))
					{
						return DaylightTransitionEnd.TimeOfDay != DateTime.MinValue.AddMilliseconds(1.0);
					}
					return false;
				}
				return true;
			}
		}

		public bool Equals([NotNullWhen(true)] AdjustmentRule? other)
		{
			if (other != null && _dateStart == other._dateStart && _dateEnd == other._dateEnd && _daylightDelta == other._daylightDelta && _baseUtcOffsetDelta == other._baseUtcOffsetDelta && _daylightTransitionEnd.Equals(other._daylightTransitionEnd))
			{
				return _daylightTransitionStart.Equals(other._daylightTransitionStart);
			}
			return false;
		}

		public override bool Equals([NotNullWhen(true)] object? obj)
		{
			if (obj is AdjustmentRule other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _dateStart.GetHashCode();
		}

		private AdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta, bool noDaylightTransitions)
		{
			ValidateAdjustmentRule(dateStart, dateEnd, daylightDelta, daylightTransitionStart, daylightTransitionEnd, noDaylightTransitions);
			_dateStart = dateStart;
			_dateEnd = dateEnd;
			_daylightDelta = daylightDelta;
			_daylightTransitionStart = daylightTransitionStart;
			_daylightTransitionEnd = daylightTransitionEnd;
			_baseUtcOffsetDelta = baseUtcOffsetDelta;
			_noDaylightTransitions = noDaylightTransitions;
		}

		public static AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta)
		{
			return new AdjustmentRule(dateStart, dateEnd, daylightDelta, daylightTransitionStart, daylightTransitionEnd, baseUtcOffsetDelta, noDaylightTransitions: false);
		}

		public static AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd)
		{
			return new AdjustmentRule(dateStart, dateEnd, daylightDelta, daylightTransitionStart, daylightTransitionEnd, TimeSpan.Zero, noDaylightTransitions: false);
		}

		internal static AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta, bool noDaylightTransitions)
		{
			AdjustDaylightDeltaToExpectedRange(ref daylightDelta, ref baseUtcOffsetDelta);
			return new AdjustmentRule(dateStart, dateEnd, daylightDelta, daylightTransitionStart, daylightTransitionEnd, baseUtcOffsetDelta, noDaylightTransitions);
		}

		internal bool IsStartDateMarkerForBeginningOfYear()
		{
			if (!NoDaylightTransitions && DaylightTransitionStart.Month == 1 && DaylightTransitionStart.Day == 1)
			{
				return DaylightTransitionStart.TimeOfDay.TimeOfDay.Ticks < 10000000;
			}
			return false;
		}

		internal bool IsEndDateMarkerForEndOfYear()
		{
			if (!NoDaylightTransitions && DaylightTransitionEnd.Month == 1 && DaylightTransitionEnd.Day == 1)
			{
				return DaylightTransitionEnd.TimeOfDay.TimeOfDay.Ticks < 10000000;
			}
			return false;
		}

		private static void ValidateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TransitionTime daylightTransitionStart, TransitionTime daylightTransitionEnd, bool noDaylightTransitions)
		{
			if (dateStart.Kind != DateTimeKind.Unspecified && dateStart.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException("Argument_DateTimeKindMustBeUnspecifiedOrUtc", "dateStart");
			}
			if (dateEnd.Kind != DateTimeKind.Unspecified && dateEnd.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException("Argument_DateTimeKindMustBeUnspecifiedOrUtc", "dateEnd");
			}
			if (daylightTransitionStart.Equals(daylightTransitionEnd) && !noDaylightTransitions)
			{
				throw new ArgumentException("Argument_TransitionTimesAreIdentical", "daylightTransitionEnd");
			}
			if (dateStart > dateEnd)
			{
				throw new ArgumentException("Argument_OutOfOrderDateTimes", "dateStart");
			}
			if (daylightDelta.TotalHours < -23.0 || daylightDelta.TotalHours > 14.0)
			{
				throw new ArgumentOutOfRangeException("daylightDelta", daylightDelta, "ArgumentOutOfRange_UtcOffset");
			}
			if (daylightDelta.Ticks % 600000000 != 0L)
			{
				throw new ArgumentException("Argument_TimeSpanHasSeconds", "daylightDelta");
			}
			if (dateStart != DateTime.MinValue && dateStart.Kind == DateTimeKind.Unspecified && dateStart.TimeOfDay != TimeSpan.Zero)
			{
				throw new ArgumentException("Argument_DateTimeHasTimeOfDay", "dateStart");
			}
			if (dateEnd != DateTime.MaxValue && dateEnd.Kind == DateTimeKind.Unspecified && dateEnd.TimeOfDay != TimeSpan.Zero)
			{
				throw new ArgumentException("Argument_DateTimeHasTimeOfDay", "dateEnd");
			}
		}

		private static void AdjustDaylightDeltaToExpectedRange(ref TimeSpan daylightDelta, ref TimeSpan baseUtcOffsetDelta)
		{
			if (daylightDelta > MaxDaylightDelta)
			{
				daylightDelta -= DaylightDeltaAdjustment;
				baseUtcOffsetDelta += DaylightDeltaAdjustment;
			}
			else if (daylightDelta < -MaxDaylightDelta)
			{
				daylightDelta += DaylightDeltaAdjustment;
				baseUtcOffsetDelta -= DaylightDeltaAdjustment;
			}
		}

		void IDeserializationCallback.OnDeserialization(object sender)
		{
			try
			{
				ValidateAdjustmentRule(_dateStart, _dateEnd, _daylightDelta, _daylightTransitionStart, _daylightTransitionEnd, _noDaylightTransitions);
			}
			catch (ArgumentException innerException)
			{
				throw new SerializationException("Serialization_InvalidData", innerException);
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			ArgumentNullException.ThrowIfNull(info, "info");
			info.AddValue("DateStart", _dateStart);
			info.AddValue("DateEnd", _dateEnd);
			info.AddValue("DaylightDelta", _daylightDelta);
			info.AddValue("DaylightTransitionStart", _daylightTransitionStart);
			info.AddValue("DaylightTransitionEnd", _daylightTransitionEnd);
			info.AddValue("BaseUtcOffsetDelta", _baseUtcOffsetDelta);
			info.AddValue("NoDaylightTransitions", _noDaylightTransitions);
		}

		private AdjustmentRule(SerializationInfo info, StreamingContext context)
		{
			ArgumentNullException.ThrowIfNull(info, "info");
			_dateStart = (DateTime)info.GetValue("DateStart", typeof(DateTime));
			_dateEnd = (DateTime)info.GetValue("DateEnd", typeof(DateTime));
			_daylightDelta = (TimeSpan)info.GetValue("DaylightDelta", typeof(TimeSpan));
			_daylightTransitionStart = (TransitionTime)info.GetValue("DaylightTransitionStart", typeof(TransitionTime));
			_daylightTransitionEnd = (TransitionTime)info.GetValue("DaylightTransitionEnd", typeof(TransitionTime));
			object valueNoThrow = info.GetValueNoThrow("BaseUtcOffsetDelta", typeof(TimeSpan));
			if (valueNoThrow != null)
			{
				_baseUtcOffsetDelta = (TimeSpan)valueNoThrow;
			}
			valueNoThrow = info.GetValueNoThrow("NoDaylightTransitions", typeof(bool));
			if (valueNoThrow != null)
			{
				_noDaylightTransitions = (bool)valueNoThrow;
			}
		}
	}

	private enum TimeZoneInfoResult
	{
		Success,
		TimeZoneNotFoundException,
		InvalidTimeZoneException,
		SecurityException
	}

	private sealed class CachedData
	{
		private volatile TimeZoneInfo _localTimeZone;

		public Dictionary<string, TimeZoneInfo> _systemTimeZones;

		public ReadOnlyCollection<TimeZoneInfo> _readOnlySystemTimeZones;

		public ReadOnlyCollection<TimeZoneInfo> _readOnlyUnsortedSystemTimeZones;

		public Dictionary<string, TimeZoneInfo> _timeZonesUsingAlternativeIds;

		public bool _allSystemTimeZonesRead;

		public TimeZoneInfo Local => _localTimeZone ?? CreateLocal();

		private TimeZoneInfo CreateLocal()
		{
			lock (this)
			{
				TimeZoneInfo timeZoneInfo = _localTimeZone;
				if (timeZoneInfo == null)
				{
					timeZoneInfo = GetLocalTimeZone(this);
					timeZoneInfo = (_localTimeZone = new TimeZoneInfo(timeZoneInfo._id, timeZoneInfo._baseUtcOffset, timeZoneInfo.DisplayName, timeZoneInfo.StandardName, timeZoneInfo.DaylightName, timeZoneInfo._adjustmentRules, disableDaylightSavingTime: false, timeZoneInfo.HasIanaId));
				}
				return timeZoneInfo;
			}
		}

		public DateTimeKind GetCorrespondingKind(TimeZoneInfo timeZone)
		{
			if (timeZone != s_utcTimeZone)
			{
				if (timeZone != _localTimeZone)
				{
					return DateTimeKind.Unspecified;
				}
				return DateTimeKind.Local;
			}
			return DateTimeKind.Utc;
		}
	}

	private struct StringSerializer
	{
		private enum State
		{
			Escaped,
			NotEscaped,
			StartOfToken,
			EndOfLine
		}

		private readonly string _serializedText;

		private int _currentTokenStartIndex;

		private State _state;

		public static string GetSerializedString(TimeZoneInfo zone)
		{
			Span<char> initialBuffer = stackalloc char[64];
			ValueStringBuilder serializedText = new ValueStringBuilder(initialBuffer);
			SerializeSubstitute(zone.Id, ref serializedText);
			serializedText.Append(';');
			serializedText.AppendSpanFormattable(zone.BaseUtcOffset.TotalMinutes, null, CultureInfo.InvariantCulture);
			serializedText.Append(';');
			SerializeSubstitute(zone.DisplayName, ref serializedText);
			serializedText.Append(';');
			SerializeSubstitute(zone.StandardName, ref serializedText);
			serializedText.Append(';');
			SerializeSubstitute(zone.DaylightName, ref serializedText);
			serializedText.Append(';');
			AdjustmentRule[] adjustmentRules = zone.GetAdjustmentRules();
			foreach (AdjustmentRule adjustmentRule in adjustmentRules)
			{
				serializedText.Append('[');
				serializedText.AppendSpanFormattable(adjustmentRule.DateStart, "MM:dd:yyyy", DateTimeFormatInfo.InvariantInfo);
				serializedText.Append(';');
				serializedText.AppendSpanFormattable(adjustmentRule.DateEnd, "MM:dd:yyyy", DateTimeFormatInfo.InvariantInfo);
				serializedText.Append(';');
				serializedText.AppendSpanFormattable(adjustmentRule.DaylightDelta.TotalMinutes, null, CultureInfo.InvariantCulture);
				serializedText.Append(';');
				SerializeTransitionTime(adjustmentRule.DaylightTransitionStart, ref serializedText);
				serializedText.Append(';');
				SerializeTransitionTime(adjustmentRule.DaylightTransitionEnd, ref serializedText);
				serializedText.Append(';');
				if (adjustmentRule.BaseUtcOffsetDelta != TimeSpan.Zero)
				{
					serializedText.AppendSpanFormattable(adjustmentRule.BaseUtcOffsetDelta.TotalMinutes, null, CultureInfo.InvariantCulture);
					serializedText.Append(';');
				}
				if (adjustmentRule.NoDaylightTransitions)
				{
					serializedText.Append('1');
					serializedText.Append(';');
				}
				serializedText.Append(']');
			}
			serializedText.Append(';');
			return serializedText.ToString();
		}

		public static TimeZoneInfo GetDeserializedTimeZoneInfo(string source)
		{
			StringSerializer stringSerializer = new StringSerializer(source);
			string nextStringValue = stringSerializer.GetNextStringValue();
			TimeSpan nextTimeSpanValue = stringSerializer.GetNextTimeSpanValue();
			string nextStringValue2 = stringSerializer.GetNextStringValue();
			string nextStringValue3 = stringSerializer.GetNextStringValue();
			string nextStringValue4 = stringSerializer.GetNextStringValue();
			AdjustmentRule[] nextAdjustmentRuleArrayValue = stringSerializer.GetNextAdjustmentRuleArrayValue();
			try
			{
				return new TimeZoneInfo(nextStringValue, nextTimeSpanValue, nextStringValue2, nextStringValue3, nextStringValue4, nextAdjustmentRuleArrayValue, disableDaylightSavingTime: false);
			}
			catch (ArgumentException innerException)
			{
				throw new SerializationException("Serialization_InvalidData", innerException);
			}
			catch (InvalidTimeZoneException innerException2)
			{
				throw new SerializationException("Serialization_InvalidData", innerException2);
			}
		}

		private StringSerializer(string str)
		{
			_serializedText = str;
			_currentTokenStartIndex = 0;
			_state = State.StartOfToken;
		}

		private static void SerializeSubstitute(string text, ref ValueStringBuilder serializedText)
		{
			foreach (char c in text)
			{
				if (c == '\\' || c == '[' || c == ']' || c == ';')
				{
					serializedText.Append('\\');
				}
				serializedText.Append(c);
			}
		}

		private static void SerializeTransitionTime(TransitionTime time, ref ValueStringBuilder serializedText)
		{
			serializedText.Append('[');
			serializedText.Append(time.IsFixedDateRule ? '1' : '0');
			serializedText.Append(';');
			serializedText.AppendSpanFormattable(time.TimeOfDay, "HH:mm:ss.FFF", DateTimeFormatInfo.InvariantInfo);
			serializedText.Append(';');
			serializedText.AppendSpanFormattable(time.Month, null, CultureInfo.InvariantCulture);
			serializedText.Append(';');
			if (time.IsFixedDateRule)
			{
				serializedText.AppendSpanFormattable(time.Day, null, CultureInfo.InvariantCulture);
				serializedText.Append(';');
			}
			else
			{
				serializedText.AppendSpanFormattable(time.Week, null, CultureInfo.InvariantCulture);
				serializedText.Append(';');
				serializedText.AppendSpanFormattable((int)time.DayOfWeek, null, CultureInfo.InvariantCulture);
				serializedText.Append(';');
			}
			serializedText.Append(']');
		}

		private static void VerifyIsEscapableCharacter(char c)
		{
			if (c != '\\' && c != ';' && c != '[' && c != ']')
			{
				throw new SerializationException(SR.Format("Serialization_InvalidEscapeSequence", c));
			}
		}

		private void SkipVersionNextDataFields(int depth)
		{
			if (_currentTokenStartIndex < 0 || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			State state = State.NotEscaped;
			for (int i = _currentTokenStartIndex; i < _serializedText.Length; i++)
			{
				switch (state)
				{
				case State.Escaped:
					VerifyIsEscapableCharacter(_serializedText[i]);
					state = State.NotEscaped;
					break;
				case State.NotEscaped:
					switch (_serializedText[i])
					{
					case '\\':
						state = State.Escaped;
						break;
					case '[':
						depth++;
						break;
					case ']':
						depth--;
						if (depth == 0)
						{
							_currentTokenStartIndex = i + 1;
							if (_currentTokenStartIndex >= _serializedText.Length)
							{
								_state = State.EndOfLine;
							}
							else
							{
								_state = State.StartOfToken;
							}
							return;
						}
						break;
					case '\0':
						throw new SerializationException("Serialization_InvalidData");
					}
					break;
				}
			}
			throw new SerializationException("Serialization_InvalidData");
		}

		private string GetNextStringValue()
		{
			if (_state == State.EndOfLine)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_currentTokenStartIndex < 0 || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			State state = State.NotEscaped;
			Span<char> initialBuffer = stackalloc char[64];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			for (int i = _currentTokenStartIndex; i < _serializedText.Length; i++)
			{
				switch (state)
				{
				case State.Escaped:
					VerifyIsEscapableCharacter(_serializedText[i]);
					valueStringBuilder.Append(_serializedText[i]);
					state = State.NotEscaped;
					break;
				case State.NotEscaped:
					switch (_serializedText[i])
					{
					case '\\':
						state = State.Escaped;
						break;
					case '[':
						throw new SerializationException("Serialization_InvalidData");
					case ']':
						throw new SerializationException("Serialization_InvalidData");
					case ';':
						_currentTokenStartIndex = i + 1;
						if (_currentTokenStartIndex >= _serializedText.Length)
						{
							_state = State.EndOfLine;
						}
						else
						{
							_state = State.StartOfToken;
						}
						return valueStringBuilder.ToString();
					case '\0':
						throw new SerializationException("Serialization_InvalidData");
					default:
						valueStringBuilder.Append(_serializedText[i]);
						break;
					}
					break;
				}
			}
			if (state == State.Escaped)
			{
				throw new SerializationException(SR.Format("Serialization_InvalidEscapeSequence", string.Empty));
			}
			throw new SerializationException("Serialization_InvalidData");
		}

		private DateTime GetNextDateTimeValue(string format)
		{
			if (!DateTime.TryParseExact(GetNextStringValue(), format, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out var result))
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			return result;
		}

		private TimeSpan GetNextTimeSpanValue()
		{
			int nextInt32Value = GetNextInt32Value();
			try
			{
				return new TimeSpan(0, nextInt32Value, 0);
			}
			catch (ArgumentOutOfRangeException innerException)
			{
				throw new SerializationException("Serialization_InvalidData", innerException);
			}
		}

		private int GetNextInt32Value()
		{
			if (!int.TryParse(GetNextStringValue(), NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var result))
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			return result;
		}

		private AdjustmentRule[] GetNextAdjustmentRuleArrayValue()
		{
			List<AdjustmentRule> list = new List<AdjustmentRule>(1);
			int num = 0;
			for (AdjustmentRule nextAdjustmentRuleValue = GetNextAdjustmentRuleValue(); nextAdjustmentRuleValue != null; nextAdjustmentRuleValue = GetNextAdjustmentRuleValue())
			{
				list.Add(nextAdjustmentRuleValue);
				num++;
			}
			if (_state == State.EndOfLine)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_currentTokenStartIndex < 0 || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (num == 0)
			{
				return null;
			}
			return list.ToArray();
		}

		private AdjustmentRule GetNextAdjustmentRuleValue()
		{
			if (_state == State.EndOfLine)
			{
				return null;
			}
			if (_currentTokenStartIndex < 0 || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_serializedText[_currentTokenStartIndex] == ';')
			{
				return null;
			}
			if (_serializedText[_currentTokenStartIndex] != '[')
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			_currentTokenStartIndex++;
			DateTime nextDateTimeValue = GetNextDateTimeValue("MM:dd:yyyy");
			DateTime nextDateTimeValue2 = GetNextDateTimeValue("MM:dd:yyyy");
			TimeSpan nextTimeSpanValue = GetNextTimeSpanValue();
			TransitionTime nextTransitionTimeValue = GetNextTransitionTimeValue();
			TransitionTime nextTransitionTimeValue2 = GetNextTransitionTimeValue();
			TimeSpan baseUtcOffsetDelta = TimeSpan.Zero;
			int num = 0;
			if (_state == State.EndOfLine || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			bool flag = char.IsAsciiDigit(_serializedText[_currentTokenStartIndex]);
			char c;
			if (!flag)
			{
				c = _serializedText[_currentTokenStartIndex];
				bool flag2 = ((c == '+' || c == '-') ? true : false);
				flag = flag2;
			}
			if (flag)
			{
				baseUtcOffsetDelta = GetNextTimeSpanValue();
			}
			c = _serializedText[_currentTokenStartIndex];
			if ((c == '0' || c == '1') ? true : false)
			{
				num = GetNextInt32Value();
			}
			if (_state == State.EndOfLine || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_serializedText[_currentTokenStartIndex] != ']')
			{
				SkipVersionNextDataFields(1);
			}
			else
			{
				_currentTokenStartIndex++;
			}
			AdjustmentRule result;
			try
			{
				result = AdjustmentRule.CreateAdjustmentRule(nextDateTimeValue, nextDateTimeValue2, nextTimeSpanValue, nextTransitionTimeValue, nextTransitionTimeValue2, baseUtcOffsetDelta, num > 0);
			}
			catch (ArgumentException innerException)
			{
				throw new SerializationException("Serialization_InvalidData", innerException);
			}
			if (_currentTokenStartIndex >= _serializedText.Length)
			{
				_state = State.EndOfLine;
			}
			else
			{
				_state = State.StartOfToken;
			}
			return result;
		}

		private TransitionTime GetNextTransitionTimeValue()
		{
			if (_state == State.EndOfLine || (_currentTokenStartIndex < _serializedText.Length && _serializedText[_currentTokenStartIndex] == ']'))
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_currentTokenStartIndex < 0 || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_serializedText[_currentTokenStartIndex] != '[')
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			_currentTokenStartIndex++;
			int nextInt32Value = GetNextInt32Value();
			if (nextInt32Value != 0 && nextInt32Value != 1)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			DateTime timeOfDay = TimeOnly.FromDateTime(GetNextDateTimeValue("HH:mm:ss.FFF")).ToDateTime();
			int nextInt32Value2 = GetNextInt32Value();
			TransitionTime result;
			if (nextInt32Value == 1)
			{
				int nextInt32Value3 = GetNextInt32Value();
				try
				{
					result = TransitionTime.CreateFixedDateRule(timeOfDay, nextInt32Value2, nextInt32Value3);
				}
				catch (ArgumentException innerException)
				{
					throw new SerializationException("Serialization_InvalidData", innerException);
				}
			}
			else
			{
				int nextInt32Value4 = GetNextInt32Value();
				int nextInt32Value5 = GetNextInt32Value();
				try
				{
					result = TransitionTime.CreateFloatingDateRule(timeOfDay, nextInt32Value2, nextInt32Value4, (DayOfWeek)nextInt32Value5);
				}
				catch (ArgumentException innerException2)
				{
					throw new SerializationException("Serialization_InvalidData", innerException2);
				}
			}
			if (_state == State.EndOfLine || _currentTokenStartIndex >= _serializedText.Length)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_serializedText[_currentTokenStartIndex] != ']')
			{
				SkipVersionNextDataFields(1);
			}
			else
			{
				_currentTokenStartIndex++;
			}
			bool flag = false;
			if (_currentTokenStartIndex < _serializedText.Length && _serializedText[_currentTokenStartIndex] == ';')
			{
				_currentTokenStartIndex++;
				flag = true;
			}
			if (!flag)
			{
				throw new SerializationException("Serialization_InvalidData");
			}
			if (_currentTokenStartIndex >= _serializedText.Length)
			{
				_state = State.EndOfLine;
			}
			else
			{
				_state = State.StartOfToken;
			}
			return result;
		}
	}

	[Serializable]
	public readonly struct TransitionTime : IEquatable<TransitionTime>, ISerializable, IDeserializationCallback
	{
		private readonly DateTime _timeOfDay;

		private readonly byte _month;

		private readonly byte _week;

		private readonly byte _day;

		private readonly DayOfWeek _dayOfWeek;

		private readonly bool _isFixedDateRule;

		public DateTime TimeOfDay => _timeOfDay;

		public int Month => _month;

		public int Week => _week;

		public int Day => _day;

		public DayOfWeek DayOfWeek => _dayOfWeek;

		public bool IsFixedDateRule => _isFixedDateRule;

		public override bool Equals([NotNullWhen(true)] object? obj)
		{
			if (obj is TransitionTime)
			{
				return Equals((TransitionTime)obj);
			}
			return false;
		}

		public static bool operator ==(TransitionTime t1, TransitionTime t2)
		{
			return t1.Equals(t2);
		}

		public static bool operator !=(TransitionTime t1, TransitionTime t2)
		{
			return !t1.Equals(t2);
		}

		public bool Equals(TransitionTime other)
		{
			if (_isFixedDateRule == other._isFixedDateRule && _timeOfDay == other._timeOfDay && _month == other._month)
			{
				if (!other._isFixedDateRule)
				{
					if (_week == other._week)
					{
						return _dayOfWeek == other._dayOfWeek;
					}
					return false;
				}
				return _day == other._day;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _month ^ (_week << 8);
		}

		private TransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek, bool isFixedDateRule)
		{
			ValidateTransitionTime(timeOfDay, month, week, day, dayOfWeek);
			_timeOfDay = timeOfDay;
			_month = (byte)month;
			_week = (byte)week;
			_day = (byte)day;
			_dayOfWeek = dayOfWeek;
			_isFixedDateRule = isFixedDateRule;
		}

		public static TransitionTime CreateFixedDateRule(DateTime timeOfDay, int month, int day)
		{
			return new TransitionTime(timeOfDay, month, 1, day, DayOfWeek.Sunday, isFixedDateRule: true);
		}

		public static TransitionTime CreateFloatingDateRule(DateTime timeOfDay, int month, int week, DayOfWeek dayOfWeek)
		{
			return new TransitionTime(timeOfDay, month, week, 1, dayOfWeek, isFixedDateRule: false);
		}

		private static void ValidateTransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek)
		{
			if (timeOfDay.Kind != DateTimeKind.Unspecified)
			{
				throw new ArgumentException("Argument_DateTimeKindMustBeUnspecified", "timeOfDay");
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", "ArgumentOutOfRange_MonthParam");
			}
			if (day < 1 || day > 31)
			{
				throw new ArgumentOutOfRangeException("day", "ArgumentOutOfRange_DayParam");
			}
			if (week < 1 || week > 5)
			{
				throw new ArgumentOutOfRangeException("week", "ArgumentOutOfRange_Week");
			}
			if (dayOfWeek < DayOfWeek.Sunday || dayOfWeek > DayOfWeek.Saturday)
			{
				throw new ArgumentOutOfRangeException("dayOfWeek", "ArgumentOutOfRange_DayOfWeek");
			}
			if (timeOfDay.Ticks >= 864000000000L || (ulong)timeOfDay.Ticks % 10000uL != 0L)
			{
				throw new ArgumentException("Argument_DateTimeHasTicks", "timeOfDay");
			}
		}

		void IDeserializationCallback.OnDeserialization(object sender)
		{
			if (this != default(TransitionTime))
			{
				try
				{
					ValidateTransitionTime(_timeOfDay, _month, _week, _day, _dayOfWeek);
				}
				catch (ArgumentException innerException)
				{
					throw new SerializationException("Serialization_InvalidData", innerException);
				}
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			ArgumentNullException.ThrowIfNull(info, "info");
			info.AddValue("TimeOfDay", _timeOfDay);
			info.AddValue("Month", _month);
			info.AddValue("Week", _week);
			info.AddValue("Day", _day);
			info.AddValue("DayOfWeek", _dayOfWeek);
			info.AddValue("IsFixedDateRule", _isFixedDateRule);
		}

		private TransitionTime(SerializationInfo info, StreamingContext context)
		{
			ArgumentNullException.ThrowIfNull(info, "info");
			_timeOfDay = (DateTime)info.GetValue("TimeOfDay", typeof(DateTime));
			_month = (byte)info.GetValue("Month", typeof(byte));
			_week = (byte)info.GetValue("Week", typeof(byte));
			_day = (byte)info.GetValue("Day", typeof(byte));
			_dayOfWeek = (DayOfWeek)info.GetValue("DayOfWeek", typeof(DayOfWeek));
			_isFixedDateRule = (bool)info.GetValue("IsFixedDateRule", typeof(bool));
		}
	}

	private readonly struct TZifType
	{
		public readonly TimeSpan UtcOffset;

		public readonly bool IsDst;

		public readonly byte AbbreviationIndex;

		public TZifType(byte[] data, int index)
		{
			if (data == null || data.Length < index + 6)
			{
				throw new ArgumentException("Argument_TimeZoneInfoInvalidTZif", "data");
			}
			UtcOffset = new TimeSpan(0, 0, TZif_ToInt32(data, index));
			IsDst = data[index + 4] != 0;
			AbbreviationIndex = data[index + 5];
		}
	}

	private readonly struct TZifHead
	{
		public readonly uint Magic;

		public readonly TZVersion Version;

		public readonly uint IsGmtCount;

		public readonly uint IsStdCount;

		public readonly uint LeapCount;

		public readonly uint TimeCount;

		public readonly uint TypeCount;

		public readonly uint CharCount;

		public TZifHead(byte[] data, int index)
		{
			if (data == null || data.Length < 44)
			{
				throw new ArgumentException("bad data", "data");
			}
			Magic = (uint)TZif_ToInt32(data, index);
			if (Magic != 1415211366)
			{
				throw new ArgumentException("Argument_TimeZoneInfoBadTZif", "data");
			}
			Version = data[index + 4] switch
			{
				51 => TZVersion.V3, 
				50 => TZVersion.V2, 
				_ => TZVersion.V1, 
			};
			IsGmtCount = (uint)TZif_ToInt32(data, index + 20);
			IsStdCount = (uint)TZif_ToInt32(data, index + 24);
			LeapCount = (uint)TZif_ToInt32(data, index + 28);
			TimeCount = (uint)TZif_ToInt32(data, index + 32);
			TypeCount = (uint)TZif_ToInt32(data, index + 36);
			CharCount = (uint)TZif_ToInt32(data, index + 40);
		}
	}

	private enum TZVersion : byte
	{
		V1,
		V2,
		V3
	}

	private sealed class AndroidTzData
	{
		private string[] _ids;

		private int[] _byteOffsets;

		private int[] _lengths;

		private bool[] _isBackwards;

		private string _tzFileDir;

		private string _tzFilePath;

		private static string GetApexTimeDataRoot()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("ANDROID_TZDATA_ROOT");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				return environmentVariable;
			}
			return "/apex/com.android.tzdata";
		}

		private static string GetApexRuntimeRoot()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("ANDROID_RUNTIME_ROOT");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				return environmentVariable;
			}
			return "/apex/com.android.runtime";
		}

		public AndroidTzData()
		{
			_003C_003Ey__InlineArray4<string> buffer = default(_003C_003Ey__InlineArray4<string>);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<string>, string>(ref buffer, 0) = GetApexTimeDataRoot() + "/etc/tz/";
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<string>, string>(ref buffer, 1) = GetApexRuntimeRoot() + "/etc/tz/";
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<string>, string>(ref buffer, 2) = Environment.GetEnvironmentVariable("ANDROID_DATA") + "/misc/zoneinfo/";
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<string>, string>(ref buffer, 3) = Environment.GetEnvironmentVariable("ANDROID_ROOT") + "/usr/share/zoneinfo/";
			ReadOnlySpan<string> readOnlySpan = _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray4<string>, string>(in buffer, 4);
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				string text = readOnlySpan[i];
				string text2 = Path.Combine(text, "tzdata");
				if (LoadData(text, text2))
				{
					_tzFileDir = text;
					_tzFilePath = text2;
					return;
				}
			}
			throw new TimeZoneNotFoundException("TimeZoneNotFound_ValidTimeZoneFileMissing");
		}

		private static HashSet<string> FilterBackwardIDs(string tzFileDir)
		{
			string path = Path.Combine(tzFileDir, "tzlookup.xml");
			if (!File.Exists(path))
			{
				return null;
			}
			HashSet<string> hashSet = null;
			try
			{
				using StreamReader streamReader = File.OpenText(path);
				while (streamReader.Peek() >= 0)
				{
					string text;
					if (!(text = streamReader.ReadLine()).AsSpan().TrimStart().StartsWith("<id".AsSpan(), StringComparison.Ordinal))
					{
						continue;
					}
					int num = text.IndexOf('>') + 1;
					int num2 = text.LastIndexOf("</", StringComparison.Ordinal) - num;
					if (num > 0 && num2 >= 0)
					{
						if (hashSet == null)
						{
							hashSet = new HashSet<string>();
						}
						string item = text.Substring(num, num2);
						hashSet.Add(item);
					}
				}
				return hashSet;
			}
			catch
			{
				return null;
			}
		}

		[MemberNotNullWhen(true, "_ids")]
		[MemberNotNullWhen(true, "_byteOffsets")]
		[MemberNotNullWhen(true, "_lengths")]
		[MemberNotNullWhen(true, "_isBackwards")]
		private bool LoadData(string tzFileDir, string path)
		{
			if (!File.Exists(path))
			{
				return false;
			}
			try
			{
				using (FileStream fs = File.OpenRead(path))
				{
					LoadTzFile(tzFileDir, fs);
				}
				return true;
			}
			catch
			{
			}
			return false;
		}

		[MemberNotNull("_ids")]
		[MemberNotNull("_byteOffsets")]
		[MemberNotNull("_lengths")]
		[MemberNotNull("_isBackwards")]
		private void LoadTzFile(string tzFileDir, Stream fs)
		{
			Span<byte> span = stackalloc byte[24];
			ReadTzDataIntoBuffer(fs, 0L, span);
			LoadHeader(span, out var indexOffset, out var dataOffset);
			ReadIndex(tzFileDir, fs, indexOffset, dataOffset);
		}

		private static void LoadHeader(ReadOnlySpan<byte> buffer, out int indexOffset, out int dataOffset)
		{
			ushort num = (ushort)TZif_ToInt16(buffer.Slice(0, 2));
			uint num2 = (uint)TZif_ToInt32(buffer.Slice(2, 4));
			if (num != 29818 || num2 != 1684108385 || buffer[11] != 0)
			{
				StringBuilder stringBuilder = new StringBuilder(buffer.Length);
				for (int i = 0; i < 12; i++)
				{
					stringBuilder.Append(' ').Append(HexConverter.ToCharLower(buffer[i]));
				}
				throw new InvalidOperationException(SR.Format("InvalidOperation_BadTZHeader", "tzdata", stringBuilder.ToString()));
			}
			indexOffset = TZif_ToInt32(buffer.Slice(12, 4));
			dataOffset = TZif_ToInt32(buffer.Slice(16, 4));
		}

		[MemberNotNull("_ids")]
		[MemberNotNull("_byteOffsets")]
		[MemberNotNull("_lengths")]
		[MemberNotNull("_isBackwards")]
		private void ReadIndex(string tzFileDir, Stream fs, int indexOffset, int dataOffset)
		{
			int num = (dataOffset - indexOffset) / 52;
			_byteOffsets = new int[num];
			_ids = new string[num];
			_lengths = new int[num];
			_isBackwards = new bool[num];
			HashSet<string> hashSet = FilterBackwardIDs(tzFileDir);
			for (int i = 0; i < num; i++)
			{
				LoadEntryAt(fs, indexOffset + 52 * i, out var id, out var byteOffset, out var length);
				_byteOffsets[i] = byteOffset + dataOffset;
				_ids[i] = id;
				_lengths[i] = length;
				if (hashSet != null)
				{
					_isBackwards[i] = !hashSet.Contains(id);
				}
				if (length < 24)
				{
					throw new InvalidOperationException("InvalidOperation_BadIndexLength");
				}
			}
		}

		private void ReadTzDataIntoBuffer(Stream fs, long position, Span<byte> buffer)
		{
			fs.Position = position;
			int num = 0;
			int num2 = buffer.Length;
			while (num2 > 0)
			{
				int num3 = fs.Read(buffer.Slice(num));
				if (num3 == 0)
				{
					break;
				}
				num += num3;
				num2 -= num3;
			}
			if (num2 != 0)
			{
				throw new InvalidOperationException(SR.Format("InvalidOperation_ReadTZError", _tzFilePath, position, buffer.Length, num, buffer.Length));
			}
		}

		private void LoadEntryAt(Stream fs, long position, out string id, out int byteOffset, out int length)
		{
			Span<byte> buffer = stackalloc byte[52];
			ReadTzDataIntoBuffer(fs, position, buffer);
			int i;
			for (i = 0; buffer[i] != 0 && i < 40; i++)
			{
			}
			id = Encoding.UTF8.GetString(buffer.Slice(0, i));
			byteOffset = TZif_ToInt32(buffer.Slice(40, 4));
			length = TZif_ToInt32(buffer.Slice(44, 4));
		}

		public string[] GetTimeZoneIds()
		{
			if (Invariant)
			{
				return new string[1] { "UTC" };
			}
			string[] array = new string[((ReadOnlySpan<bool>)_isBackwards.AsSpan(0, _ids.Length)).Count(value: false)];
			int num = 0;
			for (int i = 0; i < _ids.Length; i++)
			{
				if (!_isBackwards[i])
				{
					array[num] = _ids[i];
					num++;
				}
			}
			return array;
		}

		public string GetTimeZoneDirectory()
		{
			return _tzFilePath;
		}

		public byte[] GetTimeZoneData(string id)
		{
			int num = Array.BinarySearch(_ids, id, (IComparer<string>?)StringComparer.Ordinal);
			if (num < 0)
			{
				throw new InvalidOperationException(SR.Format("TimeZoneNotFound_MissingData", id));
			}
			int num2 = _byteOffsets[num];
			byte[] array = new byte[_lengths[num]];
			using FileStream fs = File.OpenRead(_tzFilePath);
			ReadTzDataIntoBuffer(fs, num2, array);
			return array;
		}
	}

	private readonly string _id;

	private string _displayName;

	private string _standardDisplayName;

	private string _daylightDisplayName;

	private readonly TimeSpan _baseUtcOffset;

	private readonly bool _supportsDaylightSavingTime;

	private readonly AdjustmentRule[] _adjustmentRules;

	private List<TimeZoneInfo> _equivalentZones;

	private static readonly TimeZoneInfo s_utcTimeZone = CreateUtcTimeZone();

	private static CachedData s_cachedData = new CachedData();

	private static readonly DateTime s_maxDateOnly = new DateTime(9999, 12, 31);

	private static readonly DateTime s_minDateOnly = new DateTime(1, 1, 2);

	private string _standardAbbrevName;

	private string _daylightAbbrevName;

	private static readonly TransitionTime s_daylightRuleMarker = TransitionTime.CreateFixedDateRule(DateTime.MinValue.AddMilliseconds(2.0), 1, 1);

	private static AndroidTzData s_tzData;

	private static readonly string[] s_ZonesThatUseLocationName = new string[5] { "Europe/Minsk", "Europe/Moscow", "Europe/Simferopol", "Pacific/Apia", "Pacific/Pitcairn" };

	private static CultureInfo _uiCulture;

	[FeatureSwitchDefinition("System.TimeZoneInfo.Invariant")]
	internal static bool Invariant { get; } = AppContextConfigHelper.GetBooleanConfig("System.TimeZoneInfo.Invariant", "DOTNET_SYSTEM_TIMEZONE_INVARIANT");

	public string Id => _id;

	public bool HasIanaId { get; }

	public string DisplayName
	{
		get
		{
			if (_displayName == null)
			{
				Interlocked.CompareExchange(ref _displayName, PopulateDisplayName(), null);
			}
			return _displayName ?? string.Empty;
		}
	}

	public string StandardName
	{
		get
		{
			if (_standardDisplayName == null)
			{
				Interlocked.CompareExchange(ref _standardDisplayName, PopulateStandardDisplayName(), null);
			}
			return _standardDisplayName ?? string.Empty;
		}
	}

	public string DaylightName
	{
		get
		{
			if (_daylightDisplayName == null)
			{
				Interlocked.CompareExchange(ref _daylightDisplayName, PopulateDaylightDisplayName(), null);
			}
			return _daylightDisplayName ?? string.Empty;
		}
	}

	public TimeSpan BaseUtcOffset => _baseUtcOffset;

	public bool SupportsDaylightSavingTime => _supportsDaylightSavingTime;

	public static TimeZoneInfo Local => s_cachedData.Local;

	public static TimeZoneInfo Utc => s_utcTimeZone;

	private static TimeSpan MaxOffset => TimeSpan.FromHours(14);

	private static TimeSpan MinOffset => TimeSpan.FromHours(-14);

	private string NameLookupId
	{
		get
		{
			string text;
			if (!HasIanaId)
			{
				if (_equivalentZones != null && _equivalentZones.Count > 0)
				{
					return _equivalentZones[0].Id;
				}
				text = GetAlternativeId(Id, out var _);
				if (text == null)
				{
					return Id;
				}
			}
			else
			{
				text = Id;
			}
			return text;
		}
	}

	private static AndroidTzData AndroidTzDataInstance
	{
		get
		{
			if (s_tzData == null)
			{
				Interlocked.CompareExchange(ref s_tzData, new AndroidTzData(), null);
			}
			return s_tzData;
		}
	}

	private static CultureInfo UICulture
	{
		get
		{
			if (_uiCulture == null)
			{
				CultureInfo cultureInfo = CultureInfo.CurrentUICulture;
				if (cultureInfo.Name.Length == 0)
				{
					cultureInfo = CultureInfo.GetCultureInfo("en-US");
				}
				Interlocked.CompareExchange(ref _uiCulture, cultureInfo, null);
			}
			return _uiCulture;
		}
	}

	public TimeSpan[] GetAmbiguousTimeOffsets(DateTimeOffset dateTimeOffset)
	{
		if (!SupportsDaylightSavingTime)
		{
			throw new ArgumentException("Argument_DateTimeOffsetIsNotAmbiguous", "dateTimeOffset");
		}
		DateTime dateTime = ConvertTime(dateTimeOffset, this).DateTime;
		bool flag = false;
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForAmbiguousOffsets = GetAdjustmentRuleForAmbiguousOffsets(dateTime, out ruleIndex);
		if (adjustmentRuleForAmbiguousOffsets != null && adjustmentRuleForAmbiguousOffsets.HasDaylightSaving)
		{
			DaylightTimeStruct daylightTime = GetDaylightTime(dateTime.Year, adjustmentRuleForAmbiguousOffsets, ruleIndex);
			flag = GetIsAmbiguousTime(dateTime, adjustmentRuleForAmbiguousOffsets, daylightTime);
		}
		if (!flag)
		{
			throw new ArgumentException("Argument_DateTimeOffsetIsNotAmbiguous", "dateTimeOffset");
		}
		TimeSpan[] array = new TimeSpan[2];
		TimeSpan timeSpan = _baseUtcOffset + adjustmentRuleForAmbiguousOffsets.BaseUtcOffsetDelta;
		if (adjustmentRuleForAmbiguousOffsets.DaylightDelta > TimeSpan.Zero)
		{
			array[0] = timeSpan;
			array[1] = timeSpan + adjustmentRuleForAmbiguousOffsets.DaylightDelta;
		}
		else
		{
			array[0] = timeSpan + adjustmentRuleForAmbiguousOffsets.DaylightDelta;
			array[1] = timeSpan;
		}
		return array;
	}

	public TimeSpan[] GetAmbiguousTimeOffsets(DateTime dateTime)
	{
		if (!SupportsDaylightSavingTime)
		{
			throw new ArgumentException("Argument_DateTimeIsNotAmbiguous", "dateTime");
		}
		DateTime dateTime2;
		if (dateTime.Kind == DateTimeKind.Local)
		{
			CachedData cachedData = s_cachedData;
			dateTime2 = ConvertTime(dateTime, cachedData.Local, this, TimeZoneInfoOptions.None, cachedData);
		}
		else if (dateTime.Kind == DateTimeKind.Utc)
		{
			CachedData cachedData2 = s_cachedData;
			dateTime2 = ConvertTime(dateTime, s_utcTimeZone, this, TimeZoneInfoOptions.None, cachedData2);
		}
		else
		{
			dateTime2 = dateTime;
		}
		bool flag = false;
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForAmbiguousOffsets = GetAdjustmentRuleForAmbiguousOffsets(dateTime2, out ruleIndex);
		if (adjustmentRuleForAmbiguousOffsets != null && adjustmentRuleForAmbiguousOffsets.HasDaylightSaving)
		{
			DaylightTimeStruct daylightTime = GetDaylightTime(dateTime2.Year, adjustmentRuleForAmbiguousOffsets, ruleIndex);
			flag = GetIsAmbiguousTime(dateTime2, adjustmentRuleForAmbiguousOffsets, daylightTime);
		}
		if (!flag)
		{
			throw new ArgumentException("Argument_DateTimeIsNotAmbiguous", "dateTime");
		}
		TimeSpan[] array = new TimeSpan[2];
		TimeSpan timeSpan = _baseUtcOffset + adjustmentRuleForAmbiguousOffsets.BaseUtcOffsetDelta;
		if (adjustmentRuleForAmbiguousOffsets.DaylightDelta > TimeSpan.Zero)
		{
			array[0] = timeSpan;
			array[1] = timeSpan + adjustmentRuleForAmbiguousOffsets.DaylightDelta;
		}
		else
		{
			array[0] = timeSpan + adjustmentRuleForAmbiguousOffsets.DaylightDelta;
			array[1] = timeSpan;
		}
		return array;
	}

	private AdjustmentRule GetAdjustmentRuleForAmbiguousOffsets(DateTime adjustedTime, out int? ruleIndex)
	{
		AdjustmentRule adjustmentRuleForTime = GetAdjustmentRuleForTime(adjustedTime, out ruleIndex);
		if (adjustmentRuleForTime != null && adjustmentRuleForTime.NoDaylightTransitions && !adjustmentRuleForTime.HasDaylightSaving)
		{
			return GetPreviousAdjustmentRule(adjustmentRuleForTime, ruleIndex);
		}
		return adjustmentRuleForTime;
	}

	private AdjustmentRule GetPreviousAdjustmentRule(AdjustmentRule rule, int? ruleIndex)
	{
		if (ruleIndex.HasValue && 0 < ruleIndex.GetValueOrDefault() && ruleIndex.GetValueOrDefault() < _adjustmentRules.Length)
		{
			return _adjustmentRules[ruleIndex.GetValueOrDefault() - 1];
		}
		AdjustmentRule result = rule;
		for (int i = 1; i < _adjustmentRules.Length; i++)
		{
			if (rule == _adjustmentRules[i])
			{
				result = _adjustmentRules[i - 1];
				break;
			}
		}
		return result;
	}

	public TimeSpan GetUtcOffset(DateTimeOffset dateTimeOffset)
	{
		return GetUtcOffsetFromUtc(dateTimeOffset.UtcDateTime, this);
	}

	public TimeSpan GetUtcOffset(DateTime dateTime)
	{
		return GetUtcOffset(dateTime, TimeZoneInfoOptions.NoThrowOnInvalidTime, s_cachedData);
	}

	internal static TimeSpan GetLocalUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags)
	{
		CachedData cachedData = s_cachedData;
		return cachedData.Local.GetUtcOffset(dateTime, flags, cachedData);
	}

	internal TimeSpan GetUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags)
	{
		return GetUtcOffset(dateTime, flags, s_cachedData);
	}

	private TimeSpan GetUtcOffset(DateTime dateTime, TimeZoneInfoOptions flags, CachedData cachedData)
	{
		if (dateTime.Kind == DateTimeKind.Local)
		{
			if (cachedData.GetCorrespondingKind(this) != DateTimeKind.Local)
			{
				return GetUtcOffsetFromUtc(ConvertTime(dateTime, cachedData.Local, s_utcTimeZone, flags), this);
			}
		}
		else if (dateTime.Kind == DateTimeKind.Utc)
		{
			if (cachedData.GetCorrespondingKind(this) == DateTimeKind.Utc)
			{
				return _baseUtcOffset;
			}
			return GetUtcOffsetFromUtc(dateTime, this);
		}
		return GetUtcOffset(dateTime, this);
	}

	public bool IsAmbiguousTime(DateTimeOffset dateTimeOffset)
	{
		if (!_supportsDaylightSavingTime)
		{
			return false;
		}
		return IsAmbiguousTime(ConvertTime(dateTimeOffset, this).DateTime);
	}

	public bool IsAmbiguousTime(DateTime dateTime)
	{
		return IsAmbiguousTime(dateTime, TimeZoneInfoOptions.NoThrowOnInvalidTime);
	}

	internal bool IsAmbiguousTime(DateTime dateTime, TimeZoneInfoOptions flags)
	{
		if (!_supportsDaylightSavingTime)
		{
			return false;
		}
		CachedData cachedData = s_cachedData;
		DateTime dateTime2 = ((dateTime.Kind == DateTimeKind.Local) ? ConvertTime(dateTime, cachedData.Local, this, flags, cachedData) : ((dateTime.Kind == DateTimeKind.Utc) ? ConvertTime(dateTime, s_utcTimeZone, this, flags, cachedData) : dateTime));
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForTime = GetAdjustmentRuleForTime(dateTime2, out ruleIndex);
		if (adjustmentRuleForTime != null && adjustmentRuleForTime.HasDaylightSaving)
		{
			DaylightTimeStruct daylightTime = GetDaylightTime(dateTime2.Year, adjustmentRuleForTime, ruleIndex);
			return GetIsAmbiguousTime(dateTime2, adjustmentRuleForTime, daylightTime);
		}
		return false;
	}

	public bool IsDaylightSavingTime(DateTimeOffset dateTimeOffset)
	{
		GetUtcOffsetFromUtc(dateTimeOffset.UtcDateTime, this, out var isDaylightSavings);
		return isDaylightSavings;
	}

	public bool IsDaylightSavingTime(DateTime dateTime)
	{
		return IsDaylightSavingTime(dateTime, TimeZoneInfoOptions.NoThrowOnInvalidTime, s_cachedData);
	}

	internal bool IsDaylightSavingTime(DateTime dateTime, TimeZoneInfoOptions flags)
	{
		return IsDaylightSavingTime(dateTime, flags, s_cachedData);
	}

	private bool IsDaylightSavingTime(DateTime dateTime, TimeZoneInfoOptions flags, CachedData cachedData)
	{
		if (!_supportsDaylightSavingTime || _adjustmentRules == null)
		{
			return false;
		}
		DateTime dateTime2;
		if (dateTime.Kind == DateTimeKind.Local)
		{
			dateTime2 = ConvertTime(dateTime, cachedData.Local, this, flags, cachedData);
		}
		else
		{
			if (dateTime.Kind == DateTimeKind.Utc)
			{
				if (cachedData.GetCorrespondingKind(this) == DateTimeKind.Utc)
				{
					return false;
				}
				GetUtcOffsetFromUtc(dateTime, this, out var isDaylightSavings);
				return isDaylightSavings;
			}
			dateTime2 = dateTime;
		}
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForTime = GetAdjustmentRuleForTime(dateTime2, out ruleIndex);
		if (adjustmentRuleForTime != null && adjustmentRuleForTime.HasDaylightSaving)
		{
			DaylightTimeStruct daylightTime = GetDaylightTime(dateTime2.Year, adjustmentRuleForTime, ruleIndex);
			return GetIsDaylightSavings(dateTime2, adjustmentRuleForTime, daylightTime);
		}
		return false;
	}

	public bool IsInvalidTime(DateTime dateTime)
	{
		bool result = false;
		if (dateTime.Kind == DateTimeKind.Unspecified || (dateTime.Kind == DateTimeKind.Local && s_cachedData.GetCorrespondingKind(this) == DateTimeKind.Local))
		{
			int? ruleIndex;
			AdjustmentRule adjustmentRuleForTime = GetAdjustmentRuleForTime(dateTime, out ruleIndex);
			if (adjustmentRuleForTime != null && adjustmentRuleForTime.HasDaylightSaving)
			{
				DaylightTimeStruct daylightTime = GetDaylightTime(dateTime.Year, adjustmentRuleForTime, ruleIndex);
				result = GetIsInvalidTime(dateTime, adjustmentRuleForTime, daylightTime);
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	public static void ClearCachedData()
	{
		s_cachedData = new CachedData();
	}

	public static DateTimeOffset ConvertTimeBySystemTimeZoneId(DateTimeOffset dateTimeOffset, string destinationTimeZoneId)
	{
		return ConvertTime(dateTimeOffset, FindSystemTimeZoneById(destinationTimeZoneId));
	}

	public static DateTime ConvertTimeBySystemTimeZoneId(DateTime dateTime, string destinationTimeZoneId)
	{
		return ConvertTime(dateTime, FindSystemTimeZoneById(destinationTimeZoneId));
	}

	public static TimeZoneInfo FindSystemTimeZoneById(string id)
	{
		TimeZoneInfo timeZone;
		Exception e;
		return TryFindSystemTimeZoneById(id, out timeZone, out e) switch
		{
			TimeZoneInfoResult.Success => timeZone, 
			TimeZoneInfoResult.InvalidTimeZoneException => throw e, 
			TimeZoneInfoResult.SecurityException => throw new SecurityException(SR.Format("Security_CannotReadFileData", id), e), 
			_ => throw new TimeZoneNotFoundException(SR.Format("TimeZoneNotFound_MissingData", id), e), 
		};
	}

	public static bool TryFindSystemTimeZoneById(string id, [NotNullWhen(true)] out TimeZoneInfo? timeZoneInfo)
	{
		Exception e;
		return TryFindSystemTimeZoneById(id, out timeZoneInfo, out e) == TimeZoneInfoResult.Success;
	}

	private static TimeZoneInfoResult TryFindSystemTimeZoneById(string id, out TimeZoneInfo timeZone, out Exception e)
	{
		if (string.Equals(id, "UTC", StringComparison.OrdinalIgnoreCase))
		{
			timeZone = Utc;
			e = null;
			return TimeZoneInfoResult.Success;
		}
		ArgumentNullException.ThrowIfNull(id, "id");
		if (id.Length == 0 || id.Length > 255 || id.Contains('\0'))
		{
			timeZone = null;
			e = null;
			return TimeZoneInfoResult.TimeZoneNotFoundException;
		}
		CachedData cachedData = s_cachedData;
		lock (cachedData)
		{
			return TryGetTimeZone(id, out timeZone, out e, cachedData);
		}
	}

	public static DateTime ConvertTimeBySystemTimeZoneId(DateTime dateTime, string sourceTimeZoneId, string destinationTimeZoneId)
	{
		if (dateTime.Kind == DateTimeKind.Local && string.Equals(sourceTimeZoneId, Local.Id, StringComparison.OrdinalIgnoreCase))
		{
			CachedData cachedData = s_cachedData;
			return ConvertTime(dateTime, cachedData.Local, FindSystemTimeZoneById(destinationTimeZoneId), TimeZoneInfoOptions.None, cachedData);
		}
		if (dateTime.Kind == DateTimeKind.Utc && string.Equals(sourceTimeZoneId, Utc.Id, StringComparison.OrdinalIgnoreCase))
		{
			return ConvertTime(dateTime, s_utcTimeZone, FindSystemTimeZoneById(destinationTimeZoneId), TimeZoneInfoOptions.None, s_cachedData);
		}
		return ConvertTime(dateTime, FindSystemTimeZoneById(sourceTimeZoneId), FindSystemTimeZoneById(destinationTimeZoneId));
	}

	public static DateTimeOffset ConvertTime(DateTimeOffset dateTimeOffset, TimeZoneInfo destinationTimeZone)
	{
		ArgumentNullException.ThrowIfNull(destinationTimeZone, "destinationTimeZone");
		DateTime utcDateTime = dateTimeOffset.UtcDateTime;
		TimeSpan utcOffsetFromUtc = GetUtcOffsetFromUtc(utcDateTime, destinationTimeZone);
		long num = utcDateTime.Ticks + utcOffsetFromUtc.Ticks;
		if (num <= 3155378975999999999L)
		{
			if (num >= 0)
			{
				return new DateTimeOffset(num, utcOffsetFromUtc);
			}
			return DateTimeOffset.MinValue;
		}
		return DateTimeOffset.MaxValue;
	}

	public static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo destinationTimeZone)
	{
		ArgumentNullException.ThrowIfNull(destinationTimeZone, "destinationTimeZone");
		if (dateTime.Ticks == 0L)
		{
			ClearCachedData();
		}
		CachedData cachedData = s_cachedData;
		TimeZoneInfo sourceTimeZone = ((dateTime.Kind == DateTimeKind.Utc) ? s_utcTimeZone : cachedData.Local);
		return ConvertTime(dateTime, sourceTimeZone, destinationTimeZone, TimeZoneInfoOptions.None, cachedData);
	}

	public static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone)
	{
		return ConvertTime(dateTime, sourceTimeZone, destinationTimeZone, TimeZoneInfoOptions.None, s_cachedData);
	}

	internal static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone, TimeZoneInfoOptions flags)
	{
		return ConvertTime(dateTime, sourceTimeZone, destinationTimeZone, flags, s_cachedData);
	}

	private static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone, TimeZoneInfoOptions flags, CachedData cachedData)
	{
		ArgumentNullException.ThrowIfNull(sourceTimeZone, "sourceTimeZone");
		ArgumentNullException.ThrowIfNull(destinationTimeZone, "destinationTimeZone");
		DateTimeKind correspondingKind = cachedData.GetCorrespondingKind(sourceTimeZone);
		if ((flags & TimeZoneInfoOptions.NoThrowOnInvalidTime) == 0 && dateTime.Kind != DateTimeKind.Unspecified && dateTime.Kind != correspondingKind)
		{
			throw new ArgumentException("Argument_ConvertMismatch", "sourceTimeZone");
		}
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForTime = sourceTimeZone.GetAdjustmentRuleForTime(dateTime, out ruleIndex);
		TimeSpan baseUtcOffset = sourceTimeZone.BaseUtcOffset;
		if (adjustmentRuleForTime != null)
		{
			baseUtcOffset += adjustmentRuleForTime.BaseUtcOffsetDelta;
			if (adjustmentRuleForTime.HasDaylightSaving)
			{
				DaylightTimeStruct daylightTime = sourceTimeZone.GetDaylightTime(dateTime.Year, adjustmentRuleForTime, ruleIndex);
				if ((flags & TimeZoneInfoOptions.NoThrowOnInvalidTime) == 0 && GetIsInvalidTime(dateTime, adjustmentRuleForTime, daylightTime))
				{
					throw new ArgumentException("Argument_DateTimeIsInvalid", "dateTime");
				}
				bool isDaylightSavings = GetIsDaylightSavings(dateTime, adjustmentRuleForTime, daylightTime);
				baseUtcOffset += (isDaylightSavings ? adjustmentRuleForTime.DaylightDelta : TimeSpan.Zero);
			}
		}
		DateTimeKind correspondingKind2 = cachedData.GetCorrespondingKind(destinationTimeZone);
		if (dateTime.Kind != DateTimeKind.Unspecified && correspondingKind != DateTimeKind.Unspecified && correspondingKind == correspondingKind2)
		{
			return dateTime;
		}
		bool isAmbiguousLocalDst;
		DateTime dateTime2 = ConvertUtcToTimeZone(dateTime.Ticks - baseUtcOffset.Ticks, destinationTimeZone, out isAmbiguousLocalDst);
		if (correspondingKind2 == DateTimeKind.Local)
		{
			return new DateTime(dateTime2.Ticks, DateTimeKind.Local, isAmbiguousLocalDst);
		}
		return new DateTime(dateTime2.Ticks, correspondingKind2);
	}

	public static DateTime ConvertTimeFromUtc(DateTime dateTime, TimeZoneInfo destinationTimeZone)
	{
		return ConvertTime(dateTime, s_utcTimeZone, destinationTimeZone, TimeZoneInfoOptions.None, s_cachedData);
	}

	public static DateTime ConvertTimeToUtc(DateTime dateTime)
	{
		if (dateTime.Kind == DateTimeKind.Utc)
		{
			return dateTime;
		}
		CachedData cachedData = s_cachedData;
		return ConvertTime(dateTime, cachedData.Local, s_utcTimeZone, TimeZoneInfoOptions.None, cachedData);
	}

	internal static DateTime ConvertTimeToUtc(DateTime dateTime, TimeZoneInfoOptions flags)
	{
		CachedData cachedData = s_cachedData;
		return ConvertTime(dateTime, cachedData.Local, s_utcTimeZone, flags, cachedData);
	}

	public static DateTime ConvertTimeToUtc(DateTime dateTime, TimeZoneInfo sourceTimeZone)
	{
		return ConvertTime(dateTime, sourceTimeZone, s_utcTimeZone, TimeZoneInfoOptions.None, s_cachedData);
	}

	public bool Equals([NotNullWhen(true)] TimeZoneInfo? other)
	{
		if (other != null && string.Equals(_id, other._id, StringComparison.OrdinalIgnoreCase))
		{
			return HasSameRules(other);
		}
		return false;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		return Equals(obj as TimeZoneInfo);
	}

	public static TimeZoneInfo FromSerializedString(string source)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		if (source.Length == 0)
		{
			throw new ArgumentException(SR.Format("Argument_InvalidSerializedString", source), "source");
		}
		return StringSerializer.GetDeserializedTimeZoneInfo(source);
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(_id);
	}

	public static ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones()
	{
		return GetSystemTimeZones(skipSorting: false);
	}

	public static ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones(bool skipSorting)
	{
		CachedData cachedData = s_cachedData;
		lock (cachedData)
		{
			if ((skipSorting ? cachedData._readOnlyUnsortedSystemTimeZones : cachedData._readOnlySystemTimeZones) == null)
			{
				if (!cachedData._allSystemTimeZonesRead)
				{
					PopulateAllSystemTimeZones(cachedData);
					cachedData._allSystemTimeZonesRead = true;
				}
				if (cachedData._systemTimeZones != null)
				{
					TimeZoneInfo[] array = new TimeZoneInfo[cachedData._systemTimeZones.Count];
					cachedData._systemTimeZones.Values.CopyTo(array, 0);
					if (!skipSorting)
					{
						Array.Sort(array, delegate(TimeZoneInfo x, TimeZoneInfo y)
						{
							int num = x.BaseUtcOffset.CompareTo(y.BaseUtcOffset);
							return (num != 0) ? num : string.CompareOrdinal(x.DisplayName, y.DisplayName);
						});
						cachedData._readOnlySystemTimeZones = (cachedData._readOnlyUnsortedSystemTimeZones = new ReadOnlyCollection<TimeZoneInfo>(array));
					}
					else
					{
						cachedData._readOnlyUnsortedSystemTimeZones = new ReadOnlyCollection<TimeZoneInfo>(array);
					}
				}
				else
				{
					cachedData._readOnlySystemTimeZones = (cachedData._readOnlyUnsortedSystemTimeZones = ReadOnlyCollection<TimeZoneInfo>.Empty);
				}
			}
		}
		if (!skipSorting)
		{
			return cachedData._readOnlySystemTimeZones;
		}
		return cachedData._readOnlyUnsortedSystemTimeZones;
	}

	public bool HasSameRules(TimeZoneInfo other)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		if (_baseUtcOffset != other._baseUtcOffset || _supportsDaylightSavingTime != other._supportsDaylightSavingTime)
		{
			return false;
		}
		AdjustmentRule[] adjustmentRules = _adjustmentRules;
		AdjustmentRule[] adjustmentRules2 = other._adjustmentRules;
		if (adjustmentRules == null && adjustmentRules2 == null)
		{
			return true;
		}
		return ((ReadOnlySpan<AdjustmentRule>)adjustmentRules.AsSpan()).SequenceEqual((ReadOnlySpan<AdjustmentRule>)adjustmentRules2);
	}

	public string ToSerializedString()
	{
		return StringSerializer.GetSerializedString(this);
	}

	public override string ToString()
	{
		return DisplayName;
	}

	private TimeZoneInfo(string id, TimeSpan baseUtcOffset, string displayName, string standardDisplayName, string daylightDisplayName, AdjustmentRule[] adjustmentRules, bool disableDaylightSavingTime, bool hasIanaId = false)
	{
		ValidateTimeZoneInfo(id, baseUtcOffset, adjustmentRules, out var adjustmentRulesSupportDst);
		_id = id;
		_baseUtcOffset = baseUtcOffset;
		_displayName = displayName;
		_standardDisplayName = standardDisplayName;
		_daylightDisplayName = (disableDaylightSavingTime ? null : daylightDisplayName);
		_supportsDaylightSavingTime = adjustmentRulesSupportDst && !disableDaylightSavingTime;
		_adjustmentRules = adjustmentRules;
		HasIanaId = hasIanaId || _id.Equals("UTC", StringComparison.OrdinalIgnoreCase);
	}

	public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseUtcOffset, string? displayName, string? standardDisplayName)
	{
		string windowsId;
		bool hasIanaId = TryConvertIanaIdToWindowsId(id, allocate: false, out windowsId);
		if (standardDisplayName == null)
		{
			standardDisplayName = string.Empty;
		}
		return new TimeZoneInfo(id, baseUtcOffset, displayName ?? string.Empty, standardDisplayName, standardDisplayName, null, disableDaylightSavingTime: false, hasIanaId);
	}

	public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseUtcOffset, string? displayName, string? standardDisplayName, string? daylightDisplayName, AdjustmentRule[]? adjustmentRules)
	{
		return CreateCustomTimeZone(id, baseUtcOffset, displayName, standardDisplayName, daylightDisplayName, adjustmentRules, disableDaylightSavingTime: false);
	}

	public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseUtcOffset, string? displayName, string? standardDisplayName, string? daylightDisplayName, AdjustmentRule[]? adjustmentRules, bool disableDaylightSavingTime)
	{
		if (!disableDaylightSavingTime && adjustmentRules != null && adjustmentRules.Length != 0)
		{
			adjustmentRules = (AdjustmentRule[])adjustmentRules.Clone();
		}
		string windowsId;
		bool hasIanaId = TryConvertIanaIdToWindowsId(id, allocate: false, out windowsId);
		return new TimeZoneInfo(id, baseUtcOffset, displayName ?? string.Empty, standardDisplayName ?? string.Empty, daylightDisplayName ?? string.Empty, adjustmentRules, disableDaylightSavingTime, hasIanaId);
	}

	public static bool TryConvertIanaIdToWindowsId(string ianaId, [NotNullWhen(true)] out string? windowsId)
	{
		return TryConvertIanaIdToWindowsId(ianaId, allocate: true, out windowsId);
	}

	public static bool TryConvertWindowsIdToIanaId(string windowsId, [NotNullWhen(true)] out string? ianaId)
	{
		return TryConvertWindowsIdToIanaId(windowsId, null, allocate: true, out ianaId);
	}

	public static bool TryConvertWindowsIdToIanaId(string windowsId, string? region, [NotNullWhen(true)] out string? ianaId)
	{
		return TryConvertWindowsIdToIanaId(windowsId, region, allocate: true, out ianaId);
	}

	void IDeserializationCallback.OnDeserialization(object sender)
	{
		try
		{
			ValidateTimeZoneInfo(_id, _baseUtcOffset, _adjustmentRules, out var adjustmentRulesSupportDst);
			if (adjustmentRulesSupportDst != _supportsDaylightSavingTime)
			{
				throw new SerializationException(SR.Format("Serialization_CorruptField", "SupportsDaylightSavingTime"));
			}
		}
		catch (ArgumentException innerException)
		{
			throw new SerializationException("Serialization_InvalidData", innerException);
		}
		catch (InvalidTimeZoneException innerException2)
		{
			throw new SerializationException("Serialization_InvalidData", innerException2);
		}
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		ArgumentNullException.ThrowIfNull(info, "info");
		info.AddValue("Id", _id);
		info.AddValue("DisplayName", _displayName);
		info.AddValue("StandardName", _standardDisplayName);
		info.AddValue("DaylightName", _daylightDisplayName);
		info.AddValue("BaseUtcOffset", _baseUtcOffset);
		info.AddValue("AdjustmentRules", _adjustmentRules);
		info.AddValue("SupportsDaylightSavingTime", _supportsDaylightSavingTime);
	}

	private TimeZoneInfo(SerializationInfo info, StreamingContext context)
	{
		ArgumentNullException.ThrowIfNull(info, "info");
		_id = (string)info.GetValue("Id", typeof(string));
		_displayName = (string)info.GetValue("DisplayName", typeof(string));
		_standardDisplayName = (string)info.GetValue("StandardName", typeof(string));
		_daylightDisplayName = (string)info.GetValue("DaylightName", typeof(string));
		_baseUtcOffset = (TimeSpan)info.GetValue("BaseUtcOffset", typeof(TimeSpan));
		_adjustmentRules = (AdjustmentRule[])info.GetValue("AdjustmentRules", typeof(AdjustmentRule[]));
		_supportsDaylightSavingTime = (bool)info.GetValue("SupportsDaylightSavingTime", typeof(bool));
	}

	private AdjustmentRule GetAdjustmentRuleForTime(DateTime dateTime, out int? ruleIndex)
	{
		return GetAdjustmentRuleForTime(dateTime, dateTimeisUtc: false, out ruleIndex);
	}

	private AdjustmentRule GetAdjustmentRuleForTime(DateTime dateTime, bool dateTimeisUtc, out int? ruleIndex)
	{
		if (_adjustmentRules == null || _adjustmentRules.Length == 0)
		{
			ruleIndex = null;
			return null;
		}
		DateTime dateOnly = (dateTimeisUtc ? (dateTime + BaseUtcOffset).Date : dateTime.Date);
		int num = 0;
		int num2 = _adjustmentRules.Length - 1;
		while (num <= num2)
		{
			int num3 = num + (num2 - num >> 1);
			AdjustmentRule adjustmentRule = _adjustmentRules[num3];
			AdjustmentRule previousRule = ((num3 > 0) ? _adjustmentRules[num3 - 1] : adjustmentRule);
			int num4 = CompareAdjustmentRuleToDateTime(adjustmentRule, previousRule, dateTime, dateOnly, dateTimeisUtc);
			if (num4 == 0)
			{
				ruleIndex = num3;
				return adjustmentRule;
			}
			if (num4 < 0)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		ruleIndex = null;
		return null;
	}

	private int CompareAdjustmentRuleToDateTime(AdjustmentRule rule, AdjustmentRule previousRule, DateTime dateTime, DateTime dateOnly, bool dateTimeisUtc)
	{
		if (!((rule.DateStart.Kind != DateTimeKind.Utc) ? (dateOnly >= rule.DateStart) : ((dateTimeisUtc ? dateTime : ConvertToUtc(dateTime, previousRule.DaylightDelta, previousRule.BaseUtcOffsetDelta)) >= rule.DateStart)))
		{
			return 1;
		}
		if (!((rule.DateEnd.Kind != DateTimeKind.Utc) ? (dateOnly <= rule.DateEnd) : ((dateTimeisUtc ? dateTime : ConvertToUtc(dateTime, rule.DaylightDelta, rule.BaseUtcOffsetDelta)) <= rule.DateEnd)))
		{
			return -1;
		}
		return 0;
	}

	private DateTime ConvertToUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta)
	{
		return ConvertToFromUtc(dateTime, daylightDelta, baseUtcOffsetDelta, convertToUtc: true);
	}

	private DateTime ConvertFromUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta)
	{
		return ConvertToFromUtc(dateTime, daylightDelta, baseUtcOffsetDelta, convertToUtc: false);
	}

	private DateTime ConvertToFromUtc(DateTime dateTime, TimeSpan daylightDelta, TimeSpan baseUtcOffsetDelta, bool convertToUtc)
	{
		TimeSpan timeSpan = BaseUtcOffset + daylightDelta + baseUtcOffsetDelta;
		if (convertToUtc)
		{
			timeSpan = timeSpan.Negate();
		}
		long num = dateTime.Ticks + timeSpan.Ticks;
		if (num <= 3155378975999999999L)
		{
			if (num >= 0)
			{
				return new DateTime(num);
			}
			return DateTime.MinValue;
		}
		return DateTime.MaxValue;
	}

	private static DateTime ConvertUtcToTimeZone(long ticks, TimeZoneInfo destinationTimeZone, out bool isAmbiguousLocalDst)
	{
		ticks += GetUtcOffsetFromUtc((ticks > 3155378975999999999L) ? DateTime.MaxValue : ((ticks < 0) ? DateTime.MinValue : new DateTime(ticks)), destinationTimeZone, out isAmbiguousLocalDst).Ticks;
		if (ticks <= 3155378975999999999L)
		{
			if (ticks >= 0)
			{
				return new DateTime(ticks);
			}
			return DateTime.MinValue;
		}
		return DateTime.MaxValue;
	}

	private DaylightTimeStruct GetDaylightTime(int year, AdjustmentRule rule, int? ruleIndex)
	{
		TimeSpan daylightDelta = rule.DaylightDelta;
		DateTime start;
		DateTime end;
		if (rule.NoDaylightTransitions)
		{
			AdjustmentRule previousAdjustmentRule = GetPreviousAdjustmentRule(rule, ruleIndex);
			start = ConvertFromUtc(rule.DateStart, previousAdjustmentRule.DaylightDelta, previousAdjustmentRule.BaseUtcOffsetDelta);
			end = ConvertFromUtc(rule.DateEnd, rule.DaylightDelta, rule.BaseUtcOffsetDelta);
		}
		else
		{
			start = TransitionTimeToDateTime(year, rule.DaylightTransitionStart);
			end = TransitionTimeToDateTime(year, rule.DaylightTransitionEnd);
		}
		return new DaylightTimeStruct(start, end, daylightDelta);
	}

	private static bool GetIsDaylightSavings(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime)
	{
		if (rule == null)
		{
			return false;
		}
		DateTime startTime;
		DateTime endTime;
		if (time.Kind == DateTimeKind.Local)
		{
			startTime = (rule.IsStartDateMarkerForBeginningOfYear() ? new DateTime(daylightTime.Start.Year, 1, 1) : (daylightTime.Start + daylightTime.Delta));
			endTime = (rule.IsEndDateMarkerForEndOfYear() ? new DateTime(daylightTime.End.Year + 1, 1, 1).AddTicks(-1L) : daylightTime.End);
		}
		else
		{
			bool flag = rule.DaylightDelta > TimeSpan.Zero;
			startTime = (rule.IsStartDateMarkerForBeginningOfYear() ? new DateTime(daylightTime.Start.Year, 1, 1) : (daylightTime.Start + (flag ? rule.DaylightDelta : TimeSpan.Zero)));
			endTime = (rule.IsEndDateMarkerForEndOfYear() ? new DateTime(daylightTime.End.Year + 1, 1, 1).AddTicks(-1L) : (daylightTime.End + (flag ? (-rule.DaylightDelta) : TimeSpan.Zero)));
		}
		bool flag2 = CheckIsDst(startTime, time, endTime, ignoreYearAdjustment: false, rule);
		if (flag2 && time.Kind == DateTimeKind.Local && GetIsAmbiguousTime(time, rule, daylightTime))
		{
			flag2 = time.IsAmbiguousDaylightSavingTime();
		}
		return flag2;
	}

	private TimeSpan GetDaylightSavingsStartOffsetFromUtc(TimeSpan baseUtcOffset, AdjustmentRule rule, int? ruleIndex)
	{
		if (rule.NoDaylightTransitions)
		{
			AdjustmentRule previousAdjustmentRule = GetPreviousAdjustmentRule(rule, ruleIndex);
			return baseUtcOffset + previousAdjustmentRule.BaseUtcOffsetDelta + previousAdjustmentRule.DaylightDelta;
		}
		return baseUtcOffset + rule.BaseUtcOffsetDelta;
	}

	private static TimeSpan GetDaylightSavingsEndOffsetFromUtc(TimeSpan baseUtcOffset, AdjustmentRule rule)
	{
		return baseUtcOffset + rule.BaseUtcOffsetDelta + rule.DaylightDelta;
	}

	private static bool GetIsDaylightSavingsFromUtc(DateTime time, int year, TimeSpan utc, AdjustmentRule rule, int? ruleIndex, out bool isAmbiguousLocalDst, TimeZoneInfo zone)
	{
		isAmbiguousLocalDst = false;
		if (rule == null)
		{
			return false;
		}
		DaylightTimeStruct daylightTime = zone.GetDaylightTime(year, rule, ruleIndex);
		bool ignoreYearAdjustment = false;
		TimeSpan daylightSavingsStartOffsetFromUtc = zone.GetDaylightSavingsStartOffsetFromUtc(utc, rule, ruleIndex);
		DateTime dstStart;
		if (rule.IsStartDateMarkerForBeginningOfYear())
		{
			int year2 = daylightTime.Start.Year;
			if (year2 > 1)
			{
				if (TryGetStartOfDstIfYearEndWithDst(year2 - 1, utc, zone, out dstStart))
				{
					ignoreYearAdjustment = true;
				}
				else
				{
					dstStart = new DateTime(year2, 1, 1) - daylightSavingsStartOffsetFromUtc;
				}
				goto IL_0071;
			}
		}
		dstStart = daylightTime.Start - daylightSavingsStartOffsetFromUtc;
		goto IL_0071;
		IL_0071:
		TimeSpan daylightSavingsEndOffsetFromUtc = GetDaylightSavingsEndOffsetFromUtc(utc, rule);
		DateTime dstEnd;
		if (rule.IsEndDateMarkerForEndOfYear())
		{
			int year3 = daylightTime.End.Year;
			if (year3 < 9999)
			{
				if (TryGetEndOfDstIfYearStartWithDst(year3 + 1, utc, zone, out dstEnd))
				{
					ignoreYearAdjustment = true;
				}
				else
				{
					dstEnd = new DateTime(year3 + 1, 1, 1).AddTicks(-1L) - daylightSavingsEndOffsetFromUtc;
				}
				goto IL_00dd;
			}
		}
		dstEnd = daylightTime.End - daylightSavingsEndOffsetFromUtc;
		goto IL_00dd;
		IL_00dd:
		DateTime dateTime;
		DateTime dateTime2;
		if (daylightTime.Delta.Ticks > 0)
		{
			dateTime = dstEnd - daylightTime.Delta;
			dateTime2 = dstEnd;
		}
		else
		{
			dateTime = dstStart;
			dateTime2 = dstStart - daylightTime.Delta;
		}
		bool flag = CheckIsDst(dstStart, time, dstEnd, ignoreYearAdjustment, rule);
		if (flag)
		{
			isAmbiguousLocalDst = time >= dateTime && time < dateTime2;
			if (!isAmbiguousLocalDst && dateTime.Year != dateTime2.Year)
			{
				try
				{
					DateTime dateTime3 = dateTime.AddYears(1);
					DateTime dateTime4 = dateTime2.AddYears(1);
					isAmbiguousLocalDst = time >= dateTime3 && time < dateTime4;
				}
				catch (ArgumentOutOfRangeException)
				{
				}
				if (!isAmbiguousLocalDst)
				{
					try
					{
						DateTime dateTime3 = dateTime.AddYears(-1);
						DateTime dateTime4 = dateTime2.AddYears(-1);
						isAmbiguousLocalDst = time >= dateTime3 && time < dateTime4;
					}
					catch (ArgumentOutOfRangeException)
					{
					}
				}
			}
		}
		return flag;
	}

	private static bool TryGetEndOfDstIfYearStartWithDst(int nextYear, TimeSpan utc, TimeZoneInfo zone, out DateTime dstEnd)
	{
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForTime = zone.GetAdjustmentRuleForTime(new DateTime(nextYear, 1, 1), out ruleIndex);
		if (adjustmentRuleForTime == null)
		{
			dstEnd = default(DateTime);
			return false;
		}
		if (adjustmentRuleForTime.IsStartDateMarkerForBeginningOfYear())
		{
			if (adjustmentRuleForTime.IsEndDateMarkerForEndOfYear())
			{
				dstEnd = new DateTime(nextYear, 12, 31) - utc - adjustmentRuleForTime.BaseUtcOffsetDelta - adjustmentRuleForTime.DaylightDelta;
			}
			else
			{
				dstEnd = zone.GetDaylightTime(nextYear, adjustmentRuleForTime, ruleIndex).End - utc - adjustmentRuleForTime.BaseUtcOffsetDelta - adjustmentRuleForTime.DaylightDelta;
			}
			return true;
		}
		DaylightTimeStruct daylightTime = zone.GetDaylightTime(nextYear, adjustmentRuleForTime, ruleIndex);
		if (daylightTime.End < daylightTime.Start && !adjustmentRuleForTime.IsEndDateMarkerForEndOfYear())
		{
			dstEnd = daylightTime.End - utc - adjustmentRuleForTime.BaseUtcOffsetDelta - adjustmentRuleForTime.DaylightDelta;
			return true;
		}
		dstEnd = default(DateTime);
		return false;
	}

	private static bool TryGetStartOfDstIfYearEndWithDst(int previousYear, TimeSpan utc, TimeZoneInfo zone, out DateTime dstStart)
	{
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForTime = zone.GetAdjustmentRuleForTime(new DateTime(previousYear, 12, 31), out ruleIndex);
		if (adjustmentRuleForTime == null)
		{
			dstStart = default(DateTime);
			return false;
		}
		DaylightTimeStruct daylightTime = zone.GetDaylightTime(previousYear, adjustmentRuleForTime, ruleIndex);
		if (adjustmentRuleForTime.IsEndDateMarkerForEndOfYear() || daylightTime.Start > daylightTime.End)
		{
			dstStart = daylightTime.Start - utc - adjustmentRuleForTime.BaseUtcOffsetDelta;
			return true;
		}
		dstStart = default(DateTime);
		return false;
	}

	private static bool CheckIsDst(DateTime startTime, DateTime time, DateTime endTime, bool ignoreYearAdjustment, AdjustmentRule rule)
	{
		if (!ignoreYearAdjustment && !rule.NoDaylightTransitions)
		{
			int year = startTime.Year;
			int year2 = endTime.Year;
			if (year != year2)
			{
				endTime = endTime.AddYears(year - year2);
			}
			int year3 = time.Year;
			if (year != year3)
			{
				time = time.AddYears(year - year3);
			}
		}
		if (startTime > endTime)
		{
			if (!(time < endTime))
			{
				return time >= startTime;
			}
			return true;
		}
		if (rule.NoDaylightTransitions)
		{
			if (time >= startTime)
			{
				return time <= endTime;
			}
			return false;
		}
		if (time >= startTime)
		{
			return time < endTime;
		}
		return false;
	}

	private static bool GetIsAmbiguousTime(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime)
	{
		bool result = false;
		if (rule == null || rule.DaylightDelta == TimeSpan.Zero)
		{
			return result;
		}
		DateTime dateTime;
		DateTime dateTime2;
		if (rule.DaylightDelta > TimeSpan.Zero)
		{
			if (rule.IsEndDateMarkerForEndOfYear())
			{
				return false;
			}
			dateTime = daylightTime.End;
			dateTime2 = daylightTime.End - rule.DaylightDelta;
		}
		else
		{
			if (rule.IsStartDateMarkerForBeginningOfYear())
			{
				return false;
			}
			dateTime = daylightTime.Start;
			dateTime2 = daylightTime.Start + rule.DaylightDelta;
		}
		result = time >= dateTime2 && time < dateTime;
		if (!result && dateTime.Year != dateTime2.Year)
		{
			try
			{
				DateTime dateTime3 = dateTime.AddYears(1);
				DateTime dateTime4 = dateTime2.AddYears(1);
				result = time >= dateTime4 && time < dateTime3;
			}
			catch (ArgumentOutOfRangeException)
			{
			}
			if (!result)
			{
				try
				{
					DateTime dateTime3 = dateTime.AddYears(-1);
					DateTime dateTime4 = dateTime2.AddYears(-1);
					result = time >= dateTime4 && time < dateTime3;
				}
				catch (ArgumentOutOfRangeException)
				{
				}
			}
		}
		return result;
	}

	private static bool GetIsInvalidTime(DateTime time, AdjustmentRule rule, DaylightTimeStruct daylightTime)
	{
		bool result = false;
		if (rule == null || rule.DaylightDelta == TimeSpan.Zero)
		{
			return result;
		}
		DateTime dateTime;
		DateTime dateTime2;
		if (rule.DaylightDelta < TimeSpan.Zero)
		{
			if (rule.IsEndDateMarkerForEndOfYear())
			{
				return false;
			}
			dateTime = daylightTime.End;
			dateTime2 = daylightTime.End - rule.DaylightDelta;
		}
		else
		{
			if (rule.IsStartDateMarkerForBeginningOfYear())
			{
				return false;
			}
			dateTime = daylightTime.Start;
			dateTime2 = daylightTime.Start + rule.DaylightDelta;
		}
		result = time >= dateTime && time < dateTime2;
		if (!result && dateTime.Year != dateTime2.Year)
		{
			try
			{
				DateTime dateTime3 = dateTime.AddYears(1);
				DateTime dateTime4 = dateTime2.AddYears(1);
				result = time >= dateTime3 && time < dateTime4;
			}
			catch (ArgumentOutOfRangeException)
			{
			}
			if (!result)
			{
				try
				{
					DateTime dateTime3 = dateTime.AddYears(-1);
					DateTime dateTime4 = dateTime2.AddYears(-1);
					result = time >= dateTime3 && time < dateTime4;
				}
				catch (ArgumentOutOfRangeException)
				{
				}
			}
		}
		return result;
	}

	private static TimeSpan GetUtcOffset(DateTime time, TimeZoneInfo zone)
	{
		TimeSpan baseUtcOffset = zone.BaseUtcOffset;
		int? ruleIndex;
		AdjustmentRule adjustmentRuleForTime = zone.GetAdjustmentRuleForTime(time, out ruleIndex);
		if (adjustmentRuleForTime != null)
		{
			baseUtcOffset += adjustmentRuleForTime.BaseUtcOffsetDelta;
			if (adjustmentRuleForTime.HasDaylightSaving)
			{
				DaylightTimeStruct daylightTime = zone.GetDaylightTime(time.Year, adjustmentRuleForTime, ruleIndex);
				bool isDaylightSavings = GetIsDaylightSavings(time, adjustmentRuleForTime, daylightTime);
				baseUtcOffset += (isDaylightSavings ? adjustmentRuleForTime.DaylightDelta : TimeSpan.Zero);
			}
		}
		return baseUtcOffset;
	}

	private static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone)
	{
		bool isDaylightSavings;
		return GetUtcOffsetFromUtc(time, zone, out isDaylightSavings);
	}

	private static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone, out bool isDaylightSavings)
	{
		bool isAmbiguousLocalDst;
		return GetUtcOffsetFromUtc(time, zone, out isDaylightSavings, out isAmbiguousLocalDst);
	}

	internal static TimeSpan GetUtcOffsetFromUtc(DateTime time, TimeZoneInfo zone, out bool isDaylightSavings, out bool isAmbiguousLocalDst)
	{
		isDaylightSavings = false;
		isAmbiguousLocalDst = false;
		TimeSpan baseUtcOffset = zone.BaseUtcOffset;
		AdjustmentRule adjustmentRuleForTime;
		int? ruleIndex;
		int year;
		if (time > s_maxDateOnly)
		{
			adjustmentRuleForTime = zone.GetAdjustmentRuleForTime(DateTime.MaxValue, out ruleIndex);
			year = 9999;
		}
		else if (time < s_minDateOnly)
		{
			adjustmentRuleForTime = zone.GetAdjustmentRuleForTime(DateTime.MinValue, out ruleIndex);
			year = 1;
		}
		else
		{
			adjustmentRuleForTime = zone.GetAdjustmentRuleForTime(time, dateTimeisUtc: true, out ruleIndex);
			year = (time + baseUtcOffset).Year;
		}
		if (adjustmentRuleForTime != null)
		{
			baseUtcOffset += adjustmentRuleForTime.BaseUtcOffsetDelta;
			if (adjustmentRuleForTime.HasDaylightSaving)
			{
				isDaylightSavings = GetIsDaylightSavingsFromUtc(time, year, zone._baseUtcOffset, adjustmentRuleForTime, ruleIndex, out isAmbiguousLocalDst, zone);
				baseUtcOffset += (isDaylightSavings ? adjustmentRuleForTime.DaylightDelta : TimeSpan.Zero);
			}
		}
		return baseUtcOffset;
	}

	internal static DateTime TransitionTimeToDateTime(int year, TransitionTime transitionTime)
	{
		TimeSpan timeOfDay = transitionTime.TimeOfDay.TimeOfDay;
		DateTime result;
		if (transitionTime.IsFixedDateRule)
		{
			int num = transitionTime.Day;
			if (num > 28)
			{
				int num2 = DateTime.DaysInMonth(year, transitionTime.Month);
				if (num > num2)
				{
					num = num2;
				}
			}
			result = new DateTime(year, transitionTime.Month, num) + timeOfDay;
		}
		else if (transitionTime.Week <= 4)
		{
			result = new DateTime(year, transitionTime.Month, 1) + timeOfDay;
			int dayOfWeek = (int)result.DayOfWeek;
			int num3 = (int)(transitionTime.DayOfWeek - dayOfWeek);
			if (num3 < 0)
			{
				num3 += 7;
			}
			num3 += 7 * (transitionTime.Week - 1);
			if (num3 > 0)
			{
				result = result.AddDays(num3);
			}
		}
		else
		{
			int day = DateTime.DaysInMonth(year, transitionTime.Month);
			result = new DateTime(year, transitionTime.Month, day) + timeOfDay;
			int num4 = result.DayOfWeek - transitionTime.DayOfWeek;
			if (num4 < 0)
			{
				num4 += 7;
			}
			if (num4 > 0)
			{
				result = result.AddDays(-num4);
			}
		}
		return result;
	}

	private static TimeZoneInfoResult TryGetTimeZone(string id, bool dstDisabled, out TimeZoneInfo value, out Exception e, CachedData cachedData, bool alwaysFallbackToLocalMachine = false)
	{
		TimeZoneInfoResult timeZoneInfoResult = TryGetTimeZoneUsingId(id, dstDisabled, out value, out e, cachedData, alwaysFallbackToLocalMachine);
		if (timeZoneInfoResult != TimeZoneInfoResult.Success)
		{
			bool idIsIana;
			string alternativeId = GetAlternativeId(id, out idIsIana);
			if (alternativeId != null)
			{
				timeZoneInfoResult = TryGetTimeZoneUsingId(alternativeId, dstDisabled, out value, out e, cachedData, alwaysFallbackToLocalMachine);
				if (timeZoneInfoResult == TimeZoneInfoResult.Success)
				{
					TimeZoneInfo timeZoneInfo = null;
					if (value._equivalentZones == null)
					{
						timeZoneInfo = new TimeZoneInfo(id, value._baseUtcOffset, value._displayName, value._standardDisplayName, value._daylightDisplayName, value._adjustmentRules, dstDisabled && value._supportsDaylightSavingTime, idIsIana);
						value._equivalentZones = new List<TimeZoneInfo>();
						lock (value._equivalentZones)
						{
							value._equivalentZones.Add(timeZoneInfo);
						}
					}
					else
					{
						foreach (TimeZoneInfo equivalentZone in value._equivalentZones)
						{
							if (equivalentZone.Id == id)
							{
								timeZoneInfo = equivalentZone;
								break;
							}
						}
						if (timeZoneInfo == null)
						{
							timeZoneInfo = new TimeZoneInfo(id, value._baseUtcOffset, value._displayName, value._standardDisplayName, value._daylightDisplayName, value._adjustmentRules, dstDisabled && value._supportsDaylightSavingTime, idIsIana);
							lock (value._equivalentZones)
							{
								value._equivalentZones.Add(timeZoneInfo);
							}
						}
					}
					if (cachedData._timeZonesUsingAlternativeIds == null)
					{
						cachedData._timeZonesUsingAlternativeIds = new Dictionary<string, TimeZoneInfo>(StringComparer.OrdinalIgnoreCase);
					}
					cachedData._timeZonesUsingAlternativeIds[id] = timeZoneInfo;
					value = timeZoneInfo;
				}
			}
		}
		return timeZoneInfoResult;
	}

	private static TimeZoneInfoResult TryGetTimeZoneUsingId(string id, bool dstDisabled, out TimeZoneInfo value, out Exception e, CachedData cachedData, bool alwaysFallbackToLocalMachine)
	{
		TimeZoneInfoResult result = TimeZoneInfoResult.Success;
		e = null;
		if (Invariant && !cachedData._allSystemTimeZonesRead)
		{
			PopulateAllSystemTimeZones(cachedData);
			cachedData._allSystemTimeZonesRead = true;
		}
		if (cachedData._systemTimeZones != null && cachedData._systemTimeZones.TryGetValue(id, out value))
		{
			if (dstDisabled && value._supportsDaylightSavingTime)
			{
				value = CreateCustomTimeZone(value._id, value._baseUtcOffset, value._displayName, value._standardDisplayName);
			}
			return result;
		}
		if (Invariant)
		{
			value = null;
			return TimeZoneInfoResult.TimeZoneNotFoundException;
		}
		if (cachedData._timeZonesUsingAlternativeIds != null && cachedData._timeZonesUsingAlternativeIds.TryGetValue(id, out value))
		{
			if (dstDisabled && value._supportsDaylightSavingTime)
			{
				value = CreateCustomTimeZone(value._id, value._baseUtcOffset, value._displayName, value._standardDisplayName);
			}
			return result;
		}
		if (!cachedData._allSystemTimeZonesRead || alwaysFallbackToLocalMachine)
		{
			result = TryGetTimeZoneFromLocalMachine(id, dstDisabled, out value, out e, cachedData);
		}
		else
		{
			result = TimeZoneInfoResult.TimeZoneNotFoundException;
			value = null;
		}
		return result;
	}

	private static TimeZoneInfoResult TryGetTimeZoneFromLocalMachine(string id, bool dstDisabled, out TimeZoneInfo value, out Exception e, CachedData cachedData)
	{
		TimeZoneInfoResult num = TryGetTimeZoneFromLocalMachine(id, out value, out e);
		if (num == TimeZoneInfoResult.Success)
		{
			if (cachedData._systemTimeZones == null)
			{
				cachedData._systemTimeZones = new Dictionary<string, TimeZoneInfo>(StringComparer.OrdinalIgnoreCase) { { "UTC", s_utcTimeZone } };
			}
			if (!id.Equals("UTC", StringComparison.OrdinalIgnoreCase))
			{
				cachedData._systemTimeZones.Add(id, value);
			}
			if (dstDisabled && value._supportsDaylightSavingTime)
			{
				value = CreateCustomTimeZone(value._id, value._baseUtcOffset, value._displayName, value._standardDisplayName);
			}
		}
		return num;
	}

	private static void ValidateTimeZoneInfo(string id, TimeSpan baseUtcOffset, AdjustmentRule[] adjustmentRules, out bool adjustmentRulesSupportDst)
	{
		ArgumentException.ThrowIfNullOrEmpty(id, "id");
		if (UtcOffsetOutOfRange(baseUtcOffset))
		{
			throw new ArgumentOutOfRangeException("baseUtcOffset", "ArgumentOutOfRange_UtcOffset");
		}
		if (baseUtcOffset.Ticks % 600000000 != 0L)
		{
			throw new ArgumentException("Argument_TimeSpanHasSeconds", "baseUtcOffset");
		}
		adjustmentRulesSupportDst = false;
		if (adjustmentRules == null || adjustmentRules.Length == 0)
		{
			return;
		}
		adjustmentRulesSupportDst = true;
		AdjustmentRule adjustmentRule = null;
		for (int i = 0; i < adjustmentRules.Length; i++)
		{
			AdjustmentRule adjustmentRule2 = adjustmentRule;
			adjustmentRule = adjustmentRules[i];
			if (adjustmentRule == null)
			{
				throw new InvalidTimeZoneException("Argument_AdjustmentRulesNoNulls");
			}
			if (!IsValidAdjustmentRuleOffset(baseUtcOffset, adjustmentRule))
			{
				throw new InvalidTimeZoneException("ArgumentOutOfRange_UtcOffsetAndDaylightDelta");
			}
			if (adjustmentRule2 != null && adjustmentRule.DateStart <= adjustmentRule2.DateEnd)
			{
				throw new InvalidTimeZoneException("Argument_AdjustmentRulesOutOfOrder");
			}
		}
	}

	internal static bool UtcOffsetOutOfRange(TimeSpan offset)
	{
		if (!(offset < MinOffset))
		{
			return offset > MaxOffset;
		}
		return true;
	}

	private static TimeSpan GetUtcOffset(TimeSpan baseUtcOffset, AdjustmentRule adjustmentRule)
	{
		return baseUtcOffset + adjustmentRule.BaseUtcOffsetDelta + (adjustmentRule.HasDaylightSaving ? adjustmentRule.DaylightDelta : TimeSpan.Zero);
	}

	private static bool IsValidAdjustmentRuleOffset(TimeSpan baseUtcOffset, AdjustmentRule adjustmentRule)
	{
		return !UtcOffsetOutOfRange(GetUtcOffset(baseUtcOffset, adjustmentRule));
	}

	private static TimeZoneInfo CreateUtcTimeZone()
	{
		string utcStandardDisplayName = GetUtcStandardDisplayName();
		string utcFullDisplayName = GetUtcFullDisplayName("UTC", utcStandardDisplayName);
		return CreateCustomTimeZone("UTC", TimeSpan.Zero, utcFullDisplayName, utcStandardDisplayName);
	}

	private unsafe static bool TryConvertIanaIdToWindowsId(string ianaId, bool allocate, out string windowsId)
	{
		if (!Invariant)
		{
			_ = GlobalizationMode.Invariant;
			_ = 0;
			if (ianaId != null && !ianaId.AsSpan().ContainsAny('\\', '\n', '\r'))
			{
				char* ptr = stackalloc char[100];
				int num = Interop.Globalization.IanaIdToWindowsId(ianaId, ptr, 100);
				if (num > 0)
				{
					windowsId = (allocate ? new string(ptr, 0, num) : null);
					return true;
				}
				windowsId = null;
				return false;
			}
		}
		windowsId = null;
		return false;
	}

	private unsafe static bool TryConvertWindowsIdToIanaId(string windowsId, string region, bool allocate, out string ianaId)
	{
		_ = GlobalizationMode.Invariant;
		_ = 0;
		if (windowsId == null)
		{
			ianaId = null;
			return false;
		}
		if (windowsId.Equals("utc", StringComparison.OrdinalIgnoreCase))
		{
			ianaId = "Etc/UTC";
			return true;
		}
		if (windowsId.AsSpan().ContainsAny('\\', '\n', '\r'))
		{
			ianaId = null;
			return false;
		}
		nint region2 = IntPtr.Zero;
		if (region != null && region.Length < 11)
		{
			byte* ptr = stackalloc byte[(int)(uint)(region.Length + 1)];
			int i;
			for (i = 0; i < region.Length && region[i] <= '\u007f'; i++)
			{
				ptr[i] = (char.IsAsciiLetterLower(region[i]) ? ((byte)(region[i] - 97 + 65)) : ((byte)region[i]));
			}
			if (i >= region.Length)
			{
				ptr[region.Length] = 0;
				region2 = new IntPtr(ptr);
			}
		}
		char* ptr2 = stackalloc char[100];
		int num = Interop.Globalization.WindowsIdToIanaId(windowsId, region2, ptr2, 100);
		if (num > 0)
		{
			ianaId = (allocate ? new string(ptr2, 0, num) : null);
			return true;
		}
		ianaId = null;
		return false;
	}

	private static bool IsUtcAlias(string id)
	{
		switch (id[0])
		{
		case 69:
		case 101:
			if (!string.Equals(id, "Etc/UTC", StringComparison.OrdinalIgnoreCase) && !string.Equals(id, "Etc/UCT", StringComparison.OrdinalIgnoreCase) && !string.Equals(id, "Etc/Universal", StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(id, "Etc/Zulu", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		case 85:
		case 117:
			if (!string.Equals(id, "UCT", StringComparison.OrdinalIgnoreCase) && !string.Equals(id, "UTC", StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(id, "Universal", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		case 90:
		case 122:
			return string.Equals(id, "Zulu", StringComparison.OrdinalIgnoreCase);
		default:
			return false;
		}
	}

	private TimeZoneInfo(byte[] data, string id, bool dstDisabled)
	{
		_id = id;
		HasIanaId = true;
		if (IsUtcAlias(id))
		{
			_baseUtcOffset = TimeSpan.Zero;
			_adjustmentRules = Array.Empty<AdjustmentRule>();
			return;
		}
		TZif_ParseRaw(data, out var dts, out var typeOfLocalTime, out var transitionType, out var zoneAbbreviations, out var futureTransitionsPosixFormat);
		DateTime utcNow = DateTime.UtcNow;
		for (int i = 0; i < dts.Length && dts[i] <= utcNow; i++)
		{
			int num = typeOfLocalTime[i];
			if (!transitionType[num].IsDst)
			{
				_baseUtcOffset = transitionType[num].UtcOffset;
				_standardAbbrevName = TZif_GetZoneAbbreviation(zoneAbbreviations, transitionType[num].AbbreviationIndex);
			}
			else
			{
				_daylightAbbrevName = TZif_GetZoneAbbreviation(zoneAbbreviations, transitionType[num].AbbreviationIndex);
			}
		}
		if (dts.Length == 0)
		{
			for (int j = 0; j < transitionType.Length; j++)
			{
				if (!transitionType[j].IsDst)
				{
					_baseUtcOffset = transitionType[j].UtcOffset;
					_standardAbbrevName = TZif_GetZoneAbbreviation(zoneAbbreviations, transitionType[j].AbbreviationIndex);
				}
				else
				{
					_daylightAbbrevName = TZif_GetZoneAbbreviation(zoneAbbreviations, transitionType[j].AbbreviationIndex);
				}
			}
		}
		if (_baseUtcOffset.Ticks % 600000000 != 0L)
		{
			_baseUtcOffset = new TimeSpan(_baseUtcOffset.Hours, _baseUtcOffset.Minutes, 0);
		}
		if (!dstDisabled)
		{
			TZif_GenerateAdjustmentRules(out _adjustmentRules, _baseUtcOffset, dts, typeOfLocalTime, transitionType, futureTransitionsPosixFormat);
		}
		ValidateTimeZoneInfo(_id, _baseUtcOffset, _adjustmentRules, out _supportsDaylightSavingTime);
	}

	private static DateTime GetTimeOnlyInMillisecondsPrecision(DateTime input)
	{
		return new DateTime(input.TimeOfDay.Ticks / 10000 * 10000);
	}

	public AdjustmentRule[] GetAdjustmentRules()
	{
		if (_adjustmentRules == null)
		{
			return Array.Empty<AdjustmentRule>();
		}
		List<AdjustmentRule> list = new List<AdjustmentRule>(_adjustmentRules.Length);
		for (int i = 0; i < _adjustmentRules.Length; i++)
		{
			AdjustmentRule adjustmentRule = _adjustmentRules[i];
			if (adjustmentRule.NoDaylightTransitions && adjustmentRule.DaylightTransitionStart != s_daylightRuleMarker && adjustmentRule.DaylightDelta == TimeSpan.Zero && adjustmentRule.BaseUtcOffsetDelta == TimeSpan.Zero)
			{
				continue;
			}
			DateTime input = ((adjustmentRule.DateStart.Kind == DateTimeKind.Utc) ? new DateTime(adjustmentRule.DateStart.Ticks + _baseUtcOffset.Ticks, DateTimeKind.Unspecified) : adjustmentRule.DateStart);
			DateTime input2 = ((adjustmentRule.DateEnd.Kind == DateTimeKind.Utc) ? new DateTime(adjustmentRule.DateEnd.Ticks + _baseUtcOffset.Ticks + adjustmentRule.DaylightDelta.Ticks, DateTimeKind.Unspecified) : adjustmentRule.DateEnd);
			if (input.Year == input2.Year || !adjustmentRule.NoDaylightTransitions)
			{
				TransitionTime daylightTransitionStart = (adjustmentRule.NoDaylightTransitions ? TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input), input.Month, input.Day) : adjustmentRule.DaylightTransitionStart);
				TransitionTime daylightTransitionEnd = (adjustmentRule.NoDaylightTransitions ? TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input2), input2.Month, input2.Day) : adjustmentRule.DaylightTransitionEnd);
				list.Add(AdjustmentRule.CreateAdjustmentRule(input.Date, input2.Date, adjustmentRule.DaylightDelta, daylightTransitionStart, daylightTransitionEnd, adjustmentRule.BaseUtcOffsetDelta));
				continue;
			}
			DateTime input3 = new DateTime(input.Year + 1, 1, 1).AddMilliseconds(-1.0);
			TransitionTime daylightTransitionStart2 = TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input), input.Month, input.Day);
			TransitionTime daylightTransitionEnd2 = TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input3), input3.Month, input3.Day);
			list.Add(AdjustmentRule.CreateAdjustmentRule(input.Date, input3.Date, adjustmentRule.DaylightDelta, daylightTransitionStart2, daylightTransitionEnd2, adjustmentRule.BaseUtcOffsetDelta));
			if (input2.Year - input.Year > 1)
			{
				DateTime input4 = new DateTime(input.Year + 1, 1, 1);
				DateTime input5 = new DateTime(input2.Year, 1, 1).AddMilliseconds(-1.0);
				daylightTransitionStart2 = TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input4), input4.Month, input4.Day);
				daylightTransitionEnd2 = TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input5), input5.Month, input5.Day);
				list.Add(AdjustmentRule.CreateAdjustmentRule(input4.Date, input5.Date, adjustmentRule.DaylightDelta, daylightTransitionStart2, daylightTransitionEnd2, adjustmentRule.BaseUtcOffsetDelta));
			}
			DateTime input6 = new DateTime(input2.Year, 1, 1);
			daylightTransitionStart2 = TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input6), input6.Month, input6.Day);
			daylightTransitionEnd2 = TransitionTime.CreateFixedDateRule(GetTimeOnlyInMillisecondsPrecision(input2), input2.Month, input2.Day);
			list.Add(AdjustmentRule.CreateAdjustmentRule(input6.Date, input2.Date, adjustmentRule.DaylightDelta, daylightTransitionStart2, daylightTransitionEnd2, adjustmentRule.BaseUtcOffsetDelta));
		}
		return list.ToArray();
	}

	private string PopulateDisplayName()
	{
		if (IsUtcAlias(Id))
		{
			return GetUtcFullDisplayName(Id, StandardName);
		}
		IFormatProvider formatProvider = null;
		IFormatProvider provider = formatProvider;
		Span<char> initialBuffer = stackalloc char[256];
		DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(6, 3, formatProvider, initialBuffer);
		handler.AppendLiteral("(UTC");
		handler.AppendFormatted((_baseUtcOffset >= TimeSpan.Zero) ? '+' : '-');
		handler.AppendFormatted(_baseUtcOffset, "hh\\:mm");
		handler.AppendLiteral(") ");
		handler.AppendFormatted(_id);
		string displayName = string.Create(provider, initialBuffer, ref handler);
		if (GlobalizationMode.Invariant)
		{
		}
		GetFullValueForDisplayNameField(NameLookupId, BaseUtcOffset, ref displayName);
		return displayName;
	}

	private string PopulateStandardDisplayName()
	{
		if (IsUtcAlias(Id))
		{
			return GetUtcStandardDisplayName();
		}
		string displayName = _standardAbbrevName;
		if (GlobalizationMode.Invariant)
		{
		}
		GetStandardDisplayName(NameLookupId, ref displayName);
		return displayName;
	}

	private string PopulateDaylightDisplayName()
	{
		if (IsUtcAlias(Id))
		{
			return StandardName;
		}
		string displayName = _daylightAbbrevName ?? _standardAbbrevName;
		if (GlobalizationMode.Invariant)
		{
		}
		GetDaylightDisplayName(NameLookupId, ref displayName);
		return displayName;
	}

	private static void PopulateAllSystemTimeZones(CachedData cachedData)
	{
		if (cachedData._systemTimeZones == null)
		{
			cachedData._systemTimeZones = new Dictionary<string, TimeZoneInfo>(StringComparer.OrdinalIgnoreCase) { { "UTC", s_utcTimeZone } };
		}
		if (!Invariant)
		{
			string[] timeZoneIds = GetTimeZoneIds();
			for (int i = 0; i < timeZoneIds.Length; i++)
			{
				TryGetTimeZone(timeZoneIds[i], dstDisabled: false, out var _, out var _, cachedData, alwaysFallbackToLocalMachine: true);
			}
		}
	}

	private static TimeZoneInfo GetLocalTimeZone(CachedData cachedData)
	{
		return GetLocalTimeZoneCore();
	}

	private static TimeZoneInfoResult TryGetTimeZoneFromLocalMachine(string id, out TimeZoneInfo value, out Exception e)
	{
		return TryGetTimeZoneFromLocalMachineCore(id, out value, out e);
	}

	private static TimeZoneInfo GetTimeZoneFromTzData(byte[] rawData, string id)
	{
		if (rawData != null)
		{
			try
			{
				return new TimeZoneInfo(rawData, id, dstDisabled: false);
			}
			catch (ArgumentException)
			{
			}
			catch (InvalidTimeZoneException)
			{
			}
			try
			{
				return new TimeZoneInfo(rawData, id, dstDisabled: true);
			}
			catch (ArgumentException)
			{
			}
			catch (InvalidTimeZoneException)
			{
			}
		}
		return null;
	}

	private static TimeZoneInfoResult TryGetTimeZone(string id, out TimeZoneInfo timeZone, out Exception e, CachedData cachedData)
	{
		return TryGetTimeZone(id, dstDisabled: false, out timeZone, out e, cachedData, alwaysFallbackToLocalMachine: true);
	}

	internal static TimeSpan GetDateTimeNowUtcOffsetFromUtc(DateTime time, out bool isAmbiguousLocalDst)
	{
		bool isDaylightSavings;
		return GetUtcOffsetFromUtc(time, Local, out isDaylightSavings, out isAmbiguousLocalDst);
	}

	private static void TZif_GenerateAdjustmentRules(out AdjustmentRule[] rules, TimeSpan baseUtcOffset, DateTime[] dts, byte[] typeOfLocalTime, TZifType[] transitionType, string futureTransitionsPosixFormat)
	{
		rules = null;
		if (dts.Length != 0)
		{
			int index = 0;
			List<AdjustmentRule> list = new List<AdjustmentRule>();
			while (index <= dts.Length)
			{
				TZif_GenerateAdjustmentRule(ref index, baseUtcOffset, list, dts, typeOfLocalTime, transitionType, futureTransitionsPosixFormat);
			}
			rules = list.ToArray();
			if (rules != null && rules.Length == 0)
			{
				rules = null;
			}
		}
	}

	private static void TZif_GenerateAdjustmentRule(ref int index, TimeSpan timeZoneBaseUtcOffset, List<AdjustmentRule> rulesList, DateTime[] dts, byte[] typeOfLocalTime, TZifType[] transitionTypes, string futureTransitionsPosixFormat)
	{
		while (index < dts.Length && dts[index] == DateTime.MinValue)
		{
			index++;
		}
		if (rulesList.Count == 0 && index < dts.Length)
		{
			TZifType tZifType = TZif_GetEarlyDateTransitionType(transitionTypes);
			DateTime dateTime = dts[index];
			TimeSpan timeSpan = TZif_CalculateTransitionOffsetFromBase(tZifType.UtcOffset, timeZoneBaseUtcOffset);
			TimeSpan daylightDelta = (tZifType.IsDst ? timeSpan : TimeSpan.Zero);
			TimeSpan baseUtcOffsetDelta = (tZifType.IsDst ? TimeSpan.Zero : timeSpan);
			AdjustmentRule adjustmentRule = AdjustmentRule.CreateAdjustmentRule(DateTime.MinValue, dateTime.AddTicks(-1L), daylightDelta, default(TransitionTime), default(TransitionTime), baseUtcOffsetDelta, noDaylightTransitions: true);
			if (!IsValidAdjustmentRuleOffset(timeZoneBaseUtcOffset, adjustmentRule))
			{
				NormalizeAdjustmentRuleOffset(timeZoneBaseUtcOffset, ref adjustmentRule);
			}
			rulesList.Add(adjustmentRule);
		}
		else if (index < dts.Length)
		{
			DateTime dateStart = dts[index - 1];
			TZifType tZifType2 = transitionTypes[typeOfLocalTime[index - 1]];
			DateTime dateTime2 = dts[index];
			TimeSpan timeSpan2 = TZif_CalculateTransitionOffsetFromBase(tZifType2.UtcOffset, timeZoneBaseUtcOffset);
			AdjustmentRule adjustmentRule2 = AdjustmentRule.CreateAdjustmentRule(daylightDelta: tZifType2.IsDst ? timeSpan2 : TimeSpan.Zero, baseUtcOffsetDelta: tZifType2.IsDst ? TimeSpan.Zero : timeSpan2, daylightTransitionStart: (!tZifType2.IsDst) ? default(TransitionTime) : s_daylightRuleMarker, dateStart: dateStart, dateEnd: dateTime2.AddTicks(-1L), daylightTransitionEnd: default(TransitionTime), noDaylightTransitions: true);
			if (!IsValidAdjustmentRuleOffset(timeZoneBaseUtcOffset, adjustmentRule2))
			{
				NormalizeAdjustmentRuleOffset(timeZoneBaseUtcOffset, ref adjustmentRule2);
			}
			rulesList.Add(adjustmentRule2);
		}
		else
		{
			DateTime dateTime3 = dts[index - 1];
			AdjustmentRule adjustmentRule3 = ((!string.IsNullOrEmpty(futureTransitionsPosixFormat)) ? TZif_CreateAdjustmentRuleForPosixFormat(futureTransitionsPosixFormat, dateTime3, timeZoneBaseUtcOffset) : null);
			if (adjustmentRule3 == null)
			{
				TZifType tZifType3 = transitionTypes[typeOfLocalTime[index - 1]];
				TimeSpan timeSpan3 = TZif_CalculateTransitionOffsetFromBase(tZifType3.UtcOffset, timeZoneBaseUtcOffset);
				TimeSpan daylightDelta2 = (tZifType3.IsDst ? timeSpan3 : TimeSpan.Zero);
				TimeSpan baseUtcOffsetDelta2 = (tZifType3.IsDst ? TimeSpan.Zero : timeSpan3);
				adjustmentRule3 = AdjustmentRule.CreateAdjustmentRule(dateTime3, DateTime.MaxValue, daylightDelta2, default(TransitionTime), default(TransitionTime), baseUtcOffsetDelta2, noDaylightTransitions: true);
			}
			if (!IsValidAdjustmentRuleOffset(timeZoneBaseUtcOffset, adjustmentRule3))
			{
				NormalizeAdjustmentRuleOffset(timeZoneBaseUtcOffset, ref adjustmentRule3);
			}
			rulesList.Add(adjustmentRule3);
		}
		index++;
	}

	private static TimeSpan TZif_CalculateTransitionOffsetFromBase(TimeSpan transitionOffset, TimeSpan timeZoneBaseUtcOffset)
	{
		TimeSpan result = transitionOffset - timeZoneBaseUtcOffset;
		if (result.Ticks % 600000000 != 0L)
		{
			result = new TimeSpan(result.Hours, result.Minutes, 0);
		}
		return result;
	}

	private static TZifType TZif_GetEarlyDateTransitionType(TZifType[] transitionTypes)
	{
		for (int i = 0; i < transitionTypes.Length; i++)
		{
			TZifType result = transitionTypes[i];
			if (!result.IsDst)
			{
				return result;
			}
		}
		if (transitionTypes.Length != 0)
		{
			return transitionTypes[0];
		}
		throw new InvalidTimeZoneException("InvalidTimeZone_NoTTInfoStructures");
	}

	private static AdjustmentRule TZif_CreateAdjustmentRuleForPosixFormat(string posixFormat, DateTime startTransitionDate, TimeSpan timeZoneBaseUtcOffset)
	{
		if (TZif_ParsePosixFormat(posixFormat.AsSpan(), out var _, out var standardOffset, out var daylightSavingsName, out var daylightSavingsOffset, out var start, out var startTime, out var end, out var endTime))
		{
			TimeSpan? timeSpan = TZif_ParseOffsetString(standardOffset);
			if (timeSpan.HasValue)
			{
				TimeSpan transitionOffset = timeSpan.GetValueOrDefault().Negate();
				transitionOffset = TZif_CalculateTransitionOffsetFromBase(transitionOffset, timeZoneBaseUtcOffset);
				if (!daylightSavingsName.IsEmpty)
				{
					TimeSpan? timeSpan2 = TZif_ParseOffsetString(daylightSavingsOffset);
					TimeSpan daylightDelta;
					if (!timeSpan2.HasValue)
					{
						daylightDelta = new TimeSpan(1, 0, 0);
					}
					else
					{
						daylightDelta = timeSpan2.GetValueOrDefault().Negate();
						daylightDelta = TZif_CalculateTransitionOffsetFromBase(daylightDelta, timeZoneBaseUtcOffset);
						daylightDelta = TZif_CalculateTransitionOffsetFromBase(daylightDelta, transitionOffset);
					}
					TransitionTime? transitionTime = TZif_CreateTransitionTimeFromPosixRule(start, startTime);
					TransitionTime? transitionTime2 = TZif_CreateTransitionTimeFromPosixRule(end, endTime);
					if (!transitionTime.HasValue || !transitionTime2.HasValue)
					{
						return null;
					}
					return AdjustmentRule.CreateAdjustmentRule(startTransitionDate, DateTime.MaxValue, daylightDelta, transitionTime.GetValueOrDefault(), transitionTime2.GetValueOrDefault(), transitionOffset, noDaylightTransitions: false);
				}
				return AdjustmentRule.CreateAdjustmentRule(startTransitionDate, DateTime.MaxValue, TimeSpan.Zero, default(TransitionTime), default(TransitionTime), transitionOffset, noDaylightTransitions: true);
			}
		}
		return null;
	}

	private static TimeSpan? TZif_ParseOffsetString(ReadOnlySpan<char> offset)
	{
		TimeSpan? result = null;
		if (offset.Length > 0)
		{
			bool flag = offset[0] == '-';
			if (flag || offset[0] == '+')
			{
				offset = offset.Slice(1);
			}
			TimeSpan result3;
			if (int.TryParse(offset, out var result2))
			{
				result = new TimeSpan(result2, 0, 0);
			}
			else if (TimeSpan.TryParseExact(offset, "g".AsSpan(), CultureInfo.InvariantCulture, out result3))
			{
				result = result3;
			}
			if (result.HasValue && flag)
			{
				result = result.GetValueOrDefault().Negate();
			}
		}
		return result;
	}

	private static DateTime ParseTimeOfDay(ReadOnlySpan<char> time)
	{
		TimeSpan? timeSpan = TZif_ParseOffsetString(time);
		if (timeSpan.HasValue)
		{
			timeSpan = new TimeSpan(timeSpan.GetValueOrDefault().Hours, timeSpan.GetValueOrDefault().Minutes, timeSpan.GetValueOrDefault().Seconds);
			DateTime dateTime = ((!(timeSpan.GetValueOrDefault() < TimeSpan.Zero)) ? new DateTime(1, 1, 1, 0, 0, 0) : new DateTime(1, 1, 2, 0, 0, 0));
			return dateTime + timeSpan.GetValueOrDefault();
		}
		return new DateTime(1, 1, 1, 2, 0, 0);
	}

	private static TransitionTime? TZif_CreateTransitionTimeFromPosixRule(ReadOnlySpan<char> date, ReadOnlySpan<char> time)
	{
		if (date.IsEmpty)
		{
			return null;
		}
		if (date[0] == 'M')
		{
			if (!TZif_ParseMDateRule(date, out var month, out var week, out var dayOfWeek))
			{
				throw new InvalidTimeZoneException(SR.Format("InvalidTimeZone_UnparsablePosixMDateString", date.ToString()));
			}
			return TransitionTime.CreateFloatingDateRule(ParseTimeOfDay(time), month, week, dayOfWeek);
		}
		if (date[0] != 'J')
		{
			if (int.TryParse(date, out var result) && result < 59)
			{
				int month2;
				int day;
				if (result <= 30)
				{
					month2 = 1;
					day = result + 1;
				}
				else
				{
					month2 = 2;
					day = result - 30;
				}
				return TransitionTime.CreateFixedDateRule(ParseTimeOfDay(time), month2, day);
			}
			return null;
		}
		TZif_ParseJulianDay(date, out var month3, out var day2);
		return TransitionTime.CreateFixedDateRule(ParseTimeOfDay(time), month3, day2);
	}

	private static void TZif_ParseJulianDay(ReadOnlySpan<char> date, out int month, out int day)
	{
		month = (day = 0);
		int num = 1;
		if ((uint)num >= (uint)date.Length || !char.IsAsciiDigit(date[num]))
		{
			throw new InvalidTimeZoneException("InvalidTimeZone_InvalidJulianDay");
		}
		int num2 = 0;
		do
		{
			num2 = num2 * 10 + (date[num] - 48);
			num++;
		}
		while ((uint)num < (uint)date.Length && char.IsAsciiDigit(date[num]));
		ReadOnlySpan<int> daysToMonth = GregorianCalendar.DaysToMonth365;
		if (num2 == 0 || num2 > daysToMonth[daysToMonth.Length - 1])
		{
			throw new InvalidTimeZoneException("InvalidTimeZone_InvalidJulianDay");
		}
		int i;
		for (i = 1; i < daysToMonth.Length && num2 > daysToMonth[i]; i++)
		{
		}
		month = i;
		day = num2 - daysToMonth[i - 1];
	}

	private static bool TZif_ParseMDateRule(ReadOnlySpan<char> dateRule, out int month, out int week, out DayOfWeek dayOfWeek)
	{
		if (dateRule[0] == 'M')
		{
			int num = dateRule.IndexOf('.');
			if (num > 0)
			{
				ReadOnlySpan<char> span = dateRule.Slice(num + 1);
				int num2 = span.IndexOf('.');
				if (num2 > 0 && int.TryParse(dateRule.Slice(1, num - 1), out month) && int.TryParse(span.Slice(0, num2), out week) && int.TryParse(span.Slice(num2 + 1), out var result))
				{
					dayOfWeek = (DayOfWeek)result;
					return true;
				}
			}
		}
		month = 0;
		week = 0;
		dayOfWeek = DayOfWeek.Sunday;
		return false;
	}

	private static bool TZif_ParsePosixFormat(ReadOnlySpan<char> posixFormat, out ReadOnlySpan<char> standardName, out ReadOnlySpan<char> standardOffset, out ReadOnlySpan<char> daylightSavingsName, out ReadOnlySpan<char> daylightSavingsOffset, out ReadOnlySpan<char> start, out ReadOnlySpan<char> startTime, out ReadOnlySpan<char> end, out ReadOnlySpan<char> endTime)
	{
		daylightSavingsOffset = null;
		start = null;
		startTime = null;
		end = null;
		endTime = null;
		int index = 0;
		standardName = TZif_ParsePosixName(posixFormat, ref index);
		standardOffset = TZif_ParsePosixOffset(posixFormat, ref index);
		daylightSavingsName = TZif_ParsePosixName(posixFormat, ref index);
		if (!daylightSavingsName.IsEmpty)
		{
			daylightSavingsOffset = TZif_ParsePosixOffset(posixFormat, ref index);
			if (index < posixFormat.Length && posixFormat[index] == ',')
			{
				index++;
				TZif_ParsePosixDateTime(posixFormat, ref index, out start, out startTime);
				if (index < posixFormat.Length && posixFormat[index] == ',')
				{
					index++;
					TZif_ParsePosixDateTime(posixFormat, ref index, out end, out endTime);
				}
			}
		}
		if (!standardName.IsEmpty)
		{
			return !standardOffset.IsEmpty;
		}
		return false;
	}

	private static ReadOnlySpan<char> TZif_ParsePosixName(ReadOnlySpan<char> posixFormat, scoped ref int index)
	{
		if (index < posixFormat.Length && posixFormat[index] == '<')
		{
			index++;
			ReadOnlySpan<char> result = TZif_ParsePosixString(posixFormat, ref index, (char c) => c == '>');
			if (index < posixFormat.Length && posixFormat[index] == '>')
			{
				index++;
			}
			return result;
		}
		return TZif_ParsePosixString(posixFormat, ref index, (char c) => char.IsDigit(c) || c == '+' || c == '-' || c == ',');
	}

	private static ReadOnlySpan<char> TZif_ParsePosixOffset(ReadOnlySpan<char> posixFormat, scoped ref int index)
	{
		return TZif_ParsePosixString(posixFormat, ref index, (char c) => !char.IsDigit(c) && c != '+' && c != '-' && c != ':');
	}

	private static void TZif_ParsePosixDateTime(ReadOnlySpan<char> posixFormat, scoped ref int index, out ReadOnlySpan<char> date, out ReadOnlySpan<char> time)
	{
		time = null;
		date = TZif_ParsePosixDate(posixFormat, ref index);
		if (index < posixFormat.Length && posixFormat[index] == '/')
		{
			index++;
			time = TZif_ParsePosixTime(posixFormat, ref index);
		}
	}

	private static ReadOnlySpan<char> TZif_ParsePosixDate(ReadOnlySpan<char> posixFormat, scoped ref int index)
	{
		return TZif_ParsePosixString(posixFormat, ref index, (char c) => c == '/' || c == ',');
	}

	private static ReadOnlySpan<char> TZif_ParsePosixTime(ReadOnlySpan<char> posixFormat, scoped ref int index)
	{
		return TZif_ParsePosixString(posixFormat, ref index, (char c) => c == ',');
	}

	private static ReadOnlySpan<char> TZif_ParsePosixString(ReadOnlySpan<char> posixFormat, scoped ref int index, Func<char, bool> breakCondition)
	{
		int num = index;
		while (index < posixFormat.Length)
		{
			char arg = posixFormat[index];
			if (breakCondition(arg))
			{
				break;
			}
			index++;
		}
		return posixFormat.Slice(num, index - num);
	}

	private static string TZif_GetZoneAbbreviation(string zoneAbbreviations, int index)
	{
		int num = zoneAbbreviations.IndexOf('\0', index);
		if (num <= 0)
		{
			return zoneAbbreviations.Substring(index);
		}
		return zoneAbbreviations.Substring(index, num - index);
	}

	private static short TZif_ToInt16(ReadOnlySpan<byte> value)
	{
		return BinaryPrimitives.ReadInt16BigEndian(value);
	}

	private static int TZif_ToInt32(byte[] value, int startIndex)
	{
		return BinaryPrimitives.ReadInt32BigEndian(value.AsSpan(startIndex));
	}

	private static int TZif_ToInt32(ReadOnlySpan<byte> value)
	{
		return BinaryPrimitives.ReadInt32BigEndian(value);
	}

	private static long TZif_ToInt64(byte[] value, int startIndex)
	{
		return BinaryPrimitives.ReadInt64BigEndian(value.AsSpan(startIndex));
	}

	private static long TZif_ToUnixTime(byte[] value, int startIndex, TZVersion version)
	{
		if (version == TZVersion.V1)
		{
			return TZif_ToInt32(value, startIndex);
		}
		return TZif_ToInt64(value, startIndex);
	}

	private static DateTime TZif_UnixTimeToDateTime(long unixTime)
	{
		if (unixTime >= -62135596800L)
		{
			if (unixTime <= 253402300799L)
			{
				return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
			}
			return DateTime.MaxValue;
		}
		return DateTime.MinValue;
	}

	private static void TZif_ParseRaw(byte[] data, out DateTime[] dts, out byte[] typeOfLocalTime, out TZifType[] transitionType, out string zoneAbbreviations, out string futureTransitionsPosixFormat)
	{
		futureTransitionsPosixFormat = null;
		int num = 0;
		TZifHead tZifHead = new TZifHead(data, num);
		num += 44;
		int num2 = 4;
		if (tZifHead.Version != TZVersion.V1)
		{
			num += (int)(num2 * tZifHead.TimeCount + tZifHead.TimeCount + 6 * tZifHead.TypeCount + (num2 + 4) * tZifHead.LeapCount + tZifHead.IsStdCount + tZifHead.IsGmtCount + tZifHead.CharCount);
			tZifHead = new TZifHead(data, num);
			num += 44;
			num2 = 8;
		}
		dts = new DateTime[tZifHead.TimeCount];
		typeOfLocalTime = new byte[tZifHead.TimeCount];
		transitionType = new TZifType[tZifHead.TypeCount];
		for (int i = 0; i < tZifHead.TimeCount; i++)
		{
			long unixTime = TZif_ToUnixTime(data, num, tZifHead.Version);
			dts[i] = TZif_UnixTimeToDateTime(unixTime);
			num += num2;
		}
		for (int j = 0; j < tZifHead.TimeCount; j++)
		{
			typeOfLocalTime[j] = data[num];
			num++;
		}
		for (int k = 0; k < tZifHead.TypeCount; k++)
		{
			transitionType[k] = new TZifType(data, num);
			num += 6;
		}
		Encoding uTF = Encoding.UTF8;
		zoneAbbreviations = uTF.GetString(data, num, (int)tZifHead.CharCount);
		num += (int)tZifHead.CharCount;
		num += (int)(tZifHead.LeapCount * (num2 + 4));
		num += (int)Math.Min(tZifHead.IsStdCount, tZifHead.TypeCount);
		num += (int)Math.Min(tZifHead.IsGmtCount, tZifHead.TypeCount);
		if (tZifHead.Version != TZVersion.V1 && data[num++] == 10 && data[^1] == 10)
		{
			futureTransitionsPosixFormat = uTF.GetString(data, num, data.Length - num - 1);
		}
	}

	private static void NormalizeAdjustmentRuleOffset(TimeSpan baseUtcOffset, [NotNull] ref AdjustmentRule adjustmentRule)
	{
		TimeSpan utcOffset = GetUtcOffset(baseUtcOffset, adjustmentRule);
		TimeSpan timeSpan = TimeSpan.Zero;
		if (utcOffset > MaxOffset)
		{
			timeSpan = MaxOffset - utcOffset;
		}
		else if (utcOffset < MinOffset)
		{
			timeSpan = MinOffset - utcOffset;
		}
		if (timeSpan != TimeSpan.Zero)
		{
			adjustmentRule = AdjustmentRule.CreateAdjustmentRule(adjustmentRule.DateStart, adjustmentRule.DateEnd, adjustmentRule.DaylightDelta, adjustmentRule.DaylightTransitionStart, adjustmentRule.DaylightTransitionEnd, adjustmentRule.BaseUtcOffsetDelta + timeSpan, adjustmentRule.NoDaylightTransitions);
		}
	}

	private static bool StringArrayContains(string value, string[] source, StringComparison comparison)
	{
		for (int i = 0; i < source.Length; i++)
		{
			if (string.Equals(source[i], value, comparison))
			{
				return true;
			}
		}
		return false;
	}

	private static int ParseGMTNumericZone(string name)
	{
		int num;
		if (name[3] == '+')
		{
			num = 1;
		}
		else
		{
			if (name[3] != '-')
			{
				return 0;
			}
			num = -1;
		}
		int num2 = 0;
		bool flag = false;
		int i;
		for (i = 4; i < name.Length; i++)
		{
			char c = name[i];
			if (c == ':')
			{
				i++;
				flag = true;
				break;
			}
			if (char.IsAsciiDigit(c))
			{
				num2 = num2 * 10 + c - 48;
				continue;
			}
			return 0;
		}
		int num3 = 0;
		for (; i < name.Length; i++)
		{
			char c2 = name[i];
			if (char.IsAsciiDigit(c2))
			{
				num3 = num3 * 10 + c2 - 48;
				continue;
			}
			return 0;
		}
		if (flag)
		{
			return num * (num2 * 60 + num3) * 60;
		}
		if (num2 >= 100)
		{
			return num * (num2 / 100 * 60 + num2 % 100) * 60;
		}
		return num * (num2 * 60) * 60;
	}

	private static TimeZoneInfo GetTimeZone(string id, string name)
	{
		if (name == "GMT" || name == "UTC")
		{
			return new TimeZoneInfo(id, TimeSpan.FromSeconds(0L), id, name, name, null, disableDaylightSavingTime: true);
		}
		if (name.Length >= 3 && name[0] == 'G' && name[1] == 'M' && name[2] == 'T')
		{
			return new TimeZoneInfo(id, TimeSpan.FromSeconds(ParseGMTNumericZone(name)), id, name, name, null, disableDaylightSavingTime: true);
		}
		try
		{
			return GetTimeZoneFromTzData(AndroidTzDataInstance.GetTimeZoneData(name), id);
		}
		catch
		{
			return null;
		}
	}

	private static TimeZoneInfo GetLocalTimeZoneCore()
	{
		if (Invariant)
		{
			return Utc;
		}
		string defaultTimeZone = Interop.Sys.GetDefaultTimeZone();
		if (!string.IsNullOrEmpty(defaultTimeZone))
		{
			TimeZoneInfo timeZone = GetTimeZone(defaultTimeZone, defaultTimeZone);
			if (timeZone != null)
			{
				return timeZone;
			}
		}
		return Utc;
	}

	private static TimeZoneInfoResult TryGetTimeZoneFromLocalMachineCore(string id, out TimeZoneInfo value, out Exception e)
	{
		value = ((id == "Local") ? GetLocalTimeZoneCore() : GetTimeZone(id, id));
		if (value == null)
		{
			e = new InvalidTimeZoneException(SR.Format("InvalidTimeZone_InvalidFileData", id, AndroidTzDataInstance.GetTimeZoneDirectory() + "tzdata"));
			return TimeZoneInfoResult.TimeZoneNotFoundException;
		}
		e = null;
		return TimeZoneInfoResult.Success;
	}

	private static string[] GetTimeZoneIds()
	{
		return AndroidTzDataInstance.GetTimeZoneIds();
	}

	private static string GetUtcStandardDisplayName()
	{
		CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
		_ = GlobalizationMode.Invariant;
		if (currentUICulture.Name.Length == 0 || currentUICulture.TwoLetterISOLanguageName == "en")
		{
			return "Coordinated Universal Time";
		}
		string displayName = null;
		GetDisplayName("UTC", Interop.Globalization.TimeZoneDisplayNameType.Standard, currentUICulture.Name, ref displayName);
		switch (displayName)
		{
		case null:
		case "GMT":
		case "UTC":
			displayName = "Coordinated Universal Time";
			break;
		}
		return displayName;
	}

	private static string GetUtcFullDisplayName(string timeZoneId, string standardDisplayName)
	{
		return "(UTC) " + standardDisplayName;
	}

	private static void GetStandardDisplayName(string timeZoneId, ref string displayName)
	{
		GetDisplayName(timeZoneId, Interop.Globalization.TimeZoneDisplayNameType.Standard, UICulture.Name, ref displayName);
	}

	private static void GetDaylightDisplayName(string timeZoneId, ref string displayName)
	{
		GetDisplayName(timeZoneId, Interop.Globalization.TimeZoneDisplayNameType.DaylightSavings, UICulture.Name, ref displayName);
	}

	private unsafe static void GetDisplayName(string timeZoneId, Interop.Globalization.TimeZoneDisplayNameType nameType, string uiCulture, ref string displayName)
	{
		if (GlobalizationMode.Invariant)
		{
		}
		string result;
		bool flag = Interop.CallStringMethod(delegate(Span<char> buffer, string locale, string id, Interop.Globalization.TimeZoneDisplayNameType type)
		{
			fixed (char* result2 = buffer)
			{
				return Interop.Globalization.GetTimeZoneDisplayName(locale, id, type, result2, buffer.Length);
			}
		}, uiCulture, timeZoneId, nameType, out result);
		if (!flag && uiCulture != "en-US")
		{
			flag = Interop.CallStringMethod(delegate(Span<char> buffer, string locale, string id, Interop.Globalization.TimeZoneDisplayNameType type)
			{
				fixed (char* result2 = buffer)
				{
					return Interop.Globalization.GetTimeZoneDisplayName(locale, id, type, result2, buffer.Length);
				}
			}, "en-US", timeZoneId, nameType, out result);
		}
		if (flag && !string.IsNullOrEmpty(result))
		{
			displayName = result;
		}
	}

	private static void GetFullValueForDisplayNameField(string timeZoneId, TimeSpan baseUtcOffset, ref string displayName)
	{
		CultureInfo uICulture = UICulture;
		IFormatProvider formatProvider = null;
		IFormatProvider provider = formatProvider;
		Span<char> initialBuffer = stackalloc char[128];
		DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(5, 2, formatProvider, initialBuffer);
		handler.AppendLiteral("(UTC");
		handler.AppendFormatted((baseUtcOffset >= TimeSpan.Zero) ? '+' : '-');
		handler.AppendFormatted(baseUtcOffset, "hh\\:mm");
		handler.AppendLiteral(")");
		string text = string.Create(provider, initialBuffer, ref handler);
		string displayName2 = null;
		GetDisplayName(timeZoneId, Interop.Globalization.TimeZoneDisplayNameType.Generic, uICulture.Name, ref displayName2);
		if (displayName2 == null)
		{
			return;
		}
		string displayName3 = null;
		GetDisplayName(timeZoneId, Interop.Globalization.TimeZoneDisplayNameType.GenericLocation, uICulture.Name, ref displayName3);
		if (baseUtcOffset == TimeSpan.Zero)
		{
			string displayName4 = null;
			GetDisplayName("GMT", Interop.Globalization.TimeZoneDisplayNameType.GenericLocation, uICulture.Name, ref displayName4);
			if (displayName3 == displayName4)
			{
				displayName = text + " " + displayName2;
				return;
			}
			string displayName5 = null;
			GetDisplayName("GMT", Interop.Globalization.TimeZoneDisplayNameType.Generic, uICulture.Name, ref displayName5);
			if (displayName2 == displayName5)
			{
				displayName = text + " " + displayName3;
				return;
			}
		}
		if (displayName3 == displayName2)
		{
			displayName = text + " " + displayName3;
			return;
		}
		if (StringArrayContains(timeZoneId, s_ZonesThatUseLocationName, StringComparison.OrdinalIgnoreCase))
		{
			displayName = text + " " + displayName3;
			return;
		}
		string exemplarCityName = GetExemplarCityName(timeZoneId, uICulture.Name);
		if (uICulture.CompareInfo.IndexOf(displayName2, exemplarCityName, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) >= 0 && displayName3 != null)
		{
			displayName = text + " " + displayName2;
			return;
		}
		displayName = $"{text} {displayName2} ({exemplarCityName})";
	}

	private static string GetExemplarCityName(string timeZoneId, string uiCultureName)
	{
		string displayName = null;
		GetDisplayName(timeZoneId, Interop.Globalization.TimeZoneDisplayNameType.ExemplarCity, uiCultureName, ref displayName);
		if (!string.IsNullOrEmpty(displayName))
		{
			return displayName;
		}
		int num = timeZoneId.LastIndexOf('/');
		return timeZoneId.Substring(num + 1).Replace('_', ' ');
	}

	private static string GetAlternativeId(string id, out bool idIsIana)
	{
		idIsIana = false;
		if (!TryConvertWindowsIdToIanaId(id, null, out string ianaId))
		{
			return null;
		}
		return ianaId;
	}
}

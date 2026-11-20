using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace System.Text.Json;

[DefaultMember("Item")]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct JsonElement
{
	[DebuggerDisplay("{Current,nq}")]
	public struct ArrayEnumerator : IEnumerable<JsonElement>, IEnumerable, IEnumerator<JsonElement>, IEnumerator, IDisposable
	{
		private readonly JsonElement _target;

		private int _curIdx;

		private readonly int _endIdxOrVersion;

		public JsonElement Current
		{
			get
			{
				if (_curIdx < 0)
				{
					return default(JsonElement);
				}
				return new JsonElement(_target._parent, _curIdx);
			}
		}

		object IEnumerator.Current => Current;

		internal ArrayEnumerator(JsonElement target, int currentIndex = -1)
		{
			_target = target;
			_curIdx = currentIndex;
			_endIdxOrVersion = target._parent.GetEndIndex(_target._idx, includeEndElement: false);
		}

		public ArrayEnumerator GetEnumerator()
		{
			ArrayEnumerator result = this;
			result._curIdx = -1;
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<JsonElement> IEnumerable<JsonElement>.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Dispose()
		{
			_curIdx = _endIdxOrVersion;
		}

		public void Reset()
		{
			_curIdx = -1;
		}

		public bool MoveNext()
		{
			if (_curIdx >= _endIdxOrVersion)
			{
				return false;
			}
			if (_curIdx < 0)
			{
				_curIdx = _target._idx + 12;
			}
			else
			{
				_curIdx = _target._parent.GetEndIndex(_curIdx, includeEndElement: true);
			}
			return _curIdx < _endIdxOrVersion;
		}
	}

	[DebuggerDisplay("{Current,nq}")]
	public struct ObjectEnumerator : IEnumerable<JsonProperty>, IEnumerable, IEnumerator<JsonProperty>, IEnumerator, IDisposable
	{
		private readonly JsonElement _target;

		private int _curIdx;

		private readonly int _endIdxOrVersion;

		public JsonProperty Current
		{
			get
			{
				if (_curIdx < 0)
				{
					return default(JsonProperty);
				}
				return new JsonProperty(new JsonElement(_target._parent, _curIdx));
			}
		}

		object IEnumerator.Current => Current;

		internal ObjectEnumerator(JsonElement target, int currentIndex = -1)
		{
			_target = target;
			_curIdx = currentIndex;
			_endIdxOrVersion = target._parent.GetEndIndex(_target._idx, includeEndElement: false);
		}

		public ObjectEnumerator GetEnumerator()
		{
			ObjectEnumerator result = this;
			result._curIdx = -1;
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<JsonProperty> IEnumerable<JsonProperty>.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Dispose()
		{
			_curIdx = _endIdxOrVersion;
		}

		public void Reset()
		{
			_curIdx = -1;
		}

		public bool MoveNext()
		{
			if (_curIdx >= _endIdxOrVersion)
			{
				return false;
			}
			if (_curIdx < 0)
			{
				_curIdx = _target._idx + 12;
			}
			else
			{
				_curIdx = _target._parent.GetEndIndex(_curIdx, includeEndElement: true);
			}
			_curIdx += 12;
			return _curIdx < _endIdxOrVersion;
		}
	}

	private readonly JsonDocument _parent;

	private readonly int _idx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private JsonTokenType TokenType => _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;

	public JsonValueKind ValueKind => TokenType.ToValueKind();

	internal int MetadataDbIndex => _idx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string DebuggerDisplay => $"ValueKind = {ValueKind} : \"{ToString()}\"";

	internal JsonElement(JsonDocument parent, int idx)
	{
		_parent = parent;
		_idx = idx;
	}

	public int GetPropertyCount()
	{
		CheckValidInstance();
		return _parent.GetPropertyCount(_idx);
	}

	public string? GetString()
	{
		CheckValidInstance();
		return _parent.GetString(_idx, JsonTokenType.String);
	}

	internal string GetPropertyRawText()
	{
		CheckValidInstance();
		return _parent.GetPropertyRawValueAsString(_idx);
	}

	public override string ToString()
	{
		switch (TokenType)
		{
		case JsonTokenType.None:
		case JsonTokenType.Null:
			return string.Empty;
		case JsonTokenType.True:
			return bool.TrueString;
		case JsonTokenType.False:
			return bool.FalseString;
		case JsonTokenType.StartObject:
		case JsonTokenType.StartArray:
		case JsonTokenType.Number:
			return _parent.GetRawValueAsString(_idx);
		case JsonTokenType.String:
			return GetString();
		default:
			return string.Empty;
		}
	}

	public JsonElement Clone()
	{
		CheckValidInstance();
		if (!_parent.IsDisposable)
		{
			return this;
		}
		return _parent.CloneElement(_idx);
	}

	private void CheckValidInstance()
	{
		if (_parent == null)
		{
			throw new InvalidOperationException();
		}
	}
}

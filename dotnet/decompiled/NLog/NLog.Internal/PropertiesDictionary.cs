using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using NLog.MessageTemplates;

namespace NLog.Internal;

[DebuggerDisplay("Count = {Count}")]
internal sealed class PropertiesDictionary : IDictionary<object, object?>, ICollection<KeyValuePair<object, object?>>, IEnumerable<KeyValuePair<object, object?>>, IEnumerable
{
	private readonly struct PropertyValue
	{
		public readonly object? Value;

		public readonly bool IsMessageProperty;

		public PropertyValue(object? value, bool isMessageProperty)
		{
			Value = value;
			IsMessageProperty = isMessageProperty;
		}
	}

	public struct PropertyDictionaryEnumerator : IEnumerator<KeyValuePair<object, object?>>, IEnumerator, IDisposable
	{
		private readonly PropertiesDictionary _dictionary;

		private Dictionary<object, PropertyValue>.Enumerator _eventEnumerator;

		private int? _messagePropertiesIndex;

		public KeyValuePair<object, object?> Current
		{
			get
			{
				if (_messagePropertiesIndex.HasValue)
				{
					MessageTemplateParameter messageTemplateParameter = _dictionary.MessageProperties[_messagePropertiesIndex.Value];
					return new KeyValuePair<object, object>(messageTemplateParameter.Name, messageTemplateParameter.Value);
				}
				if (_dictionary._eventProperties != null)
				{
					return new KeyValuePair<object, object>(_eventEnumerator.Current.Key, _eventEnumerator.Current.Value.Value);
				}
				throw new InvalidOperationException();
			}
		}

		public MessageTemplateParameter CurrentParameter
		{
			get
			{
				if (_messagePropertiesIndex.HasValue)
				{
					return _dictionary.MessageProperties[_messagePropertiesIndex.Value];
				}
				if (_dictionary._eventProperties != null)
				{
					return new MessageTemplateParameter(XmlHelper.XmlConvertToString(_eventEnumerator.Current.Key ?? string.Empty) ?? string.Empty, _eventEnumerator.Current.Value.Value, null, CaptureType.Unknown);
				}
				throw new InvalidOperationException();
			}
		}

		public KeyValuePair<string, object?> CurrentProperty
		{
			get
			{
				if (_messagePropertiesIndex.HasValue)
				{
					MessageTemplateParameter messageTemplateParameter = _dictionary.MessageProperties[_messagePropertiesIndex.Value];
					return new KeyValuePair<string, object>(messageTemplateParameter.Name, messageTemplateParameter.Value);
				}
				if (_dictionary._eventProperties != null)
				{
					return new KeyValuePair<string, object>(XmlHelper.XmlConvertToString(_eventEnumerator.Current.Key ?? string.Empty) ?? string.Empty, _eventEnumerator.Current.Value.Value);
				}
				throw new InvalidOperationException();
			}
		}

		object IEnumerator.Current => Current;

		public PropertyDictionaryEnumerator(PropertiesDictionary dictionary)
		{
			_dictionary = dictionary;
			_eventEnumerator = dictionary._eventProperties?.GetEnumerator() ?? default(Dictionary<object, PropertyValue>.Enumerator);
			IList<MessageTemplateParameter>? messageProperties = dictionary._messageProperties;
			_messagePropertiesIndex = ((messageProperties != null && messageProperties.Count > 0) ? new int?(-1) : ((int?)null));
		}

		public bool MoveNext()
		{
			if (_messagePropertiesIndex.HasValue && MoveNextValidMessageParameter())
			{
				return true;
			}
			if (_dictionary._eventProperties != null)
			{
				return MoveNextValidEventProperty();
			}
			return false;
		}

		private bool MoveNextValidEventProperty()
		{
			while (_eventEnumerator.MoveNext())
			{
				if (!_eventEnumerator.Current.Value.IsMessageProperty)
				{
					return true;
				}
			}
			return false;
		}

		private bool MoveNextValidMessageParameter()
		{
			IList<MessageTemplateParameter> messageProperties = _dictionary.MessageProperties;
			if (_messagePropertiesIndex.HasValue && messageProperties != null && _messagePropertiesIndex.Value + 1 < messageProperties.Count)
			{
				Dictionary<object, PropertyValue> eventProperties = _dictionary._eventProperties;
				if (eventProperties == null)
				{
					_messagePropertiesIndex = _messagePropertiesIndex.Value + 1;
					return true;
				}
				for (int i = _messagePropertiesIndex.Value + 1; i < messageProperties.Count; i++)
				{
					if (eventProperties.TryGetValue(messageProperties[i].Name, out var value) && value.IsMessageProperty)
					{
						_messagePropertiesIndex = i;
						return true;
					}
				}
			}
			_messagePropertiesIndex = null;
			return false;
		}

		public void Dispose()
		{
		}

		public void Reset()
		{
			IList<MessageTemplateParameter>? messageProperties = _dictionary._messageProperties;
			_messagePropertiesIndex = ((messageProperties != null && messageProperties.Count > 0) ? new int?(-1) : ((int?)null));
			_eventEnumerator = default(Dictionary<object, PropertyValue>.Enumerator);
		}
	}

	[DebuggerDisplay("Count = {Count}")]
	private sealed class ValueCollection : ICollection<object?>, IEnumerable<object?>, IEnumerable
	{
		private sealed class ValueCollectionEnumerator : IEnumerator<object?>, IEnumerator, IDisposable
		{
			private PropertyDictionaryEnumerator _enumerator;

			public object? Current => _enumerator.Current.Value;

			public ValueCollectionEnumerator(PropertiesDictionary dictionary)
			{
				_enumerator = dictionary.GetPropertyEnumerator();
			}

			public void Dispose()
			{
				_enumerator.Dispose();
			}

			public bool MoveNext()
			{
				return _enumerator.MoveNext();
			}

			public void Reset()
			{
				_enumerator.Reset();
			}
		}

		private readonly PropertiesDictionary _dictionary;

		public int Count => _dictionary.Count;

		public bool IsReadOnly => true;

		public ValueCollection(PropertiesDictionary dictionary)
		{
			_dictionary = dictionary;
		}

		public void Add(object? item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Remove(object? item)
		{
			throw new NotSupportedException();
		}

		public bool Contains(object? item)
		{
			if (!_dictionary.IsEmpty)
			{
				if (_dictionary.EventProperties.ContainsValue(new PropertyValue(item, isMessageProperty: false)))
				{
					return true;
				}
				if (_dictionary.EventProperties.ContainsValue(new PropertyValue(item, isMessageProperty: true)))
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(object?[] array, int arrayIndex)
		{
			Guard.ThrowIfNull(array, "array");
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (_dictionary.IsEmpty)
			{
				return;
			}
			foreach (KeyValuePair<object, object> item in _dictionary)
			{
				array[arrayIndex++] = item.Value;
			}
		}

		public IEnumerator<object?> GetEnumerator()
		{
			return new ValueCollectionEnumerator(_dictionary);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	[DebuggerDisplay("Count = {Count}")]
	private sealed class KeyCollection : ICollection<object>, IEnumerable<object>, IEnumerable
	{
		private sealed class KeyCollectionEnumerator : IEnumerator<object>, IEnumerator, IDisposable
		{
			private PropertyDictionaryEnumerator _enumerator;

			public object Current => _enumerator.Current.Key;

			public KeyCollectionEnumerator(PropertiesDictionary dictionary)
			{
				_enumerator = dictionary.GetPropertyEnumerator();
			}

			public void Dispose()
			{
				_enumerator.Dispose();
			}

			public bool MoveNext()
			{
				return _enumerator.MoveNext();
			}

			public void Reset()
			{
				_enumerator.Reset();
			}
		}

		private readonly PropertiesDictionary _dictionary;

		public int Count => _dictionary.Count;

		public bool IsReadOnly => true;

		public KeyCollection(PropertiesDictionary dictionary)
		{
			_dictionary = dictionary;
		}

		public void Add(object item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Remove(object item)
		{
			throw new NotSupportedException();
		}

		public bool Contains(object item)
		{
			return _dictionary.ContainsKey(item);
		}

		public void CopyTo(object[] array, int arrayIndex)
		{
			Guard.ThrowIfNull(array, "array");
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (_dictionary.IsEmpty)
			{
				return;
			}
			foreach (KeyValuePair<object, object> item in _dictionary)
			{
				array[arrayIndex++] = item.Key;
			}
		}

		public IEnumerator<object> GetEnumerator()
		{
			return new KeyCollectionEnumerator(_dictionary);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	internal sealed class IgnoreCasePropertyKey
	{
		private readonly string _propertyName;

		public IgnoreCasePropertyKey(string propertyName)
		{
			_propertyName = propertyName;
		}

		public bool Equals(string propertyName)
		{
			return Equals(_propertyName, propertyName);
		}

		public override bool Equals(object obj)
		{
			if (obj is string y)
			{
				return Equals(_propertyName, y);
			}
			if (obj is IgnoreCasePropertyKey ignoreCasePropertyKey)
			{
				return Equals(_propertyName, ignoreCasePropertyKey._propertyName);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return GetHashCode(_propertyName);
		}

		public override string ToString()
		{
			return _propertyName;
		}

		internal static int GetHashCode(string propertyName)
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(propertyName);
		}

		internal static bool Equals(string x, string y)
		{
			return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class PropertyKeyComparer : IEqualityComparer<object>
	{
		public static readonly PropertyKeyComparer Default = new PropertyKeyComparer();

		public new bool Equals(object x, object y)
		{
			if (y is IgnoreCasePropertyKey ignoreCasePropertyKey && x is string propertyName)
			{
				return ignoreCasePropertyKey.Equals(propertyName);
			}
			if (x is IgnoreCasePropertyKey ignoreCasePropertyKey2 && y is string propertyName2)
			{
				return ignoreCasePropertyKey2.Equals(propertyName2);
			}
			return EqualityComparer<object>.Default.Equals(x, y);
		}

		public int GetHashCode(object obj)
		{
			if (obj is string propertyName)
			{
				return IgnoreCasePropertyKey.GetHashCode(propertyName);
			}
			return EqualityComparer<object>.Default.GetHashCode(obj);
		}
	}

	private Dictionary<object, PropertyValue>? _eventProperties;

	private IList<MessageTemplateParameter>? _messageProperties;

	private static readonly KeyCollection EmptyKeyCollection = new KeyCollection(new PropertiesDictionary());

	private static readonly ValueCollection EmptyValueCollection = new ValueCollection(new PropertiesDictionary());

	private bool IsEmpty
	{
		get
		{
			if (_eventProperties == null || _eventProperties.Count == 0)
			{
				if (_messageProperties != null)
				{
					return _messageProperties.Count == 0;
				}
				return true;
			}
			return false;
		}
	}

	private Dictionary<object, PropertyValue> EventProperties
	{
		get
		{
			if (_eventProperties == null)
			{
				Interlocked.CompareExchange(ref _eventProperties, BuildEventProperties(_messageProperties), null);
			}
			return _eventProperties;
		}
	}

	public IList<MessageTemplateParameter> MessageProperties => _messageProperties ?? ArrayHelper.Empty<MessageTemplateParameter>();

	public object? this[object key]
	{
		get
		{
			if (TryGetValue(key, out object value))
			{
				return value;
			}
			throw new KeyNotFoundException();
		}
		set
		{
			EventProperties[key] = new PropertyValue(value, isMessageProperty: false);
		}
	}

	public ICollection<object> Keys
	{
		get
		{
			if (!IsEmpty)
			{
				return new KeyCollection(this);
			}
			return EmptyKeyCollection;
		}
	}

	public ICollection<object?> Values
	{
		get
		{
			if (!IsEmpty)
			{
				return new ValueCollection(this);
			}
			return EmptyValueCollection;
		}
	}

	public int Count => _eventProperties?.Count ?? _messageProperties?.Count ?? 0;

	public bool IsReadOnly => false;

	public PropertiesDictionary(IList<MessageTemplateParameter>? messageParameters = null)
	{
		if (messageParameters != null && messageParameters.Count > 0)
		{
			_messageProperties = SetMessageProperties(messageParameters, null);
		}
	}

	public PropertiesDictionary(int initialCapacity)
	{
		if (initialCapacity > 3)
		{
			_eventProperties = new Dictionary<object, PropertyValue>(initialCapacity, PropertyKeyComparer.Default);
		}
	}

	public void ResetMessageProperties(IList<MessageTemplateParameter>? newMessageProperties = null)
	{
		_messageProperties = SetMessageProperties(newMessageProperties, _messageProperties);
	}

	private IList<MessageTemplateParameter>? SetMessageProperties(IList<MessageTemplateParameter>? newMessageProperties, IList<MessageTemplateParameter>? oldMessageProperties)
	{
		if (_eventProperties == null && VerifyUniqueMessageTemplateParametersFast(newMessageProperties))
		{
			return newMessageProperties;
		}
		Dictionary<object, PropertyValue> dictionary = _eventProperties;
		if (dictionary == null)
		{
			dictionary = (_eventProperties = new Dictionary<object, PropertyValue>(newMessageProperties?.Count ?? 0, PropertyKeyComparer.Default));
		}
		if (oldMessageProperties != null && dictionary.Count > 0)
		{
			RemoveOldMessageProperties(oldMessageProperties, dictionary);
		}
		if (newMessageProperties != null)
		{
			InsertMessagePropertiesIntoEmptyDictionary(newMessageProperties, dictionary);
		}
		return newMessageProperties;
	}

	private static void RemoveOldMessageProperties(IList<MessageTemplateParameter> oldMessageProperties, Dictionary<object, PropertyValue> eventProperties)
	{
		for (int i = 0; i < oldMessageProperties.Count; i++)
		{
			if (eventProperties.TryGetValue(oldMessageProperties[i].Name, out var value) && value.IsMessageProperty)
			{
				eventProperties.Remove(oldMessageProperties[i].Name);
			}
		}
	}

	private static Dictionary<object, PropertyValue> BuildEventProperties(IList<MessageTemplateParameter>? messageProperties)
	{
		if (messageProperties != null && messageProperties.Count > 0)
		{
			Dictionary<object, PropertyValue> dictionary = new Dictionary<object, PropertyValue>(messageProperties.Count, PropertyKeyComparer.Default);
			InsertMessagePropertiesIntoEmptyDictionary(messageProperties, dictionary);
			return dictionary;
		}
		return new Dictionary<object, PropertyValue>(PropertyKeyComparer.Default);
	}

	public void Add(object key, object? value)
	{
		EventProperties.Add(key, new PropertyValue(value, isMessageProperty: false));
	}

	public void Add(KeyValuePair<object, object?> item)
	{
		Add(item.Key, item.Value);
	}

	public void Clear()
	{
		if (_eventProperties != null)
		{
			_eventProperties = null;
		}
		if (_messageProperties != null)
		{
			_messageProperties = ArrayHelper.Empty<MessageTemplateParameter>();
		}
	}

	public bool Contains(KeyValuePair<object, object?> item)
	{
		if (!IsEmpty && (_eventProperties != null || ContainsKey(item.Key)))
		{
			if (((ICollection<KeyValuePair<object, PropertyValue>>)EventProperties).Contains(new KeyValuePair<object, PropertyValue>(item.Key, new PropertyValue(item.Value, isMessageProperty: false))))
			{
				return true;
			}
			if (((ICollection<KeyValuePair<object, PropertyValue>>)EventProperties).Contains(new KeyValuePair<object, PropertyValue>(item.Key, new PropertyValue(item.Value, isMessageProperty: true))))
			{
				return true;
			}
		}
		return false;
	}

	public bool ContainsKey(object key)
	{
		object value;
		return TryGetValue(key, out value);
	}

	public void CopyTo(KeyValuePair<object, object?>[] array, int arrayIndex)
	{
		Guard.ThrowIfNull(array, "array");
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex");
		}
		if (IsEmpty)
		{
			return;
		}
		using IEnumerator<KeyValuePair<object, object>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<object, object> current = enumerator.Current;
			array[arrayIndex++] = current;
		}
	}

	internal PropertyDictionaryEnumerator GetPropertyEnumerator()
	{
		return new PropertyDictionaryEnumerator(this);
	}

	public IEnumerator<KeyValuePair<object, object?>> GetEnumerator()
	{
		if (!IsEmpty)
		{
			return new PropertyDictionaryEnumerator(this);
		}
		return Enumerable.Empty<KeyValuePair<object, object>>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public bool Remove(object key)
	{
		if (!IsEmpty && (_eventProperties != null || ContainsKey(key)))
		{
			return EventProperties.Remove(key);
		}
		return false;
	}

	public bool Remove(KeyValuePair<object, object?> item)
	{
		if (!IsEmpty && (_eventProperties != null || ContainsKey(item.Key)))
		{
			if (((ICollection<KeyValuePair<object, PropertyValue>>)EventProperties).Remove(new KeyValuePair<object, PropertyValue>(item.Key, new PropertyValue(item.Value, isMessageProperty: false))))
			{
				return true;
			}
			if (((ICollection<KeyValuePair<object, PropertyValue>>)EventProperties).Remove(new KeyValuePair<object, PropertyValue>(item.Key, new PropertyValue(item.Value, isMessageProperty: true))))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryGetValue(object key, out object? value)
	{
		if (!IsEmpty)
		{
			if (_eventProperties == null)
			{
				return TryLookupMessagePropertyValue(key, out value);
			}
			if (EventProperties.TryGetValue(key, out var value2))
			{
				value = value2.Value;
				return true;
			}
		}
		value = null;
		return false;
	}

	private bool TryLookupMessagePropertyValue(object key, out object? propertyValue)
	{
		if (_messageProperties == null || _messageProperties.Count == 0)
		{
			propertyValue = null;
			return false;
		}
		if (_messageProperties.Count > 10)
		{
			if (EventProperties.TryGetValue(key, out var value))
			{
				propertyValue = value.Value;
				return true;
			}
		}
		else if (key is string text)
		{
			for (int i = 0; i < _messageProperties.Count; i++)
			{
				if (text.Equals(_messageProperties[i].Name, StringComparison.Ordinal))
				{
					propertyValue = _messageProperties[i].Value;
					return true;
				}
			}
		}
		else if (key is IgnoreCasePropertyKey ignoreCasePropertyKey)
		{
			for (int j = 0; j < _messageProperties.Count; j++)
			{
				if (ignoreCasePropertyKey.Equals(_messageProperties[j].Name))
				{
					propertyValue = _messageProperties[j].Value;
					return true;
				}
			}
		}
		propertyValue = null;
		return false;
	}

	private static bool VerifyUniqueMessageTemplateParametersFast(IList<MessageTemplateParameter>? parameterList)
	{
		if (parameterList == null)
		{
			return true;
		}
		int count = parameterList.Count;
		if (count <= 1)
		{
			return true;
		}
		if (count > 10)
		{
			return false;
		}
		for (int i = 0; i < count - 1; i++)
		{
			string name = parameterList[i].Name;
			for (int j = i + 1; j < count; j++)
			{
				if (name == parameterList[j].Name)
				{
					return false;
				}
			}
		}
		return true;
	}

	private static void InsertMessagePropertiesIntoEmptyDictionary(IList<MessageTemplateParameter> messageProperties, Dictionary<object, PropertyValue> eventProperties)
	{
		for (int i = 0; i < messageProperties.Count; i++)
		{
			try
			{
				eventProperties.Add(messageProperties[i].Name, new PropertyValue(messageProperties[i].Value, isMessageProperty: true));
			}
			catch (ArgumentException)
			{
				MessageTemplateParameter messageTemplateParameter = messageProperties[i];
				if (eventProperties.TryGetValue(messageTemplateParameter.Name, out var value) && value.IsMessageProperty)
				{
					string text = GenerateUniquePropertyName(messageTemplateParameter.Name, eventProperties, (string newkey, IDictionary<object, PropertyValue> props) => props.ContainsKey(newkey));
					eventProperties.Add(text, new PropertyValue(messageProperties[i].Value, isMessageProperty: true));
					messageProperties[i] = new MessageTemplateParameter(text, messageTemplateParameter.Value, messageTemplateParameter.Format, messageTemplateParameter.CaptureType);
				}
			}
		}
	}

	internal static string GenerateUniquePropertyName<TKey, TValue>(string originalName, IDictionary<TKey, TValue> properties, Func<string, IDictionary<TKey, TValue>, bool> containsKey)
	{
		originalName = originalName ?? string.Empty;
		int num = 1;
		string text = originalName + "_1";
		while (containsKey(text, properties))
		{
			string text2 = originalName;
			int num2 = ++num;
			text = text2 + "_" + num2;
		}
		return text;
	}
}

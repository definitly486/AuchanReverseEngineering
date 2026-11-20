using System.Diagnostics.CodeAnalysis;

namespace System.IO;

internal struct RowConfigReader
{
	private readonly string _buffer;

	private readonly StringComparison _comparisonKind;

	private int _currentIndex;

	public RowConfigReader(string buffer)
	{
		_buffer = buffer;
		_comparisonKind = StringComparison.Ordinal;
		_currentIndex = 0;
	}

	public bool TryGetNextValue(string key, [NotNullWhen(true)] out string value)
	{
		if (_currentIndex >= _buffer.Length)
		{
			value = null;
			return false;
		}
		if (!TryFindNextKeyOccurrence(key, _currentIndex, out var keyIndex))
		{
			value = null;
			return false;
		}
		int startIndex = keyIndex + key.Length;
		int num = _buffer.IndexOf("\n", startIndex, _comparisonKind);
		int num2;
		if (num == -1)
		{
			num = _buffer.Length - 1;
			num2 = num;
		}
		else
		{
			num2 = num - 1;
		}
		int count = num - keyIndex;
		int num3 = _buffer.LastIndexOf('\t', num, count);
		if (num3 == -1)
		{
			num3 = _buffer.LastIndexOf(' ', num, count);
		}
		int num4 = num3 + 1;
		int num5 = num2 - num3;
		if (num4 <= keyIndex || num4 == -1 || num5 == 0)
		{
			value = null;
			return false;
		}
		value = _buffer.Substring(num4, num5);
		_currentIndex = num + 1;
		return true;
	}

	private bool TryFindNextKeyOccurrence(string key, int startIndex, out int keyIndex)
	{
		while (true)
		{
			keyIndex = _buffer.IndexOf(key, startIndex, _comparisonKind);
			if (keyIndex == -1)
			{
				return false;
			}
			if ((keyIndex == 0 || (keyIndex >= "\n".Length && _buffer.AsSpan(keyIndex - "\n".Length, "\n".Length).SequenceEqual("\n".AsSpan()))) && HasFollowingWhitespace(keyIndex, key.Length))
			{
				break;
			}
			startIndex += key.Length;
		}
		return true;
	}

	private bool HasFollowingWhitespace(int keyIndex, int length)
	{
		if (keyIndex + length < _buffer.Length)
		{
			if (_buffer[keyIndex + length] != ' ')
			{
				return _buffer[keyIndex + length] == '\t';
			}
			return true;
		}
		return false;
	}
}

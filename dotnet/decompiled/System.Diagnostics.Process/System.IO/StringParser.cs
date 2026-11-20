namespace System.IO;

internal struct StringParser
{
	internal delegate T ParseRawFunc<T>(string buffer, ref int startIndex, ref int endIndex);

	private readonly string _buffer;

	private readonly char _separator;

	private readonly bool _skipEmpty;

	private int _startIndex;

	private int _endIndex;

	public StringParser(string buffer, char separator, bool skipEmpty = false)
	{
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		_buffer = buffer;
		_separator = separator;
		_skipEmpty = skipEmpty;
		_startIndex = -1;
		_endIndex = -1;
	}

	public bool MoveNext()
	{
		if (_buffer == null)
		{
			throw new InvalidOperationException();
		}
		do
		{
			if (_endIndex >= _buffer.Length)
			{
				_startIndex = _endIndex;
				return false;
			}
			int num = _buffer.IndexOf(_separator, _endIndex + 1);
			_startIndex = _endIndex + 1;
			_endIndex = ((num >= 0) ? num : _buffer.Length);
		}
		while (_skipEmpty && _endIndex < _startIndex + 1);
		return true;
	}

	public void MoveNextOrFail()
	{
		if (!MoveNext())
		{
			ThrowForInvalidData();
		}
	}

	public string MoveAndExtractNextInOuterParens()
	{
		MoveNextOrFail();
		if (_buffer[_startIndex] != '(')
		{
			ThrowForInvalidData();
		}
		int num = _buffer.LastIndexOf(')');
		if (num == -1 || num < _startIndex)
		{
			ThrowForInvalidData();
		}
		string result = _buffer.Substring(_startIndex + 1, num - _startIndex - 1);
		_endIndex = num + 1;
		return result;
	}

	public unsafe int ParseNextInt32()
	{
		MoveNextOrFail();
		bool flag = false;
		int num = 0;
		fixed (char* buffer = _buffer)
		{
			char* ptr = buffer + _startIndex;
			char* ptr2 = buffer + _endIndex;
			if (ptr == ptr2)
			{
				ThrowForInvalidData();
			}
			if (*ptr == '-')
			{
				flag = true;
				ptr++;
				if (ptr == ptr2)
				{
					ThrowForInvalidData();
				}
			}
			for (; ptr != ptr2; ptr++)
			{
				int num2 = *ptr - 48;
				if (num2 < 0 || num2 > 9)
				{
					ThrowForInvalidData();
				}
				num = checked(flag ? (num * 10 - num2) : (num * 10 + num2));
			}
		}
		return num;
	}

	public unsafe long ParseNextInt64()
	{
		MoveNextOrFail();
		bool flag = false;
		long num = 0L;
		fixed (char* buffer = _buffer)
		{
			char* ptr = buffer + _startIndex;
			char* ptr2 = buffer + _endIndex;
			if (ptr == ptr2)
			{
				ThrowForInvalidData();
			}
			if (*ptr == '-')
			{
				flag = true;
				ptr++;
				if (ptr == ptr2)
				{
					ThrowForInvalidData();
				}
			}
			for (; ptr != ptr2; ptr++)
			{
				int num2 = *ptr - 48;
				if (num2 < 0 || num2 > 9)
				{
					ThrowForInvalidData();
				}
				num = checked(flag ? (num * 10 - num2) : (num * 10 + num2));
			}
		}
		return num;
	}

	public unsafe ulong ParseNextUInt64()
	{
		MoveNextOrFail();
		ulong num = 0uL;
		fixed (char* buffer = _buffer)
		{
			char* ptr = buffer + _startIndex;
			for (char* ptr2 = buffer + _endIndex; ptr != ptr2; ptr++)
			{
				int num2 = *ptr - 48;
				if (num2 < 0 || num2 > 9)
				{
					ThrowForInvalidData();
				}
				num = checked(num * 10 + (ulong)num2);
			}
		}
		return num;
	}

	public char ParseNextChar()
	{
		MoveNextOrFail();
		if (_endIndex - _startIndex != 1)
		{
			ThrowForInvalidData();
		}
		return _buffer[_startIndex];
	}

	internal T ParseRaw<T>(ParseRawFunc<T> selector)
	{
		MoveNextOrFail();
		return selector(_buffer, ref _startIndex, ref _endIndex);
	}

	public string ExtractCurrentToEnd()
	{
		if (_buffer == null || _startIndex == -1)
		{
			throw new InvalidOperationException();
		}
		return _buffer.Substring(_startIndex);
	}

	private static void ThrowForInvalidData()
	{
		throw new InvalidDataException();
	}
}

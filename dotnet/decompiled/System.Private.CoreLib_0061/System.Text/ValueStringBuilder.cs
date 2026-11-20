using System.Buffers;
using System.Runtime.CompilerServices;

namespace System.Text;

internal ref struct ValueStringBuilder
{
	private char[] _arrayToReturnToPool;

	private Span<char> _chars;

	private int _pos;

	public int Length
	{
		get
		{
			return _pos;
		}
		set
		{
			_pos = value;
		}
	}

	public ref char this[int index] => ref _chars[index];

	internal void AppendFormatHelper(IFormatProvider provider, string format, ReadOnlySpan<object> args)
	{
		ArgumentNullException.ThrowIfNull(format, "format");
		ICustomFormatter customFormatter = (ICustomFormatter)(provider?.GetFormat(typeof(ICustomFormatter)));
		int num = 0;
		ReadOnlySpan<char> readOnlySpan;
		while (true)
		{
			if ((uint)num >= (uint)format.Length)
			{
				return;
			}
			readOnlySpan = format.AsSpan(num);
			int num2 = readOnlySpan.IndexOfAny('{', '}');
			if (num2 < 0)
			{
				break;
			}
			Append(readOnlySpan.Slice(0, num2));
			num += num2;
			char c = format[num];
			char c2 = MoveNext(format, ref num);
			if (c == c2)
			{
				Append(c2);
				num++;
				continue;
			}
			if (c != '{')
			{
				ThrowHelper.ThrowFormatInvalidString(num, ExceptionResource.Format_UnexpectedClosingBrace);
			}
			int num3 = 0;
			bool flag = false;
			ReadOnlySpan<char> readOnlySpan2 = default(ReadOnlySpan<char>);
			int num4 = c2 - 48;
			if ((uint)num4 >= 10u)
			{
				ThrowHelper.ThrowFormatInvalidString(num, ExceptionResource.Format_ExpectedAsciiDigit);
			}
			c2 = MoveNext(format, ref num);
			if (c2 != '}')
			{
				while (char.IsAsciiDigit(c2) && num4 < 1000000)
				{
					num4 = num4 * 10 + c2 - 48;
					c2 = MoveNext(format, ref num);
				}
				while (c2 == ' ')
				{
					c2 = MoveNext(format, ref num);
				}
				if (c2 == ',')
				{
					while (true)
					{
						c2 = MoveNext(format, ref num);
						switch (c2)
						{
						case ' ':
							continue;
						case '-':
							flag = true;
							c2 = MoveNext(format, ref num);
							break;
						}
						break;
					}
					num3 = c2 - 48;
					if ((uint)num3 >= 10u)
					{
						ThrowHelper.ThrowFormatInvalidString(num, ExceptionResource.Format_ExpectedAsciiDigit);
					}
					c2 = MoveNext(format, ref num);
					while (char.IsAsciiDigit(c2) && num3 < 1000000)
					{
						num3 = num3 * 10 + c2 - 48;
						c2 = MoveNext(format, ref num);
					}
					while (c2 == ' ')
					{
						c2 = MoveNext(format, ref num);
					}
				}
				if (c2 != '}')
				{
					if (c2 != ':')
					{
						ThrowHelper.ThrowFormatInvalidString(num, ExceptionResource.Format_UnclosedFormatItem);
					}
					int num5 = num;
					while (true)
					{
						switch (MoveNext(format, ref num))
						{
						default:
							continue;
						case '{':
							goto IL_01a4;
						case '}':
							break;
						}
						break;
						IL_01a4:
						ThrowHelper.ThrowFormatInvalidString(num, ExceptionResource.Format_UnclosedFormatItem);
					}
					num5++;
					readOnlySpan2 = format.AsSpan(num5, num - num5);
				}
			}
			num++;
			string text = null;
			string text2 = null;
			if ((uint)num4 >= (uint)args.Length)
			{
				ThrowHelper.ThrowFormatIndexOutOfRange();
			}
			object obj = args[num4];
			if (customFormatter != null)
			{
				if (!readOnlySpan2.IsEmpty)
				{
					text2 = new string(readOnlySpan2);
				}
				text = customFormatter.Format(text2, obj, provider);
			}
			if (text == null)
			{
				if ((flag || num3 == 0) && obj is ISpanFormattable spanFormattable && spanFormattable.TryFormat(_chars.Slice(_pos), out var charsWritten, readOnlySpan2, provider))
				{
					_pos += charsWritten;
					if (flag && num3 > charsWritten)
					{
						Append(' ', num3 - charsWritten);
					}
					continue;
				}
				if (obj is IFormattable formattable)
				{
					if (readOnlySpan2.Length != 0 && text2 == null)
					{
						text2 = new string(readOnlySpan2);
					}
					text = formattable.ToString(text2, provider);
				}
				else
				{
					text = obj?.ToString();
				}
				if (text == null)
				{
					text = string.Empty;
				}
			}
			if (num3 <= text.Length)
			{
				Append(text);
			}
			else if (flag)
			{
				Append(text);
				Append(' ', num3 - text.Length);
			}
			else
			{
				Append(' ', num3 - text.Length);
				Append(text);
			}
		}
		Append(readOnlySpan);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static char MoveNext(string text3, ref int pos)
		{
			pos++;
			if ((uint)pos >= (uint)text3.Length)
			{
				ThrowHelper.ThrowFormatInvalidString(pos, ExceptionResource.Format_UnclosedFormatItem);
			}
			return text3[pos];
		}
	}

	public ValueStringBuilder(Span<char> initialBuffer)
	{
		_arrayToReturnToPool = null;
		_chars = initialBuffer;
		_pos = 0;
	}

	public ValueStringBuilder(int initialCapacity)
	{
		_arrayToReturnToPool = ArrayPool<char>.Shared.Rent(initialCapacity);
		_chars = _arrayToReturnToPool;
		_pos = 0;
	}

	public void EnsureCapacity(int capacity)
	{
		if ((uint)capacity > (uint)_chars.Length)
		{
			Grow(capacity - _pos);
		}
	}

	public override string ToString()
	{
		string result = _chars.Slice(0, _pos).ToString();
		Dispose();
		return result;
	}

	public ReadOnlySpan<char> AsSpan()
	{
		return _chars.Slice(0, _pos);
	}

	public ReadOnlySpan<char> AsSpan(int start, int length)
	{
		return _chars.Slice(start, length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Append(char c)
	{
		int pos = _pos;
		Span<char> chars = _chars;
		if ((uint)pos < (uint)chars.Length)
		{
			chars[pos] = c;
			_pos = pos + 1;
		}
		else
		{
			GrowAndAppend(c);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Append(string s)
	{
		if (s != null)
		{
			int pos = _pos;
			if (s.Length == 1 && (uint)pos < (uint)_chars.Length)
			{
				_chars[pos] = s[0];
				_pos = pos + 1;
			}
			else
			{
				AppendSlow(s);
			}
		}
	}

	private void AppendSlow(string s)
	{
		int pos = _pos;
		if (pos > _chars.Length - s.Length)
		{
			Grow(s.Length);
		}
		s.CopyTo(_chars.Slice(pos));
		_pos += s.Length;
	}

	public void Append(char c, int count)
	{
		if (_pos > _chars.Length - count)
		{
			Grow(count);
		}
		Span<char> span = _chars.Slice(_pos, count);
		for (int i = 0; i < span.Length; i++)
		{
			span[i] = c;
		}
		_pos += count;
	}

	public void Append(scoped ReadOnlySpan<char> value)
	{
		if (_pos > _chars.Length - value.Length)
		{
			Grow(value.Length);
		}
		value.CopyTo(_chars.Slice(_pos));
		_pos += value.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Span<char> AppendSpan(int length)
	{
		int pos = _pos;
		if (pos > _chars.Length - length)
		{
			Grow(length);
		}
		_pos = pos + length;
		return _chars.Slice(pos, length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GrowAndAppend(char c)
	{
		Grow(1);
		Append(c);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Grow(int additionalCapacityBeyondPos)
	{
		int minimumLength = (int)Math.Max((uint)(_pos + additionalCapacityBeyondPos), Math.Min((uint)(_chars.Length * 2), 2147483591u));
		char[] array = ArrayPool<char>.Shared.Rent(minimumLength);
		_chars.Slice(0, _pos).CopyTo(array);
		char[] arrayToReturnToPool = _arrayToReturnToPool;
		_chars = (_arrayToReturnToPool = array);
		if (arrayToReturnToPool != null)
		{
			ArrayPool<char>.Shared.Return(arrayToReturnToPool);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Dispose()
	{
		char[] arrayToReturnToPool = _arrayToReturnToPool;
		this = default(ValueStringBuilder);
		if (arrayToReturnToPool != null)
		{
			ArrayPool<char>.Shared.Return(arrayToReturnToPool);
		}
	}

	internal void AppendSpanFormattable<T>(T value, string format = null, IFormatProvider provider = null) where T : ISpanFormattable
	{
		if (value.TryFormat(_chars.Slice(_pos), out var charsWritten, format.AsSpan(), provider))
		{
			_pos += charsWritten;
		}
		else
		{
			Append(value.ToString(format, provider));
		}
	}
}

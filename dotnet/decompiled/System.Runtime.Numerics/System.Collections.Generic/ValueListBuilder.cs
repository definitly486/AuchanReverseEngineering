using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

[DefaultMember("Item")]
internal ref struct ValueListBuilder<T>
{
	private Span<T> _span;

	private T[] _arrayFromPool;

	private int _pos;

	public int Length => _pos;

	public ValueListBuilder(Span<T?> scratchBuffer)
	{
		_arrayFromPool = null;
		_pos = 0;
		_span = scratchBuffer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Append(T item)
	{
		int pos = _pos;
		Span<T> span = _span;
		if ((uint)pos < (uint)span.Length)
		{
			span[pos] = item;
			_pos = pos + 1;
		}
		else
		{
			AddWithResize(item);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Append(scoped ReadOnlySpan<T> source)
	{
		int pos = _pos;
		Span<T> span = _span;
		if (source.Length == 1 && (uint)pos < (uint)span.Length)
		{
			span[pos] = source[0];
			_pos = pos + 1;
		}
		else
		{
			AppendMultiChar(source);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AppendMultiChar(scoped ReadOnlySpan<T> source)
	{
		if ((uint)(_pos + source.Length) > (uint)_span.Length)
		{
			Grow(_span.Length - _pos + source.Length);
		}
		source.CopyTo(_span.Slice(_pos));
		_pos += source.Length;
	}

	public void Insert(int index, scoped ReadOnlySpan<T> source)
	{
		if ((uint)(_pos + source.Length) > (uint)_span.Length)
		{
			Grow(source.Length);
		}
		_span.Slice(0, _pos).CopyTo(_span.Slice(source.Length));
		source.CopyTo(_span);
		_pos += source.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Span<T> AppendSpan(int length)
	{
		int pos = _pos;
		Span<T> span = _span;
		if ((ulong)((long)(uint)pos + (long)(uint)length) <= (ulong)(uint)span.Length)
		{
			_pos = pos + length;
			return span.Slice(pos, length);
		}
		return AppendSpanWithGrow(length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Span<T> AppendSpanWithGrow(int length)
	{
		int pos = _pos;
		Grow(_span.Length - pos + length);
		_pos += length;
		return _span.Slice(pos, length);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddWithResize(T item)
	{
		int pos = _pos;
		Grow();
		_span[pos] = item;
		_pos = pos + 1;
	}

	public ReadOnlySpan<T> AsSpan()
	{
		return _span.Slice(0, _pos);
	}

	public bool TryCopyTo(Span<T> destination, out int itemsWritten)
	{
		if (_span.Slice(0, _pos).TryCopyTo(destination))
		{
			itemsWritten = _pos;
			return true;
		}
		itemsWritten = 0;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Dispose()
	{
		T[] arrayFromPool = _arrayFromPool;
		if (arrayFromPool != null)
		{
			_arrayFromPool = null;
			if (!typeof(T).IsPrimitive)
			{
				Array.Clear(arrayFromPool, 0, _pos);
			}
			ArrayPool<T>.Shared.Return(arrayFromPool);
		}
	}

	private void Grow(int additionalCapacityRequired = 1)
	{
		int num = Math.Max((_span.Length != 0) ? (_span.Length * 2) : 4, _span.Length + additionalCapacityRequired);
		if ((uint)num > 2147483591u)
		{
			num = Math.Max(Math.Max(_span.Length + 1, 2147483591), _span.Length);
		}
		T[] array = ArrayPool<T>.Shared.Rent(num);
		_span.CopyTo(array);
		T[] arrayFromPool = _arrayFromPool;
		_span = (_arrayFromPool = array);
		if (arrayFromPool != null)
		{
			if (!typeof(T).IsPrimitive)
			{
				Array.Clear(arrayFromPool, 0, _pos);
			}
			ArrayPool<T>.Shared.Return(arrayFromPool);
		}
	}
}

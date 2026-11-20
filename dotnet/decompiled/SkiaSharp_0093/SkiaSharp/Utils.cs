using System;
using System.Buffers;
using System.Reflection;

namespace SkiaSharp;

internal static class Utils
{
	[DefaultMember("Item")]
	internal readonly ref struct RentedArray<T>
	{
		public readonly T[] Array;

		public readonly Span<T> Span;

		public int Length => Span.Length;

		internal RentedArray(int length)
		{
			Array = ArrayPool<T>.Shared.Rent(length);
			Span = new Span<T>(Array, 0, length);
		}

		public void Dispose()
		{
			if (Array != null)
			{
				ArrayPool<T>.Shared.Return(Array);
			}
		}

		public static explicit operator T[](RentedArray<T> scope)
		{
			return scope.Array;
		}

		public static implicit operator Span<T>(RentedArray<T> scope)
		{
			return scope.Span;
		}

		public static implicit operator ReadOnlySpan<T>(RentedArray<T> scope)
		{
			return scope.Span;
		}
	}

	internal static int GetPreambleSize(SKData data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		ReadOnlySpan<byte> readOnlySpan = data.AsSpan();
		int length = readOnlySpan.Length;
		if (length >= 2 && readOnlySpan[0] == 254 && readOnlySpan[1] == byte.MaxValue)
		{
			return 2;
		}
		if (length >= 3 && readOnlySpan[0] == 239 && readOnlySpan[1] == 187 && readOnlySpan[2] == 191)
		{
			return 3;
		}
		if (length >= 3 && readOnlySpan[0] == 43 && readOnlySpan[1] == 47 && readOnlySpan[2] == 118)
		{
			return 3;
		}
		if (length >= 4 && readOnlySpan[0] == 0 && readOnlySpan[1] == 0 && readOnlySpan[2] == 254 && readOnlySpan[3] == byte.MaxValue)
		{
			return 4;
		}
		return 0;
	}

	internal unsafe static Span<byte> AsSpan(this nint ptr, int size)
	{
		return new Span<byte>((void*)ptr, size);
	}

	public static RentedArray<T> RentArray<T>(int length, bool nullIfEmpty = false)
	{
		if (!nullIfEmpty || length > 0)
		{
			return new RentedArray<T>(length);
		}
		return default(RentedArray<T>);
	}
}

using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

namespace System.Buffers;

public static class SearchValues
{
	internal interface IRuntimeConst
	{
		static abstract bool Value { get; }
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct TrueConst : IRuntimeConst
	{
		public static bool Value => true;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct FalseConst : IRuntimeConst
	{
		public static bool Value => false;
	}

	public static SearchValues<byte> Create([ParamCollection] scoped ReadOnlySpan<byte> values)
	{
		if (values.IsEmpty)
		{
			return new EmptySearchValues<byte>();
		}
		if (values.Length == 1)
		{
			return new Any1SearchValues<byte, byte>(values);
		}
		if (TryGetSingleRange(values, out var minInclusive, out var maxInclusive))
		{
			return new RangeByteSearchValues(minInclusive, maxInclusive);
		}
		if (values.Length >= 4 && IndexOfAnyAsciiSearcher.CanUseUniqueLowNibbleSearch(values, maxInclusive))
		{
			return new AsciiByteSearchValues<TrueConst>(values);
		}
		if (values.Length <= 5)
		{
			return values.Length switch
			{
				2 => new Any2SearchValues<byte, byte>(values), 
				3 => new Any3SearchValues<byte, byte>(values), 
				4 => new Any4SearchValues<byte, byte>(values), 
				_ => new Any5SearchValues<byte, byte>(values), 
			};
		}
		if (IndexOfAnyAsciiSearcher.IsVectorizationSupported && maxInclusive < 128)
		{
			return new AsciiByteSearchValues<FalseConst>(values);
		}
		return new AnyByteSearchValues(values);
	}

	public static SearchValues<char> Create([ParamCollection] scoped ReadOnlySpan<char> values)
	{
		if (values.IsEmpty)
		{
			return new EmptySearchValues<char>();
		}
		ReadOnlySpan<short> values2 = MemoryMarshal.Cast<char, short>(values);
		if (values.Length == 1)
		{
			char c = values[0];
			if (false)
			{
			}
			return new Any1SearchValues<char, short>(values2);
		}
		if (TryGetSingleRange(values, out var minInclusive, out var maxInclusive))
		{
			if (false)
			{
			}
			return new RangeCharSearchValues<FalseConst>(minInclusive, maxInclusive);
		}
		if (values.Length == 2)
		{
			char c2 = values[0];
			char c3 = values[1];
			if (false)
			{
			}
			return new Any2SearchValues<char, short>(values2);
		}
		if (values.Length == 3)
		{
			char c4 = values[0];
			char c5 = values[1];
			char c6 = values[2];
			if (false)
			{
			}
			return new Any3SearchValues<char, short>(values2);
		}
		if (!IndexOfAnyAsciiSearcher.IsVectorizationSupported)
		{
		}
		if (IndexOfAnyAsciiSearcher.CanUseUniqueLowNibbleSearch(values, maxInclusive))
		{
			_ = 0;
			if (false)
			{
			}
			return new AsciiCharSearchValues<IndexOfAnyAsciiSearcher.Default, TrueConst>(values);
		}
		if (IndexOfAnyAsciiSearcher.IsVectorizationSupported && maxInclusive < '\u0080')
		{
			_ = 0;
			if (false)
			{
			}
			return new AsciiCharSearchValues<IndexOfAnyAsciiSearcher.Default, FalseConst>(values);
		}
		if (values.Length == 4)
		{
			return new Any4SearchValues<char, short>(values2);
		}
		if (values.Length == 5)
		{
			return new Any5SearchValues<char, short>(values2);
		}
		if (IndexOfAnyAsciiSearcher.IsVectorizationSupported && minInclusive < '\u0080')
		{
			_ = 0;
			if (false)
			{
			}
			return new ProbabilisticWithAsciiCharSearchValues<IndexOfAnyAsciiSearcher.Default>(values, maxInclusive);
		}
		if (ShouldUseProbabilisticMap(values.Length, maxInclusive))
		{
			return new ProbabilisticCharSearchValues(values, maxInclusive);
		}
		return new BitmapCharSearchValues(values, maxInclusive);
		static bool ShouldUseProbabilisticMap(int valuesLength, int num2)
		{
			if (valuesLength > 256)
			{
				return false;
			}
			_ = 0;
			if (AdvSimd.Arm64.IsSupported)
			{
				return true;
			}
			int num = 64 + num2 / 8;
			int num3 = 128 + valuesLength * 4;
			return 2 * num3 < num;
		}
	}

	public static SearchValues<string> Create(ReadOnlySpan<string> values, StringComparison comparisonType)
	{
		if ((uint)(comparisonType - 4) > 1u)
		{
			throw new ArgumentException("Argument_SearchValues_UnsupportedStringComparison", "comparisonType");
		}
		return StringSearchValues.Create(values, comparisonType == StringComparison.OrdinalIgnoreCase);
	}

	private static bool TryGetSingleRange<T>(ReadOnlySpan<T> values, out T minInclusive, out T maxInclusive) where T : struct, INumber<T>, IMinMaxValue<T>
	{
		T val = T.MaxValue;
		T val2 = T.MinValue;
		ReadOnlySpan<T> readOnlySpan = values;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			T y = readOnlySpan[i];
			val = T.Min(val, y);
			val2 = T.Max(val2, y);
		}
		minInclusive = val;
		maxInclusive = val2;
		uint num = uint.CreateChecked(val2 - val) + 1;
		if (num > values.Length)
		{
			return false;
		}
		Span<bool> span = ((num > 256) ? ((Span<bool>)new bool[num]) : stackalloc bool[256]);
		Span<bool> span2 = span;
		span2 = span2.Slice(0, (int)num);
		span2.Clear();
		ReadOnlySpan<T> readOnlySpan2 = values;
		for (int i = 0; i < readOnlySpan2.Length; i++)
		{
			int index = int.CreateChecked(readOnlySpan2[i] - val);
			span2[index] = true;
		}
		if (((ReadOnlySpan<bool>)span2).Contains(value: false))
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static Vector128<byte> ShuffleNativeModified(Vector128<byte> vector, Vector128<byte> indices)
	{
		if (false)
		{
		}
		return Vector128.Shuffle(vector, indices);
	}
}
[DebuggerDisplay("{DebuggerDisplay,nq}")]
[DebuggerTypeProxy(typeof(SearchValuesDebugView<>))]
public class SearchValues<T> where T : IEquatable<T>?
{
	private string DebuggerDisplay
	{
		get
		{
			T[] source = GetValues();
			string text = $"{GetType().Name}, Count = {source.Length}";
			if (source.Length != 0)
			{
				text += ", Values = ";
				text += ((typeof(T) == typeof(char)) ? ("\"" + new string(Unsafe.As<T[], char[]>(ref source)) + "\"") : string.Join(",", source));
			}
			return text;
		}
	}

	private protected SearchValues()
	{
	}

	internal virtual T[] GetValues()
	{
		throw new UnreachableException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Contains(T value)
	{
		return ContainsCore(value);
	}

	internal virtual bool ContainsCore(T value)
	{
		throw new UnreachableException();
	}

	internal virtual int IndexOfAny(ReadOnlySpan<T> span)
	{
		throw new UnreachableException();
	}

	internal virtual int IndexOfAnyExcept(ReadOnlySpan<T> span)
	{
		throw new UnreachableException();
	}

	internal virtual int LastIndexOfAny(ReadOnlySpan<T> span)
	{
		throw new UnreachableException();
	}

	internal virtual int LastIndexOfAnyExcept(ReadOnlySpan<T> span)
	{
		throw new UnreachableException();
	}

	internal virtual bool ContainsAny(ReadOnlySpan<T> span)
	{
		return IndexOfAny(span) >= 0;
	}

	internal virtual bool ContainsAnyExcept(ReadOnlySpan<T> span)
	{
		return IndexOfAnyExcept(span) >= 0;
	}

	internal virtual int IndexOfAnyMultiString(ReadOnlySpan<char> span)
	{
		throw new UnreachableException();
	}
}

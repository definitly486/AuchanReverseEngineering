using System.Collections.Generic;

namespace System.Buffers;

internal sealed class AsciiStringSearchValuesTeddyBucketizedN2<TStartCaseSensitivity, TCaseSensitivity> : AsciiStringSearchValuesTeddyBase<SearchValues.TrueConst, TStartCaseSensitivity, TCaseSensitivity> where TStartCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
{
	public AsciiStringSearchValuesTeddyBucketizedN2(string[][] buckets, ReadOnlySpan<string> values, HashSet<string> uniqueValues)
		: base(buckets, values, uniqueValues, 2)
	{
	}

	internal override int IndexOfAnyMultiString(ReadOnlySpan<char> span)
	{
		return IndexOfAnyN2(span);
	}
}

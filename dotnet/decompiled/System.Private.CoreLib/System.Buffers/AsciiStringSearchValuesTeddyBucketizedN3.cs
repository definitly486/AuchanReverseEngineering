using System.Collections.Generic;

namespace System.Buffers;

internal sealed class AsciiStringSearchValuesTeddyBucketizedN3<TStartCaseSensitivity, TCaseSensitivity> : AsciiStringSearchValuesTeddyBase<SearchValues.TrueConst, TStartCaseSensitivity, TCaseSensitivity> where TStartCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
{
	public AsciiStringSearchValuesTeddyBucketizedN3(string[][] buckets, ReadOnlySpan<string> values, HashSet<string> uniqueValues)
		: base(buckets, values, uniqueValues, 3)
	{
	}

	internal override int IndexOfAnyMultiString(ReadOnlySpan<char> span)
	{
		return IndexOfAnyN3(span);
	}
}

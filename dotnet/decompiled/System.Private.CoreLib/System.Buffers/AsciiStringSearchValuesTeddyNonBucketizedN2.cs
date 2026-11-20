using System.Collections.Generic;

namespace System.Buffers;

internal sealed class AsciiStringSearchValuesTeddyNonBucketizedN2<TStartCaseSensitivity, TCaseSensitivity> : AsciiStringSearchValuesTeddyBase<SearchValues.FalseConst, TStartCaseSensitivity, TCaseSensitivity> where TStartCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
{
	public AsciiStringSearchValuesTeddyNonBucketizedN2(ReadOnlySpan<string> values, HashSet<string> uniqueValues)
		: base(values, uniqueValues, 2)
	{
	}

	internal override int IndexOfAnyMultiString(ReadOnlySpan<char> span)
	{
		return IndexOfAnyN2(span);
	}
}

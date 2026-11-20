using System.Collections.Generic;

namespace System.Buffers;

internal sealed class AsciiStringSearchValuesTeddyNonBucketizedN3<TStartCaseSensitivity, TCaseSensitivity> : AsciiStringSearchValuesTeddyBase<SearchValues.FalseConst, TStartCaseSensitivity, TCaseSensitivity> where TStartCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
{
	public AsciiStringSearchValuesTeddyNonBucketizedN3(ReadOnlySpan<string> values, HashSet<string> uniqueValues)
		: base(values, uniqueValues, 3)
	{
	}

	internal override int IndexOfAnyMultiString(ReadOnlySpan<char> span)
	{
		return IndexOfAnyN3(span);
	}
}

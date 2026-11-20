using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Intrinsics;
using System.Text;

namespace System.Buffers;

internal static class StringSearchValues
{
	private static readonly SearchValues<char> s_asciiLetters = SearchValues.Create("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".AsSpan());

	private static readonly SearchValues<char> s_allAsciiExceptLowercase = SearchValues.Create("\0\u0001\u0002\u0003\u0004\u0005\u0006\a\b\t\n\v\f\r\u000e\u000f\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001a\u001b\u001c\u001d\u001e\u001f !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`{|}~\u007f".AsSpan());

	public static SearchValues<string> Create(ReadOnlySpan<string> values, bool ignoreCase)
	{
		if (values.Length == 0)
		{
			return new EmptySearchValues<string>();
		}
		if (values.Length == 1)
		{
			string obj = values[0];
			ArgumentNullException.ThrowIfNull(obj, "values");
			string reference = NormalizeIfNeeded(obj, ignoreCase);
			AnalyzeValues(new ReadOnlySpan<string>(in reference), ref ignoreCase, out var allAscii, out var asciiLettersOnly, out var _, out var _);
			return CreateForSingleValue(reference, null, ignoreCase, allAscii, asciiLettersOnly);
		}
		HashSet<string> hashSet = new HashSet<string>(values.Length, ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		ReadOnlySpan<string> readOnlySpan = values;
		for (int minLength = 0; minLength < readOnlySpan.Length; minLength++)
		{
			string text = readOnlySpan[minLength];
			ArgumentNullException.ThrowIfNull(text, "values");
			hashSet.Add(text);
		}
		if (hashSet.Contains(string.Empty))
		{
			return new SingleStringSearchValuesFallback<SearchValues.FalseConst>(string.Empty, hashSet);
		}
		Span<string> span = new string[hashSet.Count];
		int num = 0;
		foreach (string item in hashSet)
		{
			span[num++] = NormalizeIfNeeded(item, ignoreCase);
		}
		span.Sort((string a, string b) => a.Length.CompareTo(b.Length));
		HashSet<string> unreachableValues = null;
		AhoCorasickBuilder ahoCorasickBuilder = new AhoCorasickBuilder(span, ignoreCase, ref unreachableValues);
		if (unreachableValues != null)
		{
			span = RemoveUnreachableValues(span, unreachableValues);
		}
		SearchValues<string> result = CreateFromNormalizedValues(span, hashSet, ignoreCase, ref ahoCorasickBuilder);
		ahoCorasickBuilder.Dispose();
		return result;
		static string NormalizeIfNeeded(string value, bool flag)
		{
			if (flag && value.AsSpan().ContainsAnyExcept(s_allAsciiExceptLowercase))
			{
				string text2 = string.FastAllocateString(value.Length);
				Ordinal.ToUpperOrdinal(value.AsSpan(), new Span<char>(ref text2.GetRawStringData(), text2.Length));
				value = text2;
			}
			return value;
		}
		static Span<string> RemoveUnreachableValues(Span<string> span3, HashSet<string> hashSet2)
		{
			int length = 0;
			Span<string> span2 = span3;
			for (int i = 0; i < span2.Length; i++)
			{
				string text2 = span2[i];
				if (!hashSet2.Contains(text2))
				{
					span3[length++] = text2;
				}
			}
			return span3.Slice(0, length);
		}
	}

	private static SearchValues<string> CreateFromNormalizedValues(ReadOnlySpan<string> values, HashSet<string> uniqueValues, bool ignoreCase, ref AhoCorasickBuilder ahoCorasickBuilder)
	{
		AnalyzeValues(values, ref ignoreCase, out var allAscii, out var asciiLettersOnly, out var nonAsciiAffectedByCaseConversion, out var _);
		if (values.Length == 1)
		{
			return CreateForSingleValue(values[0], uniqueValues, ignoreCase, allAscii, asciiLettersOnly);
		}
		_ = 0;
		if (false)
		{
		}
		AhoCorasick ahoCorasick = ahoCorasickBuilder.Build();
		if (!ignoreCase)
		{
			return PickAhoCorasickImplementation<StringSearchValuesHelper.CaseSensitive>(ahoCorasick, uniqueValues);
		}
		if (nonAsciiAffectedByCaseConversion)
		{
			if (ContainsIncompleteSurrogatePairs(values))
			{
				return new MultiStringIgnoreCaseSearchValuesFallback(uniqueValues);
			}
			return PickAhoCorasickImplementation<StringSearchValuesHelper.CaseInsensitiveUnicode>(ahoCorasick, uniqueValues);
		}
		if (asciiLettersOnly)
		{
			return PickAhoCorasickImplementation<StringSearchValuesHelper.CaseInsensitiveAsciiLetters>(ahoCorasick, uniqueValues);
		}
		return PickAhoCorasickImplementation<StringSearchValuesHelper.CaseInsensitiveAscii>(ahoCorasick, uniqueValues);
		static SearchValues<string> PickAhoCorasickImplementation<TCaseSensitivity>(AhoCorasick ahoCorasick2, HashSet<string> uniqueValues2) where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
		{
			_ = ahoCorasick2.ShouldUseAsciiFastScan;
			return new StringSearchValuesAhoCorasick<TCaseSensitivity, AhoCorasick.NoFastScan>(ahoCorasick2, uniqueValues2);
		}
	}

	private static SearchValues<string> CreateForSingleValue(string value, HashSet<string> uniqueValues, bool ignoreCase, bool allAscii, bool asciiLettersOnly)
	{
		if (4 != 4)
		{
		}
		int num = 1000000000;
		if (Vector128.IsHardwareAccelerated && value.Length > 1 && value.Length <= num)
		{
			int length = value.Length;
			SearchValues<string> searchValues = ((length <= 8) ? ((length >= 4) ? TryCreateSingleValuesThreeChars<StringSearchValuesHelper.ValueLength4To8>(value, uniqueValues, ignoreCase, allAscii, asciiLettersOnly) : TryCreateSingleValuesThreeChars<StringSearchValuesHelper.ValueLengthLessThan4>(value, uniqueValues, ignoreCase, allAscii, asciiLettersOnly)) : ((length > 16) ? TryCreateSingleValuesThreeChars<StringSearchValuesHelper.ValueLengthLongOrUnknown>(value, uniqueValues, ignoreCase, allAscii, asciiLettersOnly) : TryCreateSingleValuesThreeChars<StringSearchValuesHelper.ValueLength9To16>(value, uniqueValues, ignoreCase, allAscii, asciiLettersOnly)));
			SearchValues<string> searchValues2 = searchValues;
			if (searchValues2 != null)
			{
				return searchValues2;
			}
		}
		if (uniqueValues == null)
		{
			uniqueValues = new HashSet<string>(1, ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal) { value };
		}
		if (!ignoreCase)
		{
			return new SingleStringSearchValuesFallback<SearchValues.FalseConst>(value, uniqueValues);
		}
		return new SingleStringSearchValuesFallback<SearchValues.TrueConst>(value, uniqueValues);
	}

	private static SearchValues<string> TryCreateSingleValuesThreeChars<TValueLength>(string value, HashSet<string> uniqueValues, bool ignoreCase, bool allAscii, bool asciiLettersOnly) where TValueLength : struct, StringSearchValuesHelper.IValueLength
	{
		if (!ignoreCase)
		{
			return CreateSingleValuesThreeChars<TValueLength, StringSearchValuesHelper.CaseSensitive>(value, uniqueValues);
		}
		if (asciiLettersOnly)
		{
			return CreateSingleValuesThreeChars<TValueLength, StringSearchValuesHelper.CaseInsensitiveAsciiLetters>(value, uniqueValues);
		}
		if (allAscii)
		{
			return CreateSingleValuesThreeChars<TValueLength, StringSearchValuesHelper.CaseInsensitiveAscii>(value, uniqueValues);
		}
		if (char.IsAscii(value[0]) && value.AsSpan(1).ContainsAnyInRange('\0', '\u007f'))
		{
			return CreateSingleValuesThreeChars<TValueLength, StringSearchValuesHelper.CaseInsensitiveUnicode>(value, uniqueValues);
		}
		return null;
	}

	private static SearchValues<string> CreateSingleValuesThreeChars<TValueLength, TCaseSensitivity>(string value, HashSet<string> uniqueValues) where TValueLength : struct, StringSearchValuesHelper.IValueLength where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity
	{
		CharacterFrequencyHelper.GetSingleStringMultiCharacterOffsets(value, typeof(TCaseSensitivity) != typeof(StringSearchValuesHelper.CaseSensitive), out var ch2Offset, out var ch3Offset);
		if (CanUsePackedImpl(value[0]))
		{
		}
		return new SingleStringSearchValuesThreeChars<TValueLength, TCaseSensitivity>(uniqueValues, value, ch2Offset, ch3Offset);
		static bool CanUsePackedImpl(char c)
		{
			_ = 0;
			if (false)
			{
			}
			return false;
		}
	}

	private static void AnalyzeValues(ReadOnlySpan<string> values, ref bool ignoreCase, out bool allAscii, out bool asciiLettersOnly, out bool nonAsciiAffectedByCaseConversion, out int minLength)
	{
		allAscii = true;
		asciiLettersOnly = true;
		minLength = int.MaxValue;
		ReadOnlySpan<string> readOnlySpan = values;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			string text = readOnlySpan[i];
			allAscii = allAscii && Ascii.IsValid(text.AsSpan());
			asciiLettersOnly = asciiLettersOnly && !text.AsSpan().ContainsAnyExcept(s_asciiLetters);
			minLength = Math.Min(minLength, text.Length);
		}
		nonAsciiAffectedByCaseConversion = ignoreCase && !allAscii;
		if (!ignoreCase || nonAsciiAffectedByCaseConversion || asciiLettersOnly)
		{
			return;
		}
		ignoreCase = false;
		ReadOnlySpan<string> readOnlySpan2 = values;
		for (int i = 0; i < readOnlySpan2.Length; i++)
		{
			if (readOnlySpan2[i].AsSpan().ContainsAny(s_asciiLetters))
			{
				ignoreCase = true;
				break;
			}
		}
	}

	private static bool ContainsIncompleteSurrogatePairs(ReadOnlySpan<string> values)
	{
		ReadOnlySpan<string> readOnlySpan = values;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			string text = readOnlySpan[i];
			int j = text.AsSpan().IndexOfAnyInRange('\ud800', '\udfff');
			if (j < 0)
			{
				continue;
			}
			for (; (uint)j < (uint)text.Length; j++)
			{
				if (char.IsHighSurrogate(text[j]))
				{
					if ((uint)(j + 1) >= (uint)text.Length || !char.IsLowSurrogate(text[j + 1]))
					{
						return true;
					}
					j++;
				}
				else if (char.IsLowSurrogate(text[j]))
				{
					return true;
				}
			}
		}
		return false;
	}
}

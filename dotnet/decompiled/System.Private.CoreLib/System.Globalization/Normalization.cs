using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Globalization;

internal static class Normalization
{
	internal static bool IsNormalized(ReadOnlySpan<char> source, NormalizationForm normalizationForm = NormalizationForm.FormC)
	{
		CheckNormalizationForm(normalizationForm);
		_ = GlobalizationMode.Invariant;
		if (Ascii.IsValid(source))
		{
			return true;
		}
		_ = 0;
		return IcuIsNormalized(source, normalizationForm);
	}

	internal static string Normalize(string strInput, NormalizationForm normalizationForm)
	{
		CheckNormalizationForm(normalizationForm);
		_ = GlobalizationMode.Invariant;
		if (Ascii.IsValid(strInput.AsSpan()))
		{
			return strInput;
		}
		_ = 0;
		return IcuNormalize(strInput, normalizationForm);
	}

	internal static bool TryNormalize(ReadOnlySpan<char> source, Span<char> destination, out int charsWritten, NormalizationForm normalizationForm = NormalizationForm.FormC)
	{
		CheckNormalizationForm(normalizationForm);
		if (source.Overlaps(destination))
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.InvalidOperation_SpanOverlappedOperation);
		}
		_ = GlobalizationMode.Invariant;
		if (Ascii.IsValid(source))
		{
			if (source.TryCopyTo(destination))
			{
				charsWritten = source.Length;
				return true;
			}
			charsWritten = 0;
			return false;
		}
		_ = 0;
		return IcuTryNormalize(source, destination, out charsWritten, normalizationForm);
	}

	internal static int GetNormalizedLength(this ReadOnlySpan<char> source, NormalizationForm normalizationForm = NormalizationForm.FormC)
	{
		CheckNormalizationForm(normalizationForm);
		_ = GlobalizationMode.Invariant;
		if (Ascii.IsValid(source))
		{
			return source.Length;
		}
		_ = 0;
		return IcuGetNormalizedLength(source, normalizationForm);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void CheckNormalizationForm(NormalizationForm normalizationForm)
	{
		if (normalizationForm != NormalizationForm.FormC && normalizationForm != NormalizationForm.FormD && normalizationForm != NormalizationForm.FormKC && normalizationForm != NormalizationForm.FormKD)
		{
			throw new ArgumentException("Argument_InvalidNormalizationForm", "normalizationForm");
		}
	}

	private unsafe static bool IcuIsNormalized(ReadOnlySpan<char> source, NormalizationForm normalizationForm)
	{
		ValidateArguments(source, normalizationForm, "source");
		int num;
		fixed (char* src = source)
		{
			num = Interop.Globalization.IsNormalized(normalizationForm, src, source.Length);
		}
		if (num == -1)
		{
			throw new ArgumentException("Argument_InvalidCharSequenceNoIndex", "source");
		}
		return num == 1;
	}

	private unsafe static string IcuNormalize(string strInput, NormalizationForm normalizationForm)
	{
		ValidateArguments(strInput.AsSpan(), normalizationForm);
		char[] array = null;
		try
		{
			Span<char> span = ((strInput.Length > 512) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(strInput.Length))) : stackalloc char[512]);
			Span<char> span2 = span;
			for (int i = 0; i < 2; i++)
			{
				int num;
				fixed (char* src = strInput)
				{
					fixed (char* reference = &MemoryMarshal.GetReference(span2))
					{
						num = Interop.Globalization.NormalizeString(normalizationForm, src, strInput.Length, reference, span2.Length);
					}
				}
				if (num == -1)
				{
					throw new ArgumentException("Argument_InvalidCharSequenceNoIndex", "strInput");
				}
				if (num <= span2.Length)
				{
					ReadOnlySpan<char> readOnlySpan = span2.Slice(0, num);
					return readOnlySpan.SequenceEqual(strInput.AsSpan()) ? strInput : new string(readOnlySpan);
				}
				if (i == 0)
				{
					if (array != null)
					{
						char[] array2 = array;
						array = null;
						ArrayPool<char>.Shared.Return(array2);
					}
					span2 = (array = ArrayPool<char>.Shared.Rent(num));
				}
			}
			throw new ArgumentException("Argument_InvalidCharSequenceNoIndex", "strInput");
		}
		finally
		{
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}
	}

	private unsafe static bool IcuTryNormalize(ReadOnlySpan<char> source, Span<char> destination, out int charsWritten, NormalizationForm normalizationForm = NormalizationForm.FormC)
	{
		if (destination.IsEmpty)
		{
			charsWritten = 0;
			return false;
		}
		ValidateArguments(source, normalizationForm, "source");
		int num;
		fixed (char* src = source)
		{
			fixed (char* dstBuffer = destination)
			{
				num = Interop.Globalization.NormalizeString(normalizationForm, src, source.Length, dstBuffer, destination.Length);
			}
		}
		if (num < 0)
		{
			throw new ArgumentException("Argument_InvalidCharSequenceNoIndex", "source");
		}
		if (num <= destination.Length)
		{
			charsWritten = num;
			return true;
		}
		charsWritten = 0;
		return false;
	}

	private unsafe static int IcuGetNormalizedLength(ReadOnlySpan<char> source, NormalizationForm normalizationForm)
	{
		ValidateArguments(source, normalizationForm, "source");
		int num;
		fixed (char* src = source)
		{
			num = Interop.Globalization.NormalizeString(normalizationForm, src, source.Length, null, 0);
		}
		if (num < 0)
		{
			throw new ArgumentException("Argument_InvalidCharSequenceNoIndex", "source");
		}
		return num;
	}

	private static void ValidateArguments(ReadOnlySpan<char> strInput, NormalizationForm normalizationForm, string paramName = "strInput")
	{
		_ = 0;
		if (false)
		{
		}
		if (HasInvalidUnicodeSequence(strInput))
		{
			throw new ArgumentException("Argument_InvalidCharSequenceNoIndex", paramName);
		}
	}

	private static bool HasInvalidUnicodeSequence(ReadOnlySpan<char> s)
	{
		for (int i = s.IndexOfAnyInRange('\ud800', '\ufffe'); (uint)i < (uint)s.Length; i++)
		{
			char c = s[i];
			if (c < '\ud800')
			{
				continue;
			}
			if (c == '\ufffe')
			{
				return true;
			}
			if (char.IsLowSurrogate(c))
			{
				return true;
			}
			if (char.IsHighSurrogate(c))
			{
				if ((uint)(i + 1) >= (uint)s.Length || !char.IsLowSurrogate(s[i + 1]))
				{
					return true;
				}
				i++;
			}
		}
		return false;
	}
}

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Text.Unicode;

public static class UnicodeRanges
{
	private static UnicodeRange _all;

	private static UnicodeRange _u0000;

	public static UnicodeRange All => _all ?? CreateRange(ref _all, '\0', '\uffff');

	public static UnicodeRange BasicLatin => _u0000 ?? CreateRange(ref _u0000, '\0', '\u007f');

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static UnicodeRange CreateRange([NotNull] ref UnicodeRange range, char first, char last)
	{
		Volatile.Write(ref range, UnicodeRange.Create(first, last));
		return range;
	}
}

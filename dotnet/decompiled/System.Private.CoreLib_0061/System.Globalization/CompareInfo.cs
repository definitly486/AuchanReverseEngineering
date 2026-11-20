using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Unicode;

namespace System.Globalization;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class CompareInfo : IDeserializationCallback
{
	private static class SortHandleCache
	{
		private static readonly Dictionary<string, nint> s_sortNameToSortHandleCache = new Dictionary<string, nint>();

		internal static nint GetCachedSortHandle(string sortName)
		{
			lock (s_sortNameToSortHandleCache)
			{
				if (!s_sortNameToSortHandleCache.TryGetValue(sortName, out var value))
				{
					switch (Interop.Globalization.GetSortHandle(sortName, out value))
					{
					case Interop.Globalization.ResultCode.OutOfMemory:
						throw new OutOfMemoryException();
					default:
						throw new ExternalException("Arg_ExternalException");
					case Interop.Globalization.ResultCode.Success:
						break;
					}
					try
					{
						s_sortNameToSortHandleCache.Add(sortName, value);
					}
					catch
					{
						Interop.Globalization.CloseSortHandle(value);
						throw;
					}
				}
				return value;
			}
		}
	}

	internal static readonly CompareInfo Invariant = CultureInfo.InvariantCulture.CompareInfo;

	[OptionalField(VersionAdded = 2)]
	private string m_name;

	[NonSerialized]
	private nint _sortHandle;

	[NonSerialized]
	private string _sortName;

	[OptionalField(VersionAdded = 3)]
	private SortVersion m_SortVersion;

	private int culture;

	private static readonly SearchValues<char> s_nonSpecialAsciiChars = SearchValues.Create("\t\v\f !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~".AsSpan());

	[NonSerialized]
	private bool _isAsciiEqualityOrdinal;

	public string Name
	{
		get
		{
			if (m_name == "zh-CHT" || m_name == "zh-CHS")
			{
				return m_name;
			}
			return _sortName;
		}
	}

	public SortVersion Version
	{
		get
		{
			if (m_SortVersion == null)
			{
				if (GlobalizationMode.Invariant)
				{
				}
				_ = 0;
				m_SortVersion = IcuGetSortVersion();
			}
			return m_SortVersion;
		}
	}

	public int LCID => CultureInfo.GetCultureInfo(Name).LCID;

	private static ReadOnlySpan<bool> HighCharTable => new bool[128]
	{
		true, true, true, true, true, true, true, true, true, false,
		true, false, false, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, true
	};

	internal CompareInfo(CultureInfo culture)
	{
		m_name = culture._name;
		InitSort(culture);
	}

	public static CompareInfo GetCompareInfo(int culture, Assembly assembly)
	{
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		if (assembly != typeof(object).Module.Assembly)
		{
			throw new ArgumentException("Argument_OnlyMscorlib", "assembly");
		}
		return GetCompareInfo(culture);
	}

	public static CompareInfo GetCompareInfo(string name, Assembly assembly)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		ArgumentNullException.ThrowIfNull(assembly, "assembly");
		if (assembly != typeof(object).Module.Assembly)
		{
			throw new ArgumentException("Argument_OnlyMscorlib", "assembly");
		}
		return GetCompareInfo(name);
	}

	public static CompareInfo GetCompareInfo(int culture)
	{
		if (CultureData.IsCustomCultureId(culture))
		{
			throw new ArgumentException("Argument_CustomCultureCannotBePassedByNumber", "culture");
		}
		return CultureInfo.GetCultureInfo(culture).CompareInfo;
	}

	public static CompareInfo GetCompareInfo(string name)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		return CultureInfo.GetCultureInfo(name).CompareInfo;
	}

	public static bool IsSortable(char ch)
	{
		return IsSortable(new ReadOnlySpan<char>(in ch));
	}

	public static bool IsSortable(string text)
	{
		ArgumentNullException.ThrowIfNull(text, "text");
		return IsSortable(text.AsSpan());
	}

	public static bool IsSortable(ReadOnlySpan<char> text)
	{
		if (text.Length == 0)
		{
			return false;
		}
		if (GlobalizationMode.Invariant)
		{
		}
		_ = 0;
		return IcuIsSortable(text);
	}

	public static bool IsSortable(Rune value)
	{
		Span<char> destination = stackalloc char[2];
		return IsSortable(destination[..value.EncodeToUtf16(destination)]);
	}

	[MemberNotNull("_sortName")]
	private void InitSort(CultureInfo culture)
	{
		_sortName = culture.SortName;
		if (false)
		{
		}
		IcuInitSortHandle(culture.InteropName);
	}

	[OnDeserializing]
	private void OnDeserializing(StreamingContext ctx)
	{
		m_name = null;
	}

	void IDeserializationCallback.OnDeserialization(object sender)
	{
		OnDeserialized();
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext ctx)
	{
		OnDeserialized();
	}

	private void OnDeserialized()
	{
		if (m_name == null)
		{
			m_name = CultureInfo.GetCultureInfo(culture)._name;
		}
		else
		{
			InitSort(CultureInfo.GetCultureInfo(m_name));
		}
	}

	[OnSerializing]
	private void OnSerializing(StreamingContext ctx)
	{
		culture = CultureInfo.GetCultureInfo(Name).LCID;
	}

	public int Compare(string? string1, string? string2)
	{
		return Compare(string1, string2, CompareOptions.None);
	}

	public int Compare(string? string1, string? string2, CompareOptions options)
	{
		int result;
		if (string1 == null)
		{
			result = ((string2 != null) ? (-1) : 0);
		}
		else
		{
			if (string2 != null)
			{
				return Compare(string1.AsSpan(), string2.AsSpan(), options);
			}
			result = 1;
		}
		CheckCompareOptionsForCompare(options);
		return result;
	}

	internal int CompareOptionIgnoreCase(ReadOnlySpan<char> string1, ReadOnlySpan<char> string2)
	{
		_ = GlobalizationMode.Invariant;
		return CompareStringCore(string1, string2, CompareOptions.IgnoreCase);
	}

	public int Compare(string? string1, int offset1, int length1, string? string2, int offset2, int length2)
	{
		return Compare(string1, offset1, length1, string2, offset2, length2, CompareOptions.None);
	}

	public int Compare(string? string1, int offset1, string? string2, int offset2, CompareOptions options)
	{
		return Compare(string1, offset1, (string1 != null) ? (string1.Length - offset1) : 0, string2, offset2, (string2 != null) ? (string2.Length - offset2) : 0, options);
	}

	public int Compare(string? string1, int offset1, string? string2, int offset2)
	{
		return Compare(string1, offset1, string2, offset2, CompareOptions.None);
	}

	public int Compare(string? string1, int offset1, int length1, string? string2, int offset2, int length2, CompareOptions options)
	{
		ReadOnlySpan<char> slice = default(ReadOnlySpan<char>);
		ReadOnlySpan<char> slice2 = default(ReadOnlySpan<char>);
		if (string1 == null)
		{
			if (offset1 == 0 && length1 == 0)
			{
				goto IL_0027;
			}
		}
		else if (string1.TryGetSpan(offset1, length1, out slice))
		{
			goto IL_0027;
		}
		goto IL_006e;
		IL_0044:
		int result;
		if (string1 == null)
		{
			result = ((string2 != null) ? (-1) : 0);
		}
		else
		{
			if (string2 != null)
			{
				return Compare(slice, slice2, options);
			}
			result = 1;
		}
		CheckCompareOptionsForCompare(options);
		return result;
		IL_0027:
		if (string2 == null)
		{
			if (offset2 == 0 && length2 == 0)
			{
				goto IL_0044;
			}
		}
		else if (string2.TryGetSpan(offset2, length2, out slice2))
		{
			goto IL_0044;
		}
		goto IL_006e;
		IL_006e:
		ArgumentOutOfRangeException.ThrowIfNegative(length1, "length1");
		ArgumentOutOfRangeException.ThrowIfNegative(length2, "length2");
		ArgumentOutOfRangeException.ThrowIfNegative(offset1, "offset1");
		ArgumentOutOfRangeException.ThrowIfNegative(offset2, "offset2");
		if (offset1 > (string1?.Length ?? 0) - length1)
		{
			throw new ArgumentOutOfRangeException("string1", "ArgumentOutOfRange_OffsetLength");
		}
		throw new ArgumentOutOfRangeException("string2", "ArgumentOutOfRange_OffsetLength");
	}

	public int Compare(ReadOnlySpan<char> string1, ReadOnlySpan<char> string2, CompareOptions options = CompareOptions.None)
	{
		if (string1 == string2)
		{
			CheckCompareOptionsForCompare(options);
			return 0;
		}
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.NumericOrdering | CompareOptions.StringSort)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			return CompareStringCore(string1, string2, options);
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			return string1.SequenceCompareTo(string2);
		case CompareOptions.OrdinalIgnoreCase:
			return Ordinal.CompareStringIgnoreCase(ref MemoryMarshal.GetReference(string1), string1.Length, ref MemoryMarshal.GetReference(string2), string2.Length);
		default:
			ThrowCompareOptionsCheckFailed(options);
			return -1;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[StackTraceHidden]
	private static void CheckCompareOptionsForCompare(CompareOptions options)
	{
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.NumericOrdering | CompareOptions.StringSort)) != CompareOptions.None && options != CompareOptions.Ordinal && options != CompareOptions.OrdinalIgnoreCase)
		{
			ThrowCompareOptionsCheckFailed(options);
		}
	}

	[DoesNotReturn]
	[StackTraceHidden]
	private static void ThrowCompareOptionsCheckFailed(CompareOptions options)
	{
		throw new ArgumentException(((options & CompareOptions.Ordinal) != CompareOptions.None) ? "Argument_CompareOptionOrdinal" : "Argument_InvalidFlag", "options");
	}

	private int CompareStringCore(ReadOnlySpan<char> string1, ReadOnlySpan<char> string2, CompareOptions options)
	{
		_ = 0;
		return IcuCompareString(string1, string2, options);
	}

	public bool IsPrefix(string source, string prefix, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (prefix == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.prefix);
		}
		return IsPrefix(source.AsSpan(), prefix.AsSpan(), options);
	}

	public unsafe bool IsPrefix(ReadOnlySpan<char> source, ReadOnlySpan<char> prefix, CompareOptions options = CompareOptions.None)
	{
		if (prefix.IsEmpty)
		{
			return true;
		}
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			return StartsWithCore(source, prefix, options, null);
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			return source.StartsWith(prefix);
		case CompareOptions.OrdinalIgnoreCase:
			return source.StartsWithOrdinalIgnoreCase(prefix);
		default:
			ThrowCompareOptionsCheckFailed(options);
			return false;
		}
	}

	public unsafe bool IsPrefix(ReadOnlySpan<char> source, ReadOnlySpan<char> prefix, CompareOptions options, out int matchLength)
	{
		_ = GlobalizationMode.Invariant;
		bool flag;
		if (prefix.IsEmpty || (options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) != CompareOptions.None)
		{
			flag = IsPrefix(source, prefix, options);
			matchLength = (flag ? prefix.Length : 0);
		}
		else
		{
			int num = 0;
			flag = StartsWithCore(source, prefix, options, &num);
			matchLength = num;
		}
		return flag;
	}

	private unsafe bool StartsWithCore(ReadOnlySpan<char> source, ReadOnlySpan<char> prefix, CompareOptions options, int* matchLengthPtr)
	{
		_ = 0;
		return IcuStartsWith(source, prefix, options, matchLengthPtr);
	}

	public bool IsPrefix(string source, string prefix)
	{
		return IsPrefix(source, prefix, CompareOptions.None);
	}

	public bool IsSuffix(string source, string suffix, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (suffix == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.suffix);
		}
		return IsSuffix(source.AsSpan(), suffix.AsSpan(), options);
	}

	public unsafe bool IsSuffix(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options = CompareOptions.None)
	{
		if (suffix.IsEmpty)
		{
			return true;
		}
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			return EndsWithCore(source, suffix, options, null);
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			return source.EndsWith(suffix);
		case CompareOptions.OrdinalIgnoreCase:
			return source.EndsWithOrdinalIgnoreCase(suffix);
		default:
			ThrowCompareOptionsCheckFailed(options);
			return false;
		}
	}

	public unsafe bool IsSuffix(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options, out int matchLength)
	{
		_ = GlobalizationMode.Invariant;
		bool flag;
		if (suffix.IsEmpty || (options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) != CompareOptions.None)
		{
			flag = IsSuffix(source, suffix, options);
			matchLength = (flag ? suffix.Length : 0);
		}
		else
		{
			int num = 0;
			flag = EndsWithCore(source, suffix, options, &num);
			matchLength = num;
		}
		return flag;
	}

	public bool IsSuffix(string source, string suffix)
	{
		return IsSuffix(source, suffix, CompareOptions.None);
	}

	private unsafe bool EndsWithCore(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options, int* matchLengthPtr)
	{
		_ = 0;
		return IcuEndsWith(source, suffix, options, matchLengthPtr);
	}

	public int IndexOf(string source, char value)
	{
		return IndexOf(source, value, CompareOptions.None);
	}

	public int IndexOf(string source, string value)
	{
		return IndexOf(source, value, CompareOptions.None);
	}

	public int IndexOf(string source, char value, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return IndexOf(source.AsSpan(), new ReadOnlySpan<char>(in value), options);
	}

	public int IndexOf(string source, string value, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		return IndexOf(source.AsSpan(), value.AsSpan(), options);
	}

	public int IndexOf(string source, char value, int startIndex)
	{
		return IndexOf(source, value, startIndex, CompareOptions.None);
	}

	public int IndexOf(string source, string value, int startIndex)
	{
		return IndexOf(source, value, startIndex, CompareOptions.None);
	}

	public int IndexOf(string source, char value, int startIndex, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return IndexOf(source, value, startIndex, source.Length - startIndex, options);
	}

	public int IndexOf(string source, string value, int startIndex, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return IndexOf(source, value, startIndex, source.Length - startIndex, options);
	}

	public int IndexOf(string source, char value, int startIndex, int count)
	{
		return IndexOf(source, value, startIndex, count, CompareOptions.None);
	}

	public int IndexOf(string source, string value, int startIndex, int count)
	{
		return IndexOf(source, value, startIndex, count, CompareOptions.None);
	}

	public int IndexOf(string source, char value, int startIndex, int count, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (!source.TryGetSpan(startIndex, count, out var slice))
		{
			if ((uint)startIndex > (uint)source.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
			}
			else
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
			}
		}
		int num = IndexOf(slice, new ReadOnlySpan<char>(in value), options);
		if (num >= 0)
		{
			num += startIndex;
		}
		return num;
	}

	public int IndexOf(string source, string value, int startIndex, int count, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		if (!source.TryGetSpan(startIndex, count, out var slice))
		{
			if ((uint)startIndex > (uint)source.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
			}
			else
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
			}
		}
		int num = IndexOf(slice, value.AsSpan(), options);
		if (num >= 0)
		{
			num += startIndex;
		}
		return num;
	}

	public unsafe int IndexOf(ReadOnlySpan<char> source, ReadOnlySpan<char> value, CompareOptions options = CompareOptions.None)
	{
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			if (value.IsEmpty)
			{
				return 0;
			}
			return IndexOfCore(source, value, options, null, fromBeginning: true);
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			return source.IndexOf(value);
		case CompareOptions.OrdinalIgnoreCase:
			return Ordinal.IndexOfOrdinalIgnoreCase(source, value);
		default:
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidFlag, ExceptionArgument.options);
			return -1;
		}
	}

	public unsafe int IndexOf(ReadOnlySpan<char> source, ReadOnlySpan<char> value, CompareOptions options, out int matchLength)
	{
		Unsafe.SkipInit(out int num);
		int result = IndexOf(source, value, &num, options, fromBeginning: true);
		matchLength = num;
		return result;
	}

	public int IndexOf(ReadOnlySpan<char> source, Rune value, CompareOptions options = CompareOptions.None)
	{
		Span<char> destination = stackalloc char[2];
		return IndexOf(source, destination[..value.EncodeToUtf16(destination)], options);
	}

	private unsafe int IndexOf(ReadOnlySpan<char> source, ReadOnlySpan<char> value, int* matchLengthPtr, CompareOptions options, bool fromBeginning)
	{
		*matchLengthPtr = 0;
		int num = 0;
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			if (value.IsEmpty)
			{
				if (!fromBeginning)
				{
					return source.Length;
				}
				return 0;
			}
			return IndexOfCore(source, value, options, matchLengthPtr, fromBeginning);
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			num = (fromBeginning ? source.IndexOf(value) : source.LastIndexOf(value));
			break;
		case CompareOptions.OrdinalIgnoreCase:
			num = (fromBeginning ? Ordinal.IndexOfOrdinalIgnoreCase(source, value) : Ordinal.LastIndexOfOrdinalIgnoreCase(source, value));
			break;
		default:
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidFlag, ExceptionArgument.options);
			break;
		}
		if (num >= 0)
		{
			*matchLengthPtr = value.Length;
		}
		return num;
	}

	private unsafe int IndexOfCore(ReadOnlySpan<char> source, ReadOnlySpan<char> target, CompareOptions options, int* matchLengthPtr, bool fromBeginning)
	{
		_ = 0;
		return IcuIndexOfCore(source, target, options, matchLengthPtr, fromBeginning);
	}

	public int LastIndexOf(string source, char value)
	{
		return LastIndexOf(source, value, CompareOptions.None);
	}

	public int LastIndexOf(string source, string value)
	{
		return LastIndexOf(source, value, CompareOptions.None);
	}

	public int LastIndexOf(string source, char value, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return LastIndexOf(source.AsSpan(), new ReadOnlySpan<char>(in value), options);
	}

	public int LastIndexOf(string source, string value, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		return LastIndexOf(source.AsSpan(), value.AsSpan(), options);
	}

	public int LastIndexOf(string source, char value, int startIndex)
	{
		return LastIndexOf(source, value, startIndex, startIndex + 1, CompareOptions.None);
	}

	public int LastIndexOf(string source, string value, int startIndex)
	{
		return LastIndexOf(source, value, startIndex, startIndex + 1, CompareOptions.None);
	}

	public int LastIndexOf(string source, char value, int startIndex, CompareOptions options)
	{
		return LastIndexOf(source, value, startIndex, startIndex + 1, options);
	}

	public int LastIndexOf(string source, string value, int startIndex, CompareOptions options)
	{
		return LastIndexOf(source, value, startIndex, startIndex + 1, options);
	}

	public int LastIndexOf(string source, char value, int startIndex, int count)
	{
		return LastIndexOf(source, value, startIndex, count, CompareOptions.None);
	}

	public int LastIndexOf(string source, string value, int startIndex, int count)
	{
		return LastIndexOf(source, value, startIndex, count, CompareOptions.None);
	}

	public int LastIndexOf(string source, char value, int startIndex, int count, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		while ((uint)startIndex >= (uint)source.Length)
		{
			if (startIndex == -1 && source.Length == 0)
			{
				count = 0;
				break;
			}
			if (startIndex == source.Length)
			{
				startIndex--;
				if (count > 0)
				{
					count--;
				}
				continue;
			}
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLess);
			break;
		}
		startIndex = startIndex - count + 1;
		if (!source.TryGetSpan(startIndex, count, out var slice))
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		int num = LastIndexOf(slice, new ReadOnlySpan<char>(in value), options);
		if (num >= 0)
		{
			num += startIndex;
		}
		return num;
	}

	public int LastIndexOf(string source, string value, int startIndex, int count, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		while ((uint)startIndex >= (uint)source.Length)
		{
			if (startIndex == -1 && source.Length == 0)
			{
				count = 0;
				break;
			}
			if (startIndex == source.Length)
			{
				startIndex--;
				if (count > 0)
				{
					count--;
				}
				continue;
			}
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLess);
			break;
		}
		startIndex = startIndex - count + 1;
		if (!source.TryGetSpan(startIndex, count, out var slice))
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		int num = LastIndexOf(slice, value.AsSpan(), options);
		if (num >= 0)
		{
			num += startIndex;
		}
		return num;
	}

	public unsafe int LastIndexOf(ReadOnlySpan<char> source, ReadOnlySpan<char> value, CompareOptions options = CompareOptions.None)
	{
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			if (value.IsEmpty)
			{
				return source.Length;
			}
			return IndexOfCore(source, value, options, null, fromBeginning: false);
		}
		return options switch
		{
			CompareOptions.Ordinal => source.LastIndexOf(value), 
			CompareOptions.OrdinalIgnoreCase => Ordinal.LastIndexOfOrdinalIgnoreCase(source, value), 
			_ => throw new ArgumentException("Argument_InvalidFlag", "options"), 
		};
	}

	public unsafe int LastIndexOf(ReadOnlySpan<char> source, ReadOnlySpan<char> value, CompareOptions options, out int matchLength)
	{
		Unsafe.SkipInit(out int num);
		int result = IndexOf(source, value, &num, options, fromBeginning: false);
		matchLength = num;
		return result;
	}

	public int LastIndexOf(ReadOnlySpan<char> source, Rune value, CompareOptions options = CompareOptions.None)
	{
		Span<char> destination = stackalloc char[2];
		return LastIndexOf(source, destination[..value.EncodeToUtf16(destination)], options);
	}

	public SortKey GetSortKey(string source, CompareOptions options)
	{
		if (GlobalizationMode.Invariant)
		{
		}
		return CreateSortKeyCore(source, options);
	}

	public SortKey GetSortKey(string source)
	{
		if (GlobalizationMode.Invariant)
		{
		}
		return CreateSortKeyCore(source, CompareOptions.None);
	}

	private SortKey CreateSortKeyCore(string source, CompareOptions options)
	{
		_ = 0;
		return IcuCreateSortKey(source, options);
	}

	public int GetSortKey(ReadOnlySpan<char> source, Span<byte> destination, CompareOptions options = CompareOptions.None)
	{
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.NumericOrdering | CompareOptions.StringSort)) != CompareOptions.None)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidFlag, ExceptionArgument.options);
		}
		if (GlobalizationMode.Invariant)
		{
		}
		return GetSortKeyCore(source, destination, options);
	}

	private int GetSortKeyCore(ReadOnlySpan<char> source, Span<byte> destination, CompareOptions options)
	{
		_ = 0;
		return IcuGetSortKey(source, destination, options);
	}

	public int GetSortKeyLength(ReadOnlySpan<char> source, CompareOptions options = CompareOptions.None)
	{
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.NumericOrdering | CompareOptions.StringSort)) != CompareOptions.None)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidFlag, ExceptionArgument.options);
		}
		if (GlobalizationMode.Invariant)
		{
		}
		return GetSortKeyLengthCore(source, options);
	}

	private int GetSortKeyLengthCore(ReadOnlySpan<char> source, CompareOptions options)
	{
		_ = 0;
		return IcuGetSortKeyLength(source, options);
	}

	public override bool Equals([NotNullWhen(true)] object? value)
	{
		if (value is CompareInfo compareInfo)
		{
			return Name == compareInfo.Name;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}

	public int GetHashCode(string source, CompareOptions options)
	{
		if (source == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		return GetHashCode(source.AsSpan(), options);
	}

	public int GetHashCode(ReadOnlySpan<char> source, CompareOptions options)
	{
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.NumericOrdering | CompareOptions.StringSort)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			return GetHashCodeOfStringCore(source, options);
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			return string.GetHashCode(source);
		case CompareOptions.OrdinalIgnoreCase:
			return string.GetHashCodeOrdinalIgnoreCase(source);
		default:
			ThrowCompareOptionsCheckFailed(options);
			return -1;
		}
	}

	private int GetHashCodeOfStringCore(ReadOnlySpan<char> source, CompareOptions options)
	{
		_ = 0;
		return IcuGetHashCodeOfString(source, options);
	}

	public override string ToString()
	{
		return "CompareInfo - " + Name;
	}

	private void IcuInitSortHandle(string interopCultureName)
	{
		_isAsciiEqualityOrdinal = GetIsAsciiEqualityOrdinal(interopCultureName);
		_ = GlobalizationMode.Invariant;
		_sortHandle = SortHandleCache.GetCachedSortHandle(interopCultureName);
	}

	private bool GetIsAsciiEqualityOrdinal(string interopCultureName)
	{
		if (GlobalizationMode.Invariant)
		{
		}
		if (_sortName.Length != 0)
		{
			if (_sortName.Length >= 2 && _sortName[0] == 'e' && _sortName[1] == 'n')
			{
				if (_sortName.Length != 2)
				{
					return _sortName[2] == '-';
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private unsafe int IcuCompareString(ReadOnlySpan<char> string1, ReadOnlySpan<char> string2, CompareOptions options)
	{
		fixed (char* reference = &MemoryMarshal.GetReference(string1))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(string2))
			{
				return Interop.Globalization.CompareString(_sortHandle, reference, string1.Length, reference2, string2.Length, options);
			}
		}
	}

	private unsafe int IcuIndexOfCore(ReadOnlySpan<char> source, ReadOnlySpan<char> target, CompareOptions options, int* matchLengthPtr, bool fromBeginning)
	{
		if (_isAsciiEqualityOrdinal && CanUseAsciiOrdinalForOptions(options))
		{
			if ((options & CompareOptions.IgnoreCase) != CompareOptions.None)
			{
				return IndexOfOrdinalIgnoreCaseHelper(source, target, options, matchLengthPtr, fromBeginning);
			}
			return IndexOfOrdinalHelper(source, target, options, matchLengthPtr, fromBeginning);
		}
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(target))
			{
				if (fromBeginning)
				{
					return Interop.Globalization.IndexOf(_sortHandle, reference2, target.Length, reference, source.Length, options, matchLengthPtr);
				}
				return Interop.Globalization.LastIndexOf(_sortHandle, reference2, target.Length, reference, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe int IndexOfOrdinalIgnoreCaseHelper(ReadOnlySpan<char> source, ReadOnlySpan<char> target, CompareOptions options, int* matchLengthPtr, bool fromBeginning)
	{
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(target))
			{
				char* ptr = reference;
				char* ptr2 = reference2;
				if (!target.ContainsAnyExcept(s_nonSpecialAsciiChars))
				{
					if (target.Length > source.Length)
					{
						if (!source.ContainsAnyExcept(s_nonSpecialAsciiChars))
						{
							return -1;
						}
					}
					else
					{
						int num;
						int num2;
						int num3;
						if (fromBeginning)
						{
							num = 0;
							num2 = source.Length - target.Length + 1;
							num3 = 1;
						}
						else
						{
							num = source.Length - target.Length;
							num2 = -1;
							num3 = -1;
						}
						int num4 = num;
						while (true)
						{
							int num6;
							if (num4 != num2)
							{
								int num5 = 0;
								num6 = num4;
								while (true)
								{
									if (num5 < target.Length)
									{
										char c = ptr[num6];
										char c2 = ptr2[num5];
										if (c >= '\u0080' || HighCharTable[c])
										{
											break;
										}
										if (c == c2)
										{
											goto IL_0119;
										}
										if (char.IsAsciiLetterLower(c))
										{
											c = (char)(c - 32);
										}
										if (char.IsAsciiLetterLower(c2))
										{
											c2 = (char)(c2 - 32);
										}
										if (c == c2)
										{
											goto IL_0119;
										}
										goto IL_00f9;
									}
									if (num6 < source.Length && ptr[num6] >= '\u0080')
									{
										break;
									}
									if (matchLengthPtr != null)
									{
										*matchLengthPtr = target.Length;
									}
									return num4;
									IL_0119:
									num5++;
									num6++;
								}
								break;
							}
							if ((fromBeginning ? source.Slice(num2) : source.Slice(0, num)).ContainsAnyExcept(s_nonSpecialAsciiChars))
							{
								break;
							}
							return -1;
							IL_00f9:
							if (num6 < source.Length - 1 && (ptr + num6)[1] >= '\u0080')
							{
								break;
							}
							num4 += num3;
						}
					}
				}
				if (fromBeginning)
				{
					return Interop.Globalization.IndexOf(_sortHandle, ptr2, target.Length, ptr, source.Length, options, matchLengthPtr);
				}
				return Interop.Globalization.LastIndexOf(_sortHandle, ptr2, target.Length, ptr, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe int IndexOfOrdinalHelper(ReadOnlySpan<char> source, ReadOnlySpan<char> target, CompareOptions options, int* matchLengthPtr, bool fromBeginning)
	{
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(target))
			{
				char* ptr = reference;
				char* ptr2 = reference2;
				if (!target.ContainsAnyExcept(s_nonSpecialAsciiChars))
				{
					if (target.Length > source.Length)
					{
						if (!source.ContainsAnyExcept(s_nonSpecialAsciiChars))
						{
							return -1;
						}
					}
					else
					{
						int num;
						int num2;
						int num3;
						if (fromBeginning)
						{
							num = 0;
							num2 = source.Length - target.Length + 1;
							num3 = 1;
						}
						else
						{
							num = source.Length - target.Length;
							num2 = -1;
							num3 = -1;
						}
						int num4 = num;
						while (true)
						{
							int num6;
							if (num4 != num2)
							{
								int num5 = 0;
								num6 = num4;
								while (true)
								{
									if (num5 < target.Length)
									{
										char c = ptr[num6];
										char c2 = ptr2[num5];
										if (c >= '\u0080' || HighCharTable[c])
										{
											break;
										}
										if (c == c2)
										{
											num5++;
											num6++;
											continue;
										}
										goto IL_00cb;
									}
									if (num6 < source.Length && ptr[num6] >= '\u0080')
									{
										break;
									}
									if (matchLengthPtr != null)
									{
										*matchLengthPtr = target.Length;
									}
									return num4;
								}
								break;
							}
							return -1;
							IL_00cb:
							if (num6 < source.Length - 1 && (ptr + num6)[1] >= '\u0080')
							{
								break;
							}
							num4 += num3;
						}
					}
				}
				if (fromBeginning)
				{
					return Interop.Globalization.IndexOf(_sortHandle, ptr2, target.Length, ptr, source.Length, options, matchLengthPtr);
				}
				return Interop.Globalization.LastIndexOf(_sortHandle, ptr2, target.Length, ptr, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe bool IcuStartsWith(ReadOnlySpan<char> source, ReadOnlySpan<char> prefix, CompareOptions options, int* matchLengthPtr)
	{
		if (_isAsciiEqualityOrdinal && CanUseAsciiOrdinalForOptions(options))
		{
			if ((options & CompareOptions.IgnoreCase) != CompareOptions.None)
			{
				return StartsWithOrdinalIgnoreCaseHelper(source, prefix, options, matchLengthPtr);
			}
			return StartsWithOrdinalHelper(source, prefix, options, matchLengthPtr);
		}
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(prefix))
			{
				return Interop.Globalization.StartsWith(_sortHandle, reference2, prefix.Length, reference, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe bool StartsWithOrdinalIgnoreCaseHelper(ReadOnlySpan<char> source, ReadOnlySpan<char> prefix, CompareOptions options, int* matchLengthPtr)
	{
		int num = Math.Min(source.Length, prefix.Length);
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(prefix))
			{
				char* ptr = reference;
				char* ptr2 = reference2;
				while (true)
				{
					if (num != 0)
					{
						int num2 = *ptr;
						int num3 = *ptr2;
						if (num2 >= 128 || num3 >= 128 || HighCharTable[num2] || HighCharTable[num3])
						{
							break;
						}
						if (num2 == num3)
						{
							ptr++;
							ptr2++;
							num--;
							continue;
						}
						if ((uint)(num2 - 97) <= 25u)
						{
							num2 -= 32;
						}
						if ((uint)(num3 - 97) <= 25u)
						{
							num3 -= 32;
						}
						if (num2 == num3)
						{
							ptr++;
							ptr2++;
							num--;
							continue;
						}
						if ((ptr < reference + source.Length - 1 && ptr[1] >= '\u0080') || (ptr2 < reference2 + prefix.Length - 1 && ptr2[1] >= '\u0080'))
						{
							break;
						}
						return false;
					}
					if (source.Length < prefix.Length)
					{
						int num4 = *ptr2;
						if (num4 >= 128 || HighCharTable[num4])
						{
							break;
						}
						return false;
					}
					if (source.Length > prefix.Length)
					{
						int num5 = *ptr;
						if (num5 >= 128 || HighCharTable[num5])
						{
							break;
						}
					}
					if (matchLengthPtr != null)
					{
						*matchLengthPtr = prefix.Length;
					}
					return true;
				}
				return Interop.Globalization.StartsWith(_sortHandle, reference2, prefix.Length, reference, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe bool StartsWithOrdinalHelper(ReadOnlySpan<char> source, ReadOnlySpan<char> prefix, CompareOptions options, int* matchLengthPtr)
	{
		int num = Math.Min(source.Length, prefix.Length);
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(prefix))
			{
				char* ptr = reference;
				char* ptr2 = reference2;
				while (true)
				{
					if (num != 0)
					{
						int num2 = *ptr;
						int num3 = *ptr2;
						if (num2 >= 128 || num3 >= 128 || HighCharTable[num2] || HighCharTable[num3])
						{
							break;
						}
						if (num2 == num3)
						{
							ptr++;
							ptr2++;
							num--;
							continue;
						}
						if ((ptr < reference + source.Length - 1 && ptr[1] >= '\u0080') || (ptr2 < reference2 + prefix.Length - 1 && ptr2[1] >= '\u0080'))
						{
							break;
						}
						return false;
					}
					if (source.Length < prefix.Length)
					{
						int num4 = *ptr2;
						if (num4 >= 128 || HighCharTable[num4])
						{
							break;
						}
						return false;
					}
					if (source.Length > prefix.Length)
					{
						int num5 = *ptr;
						if (num5 >= 128 || HighCharTable[num5])
						{
							break;
						}
					}
					if (matchLengthPtr != null)
					{
						*matchLengthPtr = prefix.Length;
					}
					return true;
				}
				return Interop.Globalization.StartsWith(_sortHandle, reference2, prefix.Length, reference, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe bool IcuEndsWith(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options, int* matchLengthPtr)
	{
		if (_isAsciiEqualityOrdinal && CanUseAsciiOrdinalForOptions(options))
		{
			if ((options & CompareOptions.IgnoreCase) != CompareOptions.None)
			{
				return EndsWithOrdinalIgnoreCaseHelper(source, suffix, options, matchLengthPtr);
			}
			return EndsWithOrdinalHelper(source, suffix, options, matchLengthPtr);
		}
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(suffix))
			{
				return Interop.Globalization.EndsWith(_sortHandle, reference2, suffix.Length, reference, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe bool EndsWithOrdinalIgnoreCaseHelper(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options, int* matchLengthPtr)
	{
		int num = Math.Min(source.Length, suffix.Length);
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(suffix))
			{
				char* ptr = reference + source.Length - 1;
				char* ptr2 = reference2 + suffix.Length - 1;
				while (true)
				{
					if (num != 0)
					{
						int num2 = *ptr;
						int num3 = *ptr2;
						if (num2 >= 128 || num3 >= 128 || HighCharTable[num2] || HighCharTable[num3])
						{
							break;
						}
						if (num2 == num3)
						{
							ptr--;
							ptr2--;
							num--;
							continue;
						}
						if ((uint)(num2 - 97) <= 25u)
						{
							num2 -= 32;
						}
						if ((uint)(num3 - 97) <= 25u)
						{
							num3 -= 32;
						}
						if (num2 == num3)
						{
							ptr--;
							ptr2--;
							num--;
							continue;
						}
						if ((ptr > reference && *(ptr - 1) >= '\u0080') || (ptr2 > reference2 && *(ptr2 - 1) >= '\u0080'))
						{
							break;
						}
						return false;
					}
					if (source.Length < suffix.Length)
					{
						int num4 = *ptr2;
						if (num4 >= 128 || HighCharTable[num4])
						{
							break;
						}
						return false;
					}
					if (source.Length > suffix.Length)
					{
						int num5 = *ptr;
						if (num5 >= 128 || HighCharTable[num5])
						{
							break;
						}
					}
					if (matchLengthPtr != null)
					{
						*matchLengthPtr = suffix.Length;
					}
					return true;
				}
				return Interop.Globalization.EndsWith(_sortHandle, reference2, suffix.Length, reference, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe bool EndsWithOrdinalHelper(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options, int* matchLengthPtr)
	{
		int num = Math.Min(source.Length, suffix.Length);
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (char* reference2 = &MemoryMarshal.GetReference(suffix))
			{
				char* ptr = reference + source.Length - 1;
				char* ptr2 = reference2 + suffix.Length - 1;
				while (true)
				{
					if (num != 0)
					{
						int num2 = *ptr;
						int num3 = *ptr2;
						if (num2 >= 128 || num3 >= 128 || HighCharTable[num2] || HighCharTable[num3])
						{
							break;
						}
						if (num2 == num3)
						{
							ptr--;
							ptr2--;
							num--;
							continue;
						}
						if ((ptr > reference && *(ptr - 1) >= '\u0080') || (ptr2 > reference2 && *(ptr2 - 1) >= '\u0080'))
						{
							break;
						}
						return false;
					}
					if (source.Length < suffix.Length)
					{
						int num4 = *ptr2;
						if (num4 >= 128 || HighCharTable[num4])
						{
							break;
						}
						return false;
					}
					if (source.Length > suffix.Length)
					{
						int num5 = *ptr;
						if (num5 >= 128 || HighCharTable[num5])
						{
							break;
						}
					}
					if (matchLengthPtr != null)
					{
						*matchLengthPtr = suffix.Length;
					}
					return true;
				}
				return Interop.Globalization.EndsWith(_sortHandle, reference2, suffix.Length, reference, source.Length, options, matchLengthPtr);
			}
		}
	}

	private unsafe SortKey IcuCreateSortKey(string source, CompareOptions options)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.NumericOrdering | CompareOptions.StringSort)) != CompareOptions.None)
		{
			throw new ArgumentException("Argument_InvalidFlag", "options");
		}
		byte[] array;
		fixed (char* str = source)
		{
			int sortKey = Interop.Globalization.GetSortKey(_sortHandle, str, source.Length, null, 0, options);
			array = new byte[sortKey];
			fixed (byte[] array2 = array)
			{
				if (Interop.Globalization.GetSortKey(sortKey: (byte*)((array != null && array2.Length != 0) ? Unsafe.AsPointer(ref array2[0]) : null), sortHandle: _sortHandle, str: str, strLength: source.Length, sortKeyLength: sortKey, options: options) != sortKey)
				{
					throw new ArgumentException("Arg_ExternalException");
				}
			}
		}
		return new SortKey(this, source, options, array);
	}

	private unsafe int IcuGetSortKey(ReadOnlySpan<char> source, Span<byte> destination, CompareOptions options)
	{
		int sortKey;
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference(destination))
			{
				sortKey = Interop.Globalization.GetSortKey(_sortHandle, reference, source.Length, reference2, destination.Length, options);
			}
		}
		if ((uint)sortKey > (uint)destination.Length)
		{
			if (sortKey <= destination.Length)
			{
				throw new ArgumentException("Arg_ExternalException");
			}
			ThrowHelper.ThrowArgumentException_DestinationTooShort();
		}
		return sortKey;
	}

	private unsafe int IcuGetSortKeyLength(ReadOnlySpan<char> source, CompareOptions options)
	{
		fixed (char* reference = &MemoryMarshal.GetReference(source))
		{
			return Interop.Globalization.GetSortKey(_sortHandle, reference, source.Length, null, 0, options);
		}
	}

	private static bool IcuIsSortable(ReadOnlySpan<char> text)
	{
		do
		{
			if (Rune.DecodeFromUtf16(text, out var result, out var charsConsumed) != OperationStatus.Done)
			{
				return false;
			}
			UnicodeCategory unicodeCategory = Rune.GetUnicodeCategory(result);
			if (unicodeCategory == UnicodeCategory.PrivateUse || unicodeCategory == UnicodeCategory.OtherNotAssigned)
			{
				return false;
			}
			text = text.Slice(charsConsumed);
		}
		while (!text.IsEmpty);
		return true;
	}

	private unsafe int IcuGetHashCodeOfString(ReadOnlySpan<char> source, CompareOptions options)
	{
		int num = ((source.Length <= 262144) ? checked(4 * source.Length) : 0);
		byte[] array = null;
		Span<byte> span = (((uint)num > 1024u) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[1024]);
		Span<byte> span2 = span;
		fixed (char* nonNullPinnableReference = &MemoryMarshal.GetNonNullPinnableReference(source))
		{
			fixed (byte* reference = &MemoryMarshal.GetReference(span2))
			{
				num = Interop.Globalization.GetSortKey(_sortHandle, nonNullPinnableReference, source.Length, reference, span2.Length, options);
			}
			if (num > span2.Length)
			{
				if (array != null)
				{
					ArrayPool<byte>.Shared.Return(array);
				}
				span2 = (array = ArrayPool<byte>.Shared.Rent(num));
				fixed (byte* reference2 = &MemoryMarshal.GetReference(span2))
				{
					num = Interop.Globalization.GetSortKey(_sortHandle, nonNullPinnableReference, source.Length, reference2, span2.Length, options);
				}
			}
		}
		if (num == 0 || num > span2.Length)
		{
			throw new ArgumentException("Arg_ExternalException");
		}
		int result = Marvin.ComputeHash32(span2.Slice(0, num), Marvin.DefaultSeed);
		if (array != null)
		{
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	private static bool CanUseAsciiOrdinalForOptions(CompareOptions options)
	{
		return (options & CompareOptions.IgnoreSymbols) == 0;
	}

	private SortVersion IcuGetSortVersion()
	{
		int sortVersion = Interop.Globalization.GetSortVersion(_sortHandle);
		return new SortVersion(sortVersion, LCID, new Guid(sortVersion, 0, 0, 0, 0, 0, 0, (byte)(LCID >> 24), (byte)((LCID & 0xFF0000) >> 16), (byte)((LCID & 0xFF00) >> 8), (byte)(LCID & 0xFF)));
	}

	private SortKey InvariantCreateSortKey(string source, CompareOptions options)
	{
		ArgumentNullException.ThrowIfNull(source, "source");
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.NumericOrdering | CompareOptions.StringSort)) != CompareOptions.None)
		{
			throw new ArgumentException("Argument_InvalidFlag", "options");
		}
		byte[] array;
		if (source.Length == 0)
		{
			array = Array.Empty<byte>();
		}
		else
		{
			array = new byte[source.Length * 2];
			if ((options & (CompareOptions.IgnoreCase | CompareOptions.OrdinalIgnoreCase)) != CompareOptions.None)
			{
				InvariantCreateSortKeyOrdinalIgnoreCase(source.AsSpan(), array);
			}
			else
			{
				InvariantCreateSortKeyOrdinal(source.AsSpan(), array);
			}
		}
		return new SortKey(this, source, options, array);
	}

	private static void InvariantCreateSortKeyOrdinal(ReadOnlySpan<char> source, Span<byte> sortKey)
	{
		for (int i = 0; i < source.Length; i++)
		{
			BinaryPrimitives.WriteUInt16BigEndian(sortKey, source[i]);
			sortKey = sortKey.Slice(2);
		}
	}

	private static void InvariantCreateSortKeyOrdinalIgnoreCase(ReadOnlySpan<char> source, Span<byte> sortKey)
	{
		for (int i = 0; i < source.Length; i++)
		{
			char c = source[i];
			if (char.IsHighSurrogate(c) && i < source.Length - 1)
			{
				char c2 = source[i + 1];
				if (char.IsLowSurrogate(c2))
				{
					SurrogateCasing.ToUpper(c, c2, out var hr, out var lr);
					Span<byte> destination = sortKey.Slice(0, 4);
					BinaryPrimitives.WriteUInt16BigEndian(destination, hr);
					BinaryPrimitives.WriteUInt16BigEndian(destination.Slice(2), lr);
					sortKey = sortKey.Slice(4);
					i++;
					continue;
				}
			}
			BinaryPrimitives.WriteUInt16BigEndian(sortKey, InvariantModeCasing.ToUpper(c));
			sortKey = sortKey.Slice(2);
		}
	}

	private static int InvariantGetSortKey(ReadOnlySpan<char> source, Span<byte> destination, CompareOptions options)
	{
		if ((uint)destination.Length < (uint)(source.Length * 2))
		{
			ThrowHelper.ThrowArgumentException_DestinationTooShort();
		}
		if ((options & CompareOptions.IgnoreCase) == 0)
		{
			InvariantCreateSortKeyOrdinal(source, destination);
		}
		else
		{
			InvariantCreateSortKeyOrdinalIgnoreCase(source, destination);
		}
		return source.Length * 2;
	}

	private static int InvariantGetSortKeyLength(ReadOnlySpan<char> source, CompareOptions options)
	{
		int num = source.Length * 2;
		if (num < 0)
		{
			throw new ArgumentException("ArgumentOutOfRange_GetByteCountOverflow", "source");
		}
		return num;
	}

	private static int InvariantGetHashCode(ReadOnlySpan<char> source, CompareOptions options)
	{
		if ((options & CompareOptions.IgnoreCase) == 0)
		{
			return string.GetHashCode(source);
		}
		return string.GetHashCodeOrdinalIgnoreCase(source);
	}

	internal bool IsPrefixUtf8(ReadOnlySpan<byte> source, ReadOnlySpan<byte> prefix, CompareOptions options = CompareOptions.None)
	{
		if (prefix.IsEmpty)
		{
			return true;
		}
		if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth)) == 0)
		{
			_ = GlobalizationMode.Invariant;
			return StartsWithCoreUtf8(source, prefix, options);
		}
		switch (options)
		{
		case CompareOptions.Ordinal:
			return source.StartsWith(prefix);
		case CompareOptions.OrdinalIgnoreCase:
			return source.StartsWithOrdinalIgnoreCaseUtf8(prefix);
		default:
			ThrowCompareOptionsCheckFailed(options);
			return false;
		}
	}

	private unsafe bool StartsWithCoreUtf8(ReadOnlySpan<byte> source, ReadOnlySpan<byte> prefix, CompareOptions options)
	{
		int maxCharCount = Encoding.UTF8.GetMaxCharCount(source.Length);
		char[] array;
		Span<char> span;
		if ((uint)maxCharCount <= 256u)
		{
			array = null;
			span = stackalloc char[256];
		}
		else
		{
			array = ArrayPool<char>.Shared.Rent(maxCharCount);
			span = array.AsSpan(0, maxCharCount);
		}
		if (Utf8.ToUtf16PreservingReplacement(source, span, out var bytesRead, out var charsWritten) != OperationStatus.Done)
		{
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
			return false;
		}
		span = span.Slice(0, charsWritten);
		int maxCharCount2 = Encoding.UTF8.GetMaxCharCount(prefix.Length);
		char[] array2;
		Span<char> span2;
		if ((uint)maxCharCount2 < 256u)
		{
			array2 = null;
			span2 = stackalloc char[256];
		}
		else
		{
			array2 = ArrayPool<char>.Shared.Rent(maxCharCount2);
			span2 = array2.AsSpan(0, maxCharCount2);
		}
		if (Utf8.ToUtf16PreservingReplacement(prefix, span2, out bytesRead, out var charsWritten2) != OperationStatus.Done)
		{
			if (array2 != null)
			{
				ArrayPool<char>.Shared.Return(array2);
			}
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
			return false;
		}
		span2 = span2.Slice(0, charsWritten2);
		bool result = StartsWithCore(span, span2, options, null);
		if (array2 != null)
		{
			ArrayPool<char>.Shared.Return(array2);
		}
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
		return result;
	}
}

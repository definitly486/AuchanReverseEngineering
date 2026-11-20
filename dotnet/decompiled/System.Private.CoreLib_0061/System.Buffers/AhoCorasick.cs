using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Buffers;

internal readonly struct AhoCorasick
{
	public interface IFastScan
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct NoFastScan : IFastScan
	{
	}

	private readonly AhoCorasickNode[] _nodes;

	private readonly IndexOfAnyAsciiSearcher.AsciiState _startingAsciiChars;

	public bool ShouldUseAsciiFastScan
	{
		get
		{
			if (false)
			{
			}
			return false;
		}
	}

	public AhoCorasick(AhoCorasickNode[] nodes, IndexOfAnyAsciiSearcher.AsciiState startingAsciiChars)
	{
		_nodes = nodes;
		_startingAsciiChars = startingAsciiChars;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int IndexOfAny<TCaseSensitivity, TFastScanVariant>(ReadOnlySpan<char> span) where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity where TFastScanVariant : struct, IFastScan
	{
		if (!(typeof(TCaseSensitivity) == typeof(StringSearchValuesHelper.CaseInsensitiveUnicode)))
		{
			return IndexOfAnyCore<TCaseSensitivity, TFastScanVariant>(span);
		}
		return IndexOfAnyCaseInsensitiveUnicode<TFastScanVariant>(span);
	}

	private int IndexOfAnyCore<TCaseSensitivity, TFastScanVariant>(ReadOnlySpan<char> span) where TCaseSensitivity : struct, StringSearchValuesHelper.ICaseSensitivity where TFastScanVariant : struct, IFastScan
	{
		ref AhoCorasickNode arrayDataReference = ref MemoryMarshal.GetArrayDataReference(_nodes);
		int num = 0;
		int num2 = -1;
		int num3 = 0;
		while (true)
		{
			if (false)
			{
			}
			while (true)
			{
				if ((uint)num3 < (uint)span.Length)
				{
					char c = TCaseSensitivity.TransformInput(Unsafe.Add(ref MemoryMarshal.GetReference(span), num3));
					int index;
					while (true)
					{
						ref AhoCorasickNode reference = ref Unsafe.Add(ref arrayDataReference, (uint)num);
						if (reference.TryGetChild(c, out index))
						{
							break;
						}
						if (num == 0)
						{
							goto IL_0076;
						}
						num = reference.SuffixLink;
						if (num >= 0)
						{
							continue;
						}
						goto IL_008f;
					}
					num = index;
					int matchLength = Unsafe.Add(ref arrayDataReference, (uint)num).MatchLength;
					if (matchLength != 0)
					{
						num2 = num3 + 1 - matchLength;
					}
					num3++;
					continue;
				}
				goto IL_008f;
				IL_0076:
				if (num2 < 0)
				{
					break;
				}
				goto IL_008f;
				IL_008f:
				return num2;
			}
			num3++;
		}
	}

	private int IndexOfAnyCaseInsensitiveUnicode<TFastScanVariant>(ReadOnlySpan<char> span) where TFastScanVariant : struct, IFastScan
	{
		ref AhoCorasickNode arrayDataReference = ref MemoryMarshal.GetArrayDataReference(_nodes);
		int num = 0;
		int num2 = -1;
		int num3 = 0;
		char lr = '\0';
		while (true)
		{
			if (false)
			{
			}
			while (true)
			{
				if ((uint)num3 < (uint)span.Length)
				{
					char hr;
					if (lr != 0)
					{
						hr = lr;
						lr = '\0';
					}
					else
					{
						hr = Unsafe.Add(ref MemoryMarshal.GetReference(span), num3);
						char l;
						if (char.IsHighSurrogate(hr) && (uint)(num3 + 1) < (uint)span.Length && char.IsLowSurrogate(l = Unsafe.Add(ref MemoryMarshal.GetReference(span), num3 + 1)))
						{
							if (false)
							{
							}
							SurrogateCasing.ToUpper(hr, l, out hr, out lr);
						}
						else
						{
							hr = TextInfo.ToUpperOrdinal(hr);
						}
					}
					int index;
					while (true)
					{
						ref AhoCorasickNode reference = ref Unsafe.Add(ref arrayDataReference, (uint)num);
						if (reference.TryGetChild(hr, out index))
						{
							break;
						}
						if (num == 0)
						{
							goto IL_00ca;
						}
						num = reference.SuffixLink;
						if (num >= 0)
						{
							continue;
						}
						goto IL_00e3;
					}
					num = index;
					int matchLength = Unsafe.Add(ref arrayDataReference, (uint)num).MatchLength;
					if (matchLength != 0)
					{
						num2 = num3 + 1 - matchLength;
					}
					num3++;
					continue;
				}
				goto IL_00e3;
				IL_00ca:
				if (num2 < 0)
				{
					break;
				}
				goto IL_00e3;
				IL_00e3:
				return num2;
			}
			num3++;
		}
	}
}

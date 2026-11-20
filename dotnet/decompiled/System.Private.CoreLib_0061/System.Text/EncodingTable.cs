using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.Text;

internal static class EncodingTable
{
	private static readonly Hashtable s_nameToCodePage = Hashtable.Synchronized(new Hashtable(StringComparer.OrdinalIgnoreCase));

	private static CodePageDataItem[] s_codePageToCodePageData;

	private static ReadOnlySpan<int> EncodingNameIndices => new int[43]
	{
		0, 14, 28, 33, 38, 43, 50, 61, 76, 82,
		88, 103, 113, 123, 131, 140, 149, 165, 175, 190,
		192, 198, 203, 210, 227, 244, 261, 278, 289, 291,
		299, 305, 313, 321, 327, 335, 343, 348, 353, 372,
		391, 410, 429
	};

	private static ReadOnlySpan<ushort> CodePagesByName => new ushort[42]
	{
		20127, 20127, 20127, 20127, 28591, 20127, 28591, 65000, 20127, 28591,
		1200, 28591, 28591, 20127, 20127, 28591, 20127, 28591, 28591, 28591,
		28591, 1200, 1200, 65000, 65001, 65000, 65001, 1201, 20127, 20127,
		1200, 1201, 1200, 12000, 12001, 12000, 65000, 65001, 65000, 65001,
		65000, 65001
	};

	private static ReadOnlySpan<ushort> MappedCodePages => new ushort[8] { 1200, 1201, 12000, 12001, 20127, 28591, 65000, 65001 };

	private static ReadOnlySpan<int> UiFamilyCodePages => new int[8] { 1200, 1200, 1200, 1200, 1252, 1252, 1200, 1200 };

	private static ReadOnlySpan<int> WebNameIndices => new int[9] { 0, 6, 14, 20, 28, 36, 46, 51, 56 };

	private static ReadOnlySpan<uint> Flags => new uint[8] { 512u, 0u, 0u, 0u, 257u, 771u, 257u, 771u };

	internal static int GetCodePageFromName(string name)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		object obj = s_nameToCodePage[name];
		if (obj != null)
		{
			return (int)obj;
		}
		int num = InternalGetCodePageFromName(name);
		s_nameToCodePage[name] = num;
		return num;
	}

	private static int InternalGetCodePageFromName(string name)
	{
		int i = 0;
		int num = EncodingNameIndices.Length - 2;
		ReadOnlySpan<char> readOnlySpan = name.ToLowerInvariant().AsSpan();
		while (num - i > 3)
		{
			int num2 = (num - i) / 2 + i;
			int num3 = string.CompareOrdinal(readOnlySpan, "ansi_x3.4-1968ansi_x3.4-1986asciicp367cp819csasciicsisolatin1csunicode11utf7ibm367ibm819iso-10646-ucs-2iso-8859-1iso-ir-100iso-ir-6iso646-usiso8859-1iso_646.irv:1991iso_8859-1iso_8859-1:1987l1latin1ucs-2unicodeunicode-1-1-utf-7unicode-1-1-utf-8unicode-2-0-utf-7unicode-2-0-utf-8unicodefffeusus-asciiutf-16utf-16beutf-16leutf-32utf-32beutf-32leutf-7utf-8x-unicode-1-1-utf-7x-unicode-1-1-utf-8x-unicode-2-0-utf-7x-unicode-2-0-utf-8".AsSpan(EncodingNameIndices[num2], EncodingNameIndices[num2 + 1] - EncodingNameIndices[num2]));
			if (num3 == 0)
			{
				return CodePagesByName[num2];
			}
			if (num3 < 0)
			{
				num = num2;
			}
			else
			{
				i = num2;
			}
		}
		for (; i <= num; i++)
		{
			if (readOnlySpan.SequenceEqual("ansi_x3.4-1968ansi_x3.4-1986asciicp367cp819csasciicsisolatin1csunicode11utf7ibm367ibm819iso-10646-ucs-2iso-8859-1iso-ir-100iso-ir-6iso646-usiso8859-1iso_646.irv:1991iso_8859-1iso_8859-1:1987l1latin1ucs-2unicodeunicode-1-1-utf-7unicode-1-1-utf-8unicode-2-0-utf-7unicode-2-0-utf-8unicodefffeusus-asciiutf-16utf-16beutf-16leutf-32utf-32beutf-32leutf-7utf-8x-unicode-1-1-utf-7x-unicode-1-1-utf-8x-unicode-2-0-utf-7x-unicode-2-0-utf-8".AsSpan(EncodingNameIndices[i], EncodingNameIndices[i + 1] - EncodingNameIndices[i])))
			{
				return CodePagesByName[i];
			}
		}
		throw new ArgumentException(SR.Format("Argument_EncodingNotSupported", name), "name");
	}

	internal static EncodingInfo[] GetEncodings()
	{
		ReadOnlySpan<ushort> mappedCodePages = MappedCodePages;
		_ = 0;
		EncodingInfo[] array = new EncodingInfo[mappedCodePages.Length - 1];
		string text = "utf-16utf-16BEutf-32utf-32BEus-asciiiso-8859-1utf-7utf-8";
		ReadOnlySpan<int> webNameIndices = WebNameIndices;
		int num = 0;
		for (int i = 0; i < mappedCodePages.Length; i++)
		{
			int num2 = mappedCodePages[i];
			if (num2 != 65000)
			{
				int num3 = num++;
				int num4 = webNameIndices[i];
				array[num3] = new EncodingInfo(num2, text.Substring(num4, webNameIndices[i + 1] - num4), GetDisplayName(num2));
			}
		}
		return array;
	}

	internal static EncodingInfo[] GetEncodings(Dictionary<int, EncodingInfo> encodingInfoList)
	{
		ReadOnlySpan<ushort> mappedCodePages = MappedCodePages;
		string text = "utf-16utf-16BEutf-32utf-32BEus-asciiiso-8859-1utf-7utf-8";
		ReadOnlySpan<int> webNameIndices = WebNameIndices;
		for (int i = 0; i < mappedCodePages.Length; i++)
		{
			int num = mappedCodePages[i];
			if (!encodingInfoList.ContainsKey(num) && num != 65000)
			{
				int num2 = webNameIndices[i];
				encodingInfoList[num] = new EncodingInfo(num, text.Substring(num2, webNameIndices[i + 1] - num2), GetDisplayName(num));
			}
		}
		_ = 0;
		encodingInfoList.Remove(65000);
		EncodingInfo[] array = new EncodingInfo[encodingInfoList.Count];
		int num3 = 0;
		foreach (KeyValuePair<int, EncodingInfo> encodingInfo in encodingInfoList)
		{
			array[num3++] = encodingInfo.Value;
		}
		return array;
	}

	internal static CodePageDataItem GetCodePageDataItem(int codePage)
	{
		if (s_codePageToCodePageData == null)
		{
			Interlocked.CompareExchange(ref s_codePageToCodePageData, new CodePageDataItem[MappedCodePages.Length], null);
		}
		int num;
		switch (codePage)
		{
		case 1200:
			num = 0;
			break;
		case 1201:
			num = 1;
			break;
		case 12000:
			num = 2;
			break;
		case 12001:
			num = 3;
			break;
		case 20127:
			num = 4;
			break;
		case 28591:
			num = 5;
			break;
		case 65000:
			num = 6;
			break;
		case 65001:
			num = 7;
			break;
		default:
			return null;
		}
		CodePageDataItem codePageDataItem = s_codePageToCodePageData[num];
		if (codePageDataItem == null)
		{
			Interlocked.CompareExchange(ref s_codePageToCodePageData[num], InternalGetCodePageDataItem(codePage, num), null);
			codePageDataItem = s_codePageToCodePageData[num];
		}
		return codePageDataItem;
	}

	private static CodePageDataItem InternalGetCodePageDataItem(int codePage, int index)
	{
		int uiFamilyCodePage = UiFamilyCodePages[index];
		int num = WebNameIndices[index];
		string text = "utf-16utf-16BEutf-32utf-32BEus-asciiiso-8859-1utf-7utf-8".Substring(num, WebNameIndices[index + 1] - num);
		string headerName = text;
		string bodyName = text;
		string displayName = GetDisplayName(codePage);
		uint flags = Flags[index];
		return new CodePageDataItem(uiFamilyCodePage, text, headerName, bodyName, displayName, flags);
	}

	private static string GetDisplayName(int codePage)
	{
		return codePage switch
		{
			1200 => "Globalization_cp_1200", 
			1201 => "Globalization_cp_1201", 
			12000 => "Globalization_cp_12000", 
			12001 => "Globalization_cp_12001", 
			20127 => "Globalization_cp_20127", 
			28591 => "Globalization_cp_28591", 
			65000 => "Globalization_cp_65000", 
			65001 => "Globalization_cp_65001", 
			_ => "", 
		};
	}
}

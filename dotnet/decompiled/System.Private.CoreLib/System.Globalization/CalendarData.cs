using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Globalization;

internal sealed class CalendarData
{
	private struct IcuEnumCalendarsData
	{
		public List<string> Results;

		public bool DisallowDuplicates;
	}

	internal string sNativeName;

	internal string[] saShortDates;

	internal string[] saYearMonths;

	internal string[] saLongDates;

	internal string sMonthDay;

	internal string[] saEraNames;

	internal string[] saAbbrevEraNames;

	internal string[] saAbbrevEnglishEraNames;

	internal string[] saDayNames;

	internal string[] saAbbrevDayNames;

	internal string[] saSuperShortDayNames;

	internal string[] saMonthNames;

	internal string[] saAbbrevMonthNames;

	internal string[] saMonthGenitiveNames;

	internal string[] saAbbrevMonthGenitiveNames;

	internal string[] saLeapYearMonthNames;

	internal int iTwoDigitYearMax = 2049;

	private int iCurrentEra;

	internal bool bUseUserOverrides;

	internal static readonly CalendarData Invariant = CreateInvariant();

	private CalendarData()
	{
	}

	private static CalendarData CreateInvariant()
	{
		CalendarData calendarData = new CalendarData();
		calendarData.sNativeName = "Gregorian Calendar";
		calendarData.iTwoDigitYearMax = 2049;
		calendarData.iCurrentEra = 1;
		calendarData.saShortDates = new string[2] { "MM/dd/yyyy", "yyyy-MM-dd" };
		calendarData.saLongDates = new string[1] { "dddd, dd MMMM yyyy" };
		calendarData.saYearMonths = new string[1] { "yyyy MMMM" };
		calendarData.sMonthDay = "MMMM dd";
		calendarData.saEraNames = new string[1] { "A.D." };
		calendarData.saAbbrevEraNames = new string[1] { "AD" };
		calendarData.saAbbrevEnglishEraNames = new string[1] { "AD" };
		calendarData.saDayNames = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
		calendarData.saAbbrevDayNames = new string[7] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
		calendarData.saSuperShortDayNames = new string[7] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
		calendarData.saMonthNames = new string[13]
		{
			"January",
			"February",
			"March",
			"April",
			"May",
			"June",
			"July",
			"August",
			"September",
			"October",
			"November",
			"December",
			string.Empty
		};
		calendarData.saAbbrevMonthNames = new string[13]
		{
			"Jan",
			"Feb",
			"Mar",
			"Apr",
			"May",
			"Jun",
			"Jul",
			"Aug",
			"Sep",
			"Oct",
			"Nov",
			"Dec",
			string.Empty
		};
		calendarData.saMonthGenitiveNames = calendarData.saMonthNames;
		calendarData.saAbbrevMonthGenitiveNames = calendarData.saAbbrevMonthNames;
		calendarData.saLeapYearMonthNames = calendarData.saMonthNames;
		calendarData.bUseUserOverrides = false;
		return calendarData;
	}

	internal CalendarData(string localeName, CalendarId calendarId, bool bUseUserOverrides)
	{
		this.bUseUserOverrides = bUseUserOverrides;
		if (!LoadCalendarDataFromSystemCore(localeName, calendarId))
		{
			if (sNativeName == null)
			{
				sNativeName = string.Empty;
			}
			if (saShortDates == null)
			{
				saShortDates = Invariant.saShortDates;
			}
			if (saYearMonths == null)
			{
				saYearMonths = Invariant.saYearMonths;
			}
			if (saLongDates == null)
			{
				saLongDates = Invariant.saLongDates;
			}
			if (sMonthDay == null)
			{
				sMonthDay = Invariant.sMonthDay;
			}
			if (saEraNames == null)
			{
				saEraNames = Invariant.saEraNames;
			}
			if (saAbbrevEraNames == null)
			{
				saAbbrevEraNames = Invariant.saAbbrevEraNames;
			}
			if (saAbbrevEnglishEraNames == null)
			{
				saAbbrevEnglishEraNames = Invariant.saAbbrevEnglishEraNames;
			}
			if (saDayNames == null)
			{
				saDayNames = Invariant.saDayNames;
			}
			if (saAbbrevDayNames == null)
			{
				saAbbrevDayNames = Invariant.saAbbrevDayNames;
			}
			if (saSuperShortDayNames == null)
			{
				saSuperShortDayNames = Invariant.saSuperShortDayNames;
			}
			if (saMonthNames == null)
			{
				saMonthNames = Invariant.saMonthNames;
			}
			if (saAbbrevMonthNames == null)
			{
				saAbbrevMonthNames = Invariant.saAbbrevMonthNames;
			}
		}
		if (calendarId == CalendarId.TAIWAN)
		{
			_ = 1;
			sNativeName = "中華民國曆";
		}
		if (saMonthGenitiveNames == null || saMonthGenitiveNames.Length == 0 || string.IsNullOrEmpty(saMonthGenitiveNames[0]))
		{
			saMonthGenitiveNames = saMonthNames;
		}
		if (saAbbrevMonthGenitiveNames == null || saAbbrevMonthGenitiveNames.Length == 0 || string.IsNullOrEmpty(saAbbrevMonthGenitiveNames[0]))
		{
			saAbbrevMonthGenitiveNames = saAbbrevMonthNames;
		}
		if (saLeapYearMonthNames == null || saLeapYearMonthNames.Length == 0 || string.IsNullOrEmpty(saLeapYearMonthNames[0]))
		{
			saLeapYearMonthNames = saMonthNames;
		}
		InitializeEraNames(localeName, calendarId);
		InitializeAbbreviatedEraNames(localeName, calendarId);
		if (calendarId == CalendarId.JAPAN)
		{
			saAbbrevEnglishEraNames = JapaneseCalendar.EnglishEraNames();
		}
		else
		{
			saAbbrevEnglishEraNames = new string[1] { "" };
		}
		iCurrentEra = saEraNames.Length;
	}

	private void InitializeEraNames(string localeName, CalendarId calendarId)
	{
		switch (calendarId)
		{
		case CalendarId.GREGORIAN:
			if (AreEraNamesEmpty())
			{
				saEraNames = new string[1] { "A.D." };
			}
			break;
		case CalendarId.GREGORIAN_US:
		case CalendarId.JULIAN:
			saEraNames = new string[1] { "A.D." };
			break;
		case CalendarId.HEBREW:
			saEraNames = new string[1] { "C.E." };
			break;
		case CalendarId.HIJRI:
		case CalendarId.UMALQURA:
			if (localeName == "dv-MV")
			{
				saEraNames = new string[1] { "ހ\u07a8ޖ\u07b0ރ\u07a9" };
			}
			else
			{
				saEraNames = new string[1] { "بعد الهجرة" };
			}
			break;
		case CalendarId.GREGORIAN_ARABIC:
		case CalendarId.GREGORIAN_XLIT_ENGLISH:
		case CalendarId.GREGORIAN_XLIT_FRENCH:
			saEraNames = new string[1] { "م" };
			break;
		case CalendarId.GREGORIAN_ME_FRENCH:
			saEraNames = new string[1] { "ap. J.-C." };
			break;
		case CalendarId.TAIWAN:
			_ = 1;
			saEraNames = new string[1] { "中華民國" };
			break;
		case CalendarId.KOREA:
			saEraNames = new string[1] { "단기" };
			break;
		case CalendarId.THAI:
			saEraNames = new string[1] { "พ.ศ." };
			break;
		case CalendarId.JAPAN:
		case CalendarId.JAPANESELUNISOLAR:
			saEraNames = JapaneseCalendar.EraNames();
			break;
		case CalendarId.PERSIAN:
			if (AreEraNamesEmpty())
			{
				saEraNames = new string[1] { "ه.ش" };
			}
			break;
		default:
			saEraNames = Invariant.saEraNames;
			break;
		}
		bool AreEraNamesEmpty()
		{
			if (saEraNames != null && saEraNames.Length != 0)
			{
				return string.IsNullOrEmpty(saEraNames[0]);
			}
			return true;
		}
	}

	private void InitializeAbbreviatedEraNames(string localeName, CalendarId calendarId)
	{
		switch (calendarId)
		{
		case CalendarId.GREGORIAN:
			if (saAbbrevEraNames == null || saAbbrevEraNames.Length == 0 || string.IsNullOrEmpty(saAbbrevEraNames[0]))
			{
				saAbbrevEraNames = new string[1] { "AD" };
			}
			break;
		case CalendarId.GREGORIAN_US:
		case CalendarId.JULIAN:
			saAbbrevEraNames = new string[1] { "AD" };
			break;
		case CalendarId.JAPAN:
		case CalendarId.JAPANESELUNISOLAR:
			saAbbrevEraNames = JapaneseCalendar.AbbrevEraNames();
			break;
		case CalendarId.HIJRI:
		case CalendarId.UMALQURA:
			if (localeName == "dv-MV")
			{
				saAbbrevEraNames = new string[1] { "ހ." };
			}
			else
			{
				saAbbrevEraNames = new string[1] { "هـ" };
			}
			break;
		case CalendarId.TAIWAN:
			saAbbrevEraNames = new string[1];
			if (saEraNames[0].Length == 4)
			{
				saAbbrevEraNames[0] = saEraNames[0].Substring(2, 2);
			}
			else
			{
				saAbbrevEraNames[0] = saEraNames[0];
			}
			break;
		case CalendarId.PERSIAN:
			if (saAbbrevEraNames == null || saAbbrevEraNames.Length == 0 || string.IsNullOrEmpty(saAbbrevEraNames[0]))
			{
				saAbbrevEraNames = saEraNames;
			}
			break;
		default:
			saAbbrevEraNames = saEraNames;
			break;
		}
	}

	internal static int GetCalendarCurrentEra(Calendar calendar)
	{
		if (GlobalizationMode.Invariant)
		{
		}
		CalendarId baseCalendarID = calendar.BaseCalendarID;
		return CultureInfo.GetCultureInfo(CalendarIdToCultureName(baseCalendarID))._cultureData.GetCalendar(baseCalendarID).iCurrentEra;
	}

	private static string CalendarIdToCultureName(CalendarId calendarId)
	{
		switch (calendarId)
		{
		case CalendarId.GREGORIAN_US:
			return "fa-IR";
		case CalendarId.JAPAN:
			return "ja-JP";
		case CalendarId.TAIWAN:
			return "zh-TW";
		case CalendarId.KOREA:
			return "ko-KR";
		case CalendarId.HIJRI:
		case CalendarId.GREGORIAN_ARABIC:
		case CalendarId.UMALQURA:
			return "ar-SA";
		case CalendarId.THAI:
			return "th-TH";
		case CalendarId.HEBREW:
			return "he-IL";
		case CalendarId.GREGORIAN_ME_FRENCH:
			return "ar-DZ";
		case CalendarId.GREGORIAN_XLIT_ENGLISH:
		case CalendarId.GREGORIAN_XLIT_FRENCH:
			return "ar-IQ";
		default:
			return "en-US";
		}
	}

	private bool IcuLoadCalendarDataFromSystem(string localeName, CalendarId calendarId)
	{
		int num = (int)(1u & (GetCalendarInfo(localeName, calendarId, CalendarDataType.NativeName, out sNativeName) ? 1u : 0u)) & (GetCalendarInfo(localeName, calendarId, CalendarDataType.MonthDay, out sMonthDay) ? 1 : 0);
		if (sMonthDay != null)
		{
			sMonthDay = NormalizeDatePattern(sMonthDay);
		}
		int num2 = (int)((uint)num & (EnumDatePatterns(localeName, calendarId, CalendarDataType.ShortDates, out saShortDates) ? 1u : 0u) & (EnumDatePatterns(localeName, calendarId, CalendarDataType.LongDates, out saLongDates) ? 1u : 0u) & (EnumDatePatterns(localeName, calendarId, CalendarDataType.YearMonths, out saYearMonths) ? 1u : 0u) & (EnumCalendarInfo(localeName, calendarId, CalendarDataType.DayNames, out saDayNames) ? 1u : 0u) & (EnumCalendarInfo(localeName, calendarId, CalendarDataType.AbbrevDayNames, out saAbbrevDayNames) ? 1u : 0u)) & (EnumCalendarInfo(localeName, calendarId, CalendarDataType.SuperShortDayNames, out saSuperShortDayNames) ? 1 : 0);
		string leapHebrewMonthName = null;
		int num3 = num2 & (EnumMonthNames(localeName, calendarId, CalendarDataType.MonthNames, out saMonthNames, ref leapHebrewMonthName) ? 1 : 0);
		if (leapHebrewMonthName != null)
		{
			saLeapYearMonthNames = (string[])saMonthNames.Clone();
			saLeapYearMonthNames[6] = leapHebrewMonthName;
			saMonthNames[5] = saMonthNames[6];
			saMonthNames[6] = leapHebrewMonthName;
		}
		return (byte)((uint)num3 & (EnumMonthNames(localeName, calendarId, CalendarDataType.AbbrevMonthNames, out saAbbrevMonthNames, ref leapHebrewMonthName) ? 1u : 0u) & (EnumMonthNames(localeName, calendarId, CalendarDataType.MonthGenitiveNames, out saMonthGenitiveNames, ref leapHebrewMonthName) ? 1u : 0u) & (EnumMonthNames(localeName, calendarId, CalendarDataType.AbbrevMonthGenitiveNames, out saAbbrevMonthGenitiveNames, ref leapHebrewMonthName) ? 1u : 0u) & (EnumEraNames(localeName, calendarId, CalendarDataType.EraNames, out saEraNames) ? 1u : 0u) & (EnumEraNames(localeName, calendarId, CalendarDataType.AbbrevEraNames, out saAbbrevEraNames) ? 1u : 0u)) != 0;
	}

	internal static int IcuGetCalendars(string localeName, CalendarId[] calendars)
	{
		int num = Interop.Globalization.GetCalendars(localeName, calendars, calendars.Length);
		if (num == 0 && calendars.Length != 0)
		{
			calendars[0] = CalendarId.GREGORIAN;
			num = 1;
		}
		return num;
	}

	private unsafe static bool GetCalendarInfo(string localeName, CalendarId calendarId, CalendarDataType dataType, out string calendarString)
	{
		return Interop.CallStringMethod(delegate(Span<char> buffer, string locale, CalendarId id, CalendarDataType type)
		{
			fixed (char* result = buffer)
			{
				return Interop.Globalization.GetCalendarInfo(locale, id, type, result, buffer.Length);
			}
		}, localeName, calendarId, dataType, out calendarString);
	}

	private unsafe static bool EnumDatePatterns(string localeName, CalendarId calendarId, CalendarDataType dataType, out string[] datePatterns)
	{
		datePatterns = null;
		IcuEnumCalendarsData icuEnumCalendarsData = new IcuEnumCalendarsData
		{
			Results = new List<string>(),
			DisallowDuplicates = true
		};
		bool flag = EnumCalendarInfo(localeName, calendarId, dataType, &icuEnumCalendarsData);
		if (flag)
		{
			List<string> results = icuEnumCalendarsData.Results;
			for (int i = 0; i < results.Count; i++)
			{
				results[i] = NormalizeDatePattern(results[i]);
			}
			if (dataType == CalendarDataType.ShortDates)
			{
				FixDefaultShortDatePattern(results);
			}
			datePatterns = results.ToArray();
		}
		return flag;
	}

	private static void FixDefaultShortDatePattern(List<string> shortDatePatterns)
	{
		if (shortDatePatterns.Count == 0)
		{
			return;
		}
		string text = shortDatePatterns[0];
		if (text.Length > 100)
		{
			return;
		}
		Span<char> span = stackalloc char[text.Length + 2];
		int i;
		for (i = 0; i < text.Length; i++)
		{
			if (text[i] == '\'')
			{
				do
				{
					span[i] = text[i];
					i++;
				}
				while (i < text.Length && text[i] != '\'');
				if (i >= text.Length)
				{
					return;
				}
			}
			else if (text[i] == 'y')
			{
				span[i] = 'y';
				break;
			}
			span[i] = text[i];
		}
		if (i >= text.Length - 1 || text[i + 1] != 'y' || (i + 2 < text.Length && text[i + 2] == 'y'))
		{
			return;
		}
		span[i + 1] = 'y';
		span[i + 2] = 'y';
		span[i + 3] = 'y';
		for (i += 2; i < text.Length; i++)
		{
			span[i + 2] = text[i];
		}
		shortDatePatterns[0] = span.ToString();
		for (int j = 1; j < shortDatePatterns.Count; j++)
		{
			if (shortDatePatterns[j] == shortDatePatterns[0])
			{
				shortDatePatterns[j] = text;
				return;
			}
		}
		shortDatePatterns.Add(text);
	}

	private static string NormalizeDatePattern(string input)
	{
		ValueStringBuilder valueStringBuilder;
		if (input.Length < 128)
		{
			Span<char> initialBuffer = stackalloc char[128];
			valueStringBuilder = new ValueStringBuilder(initialBuffer);
		}
		else
		{
			valueStringBuilder = new ValueStringBuilder(input.Length);
		}
		ValueStringBuilder destination = valueStringBuilder;
		int index = 0;
		while (index < input.Length)
		{
			switch (input[index])
			{
			case '\'':
				destination.Append(input[index++]);
				while (index < input.Length)
				{
					char c = input[index++];
					destination.Append(c);
					if (c == '\'')
					{
						break;
					}
				}
				break;
			case 'E':
			case 'c':
			case 'e':
				NormalizeDayOfWeek(input, ref destination, ref index);
				break;
			case 'L':
			case 'M':
			{
				int num = CountOccurrences(input, input[index], ref index);
				if (num > 4)
				{
					num = 3;
				}
				destination.Append('M', num);
				break;
			}
			case 'G':
				CountOccurrences(input, 'G', ref index);
				destination.Append('g');
				break;
			case 'y':
			{
				int num = CountOccurrences(input, 'y', ref index);
				if (num == 1)
				{
					num = 4;
				}
				destination.Append('y', num);
				break;
			}
			default:
				destination.Append(input[index++]);
				break;
			}
		}
		return destination.ToString();
	}

	private static void NormalizeDayOfWeek(string input, ref ValueStringBuilder destination, ref int index)
	{
		char value = input[index];
		int val = CountOccurrences(input, value, ref index);
		val = Math.Max(val, 3);
		if (val > 4)
		{
			val = 3;
		}
		destination.Append('d', val);
	}

	private static int CountOccurrences(string input, char value, ref int index)
	{
		int num = index;
		while (index < input.Length && input[index] == value)
		{
			index++;
		}
		return index - num;
	}

	private unsafe static bool EnumMonthNames(string localeName, CalendarId calendarId, CalendarDataType dataType, out string[] monthNames, ref string leapHebrewMonthName)
	{
		monthNames = null;
		IcuEnumCalendarsData icuEnumCalendarsData = new IcuEnumCalendarsData
		{
			Results = new List<string>()
		};
		bool num = EnumCalendarInfo(localeName, calendarId, dataType, &icuEnumCalendarsData);
		if (num)
		{
			if (icuEnumCalendarsData.Results.Count == 12)
			{
				icuEnumCalendarsData.Results.Add(string.Empty);
			}
			if (icuEnumCalendarsData.Results.Count > 13)
			{
				if (calendarId == CalendarId.HEBREW)
				{
					leapHebrewMonthName = icuEnumCalendarsData.Results[13];
				}
				icuEnumCalendarsData.Results.RemoveRange(13, icuEnumCalendarsData.Results.Count - 13);
			}
			monthNames = icuEnumCalendarsData.Results.ToArray();
		}
		return num;
	}

	private static bool EnumEraNames(string localeName, CalendarId calendarId, CalendarDataType dataType, out string[] eraNames)
	{
		bool result = EnumCalendarInfo(localeName, calendarId, dataType, out eraNames);
		if (calendarId != CalendarId.JAPAN && calendarId != CalendarId.JAPANESELUNISOLAR)
		{
			string[] obj = eraNames;
			if (obj != null && obj.Length != 0)
			{
				eraNames = new string[1] { eraNames[^1] };
			}
		}
		return result;
	}

	internal unsafe static bool EnumCalendarInfo(string localeName, CalendarId calendarId, CalendarDataType dataType, out string[] calendarData)
	{
		calendarData = null;
		IcuEnumCalendarsData icuEnumCalendarsData = new IcuEnumCalendarsData
		{
			Results = new List<string>()
		};
		bool num = EnumCalendarInfo(localeName, calendarId, dataType, &icuEnumCalendarsData);
		if (num)
		{
			calendarData = icuEnumCalendarsData.Results.ToArray();
		}
		return num;
	}

	private unsafe static bool EnumCalendarInfo(string localeName, CalendarId calendarId, CalendarDataType dataType, IcuEnumCalendarsData* callbackContext)
	{
		return Interop.Globalization.EnumCalendarInfo((delegate* unmanaged<char*, nint, void>)(delegate*<char*, nint, void>)(&EnumCalendarInfoCallback), localeName, calendarId, dataType, (nint)callbackContext);
	}

	[UnmanagedCallersOnly]
	private unsafe static void EnumCalendarInfoCallback(char* calendarStringPtr, nint context)
	{
		try
		{
			ReadOnlySpan<char> span = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(calendarStringPtr);
			if (((IcuEnumCalendarsData*)context)->DisallowDuplicates)
			{
				foreach (string result in ((IcuEnumCalendarsData*)context)->Results)
				{
					if (span.SequenceEqual(result.AsSpan()))
					{
						return;
					}
				}
			}
			((IcuEnumCalendarsData*)context)->Results.Add(span.ToString());
		}
		catch (Exception)
		{
		}
	}

	private bool LoadCalendarDataFromSystemCore(string localeName, CalendarId calendarId)
	{
		return IcuLoadCalendarDataFromSystem(localeName, calendarId);
	}

	internal static int GetCalendarsCore(string localeName, bool useUserOverride, CalendarId[] calendars)
	{
		return IcuGetCalendars(localeName, calendars);
	}

	internal static int GetTwoDigitYearMax(CalendarId calendarId)
	{
		_ = GlobalizationMode.Invariant;
		return -1;
	}
}

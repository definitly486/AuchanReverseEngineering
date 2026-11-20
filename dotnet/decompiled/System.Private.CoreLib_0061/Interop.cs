using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32.SafeHandles;

internal static class Interop
{
	internal static class Globalization
	{
		internal enum ResultCode
		{
			Success,
			UnknownError,
			InsufficientBuffer,
			OutOfMemory,
			InvalidCodePoint
		}

		internal enum TimeZoneDisplayNameType
		{
			Generic,
			Standard,
			DaylightSavings,
			GenericLocation,
			ExemplarCity,
			TimeZoneName
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetCalendars", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int GetCalendars(string localeName, CalendarId[] calendars, int calendarsCapacity)
		{
			int result;
			fixed (CalendarId* ptr = &ArrayMarshaller<CalendarId, CalendarId>.ManagedToUnmanagedIn.GetPinnableReference(calendars))
			{
				void* _calendars_native = ptr;
				fixed (char* ptr2 = &Utf16StringMarshaller.GetPinnableReference(localeName))
				{
					void* _localeName_native = ptr2;
					result = __PInvoke((ushort*)_localeName_native, (CalendarId*)_calendars_native, calendarsCapacity);
				}
			}
			return result;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetCalendars", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __localeName_native, CalendarId* __calendars_native, int __calendarsCapacity_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetCalendarInfo", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static ResultCode GetCalendarInfo(string localeName, CalendarId calendarId, CalendarDataType calendarDataType, char* result, int resultCapacity)
		{
			ResultCode result2;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(localeName))
			{
				void* _localeName_native = ptr;
				result2 = __PInvoke((ushort*)_localeName_native, calendarId, calendarDataType, result, resultCapacity);
			}
			return result2;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetCalendarInfo", ExactSpelling = true)]
			static extern unsafe ResultCode __PInvoke(ushort* __localeName_native, CalendarId __calendarId_native, CalendarDataType __calendarDataType_native, char* __result_native, int __resultCapacity_native);
		}

		internal unsafe static bool EnumCalendarInfo(delegate* unmanaged<char*, nint, void> callback, string localeName, CalendarId calendarId, CalendarDataType calendarDataType, nint context)
		{
			return EnumCalendarInfo((nint)callback, localeName, calendarId, calendarDataType, context);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_EnumCalendarInfo", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private unsafe static bool EnumCalendarInfo(nint callback, string localeName, CalendarId calendarId, CalendarDataType calendarDataType, nint context)
		{
			int num;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(localeName))
			{
				void* _localeName_native = ptr;
				num = __PInvoke(callback, (ushort*)_localeName_native, calendarId, calendarDataType, context);
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_EnumCalendarInfo", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __callback_native, ushort* __localeName_native, CalendarId __calendarId_native, CalendarDataType __calendarDataType_native, nint __context_native);
		}

		[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLatestJapaneseEra", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLatestJapaneseEra")]
		internal static extern int GetLatestJapaneseEra();

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetJapaneseEraStartDate")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool GetJapaneseEraStartDate(int era, out int startYear, out int startMonth, out int startDay)
		{
			startYear = 0;
			startMonth = 0;
			startDay = 0;
			int num;
			fixed (int* _startDay_native = &startDay)
			{
				fixed (int* _startMonth_native = &startMonth)
				{
					fixed (int* _startYear_native = &startYear)
					{
						num = __PInvoke(era, _startYear_native, _startMonth_native, _startDay_native);
					}
				}
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetJapaneseEraStartDate", ExactSpelling = true)]
			static extern unsafe int __PInvoke(int __era_native, int* __startYear_native, int* __startMonth_native, int* __startDay_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ChangeCase", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static void ChangeCase(char* src, int srcLen, char* dstBuffer, int dstBufferCapacity, [MarshalAs(UnmanagedType.Bool)] bool bToUpper)
		{
			int _bToUpper_native = (bToUpper ? 1 : 0);
			__PInvoke(src, srcLen, dstBuffer, dstBufferCapacity, _bToUpper_native);
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ChangeCase", ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			static extern unsafe void __PInvoke(char* __src_native, int __srcLen_native, char* __dstBuffer_native, int __dstBufferCapacity_native, int __bToUpper_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ChangeCaseInvariant", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static void ChangeCaseInvariant(char* src, int srcLen, char* dstBuffer, int dstBufferCapacity, [MarshalAs(UnmanagedType.Bool)] bool bToUpper)
		{
			int _bToUpper_native = (bToUpper ? 1 : 0);
			__PInvoke(src, srcLen, dstBuffer, dstBufferCapacity, _bToUpper_native);
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ChangeCaseInvariant", ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			static extern unsafe void __PInvoke(char* __src_native, int __srcLen_native, char* __dstBuffer_native, int __dstBufferCapacity_native, int __bToUpper_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ChangeCaseTurkish", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static void ChangeCaseTurkish(char* src, int srcLen, char* dstBuffer, int dstBufferCapacity, [MarshalAs(UnmanagedType.Bool)] bool bToUpper)
		{
			int _bToUpper_native = (bToUpper ? 1 : 0);
			__PInvoke(src, srcLen, dstBuffer, dstBufferCapacity, _bToUpper_native);
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ChangeCaseTurkish", ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			static extern unsafe void __PInvoke(char* __src_native, int __srcLen_native, char* __dstBuffer_native, int __dstBufferCapacity_native, int __bToUpper_native);
		}

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_InitOrdinalCasingPage", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_InitOrdinalCasingPage", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern void InitOrdinalCasingPage(int pageNumber, char* pTarget);

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetSortHandle", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static ResultCode GetSortHandle(string localeName, out nint sortHandle)
		{
			sortHandle = 0;
			ResultCode resultCode = ResultCode.Success;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(localeName, buffer);
				fixed (nint* _sortHandle_native = &sortHandle)
				{
					return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), _sortHandle_native);
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetSortHandle", ExactSpelling = true)]
			static extern unsafe ResultCode __PInvoke(byte* __localeName_native, nint* __sortHandle_native);
		}

		[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_CloseSortHandle", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_CloseSortHandle")]
		internal static extern void CloseSortHandle(nint handle);

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_CompareString", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_CompareString", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int CompareString(nint sortHandle, char* lpStr1, int cwStr1Len, char* lpStr2, int cwStr2Len, CompareOptions options);

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_IndexOf", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_IndexOf", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int IndexOf(nint sortHandle, char* target, int cwTargetLength, char* pSource, int cwSourceLength, CompareOptions options, int* matchLengthPtr);

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_LastIndexOf", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_LastIndexOf", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int LastIndexOf(nint sortHandle, char* target, int cwTargetLength, char* pSource, int cwSourceLength, CompareOptions options, int* matchLengthPtr);

		[MethodImpl(MethodImplOptions.NoInlining)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_StartsWith", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool StartsWith(nint sortHandle, char* target, int cwTargetLength, char* source, int cwSourceLength, CompareOptions options, int* matchedLength)
		{
			return __PInvoke(sortHandle, target, cwTargetLength, source, cwSourceLength, options, matchedLength) != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_StartsWith", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __sortHandle_native, char* __target_native, int __cwTargetLength_native, char* __source_native, int __cwSourceLength_native, CompareOptions __options_native, int* __matchedLength_native);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_EndsWith", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool EndsWith(nint sortHandle, char* target, int cwTargetLength, char* source, int cwSourceLength, CompareOptions options, int* matchedLength)
		{
			return __PInvoke(sortHandle, target, cwTargetLength, source, cwSourceLength, options, matchedLength) != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_EndsWith", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __sortHandle_native, char* __target_native, int __cwTargetLength_native, char* __source_native, int __cwSourceLength_native, CompareOptions __options_native, int* __matchedLength_native);
		}

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_GetSortKey", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetSortKey", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int GetSortKey(nint sortHandle, char* str, int strLength, byte* sortKey, int sortKeyLength, CompareOptions options);

		[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetSortVersion", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetSortVersion")]
		internal static extern int GetSortVersion(nint sortHandle);

		[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_LoadICU", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_LoadICU")]
		internal static extern int LoadICU();

		internal static void InitICUFunctions(nint icuuc, nint icuin, ReadOnlySpan<char> version, ReadOnlySpan<char> suffix)
		{
			InitICUFunctions(icuuc, icuin, version.ToString(), (suffix.Length > 0) ? suffix.ToString() : null);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_InitICUFunctions", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static void InitICUFunctions(nint icuuc, nint icuin, string version, string suffix)
		{
			byte* ptr = default(byte*);
			byte* ptr2 = default(byte*);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				string managed = suffix;
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(managed, buffer);
				managed = version;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn2.FromManaged(managed, buffer);
				ptr2 = managedToUnmanagedIn.ToUnmanaged();
				ptr = managedToUnmanagedIn2.ToUnmanaged();
				__PInvoke(icuuc, icuin, ptr, ptr2);
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_InitICUFunctions", ExactSpelling = true)]
			static extern unsafe void __PInvoke(nint __icuuc_native, nint __icuin_native, byte* __version_native, byte* __suffix_native);
		}

		[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetICUVersion", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetICUVersion")]
		internal static extern int GetICUVersion();

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_ToAscii", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ToAscii", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int ToAscii(uint flags, char* src, int srcLen, char* dstBuffer, int dstBufferCapacity);

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_ToUnicode", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_ToUnicode", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int ToUnicode(uint flags, char* src, int srcLen, char* dstBuffer, int dstBufferCapacity);

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleName", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool GetLocaleName(string localeName, char* value, int valueLength)
		{
			int num;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(localeName))
			{
				void* _localeName_native = ptr;
				num = __PInvoke((ushort*)_localeName_native, value, valueLength);
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleName", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __localeName_native, char* __value_native, int __valueLength_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleInfoString", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool GetLocaleInfoString(string localeName, uint localeStringData, char* value, int valueLength, string uiLocaleName = null)
		{
			int num;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(uiLocaleName))
			{
				void* _uiLocaleName_native = ptr;
				fixed (char* ptr2 = &Utf16StringMarshaller.GetPinnableReference(localeName))
				{
					void* _localeName_native = ptr2;
					num = __PInvoke((ushort*)_localeName_native, localeStringData, value, valueLength, (ushort*)_uiLocaleName_native);
				}
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleInfoString", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __localeName_native, uint __localeStringData_native, char* __value_native, int __valueLength_native, ushort* __uiLocaleName_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetDefaultLocaleName", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool GetDefaultLocaleName(char* value, int valueLength)
		{
			return __PInvoke(value, valueLength) != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetDefaultLocaleName", ExactSpelling = true)]
			static extern unsafe int __PInvoke(char* __value_native, int __valueLength_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_IsPredefinedLocale", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool IsPredefinedLocale(string localeName)
		{
			int num;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(localeName))
			{
				void* _localeName_native = ptr;
				num = __PInvoke((ushort*)_localeName_native);
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_IsPredefinedLocale", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __localeName_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleTimeFormat", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool GetLocaleTimeFormat(string localeName, [MarshalAs(UnmanagedType.Bool)] bool shortFormat, char* value, int valueLength)
		{
			int _shortFormat_native = (shortFormat ? 1 : 0);
			int num;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(localeName))
			{
				void* _localeName_native = ptr;
				num = __PInvoke((ushort*)_localeName_native, _shortFormat_native, value, valueLength);
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleTimeFormat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __localeName_native, int __shortFormat_native, char* __value_native, int __valueLength_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleInfoInt", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool GetLocaleInfoInt(string localeName, uint localeNumberData, ref int value)
		{
			int num;
			fixed (int* _value_native = &value)
			{
				fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(localeName))
				{
					void* _localeName_native = ptr;
					num = __PInvoke((ushort*)_localeName_native, localeNumberData, _value_native);
				}
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleInfoInt", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __localeName_native, uint __localeNumberData_native, int* __value_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleInfoGroupingSizes", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static bool GetLocaleInfoGroupingSizes(string localeName, uint localeGroupingData, ref int primaryGroupSize, ref int secondaryGroupSize)
		{
			int num;
			fixed (int* _secondaryGroupSize_native = &secondaryGroupSize)
			{
				fixed (int* _primaryGroupSize_native = &primaryGroupSize)
				{
					fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(localeName))
					{
						void* _localeName_native = ptr;
						num = __PInvoke((ushort*)_localeName_native, localeGroupingData, _primaryGroupSize_native, _secondaryGroupSize_native);
					}
				}
			}
			return num != 0;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocaleInfoGroupingSizes", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __localeName_native, uint __localeGroupingData_native, int* __primaryGroupSize_native, int* __secondaryGroupSize_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocales", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int GetLocales([Out] char[] value, int valueLength)
		{
			int result;
			fixed (char* ptr = &ArrayMarshaller<char, char>.ManagedToUnmanagedIn.GetPinnableReference(value))
			{
				void* _value_native = ptr;
				result = __PInvoke((char*)_value_native, valueLength);
			}
			return result;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetLocales", ExactSpelling = true)]
			static extern unsafe int __PInvoke(char* __value_native, int __valueLength_native);
		}

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_IsNormalized", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_IsNormalized", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int IsNormalized(NormalizationForm normalizationForm, char* src, int srcLen);

		[DllImport("libSystem.Globalization.Native", CharSet = CharSet.Unicode, EntryPoint = "GlobalizationNative_NormalizeString", ExactSpelling = true)]
		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_NormalizeString", StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static extern int NormalizeString(NormalizationForm normalizationForm, char* src, int srcLen, char* dstBuffer, int dstBufferCapacity);

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetTimeZoneDisplayName", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static ResultCode GetTimeZoneDisplayName(string localeName, string timeZoneId, TimeZoneDisplayNameType type, char* result, int resultLength)
		{
			ResultCode result2;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(timeZoneId))
			{
				void* _timeZoneId_native = ptr;
				fixed (char* ptr2 = &Utf16StringMarshaller.GetPinnableReference(localeName))
				{
					void* _localeName_native = ptr2;
					result2 = __PInvoke((ushort*)_localeName_native, (ushort*)_timeZoneId_native, type, result, resultLength);
				}
			}
			return result2;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_GetTimeZoneDisplayName", ExactSpelling = true)]
			static extern unsafe ResultCode __PInvoke(ushort* __localeName_native, ushort* __timeZoneId_native, TimeZoneDisplayNameType __type_native, char* __result_native, int __resultLength_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_WindowsIdToIanaId", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int WindowsIdToIanaId(string windowsId, nint region, char* ianaId, int ianaIdLength)
		{
			int result;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(windowsId))
			{
				void* _windowsId_native = ptr;
				result = __PInvoke((ushort*)_windowsId_native, region, ianaId, ianaIdLength);
			}
			return result;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_WindowsIdToIanaId", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __windowsId_native, nint __region_native, char* __ianaId_native, int __ianaIdLength_native);
		}

		[LibraryImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_IanaIdToWindowsId", StringMarshalling = StringMarshalling.Utf16)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int IanaIdToWindowsId(string ianaId, char* windowsId, int windowsIdLength)
		{
			int result;
			fixed (char* ptr = &Utf16StringMarshaller.GetPinnableReference(ianaId))
			{
				void* _ianaId_native = ptr;
				result = __PInvoke((ushort*)_ianaId_native, windowsId, windowsIdLength);
			}
			return result;
			[DllImport("libSystem.Globalization.Native", EntryPoint = "GlobalizationNative_IanaIdToWindowsId", ExactSpelling = true)]
			static extern unsafe int __PInvoke(ushort* __ianaId_native, char* __windowsId_native, int __windowsIdLength_native);
		}
	}

	internal static class Advapi32
	{
		internal enum ActivityControl : uint
		{
			EVENT_ACTIVITY_CTRL_GET_ID = 1u,
			EVENT_ACTIVITY_CTRL_SET_ID,
			EVENT_ACTIVITY_CTRL_CREATE_ID,
			EVENT_ACTIVITY_CTRL_GET_SET_ID,
			EVENT_ACTIVITY_CTRL_CREATE_SET_ID
		}

		internal struct EVENT_FILTER_DESCRIPTOR
		{
			public long Ptr;

			public int Size;

			public int Type;
		}
	}

	internal enum Error
	{
		SUCCESS = 0,
		E2BIG = 65537,
		EACCES = 65538,
		EADDRINUSE = 65539,
		EADDRNOTAVAIL = 65540,
		EAFNOSUPPORT = 65541,
		EAGAIN = 65542,
		EALREADY = 65543,
		EBADF = 65544,
		EBADMSG = 65545,
		EBUSY = 65546,
		ECANCELED = 65547,
		ECHILD = 65548,
		ECONNABORTED = 65549,
		ECONNREFUSED = 65550,
		ECONNRESET = 65551,
		EDEADLK = 65552,
		EDESTADDRREQ = 65553,
		EDOM = 65554,
		EDQUOT = 65555,
		EEXIST = 65556,
		EFAULT = 65557,
		EFBIG = 65558,
		EHOSTUNREACH = 65559,
		EIDRM = 65560,
		EILSEQ = 65561,
		EINPROGRESS = 65562,
		EINTR = 65563,
		EINVAL = 65564,
		EIO = 65565,
		EISCONN = 65566,
		EISDIR = 65567,
		ELOOP = 65568,
		EMFILE = 65569,
		EMLINK = 65570,
		EMSGSIZE = 65571,
		EMULTIHOP = 65572,
		ENAMETOOLONG = 65573,
		ENETDOWN = 65574,
		ENETRESET = 65575,
		ENETUNREACH = 65576,
		ENFILE = 65577,
		ENOBUFS = 65578,
		ENODEV = 65580,
		ENOENT = 65581,
		ENOEXEC = 65582,
		ENOLCK = 65583,
		ENOLINK = 65584,
		ENOMEM = 65585,
		ENOMSG = 65586,
		ENOPROTOOPT = 65587,
		ENOSPC = 65588,
		ENOSYS = 65591,
		ENOTCONN = 65592,
		ENOTDIR = 65593,
		ENOTEMPTY = 65594,
		ENOTRECOVERABLE = 65595,
		ENOTSOCK = 65596,
		ENOTSUP = 65597,
		ENOTTY = 65598,
		ENXIO = 65599,
		EOVERFLOW = 65600,
		EOWNERDEAD = 65601,
		EPERM = 65602,
		EPIPE = 65603,
		EPROTO = 65604,
		EPROTONOSUPPORT = 65605,
		EPROTOTYPE = 65606,
		ERANGE = 65607,
		EROFS = 65608,
		ESPIPE = 65609,
		ESRCH = 65610,
		ESTALE = 65611,
		ETIMEDOUT = 65613,
		ETXTBSY = 65614,
		EXDEV = 65615,
		ESOCKTNOSUPPORT = 65630,
		EPFNOSUPPORT = 65632,
		ESHUTDOWN = 65644,
		EHOSTDOWN = 65648,
		ENODATA = 65649,
		EHOSTNOTFOUND = 131073,
		ESOCKETERROR = 131074,
		EOPNOTSUPP = 65597,
		EWOULDBLOCK = 65542
	}

	internal struct ErrorInfo
	{
		private readonly Error _error;

		private int _rawErrno;

		internal Error Error => _error;

		internal int RawErrno
		{
			get
			{
				if (_rawErrno != -1)
				{
					return _rawErrno;
				}
				return _rawErrno = Sys.ConvertErrorPalToPlatform(_error);
			}
		}

		internal ErrorInfo(int errno)
		{
			_error = Sys.ConvertErrorPlatformToPal(errno);
			_rawErrno = errno;
		}

		internal ErrorInfo(Error error)
		{
			_error = error;
			_rawErrno = -1;
		}

		internal string GetErrorMessage()
		{
			return Sys.StrError(RawErrno);
		}

		public override string ToString()
		{
			return $"RawErrno: {RawErrno} Error: {Error} GetErrorMessage: {GetErrorMessage()}";
		}
	}

	internal static class Sys
	{
		internal enum UnixFileSystemTypes : uint
		{
			adfs = 44533u,
			affs = 44543u,
			afs = 1397113167u,
			anoninode = 151263540u,
			apfs = 26u,
			aufs = 1635083891u,
			autofs = 391u,
			autofs4 = 1833588077u,
			befs = 1111905073u,
			bdev = 1650746742u,
			bfs = 464386766u,
			bpf_fs = 3405662737u,
			binfmt_misc = 1112100429u,
			bootfs = 2775400441u,
			btrfs = 2435016766u,
			ceph = 12805120u,
			cgroup = 2613483u,
			cgroup2 = 1667723888u,
			cifs = 4283649346u,
			coda = 1937076805u,
			coherent = 19920823u,
			configfs = 1650812272u,
			cramfs = 684539205u,
			debugfs = 1684170528u,
			dev = 4979u,
			devpts = 7377u,
			ecryptfs = 61791u,
			efs = 4278867u,
			exofs = 24053u,
			ext = 4989u,
			ext2_old = 61265u,
			ext2 = 61267u,
			f2fs = 4076150800u,
			fat = 16390u,
			fd = 15731998u,
			fhgfs = 428016422u,
			fuse = 1702057286u,
			fusectl = 1702057283u,
			futexfs = 195894762u,
			gfs2 = 18225520u,
			gpfs = 1196443219u,
			hfs = 16964u,
			hfsplus = 18475u,
			hpfs = 4187351113u,
			hugetlbfs = 2508478710u,
			inodefs = 288389204u,
			inotifyfs = 732765674u,
			isofs = 38496u,
			jffs = 1984u,
			jffs2 = 29366u,
			jfs = 827541066u,
			kafs = 1799439955u,
			logfs = 3380511080u,
			lustre = 198183888u,
			minix_old = 4991u,
			minix = 5007u,
			minix2 = 9320u,
			minix2v2 = 9336u,
			minix3 = 19802u,
			mqueue = 427819522u,
			msdos = 19780u,
			nfs = 26985u,
			nfsd = 1852207972u,
			nilfs = 13364u,
			novell = 22092u,
			ntfs = 1397118030u,
			ocfs2 = 1952539503u,
			openprom = 40865u,
			omfs = 3264822663u,
			overlay = 2035054128u,
			overlayfs = 2035054159u,
			panfs = 2866260714u,
			pipefs = 1346981957u,
			proc = 40864u,
			pstore = 1634035564u,
			qnx4 = 47u,
			qnx6 = 1746473250u,
			ramfs = 2240043254u,
			reiserfs = 1382369651u,
			romfs = 29301u,
			rootfs = 1397114950u,
			rpc_pipefs = 1733912937u,
			sdcardfs = 1573531125u,
			securityfs = 1935894131u,
			selinuxfs = 4185718668u,
			smb = 20859u,
			smb2 = 4266872130u,
			sockfs = 1397703499u,
			squashfs = 1936814952u,
			sysfs = 1650812274u,
			sysv2 = 19920822u,
			sysv4 = 19920821u,
			tmpfs = 16914836u,
			tracefs = 1953653091u,
			ubifs = 604313861u,
			udf = 352400198u,
			ufs = 72020u,
			ufscigam = 1410924800u,
			ufs2 = 424935705u,
			usbdevice = 40866u,
			v9fs = 16914839u,
			vboxfs = 2020557398u,
			vmhgfs = 3133910204u,
			vxfs = 2768370933u,
			vzfs = 1448756819u,
			xenfs = 2881100148u,
			xenix = 19920820u,
			xfs = 1481003842u,
			xia = 19911021u,
			zfs = 801189825u
		}

		internal enum LockOperations
		{
			LOCK_SH = 1,
			LOCK_EX = 2,
			LOCK_NB = 4,
			LOCK_UN = 8
		}

		internal struct ProcessCpuInformation
		{
			internal ulong lastRecordedCurrentTime;

			internal ulong lastRecordedKernelTime;

			internal ulong lastRecordedUserTime;
		}

		internal struct IOVector
		{
			public unsafe byte* Base;

			public nuint Count;
		}

		internal enum LockType : short
		{
			F_RDLCK,
			F_WRLCK,
			F_UNLCK
		}

		internal enum SeekWhence
		{
			SEEK_SET,
			SEEK_CUR,
			SEEK_END
		}

		private struct AllMountPointsContext
		{
			internal List<string> _results;

			internal ExceptionDispatchInfo _exception;
		}

		[Flags]
		internal enum OpenFlags
		{
			O_RDONLY = 0,
			O_WRONLY = 1,
			O_RDWR = 2,
			O_CLOEXEC = 0x10,
			O_CREAT = 0x20,
			O_EXCL = 0x40,
			O_TRUNC = 0x80,
			O_SYNC = 0x100,
			O_NOFOLLOW = 0x200
		}

		internal enum FileAdvice
		{
			POSIX_FADV_NORMAL,
			POSIX_FADV_RANDOM,
			POSIX_FADV_SEQUENTIAL,
			POSIX_FADV_WILLNEED,
			POSIX_FADV_DONTNEED,
			POSIX_FADV_NOREUSE
		}

		internal enum NodeType
		{
			DT_UNKNOWN = 0,
			DT_FIFO = 1,
			DT_CHR = 2,
			DT_DIR = 4,
			DT_BLK = 6,
			DT_REG = 8,
			DT_LNK = 10,
			DT_SOCK = 12,
			DT_WHT = 14
		}

		internal struct DirectoryEntry
		{
			internal unsafe byte* Name;

			internal int NameLength;

			internal NodeType InodeType;

			internal unsafe ReadOnlySpan<char> GetName(Span<char> buffer)
			{
				ReadOnlySpan<byte> bytes = ((NameLength == -1) ? MemoryMarshal.CreateReadOnlySpanFromNullTerminated(Name) : new ReadOnlySpan<byte>(Name, NameLength));
				if (Encoding.UTF8.TryGetChars(bytes, buffer, out var charsWritten))
				{
					return buffer.Slice(0, charsWritten);
				}
				return Encoding.UTF8.GetString(bytes).AsSpan();
			}
		}

		internal struct FileStatus
		{
			internal FileStatusFlags Flags;

			internal int Mode;

			internal uint Uid;

			internal uint Gid;

			internal long Size;

			internal long ATime;

			internal long ATimeNsec;

			internal long MTime;

			internal long MTimeNsec;

			internal long CTime;

			internal long CTimeNsec;

			internal long BirthTime;

			internal long BirthTimeNsec;

			internal long Dev;

			internal long RDev;

			internal long Ino;

			internal uint UserFlags;
		}

		[Flags]
		internal enum FileStatusFlags
		{
			None = 0,
			HasBirthTime = 1
		}

		internal enum SysConfName
		{
			_SC_CLK_TCK = 1,
			_SC_PAGESIZE
		}

		internal enum SysLogPriority
		{
			LOG_EMERG,
			LOG_ALERT,
			LOG_CRIT,
			LOG_ERR,
			LOG_WARNING,
			LOG_NOTICE,
			LOG_INFO,
			LOG_DEBUG
		}

		internal struct TimeSpec
		{
			internal long TvSec;

			internal long TvNsec;
		}

		internal struct Passwd
		{
			internal unsafe byte* Name;

			internal unsafe byte* Password;

			internal uint UserId;

			internal uint GroupId;

			internal unsafe byte* UserInfo;

			internal unsafe byte* HomeDirectory;

			internal unsafe byte* Shell;
		}

		internal static readonly bool CanSetHiddenFlag = LChflagsCanSetHiddenFlag() != 0;

		internal static readonly bool SupportsHiddenFlag = CanGetHiddenFlag() != 0;

		internal static Error GetLastError()
		{
			return ConvertErrorPlatformToPal(Marshal.GetLastPInvokeError());
		}

		internal static ErrorInfo GetLastErrorInfo()
		{
			return new ErrorInfo(Marshal.GetLastPInvokeError());
		}

		internal unsafe static string StrError(int platformErrno)
		{
			byte* ptr = stackalloc byte[1024];
			byte* ptr2 = StrErrorR(platformErrno, ptr, 1024);
			if (ptr2 == null)
			{
				ptr2 = ptr;
			}
			return Marshal.PtrToStringUTF8((nint)ptr2);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPlatformToPal")]
		[SuppressGCTransition]
		internal static extern Error ConvertErrorPlatformToPal(int platformErrno);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ConvertErrorPalToPlatform")]
		[SuppressGCTransition]
		internal static extern int ConvertErrorPalToPlatform(Error error);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_StrErrorR")]
		private unsafe static extern byte* StrErrorR(int platformErrno, byte* buffer, int bufferSize);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ChDir", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int ChDir(string path)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_path_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_ChDir", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ChMod", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int ChMod(string path, int mode)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_path_native, mode);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_ChMod", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, int __mode_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FChMod", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FChMod(SafeFileHandle fd, int mode)
		{
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, mode);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FChMod", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, int __mode_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Close", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int Close(nint fd)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(fd);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Close", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_CopyFile", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int CopyFile(SafeFileHandle source, SafeFileHandle destination, long sourceLength)
		{
			nint num = 0;
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(destination);
				managedToUnmanagedIn2.FromManaged(source);
				num = managedToUnmanagedIn.ToUnmanaged();
				nint _source_native = managedToUnmanagedIn2.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_source_native, num, sourceLength);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_CopyFile", ExactSpelling = true)]
			static extern int __PInvoke(nint __source_native, nint __destination_native, long __sourceLength_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetDefaultSearchOrderPseudoHandle", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static nint GetDefaultSearchOrderPseudoHandle()
		{
			Marshal.SetLastSystemError(0);
			nint result = __PInvoke();
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetDefaultSearchOrderPseudoHandle", ExactSpelling = true)]
			static extern nint __PInvoke();
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetErrNo", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetErrNo")]
		[SuppressGCTransition]
		internal static extern int GetErrNo();

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SetErrNo", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SetErrNo")]
		[SuppressGCTransition]
		internal static extern void SetErrNo(int errorCode);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetFileSystemType")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private static uint GetFileSystemType(SafeFileHandle fd)
		{
			uint num = 0u;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetFileSystemType", ExactSpelling = true)]
			static extern uint __PInvoke(nint __fd_native);
		}

		internal static bool TryGetFileSystemType(SafeFileHandle fd, out UnixFileSystemTypes fileSystemType)
		{
			return (fileSystemType = (UnixFileSystemTypes)GetFileSystemType(fd)) != (UnixFileSystemTypes)0u;
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FLock", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FLock(SafeFileHandle fd, LockOperations operation)
		{
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, operation);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FLock", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, LockOperations __operation_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FLock", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FLock(nint fd, LockOperations operation)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(fd, operation);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FLock", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, LockOperations __operation_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FSync", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FSync(SafeFileHandle fd)
		{
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FSync", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FTruncate", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FTruncate(SafeFileHandle fd, long length)
		{
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, length);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FTruncate", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, long __length_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetCpuUtilization")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static double GetCpuUtilization(ref ProcessCpuInformation previousCpuInfo)
		{
			double result;
			fixed (ProcessCpuInformation* _previousCpuInfo_native = &previousCpuInfo)
			{
				result = __PInvoke(_previousCpuInfo_native);
			}
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetCpuUtilization", ExactSpelling = true)]
			static extern unsafe double __PInvoke(ProcessCpuInformation* __previousCpuInfo_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetCwd", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static byte* GetCwd(byte* buffer, int bufferLength)
		{
			Marshal.SetLastSystemError(0);
			byte* result = __PInvoke(buffer, bufferLength);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetCwd", ExactSpelling = true)]
			static extern unsafe byte* __PInvoke(byte* __buffer_native, int __bufferLength_native);
		}

		internal unsafe static string GetCwd()
		{
			string cwdHelper = GetCwdHelper(stackalloc byte[256], 256);
			if (cwdHelper != null)
			{
				return cwdHelper;
			}
			int num = 256;
			while (true)
			{
				num = checked(num * 2);
				byte[] array = ArrayPool<byte>.Shared.Rent(num);
				try
				{
					fixed (byte* ptr = &array[0])
					{
						cwdHelper = GetCwdHelper(ptr, array.Length);
						if (cwdHelper != null)
						{
							return cwdHelper;
						}
					}
				}
				finally
				{
					ArrayPool<byte>.Shared.Return(array);
				}
			}
		}

		private unsafe static string GetCwdHelper(byte* ptr, int bufferSize)
		{
			if (GetCwd(ptr, bufferSize) != null)
			{
				return Marshal.PtrToStringUTF8((nint)ptr);
			}
			ErrorInfo lastErrorInfo = GetLastErrorInfo();
			if (lastErrorInfo.Error == Error.ERANGE)
			{
				return null;
			}
			throw GetExceptionForIoErrno(lastErrorInfo);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetDefaultTimeZone", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static string GetDefaultTimeZone()
		{
			bool flag = false;
			string result = null;
			byte* unmanaged = default(byte*);
			int lastSystemError;
			try
			{
				Marshal.SetLastSystemError(0);
				unmanaged = __PInvoke();
				lastSystemError = Marshal.GetLastSystemError();
				flag = true;
				result = Utf8StringMarshaller.ConvertToManaged(unmanaged);
			}
			finally
			{
				if (flag)
				{
					Utf8StringMarshaller.Free(unmanaged);
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetDefaultTimeZone", ExactSpelling = true)]
			static extern unsafe byte* __PInvoke();
		}

		[LibraryImport("libSystem.Native", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "SystemNative_GetEnv")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static nint GetEnv(string name)
		{
			nint num = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(name, buffer);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged());
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetEnv", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __name_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetEnviron", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetEnviron")]
		internal static extern nint GetEnviron();

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_FreeEnviron", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FreeEnviron")]
		internal static extern void FreeEnviron(nint environ);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetHostName", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int GetHostName(byte* name, int nameLength)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(name, nameLength);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetHostName", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __name_native, int __nameLength_native);
		}

		internal unsafe static string GetHostName()
		{
			if (false)
			{
			}
			byte* num = stackalloc byte[256];
			int hostName = GetHostName(num, 256);
			if (hostName != 0)
			{
				throw new InvalidOperationException($"{"GetHostName"}: {hostName}");
			}
			num[255] = 0;
			return Marshal.PtrToStringUTF8((nint)num);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetOSArchitecture", ExactSpelling = true)]
		[SuppressGCTransition]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetOSArchitecture")]
		internal static extern int GetOSArchitecture();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetProcessPath", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static string GetProcessPath()
		{
			bool flag = false;
			string result = null;
			byte* unmanaged = default(byte*);
			int lastSystemError;
			try
			{
				Marshal.SetLastSystemError(0);
				unmanaged = __PInvoke();
				lastSystemError = Marshal.GetLastSystemError();
				flag = true;
				result = Utf8StringMarshaller.ConvertToManaged(unmanaged);
			}
			finally
			{
				if (flag)
				{
					Utf8StringMarshaller.Free(unmanaged);
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetProcessPath", ExactSpelling = true)]
			static extern unsafe byte* __PInvoke();
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetNonCryptographicallySecureRandomBytes", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetNonCryptographicallySecureRandomBytes")]
		internal unsafe static extern void GetNonCryptographicallySecureRandomBytes(byte* buffer, int length);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetCryptographicallySecureRandomBytes", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetCryptographicallySecureRandomBytes")]
		internal unsafe static extern int GetCryptographicallySecureRandomBytes(byte* buffer, int length);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetSystemTimeAsTicks", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetSystemTimeAsTicks")]
		[SuppressGCTransition]
		internal static extern long GetSystemTimeAsTicks();

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetLowResolutionTimestamp", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetLowResolutionTimestamp")]
		[SuppressGCTransition]
		internal static extern long GetLowResolutionTimestamp();

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetTimestamp", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetTimestamp")]
		[SuppressGCTransition]
		internal static extern long GetTimestamp();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetUnixRelease", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		public unsafe static string GetUnixRelease()
		{
			bool flag = false;
			string result = null;
			byte* unmanaged = default(byte*);
			int lastSystemError;
			try
			{
				Marshal.SetLastSystemError(0);
				unmanaged = __PInvoke();
				lastSystemError = Marshal.GetLastSystemError();
				flag = true;
				result = Utf8StringMarshaller.ConvertToManaged(unmanaged);
			}
			finally
			{
				if (flag)
				{
					Utf8StringMarshaller.Free(unmanaged);
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetUnixRelease", ExactSpelling = true)]
			static extern unsafe byte* __PInvoke();
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LChflags", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int LChflags(string path, uint flags)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_path_native, flags);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_LChflags", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, uint __flags_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FChflags", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FChflags(SafeHandle fd, uint flags)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, flags);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FChflags", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, uint __flags_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_LChflagsCanSetHiddenFlag", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LChflagsCanSetHiddenFlag")]
		[SuppressGCTransition]
		private static extern int LChflagsCanSetHiddenFlag();

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_CanGetHiddenFlag", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_CanGetHiddenFlag")]
		[SuppressGCTransition]
		private static extern int CanGetHiddenFlag();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Link", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Link(string source, string link)
		{
			byte* ptr = default(byte*);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				string managed = link;
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(managed, buffer);
				managed = source;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn2.FromManaged(managed, buffer);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				byte* _source_native = managedToUnmanagedIn2.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_source_native, ptr);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Link", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __source_native, byte* __link_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LockFileRegion", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int LockFileRegion(SafeHandle fd, long offset, long length, LockType lockType)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, offset, length, lockType);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_LockFileRegion", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, long __offset_native, long __length_native, LockType __lockType_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Create", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Create")]
		internal static extern nint LowLevelMonitor_Create();

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Destroy", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Destroy")]
		internal static extern void LowLevelMonitor_Destroy(nint monitor);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Acquire", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Acquire")]
		internal static extern void LowLevelMonitor_Acquire(nint monitor);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Release", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Release")]
		internal static extern void LowLevelMonitor_Release(nint monitor);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Wait", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Wait")]
		internal static extern void LowLevelMonitor_Wait(nint monitor);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_TimedWait")]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static bool LowLevelMonitor_TimedWait(nint monitor, int timeoutMilliseconds)
		{
			return __PInvoke(monitor, timeoutMilliseconds) != 0;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_TimedWait", ExactSpelling = true)]
			static extern int __PInvoke(nint __monitor_native, int __timeoutMilliseconds_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Signal_Release", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LowLevelMonitor_Signal_Release")]
		internal static extern void LowLevelMonitor_Signal_Release(nint monitor);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LSeek", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static long LSeek(SafeFileHandle fd, long offset, SeekWhence whence)
		{
			long result = 0L;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, offset, whence);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_LSeek", ExactSpelling = true)]
			static extern long __PInvoke(nint __fd_native, long __offset_native, SeekWhence __whence_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_AlignedAlloc", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_AlignedAlloc")]
		internal unsafe static extern void* AlignedAlloc(nuint alignment, nuint size);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_AlignedFree", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_AlignedFree")]
		internal unsafe static extern void AlignedFree(void* ptr);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_AlignedRealloc", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_AlignedRealloc")]
		internal unsafe static extern void* AlignedRealloc(void* ptr, nuint alignment, nuint new_size);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Calloc", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Calloc")]
		internal unsafe static extern void* Calloc(nuint num, nuint size);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Free", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Free")]
		internal unsafe static extern void Free(void* ptr);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Malloc", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Malloc")]
		internal unsafe static extern void* Malloc(nuint size);

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_Realloc", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Realloc")]
		internal unsafe static extern void* Realloc(void* ptr, nuint new_size);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MkDir", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int MkDir(ref byte path, int mode)
		{
			int result;
			int lastSystemError;
			fixed (byte* _path_native = &path)
			{
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_path_native, mode);
				lastSystemError = Marshal.GetLastSystemError();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MkDir", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, int __mode_native);
		}

		internal static int MkDir(ReadOnlySpan<char> path, int mode)
		{
			Span<byte> initialBuffer = stackalloc byte[256];
			using ValueUtf8Converter valueUtf8Converter = new ValueUtf8Converter(initialBuffer);
			return MkDir(ref MemoryMarshal.GetReference(valueUtf8Converter.ConvertAndTerminateString(path)), mode);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MkdTemp", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static byte* MkdTemp(byte* template)
		{
			Marshal.SetLastSystemError(0);
			byte* result = __PInvoke(template);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MkdTemp", ExactSpelling = true)]
			static extern unsafe byte* __PInvoke(byte* __template_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_MksTemps", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static nint MksTemps(byte* template, int suffixlen)
		{
			Marshal.SetLastSystemError(0);
			nint result = __PInvoke(template, suffixlen);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_MksTemps", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __template_native, int __suffixlen_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetAllMountPoints", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetAllMountPoints")]
		private unsafe static extern int GetAllMountPoints(delegate* unmanaged<void*, byte*, void> onFound, void* context);

		[UnmanagedCallersOnly]
		private unsafe static void AddMountPoint(void* context, byte* name)
		{
			try
			{
				((AllMountPointsContext*)context)->_results.Add(Marshal.PtrToStringUTF8((nint)name));
			}
			catch (Exception source)
			{
				Unsafe.Write(&((AllMountPointsContext*)context)->_exception, ExceptionDispatchInfo.Capture(source));
			}
		}

		internal unsafe static string[] GetAllMountPoints()
		{
			if (false)
			{
			}
			AllMountPointsContext allMountPointsContext = new AllMountPointsContext
			{
				_results = new List<string>()
			};
			GetAllMountPoints((delegate* unmanaged<void*, byte*, void>)(delegate*<void*, byte*, void>)(&AddMountPoint), &allMountPointsContext);
			allMountPointsContext._exception?.Throw();
			return allMountPointsContext._results.ToArray();
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Open", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static SafeFileHandle Open(string filename, OpenFlags flags, int mode)
		{
			bool flag = false;
			SafeFileHandle result = null;
			nint num = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut managedToUnmanagedOut = new SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedOut();
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(filename, buffer);
				byte* _filename_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				num = __PInvoke(_filename_native, flags, mode);
				lastSystemError = Marshal.GetLastSystemError();
				flag = true;
				managedToUnmanagedOut.FromUnmanaged(num);
				result = managedToUnmanagedOut.ToManaged();
			}
			finally
			{
				if (flag)
				{
					managedToUnmanagedOut.Free();
				}
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Open", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __filename_native, OpenFlags __flags_native, int __mode_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_PosixFAdvise", SetLastError = false)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int PosixFAdvise(SafeFileHandle fd, long offset, long length, FileAdvice advice)
		{
			int num = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				return __PInvoke(managedToUnmanagedIn.ToUnmanaged(), offset, length, advice);
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_PosixFAdvise", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, long __offset_native, long __length_native, FileAdvice __advice_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FAllocate", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int FAllocate(SafeFileHandle fd, long offset, long length)
		{
			int result = 0;
			SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeFileHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, offset, length);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FAllocate", ExactSpelling = true)]
			static extern int __PInvoke(nint __fd_native, long __offset_native, long __length_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_PRead", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int PRead(SafeHandle fd, byte* buffer, int bufferSize, long fileOffset)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, buffer, bufferSize, fileOffset);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_PRead", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __bufferSize_native, long __fileOffset_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_PReadV", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static long PReadV(SafeHandle fd, IOVector* vectors, int vectorCount, long fileOffset)
		{
			long result = 0L;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, vectors, vectorCount, fileOffset);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_PReadV", ExactSpelling = true)]
			static extern unsafe long __PInvoke(nint __fd_native, IOVector* __vectors_native, int __vectorCount_native, long __fileOffset_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_PWrite", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int PWrite(SafeHandle fd, byte* buffer, int bufferSize, long fileOffset)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, buffer, bufferSize, fileOffset);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_PWrite", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __bufferSize_native, long __fileOffset_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_PWriteV", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static long PWriteV(SafeHandle fd, IOVector* vectors, int vectorCount, long fileOffset)
		{
			long result = 0L;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, vectors, vectorCount, fileOffset);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_PWriteV", ExactSpelling = true)]
			static extern unsafe long __PInvoke(nint __fd_native, IOVector* __vectors_native, int __vectorCount_native, long __fileOffset_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Read", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Read(SafeHandle fd, byte* buffer, int count)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, buffer, count);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Read", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __count_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_OpenDir", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static nint OpenDir(string path)
		{
			nint result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_path_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_OpenDir", ExactSpelling = true)]
			static extern unsafe nint __PInvoke(byte* __path_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_ReadDir", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ReadDir")]
		internal unsafe static extern int ReadDir(nint dir, DirectoryEntry* outputEntry);

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_CloseDir", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static int CloseDir(nint dir)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(dir);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_CloseDir", ExactSpelling = true)]
			static extern int __PInvoke(nint __dir_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_ReadLink", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int ReadLink(ref byte path, ref byte buffer, int bufferSize)
		{
			int result;
			int lastSystemError;
			fixed (byte* _buffer_native = &buffer)
			{
				fixed (byte* _path_native = &path)
				{
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_path_native, _buffer_native, bufferSize);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_ReadLink", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, byte* __buffer_native, int __bufferSize_native);
		}

		internal static string ReadLink(ReadOnlySpan<char> path)
		{
			Span<byte> initialBuffer = stackalloc byte[256];
			using ValueUtf8Converter valueUtf8Converter = new ValueUtf8Converter(initialBuffer);
			Span<byte> span = stackalloc byte[256];
			byte[] array = null;
			ref byte reference = ref MemoryMarshal.GetReference(valueUtf8Converter.ConvertAndTerminateString(path));
			while (true)
			{
				int num = 0;
				try
				{
					int num2 = ReadLink(ref reference, ref MemoryMarshal.GetReference(span), span.Length);
					if (num2 < 0)
					{
						num = Marshal.GetLastPInvokeError();
						return null;
					}
					if (num2 < span.Length)
					{
						return Encoding.UTF8.GetString(span.Slice(0, num2));
					}
				}
				finally
				{
					if (array != null)
					{
						ArrayPool<byte>.Shared.Return(array);
					}
					if (num > 0)
					{
						Marshal.SetLastPInvokeError(num);
					}
				}
				array = ArrayPool<byte>.Shared.Rent(span.Length * 2);
				span = array;
			}
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Rename", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Rename(string oldPath, string newPath)
		{
			byte* ptr = default(byte*);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				string managed = newPath;
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(managed, buffer);
				managed = oldPath;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn2.FromManaged(managed, buffer);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				byte* _oldPath_native = managedToUnmanagedIn2.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_oldPath_native, ptr);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Rename", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __oldPath_native, byte* __newPath_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Rename", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Rename(ref byte oldPath, ref byte newPath)
		{
			int result;
			int lastSystemError;
			fixed (byte* _newPath_native = &newPath)
			{
				fixed (byte* _oldPath_native = &oldPath)
				{
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_oldPath_native, _newPath_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Rename", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __oldPath_native, byte* __newPath_native);
		}

		internal static int Rename(ReadOnlySpan<char> oldPath, ReadOnlySpan<char> newPath)
		{
			Span<byte> initialBuffer = stackalloc byte[256];
			ValueUtf8Converter valueUtf8Converter = new ValueUtf8Converter(initialBuffer);
			initialBuffer = stackalloc byte[256];
			ValueUtf8Converter valueUtf8Converter2 = new ValueUtf8Converter(initialBuffer);
			int result = Rename(ref MemoryMarshal.GetReference(valueUtf8Converter2.ConvertAndTerminateString(oldPath)), ref MemoryMarshal.GetReference(valueUtf8Converter.ConvertAndTerminateString(newPath)));
			valueUtf8Converter.Dispose();
			valueUtf8Converter2.Dispose();
			return result;
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_RmDir", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int RmDir(string path)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_path_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_RmDir", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_SchedGetCpu", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SchedGetCpu")]
		[SuppressGCTransition]
		internal static extern int SchedGetCpu();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FStat", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int FStat(SafeHandle fd, out FileStatus output)
		{
			output = default(FileStatus);
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				fixed (FileStatus* _output_native = &output)
				{
					nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_fd_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FStat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, FileStatus* __output_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Stat", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Stat(string path, out FileStatus output)
		{
			output = default(FileStatus);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				fixed (FileStatus* _output_native = &output)
				{
					byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_path_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Stat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, FileStatus* __output_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LStat", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int LStat(string path, out FileStatus output)
		{
			output = default(FileStatus);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				fixed (FileStatus* _output_native = &output)
				{
					byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_path_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_LStat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, FileStatus* __output_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Stat", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Stat(ref byte path, out FileStatus output)
		{
			output = default(FileStatus);
			int result;
			int lastSystemError;
			fixed (FileStatus* _output_native = &output)
			{
				fixed (byte* _path_native = &path)
				{
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_path_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Stat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, FileStatus* __output_native);
		}

		internal static int Stat(ReadOnlySpan<char> path, out FileStatus output)
		{
			Span<byte> initialBuffer = stackalloc byte[256];
			ValueUtf8Converter valueUtf8Converter = new ValueUtf8Converter(initialBuffer);
			int result = Stat(ref MemoryMarshal.GetReference(valueUtf8Converter.ConvertAndTerminateString(path)), out output);
			valueUtf8Converter.Dispose();
			return result;
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_LStat", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int LStat(ref byte path, out FileStatus output)
		{
			output = default(FileStatus);
			int result;
			int lastSystemError;
			fixed (FileStatus* _output_native = &output)
			{
				fixed (byte* _path_native = &path)
				{
					Marshal.SetLastSystemError(0);
					result = __PInvoke(_path_native, _output_native);
					lastSystemError = Marshal.GetLastSystemError();
				}
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_LStat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, FileStatus* __output_native);
		}

		internal static int LStat(ReadOnlySpan<char> path, out FileStatus output)
		{
			Span<byte> initialBuffer = stackalloc byte[256];
			ValueUtf8Converter valueUtf8Converter = new ValueUtf8Converter(initialBuffer);
			int result = LStat(ref MemoryMarshal.GetReference(valueUtf8Converter.ConvertAndTerminateString(path)), out output);
			valueUtf8Converter.Dispose();
			return result;
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SymLink", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int SymLink(string target, string linkPath)
		{
			byte* ptr = default(byte*);
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				string managed = linkPath;
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(managed, buffer);
				managed = target;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn2.FromManaged(managed, buffer);
				ptr = managedToUnmanagedIn.ToUnmanaged();
				byte* _target_native = managedToUnmanagedIn2.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_target_native, ptr);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SymLink", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __target_native, byte* __linkPath_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SysConf", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal static long SysConf(SysConfName name)
		{
			Marshal.SetLastSystemError(0);
			long result = __PInvoke(name);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SysConf", ExactSpelling = true)]
			static extern long __PInvoke(SysConfName __name_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_SysLog", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static void SysLog(SysLogPriority priority, string message, string arg1)
		{
			byte* ptr = default(byte*);
			byte* ptr2 = default(byte*);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				string managed = arg1;
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(managed, buffer);
				managed = message;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn2.FromManaged(managed, buffer);
				ptr2 = managedToUnmanagedIn.ToUnmanaged();
				ptr = managedToUnmanagedIn2.ToUnmanaged();
				__PInvoke(priority, ptr, ptr2);
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
			}
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_SysLog", ExactSpelling = true)]
			static extern unsafe void __PInvoke(SysLogPriority __priority_native, byte* __message_native, byte* __arg1_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_TryGetUInt32OSThreadId", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_TryGetUInt32OSThreadId")]
		internal static extern uint TryGetUInt32OSThreadId();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Unlink", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Unlink(string pathname)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(pathname, buffer);
				byte* _pathname_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_pathname_native);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Unlink", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __pathname_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_UTimensat", StringMarshalling = StringMarshalling.Utf8, SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int UTimensat(string path, TimeSpec* times)
		{
			int result = 0;
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(path, buffer);
				byte* _path_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_path_native, times);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_UTimensat", ExactSpelling = true)]
			static extern unsafe int __PInvoke(byte* __path_native, TimeSpec* __times_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_FUTimens", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int FUTimens(SafeHandle fd, TimeSpec* times)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, times);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_FUTimens", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, TimeSpec* __times_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Write", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Write(SafeHandle fd, byte* buffer, int bufferSize)
		{
			int result = 0;
			SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn managedToUnmanagedIn = default(SafeHandleMarshaller<SafeHandle>.ManagedToUnmanagedIn);
			int lastSystemError;
			try
			{
				managedToUnmanagedIn.FromManaged(fd);
				nint _fd_native = managedToUnmanagedIn.ToUnmanaged();
				Marshal.SetLastSystemError(0);
				result = __PInvoke(_fd_native, buffer, bufferSize);
				lastSystemError = Marshal.GetLastSystemError();
			}
			finally
			{
				managedToUnmanagedIn.Free();
			}
			Marshal.SetLastPInvokeError(lastSystemError);
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Write", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __bufferSize_native);
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_Write", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int Write(nint fd, byte* buffer, int bufferSize)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(fd, buffer, bufferSize);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_Write", ExactSpelling = true)]
			static extern unsafe int __PInvoke(nint __fd_native, byte* __buffer_native, int __bufferSize_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetEUid", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetEUid")]
		internal static extern uint GetEUid();

		internal unsafe static bool IsMemberOfGroup(uint gid)
		{
			if (gid == GetEGid())
			{
				return true;
			}
			Span<uint> span = stackalloc uint[64];
			while (true)
			{
				int groups2;
				fixed (uint* groups = span)
				{
					groups2 = GetGroups(span.Length, groups);
				}
				if (groups2 >= 0)
				{
					return ((ReadOnlySpan<uint>)span.Slice(0, groups2)).IndexOf(gid) >= 0;
				}
				if (groups2 != -1 || GetLastError() != Error.EINVAL)
				{
					break;
				}
				span = new uint[span.Length * 2];
			}
			return false;
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetEGid", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetEGid")]
		private static extern uint GetEGid();

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetGroups", SetLastError = true)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static int GetGroups(int ngroups, uint* groups)
		{
			Marshal.SetLastSystemError(0);
			int result = __PInvoke(ngroups, groups);
			Marshal.SetLastPInvokeError(Marshal.GetLastSystemError());
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetGroups", ExactSpelling = true)]
			static extern unsafe int __PInvoke(int __ngroups_native, uint* __groups_native);
		}

		internal unsafe static string GetUserNameFromPasswd(uint uid)
		{
			byte* buf = stackalloc byte[256];
			if (TryGetUserNameFromPasswd(uid, buf, 256, out var username))
			{
				return username ?? string.Empty;
			}
			int num = 256;
			while (true)
			{
				num *= 2;
				byte[] array = new byte[num];
				fixed (byte* buf2 = &array[0])
				{
					if (TryGetUserNameFromPasswd(uid, buf2, array.Length, out username))
					{
						return username ?? string.Empty;
					}
				}
			}
		}

		private unsafe static bool TryGetUserNameFromPasswd(uint uid, byte* buf, int bufLen, out string username)
		{
			Passwd pwd;
			int pwUidR = GetPwUidR(uid, out pwd, buf, bufLen);
			switch (pwUidR)
			{
			case 0:
				username = Marshal.PtrToStringUTF8((nint)pwd.Name);
				return true;
			case -1:
				username = null;
				return true;
			default:
			{
				ErrorInfo errorInfo = new ErrorInfo(pwUidR);
				if (errorInfo.Error == Error.ERANGE)
				{
					username = null;
					return false;
				}
				throw new IOException(errorInfo.GetErrorMessage(), errorInfo.RawErrno);
			}
			}
		}

		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetPwUidR", SetLastError = false)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		internal unsafe static int GetPwUidR(uint uid, out Passwd pwd, byte* buf, int bufLen)
		{
			pwd = default(Passwd);
			int result;
			fixed (Passwd* _pwd_native = &pwd)
			{
				result = __PInvoke(uid, _pwd_native, buf, bufLen);
			}
			return result;
			[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetPwUidR", ExactSpelling = true)]
			static extern unsafe int __PInvoke(uint __uid_native, Passwd* __pwd_native, byte* __buf_native, int __bufLen_native);
		}

		[DllImport("libSystem.Native", EntryPoint = "SystemNative_GetPid", ExactSpelling = true)]
		[LibraryImport("libSystem.Native", EntryPoint = "SystemNative_GetPid")]
		internal static extern int GetPid();
	}

	internal static class procfs
	{
		internal enum ProcPid
		{
			Invalid = -1,
			Self
		}

		internal struct ParsedStatus
		{
			internal ulong VmHWM;

			internal ulong VmRSS;

			internal ulong VmData;

			internal ulong VmSwap;

			internal ulong VmSize;

			internal ulong VmPeak;
		}

		internal static string GetStatusFilePathForProcess(ProcPid pid)
		{
			if (pid == ProcPid.Self)
			{
				return "/proc/self/status";
			}
			IFormatProvider formatProvider = null;
			IFormatProvider provider = formatProvider;
			Span<char> initialBuffer = stackalloc char[256];
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
			handler.AppendFormatted("/proc/");
			handler.AppendFormatted((uint)pid);
			handler.AppendFormatted("/status");
			return string.Create(provider, initialBuffer, ref handler);
		}

		internal static bool TryReadStatusFile(ProcPid pid, out ParsedStatus result)
		{
			return TryParseStatusFile(GetStatusFilePathForProcess(pid), out result);
		}

		internal static bool TryParseStatusFile(string statusFilePath, out ParsedStatus result)
		{
			if (!TryReadFile(statusFilePath, out var contents))
			{
				result = default(ParsedStatus);
				return false;
			}
			ParsedStatus parsedStatus = default(ParsedStatus);
			SpanLineEnumerator enumerator = contents.AsSpan().EnumerateLines().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ReadOnlySpan<char> current = enumerator.Current;
					int num = current.IndexOf(':');
					if (num == -1)
					{
						break;
					}
					ReadOnlySpan<char> readOnlySpan = current.Slice(num + 1);
					switch (current.Slice(0, num))
					{
					case "VmHWM":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmHWM);
						break;
					case "VmRSS":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmRSS);
						break;
					case "VmData":
					{
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out var result3);
						parsedStatus.VmData += result3;
						break;
					}
					case "VmSwap":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmSwap);
						break;
					case "VmSize":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmSize);
						break;
					case "VmPeak":
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out parsedStatus.VmPeak);
						break;
					case "VmStk":
					{
						ulong.TryParse(readOnlySpan.Slice(0, readOnlySpan.Length - 3), out var result2);
						parsedStatus.VmData += result2;
						break;
					}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
			}
			parsedStatus.VmData *= 1024uL;
			parsedStatus.VmPeak *= 1024uL;
			parsedStatus.VmSize *= 1024uL;
			parsedStatus.VmSwap *= 1024uL;
			parsedStatus.VmRSS *= 1024uL;
			parsedStatus.VmHWM *= 1024uL;
			result = parsedStatus;
			return true;
		}

		private static bool TryReadFile(string path, [NotNullWhen(true)] out string contents)
		{
			byte[] array = ArrayPool<byte>.Shared.Rent(4096);
			int num = 0;
			try
			{
				using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1, useAsync: false);
				while (true)
				{
					int num2 = fileStream.Read(array, num, array.Length - num);
					if (num2 == 0)
					{
						break;
					}
					num += num2;
					if (num >= array.Length)
					{
						byte[] array2 = ArrayPool<byte>.Shared.Rent(array.Length * 2);
						Array.Copy(array, array2, array.Length);
						byte[] array3 = array;
						array = array2;
						ArrayPool<byte>.Shared.Return(array3);
					}
				}
				contents = Encoding.UTF8.GetString(array, 0, num);
				return true;
			}
			catch (Exception ex) when (ex is IOException || ex.InnerException is IOException)
			{
				contents = null;
				return false;
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}
	}

	internal static class Logcat
	{
		internal enum LogLevel
		{
			Unknown,
			Default,
			Verbose,
			Debug,
			Info,
			Warn,
			Error,
			Fatal,
			Silent
		}

		[LibraryImport("liblog", StringMarshalling = StringMarshalling.Utf8)]
		[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "10.0.14.42308")]
		private unsafe static void __android_log_print(LogLevel level, string tag, string format, string args, nint ptr)
		{
			byte* ptr2 = default(byte*);
			byte* ptr3 = default(byte*);
			byte* ptr4 = default(byte*);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn2 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			Utf8StringMarshaller.ManagedToUnmanagedIn managedToUnmanagedIn3 = default(Utf8StringMarshaller.ManagedToUnmanagedIn);
			try
			{
				string managed = args;
				Span<byte> buffer = stackalloc byte[256];
				managedToUnmanagedIn.FromManaged(managed, buffer);
				managed = format;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn2.FromManaged(managed, buffer);
				managed = tag;
				buffer = stackalloc byte[256];
				managedToUnmanagedIn3.FromManaged(managed, buffer);
				ptr4 = managedToUnmanagedIn.ToUnmanaged();
				ptr3 = managedToUnmanagedIn2.ToUnmanaged();
				ptr2 = managedToUnmanagedIn3.ToUnmanaged();
				__PInvoke(level, ptr2, ptr3, ptr4, ptr);
			}
			finally
			{
				managedToUnmanagedIn.Free();
				managedToUnmanagedIn2.Free();
				managedToUnmanagedIn3.Free();
			}
			[DllImport("liblog", EntryPoint = "__android_log_print", ExactSpelling = true)]
			static extern unsafe void __PInvoke(LogLevel __level_native, byte* __tag_native, byte* __format_native, byte* __args_native, nint __ptr_native);
		}

		internal static void AndroidLogPrint(LogLevel level, string tag, string message)
		{
			__android_log_print(level, tag, "%s", message, IntPtr.Zero);
		}
	}

	internal static bool CallStringMethod<TArg1, TArg2, TArg3>(SpanFunc<char, TArg1, TArg2, TArg3, Globalization.ResultCode> interopCall, TArg1 arg1, TArg2 arg2, TArg3 arg3, out string result)
	{
		Span<char> span = stackalloc char[256];
		switch (interopCall(span, arg1, arg2, arg3))
		{
		case Globalization.ResultCode.Success:
			result = span.Slice(0, ((ReadOnlySpan<char>)span).IndexOf('\0')).ToString();
			return true;
		case Globalization.ResultCode.InsufficientBuffer:
			span = new char[1280];
			if (interopCall(span, arg1, arg2, arg3) == Globalization.ResultCode.Success)
			{
				result = span.Slice(0, ((ReadOnlySpan<char>)span).IndexOf('\0')).ToString();
				return true;
			}
			break;
		}
		result = null;
		return false;
	}

	private static void ThrowExceptionForIoErrno(ErrorInfo errorInfo, string path, bool isDirError)
	{
		throw GetExceptionForIoErrno(errorInfo, path, isDirError);
	}

	internal static void CheckIo(Error error, string path = null, bool isDirError = false)
	{
		if (error != Error.SUCCESS)
		{
			ThrowExceptionForIoErrno(error.Info(), path, isDirError);
		}
	}

	internal static long CheckIo(long result, string path = null, bool isDirError = false)
	{
		if (result < 0)
		{
			ThrowExceptionForIoErrno(Sys.GetLastErrorInfo(), path, isDirError);
		}
		return result;
	}

	internal static void ThrowIOExceptionForLastError()
	{
		ThrowExceptionForIoErrno(Sys.GetLastErrorInfo(), null, isDirError: false);
	}

	internal static int CheckIo(int result, string path = null, bool isDirError = false)
	{
		CheckIo((long)result, path, isDirError);
		return result;
	}

	internal static nint CheckIo(nint result, string path = null, bool isDirError = false)
	{
		CheckIo((long)result, path, isDirError);
		return result;
	}

	internal static Exception GetExceptionForIoErrno(ErrorInfo errorInfo, string path = null, bool isDirError = false)
	{
		Error error = errorInfo.Error;
		if (error <= Error.EEXIST)
		{
			if (error <= Error.EAGAIN)
			{
				if (error == Error.EACCES)
				{
					goto IL_00f0;
				}
				if (error == Error.EAGAIN)
				{
					if (string.IsNullOrEmpty(path))
					{
						return new IOException("IO_SharingViolation_NoFileName", errorInfo.RawErrno);
					}
					return new IOException(SR.Format("IO_SharingViolation_File", path), errorInfo.RawErrno);
				}
			}
			else
			{
				if (error == Error.EBADF)
				{
					goto IL_00f0;
				}
				switch (error)
				{
				case Error.ECANCELED:
					return new OperationCanceledException();
				case Error.EEXIST:
					if (!string.IsNullOrEmpty(path))
					{
						return new IOException(SR.Format("IO_FileExists_Name", path), errorInfo.RawErrno);
					}
					break;
				}
			}
		}
		else
		{
			if (error > Error.ENAMETOOLONG)
			{
				if (error != Error.ENOENT)
				{
					if (error != Error.ENOTDIR)
					{
						if (error == Error.EPERM)
						{
							goto IL_00f0;
						}
						goto IL_01aa;
					}
				}
				else if (!isDirError && (path == null || ParentDirectoryExists(path)))
				{
					if (string.IsNullOrEmpty(path))
					{
						return new FileNotFoundException("IO_FileNotFound");
					}
					return new FileNotFoundException(SR.Format("IO_FileNotFound_FileName", path), path);
				}
				if (string.IsNullOrEmpty(path))
				{
					return new DirectoryNotFoundException("IO_PathNotFound_NoPathName");
				}
				return new DirectoryNotFoundException(SR.Format("IO_PathNotFound_Path", path));
			}
			switch (error)
			{
			case Error.ENAMETOOLONG:
				if (string.IsNullOrEmpty(path))
				{
					return new PathTooLongException("IO_PathTooLong");
				}
				return new PathTooLongException(SR.Format("IO_PathTooLong_Path", path));
			case Error.EFBIG:
				return new ArgumentOutOfRangeException("value", "ArgumentOutOfRange_FileLengthTooBig");
			}
		}
		goto IL_01aa;
		IL_00f0:
		Exception iOException = GetIOException(errorInfo);
		if (string.IsNullOrEmpty(path))
		{
			return new UnauthorizedAccessException("UnauthorizedAccess_IODenied_NoPathName", iOException);
		}
		return new UnauthorizedAccessException(SR.Format("UnauthorizedAccess_IODenied_Path", path), iOException);
		IL_01aa:
		return GetIOException(errorInfo, path);
		static bool ParentDirectoryExists(string fullPath)
		{
			return Directory.Exists(Path.GetDirectoryName(Path.TrimEndingDirectorySeparator(fullPath)));
		}
	}

	internal static Exception GetIOException(ErrorInfo errorInfo, string path = null)
	{
		string errorMessage = errorInfo.GetErrorMessage();
		return new IOException(string.IsNullOrEmpty(path) ? errorMessage : (errorMessage + " : '" + path + "'"), errorInfo.RawErrno);
	}

	internal unsafe static void GetRandomBytes(byte* buffer, int length)
	{
		Sys.GetNonCryptographicallySecureRandomBytes(buffer, length);
	}

	internal unsafe static void GetCryptographicallySecureRandomBytes(byte* buffer, int length)
	{
		if (Sys.GetCryptographicallySecureRandomBytes(buffer, length) != 0)
		{
			throw new CryptographicException();
		}
	}
}

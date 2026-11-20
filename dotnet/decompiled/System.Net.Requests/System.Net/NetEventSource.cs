using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Net;

[EventSource(Name = "Private.InternalDiagnostics.System.Net.Requests")]
internal sealed class NetEventSource : EventSource
{
	public static class Keywords
	{
		public const EventKeywords Default = (EventKeywords)1L;

		public const EventKeywords Debug = (EventKeywords)2L;
	}

	public static readonly System.Net.NetEventSource Log = new System.Net.NetEventSource();

	[NonEvent]
	public static void Info(object thisOrContextObject, FormattableString formattableString = null, [CallerMemberName] string memberName = null)
	{
		Log.Info(IdOf(thisOrContextObject), memberName, (formattableString != null) ? Format(formattableString) : "");
	}

	[NonEvent]
	public static void Info(object thisOrContextObject, object message, [CallerMemberName] string memberName = null)
	{
		Log.Info(IdOf(thisOrContextObject), memberName, Format(message));
	}

	[Event(1, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
	private void Info(string thisOrContextObject, string memberName, string message)
	{
		WriteEvent(1, thisOrContextObject, memberName ?? "(?)", message);
	}

	[NonEvent]
	public static void Error(object thisOrContextObject, FormattableString formattableString, [CallerMemberName] string memberName = null)
	{
		Log.ErrorMessage(IdOf(thisOrContextObject), memberName, Format(formattableString));
	}

	[NonEvent]
	public static void Error(object thisOrContextObject, object message, [CallerMemberName] string memberName = null)
	{
		Log.ErrorMessage(IdOf(thisOrContextObject), memberName, Format(message));
	}

	[Event(2, Level = EventLevel.Error, Keywords = (EventKeywords)1L)]
	private void ErrorMessage(string thisOrContextObject, string memberName, string message)
	{
		WriteEvent(2, thisOrContextObject, memberName ?? "(?)", message);
	}

	[NonEvent]
	public static string IdOf(object value)
	{
		if (value == null)
		{
			return "(null)";
		}
		return value.GetType().Name + "#" + GetHashCode(value);
	}

	[NonEvent]
	public static int GetHashCode(object value)
	{
		return value?.GetHashCode() ?? 0;
	}

	[NonEvent]
	public static string Format(object value)
	{
		if (value == null)
		{
			return "(null)";
		}
		string text = null;
		if (text != null)
		{
			return text;
		}
		if (value is Array array)
		{
			return $"{array.GetType().GetElementType()}[{((Array)value).Length}]";
		}
		if (value is ICollection collection)
		{
			return $"{collection.GetType().Name}({collection.Count})";
		}
		if (value is SafeHandle safeHandle)
		{
			return $"{safeHandle.GetType().Name}:{safeHandle.GetHashCode()}(0x{safeHandle.DangerousGetHandle():X})";
		}
		if (value is nint)
		{
			return $"0x{value:X}";
		}
		string text2 = value.ToString();
		if (text2 == null || text2 == value.GetType().FullName)
		{
			return IdOf(value);
		}
		return value.ToString();
	}

	[NonEvent]
	private static string Format(FormattableString s)
	{
		switch (s.ArgumentCount)
		{
		case 0:
			return s.Format;
		case 1:
			return string.Format(s.Format, Format(s.GetArgument(0)));
		case 2:
			return string.Format(s.Format, Format(s.GetArgument(0)), Format(s.GetArgument(1)));
		case 3:
			return string.Format(s.Format, Format(s.GetArgument(0)), Format(s.GetArgument(1)), Format(s.GetArgument(2)));
		default:
		{
			string[] array = new string[s.ArgumentCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Format(s.GetArgument(i));
			}
			string format = s.Format;
			object[] array2 = array;
			return string.Format(format, (ReadOnlySpan<object>)array2);
		}
		}
	}

	[NonEvent]
	public static void Associate(object first, object second, [CallerMemberName] string memberName = null)
	{
		Associate(first, first, second, memberName);
	}

	[NonEvent]
	public static void Associate(object thisOrContextObject, object first, object second, [CallerMemberName] string memberName = null)
	{
		Log.Associate(IdOf(thisOrContextObject), memberName, IdOf(first), IdOf(second));
	}

	[Event(3, Level = EventLevel.Informational, Keywords = (EventKeywords)1L, Message = "[{2}]<-->[{3}]")]
	private void Associate(string thisOrContextObject, string memberName, string first, string second)
	{
		WriteEvent(3, thisOrContextObject, memberName ?? "(?)", first, second);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:UnrecognizedReflectionPattern", Justification = "Parameters to this method are primitive and are trimmer safe")]
	[NonEvent]
	private unsafe void WriteEvent(int eventId, string arg1, string arg2, string arg3, string arg4)
	{
		//The blocks IL_004b, IL_004e, IL_0060, IL_0066, IL_006a, IL_0075, IL_0076, IL_0158, IL_015c are reachable both inside and outside the pinned region starting at IL_0048. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0076 are reachable both inside and outside the pinned region starting at IL_0071. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		//The blocks IL_0076 are reachable both inside and outside the pinned region starting at IL_0071. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		if (arg1 == null)
		{
			arg1 = "";
		}
		if (arg2 == null)
		{
			arg2 = "";
		}
		if (arg3 == null)
		{
			arg3 = "";
		}
		if (arg4 == null)
		{
			arg4 = "";
		}
		fixed (char* dataPointer = arg1)
		{
			char* intPtr;
			char* intPtr2;
			EventData* intPtr3;
			nint num;
			nint num2;
			nint num3;
			if (arg2 == null)
			{
				char* dataPointer2;
				intPtr = (dataPointer2 = null);
				fixed (char* ptr = arg3)
				{
					char* dataPointer3 = ptr;
					if (arg4 == null)
					{
						char* dataPointer4;
						intPtr2 = (dataPointer4 = null);
						EventData* ptr2 = stackalloc EventData[4];
						intPtr3 = ptr2;
						*intPtr3 = new EventData
						{
							DataPointer = (nint)dataPointer,
							Size = (arg1.Length + 1) * 2
						};
						num = (nint)(ptr2 + 1);
						*(EventData*)num = new EventData
						{
							DataPointer = (nint)dataPointer2,
							Size = (arg2.Length + 1) * 2
						};
						num2 = (nint)(ptr2 + 2);
						*(EventData*)num2 = new EventData
						{
							DataPointer = (nint)dataPointer3,
							Size = (arg3.Length + 1) * 2
						};
						num3 = (nint)(ptr2 + 3);
						*(EventData*)num3 = new EventData
						{
							DataPointer = (nint)dataPointer4,
							Size = (arg4.Length + 1) * 2
						};
						WriteEventCore(eventId, 4, ptr2);
						return;
					}
					fixed (char* ptr3 = &arg4.GetPinnableReference())
					{
						char* dataPointer4;
						intPtr2 = (dataPointer4 = ptr3);
						EventData* ptr2 = stackalloc EventData[4];
						intPtr3 = ptr2;
						*intPtr3 = new EventData
						{
							DataPointer = (nint)dataPointer,
							Size = (arg1.Length + 1) * 2
						};
						num = (nint)(ptr2 + 1);
						*(EventData*)num = new EventData
						{
							DataPointer = (nint)dataPointer2,
							Size = (arg2.Length + 1) * 2
						};
						num2 = (nint)(ptr2 + 2);
						*(EventData*)num2 = new EventData
						{
							DataPointer = (nint)dataPointer3,
							Size = (arg3.Length + 1) * 2
						};
						num3 = (nint)(ptr2 + 3);
						*(EventData*)num3 = new EventData
						{
							DataPointer = (nint)dataPointer4,
							Size = (arg4.Length + 1) * 2
						};
						WriteEventCore(eventId, 4, ptr2);
					}
				}
				return;
			}
			fixed (char* ptr4 = &arg2.GetPinnableReference())
			{
				char* dataPointer2;
				intPtr = (dataPointer2 = ptr4);
				fixed (char* ptr = arg3)
				{
					char* dataPointer3 = ptr;
					if (arg4 == null)
					{
						char* dataPointer4;
						intPtr2 = (dataPointer4 = null);
						EventData* ptr2 = stackalloc EventData[4];
						intPtr3 = ptr2;
						*intPtr3 = new EventData
						{
							DataPointer = (nint)dataPointer,
							Size = (arg1.Length + 1) * 2
						};
						num = (nint)(ptr2 + 1);
						*(EventData*)num = new EventData
						{
							DataPointer = (nint)dataPointer2,
							Size = (arg2.Length + 1) * 2
						};
						num2 = (nint)(ptr2 + 2);
						*(EventData*)num2 = new EventData
						{
							DataPointer = (nint)dataPointer3,
							Size = (arg3.Length + 1) * 2
						};
						num3 = (nint)(ptr2 + 3);
						*(EventData*)num3 = new EventData
						{
							DataPointer = (nint)dataPointer4,
							Size = (arg4.Length + 1) * 2
						};
						WriteEventCore(eventId, 4, ptr2);
						return;
					}
					fixed (char* ptr3 = &arg4.GetPinnableReference())
					{
						char* dataPointer4;
						intPtr2 = (dataPointer4 = ptr3);
						EventData* ptr2 = stackalloc EventData[4];
						intPtr3 = ptr2;
						*intPtr3 = new EventData
						{
							DataPointer = (nint)dataPointer,
							Size = (arg1.Length + 1) * 2
						};
						num = (nint)(ptr2 + 1);
						*(EventData*)num = new EventData
						{
							DataPointer = (nint)dataPointer2,
							Size = (arg2.Length + 1) * 2
						};
						num2 = (nint)(ptr2 + 2);
						*(EventData*)num2 = new EventData
						{
							DataPointer = (nint)dataPointer3,
							Size = (arg3.Length + 1) * 2
						};
						num3 = (nint)(ptr2 + 3);
						*(EventData*)num3 = new EventData
						{
							DataPointer = (nint)dataPointer4,
							Size = (arg4.Length + 1) * 2
						};
						WriteEventCore(eventId, 4, ptr2);
					}
				}
			}
		}
	}
}

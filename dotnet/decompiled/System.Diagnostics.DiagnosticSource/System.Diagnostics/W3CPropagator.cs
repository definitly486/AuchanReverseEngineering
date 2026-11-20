using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Diagnostics;

internal sealed class W3CPropagator : DistributedContextPropagator
{
	private static readonly SearchValues<char> s_validBaggageKeyChars = SearchValues.Create("!#$%&'*+-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ^_`abcdefghijklmnopqrstuvwxyz|~".AsSpan());

	private static readonly SearchValues<char> s_validTraceStateChars = SearchValues.Create("*-/0123456789@_abcdefghijklmnopqrstuvwxyz".AsSpan());

	private static readonly SearchValues<char> s_validTraceStateValueChars = SearchValues.Create("!\"#$%&'()*+-./0123456789:;<>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~".AsSpan());

	private static ulong[] s_baggageOctet = new ulong[2] { 17870265566011326464uL, 9223372036586340351uL };

	private static ulong[] s_traceParentMask = new ulong[2] { 287948901175001088uL, 541165879296uL };

	internal static DistributedContextPropagator Instance { get; } = new W3CPropagator();

	public override IReadOnlyCollection<string> Fields { get; } = new ReadOnlyCollection<string>(new string[4] { "traceparent", "tracestate", "baggage", "Correlation-Context" });

	public override void Inject(Activity activity, object carrier, PropagatorSetterCallback setter)
	{
		if (activity == null || setter == null || activity.IdFormat != ActivityIdFormat.W3C)
		{
			return;
		}
		string id = activity.Id;
		if (id != null)
		{
			setter(carrier, "traceparent", id);
			string traceStateString = activity.TraceStateString;
			if (traceStateString != null && traceStateString.Length > 0)
			{
				InjectTraceState(traceStateString, carrier, setter);
			}
			InjectW3CBaggage(carrier, activity.Baggage, setter);
		}
	}

	internal static string ValidateTraceState(string traceState)
	{
		if (string.IsNullOrEmpty(traceState))
		{
			return null;
		}
		int i;
		int num2;
		for (i = 0; i < traceState.Length; i += num2)
		{
			ReadOnlySpan<char> readOnlySpan = traceState.AsSpan(i);
			int num = readOnlySpan.IndexOf(',');
			ReadOnlySpan<char> span = ((num >= 0) ? readOnlySpan.Slice(0, num) : readOnlySpan);
			num2 = span.Length + ((num >= 0) ? 1 : 0);
			if (i + num2 > 256)
			{
				break;
			}
			int num3 = span.IndexOf('=');
			if (num3 <= 0 || num3 >= span.Length - 1 || IsInvalidTraceStateKey(Trim(span.Slice(0, num3))) || IsInvalidTraceStateValue(TrimSpaceOnly(span.Slice(num3 + 1))))
			{
				break;
			}
		}
		if (i > 0)
		{
			if (traceState[i - 1] == ',')
			{
				i--;
			}
			if (i > 0)
			{
				if (i < traceState.Length)
				{
					return traceState.AsSpan(0, i).ToString();
				}
				return traceState;
			}
		}
		return null;
	}

	internal static void InjectTraceState(string traceState, object carrier, PropagatorSetterCallback setter)
	{
		string text = ValidateTraceState(traceState);
		if (text != null)
		{
			setter(carrier, "tracestate", text);
		}
	}

	internal static void InjectW3CBaggage(object carrier, IEnumerable<KeyValuePair<string, string>> baggage, PropagatorSetterCallback setter)
	{
		using IEnumerator<KeyValuePair<string, string>> enumerator = baggage.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return;
		}
		Span<char> initialBuffer = stackalloc char[256];
		System.Text.ValueStringBuilder vsb = new System.Text.ValueStringBuilder(initialBuffer);
		int num = 0;
		int num2 = 0;
		do
		{
			KeyValuePair<string, string> current = enumerator.Current;
			if (EncodeBaggageKey(current.Key.AsSpan(), ref vsb))
			{
				vsb.Append(' ');
				vsb.Append('=');
				vsb.Append(' ');
				if (!string.IsNullOrEmpty(current.Value))
				{
					EncodeBaggageValue(current.Value.AsSpan(), ref vsb);
				}
				vsb.Append(", ");
				num++;
				if (vsb.Length < 8192)
				{
					num2 = vsb.Length;
				}
			}
		}
		while (enumerator.MoveNext() && num < 64 && vsb.Length < 8192);
		if (num2 - 2 > 0)
		{
			setter(carrier, "baggage", vsb.AsSpan(0, num2 - 2).ToString());
		}
		vsb.Dispose();
	}

	private static bool IsInvalidBaggageKey(ReadOnlySpan<char> span)
	{
		return span.ContainsAnyExcept(s_validBaggageKeyChars);
	}

	private static bool IsInvalidTraceStateKey(ReadOnlySpan<char> key)
	{
		if (!key.IsEmpty && ((uint)(122 - key[0]) <= 25u || (uint)(57 - key[0]) <= 9u))
		{
			return key.ContainsAnyExcept(s_validTraceStateChars);
		}
		return true;
	}

	private static bool IsInvalidTraceStateValue(ReadOnlySpan<char> value)
	{
		if (!value.IsEmpty)
		{
			return value.ContainsAnyExcept(s_validTraceStateValueChars);
		}
		return true;
	}

	internal static bool EncodeBaggageKey(ReadOnlySpan<char> key, ref System.Text.ValueStringBuilder vsb)
	{
		key = Trim(key);
		if (key.IsEmpty || IsInvalidBaggageKey(key))
		{
			return false;
		}
		vsb.Append(key);
		return true;
	}

	internal static void EncodeBaggageValue(ReadOnlySpan<char> value, ref System.Text.ValueStringBuilder vsb)
	{
		value = Trim(value);
		for (int i = 0; i < value.Length; i++)
		{
			char c = value[i];
			if (!NeedToEscapeBaggageValueCharacter(c))
			{
				vsb.Append(c);
			}
			else if ((uint)c <= 127u)
			{
				EmitEscapedByte((byte)c, ref vsb);
			}
			else if ((uint)c <= 2047u)
			{
				EmitEscapedByte((byte)((uint)(c + 12288) >> 6), ref vsb);
				EmitEscapedByte((byte)((c & 0x3F) + 128), ref vsb);
			}
			else if (char.IsSurrogate(c))
			{
				if (i < value.Length - 1 && char.IsSurrogatePair(c, value[i + 1]))
				{
					int num = char.ConvertToUtf32(c, value[i + 1]);
					EmitEscapedByte((byte)((uint)(num + 62914560) >> 18), ref vsb);
					EmitEscapedByte((byte)(((num & 0x3F000) >>> 12) + 128), ref vsb);
					EmitEscapedByte((byte)(((num & 0xFC0) >>> 6) + 128), ref vsb);
					EmitEscapedByte((byte)((num & 0x3F) + 128), ref vsb);
					i++;
				}
				else
				{
					EmitEscapedByte(239, ref vsb);
					EmitEscapedByte(191, ref vsb);
					EmitEscapedByte(189, ref vsb);
				}
			}
			else
			{
				EmitEscapedByte((byte)(c + 917504 >> 12), ref vsb);
				EmitEscapedByte((byte)(((c & 0xFC0) >>> 6) + 128), ref vsb);
				EmitEscapedByte((byte)((c & 0x3F) + 128), ref vsb);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool NeedToEscapeBaggageValueCharacter(char c)
	{
		if (c >= '\u007f')
		{
			return true;
		}
		return (s_baggageOctet[(int)c >> 6] & (ulong)(1L << (int)c)) == 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void EmitEscapedByte(byte b, ref System.Text.ValueStringBuilder vsb)
	{
		vsb.Append('%');
		vsb.Append("0123456789ABCDEF"[(b >> 4) & 0xF]);
		vsb.Append("0123456789ABCDEF"[b & 0xF]);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ReadOnlySpan<char> TrimSpaceOnly(ReadOnlySpan<char> span)
	{
		return span.Trim(' ');
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ReadOnlySpan<char> Trim(ReadOnlySpan<char> span)
	{
		return span.Trim(" \t".AsSpan());
	}
}

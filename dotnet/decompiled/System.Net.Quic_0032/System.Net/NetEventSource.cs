using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Quic;

namespace System.Net;

[EventSource(Name = "Private.InternalDiagnostics.System.Net.Quic")]
internal sealed class NetEventSource : EventSource
{
	public static class Keywords
	{
		public const EventKeywords Default = (EventKeywords)1L;

		public const EventKeywords Debug = (EventKeywords)2L;
	}

	private static readonly Meter s_meter = new Meter("Private.InternalDiagnostics.System.Net.Quic.MsQuic");

	private static long s_countersLastFetched;

	private static readonly long[] s_counters = new long[32];

	public static readonly ObservableCounter<long> s_CONN_CREATED = s_meter.CreateObservableCounter("msquic.connection.created", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_CREATED), "{connection}", "New connections allocated");

	public static readonly ObservableCounter<long> s_CONN_HANDSHAKE_FAIL = s_meter.CreateObservableCounter("msquic.connection.handshake_failures", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_HANDSHAKE_FAIL), "{connection}", "Connections that failed during handshake");

	public static readonly ObservableCounter<long> s_CONN_APP_REJECT = s_meter.CreateObservableCounter("msquic.connection.app_rejected", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_APP_REJECT), "{connection}", "Connections rejected by the application");

	public static readonly ObservableCounter<long> s_CONN_LOAD_REJECT = s_meter.CreateObservableCounter("msquic.connection.load_rejected", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_LOAD_REJECT), "{connection}", "Connections rejected due to worker load.");

	public static readonly ObservableCounter<long> s_CONN_RESUMED = s_meter.CreateObservableCounter("msquic.connection.resumed", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_RESUMED), "{connection}", "Connections resumed");

	public static readonly ObservableGauge<long> s_CONN_ACTIVE = s_meter.CreateObservableGauge("msquic.connection.allocated", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_ACTIVE), "{connection}", "Connections currently allocated");

	public static readonly ObservableGauge<long> s_CONN_CONNECTED = s_meter.CreateObservableGauge("msquic.connection.connected", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_CONNECTED), "{connection}", "Connections currently in the connected state");

	public static readonly ObservableCounter<long> s_CONN_PROTOCOL_ERRORS = s_meter.CreateObservableCounter("msquic.connection.protocol_errors", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_PROTOCOL_ERRORS), "{connection}", "Connections shutdown with a protocol error");

	public static readonly ObservableCounter<long> s_CONN_NO_ALPN = s_meter.CreateObservableCounter("msquic.connection.no_alpn", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_NO_ALPN), "{connection}", "Connection attempts with no matching ALPN");

	public static readonly ObservableGauge<long> s_STRM_ACTIVE = s_meter.CreateObservableGauge("msquic.stream.allocated", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.STRM_ACTIVE), "{stream}", "Current streams allocated");

	public static readonly ObservableCounter<long> s_PKTS_SUSPECTED_LOST = s_meter.CreateObservableCounter("msquic.packet.suspected_lost", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.PKTS_SUSPECTED_LOST), "{packet}", "Packets suspected lost");

	public static readonly ObservableCounter<long> s_PKTS_DROPPED = s_meter.CreateObservableCounter("msquic.packet.dropped", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.PKTS_DROPPED), "{packet}", "Packets dropped for any reason");

	public static readonly ObservableCounter<long> s_PKTS_DECRYPTION_FAIL = s_meter.CreateObservableCounter("msquic.packet.decryption_failures", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.PKTS_DECRYPTION_FAIL), "{packet}", "Packets with decryption failures");

	public static readonly ObservableCounter<long> s_UDP_RECV = s_meter.CreateObservableCounter("msquic.udp.recv_datagrams", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.UDP_RECV), "{datagram}", "UDP datagrams received");

	public static readonly ObservableCounter<long> s_UDP_SEND = s_meter.CreateObservableCounter("msquic.udp.send_datagrams", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.UDP_SEND), "{datagram}", "UDP datagrams sent");

	public static readonly ObservableCounter<long> s_UDP_RECV_BYTES = s_meter.CreateObservableCounter("msquic.udp.recv_bytes", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.UDP_RECV_BYTES), "By", "UDP payload bytes received");

	public static readonly ObservableCounter<long> s_UDP_SEND_BYTES = s_meter.CreateObservableCounter("msquic.udp.send_bytes", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.UDP_SEND_BYTES), "By", "UDP payload bytes sent");

	public static readonly ObservableCounter<long> s_UDP_RECV_EVENTS = s_meter.CreateObservableCounter("msquic.udp.recv_events", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.UDP_RECV_EVENTS), "{event}", "UDP receive events");

	public static readonly ObservableCounter<long> s_UDP_SEND_CALLS = s_meter.CreateObservableCounter("msquic.udp.send_calls", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.UDP_SEND_CALLS), "{call}", "UDP send API calls");

	public static readonly ObservableCounter<long> s_APP_SEND_BYTES = s_meter.CreateObservableCounter("msquic.app.send_bytes", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.APP_SEND_BYTES), "By", "Bytes sent by applications");

	public static readonly ObservableCounter<long> s_APP_RECV_BYTES = s_meter.CreateObservableCounter("msquic.app.recv_bytes", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.APP_RECV_BYTES), "By", "Bytes received by applications");

	public static readonly ObservableGauge<long> s_CONN_QUEUE_DEPTH = s_meter.CreateObservableGauge("msquic.threadpool.conn_queue_depth", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_QUEUE_DEPTH), "{connection}", "Current connections queued for processing");

	public static readonly ObservableGauge<long> s_CONN_OPER_QUEUE_DEPTH = s_meter.CreateObservableGauge("msquic.threadpool.conn_oper_queue_depth", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_OPER_QUEUE_DEPTH), "{operation}", "Current connection operations queued");

	public static readonly ObservableCounter<long> s_CONN_OPER_QUEUED = s_meter.CreateObservableCounter("msquic.threadpool.conn_oper_queued", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_OPER_QUEUED), "{operation}", "New connection operations queued");

	public static readonly ObservableCounter<long> s_CONN_OPER_COMPLETED = s_meter.CreateObservableCounter("msquic.threadpool.conn_oper_completed", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.CONN_OPER_COMPLETED), "{operation}", "Connection operations processed");

	public static readonly ObservableGauge<long> s_WORK_OPER_QUEUE_DEPTH = s_meter.CreateObservableGauge("msquic.threadpool.work_oper_queue_depth", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.WORK_OPER_QUEUE_DEPTH), "{operation}", "Current worker operations queued");

	public static readonly ObservableCounter<long> s_WORK_OPER_QUEUED = s_meter.CreateObservableCounter("msquic.threadpool.work_oper_queued", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.WORK_OPER_QUEUED), "{operation}", "New worker operations queued");

	public static readonly ObservableCounter<long> s_WORK_OPER_COMPLETED = s_meter.CreateObservableCounter("msquic.threadpool.work_oper_completed", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.WORK_OPER_COMPLETED), "{operation}", "Worker operations processed");

	public static readonly ObservableCounter<long> s_PATH_VALIDATED = s_meter.CreateObservableCounter("msquic.datapath.path_validated", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.PATH_VALIDATED), "{challenge}", "Successful path challenges");

	public static readonly ObservableCounter<long> s_PATH_FAILURE = s_meter.CreateObservableCounter("msquic.datapath.path_failure", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.PATH_FAILURE), "{challenge}", "Unsuccessful path challenges");

	public static readonly ObservableCounter<long> s_SEND_STATELESS_RESET = s_meter.CreateObservableCounter("msquic.datapath.send_stateless_reset", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.SEND_STATELESS_RESET), "{packet}", "Stateless reset packets sent ever");

	public static readonly ObservableCounter<long> s_SEND_STATELESS_RETRY = s_meter.CreateObservableCounter("msquic.datapath.send_stateless_retry", () => GetCounterValue(QUIC_PERFORMANCE_COUNTERS.SEND_STATELESS_RETRY), "{packet}", "Stateless retry packets sent");

	public static readonly System.Net.NetEventSource Log = new System.Net.NetEventSource();

	[NonEvent]
	private unsafe static void UpdateCounters()
	{
		if (MsQuicApi.IsQuicSupported)
		{
			fixed (long* ptr = s_counters)
			{
				uint num = (uint)(s_counters.Length * 8);
				MsQuicApi.Api.ApiTable->GetParam(null, 16777219u, &num, ptr);
			}
		}
	}

	[NonEvent]
	private static long GetCounterValue(QUIC_PERFORMANCE_COUNTERS counter)
	{
		if (s_countersLastFetched == 0L || Stopwatch.GetElapsedTime(s_countersLastFetched).TotalMilliseconds > 50.0)
		{
			UpdateCounters();
			s_countersLastFetched = Stopwatch.GetTimestamp();
		}
		return s_counters[(int)counter];
	}

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
		string result = null;
		AdditionalCustomizedToString(value, ref result);
		if (result != null)
		{
			return result;
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
		string text = value.ToString();
		if (text == null || text == value.GetType().FullName)
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

	private static void AdditionalCustomizedToString(object value, ref string result)
	{
		if (value is MsQuicSafeHandle msQuicSafeHandle)
		{
			result = msQuicSafeHandle.ToString();
		}
	}
}

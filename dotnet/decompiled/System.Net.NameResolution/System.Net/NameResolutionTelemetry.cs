using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.Sockets;
using System.Threading;

namespace System.Net;

[EventSource(Name = "System.Net.NameResolution")]
internal sealed class NameResolutionTelemetry : EventSource
{
	public static readonly NameResolutionTelemetry Log = new NameResolutionTelemetry();

	private PollingCounter _lookupsRequestedCounter;

	private PollingCounter _currentLookupsCounter;

	private EventCounter _lookupsDuration;

	private long _lookupsRequested;

	private long _currentLookups;

	protected override void OnEventCommand(EventCommandEventArgs command)
	{
		if (command.Command != EventCommand.Enable)
		{
			return;
		}
		if (_lookupsRequestedCounter == null)
		{
			_lookupsRequestedCounter = new PollingCounter("dns-lookups-requested", this, () => Interlocked.Read(ref _lookupsRequested))
			{
				DisplayName = "DNS Lookups Requested"
			};
		}
		if (_currentLookupsCounter == null)
		{
			_currentLookupsCounter = new PollingCounter("current-dns-lookups", this, () => Interlocked.Read(ref _currentLookups))
			{
				DisplayName = "Current DNS Lookups"
			};
		}
		if (_lookupsDuration == null)
		{
			_lookupsDuration = new EventCounter("dns-lookups-duration", this)
			{
				DisplayName = "Average DNS Lookup Duration",
				DisplayUnits = "ms"
			};
		}
	}

	[Event(1, Level = EventLevel.Informational)]
	private void ResolutionStart(string hostNameOrAddress)
	{
		WriteEvent(1, hostNameOrAddress);
	}

	[Event(2, Level = EventLevel.Informational)]
	private void ResolutionStop()
	{
		WriteEvent(2);
	}

	[Event(3, Level = EventLevel.Informational)]
	private void ResolutionFailed()
	{
		WriteEvent(3);
	}

	[NonEvent]
	public static bool AnyDiagnosticsEnabled()
	{
		_ = 0;
		Log.IsEnabled();
		NameResolutionMetrics.IsEnabled();
		return NameResolutionActivity.IsTracingEnabled();
	}

	[NonEvent]
	public NameResolutionActivity BeforeResolution(object hostNameOrAddress, long startingTimestamp = 0L)
	{
		if (!AnyDiagnosticsEnabled())
		{
			return default(NameResolutionActivity);
		}
		if (false)
		{
		}
		long num;
		if (startingTimestamp == 0L)
		{
			NameResolutionMetrics.IsEnabled();
			num = 0L;
		}
		else
		{
			num = startingTimestamp;
		}
		startingTimestamp = num;
		return new NameResolutionActivity(hostNameOrAddress, startingTimestamp);
	}

	[NonEvent]
	public void AfterResolution(object hostNameOrAddress, in NameResolutionActivity activity, object answer, Exception exception = null)
	{
		if (false)
		{
		}
		if (activity.Stop(answer, exception, out var _))
		{
			if (false)
			{
			}
			if (!NameResolutionMetrics.IsEnabled())
			{
			}
		}
	}

	[NonEvent]
	internal static string GetHostnameFromStateObject(object hostNameOrAddress)
	{
		if (!(hostNameOrAddress is string result))
		{
			if (!(hostNameOrAddress is KeyValuePair<string, AddressFamily> { Key: var key }))
			{
				if (!(hostNameOrAddress is IPAddress iPAddress))
				{
					if (hostNameOrAddress is KeyValuePair<IPAddress, AddressFamily> keyValuePair2)
					{
						return keyValuePair2.Key.ToString();
					}
					return null;
				}
				return iPAddress.ToString();
			}
			return key;
		}
		return result;
	}

	[NonEvent]
	internal static string GetErrorType(Exception exception)
	{
		return (exception as SocketException)?.SocketErrorCode switch
		{
			SocketError.HostNotFound => "host_not_found", 
			SocketError.TryAgain => "try_again", 
			SocketError.AddressFamilyNotSupported => "address_family_not_supported", 
			SocketError.NoRecovery => "no_recovery", 
			_ => exception.GetType().FullName, 
		};
	}
}

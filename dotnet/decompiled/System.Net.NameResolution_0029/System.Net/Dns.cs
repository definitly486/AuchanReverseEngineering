using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net;

public static class Dns
{
	private static readonly Dictionary<object, Task> s_tasks = new Dictionary<object, Task>();

	public static string GetHostName()
	{
		NameResolutionActivity activity = NameResolutionTelemetry.Log.BeforeResolution(string.Empty, 0L);
		string hostName;
		try
		{
			hostName = NameResolutionPal.GetHostName();
		}
		catch (Exception exception) when (LogFailure(string.Empty, in activity, exception))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(string.Empty, in activity, hostName);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return hostName;
	}

	public static IPHostEntry GetHostEntry(string hostNameOrAddress)
	{
		return GetHostEntry(hostNameOrAddress, AddressFamily.Unspecified);
	}

	public static IPHostEntry GetHostEntry(string hostNameOrAddress, AddressFamily family)
	{
		ArgumentNullException.ThrowIfNull(hostNameOrAddress, "hostNameOrAddress");
		_ = 1;
		IPHostEntry hostEntryCore;
		if (IPAddress.TryParse(hostNameOrAddress, out IPAddress address))
		{
			if (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any))
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				throw new ArgumentException("net_invalid_ip_addr", "hostNameOrAddress");
			}
			hostEntryCore = GetHostEntryCore(address, family);
		}
		else
		{
			hostEntryCore = GetHostEntryCore(hostNameOrAddress, family);
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return hostEntryCore;
	}

	public static Task<IPHostEntry> GetHostEntryAsync(string hostNameOrAddress, CancellationToken cancellationToken)
	{
		return GetHostEntryAsync(hostNameOrAddress, AddressFamily.Unspecified, cancellationToken);
	}

	public static Task<IPHostEntry> GetHostEntryAsync(string hostNameOrAddress, AddressFamily family, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return GetHostEntryCoreAsync(hostNameOrAddress, justReturnParsedIp: false, throwOnIIPAny: true, family, cancellationToken);
	}

	public static IPAddress[] GetHostAddresses(string hostNameOrAddress)
	{
		return GetHostAddresses(hostNameOrAddress, AddressFamily.Unspecified);
	}

	public static IPAddress[] GetHostAddresses(string hostNameOrAddress, AddressFamily family)
	{
		ArgumentNullException.ThrowIfNull(hostNameOrAddress, "hostNameOrAddress");
		IPAddress[] result;
		if (IPAddress.TryParse(hostNameOrAddress, out IPAddress address))
		{
			if (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any))
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				throw new ArgumentException("net_invalid_ip_addr", "hostNameOrAddress");
			}
			result = ((family != AddressFamily.Unspecified && address.AddressFamily != family) ? Array.Empty<IPAddress>() : new IPAddress[1] { address });
		}
		else
		{
			result = GetHostAddressesCore(hostNameOrAddress, family);
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return result;
	}

	public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress, CancellationToken cancellationToken)
	{
		return (Task<IPAddress[]>)GetHostEntryOrAddressesCoreAsync(hostNameOrAddress, justReturnParsedIp: true, throwOnIIPAny: true, justAddresses: true, AddressFamily.Unspecified, cancellationToken);
	}

	public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress, AddressFamily family, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (Task<IPAddress[]>)GetHostEntryOrAddressesCoreAsync(hostNameOrAddress, justReturnParsedIp: true, throwOnIIPAny: true, justAddresses: true, family, cancellationToken);
	}

	private static IPHostEntry GetHostEntryCore(string hostName, AddressFamily addressFamily, NameResolutionActivity? activityOrDefault = null)
	{
		return (IPHostEntry)GetHostEntryOrAddressesCore(hostName, justAddresses: false, addressFamily, activityOrDefault);
	}

	private static IPAddress[] GetHostAddressesCore(string hostName, AddressFamily addressFamily, NameResolutionActivity? activityOrDefault = null)
	{
		return (IPAddress[])GetHostEntryOrAddressesCore(hostName, justAddresses: true, addressFamily, activityOrDefault);
	}

	private static bool ValidateAddressFamily(ref AddressFamily addressFamily, string hostName, bool justAddresses, [NotNullWhen(false)] out object resultOnFailure)
	{
		if (!SocketProtocolSupportPal.OSSupportsIPv6)
		{
			if (addressFamily == AddressFamily.InterNetworkV6)
			{
				IPAddress[] array = Array.Empty<IPAddress>();
				resultOnFailure = (justAddresses ? ((object)array) : ((object)new IPHostEntry
				{
					AddressList = array,
					HostName = hostName,
					Aliases = Array.Empty<string>()
				}));
				return false;
			}
			if (addressFamily == AddressFamily.Unspecified)
			{
				addressFamily = AddressFamily.InterNetwork;
			}
		}
		resultOnFailure = null;
		return true;
	}

	private static object GetHostEntryOrAddressesCore(string hostName, bool justAddresses, AddressFamily addressFamily, NameResolutionActivity? activityOrDefault = null)
	{
		ValidateHostName(hostName);
		if (!ValidateAddressFamily(ref addressFamily, hostName, justAddresses, out var resultOnFailure))
		{
			return resultOnFailure;
		}
		NameResolutionActivity activity = activityOrDefault ?? NameResolutionTelemetry.Log.BeforeResolution(hostName, 0L);
		object obj;
		try
		{
			string hostName2;
			string[] aliases;
			IPAddress[] addresses;
			int nativeErrorCode;
			SocketError socketError = NameResolutionPal.TryGetAddrInfo(hostName, justAddresses, addressFamily, out hostName2, out aliases, out addresses, out nativeErrorCode);
			if (socketError != SocketError.Success)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				throw CreateException(socketError, nativeErrorCode);
			}
			obj = (justAddresses ? ((object)addresses) : ((object)new IPHostEntry
			{
				AddressList = addresses,
				HostName = hostName2,
				Aliases = aliases
			}));
		}
		catch (Exception exception) when (LogFailure(hostName, in activity, exception))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(hostName, in activity, obj);
		return obj;
	}

	private static IPHostEntry GetHostEntryCore(IPAddress address, AddressFamily addressFamily, NameResolutionActivity? activityOrDefault = null)
	{
		return (IPHostEntry)GetHostEntryOrAddressesCore(address, justAddresses: false, addressFamily, activityOrDefault);
	}

	private static IPAddress[] GetHostAddressesCore(IPAddress address, AddressFamily addressFamily, NameResolutionActivity? activityOrDefault = null)
	{
		return (IPAddress[])GetHostEntryOrAddressesCore(address, justAddresses: true, addressFamily, activityOrDefault);
	}

	private static object GetHostEntryOrAddressesCore(IPAddress address, bool justAddresses, AddressFamily addressFamily, NameResolutionActivity? activityOrDefault = null)
	{
		if (false)
		{
		}
		NameResolutionActivity activity = activityOrDefault ?? NameResolutionTelemetry.Log.BeforeResolution(address, 0L);
		string text;
		try
		{
			text = NameResolutionPal.TryGetNameInfo(address, out var socketError, out var nativeErrorCode);
			if (socketError != SocketError.Success)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				throw CreateException(socketError, nativeErrorCode);
			}
		}
		catch (Exception exception) when (LogFailure(address, in activity, exception))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(address, in activity, text);
		if (!ValidateAddressFamily(ref addressFamily, text, justAddresses, out var resultOnFailure))
		{
			return resultOnFailure;
		}
		activity = NameResolutionTelemetry.Log.BeforeResolution(text, 0L);
		object obj;
		try
		{
			if (NameResolutionPal.TryGetAddrInfo(text, justAddresses, addressFamily, out var hostName, out var aliases, out var addresses, out var _) == SocketError.Success || System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			obj = (justAddresses ? ((object)addresses) : ((object)new IPHostEntry
			{
				HostName = hostName,
				Aliases = aliases,
				AddressList = addresses
			}));
		}
		catch (Exception exception2) when (LogFailure(text, in activity, exception2))
		{
			throw;
		}
		NameResolutionTelemetry.Log.AfterResolution(text, in activity, obj);
		return obj;
	}

	private static Task<IPHostEntry> GetHostEntryCoreAsync(string hostName, bool justReturnParsedIp, bool throwOnIIPAny, AddressFamily family, CancellationToken cancellationToken)
	{
		return (Task<IPHostEntry>)GetHostEntryOrAddressesCoreAsync(hostName, justReturnParsedIp, throwOnIIPAny, justAddresses: false, family, cancellationToken);
	}

	private static Task GetHostEntryOrAddressesCoreAsync(string hostName, bool justReturnParsedIp, bool throwOnIIPAny, bool justAddresses, AddressFamily family, CancellationToken cancellationToken)
	{
		ArgumentNullException.ThrowIfNull(hostName, "hostName");
		if (cancellationToken.IsCancellationRequested)
		{
			if (!justAddresses)
			{
				return Task.FromCanceled<IPHostEntry>(cancellationToken);
			}
			return Task.FromCanceled<IPAddress[]>(cancellationToken);
		}
		if (!ValidateAddressFamily(ref family, hostName, justAddresses, out var resultOnFailure))
		{
			if (!justAddresses)
			{
				return Task.FromResult((IPHostEntry)resultOnFailure);
			}
			return Task.FromResult((IPAddress[])resultOnFailure);
		}
		_ = 1;
		object key;
		if (IPAddress.TryParse(hostName, out IPAddress address))
		{
			if (throwOnIIPAny && (address.Equals(IPAddress.Any) || address.Equals(IPAddress.IPv6Any)))
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				throw new ArgumentException("net_invalid_ip_addr", "hostName");
			}
			if (justReturnParsedIp)
			{
				if (!justAddresses)
				{
					return Task.FromResult(CreateHostEntryForAddress(address));
				}
				return Task.FromResult((family != AddressFamily.Unspecified && address.AddressFamily != family) ? Array.Empty<IPAddress>() : new IPAddress[1] { address });
			}
			key = ((family == AddressFamily.Unspecified) ? address : ((object)new KeyValuePair<IPAddress, AddressFamily>(address, family)));
		}
		else
		{
			key = ((family == AddressFamily.Unspecified) ? hostName : ((object)new KeyValuePair<string, AddressFamily>(hostName, family)));
		}
		if (justAddresses)
		{
			return RunAsync(delegate(object s, NameResolutionActivity activity)
			{
				if (s is string hostName2)
				{
					return GetHostAddressesCore(hostName2, AddressFamily.Unspecified, activity);
				}
				if (s is KeyValuePair<string, AddressFamily> keyValuePair)
				{
					return GetHostAddressesCore(keyValuePair.Key, keyValuePair.Value, activity);
				}
				if (s is IPAddress address2)
				{
					return GetHostAddressesCore(address2, AddressFamily.Unspecified, activity);
				}
				return (s is KeyValuePair<IPAddress, AddressFamily> keyValuePair2) ? GetHostAddressesCore(keyValuePair2.Key, keyValuePair2.Value, activity) : null;
			}, key, cancellationToken);
		}
		return RunAsync(delegate(object s, NameResolutionActivity activity)
		{
			if (s is string hostName2)
			{
				return GetHostEntryCore(hostName2, AddressFamily.Unspecified, activity);
			}
			if (s is KeyValuePair<string, AddressFamily> keyValuePair)
			{
				return GetHostEntryCore(keyValuePair.Key, keyValuePair.Value, activity);
			}
			if (s is IPAddress address2)
			{
				return GetHostEntryCore(address2, AddressFamily.Unspecified, activity);
			}
			return (s is KeyValuePair<IPAddress, AddressFamily> keyValuePair2) ? GetHostEntryCore(keyValuePair2.Key, keyValuePair2.Value, activity) : null;
		}, key, cancellationToken);
	}

	private static IPHostEntry CreateHostEntryForAddress(IPAddress address)
	{
		IPHostEntry iPHostEntry = new IPHostEntry();
		iPHostEntry.HostName = address.ToString();
		iPHostEntry.Aliases = Array.Empty<string>();
		iPHostEntry.AddressList = new IPAddress[1] { address };
		return iPHostEntry;
	}

	private static void ValidateHostName(string hostName)
	{
		if (hostName.Length > 255 || (hostName.Length == 255 && hostName[254] != '.'))
		{
			throw new ArgumentOutOfRangeException("hostName", System.SR.Format("net_toolong", "hostName", 255.ToString(NumberFormatInfo.CurrentInfo)));
		}
	}

	private static bool LogFailure(object hostNameOrAddress, in NameResolutionActivity activity, Exception exception)
	{
		NameResolutionTelemetry.Log.AfterResolution(hostNameOrAddress, in activity, null, exception);
		return false;
	}

	private static Task<TResult> RunAsync<TResult>(Func<object, NameResolutionActivity, TResult> func, object key, CancellationToken cancellationToken)
	{
		bool num = NameResolutionActivity.IsTracingEnabled();
		Activity current = (num ? Activity.Current : null);
		NameResolutionActivity activity = NameResolutionTelemetry.Log.BeforeResolution(key, 0L);
		if (num)
		{
			Activity.Current = current;
		}
		Task<TResult> task = null;
		lock (s_tasks)
		{
			s_tasks.TryGetValue(key, out var value);
			if (value == null)
			{
				value = Task.CompletedTask;
			}
			task = value.ContinueWith(delegate
			{
				try
				{
					return func(key, activity);
				}
				finally
				{
					lock (s_tasks)
					{
						((ICollection<KeyValuePair<object, Task>>)s_tasks).Remove(new KeyValuePair<object, Task>(key, task));
					}
				}
			}, key, cancellationToken, TaskContinuationOptions.DenyChildAttach, TaskScheduler.Default);
			if (cancellationToken.CanBeCanceled)
			{
				task.ContinueWith(delegate(Task<TResult> value2, object obj)
				{
					lock (s_tasks)
					{
						((ICollection<KeyValuePair<object, Task>>)s_tasks).Remove(new KeyValuePair<object, Task>(obj, value2));
					}
					NameResolutionTelemetry.Log.AfterResolution(obj, in activity, new OperationCanceledException());
				}, key, CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled | TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			}
			s_tasks[key] = task;
		}
		return task;
	}

	private static SocketException CreateException(SocketError error, int nativeError)
	{
		return new SocketException((int)error)
		{
			HResult = nativeError
		};
	}
}

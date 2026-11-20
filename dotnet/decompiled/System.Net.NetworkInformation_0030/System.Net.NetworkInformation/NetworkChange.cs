using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.NetworkInformation;

public class NetworkChange
{
	private static readonly Dictionary<NetworkAddressChangedEventHandler, ExecutionContext> s_addressChangedSubscribers = new Dictionary<NetworkAddressChangedEventHandler, ExecutionContext>();

	private static readonly Dictionary<NetworkAvailabilityChangedEventHandler, ExecutionContext> s_availabilityChangedSubscribers = new Dictionary<NetworkAvailabilityChangedEventHandler, ExecutionContext>();

	private static readonly NetworkAvailabilityEventArgs s_availableEventArgs = new NetworkAvailabilityEventArgs(isAvailable: true);

	private static readonly NetworkAvailabilityEventArgs s_notAvailableEventArgs = new NetworkAvailabilityEventArgs(isAvailable: false);

	private static readonly ContextCallback s_runHandlerAvailable = RunAvailabilityHandlerAvailable;

	private static readonly ContextCallback s_runHandlerNotAvailable = RunAvailabilityHandlerNotAvailable;

	private static readonly ContextCallback s_runAddressChangedHandler = RunAddressChangedHandler;

	private static readonly TimeSpan s_timerInterval = TimeSpan.FromSeconds(2L);

	private static readonly object s_lockObj = new object();

	private static Task s_loopTask;

	private static CancellationTokenSource s_cancellationTokenSource;

	private static IPAddress[] s_lastIpAddresses;

	[UnsupportedOSPlatform("illumos")]
	[UnsupportedOSPlatform("solaris")]
	public static event NetworkAddressChangedEventHandler? NetworkAddressChanged
	{
		add
		{
			if (value == null)
			{
				return;
			}
			lock (s_lockObj)
			{
				if (s_addressChangedSubscribers.Count == 0 && s_availabilityChangedSubscribers.Count == 0)
				{
					CreateAndStartLoop();
				}
				s_addressChangedSubscribers.TryAdd(value, ExecutionContext.Capture());
			}
		}
		remove
		{
			if (value == null)
			{
				return;
			}
			lock (s_lockObj)
			{
				bool num = s_addressChangedSubscribers.Count != 0;
				s_addressChangedSubscribers.Remove(value);
				if (num && s_addressChangedSubscribers.Count == 0 && s_availabilityChangedSubscribers.Count == 0)
				{
					StopLoop();
				}
			}
		}
	}

	private static void RunAddressChangedHandler(object state)
	{
		((NetworkAddressChangedEventHandler)state)(null, EventArgs.Empty);
	}

	private static void RunAvailabilityHandlerAvailable(object state)
	{
		((NetworkAvailabilityChangedEventHandler)state)(null, s_availableEventArgs);
	}

	private static void RunAvailabilityHandlerNotAvailable(object state)
	{
		((NetworkAvailabilityChangedEventHandler)state)(null, s_notAvailableEventArgs);
	}

	private static void CreateAndStartLoop()
	{
		s_cancellationTokenSource = new CancellationTokenSource();
		s_loopTask = PeriodicallyCheckIfNetworkChanged(s_cancellationTokenSource.Token);
	}

	private static void StopLoop()
	{
		s_cancellationTokenSource.Cancel();
		s_loopTask = null;
		s_cancellationTokenSource = null;
		s_lastIpAddresses = null;
	}

	private static async Task PeriodicallyCheckIfNetworkChanged(CancellationToken cancellationToken)
	{
		await Task.CompletedTask.ConfigureAwait(ConfigureAwaitOptions.ForceYielding);
		PeriodicTimer timer = new PeriodicTimer(s_timerInterval);
		try
		{
			while (await timer.WaitForNextTickAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false) && !cancellationToken.IsCancellationRequested)
			{
				CheckIfNetworkChanged();
			}
		}
		catch (OperationCanceledException)
		{
		}
		finally
		{
			timer.Dispose();
		}
	}

	private static void CheckIfNetworkChanged()
	{
		IPAddress[] iPAddresses = GetIPAddresses();
		IPAddress[] array = s_lastIpAddresses;
		if (array != null && NetworkChanged(array, iPAddresses))
		{
			OnNetworkChanged();
		}
		s_lastIpAddresses = iPAddresses;
	}

	private static IPAddress[] GetIPAddresses()
	{
		List<IPAddress> list = new List<IPAddress>();
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		for (int i = 0; i < allNetworkInterfaces.Length; i++)
		{
			foreach (UnicastIPAddressInformation unicastAddress in allNetworkInterfaces[i].GetIPProperties().UnicastAddresses)
			{
				list.Add(unicastAddress.Address);
			}
		}
		return list.ToArray();
	}

	private static bool NetworkChanged(IPAddress[] oldAddresses, IPAddress[] newAddresses)
	{
		if (oldAddresses.Length != newAddresses.Length)
		{
			return true;
		}
		for (int i = 0; i < newAddresses.Length; i++)
		{
			if (Array.IndexOf(oldAddresses, newAddresses[i]) == -1)
			{
				return true;
			}
		}
		return false;
	}

	private static void OnNetworkChanged()
	{
		Dictionary<NetworkAddressChangedEventHandler, ExecutionContext> dictionary = null;
		Dictionary<NetworkAvailabilityChangedEventHandler, ExecutionContext> dictionary2 = null;
		lock (s_lockObj)
		{
			if (s_addressChangedSubscribers.Count > 0)
			{
				dictionary = new Dictionary<NetworkAddressChangedEventHandler, ExecutionContext>(s_addressChangedSubscribers);
			}
			if (s_availabilityChangedSubscribers.Count > 0)
			{
				dictionary2 = new Dictionary<NetworkAvailabilityChangedEventHandler, ExecutionContext>(s_availabilityChangedSubscribers);
			}
		}
		if (dictionary != null)
		{
			foreach (KeyValuePair<NetworkAddressChangedEventHandler, ExecutionContext> item in dictionary)
			{
				NetworkAddressChangedEventHandler key = item.Key;
				ExecutionContext value = item.Value;
				if (value == null)
				{
					key(null, EventArgs.Empty);
				}
				else
				{
					ExecutionContext.Run(value, s_runAddressChangedHandler, key);
				}
			}
		}
		if (dictionary2 == null)
		{
			return;
		}
		bool isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
		NetworkAvailabilityEventArgs e = (isNetworkAvailable ? s_availableEventArgs : s_notAvailableEventArgs);
		ContextCallback callback = (isNetworkAvailable ? s_runHandlerAvailable : s_runHandlerNotAvailable);
		foreach (KeyValuePair<NetworkAvailabilityChangedEventHandler, ExecutionContext> item2 in dictionary2)
		{
			NetworkAvailabilityChangedEventHandler key2 = item2.Key;
			ExecutionContext value2 = item2.Value;
			if (value2 == null)
			{
				key2(null, e);
			}
			else
			{
				ExecutionContext.Run(value2, callback, key2);
			}
		}
	}
}

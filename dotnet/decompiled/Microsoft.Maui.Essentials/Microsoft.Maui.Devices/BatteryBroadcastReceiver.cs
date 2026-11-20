using System;
using Android.Content;

namespace Microsoft.Maui.Devices;

[BroadcastReceiver(Enabled = true, Exported = false, Label = "Essentials Battery Broadcast Receiver")]
internal class BatteryBroadcastReceiver : BroadcastReceiver
{
	private readonly Action? onChanged;

	public BatteryBroadcastReceiver()
	{
	}

	public BatteryBroadcastReceiver(Action onChanged)
	{
		this.onChanged = onChanged;
	}

	public override void OnReceive(Context? context, Intent? intent)
	{
		onChanged?.Invoke();
	}
}

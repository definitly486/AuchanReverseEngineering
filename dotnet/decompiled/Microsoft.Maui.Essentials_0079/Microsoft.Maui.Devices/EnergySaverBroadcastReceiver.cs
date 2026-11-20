using System;
using Android.Content;

namespace Microsoft.Maui.Devices;

[BroadcastReceiver(Enabled = true, Exported = false, Label = "Essentials Energy Saver Broadcast Receiver")]
internal class EnergySaverBroadcastReceiver : BroadcastReceiver
{
	private readonly Action? onChanged;

	public EnergySaverBroadcastReceiver()
	{
	}

	public EnergySaverBroadcastReceiver(Action onChanged)
	{
		this.onChanged = onChanged;
	}

	public override void OnReceive(Context? context, Intent? intent)
	{
		onChanged?.Invoke();
	}
}

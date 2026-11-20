using System;
using System.Threading.Tasks;
using Android.Content;

namespace Microsoft.Maui.Networking;

[BroadcastReceiver(Enabled = true, Exported = false, Label = "Essentials Connectivity Broadcast Receiver")]
internal class ConnectivityBroadcastReceiver : BroadcastReceiver
{
	private Action onChanged;

	public ConnectivityBroadcastReceiver()
	{
	}

	public ConnectivityBroadcastReceiver(Action onChanged)
	{
		this.onChanged = onChanged;
	}

	public override async void OnReceive(Context context, Intent intent)
	{
		if (!(intent.Action != "android.net.conn.CONNECTIVITY_CHANGE") || !(intent.Action != "com.maui.essentials.ESSENTIALS_CONNECTIVITY_CHANGED"))
		{
			await Task.Delay(1500);
			onChanged?.Invoke();
		}
	}
}

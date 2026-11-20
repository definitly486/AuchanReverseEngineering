using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Android.OS;
using Android.Runtime;

namespace Android.App;

internal class SyncContext : SynchronizationContext
{
	public override SynchronizationContext CreateCopy()
	{
		return new SyncContext();
	}

	private static bool EnsureLooper([NotNullWhen(true)] Looper? looper, SendOrPostCallback d)
	{
		if (looper == null)
		{
			string log = $"No Android message loop is available. Skipping invocation of `{d.Method.DeclaringType?.FullName}.{d.Method.Name}`!";
			Logger.Log(LogLevel.Error, "monodroid-synccontext", log);
			return false;
		}
		return true;
	}

	public override void Post(SendOrPostCallback d, object state)
	{
		Looper looper = Application.Context?.MainLooper;
		if (!EnsureLooper(looper, d))
		{
			return;
		}
		using Handler handler = new Handler(looper);
		handler.Post(delegate
		{
			d(state);
		});
	}

	public override void Send(SendOrPostCallback d, object state)
	{
		Looper mainLooper = Looper.MainLooper;
		if (!EnsureLooper(mainLooper, d))
		{
			return;
		}
		if (Looper.MyLooper() == mainLooper)
		{
			d(state);
			return;
		}
		ManualResetEvent m = new ManualResetEvent(initialState: false);
		using (Handler handler = new Handler(mainLooper))
		{
			handler.Post(delegate
			{
				d(state);
				m.Set();
			});
		}
		m.WaitOne();
	}
}

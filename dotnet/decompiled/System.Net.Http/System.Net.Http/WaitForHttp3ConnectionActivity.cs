using System.Diagnostics;

namespace System.Net.Http;

internal struct WaitForHttp3ConnectionActivity
{
	private HttpConnectionSettings _settings;

	private readonly HttpAuthority _authority;

	private Activity _activity;

	private long _startTimestamp;

	public bool Started { get; private set; }

	public WaitForHttp3ConnectionActivity(HttpConnectionSettings settings, HttpAuthority authority)
	{
		_activity = null;
		_startTimestamp = 0L;
		Started = false;
		_settings = settings;
		_authority = authority;
	}

	public void Start()
	{
		HttpTelemetry.Log.IsEnabled();
		if (false)
		{
		}
		_startTimestamp = 0L;
		_activity = ConnectionSetupDistributedTracing.StartWaitForConnectionActivity(_authority);
		Started = true;
	}

	public void Stop(HttpRequestMessage request, HttpConnectionPool pool, Exception exception)
	{
		if (exception != null)
		{
			ConnectionSetupDistributedTracing.ReportError(_activity, exception);
		}
		_activity?.Stop();
		if (_startTimestamp != 0L)
		{
			TimeSpan elapsedTime = Stopwatch.GetElapsedTime(_startTimestamp);
			if (false)
			{
			}
			if (!HttpTelemetry.Log.IsEnabled())
			{
			}
		}
	}
}

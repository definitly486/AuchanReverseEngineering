using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Java.Net;

namespace Xamarin.Android.Net;

public class AndroidHttpResponseMessage : HttpResponseMessage
{
	private URL? javaUrl;

	private HttpURLConnection? httpConnection;

	[CompilerGenerated]
	private IList<AuthenticationData>? _003CRequestedAuthentication_003Ek__BackingField;

	internal IList<AuthenticationData>? RequestedAuthentication
	{
		[CompilerGenerated]
		set
		{
			_003CRequestedAuthentication_003Ek__BackingField = value;
		}
	}

	public AndroidHttpResponseMessage(URL javaUrl, HttpURLConnection httpConnection)
	{
		this.javaUrl = javaUrl;
		this.httpConnection = httpConnection;
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (javaUrl != null)
		{
			javaUrl.Dispose();
		}
		if (httpConnection != null)
		{
			httpConnection.Dispose();
		}
	}
}

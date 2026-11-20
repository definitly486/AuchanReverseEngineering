using System.Net;
using Java.Net;

namespace Xamarin.Android.Net;

public interface IAndroidAuthenticationModule
{
	AuthenticationScheme Scheme { get; }

	Authorization Authenticate(string challenge, HttpURLConnection request, ICredentials credentials);
}

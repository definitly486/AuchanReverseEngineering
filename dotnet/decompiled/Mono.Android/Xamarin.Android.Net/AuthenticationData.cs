namespace Xamarin.Android.Net;

public class AuthenticationData
{
	public AuthenticationScheme Scheme { get; set; }

	public string? Challenge { get; internal set; }

	public bool UseProxyAuthentication { get; set; }

	public IAndroidAuthenticationModule? AuthModule { get; }
}

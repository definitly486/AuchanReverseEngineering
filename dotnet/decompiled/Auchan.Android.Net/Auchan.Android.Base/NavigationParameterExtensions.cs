using System;
using Android.OS;
using AndroidX.Fragment.App;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Android.Base;

internal static class NavigationParameterExtensions
{
	private const string NAV_PARAM_KEY = "NavigationParameter";

	public static Bundle ToNavBundle<T>(this T parameter, Bundle? existingBindle = null)
	{
		Bundle? obj = existingBindle ?? new Bundle();
		string value = JsonConvert.SerializeObject(parameter);
		obj.PutString("NavigationParameter", value);
		return obj;
	}

	public static T? NavParam<T>(this Fragment fragment) where T : class
	{
		string text = fragment.Arguments?.GetString("NavigationParameter");
		if (text == null)
		{
			return null;
		}
		return JsonConvert.DeserializeObject<T>(text);
	}

	public static T RequireNavParam<T>(this Fragment fragment) where T : class
	{
		return fragment.NavParam<T>() ?? throw new InvalidOperationException($"Fragment {fragment} does not have navigation parameters.");
	}

	public static BrokerToken RequireNavToken(this Fragment fragment)
	{
		return fragment.RequireNavParam<BrokerToken>();
	}
}

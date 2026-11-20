using System;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Analytics.YandexAppMetrica;

internal sealed class AppMetricaKeyProvider : IAppMetricaKeyProvider
{
	private const string KEY_ID = "0CBD4ED4-2DBD-489F-9494-D652EA984836";

	private const string SHARED_VALUE = "39139B2E-84EE-4180-8F0A-9DDC5A12F06D";

	private readonly Lazy<IAdminContext> _adminContext;

	public string CustomKey
	{
		get
		{
			return Preferences.Get("0CBD4ED4-2DBD-489F-9494-D652EA984836", string.Empty, "39139B2E-84EE-4180-8F0A-9DDC5A12F06D");
		}
		set
		{
			Preferences.Set("0CBD4ED4-2DBD-489F-9494-D652EA984836", value, "39139B2E-84EE-4180-8F0A-9DDC5A12F06D");
		}
	}

	public AppMetricaKeyProvider(Lazy<IAdminContext> adminContext)
	{
		_adminContext = adminContext;
	}

	public async Task<string> GetKeyAsync()
	{
		string customKey = CustomKey;
		if (!string.IsNullOrEmpty(customKey))
		{
			return customKey;
		}
		return (await _adminContext.Value.WaitForAppConfig()).AppMetricaPostApiKey;
	}
}

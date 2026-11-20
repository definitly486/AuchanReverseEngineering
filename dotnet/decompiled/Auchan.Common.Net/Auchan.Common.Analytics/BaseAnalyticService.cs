using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.Analytics;

public abstract class BaseAnalyticService : IAnalyticsService
{
	private readonly IUserContext _userContext;

	protected BaseAnalyticService(IUserContext userContext)
	{
		_userContext = userContext;
		_userContext.BeforeLoggedOut += OnLoggedOut;
		_userContext.AfterLoggedIn += OnLoggedIn;
	}

	protected virtual void Initialize()
	{
		SetUserId(_userContext.Profile);
	}

	private Task OnLoggedOut()
	{
		SetUserId(null);
		return Task.CompletedTask;
	}

	private Task OnLoggedIn()
	{
		SetUserId(_userContext.Profile);
		return Task.CompletedTask;
	}

	public abstract void TrackEvent(string eventName);

	public abstract void TrackEvent(string eventName, IDictionary<string, string> parameters);

	public abstract void TrackScreen(string screenName);

	protected abstract void SetUserId(ProfileModel? model);
}

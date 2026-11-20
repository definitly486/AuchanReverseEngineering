using System;
using System.Threading.Tasks;
using Auchan.Common.Feedback;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Profile;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Devices;

namespace Auchan.Common.Navigation;

public abstract class BaseNavigationService : INavigationService
{
	private readonly IUserContext _userContext;

	protected readonly INavigationContext _navigationContext;

	protected readonly IExternalAppsLinkCreator _externalAppsLinkCreator;

	private readonly IFeedbackContactsProvider _feedbackContactsProvider;

	private readonly Lazy<ILoginManager> _loginManager;

	private Type? _currentDestination;

	private object? _currentParameter;

	public BaseNavigationService(INavigationContext context, IUserContext userContext, IExternalAppsLinkCreator externalAppsLinkCreator, IFeedbackContactsProvider feedbackContactsProvider, Lazy<ILoginManager> loginManager)
	{
		_userContext = userContext;
		_navigationContext = context;
		_externalAppsLinkCreator = externalAppsLinkCreator;
		_feedbackContactsProvider = feedbackContactsProvider;
		_loginManager = loginManager;
	}

	public void NavigateTo(Type viewModelType, object? parameter = null, Action? afterNavigation = null)
	{
		_navigationContext.IsNavigating = true;
		MainThread.BeginInvokeOnMainThread(async delegate
		{
			if (!_userContext.Authorized && RequiresAuthorization(viewModelType))
			{
				_navigationContext.AfterAuthNavigationType = viewModelType;
				_navigationContext.AfterAuthNavigationParameter = parameter;
				await _loginManager.Value.LoginAsync(displayOnboardings: false);
			}
			else
			{
				if (_userContext.Authorized && (viewModelType == typeof(AuthOrRegisterViewModel) || viewModelType == typeof(LoginViewModel)))
				{
					viewModelType = typeof(ProfileViewModel);
					parameter = null;
				}
				_currentDestination = viewModelType;
				_currentParameter = parameter;
				await PerformNavigationAsync(viewModelType, parameter);
				afterNavigation?.Invoke();
			}
		});
	}

	public virtual void ReadyForDelayedNavigation()
	{
		if (_navigationContext.IsAwaitingDelayedNavigation)
		{
			Type delayedNavigationType = _navigationContext.DelayedNavigationType;
			object delayedNavigationParameter = _navigationContext.DelayedNavigationParameter;
			TaskCompletionSource tcs = _navigationContext.DelayedNavigationTaskSource;
			_navigationContext.DelayedNavigationType = null;
			_navigationContext.DelayedNavigationParameter = null;
			_navigationContext.DelayedNavigationTaskSource = null;
			NavigateTo(delayedNavigationType, delayedNavigationParameter, delegate
			{
				tcs?.TrySetResult();
			});
		}
		else if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			ReadyForNavigationAfterAuth();
		}
	}

	public virtual void ReadyForNavigationAfterAuth()
	{
		if (_navigationContext.AfterAuthNavigationType != null)
		{
			Type afterAuthNavigationType = _navigationContext.AfterAuthNavigationType;
			object afterAuthNavigationParameter = _navigationContext.AfterAuthNavigationParameter;
			_navigationContext.AfterAuthNavigationType = null;
			_navigationContext.AfterAuthNavigationParameter = null;
			NavigateTo(afterAuthNavigationType, afterAuthNavigationParameter);
		}
	}

	public abstract void WriteFeedback();

	public void CallToAuchanSupport()
	{
		CallTo(_feedbackContactsProvider.Phone);
	}

	public void CallTo(string number)
	{
		if (PhoneDialer.Default.IsSupported)
		{
			PhoneDialer.Default.Open(number);
		}
	}

	protected abstract Task PerformNavigationAsync(Type viewModelType, object? parameter);

	protected void DelayNavigation()
	{
		_navigationContext.DelayedNavigationType = _currentDestination;
		_navigationContext.DelayedNavigationParameter = _currentParameter;
		_navigationContext.DelayedNavigationTaskSource = new TaskCompletionSource();
		_navigationContext.IsNavigating = false;
	}

	public void ResetDelayedNavigation()
	{
		_navigationContext.DelayedNavigationType = null;
		_navigationContext.DelayedNavigationParameter = null;
		_navigationContext.DelayedNavigationTaskSource?.TrySetResult();
		_navigationContext.DelayedNavigationTaskSource = null;
	}

	public void ResetAfterAuthNavigation()
	{
		_navigationContext.AfterAuthNavigationType = null;
		_navigationContext.AfterAuthNavigationParameter = null;
	}

	protected void NavigationSuccessful()
	{
		_navigationContext.DelayedNavigationType = null;
		_navigationContext.DelayedNavigationParameter = null;
		_navigationContext.DelayedNavigationTaskSource?.TrySetResult();
		_navigationContext.DelayedNavigationTaskSource = null;
		_currentDestination = null;
		_currentParameter = null;
		_navigationContext.IsNavigating = false;
	}

	protected void NavigationFailure()
	{
		_currentDestination = null;
		_currentParameter = null;
		_navigationContext.IsNavigating = false;
	}

	private bool RequiresAuthorization(Type viewModelType)
	{
		if (viewModelType == typeof(AuthOrRegisterViewModel))
		{
			return false;
		}
		return true;
	}
}

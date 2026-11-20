using System;

namespace Auchan.Common.Navigation;

public interface INavigationService
{
	void NavigateTo(Type viewModelType, object? parameter = null, Action? afterNavigation = null);

	void WriteFeedback();

	void CallToAuchanSupport();

	void CallTo(string number);

	void ReadyForDelayedNavigation();

	void ReadyForNavigationAfterAuth();

	void ResetDelayedNavigation();

	void ResetAfterAuthNavigation();
}

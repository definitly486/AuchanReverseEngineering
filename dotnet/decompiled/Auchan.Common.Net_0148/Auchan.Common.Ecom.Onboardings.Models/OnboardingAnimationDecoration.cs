using System.Diagnostics.CodeAnalysis;

namespace Auchan.Common.Ecom.Onboardings.Models;

internal sealed class OnboardingAnimationDecoration : IOnboardingDecoration
{
	private readonly string _url;

	public OnboardingAnimationDecoration(string url)
	{
		_url = url;
	}

	public bool TryGetAnimationUrl([NotNullWhen(true)] out string? animationUrl)
	{
		animationUrl = _url;
		return true;
	}
}

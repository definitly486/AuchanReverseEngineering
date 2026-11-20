using System.Diagnostics.CodeAnalysis;

namespace Auchan.Common.Ecom.Onboardings.Models;

internal sealed class OnboardingImageDecoration : IOnboardingDecoration
{
	private readonly string _url;

	public OnboardingImageDecoration(string url)
	{
		_url = url;
	}

	public bool TryGetImageUrl([NotNullWhen(true)] out string? imageUrl)
	{
		imageUrl = _url;
		return true;
	}
}

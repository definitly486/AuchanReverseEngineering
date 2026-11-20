using System.Diagnostics.CodeAnalysis;

namespace Auchan.Common.Ecom.Onboardings.Models;

public interface IOnboardingDecoration
{
	bool TryGetImageUrl([NotNullWhen(true)] out string? imageUrl)
	{
		imageUrl = null;
		return false;
	}

	bool TryGetAnimationUrl([NotNullWhen(true)] out string? animationUrl)
	{
		animationUrl = null;
		return false;
	}
}

using System;

namespace SkiaSharp.Views;

internal static class EnvironmentExtensions
{
	private static readonly Lazy<bool> isValidEnvironment = new Lazy<bool>(delegate
	{
		try
		{
			SKPMColor.PreMultiply(SKColors.Black);
			return true;
		}
		catch (DllNotFoundException)
		{
			return false;
		}
	});

	internal static bool IsValidEnvironment => isValidEnvironment.Value;
}

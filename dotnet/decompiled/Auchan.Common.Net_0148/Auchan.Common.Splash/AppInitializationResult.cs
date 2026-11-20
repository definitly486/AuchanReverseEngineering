namespace Auchan.Common.Splash;

public class AppInitializationResult
{
	public SplashViewModel.VisualState SplashScreenState { get; }

	public AppInitError? InitError { get; }

	public SplashScreenNextNavigation SplashScreenNextNavigation { get; }

	public bool HasError
	{
		get
		{
			if (SplashScreenState != SplashViewModel.VisualState.Default)
			{
				return InitError != null;
			}
			return false;
		}
	}

	public AppInitializationResult(SplashViewModel.VisualState splashScreenState, SplashScreenNextNavigation splashScreenNextNavigation, AppInitError? initError = null)
	{
		SplashScreenState = splashScreenState;
		InitError = initError;
		SplashScreenNextNavigation = splashScreenNextNavigation;
	}
}

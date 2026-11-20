namespace Auchan.Common.Splash;

public class AppInitError
{
	public string Title { get; }

	public string Message { get; }

	public string RetryButtonText { get; }

	public AppInitError(string title, string message, string retryButtonText)
	{
		Title = title;
		Message = message;
		RetryButtonText = retryButtonText;
	}
}

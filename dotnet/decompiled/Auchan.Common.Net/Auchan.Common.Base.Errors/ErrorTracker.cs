namespace Auchan.Common.Base.Errors;

public class ErrorTracker
{
	public void OnError(object sender, string message)
	{
		string.IsNullOrWhiteSpace(message);
	}
}

namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyPersonalizedGreetingEntity
{
	public string Title { get; }

	public string GreetingMessage { get; }

	public LoyaltyPersonalizedGreetingEntity(string title, string greetingMessage)
	{
		Title = title;
		GreetingMessage = greetingMessage;
	}
}

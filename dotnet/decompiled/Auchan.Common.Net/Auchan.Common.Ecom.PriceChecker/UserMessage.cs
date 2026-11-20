using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Ecom.PriceChecker;

public class UserMessage : DomainError
{
	public static readonly UserMessage Default = new UserMessage
	{
		MessageState = MessageState.Default
	};

	public MessageState MessageState { get; set; } = MessageState.Red;

	public string Title { get; set; } = string.Empty;
}

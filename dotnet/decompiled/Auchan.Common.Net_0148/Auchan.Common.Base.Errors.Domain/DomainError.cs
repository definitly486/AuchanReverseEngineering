namespace Auchan.Common.Base.Errors.Domain;

public abstract class DomainError
{
	public string? Message { get; set; } = string.Empty;

	public override string ToString()
	{
		if (!string.IsNullOrWhiteSpace(Message))
		{
			return Message;
		}
		return GetType().Name;
	}
}

namespace Auchan.Common.PersonalCabinet.DomainModels;

public class SubscriptionCommunicationModel
{
	public int Id { get; }

	public string Title { get; }

	public SubscriptionCommunicationModel(int id, string title)
	{
		Id = id;
		Title = title;
	}
}

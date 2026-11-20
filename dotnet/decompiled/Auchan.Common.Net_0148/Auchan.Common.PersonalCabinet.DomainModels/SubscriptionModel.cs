using System;

namespace Auchan.Common.PersonalCabinet.DomainModels;

public class SubscriptionModel
{
	public int? Id { get; set; }

	public SubscriptionCommunicationModel CommunicationType { get; set; }

	public SubscriptionTypeModel Type { get; set; }

	public DateTime StartDate { get; set; }

	public DateTime? EndDate { get; set; }
}

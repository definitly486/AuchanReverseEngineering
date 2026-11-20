using System.Collections.Generic;

namespace Auchan.Common.PersonalCabinet.DomainModels;

public class SubscriptionsListModel
{
	public List<SubscriptionTypeModel> SubscriptionTypes { get; set; }

	public List<SubscriptionCommunicationModel> SubscriptionCommTypes { get; set; }
}

using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

[JsonConverter(typeof(BatchRequestConverter))]
public sealed class BatchItemRequest
{
	public string EventName { get; }

	public TrackingRequest Request { get; }

	public BatchItemRequest(string eventName, TrackingRequest request)
	{
		EventName = eventName;
		Request = request;
	}
}

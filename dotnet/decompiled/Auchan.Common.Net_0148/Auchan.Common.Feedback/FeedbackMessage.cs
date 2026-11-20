using Newtonsoft.Json;

namespace Auchan.Common.Feedback;

public sealed class FeedbackMessage
{
	[JsonProperty("city")]
	public FeedbackCity City { get; set; }

	[JsonProperty("store")]
	public FeedbackStore? Store { get; set; }

	[JsonProperty("email")]
	public string Email { get; set; }

	[JsonProperty("phone")]
	public string? Phone { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("category_id")]
	public int CategoryId { get; set; }

	[JsonProperty("subject_id")]
	public int? SubjectId { get; set; }

	[JsonProperty("body")]
	public string Body { get; set; }

	[JsonProperty("attachments")]
	public FeedbackAttachment[]? Attachments { get; set; }

	[JsonProperty("send_to_email_pok")]
	public bool? SendToEmailPok { get; set; }

	public FeedbackMessage(FeedbackCity city, string email, string name, int categoryId, string body, bool? sendToEmailPok = null, string? phone = null, FeedbackStore? store = null, int? subjectId = null, FeedbackAttachment[]? attachments = null)
	{
		City = city;
		Store = store;
		Email = email;
		Phone = phone;
		Name = name;
		CategoryId = categoryId;
		SubjectId = subjectId;
		Body = body;
		Attachments = attachments;
		SendToEmailPok = sendToEmailPok;
	}
}

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public class ShareTextRequest : ShareRequestBase
{
	public string? Text { get; set; }

	public string? Subject { get; }

	public string? Uri { get; }

	public ShareTextRequest()
	{
	}

	public ShareTextRequest(string text)
	{
		Text = text;
	}

	public ShareTextRequest(string text, string title)
		: this(text)
	{
		base.Title = title;
	}
}

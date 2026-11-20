namespace Auchan.Common.Streams;

public class StreamItemViewModel
{
	public bool IsBlockTitle { get; }

	public string BlockTitle { get; }

	public string Id { get; }

	public string ImageUrl { get; }

	public bool IsAvailable { get; }

	public StreamItemViewModel(string blockTitle)
	{
		IsBlockTitle = true;
		BlockTitle = blockTitle;
		Id = string.Empty;
		ImageUrl = string.Empty;
	}

	public StreamItemViewModel(string id, string imageUrl, bool isAvailable)
	{
		BlockTitle = string.Empty;
		Id = id;
		ImageUrl = "https://api.shopstory.live" + imageUrl;
		IsAvailable = isAvailable;
	}
}

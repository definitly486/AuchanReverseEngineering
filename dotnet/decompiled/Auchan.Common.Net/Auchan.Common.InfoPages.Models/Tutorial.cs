namespace Auchan.Common.InfoPages.Models;

public class Tutorial
{
	public TutorialContentType ContentType { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public string Url { get; set; }

	public string? BannerUrl { get; set; }

	public Tutorial(TutorialContentType contentType, string title, string description, string url, string? bannerUrl)
	{
		ContentType = contentType;
		Title = title;
		Description = description;
		Url = url;
		BannerUrl = bannerUrl;
	}
}

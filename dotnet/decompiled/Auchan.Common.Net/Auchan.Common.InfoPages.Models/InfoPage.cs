namespace Auchan.Common.InfoPages.Models;

public class InfoPage
{
	public InfoContentType ContentType { get; set; }

	public InfoPagePosition Position { get; set; }

	public string Slug { get; set; }

	public string Url { get; set; }

	public string Title { get; set; }

	public string Content { get; set; }

	public string BannerUrl { get; set; }

	public string IconUrl { get; set; }

	public InfoPage(InfoContentType infoContentType, InfoPagePosition position, string slug, string url, string title, string content, string bannerUrl, string iconUrl)
	{
		ContentType = infoContentType;
		Position = position;
		Slug = slug;
		Url = url;
		Title = title;
		Content = content;
		BannerUrl = bannerUrl;
		IconUrl = iconUrl;
	}
}

namespace Auchan.Common.InfoPages.Models;

public class InfoPageIntermediateModel
{
	public string Slug { get; }

	public string Title { get; }

	public string IconUrl { get; }

	public InfoPageIntermediateModel(InfoPage infoPage)
	{
		Slug = infoPage.Slug;
		Title = infoPage.Title;
		IconUrl = infoPage.IconUrl;
	}
}

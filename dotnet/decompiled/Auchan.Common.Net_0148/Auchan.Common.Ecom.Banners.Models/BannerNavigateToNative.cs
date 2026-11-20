using Auchan.Common.Common;

namespace Auchan.Common.Ecom.Banners.Models;

internal sealed class BannerNavigateToNative : IBannerNavigateTo
{
	private readonly string _title;

	private readonly string _content;

	public BannerNavigateToNative(string title, string content)
	{
		_title = title;
		_content = content;
	}

	public void Activate(IBannerNavigationSupport viewModel)
	{
		WebViewModel.Parameter subject = new WebViewModel.Parameter
		{
			Title = _title,
			Content = _content,
			Url = null
		};
		viewModel.OpenWebViewCommand.Trigger(subject);
	}
}

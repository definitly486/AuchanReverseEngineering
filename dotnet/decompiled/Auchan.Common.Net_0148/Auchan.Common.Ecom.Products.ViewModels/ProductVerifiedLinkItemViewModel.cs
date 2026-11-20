using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Products.ViewModels;

public sealed class ProductVerifiedLinkItemViewModel : BaseItemViewModel
{
	public UICommand<string> OpenLinkCommand { get; }

	public LinkedText Description { get; }

	public ProductVerifiedLinkItemViewModel(string url, string linkText, UICommand<string> openLinkCommand)
	{
		ProductVerifiedLinkItemViewModel productVerifiedLinkItemViewModel = this;
		OpenLinkCommand = openLinkCommand;
		Description = new LinkedText("{0}", linkText, delegate
		{
			productVerifiedLinkItemViewModel.OpenLinkCommand.Trigger(url);
		});
	}
}

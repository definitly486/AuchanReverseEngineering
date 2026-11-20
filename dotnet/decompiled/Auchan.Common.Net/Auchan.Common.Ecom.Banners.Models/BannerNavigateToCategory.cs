using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Common.Ecom.Banners.Models;

internal sealed class BannerNavigateToCategory : IBannerNavigateTo
{
	private readonly IDataBroker _dataBroker;

	private readonly long _id;

	private readonly string _code;

	private readonly string _name;

	public BannerNavigateToCategory(IDataBroker dataBroker, long id, string code, string name)
	{
		_dataBroker = dataBroker;
		_id = id;
		_code = code;
		_name = name;
	}

	public void Activate(IBannerNavigationSupport viewModel)
	{
		CatalogProductsViewModel.Parameter data = new CatalogProductsViewModel.Parameter(_name, _code.Split('/').Last(), ProductsToLoad.ByCategory, _id);
		viewModel.OpenCategoryCommand.Trigger(_dataBroker.Push(data));
	}
}

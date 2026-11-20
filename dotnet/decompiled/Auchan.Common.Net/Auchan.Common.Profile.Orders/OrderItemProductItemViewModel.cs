using System.Linq;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class OrderItemProductItemViewModel : BaseItemViewModel, IWithImageUrl
{
	public string ImageUrl { get; }

	public OrderItemProductItemViewModel(ProductModel product)
	{
		ImageUrl = product.SelectedModifications.FirstOrDefault((SelectedModification c) => !string.IsNullOrEmpty(c.Value?.PreviewImageUrl))?.Value?.PreviewImageUrl ?? product.ImageUrl?.ToString();
	}
}

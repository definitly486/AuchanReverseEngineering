using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Reviews;

public class UnreviewedProductItemViewModel : BaseItemViewModel
{
	[CompilerGenerated]
	private UnreviewedProduct _003CProduct_003Ek__BackingField;

	public string ImageUrl => Product.ImageUrl;

	public string Title => Product.Title;

	public string GimaId
	{
		get
		{
			if (!string.IsNullOrEmpty(Product.GimaId))
			{
				return Product.GimaId;
			}
			return string.Empty;
		}
	}

	public ReviewRewardSticker? ReviewRewardSticker => Product.ReviewRewardSticker;

	public UnreviewedProduct Product
	{
		[CompilerGenerated]
		get
		{
			return _003CProduct_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CProduct_003Ek__BackingField, value))
			{
				_003CProduct_003Ek__BackingField = value;
				RaisePropertyChanged("ImageUrl");
				RaisePropertyChanged("Title");
				RaisePropertyChanged("GimaId");
				RaisePropertyChanged("ReviewRewardSticker");
				RaisePropertyChanged("Product");
			}
		}
	}

	public UnreviewedProductItemViewModel(UnreviewedProduct product)
	{
		Product = product;
	}
}

using System.Collections.ObjectModel;
using Auchan.Common.Ecom.Banners.Models;

namespace Auchan.Common.Profile.SalesAndNews;

public interface ISalesAndNewsSource
{
	ObservableRangeCollection<Banner> SalesAndNewsList { get; }

	void OnSalesOrNewsClicked(Banner salesAndNewsItemViewModel);
}

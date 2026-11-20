using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom;

public interface IPromoDiscountUsecase
{
	Task ProcessComboSuggection(ProductOffer offer, IPromoDiscountUsecaseSupport support, ICollection<IDisposable> disposables);

	void ProcessOfferChange(ProductOfferChange change, IPromoDiscountUsecaseSupport support, ICollection<IDisposable> disposables);
}

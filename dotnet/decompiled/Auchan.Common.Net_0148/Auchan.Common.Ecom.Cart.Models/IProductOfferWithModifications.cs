using System.Collections.Generic;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Cart.Models;

public interface IProductOfferWithModifications
{
	long? Id { get; }

	IReadOnlyList<SelectedModification> SelectedModifications { get; }
}

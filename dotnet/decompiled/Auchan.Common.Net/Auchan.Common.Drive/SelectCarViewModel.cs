using Auchan.Common.Base.Errors;
using Auchan.Common.Ecom.Drive;

namespace Auchan.Common.Drive;

public class SelectCarViewModel : UserCarsViewModel
{
	public SelectCarViewModel(ICarsRepository carsRepository, DefaultErrorTranslator errorTranslator)
		: base(carsRepository, errorTranslator)
	{
	}
}

using Auchan.Common.Ecom.Drive;

namespace Auchan.Common.Drive;

public class UserCarsItemViewModel
{
	public Car? Car { get; private set; }

	public string CarNumber => Car?.CarNumber ?? string.Empty;

	public string CarName => (Car?.CarColor ?? string.Empty) + " " + (Car?.CarMark ?? string.Empty);

	public bool IsEnabled => Car?.IsDefault ?? false;

	public UserCarsItemViewType ViewType { get; set; }

	public UserCarsItemViewModel(Car car)
	{
		Car = car;
	}

	public UserCarsItemViewModel(UserCarsItemViewType viewType)
	{
		ViewType = viewType;
	}
}

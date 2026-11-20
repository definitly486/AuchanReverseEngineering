using System;
using Auchan.Common.Drive;

namespace Auchan.Android.Drive;

internal class AddCarPopupFragment : CarFormPopupFragment<AddCarViewModel>
{
	public AddCarPopupFragment(Func<CarFormViewModel.Parameter, AddCarViewModel> newViewModel)
		: base(newViewModel)
	{
	}
}

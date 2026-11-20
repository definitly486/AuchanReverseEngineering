using System;
using Auchan.Common.Drive;

namespace Auchan.Android.Drive;

internal class EditCarPopupFragment : CarFormPopupFragment<EditCarViewModel>
{
	public EditCarPopupFragment(Func<CarFormViewModel.Parameter, EditCarViewModel> newViewModel)
		: base(newViewModel)
	{
	}
}

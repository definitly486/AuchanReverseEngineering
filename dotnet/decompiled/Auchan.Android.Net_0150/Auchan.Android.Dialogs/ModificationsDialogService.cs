using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products.Modifications;
using Auchan.Common.Managers.Dialogs;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Dialogs;

public class ModificationsDialogService : IModificationsDialogService
{
	private readonly FragmentFactory _fragmentFactory;

	public ModificationsDialogService(FragmentFactory fragmentFactory)
	{
		_fragmentFactory = fragmentFactory;
	}

	public void ShowModificationsPopup(Product product)
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			PopupProductModifications popupProductModifications = _fragmentFactory.Instantiate<PopupProductModifications>();
			popupProductModifications.Arguments = new PopupModificationsViewModel.Parameter(product).ToNavBundle();
			popupProductModifications.Show(appCompatActivity.SupportFragmentManager, null);
		}
	}
}

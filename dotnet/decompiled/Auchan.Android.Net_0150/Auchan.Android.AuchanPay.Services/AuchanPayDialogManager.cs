using System.Reactive;
using System.Threading.Tasks;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using Auchan.Android.Extensions;
using Auchan.Common.AuchanPay.Services;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.AuchanPay.Services;

public class AuchanPayDialogManager : IAuchanPayDialogManager
{
	private readonly FragmentFactory _fragmentFactory;

	public AuchanPayDialogManager(FragmentFactory fragmentFactory)
	{
		_fragmentFactory = fragmentFactory;
	}

	public async Task<Unit> OpenAuchanPayUnavailablePopup()
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			AuchanPayUnavailableFragment auchanPayUnavailableFragment = _fragmentFactory.Instantiate<AuchanPayUnavailableFragment>();
			auchanPayUnavailableFragment.Show(appCompatActivity.SupportFragmentManager, null);
			return await auchanPayUnavailableFragment.Execute();
		}
		return await Task.FromResult(Unit.Default);
	}
}

using System.Threading.Tasks;
using Auchan.Common.Ecom.Search.Infrastructure;

namespace Auchan.Common.Base;

public class BottomNavigationNotAuthViewModel : ScreenViewModel
{
	public enum TabbarItem
	{
		Home,
		Catalog,
		Cart,
		Loyalty,
		Profile
	}

	private readonly SearchProductsManager _searchManager;

	public BottomNavigationNotAuthViewModel(SearchProductsManager searchManager)
	{
		_searchManager = searchManager;
	}

	protected override async Task Start()
	{
		await base.Start();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		SetReadyForNavigation();
	}

	public async Task DoResetSearchStateAsync()
	{
		await Task.Delay(100);
		_searchManager.ResetSearchState();
	}

	private void SetReadyForNavigation()
	{
	}
}

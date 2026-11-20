using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Navigation;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.DeveloperMenu;

public class ChangeEnvironmentUseCase
{
	private readonly IEnvironmentManager _environmentManager;

	private readonly IAdminContext _adminContext;

	private readonly IUserContext _userContext;

	private readonly IEcomContext _ecomContext;

	private readonly INavigationContext _navigationContext;

	private readonly Cart _cart;

	public ChangeEnvironmentUseCase(IEnvironmentManager environmentManager, IAdminContext adminContext, IUserContext userContext, IEcomContext ecomContext, INavigationContext navigationContext, Cart cart)
	{
		_environmentManager = environmentManager;
		_adminContext = adminContext;
		_userContext = userContext;
		_ecomContext = ecomContext;
		_navigationContext = navigationContext;
		_cart = cart;
	}

	public async Task Execute(Environment environment)
	{
		await _adminContext.CleanDeinitialize();
		await _userContext.LogOut();
		await _ecomContext.CleanDeinitialize();
		await _cart.ClearCache();
		_navigationContext.IsStartForExtraOnboardingsShowed = false;
		_environmentManager.CurrentEnvironment = environment;
	}
}

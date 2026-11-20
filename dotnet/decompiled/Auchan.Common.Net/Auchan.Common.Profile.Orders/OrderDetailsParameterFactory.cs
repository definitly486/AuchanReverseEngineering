using System;
using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

internal class OrderDetailsParameterFactory : IOrderDetailsParameterFactory
{
	private sealed class PassToken : IOrderDetailsParameterFactory.IPassToken
	{
	}

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	public OrderDetailsParameterFactory(Lazy<IEcomContext> ecomContext, Lazy<IAgeGateDialog> ageGateDialog)
	{
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
	}

	public async Task<OrderDetailsViewModel.Parameter?> CreateAsync(IOrderModel orderModel)
	{
		bool flag = !orderModel.IsAdult || _ecomContext.Value.AgeGateAgreement == AgreeState.Yes;
		if (!flag)
		{
			flag = await _ageGateDialog.Value.ShowAgeGateDialogAsync() == AgreeState.Yes;
		}
		if (flag)
		{
			return new OrderDetailsViewModel.Parameter(orderModel.Id, new PassToken());
		}
		return null;
	}
}

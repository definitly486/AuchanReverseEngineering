using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class AvailableShopsPopupViewModel : ScreenViewModel
{
	public class Parameter
	{
		public IReadOnlyList<AvailableShop> AvailableShops { get; init; } = Array.Empty<AvailableShop>();

		public Parameter(ProductItemViewModel viewModel)
		{
			if (viewModel?.Product.Stock?.Shops != null)
			{
				AvailableShops = viewModel.Product.Stock.Shops;
			}
			if (viewModel != null && viewModel.Product.Price?.UnitType == ProductUnitType.Unit)
			{
				return;
			}
			foreach (AvailableShop availableShop in AvailableShops)
			{
				availableShop.IsLessOrEqualTwo = false;
				decimal? qty = availableShop.Qty;
				decimal num = 2;
				object qtyText;
				if (!((qty.GetValueOrDefault() <= num) & qty.HasValue))
				{
					qtyText = $"В наличии: {availableShop.Qty} кг";
				}
				else
				{
					qty = availableShop.Qty % (decimal?)10;
					num = 1;
					qtyText = (((qty.GetValueOrDefault() == num) & qty.HasValue) ? $"Остался {availableShop.Qty} кг" : $"Осталось {availableShop.Qty} кг");
				}
				availableShop.QtyText = (string?)qtyText;
			}
		}
	}

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	public UICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCloseCommand_003Ek__BackingField, value))
			{
				_003CCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseCommand");
			}
		}
	} = new UICommand();

	public IReadOnlyList<AvailableShop> AvailableShops { get; }

	public string Title => "Список магазинов";

	public AvailableShopsPopupViewModel(Parameter parameter)
	{
		AvailableShops = parameter.AvailableShops;
	}
}

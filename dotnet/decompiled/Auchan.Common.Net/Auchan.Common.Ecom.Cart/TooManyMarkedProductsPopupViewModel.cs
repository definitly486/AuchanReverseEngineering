using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Helpers;

namespace Auchan.Common.Ecom.Cart;

public sealed class TooManyMarkedProductsPopupViewModel : ScreenViewModel
{
	public sealed record Parameter
	{
		public required MarkingInfo MarkingInfo { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private Parameter(Parameter original)
		{
			MarkingInfo = original.MarkingInfo;
		}

		public Parameter()
		{
		}
	}

	private readonly Parameter _parameter;

	public string Title => "Слишком много маркированных товаров";

	public string Message => $"Для одного заказа доступно {GetNoun(_parameter.MarkingInfo.Limit)}. Пожалуйста, уберите {GetNoun(_parameter.MarkingInfo.Excess)} из выбора или уменьшите их количество";

	public string ButtonText => "Хорошо";

	public UICommand CloseCommand { get; } = new UICommand();

	public TooManyMarkedProductsPopupViewModel(Parameter parameter)
	{
		_parameter = parameter;
	}

	private string GetNoun(int noun)
	{
		return $"{noun} {GrammarHelper.DeclineNoun(noun, "маркированный товар", "маркированных товара", "маркированных товаров")}";
	}
}

using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Profile.Orders;

public sealed class AddToOrderFailedViewModel : ScreenViewModel
{
	public sealed class Parameter
	{
		public required string Title { get; init; }

		public required string Description { get; init; }
	}

	private readonly Parameter _parameter;

	public string Title => _parameter.Title;

	public string Description => _parameter.Description;

	public string DoneButtonText => "Вернуться в корзину";

	public UICommand CloseCommand { get; } = new UICommand();

	public AddToOrderFailedViewModel(Parameter parameter)
	{
		_parameter = parameter;
	}
}

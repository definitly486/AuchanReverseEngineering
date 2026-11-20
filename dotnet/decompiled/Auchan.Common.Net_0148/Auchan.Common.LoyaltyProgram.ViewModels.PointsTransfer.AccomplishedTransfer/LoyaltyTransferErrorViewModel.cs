using Auchan.Common.LoyaltyProgram.Managers;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;

public class LoyaltyTransferErrorViewModel : BaseLoyaltyPointsSentSuccessViewModel
{
	public class Parameter
	{
		public string ErrorTitle { get; protected set; }

		public string ErrorDescription { get; protected set; }

		public Parameter(string errorTitle, string errorDescription)
		{
			ErrorTitle = errorTitle;
			ErrorDescription = errorDescription;
		}
	}

	private readonly Parameter _parameter;

	public string Title => _parameter.ErrorTitle;

	public string Description => _parameter.ErrorDescription;

	public override string ContinueButtonText => "Продолжить";

	public LoyaltyTransferErrorViewModel(Parameter parameter, ILoyaltyManager loyaltyManager)
		: base(loyaltyManager)
	{
		_parameter = parameter;
	}
}

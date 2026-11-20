using Auchan.Common.LoyaltyProgram.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public class LoyaltyPointsTransferNavigationParameter
{
	public LoyaltyPointType PointType { get; set; }

	public bool ReplacePrevious { get; set; }

	public int PointsBalanceInt { get; set; }

	public int PointsBalanceFraction { get; set; }

	public int StampsBalance { get; set; }

	public bool ForStamps { get; set; }

	[JsonConstructor]
	public LoyaltyPointsTransferNavigationParameter()
	{
	}

	public LoyaltyPointsTransferNavigationParameter(int points, int pointsFraction, int stamps, LoyaltyPointType pointType, bool replacePrevious, bool forStamps = false)
	{
		PointsBalanceInt = points;
		PointsBalanceFraction = pointsFraction;
		StampsBalance = stamps;
		PointType = pointType;
		ReplacePrevious = replacePrevious;
		ForStamps = forStamps;
	}
}

using System.Collections.Generic;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.LoyaltyProgram.Models;

public class DelayedPointsEntity
{
	public List<DelayedPointsEntryEntity> DelayedPoints { get; set; }

	public LoyaltyCurrencyDto[]? DelayedCurrencyList { get; set; }

	public DelayedPointsEntity(List<DelayedPointsEntryEntity> delayedPoints)
	{
		DelayedPoints = delayedPoints;
	}
}

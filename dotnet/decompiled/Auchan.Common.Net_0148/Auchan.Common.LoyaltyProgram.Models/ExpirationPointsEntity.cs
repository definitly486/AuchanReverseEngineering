using System;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.LoyaltyProgram.Models;

public class ExpirationPointsEntity
{
	public decimal Points { get; set; }

	public ExpirationPointType PointType { get; set; }

	public DateTime ExpirationDate { get; set; }

	public LoyaltyCurrencyDto[]? ExpirationCurrencyList { get; set; }
}

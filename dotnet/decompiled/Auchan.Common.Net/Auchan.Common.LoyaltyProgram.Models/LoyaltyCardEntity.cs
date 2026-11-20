using System;
using Auchan.Common.LoyaltyProgram.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyCardEntity
{
	[JsonProperty]
	private DateTime? _lastBalanceUpdateTimeUTC;

	public DateTime? QrCodeExpirationDate { get; set; }

	public string? CardNumber { get; set; }

	public string? Cvc { get; set; }

	public string? QrCode { get; set; }

	public decimal PointsAmount { get; set; }

	public decimal EPointsAmount { get; set; }

	public decimal StampsAmount { get; set; }

	[JsonIgnore]
	public DateTime? LastBalanceUpdateTime
	{
		get
		{
			return _lastBalanceUpdateTimeUTC?.ToLocalTime();
		}
		set
		{
			_lastBalanceUpdateTimeUTC = value?.ToUniversalTime();
		}
	}

	public LoyaltyCardStatus CardStatus { get; set; }

	public ExpirationPointsEntity? ExpirationPoints { get; set; }

	public DelayedPointsEntity? DelayedPoints { get; set; }
}

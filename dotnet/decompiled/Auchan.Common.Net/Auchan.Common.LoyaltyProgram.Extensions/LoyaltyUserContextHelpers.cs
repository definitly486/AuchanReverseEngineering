using System;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.LoyaltyProgram.Extensions;

public static class LoyaltyUserContextHelpers
{
	public const string VirtualCardPrefix = "202";

	public static void SetLoyaltyCardProperties(this IUserContext userContext, LoyaltyCardEntity cardEntity, bool UpdateTime = false)
	{
		LoyaltyCardEntity loyaltyCard = userContext.LoyaltyCard;
		if (UpdateTime)
		{
			cardEntity.LastBalanceUpdateTime = DateTime.Now;
		}
		if (loyaltyCard == null)
		{
			userContext.LoyaltyCard = cardEntity;
			return;
		}
		loyaltyCard.CardStatus = cardEntity.CardStatus;
		loyaltyCard.EPointsAmount = cardEntity.EPointsAmount;
		loyaltyCard.PointsAmount = cardEntity.PointsAmount;
		loyaltyCard.StampsAmount = cardEntity.StampsAmount;
		loyaltyCard.LastBalanceUpdateTime = cardEntity.LastBalanceUpdateTime;
		userContext.LoyaltyCard = loyaltyCard;
	}

	public static bool GetIsLoyaltyCardVirtual(this IUserContext userContext)
	{
		LoyaltyCardEntity loyaltyCard = userContext.LoyaltyCard;
		if (loyaltyCard == null)
		{
			return false;
		}
		string cardNumber = loyaltyCard.CardNumber;
		if (cardNumber != null && cardNumber.Length >= 3)
		{
			return cardNumber.StartsWith("202", StringComparison.Ordinal);
		}
		return false;
	}

	public static void SetLoyaltyCardCode(this IUserContext userContext, LoyaltyProgramQrCodeResponseDto result)
	{
		LoyaltyCardEntity loyaltyCardEntity = userContext.LoyaltyCard ?? new LoyaltyCardEntity();
		loyaltyCardEntity.QrCode = result.Data.QrCode;
		loyaltyCardEntity.CardNumber = result.Data.CardNumber;
		loyaltyCardEntity.QrCodeExpirationDate = DateTime.Now.AddDays(175.0);
		userContext.LoyaltyCard = loyaltyCardEntity;
	}
}

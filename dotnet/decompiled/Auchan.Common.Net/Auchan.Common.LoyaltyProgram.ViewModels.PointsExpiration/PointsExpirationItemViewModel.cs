using System;
using System.Linq;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;

public class PointsExpirationItemViewModel : FeedItemViewModel, ILoyaltyOperation
{
	public ExpirationPointType PointType { get; }

	public DateTime OperationDate { get; }

	public string Title => GetTitle();

	public string TypeLetter => GetTitle().First().ToString();

	private decimal Points { get; }

	public string PointsFormat => $"{Points:N2}";

	public string GetFormattedTime => OperationDate.ToString("dd.MM.yyyy, HH:mm");

	public PointsExpirationItemViewModel(ExpirationPointsEntity expirationPointsEntity)
	{
		PointType = expirationPointsEntity.PointType;
		Points = expirationPointsEntity.Points;
		OperationDate = expirationPointsEntity.ExpirationDate;
	}

	private string GetTitle()
	{
		return PointType switch
		{
			ExpirationPointType.Points => "Баллы", 
			ExpirationPointType.EPoints => "Экспресс-баллы", 
			ExpirationPointType.PromoPoints => "Марки", 
			_ => string.Empty, 
		};
	}
}

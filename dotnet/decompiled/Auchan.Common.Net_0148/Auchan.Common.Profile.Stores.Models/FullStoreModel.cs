using System.Collections.Generic;
using System.Drawing;
using Auchan.Common.Helpers;

namespace Auchan.Common.Profile.Stores.Models;

public class FullStoreModel
{
	public int ExternalId { get; set; } = -1;

	public string Name { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;

	public string Phone { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string EmailPok { get; set; } = string.Empty;

	public string InternalEmail { get; set; } = string.Empty;

	public string StoreFormat { get; set; } = string.Empty;

	public StoreType StoreType { get; set; }

	public string PublicTransport { get; set; } = string.Empty;

	public string PrivateTransport { get; set; } = string.Empty;

	public double Latitude { get; set; }

	public double Longitude { get; set; }

	public string Description { get; set; } = string.Empty;

	public string Schedule { get; set; } = string.Empty;

	public double DistanceFromGeo { get; set; }

	public List<FullStoreServiceModel> Services { get; set; } = new List<FullStoreServiceModel>();

	public int RegionId { get; set; }

	public List<TempWorkHoursModel> TempWorkHours { get; set; } = new List<TempWorkHoursModel>();

	public string TempWorkDescription => "В период праздников магазины работают в режиме повышенной нагрузки. Планируйте свои покупки заранее.";

	public Color TempWorkBgColor { get; set; } = ColorTranslator.FromHtml("#E2EEFB");

	public bool IsOpen { get; set; }

	public string OpenStatusText
	{
		get
		{
			if (!IsOpen)
			{
				return "Закрыто";
			}
			return "Открыто";
		}
	}

	public string OpenStatusDescription { get; set; } = string.Empty;

	public int ParkingLots { get; set; }

	public string ParkingLotsText
	{
		get
		{
			if (ParkingLots <= 0)
			{
				return "Парковки нет";
			}
			return $"{ParkingLots} {GrammarHelper.DeclineNoun(ParkingLots, new string[3] { "место", "места", "мест" })}";
		}
	}
}

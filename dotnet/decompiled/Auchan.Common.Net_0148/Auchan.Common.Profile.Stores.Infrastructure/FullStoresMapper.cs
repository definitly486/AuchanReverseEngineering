using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Profile.Stores.Dto;
using Auchan.Common.Profile.Stores.Models;

namespace Auchan.Common.Profile.Stores.Infrastructure;

public static class FullStoresMapper
{
	public static List<FullStoreModel> ToModel(this IEnumerable<FullStoreDto> stores)
	{
		return stores.Select((FullStoreDto store) => new FullStoreModel
		{
			ExternalId = store.ExternalId,
			Address = store.Address,
			Description = store.Description,
			Email = store.Email,
			EmailPok = store.EmailPok,
			InternalEmail = store.InternalEmail,
			Latitude = store.Latitude.GetValueOrDefault(),
			Longitude = store.Longitude.GetValueOrDefault(),
			Name = store.Name,
			Phone = store.Phone,
			PrivateTransport = store.PrivateTransport,
			PublicTransport = store.PublicTransport,
			Schedule = store.Schedules.MakeSchedule(),
			StoreFormat = store.StoreFormat,
			StoreType = ((store.StoreFormat == "Супермаркет") ? StoreType.Supermarket : StoreType.Gipermarket),
			Services = store.Services.Select((FullStoreServiceDto c) => new FullStoreServiceModel
			{
				Icon = c.Icon,
				Id = c.Id,
				Name = c.Name
			}).ToList()
		}).ToList();
	}

	public static FullStoreModel ToModel(this ShopDto shop)
	{
		new List<TempWorkHoursModel>
		{
			new TempWorkHoursModel(),
			new TempWorkHoursModel()
		};
		return new FullStoreModel
		{
			Address = (shop.AddressString ?? ""),
			Description = (shop.Description ?? ""),
			Email = (shop.Email ?? ""),
			ExternalId = shop.MerchantId,
			Latitude = shop.GeoLat.GetValueOrDefault(),
			Longitude = shop.GeoLon.GetValueOrDefault(),
			Name = shop.Name,
			Phone = (shop.Phone ?? ""),
			StoreType = ((shop.Format == "Супермаркет") ? StoreType.Supermarket : StoreType.Gipermarket),
			Schedule = shop.TimeWork.MakeWorkScheduleString(),
			StoreFormat = (shop.Format ?? ""),
			RegionId = (int)shop.RegionId,
			PublicTransport = (shop.PublicTransport ?? ""),
			TempWorkHours = shop.TempTimeWork.Select((TempWorkHoursDto t) => new TempWorkHoursModel(t)).ToList(),
			TempWorkBgColor = (string.IsNullOrEmpty(shop.TempWorkBackgroundColor) ? ColorTranslator.FromHtml("#E2EEFB") : ColorTranslator.FromHtml(shop.TempWorkBackgroundColor)),
			IsOpen = shop.IsOpen,
			OpenStatusDescription = (shop.OpenStatusDescription ?? ""),
			ParkingLots = shop.ParkingLots.GetValueOrDefault(),
			Services = shop.Services.Select((ShopServiceDto c) => new FullStoreServiceModel
			{
				Icon = (c.Icon ?? string.Empty),
				Id = c.Id,
				Name = c.Name
			}).ToList()
		};
	}

	public static IEnumerable<RegionModel> ToModel(this IEnumerable<City> regions)
	{
		return regions.Select((City c) => new RegionModel
		{
			Id = (int)c.EcomId,
			Name = c.Name,
			RegionFias = c.FiasId
		});
	}

	public static RegionModel ToModel(this City region)
	{
		return new RegionModel
		{
			Id = (int)region.EcomId,
			Name = region.Name,
			RegionFias = region.FiasId
		};
	}

	private static string MakeWorkScheduleString(this TimeWorkDto schedules)
	{
		WorkHoursDto workdays = schedules.Workdays;
		WorkHoursDto weekends = schedules.Weekends;
		if (workdays.IsAroundTheClock && weekends.IsAroundTheClock)
		{
			return "Круглосуточно";
		}
		string text = ScheduleString(workdays);
		string text2 = ScheduleString(weekends);
		if (text.Equals(text2) && !string.IsNullOrEmpty(text2))
		{
			return "Ежедневно: " + text;
		}
		string text3 = "";
		if (!string.IsNullOrEmpty(text))
		{
			text3 = "Пн—Пт: " + text;
		}
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
		{
			text3 += "\n";
		}
		if (!string.IsNullOrEmpty(text2))
		{
			text3 = text3 + "Сб-Вс: " + text2;
		}
		return text3;
	}

	private static string ScheduleString(WorkHoursDto workHours)
	{
		if (workHours.IsAroundTheClock)
		{
			return "круглосуточно";
		}
		if (string.IsNullOrEmpty(workHours.Open) || string.IsNullOrEmpty(workHours.Close))
		{
			return string.Empty;
		}
		return workHours.Open + "-" + workHours.Close;
	}

	private static string MakeSchedule(this IEnumerable<FullStoreScheduleDto> schedules)
	{
		FullStoreScheduleDto workdays = schedules.FirstOrDefault((FullStoreScheduleDto c) => c.Weekdays == "workdays");
		FullStoreScheduleDto weekends = schedules.FirstOrDefault((FullStoreScheduleDto c) => c.Weekdays == "weekends");
		FullStoreScheduleDto? holidays = schedules.FirstOrDefault((FullStoreScheduleDto c) => c.Weekdays == "holidays");
		StringBuilder stringBuilder = new StringBuilder();
		string worksAndWeeks = GetWorksAndWeeks(workdays, weekends);
		if (!string.IsNullOrEmpty(worksAndWeeks))
		{
			stringBuilder.Append(worksAndWeeks);
		}
		string holidays2 = GetHolidays(holidays);
		if (!string.IsNullOrEmpty(holidays2))
		{
			stringBuilder.AppendLine();
			stringBuilder.Append(holidays2);
		}
		return stringBuilder.ToString();
	}

	private static string GetHolidays(FullStoreScheduleDto? holidays)
	{
		if (holidays != null)
		{
			if (holidays.IsAroundTheClock)
			{
				return "Праздники: круглосуточно";
			}
			TimeSpan.TryParse(holidays.OpenTime, out var result);
			TimeSpan.TryParse(holidays.CloseTime, out var result2);
			return MakeShedule(result, result2, ScheduleType.Holidays);
		}
		return string.Empty;
	}

	private static string GetWorksAndWeeks(FullStoreScheduleDto? workdays, FullStoreScheduleDto? weekends)
	{
		if (workdays != null && weekends != null)
		{
			if (workdays.IsAroundTheClock && weekends.IsAroundTheClock)
			{
				return "Круглосуточно";
			}
			TimeSpan.TryParse(workdays.OpenTime, out var result);
			TimeSpan.TryParse(workdays.CloseTime, out var result2);
			TimeSpan.TryParse(weekends.OpenTime, out var result3);
			TimeSpan.TryParse(weekends.CloseTime, out var result4);
			if (result == result3 && result2 == result4)
			{
				return $"Ежедневно: {result:hh\\:mm}—{result2:hh\\:mm}";
			}
			if (workdays.IsAroundTheClock)
			{
				return "Пн—Пт: круглосуточно\n" + MakeShedule(result3, result4, ScheduleType.Weekend);
			}
			if (weekends.IsAroundTheClock)
			{
				return MakeShedule(result3, result4, ScheduleType.Weekend) + "\nСб—Вс: круглосуточно";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(MakeShedule(result, result2, ScheduleType.Workdays));
			stringBuilder.Append("\n");
			stringBuilder.Append(MakeShedule(result3, result4, ScheduleType.Weekend));
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	private static string MakeShedule(TimeSpan opening, TimeSpan closing, ScheduleType type)
	{
		StringBuilder stringBuilder = new StringBuilder();
		switch (type)
		{
		case ScheduleType.Workdays:
			stringBuilder.Append("Пн—Пт");
			break;
		case ScheduleType.Weekend:
			stringBuilder.Append("Сб—Вс");
			break;
		case ScheduleType.Holidays:
			stringBuilder.Append("Праздники");
			break;
		}
		stringBuilder.Append(": ");
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
		handler.AppendFormatted(opening, "hh\\:mm");
		handler.AppendLiteral("—");
		handler.AppendFormatted(closing, "hh\\:mm");
		stringBuilder2.Append(ref handler);
		return stringBuilder.ToString();
	}

	public static FullStoreServiceModel ToModel(this ShopServiceDto s)
	{
		return new FullStoreServiceModel
		{
			Id = s.Id,
			Name = s.Name,
			Icon = (s.Icon ?? string.Empty)
		};
	}

	public static IEnumerable<FullStoreServiceModel> ToModel(this IEnumerable<FullStoreServiceDto> services)
	{
		return services.Select((FullStoreServiceDto c) => new FullStoreServiceModel
		{
			Id = c.Id,
			Name = c.Name,
			Icon = c.Icon
		});
	}
}

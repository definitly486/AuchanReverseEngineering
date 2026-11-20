using Auchan.Common.Ecom.DTO;

namespace Auchan.Common.Profile.Stores.Models;

public class TempWorkHoursModel
{
	public string DateText { get; set; } = "";

	public string TimeText { get; set; } = "";

	public TempWorkHoursModel(TempWorkHoursDto dto)
	{
		DateText = (dto.Date.HasValue ? $"{dto.Date:dd.MM.yyyy}" : "");
		if (dto.IsAroundTheClock)
		{
			TimeText = "круглосуточно";
		}
		else if (dto.IsClosed)
		{
			TimeText = "закрыто";
		}
		else
		{
			TimeText = dto.Open + "-" + dto.Close;
		}
	}

	public TempWorkHoursModel()
	{
		DateText = "03.12.2023";
		TimeText = "11:23-14:32";
	}
}

using Auchan.Common.Ecom.DTO;

namespace Auchan.Common.Ecom.Drive;

public static class CarMapper
{
	public static Car ToModel(this CarDto carDto)
	{
		return new Car
		{
			Id = carDto.Id,
			CarColor = carDto.CarColor,
			CarMark = carDto.CarMark,
			CarNumber = carDto.CarNumber,
			IsDefault = carDto.Default
		};
	}

	public static CarDto ToDTO(this Car car)
	{
		return new CarDto
		{
			Id = car.Id,
			CarColor = car.CarColor,
			CarMark = car.CarMark,
			CarNumber = car.CarNumber,
			Default = car.IsDefault
		};
	}
}

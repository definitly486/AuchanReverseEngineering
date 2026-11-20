namespace Auchan.Common.Addresses.DTO;

public enum FiasLevel
{
	Country = 0,
	CountryRegion = 1,
	CountryRegionSmaller = 3,
	City = 4,
	CityRegion = 5,
	Locality = 6,
	Street = 7,
	Building = 8,
	Apartment = 9,
	PlanningStructure = 65,
	ForeignOrEmpty = -1
}

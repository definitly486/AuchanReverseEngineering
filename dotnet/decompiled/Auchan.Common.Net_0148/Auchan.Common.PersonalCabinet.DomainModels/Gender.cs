using System.ComponentModel;

namespace Auchan.Common.PersonalCabinet.DomainModels;

public enum Gender
{
	[Description("Не указан")]
	Unknown,
	[Description("Мужской")]
	Male,
	[Description("Женский")]
	Female
}

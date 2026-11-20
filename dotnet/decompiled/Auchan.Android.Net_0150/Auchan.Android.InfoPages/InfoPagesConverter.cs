using System.ComponentModel;
using Auchan.Common.InfoPages;

namespace Auchan.Android.InfoPages;

public static class InfoPagesConverter
{
	public static int FromInfoTypeToDrawableResource(InfoType infoType)
	{
		return infoType switch
		{
			InfoType.About => 2131231450, 
			InfoType.AuchanPayAgreement => 2131231446, 
			InfoType.Delivery => 2131231448, 
			InfoType.Exchange => 2131231448, 
			InfoType.FAQ => 2131231454, 
			InfoType.Payment => 2131231451, 
			InfoType.PersonalDataProcessingPolicy => 2131231449, 
			InfoType.PrivacyPolicy => 2131231449, 
			InfoType.Refund => 2131231455, 
			InfoType.Tutorial => 2131231449, 
			InfoType.UserGuide => 2131231456, 
			_ => throw new InvalidEnumArgumentException(), 
		};
	}
}

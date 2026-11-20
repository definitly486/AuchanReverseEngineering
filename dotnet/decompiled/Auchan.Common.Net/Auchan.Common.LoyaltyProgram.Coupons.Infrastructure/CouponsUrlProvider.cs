using System;
using Auchan.Common.Networking;

namespace Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;

public class CouponsUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Auchan.Common.Networking.Environment env)
	{
		return env switch
		{
			Auchan.Common.Networking.Environment.Production => "https://mobile.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Preprod => "https://mobile-preprod.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_1 => "https://mobile-stage-1.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_2 => "https://mobile-stage-2.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_3 => "https://mobile-stage-3.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_4 => "https://mobile-stage-4.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_5 => "https://mobile-stage-5.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_6 => "https://mobile-stage-6.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_7 => "https://mobile-stage-7.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_8 => "https://mobile-stage-8.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_9 => "https://mobile-stage-9.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_10 => "https://mobile-stage-10.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_11 => "https://mobile-stage-11.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_12 => "https://mobile-stage-12.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_13 => "https://mobile-stage-13.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_14 => "https://mobile-stage-14.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_15 => "https://mobile-stage-15.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_16 => "https://mobile-stage-16.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_17 => "https://mobile-stage-17.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_18 => "https://mobile-stage-18.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_19 => "https://mobile-stage-19.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_20 => "https://mobile-stage-20.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_21 => "https://mobile-stage-21.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_22 => "https://mobile-stage-22.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_23 => "https://mobile-stage-23.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_24 => "https://mobile-stage-24.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_25 => "https://mobile-stage-25.ecom.auchan.ru/ecom", 
			_ => throw new NotSupportedException(), 
		};
	}
}

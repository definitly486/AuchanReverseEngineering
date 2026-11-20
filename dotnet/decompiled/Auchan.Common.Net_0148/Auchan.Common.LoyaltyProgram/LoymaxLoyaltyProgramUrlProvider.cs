using System;
using Auchan.Common.Networking;

namespace Auchan.Common.LoyaltyProgram;

public class LoymaxLoyaltyProgramUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Auchan.Common.Networking.Environment env)
	{
		return env switch
		{
			Auchan.Common.Networking.Environment.Production => "https://mobile.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Preprod => "https://mobile-preprod.ecom.auchan.ru/ecom", 
			Auchan.Common.Networking.Environment.Stage_1 => "https://api-stage-1.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_2 => "https://api-stage-2.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_3 => "https://api-stage-3.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_4 => "https://api-stage-4.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_5 => "https://api-stage-5.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_6 => "https://api-stage-6.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_7 => "https://api-stage-7.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_8 => "https://api-stage-8.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_9 => "https://api-stage-9.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_10 => "https://api-stage-10.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_11 => "https://api-stage-11.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_12 => "https://api-stage-12.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_13 => "https://api-stage-13.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_14 => "https://api-stage-14.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_15 => "https://api-stage-15.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_16 => "https://api-stage-16.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_17 => "https://api-stage-17.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_18 => "https://api-stage-18.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_19 => "https://api-stage-19.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_20 => "https://api-stage-20.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_21 => "https://api-stage-21.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_22 => "https://api-stage-22.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_23 => "https://api-stage-23.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_24 => "https://api-stage-24.ecom.auchan.ru/v1", 
			Auchan.Common.Networking.Environment.Stage_25 => "https://api-stage-25.ecom.auchan.ru/v1", 
			_ => throw new NotSupportedException(), 
		};
	}
}

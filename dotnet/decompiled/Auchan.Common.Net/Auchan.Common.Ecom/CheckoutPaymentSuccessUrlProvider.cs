using System;
using Auchan.Common.Networking;

namespace Auchan.Common.Ecom;

public class CheckoutPaymentSuccessUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Auchan.Common.Networking.Environment env)
	{
		return env switch
		{
			Auchan.Common.Networking.Environment.Production => "https://api.dostavka.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Preprod => "https://front-preprod.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_1 => "https://front-stage-1.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_2 => "https://front-stage-2.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_3 => "https://front-stage-3.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_4 => "https://front-stage-4.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_5 => "https://front-stage-5.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_6 => "https://front-stage-6.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_7 => "https://front-stage-7.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_8 => "https://front-stage-8.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_9 => "https://front-stage-9.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_10 => "https://front-stage-10.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_11 => "https://front-stage-11.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_12 => "https://front-stage-12.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_13 => "https://front-stage-13.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_14 => "https://front-stage-14.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_15 => "https://front-stage-15.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_16 => "https://front-stage-16.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_17 => "https://front-stage-17.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_18 => "https://front-stage-18.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_19 => "https://front-stage-19.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_20 => "https://front-stage-20.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_21 => "https://front-stage-21.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_22 => "https://front-stage-22.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_23 => "https://front-stage-23.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_24 => "https://front-stage-24.ecom.auchan.ru/v1/checkout/thanks", 
			Auchan.Common.Networking.Environment.Stage_25 => "https://front-stage-25.ecom.auchan.ru/v1/checkout/thanks", 
			_ => throw new NotSupportedException(), 
		};
	}
}

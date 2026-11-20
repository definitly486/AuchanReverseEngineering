using System;
using Auchan.Common.Networking;

namespace Auchan.Common.SupportChat;

public class SupportChatWebSocketUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Auchan.Common.Networking.Environment env)
	{
		return env switch
		{
			Auchan.Common.Networking.Environment.Production => "wss://api.dostavka.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Preprod => "wss://api-preprod.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_1 => "wss://api-stage-1.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_2 => "wss://api-stage-2.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_3 => "wss://api-stage-3.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_4 => "wss://api-stage-4.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_5 => "wss://api-stage-5.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_6 => "wss://api-stage-6.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_7 => "wss://api-stage-7.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_8 => "wss://api-stage-8.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_9 => "wss://api-stage-9.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_10 => "wss://api-stage-10.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_11 => "wss://api-stage-11.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_12 => "wss://api-stage-12.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_13 => "wss://api-stage-13.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_14 => "wss://api-stage-14.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_15 => "wss://api-stage-15.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_16 => "wss://api-stage-16.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_17 => "wss://api-stage-17.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_18 => "wss://api-stage-18.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_19 => "wss://api-stage-19.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_20 => "wss://api-stage-20.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_21 => "wss://api-stage-21.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_22 => "wss://api-stage-22.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_23 => "wss://api-stage-23.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_24 => "wss://api-stage-24.ecom.auchan.ru:6001/chat", 
			Auchan.Common.Networking.Environment.Stage_25 => "wss://api-stage-25.ecom.auchan.ru:6001/chat", 
			_ => throw new NotSupportedException(), 
		};
	}
}

using System;
using Auchan.Common.Networking;

namespace Auchan.Common.Analytics.Digenetica;

internal class DigeneticaBaseUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Auchan.Common.Networking.Environment env)
	{
		switch (env)
		{
		case Auchan.Common.Networking.Environment.Production:
			return "https://tracking-app.diginetica.net";
		case Auchan.Common.Networking.Environment.Preprod:
		case Auchan.Common.Networking.Environment.Stage_1:
		case Auchan.Common.Networking.Environment.Stage_2:
		case Auchan.Common.Networking.Environment.Stage_3:
		case Auchan.Common.Networking.Environment.Stage_4:
		case Auchan.Common.Networking.Environment.Stage_5:
		case Auchan.Common.Networking.Environment.Stage_6:
		case Auchan.Common.Networking.Environment.Stage_7:
		case Auchan.Common.Networking.Environment.Stage_8:
		case Auchan.Common.Networking.Environment.Stage_9:
		case Auchan.Common.Networking.Environment.Stage_10:
		case Auchan.Common.Networking.Environment.Stage_11:
		case Auchan.Common.Networking.Environment.Stage_12:
		case Auchan.Common.Networking.Environment.Stage_13:
		case Auchan.Common.Networking.Environment.Stage_14:
		case Auchan.Common.Networking.Environment.Stage_15:
		case Auchan.Common.Networking.Environment.Stage_16:
		case Auchan.Common.Networking.Environment.Stage_17:
		case Auchan.Common.Networking.Environment.Stage_18:
		case Auchan.Common.Networking.Environment.Stage_19:
		case Auchan.Common.Networking.Environment.Stage_20:
		case Auchan.Common.Networking.Environment.Stage_21:
		case Auchan.Common.Networking.Environment.Stage_22:
		case Auchan.Common.Networking.Environment.Stage_23:
		case Auchan.Common.Networking.Environment.Stage_24:
		case Auchan.Common.Networking.Environment.Stage_25:
			return "https://tracking-dev.diginetica.net";
		default:
			throw new NotSupportedException();
		}
	}
}

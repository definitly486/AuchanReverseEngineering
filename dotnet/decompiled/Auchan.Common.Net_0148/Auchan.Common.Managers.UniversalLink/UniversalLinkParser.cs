using System;
using System.Collections.Specialized;
using System.Web;

namespace Auchan.Common.Managers.UniversalLink;

public class UniversalLinkParser
{
	public bool TryParseStartQrLink(Uri fullUrl, out string? qrData)
	{
		qrData = null;
		if (fullUrl == null)
		{
			return false;
		}
		NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(fullUrl.Query);
		qrData = nameValueCollection["data"];
		string text = nameValueCollection["type"];
		if (qrData != null)
		{
			return text == "selfscanning_start";
		}
		return false;
	}
}

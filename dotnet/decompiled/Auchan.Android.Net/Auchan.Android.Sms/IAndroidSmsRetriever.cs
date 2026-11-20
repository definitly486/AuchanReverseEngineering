using Auchan.Common.Sms;

namespace Auchan.Android.Sms;

public interface IAndroidSmsRetriever : ISmsRetriever
{
	void RetrieveSms(string sms);
}

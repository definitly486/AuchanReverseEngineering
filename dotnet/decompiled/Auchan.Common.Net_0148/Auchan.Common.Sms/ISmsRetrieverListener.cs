namespace Auchan.Common.Sms;

public interface ISmsRetrieverListener
{
	void OnSmsRecieved(string sms);
}

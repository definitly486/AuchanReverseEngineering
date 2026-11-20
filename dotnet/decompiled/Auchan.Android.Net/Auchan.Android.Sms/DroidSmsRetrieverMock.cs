using System;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Auchan.Common.Sms;

namespace Auchan.Android.Sms;

public class DroidSmsRetrieverMock : IAndroidSmsRetriever, ISmsRetriever
{
	public IDisposable AddListener(ISmsRetrieverListener listener)
	{
		return Disposable.Create(delegate
		{
		});
	}

	public Task<bool> Prepare()
	{
		return Task.FromResult(result: true);
	}

	public void RetrieveSms(string sms)
	{
	}
}

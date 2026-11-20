using System;
using System.Threading.Tasks;

namespace Auchan.Common.Sms;

public interface ISmsRetriever
{
	Task<bool> Prepare();

	IDisposable AddListener(ISmsRetrieverListener listener);
}

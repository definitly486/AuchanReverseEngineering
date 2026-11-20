using System.Threading.Tasks;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public interface IAppMetricaKeyProvider
{
	string CustomKey { get; set; }

	Task<string> GetKeyAsync();
}

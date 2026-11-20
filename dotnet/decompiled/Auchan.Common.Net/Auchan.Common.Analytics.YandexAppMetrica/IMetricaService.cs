using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public interface IMetricaService
{
	Task<Result<string, DomainError>> TrackEvent(string postApiKey, string csvContent);
}

using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Analytics.Digenetica;

internal interface IDigeneticaApi
{
	[Post("/event")]
	Task<object> TrackEvent([Body(true)] string eventJson, [Header("Content-Type")] string contentType = "application/json;charset=UTF-8");
}

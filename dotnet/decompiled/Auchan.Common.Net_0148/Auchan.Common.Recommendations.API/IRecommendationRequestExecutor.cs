using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API;

internal interface IRecommendationRequestExecutor
{
	public delegate IReadOnlyList<RecommendationList.Item>? ReadResponseDelegate(JsonReader from, string blockId, RecomendationAnalyticActionsTag actionsTag);

	Task<Result<RecommendationList, DomainError>> Execute(int timeoutInSeconds, string blockId, RecomendationAnalyticActionsTag actionsTag, ReadResponseDelegate readResponseDelegate, Func<CancellationToken, Task<HttpResponseMessage>> requestFactory, CancellationToken token);
}

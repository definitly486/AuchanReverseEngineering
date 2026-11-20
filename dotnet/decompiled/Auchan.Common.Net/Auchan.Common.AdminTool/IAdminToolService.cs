using System.Threading.Tasks;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.AdminTool;

public interface IAdminToolService
{
	Task<Result<Initialization, DomainError>> Initialize(string deviceUdid, string regionFiasId, string storeId);

	Task<Result<AppConfig, DomainError>> AppConfig();

	Task<StampsConfig?> StampsConfig();
}

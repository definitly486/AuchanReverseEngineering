using System.Threading.Tasks;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Vpn;

public interface IVpnChecker
{
	Task<VpnState> GetVpnState();

	Task<VpnState> VpnStateAtAppStart();

	Task CheckAppConfigResultAndShowVpnScreenAsync(Result<AppConfig, DomainError> appConfigResult);
}

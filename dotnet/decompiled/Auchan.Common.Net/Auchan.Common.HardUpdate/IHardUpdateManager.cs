using System.Threading.Tasks;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.HardUpdate;

public interface IHardUpdateManager
{
	Task<Result<AppConfig, DomainError>> CheckHardUpdate();

	void OnHardUpdateRequired(HardUpdateViewModel.Parameter parameter);
}

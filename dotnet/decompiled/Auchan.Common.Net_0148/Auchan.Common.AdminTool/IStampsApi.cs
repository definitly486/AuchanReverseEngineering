using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Refit;

namespace Auchan.Common.AdminTool;

public interface IStampsApi
{
	[Get("/section-visible")]
	Task<SectionVisibleDto> SectionVisible(CancellationToken cancellationToken = default(CancellationToken));

	[Get("/informers")]
	Task<InformersDto> GetInformers(CancellationToken cancellationToken = default(CancellationToken));
}

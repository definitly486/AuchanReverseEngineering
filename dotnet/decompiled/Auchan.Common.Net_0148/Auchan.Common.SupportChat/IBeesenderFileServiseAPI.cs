using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.SupportChat.DTO;
using Refit;

namespace Auchan.Common.SupportChat;

public interface IBeesenderFileServiseAPI
{
	[Post("")]
	[Multipart("----MyGreatBoundary")]
	Task<UploadFileResponseDTO> SendFileAsync([AliasAs("Name")] string name, [AliasAs("FileName")] string fileName, [AliasAs("File")] StreamPart file, CancellationToken cancellationToken);
}

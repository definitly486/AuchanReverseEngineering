using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.SupportChat.DTO;
using Refit;

namespace Auchan.Common.SupportChat;

internal interface ISupportChatAPI
{
	[Get("/chat/mssgcount")]
	Task<MessageCountResponseDTO> GetMessageCount([AliasAs("CMD_ID")] string cmdId, [Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/chat/status")]
	Task<ChatStatusResponseDTO> GetChatStatus([AliasAs("CMD_ID")] string cmdId, [Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));
}

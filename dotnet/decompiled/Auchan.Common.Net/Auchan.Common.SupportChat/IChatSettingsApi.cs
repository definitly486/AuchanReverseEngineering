using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.SupportChat.DTO;
using Refit;

namespace Auchan.Common.SupportChat;

internal interface IChatSettingsApi
{
	[Get("/chat/test-settings")]
	Task<ChatConfigurationResponseDto> GetTestSettings(CancellationToken cancellationToken = default(CancellationToken));
}

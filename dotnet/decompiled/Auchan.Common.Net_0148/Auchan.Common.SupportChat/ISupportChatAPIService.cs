using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.SupportChat.DTO;
using CSharpFunctionalExtensions;

namespace Auchan.Common.SupportChat;

public interface ISupportChatAPIService
{
	Task<Result<ChatStatusResponseDTO, DomainError>> GetStatus();

	Task<Result<int, DomainError>> GetUnreadMessageCount();
}

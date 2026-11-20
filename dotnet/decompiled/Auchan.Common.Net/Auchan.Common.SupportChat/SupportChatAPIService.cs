using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.SupportChat.DTO;
using CSharpFunctionalExtensions;

namespace Auchan.Common.SupportChat;

internal class SupportChatAPIService : ISupportChatAPIService
{
	private readonly object _lock = new object();

	private readonly ISupportChatAPI _api;

	private readonly IRequestExecutor _requestExecutor;

	private readonly IUserContext _userContext;

	private Task<Result<int, DomainError>>? _getUnreadMessageCount;

	public SupportChatAPIService(ISupportChatAPI api, IRequestExecutor requestExecutor, IUserContext userContext)
	{
		_api = api;
		_requestExecutor = requestExecutor;
		_userContext = userContext;
	}

	public Task<Result<int, DomainError>> GetUnreadMessageCount()
	{
		lock (_lock)
		{
			if (_getUnreadMessageCount == null)
			{
				_getUnreadMessageCount = DoAsync();
			}
			return _getUnreadMessageCount;
		}
		async Task<Result<int, DomainError>> DoAsync()
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			int num = -1;
			awaiter.GetResult();
			Result<int, DomainError> result = (await _requestExecutor.ExecuteWithToken(delegate(CancellationToken ct, TokenModel tokenModel)
			{
				string text = _userContext.Profile?.ClientAccountId;
				return (Task<MessageCountResponseDTO>)((text == null) ? ((Task)Task.FromResult(new MessageCountResponseDTO
				{
					Data = new MessageCountResponseDTO.DataDto
					{
						MessageCount = 0
					}
				})) : ((Task)_api.GetMessageCount(text, tokenModel.Token, ct)));
			})).Map((MessageCountResponseDTO dto) => dto.Data.MessageCount, (ServiceError error) => error.ToBaseDomainError());
			object obj = _lock;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				_getUnreadMessageCount = null;
				return result;
			}
			finally
			{
				if (num < 0 && lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
	}

	public async Task<Result<ChatStatusResponseDTO, DomainError>> GetStatus()
	{
		return (await _requestExecutor.ExecuteWithToken(delegate(CancellationToken ct, TokenModel tokenModel)
		{
			string text = _userContext.Profile?.ClientAccountId;
			return (Task<ChatStatusResponseDTO>)((text == null) ? ((Task)Task.FromResult(new ChatStatusResponseDTO())) : ((Task)_api.GetChatStatus(text, tokenModel.Token, ct)));
		})).Map((ChatStatusResponseDTO dto) => dto, (ServiceError error) => error.ToBaseDomainError());
	}
}

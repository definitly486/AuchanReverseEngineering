using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.SupportChat;

public interface ISupportChatMessageService
{
	bool IsConnected { get; }

	event EventHandler<BaseWSMessageDTO>? OnMessageReceived;

	event EventHandler? OnDisconnected;

	Task<Result<CacheMessage, DomainError>> SendMessage(CacheMessage message);

	Task SendAcknowledgeAsync(int ackId);

	Task<bool> ConnectAsync();

	void Disconnect(bool closeConnection = true);
}

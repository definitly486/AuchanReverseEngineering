using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Cache;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.SupportChat.Models;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.SupportChat;

public class SupportChatMessageRepository
{
	private const string MessagesCacheKey = "SupportChatMessages";

	private const string MacrosCacheKey = "SupportChatMacros";

	private const string LastMacrosCacheKey = "SupportChatLastMacros";

	private const string OPERATOR_NAME = "SupportChatOperatorName";

	private const string OPERATOR_AVATAR = "SupportChatOperatorAvatar";

	public const int MessagesPerPage = 20;

	private readonly Lazy<ICache> _cache;

	private readonly SemaphoreSlim _messagesGate = new SemaphoreSlim(1, 1);

	private readonly List<string> _macros = new List<string>();

	private readonly List<string> _lastMacros = new List<string>();

	private bool _macrosLoaded;

	private bool _lastMacrosLoaded;

	private string? _operatorName;

	private string? _operatorAvatar;

	public List<CacheMessage> AllMessages { get; private set; } = new List<CacheMessage>();

	public ObservableRangeCollection<CacheMessage> Messages { get; private set; } = new ObservableRangeCollection<CacheMessage>();

	public SupportChatMessageRepository(Lazy<ICache> cache, IUserContext userContext)
	{
		_cache = cache;
		userContext.AfterLoggedOut += CleanupOnLogout;
	}

	private async Task CleanupOnLogout()
	{
		_macros.Clear();
		_lastMacros.Clear();
		_lastMacrosLoaded = false;
		_operatorName = null;
		_operatorAvatar = null;
		await _messagesGate.WaitAsync();
		try
		{
			AllMessages.Clear();
		}
		finally
		{
			_messagesGate.Release();
		}
		MainThread.BeginInvokeOnMainThread(delegate
		{
			Messages.Clear();
		});
		await _cache.Value.Remove("SupportChatMessages", "SupportChatMacros", "SupportChatLastMacros", "SupportChatOperatorAvatar", "SupportChatOperatorName");
	}

	public Task ClearOperatorInfoAsync()
	{
		_operatorName = null;
		_operatorAvatar = null;
		return _cache.Value.Remove("SupportChatOperatorAvatar", "SupportChatOperatorName");
	}

	public Task UpdateMacrosAsync(List<string> macros)
	{
		List<string> copy = new List<string>(macros);
		_macros.Clear();
		_macros.AddRange(copy);
		_macrosLoaded = true;
		Task task = Task.Run(() => _cache.Value.Save("SupportChatMacros", copy));
		if (copy.Count == 0)
		{
			return task;
		}
		_lastMacros.Clear();
		_lastMacros.AddRange(copy);
		_lastMacrosLoaded = true;
		Task task2 = Task.Run(() => _cache.Value.Save("SupportChatLastMacros", copy));
		return Task.WhenAll(task, task2);
	}

	public async Task<string> GetOperatorNameAsync()
	{
		string text = _operatorName;
		if (text == null)
		{
			text = (await _cache.Value.TryGet<string>("SupportChatOperatorName")) ?? "АШАН-бот";
		}
		return text;
	}

	public async Task<string> GetOperatorAvatarAsync()
	{
		string text = _operatorAvatar;
		if (text == null)
		{
			text = (await _cache.Value.TryGet<string>("SupportChatOperatorAvatar")) ?? "Default";
		}
		return text;
	}

	public Task UpdateOperatorInfoAsync(WSDataOperatorDTO? operatorInfo)
	{
		if (operatorInfo == null)
		{
			return Task.CompletedTask;
		}
		_operatorName = operatorInfo.Name ?? _operatorName;
		_operatorAvatar = operatorInfo.IconUrl ?? _operatorAvatar;
		return Task.Run(() => Task.WhenAll(_cache.Value.Save("SupportChatOperatorAvatar", operatorInfo.IconUrl), _cache.Value.Save("SupportChatOperatorName", operatorInfo.Name)));
	}

	public Task ClearMacroCachesAsync()
	{
		_macros.Clear();
		_lastMacros.Clear();
		_macrosLoaded = true;
		_lastMacrosLoaded = true;
		return _cache.Value.Remove("SupportChatMacros", "SupportChatLastMacros");
	}

	public async Task ClearStructMessagesAsync()
	{
		if (!MainThread.IsMainThread)
		{
			throw new InvalidOperationException("main thread required");
		}
		await _messagesGate.WaitAsync();
		IReadOnlyList<CacheMessage> messages;
		IReadOnlyList<CacheMessageDTO> snapshot;
		try
		{
			List<CacheMessage> list = new List<CacheMessage>();
			list.AddRange(AllMessages.Where((CacheMessage m) => m.Type.IsStructured()));
			messages = new _003C_003Ez__ReadOnlyList<CacheMessage>(list);
			if (messages == null)
			{
				return;
			}
			foreach (CacheMessage item in messages)
			{
				AllMessages.Remove(item);
			}
			List<CacheMessageDTO> list2 = new List<CacheMessageDTO>();
			list2.AddRange(AllMessages.Select((CacheMessage m) => m.ToDTO()));
			snapshot = new _003C_003Ez__ReadOnlyList<CacheMessageDTO>(list2);
		}
		finally
		{
			_messagesGate.Release();
		}
		await MainThread.InvokeOnMainThreadAsync(delegate
		{
			foreach (CacheMessage item2 in messages)
			{
				Messages.Remove(item2);
			}
		});
		await _cache.Value.Save("SupportChatMessages", snapshot);
	}

	public async Task<IReadOnlyList<string>> GetMacrosAsync()
	{
		if (!_macrosLoaded)
		{
			_macrosLoaded = true;
			List<string> list = await _cache.Value.TryGet<List<string>>("SupportChatMacros");
			if (list != null)
			{
				_macros.AddRange(list);
			}
		}
		return _macros;
	}

	public async Task<IReadOnlyList<string>> GetLastMacrosAsync()
	{
		if (!_lastMacrosLoaded)
		{
			_lastMacrosLoaded = true;
			List<string> list = await _cache.Value.TryGet<List<string>>("SupportChatLastMacros");
			if (list != null)
			{
				_lastMacros.AddRange(list);
			}
		}
		return _lastMacros;
	}

	public async Task<ObservableRangeCollection<CacheMessage>> GetMessages()
	{
		List<CacheMessage> loadedMessages = (await _cache.Value.TryGet<List<CacheMessageDTO>>("SupportChatMessages"))?.Select((CacheMessageDTO m) => m.ToModel())?.OrderBy((CacheMessage m) => m.SendTime)?.ToList() ?? new List<CacheMessage>();
		await _messagesGate.WaitAsync();
		try
		{
			AllMessages = loadedMessages;
		}
		finally
		{
			_messagesGate.Release();
		}
		await MainThread.InvokeOnMainThreadAsync(delegate
		{
			Messages.ReplaceRange(loadedMessages);
		});
		return Messages;
	}

	public async Task<CacheMessage?> UpdateMessage(Guid id, MessageStatusType status)
	{
		CacheMessage message = null;
		List<CacheMessageDTO> snapshot = null;
		await _messagesGate.WaitAsync();
		try
		{
			message = AllMessages.FirstOrDefault((CacheMessage m) => m.Id == id);
			if (message != null)
			{
				message.Status = status;
				snapshot = AllMessages.Select((CacheMessage m) => m.ToDTO()).ToList();
			}
		}
		finally
		{
			_messagesGate.Release();
		}
		if (message == null)
		{
			return null;
		}
		await _cache.Value.Save("SupportChatMessages", snapshot);
		return message;
	}

	public async Task<bool> MessageExists(int? seqNumber)
	{
		if (!seqNumber.HasValue)
		{
			return false;
		}
		await _messagesGate.WaitAsync();
		try
		{
			return AllMessages.Any((CacheMessage m) => m.SequenceNumber == seqNumber);
		}
		finally
		{
			_messagesGate.Release();
		}
	}

	public async Task DeleteMessage(Guid id)
	{
		CacheMessage message = null;
		List<CacheMessageDTO> snapshot = null;
		await _messagesGate.WaitAsync();
		try
		{
			message = AllMessages.FirstOrDefault((CacheMessage m) => m.Id == id);
			if (message == null)
			{
				return;
			}
			AllMessages.Remove(message);
			snapshot = AllMessages.Select((CacheMessage m) => m.ToDTO()).ToList();
		}
		finally
		{
			_messagesGate.Release();
		}
		await MainThread.InvokeOnMainThreadAsync(() => Messages.Remove(message));
		await _cache.Value.Save("SupportChatMessages", snapshot);
	}

	public async Task<CacheMessage> SaveMessage(CacheMessageType type, WSDataContentType dataContentType, string? text, MessageStatusType status, int? sequenceNumber = null, string? operatorIconUrl = null, string? operatorName = null, UploadFileResult? uploadFileResult = null)
	{
		DateTime now = DateTime.Now;
		CacheMessage message = new CacheMessage
		{
			Type = type,
			DataContentType = dataContentType,
			Id = Guid.NewGuid(),
			Text = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(text ?? "")).Replace("\n", "<br/>"),
			Status = status,
			SendTime = now,
			UploadFileResult = uploadFileResult,
			SequenceNumber = sequenceNumber
		};
		if (type == CacheMessageType.System && !string.IsNullOrWhiteSpace(operatorIconUrl) && !string.IsNullOrWhiteSpace(operatorName))
		{
			message.OperatorIconUrl = operatorIconUrl;
			message.SenderName = operatorName;
		}
		else if (type == CacheMessageType.Incoming)
		{
			if (!string.IsNullOrWhiteSpace(operatorName) && !string.IsNullOrWhiteSpace(operatorIconUrl))
			{
				message.OperatorIconUrl = operatorIconUrl;
				message.SenderName = operatorName;
			}
			else
			{
				message.OperatorIconUrl = "Default";
				message.SenderName = "АШАН-бот";
			}
		}
		await _messagesGate.WaitAsync();
		List<CacheMessageDTO> snapshot;
		try
		{
			AllMessages.Add(message);
			snapshot = AllMessages.Select((CacheMessage m) => m.ToDTO()).ToList();
		}
		finally
		{
			_messagesGate.Release();
		}
		await MainThread.InvokeOnMainThreadAsync(delegate
		{
			Messages.Add(message);
		});
		_cache.Value.Save("SupportChatMessages", snapshot).SafeFireAndForget((Action<Exception>)null, false);
		return message;
	}
}

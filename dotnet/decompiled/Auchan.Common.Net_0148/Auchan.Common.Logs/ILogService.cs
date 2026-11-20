using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Feedback;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Logs;

public interface ILogService
{
	public enum SendFrom
	{
		AuthOrRegister,
		Checkout,
		ChatBot
	}

	Task LogUnrecoverableCrashAsync(Exception exception);

	void Log(string name, string description, LogLevel logLevel, LogType logType, SystemType systemType);

	void LogInfo(string name, string description, LogType logType, SystemType systemType);

	void LogError(string name, string description, LogType logType, SystemType systemType);

	Task<List<Log>> ReadLogAsyncBackwards();

	Task<Result<Unit, DomainError>> ExportLogs();

	Task<Result<Unit, DomainError>> SendLogs(SendFrom? sendFrom = null);

	Task<Result<Unit, DomainError>> SendLogs(FeedbackCity feedbackCity, string email, string fullName, SendFrom? sendFrom = null);
}

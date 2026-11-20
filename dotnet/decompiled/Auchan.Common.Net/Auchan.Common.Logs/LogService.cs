using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom;
using Auchan.Common.Extensions;
using Auchan.Common.Feedback;
using Auchan.Common.Feedback.DTO;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using CsvHelper;
using CsvHelper.Configuration;
using DryIoc;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Devices;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Wrappers;
using Refit;

namespace Auchan.Common.Logs;

internal class LogService : ILogService
{
	private sealed class LogMap : ClassMap<Log>
	{
		public LogMap()
		{
			Map((Expression<Func<Log, DateTime>>)((Log m) => m.DateTime), useExistingMap: true).Index(0).Convert((ConvertFromStringArgs s) => ParseDateTime(s.Row.GetField(0)));
			Map((Expression<Func<Log, string?>>)((Log m) => m.Name), useExistingMap: true).Index(1);
			Map((Expression<Func<Log, LogLevel>>)((Log m) => m.LogLevel), useExistingMap: true).Index(2).Convert((ConvertFromStringArgs s) => ParseEnum<LogLevel>(s.Row.GetField(2)));
			Map((Expression<Func<Log, LogType>>)((Log m) => m.LogType), useExistingMap: true).Index(3).Convert((ConvertFromStringArgs s) => ParseEnum<LogType>(s.Row.GetField(3)));
			Map((Expression<Func<Log, SystemType>>)((Log m) => m.SystemType), useExistingMap: true).Index(4).Convert((ConvertFromStringArgs s) => ParseEnum<SystemType>(s.Row.GetField(4)));
			Map((Expression<Func<Log, string?>>)((Log m) => m.Description), useExistingMap: true).Index(5);
		}

		private DateTime ParseDateTime(string? v)
		{
			if (string.IsNullOrEmpty(v))
			{
				return default(DateTime);
			}
			if (DateTime.TryParse(v, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
			{
				return result;
			}
			if (DateTime.TryParse(v, out result))
			{
				return result;
			}
			return default(DateTime);
		}

		private T ParseEnum<T>(string? input) where T : struct
		{
			if (!string.IsNullOrEmpty(input) && Enum.TryParse<T>(input, out var result))
			{
				return result;
			}
			return default(T);
		}
	}

	private const double ONE_MEGABYTE = 1048576.0;

	private const string ARCHIVE_EXTENSION = ".zip";

	private const bool COLLECT_FILE_STATISTICS = false;

	private const int MAX_INFO_PER_CELL = 32768;

	private const int MAX_INFO_PER_LOG = 4096;

	private const int _logVersion = 1;

	private const string _logCsvDelimiter = "-!-";

	private readonly Lazy<IFeedbackApi> _api;

	private readonly Lazy<IAdminToolAuthorizer> _authorizer;

	private readonly Lazy<IExcelService> _excelService;

	private readonly Lazy<IPolicyProvider> _policyProvider;

	private readonly string _logFilepath;

	private readonly string _logExcelFilepath;

	private readonly string _directory;

	private readonly TaskQueue _logWriteQueue = new TaskQueue();

	private Logger? _logger;

	private bool _unrecoverableCrashRegistered;

	public LogService(Lazy<IFeedbackApi> api, Lazy<IAdminToolAuthorizer> authorizer, Lazy<IExcelService> excelService, Lazy<IPolicyProvider> policyProvider)
	{
		_api = api;
		_authorizer = authorizer;
		_excelService = excelService;
		_policyProvider = policyProvider;
		_directory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		_logFilepath = GetLogFileNameOfVersion(_directory, 1);
		_logExcelFilepath = Path.Combine(_directory, "log.xlsx");
		Task.Run(() => _logWriteQueue.Enqueue(InitLogerAsync)).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void LogInfo(string name, string description, LogType logType, SystemType systemType)
	{
		Log(name, description, LogLevel.Info, logType, systemType);
	}

	public void LogError(string name, string description, LogType logType, SystemType systemType)
	{
		Log(name, description, LogLevel.Error, logType, systemType);
	}

	public void Log(string name, string description, LogLevel logLevel, LogType logType, SystemType systemType)
	{
		if (_unrecoverableCrashRegistered)
		{
			return;
		}
		Task.Run(delegate
		{
			LogEventInfo logEvent = CreateLogEventInfo(name, description, logLevel, logType, systemType);
			return _logWriteQueue.Enqueue(() => LogAsync(logEvent));
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	private LogEventInfo CreateLogEventInfo(string name, string description, LogLevel logLevel, LogType logType, SystemType systemType)
	{
		name = TrimForSanitization(name).Sanitize();
		description = TrimForSanitization(description).Sanitize();
		return new LogEventInfo((logLevel == LogLevel.Info) ? NLog.LogLevel.Info : NLog.LogLevel.Error, "MainLogTarget", CultureInfo.InvariantCulture, "CustomValue", Array.Empty<object>())
		{
			Properties = 
			{
				{
					(object)"date",
					(object)DateTime.UtcNow
				},
				{
					(object)"name",
					(object)EnsureMaxLength(name)
				},
				{
					(object)"logLevel",
					(object)logLevel
				},
				{
					(object)"logType",
					(object)logType
				},
				{
					(object)"systemType",
					(object)systemType
				},
				{
					(object)"description",
					(object)EnsureMaxLength(description)
				}
			}
		};
		static string EnsureMaxLength(string message)
		{
			if (message.Length <= 32768)
			{
				return message;
			}
			return message.Substring(0, 32768);
		}
		static string TrimForSanitization(string message)
		{
			if (message.Length <= 4096)
			{
				return message;
			}
			int num = 4096;
			bool flag = false;
			bool flag2 = false;
			int num2 = -1;
			for (int i = 0; i < num; i++)
			{
				char c = message[i];
				if (flag)
				{
					if (flag2)
					{
						flag2 = false;
					}
					else
					{
						switch (c)
						{
						case '\\':
							flag2 = true;
							break;
						case '"':
							flag = false;
							break;
						}
					}
				}
				else
				{
					switch (c)
					{
					case '"':
						flag = true;
						break;
					case '\n':
					case '&':
					case ',':
					case '[':
					case '{':
						num2 = i;
						break;
					}
				}
			}
			if (num2 >= 0 && num2 < num - 1)
			{
				return message.Substring(0, num2 + 1);
			}
			if (flag)
			{
				return string.Empty;
			}
			return message.Substring(0, num);
		}
	}

	private Task LogAsync(LogEventInfo logEvent)
	{
		if (_logger == null)
		{
			InitLogger();
			_logger.Log(logEvent);
			return Task.CompletedTask;
		}
		_logger.Log(logEvent);
		return Task.CompletedTask;
	}

	private Task InitLogerAsync()
	{
		return Task.Run(delegate
		{
			InitLogger();
		});
	}

	private void InitLogger()
	{
		if (!Directory.Exists(_directory))
		{
			Directory.CreateDirectory(_directory);
		}
		ClearOldLogVersions();
		if (!File.Exists(_logFilepath))
		{
			File.Create(_logFilepath).Close();
		}
		AsyncTargetWrapper target = new AsyncTargetWrapper(new ConcurrentFileTarget
		{
			Name = "MainLogTarget",
			FileName = _logFilepath,
			Layout = new CsvLayout
			{
				WithHeader = false,
				Columns = 
				{
					new CsvColumn("date", "${event-context:item=date}"),
					new CsvColumn("name", "${event-context:item=name}"),
					new CsvColumn("logLevel", "${event-context:item=logLevel}"),
					new CsvColumn("logType", "${event-context:item=logType}"),
					new CsvColumn("systemType", "${event-context:item=systemType}"),
					new CsvColumn("description", "${event-context:item=description}")
				},
				Delimiter = CsvColumnDelimiterMode.Custom,
				CustomColumnDelimiter = "-!-"
			},
			ConcurrentWrites = true,
			KeepFileOpen = false,
			ArchiveAboveSize = 5242880L,
			MaxArchiveFiles = 10,
			EnableArchiveFileCompression = true
		});
		LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
		loggingConfiguration.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, target);
		LogManager.Configuration = loggingConfiguration;
		_logger = LogManager.GetCurrentClassLogger();
		LogInfo("Запуск приложения", "Запущено приложение и служба логирования", LogType.UserAction, SystemType.MobileApp);
	}

	private async Task<List<Log>> ReadLogAsync()
	{
		return await Task.Run(() => DoReadLogAsync());
	}

	private async Task<List<Log>> DoReadLogAsync()
	{
		List<Log> records = new List<Log>();
		long totalDataLength = 0L;
		StringBuilder filesWithLength = new StringBuilder();
		StringBuilder stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler;
		using (LogManager.SuspendLogging())
		{
			IReadOnlyList<string> logsOfVersion = GetLogsOfVersion(_directory, 1);
			foreach (string file in logsOfVersion)
			{
				if (!File.Exists(file))
				{
					continue;
				}
				using FileStream stream = File.OpenRead(file);
				totalDataLength += stream.Length;
				stringBuilder = filesWithLength;
				StringBuilder stringBuilder2 = stringBuilder;
				handler = new StringBuilder.AppendInterpolatedStringHandler(16, 3, stringBuilder);
				handler.AppendFormatted(file);
				handler.AppendLiteral(" : ");
				handler.AppendFormatted((double)stream.Length / 1048576.0, "F2");
				handler.AppendLiteral(" MB == ");
				handler.AppendFormatted(stream.Length);
				handler.AppendLiteral(" bytes");
				stringBuilder2.AppendLine(ref handler);
				if (!(Path.GetExtension(file) == ".zip"))
				{
					await ReadLogRecordsAsync(records, stream);
					continue;
				}
				try
				{
					using ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen: true);
					foreach (ZipArchiveEntry entry in archive.Entries)
					{
						using Stream entryStream = entry.Open();
						await ReadLogRecordsAsync(records, entryStream);
					}
				}
				catch (Exception ex)
				{
					stringBuilder = filesWithLength;
					StringBuilder stringBuilder3 = stringBuilder;
					handler = new StringBuilder.AppendInterpolatedStringHandler(44, 1, stringBuilder);
					handler.AppendLiteral("got exception while reading archive file: [");
					handler.AppendFormatted(file);
					handler.AppendLiteral("]");
					stringBuilder3.AppendLine(ref handler);
					filesWithLength.AppendLine(ex.Message);
				}
			}
		}
		stringBuilder = filesWithLength;
		StringBuilder stringBuilder4 = stringBuilder;
		handler = new StringBuilder.AppendInterpolatedStringHandler(20, 2, stringBuilder);
		handler.AppendLiteral("total: ");
		handler.AppendFormatted((double)totalDataLength / 1048576.0, "F2");
		handler.AppendLiteral(" MB == ");
		handler.AppendFormatted(totalDataLength);
		handler.AppendLiteral(" bytes");
		stringBuilder4.AppendLine(ref handler);
		records.Add(new Log
		{
			DateTime = DateTime.UtcNow,
			Name = "Log usage statistics",
			Description = filesWithLength.ToString(),
			LogLevel = LogLevel.Info,
			LogType = LogType.UserAction,
			SystemType = SystemType.MobileApp
		});
		records.Add(new Log
		{
			DateTime = DateTime.UtcNow,
			Name = "App And Device Info",
			Description = "App Version " + ((DeviceInfo.Platform == DevicePlatform.Android) ? AppInfo.VersionString : AppInfo.BuildString) + ", " + $"OS {DeviceInfo.Platform} {DeviceInfo.VersionString}, " + "Device " + DeviceInfo.Manufacturer + " " + DeviceInfo.Model,
			LogLevel = LogLevel.Info,
			LogType = LogType.UserAction,
			SystemType = SystemType.MobileApp
		});
		return records;
	}

	private static async Task ReadLogRecordsAsync(List<Log> records, Stream stream)
	{
		using StreamReader reader = new StreamReader(stream);
		using CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
		{
			HasHeaderRecord = false,
			Delimiter = "-!-"
		});
		csv.Context.RegisterClassMap(new LogMap());
		IAsyncEnumerable<Log> recordsAsync = csv.GetRecordsAsync<Log>();
		await foreach (Log item in recordsAsync)
		{
			records.Add(item);
		}
	}

	public async Task<List<Log>> ReadLogAsyncBackwards()
	{
		List<Log> obj = await ReadLogAsync();
		obj.Reverse();
		return obj;
	}

	public async Task<Result<Unit, DomainError>> ExportLogs()
	{
		await CreateLogFile(_logExcelFilepath);
		await Share.RequestAsync(new ShareFileRequest(new ShareFile(_logExcelFilepath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")));
		return Result.Success<Unit, DomainError>(Unit.Default);
	}

	public Task<Result<Unit, DomainError>> SendLogs(ILogService.SendFrom? sendFrom = null)
	{
		IEcomContext ecomContext = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IEcomContext>();
		IUserContext userContext = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IUserContext>();
		FeedbackCity feedbackCity = ((ecomContext.DeliveryAddress != null) ? new FeedbackCity(0, ecomContext.DeliveryAddress?.City ?? "City not specified", ecomContext.DeliveryAddress?.CityGuid?.ToString() ?? "City not specified") : new FeedbackCity(0, "Address not selected", "Address not selected"));
		string email = ((!userContext.Authorized) ? "User not authorized" : (string.IsNullOrWhiteSpace(userContext.Profile?.Email) ? "Email not specified" : userContext.Profile.Email));
		string fullName = ((!userContext.Authorized) ? "User not authorized" : (string.IsNullOrWhiteSpace(userContext.Profile?.FullName) ? "Name not specified" : userContext.Profile.FullName));
		return SendLogs(feedbackCity, email, fullName, sendFrom);
	}

	public async Task<Result<Unit, DomainError>> SendLogs(FeedbackCity feedbackCity, string email, string fullName, ILogService.SendFrom? sendFrom = null)
	{
		Result<string, ServiceError> tokenResult = await _authorizer.Value.UdidKey();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(tokenResult.Error.ToBaseDomainError());
		}
		bool limitLogSize = sendFrom.HasValue && sendFrom != ILogService.SendFrom.ChatBot;
		await CreateLogFile(_logExcelFilepath, limitLogSize);
		FileStream stream = new FileStream(_logExcelFilepath, FileMode.Open);
		Result<FeedbackAttachmentResponseDto, ServiceError> apiAttachmentResult;
		try
		{
			apiAttachmentResult = await _policyProvider.Value.DefaultPolicy<FeedbackAttachmentResponseDto>(15).ExecuteAsync((CancellationToken t) => _api.Value.FeedbackAttachment(new StreamPart(stream, "log.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"), tokenResult.Value, t).CatchErrors(), CancellationToken.None);
		}
		finally
		{
			if (stream != null)
			{
				((IDisposable)stream).Dispose();
			}
		}
		if (File.Exists(_logExcelFilepath))
		{
			File.Delete(_logExcelFilepath);
		}
		if (apiAttachmentResult.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(apiAttachmentResult.Error.ToFeedbackAttachmentError());
		}
		Result<FeedbackConfigResponseDto, ServiceError> result = await _policyProvider.Value.DefaultPolicy<FeedbackConfigResponseDto>(15).ExecuteAsync((CancellationToken t) => _api.Value.Config(tokenResult.Value, t).CatchErrors(), CancellationToken.None);
		if (result.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(result.Error.ToBaseDomainError());
		}
		FeedbackCategory feedbackCategory = result.Value.Categories.FirstOrDefault((FeedbackCategory x) => x.Name == "Логи");
		string text = "Логи";
		int? num = sendFrom switch
		{
			ILogService.SendFrom.ChatBot => feedbackCategory?.Subjects?.FirstOrDefault((FeedbackSubject x) => x.Name == "Чат-бот")?.Id, 
			ILogService.SendFrom.AuthOrRegister => feedbackCategory?.Subjects?.FirstOrDefault((FeedbackSubject x) => x.Name == "Авторизация/регистрация")?.Id, 
			ILogService.SendFrom.Checkout => feedbackCategory?.Subjects?.FirstOrDefault((FeedbackSubject x) => x.Name == "Ошибка оплаты")?.Id, 
			_ => null, 
		};
		FeedbackMessage feedback = new FeedbackMessage(feedbackCity, email, fullName, feedbackCategory?.Id ?? 0, text, subjectId: num, attachments: new FeedbackAttachment[1]
		{
			new FeedbackAttachment(apiAttachmentResult.Value.Id)
		}, sendToEmailPok: false);
		Result<FeedbackResponseDto, ServiceError> result2 = await _policyProvider.Value.DefaultPolicy<FeedbackResponseDto>(15).ExecuteAsync((CancellationToken t) => _api.Value.Feedback(feedback, tokenResult.Value, t).CatchErrors(), CancellationToken.None);
		if (result2.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(result2.Error.ToFeedbackError());
		}
		return Result.Success<Unit, DomainError>(Unit.Default);
	}

	private async Task CreateLogFile(string filepath, bool limitLogSize = false)
	{
		if (File.Exists(filepath))
		{
			File.Delete(filepath);
		}
		int limit = (limitLogSize ? 30 : 0);
		List<Log> list = await ReadLogAsync();
		if (limit > 0 && list.Count > limit)
		{
			list = list.TakeLast(limit).ToList();
		}
		List<List<string>> values = (from x in list
			orderby x.DateTime descending
			select new List<string>
			{
				x.DateTime.UTCToMoscow().ToString("dd.MM.yyyy HH:mm:ss.ffff"),
				x.Name,
				x.LogType.ToString(),
				x.SystemType.ToString(),
				x.LogLevel.ToString(),
				x.Description
			}).ToList();
		_excelService.Value.CreateExcelDoc(filepath, new List<string> { "Дата", "Событие", "Тип", "Система", "Уровень", "Описание" }, values);
	}

	private void ClearOldLogVersions()
	{
		string path = Path.Combine(_directory, "log.csv");
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		for (int i = 1; i < 1; i++)
		{
			DeleteFiles(GetLogsOfVersion(_directory, i));
		}
		for (int j = 0; j <= 1; j++)
		{
			DeleteFiles(GetUncompressedArchiveLogsOfVersion(_directory, j));
		}
		static void DeleteFiles(IEnumerable<string> files)
		{
			foreach (string file in files)
			{
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}
		}
		static IReadOnlyList<string> GetUncompressedArchiveLogsOfVersion(string directory, int version)
		{
			string prefix = GetPrefix(version);
			return Directory.EnumerateFiles(directory, prefix + ".*.csv").ToList();
		}
	}

	private static string GetPrefix(int version)
	{
		return "log" + version;
	}

	private static IReadOnlyList<string> GetLogsOfVersion(string directory, int version)
	{
		string prefix = GetPrefix(version);
		List<string> list = Directory.EnumerateFiles(directory, prefix + ".zip").Concat(Directory.EnumerateFiles(directory, prefix + ".*.zip").OrderBy(FileIndex)).ToList();
		list.Add(GetLogFileNameOfVersion(directory, version));
		return list;
		static int FileIndex(string filePath)
		{
			return int.Parse(Path.GetExtension(Path.GetFileNameWithoutExtension(filePath)).Substring(1));
		}
	}

	private static string GetLogFileNameOfVersion(string directory, int version)
	{
		return Path.Combine(directory, GetPrefix(version) + ".csv");
	}

	public async Task LogUnrecoverableCrashAsync(Exception exception)
	{
		try
		{
			LogEventInfo logEvent = CreateLogEventInfo(".net unhandled exception", exception.ToString(), LogLevel.Error, LogType.Crash, SystemType.MobileApp);
			_logger?.Log(logEvent);
			LogManager.Flush();
			LogManager.Shutdown();
			_unrecoverableCrashRegistered = true;
			_logger = null;
		}
		catch (Exception)
		{
			throw;
		}
	}
}

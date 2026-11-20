using System;
using System.Globalization;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using NLog.Common;

namespace NLog.Internal.FileAppenders;

internal abstract class BaseMutexFileAppender : BaseFileAppender
{
	public Mutex ArchiveMutex { get; private set; }

	protected BaseMutexFileAppender(string fileName, ICreateFileParameters createParameters)
		: base(fileName, createParameters)
	{
		if (createParameters.IsArchivingEnabled && createParameters.ConcurrentWrites)
		{
			if (MutexDetector.SupportsSharableMutex)
			{
				ArchiveMutex = CreateArchiveMutex();
			}
			else
			{
				InternalLogger.Debug("{0}: Mutex for file archive not supported", base.CreateFileParameters);
			}
		}
	}

	private Mutex CreateArchiveMutex()
	{
		try
		{
			return CreateSharableMutex("FileArchiveLock");
		}
		catch (Exception ex)
		{
			if (ex is SecurityException || ex is UnauthorizedAccessException || ex is NotSupportedException || ex is NotImplementedException || ex is PlatformNotSupportedException)
			{
				InternalLogger.Warn(ex, "{0}: Failed to create global archive mutex: {1}", base.CreateFileParameters, base.FileName);
				return new Mutex();
			}
			InternalLogger.Error(ex, "{0}: Failed to create global archive mutex: {1}", base.CreateFileParameters, base.FileName);
			if (LogManager.ThrowExceptions)
			{
				throw;
			}
			return new Mutex();
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			ArchiveMutex?.Close();
		}
	}

	protected Mutex CreateSharableMutex(string mutexNamePrefix)
	{
		if (!MutexDetector.SupportsSharableMutex)
		{
			throw new NotSupportedException("Creating Mutex not supported");
		}
		return ForceCreateSharableMutex(GetMutexName(mutexNamePrefix));
	}

	internal static Mutex ForceCreateSharableMutex(string name)
	{
		return new Mutex(initiallyOwned: false, name);
	}

	private string GetMutexName(string mutexNamePrefix)
	{
		string text = Path.GetFullPath(base.FileName).ToLowerInvariant();
		text = text.Replace('\\', '_');
		text = text.Replace('/', '_');
		string text2 = $"Global\\NLog-File{mutexNamePrefix}-{text}";
		if (text2.Length <= 260)
		{
			return text2;
		}
		string arg;
		using (MD5 mD = MD5.Create())
		{
			arg = Convert.ToBase64String(mD.ComputeHash(Encoding.UTF8.GetBytes(text)));
		}
		text2 = string.Format(CultureInfo.InvariantCulture, "Global\\NLog-File{0}-{1}", mutexNamePrefix, arg);
		int startIndex = text.Length - (260 - text2.Length);
		return text2 + text.Substring(startIndex);
	}
}

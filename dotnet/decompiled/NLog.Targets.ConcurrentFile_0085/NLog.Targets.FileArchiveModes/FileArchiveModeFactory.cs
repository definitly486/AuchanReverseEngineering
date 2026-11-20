using System;
using NLog.Common;

namespace NLog.Targets.FileArchiveModes;

internal static class FileArchiveModeFactory
{
	public static IFileArchiveMode CreateArchiveStyle(string archiveFilePath, ArchiveNumberingMode archiveNumbering, string dateFormat, bool customArchiveFileName, bool archiveCleanupEnabled)
	{
		if (ContainsFileNamePattern(archiveFilePath))
		{
			IFileArchiveMode fileArchiveMode = CreateStrictFileArchiveMode(archiveNumbering, dateFormat, archiveCleanupEnabled);
			if (fileArchiveMode != null)
			{
				return fileArchiveMode;
			}
		}
		if (archiveNumbering != ArchiveNumberingMode.Sequence)
		{
			if (!customArchiveFileName)
			{
				IFileArchiveMode fileArchiveMode2 = CreateStrictFileArchiveMode(archiveNumbering, dateFormat, archiveCleanupEnabled);
				if (fileArchiveMode2 != null)
				{
					return new FileArchiveModeDynamicTemplate(fileArchiveMode2);
				}
			}
			else
			{
				InternalLogger.Info("FileTarget: Pattern {{#}} is missing in ArchiveFileName `{0}` (Fallback to dynamic wildcard)", archiveFilePath);
			}
		}
		return new FileArchiveModeDynamicSequence(archiveNumbering, dateFormat, customArchiveFileName, archiveCleanupEnabled);
	}

	private static IFileArchiveMode CreateStrictFileArchiveMode(ArchiveNumberingMode archiveNumbering, string dateFormat, bool archiveCleanupEnabled)
	{
		return archiveNumbering switch
		{
			ArchiveNumberingMode.Rolling => new FileArchiveModeRolling(), 
			ArchiveNumberingMode.Sequence => new FileArchiveModeSequence(dateFormat, archiveCleanupEnabled), 
			ArchiveNumberingMode.Date => new FileArchiveModeDate(dateFormat, archiveCleanupEnabled), 
			ArchiveNumberingMode.DateAndSequence => new FileArchiveModeDateAndSequence(dateFormat, archiveCleanupEnabled), 
			_ => null, 
		};
	}

	public static bool ContainsFileNamePattern(string fileName)
	{
		int num = fileName.IndexOf("{#", StringComparison.Ordinal);
		int num2 = fileName.IndexOf("#}", StringComparison.Ordinal);
		if (num != -1 && num2 != -1)
		{
			return num < num2;
		}
		return false;
	}
}

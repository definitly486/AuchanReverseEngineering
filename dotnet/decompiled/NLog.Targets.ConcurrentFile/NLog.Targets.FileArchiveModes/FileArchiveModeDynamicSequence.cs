using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using NLog.Internal;
using NLog.Time;

namespace NLog.Targets.FileArchiveModes;

internal sealed class FileArchiveModeDynamicSequence : FileArchiveModeBase
{
	private readonly ArchiveNumberingMode _archiveNumbering;

	private readonly string _archiveDateFormat;

	private readonly bool _customArchiveFileName;

	public FileArchiveModeDynamicSequence(ArchiveNumberingMode archiveNumbering, string archiveDateFormat, bool customArchiveFileName, bool archiveCleanupEnabled)
		: base(archiveCleanupEnabled)
	{
		_archiveNumbering = archiveNumbering;
		_archiveDateFormat = archiveDateFormat;
		_customArchiveFileName = customArchiveFileName;
	}

	private static bool RemoveNonLetters(string fileName, int startPosition, StringBuilder sb, out int digitsRemoved)
	{
		digitsRemoved = 0;
		sb.Length = 0;
		for (int i = 0; i < startPosition; i++)
		{
			sb.Append(fileName[i]);
		}
		bool? flag = null;
		for (int j = startPosition; j < fileName.Length; j++)
		{
			char c = fileName[j];
			if (char.IsDigit(c))
			{
				if (!flag.HasValue)
				{
					flag = true;
					digitsRemoved = 1;
					sb.Append('{');
					sb.Append('#');
					sb.Append('}');
				}
				else if (!flag.Value)
				{
					sb.Append(c);
				}
				else
				{
					digitsRemoved++;
				}
			}
			else if (!char.IsLetter(c))
			{
				if (!flag.HasValue || !flag.Value)
				{
					sb.Append(c);
				}
			}
			else
			{
				if (flag.HasValue)
				{
					flag = false;
				}
				sb.Append(c);
			}
		}
		return flag.HasValue;
	}

	protected override FileNameTemplate GenerateFileNameTemplate(string archiveFilePath)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(archiveFilePath);
		StringBuilder stringBuilder = new StringBuilder();
		int startPosition = 0;
		int num = int.MaxValue;
		int digitsRemoved;
		for (int i = 0; i < fileNameWithoutExtension.Length && (RemoveNonLetters(fileNameWithoutExtension, i, stringBuilder, out digitsRemoved) || i != 0); i++)
		{
			if (digitsRemoved > 1 && stringBuilder.Length < num)
			{
				startPosition = i;
				num = stringBuilder.Length;
			}
		}
		RemoveNonLetters(fileNameWithoutExtension, startPosition, stringBuilder, out digitsRemoved);
		if (digitsRemoved <= 1)
		{
			stringBuilder.Length = 0;
			stringBuilder.Append(fileNameWithoutExtension);
		}
		ArchiveNumberingMode archiveNumbering = _archiveNumbering;
		if (((uint)archiveNumbering <= 1u || archiveNumbering == ArchiveNumberingMode.DateAndSequence) && (stringBuilder.Length < 3 || (stringBuilder[stringBuilder.Length - 3] != '{' && stringBuilder[stringBuilder.Length - 2] != '#' && stringBuilder[stringBuilder.Length - 1] != '}')))
		{
			if (digitsRemoved <= 1)
			{
				stringBuilder.Append('{');
				stringBuilder.Append('#');
				stringBuilder.Append('}');
			}
			else
			{
				stringBuilder.Append('*');
			}
		}
		stringBuilder.Append(Path.GetExtension(archiveFilePath));
		return base.GenerateFileNameTemplate(stringBuilder.ToString());
	}

	protected override DateAndSequenceArchive GenerateArchiveFileInfo(FileInfo archiveFile, FileNameTemplate fileTemplate)
	{
		if (fileTemplate != null && fileTemplate.EndAt > 0 && !FileNameMatchesTemplate(archiveFile.Name, fileTemplate))
		{
			return null;
		}
		int num = ExtractArchiveNumberFromFileName(archiveFile.FullName);
		DateTime dateTime = archiveFile.LookupValidFileCreationTimeUtc();
		DateTime date = ((dateTime > DateTime.MinValue) ? TimeSource.Current.FromSystemTime(dateTime) : DateTime.MinValue);
		return new DateAndSequenceArchive(archiveFile.FullName, date, _archiveDateFormat, (num > 0) ? num : 0);
	}

	private static bool FileNameMatchesTemplate(string filename, FileNameTemplate fileTemplate)
	{
		int num = 0;
		for (int i = 0; i < filename.Length; i++)
		{
			char c = filename[i];
			if (num >= fileTemplate.Template.Length)
			{
				if (!char.IsLetter(c))
				{
					break;
				}
				return false;
			}
			char c2;
			if (num < fileTemplate.EndAt && i >= fileTemplate.BeginAt)
			{
				if (!char.IsLetter(c))
				{
					continue;
				}
				num = fileTemplate.EndAt;
				do
				{
					if (num >= fileTemplate.Template.Length)
					{
						return false;
					}
					c2 = fileTemplate.Template[num];
					num++;
				}
				while (!char.IsLetter(c2));
			}
			else
			{
				c2 = fileTemplate.Template[num];
				num++;
			}
			if (c != c2 && char.ToUpperInvariant(c) != char.ToUpperInvariant(c2))
			{
				if (c2 == '*' && !char.IsLetter(c))
				{
					break;
				}
				return false;
			}
		}
		return true;
	}

	private static int ExtractArchiveNumberFromFileName(string archiveFileName)
	{
		archiveFileName = Path.GetFileName(archiveFileName);
		int num = archiveFileName.LastIndexOf('.');
		if (num == -1)
		{
			return 0;
		}
		int num2 = archiveFileName.LastIndexOf('.', num - 1);
		if (!int.TryParse((num2 == -1) ? archiveFileName.Substring(num + 1) : archiveFileName.Substring(num2 + 1, num - num2 - 1), out var result))
		{
			return 0;
		}
		return result;
	}

	public override DateAndSequenceArchive GenerateArchiveFileName(string archiveFilePath, DateTime archiveDate, List<DateAndSequenceArchive> existingArchiveFiles)
	{
		int num = GetStartSequenceNo() - 1;
		string fileName = Path.GetFileName(archiveFilePath);
		foreach (DateAndSequenceArchive existingArchiveFile in existingArchiveFiles)
		{
			string fileName2 = Path.GetFileName(existingArchiveFile.FileName);
			if (string.Equals(fileName2, fileName, StringComparison.OrdinalIgnoreCase))
			{
				num = Math.Max(num, existingArchiveFile.Sequence + GetStartSequenceNo());
				continue;
			}
			string extension = Path.GetExtension(fileName2);
			fileName2 = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(fileName2)) + extension;
			if (string.Equals(fileName2, fileName, StringComparison.OrdinalIgnoreCase))
			{
				num = Math.Max(num, existingArchiveFile.Sequence + 1);
			}
		}
		archiveFilePath = Path.GetFullPath(archiveFilePath);
		if (num >= GetStartSequenceNo())
		{
			archiveFilePath = Path.Combine(Path.GetDirectoryName(archiveFilePath), Path.GetFileNameWithoutExtension(fileName) + "." + num.ToString(CultureInfo.InvariantCulture) + Path.GetExtension(fileName));
		}
		return new DateAndSequenceArchive(archiveFilePath, archiveDate, _archiveDateFormat, num);
	}

	private int GetStartSequenceNo()
	{
		return _customArchiveFileName ? 1 : 0;
	}
}

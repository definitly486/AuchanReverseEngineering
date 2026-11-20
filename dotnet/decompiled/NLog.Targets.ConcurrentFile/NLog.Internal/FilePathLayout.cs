using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NLog.Common;
using NLog.Layouts;
using NLog.Targets;

namespace NLog.Internal;

internal sealed class FilePathLayout
{
	private static readonly char[] DirectorySeparatorChars = new char[2]
	{
		Path.DirectorySeparatorChar,
		Path.AltDirectorySeparatorChar
	};

	private static readonly HashSet<char> InvalidFileNameChars = new HashSet<char>(Path.GetInvalidFileNameChars());

	private readonly Layout _layout;

	private readonly FilePathKind _filePathKind;

	private readonly string _baseDir;

	private readonly string _cleanedFixedResult;

	private readonly bool _cleanupInvalidChars;

	private string _cachedPrevRawFileName;

	private string _cachedPrevCleanFileName;

	public bool IsFixedFilePath => _cleanedFixedResult != null;

	public FilePathLayout(Layout layout, bool cleanupInvalidChars, FilePathKind filePathKind)
	{
		_layout = layout ?? Layout.Empty;
		_cleanupInvalidChars = cleanupInvalidChars;
		_filePathKind = ((filePathKind == FilePathKind.Unknown) ? DetectFilePathKind(_layout as SimpleLayout) : filePathKind);
		_cleanedFixedResult = (_layout as SimpleLayout)?.FixedText;
		if (_filePathKind == FilePathKind.Relative)
		{
			_baseDir = AppDomain.CurrentDomain.BaseDirectory;
			InternalLogger.Debug("FileTarget FilePathLayout with FilePathKind.Relative using AppDomain.BaseDirectory: {0}", _baseDir);
		}
		if (_cleanedFixedResult != null)
		{
			if (!StringHelpers.IsNullOrWhiteSpace(_cleanedFixedResult))
			{
				string cleanFileName = GetCleanFileName(_cleanedFixedResult);
				if (_filePathKind == FilePathKind.Absolute && cleanFileName != _cleanedFixedResult)
				{
					InternalLogger.Warn("FileTarget FilePathLayout contains invalid file characters, that have been removed : {0}", _cleanedFixedResult);
				}
				_cleanedFixedResult = cleanFileName;
				_filePathKind = FilePathKind.Absolute;
			}
			else
			{
				_filePathKind = FilePathKind.Unknown;
			}
		}
		if (layout is SimpleLayout simpleLayout)
		{
			string originalText = simpleLayout.OriginalText;
			if (originalText != null && originalText.IndexOfAny(new char[8] { '\a', '\b', '\f', '\n', '\r', '\t', '\v', '"' }) >= 0)
			{
				InternalLogger.Warn("FileTarget FilePathLayout contains unexpected escape characters (Maybe change to forward-slash): {0}", _cleanedFixedResult ?? simpleLayout.OriginalText);
				return;
			}
		}
		if (_cleanedFixedResult != null && DetectFilePathKind(_cleanedFixedResult) != FilePathKind.Absolute && _cleanedFixedResult.IndexOfAny(DirectorySeparatorChars) < 0)
		{
			InternalLogger.Warn("FileTarget FilePathLayout not recognized as absolute path (Maybe change to forward-slash): {0}", _cleanedFixedResult);
		}
	}

	public Layout GetLayout()
	{
		return _layout;
	}

	private string GetRenderedFileName(LogEventInfo logEvent, StringBuilder reusableBuilder = null)
	{
		if (reusableBuilder == null)
		{
			return _layout.Render(logEvent);
		}
		_layout.Render(logEvent, reusableBuilder);
		if (_cachedPrevRawFileName != null && reusableBuilder.EqualTo(_cachedPrevRawFileName))
		{
			return _cachedPrevRawFileName;
		}
		_cachedPrevRawFileName = reusableBuilder.ToString();
		_cachedPrevCleanFileName = null;
		return _cachedPrevRawFileName;
	}

	private string GetCleanFileName(string rawFileName)
	{
		string text = rawFileName;
		if (_cleanupInvalidChars)
		{
			text = CleanupInvalidFilePath(rawFileName);
		}
		if (_filePathKind == FilePathKind.Absolute)
		{
			return text;
		}
		if (_filePathKind == FilePathKind.Relative && _baseDir != null)
		{
			return Path.Combine(_baseDir, text);
		}
		return Path.GetFullPath(text);
	}

	public string Render(LogEventInfo logEvent)
	{
		return RenderWithBuilder(logEvent);
	}

	internal string RenderWithBuilder(LogEventInfo logEvent, StringBuilder reusableBuilder = null)
	{
		if (_cleanedFixedResult != null)
		{
			return _cleanedFixedResult;
		}
		string renderedFileName = GetRenderedFileName(logEvent, reusableBuilder);
		if (string.IsNullOrEmpty(renderedFileName))
		{
			return renderedFileName;
		}
		if (_filePathKind == FilePathKind.Absolute && !_cleanupInvalidChars)
		{
			return renderedFileName;
		}
		if (string.Equals(_cachedPrevRawFileName, renderedFileName, StringComparison.Ordinal) && _cachedPrevCleanFileName != null)
		{
			return _cachedPrevCleanFileName;
		}
		string result = (_cachedPrevCleanFileName = GetCleanFileName(renderedFileName));
		_cachedPrevRawFileName = renderedFileName;
		return result;
	}

	internal static FilePathKind DetectFilePathKind(SimpleLayout pathLayout)
	{
		if (pathLayout == null)
		{
			return FilePathKind.Unknown;
		}
		bool isFixedText = pathLayout.IsFixedText;
		return DetectFilePathKind(isFixedText ? pathLayout.FixedText : pathLayout.Text, isFixedText);
	}

	internal static FilePathKind DetectFilePathKind(string path, bool isFixedText = true)
	{
		if (!string.IsNullOrEmpty(path))
		{
			path = path.TrimStart(Array.Empty<char>());
			int length = path.Length;
			if (length >= 1)
			{
				char c = path[0];
				if (IsAbsoluteStartChar(c))
				{
					return FilePathKind.Absolute;
				}
				if (c == '.')
				{
					return FilePathKind.Relative;
				}
				if (length >= 2)
				{
					char c2 = path[1];
					if (Path.VolumeSeparatorChar != Path.DirectorySeparatorChar && c2 == Path.VolumeSeparatorChar)
					{
						return FilePathKind.Absolute;
					}
				}
				if (IsLayoutRenderer(path, isFixedText))
				{
					return FilePathKind.Unknown;
				}
				return FilePathKind.Relative;
			}
		}
		return FilePathKind.Unknown;
	}

	private static bool IsLayoutRenderer(string path, bool isFixedText)
	{
		if (!isFixedText)
		{
			return path.StartsWith("${", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	private static bool IsAbsoluteStartChar(char firstChar)
	{
		if (firstChar != Path.DirectorySeparatorChar)
		{
			return firstChar == Path.AltDirectorySeparatorChar;
		}
		return true;
	}

	private static string CleanupInvalidFilePath(string filePath)
	{
		if (StringHelpers.IsNullOrWhiteSpace(filePath))
		{
			return filePath;
		}
		int num = filePath.LastIndexOfAny(DirectorySeparatorChars);
		char[] array = null;
		for (int i = num + 1; i < filePath.Length; i++)
		{
			if (InvalidFileNameChars.Contains(filePath[i]))
			{
				if (array == null)
				{
					array = filePath.Substring(num + 1).ToCharArray();
				}
				array[i - (num + 1)] = '_';
			}
		}
		if (array != null)
		{
			string path = ((num > 0) ? filePath.Substring(0, num + 1) : string.Empty);
			string path2 = new string(array);
			return Path.Combine(path, path2);
		}
		return filePath;
	}
}

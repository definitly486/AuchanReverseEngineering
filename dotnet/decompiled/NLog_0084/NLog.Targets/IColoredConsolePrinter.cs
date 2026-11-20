using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NLog.Targets;

internal interface IColoredConsolePrinter
{
	IList<ConsoleRowHighlightingRule> DefaultConsoleRowHighlightingRules { get; }

	TextWriter AcquireTextWriter(TextWriter consoleStream, StringBuilder reusableBuilder);

	void ReleaseTextWriter(TextWriter consoleWriter, TextWriter consoleStream, ConsoleColor? oldForegroundColor, ConsoleColor? oldBackgroundColor, bool flush);

	ConsoleColor? ChangeForegroundColor(TextWriter consoleWriter, ConsoleColor? foregroundColor, ConsoleColor? oldForegroundColor = null);

	ConsoleColor? ChangeBackgroundColor(TextWriter consoleWriter, ConsoleColor? backgroundColor, ConsoleColor? oldBackgroundColor = null);

	void ResetDefaultColors(TextWriter consoleWriter, ConsoleColor? foregroundColor, ConsoleColor? backgroundColor);

	void WriteSubString(TextWriter consoleWriter, string text, int index, int endIndex);

	void WriteChar(TextWriter consoleWriter, char text);

	void WriteLine(TextWriter consoleWriter, string text);
}

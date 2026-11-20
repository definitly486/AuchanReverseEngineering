using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets;

[Target("ColoredConsole")]
public sealed class ColoredConsoleTarget : TargetWithLayoutHeaderAndFooter
{
	private bool _pauseLogging;

	private bool _disableColors;

	private IColoredConsolePrinter _consolePrinter;

	private Encoding? _encoding;

	[Obsolete("Replaced by StdErr to align with ConsoleTarget. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ErrorStream
	{
		get
		{
			Layout<bool>? stdErr = StdErr;
			if (stdErr != null && stdErr.IsFixed)
			{
				return StdErr.FixedValue;
			}
			return false;
		}
		set
		{
			StdErr = value;
		}
	}

	public Layout<bool>? StdErr { get; set; }

	public bool UseDefaultRowHighlightingRules { get; set; } = true;

	public Encoding Encoding
	{
		get
		{
			return ConsoleTargetHelper.GetConsoleOutputEncoding(_encoding, base.IsInitialized, _pauseLogging);
		}
		set
		{
			if (ConsoleTargetHelper.SetConsoleOutputEncoding(value, base.IsInitialized, _pauseLogging))
			{
				_encoding = value;
			}
		}
	}

	public bool DetectConsoleAvailable { get; set; }

	public bool DetectOutputRedirected { get; set; }

	public bool AutoFlush { get; set; }

	public bool EnableAnsiOutput { get; set; }

	public Layout<bool> NoColor { get; set; } = Layout<bool>.FromMethod((LogEventInfo evt) => new string[2] { "1", "TRUE" }.Contains(EnvironmentHelper.GetSafeEnvironmentVariable("NO_COLOR")?.Trim().ToUpper()));

	[ArrayParameter(typeof(ConsoleRowHighlightingRule), "highlight-row")]
	public IList<ConsoleRowHighlightingRule> RowHighlightingRules { get; } = new List<ConsoleRowHighlightingRule>();

	[ArrayParameter(typeof(ConsoleWordHighlightingRule), "highlight-word")]
	public IList<ConsoleWordHighlightingRule> WordHighlightingRules { get; } = new List<ConsoleWordHighlightingRule>();

	public ColoredConsoleTarget()
	{
		_consolePrinter = CreateConsolePrinter(EnableAnsiOutput);
	}

	public ColoredConsoleTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void InitializeTarget()
	{
		_pauseLogging = false;
		_disableColors = false;
		if (DetectConsoleAvailable)
		{
			_pauseLogging = !ConsoleTargetHelper.IsConsoleAvailable(out string reason);
			if (_pauseLogging)
			{
				InternalLogger.Info("{0}: Console detected as turned off. Set DetectConsoleAvailable=false to skip detection. Reason: {1}", this, reason);
			}
		}
		if (_encoding != null)
		{
			ConsoleTargetHelper.SetConsoleOutputEncoding(_encoding, isInitialized: true, _pauseLogging);
		}
		if (DetectOutputRedirected)
		{
			try
			{
				bool flag = RenderLogEvent(StdErr, LogEventInfo.CreateNullEvent(), defaultValue: false);
				_disableColors = (flag ? Console.IsErrorRedirected : Console.IsOutputRedirected);
				if (_disableColors)
				{
					InternalLogger.Info("{0}: Console output is redirected so no colors. Set DetectOutputRedirected=false to skip detection.", this);
					if (!AutoFlush && GetOutput(flag) is StreamWriter { AutoFlush: false })
					{
						AutoFlush = true;
					}
				}
			}
			catch (Exception ex)
			{
				InternalLogger.Error(ex, "{0}: Failed checking if Console Output Redirected.", new ReadOnlySpan<object>(new object[1] { this }));
			}
		}
		if (!_disableColors)
		{
			Layout<bool> noColor = NoColor;
			if (noColor != null && noColor.RenderValue(LogEventInfo.CreateNullEvent(), defaultValue: false))
			{
				_disableColors = true;
				InternalLogger.Info("{0}: Environment with NO_COLOR, so colors are disabled. Set NoColor=false to skip detection.", this);
			}
		}
		base.InitializeTarget();
		if (base.Header != null)
		{
			LogEventInfo logEvent = LogEventInfo.CreateNullEvent();
			WriteToOutput(logEvent, RenderLogEvent(base.Header, logEvent));
		}
		_consolePrinter = CreateConsolePrinter(EnableAnsiOutput);
	}

	private static IColoredConsolePrinter CreateConsolePrinter(bool enableAnsiOutput)
	{
		if (!enableAnsiOutput)
		{
			return new ColoredConsoleSystemPrinter();
		}
		return new ColoredConsoleAnsiPrinter();
	}

	protected override void CloseTarget()
	{
		if (base.Footer != null)
		{
			LogEventInfo logEvent = LogEventInfo.CreateNullEvent();
			WriteToOutput(logEvent, RenderLogEvent(base.Footer, logEvent));
		}
		ExplicitConsoleFlush();
		base.CloseTarget();
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		try
		{
			ExplicitConsoleFlush();
			base.FlushAsync(asyncContinuation);
		}
		catch (Exception exception)
		{
			asyncContinuation(exception);
		}
	}

	private void ExplicitConsoleFlush()
	{
		if (!_pauseLogging && !AutoFlush)
		{
			Layout<bool>? stdErr = StdErr;
			if (stdErr == null || stdErr.IsFixed)
			{
				GetOutput(StdErr?.FixedValue ?? false).Flush();
				return;
			}
			GetOutput(stdErr: false).Flush();
			GetOutput(stdErr: true).Flush();
		}
	}

	protected override void Write(LogEventInfo logEvent)
	{
		if (!_pauseLogging)
		{
			WriteToOutput(logEvent, RenderLogEvent(Layout, logEvent));
		}
	}

	private void WriteToOutput(LogEventInfo logEvent, string message)
	{
		try
		{
			WriteToOutputWithColor(logEvent, message ?? string.Empty);
		}
		catch (Exception ex) when (ex is OverflowException || ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
		{
			_pauseLogging = true;
			InternalLogger.Warn(ex, "{0}: {1} has been thrown and this is probably due to a race condition.Logging to the console will be paused. Enable by reloading the config or re-initialize the targets", new ReadOnlySpan<object>(new object[2]
			{
				this,
				ex.GetType()
			}));
		}
	}

	private void WriteToOutputWithColor(LogEventInfo logEvent, string message)
	{
		string text = message;
		ConsoleColor? newForegroundColor = null;
		ConsoleColor? newBackgroundColor = null;
		if (!_disableColors)
		{
			ConsoleRowHighlightingRule matchingRowHighlightingRule = GetMatchingRowHighlightingRule(logEvent);
			if (WordHighlightingRules.Count > 0)
			{
				text = GenerateColorEscapeSequences(logEvent, message);
			}
			newForegroundColor = ((matchingRowHighlightingRule.ForegroundColor != ConsoleOutputColor.NoChange) ? new ConsoleColor?((ConsoleColor)matchingRowHighlightingRule.ForegroundColor) : ((ConsoleColor?)null));
			newBackgroundColor = ((matchingRowHighlightingRule.BackgroundColor != ConsoleOutputColor.NoChange) ? new ConsoleColor?((ConsoleColor)matchingRowHighlightingRule.BackgroundColor) : ((ConsoleColor?)null));
		}
		TextWriter output = GetOutput(RenderLogEvent(StdErr, logEvent, defaultValue: false));
		if ((object)text == message && !newForegroundColor.HasValue && !newBackgroundColor.HasValue)
		{
			ConsoleTargetHelper.WriteLineThreadSafe(output, message, AutoFlush);
			return;
		}
		bool flag = (object)text != message;
		if (!flag && message.IndexOf('\n') >= 0)
		{
			flag = true;
			text = EscapeColorCodes(message);
		}
		WriteToOutputWithPrinter(output, text, newForegroundColor, newBackgroundColor, flag);
	}

	private void WriteToOutputWithPrinter(TextWriter consoleStream, string colorMessage, ConsoleColor? newForegroundColor, ConsoleColor? newBackgroundColor, bool wordHighlighting)
	{
		ReusableObjectCreator<StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
		try
		{
			TextWriter consoleWriter = _consolePrinter.AcquireTextWriter(consoleStream, lockOject.Result);
			ConsoleColor? consoleColor = null;
			ConsoleColor? consoleColor2 = null;
			try
			{
				if (wordHighlighting)
				{
					consoleColor = _consolePrinter.ChangeForegroundColor(consoleWriter, newForegroundColor);
					consoleColor2 = _consolePrinter.ChangeBackgroundColor(consoleWriter, newBackgroundColor);
					ConsoleColor? rowForegroundColor = newForegroundColor ?? consoleColor;
					ConsoleColor? rowBackgroundColor = newBackgroundColor ?? consoleColor2;
					ColorizeEscapeSequences(_consolePrinter, consoleWriter, colorMessage, consoleColor, consoleColor2, rowForegroundColor, rowBackgroundColor);
					_consolePrinter.WriteLine(consoleWriter, string.Empty);
					return;
				}
				if (newForegroundColor.HasValue)
				{
					consoleColor = _consolePrinter.ChangeForegroundColor(consoleWriter, newForegroundColor.Value);
					if (consoleColor == newForegroundColor)
					{
						consoleColor = null;
					}
				}
				if (newBackgroundColor.HasValue)
				{
					consoleColor2 = _consolePrinter.ChangeBackgroundColor(consoleWriter, newBackgroundColor.Value);
					if (consoleColor2 == newBackgroundColor)
					{
						consoleColor2 = null;
					}
				}
				_consolePrinter.WriteLine(consoleWriter, colorMessage);
			}
			finally
			{
				_consolePrinter.ReleaseTextWriter(consoleWriter, consoleStream, consoleColor, consoleColor2, AutoFlush);
			}
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private ConsoleRowHighlightingRule GetMatchingRowHighlightingRule(LogEventInfo logEvent)
	{
		ConsoleRowHighlightingRule matchingRowHighlightingRule = GetMatchingRowHighlightingRule(RowHighlightingRules, logEvent);
		if (matchingRowHighlightingRule == null && UseDefaultRowHighlightingRules)
		{
			matchingRowHighlightingRule = GetMatchingRowHighlightingRule(_consolePrinter.DefaultConsoleRowHighlightingRules, logEvent);
		}
		return matchingRowHighlightingRule ?? ConsoleRowHighlightingRule.Default;
	}

	private static ConsoleRowHighlightingRule? GetMatchingRowHighlightingRule(IList<ConsoleRowHighlightingRule> rules, LogEventInfo logEvent)
	{
		for (int i = 0; i < rules.Count; i++)
		{
			ConsoleRowHighlightingRule consoleRowHighlightingRule = rules[i];
			if (consoleRowHighlightingRule.CheckCondition(logEvent))
			{
				return consoleRowHighlightingRule;
			}
		}
		return null;
	}

	private string GenerateColorEscapeSequences(LogEventInfo logEvent, string message)
	{
		if (string.IsNullOrEmpty(message))
		{
			return message;
		}
		message = EscapeColorCodes(message);
		ReusableObjectCreator<StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
		try
		{
			StringBuilder stringBuilder = lockOject.Result;
			for (int i = 0; i < WordHighlightingRules.Count; i++)
			{
				ConsoleWordHighlightingRule consoleWordHighlightingRule = WordHighlightingRules[i];
				if (!consoleWordHighlightingRule.CheckCondition(logEvent))
				{
					continue;
				}
				IEnumerable<KeyValuePair<int, int>> wordsForHighlighting = consoleWordHighlightingRule.GetWordsForHighlighting(message);
				if (wordsForHighlighting == null)
				{
					continue;
				}
				if (stringBuilder != null)
				{
					stringBuilder.Length = 0;
				}
				int num = 0;
				foreach (KeyValuePair<int, int> item in wordsForHighlighting)
				{
					stringBuilder = stringBuilder ?? new StringBuilder(message.Length + 5);
					stringBuilder.Append(message, num, item.Key - num);
					stringBuilder.Append('\a');
					stringBuilder.Append((char)(consoleWordHighlightingRule.ForegroundColor + 65));
					stringBuilder.Append((char)(consoleWordHighlightingRule.BackgroundColor + 65));
					for (int j = 0; j < item.Value; j++)
					{
						stringBuilder.Append(message[j + item.Key]);
					}
					stringBuilder.Append('\a');
					stringBuilder.Append('X');
					num = item.Key + item.Value;
				}
				if (stringBuilder != null && stringBuilder.Length > 0)
				{
					stringBuilder.Append(message, num, message.Length - num);
					message = stringBuilder.ToString();
				}
			}
			return message;
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private static string EscapeColorCodes(string message)
	{
		if (message.IndexOf('\a') >= 0)
		{
			message = message.Replace("\a", "\a\a");
		}
		return message;
	}

	private static void ColorizeEscapeSequences(IColoredConsolePrinter consolePrinter, TextWriter consoleWriter, string message, ConsoleColor? defaultForegroundColor, ConsoleColor? defaultBackgroundColor, ConsoleColor? rowForegroundColor, ConsoleColor? rowBackgroundColor)
	{
		Stack<KeyValuePair<ConsoleColor?, ConsoleColor?>> stack = new Stack<KeyValuePair<ConsoleColor?, ConsoleColor?>>();
		stack.Push(new KeyValuePair<ConsoleColor?, ConsoleColor?>(rowForegroundColor, rowBackgroundColor));
		int num = 0;
		while (num < message.Length)
		{
			int i;
			for (i = num; i < message.Length && message[i] >= ' '; i++)
			{
			}
			if (i != num)
			{
				consolePrinter.WriteSubString(consoleWriter, message, num, i);
			}
			if (i >= message.Length)
			{
				num = i;
				break;
			}
			char c = message[i];
			switch (c)
			{
			case '\n':
			case '\r':
			{
				KeyValuePair<ConsoleColor?, ConsoleColor?> keyValuePair3 = stack.Peek();
				ConsoleColor? foregroundColor = ((keyValuePair3.Key != defaultForegroundColor) ? defaultForegroundColor : ((ConsoleColor?)null));
				ConsoleColor? backgroundColor = ((keyValuePair3.Value != defaultBackgroundColor) ? defaultBackgroundColor : ((ConsoleColor?)null));
				consolePrinter.ResetDefaultColors(consoleWriter, foregroundColor, backgroundColor);
				if (i + 1 < message.Length && message[i + 1] == '\n')
				{
					consolePrinter.WriteSubString(consoleWriter, message, i, i + 2);
					num = i + 2;
				}
				else
				{
					consolePrinter.WriteChar(consoleWriter, c);
					num = i + 1;
				}
				consolePrinter.ChangeForegroundColor(consoleWriter, keyValuePair3.Key, defaultForegroundColor);
				consolePrinter.ChangeBackgroundColor(consoleWriter, keyValuePair3.Value, defaultBackgroundColor);
				break;
			}
			case '\a':
				if (i + 1 < message.Length)
				{
					char c2 = message[i + 1];
					switch (c2)
					{
					case '\a':
						consolePrinter.WriteChar(consoleWriter, '\a');
						num = i + 2;
						break;
					case 'X':
					{
						KeyValuePair<ConsoleColor?, ConsoleColor?> keyValuePair = stack.Pop();
						KeyValuePair<ConsoleColor?, ConsoleColor?> keyValuePair2 = stack.Peek();
						if (keyValuePair2.Key != keyValuePair.Key || keyValuePair2.Value != keyValuePair.Value)
						{
							if ((keyValuePair.Key.HasValue && !keyValuePair2.Key.HasValue) || (keyValuePair.Value.HasValue && !keyValuePair2.Value.HasValue))
							{
								consolePrinter.ResetDefaultColors(consoleWriter, defaultForegroundColor, defaultBackgroundColor);
							}
							consolePrinter.ChangeForegroundColor(consoleWriter, keyValuePair2.Key, keyValuePair.Key);
							consolePrinter.ChangeBackgroundColor(consoleWriter, keyValuePair2.Value, keyValuePair.Value);
						}
						num = i + 2;
						break;
					}
					default:
					{
						ConsoleColor? consoleColor = stack.Peek().Key;
						ConsoleColor? consoleColor2 = stack.Peek().Value;
						ConsoleOutputColor consoleOutputColor = (ConsoleOutputColor)(c2 - 65);
						ConsoleOutputColor consoleOutputColor2 = (ConsoleOutputColor)(message[i + 2] - 65);
						if (consoleOutputColor != ConsoleOutputColor.NoChange)
						{
							consoleColor = (ConsoleColor)consoleOutputColor;
							consolePrinter.ChangeForegroundColor(consoleWriter, consoleColor);
						}
						if (consoleOutputColor2 != ConsoleOutputColor.NoChange)
						{
							consoleColor2 = (ConsoleColor)consoleOutputColor2;
							consolePrinter.ChangeBackgroundColor(consoleWriter, consoleColor2);
						}
						stack.Push(new KeyValuePair<ConsoleColor?, ConsoleColor?>(consoleColor, consoleColor2));
						num = i + 3;
						break;
					}
					}
					break;
				}
				goto default;
			default:
				consolePrinter.WriteChar(consoleWriter, c);
				num = i + 1;
				break;
			}
		}
		if (num < message.Length)
		{
			consolePrinter.WriteSubString(consoleWriter, message, num, message.Length);
		}
	}

	private static TextWriter GetOutput(bool stdErr)
	{
		if (!stdErr)
		{
			return Console.Out;
		}
		return Console.Error;
	}
}

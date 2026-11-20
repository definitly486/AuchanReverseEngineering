using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using NLog.Common;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets;

[Target("Console")]
public sealed class ConsoleTarget : TargetWithLayoutHeaderAndFooter
{
	private bool _pauseLogging;

	private readonly ReusableBufferCreator _reusableEncodingBuffer = new ReusableBufferCreator(16384);

	private Encoding? _encoding;

	[Obsolete("Replaced by StdErr to align with ColoredConsoleTarget. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool Error
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

	public bool AutoFlush { get; set; }

	public bool ForceWriteLine { get; set; }

	[Obsolete("Replaced by ForceWriteLine. Marked obsolete with NLog v6.0")]
	public bool WriteBuffer
	{
		get
		{
			return !ForceWriteLine;
		}
		set
		{
			ForceWriteLine = !value;
		}
	}

	public ConsoleTarget()
	{
	}

	public ConsoleTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void InitializeTarget()
	{
		_pauseLogging = false;
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
		base.InitializeTarget();
		if (base.Header != null)
		{
			RenderToOutput(base.Header, LogEventInfo.CreateNullEvent());
		}
	}

	protected override void CloseTarget()
	{
		if (base.Footer != null)
		{
			RenderToOutput(base.Footer, LogEventInfo.CreateNullEvent());
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
			RenderToOutput(Layout, logEvent);
		}
	}

	protected override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		if (!_pauseLogging)
		{
			if (ForceWriteLine)
			{
				base.Write(logEvents);
			}
			else
			{
				WriteBufferToOutput(logEvents);
			}
		}
	}

	private void RenderToOutput(Layout layout, LogEventInfo logEvent)
	{
		if (!_pauseLogging)
		{
			TextWriter output = GetOutput(RenderLogEvent(StdErr, logEvent, defaultValue: false));
			if (ForceWriteLine)
			{
				WriteLineToOutput(output, RenderLogEvent(layout, logEvent));
			}
			else
			{
				WriteBufferToOutput(output, layout, logEvent);
			}
		}
	}

	private void WriteBufferToOutput(TextWriter output, Layout layout, LogEventInfo logEvent)
	{
		int targetBufferPosition = 0;
		ReusableObjectCreator<char[]>.LockOject lockOject = _reusableEncodingBuffer.Allocate();
		try
		{
			ReusableObjectCreator<StringBuilder>.LockOject lockOject2 = ReusableLayoutBuilder.Allocate();
			try
			{
				RenderLogEventToWriteBuffer(output, layout, logEvent, lockOject2.Result, lockOject.Result, ref targetBufferPosition);
				if (targetBufferPosition > 0)
				{
					WriteBufferToOutput(output, lockOject.Result, targetBufferPosition);
				}
			}
			finally
			{
				((IDisposable)lockOject2/*cast due to .constrained prefix*/).Dispose();
			}
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private void WriteBufferToOutput(IList<AsyncLogEventInfo> logEvents)
	{
		ReusableObjectCreator<char[]>.LockOject lockOject = _reusableEncodingBuffer.Allocate();
		try
		{
			ReusableObjectCreator<StringBuilder>.LockOject lockOject2 = ReusableLayoutBuilder.Allocate();
			try
			{
				int targetBufferPosition = 0;
				bool flag = false;
				TextWriter output = GetOutput(flag);
				try
				{
					for (int i = 0; i < logEvents.Count; i++)
					{
						LogEventInfo logEvent = logEvents[i].LogEvent;
						if (flag != RenderLogEvent(StdErr, logEvent, defaultValue: false))
						{
							if (targetBufferPosition > 0)
							{
								WriteBufferToOutput(output, lockOject.Result, targetBufferPosition);
							}
							flag = !flag;
							output = GetOutput(flag);
						}
						lockOject2.Result.ClearBuilder();
						RenderLogEventToWriteBuffer(output, Layout, logEvent, lockOject2.Result, lockOject.Result, ref targetBufferPosition);
						logEvents[i].Continuation(null);
					}
				}
				finally
				{
					if (targetBufferPosition > 0)
					{
						WriteBufferToOutput(output, lockOject.Result, targetBufferPosition);
					}
				}
			}
			finally
			{
				((IDisposable)lockOject2/*cast due to .constrained prefix*/).Dispose();
			}
		}
		finally
		{
			((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
		}
	}

	private void RenderLogEventToWriteBuffer(TextWriter output, Layout layout, LogEventInfo logEvent, StringBuilder targetBuilder, char[] targetBuffer, ref int targetBufferPosition)
	{
		int length = "\n".Length;
		layout.Render(logEvent, targetBuilder);
		if (targetBuilder.Length > targetBuffer.Length - targetBufferPosition - length)
		{
			if (targetBufferPosition > 0)
			{
				WriteBufferToOutput(output, targetBuffer, targetBufferPosition);
				targetBufferPosition = 0;
			}
			if (targetBuilder.Length > targetBuffer.Length - length)
			{
				WriteLineToOutput(output, targetBuilder.ToString());
				return;
			}
		}
		targetBuilder.Append("\n");
		targetBuilder.CopyToBuffer(targetBuffer, targetBufferPosition);
		targetBufferPosition += targetBuilder.Length;
	}

	private void WriteLineToOutput(TextWriter output, string message)
	{
		try
		{
			ConsoleTargetHelper.WriteLineThreadSafe(output, message, AutoFlush);
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

	private void WriteBufferToOutput(TextWriter output, char[] buffer, int length)
	{
		try
		{
			ConsoleTargetHelper.WriteBufferThreadSafe(output, buffer, length, AutoFlush);
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

	private static TextWriter GetOutput(bool stdErr)
	{
		if (!stdErr)
		{
			return Console.Out;
		}
		return Console.Error;
	}
}

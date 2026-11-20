using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers;

[LayoutRenderer("stacktrace")]
[ThreadAgnostic]
public class StackTraceLayoutRenderer : LayoutRenderer, IUsesStackTrace
{
	private readonly struct StackFrameList
	{
		private readonly StackTrace _stackTrace;

		private readonly int _startingFrame;

		private readonly int _endingFrame;

		private readonly bool _reverse;

		public int Count => _startingFrame - _endingFrame;

		public StackFrame this[int index]
		{
			get
			{
				int index2 = (_reverse ? (_endingFrame + index + 1) : (_startingFrame - index));
				return _stackTrace.GetFrame(index2);
			}
		}

		public StackFrameList(StackTrace stackTrace, int startingFrame, int endingFrame, bool reverse)
		{
			_stackTrace = stackTrace;
			_startingFrame = startingFrame;
			_endingFrame = endingFrame - 1;
			_reverse = reverse;
		}
	}

	private string _separator = " => ";

	private string _separatorOriginal = " => ";

	public StackTraceFormat Format { get; set; } = StackTraceFormat.Flat;

	public int TopFrames { get; set; } = 3;

	public int SkipFrames { get; set; }

	public string Separator
	{
		get
		{
			return _separatorOriginal ?? _separator;
		}
		set
		{
			_separatorOriginal = value;
			_separator = SimpleLayout.Evaluate(value, base.LoggingConfiguration, null, false);
		}
	}

	public bool CaptureStackTrace { get; set; } = true;

	public bool Reverse { get; set; }

	StackTraceUsage IUsesStackTrace.StackTraceUsage
	{
		get
		{
			if (!CaptureStackTrace)
			{
				return StackTraceUsage.None;
			}
			if (Format == StackTraceFormat.Raw)
			{
				return StackTraceUsage.WithSource;
			}
			return StackTraceUsage.WithStackTrace;
		}
	}

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (_separatorOriginal != null)
		{
			_separator = SimpleLayout.Evaluate(_separatorOriginal, base.LoggingConfiguration);
		}
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (logEvent.StackTrace != null)
		{
			int num = logEvent.CallSiteInformation?.UserStackFrameNumberLegacy ?? logEvent.CallSiteInformation?.UserStackFrameNumber ?? 0;
			int num2 = num + TopFrames - 1;
			if (num2 >= logEvent.StackTrace.GetFrameCount())
			{
				num2 = logEvent.StackTrace.GetFrameCount() - 1;
			}
			int endingFrame = num + SkipFrames;
			StackFrameList stackFrameList = new StackFrameList(logEvent.StackTrace, num2, endingFrame, Reverse);
			switch (Format)
			{
			case StackTraceFormat.Raw:
				AppendRaw(builder, stackFrameList);
				break;
			case StackTraceFormat.Flat:
				AppendFlat(builder, stackFrameList);
				break;
			case StackTraceFormat.DetailedFlat:
				AppendDetailedFlat(builder, stackFrameList);
				break;
			}
		}
	}

	private void AppendRaw(StringBuilder builder, StackFrameList stackFrameList)
	{
		string text = null;
		for (int i = 0; i < stackFrameList.Count; i++)
		{
			builder.Append(text);
			StackFrame stackFrame = stackFrameList[i];
			builder.Append(stackFrame.ToString());
			text = text ?? _separator ?? string.Empty;
		}
	}

	private void AppendFlat(StringBuilder builder, StackFrameList stackFrameList)
	{
		bool flag = true;
		for (int i = 0; i < stackFrameList.Count; i++)
		{
			MethodBase stackMethod = StackTraceUsageUtils.GetStackMethod(stackFrameList[i]);
			if ((object)stackMethod != null)
			{
				if (!flag)
				{
					builder.Append(_separator);
				}
				Type declaringType = stackMethod.DeclaringType;
				if ((object)declaringType == null)
				{
					builder.Append("<no type>");
				}
				else
				{
					builder.Append(declaringType.Name);
				}
				builder.Append('.');
				builder.Append(stackMethod.Name);
				flag = false;
			}
		}
	}

	private void AppendDetailedFlat(StringBuilder builder, StackFrameList stackFrameList)
	{
		bool flag = true;
		for (int i = 0; i < stackFrameList.Count; i++)
		{
			MethodBase stackMethod = StackTraceUsageUtils.GetStackMethod(stackFrameList[i]);
			if ((object)stackMethod != null)
			{
				if (!flag)
				{
					builder.Append(_separator);
				}
				builder.Append('[');
				builder.Append(stackMethod);
				builder.Append(']');
				flag = false;
			}
		}
	}
}

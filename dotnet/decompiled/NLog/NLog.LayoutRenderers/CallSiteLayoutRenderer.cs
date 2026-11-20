using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("callsite")]
[ThreadAgnostic]
public class CallSiteLayoutRenderer : LayoutRenderer, IUsesStackTrace
{
	public bool ClassName { get; set; } = true;

	public bool IncludeNamespace { get; set; } = true;

	public bool MethodName { get; set; } = true;

	public bool CleanNamesOfAnonymousDelegates { get; set; } = true;

	public bool CleanNamesOfAsyncContinuations { get; set; } = true;

	public int SkipFrames { get; set; }

	public bool FileName { get; set; }

	public bool IncludeSourcePath { get; set; } = true;

	public bool CaptureStackTrace { get; set; } = true;

	StackTraceUsage IUsesStackTrace.StackTraceUsage => (StackTraceUsage)((int)StackTraceUsageUtils.GetStackTraceUsage(FileName, SkipFrames, CaptureStackTrace) | (ClassName ? 8 : 0));

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		CallSiteInformation callSiteInformation = logEvent.CallSiteInformation;
		if (callSiteInformation == null)
		{
			AppendExceptionCallSite(builder, logEvent);
			return;
		}
		if (ClassName || MethodName)
		{
			MethodBase callerStackFrameMethod = callSiteInformation.GetCallerStackFrameMethod(SkipFrames);
			if (ClassName)
			{
				string callerClassName = callSiteInformation.GetCallerClassName(callerStackFrameMethod, IncludeNamespace, CleanNamesOfAsyncContinuations, CleanNamesOfAnonymousDelegates);
				builder.Append(string.IsNullOrEmpty(callerClassName) ? "<no type>" : callerClassName);
			}
			if (MethodName)
			{
				string callerMethodName = callSiteInformation.GetCallerMethodName(callerStackFrameMethod, includeMethodInfo: false, CleanNamesOfAsyncContinuations, CleanNamesOfAnonymousDelegates);
				if (ClassName)
				{
					builder.Append('.');
				}
				builder.Append(string.IsNullOrEmpty(callerMethodName) ? "<no method>" : callerMethodName);
			}
		}
		if (FileName)
		{
			string callerFilePath = callSiteInformation.GetCallerFilePath(SkipFrames);
			if (!string.IsNullOrEmpty(callerFilePath))
			{
				int callerLineNumber = callSiteInformation.GetCallerLineNumber(SkipFrames);
				AppendFileName(builder, callerFilePath, callerLineNumber);
			}
		}
	}

	private void AppendFileName(StringBuilder builder, string fileName, int lineNumber)
	{
		builder.Append('(');
		if (IncludeSourcePath)
		{
			builder.Append(fileName);
		}
		else
		{
			builder.Append(Path.GetFileName(fileName));
		}
		builder.Append(':');
		builder.AppendInvariant(lineNumber);
		builder.Append(')');
	}

	[UnconditionalSuppressMessage("Trimming - Allow callsite logic", "IL2026")]
	private void AppendExceptionCallSite(StringBuilder builder, LogEventInfo logEvent)
	{
		MethodBase methodBase = logEvent?.Exception?.TargetSite;
		if (methodBase != null)
		{
			if (ClassName)
			{
				string stackFrameMethodClassName = StackTraceUsageUtils.GetStackFrameMethodClassName(methodBase, includeNameSpace: true, CleanNamesOfAsyncContinuations, CleanNamesOfAnonymousDelegates);
				builder.Append(stackFrameMethodClassName);
			}
			if (MethodName)
			{
				if (ClassName)
				{
					builder.Append('.');
				}
				string stackFrameMethodName = StackTraceUsageUtils.GetStackFrameMethodName(methodBase, includeMethodInfo: false, CleanNamesOfAsyncContinuations, CleanNamesOfAnonymousDelegates);
				builder.Append(stackFrameMethodName);
			}
		}
		else if (ClassName || FileName)
		{
			string value = logEvent?.Exception?.Source;
			builder.Append(value);
		}
	}
}

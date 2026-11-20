using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;
using Java.Lang;

namespace Android.Runtime;

internal sealed class JavaProxyThrowable : Error
{
	public new readonly System.Exception InnerException;

	private JavaProxyThrowable(string message, System.Exception innerException)
		: base(message)
	{
		InnerException = innerException;
	}

	public static JavaProxyThrowable Create(System.Exception innerException)
	{
		if (innerException == null)
		{
			throw new ArgumentNullException("innerException");
		}
		JavaProxyThrowable javaProxyThrowable = new JavaProxyThrowable($"[{innerException.GetType()}]: {innerException.Message}", innerException);
		try
		{
			javaProxyThrowable.TranslateStackTrace();
		}
		catch (System.Exception value)
		{
			Console.WriteLine($"JavaProxyThrowable: translation threw an exception: {value}");
			javaProxyThrowable = new JavaProxyThrowable(innerException.ToString(), innerException);
		}
		return javaProxyThrowable;
	}

	private (int lineNumber, string? methodName, string? className) GetFrameInfo(StackFrame? managedFrame, MethodBase? managedMethod)
	{
		string item = null;
		string item2 = null;
		if (managedFrame == null)
		{
			if (managedMethod != null)
			{
				item = managedMethod.Name;
				item2 = managedMethod.DeclaringType?.FullName;
			}
			return (lineNumber: -1, methodName: item, className: item2);
		}
		int num = -1;
		num = managedFrame.GetFileLineNumber();
		if (num == 0)
		{
			num = (managedFrame.HasNativeImage() ? (-2) : (-1));
		}
		if (managedMethod != null)
		{
			item = ((num != -1 || !managedFrame.HasILOffset()) ? managedMethod.Name : $"{managedMethod.Name} + 0x{managedFrame.GetILOffset():x}");
			return (lineNumber: num, methodName: item, className: managedMethod.DeclaringType?.FullName);
		}
		string text = managedFrame.ToString();
		System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
		int num2 = text.IndexOf(' ');
		string text2 = null;
		if (num2 > 1)
		{
			text2 = text.Substring(0, num2);
		}
		if (!string.IsNullOrEmpty(text2) && (num2 = text2.LastIndexOf('.')) >= 1)
		{
			item2 = ((num2 + 1 < text2.Length) ? text2.Substring(num2 + 1) : null);
			text2 = text2.Substring(0, num2);
		}
		if (!string.IsNullOrEmpty(text2))
		{
			stringBuilder.Append(text2);
		}
		else if (managedFrame.HasNativeImage())
		{
			nint nativeIP = managedFrame.GetNativeIP();
			System.Text.StringBuilder stringBuilder2 = stringBuilder;
			System.Text.StringBuilder stringBuilder3 = stringBuilder2;
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider provider = invariantCulture;
			System.Text.StringBuilder.AppendInterpolatedStringHandler handler = new System.Text.StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2, invariantCulture);
			handler.AppendLiteral("Native 0x");
			handler.AppendFormatted(nativeIP, "x");
			stringBuilder3.Append(provider, ref handler);
		}
		if (stringBuilder.Length > 0)
		{
			int nativeOffset = managedFrame.GetNativeOffset();
			if (nativeOffset != -1)
			{
				stringBuilder.Append(" + ");
				System.Text.StringBuilder stringBuilder2 = stringBuilder;
				System.Text.StringBuilder stringBuilder4 = stringBuilder2;
				IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
				IFormatProvider provider2 = invariantCulture;
				System.Text.StringBuilder.AppendInterpolatedStringHandler handler = new System.Text.StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder2, invariantCulture);
				handler.AppendLiteral("0x");
				handler.AppendFormatted(nativeOffset, "x");
				stringBuilder4.Append(provider2, ref handler);
			}
		}
		if (stringBuilder.Length > 0)
		{
			item = stringBuilder.ToString();
		}
		return (lineNumber: num, methodName: item, className: item2);
	}

	private void TranslateStackTrace()
	{
		StackTrace stackTrace = new StackTrace(InnerException, fNeedFileInfo: true);
		if (stackTrace.FrameCount <= 0)
		{
			return;
		}
		StackTraceElement[] array = null;
		try
		{
			array = GetStackTrace();
		}
		catch (System.Exception value)
		{
			Console.WriteLine($"JavaProxyThrowable: obtaining Java stack trace threw an exception: {value}");
		}
		StackFrame[] frames = stackTrace.GetFrames();
		int num = frames.Length + ((array != null) ? array.Length : 0);
		StackTraceElement[] array2 = new StackTraceElement[num];
		for (int i = 0; i < frames.Length; i++)
		{
			StackFrame stackFrame = frames[i];
			MethodBase managedMethod = StackFrameGetMethod(stackFrame);
			(int lineNumber, string? methodName, string? className) frameInfo = GetFrameInfo(stackFrame, managedMethod);
			StackTraceElement stackTraceElement = new StackTraceElement(lineNumber: frameInfo.lineNumber, methodName: frameInfo.methodName ?? "Unknown", declaringClass: frameInfo.className ?? "Unknown", fileName: stackFrame?.GetFileName());
			array2[i] = stackTraceElement;
		}
		if (array != null)
		{
			for (int j = frames.Length; j < num; j++)
			{
				array2[j] = array[j - frames.Length];
			}
		}
		SetStackTrace(array2);
		[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "StackFrame.GetMethod() is \"best attempt\", we handle null & exceptions")]
		static MethodBase? StackFrameGetMethod(StackFrame frame)
		{
			return frame.GetMethod();
		}
	}
}

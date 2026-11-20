using System;
using System.Text;
using NLog.MessageTemplates;

namespace NLog;

public interface IValueFormatter
{
	bool FormatValue(object? value, string? format, CaptureType captureType, IFormatProvider? formatProvider, StringBuilder builder);
}

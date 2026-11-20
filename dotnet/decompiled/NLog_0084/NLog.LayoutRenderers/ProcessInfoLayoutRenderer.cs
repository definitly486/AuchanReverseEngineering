using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("processinfo")]
public class ProcessInfoLayoutRenderer : LayoutRenderer
{
	private Process? _process;

	private ReflectionHelpers.LateBoundMethod? _lateBoundPropertyGet;

	[DefaultParameter]
	public ProcessInfoProperty Property { get; set; } = ProcessInfoProperty.Id;

	public string? Format { get; set; }

	public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		PropertyInfo property = typeof(Process).GetProperty(Property.ToString());
		if ((object)property == null)
		{
			throw new ArgumentException($"Property '{Property}' not found in System.Diagnostics.Process");
		}
		_lateBoundPropertyGet = ReflectionHelpers.CreateLateBoundMethod(property.GetGetMethod());
		_process = Process.GetCurrentProcess();
	}

	protected override void CloseLayoutRenderer()
	{
		_process?.Close();
		_process = null;
		base.CloseLayoutRenderer();
	}

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (_process != null && _lateBoundPropertyGet != null)
		{
			object obj = _lateBoundPropertyGet(_process, ArrayHelper.Empty<object>());
			if (obj != null)
			{
				AppendFormattedValue(builder, logEvent, obj, Format, Culture);
			}
		}
	}
}

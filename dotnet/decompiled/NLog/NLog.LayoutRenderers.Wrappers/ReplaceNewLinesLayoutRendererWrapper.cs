using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("replace-newlines")]
[AmbientProperty("ReplaceNewLines")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class ReplaceNewLinesLayoutRendererWrapper : WrapperLayoutRendererBase
{
	private const string WindowsNewLine = "\r\n";

	private const string UnixNewLine = "\n";

	private string _replacement = " ";

	private bool _replaceWithNewLines;

	public string Replacement
	{
		get
		{
			return _replacement;
		}
		set
		{
			_replacement = value;
			_replaceWithNewLines = value != null && value.IndexOf('\n') >= 0;
		}
	}

	public string ReplaceNewLines
	{
		get
		{
			return Replacement;
		}
		set
		{
			Replacement = value;
		}
	}

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner?.Render(logEvent, builder);
		if (builder.Length > orgLength && builder.IndexOf('\n', orgLength) >= 0)
		{
			string value = builder.ToString(orgLength, builder.Length - orgLength).Replace("\r\n", _replaceWithNewLines ? "\n" : Replacement).Replace("\n", Replacement);
			builder.Length = orgLength;
			builder.Append(value);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}
}

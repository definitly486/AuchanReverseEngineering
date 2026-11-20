using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("filesystem-normalize")]
[AmbientProperty("FSNormalize")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class FileSystemNormalizeLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public bool FSNormalize { get; set; } = true;

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner.Render(logEvent, builder);
		if (FSNormalize && builder.Length > orgLength)
		{
			TransformFileSystemNormalize(builder, orgLength);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	private static void TransformFileSystemNormalize(StringBuilder builder, int startPos)
	{
		for (int i = startPos; i < builder.Length; i++)
		{
			if (!IsSafeCharacter(builder[i]))
			{
				builder[i] = '_';
			}
		}
	}

	private static bool IsSafeCharacter(char c)
	{
		if (!char.IsLetterOrDigit(c) && c != '_' && c != '-' && c != '.')
		{
			return c == ' ';
		}
		return true;
	}
}

using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("pad")]
[AmbientProperty("Padding")]
[AmbientProperty("PadCharacter")]
[AmbientProperty("FixedLength")]
[AmbientProperty("AlignmentOnTruncation")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class PaddingLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public int Padding { get; set; }

	public char PadCharacter { get; set; } = ' ';

	public bool FixedLength { get; set; }

	public PaddingHorizontalAlignment AlignmentOnTruncation { get; set; }

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner?.Render(logEvent, builder);
		if (Padding == 0)
		{
			return;
		}
		int num = Padding;
		if (num < 0)
		{
			num = -num;
		}
		int num2 = AppendPadding(builder, orgLength, num);
		if (FixedLength && num2 > num)
		{
			if (AlignmentOnTruncation == PaddingHorizontalAlignment.Left)
			{
				builder.Length = orgLength + num;
			}
			else
			{
				builder.Remove(orgLength, num2 - num);
			}
		}
	}

	private int AppendPadding(StringBuilder builder, int orgLength, int absolutePadding)
	{
		int num = builder.Length - orgLength;
		if (Padding > 0)
		{
			if (num < 10 || num >= absolutePadding)
			{
				for (int i = num; i < absolutePadding; i++)
				{
					builder.Append(PadCharacter);
					for (int num2 = builder.Length - 1; num2 > orgLength; num2--)
					{
						builder[num2] = builder[num2 - 1];
					}
					builder[orgLength] = PadCharacter;
					num++;
				}
			}
			else
			{
				string value = builder.ToString(orgLength, num);
				builder.Length = orgLength;
				for (int j = num; j < absolutePadding; j++)
				{
					builder.Append(PadCharacter);
					num++;
				}
				builder.Append(value);
			}
		}
		else
		{
			for (int k = num; k < absolutePadding; k++)
			{
				builder.Append(PadCharacter);
				num++;
			}
		}
		return num;
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}
}

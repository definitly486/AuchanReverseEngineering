using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("substring")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class SubstringLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public int Start { get; set; }

	public int? Length { get; set; }

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		if (Length != 0)
		{
			base.Inner?.Render(logEvent, builder);
			int num = builder.Length - orgLength;
			if (num > 0)
			{
				int num2 = CalcStart(num);
				int num3 = CalcLength(num, num2);
				string value = builder.ToString(orgLength + num2, num3);
				builder.Length = orgLength;
				builder.Append(value);
			}
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	private int CalcStart(int textLength)
	{
		int num = Start;
		if (num > textLength)
		{
			num = textLength;
		}
		if (num < 0)
		{
			num = textLength + num;
			if (num < 0)
			{
				num = 0;
			}
		}
		return num;
	}

	private int CalcLength(int textLength, int start)
	{
		int num = textLength - start;
		if (Length.HasValue && textLength > Length.Value + start)
		{
			num = Length.Value;
		}
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}
}

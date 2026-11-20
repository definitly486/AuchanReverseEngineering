using System;
using System.Text;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("rot13")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class Rot13LayoutRendererWrapper : WrapperLayoutRendererBase
{
	public Layout Text
	{
		get
		{
			return base.Inner;
		}
		set
		{
			base.Inner = value;
		}
	}

	public static string DecodeRot13(string encodedValue)
	{
		StringBuilder stringBuilder = new StringBuilder(encodedValue.Length);
		stringBuilder.Append(encodedValue);
		DecodeRot13(stringBuilder, 0);
		return stringBuilder.ToString();
	}

	protected override void RenderInnerAndTransform(LogEventInfo logEvent, StringBuilder builder, int orgLength)
	{
		base.Inner.Render(logEvent, builder);
		if (builder.Length > orgLength)
		{
			DecodeRot13(builder, orgLength);
		}
	}

	protected override string Transform(string text)
	{
		throw new NotSupportedException();
	}

	internal static void DecodeRot13(StringBuilder encodedValue, int startPos)
	{
		if (encodedValue != null)
		{
			for (int i = startPos; i < encodedValue.Length; i++)
			{
				encodedValue[i] = DecodeRot13Char(encodedValue[i]);
			}
		}
	}

	private static char DecodeRot13Char(char c)
	{
		if (c >= 'A' && c <= 'M')
		{
			return (char)(78 + (c - 65));
		}
		if (c >= 'a' && c <= 'm')
		{
			return (char)(110 + (c - 97));
		}
		if (c >= 'N' && c <= 'Z')
		{
			return (char)(65 + (c - 78));
		}
		if (c >= 'n' && c <= 'z')
		{
			return (char)(97 + (c - 110));
		}
		return c;
	}
}

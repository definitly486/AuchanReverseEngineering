using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("wrapline")]
[AmbientProperty("WrapLine")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class WrapLineLayoutRendererWrapper : WrapperLayoutRendererBase
{
	public int WrapLine { get; set; } = 80;

	protected override string Transform(string text)
	{
		if (WrapLine <= 0)
		{
			return text;
		}
		int num = WrapLine;
		if (text.Length <= num)
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder(text.Length + text.Length / num * "\n".Length);
		for (int i = 0; i < text.Length; i += num)
		{
			if (num + i > text.Length)
			{
				num = text.Length - i;
			}
			stringBuilder.Append(text.Substring(i, num));
			if (num + i < text.Length)
			{
				stringBuilder.Append("\n");
			}
		}
		return stringBuilder.ToString();
	}
}

using NLog.LayoutRenderers;
using NLog.Layouts;

namespace NLog.Targets;

public abstract class TargetWithLayout : Target
{
	private const string DefaultLayoutText = "${longdate}|${level:uppercase=true}|${logger}|${message:withexception=true}";

	private static LayoutRenderer[] DefaultLayout => new LayoutRenderer[7]
	{
		new LongDateLayoutRenderer(),
		new LiteralLayoutRenderer("|"),
		new LevelLayoutRenderer
		{
			Uppercase = true
		},
		new LiteralLayoutRenderer("|"),
		new LoggerNameLayoutRenderer(),
		new LiteralLayoutRenderer("|"),
		new MessageLayoutRenderer
		{
			WithException = true
		}
	};

	public virtual Layout Layout { get; set; }

	protected TargetWithLayout()
	{
		Layout = new SimpleLayout(DefaultLayout, "${longdate}|${level:uppercase=true}|${logger}|${message:withexception=true}");
	}
}

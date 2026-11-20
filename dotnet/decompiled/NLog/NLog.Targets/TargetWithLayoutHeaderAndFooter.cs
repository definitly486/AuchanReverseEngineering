using NLog.Layouts;

namespace NLog.Targets;

public abstract class TargetWithLayoutHeaderAndFooter : TargetWithLayout
{
	private Layout _layout;

	public override Layout Layout
	{
		get
		{
			return _layout;
		}
		set
		{
			if (value is LayoutWithHeaderAndFooter layoutWithHeaderAndFooter)
			{
				base.Layout = value;
				_layout = layoutWithHeaderAndFooter.Layout;
			}
			else if (base.Layout is LayoutWithHeaderAndFooter layoutWithHeaderAndFooter2)
			{
				layoutWithHeaderAndFooter2.Layout = value;
				_layout = value;
			}
			else
			{
				base.Layout = new LayoutWithHeaderAndFooter
				{
					Layout = value
				};
				_layout = value;
			}
		}
	}

	public Layout? Footer
	{
		get
		{
			return (base.Layout as LayoutWithHeaderAndFooter)?.Footer;
		}
		set
		{
			if (base.Layout is LayoutWithHeaderAndFooter layoutWithHeaderAndFooter)
			{
				layoutWithHeaderAndFooter.Footer = value;
			}
			else if (value != null)
			{
				base.Layout = new LayoutWithHeaderAndFooter
				{
					Layout = base.Layout,
					Footer = value
				};
			}
		}
	}

	public Layout? Header
	{
		get
		{
			return (base.Layout as LayoutWithHeaderAndFooter)?.Header;
		}
		set
		{
			if (base.Layout is LayoutWithHeaderAndFooter layoutWithHeaderAndFooter)
			{
				layoutWithHeaderAndFooter.Header = value;
			}
			else if (value != null)
			{
				base.Layout = new LayoutWithHeaderAndFooter
				{
					Layout = base.Layout,
					Header = value
				};
			}
		}
	}

	protected TargetWithLayoutHeaderAndFooter()
	{
		Layout layout = base.Layout;
		_layout = ((layout is LayoutWithHeaderAndFooter layoutWithHeaderAndFooter) ? layoutWithHeaderAndFooter.Layout : layout);
	}
}

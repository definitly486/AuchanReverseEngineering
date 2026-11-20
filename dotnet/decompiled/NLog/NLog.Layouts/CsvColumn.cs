using NLog.Config;

namespace NLog.Layouts;

[NLogConfigurationItem]
public class CsvColumn
{
	internal CsvQuotingMode? _quoting;

	public string Name { get; set; }

	public Layout Layout { get; set; }

	public CsvQuotingMode Quoting
	{
		get
		{
			return _quoting ?? CsvQuotingMode.Auto;
		}
		set
		{
			_quoting = value;
		}
	}

	public CsvColumn()
		: this(string.Empty, NLog.Layouts.Layout.Empty)
	{
	}

	public CsvColumn(string name, Layout layout)
	{
		Name = name;
		Layout = layout;
	}
}

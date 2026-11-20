using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.Layouts;

[Layout("CsvLayout")]
[ThreadAgnostic]
[AppDomainFixedOutput]
public class CsvLayout : LayoutWithHeaderAndFooter
{
	[ThreadAgnostic]
	[AppDomainFixedOutput]
	internal sealed class CsvHeaderLayout : Layout
	{
		private readonly CsvLayout _parent;

		private string? _headerOutput;

		public CsvHeaderLayout(CsvLayout parent)
		{
			_parent = parent;
		}

		protected override void InitializeLayout()
		{
			_headerOutput = null;
			base.InitializeLayout();
		}

		private string GetHeaderOutput()
		{
			return _headerOutput ?? (_headerOutput = BuilderHeaderOutput());
		}

		private string BuilderHeaderOutput()
		{
			StringBuilder stringBuilder = new StringBuilder();
			_parent.RenderHeader(stringBuilder);
			return stringBuilder.ToString();
		}

		internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
		{
		}

		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			return GetHeaderOutput();
		}

		protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
		{
			target.Append(GetHeaderOutput());
		}
	}

	private string _actualColumnDelimiter;

	private string _doubleQuoteChar;

	private char[] _quotableCharacters;

	private Layout[]? _precalculateLayouts;

	[ArrayParameter(typeof(CsvColumn), "column")]
	public IList<CsvColumn> Columns { get; } = new List<CsvColumn>();

	public bool WithHeader { get; set; } = true;

	public CsvColumnDelimiterMode Delimiter { get; set; }

	public CsvQuotingMode Quoting { get; set; } = CsvQuotingMode.Auto;

	public string QuoteChar { get; set; } = "\"";

	public string CustomColumnDelimiter { get; set; } = string.Empty;

	public CsvLayout()
	{
		base.Layout = this;
		base.Header = new CsvHeaderLayout(this);
		base.Footer = null;
		ResolveQuoteChars(QuoteChar, out _actualColumnDelimiter, out _doubleQuoteChar, out _quotableCharacters);
	}

	protected override void InitializeLayout()
	{
		if (!WithHeader)
		{
			base.Header = null;
		}
		base.InitializeLayout();
		ResolveQuoteChars(QuoteChar, out _actualColumnDelimiter, out _doubleQuoteChar, out _quotableCharacters);
		_precalculateLayouts = ResolveLayoutPrecalculation(Columns.Select((CsvColumn cln) => cln.Layout));
		foreach (CsvColumn column in Columns)
		{
			if (string.IsNullOrEmpty(column.Name))
			{
				throw new NLogConfigurationException("CsvLayout: Contains invalid CsvColumn with unassigned Name-property");
			}
		}
	}

	private void ResolveQuoteChars(string quoteChar, out string actualColumnDelimiter, out string doubleQuoteChar, out char[] quotableCharacters)
	{
		actualColumnDelimiter = ResolveColumnDelimiter(Delimiter);
		quotableCharacters = (quoteChar + "\r\n" + actualColumnDelimiter).ToCharArray();
		doubleQuoteChar = quoteChar + quoteChar;
	}

	private string ResolveColumnDelimiter(CsvColumnDelimiterMode delimiter)
	{
		switch (delimiter)
		{
		case CsvColumnDelimiterMode.Auto:
			return CultureInfo.CurrentCulture.TextInfo.ListSeparator;
		case CsvColumnDelimiterMode.Comma:
			return ",";
		case CsvColumnDelimiterMode.Semicolon:
			return ";";
		case CsvColumnDelimiterMode.Pipe:
			return "|";
		case CsvColumnDelimiterMode.Tab:
			return "\t";
		case CsvColumnDelimiterMode.Space:
			return " ";
		case CsvColumnDelimiterMode.Custom:
			if (!string.IsNullOrEmpty(CustomColumnDelimiter))
			{
				return CustomColumnDelimiter;
			}
			return ";";
		default:
			return ";";
		}
	}

	protected override void CloseLayout()
	{
		_precalculateLayouts = null;
		base.CloseLayout();
	}

	internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
	{
		PrecalculateBuilderInternal(logEvent, target, _precalculateLayouts);
	}

	protected override string GetFormattedMessage(LogEventInfo logEvent)
	{
		return RenderAllocateBuilder(logEvent);
	}

	protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		for (int i = 0; i < Columns.Count; i++)
		{
			Layout layout = Columns[i].Layout;
			RenderColumnLayout(logEvent, layout, Columns[i]._quoting ?? Quoting, target, i);
		}
	}

	private void RenderColumnLayout(LogEventInfo logEvent, Layout columnLayout, CsvQuotingMode quoting, StringBuilder target, int i)
	{
		if (i != 0)
		{
			target.Append(_actualColumnDelimiter);
		}
		if (quoting == CsvQuotingMode.All)
		{
			target.Append(QuoteChar);
		}
		int length = target.Length;
		columnLayout.Render(logEvent, target);
		if (length != target.Length && ColumnValueRequiresQuotes(quoting, target, length))
		{
			string text = target.ToString(length, target.Length - length);
			target.Length = length;
			if (quoting != CsvQuotingMode.All)
			{
				target.Append(QuoteChar);
			}
			target.Append(text.Replace(QuoteChar, _doubleQuoteChar));
			target.Append(QuoteChar);
		}
		else if (quoting == CsvQuotingMode.All)
		{
			target.Append(QuoteChar);
		}
	}

	private void RenderHeader(StringBuilder sb)
	{
		LogEventInfo logEvent = LogEventInfo.CreateNullEvent();
		for (int i = 0; i < Columns.Count; i++)
		{
			CsvColumn csvColumn = Columns[i];
			Layout layout = NLog.Layouts.Layout.FromLiteral(csvColumn.Name);
			layout.Initialize(base.LoggingConfiguration);
			RenderColumnLayout(logEvent, layout, csvColumn._quoting ?? Quoting, sb, i);
		}
	}

	private bool ColumnValueRequiresQuotes(CsvQuotingMode quoting, StringBuilder sb, int startPosition)
	{
		switch (quoting)
		{
		case CsvQuotingMode.Nothing:
			return false;
		case CsvQuotingMode.All:
			if (QuoteChar.Length == 1)
			{
				return sb.IndexOf(QuoteChar[0], startPosition) >= 0;
			}
			return sb.IndexOfAny(_quotableCharacters, startPosition) >= 0;
		default:
			return sb.IndexOfAny(_quotableCharacters, startPosition) >= 0;
		}
	}

	public override string ToString()
	{
		return ToStringWithNestedItems(Columns, (CsvColumn c) => c.Name);
	}
}

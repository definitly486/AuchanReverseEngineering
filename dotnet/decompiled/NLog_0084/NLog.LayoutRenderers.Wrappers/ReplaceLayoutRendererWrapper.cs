using System;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("replace")]
[AppDomainFixedOutput]
[ThreadAgnostic]
public sealed class ReplaceLayoutRendererWrapper : WrapperLayoutRendererBase
{
	private string _searchFor = string.Empty;

	private string _searchForOriginal = string.Empty;

	private string _replaceWith = string.Empty;

	private string _replaceWithOriginal = string.Empty;

	public string SearchFor
	{
		get
		{
			return _searchForOriginal ?? _searchFor;
		}
		set
		{
			_searchForOriginal = value;
			_searchFor = SimpleLayout.Evaluate(value, base.LoggingConfiguration, null, false);
		}
	}

	public string ReplaceWith
	{
		get
		{
			return _replaceWithOriginal ?? _replaceWith;
		}
		set
		{
			_replaceWithOriginal = value;
			_replaceWith = SimpleLayout.Evaluate(value, base.LoggingConfiguration, null, false);
		}
	}

	public bool IgnoreCase { get; set; }

	public bool WholeWords { get; set; }

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if (string.IsNullOrEmpty(SearchFor))
		{
			throw new NLogConfigurationException("Replace-LayoutRenderer SearchFor-property must be assigned. Searching for blank value not supported.");
		}
		if (_searchForOriginal != null)
		{
			_searchFor = SimpleLayout.Evaluate(_searchForOriginal, base.LoggingConfiguration);
		}
		if (_replaceWithOriginal != null)
		{
			_replaceWith = SimpleLayout.Evaluate(_replaceWithOriginal, base.LoggingConfiguration);
		}
	}

	protected override string Transform(string text)
	{
		if (IgnoreCase || WholeWords)
		{
			StringComparison comparison = (IgnoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			return StringHelpers.Replace(text, _searchFor, _replaceWith, comparison, WholeWords);
		}
		return text.Replace(_searchFor, _replaceWith);
	}
}

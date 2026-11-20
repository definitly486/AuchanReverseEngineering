namespace NLog.Config;

internal interface IIncludeContext
{
	bool IncludeEventProperties { get; set; }

	bool IncludeScopeProperties { get; set; }

	bool IncludeScopeNested { get; set; }
}

using System;
using CsvHelper.Configuration.Attributes;

namespace Auchan.Common.Logs;

public class Log
{
	[Name("date")]
	public DateTime DateTime { get; set; }

	[Name("logLevel")]
	public LogLevel LogLevel { get; set; }

	[Name("logType")]
	public LogType LogType { get; set; }

	[Name("systemType")]
	public SystemType SystemType { get; set; }

	[Name("name")]
	public string Name { get; set; } = "";

	[Name("description")]
	public string Description { get; set; } = "";
}

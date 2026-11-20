using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Parameter)]
public class HeaderAttribute(string header) : Attribute()
{
	public string Header { get; } = header;
}

using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Interface)]
public class HeadersAttribute : Attribute
{
	public string[] Headers { get; } = headers ?? Array.Empty<string>();

	public HeadersAttribute(params string[] headers)
	{
	}
}

using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class QueryUriFormatAttribute(UriFormat uriFormat) : Attribute()
{
	public UriFormat UriFormat { get; } = uriFormat;
}

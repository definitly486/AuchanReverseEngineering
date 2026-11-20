using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Parameter)]
public class AuthorizeAttribute(string scheme = "Bearer") : Attribute()
{
	public string Scheme { get; } = scheme;
}

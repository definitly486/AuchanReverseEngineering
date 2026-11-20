using System;
using System.Net.Http;

namespace Refit;

public abstract class HttpMethodAttribute(string path) : Attribute()
{
	public abstract HttpMethod Method { get; }

	public virtual string Path { get; protected set; } = path;
}

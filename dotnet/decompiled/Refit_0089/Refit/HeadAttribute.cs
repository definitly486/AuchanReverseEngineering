using System;
using System.Net.Http;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class HeadAttribute : HttpMethodAttribute
{
	public override HttpMethod Method => HttpMethod.Head;

	public HeadAttribute(string path)
		: base(path)
	{
	}
}

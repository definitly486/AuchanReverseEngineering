using System;
using System.Net.Http;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class GetAttribute : HttpMethodAttribute
{
	public override HttpMethod Method => HttpMethod.Get;

	public GetAttribute(string path)
		: base(path)
	{
	}
}

using System;
using System.Net.Http;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class PutAttribute : HttpMethodAttribute
{
	public override HttpMethod Method => HttpMethod.Put;

	public PutAttribute(string path)
		: base(path)
	{
	}
}

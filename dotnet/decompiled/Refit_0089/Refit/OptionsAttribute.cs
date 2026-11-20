using System;
using System.Net.Http;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class OptionsAttribute : HttpMethodAttribute
{
	public override HttpMethod Method => new HttpMethod("OPTIONS");

	public OptionsAttribute(string path)
		: base(path)
	{
	}
}

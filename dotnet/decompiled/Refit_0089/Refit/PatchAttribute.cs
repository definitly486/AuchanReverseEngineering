using System;
using System.Net.Http;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class PatchAttribute : HttpMethodAttribute
{
	public override HttpMethod Method => new HttpMethod("PATCH");

	public PatchAttribute(string path)
		: base(path)
	{
	}
}

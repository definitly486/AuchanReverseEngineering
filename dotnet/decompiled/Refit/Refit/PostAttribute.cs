using System;
using System.Net.Http;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class PostAttribute : HttpMethodAttribute
{
	public override HttpMethod Method => HttpMethod.Post;

	public PostAttribute(string path)
		: base(path)
	{
	}
}

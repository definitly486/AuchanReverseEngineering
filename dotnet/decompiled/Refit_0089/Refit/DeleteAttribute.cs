using System;
using System.Net.Http;

namespace Refit;

[AttributeUsage(AttributeTargets.Method)]
public class DeleteAttribute : HttpMethodAttribute
{
	public override HttpMethod Method => HttpMethod.Delete;

	public DeleteAttribute(string path)
		: base(path)
	{
	}
}

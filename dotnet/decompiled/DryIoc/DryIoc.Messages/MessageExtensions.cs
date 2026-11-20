using System.Threading.Tasks;

namespace DryIoc.Messages;

public static class MessageExtensions
{
	public static async Task<EmptyResponse> ToEmptyResponse(this Task task)
	{
		await task;
		return EmptyResponse.Value;
	}
}

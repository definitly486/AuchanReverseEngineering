using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DryIoc.Messages;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct EmptyResponse
{
	public static readonly EmptyResponse Value = default(EmptyResponse);

	public static readonly Task<EmptyResponse> Task = System.Threading.Tasks.Task.FromResult(Value);
}

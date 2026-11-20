using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DryIoc.Messages;

public class BroadcastMessageHandler<M> : IMessageHandler<M, EmptyResponse> where M : IMessage<EmptyResponse>
{
	private readonly IEnumerable<IMessageHandler<M, EmptyResponse>> _handlers;

	public BroadcastMessageHandler(IEnumerable<IMessageHandler<M, EmptyResponse>> handlers)
	{
		_handlers = handlers;
	}

	public async Task<EmptyResponse> Handle(M message, CancellationToken cancellationToken)
	{
		await Task.WhenAll(_handlers.Select((IMessageHandler<M, EmptyResponse> h) => h.Handle(message, cancellationToken)));
		return EmptyResponse.Value;
	}
}

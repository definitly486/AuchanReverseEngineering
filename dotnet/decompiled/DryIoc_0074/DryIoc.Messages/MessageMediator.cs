using System.Threading;
using System.Threading.Tasks;

namespace DryIoc.Messages;

public class MessageMediator
{
	private readonly IResolver _resolver;

	public MessageMediator(IResolver resolver)
	{
		_resolver = resolver;
	}

	public Task<R> Send<M, R>(M message, CancellationToken cancellationToken) where M : IMessage<R>
	{
		return _resolver.Resolve<IMessageHandler<M, R>>().Handle(message, cancellationToken);
	}

	public Task Send<M>(M message, CancellationToken cancellationToken) where M : IMessage<EmptyResponse>
	{
		return _resolver.Resolve<IMessageHandler<M, EmptyResponse>>().Handle(message, cancellationToken);
	}
}

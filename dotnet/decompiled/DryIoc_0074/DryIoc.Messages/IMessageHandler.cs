using System.Threading;
using System.Threading.Tasks;

namespace DryIoc.Messages;

public interface IMessageHandler<in M, R> where M : IMessage<R>
{
	Task<R> Handle(M message, CancellationToken cancellationToken);
}
public interface IMessageHandler<in M> : IMessageHandler<M, EmptyResponse> where M : IMessage<EmptyResponse>
{
}

using System.Threading;
using System.Threading.Tasks;

namespace DryIoc.Messages;

public abstract class AsyncMessageHandler<M, R> : IMessageHandler<M, R> where M : IMessage<R>
{
	protected abstract Task<R> Handle(M message, CancellationToken cancellationToken);

	async Task<R> IMessageHandler<M, R>.Handle(M message, CancellationToken cancellationToken)
	{
		return await Handle(message, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DryIoc.Messages;

public interface IMessageMiddleware<in M, R>
{
	int RelativeOrder { get; }

	Task<R> Handle(M message, CancellationToken cancellationToken, Func<Task<R>> nextMiddleware);
}

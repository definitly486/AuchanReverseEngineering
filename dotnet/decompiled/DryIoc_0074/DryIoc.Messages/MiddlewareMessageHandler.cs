using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DryIoc.Messages;

public class MiddlewareMessageHandler<M, R> : IMessageHandler<M, R> where M : IMessage<R>
{
	private readonly IMessageHandler<M, R> _handler;

	private readonly IEnumerable<IMessageMiddleware<M, R>> _middlewares;

	public MiddlewareMessageHandler(IMessageHandler<M, R> handler, IEnumerable<IMessageMiddleware<M, R>> middlewares)
	{
		_handler = handler;
		_middlewares = middlewares;
	}

	public Task<R> Handle(M message, CancellationToken cancellationToken)
	{
		return _middlewares.OrderBy((IMessageMiddleware<M, R> x) => x.RelativeOrder).Reverse().Aggregate<IMessageMiddleware<M, R>, Func<Task<R>>>(() => _handler.Handle(message, cancellationToken), (Func<Task<R>> f, IMessageMiddleware<M, R> middleware) => () => middleware.Handle(message, cancellationToken, f))();
	}
}

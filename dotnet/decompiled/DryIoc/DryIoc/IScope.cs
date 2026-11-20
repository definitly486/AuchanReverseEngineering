using System;
using System.Collections;
using System.Collections.Generic;
using DryIoc.FastExpressionCompiler.LightExpression;

namespace DryIoc;

public interface IScope : IEnumerable<IScope>, IEnumerable, IDisposable
{
	IScope Parent { get; }

	object Name { get; }

	bool IsDisposed { get; }

	bool TryGet(out object item, int id);

	object GetOrAddViaFactoryDelegate(int id, FactoryDelegate createValue, IResolverContext r);

	object GetOrAddViaFactoryDelegateWithDisposalOrder(int id, FactoryDelegate createValue, IResolverContext r, int disposalOrder);

	object TryGetOrAddWithoutClosure(int id, IResolverContext resolveContext, Expression expr, Func<IResolverContext, Expression, object> createValue, int disposalOrder = 0);

	T TrackDisposable<T>(T disposable, int disposalOrder = 0) where T : IDisposable;

	void SetOrAdd(int id, object item);

	void SetUsed(int hash, Type type, object instance);

	bool TryGetUsed(int hash, Type type, out object instance);

	IScope Clone(bool withDisposables);
}

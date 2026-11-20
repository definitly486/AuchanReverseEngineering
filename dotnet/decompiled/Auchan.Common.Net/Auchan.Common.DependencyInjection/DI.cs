using System;
using DryIoc;

namespace Auchan.Common.DependencyInjection;

public static class DI
{
	private static IContainer? _container;

	public static IResolver ResolverBecauseConstructorInjectionIsNotPossible => _container ?? throw new InvalidOperationException("Resolver is not initialized");

	internal static void Setup(IContainer container)
	{
		if (_container != null)
		{
			throw new InvalidOperationException("Container is already initialized!");
		}
		_container = container;
	}
}

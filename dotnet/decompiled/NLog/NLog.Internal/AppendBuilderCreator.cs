using System;
using System.Text;

namespace NLog.Internal;

internal struct AppendBuilderCreator : IDisposable
{
	private static readonly StringBuilderPool _builderPool = new StringBuilderPool(Environment.ProcessorCount * 2);

	private StringBuilderPool.ItemHolder _builder;

	public StringBuilder Builder => _builder.Item;

	public AppendBuilderCreator(bool mustBeEmpty)
	{
		_builder = _builderPool.Acquire();
	}

	public void Dispose()
	{
		_builder.Dispose();
	}
}

using System;
using System.Collections.Generic;
using NLog.LayoutRenderers;

namespace NLog.Config;

internal sealed class LayoutRendererFactory : Factory<LayoutRenderer, LayoutRendererAttribute>
{
	private readonly Dictionary<string, FuncLayoutRenderer> _funcRenderers = new Dictionary<string, FuncLayoutRenderer>(StringComparer.OrdinalIgnoreCase);

	public LayoutRendererFactory(ConfigurationItemFactory parentFactory)
		: base(parentFactory)
	{
	}

	public override void Clear()
	{
		_funcRenderers.Clear();
		base.Clear();
	}

	public void RegisterFuncLayout(string itemName, FuncLayoutRenderer renderer)
	{
		itemName = FactoryExtensions.NormalizeName(itemName);
		lock (ConfigurationItemFactory.SyncRoot)
		{
			_funcRenderers[itemName] = renderer;
		}
	}

	public override bool TryCreateInstance(string typeAlias, out LayoutRenderer? result)
	{
		typeAlias = FactoryExtensions.NormalizeName(typeAlias);
		if (_funcRenderers.Count > 0)
		{
			lock (ConfigurationItemFactory.SyncRoot)
			{
				if (_funcRenderers.TryGetValue(typeAlias, out FuncLayoutRenderer value))
				{
					result = value;
					return true;
				}
			}
		}
		return base.TryCreateInstance(typeAlias, out result);
	}
}

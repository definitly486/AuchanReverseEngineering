using System;
using System.Linq;
using DryIoc;

namespace Auchan.Common.DependencyInjection;

internal static class ViewModelRegistry
{
	public static void Register(IRegistrator registrator)
	{
		foreach (Type item in from type in typeof(ViewModelRegistry).Assembly.GetTypes()
			where type.IsClass && !type.IsAbstract && !type.Name.EndsWith("ItemViewModel") && type.Name.EndsWith("ViewModel")
			select type)
		{
			registrator.Register(item);
		}
	}
}

using DryIoc;

namespace Auchan.Common.DeveloperMenu;

internal static class DevMenuDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<ChangeEnvironmentUseCase>();
	}
}

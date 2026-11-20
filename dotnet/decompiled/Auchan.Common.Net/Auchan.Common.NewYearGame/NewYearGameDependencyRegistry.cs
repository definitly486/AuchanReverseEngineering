using DryIoc;

namespace Auchan.Common.NewYearGame;

public static class NewYearGameDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<INewYearGameService, NewYearGameService>();
	}
}

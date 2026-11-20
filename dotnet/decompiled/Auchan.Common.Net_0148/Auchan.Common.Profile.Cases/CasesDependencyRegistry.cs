using Auchan.Common.Extensions;
using Auchan.Common.Profile.Cases.Api;
using DryIoc;

namespace Auchan.Common.Profile.Cases;

internal static class CasesDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.AddRefitClient<ICasesApi>();
		registrator.Register<CasesService>(Reuse.Singleton);
	}
}

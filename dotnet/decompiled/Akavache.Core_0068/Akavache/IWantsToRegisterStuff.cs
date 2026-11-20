using Splat;

namespace Akavache;

internal interface IWantsToRegisterStuff
{
	void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver);
}

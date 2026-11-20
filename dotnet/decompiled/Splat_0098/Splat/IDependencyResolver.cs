using System;

namespace Splat;

public interface IDependencyResolver : IReadonlyDependencyResolver, IMutableDependencyResolver, IDisposable
{
}

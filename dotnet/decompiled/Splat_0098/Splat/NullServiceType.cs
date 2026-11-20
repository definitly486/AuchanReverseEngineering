using System;

namespace Splat;

public class NullServiceType(Func<object?> factory)
{
	public Func<object?> Factory { get; } = factory;
}

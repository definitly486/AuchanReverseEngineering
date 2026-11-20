using System.Collections.Generic;

namespace System.Diagnostics;

public abstract class DistributedContextPropagator
{
	public delegate void PropagatorSetterCallback(object? carrier, string fieldName, string fieldValue);

	private static DistributedContextPropagator s_current = CreateDefaultPropagator();

	internal static readonly char[] s_trimmingSpaceCharacters = new char[2] { ' ', '\t' };

	public abstract IReadOnlyCollection<string> Fields { get; }

	public static DistributedContextPropagator Current => s_current;

	public abstract void Inject(Activity? activity, object? carrier, PropagatorSetterCallback? setter);

	public static DistributedContextPropagator CreateDefaultPropagator()
	{
		return W3CPropagator.Instance;
	}
}

using System;
using System.Runtime.CompilerServices;

namespace DryIoc;

public static class RequestTools
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool MatchFactoryConditionAndMetadata(this Request request, ServiceDetails details, Factory factory)
	{
		Setup setup = factory.Setup;
		if (setup.Condition == null || setup.Condition(request))
		{
			if (details.MetadataKey != null || details.Metadata != null)
			{
				return setup.MatchesMetadata(details.MetadataKey, details.Metadata);
			}
			return true;
		}
		return false;
	}

	public static bool MatchFactoryReuse(this Request r, Factory f)
	{
		return f.Reuse?.CanApply(r) ?? true;
	}

	public static bool MatchGeneratedFactory(this Request r, Factory f)
	{
		if (f.GeneratedFactories != null)
		{
			return f.GetGeneratedFactoryOrDefault(r, ifErrorReturnDefault: true) != null;
		}
		return true;
	}

	public static Factory MatchGeneratedFactoryByReuseAndConditionOrNull(this Request r, Factory f)
	{
		if (!f.Setup.OpenResolutionScope && !r.MatchFactoryReuse(f))
		{
			return null;
		}
		Func<Request, bool> condition = f.Setup.Condition;
		if (condition != null && !condition(r))
		{
			return null;
		}
		if (f.GeneratedFactories != null)
		{
			return f.GetGeneratedFactoryOrDefault(r, ifErrorReturnDefault: true);
		}
		return f;
	}
}
